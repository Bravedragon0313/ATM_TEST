const fs = require('fs')
const crypto = require('crypto')
const got = require('got')
const baseX = require('base-x')
const querystring = require('querystring')
const config = require('../config/software_config.json')

const E = require('./error')
const selfSign = require('./self_sign')
const HOST = config.trader.host
const PORT = config.trader.port
const PROTOCOL = config.trader.protocol
const ALPHA_BASE = '0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ $%*+-./:'

const bsAlpha = baseX(ALPHA_BASE)

// [caHash, token, Buffer.from(hostname)]
function extractHostname(totem) {
    return totem.slice(64).toString()
}
//function pair (totemStr) {
//  const expectedCaHash = totemStr.slice(0, 32)
//  const token = totemStr.slice(32, 64).toString('hex')
//  const hexToken = token.toString('hex')
//  const caHexToken = crypto.createHash('sha256').update(hexToken).digest('hex')

//  return got(`${HOST}:${PORT}/Pairing/ca?token=${totemStr}`)
//    .then(r => {
//      const ca = r.body
//      console.log("here response ca", ca)
//      const caHash = crypto.createHash('sha256').update(ca).digest()
//      console.log("here caHash", caHash)
//      console.log("here excepted hash", expectedCaHash)
//      //if (!caHash.equals(expectedCaHash)) throw new E.CaHashError()
//      return got.post(`${HOST}:${PORT}/Pairing/pair`)
//        .then(r => {
//          const connectioninfo = r.body
//          console.log(connectioninfo);
//          fs.writeFileSync('./data/connection_info.json', connectioninfo)
//        })
//    })
//   .catch(err => {
//    const caHash = crypto.createHash('sha256').update(caHexToken).digest()
//    console.log("here caHash", caHash)
//    console.log(err)
//    throw new Error("Pairing error - Please make sure you have a stable network connection and that you are using the right QR Code")
//   })
//}

function pair(totemStr, clientCert, connectionInfoPath, model) {

    const totem = Buffer.from(bsAlpha.decode(totemStr))
    console.log("here totem", totem)
    const hostname = extractHostname(totem)
    const expectedCaHash = totem.slice(0, 32)
    const token = totem.slice(32, 64).toString('hex')
    const hexToken = token.toString('hex')
    const caHexToken = crypto.createHash('sha256').update(hexToken).digest('hex')

    const initialOptions = {
        json: true,
        key: clientCert.key,
        cert: clientCert.cert,
        rejectUnauthorized: false
    }

    //TODO: protocol, hostname and port should be extracted from totem - not being partially used from configuration
    return got(`${PROTOCOL}://${hostname}:${PORT}/Pairing/ca?token=${caHexToken}`, initialOptions)
        .then(r => {

            const ca = r.body.ca
            console.log("here response ca", ca)

            const caHash = crypto.createHash('sha256').update(ca).digest()

            console.log("here caHash", caHash)

            console.log("here excepted hash", expectedCaHash)

            if (!caHash.equals(expectedCaHash)) throw new E.CaHashError()

            const options = {
                key: clientCert.key,
                cert: clientCert.cert,
                ca
            }

            const query = querystring.stringify({ token: hexToken, model })

            //TODO: protocol, hostname and port should be extracted from totem - not being partially used from configuration
            return got.post(`${PROTOCOL}://${hostname}:${PORT}/Pairing/pair?${query}`, options)
                .then(() => {
                    const connectionInfo = {
                        host: hostname,
                        ca
                    }

                    fs.writeFileSync(connectionInfoPath, JSON.stringify(connectionInfo))
                    console.log("here query", query)
                })

        })
        .catch(err => {

            const caHash = crypto.createHash('sha256').update(caHexToken).digest()
            console.log("here caHash", caHash)
            console.log(err)

            throw new Error("Pairing error - Please make sure you have a stable network connection and that you are using the right QR Code")

        })

}

function unpair(connectionInfoPath) {
    fs.unlinkSync(connectionInfoPath)
}

function isPaired(connectionInfoPath) {
    return !!connectionInfo(connectionInfoPath)
}

function connectionInfo(connectionInfoPath) {
    try {
        return JSON.parse(fs.readFileSync(connectionInfoPath))
    } catch (e) {
        return null
    }
}

function init(certPath) {
    return selfSign.generateCertificate()
        .then(cert => {
            fs.writeFileSync(certPath.key, cert.key)
            fs.writeFileSync(certPath.cert, cert.cert)
            return cert
        })
}

function getCert(certPath) {
    try {
        return {
            key: fs.readFileSync(certPath.key),
            cert: fs.readFileSync(certPath.cert)
        }
    } catch (e) {
        return null
    }
}

module.exports = { init, pair, unpair, isPaired, connectionInfo, getCert }

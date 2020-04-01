const path = require('path')
const atm_baseMachineRoot = path.resolve(__dirname, '..')
const atm_baseAdminServerRoot = path.resolve(atm_baseMachineRoot, '..', 'atm_base-admin-server')

const Haikunator = require('haikunator')
const atm_baseAdminServerPairing = require(path.resolve(atm_baseAdminServerRoot, 'lib', 'pairing'))
const pairing = require('../lib/pairing')

const suppliedTotem = process.argv[2]

const fetchTotem = suppliedTotem
? Promise.resolve(suppliedTotem)
: atm_baseAdminServerPairing.totem('localhost', name)

const haikunator = new Haikunator()
const name = haikunator.haikunate({tokenLength: 0})

fetchTotem
.then(totem => {
  const clientCert = pairing.getCert(path.resolve(atm_baseMachineRoot, 'data', 'cert.json'))
  const connectionInfoPath = path.resolve(atm_baseMachineRoot, 'data', 'connection_info.json')

  console.log('DEBUG1: %s, %s', totem, connectionInfoPath)
  return pairing.pair(totem, clientCert, connectionInfoPath)
  .then(r => {
    console.log('paired.')
    process.exit(0)
  })
})
.catch(e => {
  console.log(e)
  process.exit(1)
})

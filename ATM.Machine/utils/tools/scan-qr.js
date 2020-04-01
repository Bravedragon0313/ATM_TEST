const _ = require('lodash/fp')
const scanner = require('../../lib/scanner')

const config = require('../../config/device_config.json')

_config = _.merge(config)
scanner.config(_config.scanner)

scanner.scanMainQR('BTC', (err, address) => {
    if (err) throw err

    console.log(address)
})

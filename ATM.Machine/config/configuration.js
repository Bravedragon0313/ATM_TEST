'use strict'

const fs = require('fs')
const path = require('path')

const _ = require('lodash/fp')

const SOFTWARE_CONFIG = require('../config/software_config.json')
const DEVICE_CONFIG = require('../config/device_config.json')

exports.loadConfig = function (commandLine) {
    const otherConfig = {
        brain: {
            wsPort: commandLine.port || 9001,
            wsHost: commandLine.host || 'localhost'
        }
    }

    const config = _.mergeAll([{}, DEVICE_CONFIG, SOFTWARE_CONFIG, commandLine, otherConfig])
    delete config._

    if (config.mockBv) config.billValidator.rs232.device = config.mockBv
    if (commandLine.dataPath) config.brain.dataPath = commandLine.dataPath

    if (config.mockCam) {
        const fakeLicense = fs.readFileSync(path.join(__dirname,
            '../utils/mock_data/compliance/license.jpg'))
        const pdf417Data = fs.readFileSync(path.join(__dirname,
            '../utils/mock_data/compliance/nh.dat'))

        const mockCamConfig = {
            pairingData: config.mockPair,
            qrData: config.brain.mockCryptoQR,
            pk: config.brain.mockPK,
            pdf417Data: pdf417Data,
            fakeLicense: fakeLicense
        }

        config.scanner = _.assign(config.scanner, {
            mock: {
                data: mockCamConfig
            }
        })
    }

    return config
}

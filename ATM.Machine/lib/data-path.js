const path = require('path')
const deviceConfig = require('../config/device_config.json')

module.exports = path.resolve(__dirname, '..', deviceConfig.brain.dataPath)

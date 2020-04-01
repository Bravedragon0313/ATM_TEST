// for now, make this b/w compat with trader.js calls

const got = require('got')
const uuid = require('uuid')
const argv = require('minimist')(process.argv.slice(2))
const config = require('../config/software_config.json')
const PORT = config.trader.port
const RETRY_INTERVAL = 5000
const RETRY_TIMEOUT = 60000

function retrier (timeout) {
  const maxRetries = timeout / RETRY_INTERVAL

  return (retry, err) => {
    if (err.statusCode && err.statusCode === 403) return 0
    if (retry >= maxRetries) return 0

    return RETRY_INTERVAL
  }
}

function request (configVersion, globalOptions, options) {
  const protocol = globalOptions.protocol
  const connectionInfo = globalOptions.connectionInfo

  if (!connectionInfo) return Promise.resolve()

  const host = protocol === 'http:' ? 'localhost' : connectionInfo.host
  const requestId = uuid.v4()
  const date = new Date().toISOString()
  const headers = {date, 'request-id': requestId}
  if (options.body) headers['content-type'] = 'application/json'
  if (configVersion) headers['config-version'] = configVersion
  const repeatUntilSuccess = !options.noRetry
  const retryTimeout = options.retryTimeout || RETRY_TIMEOUT

  const retries = repeatUntilSuccess
    ? retrier(retryTimeout)
    : null

  const gotOptions = {
    protocol,
    host,
    port: PORT,
    agent: false,
    cert: globalOptions.clientCert.cert,
    key: globalOptions.clientCert.key,
    ca: connectionInfo.ca,
    rejectUnauthorized: true,
    method: options.method,
    path: options.path,
    body: options.body,
    retries,
    timeout: 10000,
    headers,
    json: true
  }

  return got(options.path, gotOptions)
}

module.exports = {request}


const coins = {
    AUC: {
        displayScale: 5,
        unitScale: 8,
        zeroConf: true
    }
}

module.exports = { coins, depositUrl, parseUrl, formatAddress, createWallet }

const plugins = {
    AUC: require('./auc')
}

function depositUrl(cryptoCode, address, amountStr) {
    if (!address) return null
    const plugin = coinPlugin(cryptoCode)
    return plugin.depositUrl(address, amountStr)
}

function coinPlugin(cryptoCode) {
    const plugin = plugins[cryptoCode]
    if (!plugin) throw new Error(`Unsupported coin: ${cryptoCode}`)
    return plugin
}

function parseUrl(cryptoCode, network, url) {
    const plugin = coinPlugin(cryptoCode)
    return plugin.parseUrl(network, url)
}

function formatAddress(cryptoCode, address) {
    if (!address) return null

    const plugin = coinPlugin(cryptoCode)
    if (!plugin.formatAddress) return address
    return plugin.formatAddress(address)
}

function createWallet(cryptoCode) {
    const plugin = coinPlugin(cryptoCode)
    if (!plugin.createWallet) {
        throw new Error(`${cryptoCode} paper wallet printing is not supported`)
    }

    return plugin.createWallet()
}

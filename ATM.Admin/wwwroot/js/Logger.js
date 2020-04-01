var logger = {
    logInfo: function log(data) {
        if (typeof console !== 'undefined') {
            console.info(data);
        }
    },
    logError: function log(data) {

        if (typeof console !== 'undefined') {
            console.error(data);
        }
    }
};
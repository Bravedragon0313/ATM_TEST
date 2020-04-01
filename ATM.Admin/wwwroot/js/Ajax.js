var ajax = {
    isDebug: false,
    log: function log(data, isInfo) {
        if (ajax.isDebug === true) {
            if (isInfo !== null && isInfo === false) {
                logger.logError(data);
            } else {
                logger.logInfo(data);
            }
        }
    },
    createRequest: function createRequest() {
        ajax.log("ajax.createRequest");

        if (typeof XMLHttpRequest !== 'undefined') {
            ajax.log("ajax.XMLHttpRequest");
            return new XMLHttpRequest();
        }

        var versions = [
            "MSXML2.XmlHttp.6.0",
            "MSXML2.XmlHttp.5.0",
            "MSXML2.XmlHttp.4.0",
            "MSXML2.XmlHttp.3.0",
            "MSXML2.XmlHttp.2.0",
            "Microsoft.XmlHttp"
        ];

        var xhr = null;

        for (var i = 0; i < versions.length; i++) {
            try {
                ajax.log("ajax." + versions[i]);
                xhr = new ActiveXObject(versions[i]);
                break;
            } catch (e) {
                ajax.log(versions[i], false);
            }
        }

        return xhr;
    },
    sendRequest: function sendRequest(url, callback, method, data, isAsync) {
        ajax.log("ajax.send");
        if (isAsync === "undefined") {
            isAsync = true;
        }

        ajax.log("ajax.send isAsync: " + isAsync);
        ajax.log("ajax.send url: " + url);
        ajax.log("ajax.send callback: " + callback);
        ajax.log("ajax.send method: " + method);
        ajax.log("ajax.send data: " + data);

        var req = ajax.createRequest();

        req.open(method, url, isAsync);

        req.onreadystatechange = function () {

            ajax.log("ajax.send readyState: " + req.readyState);

            if (req.readyState === 4) {
                ajax.log("ajax.send response: " + req.responseText);
                req.responseJson = JSON.parse(req.responseText);
                callback(req);
            }
        };

        if (method === 'POST') {
            req.setRequestHeader('Content-type', 'application/json; charset=utf-8');
            //req.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        }

        req.send(data);
    },
    getData: function getData(url, data, callback, async) {
        var query = [];
        for (let key in data) {
            if (Object.prototype.hasOwnProperty.call(data, key)) {
                query.push(encodeURIComponent(key) + '=' + encodeURIComponent(data[key]));
            }
        }

        ajax.sendRequest(url + (query.length ? '?' + query.join('&') : ''), callback, 'GET', null, async);
    },
    postData: function postData(url, data, callback, async) {
        ajax.sendRequest(url, callback, 'POST', JSON.stringify(data), async);
    }
};
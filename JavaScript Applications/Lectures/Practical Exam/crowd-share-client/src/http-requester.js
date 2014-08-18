define(['jquery'], function($) {
    var HttpRequester = (function() {
        var makeHttpRequest = function(url, type, data, headers) {
            // this returns a jQuery promise
            return $.ajax({
                url: url,
                type: type,
                data: data ? JSON.stringify(data) : "",
                beforeSend: function(xhr) {
                    if (headers) {
                        for (var i = 0; i < headers.length; i++) {
                            xhr.setRequestHeader(headers[i].name, headers[i].value);
                        }
                    }
                },
                contentType: "application/json",
                timeout: 5000
            });
        };

        var getJSON = function(url, data, headers) {
            return makeHttpRequest(url, "GET", data, headers);
        };

        var postJSON = function(url, data, headers) {
            return makeHttpRequest(url, "POST", data, headers);
        };
        
        var putJSON = function(url, data, headers) {
            return makeHttpRequest(url, "PUT", data, headers);
        };

        return {
            getJSON: getJSON,
            postJSON: postJSON,
            putJSON: putJSON
        }
    }());

    return HttpRequester;
});
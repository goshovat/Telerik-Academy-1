define(['jquery'], function($){

    var httpRequester = (function() {

        function getJSON (options) {
            var requestUrl, deferred;
            deferred = $.Deferred();

            options = options || {};
            requestUrl = options.url;

            $.ajax({
                url: requestUrl,
                type: 'GET',
                contentType: 'application/json',
                accepts: 'application/json',
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (err) {
                    deferred.reject(err);
                }
            });

            return deferred.promise();
        }

        function postJSON(options) {
            var requestUrl, data, deferred;
            deferred = $.Deferred();
            options = options || {};
            requestUrl = options.url;
            data = options.data || null;

            $.ajax({
                url: requestUrl,
                type: 'POST',
                data: JSON.stringify(data),
                contentType: 'application/json',
                accepts: 'application/json',
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (err) {
                    deferred.reject(err);
                }
            });

            return deferred.promise();
        }

        return {
            getJSON: getJSON,
            postJSON: postJSON
        };
    }());

    return httpRequester;
});
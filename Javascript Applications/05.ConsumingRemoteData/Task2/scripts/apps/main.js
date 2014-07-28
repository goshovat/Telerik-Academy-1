require(['jquery', 'oauth'], function ($) {

    function getAuthPromise() {
        OAuth.initialize('CziAuC3ZsmDC0hUGDtv-Mo8eIZM');
        var authPromise = OAuth.popup('twitter', {
            cache: true
        });

        return authPromise;
    }

    $('#authorize').on('click', function () {
        getAuthPromise()
            .done(function () {
                $('#container').text('Authenticated succesfully. Your login authorization has been cached.');
            })
            .fail(function (err) {
                $('#container').text(err);
            });
    });

    $('#get-user').on('click', function () {
        var username = $('#username').val(),
            messageCount = parseInt($('#count').val(), 10),
            requestUrl = 'https://api.twitter.com/1.1/statuses/user_timeline.json?count=' + messageCount + '&screen_name=' + username;

        getAuthPromise()
            .done(function (result) {
                result.get(requestUrl)
                    .done(function (response) {
                        var $container = $('#container');
                        var elements = response.map(function (item) {
                            return item.text;
                        });

                        $container.html('');
                        for (var i = 0; i < elements.length; i += 1) {
                            $container.append($('<p/>').text(elements[i]));
                        }
                    })
                    .fail(function (error) {
                        $('#container').text(error);
                    });
            })
    });
});
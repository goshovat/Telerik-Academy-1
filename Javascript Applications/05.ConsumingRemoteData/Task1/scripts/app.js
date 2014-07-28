(function () {
    'use strict';
    require.config({
        paths: {
            'jquery' : 'libs/jquery-2.1.1.min'
        }
    });

    require(['jquery', 'modules/http-requester'], function ($, httpRequester) {
        var url = 'http://crowd-chat.herokuapp.com/posts';

        $('#get-button').on('click', function(){
            httpRequester.getJSON({
                url: url
            })
                .then(
                function(data) {
                    var elements = data.map(function(item){
                        return 'User: ' + item.by + ' Text: ' + item.text + ' | ';
                    });
                    $('#container').text(elements);
                    console.log(data);
                },
                function(err) {
                    $('#container').text(err);
                }
            );
        });

        $('#post-button').on('click', function() {
            httpRequester.postJSON({
                url: url,
                data: {
                    user: 'ivan',
                    text: 'ko staa'
                }
            })
                .then(
                function(data){
                    $('#container').text(data);
                },
                function(err){
                    $('#container').text(err);
                });
        });
    });
}());
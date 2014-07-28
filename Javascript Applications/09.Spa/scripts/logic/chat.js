define(['jquery', 'handlebars', 'http-requester'], function ($, Handlebars, httpRequester) {
    var url = 'http://crowd-chat.herokuapp.com/posts';

    function IsValidMessage(username) {
        if(username && username.length > 0) {
            return true;
        }

        return false;
    }

    function postMessage() {
        var message, username;

        message = $('#message-to-post').val();
        if(IsValidMessage(message)) {
            username = localStorage.getItem('username');

            httpRequester.postJSON({
                url: url,
                data: {
                    user: username,
                    text: message
                }
            })
                .then(
                function () {
                    showMessages();
                },
                function () {
                    alert('Error while posting!');
                });
        } else {
            alert('Message cannot be whitespace!');
        }
    }

    function showMessages() {
        httpRequester.getJSON({
            url: url
        })
            .then(
            function (messages) {
                var postTemplateHTML, postTemplate;
                $.ajax({
                    url: 'view/chat.html',
                    success: function (chatHTML) {
                        var username = localStorage.getItem('username'),
                            div;

                        postTemplateHTML = $(chatHTML).html();

                        postTemplate = Handlebars.compile(postTemplateHTML);

                        $('#container').html(postTemplate({
                                username: username,
                                messages: messages
                            })
                        );

                        div = document.getElementById('scroller');
                        div.scrollTop = div.scrollHeight;

                        $('#post-message').on('click', postMessage);
                        $('#log-out').on('click', function() {
                           localStorage.removeItem('username');

                            window.location = '#/log-in';
                        });
                    },
                    error: function () {
                        alert('Cannot load log-in!');
                    }
                });
            },
            function () {
                alert('Error while getting messages!');
            }
        );
    }

    function show() {
        if(localStorage.getItem('username')) {
            showMessages();
        } else {
            window.location = '#/log-in';
        }
    }

    return {
        show: show
    };
});
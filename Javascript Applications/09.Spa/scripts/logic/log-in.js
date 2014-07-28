define(['jquery'], function($) {
    function IsValidUsername(username) {
        if(username && username.length > 4) {
            return true;
        }

        return false;
    }

    function success(logInHTML) {
        if(localStorage.getItem('username')) {
            window.location = '#/chat';
        } else {
            $('#container').html(logInHTML);

            $('#submit').on('click', function () {
                var username = $('#username').val();
                if (IsValidUsername(username)) {
                    localStorage.setItem('username', username);
                    window.location = '#/chat';
                } else {
                    alert('Username should be longer!');
                }
            });
        }
    }

    var show = function() {
        $.ajax({
            url: 'view/log-in.html',
            success: success,
            error:function() {
                alert('Cannot load log-in!');
            }
        });
    };

    return {
        show: show
    };
});
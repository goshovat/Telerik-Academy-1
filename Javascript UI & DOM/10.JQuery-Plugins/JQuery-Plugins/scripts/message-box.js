/// <reference path="jquery-1.11.1.min.js" />
(function ($) {
    $.fn.messageBox = function () {
        var $this = $(this);

        function showBlock(message, type) {
            var color = type === 'success' ? 'green' : 'red';

            $this.text(message)
                .css({
                    'border': '1px solid black',
                    'border-radius': '10px',
                    'padding': '10px 10px 10px 10px',
                    'position': 'absolute',
                    'widht': '200px',
                    'top': '300px',
                    'left': '300px',
                    'background-color': color
                })
                .fadeIn(1000)
                .delay(3000)
                .fadeOut(1000);
        }

        return {
            success: function (message) {
                showBlock(message, "success");
                return $this;
            },
            error: function (message) {
                showBlock(message, "error");
                return $this;
            }
        };
    };
})(jQuery); 

var msgBox = $('#message-box').messageBox(); 

$('#success').on('click', function () {
    msgBox.success('Success message');
}); 

$('#error').on('click', function () {
    msgBox.error('Error message');
});
 

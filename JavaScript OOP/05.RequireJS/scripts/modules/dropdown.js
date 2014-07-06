define(['jquery'], function ($) {
    $.fn.dropdown = function () {
        var $this = $(this),
            options = $this.children(),
            $selectionContainer = $('#selected-option div');

        $this.hide();

        for (var j = 0; j < options.length; j++) {
            $(options[j]).on('click', function () {
                var $target = $(this);
                $selectionContainer.find('strong').text($target.find('strong').text());
                $selectionContainer.find('p').text($target.find('p').text());
                $selectionContainer.find('img').attr('src', $target.find('img').attr('src'));

                $this.slideUp('fast');
            });
        }

        $selectionContainer.on('click', function () {
            $this.slideToggle('fast');
        })

        return $this;
    };
});
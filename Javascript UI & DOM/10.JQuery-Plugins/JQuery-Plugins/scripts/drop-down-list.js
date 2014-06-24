/// <reference path="jquery-1.11.1.min.js" />
(function ($) {
    $.fn.dropdown = function () {
        var $this = $(this),
            options = $this.children(),
            $container = $('<div>').addClass('dropdown-list-container'),
            $ul = $('<ul>').addClass('dropdown-list-options'),
            $selectionContainer = $('<li>')
                .addClass('dropdown-list-selectionContainer')
                .text('Numbers')
                .attr('data-value', 'not-selected')
                .appendTo($ul);

        $this.hide();

        for (var j = 0; j < options.length; j++) {
            $('<li>')
                .text(options[j].innerHTML)
                .attr('data-value', options[j].value)
                .on('click', function () {
                    $target = $(this);
                    $('.dropdown-list-options li[selected]').removeAttr('selected');
                    $target.attr('selected', 'selected');
                    $selectionContainer.text($target.text());
                    $selectionContainer.attr('data-value', $target.attr('data-value'));
                    $('.dropdown-list-options li:not(.dropdown-list-selectionContainer)').slideUp('fast');

                })
                .appendTo($ul);
        }

        $allOptions = $selectionContainer.siblings().hide();

        $selectionContainer.on('click', function () {
            $allOptions.slideToggle();
        })
        $ul.appendTo($container);
        $container.appendTo($('body'));

        return $this;
    };
})(jQuery);

$('#dropdown').dropdown();
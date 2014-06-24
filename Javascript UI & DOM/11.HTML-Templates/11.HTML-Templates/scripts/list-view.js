/// <reference path="jquery-1.11.1.min.js" />
(function ($) {
    $.fn.listview = function (collection) {
        var $this = $(this),
            $templateNode,
            $postTemplateHtml,
            $postTemplate,
            templateID = $this.attr('data-template');

        if (templateID === undefined) {
            $postTemplateHtml = $this.html();
            $this.html('');
        }
        else {
            $templateNode = $('#' + templateID);
            $postTemplateHtml = $templateNode.html();
        }

        $postTemplate = Handlebars.compile($postTemplateHtml);

        for (var i in collection) {
            $this.append($postTemplate(collection[i]));
        }

        return $this;
    }
})(jQuery);

var books = [{
    title: "JavaScript"
}, {
    title: "C#"
}, {
    title: "Core JAVA"
}, {
    title: "Core HTML5 Canvas"
}, {
    title: "JavaScript Patterns"
}];

var students = [{
    number: 1,
    name: "Peter Petrov",
    mark: 5.5
}, {
    number: 2,
    name: "Stamat Georgiev",
    mark: 4.7
}, {
    number: 3,
    name: "Maria Todorova",
    mark: 6
}, {
    number: 4,
    name: "Georgi Geshov",
    mark: 3.7
}];

$('#books-list').listview(books);
$('#students-table').listview(students);
$("#books-list-without-data-template").listview(books);
$("#students-table-without-data-template").listview(students);
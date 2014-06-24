/// <reference path="jquery-1.11.1.min.js" />
var $insertHere = $('#insert-here'),
    $divToInsertBefore = $('<div/>').text('I am before'),
    $divToInsertAfter = $('<div/>').text('I am after');

$divToInsertBefore.insertBefore($insertHere);
$divToInsertAfter.insertAfter($insertHere);

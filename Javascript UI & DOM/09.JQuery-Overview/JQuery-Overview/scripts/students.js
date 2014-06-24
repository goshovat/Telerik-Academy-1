/// <reference path="jquery-1.11.1.min.js" />
var $table = $('<table/>').css('border-collapse', 'collapse'),
    students = [
    {
        firstName: "Ivan",
        lastName: "Ivanov",
        grade: 3
    },
    {
        firstName: "Milcho",
        lastName: "Milchev",
        grade: 2
    },
    {
        firstName: "Kolio",
        lastName: "Kolev",
        grade: 4
    },
    {
        firstName: "Gosho",
        lastName: "Peshev",
        grade: 1
    }],
    $header = $('<thead/>');

$header.append($('<th/>').text('First name'));
$header.append($('<th/>').text('Last name'));
$header.append($('<th/>').text('Grade'));

$table.html($header);

for (var i in students) {
    var $row = $('<tr/>');
    $row.append($('<td/>').text(students[i].firstName));
    $row.append($('<td/>').text(students[i].lastName));
    $row.append($('<td/>').text(students[i].grade));

    $table.append($row);
}

$('body').append($table);

$('th, td').css('border', '1px solid black')
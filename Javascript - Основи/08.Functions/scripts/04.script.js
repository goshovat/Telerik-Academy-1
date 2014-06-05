/*Exercise 4 - Write a function to count the number of divs on the web page*/

function getDivNumber() {
    /*global document*/
    var divNumber = document.getElementsByTagName('div').length;
    return divNumber;
}

function main() {
    /*global document, console, jsConsole*/
    jsConsole.writeLine('There are ' + getDivNumber() + ' divs in the document.');
    console.log('There are ' + getDivNumber() + ' divs in the document.');
    jsConsole.writeLine('');
    console.log('');
}

/*Exercise 1 - Write a script that prints all the numbers from 1 to N*/

function printNumbers() {
    /*global document, console, jsConsole*/
    var stopNumber = jsConsole.readInteger('#n');

    for (var number = 1; number <= stopNumber; number++) {
        jsConsole.writeLine(number);
        console.log(number);
    }

    jsConsole.writeLine('');
    console.log('');
}
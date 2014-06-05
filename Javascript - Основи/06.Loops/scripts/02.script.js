/*Exercise 2 - Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time*/

function findNumbers() {
    /*global document, console, jsConsole*/
    var stopNumber = jsConsole.readInteger('#n');

    for (var number = 1; number <= stopNumber; number++) {
        if (number % 21 !== 0) {
            jsConsole.writeLine(number);
            console.log(number);
        }
    }
 
    jsConsole.writeLine('');
    console.log('');
}
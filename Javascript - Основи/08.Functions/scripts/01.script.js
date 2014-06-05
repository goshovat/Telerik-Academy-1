/*Exercise 1 - Write a function that returns the last digit of 
 given integer as an English word. 
 Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine"*/

function findDigitName(digit) {
    var digitName = "";

    switch (digit) {
    case 0:
        digitName = "zero";
        break;
    case 1:
        digitName = "one";
        break;
    case 2:
        digitName = "two";
        break;
    case 3:
        digitName = "three";
        break;
    case 4:
        digitName = "four";
        break;
    case 5:
        digitName = "five";
        break;
    case 6:
        digitName = "six";
        break;
    case 7:
        digitName = "seven";
        break;
    case 8:
        digitName = "eight";
        break;
    case 9:
        digitName = "nine";
        break;
    }

    return digitName;
}

function findLastDigitName() {
    /*global document, console, jsConsole*/
    var number = jsConsole.readInteger('#number');

    jsConsole.writeLine('The last digit of the number ' +
        number + ' is ' + findDigitName(number % 10));
    console.log('The last digit of the number ' + number +
        ' is ' + (findDigitName(number % 10)));
    jsConsole.writeLine('');
    console.log('');
}

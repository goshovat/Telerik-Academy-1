/*Exercise 2 - Write a function that reverses the digits of 
 given decimal number. Example: 256 -> 652*/

function reverseDigits(number) {
    var reversedNumber = 0,
        digit;

    do {
        digit = number % 10;
        reversedNumber = reversedNumber * 10 + digit;
        number = parseInt(number / 10, 10);
    }
    while (number !== 0);

    return reversedNumber;
}

function main() {
    /*global document, console, jsConsole*/
    var number = jsConsole.readInteger('#number');

    jsConsole.writeLine('The number ' + number +
        ' in a reversed order is ' + reverseDigits(number));
    console.log('The number ' + number +
        ' in a reversed order is ' + (reverseDigits(number)));
    jsConsole.writeLine('');
    console.log('');
}

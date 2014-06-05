/*Exercise 4 - Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732 -> true.*/

function checkThirdDigit() {
    var number = jsConsole.readInteger("#number"),
        thirdDigit = Math.abs((parseInt(number / 100))% 10);

    if (thirdDigit !== 7) {
        jsConsole.writeLine("Third digit of the number " + number + " is not 7!");
        console.log("Third digit of the number " + number + " is not 7!");
    } else {
        jsConsole.writeLine("Third digit of the number " + number + " is 7!");
        console.log("Third digit of the number " + number + " is 7!");
    }
}
/*Exercise 5 - Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.*/

function checkThirdDigit() {
    var number = jsConsole.readInteger("#number"),
        mask = 1 << 3,
        thirdBit = number & mask;

    if (thirdBit === 0) {
        jsConsole.writeLine("Third bit of the number " + number + " is 0!");
        console.log("Third bit of the number " + number + " is 0!");
    } else {
        jsConsole.writeLine("Third bit of the number " + number + " is 1!");
        console.log("Third bit of the number " + number + " is 1!");
    }
}
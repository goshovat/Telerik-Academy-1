/*Exercise 2 - Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.*/

function isDivisibleBy3and5() {
    var firstVar = jsConsole.readInteger("#first");

    if (firstVar % 35 === 0) {
        jsConsole.writeLine("firstVar = " + firstVar + " is divisible by 5 and 7 at the same time.");
        console.log("firstVar = " + firstVar + " is divisible by 5 and 7 at the same time.");
    } else {
        jsConsole.writeLine("firstVar = " + firstVar + " is not divisible by 5 and 7 at the same time.");
        console.log("firstVar = " + firstVar + " is not divisible by 5 and 7 at the same time.");
    }
}
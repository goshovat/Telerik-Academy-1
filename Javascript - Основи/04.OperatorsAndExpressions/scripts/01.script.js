/*Exercise 1 - Write an expression that checks if given integer is odd or even.*/

function isEvenOrOdd() {
    var firstVar = jsConsole.readInteger("#tb-first");

    jsConsole.writeLine("firstVar = " + firstVar + " is " + (firstVar % 2 === 0 ? "even" : "odd"));
    console.log("firstVar = " + firstVar + " is " + (firstVar % 2 === 0 ? "even" : "odd"));
}
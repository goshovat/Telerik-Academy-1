/*Exercise 3 - Write a script that finds the biggest of three integers using nested if statements.*/

function findBiggest() {
    /*global console, jsConsole*/
    var firstNumber = jsConsole.readInteger("#first"),
        secondNumber = jsConsole.readInteger("#second"),
        thirdNumber = jsConsole.readInteger("#third");

    if (firstNumber > secondNumber)
    {
        if (firstNumber > thirdNumber)
        {
            jsConsole.writeLine("The first number " + firstNumber + " is the biggest!");
            console.log("The first number " + firstNumber + " is the biggest!");
        } else {
            jsConsole.writeLine("The third number " + thirdNumber + " is the biggest!");
            console.log("The third number " + thirdNumber + " is the biggest!");
        }
    } else {
        if (secondNumber > thirdNumber)
        {
            jsConsole.writeLine("The second number " + secondNumber + " is the biggest!");
            console.log("The second number " + secondNumber + " is the biggest!");
        } else {
            jsConsole.writeLine("The third number " + thirdNumber + " is the biggest!");
            console.log("The third number " + thirdNumber + " is the biggest!");
        }
    }
}
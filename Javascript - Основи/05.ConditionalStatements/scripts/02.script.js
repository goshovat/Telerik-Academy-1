/*Exercise 2 - Write a script that shows the sign (+ or -) of the product of three real numbers 
    without calculating it. Use a sequence of if statements.*/

function findSign() {
    /*global console, jsConsole*/
    var firstNumber = jsConsole.readInteger("#first"),
        secondNumber = jsConsole.readInteger("#second"),
        thirdNumber = jsConsole.readInteger("#third");

    if (firstNumber > 0 && secondNumber > 0 && thirdNumber > 0) {
        jsConsole.writeLine("The sign of product of the three numbers is positive.");
        console.log("The sign of product of the three numbers is positive.");
    } else if (firstNumber < 0 && secondNumber < 0 && thirdNumber > 0) {
        jsConsole.writeLine("The sign of product of the three numbers is positive.");
        console.log("The sign of product of the three numbers is positive.");
    } else if (firstNumber < 0 && secondNumber > 0 && thirdNumber < 0) {
        jsConsole.writeLine("The sign of product of the three numbers is positive.");
        console.log("The sign of product of the three numbers is positive.");
    } else if (firstNumber > 0 && secondNumber < 0 && thirdNumber < 0) {
        jsConsole.writeLine("The sign of product of the three numbers is positive.");
        console.log("The sign of product of the three numbers is positive.");
    } else if (firstNumber === 0 || secondNumber === 0 || thirdNumber === 0) {
        jsConsole.writeLine("The product is 0.");
        console.log("The product is 0.");
    } else {
        jsConsole.writeLine("The sign of product of the three numbers is negative.");
        console.log("The sign of product of the three numbers is negative.");
    }
}
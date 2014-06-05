/*Exercise 4 - Sort 3 real values in descending order using nested if statements.*/

function sort() {
    /*global console, jsConsole*/
    var firstNumber = jsConsole.readFloat("#first"),
        secondNumber = jsConsole.readFloat("#second"),
        thirdNumber = jsConsole.readFloat("#third"),
        tempNumber;

    if (firstNumber > secondNumber && firstNumber > thirdNumber) {
        if (secondNumber < thirdNumber) {
            tempNumber = secondNumber;
            secondNumber = thirdNumber;
            thirdNumber = tempNumber;
        }
    }
    else if (secondNumber > firstNumber && secondNumber > thirdNumber) {
        tempNumber = firstNumber;
        firstNumber = secondNumber;
        secondNumber = tempNumber;

        if (secondNumber < thirdNumber) {
            tempNumber = secondNumber;
            secondNumber = thirdNumber;
            thirdNumber = tempNumber;
        }
    }
    else {
        tempNumber = firstNumber;
        firstNumber = thirdNumber;
        thirdNumber = tempNumber;

        if (secondNumber < thirdNumber) {
            tempNumber = secondNumber;
            secondNumber = thirdNumber;
            thirdNumber = tempNumber;
        }
    }

    jsConsole.writeLine("First: " + firstNumber + " Second: " + secondNumber + " Third: " + thirdNumber);
    console.log("First: " + firstNumber + " Second: " + secondNumber + " Third: " + thirdNumber);
}
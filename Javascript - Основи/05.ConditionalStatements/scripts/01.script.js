/*Exercise 1 - Write an if statement that examines two integer variables 
 and exchanges their values if the first one is greater than the second one.*/

function exchangeValues() {
    /*global document, console, jsConsole*/
    var firstVar = jsConsole.readInteger("#first"),
        secondVar = jsConsole.readInteger("#second");

    if (firstVar > secondVar) {
        firstVar = firstVar + secondVar;
        secondVar = firstVar - secondVar;
        firstVar = firstVar - secondVar;

        jsConsole.writeLine("Numbers was exchanged:");
        console.log("Numbers was exchanged:");
        jsConsole.writeLine("firstVar = " + firstVar);
        console.log("firstVar = " + firstVar);
        jsConsole.writeLine("secondVar = " + secondVar);
        console.log("secondVar = " + secondVar);
    } else {
        jsConsole.writeLine("Numbers was not exchanged!");
        console.log("Numbers was not exchanged!");
    }
}
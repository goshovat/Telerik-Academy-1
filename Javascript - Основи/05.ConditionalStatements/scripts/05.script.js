/*Exercise 5 - Write script that asks for a digit and depending on the input 
 shows the name of that digit (in English) using a switch statement.*/

function findDigitName() {
    /*global console, jsConsole*/
    var digit = jsConsole.readInteger("#digit"),
        digitName;

    if (digit < 0 || digit > 9) {
        alert("You must enter a digit 0,1,2,3,4,5,6,7,8 or 9!");
    } else {
        switch (digit) {
            case 0:
                digitName = "Zero";
                break;
            case 1:
                digitName = "One";
                break;
            case 2:
                digitName = "Two";
                break;
            case 3:
                digitName = "Three";
                break;
            case 4:
                digitName = "Four";
                break;
            case 5:
                digitName = "Five";
                break;
            case 6:
                digitName = "Six";
                break;
            case 7:
                digitName = "Seven";
                break;
            case 8:
                digitName = "Eight";
                break;
            case 9:
                digitName = "Nine";
                break;
        }

        jsConsole.writeLine("The name of the digit " + digit + " is " + digitName);
        console.log("The name of the digit " + digit + " is " + digitName);
    }
}
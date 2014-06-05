/*Exercise 8 - Write a program that converts a number in the range [0...999] 
    to a text corresponding to its English pronunciation. Examples:
	0 -> "Zero" , 273 -> "Two hundred seventy three", 400 -> "Four hundred", 
    501 -> "Five hundred and one", 711 -> "Seven hundred and eleven"*/

function findName() {
    /*global console, jsConsole*/
    var number = jsConsole.readInteger("#number"),
        firstNumber,
        secondNumber,
        thirdNumber,
        numberName = "",
        flagThirdNumbe = 0;

    if (number < 0 || number > 999) {
        alert("You must enter a number in the range [0...999]");
    } else {
        firstNumber = parseInt(number / 100);
        secondNumber = (parseInt(number / 10)) % 10;
        thirdNumber = number % 10;

        switch (firstNumber) {
            case 1:
                numberName += "one hundred ";
                break;
            case 2:
                numberName += "two hundred ";
                break;
            case 3:
                numberName += "three hundred ";
                break;
            case 4:
                numberName += "four hundred ";
                break;
            case 5:
                numberName += "five hundred ";
                break;
            case 6:
                numberName += "six hundred ";
                break;
            case 7:
                numberName += "seven hundred ";
                break;
            case 8:
                numberName += "eight hundred ";
                break;
            case 9:
                numberName += "nine hundred ";
                break;
        }

        switch (secondNumber) {
            case 0:
                if (firstNumber != 0 && thirdNumber != 0) {
                    numberName += "and ";
                }
                break;
            case 1:
                flagThirdNumbe = 1;
                if (firstNumber != 0) {
                    numberName += "and ";
                }
                switch (thirdNumber) {
                    case 0:
                        numberName += "ten";
                        break;
                    case 1:
                        numberName += "eleven";
                        break;
                    case 2:
                        numberName += "twelve";
                        break;
                    case 3:
                        numberName += "thirteen";
                        break;
                    case 4:
                        numberName += "fourteen";
                        break;
                    case 5:
                        numberName += "fifteen";
                        break;
                    case 6:
                        numberName += "sixteen";
                        break;
                    case 7:
                        numberName += "seventeen";
                        break;
                    case 8:
                        numberName += "eighteen";
                        break;
                    case 9:
                        numberName += "nineteen";
                        break;
                }
                break;
            case 2:
                numberName += "twenty ";
                break;
            case 3:
                numberName += "thirty ";
                break;
            case 4:
                numberName += "forty ";
                break;
            case 5:
                numberName += "fifty ";
                break;
            case 6:
                numberName += "sixty ";
                break;
            case 7:
                numberName += "seventy ";
                break;
            case 8:
                numberName += "eighty ";
                break;
            case 9:
                numberName += "ninety ";
                break;
        }

        if (flagThirdNumbe == 0) {
            switch (thirdNumber) {
                case 0:
                    if (firstNumber == 0 && secondNumber == 0) {
                        numberName += "zero";
                    }
                    break;
                case 1:
                    numberName += "one";
                    break;
                case 2:
                    numberName += "two";
                    break;
                case 3:
                    numberName += "three";
                    break;
                case 4:
                    numberName += "four";
                    break;
                case 5:
                    numberName += "five";
                    break;
                case 6:
                    numberName += "six";
                    break;
                case 7:
                    numberName += "seven";
                    break;
                case 8:
                    numberName += "eight";
                    break;
                case 9:
                    numberName += "nine";
                    break;
            }
        }

        jsConsole.writeLine("The name of the number " + number + " is " + numberName);
        console.log("The name of the number " + number + " is " + numberName);
    }
}
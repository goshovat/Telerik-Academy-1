/*Exercise 7 - Write a script that finds the greatest of given 5 variables.*/

function findGreatestNumber() {
    /*global console, jsConsole*/
    var numbers = new Array(5),
        greatestNumber,
        index;
       
    numbers[0] = jsConsole.readInteger("#first");
    numbers[1] = jsConsole.readInteger("#second");
    numbers[2] = jsConsole.readInteger("#third");
    numbers[3] = jsConsole.readInteger("#fourth");
    numbers[4] = jsConsole.readInteger("#fifth");
    greatestNumber = numbers[0];

    for (index = 1; index < numbers.length; index++)
    {
        greatestNumber = (numbers[index] + greatestNumber + Math.abs(numbers[index] - greatestNumber)) / 2;
    }

    jsConsole.writeLine("The greatest number is " + greatestNumber);
    console.log("The greatest number is " + greatestNumber);
}
/*Exercise 1 - Write a script that allocates array of 20 integers and 
 initializes each element by its index multiplied by 5. Print the obtained array on the console.*/

function printArray() {
    /*global document, console, jsConsole*/
    var length = jsConsole.readInteger('#n'),
        integerArray = new Array(length);

    for (var index = 0; index < integerArray.length; index++)
    {
        integerArray[index] = index * 5;
        jsConsole.writeLine('Array[' + index + ']= ' + integerArray[index]);
        console.log('Array[' + index + ']= ' + integerArray[index]);
    }

    jsConsole.writeLine('');
    console.log('');
}
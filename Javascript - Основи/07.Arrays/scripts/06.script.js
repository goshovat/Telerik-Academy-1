/*Exercise 6 - Write a program that finds the most frequent number in an array. Example:
	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)*/

function findMostFrequentNumber() {
    /*global document, console, jsConsole*/
    var array = jsConsole.read('#array').split(' '),
    length,
    index = 0,
    countNumbers = 1,
    max = 1,
    frequentNumbers = new Array(1),
    i;

    //Parse element to int
    for (i = 0; i < array.length; i++) {
        array[i] = parseInt(array[i]);

        if (isNaN(array[i])) {
            array.splice(i, 1);
            i--;
        }
    }

    length = array.length;

    //Sort array
    array.sort(orderBy);
    frequentNumbers[0] = array[0];

    for (i = 1; i < length; i++) {
        if (array[i] === array[i - 1]) {
            countNumbers++;

            if (countNumbers > max) {
                max = countNumbers;
                index = 0;
                frequentNumbers = new Array(1);
                frequentNumbers[index] = array[i];
            } else if (countNumbers === max) {
                index++;
                frequentNumbers[index] = array[i];
            }
        } else {
            countNumbers = 1;
        }
    }

    jsConsole.writeLine("The most frequent number in the array is : ");

    if (max === 1) {
        for (i = 0; i < length; i++) {
            jsConsole.writeLine(array[i] + ' (' + max + ' time) ');
        }
    } else {
        for (i = 0; i < frequentNumbers.length; i++) {
            jsConsole.writeLine(frequentNumbers[i] + ' (' + max + ' time) ');
        }
    }

    jsConsole.writeLine('');
    console.log('');
}

function orderBy(a, b) {
    return (a === b) ? 0 : (a > b) ? 1 : -1;
}
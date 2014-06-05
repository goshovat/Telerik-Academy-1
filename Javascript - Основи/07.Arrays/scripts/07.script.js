/*Exercise 7 - Write a program that finds the index of given element in a sorted array of 
 integers by using the binary search algorithm (find it in Wikipedia).*/

function findIndex() {
    /*global document, console, jsConsole*/
    var array = jsConsole.read('#array').split(' '),
    numberForSearch = jsConsole.readInteger('#element'),
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

    var withOutDuplicates = array.filter(function (elem, index, self) {
        return index == self.indexOf(elem);
    });

    var isSorted = true;

    // Check if the array is not sorted ascending
    for (i = 0; i < withOutDuplicates.length - 1; i++) {
        if (withOutDuplicates[i] > withOutDuplicates[i + 1]) {
            isSorted = false;
            break;
        }
    }

    if (!isSorted) {
        withOutDuplicates.sort(orderBy);
    }

    for (i = 0; i < withOutDuplicates.length; i++) {
        jsConsole.writeLine('Element [' + i + '] = ' + withOutDuplicates[i]);
    }

    index = binarySearchElement(withOutDuplicates, numberForSearch);

    if (index === -1) {
        jsConsole.writeLine('The element ' + numberForSearch + ' is not in the array!!!');
    } else {
        jsConsole.writeLine('The element\'s index is ' + index);
    }

    jsConsole.writeLine('');
    console.log('');
}

function binarySearchElement(array, value) {
    var low = 0, high = array.length - 1, midpoint = 0;

    while (low <= high) {
        midpoint = parseInt(low + (high - low) / 2);

        // Check if the element is on the current position
        if (value === array[midpoint]) {
            return midpoint;
        } else if (value < array[midpoint]) {
            high = midpoint - 1;

        } else {
            low = midpoint + 1;
        }
    }
    // Return -1 when element was not found
    return -1;
}

function orderBy(a, b) {
    return (a === b) ? 0 : (a > b) ? 1 : -1;
}
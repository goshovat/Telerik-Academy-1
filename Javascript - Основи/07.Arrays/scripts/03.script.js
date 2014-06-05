/*Exercise 3 - Write a script that finds the maximal sequence of equal elements in an array.
		Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.*/

function findSequence() {
    /*global document, console, jsConsole*/
    var array = jsConsole.read('#array').split(' '),
    maxElements = 1,
    currentElements = 1,
    endPoint = 0,
    i,
    j;

    // Find the maximal sequence
    for (j = 1; j < array.length; j++) {
        if (array[j - 1] === array[j]) {
            currentElements++;
            if (maxElements < currentElements) {
                maxElements = currentElements;
            }
        } else {
            currentElements = 1;
        }
    }

    jsConsole.writeLine('The maximal sequence is with ' + maxElements + ' elements.');

    currentElements = 1;

    // Check if there are more than one sequence with maximal length
    for (j = 1; j < array.length; j++) {
        if (array[j - 1] === array[j]) {
            currentElements++;
            if (maxElements === currentElements) {
                endPoint = j + 1;
                printSequence(array, endPoint, maxElements);
            }
        } else {
            currentElements = 1;
        }
    }

    if (maxElements === 1) {
        for (i = 0; i < array.length; i++) {
            endPoint = i + 1;
            printSequence(array, endPoint, 1);
        }
    }

    jsConsole.writeLine('');
    console.log('');
}

// Print the sequence with equal elements
function printSequence(array, endPoint, maxElements) {
    jsConsole.writeLine("\nThe sequence looks like :");

    for (var i = endPoint - maxElements; i < endPoint; i++) {
        jsConsole.writeLine('Element[' + i + '] = ' + array[i]);
    }

    jsConsole.writeLine('');
}
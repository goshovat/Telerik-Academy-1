/*Exercise 4 - Write a script that finds the maximal increasing sequence in an array. 
 Example:{3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.*/

function findMaxIncreasingSequence() {
    /*global document, console, jsConsole*/
    var array = jsConsole.read('#array').split(' '),
    maxElements = 1,
    currentElements = 1,
    endPoint = 0,
    i,
    j;

    //Parse element to int
    for (i = 0; i < array.length; i++) {
        array[i] = parseInt(array[i]);

        if (isNaN(array[i])) {
            array.splice(i, 1);
            i--;
        }
    }

    // Find the maximal sequence
    for (j = 1; j < array.length; j++) {
        if (array[j - 1] === array[j] - 1) {
            currentElements++;
            if (maxElements < currentElements) {
                maxElements = currentElements;
            }
        } else {
            currentElements = 1;
        }
    }

    // Check if there are no sequences with increasing elements and finish the program if it is true
    if (maxElements === 1) {
        jsConsole.writeLine('There are no sequences with increasing elements!!!');
        return;
    }

    jsConsole.writeLine('The maximal sequence is with ' + maxElements + ' elements.');

    currentElements = 1;

    // Check if there are more than one sequence with maximal length
    for (j = 1; j < array.length; j++) {
        if (array[j - 1] === array[j] - 1) {
            currentElements++;
            if (maxElements === currentElements) {
                endPoint = j + 1;
                printSequence(array, endPoint, maxElements);
            }
        } else {
            currentElements = 1;
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
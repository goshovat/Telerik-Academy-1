/*Exercise 5 - Sorting an array means to arrange its elements in increasing order. 
Write a script to sort an array. Use the 'selection sort' algorithm: 
Find the smallest element, move it at the first position, 
find the smallest from the rest, move it at the second position, etc.
Hint: Use a second array*/

function sort() {
    /*global document, console, jsConsole*/
    var arrayToSort = jsConsole.read('#array').split(' '),
    min = Number.POSITIVE_INFINITY,
    index = 0,
    n = arrayToSort.length,
    i,
    j;

    //Parse element to int
    for (i = 0; i < arrayToSort.length; i++) {
        arrayToSort[i] = parseInt(arrayToSort[i]);

        if (isNaN(arrayToSort[i])) {
            arrayToSort.splice(i, 1);
            i--;
        }
    }
    
    n = arrayToSort.length;

    //Selection sort
    for (i = 0; i < n - 1; i++) {
        min = Number.POSITIVE_INFINITY;
        index = 0;
        for (j = i + 1; j < n; j++) {
            if (min > arrayToSort[j]) {
                min = arrayToSort[j]; // Get minimal value from the remaining elements
                index = j;
            }
        }

        // Check if the two elements are not sorted  and swap them
        if (min < arrayToSort[i])
        {
            arrayToSort[index] = arrayToSort[i];
            arrayToSort[i] = min;
        }
    }

    jsConsole.writeLine('The sorted array is : ');
    for (i = 0; i < n; i++)
    {
        jsConsole.writeLine(arrayToSort[i]);
    }

    jsConsole.writeLine('');
    console.log('');
}
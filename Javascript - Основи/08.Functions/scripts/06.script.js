/*Exercise 6 - Write a function that checks if the element at given position
in given array of integers is bigger than its two neighbors (when such exist).*/

function isNumberBiggerThanNeighbors(array, index) {
    var isBigger = false;

    if (array[index] > array[index - 1] &&
            array[index] > array[index + 1]) {
        isBigger = true;
    }

    return isBigger;
}

function main() {
    /*global document, console, jsConsole*/
    var array = jsConsole.read('#array').split(' '),
        index = jsConsole.readInteger('#index'),
        i;

    //Parse element to int
    for (i = 0; i < array.length; i += 1) {
        array[i] = parseInt(array[i], 10);

        if (isNaN(array[i])) {
            array.splice(i, 1);
            i -= 1;
        }
    }

    jsConsole.writeLine('Does the number at index ' + index +
        ' is bigger than its neighbors ? ' + isNumberBiggerThanNeighbors(array, index));
    console.log('Does the number at index ' + index +
        ' is bigger than its neighbors ? ' + isNumberBiggerThanNeighbors(array, index));
    jsConsole.writeLine('');
    console.log('');
}

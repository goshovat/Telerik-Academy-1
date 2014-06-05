/*Exercise 7 - Write a function that returns the index of the first element
in array that is bigger than its neighbors, or -1, if there’s no such element.
Use the function from the previous exercise.*/

function firstNumberBiggerThanNeighbors(array) {
    /*global isNumberBiggerThanNeighbors*/
    var index = -1,
        i;

    for (i = 1; i < array.length - 1; i += 1) {
        if (isNumberBiggerThanNeighbors(array, i)) {
            index = i;
            break;
        }
    }

    return index;
}

function main() {
    /*global document, console, jsConsole*/
    var array = jsConsole.read('#array').split(' '),
        index,
        i;

    //Parse element to int
    for (i = 0; i < array.length; i += 1) {
        array[i] = parseInt(array[i], 10);

        if (isNaN(array[i])) {
            array.splice(i, 1);
            i -= 1;
        }
    }

    index = firstNumberBiggerThanNeighbors(array);

    jsConsole.writeLine('There is an element in the array that is' +
        ' bigger than his neighbors - ' + (index === -1 ? 'False' : 'True'));
    console.log('There is an element in the array that is' +
        ' bigger than his neighbors - ' + (index === -1 ? 'False' : 'True'));

    if (index !== -1) {
        jsConsole.writeLine('The first number is ' + array[index] +
            ' at position ' + index);
        console.log('The first number is ' + array[index] +
            ' at position ' + index);
    }

    jsConsole.writeLine('');
    console.log('');
}

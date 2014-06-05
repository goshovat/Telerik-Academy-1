/*Exercise 5 - Write a function that counts how many times given 
    number appears in given array. Write a test function to check 
    if the function is working correctly.*/

function countNumber(array, number) {
    /*global document*/
    var counter = 0,
        i;

    for (i = 0; i < array.length; i += 1) {
        if (number === array[i]) {
            counter += 1;
        }
    }

    return counter;
}

function testCountNUmber() {
    /*global console, jsConsole*/
    var first = [2, 2, 2, 2, 2],
        secont = [3, 5, 4, 5, 2, 1, 10, 25],
        third = [1, 2, 3, 4, 5, 6],
        isCorrect = true;

    if (countNumber(first, 2) !== 5) {
        jsConsole.writeLine('Function countNumber is incorrect!!!');
        console.log('Function countNumber is incorrect!!!');
        jsConsole.writeLine('');
        console.log('');
        isCorrect = false;
    }

    if (countNumber(secont, 5) !== 2) {
        jsConsole.writeLine('Function countNumber is incorrect!!!');
        console.log('Function countNumber is incorrect!!!');
        jsConsole.writeLine('');
        console.log('');
        isCorrect = false;
    }

    if (countNumber(third, -52) !== 0) {
        jsConsole.writeLine('Function countNumber is incorrect!!!');
        console.log('Function countNumber is incorrect!!!');
        jsConsole.writeLine('');
        console.log('');
        isCorrect = false;
    }

    if (isCorrect) {
        jsConsole.writeLine('Function countNumber is correct.');
        console.log('Function countNumber is correct.');
        jsConsole.writeLine('');
        console.log('');
    }
}

function main() {
    /*global document, console, jsConsole*/
    var array = jsConsole.read('#array').split(' '),
        number = jsConsole.readInteger('#number'),
        i;

    //Parse element to int
    for (i = 0; i < array.length; i += 1) {
        array[i] = parseInt(array[i], 10);

        if (isNaN(array[i])) {
            array.splice(i, 1);
            i -= 1;
        }
    }

    jsConsole.writeLine('The number ' + number + ' appears ' +
        countNumber(array, number) + ' times in the array.');
    console.log('The number ' + number + ' appears ' +
        countNumber(array, number) + ' times in the array.');
    jsConsole.writeLine('');
    console.log('');
}

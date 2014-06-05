/*Exercise 2 - Write a script that compares two char arrays lexicographically (letter by letter).*/

function checkArrays() {
    /*global document, console, jsConsole*/
    var firstArr = jsConsole.read('#firstArr').split(''),
        secondArr = jsConsole.read('#secondArr').split(''),
        result;

    result = compare(firstArr, secondArr);

    switch (result) {
        case -1:
            jsConsole.writeLine('First array is lexicographically first.');
            console.log('First array is lexicographically first.');
            break;
        case 0:
            jsConsole.writeLine('The arrays are equals.');
            console.log('The arrays are equals.');
            break;
        case 1:
            jsConsole.writeLine('Second array is lexicographically first.');
            console.log('Second array is lexicographically first.');
            break;
        default:
    }

    jsConsole.writeLine('');
    console.log('');
}

// Returns -1 if first is before second, 0 if they are equal and 1 if second is before first
function compare(first, second) {
    var smallerLength = first.length < second.length ? first.length : second.length,
        areEquals = 0;

    for (var index = 0; index < smallerLength; index++) {
        if (first[index] < second[index]) {
            areEquals = -1;
            break;
        }
        else if (first[index] > second[index]) {
            areEquals = 1;
            break;
        }
    }

    if (areEquals === 0) {
        if(first.length > smallerLength){
            areEquals = 1;
        }
        else if (second.length > smallerLength) {
            areEquals = -1;
        }
    }

    return areEquals;
}
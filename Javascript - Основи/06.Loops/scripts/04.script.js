/*Exercise 4 - Write a script that finds the lexicographically smallest and largest property in document, window and navigator objects*/

function findProperties() {
    /*global document, navigator, window, console, jsConsole*/
    findSmallestProperty(window);
    findBiggestProperty(window);
    findSmallestProperty(navigator);
    findBiggestProperty(navigator);
    findSmallestProperty(document);
    findBiggestProperty(document);
    jsConsole.writeLine('');
    console.log('');
}

function findSmallestProperty(object) {
    var smallest = 'zzzzz';

    for (var property in object) {
        if (property < smallest) {
            smallest = property;
        }
    }

    jsConsole.writeLine('The ' + object + '\'s smallest lexicographically property  is ' + smallest);
    console.log('The ' + object + '\'s smallest lexicographically property  is ' + smallest);
}

function findBiggestProperty(object) {
    var biggest = 'aaaaaa';

    for (var property in object) {
        if (property > biggest) {
            biggest = property;
        }
    }

    jsConsole.writeLine('The ' + object + '\'s biggest lexicographically property  is ' + biggest);
    console.log('The ' + object + '\'s biggest lexicographically property  is ' + biggest);
}
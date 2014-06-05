/*Exercise 2 - Write a function that reverses the digits of 
 given decimal number. Example: 256 -> 652*/

function findAllOccurrences(word, text, caseSensitive) {
    var wordCount = 0,
        regularExpression = new RegExp('\\b' + word + '\\b', 'g');

    caseSensitive = caseSensitive || false;

    if (caseSensitive === true) {
        regularExpression = new RegExp('\\b' + word + '\\b', 'gi');
    }
        
    wordCount = text.match(regularExpression);
    return wordCount === null ? 0 : wordCount.length;
}

function main() {
    /*global document, console, jsConsole*/
    var word = jsConsole.read('#word'),
        text = jsConsole.read('#text');

    jsConsole.writeLine('(Case sensitive) The word ' + word + ' is ' +
        findAllOccurrences(word, text, true) + ' times in the text.');
    console.log('(Case insensitive) The word ' + word + ' is ' +
        findAllOccurrences(word, text, true) + ' times in the text.');
    jsConsole.writeLine('');
    console.log('');

    jsConsole.writeLine('(Case insensitive) The word ' + word + ' is ' +
       findAllOccurrences(word, text) + ' times in the text.');
    console.log('(Case insensitive) The word ' + word + ' is ' +
        findAllOccurrences(word, text) + ' times in the text.');
    jsConsole.writeLine('');
    console.log('');
}

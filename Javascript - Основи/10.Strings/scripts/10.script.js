/*Exercise 10 - Write a program that extracts from a given 
    text all palindromes, e.g. "ABBA", "lamal", "exe".
*/
/*global document, console, jsConsole*/

function extractPalindromes(doc) {
    var word,
        words,
        i,
        palindromes = [];
     
    doc = doc.toLowerCase();
    doc = doc.replace(".", " ").replace("!", " ").replace("?", " ")
        .replace("_", " ").replace("-", " ").replace(",", " ");
    words = doc.split(" ");

    for (i = 0; i < words.length; i += 1) {
        word = '';
        
        word = words[i].split('').reverse().join('');

        if (word == words[i]) {
            palindromes.push(words[i]);
        }
    }

    return palindromes;
}

var text = 'ABBA odsalskdjaskldj sklkj skks ' +
    'lalal llls sdaklj nakjh askjh a12321a pop zxcxz';

jsConsole.writeLine(text);
console.log(text);
jsConsole.writeLine('');
console.log('');

function main() {
    var palindromes = extractPalindromes(text);
    
    jsConsole.writeLine(palindromes.join(' | '));
    console.log(palindromes.join(' | '));
    jsConsole.writeLine('');
    console.log('');
}

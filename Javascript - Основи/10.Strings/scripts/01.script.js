/*Exercise 1 - Write a JavaScript function reverses string 
and returns it Example: "sample" -> "elpmas".
*/
/*global document, console, jsConsole*/
function reverseString(word) {
    var reversed = '',
        index;
    for (index in word)
    {
        reversed = word[index] + reversed;
    }

    return reversed;
}

function reverseWord() {
    var word = jsConsole.read('#word'),
        reversedWord = reverseString(word);

    jsConsole.writeLine('Word: ' + word +
        ' | Reversed word: ' + reversedWord);
    console.log('Word: ' + word +
        ' | Reversed word: ' + reversedWord);
}

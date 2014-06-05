/*Exercise 3 - Write a JavaScript function that finds how many times a 
    substring is contained in a given text (perform case insensitive search).
	Example: The target substring is "in". The text is as follows:
	We are living in an yellow submarine. We don't have anything else. 
	Inside the submarine is very tight. So we are drinking all the day. 
	We will move out of it in 5 days.
The result is: 9.
*/
/*global document, console, jsConsole*/
function countSubtstringInText(text, substring) {
    var patt = new RegExp(substring, 'gi'),
        counter = 0;

    while (patt.exec(text))
    {
        counter += 1;
    }

    return counter;
}

function main() {
    var substring = jsConsole.read('#substring'),
        text = jsConsole.read('#text'),
        result = countSubtstringInText(text, substring);

    jsConsole.writeLine('Substring "' + substring + '" is ' + result +
        ' times in the text');
    console.log('Substring "' + substring + '" is ' + result +
        ' times in the text');
    jsConsole.writeLine('');
    console.log('');
}

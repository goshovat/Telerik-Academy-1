/*Exercise 5 - Write a function that replaces non breaking 
    white-spaces in a text with &nbsp;
*/
/*global document, console, jsConsole*/

function replace(text) {
    var i;

    for (i = 0; i < text.length; i += 1) {
        if (text[i] == " ") {
            text = text.replace(text[i], "&nbsp;");
            i += 5;
        }
    }
    return text;
}

function main() {
    var text = "We are living yellow submarine in a yellow submarine." +
        " We don't have Anything else.";

    jsConsole.writeLine(replace(text));
    console.log(replace(text));
    jsConsole.writeLine('');
    console.log('');
}

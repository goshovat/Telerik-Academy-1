/*Exercise 11 - Write a function that formats a string using placeholders:
    var str = stringFormat("Hello {0}!","Peter");
    //str = "Hello Peter!";
    The function should work with up to 30 placeholders and all types
    var format = "{0}, {1}, {0} text {2}";
    var str = stringFormat(format,1,"Pesho","Gosho");
    //str = "1, Pesho, 1 text Gosho"
*/
/*global document, console, jsConsole*/

function stringFormat(text, placheHolders) {
    var formattedText = text,
        i;

    for (i = 0; i < arguments.length - 1; i += 1) {
        formattedText = formattedText.split('{' + i + '}').join(arguments[i + 1]);
    }

    return formattedText;
}

function main() {
    var firstString = stringFormat("Hello {0}!", "Peter"),
        format = "{0}, {1}, {0} text {2}",
        secondString = stringFormat(format, 1, "Pesho", "Gosho");

    jsConsole.writeLine(firstString);
    console.log(firstString);
    jsConsole.writeLine(secondString);
    console.log(secondString);
    jsConsole.writeLine('');
    console.log('');
}

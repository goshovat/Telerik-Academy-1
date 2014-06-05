/*Exercise 8 - Write a JavaScript function that replaces in a HTML document given as 
string all the tags <a href="…">…</a> with corresponding tags 
[URL=…]…/URL]. Sample HTML fragment:
*/
/*global document, console, jsConsole*/

function replaceAnchor(doc) {
    var changedDoc = doc.split('<a href="').join('[URL=');

    changedDoc = changedDoc.split('">').join(']');
    changedDoc = changedDoc.split('</a>').join('[/URL]');

    return changedDoc;
}

var text = '<p>Please visit <a href="http://academy.telerik.com">our ' +
    'site</a> to choose a training course. Also visit <a href="www.devbg.org">' + 
    'our forum</a> to discuss the courses.</p>';

jsConsole.writeLine(text);
console.log(text);
jsConsole.writeLine('');
console.log('');

function main() {
    var changedText = replaceAnchor(text);
    
    jsConsole.writeLine(changedText);
    console.log(changedText);
    jsConsole.writeLine('');
    console.log('');
}

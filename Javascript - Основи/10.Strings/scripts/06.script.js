/*Exercise 6 - Write a function that extracts the content of a html page given 
    as text. The function should return anything that is in a tag, 
    without the tags:
    <html><head><title>Sample site</title></head><body><div>text<div>
    more text</div>and more...</div>in body</body></html>
    result:
    Sample sitetextmore textand more...in body
*/
/*global document, console, jsConsole*/

function findTags(text) {
    var i,
        startIndex,
        stopIndex,
        tag,
        tags = [];

    startIndex = text.indexOf('<', 0);
    
    while (startIndex > -1) {
        stopIndex = text.indexOf('>', startIndex);
        tag = text.substring(startIndex, stopIndex + 1);
        tags.push(tag);
        startIndex = text.indexOf('<', stopIndex);
    }

    return tags;
}

function main() {
    var text = " <html><head><title>Sample site</title></head>" +
        "<body><div>text<div>more text</div>and more...</div>" +
        "in body</body></html>",
    tags = findTags(text),
    content = text.split(new RegExp(tags.join('|'), 'g')).join('');

    jsConsole.writeLine(content);
    console.log(content);
    jsConsole.writeLine('');
    console.log('');
}

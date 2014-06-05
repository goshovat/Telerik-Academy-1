/*Exercise 9 - Write a function for extracting all email addresses from 
    given text. All substrings that match the format <identifier>@<host>…<domain> 
    should be recognized as emails. Return the emails as array of strings.
*/
/*global document, console, jsConsole*/

function extractEmails(doc) {
    var pattern = /([a-zA-Z0-9._\-]+@[a-zA-Z0-9._\-]+\.[a-zA-Z0-9._\-]+)/gi,
    emails = doc.match(pattern);

    return emails;
}

var text = 'ivancho_emil@abv.bg dsalk sal sadl saj jklas opa@gmail.com ' +
    'aaas peter.ivanchev@mail.bg sa a zxa sd asd as asd dsa as das' +
    ' opalq asdasa asdklsdaskdlajs jivko-jivkov@mail.com';

jsConsole.writeLine(text);
console.log(text);
jsConsole.writeLine('');
console.log('');

function main() {
    var emails = extractEmails(text);
    
    jsConsole.writeLine(emails.join(' | '));
    console.log(emails.join(' | '));
    jsConsole.writeLine('');
    console.log('');
}

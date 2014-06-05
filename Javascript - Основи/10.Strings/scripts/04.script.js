/*Exercise 4 - You are given a text. Write a function that changes 
the text in all regions:
<upcase>text</upcase> to uppercase.
<lowcase>text</lowcase> to lowercase
<mixcase>text</mixcase> to mix casing(random)
We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. 
We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.
The expected result:
We are LiVinG in a YELLOW SUBMARINE. We dOn'T have anything else.
Regions can be nested
*/
/*global document, console, jsConsole*/
function changeToUpper(textToChange) {
    return textToChange.toUpperCase();
}

function changeToLower(textToChange) {
    return textToChange.toLowerCase();
}

function changeToMixer(textToChange) {
    var j,
        numberUpCaseLetters,
        randomIndex,
        character;

    numberUpCaseLetters = parseInt(Math.random() * 10, 10) % textToChange.length;

    for (j = 0; j < numberUpCaseLetters; j += 1) {
        randomIndex = parseInt(Math.random() * 10, 10) % textToChange.length;
        character = textToChange[randomIndex].toUpperCase();
        textToChange = textToChange.substr(0, randomIndex) + character +
        textToChange.substr(randomIndex + character.length);
    }

    return textToChange;
}

var text = "<lowcase>We are</lowcase> <mixcase><lowcase>LIVING</lowcase></mixcase>" +
        " in a <lowcase><upcase>yellow submarine</upcase>. We</lowcase>" +
        "<mixcase> don't</mixcase> have <upcase><mixcase><lowcase>anYthInG" +
        "</lowcase></mixcase> else.</upcase>EnD!";
jsConsole.writeLine(text);

function main() {
    var result = '',
        tags = [],
        character,
        changedSubstring = '',
        substring = '',
        nestedSubstring = [],
        popedString = '',
        i,
        isPoped = false;

    for (i = 0; i < text.length; i += 1) {
        character = text[i];

        if (character === '<') {
            switch (text[i + 1]) {
            case 'u':
                tags.push('<upcase>');
                i += 7;
                break;
            case 'l':
                tags.push('<lowcase>');
                i += 8;
                break;
            case 'm':
                tags.push('<mixcase>');
                i += 8;
                break;
            case '/':
                isPoped = true;

                switch (text[i + 2]) {
                case 'u':
                    tags.pop();
                    i += 8;
                    changedSubstring = changeToUpper(substring);
                    break;
                case 'l':
                    tags.pop();
                    i += 9;
                    changedSubstring = changeToLower(substring);
                    break;
                case 'm':
                    tags.pop();
                    i += 9;
                    changedSubstring = changeToMixer(substring);
                    break;
                }

                if (tags.length === 0) {
                    result += changedSubstring;
                    substring = '';
                } else {
                    popedString = nestedSubstring.pop();
                    substring = typeof popedString === 'undefined' ?
                        changedSubstring : popedString + changedSubstring;
                }

                break;
            }

            if (tags.length === 1 && isPoped !== true) {
                result += substring;
            } else if (!isPoped) {
                nestedSubstring.push(substring);
            } else {
                isPoped = false;
                continue; // To save current substring 
            }
        
            substring = '';
        } else {
            substring += character;
        }
    }

    result += text.substr(text.lastIndexOf('>') + 1);

    jsConsole.writeLine(result);
    console.log(result);
    jsConsole.writeLine('');
    console.log('');
}

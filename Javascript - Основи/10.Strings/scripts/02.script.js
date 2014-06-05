/*Exercise 2 - Write a JavaScript function to check if in a 
    given expression the brackets are put correctly.
    Example of correct expression: ((a+b)/5-d).
    Example of incorrect expression: )(a+b)).
*/
/*global document, console, jsConsole*/
function isValidBrackets(expression) {
    var leftBracket = 0,
        index;

    for (index in expression) {
        if (expression[index] === '(') {
            leftBracket += 1;
        } else if (expression[index] === ')') {
            if (leftBracket === 0) {
                return 'incorrect';
            } else {
                leftBracket -= 1;
            }
        }
    }

    if (leftBracket === 0) {
        return 'correct';
    } else {
        return 'incorrect';
    }
}

function check() {
    var expression = jsConsole.read('#expression'),
        result = isValidBrackets(expression);

    jsConsole.writeLine('Expression: ' + expression + ' is ' + result);
    console.log('Expression: ' + expression + ' is ' + result);
    jsConsole.writeLine('');
    console.log('');
}

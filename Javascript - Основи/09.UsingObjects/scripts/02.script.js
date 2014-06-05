/*Exercise 2 - Write a function that removes all elements with a given value
    var arr = [1,2,1,4,1,3,4,1,111,3,2,1,"1"];
    arr.remove(1); //arr = [2,4,3,4,111,3,2,"1"];
    Attach it to the array type
    Read about prototype and how to attach methods
*/

function removeElements() {
    /*global document, console, jsConsole*/
    var array = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, "1"],
        secondArray = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, "1"],
        intElementToRemove = jsConsole.readInteger('#element'),
        stringElementToRemove = jsConsole.read('#element');

    Array.prototype.remove = function (element) {
        for (var i = 0; i < this.length; i += 1) {
            if (this[i] === element) {
                this.splice(i, 1);
				i--;
            }
        }
    };

    array.remove(intElementToRemove);
    jsConsole.writeLine('(Remove integer = ' + intElementToRemove +
        ') Array [' + array.join(', ') + ']');
    console.log('(Remove integer = ' + intElementToRemove +
        ') Array [' + array.join(', ') + ']');

    secondArray.remove(stringElementToRemove);
    jsConsole.writeLine('(Remove string = "' + stringElementToRemove +
       '") Array [' + secondArray.join(', ') + ']');
    console.log('(Remove string = "' + stringElementToRemove +
       '") Array [' + secondArray.join(', ') + ']');
	jsConsole.writeLine('');
	console.log('');
}

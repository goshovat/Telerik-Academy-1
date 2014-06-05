/*Exercise 3 - Write a function that makes a deep copy of an object
The function should work for both primitive and reference types
*/

function clone(objectToClone) {
    var copy,
        i;

    // Handle the 3 simple types, and null or undefined
    if (null === objectToClone || 'object' !== typeof objectToClone) {
        return objectToClone;
    }

    if (objectToClone instanceof Date) {
        copy = new Date();
        copy.setTime(objectToClone.getTime());
        return copy;
    }

    copy = objectToClone instanceof Array ? [] : {};

    for (i in objectToClone) {
        copy[i] = clone(objectToClone[i]);
    }

    return copy;
}

var array = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'],
	intVar = 27,
	stringVar = 'Hello',
	objectVar = {
		name: 'ivan',
		age: 3,
		toString: function () {
			return 'name: ' + this.name + ', age:' + this.age;
		}
	};
	
jsConsole.writeLine(array);
console.log(array);
jsConsole.writeLine(intVar);
console.log(intVar);
jsConsole.writeLine(stringVar);
console.log(stringVar);
jsConsole.writeLine(objectVar);
console.log(objectVar);
jsConsole.writeLine('');
console.log('');

function cloneObject() {
    /*global document, console, jsConsole*/
	var clonedArray,
        clonedIntVar,
        clonedStringVar,
        clonedObjectVar;

    clonedArray = clone(array);
    clonedIntVar = clone(intVar);
    clonedStringVar = clone(stringVar);
    clonedObjectVar = clone(objectVar);

	array.splice(0, 10);
	intVar = -10;
	stringVar = 'World';
    objectVar.name = 'dimi';
    objectVar.age = 123;
	
    jsConsole.writeLine(clonedArray);
    console.log(clonedArray);
    jsConsole.writeLine(clonedIntVar);
    console.log(clonedIntVar);
    jsConsole.writeLine(clonedStringVar);
    console.log(clonedStringVar);
    jsConsole.writeLine(clonedObjectVar);
    console.log(clonedObjectVar);
    jsConsole.writeLine('');
	console.log('');
}

/*Exercise 4 - Write a function that checks if a given object contains a given property
    var obj  = …;
    var hasProp = hasProperty(obj,'length');
*/

function hasProperty(obj, property) {
    if (obj.hasOwnProperty(property)) {
        return true;
    }

    return false;
}

function checkObjectForPropery() {
    /*global document, console, jsConsole*/
    var prop = jsConsole.read('#property'),
        objectVar = {
            name: 'ivan',
            age: 3,
            toString: function () {
                return 'name: ' + this.name + ', age:' + this.age;
            }
        },
        hasProp = hasProperty(objectVar, prop);

    jsConsole.writeLine('Does objectVar has property ' + prop + ' ? ' + hasProp);
    console.log('Does objectVar has property ' + prop + ' ? ' + hasProp);
    jsConsole.writeLine('');
    console.log('');
}

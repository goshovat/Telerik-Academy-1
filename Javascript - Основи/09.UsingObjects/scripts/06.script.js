/*Exercise 6 - Write a function that groups an array of persons by age, 
    first or last name. The function must return an associative array, with 
    keys - the groups, and values -arrays with persons in this groups
    Use function overloading (i.e. just one function)
    var persons = {…};
    var groupedByFname = group(persons,'firstname');
    var groupedByAge= group(persons,'age');
*/
/*global console, jsConsole, Person*/

function group(array, groupBy) {
    var groupedPeople = {},
        index;

    for (index in array) {
        if (!groupedPeople.hasOwnProperty(array[index][groupBy])) {
            groupedPeople[array[index][groupBy]] = [];
        }

        groupedPeople[array[index][groupBy]].push(array[index]);
    }

    return groupedPeople;
}

var peter = new Person('Peter', 'Petrov', 23),
    george = new Person('George', 'Kolev', 23),
    jack = new Person('Jack', 'Kirov', 19),
    ivan = new Person('Peter', 'Kirov', 19),
    people = [peter, george, jack, ivan];

jsConsole.writeLine(people.join(' | '));
console.log(people.join(' | '));
jsConsole.writeLine('');
console.log('');

function groupPeople() {
    var groupBy = jsConsole.read('#groupBy'),
        groupedPeople = group(people, groupBy),
        index;

    for (index in groupedPeople) {
        jsConsole.writeLine('Property = ' + index + '/ Value = ' + groupedPeople[index].join(' | '));
        console.log('Property = ' + index + '/ Value = ' + groupedPeople[index].join(' | '));
    }

    jsConsole.writeLine('');
    console.log('');
}

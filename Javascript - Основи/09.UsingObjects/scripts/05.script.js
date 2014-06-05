/*Exercise 5 - Write a function that finds the youngest person in a 
    given array of persons and prints his/hers full name
    Each person have properties firstname, lastname and age, as shown:
    var persons = [
      {firstname : "Gosho", lastname: "Petrov", age: 32}, 
      {firstname : "Bay", lastname: "Ivan", age: 81},…];
*/
/*global document, console, jsConsole, Person*/

function findYoungest(array) {
    var youngest = array[0],
        index;
    for (index in array) {
        if (array[index].age < youngest.age) {
            youngest = array[index];
        }
    }

    return youngest;
}

var peter = new Person("Peter", "Petrov", 23),
    george = new Person("George", "Kolev", 17),
    jack = new Person("Jack", "Ivanov", 42),
    ivan = new Person("Ivan", "Kirov", 56),
    people = [peter, george, jack, ivan];

jsConsole.writeLine(people.join(' | '));
console.log(people.join(' | '));
jsConsole.writeLine('');
console.log('');

function findYoungestPerson() {
    var youngestPerson = findYoungest(people);

    jsConsole.writeLine("Youngest person is: " + youngestPerson);
    console.log("Youngest person is: " + youngestPerson);
    jsConsole.writeLine('');
    console.log('');
}

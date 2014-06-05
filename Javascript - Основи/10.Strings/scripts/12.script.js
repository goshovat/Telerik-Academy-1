/*Exercise 12 -Write a function that creates a HTML UL using a template 
    for every HTML LI. The source of the list should an array 
    of elements. Replace all placeholders marked with –{…}–   
    with the value of the corresponding property of the object. Example: 
    <div data-type="template" id="list-item">
     <strong>-{name}-</strong> <span>-{age}-</span>
    /div>
    var people = [{name: "Peter", age: 14},…];
    var tmpl = document.getElementById("list-item").innerHtml;
    var peopleList = generateList(people,template);
    //peopleList = "<ul><li><strong>Peter</strong> <span>14</span></li><li>…</li>…</ul>"
*/
/*global document, console, jsConsole*/

function generateList(temp, people) {
    var holder = temp,
        liArr = [],
        person;

    for (person in people) {
        temp = temp.replace("{name}", people[person].name);
        temp = temp.replace("{age}", people[person].age);
        liArr.push(temp);
        temp = holder;
    }
    return liArr;
}

function main() {
    var people = [{ name: "Peter", age: 27 }, { name: "Ivan", age: 18 },
        { name: "George", age: 52 }, { name: "Dimana", age: 22}],
        temp = document.getElementById("list-item").innerHTML,
        finalArr = generateList(temp, people),
        i;

    jsConsole.writeLine("<ul>");

    for (i = 0; i < finalArr.length; i += 1) {
        jsConsole.writeLine('<li>' + finalArr[i] + '</li>');
    }

    jsConsole.writeLine("</ul>");

    jsConsole.writeLine('');
    console.log('');
}

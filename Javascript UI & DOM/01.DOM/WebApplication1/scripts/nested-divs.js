/*global console, document, alert */
function findLiveDivs() {
    var allDivs = document.getElementsByTagName('div'),
        i;
    console.log('Nested divs found by getElementsByTagName');

    for (i = 0; i < allDivs.length; i += 1) {
        if (allDivs[i].parentNode.nodeName === "DIV") {
            console.log(allDivs[i]);
        }
    }

    console.log('');

    alert("See the results from getElementsByTagName in the console.");
}

function findStaticDivs() {
    var staticDivs = document.querySelectorAll('div > div'),
        i;

    console.log('Nested divs found by querySelectorAll');

    for (i = 0; i < staticDivs.length; i += 1) {
        console.log(staticDivs[i]);
    }

    console.log('');

    alert("See the results from querySelectorAll in the console.");
}
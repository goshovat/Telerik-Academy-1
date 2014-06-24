/*global document, setInterval*/
var angle = 0,
    x = 300,
    y = 300,
    radius = 50;

function createDiv(index) {
    var div = document.createElement('div'),
        posY,
        posX,
        divAngle;

    divAngle = angle + index * 2 * Math.PI / 5;
    posY = y + radius * Math.PI * Math.sin(divAngle);
    posX = x + radius * Math.PI * Math.cos(divAngle);
    div.style.width = '30px';
    div.style.position = 'absolute';
    div.style.height = '30px';
    div.style.backgroundColor = 'green';
    div.style.top = posY + 'px';
    div.style.left = posX + 'px';
    div.style.borderRadius = '10px';

    return div;
}

var divs = [],
    dFrag = document.createDocumentFragment();

for (var i = 0; i < 5; i += 1) {
    divs[i] = document.createElement('div');

    dFrag.appendChild(createDiv(i));
}

document.body.appendChild(dFrag);
divs = document.getElementsByTagName('div');

function move() {
    var posY,
        posX,
        divAngle,
        i;

    angle += 0.05;
    for (i = 0; i < 5; i += 1) {
        divAngle = angle + i * 2 * Math.PI / 5;
        posY = y + radius * Math.PI * Math.sin(divAngle);
        posX = x + radius * Math.PI * Math.cos(divAngle);
        divs[i].style.top = posY + 'px';
        divs[i].style.left = posX + 'px';
    }
}

setInterval(move, 100);

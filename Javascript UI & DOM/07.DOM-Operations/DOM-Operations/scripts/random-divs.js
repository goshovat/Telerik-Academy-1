/*global document*/
var colors = ["red", "green", "blue", "yellow", "black", "white", "purple", "pink"];

function createDiv() {
    var div = document.createElement('div'),
        strongText = document.createElement('strong');

    div.style.width = Math.floor((Math.random() * 80) + 21) + "px";
    div.style.height = Math.floor((Math.random() * 80) + 21) + "px";
    div.style.backgroundColor = colors[Math.floor((Math.random() * colors.length) + 1)];
    div.style.color = colors[Math.floor((Math.random() * colors.length) + 1)];
    div.style.position = "absolute";
    div.style.top = Math.floor((Math.random() * 400) + 1) + "px";
    div.style.left = Math.floor((Math.random() * 800) + 1) + "px";

    strongText.innerHTML = 'div';
    div.appendChild(strongText);
    div.style.borderRadius = Math.floor((Math.random() * div.style.height) + 1) + "px";
    div.style.borderColor = colors[Math.floor((Math.random() * colors.length) + 1)];
    div.style.borderWidth = Math.floor((Math.random() * 20) + 1) + "px";

    return div;
}

var divNumbers = Math.floor((Math.random() * 20) + 1),
    dFrag = document.createDocumentFragment();

for (var i = 0; i < divNumbers; i += 1) {
    dFrag.appendChild(createDiv());
}

document.body.appendChild(dFrag);

/*global document*/
var textarea = document.getElementById('text');

function changeBackgroundColor() {
    var value = document.getElementById('background').value;
    textarea.style.background = value;
}

function changeFontColor() {
    var value = document.getElementById('font').value;
    textarea.style.color = value;
}
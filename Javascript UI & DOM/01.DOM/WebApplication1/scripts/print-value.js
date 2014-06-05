/*global console, document */
function printValue() {
    var value = document.getElementById('inputedText').value;
    console.log(value);
    document.getElementById('result').value = value;
}
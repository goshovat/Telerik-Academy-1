/*global document*/
var svgNS = 'http://www.w3.org/2000/svg',
    svg = document.createElementNS(svgNS, 'svg');

function createCircle(x, y, r, fill) {
    var circle = document.createElementNS(svgNS, 'circle');
    circle.setAttribute('cx', x);
    circle.setAttribute('cy', y);
    circle.setAttribute('r', r);
    circle.setAttribute('stroke', 'none');
    circle.setAttribute('fill', fill);

    svg.appendChild(circle);
}

function writeTextOnThePage(x, y, fontSize, color, innerText, fontFamily) {
    var text = document.createElementNS(svgNS, 'text');
    text.setAttribute('x', x);
    text.setAttribute('y', y);
    text.setAttribute('font-size', fontSize);
    text.setAttribute('fill', color);
    text.setAttribute('font-family', fontFamily),
    text.setAttribute('font-weight', 'bold');
    text.innerHTML = innerText;
    svg.appendChild(text);

}

function drawPath(fillColor, strokeColor, d, strokeWidth) {
    var leftCurve = document.createElementNS(svgNS, 'path');
    leftCurve.setAttribute('d', d);
    leftCurve.setAttribute('fill', fillColor);
    leftCurve.setAttribute('stroke', strokeColor);
    leftCurve.setAttribute('stroke-width', strokeWidth);
    svg.appendChild(leftCurve);
}

function addNodeJSLogo() {
    var nodeJSLogo = document.createElementNS('http://www.w3.org/2000/svg', 'image');
    nodeJSLogo.setAttributeNS(null, 'width', '125');
    nodeJSLogo.setAttributeNS(null, 'height', '65');
    nodeJSLogo.setAttributeNS(
        'http://www.w3.org/1999/xlink', 'href', 'pictures/node-logo.svg');
    nodeJSLogo.setAttributeNS(null, 'x', '205');
    nodeJSLogo.setAttributeNS(null, 'y', '275');
    nodeJSLogo.setAttributeNS(null, 'visibility', 'visible');
    svg.appendChild(nodeJSLogo);
}

var svgJS = document.getElementById('svg-js'),
    repetitionsCount = 4,
    circleStartX = 250,
    textStartX = 140,
    startY = 130,
    radius = 60,
    fontSize = '40px',
    colors = ['#3E3F37', '#282827', '#E23337', '#8EC74E', 'green'],
    word = ['MEAN', 'express'],
    OrderedFunctions = [
        function drawLeaf() {
            drawPath('#5EB14A', '#5EB14A', 'M 250 95 C225 120 225 150 250 150', 1);
            drawPath('#449644', '#449644', 'M 250 95 C275 120 275 150 250 150', 1);
        },
        function drawExpress() {
            writeTextOnThePage(200, 190, 26, '#FFFFFF', word[1], 'Consolas');
        },
        function drawAngularJs() {
            drawPath('#B63032', '#B3B3B3', 'M 250 215 L285 230 L275 300 L250 300', 3);
            drawPath('#E23337', '#B3B3B3', 'M 250 215 L215 230 L225 300 L250 300', 3);
            drawPath('#FFFFFF', '#FFFFFF', 'M 250 220 L220 280 L230 280 L 250 235', 1);
            drawPath('#B3B3B3', '#B3B3B3', 'M 250 220 L280 280 L270 280 L250 235', 1);
        },
        function drawNodeJSLog() {
            addNodeJSLogo();
        }
    ];

svg.setAttribute('width', '500');
svg.setAttribute('height', '500');
svgJS.appendChild(svg);


for (var i = 0; i < repetitionsCount; i += 1) {
    createCircle(circleStartX, startY, radius, colors[i]);
    writeTextOnThePage(textStartX, startY + 10, fontSize, colors[i], word[0][i], 'Arial');
    if (OrderedFunctions[i]) {
        OrderedFunctions[i]();
    }

    startY += 60;
}


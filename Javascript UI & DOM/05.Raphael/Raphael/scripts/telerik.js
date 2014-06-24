/// <reference path="raphael-min.js" />
/*global window*/
function findSecondPoint(x, y, width, angle) {
    var secondPoint = {},
        side = Math.sqrt((width * width) / 2);

    secondPoint.side = side;

    switch (angle) {
        case 45:
            secondPoint.x = x + side;
            secondPoint.y = y + side;
            break
        case 135:
            secondPoint.x = x - side;
            secondPoint.y = y + side;
            break;
        case 225:
            secondPoint.x = x - side;
            secondPoint.y = y - side;
            break;
        case 315:
            secondPoint.x = x + side;
            secondPoint.y = y - side;
            break;
    }

    return secondPoint;
}

function drawLine(x, y, width, height, angle) {
    paper.rect(x, y, width, height)
        .attr({
            fill: '#5CE600',
            stroke: '#5CE600',
        })
        .rotate(angle, x, y);

    return findSecondPoint(x, y, width, angle);
}

var paper = Raphael(0, 50, 500, 180),
    sides = [70, 40, 40, 70, 30],
    angles = [45, 135, 225, 315, 45],
    sideHeight = 10,
    secondPoint = drawLine(50, 50, 30, 10, 315);

//Logo
for (var i = 0; i < sides.length; i++) {
    secondPoint = drawLine(secondPoint.x, secondPoint.y, sides[i], sideHeight, angles[i]);
}

//Caption
paper.text(270, 80, "Telerik")
.attr({
    'font-size': 75,
    'font-family': 'Arial',
    'font-weight': 'bold'
});

//Motto
paper.text(300, 125, "Develop experiences")
.attr({
    'font-size': 30,
    'font-family': 'Arial'
});

//Copyrights
paper.circle(397, 73, 5);
paper.text(397, 73, "R")
.attr({
    'font-size': 10
});
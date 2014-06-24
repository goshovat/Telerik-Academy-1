/// <reference path="raphael-min.js" />
/*global Raphael, window*/
var paper = Raphael(0, 50, 500, 500),
    radius,
    center = 250,
    x = center,
    y = center,
    prevX = 0,
    prevY = 0,
    i = 0,
    refreshIntervalId,
    radius,
    a = 4,
    b = 4;

function paint() {

    if (i === 600) {
        clearInterval(refreshIntervalId);
        return;
    }

    i += 1;
    prevX = x;
    prevY = y;
    angle = 0.1 * i;
    radius = a + b * angle;
    x = radius * Math.sin(angle) + center;
    y = radius * Math.cos(angle) + center;
    paper.path("M " + prevX + " " + prevY + " L " + x + " " + y);


}

refreshIntervalId = setInterval(paint, 10);

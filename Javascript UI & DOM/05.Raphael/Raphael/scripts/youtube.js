/// <reference path="raphael-min.js" />
/*global Raphael, window*/
Raphael.fn.roundedRectangle = function (x, y, w, h, r1, r2, r3, r4) {
    var array = [];
    array = array.concat(["M", x, r1 + y, "Q", x, y, x + r1, y]); //A
    array = array.concat(["L", x + w - r2, y, "Q", x + w, y, x + w, y + r2]); //B
    array = array.concat(["L", x + w, y + h - r3, "Q", x + w, y + h, x + w - r3, y + h]); //C
    array = array.concat(["L", x + r4, y + h, "Q", x, y + h, x, y + h - r4, "Z"]); //D

    return this.path(array);
};

var paper = Raphael(0, 50, 320, 100);

//Caption
paper.text(70, 50, "You")
.attr({
    'font-size': 60,
    'font-family': 'Arial',
    'font-weight': 'bold'
});

//Balloon
paper.roundedRectangle(135, 20, 160, 60, 20, 20, 20, 20)
.attr({
    fill: '#EC2828',
    stroke: 'none',
    rx: 15,
    ry: 15
});

//Caption
paper.text(215, 50, "Tube")
.attr({
    fill: '#FFFFFF',
    'font-size': 60,
    'font-family': 'Arial',
    'font-weight': 'bold'
});
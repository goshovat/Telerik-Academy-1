/*Exercise 1 - Write functions for working with shapes in  standard 
    Planar coordinate system
    Points are represented by coordinates P(X, Y)
    Lines are represented by two points, marking their beginning and ending
    L(P1(X1,Y1), P2(X2,Y2))
    Calculate the distance between two points
    Check if three segment lines can form a triangle*/

function buildPoint(x, y) {
    return {
        xCoordinate: x,
        yCoordinate: y,
        calculateDistance: function (otherPoint) {
            var x = Math.abs(this.xCoordinate - otherPoint.xCoordinate) *
                Math.abs(this.xCoordinate - otherPoint.xCoordinate),
                y = Math.abs(this.xCoordinate - otherPoint.xCoordinate) *
                Math.abs(this.xCoordinate - otherPoint.xCoordinate);
            return Math.sqrt(x + y);
        },
        toString: function () {
            return '(' + this.xCoordinate + ", " + this.yCoordinate + ')';
        }
    };
}

function buildLine(startPoint, stopPoint) {
    return {
        startPoint: startPoint, //buildPoint(startX, startY),
        stopPoint: stopPoint, //buildPoint(stopX, stopY),
        toString: function () {
            return '(' + this.startPoint.toString() + ", " +
                this.stopPoint.toString() + ')';
        }
    };
}

function checkForTriangle(lineOne, lineTwo, lineThree)
{
    var a = lineOne.startPoint.calculateDistance(lineOne.stopPoint),
        b = lineTwo.startPoint.calculateDistance(lineTwo.stopPoint),
        c = lineThree.startPoint.calculateDistance(lineThree.stopPoint);

    if ((a + b > c) && (a + c > b) && (b + c > a)) {
        return true;
    } else {
        return false;
    }
}

function findLastDigitName() {
    /*global document, console, jsConsole*/
    var firstStartX = jsConsole.readInteger('#firstStartX'),
        firstStartY = jsConsole.readInteger('#firstStartY'),
        firstStopX = jsConsole.readInteger('#firstStopX'),
        firstStopY = jsConsole.readInteger('#firstStopY'),
        secondStartX = jsConsole.readInteger('#secondStartX'),
        secondStartY = jsConsole.readInteger('#secondStartY'),
        secondStopX = jsConsole.readInteger('#secondStopX'),
        secondStopY = jsConsole.readInteger('#secondStopY'),
        thirdStartX = jsConsole.readInteger('#thirdStartX'),
        thirdStartY = jsConsole.readInteger('#thirdStartY'),
        thirdStopX = jsConsole.readInteger('#thirdStopX'),
        thirdStopY = jsConsole.readInteger('#thirdStopY'),
        firstLine = buildLine(buildPoint(firstStartX, firstStartY),
            buildPoint(firstStopX, firstStopY)),
        secondLine = buildLine(buildPoint(secondStartX, secondStartY),
            buildPoint(secondStopX, secondStopY)),
        thirdLine = buildLine(buildPoint(thirdStartX, thirdStartY),
            buildPoint(thirdStopX, thirdStopY));

    jsConsole.writeLine('The lines can form triangle ? - ' +
        checkForTriangle(firstLine, secondLine, thirdLine));
    console.log('The lines can form triangle ? - ' +
        checkForTriangle(firstLine, secondLine, thirdLine));
}

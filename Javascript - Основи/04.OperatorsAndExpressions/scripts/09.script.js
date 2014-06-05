/*Exercise 9 - Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) 
 and out of the rectangle R(top=1, left=-1, width=6, height=2).*/

function checkPoint() {
    var xCoordinate = jsConsole.readFloat("#x"),
        yCoordinate = jsConsole.readFloat("#y"),
        pointRadius = Math.sqrt((xCoordinate - 1) * (xCoordinate - 1) + (yCoordinate - 1) * (yCoordinate - 1)),
        isWithinCircle = pointRadius <= 3.0,
        isWithinFirstRectangle = xCoordinate >= -1.0 && xCoordinate <= 5.0 && yCoordinate >= -1.0 && yCoordinate <= 1.0,
        isWithinSecondRectangle = xCoordinate >= 1.0 && xCoordinate <= 7.0 && yCoordinate >= -3.0 && yCoordinate <= -1.0;

    // I could not decide which one is the correct rectangle so I made checks for both

    if (isWithinCircle)
    {
        jsConsole.writeLine("The point (" + xCoordinate + ", " + yCoordinate + ") is within the circle K((1,1),3)  ");
        console.log("The point (" + xCoordinate + ", " + yCoordinate + ") is within the circle K((1,1),3)  ");
    }
    else
    {
        jsConsole.writeLine("The point (" + xCoordinate + ", " + yCoordinate + ") is out of the circle K((1,1),3) ");
        console.log("The point (" + xCoordinate + ", " + yCoordinate + ") is out of the circle K((1,1),3) ");
    }

    // First rectangle R((-1,1),(5,-1)), where (-1,1) is the top left corner and (5,-1) is the bottom right corner
    if (isWithinFirstRectangle)
    {
        jsConsole.writeLine("and is within the rectangle R((-1,1),(5,-1)) ");
        console.log("and is within the rectangle R((-1,1),(5,-1)) ")
    }
    else
    {
        jsConsole.writeLine("and is out of the rectangle R((-1,1),(5,-1))  ");
        console.log("and is out of the rectangle R((-1,1),(5,-1))  ");
    }

    // Second rectanle R((1,-1),(7,-3)), where (1,1) is the top left corner and (7,-3) is the bottom right corner
    if (isWithinSecondRectangle)
    {
        jsConsole.writeLine("and is within the rectangle R((1,-1),(7,-3)) ");
        console.log("and is within the rectangle R((1,-1),(7,-3)) ");
    }
    else
    {
        jsConsole.writeLine("and is out of the rectangle R((1,-1),(7,-3)) ");
        console.log("and is out of the rectangle R((1,-1),(7,-3)) ");
    }
}
/*Exercise 6 - Write an expression that checks if given print (x,  y) is within a circle K(O, 5).*/

function checkPoint() {
    var x = jsConsole.readFloat("#x"),
        y = jsConsole.readFloat("#y"),
        hypotenuse = Math.sqrt(Math.pow(x, 2) + Math.pow(y, 2));

    if (hypotenuse <= 5.0) {
        jsConsole.writeLine("The point (" + x + ", " + y + ") is within the circle k(0,5).");
        console.log("The point (" + x + ", " + y + ") is within the circle k(0,5).");
    } else {
        jsConsole.writeLine("The point (" + x + ", " + y + ") is not within the circle k(0,5).");
        console.log("The point (" + x + ", " + y + ") is not within the circle k(0,5).");
    }
}
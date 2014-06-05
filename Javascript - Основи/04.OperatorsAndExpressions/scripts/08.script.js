/*Exercise 8 - Write an expression that calculates trapezoid's area by given sides a and b and height h.*/

function calculateArea() {
    var a = jsConsole.readFloat("#a"),
        b = jsConsole.readFloat("#b"),
        h = jsConsole.readFloat("#h"),
        area;

    area = (a + b) * h / 2;
    jsConsole.writeLine("The area of trapezoid is " + area);
    console.log("The area of trapezoid is " + area);

}

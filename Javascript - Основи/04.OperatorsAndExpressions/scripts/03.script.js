/*Exercise 3 -Write an expression that calculates rectangle’s area by given width and height. */

function calculateArea() {
    var width = jsConsole.readFloat("#width"),
        height = jsConsole.readFloat("#height"),
        area = width * height;

    jsConsole.writeLine("The rectangle's area is = " + area);
    console.log("The rectangle's area is = " + area);
}
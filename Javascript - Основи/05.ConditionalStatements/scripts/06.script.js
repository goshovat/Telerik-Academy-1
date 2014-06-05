/*Exercise 6 - Write a script that enters the coefficients a, b and c of a quadratic equation
		a*x2 + b*x + c = 0
  and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.*/

function findRealRoots() {
    /*global console, jsConsole*/
    var coefficientA = jsConsole.readInteger("#a"),
        coefficientB = jsConsole.readInteger("#b"),
        coefficientC = jsConsole.readInteger("#c"),
        discriminant,
        root1,
        root2;

    if (coefficientA === 0 || coefficientB === 0 || coefficientC === 0) {
        alert("Coefficient a, b or c must not be 0!");
    } else {
        discriminant = coefficientB * coefficientB - 4 * coefficientA * coefficientC;

        if (discriminant > 0) {
            root1 = (-coefficientB + Math.sqrt(discriminant)) / 2 * coefficientA;
            root2 = (-coefficientB - Math.sqrt(discriminant)) / 2 * coefficientA;
            jsConsole.writeLine("The quadratic equation has two differtent real roots");
            console.log("The quadratic equation has two differtent real roots");
            jsConsole.writeLine("root1 = " + root1 + "  root2 = " + root2);
            console.log.writeLine("root1 = " + root1 + "  root2 = " + root2);
        } else if (discriminant === 0) {
            root1 = root2 = (-coefficientB) / 2 * coefficientA;
            jsConsole.writeLine("The quadratic equation has two equals real roots = " + root1);
            console.log("The quadratic equation has two equals real roots = " + root1);
        } else {
            jsConsole.writeLine("The quadratic equation doesn't have real roots!");
            console.log("The quadratic equation doesn't have real roots!");
        }
    }
}
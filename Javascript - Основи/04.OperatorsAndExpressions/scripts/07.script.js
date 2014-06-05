/*Exercise 7 - Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.*/

function checkPrimeNumber() {
    var number = jsConsole.readInteger("#number"),
        numberSquareRoot,
        isPrime = true;

    if (number > 100 || number < 0) {
        alert("The number must be between 0 and 100");
    }
    else {
        numberSquareRoot = parseInt(Math.sqrt(number));

        for (var counter = 2; counter <= numberSquareRoot; counter++) {
            if (number % counter === 0) {
                isPrime = false;
                break;
            }
        }

        if (isPrime) {
            jsConsole.writeLine("The number " + number + " is prime!");
            console.log("The number " + number + " is prime!");
        }
        else {
            jsConsole.writeLine("The number " + number + " is not prime!");
            console.log("The number " + number + " is not prime!");
           
        }
    }
}
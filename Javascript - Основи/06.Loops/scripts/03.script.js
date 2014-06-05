/*Exercise 3 - Write a script that finds the max and min number from a sequence of numbers*/

function findMaxAndMin() {
    /*global document, console, jsConsole*/
    var numbers = jsConsole.read('#arr'),
        sequence = numbers.split(' '),
        max,
        min;
    
    for (var i = 0; i < sequence.length; i++)
    {
        sequence[i] = parseFloat(sequence[i]);

        if (i === 0) {
            max  = sequence[0];
            min = sequence[0];
        }
        
        if (max < sequence[i]) {
            max = sequence[i];
        }

        if (min > sequence[i]) {
            min = sequence[i];
        }
    }

    jsConsole.writeLine('Max number is: ' + max);
    console.log('Max number is: ' + max);
    jsConsole.writeLine('Min number is: ' + min);
    console.log('Min number is: ' + min);
    jsConsole.writeLine('');
    console.log('');
}
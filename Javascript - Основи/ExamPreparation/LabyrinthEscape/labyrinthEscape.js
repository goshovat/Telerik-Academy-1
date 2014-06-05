function Solve(args) {
	var dimensionMN = args.shift().split(' ').map(Number),
	    currentPositionXY = args.shift().split(' ').map(Number),
        field = [],        
        totalSum = 0,
        totalCells = -1, 
        i,
        j,
        jumpIndex = 0,
        currentNumber = 0,
        answer = '';

    for (i = 0; i < dimensionMN[0]; i += 1) {
        field[i] = new Array(dimensionMN[1]);
        
        for (j = 0; j < dimensionMN[1]; j += 1) {
            currentNumber += 1;
            field[i][j] = currentNumber;
        }
    }
    
    
    while (true) {
        totalSum += field[currentPositionXY[0]][currentPositionXY[1]];
        totalCells += 1;
        
        if (field[currentPositionXY[0]][currentPositionXY[1]] == 0) {
            answer = 'lost ' + totalCells;
            break;
        }

        field[currentPositionXY[0]][currentPositionXY[1]] = 0;

        switch (args[currentPositionXY[0]][currentPositionXY[1]]) {
        case 'l' :
            currentPositionXY[1] -= 1;
            break;
        case 'r' :
            currentPositionXY[1] += 1;
            break;
        case 'u' :
            currentPositionXY[0] -= 1;
            break;
        case 'd' :
            currentPositionXY[0] += 1;
            break;
        }

        if ( (0 > currentPositionXY[0] || currentPositionXY[0] >=  dimensionMN[0]) ||
            (0 > currentPositionXY[1] || currentPositionXY[1] >=  dimensionMN[1]) ) {
            answer = 'out ' + totalSum;
            break;
        }
    }

	return answer;
}

var test1= [
    "3 4",
    "1 3",
    "lrrd",
    "dlll",
    "rddd"
];

var test2 = [
    "5 8",
    "0 0",
    "rrrrrrrd",
    "rludulrd",
    "durlddud",
    "urrrldud",
    "ulllllll"
];

var test3 = [
    "5 8",
    "0 0",
    "rrrrrrrd",
    "rludulrd",
    "lurlddud",
    "urrrldud",
    "ulllllll"
];

console.log(Solve(test1));
console.log(Solve(test2));
console.log(Solve(test3));
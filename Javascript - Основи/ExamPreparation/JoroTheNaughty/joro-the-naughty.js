function Solve(params) {
	var dimensionMNJ = params.shift().split(' ').map(Number),
	    currentPositionXY = params.shift().split(' ').map(Number),
        i,
        j,
        jumps = [],
        totalSum = 0,
        totalJumps = -1, 
        field = [],
        jumpIndex = 0,
        currentNumber = 0,
        answer = '';

    for (i = 0; i < params.length; i += 1) {
        jumps[i] = params[i].split(' ').map(Number);        
    }

    for (i = 0; i < dimensionMNJ[0]; i += 1) {
        field[i] = new Array(dimensionMNJ[1]);
        
        for (j = 0; j < dimensionMNJ[1]; j += 1) {
            currentNumber += 1;
            field[i][j] = currentNumber;
        }
    }
    
    
    while (true) {
        totalSum += field[currentPositionXY[0]][currentPositionXY[1]];
        totalJumps += 1;
        
        if (field[currentPositionXY[0]][currentPositionXY[1]] == 0) {
            answer = 'caught ' + totalJumps;
            break;
        }

        field[currentPositionXY[0]][currentPositionXY[1]] = 0;

        currentPositionXY[0] += jumps[jumpIndex][0];
        currentPositionXY[1] += jumps[jumpIndex][1];

        if ( (0 > currentPositionXY[0] || currentPositionXY[0] >=  dimensionMNJ[0]) ||
            (0 > currentPositionXY[1] || currentPositionXY[1] >=  dimensionMNJ[1]) ) {
            answer = 'escaped ' + totalSum;
            break;
        }

        jumpIndex += 1;

        if (jumpIndex >= jumps.length) {
            jumpIndex = 0;    
        }
    }

	return answer;
}

var test1= [
    '6 7 3',
    '0 0',
    '2 2',
    '-2 2',
    '3 -1'
];

console.log(Solve(test1));

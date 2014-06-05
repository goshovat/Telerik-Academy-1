function solve(args) {
	var dimensionMN = args.shift().split(' ').map(Number),
	    currentPositionXY = [0, 0],
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

        args[i] = args[i].split(' ');
        for (j = 0; j < dimensionMN[1]; j += 1) {
            currentNumber = parseInt(Math.pow(2, i));
            currentNumber += j;
            field[i][j] = currentNumber;
        }
    }
    
    
    while (true) {
        totalSum += field[currentPositionXY[0]][currentPositionXY[1]];
        totalCells += 1;
        
        if (field[currentPositionXY[0]][currentPositionXY[1]] == 0) {
            answer = 'failed at (' + currentPositionXY[0] + ', ' + currentPositionXY[1] + ')';
            break;
        }

        field[currentPositionXY[0]][currentPositionXY[1]] = 0;

        switch (args[currentPositionXY[0]][currentPositionXY[1]]) {
        case 'dl' :
            currentPositionXY[1] -= 1;
            currentPositionXY[0] += 1;
            break;
        case 'dr' :
            currentPositionXY[1] += 1;
            currentPositionXY[0] += 1;
            break;
        case 'ur' :
            currentPositionXY[0] -= 1;
            currentPositionXY[1] += 1;
            break;
        case 'ul' :
            currentPositionXY[0] -= 1;
            currentPositionXY[1] -= 1;
            break;
        }

        if ( (0 > currentPositionXY[0] || currentPositionXY[0] >=  dimensionMN[0]) ||
            (0 > currentPositionXY[1] || currentPositionXY[1] >=  dimensionMN[1]) ) {
            answer = 'successed with ' + totalSum;
            break;
        }
    }

	return answer;
}

var test1 =[
  '3 5',
  'dr dl dr ur ul',
  'dr dr ul ur ur',
  'dl dr ur dl ur'   
]


var test2 = [
  '3 5',
  'dr dl dl ur ul',
  'dr dr ul ul ur',
  'dl dr ur dl ur'   
]



console.log(solve(test1));
console.log(solve(test2));
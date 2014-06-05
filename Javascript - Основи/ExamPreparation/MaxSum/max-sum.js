function Solve(params) {
    var n = params.shift(),
        array = params.map(Number),
        answer = array[0],
        currentSum = 0,
        i,
        j;
    
    for (i = 0; i < n; i++) {
        currentSum = 0;

        for (j = i; j < n; j++) {
            currentSum += array[j];

            if (currentSum > answer) {
                answer = currentSum;
            }
        }
    }
    
    return answer;
}

var test1 = [
    '8',
    '1',
    '6',
    '-9',
    '4',
    '4',
    '-2',
    '10',
    '-1'
];

var test2 = [
    '6',
    '1',
    '3',
    '-5',
    '8',
    '7',
    '-6'
];

var test3 = [
    '9',
    '-9',
    '-8',
    '-8',
    '-7',
    '-6',
    '-5',
    '-1',
    '-7',
    '-6'
];

console.log(Solve(test1));
console.log(Solve(test2));
console.log(Solve(test3));
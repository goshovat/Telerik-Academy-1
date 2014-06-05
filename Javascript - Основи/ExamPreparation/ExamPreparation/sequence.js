function Solve(params) {
	var N = parseInt(params.shift()),
	    answer = 1,
        array = params.map(Number),
        i,
        currentNum = array[0];

    for (i = 1; i < array.length; i += 1) {
        if (currentNum > array[i]) {
            answer += 1;
        }

        currentNum = array[i];
    }

	return answer;
}

var test1= [
    7,
    1,
    2,
    -3,
    4,
    4,
    0,
    1
];

var test2 = [
    6,
    1,
    3,
    -5,
    8,
    7,
    -6
];

var test3 = [
   6,
1,
3,
-5,
8,
7,
8,
9,
10

];

console.log(Solve(test1));
console.log(Solve(test2));
console.log(Solve(test3));
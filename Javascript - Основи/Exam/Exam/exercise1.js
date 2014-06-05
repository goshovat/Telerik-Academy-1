function solve( params ) {
    var s = parseInt( params[0] );
    var count = 0;
    var wheels = [3, 4, 10],
        indexCar = 0,
        indexTruck = 0,
        indexTrike = 0,
        currentSum = 0,
        array = [];

    for ( var i = 0; currentSum < s; i++ ) {
        currentSum += i * wheels[2];
        for ( var j = 0; currentSum < s; j++ ) {
            currentSum += j * wheels[1];

            
            for ( var k = 0; currentSum < s; k++ ) {
                currentSum += k * wheels[0];

                if ( currentSum === s ) {
                    count += 1;
                    currentSum -= k * wheels[0];
                    break;
                }

                if ( currentSum < s ) {
                    currentSum -= k * wheels[0];
                }



                if ( currentSum > s ) {
                    currentSum -= k * wheels[0];
                    break;
                }
            }

            if ( currentSum === s ) {
                count += 1;
                currentSum -= j * wheels[1];
                break;
            }

            if ( currentSum < s ) {
                currentSum -= j * wheels[1];
            }



            if ( currentSum > s ) {
                currentSum -= j * wheels[1];
                break;
            }
        }

        if ( currentSum === s ) {
            count += 1;
            currentSum -= i * wheels[2];
            break;
        }

        if ( currentSum < s ) {
            currentSum -= i * wheels[2];
        }

        

        if ( currentSum > s ) {
            currentSum -= i * wheels[2];
            break;
        }
    }

    return count;
}

var test1 = [
    7
];

var test2 = [
    10
];
var test3 = [
    40
]
;

//console.log( solve( test1 ) );
//console.log( solve( test2 ) );
console.log( solve( test3 ) );

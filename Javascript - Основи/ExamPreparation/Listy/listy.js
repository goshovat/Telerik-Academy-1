function Solve(lines) {
	var result,
        variables = {},
        line,
        i,
        j,
        separators = [' ', ','];

Array.prototype.clean = function(deleteValue) {
  for (var i = 0; i < this.length; i++) {
    if (this[i] == deleteValue) {         
      this.splice(i, 1);
      i--;
    }
  }
  return this;
};

    function execute(array, operation) {
        var executeResult = 0;

        for (var index = 0; index < array.length; index += 1) {
            var number = parseInt(array[index]);
            if (isNaN(number)) {
                array.splice(index, 1);
                if (elements[array[index]].hasOwnProperty('length)')) {
                    for (var j = 0 ; j< elements[array[index]].length; j += 1) {
                        array.splice(index, 0, elements[array[index][j]]);
                    }
                }
                else {
                    array.splice(index, 0, elements[array[index]]);
                }
            }
        }

        switch(operation) {
        case 'min' :
        executeResult = array[0];

            for (var index = 0; index < array.length; index += 1) {
                if (executeResult > array[i]) {
                    executeResult = array[i];
                }
            }

            break;
        case 'max' :
            executeResult = array[0];

            for (var index = 0; index < array.length; index += 1) {
                if (executeResult < array[i]) {
                    executeResult = array[i];
                }
            }
            break;
        case 'average' :
            var counter = 0;

            for (var index = 0; index < array.length; index += 1) {
                executeResult += parseInt(array[index]);
                counter += 1;
            }

            executeResult = executeResult / counter;

            break;
        case 'sum':
            for (var index = 0; index < array.length; index += 1) {
                executeResult += parseInt(array[index]);
            }
            break;
        }

        return executeResult;
    }


    function isOperation(checker) {
        switch(checker) {
        case 'min' :
        case 'max' :
        case 'average' :
        case 'sum':
            return true;
        default:
            return false;
        }
    }

	for (i = 0; i < lines.length; i += 1) {
        lines[i] = lines[i].replace('[', ' ');
        lines[i] = lines[i].replace(']', ' ');
        var elements = lines[i].split(new RegExp(separators.join('|'), 'g'));
        elements = elements.clean('');
        
        if (elements[0] === 'def') {
            if (isOperation(elements[2])) {
                var variable = execute(elements.slice(3), elements[2]);
                variables[elements[1]] = variable;
            }
            else {
                variables[elements[1]] = elements.slice(2);
            }

            if (i === lines.length - 1) {
                result = variables[element[1]];
            }
        }
        else if (isOperation(elements[0])) {
            result = execute(elements.slice(1), elements[0]);
        } else if (variables.hasOwnProperty(elements[0])) {
            result = variables[elements[0]];
        }
        

	}
        
	return result;
}

var test1 = [
    'def func sum[5, 3, 7, 2, 6, 3]',
    'def func2 [5, 3, 7, 2, 6, 3]',
    'def func3 min[func2]',
    'def func4 max[5, 3, 7, 2, 6, 3]',
    'def func5 avg[5, 3, 7, 2, 6, 3]',
    'def func6 sum[func2, func3, func4 ]',
    'sum[func6, func4]'
];

var test2 = [
    'def func sum[1, 2, 3, -6]',
    'def newList [func, 10, 1]',
    'def newFunc sum[func, 100, newList]',
    '[newFunc]'
];

console.log(Solve(test1));
console.log(Solve(test2));
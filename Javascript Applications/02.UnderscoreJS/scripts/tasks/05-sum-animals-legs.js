define(['tasks/animals', 'underscore'], function(animals, _){
    var task = 'By a given array of animals, find the total number of legs, Each animal can have 2, 4, 6, 8 or 100 legs',
    elements;

    elements = _.map(animals, function(animal){
        return JSON.stringify(animal);
    });

    function sumLegs() {
        var totalSum = _.reduce(animals, function(memo, animal){
            return memo + animal.legs;
        }, 0);

        return 'Total sum of animal\'s legs is ' + totalSum;
    }

    return {
        task: task,
        elements: elements,
        execute: sumLegs
    }
});
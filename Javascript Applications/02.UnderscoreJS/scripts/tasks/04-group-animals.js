define(['tasks/animals', 'underscore'], function(animals, _){
    var task = 'Write a function that by a given array of animals, groups them by species and sorts them by number of legs',
    elements;

    elements = _.map(animals, function(animal){
        return JSON.stringify(animal);
    });

    function groupAnimals() {
        var   groupedAnimals = _.sortBy(animals, 'legs');

        groupedAnimals = _.groupBy(groupedAnimals, 'species');


        return _.map(groupedAnimals, function(item){
            return JSON.stringify(item);
        });
    }


    return {
        task: task,
        elements: elements,
        execute: groupAnimals
    }
});
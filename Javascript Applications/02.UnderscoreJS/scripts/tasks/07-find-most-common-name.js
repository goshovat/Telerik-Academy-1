define(['tasks/students', 'underscore'], function(students, _){
    var task = 'By an array of people find the most common first and last name. Use underscore.',
        elements;

    elements = _.map(students, function(student){
        return JSON.stringify(student);
    });

    function findMostCommonNames() {
        var groupFirstNames = _.groupBy(students, function(student){
            return student.firstName;
        });

        var groupLastNames = _.groupBy(students, function(student){
            return student.lastName;
        });



        var mostPopularFirstName = _.max(groupFirstNames, function(item){
            return item.length;
        });

        var mostPopularLastName = _.max(groupLastNames, function(item){
            return item.length;
        });

        return 'Most popular first name is ' + mostPopularFirstName[0].firstName
            + ' and most popular last name is ' + mostPopularLastName[0].lastName;
    }

    return {
        task: task,
        elements: elements,
        execute: findMostCommonNames
    }
});
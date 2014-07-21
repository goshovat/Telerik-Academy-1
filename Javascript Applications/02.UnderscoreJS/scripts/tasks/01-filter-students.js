define(['tasks/students', 'underscore'], function(students, _){
    var task = 'Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Print the students in descending order by full name. Use Underscore.js',
    elements;

    elements = _.map(students, function(student){
        return JSON.stringify(student);
    });

    function filterStudents() {
        var filteredStudents = _.filter(students, function(student) {
            return student.firstName < student.lastName;
        });

        return _.map(filteredStudents, function(item){
            return JSON.stringify(item);
        });
    }


    return {
        task: task,
        elements: elements,
        execute: filterStudents
    }
});
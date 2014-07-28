define(['tasks/students', 'underscore'], function(students, _){
    var task = 'Write a function that by a given array of students finds the student with highest marks',
        elements;

    elements = _.map(students, function(student){
        return JSON.stringify(student);
    });

    function findStudentWithHighestMarks() {
        var student = _.max(students, function(student){
            return student.mark;
        });

    return JSON.stringify(student);

    }

    return {
        task: task,
        elements: elements,
        execute: findStudentWithHighestMarks
    }
});
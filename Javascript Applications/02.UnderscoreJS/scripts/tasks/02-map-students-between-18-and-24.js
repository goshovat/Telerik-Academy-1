define(['tasks/students', 'underscore'], function (students, _) {
    var task = 'Write function that finds the first name and last name of all students with age between 18 and 24. Use Underscore.js',
        MIN_RANGE = 18,
        MAX_RANGE = 24,
        elements;

    elements = _.map(students, function(student){
        return JSON.stringify(student);
    });

    function mapStudentsBetween18And24() {
        var mappedStudents = _.filter(students, function (student) {
            return MIN_RANGE <= student.age && student.age <= MAX_RANGE;
        });

        mappedStudents = _.map(mappedStudents, function(student) {
            return {
                firstName: student.firstName,
                lastName: student.lastName
            }
        });

        return _.map(mappedStudents, function(item){
            return JSON.stringify(item);
        });
    }


    return {
        task: task,
        elements: elements,
        execute: mapStudentsBetween18And24
    }
});
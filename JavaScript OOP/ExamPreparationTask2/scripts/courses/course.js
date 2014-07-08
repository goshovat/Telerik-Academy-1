define(['courses/student'], function (Student) {
    var Course = (function () {

        function sortStudents(sortBy) {
            var sortedStudents = this._students.slice(0);

            sortedStudents.sort(function (student1, student2) {
                return student2[sortBy] - student1[sortBy];
            });

            return sortedStudents;
        }

        function Course(title, formulate) {
            this._title = title;
            this._formulate = formulate;
            this._students = [];

            return this;
        }


        Course.prototype.addStudent = function (student) {
            if (!(student instanceof Student)) {
                throw new TypeError('You must submit a Student!');
            }

            this._students.push(student);
            return this;
        };

        Course.prototype.calculateResults = function () {
            var self = this;

            this._students.forEach(function (student) {
                student.totalScore = self._formulate(student);
            });

            return this;
        };

        Course.prototype.getTopStudentsByExam = function (count) {
            if (!(parseInt(count, 10))) {
                count = this._students.length;
            }

            return sortStudents.call(this, 'exam').slice(0, count);
        };


        Course.prototype.getTopStudentsByTotalScore = function (count) {
            if (!(parseInt(count, 10))) {
                count = this._students.length;
            }

            if (!this._totalScores ||
                this._totalScores.length !== this._students.length) {
                this.calculateResults();
            }

            return sortStudents.call(this, 'totalScore').slice(0, count);
        };


        return Course;
    }());

    return Course;
});
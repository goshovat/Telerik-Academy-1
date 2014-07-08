define(function () {
    var Student = (function () {


        function Student(info) {
            this._name = info.name;
            this._exam = info.exam;
            this._homework = info.homework;
            this._attendance = info.attendance;
            this._teamwork = info.teamwork;
            this._bonus = info.bonus;

            return this;
        }




        return Student;
    }());

    return Student;
});
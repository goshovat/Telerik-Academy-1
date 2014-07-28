(function () {
    'use strict';
    require.config({
        paths: {
            'jquery': 'libs/jquery-1.11.1.min',
            'handlebars': 'libs/handlebars-v1.3.0',
            'underscore': 'libs/underscore',
            'taskone': 'tasks/01-filter-students',
            'tasktwo': 'tasks/02-map-students-between-18-and-24',
            'taskthree': 'tasks/03-filter-students-by-marks',
            'taskfour': 'tasks/04-group-animals',
            'taskfive': 'tasks/05-sum-animals-legs',
            'tasksix': 'tasks/06-find-most-popular-author',
            'taskseven': 'tasks/07-find-most-common-name'
        }, shim: {
            "handlebars": {
                exports: "Handlebars"
            },
            underscore: {
                exports: '_'
            }
        }
    });

    require(['jquery', 'handlebars', 'taskone', 'tasktwo', 'taskthree', 'taskfour', 'taskfive', 'tasksix', 'taskseven'],
        function ($, Handlebars, taskOne, taskTwo, taskThree, taskFour, taskFive, taskSix, taskSeven) {
            var tasks = [taskOne, taskTwo, taskThree, taskFour, taskFive, taskSix, taskSeven];

            function executeTask() {
                var exercise = tasks[$(this).find(':selected').val() - 1],
                    postTemplateHTML,
                    postTemplate;

                postTemplateHTML = $('#template').html();

                postTemplate = Handlebars.compile(postTemplateHTML);

                $('#container').html(postTemplate(
                    {
                        task: exercise.task,
                        elements: exercise.elements,
                        result: exercise.execute()
                    }));

            }

            executeTask.call($('#selected-task'));

            $('#selected-task').on('change', executeTask);
        });
}());
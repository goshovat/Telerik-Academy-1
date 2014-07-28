(function () {
    'use strict';
    require.config({
        paths: {
            'jquery': 'libs/jquery',
            'handlebars': 'libs/handlebars-v1.3.0',
            'underscore': 'libs/underscore',
            'sammy': 'libs/sammy',
            'chat': 'logic/chat',
            'log-in': 'logic/log-in',
            'http-requester': 'logic/http-requester'
        }, shim: {
            "handlebars": {
                exports: "Handlebars"
            },
            underscore: {
                exports: '_'
            }
        }
    });

    require(['jquery', 'sammy', 'log-in', 'chat'], function($, Sammy, logIn, chat) {
        var app = Sammy('#container', function () {

            this.get("#/log-in", function () {
                logIn.show();
            });

            this.get("#/chat", function () {
                chat.show();
            });
        });

        app.run('#/log-in');
    });
}());
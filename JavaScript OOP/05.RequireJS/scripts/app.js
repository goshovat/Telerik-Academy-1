(function() {
    require.config({
        paths: {
            "jquery": "libs/jquery-1.11.1.min",
            "handlebars": "libs/handlebars-v1.3.0",
            "controls": "modules/controls",
            "container": "modules/container",
            "dropdown": "modules/dropdown",
            "selected-option": "modules/selected-option"
        },
        shim: {
            "handlebars" : {
                exports: "Handlebars"
            }
        }
    });

    require(["controls", "jquery", "container", "dropdown", "selected-option"], function(controls, $, container, dropdown, selectedOption) {
        var people = [
            { name: "Brazil", titles: 5, avatarUrl: "images/brazil.jpg" },
            { name: "Colombia", titles: 0, avatarUrl: "images/colombia.jpg" },
            { name: "France", titles: 1, avatarUrl: "images/france.jpg" },
            { name: "Germany", titles: 3, avatarUrl: "images/germany.jpg" },
            { name: "Netherlands", titles: 0, avatarUrl: "images/netherlands.jpg" },
            { name: "Costa Rica", titles: 0, avatarUrl: "images/costa-rica.jpg" },
            { name: "Argentina", titles: 2, avatarUrl: "images/argentina.jpg" },
            { name: "Belgium", titles: 0, avatarUrl: "images/belgium.jpg" }
        ];
        var comboBox = new controls.ComboBox(people);
        var template = $("#team-template").html();
        var comboBoxHtml = comboBox.render(template);
        container.append(comboBoxHtml);

        comboBox = new controls.ComboBox(people.slice(0, 1));
        comboBoxHtml = comboBox.render(template);

        selectedOption.append(comboBoxHtml);
        selectedOption.find('.team-item').removeClass('team-item');
        container.dropdown();
    });
}());
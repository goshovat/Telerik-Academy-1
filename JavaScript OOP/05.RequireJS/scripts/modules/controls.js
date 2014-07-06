define(["handlebars", "jquery"], function(Handlebars, $){
    var people;

    function ComboBox (items){
        people = items;
    }

    ComboBox.prototype.render = function(template) {
        var source = Handlebars.compile(template),
            result = source(
            {
                people: people
            });

        return result;
    };

    return {
        ComboBox: ComboBox
    };
});
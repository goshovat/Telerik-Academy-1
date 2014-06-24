var items = [{
    value: 1,
    text: 'One'
}, {
    value: 2,
    text: 'Two'
}, {
    value: 3,
    text: 'Three'
}, {
    value: 4,
    text: 'Four'
}, {
    value: 5,
    text: 'Five'
}, {
    value: 6,
    text: 'Six'
}, {
    value: 7,
    text: 'Seven'
}];

var templateNode = document.getElementById('post-template'),
    postTemplateHtml = templateNode.innerHTML,
    postTemplate = Handlebars.compile(postTemplateHtml);

document.body.innerHTML += postTemplate(
    {
        options: items
    });
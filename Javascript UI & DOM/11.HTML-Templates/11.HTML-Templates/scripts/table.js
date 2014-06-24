var lectures = [{
    id: 0,
    title: 'Course Introduction',
    firstDate: 'Wed 18:00, 28-May-2014',
    secondDate: 'Thus 14:00, 29-May-2014'
}, {
    id: 1,
    title: 'Document Objec Model',
    firstDate: 'Wed 18:00, 28-May-2014',
    secondDate: 'Thus 14:00, 29-May-2014'
}, {
    id: 2,
    title: 'HTML5 Canvas',
    firstDate: 'Thus 18:00, 29-May-2014',
    secondDate: 'Fri 14:00, 30-May-2014'
}, {
    id: 3,
    title: 'Kinect JS Overview',
    firstDate: 'Thus 18:00, 29-May-2014',
    secondDate: 'Fri 14:00, 30-May-2014'
}, {
    id: 4,
    title: 'SVG and RaphaelJS',
    firstDate: 'Wed 18:00, 04-Jun-2014',
    secondDate: 'Thus 14:00, 05-Jun-2014'
}, {
    id: 5,
    title: 'Animations with Canvas and SVG',
    firstDate: 'Wed 18:00, 04-Jun-2014',
    secondDate: 'Thus 14:00, 05-Jun-2014'
}];
var templateNode = document.getElementById('post-template'),
    postTemplateHtml = templateNode.innerHTML,
    postTemplate = Handlebars.compile(postTemplateHtml);

document.body.innerHTML += postTemplate(
    {
        lectures: lectures
    });
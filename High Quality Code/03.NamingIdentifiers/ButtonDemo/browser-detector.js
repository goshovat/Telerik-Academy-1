/*global window, alert*/
function onButtonClick() {
    var userAppCodeName = window.navigator.appCodeName;

    if (userAppCodeName === 'Mozilla') {
        alert('This is Mozilla');
    } else {
        alert('This is not Mozilla');
    }
}
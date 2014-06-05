/*global console, alert, document*/

function toArray(list) {
    return Array.prototype.slice.call(list || []);
}

function querySelectorAll(selector) {
    if (/^[\w\-]+$/.test(selector)) {
        return toArray(document.getElementsByTagName(selector));

    } else if (/^#[\w\-]+$/.test(selector)) {
        return [document.getElementById(selector.slice(1))];

    } else if (/^\.[\w\-]+$/.test(selector)) {
        var allEls = toArray(document.getElementsByTagName('*')),
          className = selector.slice(1),
          pattern = new RegExp('\\b' + className + '\\b');

        return allEls.filter(function (item) {
            return pattern.test(item.className);
        });

    }
}

if (typeof document.querySelectorAll !== 'function') {
    document.querySelectorAll = querySelectorAll;
}

document.querySelectorAllShim = querySelectorAll;

function querySelector(selector) {
    return querySelectorAll(selector)[0];
}

if (typeof document.querySelectorAll !== 'function') {
    document.querySelectorAll = querySelectorAll;
}

document.querySelectorShim = querySelector;

function testShims() {
    var selectorsAll = ['li'],
        selector = ['body'];

    selectorsAll.forEach(function (selector) {
        console.group('Elements matched by qeurySelectorAll:', selector);
        console.log('matches:', document.querySelectorAllShim(selector));
        console.groupEnd();
    });


    selector.forEach(function (selector) {
        console.group('Elements matched by qeurySelector:', selector);
        console.log('matches:', document.querySelectorAllShim(selector));
        console.groupEnd();
    });

    alert("Check the console for the result.");
}
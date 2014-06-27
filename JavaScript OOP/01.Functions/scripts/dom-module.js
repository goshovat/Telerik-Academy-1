(function() {
    var domModule = (function (){
        var self,
            parent,
            child,
            elements,
            buffer = {},
            MAX_SIZE = 100;

        function appendChild (child, parentSelector) {
            parent = document.querySelector(parentSelector);
            parent.appendChild(child);
        }

        function removeChild(parentSelector, childSelector) {
            parent = document.querySelector(parentSelector);
            child = parent.querySelector(childSelector);
            parent.removeChild(child);
        }

        function addHandler (elementSelector, event, functionEvent) {
            var i;
            elements = document.querySelectorAll(elementSelector);

            for(i=0; i < elements.length; i+=1){
                if (elements[i].addEventListener) {
                    elements[i].addEventListener(event, functionEvent, false);
                }
                else{
                    elements.attachEvent("on" + event, functionEvent);
                }
            }
        }

        function appendToBuffer(parentSelector, child){
            parent = document.querySelector(parentSelector);

            if (!buffer[parentSelector]) {
                buffer[parentSelector] = document.createDocumentFragment();
            }

            buffer[parentSelector].appendChild(child);

            if (buffer[parentSelector].childNodes.length === MAX_SIZE) {
                parent.appendChild(buffer[parentSelector]);
                buffer[parentSelector] = null;
            }
        }

        self = {
            appendChild: appendChild,
            removeChild: removeChild,
            addHandler: addHandler,
            appendToBuffer: appendToBuffer
        };


        return self;
    }());

    var div = document.createElement('div'),
        navItem = document.createElement('li'),
        i;

    div.className = 'add';
    navItem.className = 'add';

    //removes li:first-child from ul
    domModule.removeChild("#main-nav ul","li:first-child");

    //add handler to each a element with class button
    domModule.addHandler("a.button", 'click', function(){
        alert("Clicked");
    });

    // Add 100 elements to ul
    for(i= 1; i <= 100; i+=1){
        navItem.textContent = "Added by buffer " + i;
        domModule.appendToBuffer("#main-nav ul", navItem.cloneNode(true));
    }

    // Add 99 elements to buffer #container
    for(i=1; i <100; i+=1){
        div.textContent = "Added by buffer " + i;
        domModule.appendToBuffer("#container", div.cloneNode(true));
    }

    // Uncomment the following line to see that the function work with 100 div elements
    // div.textContent = "Added by buffer " + i;
    // domModule.appendToBuffer("#container", div.cloneNode(true));

    //appends div to #wrapper
    div.textContent = 'Appended to #wrapper';
    div.className = 'append';
    domModule.appendChild(div,"#wrapper");
}());
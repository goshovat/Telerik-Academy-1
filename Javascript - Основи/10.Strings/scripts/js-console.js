(function () {
    function CreateJsConsole(selector) {
        /*global document, jsConsole*/
        /*global jsConsole:true */
        var self = this,
            consoleElement = document.querySelector(selector),
            textArea = document.createElement("p");

        if (consoleElement.className) {
            consoleElement.className = consoleElement.className + " js-console";
        } else {
            consoleElement.className = "js-console";
        }

        consoleElement.appendChild(textArea);

        self.write = function jsConsoleWrite(text) {
            var textLine = document.createElement("span");
            textLine.innerHTML = text;
            textArea.appendChild(textLine);
            consoleElement.scrollTop = consoleElement.scrollHeight;
        };

        self.writeLine = function jsConsoleWriteLine(text) {
            self.write(text);
            textArea.appendChild(document.createElement("br"));
        };

        self.read = function readText(inputSelector) {
            var element = document.querySelector(inputSelector);
            if (element.innerHTML) {
                return element.innerHTML;
            }

            return element.value;
        };

        self.readInteger = function readInteger(inputSelector) {
            var text = self.read(inputSelector);
            return parseInt(text, 10);
        };

        self.readFloat = function readFloat(inputSelector) {
            var text = self.read(inputSelector);
            return parseFloat(text);
        };

        return self;
    }
    jsConsole = new CreateJsConsole("#js-console");
}).call(this);

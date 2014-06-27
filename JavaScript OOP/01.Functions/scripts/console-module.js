var specialConsole = (function () {
    var self,
        formattedString,
        consoleHolder = document.getElementById('special-console'),
        messageParagraph = document.createElement('p'),
        icon = document.createElement('img'),
        newLine = document.createElement('br');

    function toString(elements) {
        var message = elements[0].toString();
        var   formatted;
        var   pieces = message.split(/{|}/);
        var  i;
        var  currentElement;

        for (i = 0; i < pieces.length; i+=1) {
            currentElement = parseInt(pieces[i], 10);
            if (!isNaN(currentElement)) {
                pieces[i] = elements[currentElement + 1].toString();
            }
        }

        formatted = pieces.join('');

        return formatted;
    }

    function writeLine() {
        formattedString = toString(arguments);

        messageParagraph.className = 'console-write';
        messageParagraph.textContent = formattedString;
        icon.src = 'images/message.png';

        consoleHolder.appendChild(icon.cloneNode(true));
        consoleHolder.appendChild(messageParagraph.cloneNode(true));
        consoleHolder.appendChild(newLine.cloneNode(true));
        consoleHolder.scrollTop = consoleHolder.scrollHeight;
        console.log(formattedString);
    }

    function writeError() {
        formattedString = toString(arguments);

        messageParagraph.className = 'console-error';
        messageParagraph.textContent = formattedString;
        icon.src = 'images/error.png';

        consoleHolder.appendChild(icon.cloneNode(true));
        consoleHolder.appendChild(messageParagraph.cloneNode(true));
        consoleHolder.appendChild(newLine.cloneNode(true));
        consoleHolder.scrollTop = consoleHolder.scrollHeight;
        console.error(formattedString);
    }

    function writeWarning() {
        formattedString = toString(arguments);

        messageParagraph.className = 'console-warning';
        messageParagraph.textContent  = formattedString;
        icon.src = 'images/warning.png';

        consoleHolder.appendChild(icon.cloneNode(true));
        consoleHolder.appendChild(messageParagraph.cloneNode(true));
        consoleHolder.appendChild(newLine.cloneNode(true));
        consoleHolder.scrollTop = consoleHolder.scrollHeight;
        console.warn(formattedString);
    }

    self = {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    };

    return self;
}());

specialConsole.writeLine("Message: hello");
//logs to the console "Message: hello"
specialConsole.writeLine("Message: {0}", "hello");
//logs to the console "Message: hello"
specialConsole.writeError("Error: {0}", "Something happened");
specialConsole.writeWarning("Warning: {0}", "A warning");


function writeLineToConsole() {
    var line = document.getElementById('message-to-write').value;

    if (line) {
        specialConsole.writeLine("Message: {0}", line);
        document.getElementById('message-to-write').value = '';
    } else {
        specialConsole.writeWarning("Warning: {0}", "You must enter message to display it!");
    }
}

function writeWarningToConsole() {
    var line = document.getElementById('message-to-write').value;

    if (line) {
        specialConsole.writeWarning("Warning: {0}", line);
        document.getElementById('message-to-write').value = '';
    } else {
        specialConsole.writeWarning("Warning: {0}", "You must enter message to display it!");
    }
}

function writeErrorToConsole() {
    var line = document.getElementById('message-to-write').value;

    if (line) {
        specialConsole.writeError("Error: {0}", line);
        document.getElementById('message-to-write').value = '';
    } else {
        specialConsole.writeWarning("Warning: {0}", "You must enter message to display it!");
    }
}

document.getElementById('button-write').addEventListener('click', writeLineToConsole);
document.getElementById('button-error').addEventListener('click', writeErrorToConsole);
document.getElementById('button-warning').addEventListener('click', writeWarningToConsole);
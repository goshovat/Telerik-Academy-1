/*Exercise 7 - Write a script that parses an URL address given in 
    the format:
    [protocol]://[server]/[resource]
    and extracts from it the [protocol], [server] and 
    [resource] elements. Return the elements in a JSON object.
    For example from the URL http://www.devbg.org/forum/index.php 
    the following information should be extracted:
    {protocol: "http",
    server: "www.devbg.org", 
    resource: "/forum/index.php"}
*/
/*global document, console, jsConsole*/

function parseUrl(url) {
    var i,
        startIndex,
        stopIndex,
        elements = {
            protocol: '',
            server: '',
            resource: '',
            toString: function () {
                return 'Protocol: ' + this.protocol +
                    ' Server: ' + this.server +
                    ' Resource: ' + this.resource;
            }
        };

    startIndex = url.indexOf(':', 0);
    elements.protocol = url.substring(0, startIndex);

    stopIndex = url.indexOf('/', startIndex + 3);
    elements.server = url.substring(startIndex + 3, stopIndex);
    elements.resource = url.substr(stopIndex);

    return elements;
}

function main() {
    var url = jsConsole.read('#url'),
    elements = parseUrl(url);
    
    jsConsole.writeLine(elements);
    console.log(elements);
    jsConsole.writeLine('');
    console.log('');
}

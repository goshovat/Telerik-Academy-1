function solve(args) {
    var i;
     var   keysNumber = parseInt(args.shift());
       var keys = args.slice(0, keysNumber);
       var keysObj = {};
    var modelNumber = parseInt(args.splice(keysNumber, 1));
    
    var models = args.slice(0);

    var procedure = {};

    if (typeof String.prototype.startsWith != 'function') {
      // see below for better implementation!
      String.prototype.startsWith = function (str){
        return this.indexOf(str) == 0;
      };
    }

    for(var i = 0; i < models.length; i ++) {
        var row = models[i].toString();
        if(row.startsWith('@section')) {
            var section = models.shift();
            section =section.replace('@section ', '');
            section =section.replace('{', '');
            procedure[section] = [];

            while(models[i] !== '}') {
                 var content = models.shift();
                    procedure[section].push(content);
            }
              var content = models.shift();
              i--;
        }
    }



    for (var i = 0; i < keysNumber; i++) {
       keys[i] = keys[i].split(':');

       if (keys[i][1].indexOf(',') > - 1) {
           //array
           keys[i][1] = keys[i][1].split(',');
           var num = keys[i][1][0];
           if (!isNaN(num)) {
               keys[i][1] = keys[i][1].map(Number);
            }
        }

        keysObj[keys[i][0]] = keys[i][1];
    }

    for (i = 0; i < models.length; i++) {
        var indexOfAt =  models[i].indexOf('@');
        if(indexOfAt > -1 && models[i][indexOfAt + 1] !== '@') {
            var proper = '';
            for (var j = indexOfAt + 1; j < models[i].length; j++) {
                var char = models[i][j];
                if (char === ' ' || char === '<') {
                    break;
                }
                proper += char;
            }

            var indexOfBraket = proper.indexOf('(');
            if (indexOfBraket !== -1) {
                proper = proper.substring(0, indexOfBraket)
               }

            if (proper=== 'renderSection') {
                var firstIndex = models[i].indexOf('"');
                 var lastIndex = models[i].lastIndexOf('"');
                 var sectionName = models[i].substring(firstIndex + 1, lastIndex);
                 models.splice(i, 1);

                 for (var j; j < procedure[sectionName].length; j ++) {
                        models.splice(i, 0, procedure[section][j]);
                }
            }
            else {
                  models[i] = models[i].replace('@' + proper, keysObj[proper]);
           }
        }
    }

    for (var i = 0; i < models.length; i++) {
        console.log(models[i]);
    }
}

var test1 = [
'0',
'15',
'<div>',
'    <p>',
'    @@if (pesho)',
'        @@escaped dude',
'    </p>',
'    <p>',
'    @@renderSection("pesho")',
'    </p>',
'    <p>',
'    @@foreach(var pesho in peshos)',
'        @@escaped in comment',
'    </p>',
'</div>'
];


solve(test1);
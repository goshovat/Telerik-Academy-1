/// <reference path="kinetic-v5.1.0.min.js" />
/*global Kinetic, window*/

var boxWidth = 120,
    boxHeight = 35,
    fontSize = 10,
    levelStartHeight = 10,
    levelStep = 65,
    widthStep = boxWidth + 20,
    posX = 400,
    posXStep = 2 * widthStep;

function Family(mother, father, childs) {
    this.mother = mother;
    this.father = father;
    this.children = childs || [];
    this.isFemale = false;
    return this;
}

Family.prototype.hasChild = function (name) {
    var i,
        child;

    for (i = 0; i < this.children.length; i += 1) {
        child = this.children[i];

        if (child.mother === name || child.father === name) {
            return true;
        }
    }
};

function parseData(info) {
    var result = [],
        index,
        family;

    for (index = 0; index < info.length; index += 1) {
        family = new Family(info[index].mother,
            info[index].father,
            info[index].children);

        result.push(family);
    }

    return result;
}

function buildDictionary(info) {
    var dictionary = [],
        index,
        name,
        mother,
        father,
        family,
        childName,
        leaf;

    for (index = 0; index < info.length; index += 1) {
        mother = info[index].mother;
        father = info[index].father;

        dictionary[mother] = info[index];
        dictionary[father] = info[index];
    }

    for (name in dictionary) {
        family = dictionary[name];

        for (index = 0; index < family.children.length; index += 1) {
            childName = family.children[index];

            if (dictionary[childName] && !(childName instanceof Family)) {
                family.children[index] = dictionary[childName];

                if (dictionary[childName].mother === childName) {
                    dictionary[childName].isFemale = true;
                }
            }
            else if (!(childName instanceof Family)) {
                leaf = new Family(null, childName);
                dictionary[childName] = leaf;
                family.children[index] = leaf;
            }
        }
    }

    return dictionary;
}

function findRoot(tree, dictionary) {
    var root = null,
        i,
        j,
        mother,
        father,
        isRoot;

    for (i = 0; i < tree.length; i += 1) {
        mother = tree[i].mother;
        father = tree[i].father;
        isRoot = true;

        for (j = 0; j < tree.length; j += 1) {
            if (i === j) {
                continue;
            }

            if (tree[j].hasChild(mother) || tree[j].hasChild(father)) {
                isRoot = false;
                break;
            }
        }

        if (isRoot) {
            root = tree[i];
            break;
        }
    }

    return dictionary[root.mother];
}



function makeConnection(leftParentX, leftParentY, childX, childY, layer) {
    var startX = leftParentX + boxWidth * 1.25,
        startY = leftParentY + boxHeight / 2 - 4,
        endX = childX + boxWidth / 2,
        endY = childY,
        beizerCPdx,
    beizerCPdY,
    currLine;

    function innerGetBezierLine(stX, stY, eX, eY) {
        beizerCPdx = Math.abs(eX - stX) / 10;
        beizerCPdY = Math.abs(eY - stY) * 0.95;
        currLine = new Kinetic.Shape({
            drawFunc: function (context) {
                context.beginPath();
                context.moveTo(stX, stY);
                context.bezierCurveTo(stX + beizerCPdx, stY + beizerCPdY,
                    eX - beizerCPdx, eY - beizerCPdY,
                    eX, eY);
                context.strokeShape(this);
                context.beginPath();
                context.lineTo(eX + 5, eY - 5);
                context.lineTo(eX - 5, eY - 5);
                context.lineTo(eX, eY);
                context.fillShape(this);
            },
            strokeWidth: 1,
            fill: 'green',
            stroke: 'green'
        });


        layer.add(currLine);
    }

    innerGetBezierLine(startX, startY, endX, endY, layer);
}



function createRect(posX, posY, height, radius) {
    var rect = new Kinetic.Rect({
        x: posX,
        y: posY,
        width: boxWidth,
        stroke: 'green',
        strokeWidth: 1,
        height: height,
        cornerRadius: radius
    });
    return rect;
}

function createLine(posX, posY) {
    var line = new Kinetic.Line({
        points: [0, 0, boxWidth - widthStep, 0],
        stroke: 'green',
        strokeWidth: 2
    });
    line.move({
        x: posX + widthStep,
        y: posY + boxHeight / 2 - 5
    });
    return line;
}

function getFamilyText(posX, posY, text) {
    var familyText = new Kinetic.Text({
        x: posX,
        y: posY,
        width: boxWidth,
        padding: 10,
        text: text,
        fontSize: fontSize,
        fill: 'black',
        align: 'center'
    });
    return familyText;
}

function addFigureToLayer(layer, posX, posY, text, radius) {
    var familyText = getFamilyText(posX, posY, text),
        familyFigure = createRect(posX, posY, familyText.height(), radius);
    layer.add(familyFigure);
    layer.add(familyText);
}

function drawSubTree(layer, root) {
    var child,
        x,
        line,
        i;

    if (root.father) {
        addFigureToLayer(layer, root.posX, root.level, root.father || "", 5);
    }

    if (root.mother) {
        addFigureToLayer(layer, root.posX + widthStep, root.level, root.mother || "", 17);
    }

    if (root.father && root.mother) {
        line = createLine(root.posX, root.level);
        layer.add(line);
    }

    for (i = 0; i < root.children.length; i += 1) {
        child = root.children[i];
        x = child.posX + boxWidth / 2;

        if (child.father === null || child.isFemale) {
            x += widthStep;
        }

        makeConnection(root.posX - 20, root.level, x - 50, child.level - 1, layer);
    }
}

function drawFamilyTree(layer, root) {
    var queue = [],
        i,
        child,
        paddingRight,
        family;

    root.level = levelStartHeight;
    root.posX = posX;
    queue.push(root);

    while (queue.length > 0) {
        family = queue.shift();

        for (i = 0; i < family.children.length; i += 1) {
            child = family.children[i];
            child.level = family.level + levelStep;
            child.num = i;

            paddingRight = 0;

            if (family.children.length > 1) {
                paddingRight = widthStep * (family.children.length - 1);
            }

            child.posX = family.posX + posXStep * i - paddingRight;
            queue.push(family.children[i]);
        }

        drawSubTree(layer, family);
    }
}








var familyMembers = [{
    mother: 'Nikolina Hristova',
    father: 'Mario Hristov',
    children: ['Toni Jekova', 'Stoil Hristov']
}, {
    mother: 'Julia Simeonova',
    father: 'Stoil Hristov',
    children: ['Nikolay Hristov', 'Peter Hristov']
}, {
    mother: 'Victoria Georgieva',
    father: 'Nikolay Hristov',
    children: ['Ivana Marinova', 'Lidia Marinova']
}, {
    mother: 'Toni Jekova',
    father: 'Svetoslav Jekov',
    children: ['Kiril Jekov']
}, {
    mother: 'Cura Hristova',
    father: 'Peter Hristov',
    children: ['Iliana Dobreva']
}
];

window.onload = function () {
    var stage, layer, families, dictionary, root;

    stage = new Kinetic.Stage({
        container: 'the-container',
        width: 1376,
        height: 768
    });

    layer = new Kinetic.Layer();

    families = parseData(familyMembers);
    dictionary = buildDictionary(families);
    root = findRoot(families, dictionary);

    drawFamilyTree(layer, root);
    stage.add(layer);
};

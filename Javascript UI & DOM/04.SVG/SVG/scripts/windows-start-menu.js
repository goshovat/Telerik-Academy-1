

function createText(posX, posY, content, fillColor, fontSize, fontFamily, fontWeight) {
    if (fontSize === undefined) {
        fontSize = 9.5;
    }

    if (fontFamily === undefined) {
        fontFamily = "Arial";
    }

    if (fontWeight === undefined) {
        fontWeight = "normal";
    }

    if (fillColor === undefined) {
        fillColor = "#fff";
    }

    var text = '<text x="';
    text += posX;
    text += '" y="';
    text += posY;
    text += '" fill="';
    text += fillColor;
    text += '" font-size="';
    text += fontSize;
    text += 'px" font-weight="';
    text += fontWeight;
    text += '" font-family="';
    text += fontFamily;
    text += '" >';
    text += content;
    text += '</text>';

    return text;
}

function createRect(posX, posY, width, height, fillColor) {
    var rect = '<rect x="';
    rect += posX;
    rect += '" y="';
    rect += posY;
    rect += '" width="';
    rect += width;
    rect += '" height="';
    rect += height;
    rect += '" style="fill:';
    rect += fillColor;
    rect += ';" />';

    return rect;
}

function addImage(posX, posY, src, w, h) {
    if (w === undefined) {
        w = "70px";
    }

    if (h === undefined) {
        h = "70px"
    }

    var image = '<image xlink:href="';
    image += src;
    image += '" x="';
    image += posX + 15;
    image += '" y="';
    image += posY + 10;
    image += '" height="' + w + '" width="' + h + '"/>';

    return image;
}

function createSmall(posX, posY, color, text, icon) {
    var result = createRect(posX, posY, 100, 100, color);
    result += createText(posX + 10, posY + 90, text);

    if (icon !== undefined) {
        result += addImage(posX, posY, icon);
    }

    return result;
}

function createBig(posX, posY, color, text, icon) {
    var result = createRect(posX, posY, 205, 100, color);
    result += createText(posX + 10, posY + 90, text);

    if (icon !== undefined) {
        result += addImage(posX + 50, posY, icon);
    }

    return result;
}
var svgNS = 'http://www.w3.org/2000/svg',
    svg = document.createElementNS(svgNS, 'svg'),
    svgJS = document.getElementById('svg-js');

svg.innerHTML += createRect(0, 0, 1057.868, 662, "#06173F", "");
svg.innerHTML += createText(100, 90, "Start", "#fff", 30, "Arial");
svg.innerHTML += createText(905.7, 67, "Richard", "#FFFFFF", 21.4);
svg.innerHTML += createText(951.7,  84, "Perry", "#FFFFFF", 11.5);
svg.innerHTML += addImage(970, 40, "/pictures/avatar.png", "35px", "35px");

// Row 1
svg.innerHTML += createSmall(100, 150, "#2b86f0", "Store", "/pictures/store.png");
svg.innerHTML += createSmall(205, 150, "#66b311", "xBox", "/pictures/games.png");
svg.innerHTML += createBig(310, 150, "#be1c4b", "Photos", "/pictures/picture.png");
svg.innerHTML += createBig(520, 150, "#009118", "Calendar");
svg.innerHTML += createText(655.7, 202.9, "12", "#FFFFFF", 55.7);
svg.innerHTML += createText(660.8, 214.4, "monday", "#FFFFFF", 8.8);

svg.innerHTML += createBig(770, 150, "#5e3ab8", "Music", "/pictures/music.png");
svg.innerHTML += addImage(965, 90, "/pictures/dolar.png", "200px", "90px");

// Row 2
svg.innerHTML += createSmall(100, 255, "#5d39b5", "Maps", "/pictures/map.png");
svg.innerHTML += createSmall(205, 255, "#2b86f0", "Internet", "/pictures/internet.png");
svg.innerHTML += createBig(310, 255, "#5d39b5", "Messaging", "/pictures/message.png");
svg.innerHTML += createBig(520, 255, "#d9532d", "");
svg.innerHTML += addImage(505, 200, "/pictures/people.png", "170px", "60px");
svg.innerHTML += createText(586.2, 285.9, "Mike Gibbs, Troll Scout", "#FFFFFF", 11.6);
svg.innerHTML += createText(586.2, 299.9, "and 5 others commented", "#FFFFFF", 11.6);
svg.innerHTML += createText(586.2, 313.8, "on your photo.", "#FFFFFF", 11.6);
svg.innerHTML += createBig(770, 255, "#009017", "Finance", "/pictures/stats.png");
svg.innerHTML += createBig(980, 255, "#0062a6", "");
svg.innerHTML += addImage(965, 195, "/pictures/penguin.png", "200px", "90px");

//Row 3
svg.innerHTML += createBig(100, 360, "#da552c", "Videos", "/pictures/video.png");
svg.innerHTML += createBig(310, 360, "#009a18", "");
svg.innerHTML += createText(324.8, 390.1, "Devon Hypnotize", "#FFFFFF", 19.3);
svg.innerHTML += createText(324.8, 402.7, "something they can do about him", "#FFFFFF", 10.5);
svg.innerHTML += createText(324.8, 415.4, "pile of books and scrollnext to", "#FFFFFF", 10.5);
svg.innerHTML += createText(501.5, 456.1, "3", "#FFFFFF", 13.6);
svg.innerHTML += createSmall(520, 360, "#000", "");
svg.innerHTML += addImage(505, 350, "/pictures/planet.png", "100px", "100px");
svg.innerHTML += createSmall(625, 360, "#2e88ee", "Solitaire", "/pictures/cards.png");
svg.innerHTML += createSmall(770, 360, "#d7512a", "Reader", "/pictures/reader.png");
svg.innerHTML += createSmall(875, 360, "#012a6a", "");
svg.innerHTML += addImage(875, 355, "/pictures/folder.png", "80px", "80px");
svg.innerHTML += createSmall(980, 360, "#267beb", "SkyDrive", "/pictures/skydrive.png");

//Row 4
svg.innerHTML += addImage(80, 405, "/pictures/desktop.png", "200px", "210px");
svg.innerHTML += createBig(310, 465, "#2d8bef", "Weather", "/pictures/weather.png");
svg.innerHTML += createSmall(520, 465, "#bc1c4a", "Camera", "/pictures/photo.png");
svg.innerHTML += createSmall(625, 465, "#5aa518", "Xbox Smth", "/pictures/xbox.png");
svg.innerHTML += addImage(750, 405, "/pictures/news.png", "200px", "210px");

svgJS.appendChild(svg);
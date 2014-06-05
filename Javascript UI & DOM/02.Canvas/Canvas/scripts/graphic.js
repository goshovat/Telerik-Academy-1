/*global document*/
var canvas = document.getElementById('the-canvas');
var context = canvas.getContext('2d');
var violetColor = '#975B5B';
context.strokeRect(0, 0, 800, 600);

//***********House***********
context.fillStyle = violetColor;
context.lineWidth = 2;
context.beginPath();
context.moveTo(420, 260);
context.lineTo(700, 260);
context.lineTo(560, 100);
context.lineTo(420, 260);
context.lineTo(420, 475);
context.lineTo(700, 475);
context.lineTo(700, 260);
context.fill();
context.stroke();

context.beginPath();
context.moveTo(620, 220);
context.lineTo(620, 139);
context.lineTo(650, 139);
context.lineTo(650, 220);
context.fill();
context.stroke();

context.beginPath();
context.moveTo(620, 139);
context.quadraticCurveTo(635, 130, 650, 139);
context.quadraticCurveTo(635, 148, 620, 139);
context.fill();
context.stroke();

context.fillStyle = 'black';
context.fillRect(435, 280, 110, 70);
context.fillRect(575, 280, 110, 70);
context.fillRect(575, 370, 110, 70);

context.strokeStyle = violetColor;
context.beginPath();
context.moveTo(435, 315);
context.lineTo(690, 315);
context.stroke();

context.beginPath();
context.moveTo(575, 405);
context.lineTo(690, 405);
context.stroke();

context.beginPath();
context.moveTo(490, 280);
context.lineTo(490, 385);
context.stroke();

context.beginPath();
context.moveTo(630, 280);
context.lineTo(630, 460);
context.stroke();

// Door
context.strokeStyle = 'black';
context.beginPath();
context.moveTo(455, 475);
context.lineTo(455, 400);
context.stroke();

context.save();
context.beginPath();
context.scale(1, 0.6);
context.arc(490, 400 / 0.6, 35, 0, Math.PI, true);
context.restore();
context.stroke();

context.beginPath();
context.moveTo(525, 400);
context.lineTo(525, 475);
context.stroke();

context.beginPath();
context.moveTo(490, 475);
context.lineTo(490, 380);
context.stroke();

// Door's left handle
context.beginPath();
context.arc(480, 440, 3, 0, 2 * Math.PI, true);
context.stroke();


// Door's right handle
context.beginPath();
context.arc(500, 440, 3, 0, 2 * Math.PI, true);
context.stroke();

//***********Face***********
//Ellipse face
context.strokeStyle = '#22545F';
context.fillStyle = '#90CAD7';
context.save();
context.beginPath();
context.scale(1, 0.9);
context.arc(100, 300 / 0.9, 50, 0, 2 * Math.PI, true);
context.restore();
context.fill();
context.stroke();

//Left eye
context.save();
context.beginPath();
context.scale(1, 0.7);
context.arc(70, 280 / 0.7, 8, 0, 2 * Math.PI, true);
context.restore();
context.fill();
context.stroke();

//Right eye
context.save();
context.beginPath();
context.scale(1, 0.7);
context.arc(105, 280 / 0.7, 8, 0, 2 * Math.PI, true);
context.restore();
context.fill();
context.stroke();

//Left eye retina
context.fillStyle = '#22545F';
context.save();
context.beginPath();
context.scale(0.6, 1);
context.arc(68 / 0.6, 280, 5, 0, 2 * Math.PI, true);
context.restore();
context.fill();

//Right eye retina
context.save();
context.beginPath();
context.scale(0.6, 1);
context.arc(103 / 0.6, 280, 5, 0, 2 * Math.PI, true);
context.restore();
context.fill();

//Nose
context.beginPath();
context.moveTo(88, 280);
context.lineTo(75, 305);
context.lineTo(88, 305);
context.stroke();

// Mouth
context.save();
context.beginPath();
context.rotate(10 * Math.PI / 180);
context.scale(1, 0.3);
context.arc(138, 303 / 0.3, 20, 0, 2 * Math.PI);

context.restore();
context.stroke();

//Hat bottom
context.fillStyle = '#396693';
context.strokeStyle = 'black';
context.save();
context.beginPath();
context.scale(1, 0.2);
context.arc(95, 255 / 0.2, 55, 0, 2 * Math.PI, true);
context.restore();
context.fill();
context.stroke();

//Hat cylinder
context.beginPath();
context.save();
context.scale(1, 0.3);
context.arc(100, 245 / 0.3, 30, 0, Math.PI);
context.restore();
context.fill();
context.stroke();

context.beginPath();
context.moveTo(70, 245);
context.lineTo(70, 190);
context.lineTo(130, 190);
context.lineTo(130, 245);
context.fill();
context.stroke();

context.beginPath();
context.save();
context.scale(1, 0.3);
context.arc(100, 190 / 0.3, 30, 0, 2 * Math.PI);
context.restore();
context.fill();
context.stroke();

//***********Bicycle***********
//Leftt wheel
context.beginPath();
context.arc(100, 500, 50, 0, 2 * Math.PI);
context.fillStyle = "rgb(144, 202, 215)";
context.fill();
context.strokeStyle = "rgb(81, 150, 166)";
context.stroke();
context.closePath();

//Right wheel
context.beginPath();
context.arc(300, 500, 50, 0, 2 * Math.PI);
context.fillStyle = "rgb(144, 202, 215)";
context.fill();
context.strokeStyle = "rgb(81, 150, 166)";
context.stroke();
context.closePath();

//Chain and the seat
context.beginPath();
context.moveTo(200, 500);
context.lineTo(290, 430);
context.lineTo(160, 430);
context.lineTo(100, 500);
context.lineTo(200, 500);
context.lineTo(140, 410);
context.lineTo(120, 410);
context.lineTo(160, 410);
context.stroke();
context.closePath();

//Chain circle
context.beginPath();
context.arc(200, 500, 20, 0, (360 * Math.PI / 180));
context.stroke();
context.closePath();

//Left pedal
context.beginPath();
context.moveTo(185, 485);
context.lineTo(170, 470);
context.stroke();
context.closePath();

//Right pedal
context.beginPath();
context.moveTo(215, 515);
context.lineTo(230, 530);
context.stroke();
context.closePath();

//Rudder
context.beginPath();
context.moveTo(300, 500);
context.lineTo(285, 385);
context.lineTo(245, 395);
context.moveTo(285, 385);
context.lineTo(325, 355);
context.stroke();
context.closePath();
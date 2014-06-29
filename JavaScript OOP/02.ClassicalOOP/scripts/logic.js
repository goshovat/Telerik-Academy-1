(function() {
    var select = document.getElementById('select-drawer');
    var drawButton = document.getElementById('draw');
    var drawer = new CanvasModule.Drawer();
	var isIE = /*@cc_on!@*/false || !!document.documentMode;
	
    function changeRequiredFromRect(isRequired) {
        if (isRequired) {
            document.getElementById('li-rect-x').required = isRequired;
            document.getElementById('li-rect-y').Required = isRequired;
            document.getElementById('li-rect-width').required = isRequired;
            document.getElementById('li-rect-height').required = isRequired;
        } else {
            document.getElementById('li-rect-x').removeAttribute('required');
            document.getElementById('li-rect-y').removeAttribute('required');
            document.getElementById('li-rect-width').removeAttribute('required');
            document.getElementById('li-rect-height').removeAttribute('required');
        }
    }

    function changeRequiredFromCircle(isRequired) {
        if (isRequired) {
            document.getElementById('li-circle-x').required = isRequired;
            document.getElementById('li-circle-y').required = isRequired;
            document.getElementById('li-circle-radius').required = isRequired;
        } else {
            document.getElementById('li-circle-x').removeAttribute('required');
            document.getElementById('li-circle-y').removeAttribute('required');
            document.getElementById('li-circle-radius').removeAttribute('required');
        }
    }

    function changeRequiredFromLine(isRequired) {
        if (isRequired) {
            document.getElementById('li-line-x1').required = isRequired;
            document.getElementById('li-line-y1').required = isRequired;
            document.getElementById('li-line-x2').required = isRequired;
            document.getElementById('li-line-y2').required = isRequired;
        } else {
            document.getElementById('li-line-x1').removeAttribute('required');
            document.getElementById('li-line-y1').removeAttribute('required');
            document.getElementById('li-line-x2').removeAttribute('required');
            document.getElementById('li-line-y2').removeAttribute('required');
        }
    }

    function drawRect() {
        var x = parseInt(document.getElementById('li-rect-x').value, 10) || 0;
        var y = parseInt(document.getElementById('li-rect-y').value, 10) || 0;
        var width = parseInt(document.getElementById('li-rect-width').value, 10) || 0;
        var height = parseInt(document.getElementById('li-rect-height').value, 10) || 0;
        var strokeColor = document.getElementById('stroke-color').value || 'black';
        var fillColor = document.getElementById('fill-color').value || 'none';
        var strokeWidth = parseInt(document.getElementById('stroke-width').value, 10);
        var rectPoint = new CanvasModule.Point(x, y);
        var rectSize = new CanvasModule.Size(width, height);

        drawer.rect(rectPoint, rectSize, strokeColor, fillColor, strokeWidth);
    }

    function drawCircle() {
        var x = parseInt(document.getElementById('li-circle-x').value, 10) || 0;
        var y = parseInt(document.getElementById('li-circle-y').value, 10) || 0;
        var radius = parseInt(document.getElementById('li-circle-radius').value, 10) || 0;
        var strokeColor = document.getElementById('stroke-color').value || 'black';
        var fillColor = document.getElementById('fill-color').value || 'none';
        var strokeWidth = parseInt(document.getElementById('stroke-width').value, 10);
        var circleCenter = new CanvasModule.Point(x, y);

        drawer.circle(circleCenter, radius, strokeColor, fillColor, strokeWidth);
    }

    function drawLine() {
        var x1 = parseInt(document.getElementById('li-line-x1').value, 10) || 0;
        var y1 = parseInt(document.getElementById('li-line-y1').value, 10) || 0;
        var x2 = parseInt(document.getElementById('li-line-x2').value, 10) || 0;
        var y2 = parseInt(document.getElementById('li-line-y2').value, 10) || 0;
        var strokeColor = document.getElementById('stroke-color').value;
        var strokeWidth = document.getElementById('stroke-width').value;
        var lineStartPoint = new CanvasModule.Point(x1, y1);
        var lineEndPoint = new CanvasModule.Point(x2, y2);

        drawer.line(lineStartPoint, lineEndPoint, strokeColor, strokeWidth);
    }

    function drawShape(ev) {
        switch (select.value) {
            case 'rect':
                drawRect();
                break;
            case 'circle':
                drawCircle();
                break;
            case 'line':
                drawLine();
                break;
        }
    }

    function changeSelected(ev) {
        var selectedId = 'li-' + this.value;
        var currentSelected = document.getElementsByClassName('selected');
        var newSelected = document.getElementById(selectedId);

        currentSelected[0].className = currentSelected[0].className.replace(/\bselected\b/, '');
        newSelected.className = 'selected';

        switch (select.value) {
            case 'rect':
                changeRequiredFromRect(true);
                changeRequiredFromCircle(false);
                changeRequiredFromLine(false);
                break;
            case 'circle':
                changeRequiredFromRect(false);
                changeRequiredFromCircle(true);
                changeRequiredFromLine(false);
                break;
            case 'line':
                changeRequiredFromRect(false);
                changeRequiredFromCircle(false);
                changeRequiredFromLine(true);
                break;
        }
    }
	
	if (isIE) {
		alert('Test it on Chrome or Firefox. See the READ-ME.txt file for more information.');
	}
	else {
		// Submit the form to prevent from losing the first shape when the Draw button
		// is clicked for the first time
		document.forms["draw-form"].submit()
	}
    drawButton.addEventListener('click', drawShape);
    select.addEventListener('change', changeSelected);
}());

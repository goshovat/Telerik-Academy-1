function generateGridView(cellsNumber) {
    var $gridview = $('<div/>'),
		hasHeader = false,
		$table = $('<table/>'),
		$row = $('<tr/>'),
		$cell = $('<td/>'),
		$header = $('<th/>'),
        $addRowBtn = $('<a/>').attr('href', '#').html('Add row'),
        $inputs = [];

        for (var i = 0; i < cellsNumber; i++) {
            var $input = $('<input />').attr('placeholder', 'Enter cell content').attr('type', 'text');
            $inputs.push($input);
        }		

    $addRowBtn.addClass('button');
    var $addHeaderBtn = $addRowBtn.clone(true).html('Add Header'),
		$removeHeaderBtn = $addRowBtn.clone(true).html('Remove Header'),
		$addGridBtn = $addRowBtn.clone(true).html('Add Grid View');

    $gridview.addClass('gridview').css('text-align', 'center');

    for (i in $inputs) {
        $gridview.append($inputs[i]);
    }
	
    $gridview.append($('<br/>'))
	.append($addRowBtn)
	.append($addHeaderBtn)
	.append($removeHeaderBtn)
	.append($addGridBtn)
	.append($table);

    $gridview.on('click', '> .button:first-of-type', function () {
        debugger;
        var $this = $(this).parent(),
			$newRow = $row.clone(true),
			$cells = $this.find('> input');

        for (var i = 0, len = $cells.length; i < len; i++) {
            var $newCell = $cell.clone(true),
				content = $cells[i].value;

            if (content === '') {
                content = '&nbsp;'
            }

            $newCell.html(content);
            $newRow.append($newCell);
        }

        $this.find('> table:first-of-type').append($newRow);
    });

    $gridview.on('click', '> .button:nth-of-type(2)', function () {
        if (hasHeader) {
            return;
        }

        var $this = $(this).parent(),
			$firstRow = $row.clone(true),
			$cells = $this.find('> input');


        for (var i = 0, len = $cells.length; i < len; i++) {
            var $newHeader = $header.clone(true),
				content = $cells[i].value;

            if (content === '') {
                content = '&nbsp;'
            }

            $newHeader.append(content);
            $firstRow.append($newHeader);
        }

        $this.find('> table:first-of-type').prepend($firstRow);
        hasHeader = true;
    });

    $gridview.on('click', '> .button:nth-of-type(3)', function () {
        var $this = $(this).parent();

        if (hasHeader) {
            $this.find('> table:first-of-type').find('tr:first-child').remove();
            hasHeader = false;
        }
    });

    $gridview.on('click', '> .button:last-of-type', function () {
        var $this = $(this).parent(),
			$newRow = $row.clone(true),
			$newCell = $cell.clone(true),
			$newGrid = generateGridView(cellsNumber);

        $newCell.html($newGrid[0]).attr('colspan', cellsNumber);
        $newRow.append($newCell);
        $this.find('> table:first-of-type').append($newRow);
    });

    return $gridview;
};


function createView() {
    $colsNumber = $('#cols-number')[0].value | 0;

    if ($colsNumber) {
        if ($colsNumber > 0) {
            $('#container').append(generateGridView($colsNumber));
        } else {
            alert('Please enter a positive number!');
        }
    }
    else {
        alert('Please enter a number!')
    }
}

var $colsNumber;
$('#create').on('click', createView);
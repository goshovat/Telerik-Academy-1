function createCalendar(selector, events) {
    var calendarContainer = document.querySelector(selector);
    var dayContent = document.createElement('div');
    var dayTitle = document.createElement('span');
    var eventContent = document.createElement('div');
    var documentFragment = document.createDocumentFragment();
    var daysName = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
    var days = [];
    var selected = null;
    eventContent.innerHTML = '&nbsp;';

    dayContent.style.display = 'inline-block';
    dayContent.style.border = '1px solid black';
    dayContent.style.width = document.body.clientWidth / 7.5 + 'px';
    dayContent.style.height = document.body.clientWidth / 7.5 + 'px';

    dayTitle.style.display = 'block';
    dayTitle.style.backgroundColor = '#CCCCCC';
    dayTitle.style.borderBottom = '1px solid black';
    dayTitle.style.fontWeight = 'bold';
    dayTitle.style.textAlign = 'center';

    function createDay(number) {
        var clonedDayTitle = dayTitle.cloneNode(true);
        var clonedDayContent = dayContent.cloneNode(true);
        var clonedEventContent = eventContent.cloneNode(true);

        clonedDayTitle.innerHTML = daysName[number % daysName.length] + ' ' + (number + 1) + ' June 2014';

        clonedDayContent.appendChild(clonedDayTitle);
        clonedDayContent.appendChild(clonedEventContent);


        return clonedDayContent;
    }

    function placeEvents(tasks) {
        for (var i = 0; i < tasks.length; i++) {
            var current = days[tasks[i].date - 1].lastElementChild;
            current.innerHTML = tasks[i].hour + ' ' + tasks[i].title;
        }
    }

    function onMouseover(ev) {
        this.firstElementChild.style.backgroundColor = '#999999';
    }

    function onMouseout(ev) {
        if (this !== selected) {
            this.firstElementChild.style.backgroundColor = '#CCCCCC';
        } else {
            this.firstElementChild.style.backgroundColor = 'green';
        }
    }

    function clearCurrentSelected() {
        selected.firstElementChild.style.backgroundColor = '#CCCCCC';
        selected.lastElementChild.style.backgroundColor = '#FFFFFF';
        selected.style.backgroundColor = '#FFFFFF';
    }

    function onClick(ev) {
        if (selected) {
            clearCurrentSelected();
        }

        if (selected === this) {
            clearCurrentSelected();
            selected = null;
        }
        else {
            var children = this.childNodes;
            selected = this;
            selected.style.backgroundColor = "green";

            for (var i = 0; i < children.length; i++) {
                children[i].style.backgroundColor = "green";
            }
        }

    }


    for (var i = 0; i < 30; i++) {
        days.push(createDay(i + 1));
        days[i].addEventListener('mouseover', onMouseover);
        days[i].addEventListener('mouseout', onMouseout);
        days[i].addEventListener('click', onClick);
        documentFragment.appendChild(days[i]);
    }

    placeEvents(events);
    calendarContainer.appendChild(documentFragment);

}
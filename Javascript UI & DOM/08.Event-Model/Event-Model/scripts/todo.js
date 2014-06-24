/*global document*/
var input = document.getElementById('input'),
    addButton = document.getElementById('add'),
    deleteButton = document.getElementById('delete'),
    hideButton = document.getElementById('hide'),
    showButton = document.getElementById('show'),
    taskList = document.getElementById('tasks');

function addItem() {
    var text = input.value,
        newLi = document.createElement('li'),
        newRadio = document.createElement('input');

    newRadio.type = 'radio';
    newRadio.name = 'todoes';
    newLi.appendChild(newRadio);
    newLi.appendChild(document.createTextNode(text));
    taskList.appendChild(newLi);

    input.value = '';
}

function removeItem() {
    var selected = taskList.querySelectorAll(':checked'),
        i,
        par;

    for (i = 0; i < selected.length; i += 1) {
        par = selected[i].parentElement;
        par.parentElement.removeChild(par);
    }
}

function hideItem() {
    var item = taskList.querySelectorAll(':checked')[0],
        par = item.parentElement;

    par.style.display = 'none';
}

function showItems() {
    var hiddenItems = taskList.querySelectorAll('li'),
        i;

    for (i = 0; i < hiddenItems.length; i += 1) {
        hiddenItems[i].style.display = 'list-item';
    }
}

addButton.addEventListener('click', addItem, false);
deleteButton.addEventListener('click', removeItem, false);
hideButton.addEventListener('click', hideItem, false);
showButton.addEventListener('click', showItems, false);
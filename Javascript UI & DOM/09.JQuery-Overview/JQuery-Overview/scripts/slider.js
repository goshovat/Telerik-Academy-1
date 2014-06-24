/// <reference path="jquery-1.11.1.min.js" />

var $slider = $('#container'),
    $image = $('<img/>').attr('src', 'pictures/FIFA-World-Cup-2014-4.jpg'),
    $header = $('<h1/>').text('Hello'),
    $form = $('<form/>').append($('<button/>').text('I am in a form')),
    $anchor = $('<a/>').text('Test link').attr('href', '#'),
    slides = [],
    currentSlide = 0;

slides.push($image);
slides.push($header);
slides.push($form);
slides.push($anchor);

function placeSlide() {
    $('#container').html(slides[currentSlide]);
}

function nextSlide() {
    currentSlide += 1;

    if (currentSlide === slides.length) {
        currentSlide = 0;
    }

    placeSlide();
    resetTimer();
};


function previousSlide() {
    currentSlide -= 1;

    if (currentSlide === -1) {
        currentSlide = slides.length - 1;
    }

    placeSlide();
    resetTimer();
};

$('#next').on('click', nextSlide);
$('#previous').on('click', previousSlide);

placeSlide();

function resetTimer() {
    clearInterval(autoSlideChanger);
    autoSlideChanger = setInterval(nextSlide, 5000);
}

var autoSlideChanger = setInterval(nextSlide, 5000);
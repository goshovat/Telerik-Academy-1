/// <reference path="C:\Users\Nikolay\Desktop\Exam-preparation-task-files\Exam-preparation-task-files\task2\Zad 2\Zad 2\jquery.min.js" />
$.fn.tabs = function () {
    var $this = $(this);
    var $all = $this.find('.tab-item-content').hide();

    $this.addClass('tabs-container');

    var $current = $this.children().first().addClass('current').css('margin-right', '-4px');
    
    $current.find('.tab-item-content').show();

   $this.find('.tab-item').on('click', '.tab-item-title', function (){
       var $clicked = $(this);

       $current.find('.tab-item-content').hide();
       $current.removeClass('current');
       $clicked.parent().addClass('current');
       $clicked.parent().find('.tab-item-content').show();
       $current = $clicked.parent();
   });

};
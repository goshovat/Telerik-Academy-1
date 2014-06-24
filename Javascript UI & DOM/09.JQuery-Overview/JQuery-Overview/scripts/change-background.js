/// <reference path="jquery-1.11.1.min.js" />
$('#background').on('change',
   function () {
       $('body').css({ 'background-color': this.value });
   });

<?php
mb_internal_encoding('UTF-8');
$types = array(0=>"Възходящо", 1=>"Низходящо");
$debug = FALSE;
$connection = mysqli_connect('localhost', 'TelerikAdmin', 'qwerty', 'books');
mysqli_query($connection, 'SET NAMES utf8');

if (!$connection) {
    echo 'Error with database !!!';
    exit;
}
?>

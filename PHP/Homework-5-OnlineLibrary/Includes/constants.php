<?php
session_start();
mb_internal_encoding('UTF-8');
$types = array(0=>"Възходящо", 1=>"Низходящо");
$debug = TRUE;
$connection = mysqli_connect('localhost', 'TelerikAdmin', 'qwerty', 'library_homework_5');
mysqli_query($connection, 'SET NAMES utf8');

if (!$connection) {
    echo 'Error with database !!!';
    exit;
}

if (!isset($_SESSION['logged'])) {
    $_SESSION['logged'] = false;
}
?>

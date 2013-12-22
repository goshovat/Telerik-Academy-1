<?php
session_start();

mb_internal_encoding('UTF-8');

$group = array(-1 => 'Всички публикации', 0 => 'C#', 1 => 'PHP', 2 => 'JAVA', 3 => 'JAVASCRIPT', 4 => 'HTML', 5 => 'CSS');

$connection = mysqli_connect('localhost', 'TelerikAdmin', 'qwerty', 'php_homework_3_database');

mysqli_query($connection, 'SET NAMES utf8');

if (!$connection) {
    echo 'Error with database !!!';
    exit;
}

if (!isset($_SESSION['logged'])) {
    $_SESSION['logged'] = false;
}
?>

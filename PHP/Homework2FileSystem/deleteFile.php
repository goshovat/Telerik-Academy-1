<?php
include 'includes'.DIRECTORY_SEPARATOR.'header.php';
if($_GET){
    if(unlink('Users'.DIRECTORY_SEPARATOR.$_SESSION['userId'].DIRECTORY_SEPARATOR.$_GET['name'])){
        $_SESSION['message'] = 'Файлът е изтрит успешно!!!';
    }
    else{
        $_SESSION['message'] = 'Възникна грешка при изтриването на файла!!!';
    }
    header('Location: index.php');
    exit;
}
?>

<?php

include 'includes' . DIRECTORY_SEPARATOR . 'header.php';
if ($_GET) {
    $q = mysqli_query($connection, 
            'DELETE FROM messages 
             WHERE id = "' . $_GET['id'] . '"'
    );

    if (!$q) {
        echo 'error';
        $_SESSION['message'] = 'Възникна грешка при изтриването на публикацията!!!';
    
        echo mysqli_error($connection); // da go mahna
        exit;
    } else {
        $_SESSION['message'] = 'Публикацията е изтрита успешно!!!';
    }
    
    header('Location: index.php');
    exit;
}
?>

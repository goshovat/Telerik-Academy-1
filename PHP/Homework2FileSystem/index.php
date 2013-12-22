<?php

$pageTitle = 'Вход';
include 'includes'.DIRECTORY_SEPARATOR.'header.php';

if ($_SESSION['logged']) {
    header('Location: files.php');
    exit;
}
else{
    $error = FALSE;
    
    checkForMessage();

    if($_POST){
        $error = FALSE;
        // Normalize username and password
        $username=trim($_POST['username']);
        $username = strip_tags(str_replace('!', '', $username));
        $password=trim($_POST['password']);
        
        if(isTryingToChangeTheDirectory($username)){
            echo '<div>Невалидно име!!!</div>';
            $error = TRUE;
        }
        
        if (mb_strlen($username) < 3) {
            echo '<div>Името е прекалено късо!!!</div>';
            $error = TRUE;
        }
        
        if (mb_strlen($password) < 6) {
            echo '<div>Паролата е прекалено късо!!!</div>';
            $error = TRUE;
        }
        
        if(!$error){
            if (checkLogginData($username, $password)) {
                $_SESSION['logged']=true;
                header('Location: index.php');
                exit;
            }
            else{
                echo 'Грешно име или парола!!!';
            }
        }
    }
?>

<div><a href="signUp.php">Регистрация</a></div>

<form method="POST">
    <br>
    <div>Име: <br><input type="text" name="username" maxlength="20" required /></div>
    <div>Парола: <br><input type="password" name="password" maxlength="20" required /></div>
    <div><input type="submit" value="Вход"/></div>
    
 </form>

<?php
}
include 'includes/footer.php';
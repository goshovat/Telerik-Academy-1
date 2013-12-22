<?php

$pageTitle = 'Регистрация';
include 'includes'.DIRECTORY_SEPARATOR.'header.php';

if($_POST){
    $error=FALSE;
    
    // Normalize username and password
    $username=trim($_POST['username']);
    $username = strip_tags(str_replace('!', '', $username));
    $password=trim($_POST['password']);
    $secondPssword=trim($_POST['secondPassword']);
    
    if (mb_strlen($username) < 3) {
        echo '<div>Името е прекалено късо!!!</div>';
        $error = TRUE;
    }
    
    if(isTryingToChangeTheDirectory($username)){
           echo '<div>Невалидно име!!!</div>';
           $error = TRUE;
    }
    
    if(isUserExists($username)){
        echo '<div>Вече съществува потребител с това име!!!</div>';
        $error = TRUE;    
    }
    
    if ($password != $secondPssword) {
        echo '<div>Двете пароли не съвпадат!!!</div>';
        $error = TRUE;
    }
    
    if (mb_strlen($password) < 6) {
        echo '<div>Паролата е прекалено къса!!!</div>';
        $error = TRUE;
    }
    
    if (!$error) {
        $userData=getNewUserNumber().'!'.$username.'!'.$password."\n";
        if(file_put_contents($fileName, $userData, FILE_APPEND)){
            $_SESSION['message'] = 'Регистрацията е успешна';
            header('Location: index.php');
            exit;
        }
    }
}
?>

<div><a href="index.php">Вход в системата</a></div>
<form method="POST">
    <br>
    <div>Име:<br><input type="text" name="username" maxlength="20" /></div>
    <div>Парола:<br><input type="password" name="password" maxlength="20" /></div>
    <div>Повторете паролата:<br><input type="password" name="secondPassword" maxlength="20" /></div>
    <div><input type="submit" name="submit" value="Регистрирай" /></div>
</form>

<?php
include 'includes/footer.php';
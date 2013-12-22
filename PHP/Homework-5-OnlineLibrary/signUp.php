<?php
$pageTitle = 'Регистрация';
include 'includes' . DIRECTORY_SEPARATOR . 'header.php';

if ($_POST) {
    $error = FALSE;

    // Normalize username and password
    $username = normalizeInputedString(trim($_POST['username']), $connection);
    $password = normalizeInputedString(trim($_POST['password']), $connection);
    $secondPssword = normalizeInputedString(trim($_POST['secondPassword']), $connection);
    
    if (!isInputedStringCorrect($username)) {
        echo '<div>Името съдържа непозволени символи!!!</div>';
        $error = TRUE;
    }

    if (mb_strlen($username) < 5 || mb_strlen($username) > 20) {
        echo '<div>Името е прекалено късо или прекалено дълго!!!</div>';
        $error = TRUE;
    }

    if (isUserExists($username, $connection)) {
        echo '<div>Вече съществува потребител с това име!!!</div>';
        $error = TRUE;
    }

    if ($password != $secondPssword) {
        echo '<div>Двете пароли не съвпадат!!!</div>';
        $error = TRUE;
    }

    if (!isInputedStringCorrect($password)) {
        echo '<div>Паролата съдържа непозволени символи!!!</div>';
        $error = TRUE;
    }

    if (mb_strlen($password) < 5 || mb_strlen($password) > 20) {
        echo '<div>Паролата е прекалено къса или прекалено дълга!!!</div>';
        $error = TRUE;
    }

    if (!$error) {
        $sql = 'INSERT INTO users (user_name, user_password)
        VALUES ("' . $username . '", "' . $password . '")';

        if (mysqli_query($connection, $sql)) {
            $_SESSION['message'] = 'Регистрацията е успешна';
            header('Location: signIn.php');
            exit;
        } else {
            echo 'Възникна проблем при регистрацията !!!';
            exit;
        }
    }
}
?>

<div><a href="index.php">Вход в системата</a></div>
<form method="POST">
    <br>
    <div>Име:<br><input type="text" name="username" maxlength="20" required /></div>
    <div>Парола:<br><input type="password" name="password" maxlength="20" required /></div>
    <div>Повторете паролата:<br><input type="password" name="secondPassword" maxlength="20" required /></div>
    <!-- TODO: random generator   -->
    <div><input type="submit" name="submit" value="Регистрирай" /></div>
</form>

<?php
include 'includes/footer.php';
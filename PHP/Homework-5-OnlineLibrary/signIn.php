<?php
// The admin account is : username = PHPMASTER, password = THEMOSTSECRETPASSWORD
$pageTitle = 'Вход';
include 'includes' . DIRECTORY_SEPARATOR . 'header.php';

if ($_SESSION['logged']) {
    header('Location: forum.php');
    exit;
} else {
    $error = FALSE;

    checkForMessage();

    if ($_POST) {
        $error = FALSE;
        
        // Normalize username and password
        $username = normalizeInputedString(trim($_POST['username']), $connection);
        $password = normalizeInputedString(trim($_POST['password']), $connection);

        if (!isInputedStringCorrect($username)) {
            echo '<div>Името съдържа непозволени символи!!!</div>';
            $error = TRUE;
        }

        if (mb_strlen($username) < 5 || mb_strlen($username) > 20) {
            echo '<div>Името е прекалено късо или прекалено дълго!!!</div>';
            $error = TRUE;
        }

        if (!isInputedStringCorrect($password)) {
            echo '<div>Паролатаs съдържа непозволени символи!!!</div>';
             $error = TRUE;
        }
        
        if (mb_strlen($password) < 5 || mb_strlen($password) > 20) {
            echo '<div>Паролата е прекалено къса или прекалено дълга!!!</div>';
            $error = TRUE;
        }

        if (!$error) {
            if (checkLogginData($username, $password, $connection)) {
                $_SESSION['logged'] = true;
                header('Location: index.php');
                exit;
            } else {
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
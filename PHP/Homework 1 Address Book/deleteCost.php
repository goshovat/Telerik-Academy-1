<?php

mb_internal_encoding('UTF-8');
$title = 'Изтриване на разход';
include 'header.php';
if ($_POST) {
    $name = trim($_POST['name']);
    $name = str_replace('!', '', $name);
    $name = mb_convert_case($name, MB_CASE_TITLE, 'utf-8');
    if ($_POST['date'] == 'Днешна дата') {
        $date = date(date('d\.m\.Y'));
    } else {
        $date = trim($_POST['date']);
    }

    $error = false;

    if (mb_strlen($name) < 4) {
        echo '<p>Името е прекалено късо!!!</p>';
        $error = true;
    }

    if (strtotime($date) == false) {
        echo '<p>Невалидна дата!!!</p>';
        $error = true;
    }

    if (!$error) {
        $error = true;
        file_put_contents($fileName, '');
        foreach ($fileContent as $key => $value) {
            $elements = explode('!', $value);
            $elements[1] = mb_convert_case($elements[1], MB_CASE_TITLE, 'utf-8');
            if ($elements[0] == $date && strcasecmp($elements[1], $name) == 0) {
                $error = false;
            } else {
                file_put_contents($fileName, $value, FILE_APPEND);
            }
        }

        if ($error) {
            echo '<p>Записът не е намерен!!!</p>';
        } else {
            echo '<p>Записът е изтрит успешно!!!</p>';
        }
    }
}
?>

<div><a href="index.php">Списък</a></div> 
<div><a href="cost.php">Добави нов разход</a></div>		
<form method="POST">
    <div>Име:<input type="text" name="name" maxlength="100"></div>
    <div>Дата:<input type="text" name="date"maxlength="11" value="Днешна дата"></div>
    <div><input type="submit" value="Изтрий"/></div>
</form>

<?php
include 'footer.php';
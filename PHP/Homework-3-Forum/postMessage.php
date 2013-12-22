<?php
$pageTitle = 'Публикуване на съобщение!!!';
include 'includes' . DIRECTORY_SEPARATOR . 'header.php';

if (!isset($_SESSION['logged']) || !$_SESSION['logged']) {
    header('Location: index.php');
    exit;
}

echo '<div>Здравей, ' . $_SESSION['username'].'</div>';

if ($_POST) {
    $error = FALSE;
    $selectedGroup = $group[trim($_POST['group'])];

    // Normalize name and message
    $name = trim($_POST['name']);
    $name = strip_tags($name);
    $name = mysqli_real_escape_string($connection, $name);

    $message = trim($_POST['message']);
    $message = strip_tags($message);
    $message = mysqli_real_escape_string($connection, $message);

    // Set default name for the message
    if (mb_strlen($name) == 0) {
        $name = 'Неозаглавено';
    } else if (mb_strlen($name) > 256) {
        $error = TRUE;
        echo '<pre>Прекалено дълно име на публикация!!!</pre>';
    }

    if (!$error) {
        $sql = 'INSERT INTO messages (message_label, date, postedBy, message_group, content)
                VALUES ("' . $name . '", "' . date("Y-m-d H:i:s") . '", "' . $_SESSION['username'] . '", "' . $selectedGroup . '", "' . $message . '")';

        if (mysqli_query($connection, $sql)) {
            $_SESSION['message'] = 'Публикацията е успешна';
            header('Location: forum.php');
            exit;
        } else {
            echo 'Възникна проблем при публикуването';
            exit;            
        }
    }
}
?>

<div><a href="forum.php">Форум</a></div> 
<br>
<form method="POST" >
    <div>Заглавие:</div>
    <div><input type="text" name="name" size="20" maxlength="20"  /></div>
    <div>Група:</div>
    <div>
        <select name="group">
            <?php
            $groupLength = count($group) - 1;
            for ($key = 0; $key < $groupLength; $key++) {
                echo '<option value="' . $key . '" />' . $group[$key] . '</option>';
            }
            ?>	
        </select>
    </div>
   <div>Съобщение:</div>    
    <div><textarea name="message" rows="10" cols="50" required></textarea></div>
    <div><input type="submit" name="submit" value="Публикувай" /></div>
</form>

<?php
echo '<div><a href="exit.php" onClick="return confirm(\'Наистина ли искате да излезете от профила си?\')">Изход</a></div>';
include 'includes/footer.php';
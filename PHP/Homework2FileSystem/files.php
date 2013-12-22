<?php
$pageTitle = 'Файлове';
include 'includes' . DIRECTORY_SEPARATOR . 'header.php';
$files = scandir('Users' . DIRECTORY_SEPARATOR . $_SESSION['userId']);

checkForMessage();
?>

<div><a href="upload.php"> Качи</a></div>
<br>
<table border="1" bgcolor="#00FF00">
    <th>Номер</th>
    <th>Име</th>
    <th>Размер</th>
    <?php
    $index = 1;

    if (count($files) > 2) { // First file is  .(current directory) and the second is ..(previous directory)
        foreach ($files as $value) {
            $filePath = 'Users' . DIRECTORY_SEPARATOR . $_SESSION['userId'] . DIRECTORY_SEPARATOR . $value;
            $fileSize = number_format(filesize($filePath) / 1048576, 2);

            if ($value != '.' && $value != '..') {
                echo '<tr>';
                echo '<td>' . $index . '</td>';
                echo '<td><a href="' . $filePath . '">' . $value . '</a></td>';
                echo '<td>' . $fileSize . ' MB</td>';
                echo '<td><a href="deleteFile.php?name=' . $value . '" onClick="return confirm(\'Наистина ли искате да изтриете файла?\')">Изтрий</a></td>';
                echo '</tr>';
                $index++;
            }
        }
    } else {
        echo '<div><tr><td colspan=3>Нямате добавени файлове!!!</td></tr></div>';
    }
    ?>
</table>
<br>
<div><a href="exit.php" onClick="return confirm('Наистина ли искате да излезете от профила си?')">Изход</a></div>

<?php
include 'includes/footer.php';
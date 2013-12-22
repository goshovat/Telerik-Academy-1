<?php
$pageTitle = 'Добавяне на автор';
include 'includes' . DIRECTORY_SEPARATOR . 'header.php';

echo '<br><div><a href="index.php"> Библиотека</a></div><br>';

$sortType = "ASC";
if ($_GET) {
    $sort = trim($_GET['sort_authors']);
    if ($sort == 1) {
        $sortType = "DESC";
    }
}

if ($_POST) {
    $author_name = normalizeInputedString(trim($_POST['author_name']), $connection);
    $error = FALSE;

    if (mb_strlen($author_name) < 3) {
        echo 'Името на автора е прекалено късо!!!';
        $error = TRUE;
    }

    if (!$error) {
        if (isAuthorExists($author_name, $connection)) {
            echo '<pre>Авторът присъства в базата данни!!!</pre>';
        } else {
            $sql = 'INSERT INTO authors (author_name) VALUES ("' . $author_name . '")';

            $q = mysqli_query($connection, $sql);

            if (!$q) {
                echo 'Възникна грешка с базата данни!!!';
                if ($debug) {
                    echo mysqli_error($connection);
                }
                exit;
            } else {
                echo '<pre>Авторът е добавен успешно в базата данни!!!</pre>';
            }
        }
    }
}

$sql = 'SELECT * FROM authors ORDER BY author_name ' . $sortType;
?>

<form method="POST">
    <div>Автор:</div>
    <div><input type="text" name="author_name" ></div>
    <div><input type="submit" name="submit" value="Добави"></div>
</form>

<form method="GET">
    Автори:
    <select name="sort_authors">
        <?php
        foreach ($types as $key => $value) {
            if ($sort == $key) {
                $isSelected = 'selected';
            } else {
                $isSelected = '';
            }
            echo '<option value="' . $key . '" ' . $isSelected . '>' . $value . '</option>';
        }
        ?>      
    </select>
    <input type="submit" value="Сортирай">
</form>

<?php
$q = mysqli_query($connection, $sql);

if (!$q) {
    echo 'Възникна грешка с базата данни!!!';
    if ($debug) {
        echo mysqli_error($connection);
    }
    exit;
} else {
    if ($q->num_rows > 0) {
        $index = 1;
        echo '<table bgcolor="white"><tr bgcolor="magenta"><th>Номер</th><th>Автор</th></tr><tbody align="center">';
        while ($row = mysqli_fetch_assoc($q)) {
            echo '<tr><td>' . $index . '</td><td>';
            echo '<a href="booksOfAuthor.php?author='. $row['author_name'] . '" title="Виж всички книги на ' . $row['author_name'] . '"> '. $row['author_name'] .  '</a></td></tr>';
            $index++;
        }
        echo '</tbody></table>';
    } else {
        echo 'Все още няма въведени книги!!!';
    }
}
?>

<?php
include 'includes/footer.php';
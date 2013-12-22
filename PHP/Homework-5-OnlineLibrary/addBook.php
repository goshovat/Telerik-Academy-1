<?php
$pageTitle = 'Добавяне на книга';
include 'includes' . DIRECTORY_SEPARATOR . 'header.php';

echo '<br><div><a href="index.php"> Библиотека</a></div><br>';

if ($_GET) {
    $book_id = normalizeInputedString(trim($_GET['book_id']), $connection);

    $sql = 'SELECT book_title FROM books WHERE book_id = ' . $book_id;
    $q = mysqli_query($connection, $sql);

    if (!$q) {
        echo 'Възникна грешка!';
        if ($debug) {
            echo mysqli_error($connection);
        }
        exit;
    } else {
        $book = mysqli_fetch_assoc($q)['book_title'];
        $book_length = mb_strlen($book) + 3;
    }
    $readonly = 'readonly';
    $get = true;
} else {
    $book = '';
    $readonly = '';
    $get = false;
    $book_length = 20;
}

if ($_POST) {
    $book_title = normalizeInputedString(trim($_POST['book_title']), $connection);

    $error = FALSE;

    if (mb_strlen($book_title) < 3) {
        echo 'Заглавието на книгата е прекалено късо!!!';
        $error = TRUE;
    }

    if (!$error) {
        if (!$get) {
            $sql = 'INSERT INTO books (book_title) VALUES ("' . $book_title . '")';
        }

        $q = mysqli_query($connection, $sql);

        if (!$q) {
            echo 'Възникна грешка!';
            if ($debug) {
                echo mysqli_error($connection);
            }
            exit;
        } else {
            if (!$get) {
                $book_id = mysqli_insert_id($connection);
            }

            foreach ($_POST['authors'] as $author_id) {
                $sql = 'SELECT * FROM books_authors WHERE book_id = ' . $book_id . ' AND author_id = ' . $author_id;
                $q = mysqli_query($connection, $sql);

                if (!$q) {
                    echo 'Възникна грешка!';
                    if ($debug) {
                        echo mysqli_error($connection);
                    }
                    exit;
                } else {
                    if ($q->num_rows == 0) {
                        $sql = 'INSERT INTO books_authors (book_id, author_id) VALUES (' . $book_id . ', ' . $author_id . ')';
                        $q = mysqli_query($connection, $sql);
                        
                        if (!$q) {
                            echo 'Възникна грешка!';
                            if ($debug) {
                                echo mysqli_error($connection);
                            }
                            exit;
                        }
                    } else {
                        echo '<pre>Един от авторите вече присъства в описанието на книгата!!!</pre>';
                    }
                }
            }
            echo '<pre>Книгата е добавена/обновена успешно!!!</pre>';
        }
    }
}

?>

<form method="POST">

    <div>Заглавие на книга:</div>
    <div><input type="text" name="book_title" value="<?= $book ?>" <?= $readonly ?> size="<?= $book_length ?>" required></div>
    <div>Автор(и):</div>
    <select name="authors[]" multiple required>
        <?php
        $sql = 'SELECT * FROM authors';

        $q = mysqli_query($connection, $sql);

        if (!$q) {
            echo 'Възникна грешка с базата данни!!!';
            exit;
        } else {
            if ($q->num_rows > 0) {
                while ($row = mysqli_fetch_assoc($q)) {
                    echo '<option value=' . $row['author_id'] . '>' . $row['author_name'] . '</option>';
                }
            } else {
                echo 'Все още няма въведени автори!!!';
            }
        }
        ?>
    </select>
    <div><input type="submit" name="submit" value="Добави"></div>

</form>

<?php
include 'includes/footer.php';
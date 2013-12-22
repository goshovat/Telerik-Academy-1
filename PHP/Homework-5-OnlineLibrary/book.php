<?php
$pageTitle = 'Книга';
include 'includes' . DIRECTORY_SEPARATOR . 'header.php';

if ($_GET) {
    $book = normalizeInputedString(trim($_GET['title']), $connection);

    if (!($book_id = isBookExists($book, $connection))) {
        echo '<pre>Непозната книга - ' . $book . ' !!!</pre>';
        echo '<br><div><a href="index.php"> Библиотека</a></div>';
        exit;
    }
} else {
    header('Location: index.php');
    exit;
}

if ($_POST) {
    $error = FALSE;

    // Normalize name and message
    $comment = normalizeInputedString(trim($_POST['comment']), $connection);

    if (mb_strlen($comment) < 3) {
        echo '<pre>Преклено къс коментар!</pre>';
        $error = TRUE;
    }

    if (!$error) {
        $sql = 'INSERT INTO comments (user_id, text, date_time, book_id)
                VALUES (' . $_SESSION['user_id'] . ', "' . $comment . '", "' . date("Y-m-d H:i:s") . '", "' . $book_id . '")';

        if (mysqli_query($connection, $sql)) {
            echo 'Коментарът е добавен успешно.';
        } else {
            echo 'Възникна проблем при публикуването';
            exit;
        }
    }
}

echo '<hr>';
showUserMessage();
?>

<hr>
<br><div><a href="index.php"> Библиотека</a></div>

<?php
$sql = 'SELECT *
        FROM books INNER JOIN books_authors
        ON books.book_id = books_authors.book_id
        INNER JOIN authors
        ON books_authors.author_id = authors.author_id 
        WHERE books.book_title = "' . $book . '" ';


$q = mysqli_query($connection, $sql);


if (!$q) {
    echo 'Възникна грешка!';
    if ($debug) {
        echo mysqli_error($connection);
    }
    exit;
} else {
    if ($q->num_rows > 0) {
        $result = array();

        while ($row = mysqli_fetch_assoc($q)) {
            $result['book_id'] = $row['book_id'];
            $result['book_name'] = $row['book_title'];
            $result['author_name'][] = $row['author_name'];
        }

        echo '<h1>Книга</h1>';

        echo '<table bgcolor="white"><tr bgcolor="yellow"><th>Заглавие</th><th>Автор(и)</th></tr>';
        echo '<tr align="center"><td>' . $result['book_name'] . '</td><td>';

        foreach ($result['author_name'] as $author_name) {
            echo '<a href="booksOfAuthor.php?author=' . $author_name . '" title="Виж всички книги на ' . $author_name . '">' . $author_name . '</a> , ';
        }

        echo '<a href="addBook.php?book_id=' . $result['book_id'] . '" title="Добави автор към тази книга"> + </a></td></tr>';
        echo '</table>';

        $sql = 'SELECT *
        FROM books INNER JOIN (
            SELECT comments.book_id, comments.user_id, comments.text, comments.date_time, users.user_name
            FROM comments
            INNER JOIN users
            ON users.user_id = comments.user_id) AS cmnt
        ON cmnt.book_id = books.book_id  
        WHERE books.book_title = "' . $book . '"  
        ORDER BY cmnt.date_time ASC';
        

        $q = mysqli_query($connection, $sql);

        if (!$q) {
            echo 'Възникна грешка!';
            if ($debug) {
                echo mysqli_error($connection);
            }
            exit;
        } else {
            echo '<h2>Коментари</h2>';

            if ($q->num_rows > 0) {

                $result = array();
                $index = 1;
                while ($row = mysqli_fetch_assoc($q)) {
                    $result['comments'][$index]['date'] = $row['date_time'];
                    $result['comments'][$index]['user'] = $row['user_name'];
                    $result['comments'][$index]['text'] = $row['text'];
                    $index++;
                }

                if (is_array($result['comments']) && count($result['comments']) > 0) {
                    echo '<table bgcolor="white" >';
                    foreach ($result['comments'] as $key => $book_comment) {
                        echo '<tr bgcolor="cyan" align="center"><td>№<b>' . $key . '</b>&nbsp; &nbsp; &nbsp; <i>коментирана от</i>: <b>
                                <a href="user.php?name=' . $book_comment['user'] . '" title="Виж всички коментари на ' . $book_comment['user'] . '">' . $book_comment['user'] . '</a> </b>
                     &nbsp; &nbsp; &nbsp; <i>на</i>: <b>' . $book_comment['date'] . '</b></td></tr>';
                        echo '<tr bgcolor="yellow" align="center"><td>' . $book_comment['text'] . '</td>';
                    }
                    echo '</table>';
                } else {
                    echo '<div>Все още няма коментари към тази книга!</div>';
                }
            } else {
                echo '<div>Все още няма коментари към тази книга!</div>';
            }

            if (isset($_SESSION['username'])) {
                ?>

                <div>
                    <form method="POST">
                        Добави нов коментар:
                        <input type="text" name="comment"/>
                        <input type="submit" value="Коментирай"/>
                    </form>
                </div>

                <?php
            }
        }
    } else {
        echo 'Възникна грешка!!!';
    }
}
?>

<?php
include 'includes/footer.php';
<?php
$pageTitle = 'Книги от автор';
include 'includes' . DIRECTORY_SEPARATOR . 'header.php';

if ($_GET) {
    $author = normalizeInputedString(trim($_GET['author']), $connection);

    if (!isAuthorExists($author, $connection)) {
        echo '<pre>Непознат автор - ' . $author . ' !!!</pre>';
        echo '<br><div><a href="index.php"> Библиотека</a></div>';
        exit;
    }
    if (isset($_GET['search_book'])) {
        $whereClause = normalizeInputedString(trim($_GET['search_book']), $connection);
        if (!$whereClause == '') {
            $whereClause = 'AND books.book_title LIKE "%' . $whereClause . '%" ';
        }
    } else {
        $whereClause = '';
    }
} else {
    header('Location: index.php');
    exit;
}

$sortType = "ASC";
if ($_POST) {
    $sort = trim($_POST['sort_books']);
    if ($sort == 1) {
        $sortType = "DESC";
    }
}

echo '<hr>';
showUserMessage();
?>

<div align="right">
    <form method="GET">
        Заглавие:
        <input type="text" name="author" value="<?php echo $author; ?>" hidden/>
        <input type="text" name="search_book"/>
        <input type="submit" value="Намери"/>
    </form>
</div>
<hr>
<br><div><a href="index.php"> Библиотека</a></div>

<br><div><a href="addBook.php"> Добави нова книга</a></div>

<br><div><a href="addAuthor.php"> Добави нов автор</a></div><br>

<form method="POST">
    Книги:
    <select name="sort_books">

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
    <input type="submit" name="submit" value="Сортирай">
</form>

<?php
$sql = 'SELECT books.book_id, books.book_title, authors.author_name, com.book_comments
        FROM books INNER JOIN books_authors
        ON books.book_id = books_authors.book_id
        INNER JOIN authors
        ON books_authors.author_id = authors.author_id
         LEFT JOIN (
            SELECT comments.book_id, COUNT(comments.book_id) as book_comments
            FROM comments
            GROUP BY comments.book_id) as com
        ON com.book_id = books.book_id
        WHERE books_authors.book_id IN (
            SELECT books_authors.book_id
            FROM books_authors INNER JOIN authors
            ON books_authors.author_id = authors.author_id
            WHERE authors.author_name = "' . $author . '") ' .
        $whereClause . ' ORDER BY books.book_title ' . $sortType . '';

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
            $result[$row['book_id']]['book_name'] = $row['book_title'];
            $result[$row['book_id']]['author_name'][] = $row['author_name'];
            $result[$row['book_id']]['comments'] = $row['book_comments'];
        }

        echo '<table bgcolor="white"><tr bgcolor="cyan"><th>Заглавие</th><th>Автор(и)</th><th>Коментари</th></tr><tbody align="center">';
        foreach ($result as $key => $v) {
            echo '<tr><td><a href="book.php?title=' . $v['book_name'] . '" title="Виж всички коментари за ' . $v['book_name'] . '">' . $v['book_name'] . '</a></td><td>';
            foreach ($v['author_name'] as $vv) {
                echo '<a href="booksOfAuthor.php?author=' . $vv . '" title="Виж всички книги на ' . $vv . '">' . $vv . '</a> , ';
            }
            echo '<a href="addBook.php?book_id=' . $key . '" title="Добави автор към тази книга"> + </a></td>';
            if (isset($v['comments'])) {
                echo '<td>' . $v['comments'] . '</td></tr>';
            } else {
                echo '<td> 0 </td></tr>';
            }
        }
        echo '</tbody></table>';
        echo '</table>';
    } else {
        echo 'Все още няма въведени книги за този автор!!!';
    }
}
?>

<?php
include 'includes/footer.php';
<?php
$pageTitle = 'Библиотека';
include 'includes' . DIRECTORY_SEPARATOR . 'header.php';

if ($_GET) {
    $whereClause = normalizeInputedString(trim($_GET['search_book']), $connection);

    if (!$whereClause == '') {
        $whereClause = 'WHERE books.book_title LIKE "%' . $whereClause . '%" ';
    }
} else {
    $whereClause = '';
}

$sortType = "ASC";
if ($_POST) {
    $sort = trim($_POST['sort_books']);
    if ($sort == 1) {
        $sortType = "DESC";
    }
}

$sql = 'SELECT * 
        FROM books INNER JOIN books_authors
        ON books.book_id = books_authors.book_id
        INNER JOIN authors
        ON books_authors.author_id = authors.author_id ' .
        $whereClause .' ORDER BY books.book_title ' . $sortType;

$q = mysqli_query($connection, $sql);
?>

<div align="right">
    <form method="GET">
        Заглавие:
        <input type="text" name="search_book"/>
        <input type="submit" value="Намери"/>
    </form>
</div>


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
if (!$q) {
    echo 'Възникна грешка с базата данни!!!';
    echo mysqli_error($connection);
    exit;
} else {
    if ($q->num_rows > 0) {
        $result = array();


        while ($row = mysqli_fetch_assoc($q)) {
            $result[$row['book_id']]['book_name'] = $row['book_title'];
            $result[$row['book_id']]['author_name'][] = $row['author_name'];
        }

        echo '<table bgcolor="white"><tr bgcolor="yellow"><th>Заглавие</th><th>Автор(и)</th></tr><tbody align="center">';
        foreach ($result as $key=>$v) {
            echo '<tr><td>' . $v['book_name'] . '</td><td>';
            foreach ($v['author_name'] as $vv) {
                echo '<a href="booksOfAuthor.php?author=' . $vv . '" title="Виж всички книги на ' . $vv . '">' . $vv . '</a> , ';
                
            }
            echo '<a href="addBook.php?book_id=' . $key . '" title="Добави автор към тази книга"> + </a>';
            echo '</td></tr>';
        }
        echo '</tbody></table>';



        echo '</table>';
    } else {
        echo 'Все още няма въведени книги!!!';
    }
}
?>

<?php
include 'includes/footer.php';
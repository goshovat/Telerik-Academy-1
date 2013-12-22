<?php
$pageTitle = 'Потребител';
include 'includes' . DIRECTORY_SEPARATOR . 'header.php';

if ($_GET) {
    $user = normalizeInputedString(trim($_GET['name']), $connection);

    if (!($user_id = isUserExists($user, $connection))) {
        echo '<pre>Невалиден потребител - ' . $user . ' !!!</pre>';
        echo '<br><div><a href="index.php"> Библиотека</a></div>';
        exit;
    }
} else {
    header('Location: index.php');
    exit;
}

echo '<hr>';
showUserMessage();
?>

<hr>
<br><div><a href="index.php"> Библиотека</a></div>

<?php
$sql = 'SELECT *
        FROM books INNER JOIN comments
        ON books.book_id = comments.book_id
        WHERE comments.user_id = ' . $user_id;


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

        echo '<h1>Потренител: <i><b>' . $user . '</b></i></h1>';
        echo '<h2>Коментари</h2>';

        if ($q->num_rows > 0) {
            echo '<table bgcolor="white" >';
            while ($result = mysqli_fetch_assoc($q)) {

                echo '<tr bgcolor="cyan" align="center"><td><i>Книга</i>: <b>
                <a href="book.php?title=' . $result['book_title'] . '" title="Виж всички коментари на ' . $result['book_title'] . '">' . $result['book_title'] . '</a> </b> 
                   &nbsp; &nbsp; &nbsp; <i>коментирана от</i>: <b>' . $user . '</b>
                     &nbsp; &nbsp; &nbsp; <i>на</i>: <b>' . $result['date_time'] . '</b></td></tr>';
                echo '<tr bgcolor="yellow" align="center"><td>' . $result['text'] . '</td>';
            }

            echo '</table>';
        } else {
            echo '<div>Все още няма коментари към тази книга!</div>';
        }
    }
}
?>

<?php
include 'includes/footer.php';



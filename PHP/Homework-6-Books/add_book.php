<?php
include './inc/functions.php';

$data['messages'] = array();
if ($_POST) {
    $book_name = trim($_POST['book_name']);
    if (!isset($_POST['authors'])) {
        $_POST['authors'] = '';
    }
    $authors = $_POST['authors'];
    if (mb_strlen($book_name) < 2) {
         $data['messages'][] = '<p>Невалидно име</p>';
    }
    if (!is_array($authors) || count($authors) == 0) {
         $data['messages'][] = '<p>Грешка</p>';
    }
    if (!isAuthorIdExists($db, $authors)) {
         $data['messages'][] = 'невалиден автор';
    }

    if (count( $data['messages']) == 0) {
        mysqli_query($db, 'INSERT INTO books (book_title) VALUES("' .
                mysqli_real_escape_string($db, $book_name) . '")');
        if (mysqli_error($db)) {
            $data['messages'][] = 'Error';
        }
        $id = mysqli_insert_id($db);
        foreach ($authors as $authorId) {
            mysqli_query($db, 'INSERT INTO books_authors (book_id,author_id)
                VALUES (' . $id . ',' . $authorId . ')');
            if (mysqli_error($db)) {
                $data['messages'][] = 'Error';
                $data['messages'][] = mysqli_error($db);
            }
        }
        $data['messages'][] =  'Книгата е добавена';
    }
}

$data['authors'] = getAuthors($db);
if ($data['authors']===false) {
    $data['messages'][] = 'Грешка';
} 

$data['title'] = 'Нова книга';
$data['content'] = 'templates/add_book_public.php';
exectute($data, 'templates/layouts/normal_layout.php');


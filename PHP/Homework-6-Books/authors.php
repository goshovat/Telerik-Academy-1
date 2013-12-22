<?php
include './inc/functions.php';

if ($_POST) {
    $author_name = trim($_POST['author_name']);
    if (mb_strlen($author_name) < 2) {
        $data['messages'][] = 'Невалидно име';
    } else {
        $author_esc = mysqli_real_escape_string($db, $author_name);
        $q = mysqli_query($db, 'SELECT * FROM authors WHERE
                                author_name="' . $author_esc . '"');
        if (mysqli_error($db)) {
            $data['messages'][] = 'Грешка';
        }

        if (mysqli_num_rows($q) > 0) {
            $data['messages'][] = 'Има такъв автор';
        } else {
            mysqli_query($db, 'INSERT INTO authors (author_name)
            VALUES("' . $author_esc . '")');
            if (mysqli_error($db)) {
                $data['messages'][] = 'Грешка';
            } else {
                $data['messages'][] = 'Успешен запис';
            }
        }
    }
}

$data['authors'] = getAuthors($db);
if ($data['authors']===false) {
    $data['messages'][] = 'Грешка';
} 

$data['title'] = 'Автори';
$data['content'] = 'templates/author_public.php';
exectute($data, 'templates/layouts/normal_layout.php');


<?php

mb_internal_encoding('UTF-8');
$data = array();
$db = mysqli_connect('localhost', 'TelerikAdmin', 'qwerty', 'books');
if (!$db) {
    $data['messages'] = 'No database';
}
mysqli_set_charset($db, 'utf8');


function exectute($data, $name){
    include $name;
}

function getAuthors($db) {
    $q = mysqli_query($db, 'SELECT * FROM authors');
    if (mysqli_error($db)) {
        return false;
    }
    $ret = [];
    while ($row = mysqli_fetch_assoc($q)) {
        $ret[] = $row;
    }
    return $ret;
}

function isAuthorIdExists($db, $ids) {
    if (!is_array($ids)) {
        return false;
    }
    $q = mysqli_query($db, 'SELECT * FROM authors WHERE 
        author_id IN(' . implode(',', $ids) . ')');
    if (mysqli_error($db)) {
        return false;
    }
    
    if (mysqli_num_rows($q) == count($ids)) {
        return true;
    }
    return false;
}
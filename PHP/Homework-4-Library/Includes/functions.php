<?php

// Check if the author already exist in the database
function isAuthorExists($author_name, $connection) {
    $q = mysqli_query($connection, 'SELECT * 
            FROM authors
            WHERE author_name = "' . $author_name . '"'
    );

    if (!$q) {
        echo 'Възникна грешка с базата данни!!!';
        if ($debug) {
            echo mysqli_error($connection);
        }
        exit;
    } else {
        if ($q->num_rows == 0) {
            return false;
        } else {
            return true;
        }
    }
}

//Normalize user input data
function normalizeInputedString($input, $connection) {
    $input = strip_tags($input);
    $input = mysqli_real_escape_string($connection, $input);
    return $input;
}
?>
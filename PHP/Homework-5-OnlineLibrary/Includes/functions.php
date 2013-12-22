<?php

// Check if the author already exist in the database
function isAuthorExists($author_name, $connection) {
    $q = mysqli_query($connection, 'SELECT * 
            FROM authors
            WHERE author_name = "' . $author_name . '"'
    );

    if (!$q) {
        echo 'Възникна грешка!';
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

// Check if the book exists in the database
function isBookExists($book, $connection) {
    $q = mysqli_query($connection, 'SELECT * 
            FROM books
            WHERE book_title = "' . $book . '"'
    );

    if (!$q) {
        echo 'Възникна грешка!';
            echo mysqli_error($connection);
        exit;
    } else {
        if ($q->num_rows == 0) {
            return false;
        } else {
            return mysqli_fetch_assoc($q)['book_id'];
        }
    }
}

//Normalize user input data
function normalizeInputedString($input, $connection) {
    $input = strip_tags($input);
    $input = mysqli_real_escape_string($connection, $input);
    return $input;
}

// Show username or enter 
function showUserMessage() {
    if (isset($_SESSION['username'])) {
        echo '<div align="left"> Здравейте, ' . $_SESSION['username'] . '!  &nbsp;
           <a href="exit.php"> Изход <a></div>';
    } else {
        echo '<div align="left"><a href="signIn.php"> Вход </a></div>';
    }
}

// Check for message from the previous action
function checkForMessage() {
    if (isset($_SESSION['message'])) {
        echo $_SESSION['message'] . '<br>';
        unset($_SESSION['message']);
    }
}

// Check if the user already exist in the file
function isUserExists($username, $connection) {
    $q = mysqli_query($connection, 'SELECT user_name, user_id 
            FROM users 
            WHERE user_name = "' . $username . '"'
    );

    if (!$q) {
        echo 'Възникна грешка с базата данни!!!';
        exit;
    } else {
        if ($q->num_rows == 0) {
            return false;
        } else {
            return mysqli_fetch_assoc($q)['user_id'];
        }
    }
}

// Check inputed string
function isInputedStringCorrect($input) {
    if (!(strcmp($input, strip_tags($input)) == 0)) { // Check for html tags
        return FALSE;
    } else if (strpos($input, '.') !== FALSE) {
        return FALSE;
    } else if (strpos($input, '|') !== FALSE) {
        return FALSE;
    } else if (strpos($input, '\\') !== FALSE) {
        return FALSE;
    } else if (strpos($input, ' ') !== FALSE) {
        return FALSE;
    } else if (strpos($input, ':') !== FALSE) {
        return FALSE;
    } else if (strpos($input, '*') !== FALSE) {
        return FALSE;
    } else if (strpos($input, '?') !== FALSE) {
        return FALSE;
    } else if (strpos($input, '!') !== FALSE) {
        return FALSE;
    } else if (strpos($input, '"') !== FALSE) {
        return FALSE;
    } else if (strpos($input, '~') !== FALSE) {
        return FALSE;
    } else if (strpos($input, '\'') !== FALSE) {
        return FALSE;
    } else if (strpos($input, '+') !== FALSE) {
        return FALSE;
    } else if (strpos($input, '/') !== FALSE) {
        return FALSE;
    } else if (strpos($input, ',') !== FALSE) {
        return FALSE;
    } else if (strpos($input, '[') !== FALSE) {
        return FALSE;
    } else if (strpos($input, ']') !== FALSE) {
        return FALSE;
    } else if (strpos($input, '(') !== FALSE) {
        return FALSE;
    } else if (strpos($input, ')') !== FALSE) {
        return FALSE;
    } else if (strpos($input, '-') !== FALSE) {
        return FALSE;
    } else if (strpos($input, '=') !== FALSE) {
        return FALSE;
    }
    return TRUE;
}

// Check the loggin infromation that user was entered
function checkLogginData($username, $password, $connection) {
    $q = mysqli_query($connection, 'SELECT user_name, user_password, user_id
FROM users 
WHERE user_name = "' . $username . '" AND user_password = "' . $password . '"'
    );

    if (!$q) {
        echo 'Възникна грешка с базата данни!!!';
        exit;
    } else {
        if ($q->num_rows == 0) {
            return false;
        } else {
            $row = $q->fetch_assoc();
            $_SESSION['username'] = $row['user_name'];
            $_SESSION['user_id'] = $row['user_id'];
            return true;
        }
    }
}

?>
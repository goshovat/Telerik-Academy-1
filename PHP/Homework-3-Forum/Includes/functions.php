<?php

// Check for message from the previous action
function checkForMessage() {
    if (isset($_SESSION['message'])) {
        echo $_SESSION['message'] . '<br>';
        unset($_SESSION['message']);
    }
}

// Check for admin
function hasAdmin($connection) {
    $q = mysqli_query($connection, 'SELECT user_name 
            FROM users 
            WHERE isAdmin = 1'
    );

    if (!$q) {
        echo 'Възникна грешка с базата данни!!!';
        exit;
    } else {
        if ($q->num_rows == 0) {
            $sql = 'INSERT INTO users (user_name, user_password, isAdmin)
                    VALUES ("PHPMASTER", "THEMOSTSECRETPASSWORD", 1)';

            if (mysqli_query($connection, $sql)) {
                header('Location: index.php');
                exit;
            } else {
                echo 'Възникна проблем при регистрацията !!!';
            }
        } else {
            return true;
        }
    }
}

// Check if the user already exist in the file
function isUserExists($username, $connection) {
    $q = mysqli_query($connection, 'SELECT user_name 
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
            return true;
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
    $q = mysqli_query($connection, 'SELECT user_name, user_password, isAdmin
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
            $_SESSION['isAdmin'] = $row['isAdmin'];
            return true;
        }
    }
}
?>



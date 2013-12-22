<?php

$fileName = 'Users' . DIRECTORY_SEPARATOR . 'users.txt'; // The document with the information about users

// Check for message from the previous action
function checkForMessage() {
    if (isset($_SESSION['message'])) {
        echo $_SESSION['message'] . '<br>';
        unset($_SESSION['message']);
    }
}

// Check the inputed name for the uploaded file
function checkFileName($name) {
    if (!(strcmp($name, strip_tags($name)) == 0)) { // Check for html tags
        return FALSE;
    } else if (isTryingToChangeTheDirectory($name)) {
        return FALSE;
    } else if (realpath('Users' . DIRECTORY_SEPARATOR . $_SESSION['userId'])) {
        return TRUE;
    }
    return false;
}

// Check the name for characters, which will change the directory
function isTryingToChangeTheDirectory($name) {
    if (stripos($name, './') !== FALSE || stripos($name, '../') !== FALSE) {
        return TRUE;
    }
    return FALSE;
}

// Check if the user already exist in the file
function isUserExists($username) {
    global $fileName;

    if (file_exists($fileName)) {
        $users = file($fileName);

        foreach ($users as $value) {
            $userData = explode('!', $value);
            if ($username == trim($userData[1])) {
                return true;
            }
        }
    }
    return false;
}

//Check the type of the uploaded file
function checkType($type) {
    switch ($type) {
        case 'png':
            return TRUE;
            break;
        case 'jpeg':
            return TRUE;
            break;
        case 'bmp':
            return TRUE;
            break;
        case 'gif':
            return TRUE;
            break;
        case 'raw':
            return TRUE;
            break;
        case 'tiff':
            return TRUE;
            break;
        case 'docx':
            return TRUE;
            break;
        case 'doc':
            return TRUE;
            break;
        case 'ppt':
            return TRUE;
            break;
        case 'txt':
            return TRUE;
            break;
        case 'pptx':
            return TRUE;
            break;
        case 'mdb':
            return TRUE;
            break;
        case 'pdf':
            return TRUE;
            break;
        case 'xls':
            return TRUE;
            break;
        case 'xlsx':
            return TRUE;
            break;
        case 'jpg':
            return TRUE;
            break;
    }
    return FALSE;
}

//If there the file for users don't exist this method will create it and put the default user
function checkUsersDataFile() {
    global $fileName;
    if (!file_exists($fileName)) {
        $defaultUser = '1!user!qwerty' . "\n";
        file_put_contents($fileName, $defaultUser);
        mkdir('Users' . DIRECTORY_SEPARATOR . '1');
    }
}

// Check the loggin infromation that user was entered
function checkLogginData($username, $password) {
    global $fileName;
    if (file_exists($fileName)) {
        $users = file($fileName);

        foreach ($users as $value) {
            $userData = explode('!', $value);
            if ($username == trim($userData[1]) && $password == trim($userData[2])) {
                $_SESSION['userId'] = $userData[0];
                $_SESSION['username'] = $userData[1];
                return true;
            }
        }
    }
    return false;
}

// Get the number of new user and create a folder for him
function getNewUserNumber() {
    global $fileName;
    if (file_exists($fileName)) {
        $data = file($fileName);
        $lastUserData = explode('!', $data[count($data) - 1]);
        $nextUserNumber = $lastUserData[0] + 1;
    } else {
        checkUsersDataFile();
        $nextUserNumber = 2;
    }
    mkdir('Users' . DIRECTORY_SEPARATOR . $nextUserNumber);
    return $nextUserNumber;
}

?>

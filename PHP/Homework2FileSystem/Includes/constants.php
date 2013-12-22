<?php

session_start();

mb_internal_encoding('UTF-8');

if(!isset($_SESSION['logged'])){
    $_SESSION['logged'] = false;
}

?>

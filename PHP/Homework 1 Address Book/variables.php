<?php

$fileName = 'costs.txt';
$fileContent = getRecordings($fileName);

$types = array(-1 => 'Всички видове', 0 => 'Храна', 1 => 'Транспорт', 2 => 'Дрехи', 3 => 'Интернет', 4 => 'Наем');

function getRecordings($name = '') {
    $fileContent = '';
    if (file_exists($name)) {
        $fileContent = file($name);
    }
    return $fileContent;
}

function checkPrice(&$price) {
    $price = str_replace('!', '', $price);
    $price = str_replace(',', '.', $price);
    $elements = explode('.', $price);
    if (count($elements) != 2 && count($elements) != 1) {
        return false;
    } else if ($elements[0] < 0) {
        return false;
    } else {

        if (count($elements) == 2) {
            $elements[0] = (int) $elements[0];
            $length = strlen($elements[1]);
            if ($length > 2) {
                $price = $elements[0] . '.' . substr($elements[1], 0, 2);
            } else if ($length == 1) {
                $price = $elements[0] . '.' . $elements[1] . '0';
            }
        } else {
            $elements[0] = (int)$elements[0];
            $price = $elements[0] . '.00';
        }
    }

    return true;
}

?>
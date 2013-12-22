<?php
mb_internal_encoding('UTF-8');
$title = "Добавяне на разход";
include 'header.php';

if (isset($_GET['action']) && $_GET['action'] == 'insert') {
    $name = '';
    $price = '';
    $typeKey = '';
    $date = 'Днешна дата';
    $buttonName='Добави';
    $inEditMode = false;
} else if (isset($_GET['action']) && $_GET['action'] == 'edit' && isset($_GET['row'])) {
    $rowNumber=$_GET['row'];
    $rowToEdit = $fileContent[$_GET['row']];
    $rowToEdit = explode('!', $rowToEdit);
    $date = $rowToEdit[0];
    $name = $rowToEdit[1];
    $price = $rowToEdit[2];
    $typeKey = $rowToEdit[3];
    $buttonName='Редактирай';
    $inEditMode = true;
}

if ($_POST) {
    $name = trim($_POST['name']);
    $name = str_replace('!', '', $name);
    $price = trim($_POST['price']);
    
    if ($_POST['date'] == 'Днешна дата') {
        $date = date('d.m.Y');
    } else {
        $date = trim($_POST['date']);
    }
    $selectedType = (int) $_POST['type'];
    $error = false;

    if (mb_strlen($name) < 4) {
        echo '<p>Името е прекалено късо!!!</p>';
        $error = true;
    }

    if (!checkPrice($price)) {
        echo '<p>Невалидна цена!!!</p>';
        $error = true;
    }
    
    $dateComponents = explode('.', $date);
    if (count($dateComponents) != 3 || !checkdate((int)$dateComponents[1], (int)$dateComponents[0], (int)$dateComponents[2])) {
        echo '<p>Невалидна дата!!!</p>';
        $error = true; 
    }
    
    if (!array_key_exists($selectedType, $types)) {
        echo '<p>Невалиден тип на разхода!!!</p>';
        $error = true;
    }
    
    if (!$error) {
        $result = $date . '!' . $name . '!' . $price . '!' . $selectedType . "\n";
        if ($inEditMode) {
            $fileContent[$rowNumber] = $result;
            file_put_contents($fileName, '');
            foreach ($fileContent as $value) {
                file_put_contents($fileName, $value, FILE_APPEND);
            }
            echo '<p>Записът е редактиран!!!</p>';
        } else {
            if (file_put_contents($fileName, $result, FILE_APPEND)) {
                echo '<p>Записът е успешен!!!</p>';
            }
        }
    }
}
?>

<div><a href="index.php">Списък</a></div> 
<div><a href="deleteCost.php">Изтрий стар разход</a></div>	
<form method="POST">
    <div>Име:<input type="text" name="name" maxlength="100" value="<?php echo $name ?>" /></div>
    <div>Сума:<input type="text" name="price" maxlength="10" value="<?php echo $price ?>" /></div>
    <div>Дата:<input type="text" name="date" maxlength="11" value="<?php echo $date ?>"></div>
    <div>
        <select name="type">
            <?php
            $typesLength = count($types) - 1;
            for ($key = 0; $key < $typesLength; $key++) {
                if ($typeKey == $key) {
                    $isSelected = 'selected';
                } else {
                    $isSelected = '';
                }
                echo '<option value="' . $key . '" ' . $isSelected . '/>' . $types[$key] . '</option>';
            }
            ?>	
        </select>
    </div>
    <div><input type="submit" value="<?php echo $buttonName ?>" /></div>
</form>

<?php
include 'footer.php';
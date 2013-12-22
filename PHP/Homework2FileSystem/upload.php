<?php

$pageTitle='Качване на файл!!!';
include 'includes'.DIRECTORY_SEPARATOR.'header.php';

if ($_POST) {

    if(count($_FILES)>0){
        $error = FALSE;
        $fileData = explode('.', $_FILES['picture']['name']);
        
        // Normalize fileName
        $fileName = trim($_POST['name']);        
        $fileName = str_replace('|', '', $fileName);
        $fileName = str_replace('\\', '', $fileName);
        $fileName = str_replace(':', '', $fileName);
        $fileName = str_replace('*', '', $fileName);
        $fileName = str_replace('?', '', $fileName);
        $fileName = str_replace('"', '', $fileName);
        
        if(strlen($fileName) == 0){ // Set default name for the file
            $fileName = 'Unnamed';
        }
 
        $fileType = trim($fileData[count($fileData) - 1]);

        if(!checkType($fileType)){
            echo '<div>Непозволен тип на файл!!!</div>';
            $error = TRUE;
        }
        
        if(!checkFileName($fileName)){
            echo '<div>Невалидно име!!!</div>';
            $error = TRUE;
        }
        
        if(!$error){ // If there was no errors with the entered name and uploaded file the program will try to save them
            $filePath = 'Users'.DIRECTORY_SEPARATOR.$_SESSION['userId'].DIRECTORY_SEPARATOR.$fileName.'.'.$fileType;

            if(move_uploaded_file($_FILES['picture']['tmp_name'], $filePath)){
                $_SESSION['message'] = 'Файлът е качен успешно!!!';
            }
            else{
                $_SESSION['message'] = 'Възникна грешка при качването на файла!!!';
            }
            
            header('Location: files.php');
            exit;
        }
        
    }
}
?>

<div><a href="files.php">Галерия</a></div> 
<br>
<form method="POST" enctype="multipart/form-data">
    <div>Име:<input type="text" name="name"  maxlength="30"/></div>
    <div>Файл:<input type="file" name="picture" /></div>
    <div><input type="submit" name="submit" value="Добави" /></div>
</form>

<?php
echo 'Позволени типове файлове: png, jpeg, bmp, gif, raw, tiff, docx, doc, ppt, txt, pptx, mdb, pdf, xls, xlsx<br><br>';
echo '<div><a href="exit.php" onClick="return confirm(\'Наистина ли искате да излезете от профила си?\')">Изход</a></div>';
include 'includes/footer.php';
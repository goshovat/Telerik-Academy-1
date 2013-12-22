
<a href="index.php">Списък</a>

<?php
if (isset($data['messages']) && is_array($data['messages']) && count($data['messages'])) {
    foreach ($data['messages'] as $value) {
        echo '<p>' . $value . '</p>';
        if ($value == "Error") {
            exit;
        }
    }
}
?>

<form method="post" action="add_book.php">
    Име: <input type="text" name="book_name" />
    <div>Автори:<select name="authors[]" multiple style="width: 200px">
            <?php
            foreach ($data['authors'] as $row) {
                echo '<option value="' . $row['author_id'] . '">
                    ' . $row['author_name'] . '</option>';
            }
            ?>
        </select></div>
    <input type="submit" value="Добави" />    

</form>

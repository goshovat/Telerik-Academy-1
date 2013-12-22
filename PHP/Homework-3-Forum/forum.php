<?php
$pageTitle = 'Форум';
include 'includes' . DIRECTORY_SEPARATOR . 'header.php';

if (!isset($_SESSION['logged']) || !$_SESSION['logged']) {     
    header('Location: index.php');
    exit;
}

echo '<div>Здравей, ' . $_SESSION['username'].'</div>';
checkForMessage();

echo '<br><div><a href="postMessage.php"> Добави съобщение</a></div><br>';
?>

<form method="POST">
    <select name="sort">
        <option value="0" > Най-нови</option>
        <option value ="1" > Най-стари</option>
    </select>

    <select name="group">
        <?php
        $groupLength = count($group) - 1;
        for ($key = -1; $key < $groupLength; $key++) {
            echo '<option value="' . $key . '" />' . $group[$key] . '</option>';
        }
        ?>	
    </select>

    <input type="submit" name="submit" value="Филтрирай">
</form>

<?php
if ($_POST) {
    $sort = trim($_POST['sort']);
    $select = $group[trim($_POST['group'])];

    if ($select == 'Всички публикации') {
        $whereClause = ' ';
    } else {
        $whereClause = 'WHERE message_group = "' . $select . '"';
    }

    if ($sort == 0) {
        $sql = 'SELECT id, message_label, date, postedBy, message_group, content 
            FROM messages
            ' . $whereClause . '
            ORDER BY date DESC';
    } else {
        $sql = 'SELECT id, message_label, date, postedBy, message_group, content 
            FROM messages 
            ' . $whereClause . '
            ORDER BY date ASC';
    }
} else {
    $sql = 'SELECT id, message_label, date, postedBy, content, message_group 
        FROM messages ORDER BY date DESC';
}
$q = mysqli_query($connection, $sql);
if (!$q) {
    echo 'Възникна грешка с базата данни!!!';
    exit;
} else {
    if ($q->num_rows > 0) {
        echo '<table bgcolor="#989898">';
        while ($row = $q->fetch_assoc()) {
            echo '<tr>
                    <td colspan="4" align="center" bgcolor="#989898"><i>Заглавие:</i> <b>' . $row['message_label'] . '</b></td>
                  </tr>
                  <tr bgcolor="#A8A8A8">
                    <td><i> &nbsp; &nbsp; &nbsp; публикувано от: </i><b>' . $row['postedBy'] . '</b></td> 
                    <td><i> &nbsp; &nbsp; &nbsp; на: </i><b>' . $row['date'] . '</b></td>
                    <td><i> &nbsp; &nbsp; &nbsp; група: </i><b>' . $row['message_group'] . '</b></td></tr>';

            echo '<tr bgcolor="#C0C0C0"><td colspan=2>' . $row['content'] . '</td>';
            if ($_SESSION['isAdmin']) {
                echo '<td><a href="remove.php?id=' . $row['id'] . '" onClick="return confirm(\'Наистина ли искате да изтриете публикацията?\')">Изтрий</a></td>';
            }
            echo '</tr>';
            echo '<tr><td> &nbsp; </td></tr>';
        }

        echo '</table>';
    } else {
        echo 'Все още няма въведени съобщения';
    }
}
?>
<br>
<div><a href="exit.php" onClick="return confirm('Наистина ли искате да излезете от профила си?')">Изход</a></div>

<?php
include 'includes/footer.php';
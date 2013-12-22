<?php
$title = 'Списък с разходи';
include 'header.php';
$info = array();
$dates = array(-1 => 'Всички дати');

foreach ($fileContent as $value) {
    $info[] = $value;
    $elements = explode('!', $value);
    if (!in_array($elements[0], $dates)) {
        $dates[] = $elements[0];
    }
}
if ($_POST) {
    $typeChoice = trim($_POST['choice']);
    $dateChoice = trim($_POST['wantedDate']);
    $info = array();
    foreach ($fileContent as $value) {
        $sections = explode('!', $value);
        $firstCheck = (int) $typeChoice == -1 && $dateChoice == -1;
        $secondCheck = (int) $typeChoice == -1 && $dates[$dateChoice] == $sections[0];
        $thirdCheck = $typeChoice == (int) $sections[3] && $dateChoice == -1;
        $fourthCheck = $typeChoice == (int) $sections[3] && $dates[$dateChoice] == $sections[0];
        if ($firstCheck || $secondCheck || $thirdCheck || $fourthCheck) {
            $info[] = $value;
        }
    }
}
?>

<div><a href="cost.php?action=insert">Добави нов разход</a></div>
<div><a href="deleteCost.php">Изтрий стар разход</a></div>	
<form method="POST">
    <select name="choice">
        <?php
        foreach ($types as $key => $option) {
            echo '<option value="' . $key . '">' . $option . '</option>';
        }
        ?>
    </select>
    <select name="wantedDate">
        <?php
        foreach ($dates as $keyDate => $currentDate) {
            echo '<option value="' . $keyDate . '">' . $currentDate . '</option>';
        }
        ?>
    </select>
    <input type="submit" value="Филтрирай">

    <table bgcolor="red" border="1" bordercolor="yellow">
        <tr>
            <th>Дата</th>
            <th>Име</th>
            <th>Сума</th>
            <th>Вид</th>
        </tr>

        <?php
        $sum = 0;
        foreach ($info as $row => $value) {
            $data = explode('!', $value);
            $sum+=$data[2];
            echo '<tr>
	  				<td>' . $data[0] . '</td>
					<td>' . $data[1] . '</td>
					<td>' . $data[2] . '</td>
					<td>' . $types[(int) $data[3]] . '</td>
                                        <td><a href="cost.php?action=edit&row=' . $row . '">Редактирай</a></td>
				</tr>';
        }
        echo '<tr>
	  				<td>----</td>
					<td>Общо</td>
					<td>' . $sum . '</td>
					<td>----</td>
				</tr>';
        ?>
    </table>
</form>

<?php
include 'footer.php';
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num1" />
        M: <input type="text" name="num2" />
        <input type="submit" />
    </form>
	<ul>
    <?php
        if(isset($_GET['num1']) && isset($_GET['num2'])) {
            $number1 = intval($_GET['num1']);
            $number2 = intval($_GET['num2']);
            if (filter_var($number1, FILTER_VALIDATE_INT) !== FALSE &&
                filter_var($number2, FILTER_VALIDATE_INT) !== FALSE) {
                for($i = 1; $i <= $number1; $i++) { ?>
                    <li>List <?=$i; ?><ul>
                    <?php for($p = 1; $p <= $number2; $p++): ?>
                        <li>Element <?=$i . "." . $p; ?></li>
                    <?php endfor; ?>
                    </ul></li>
    <?php
                }
            }
        }
    ?>
	</ul>
</body>
</html>
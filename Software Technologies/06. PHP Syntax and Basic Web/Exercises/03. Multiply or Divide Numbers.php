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
	<!--Write your PHP Script here-->
    <?php
    if(isset($_GET['num1']) && isset($_GET['num2']) ) {
        if (filter_var($_GET['num1'], FILTER_VALIDATE_INT) !== FALSE &&
            filter_var($_GET['num2'], FILTER_VALIDATE_INT) !== FALSE) {
            if($_GET['num2'] >= $_GET['num1']) {
                echo intval($_GET['num1']) * intval($_GET['num2']);
            }
            else {
                echo intval($_GET['num1']) / intval($_GET['num2']);
            }
        }
    }
    ?>
</body>
</html>
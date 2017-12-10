<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        X: <input type="text" name="num1" />
		Y: <input type="text" name="num2" />
        Z: <input type="text" name="num3" />
		<input type="submit" />
    </form>
	<!--Write your PHP Script here-->
    <?php
    if(isset($_GET['num1']) &&
       isset($_GET['num2']) &&
       isset($_GET['num3'])) {

        $number1 = intval($_GET['num1']);
        $number2 = intval($_GET['num2']);
        $number3 = intval($_GET['num3']);

        if (filter_var($number1, FILTER_VALIDATE_INT) !== FALSE &&
            filter_var($number2, FILTER_VALIDATE_INT) !== FALSE &&
            filter_var($number3, FILTER_VALIDATE_INT) !== FALSE) {

            if($number1 == 0 || $number2 == 0 || @$number3 == 0) {
                $isPositive = true;
            }
            else {
                $isPositive = ($number1 < 0) ? false : true;
                $isPositive = ($number2 < 0) ? !$isPositive : $isPositive;
                $isPositive = ($number3 < 0) ? !$isPositive : $isPositive;
            }
            echo ($isPositive) ? "Positive" : "Negative";
        }
    }
    ?>
</body>
</html>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>
	<!--Write your PHP Script here-->
    <?php
    if(isset($_GET['num'])) {
        $number = intval($_GET['num']);
        if (filter_var($number, FILTER_VALIDATE_INT) !== FALSE) {
            echo factorial($number);
        }
    }

    function factorial(int $number) : int
    {
        $result = 1;
        for ($i = 1; $i <= $number; $i++) {
            $result *= $i;
        }

        return $result;
    }
    ?>
</body>
</html>
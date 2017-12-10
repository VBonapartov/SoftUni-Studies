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
            $previous = 0;
            $current = 1;
            echo $current . " ";

            for($i = 1; $i <= $number - 1; $i++) {
                $new = $current + $previous;
                $previous = $current;
                $current = $new;
                echo $current . " ";
            }
        }
    }
    ?>
</body>
</html>
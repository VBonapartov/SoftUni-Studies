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
            for($i = $number; $i >= 2; $i--) {
                if(IsPrime($i)) {
                    echo $i . " ";
                }
            }
        }
    }

    function IsPrime(int $number) : bool {
        for($i = 2; $i < $number; $i++) {
            if($number % $i == 0) {
                return false;
            }
        }

        return true;
    }
    ?>
</body>
</html>
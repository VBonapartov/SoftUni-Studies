<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        button {
            display: block;
        }
    </style>
</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>
<?php
    if(isset($_GET['num'])) {
        $number = intval($_GET['num']);
        if (filter_var($number, FILTER_VALIDATE_INT) !== FALSE) {
            for($i = 1; $i <= $number; $i++) {
                echo "<button>$i</button>\n\t";
            }
        }
    }
    ?>
</body>
</html>
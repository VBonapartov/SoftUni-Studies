<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
</head>
<body>
<?php
        $rows = 9;
        $cols = 5;
        for($row = 1; $row <= $rows; $row++) {
            for($col = 1; $col <= $cols; $col++) {
                if($row == 1 || $row == 5 || $row == 9 ||
                  ($col == 1 && $row >= 1 && $row <= 5) ||
                  ($col == 5 && $row >= 5 && $row <= 9)  ) {
                    echo "\t<button style='background-color: blue'>1</button>\n";
                }
                else {
                    echo "\t<button>0</button>\n";
                }
            }
            echo "\t<br/>\n";
        }
    ?>
</body>
</html>
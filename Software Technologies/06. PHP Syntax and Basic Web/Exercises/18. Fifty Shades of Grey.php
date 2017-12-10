<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        div {
            display: inline-block;
            margin: 5px;
            width: 20px;
            height: 20px;
        }
    </style> 
</head>
<body>
<?php
    for($colorIdx = 0; $colorIdx <= 204; $colorIdx += 51) {
        for($step = 0; $step <= 45; $step += 5) {
            $color = $colorIdx + $step;
            echo "\t<div style='background-color: rgb($color,$color,$color)'></div>\n";
        }
        echo "\t<br/>\n";
    }
    ?>
</body>
</html>
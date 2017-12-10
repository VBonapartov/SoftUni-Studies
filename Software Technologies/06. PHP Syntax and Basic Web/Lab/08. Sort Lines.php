<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sort Lines</title>
</head>
<body>

<form>
    <?php
    $sortedLines = "";
    if(isset($_GET['lines'])) {
        $text = $_GET['lines'];
        $lines = explode(PHP_EOL, $text);
        $lines = array_map('trim', $lines);
        sort($lines, SORT_STRING);
        $sortedLines = implode(PHP_EOL, $lines);
    }
    ?>
    <textarea rows="10" name="lines"><?= $sortedLines  ?></textarea> <br>
    <input type="submit" value="Sort">
</form>

</body>
</html>
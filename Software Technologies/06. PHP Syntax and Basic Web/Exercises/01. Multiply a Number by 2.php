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

    <?php
    if(isset($_GET['num'])) {
        if (filter_var($_GET['num'], FILTER_VALIDATE_INT) !== FALSE) {
            echo intval($_GET['num']) * 2;
        }
    }
    ?>
</body>
</html>
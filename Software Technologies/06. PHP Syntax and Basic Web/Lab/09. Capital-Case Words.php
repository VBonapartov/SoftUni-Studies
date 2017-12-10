<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sort Lines</title>
</head>
<body>

<form>
    <form>
        <textarea rows="10" name="text"></textarea><br/>
        <input type="submit" value="Extract">
    </form>

    <?php
    if(isset($_GET['text'])) {
        $text = $_GET['text'];
        preg_match_all("/\b[[:upper:]]+\b/u", $text, $words);
        $words = $words[0];

        $upperWords = array_filter($words, function($word){
            return strtoupper($word) == $word;
        });

        echo implode(", ", $upperWords);
    }
    ?>
</form>

</body>
</html>
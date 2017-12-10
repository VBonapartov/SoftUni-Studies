<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Celsius - Fahrenheit</title>
</head>
<body>
<form>
    <?php
    $msgAfterCelsius = "";
    if(isset($_GET['cel'])) {
        $celsius = floatval($_GET['cel']);
        $fah = celsiusToFahrenheit($celsius);
        $msgAfterCelsius = "$celsius &deg;C = $fah &deg;F";
    }

    $msgAfterFahrenheit = "";
    if(isset($_GET['fah'])) {
        $fahrenheit = floatval($_GET['fah']);
        $cel = fahrenheitToCelsius($fahrenheit);
        $msgAfterFahrenheit = "$fahrenheit &deg;F = $cel &deg;C";
    }

    function celsiusToFahrenheit(float $celsius) : float {
        return $celsius * 1.8 + 32;
    }

    function fahrenheitToCelsius(float $fahrenheit) : float {
        return ($fahrenheit - 32) / 1.8;
    }

    ?>
    Celsius: <input type="text" name="cel" />
    <input type="submit" value="Convert">
    <?= $msgAfterCelsius ?>
</form>
<form>
    Fahrenheit: <input type="text" name="fah" />
    <input type="submit" value="Convert">
    <?= $msgAfterFahrenheit ?>
</form>


</body>
</html>
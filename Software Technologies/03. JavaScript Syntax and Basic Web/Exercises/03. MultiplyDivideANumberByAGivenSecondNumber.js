function solve(input) {
    let num1 = Number(input[0]);
    let num2 = Number(input[1]);

    let result = 0;
    if(num2 >= num1) {
        result = num1 * num2;
    } else {
        result = num1 / num2;
    }

    console.log(result);
}

function solve(input) {
    let num1 = Number(input[0]);
    let num2 = Number(input[1]);
    let num3 = Number(input[2]);

    let isPositive = false;
    if(num1 === 0 || num2 ===0 || num3  === 0) {
        isPositive = true;
    } else
    {
        isPositive = (num1 >= 0);
        isPositive = (num2 >= 0) ? isPositive : !isPositive;
        isPositive = (num3 >= 0) ? isPositive : !isPositive;
    }

    if(isPositive) {
        console.log("Positive");
    } else {
        console.log("Negative");
    }
}

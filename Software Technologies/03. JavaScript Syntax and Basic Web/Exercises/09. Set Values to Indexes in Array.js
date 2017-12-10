function solve(input) {
    let numOfElements = Number(input[0]);
    let arr = new Array(numOfElements).fill(0);

    for(let i = 1; i < input.length; i++) {
        let line = input[i].split(" - ");

        let index = Number(line[0]);
        arr[index] = Number(line[1]);
    }

    for(let e of arr) {
        console.log(e);
    }
}
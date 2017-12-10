function solve(input) {
    let obj = {};
    for(let i = 0; i < input.length; i++) {
        let command = input[i].split(" -> ");

        let key = command[0].trim();
        let value = command[1].trim();
        if(!isNaN(value)) {
            value = parseFloat(value);
        }

        obj[key] = value;
    }

    let json = JSON.stringify(obj);
    console.log(json);
}
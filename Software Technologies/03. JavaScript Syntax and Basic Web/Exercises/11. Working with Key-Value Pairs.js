function solve(input) {
    let obj = {};
    for(let i = 0; i < input.length; i++) {
        let command = input[i].split(" ");

        if (i === input.length - 1) {
            if(obj.hasOwnProperty(command[0])) {
                console.log(obj[command[0]]);
            } else {
                console.log("None");
            }
        }

        let key = command[0];
        let value = command[1];
        obj[key] = value;
    }
}
function solve(input) {
    let obj = {};
    for(let i = 0; i < input.length; i++) {
        let command = input[i].split(" ");

        if (i === input.length - 1) {
            if(obj.hasOwnProperty(command[0])) {
                for(let e of obj[command[0]]) {
                    console.log(e);
                }
            } else {
                console.log("None");
            }
        }

        let key = command[0];
        let value = command[1];
        if(obj.hasOwnProperty(key)) {
            obj[key].push(value);
        }
         else {
            obj[key] = [];
            obj[key].push(value);
         }
    }
}
function solve(input) {
    let arr = [];
    for(let i = 0; i < input.length; i++) {
        let command = JSON.parse(input[i]);
        arr.push(command);
    }

    for(let object of arr) {
        for(let key of Object.keys(object)) {
            let modifiedKey = key.charAt(0).toUpperCase() + key.substr(1).toLowerCase();
            console.log(`${modifiedKey}: ${object[key]}`)
        }
    }

    //for(let object of arr) {
    //    for(let key of Object.keys(object)) {
    //        console.log(`${key.replace(/\w\S*/g, function(txt){return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();})}: ${object[key]}`)
    //    }
    //}
}

solve(['{"name":"Gosho","age":10,"date":"19/06/2005"}']);

function solve(input) {
    let arr = [];
    for(let i = 0; i < input.length; i++) {
        let command = input[i].split(" -> ");

        let name = command[0];
        let age = command[1];
        let grade = command[2];

        arr.push({
            Name: name,
            Age: age,
            Grade: grade
        });
    }

    for(let student of arr) {
        for(let key of Object.keys(student)) {
            console.log(`${key}: ${student[key]}`)
        }
    }

    //for(let e of arr) {
    //    console.log("Name:" + e.Name);
    //    console.log("Age:" + e.Age);
    //    console.log("Grade:" + e.Grade);
    //}
}

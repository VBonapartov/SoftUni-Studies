function solve(input) {
    let arr = [];
    for(let i = 0; i < input.length; i++) {
        let command = input[i].split(" ");

        switch (command[0])
        {
            case "add":
                arr.push(command[1]);
                break;

            case "remove":
                let index = Number(command[1]);
                if(index < 0 || index > arr.length - 1)
                    continue;

                arr.splice(index, 1);
                break;
        }
    }

    for(let e of arr)
        console.log(e);
}

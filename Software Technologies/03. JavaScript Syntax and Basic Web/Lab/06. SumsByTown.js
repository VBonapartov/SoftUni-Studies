function solve(input) {
    let allTowns = {};
    for(let i = 0; i < input.length; i++) {
        let obj = JSON.parse(input[i]);
        if(!(obj.town in allTowns)) {
            allTowns[obj.town] = 0;
        }
        allTowns[obj.town] += obj.income;
    }

    for (let sortedTown of Object.keys(allTowns).sort((a, b) => a.localeCompare(b))) {
        console.log(`${sortedTown} -> ${allTowns[sortedTown]}`);
    }
}

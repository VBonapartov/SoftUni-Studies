function solve(input) {
    let text = input.join(" ");
    console.log(
                 text
                     .split(/([^A-Za-z]+)/)
                     .filter(e => !e.match(/([^A-Za-z]+)/))
                     .filter(e => e === e.toUpperCase())
                     .filter(e => e)
                     .join(", ")
                );
}

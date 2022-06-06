function solve(...params) {
    let result = [];
    let occurences = {};

    params.forEach(el => {
        let type = typeof (el);
        result.push(`${type}: ${el}`)
        occurences[type] = occurences[type] !== undefined
            ? occurences[type]++
            : 1;
    })

    Object.keys(occurences).sort((a,b) => occurences[b] - occurences[a])
    .forEach(key => {
        result.push(`${key} = ${occurences[key]}`);
    })

    return result.join('\n');
}

let output = solve('cat', 42, function () { console.log('Hello world!'); });
console.log(output);

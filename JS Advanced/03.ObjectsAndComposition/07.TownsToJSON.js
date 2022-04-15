function solve(inputArr) {
    let towns = [];
    const regex = new RegExp(/\s*\|\s*/)
    for (let index = 1; index < inputArr.length; index++) {
        let [Town, Latitude, Longitude] = inputArr[index].split(regex).filter(Boolean);
        let town = {
            Town: Town,
            Latitude: +Number(Latitude).toFixed(2),
            Longitude: +Number(Longitude).toFixed(2)
        };
        towns.push(town);
    }
    return JSON.stringify(towns);
};
console.log(solve(
    ['| Town | Latitude | Longitude |',
        '| Sofia | 42.696552 | 23.32601 |',
        '| Beijing | 39.913818 | 116.363625 |']
));
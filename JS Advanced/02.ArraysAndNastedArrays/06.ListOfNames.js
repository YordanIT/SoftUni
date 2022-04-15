function sortNames(names) {
    names.sort();
    for (let index = 1; index <= names.length; index++) {
        names[index - 1] = index + '.' + names[index - 1];
    }
    return names.join('\n');
}
console.log(sortNames(["John", "Bob", "Christina", "Ema"]));
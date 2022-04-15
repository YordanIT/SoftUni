function sortNumbers(numbers) {
    const small = numbers.sort((a, b) => a - b).slice(0, numbers.length / 2)
    const big = numbers.slice(numbers.length / 2).reverse()
    let result = [];
    for (let i = 0; i < small.length; i++) {
        result.push(small[i], big[i])
    }
    return result
}
console.log(sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));

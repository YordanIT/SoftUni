function sortArray(arr, sort) {
    if (sort === 'asc') {
        return arr.sort((a, b) => a - b);
    } else if (sort === 'desc') {
        return arr.sort((a, b) => b - a);
    }
}

console.log(sortArray([14, 7, 17, 6, 8], 'desc'));
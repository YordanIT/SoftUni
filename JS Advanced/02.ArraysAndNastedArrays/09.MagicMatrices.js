function magicMatrix(matrix) {
    let sum = 0;
    let currSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        if (sum !== currSum) {
            return false;
        }
        currSum = 0;
        for (let col = 0; col < matrix[row].length; col++) {
            if (row === 0) {
                sum += matrix[row][col];
                currSum = sum
            } else {
                currSum += matrix[row][col];
            }
        }
    }
    return true;
}
console.log(magicMatrix(
    [[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
));


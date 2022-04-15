function solve(arr, num) {
    let newArr = arr.filter((el, index) => index % num === 0);

    return newArr;
};

console.log(solve(['5', 
'20', 
'31', 
'4', 
'20'], 
2
));
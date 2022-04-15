function rotate(arr, num) {
    let rotations = num % arr.lenght;
    let elements = arr.splice(arr.lenght-rotations, rotations);
    arr.splice(0, 0, ...elements);
    
    return arr.join(' ');
}

console.log(rotate(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15));

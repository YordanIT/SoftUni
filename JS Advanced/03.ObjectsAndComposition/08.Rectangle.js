function rectangle(width, height, color) {
    let rec = {
        width,
        height,
        color,
        calcArea: function(){ return width * height }
    }
    return rec;
}
let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());

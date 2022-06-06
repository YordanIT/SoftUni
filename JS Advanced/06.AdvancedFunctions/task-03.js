function getFibonator() {
    let previous = 1;
    let current = 0;

    function inner() {
        let next = previous + current;
        previous = current;
        current = next;
        return current;
    }

    return inner;
}

let fib = getFibonator();
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib());
console.log(fib()); 

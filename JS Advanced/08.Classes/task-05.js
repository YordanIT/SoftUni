class Stringer {
    constructor(string, length) {
        this.innerString = string;
        this.innerLength = length;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        if (this.innerLength < length) {
            this.innerLength = 0;
        }
        this.innerLength -= length;
    }

    toString() {
        if (this.innerLength >= this.innerString.length) {
            return this.innerString
        } else if (this.innerLength === 0) {
            return '...'
        }
        return `${this.innerString.slice(0, Number(this.innerLength))}...`
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test

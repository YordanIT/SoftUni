(function solve() {
    Array.prototype.last = function () {
        return this[this.length - 1]
    }

    Array.prototype.skip = function (n) {
        if (n < 0 || n >= this.length || n === NaN) {
            throw new Error('Invalid index')
        }

        let arr = [];
        for (let index = n; index < this.length; index++) {
            arr.push(this[index])
        }
        return arr
    }

    Array.prototype.take = function (n) {
        if (n < 0 || n >= this.length || n === NaN) {
            throw new Error('Invalid index')
        }

        let arr = [];
        for (let index = 0; index < n; index++) {
            arr.push(this[index])
        }
        return arr
    }

    Array.prototype.sum = function () {
        return this.reduce((a, b) => a + b, 0)
    }

    Array.prototype.average = function() {
        return this.reduce((a, b) => a + b, 0)/this.length
    }
})()

var testArray = [1, 2, 3];
console.log(testArray.skip(1)[0])



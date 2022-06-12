const { assert } = require('chai');

let mathEnforcer = {
    addFive: function (num) {
        if (typeof (num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof (num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof (num1) !== 'number' || typeof (num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

describe('mathEnforcer', function () {
    describe('addFive', function () {
        it('Should return correct result with a non-number parameter', function () {
            assert.equal(undefined, mathEnforcer.addFive('test'))
        })
        it('Should add five to result with a number parameter', function () {
            assert.equal(10, mathEnforcer.addFive(5))
        })
        it('Should add five to result with a floating-point parameter', function () {
            assert.equal(10.5, mathEnforcer.addFive(5.5))
        })
        it('Should add five to result with a negative parameter', function () {
            assert.equal(0, mathEnforcer.addFive(-5))
        })
    })
    describe('subtractTen', function () {
        it('Should return correct result with a non-number parameter', function () {
            assert.equal(undefined, mathEnforcer.subtractTen('test'))
        })
        it('Should subtract ten to result with a number parameter', function () {
            assert.equal(5, mathEnforcer.subtractTen(15))
        })
        it('Should subtract ten to result with a floating-point parameter', function () {
            assert.equal(5.5, mathEnforcer.subtractTen(15.5))
        })
        it('Should subtract ten to result with a negative parameter', function () {
            assert.equal(-10, mathEnforcer.subtractTen(0))
        })
    })
    describe('subtractTen', function () {
        it('Should return correct result with a non-number parameters', function () {
            assert.equal(undefined, mathEnforcer.sum('test', 'test'))
        })
        it('Should return correct result with first non-number parameters', function () {
            assert.equal(undefined, mathEnforcer.sum('test', 5))
        })
        it('Should return correct result with second non-number parameters', function () {
            assert.equal(undefined, mathEnforcer.sum(5, 'test'))
        })
        it('Should sum numbers with number parameters', function () {
            assert.equal(2, mathEnforcer.sum(1, 1))
        })
        it('Should sum numbers with floating-point parameter', function () {
            assert.equal(3, mathEnforcer.sum(1.5, 1.5))
        })
        it('Should sum numbers with negative parameters', function () {
            assert.equal(-2, mathEnforcer.sum(-1, -1))
        })
    })
})

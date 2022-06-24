const flowerShop = {
    calcPriceOfFlowers(flower, price, quantity) {
        if (typeof flower != 'string' || !Number.isInteger(price) || !Number.isInteger(quantity)) {
            throw new Error('Invalid input!');
        } else {
            let result = price * quantity;
            return `You need $${result.toFixed(2)} to buy ${flower}!`;
        }
    },
    checkFlowersAvailable(flower, gardenArr) {
        if (gardenArr.indexOf(flower) >= 0) {
            return `The ${flower} are available!`;
        } else {
            return `The ${flower} are sold! You need to purchase more!`;
        }
    },
    sellFlowers(gardenArr, space) {
        let shop = [];
        let i = 0;
        if (!Array.isArray(gardenArr) || !Number.isInteger(space) || space < 0 || space >= gardenArr.length) {
            throw new Error('Invalid input!');
        } else {
            while (gardenArr.length > i) {
                if (i != space) {
                    shop.push(gardenArr[i]);
                }
                i++
            }
        }
        return shop.join(' / ');
    }
}

const { assert } = require("chai");

describe("Flower shop", function () {

    describe("Test for calcPriceOfFlowers", function () {
        it("Should throw error if flower is not a string", function () {
            assert.throws(() => flowerShop.calcPriceOfFlowers(0, 10, 10))
        });
        it("Should throw error if price is not a integer", function () {
            assert.throws(() => flowerShop.calcPriceOfFlowers('flower', 10.11, 10))
        });
        it("Should throw error if quantity is not a integer", function () {
            assert.throws(() => flowerShop.calcPriceOfFlowers('flower', 10, 10.11))
        });
        it("Should return message if input is correct", function () {
            assert.equal("You need $10.00 to buy rose!",
                flowerShop.calcPriceOfFlowers('rose', 10, 1))
        });
    })

    describe("Test for checkFlowersAvailable", function () {

        it("Should return message if input is correct", function () {
            assert.equal("The roses are available!",
                flowerShop.checkFlowersAvailable('roses', ['roses', 'cactus']))
        });
        it("Should return message if input is correct", function () {
            assert.equal("The roses are sold! You need to purchase more!",
                flowerShop.checkFlowersAvailable('roses', ['lotus', 'cactus']))
        });
    })

    describe("Test for sellFlowers", function () {
        it("Should throw error if garden arr is not a array", function () {
            assert.throws(() => flowerShop.sellFlowers(0, 10))
        });
        it("Should throw error if space is not a integer", function () {
            assert.throws(() => flowerShop.sellFlowers([], 10.11))
        });
        it("Should throw error if space is negative", function () {
            assert.throws(() => flowerShop.sellFlowers([], -10))
        });
        it("Should throw error if space is greater than garden arr", function () {
            assert.throws(() => flowerShop.sellFlowers(['test', 'test'], 10))
        });
        it("Should throw error if space is equal to garden arr", function () {
            assert.throws(() => flowerShop.sellFlowers(['test', 'test'], 2))
        });
        it("Should return message if input is correct", function () {
            assert.equal("test / test",
                flowerShop.sellFlowers(['test', 'test', 'test'], 2))
        });
    })
})

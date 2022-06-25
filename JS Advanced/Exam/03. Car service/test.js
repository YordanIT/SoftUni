const carService = {
  isItExpensive(issue) {
    if (issue === "Engine" || issue === "Transmission") {
      return `The issue with the car is more severe and it will cost more money`;
    } else {
      return `The overall price will be a bit cheaper`;
    }
  },
  discount(numberOfParts, totalPrice) {
    if (typeof numberOfParts !== "number" || typeof totalPrice !== "number") {
      throw new Error("Invalid input");
    }

    let discountPercentage = 0;

    if (numberOfParts > 2 && numberOfParts <= 7) {
      discountPercentage = 15;
    } else if (numberOfParts > 7) {
      discountPercentage = 30;
    }

    let result = (discountPercentage / 100) * totalPrice;

    if (numberOfParts <= 2) {
      return "You cannot apply a discount";
    } else {
      return `Discount applied! You saved ${result}$`;
    }
  },
  partsToBuy(partsCatalog, neededParts) {
    let totalSum = 0;

    if (!Array.isArray(partsCatalog) || !Array.isArray(neededParts)) {
      throw new Error("Invalid input");
    }
    neededParts.forEach((neededPart) => {
      partsCatalog.map((obj) => {
        if (obj.part === neededPart) {
          totalSum += obj.price;
        }
      });
    });

    return totalSum;
  },
};

const { assert } = require("chai");

describe("Car service", function () {

  describe("Test for isItExpensive", function () {
    it("Should return message if issue is Engine", function () {
      assert.equal("The issue with the car is more severe and it will cost more money",
        carService.isItExpensive('Engine'))
    });
    it("Should return message if issue is Transmission", function () {
      assert.equal("The issue with the car is more severe and it will cost more money",
        carService.isItExpensive('Transmission'))
    });
    it("Should return message in any other case", function () {
      assert.equal("The overall price will be a bit cheaper",
        carService.isItExpensive('oil'))
    });
  })

  describe("Test for discount", function () {
    it("Should throw error if number of parts is NaN", function () {
      assert.throws(() => carService.discount('10', 10))
    });
    it("Should throw error if total price is NaN", function () {
      assert.throws(() => carService.discount(10, '10'))
    });
    it("Should return message if number of parts is less than 2", function () {
      assert.equal("You cannot apply a discount",
        carService.discount(1, 250))
    });
    it("Should return message if number of parts is exactly 2", function () {
      assert.equal("You cannot apply a discount",
        carService.discount(2, 250))
    });
    it("Should return message with amount of discount if number of parts is greater than 7", function () {
      assert.equal("Discount applied! You saved 30$",
        carService.discount(10, 100))
    });
    it("Should return message with amount of discount if number of parts is exactly 7", function () {
      assert.equal("Discount applied! You saved 15$",
        carService.discount(7, 100))
    });
    it("Should return message with amount of discount if number of parts is between 2 and 7", function () {
      assert.equal("Discount applied! You saved 15$",
        carService.discount(5, 100))
    });
  })

  describe("Test for partsToBuy", function () {
    it("Should throw error if parts catalog is not an array", function () {
      assert.throws(() => carService.partsToBuy('arr', []))
    });
    it("Should throw error if needed parts is not an array", function () {
      assert.throws(() => carService.partsToBuy([], 'arr'))
    });
    it("Should return total sum of needed parts", function () {
      assert.equal(200,
        carService.partsToBuy([
          {part: 'front bumper', price: 180},
          {part: 'shift stick', price: 10},
          {part: 'rear mirror', price: 10},
          {part: 'test', price: 150},
        ], 
        ['front bumper', 'shift stick', 'rear mirror']))
    });
  })

})

const bookSelection = {
  isGenreSuitable(genre, age) {
    if (age <= 12 && (genre === "Thriller" || genre === "Horror")) {
      return `Books with ${genre} genre are not suitable for kids at ${age} age`;
    } else {
      return `Those books are suitable`;
    }
  },
  isItAffordable(price, budget) {
    if (typeof price !== "number" || typeof budget !== "number") {
      throw new Error("Invalid input");
    }

    let result = budget - price;

    if (result < 0) {
      return "You don't have enough money";
    } else {
      return `Book bought. You have ${result}$ left`;
    }
  },
  suitableTitles(array, wantedGenre) {
    let resultArr = [];

    if (!Array.isArray(array) || typeof wantedGenre !== "string") {
      throw new Error("Invalid input");
    }
    array.map((obj) => {
      if (obj.genre === wantedGenre) {
        resultArr.push(obj.title);
      }
    });
    return resultArr;
  },
};

const { assert } = require("chai");
describe("Book selection", function () {

  describe("Test for isGenreSuitable", function () {
    it("Should return message if genres are not suitable", function () {
      assert.equal("Books with Horror genre are not suitable for kids at 10 age",
        bookSelection.isGenreSuitable("Horror", 10))
    });
    it("Should return message if genres are suitable", function () {
      assert.equal("Those books are suitable",
        bookSelection.isGenreSuitable("Horror", 18))
    });
  });

  describe("Test for isItAffordable", function () {
    it("Should throw error if there is invalid input", function () {
      assert.throws(() => bookSelection.isItAffordable("test", "test"), Error)
    });
    it("Should return message if is not affordable", function () {
      assert.equal("You don't have enough money",
        bookSelection.isItAffordable(20, 10))
    });
    it("Should return message if is affordable", function () {
      assert.equal("Book bought. You have 10$ left",
        bookSelection.isItAffordable(10, 20))
    });
  });

  describe("Test for suitableTitles", function () {
    it("Should throw error if there is invalid input", function () {
      assert.throws(() => bookSelection.suitableTitles(0, 0), Error)
    });
    it("Should return array of titles with wanted genre", function () {
      const arr = [
        { title: "test1", genre: "comedy" },
        { title: "test2", genre: "comedy" },
        { title: "test3", genre: "comedy" },
        { title: "test4", genre: "fantasy" },
        { title: "test5", genre: "fantasy" }
      ]
      assert.equal(3, bookSelection.suitableTitles(arr, "comedy").length)
    });
  });

});


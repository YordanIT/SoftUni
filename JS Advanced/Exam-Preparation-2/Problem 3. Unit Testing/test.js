const companyAdministration = {

    hiringEmployee(name, position, yearsExperience) {
        if (position == "Programmer") {
            if (yearsExperience >= 3) {
                return `${name} was successfully hired for the position ${position}.`;
            } else {
                return `${name} is not approved for this position.`;
            }
        }
        throw new Error(`We are not looking for workers for this position.`);
    },
    calculateSalary(hours) {

        let payPerHour = 15;
        let totalAmount = payPerHour * hours;

        if (typeof hours !== "number" || hours < 0) {
            throw new Error("Invalid hours");
        } else if (hours > 160) {
            totalAmount += 1000;
        }
        return totalAmount;
    },
    firedEmployee(employees, index) {

        let result = [];

        if (!Array.isArray(employees) || !Number.isInteger(index) || index < 0 || index >= employees.length) {
            throw new Error("Invalid input");
        }
        for (let i = 0; i < employees.length; i++) {
            if (i !== index) {
                result.push(employees[i]);
            }
        }
        return result.join(", ");
    }
}

const { assert } = require("chai");
describe("Company administration", function () {

    describe("Test for hiringEmployee", function () {
        it("Should return message if there is more than three years of experience", function () {
            assert.equal("John was successfully hired for the position Programmer.",
                companyAdministration.hiringEmployee("John", "Programmer", 10))
        });
        it("Should return message if there is exact three years of experience", function () {
            assert.equal("John was successfully hired for the position Programmer.",
                companyAdministration.hiringEmployee("John", "Programmer", 3))
        });
        it("Should return message if there is less than three years of experience", function () {
            assert.equal("John is not approved for this position.",
                companyAdministration.hiringEmployee("John", "Programmer", 1))
        });
        it("Should throw error if position is different from Programmer", function () {
            assert.throws(() => companyAdministration.hiringEmployee("John", "Hr", 10))
        });
    })

    describe("Test for calculateSalary", function () {
        it("Should throw error if hours is NaN", function () {
            assert.throws(() => companyAdministration.calculateSalary("10"))
        });
        it("Should throw error if hours is negative", function () {
            assert.throws(() => companyAdministration.calculateSalary(-10))
        });
        it("Should add 1000 to salary if hours is greater than 160", function () {
            assert.equal(4000, companyAdministration.calculateSalary(200))
        });
        it("Should return salary if input is correct", function () {
            assert.equal(1500, companyAdministration.calculateSalary(100))
        });
    })

    describe("Test for firedEmployee", function () {
        let arr = ['John', 'Maria', 'Pesho'];

        it("Should throw error if employee is not array", function () {
            assert.throws(() => companyAdministration.firedEmployee(0, 1))
        });
        it("Should throw error if index is NaN", function () {
            assert.throws(() => companyAdministration.firedEmployee(arr, "1"))
        });
        it("Should throw error if index is negative", function () {
            assert.throws(() => companyAdministration.firedEmployee(arr, -1))
        });
        it("Should throw error if index out of range", function () {
            assert.throws(() => companyAdministration.firedEmployee(arr, 5))
        });
        it("Should return string if input is correct", function () {
            assert.equal("John, Pesho", companyAdministration.firedEmployee(arr, 1))
        });
    })
})

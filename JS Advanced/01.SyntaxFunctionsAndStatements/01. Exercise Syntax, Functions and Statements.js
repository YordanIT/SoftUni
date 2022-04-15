//Problem 01.Fruit
function cacl(fruit, weight, pricePerKg) {
    let weightInKg = weight / 1000;
    let price = pricePerKg * weightInKg;

    return `I need $${price.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`
}
console.log(cacl('orange', 2500, 1.80));

//Problem 02.Greatest Common Divisor - GCD
function gcd(num1, num2) {
    while (num2 > 0) {
        let temp = num2;
        num2 = num1 % num2;
        num1 = temp;
    }

    console.log(num1);
}
gcd(2154, 458);

//Problem 03.Same Numbers
function sameNumbers(number) {
    let sum = 0;
    let isNumbersEqual = false;
    let numberString = String(number);

    for (let index = 0; index < numberString.length; index++) {

        sum += Number(numberString[index]);

        if (index == numberString.length) {
            break;
        }

        if (numberString[index] === numberString[index + 1]) {
            isNumbersEqual = true;
        }
    }

    console.log(isNumbersEqual);
    console.log(sum);
}
sameNumbers(2222222);

//Problem 05.Road Radar
function roadRadar(speed, zone) {
    let motorwaySpeedLimit = 130;
    let interstateSpeedLimit = 90;
    let citySpeedLimit = 50;
    let residentialSpeedLimit = 20;
    let currentSpeedLimit = 0;

    switch (zone) {
        case 'motorway': {
            currentSpeedLimit = motorwaySpeedLimit;
            break;
        }
        case 'interstate': {
            currentSpeedLimit = interstateSpeedLimit;
            break;
        }
        case 'city': {
            currentSpeedLimit = citySpeedLimit;
            break;
        }
        case 'residential': {
            currentSpeedLimit = residentialSpeedLimit;
            break;
        }
        default:
            break;
    }

    if (speed <= currentSpeedLimit) {
        return `Driving ${speed} km/h in a ${currentSpeedLimit} zone`        
    }
     else if(speed - currentSpeedLimit <= 20){
        return `The speed is ${speed - currentSpeedLimit} km/h faster than the allowed speed of ${currentSpeedLimit} - speeding`;
    }
    else if (speed - currentSpeedLimit <= 40) { 
        return `The speed is ${speed - currentSpeedLimit} km/h faster than the allowed speed of ${currentSpeedLimit} - excessive speeding`;
    }
    else{
        return `The speed is ${speed - currentSpeedLimit} km/h faster than the allowed speed of ${currentSpeedLimit} - reckless driving `;
    }
}
console.log(roadRadar(120, 'interstate'));

//Problem 06.Cooking by numbers
function cooking(num, op1, op2, op3, op4, op5) {

    num = operation(num, op1);
    console.log(num);
    num = operation(num, op2);
    console.log(num);
    num = operation(num, op3);
    console.log(num);
    num = operation(num, op4);
    console.log(num);
    num = operation(num, op5);
    console.log(num);

    function operation(num, op) {
        switch (op) {
            case 'chop':
                num /= 2;
                break;
            case 'dice':
                num = Math.sqrt(num);
                break;
            case 'spice':
                num += 1;
                break;
            case 'bake':
                num *= 3;
                break;
            case 'fillet':
                num *= 0.8;
                break;
        }
        return num;
    }
}
console.log(cooking('9', 'dice', 'spice', 'chop', 'bake', 'fillet'));

//Problem 07.Validity Checker
function checker(x1, y1, x2, y2) {

    let status1 = 'valid';
    let status2 = 'valid';
    let status3 = 'valid';

    if (x1 === 0 || y1 === 0) {
        status1 = 'valid';
    } else {
        let distance = Math.sqrt((Math.pow(x1, 2) + Math.pow(y1, 2)));

        if (Number.isInteger(distance)) {
            status1 = 'valid';
        } else {
            status1 = 'invalid';
        }
    }

    if (x2 === 0 || y2 === 0) {
        status2 = 'valid';
    } else {
        let distance = Math.sqrt((Math.pow(x2, 2) + Math.pow(y2, 2)));

        if (Number.isInteger(distance)) {
            status2 = 'valid';
        } else {
            status2 = 'invalid';
        }
    }

    let firstPoint = Math.pow((x2-x1), 2);
    let secondPoint = Math.pow((y2-y1), 2);
    let distance = Math.sqrt(firstPoint + secondPoint);

    if (Number.isInteger(distance)) {
        status3 = 'valid';
    } else {
        status3 = 'invalid';
    }

    console.log(`{${x1}, ${y1}} to {${0}, ${0}} is ${status1}`);
    console.log(`{${x2}, ${y2}} to {${0}, ${0}} is ${status2}`);
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${status3}`);
}
checker(2, 1, 1, 1);


function calculator() {
    let numOne = document.getElementById('num1');
    let numTwo = document.getElementById('num2');
    let sumBtn = document.getElementById('sumButton');
    let subtractBtn = document.getElementById('subtractButton');
    let result = document.getElementById('result');

    sumBtn.addEventListener('click', () => {
        return result.value = 
        Number(numOne.value) + Number(numTwo.value);
    })

    subtractBtn.addEventListener('click', () => {
        return result.value = 
        Number(numOne.value) - Number(numTwo.value);
    })
}

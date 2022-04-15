function addItem() {
    let inputTextElement = document.getElementById('newItemText');
    let inputValueElement = document.getElementById('newItemValue');
    let select = document.getElementById('menu');
    let option = document.createElement('option');

    option.textContent = inputTextElement.value;
    option.value = inputValueElement.value;
    select.appendChild(option);

    inputTextElement.value = '';
    inputValueElement.value = '';
}
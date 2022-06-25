window.addEventListener("load", solve);

function solve() {
  let makeEl = document.getElementById('make');
  let modelEl = document.getElementById('model');
  let yearEl = document.getElementById('year');
  let fuelEl = document.getElementById('fuel');
  let originalCostEl = document.getElementById('original-cost');
  let sellingPriceEl = document.getElementById('selling-price');

  let publishBtn = document.getElementById('publish');
  publishBtn.addEventListener('click', publish)

  let tBody = document.getElementById('table-body');
  let ul = document.getElementById('cars-list');
  let profitEl = document.getElementById('profit');
  let sum = 0;

  function publish(e) {
    e.preventDefault()

    if (makeEl.value === '' || modelEl.value === '' || yearEl.value === '' ||
      fuelEl.value === '' || originalCostEl.value > sellingPriceEl.value) {
      return
    }

    let tr = document.createElement('tr');
    tr.className = 'row';
    tr.innerHTML = `
    <td>${makeEl.value}</td>
    <td>${modelEl.value}</td>
    <td>${yearEl.value}</td>
    <td>${fuelEl.value}</td>
    <td>${originalCostEl.value}</td>
    <td>${sellingPriceEl.value}</td>
    <td>
      <button class="action-btn edit">Edit</button>
      <button class="action-btn sell">Sell</button>
    </td>`;
    tBody.appendChild(tr)

    makeEl.value = '';
    modelEl.value = '';
    yearEl.value = '';
    fuelEl.value = '';
    originalCostEl.value = '';
    sellingPriceEl.value = '';

    let editBtn = tr.getElementsByClassName('action-btn edit')[0];
    editBtn.addEventListener('click', edit)
    let sellBtn = tr.getElementsByClassName('action-btn sell')[0];
    sellBtn.addEventListener('click', sell)

    function edit() {
      makeEl.value = tr.children[0].textContent;
      modelEl.value = tr.children[1].textContent;
      yearEl.value = tr.children[2].textContent;
      fuelEl.value = tr.children[3].textContent;
      originalCostEl.value = tr.children[4].textContent;
      sellingPriceEl.value = tr.children[5].textContent;

      tr.remove()
    }

    function sell() {
      let currProfit = Number(tr.children[5].textContent) - Number(tr.children[4].textContent);

      let li = document.createElement('li');
      li.className = 'each-list';
      li.innerHTML = `
      <span>${tr.children[0].textContent} ${tr.children[1].textContent}</span>
      <span>${tr.children[2].textContent}</span>
      <span>${currProfit}</span>`;
      ul.appendChild(li)

      tr.remove()

      sum += currProfit;
      profitEl.textContent = sum.toFixed(2);
    }
  }
}

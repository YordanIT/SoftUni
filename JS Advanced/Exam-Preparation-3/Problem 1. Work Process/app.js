function solve() {
    let firstNameEl = document.getElementById('fname');
    let lastNameEl = document.getElementById('lname');
    let emailEl = document.getElementById('email');
    let birthEl = document.getElementById('birth');
    let positionEl = document.getElementById('position');
    let salaryEl = document.getElementById('salary');
    let tBody = document.getElementById('tbody');

    let sumEl = document.getElementById('sum');
    let sum = 0;

    let addBtn = document.getElementById('add-worker');
    addBtn.addEventListener('click', add)

    function add(e) {
        e.preventDefault()

        if (firstNameEl.value === '' || lastNameEl.value === '' || emailEl.value === ''
            || birthEl.value === '' || positionEl.value === '' || salaryEl.value === '') {
            return
        }

        let salary = Number(salaryEl.value);
        let tr = document.createElement('tr');
        tr.innerHTML = `
        <td>${firstNameEl.value}</td>
        <td>${lastNameEl.value}</td>
        <td>${emailEl.value}</td>
        <td>${birthEl.value}</td>
        <td>${positionEl.value}</td>
        <td>${salary}</td>
        <td><button class="fired">Fired</button> <br> <button class="edit">Edit</button></td>
        `;
        tBody.appendChild(tr)
        sum += salary;
        sumEl.textContent = sum.toFixed(2);

        firstNameEl.value = '';
        lastNameEl.value = '';
        emailEl.value = '';
        birthEl.value = '';
        positionEl.value = '';
        salaryEl.value = '';

        let fireBtn = tr.querySelector('.fired');
        fireBtn.addEventListener('click', fire)
        let editBtn = tr.querySelector('.edit');
        editBtn.addEventListener('click', edit)

        function edit() {
            firstNameEl.value = tr.children[0].textContent;
            lastNameEl.value = tr.children[1].textContent;
            emailEl.value = tr.children[2].textContent;
            birthEl.value = tr.children[3].textContent;
            positionEl.value = tr.children[4].textContent;
            salaryEl.value = tr.children[5].textContent;

            tr.innerHTML = '';
            sum -= salary;
            sumEl.textContent = sum.toFixed(2);
        }

        function fire() {
            tr.innerHTML = '';
            sum -= salary;
            sumEl.textContent = sum.toFixed(2);
        }
    }
}
solve()
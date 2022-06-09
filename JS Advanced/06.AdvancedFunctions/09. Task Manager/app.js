function solve() {
    let task = document.getElementById('task');
    let text = document.getElementById('description');
    let date = document.getElementById('date');
    let div = document.querySelectorAll('div');
    let addBtn = document.getElementById('add');
    addBtn.addEventListener('click', add)

    function add(event) {
        event.preventDefault()
        if (task.value == '' || text.value == '' || date.value == '') {
            return
        }

        let article = document.createElement('article');
        let h3 = document.createElement('h3');
        h3.textContent = task.value
        let p1 = document.createElement('p');
        p1.textContent = `Description: ${text.value}`
        let p2 = document.createElement('p');
        p2.textContent = `Due Date: ${date.value}`
        let divFlex = document.createElement('div');
        divFlex.className = "flex"
        let btnStart = document.createElement('button');
        btnStart.className = "green"
        btnStart.textContent = 'Start'
        let btnDelete = document.createElement('button');
        btnDelete.className = "red"
        btnDelete.textContent = 'Delete'
        let btnFinish = document.createElement('button');
        btnFinish.className = "orange"
        btnFinish.textContent = 'Finish'
        btnFinish.style.display = 'none'

        divFlex.appendChild(btnStart)
        divFlex.appendChild(btnDelete)
        divFlex.appendChild(btnFinish)

        article.appendChild(h3)
        article.appendChild(p1)
        article.appendChild(p2)
        article.appendChild(divFlex)
        div[4].appendChild(article)

        btnStart.addEventListener('click', startTask)
        btnDelete.addEventListener('click', deleteTaskOnOpen)
        btnDelete.addEventListener('click', deleteTaskOnProgress)
        btnFinish.addEventListener('click', finishTask)

        function startTask() {
            div[6].appendChild(article)
            btnStart.style.display = 'none'
            btnFinish.style.display = 'inline'
        }

        function deleteTaskOnOpen() {
            div[4].removeChild(article)
        }

        function deleteTaskOnProgress() {
            div[6].removeChild(article)
        }

        function finishTask() {
            div[8].appendChild(article)
            btnFinish.style.display = 'none'
            btnDelete.style.display = 'none'
        }
    }
}
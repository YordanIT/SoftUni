window.addEventListener('load', solve);

function solve() {
    const productTypeEl = document.getElementById('type-product');
    const descriptionEl = document.getElementById('description');
    const clientNameEl = document.getElementById('client-name');
    const clientPhoneEl = document.getElementById('client-phone');
    const sectionCompleted = document.getElementById('completed-orders');

    const submitBtn = document.querySelector('button[type="submit"]');
    submitBtn.addEventListener('click', send)
    const clearBtn = document.querySelector('.clear-btn');
    clearBtn.addEventListener('click', clear)

    function send(event) {
        event.preventDefault()

        if (productTypeEl.value === '' || descriptionEl.value === '' ||
            clientNameEl.value === '' || clientPhoneEl.value === '') {
            return
        }

        const div = document.createElement('div');
        div.className = 'container';
        div.innerHTML = `
        <h2>Product type for repair: ${productTypeEl.value}</h2>
        <h3>Client information: ${clientNameEl.value}, ${clientPhoneEl.value}</h3>
        <h4>Description of the problem: ${descriptionEl.value}</h4>
        <button class="start-btn">Start repair</button>
        <button class="finish-btn" disabled>Finish repair</button>
        `;

        const section = document.getElementById('received-orders');
        section.appendChild(div)

        descriptionEl.value = '';
        clientNameEl.value = '';
        clientPhoneEl.value = '';

        const startBtn = div.querySelector('.start-btn');
        startBtn.addEventListener('click', start)
        const finishBtn = div.querySelector('.finish-btn');
        finishBtn.addEventListener('click', finish)

        function start() {
            startBtn.disabled = true;
            finishBtn.disabled = false;
        }

        function finish() {
            sectionCompleted.appendChild(div)
            startBtn.remove()
            finishBtn.remove()
        }
    }

    function clear() {
        const divs = sectionCompleted.querySelectorAll('div');
        divs.forEach(element => {
            element.remove()
        })
    }
}
function validate() {
    const input = document.getElementById('email');
    const regex = /^[a-z]+@[a-z]+\.[a-z]+$/;

    input.addEventListener('change', () => {
        if (regex.test(input.value)) {
            input.classList.remove('error')
        } else {
            input.classList.add('error')
        }
    })
}
function lockedProfile() {
    let buttons = document.querySelectorAll('#main .profile button');

    for (let index = 0; index < buttons.length; index++) {
        buttons[index].addEventListener('click', () => {

            let radioBtnName = `user${index + 1}Locked`;
            let radioBtn = document.querySelector(`input[name="${radioBtnName}"]:checked`);

            if (radioBtn.value === 'unlock') {

                let hiddenFieldElement = document.getElementById(`user${index + 1}HiddenFields`);
                
                hiddenFieldElement.style.display =
                    hiddenFieldElement.style.display === 'block' ? 'none' : 'block';

                buttons[index].textContent =
                    buttons[index].textContent === 'Show more' ? 'Hide it' : 'Show more';
            }
        })
    }
}

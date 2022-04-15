function attachEventsListeners() {
    let secondsInput = document.getElementById('seconds');
    let minutesInput = document.getElementById('minutes');
    let hoursInput = document.getElementById('hours');
    let daysInput = document.getElementById('days');

    let secondsBtn = document.getElementById('secondsBtn');
    let minutesBtn = document.getElementById('minutesBtn');
    let hoursBtn = document.getElementById('hoursBtn');
    let daysBtn = document.getElementById('daysBtn');

    secondsBtn.addEventListener('click', () => {
        secondsInput = Number(secondsInput.value);
        minutesInput.value = secondsInput / 60;
        hoursInput.value = secondsInput / 60 / 60;
        daysInput.value = secondsInput / 60 / 60 / 24;
    })

    minutesBtn.addEventListener('click', () => {
        minutesInput = Number(minutesInput.value);
        secondsInput.value = minutesInput * 60;
        hoursInput.value = minutesInput / 60;
        daysInput.value = minutesInput / 60 / 24;
    })

    hoursBtn.addEventListener('click', () => {
        hoursInput = Number(hoursInput.value);
        minutesInput.value = hoursInput * 60;
        secondsInput.value = hoursInput * 60 * 60;
        daysInput.value = hoursInput / 24;
    })

    daysBtn.addEventListener('click', () => {
        daysInput = Number(daysInput.value);
        hoursInput.value = daysInput * 24;
        minutesInput.value = daysInput * 24 * 60;
        secondsInput.value = daysInput * 24 * 60 * 60;
    })
}
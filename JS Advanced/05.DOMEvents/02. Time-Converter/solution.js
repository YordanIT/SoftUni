function attachEventsListeners() {
    let daysBtn = document.getElementById('daysBtn');
    daysBtn.addEventListener('click', convert)
    let hoursBtn = document.getElementById('hoursBtn');
    hoursBtn.addEventListener('click', convert)
    let minutesBtn = document.getElementById('minutesBtn');
    minutesBtn.addEventListener('click', convert)
    let secondsBtn = document.getElementById('secondsBtn');
    secondsBtn.addEventListener('click', convert)

    let time = {
        days: 1,
        hours: 24,
        minute: 1440,
        seconds: 86400
    };

    function convert(e) {
        let parent = e.target.parentElement;
        let input = parent.children[1].value;
        let inputId = parent.children[1].id;

        if (inputId === 'days') {
            input /= time.days;
        } else if (inputId === 'hours') {
            input /= time.hours;
        } else if (inputId === 'minutes') {
            input /= time.minute;
        } else if (inputId === 'seconds') {
            input /= time.seconds;
        }

        let days = document.getElementById('days');
        days.value = input * time.days;
        let hours = document.getElementById('hours');
        hours.value = input * time.hours;
        let minutes = document.getElementById('minutes');
        minutes.value = input * time.minute;
        let seconds = document.getElementById('seconds');
        seconds.value = input * time.seconds;
    }
}

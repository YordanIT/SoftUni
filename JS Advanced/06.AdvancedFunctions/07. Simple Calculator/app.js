function calculator() {
    let section1 = null;
    let section2 = null;
    let result = null;

    return {
        init,
        add,
        subtract
    }

    function init(sec1, sec2, result) {
        section1 = document.querySelector(sec1);
        section2 = document.querySelector(sec2);
        result = document.querySelector(result);
    }
    function add() {
        result.value = Number(section1.value) + Number(section2.value)
    }
    function subtract() {
        result.value = Number(section1.value) - Number(section2.value)
    }
}

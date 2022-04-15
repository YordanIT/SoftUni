function addAndRemove(commands) {

    let arr = [];

    for (let index = 0; index < commands.length; index++) {

        if (commands[index] === 'add') {
            arr.push(index + 1);
        } else {
            arr.pop();
        }
    }

    if (arr.length === 0) {
        console.log('Empty');
    } else {
        console.log(arr.join('\n'))
    }
};

let array = (addAndRemove(['remove',
    'remove',
    'remove']
));


function solution() {
    const food = {
        apple: {
            carbohydrate: 1,
            flavour: 2
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    };
    let microElements = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    function manage(arr) {
        const [cmd, arg, qty] = arr.split(' ');
        if (cmd === 'restock') {
            const element = Object.keys(microElements).find(e => e == arg);
            microElements[element] += Number(qty);
            return 'Success'
        } else if (cmd === 'prepare') {
            if (arg === 'apple') {
                if (food.apple.carbohydrate * qty > microElements.carbohydrate) {
                    return 'Error: not enough carbohydrate in stock'
                } else if (food.apple.flavour * qty > microElements.flavour) {
                    return 'Error: not enough flavour in stock'
                }
                microElements.carbohydrate -= qty * food.apple.carbohydrate
                microElements.flavour -= qty * food.apple.flavour
            } else if (arg === 'burger') {
                if (food.burger.carbohydrate * qty > microElements.carbohydrate) {
                    return 'Error: not enough carbohydrate in stock'
                } else if (food.burger.flavour * qty > microElements.flavour) {
                    return 'Error: not enough flavour in stock'
                }
                microElements.carbohydrate -= qty * food.burger.carbohydrate
                microElements.flavour -= qty * food.burger.flavour
            } else if (arg === 'eggs') {
                if (food.eggs.carbohydrate * qty > microElements.carbohydrate) {
                    return 'Error: not enough carbohydrate in stock'
                } else if (food.eggs.flavour * qty > microElements.flavour) {
                    return 'Error: not enough flavour in stock'
                } else if (food.eggs.fat * qty > microElements.fat) {
                    return 'Error: not enough fat in stock'
                }
                microElements.carbohydrate -= qty * food.eggs.carbohydrate
                microElements.flavour -= qty * food.eggs.flavour
                microElements.fat -= qty * food.eggs.fat
            } else if (arg === 'lemonade') {
                if (food.lemonade.carbohydrate * qty > microElements.carbohydrate) {
                    return 'Error: not enough carbohydrate in stock'
                } else if (food.lemonade.flavour * qty > microElements.flavour) {
                    return 'Error: not enough flavour in stock'
                }
                microElements.carbohydrate -= qty * food.lemonade.carbohydrate
                microElements.flavour -= qty * food.lemonade.flavour
            } else if (arg === 'turkey') {
                if (food.turkey.protein * qty > microElements.protein) {
                    return 'Error: not enough protein in stock'
                } else if (food.turkey.carbohydrate * qty > microElements.carbohydrate) {
                    return 'Error: not enough carbohydrate in stock'
                } else if (food.turkey.flavour * qty > microElements.flavour) {
                    return 'Error: not enough flavour in stock'
                } else if (food.turkey.fat * qty > microElements.fat) {
                    return 'Error: not enough fat in stock'
                }
                microElements.protein -= qty * food.turkey.protein
                microElements.carbohydrate -= qty * food.turkey.carbohydrate
                microElements.flavour -= qty * food.turkey.flavour
                microElements.fat -= qty * food.turkey.fat
            }
            return 'Success'
        } else {
            const result = Object.entries(microElements).map(x => x.join('='));
            return result.join(' ')
        }
    }
    return manage
}

let manager = solution();
console.log(manager("restock flavour 50"));
console.log(manager("prepare apple 4"));
console.log(manager("prepare eggs 2"));
console.log(manager("report")); 

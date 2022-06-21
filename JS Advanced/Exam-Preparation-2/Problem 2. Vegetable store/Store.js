class VegetableStore {
    constructor(owner, location) {
        this.owner = owner
        this.location = location
        this.availableProducts = []
    }

    loadingVegetables(vegetables) {
        let arr = [];
        for (const item of vegetables) {
            let [type, quantity, price] = item.split(' ');
            let vegie = this.availableProducts.find(p => p.type === type);

            if (vegie === undefined) {
                vegie = {
                    type: type,
                    quantity: Number(quantity),
                    price: Number(price)
                };
                this.availableProducts.push(vegie)
                arr.push(type);
            } else {
                vegie.price = vegie.price < price ? price : vegie.price;
                vegie.quantity += Number(quantity);
            }
        }

        return `Successfully added ${arr.join(', ')}`
    }

    buyingVegetables(selectedProducts) {
        let totalPrice = 0;

        for (const item of selectedProducts) {
            let [type, quantity] = item.split(' ');
            let vegie = this.availableProducts.find(p => p.type === type);

            if (vegie === undefined) {
                throw new Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            } else if (vegie.quantity < quantity) {
                throw new Error
                    (`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            }

            totalPrice += (quantity * vegie.price);
            vegie.quantity -= quantity;
        }

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`
    }

    rottingVegetable(type, quantity) {
        let vegie = this.availableProducts.find(p => p.type === type);

        if (vegie === undefined) {
            throw new Error(`${type} is not available in the store.`)
        } else if (vegie.quantity < quantity) {
            vegie.quantity = 0;
            return `The entire quantity of the ${type} has been removed.`
        }
        vegie.quantity -= quantity;

        return `Some quantity of the ${type} has been removed.`
    }

    revision() {
        let result = 'Available vegetables:\n';
        let products = this.availableProducts.sort((a, b) => a.price - b.price).map(p => `${p.type}-${p.quantity}-$${p.price}`);
        result += products.join('\n');
        result += '\n';
        result += `The owner of the store is ${this.owner}, and the location is ${this.location}.`

        return result;
    }
}

let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
console.log(vegStore.rottingVegetable("Okra", 1));
console.log(vegStore.rottingVegetable("Okra", 2.5));
console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
console.log(vegStore.revision());
/*
Successfully added Okra, Beans, Celery 
Some quantity of the Okra has been removed. 
The entire quantity of the Okra has been removed. 
Great choice! You must pay the following amount $26.15.
Available vegetables:
Celery-4.5-$2.5
Beans-2-$2.8
Okra-0-$3.5
The owner of the store is Jerrie Munro, and the location is 1463 Pette Kyosheta, Sofia.
*/



class Garden {
    constructor(spaceAvailable) {
        this.spaceAvailable = Number(spaceAvailable),
            this.plants = [],
            this.storage = []
    }

    addPlant(plantName, spaceRequired) {
        if (this.spaceAvailable < spaceRequired) {
            throw new Error("Not enough space in the garden.")
        }

        if (this.plants.includes(p => p.plantName === plantName)) {
            return
        }

        let plant = {
            plantName,
            spaceRequired,
            ripe: false,
            quantity: 0
        }
        this.plants.push(plant)
        this.spaceAvailable -= plant.spaceRequired;

        return `The ${plantName} has been successfully planted in the garden.`
    }

    ripenPlant(plantName, quantity) {
        let plant = this.plants.find(p => p.plantName === plantName);

        if (plant === undefined) {
            throw new Error(`There is no ${plantName} in the garden.`)
        }

        if (plant.ripe === true) {
            throw new Error(`The ${plantName} is already ripe.`)
        }

        if (quantity <= 0) {
            throw new Error('The quantity cannot be zero or negative.')
        }

        plant.ripe = true;
        plant.quantity += quantity;

        if (plant.quantity === 1) {
            return `${quantity} ${plantName} has successfully ripened.`
        } else if (plant.quantity > 1) {
            return `${quantity} ${plantName}s have successfully ripened.`
        }
    }

    harvestPlant(plantName) {
        let plant = this.plants.find(p => p.plantName === plantName);

        if (plant === undefined) {
            throw new Error(`There is no ${plantName} in the garden.`)
        }

        if (plant.ripe === false) {
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`)
        }

        const indexOfPlant = this.plants.findIndex(p => {
            return p.plantName === plantName;
        });
        this.plants.splice(indexOfPlant, 1)
        this.storage.push({ plantName: plant.plantName, quantity: plant.quantity })
        this.spaceAvailable += plant.spaceRequired;

        return `The ${plantName} has been successfully harvested.`
    }

    generateReport() {
        this.plants.sort((a, b) => a.plantName.localeCompare(b.plantName))
        let result = `The garden has ${this.spaceAvailable} free space left.\n`
        result += `Plants in the garden: ${this.plants.map(p => p.plantName).join(', ')}\n`
        if (this.storage.length === 0) {
            result += 'Plants in storage: The storage is empty.'
        } else {
            result += `Plants in storage: ${this.storage.map(p => p.plantName+' '+'('+p.quantity+')').join(', ')}`
        }

        return result
    }
}

let myGarden = new Garden(250);
console.log(myGarden.addPlant("apple", 20)) //"The apple has been successfully planted in the garden.");
console.log(myGarden.addPlant("orange", 200)) //"The orange has been successfully planted in the garden.");
console.log(myGarden.addPlant("raspberry", 10)) //"The raspberry has been successfully planted in the garden.");
console.log(myGarden.ripenPlant("apple", 10)) //"10 apples have successfully ripened.");
console.log(myGarden.ripenPlant("orange", 1)) //"1 orange has successfully ripened.");
console.log(myGarden.harvestPlant("orange")) //"The orange has been successfully harvested.");
console.log(myGarden.generateReport()) //"The garden has 220 free space left.\nPlants in the garden: apple, raspberry\nPlants in storage: orange (1)");






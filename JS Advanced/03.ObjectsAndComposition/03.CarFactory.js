function carCreator(car) {
    let volume = 0;
    if (car.power <= 90) {
        volume = 1800;
        car.power = 90;
    } else if(car.power <= 120){
        volume = 2400;
        car.power = 120;
    }else{
        volume = 3500;
        car.power = 200;
    }
   
    let wheels = car.wheelsize % 2 === 0 ?
    [car.wheelsize - 1, car.wheelsize - 1, car.wheelsize - 1, car.wheelsize - 1] :
    [car.wheelsize, car.wheelsize, car.wheelsize, car.wheelsize]

    const newCar = {
        model: car.model,
        engine: {
            power: car.power,
            volume: volume
        },
        carriage: {
            type: car.carriage,
            color: car.color
        },
        wheels: wheels
    };
    return newCar;
}

console.log(carCreator({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17  
}));


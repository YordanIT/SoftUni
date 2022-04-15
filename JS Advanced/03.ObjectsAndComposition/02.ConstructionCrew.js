function hydrateWorker(worker) {
    if (worker['dizziness'] === false) {
        return worker;
    } else {
        worker['dizziness'] = false;
        worker['levelOfHydrated'] += worker['weight'] * 0.1 * worker['experience'];
    }
    return worker;
}
console.log(hydrateWorker(
    { weight: 120,
        experience: 20,
        levelOfHydrated: 200,
        dizziness: true }     
));
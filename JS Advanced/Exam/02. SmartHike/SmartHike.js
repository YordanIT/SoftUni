class SmartHike {
    constructor(username) {
        this.username = username
        this.goals = {
            peaks: new Map()
        }
        this.listOfHikes = []
        this.resources = 100
    }

    addGoal(peak, altitude) {
        if (this.goals.peaks.has(peak)) {
            return `${peak} has already been added to your goals`
        }

        this.goals.peaks.set(peak, altitude)
        return `You have successfully added a new goal - ${peak}`
    }

    hike(peak, time, difficultyLevel) {
        let goal = this.goals.peaks.get(peak);

        if (goal == undefined) {
            throw new Error(`${peak} is not in your current goals`)
        }
        if (this.resources === 0) {
            throw new Error('You don\'t have enough resources to start the hike')
        }

        if (this.resources - (Number(time) * 10) < 0) {
            return 'You don\'t have enough resources to complete the hike'
        }

        this.resources -= (Number(time) * 10);
        this.listOfHikes.push({ peak, time, difficultyLevel })

        return `You hiked ${peak} peak for ${time} hours and you have ${this.resources}% resources left`
    }

    rest(time) {
        this.resources += (Number(time) * 10);

        if (this.resources >= 100) {
            this.resources = 100;
            return 'Your resources are fully recharged. Time for hiking!';
        }

        return `You have rested for ${time} hours and gained ${Number(time) * 10}% resources`
    }

    showRecord(criteria) {
        if (this.listOfHikes.length === 0) {
            return `${this.username} has not done any hiking yet`
        }

        if (criteria === 'hard' || criteria === 'easy') {
            let hike = this.listOfHikes.filter(h => h.difficultyLevel === criteria)
                .sort((a, b) => a - b)[0];

            if (hike === undefined) {
                return `${this.username} has not done any ${criteria} hiking yet`
            }

            return `${this.username}'s best ${criteria} hike is ${hike.peak} peak, for ${hike.time} hours`
        } else if (criteria === 'all') {
            let result = 'All hiking records:\n';
            result += this.listOfHikes.map(h => `${this.username} hiked ${h.peak} for ${h.time} hours`).join('\n');
            return result
        }
    }
}

const user = new SmartHike('Vili');
console.log(user.addGoal('Musala', 2925));
console.log(user.addGoal('Rui', 1706));
console.log(user.hike('Musala', 8, 'hard'));
console.log(user.hike('Rui', 3, 'easy'));
console.log(user.hike('Everest', 12, 'hard'));













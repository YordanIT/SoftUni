function sortTickets(ticketsArr, sortingCriterion) {
    
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }

        compare(other, criterion){
            if (typeof this[criterion] === 'string') {
                return this[criterion].localeCompare(other[criterion]);
            } else {
                return this[criterion] - (other[criterion]);
            }
        }
    }

    let tickets = [];

    for (let index = 0; index < ticketsArr.length; index++) {
        let [destination, price, status] = ticketsArr[index].split('|');
        price = Number(price);
        let ticket = new Ticket(destination, price, status);
        tickets.push(ticket);
    }

    tickets.sort((a, b) => a.compare(b, sortingCriterion));

    return tickets;
}

let sortedTickets = sortTickets(
    ['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'status'
);

console.log(sortedTickets);


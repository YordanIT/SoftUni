class LibraryCollection {
    constructor(number) {
        this.capacity = Number(number);
        this.books = [];
    }

    addBook(bookName, bookAuthor) {
        if (this.capacity == this.books.length) {
            throw new Error('Not enough space in the collection.')
        }

        let book = {
            bookName: bookName,
            bookAuthor: bookAuthor,
            payed: false
        }

        this.books.push(book);

        return `The ${bookName}, with an author ${bookAuthor}, collect.`
    }

    payBook(bookName) {
        let book = this.books.find(b => b.bookName === bookName);

        if (book === undefined) {
            throw new Error(`${bookName} is not in the collection.`)
        }
        if (book.payed === true) {
            throw new Error(`${bookName} has already been paid.`);
        }

        book.payed = true;
        return `${bookName} has been successfully paid.`
    }

    removeBook(bookName) {
        let book = this.books.find(b => b.bookName === bookName);

        if (book === undefined) {
            throw new Error('The book, you\'re looking for, is not found.')
        }
        if (book.payed === false) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }

        let index = this.books.indexOf(book);
        this.books.splice(index, 1)

        return `${bookName} remove from the collection.`
    }

    getStatistics(bookAuthor) {
        let result;
        let emptySlots = this.capacity - this.books.length;

        if (bookAuthor === undefined) {
            result = `The book collection has ${emptySlots} empty spots left.\n`
            let arr = this.books.sort((a, b) => a.bookName.localeCompare(b.bookName));
            arr = arr.map(b => b = `${b.bookName} == ${b.bookAuthor} - ${b.payed === true ? 'Has Paid' : 'Not Paid'}.`)
            result += arr.join('\n');
        } else {
            let book = this.books.find(b => b.bookAuthor === bookAuthor);

            if (book === undefined) {
                throw new Error(`${bookAuthor} is not in the collection.`)
            }

            result = `${book.bookName} == ${book.bookAuthor} - ${book.payed === true ? 'Has Paid' : 'Not Paid'}.`;
        }

        return result
    }
}

const library = new LibraryCollection(5)
library.addBook('Don Quixote', 'Miguel de Cervantes');
library.payBook('Don Quixote');
library.addBook('In Search of Lost Time', 'Marcel Proust');
library.addBook('Ulysses', 'James Joyce');
console.log(library.getStatistics());
/*
The book collection has 2 empty spots left.
Don Quixote == Miguel de Cervantes - Has Paid.
In Search of Lost Time == Marcel Proust - Not Paid.
Ulysses == James Joyce - Not Paid.
*/

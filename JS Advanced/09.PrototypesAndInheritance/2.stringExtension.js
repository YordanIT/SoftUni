function solve() {
    String.prototype.ensureStart(str) = function () {
        if (this.startsWith(str)) {
            return this
        }
        return str + this
    }

    String.prototype.ensureEnd(str) = function () {
        if (this.endsWith(str)) {
            return this
        }
        return this + str
    }

    String.prototype.isEmpty() = function () {
        if (this === '') {
            return true
        }
        return false
    }

    String.prototype.truncate(n) = function () {
        let arr = this.split(' '); 

        if (n >= this.length) {
            return this
        }
        //to do
    }

    String.format(string, ...params)  = function () {
        //to do
        
    }
}


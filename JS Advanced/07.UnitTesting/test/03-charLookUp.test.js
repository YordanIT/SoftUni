const charLookUp = require('../03-charLookUp');
const { assert } = require('chai');
const { string } = require('yargs');

describe('Test find char at given index', () => {
    it('Should return undefined when test non string', () => {
        assert.equal(undefined, charLookUp(undefined, 5));
    })

    it('Should return undefined when test NaN undex', () => {
        assert.equal(undefined, charLookUp('cat', 'index'));
    })

    it('Should return message when test negative index', () => {
        assert.equal('Incorrect index', charLookUp('cat', -1));
    })

    it('Should return message when test out of string length index', () => {
        assert.equal('Incorrect index', charLookUp('cat', 11));
    })

    it('Should return char at given index', () => {
        assert.equal('a', charLookUp('cat', 1));
    })
})
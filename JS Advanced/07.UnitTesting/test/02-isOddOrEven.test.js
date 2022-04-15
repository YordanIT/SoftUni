const isOddOrEven = require('../02-isOddOrEven');
const { assert } = require('chai');

describe('Test odd or even string length', () => {
    it('Shoud return undefined when nonstring is tested', () => {
        assert.equal(undefined, isOddOrEven(undefined));
    })

    it('Shoud return even when even string passed', () => {
        assert.equal('even', isOddOrEven('cats'));
    })

    it('Shoud return odd when odd string passed', () => {
        assert.equal('odd', isOddOrEven('cat'));
    })
})


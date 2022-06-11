const isOddOrEven = require('../02-isOddOrEven');
const { assert } = require('chai');

describe('Test odd or even string length', () => {
    it('Should return undefined if nonstring is tested', () => {
        assert.equal(undefined, isOddOrEven(undefined));
    })

    it('Should return even if even string passed', () => {
        assert.equal('even', isOddOrEven('cats'));
    })

    it('Should return odd if odd string passed', () => {
        assert.equal('odd', isOddOrEven('cat'));
    })
})


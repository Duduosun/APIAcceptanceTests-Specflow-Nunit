// JavaScript source code
exports.config = {
    seleniumAddress: 'http://localhost:4444/wd/hub',
		specs: ['./ProductPage/test.spec.js'],
console.log(specs)
    onPrepare:function() {
        browser.driver.manage().window().setPosition(0, 0);
    }
}
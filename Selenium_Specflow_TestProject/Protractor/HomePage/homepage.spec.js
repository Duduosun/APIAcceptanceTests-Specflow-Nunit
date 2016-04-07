// JavaScript source code
describe('HomePage functionality: ', function() {
    describe('when nagivating to trendycams website', function () {

        beforeEach(function() {
            browser.get('http://www.trendycams.com/');
            browser.waitForAngular();
        });


        it('should display welcome message ', function() {
            var header = element(by.css('div.ui.segment.yellow > h1'));
            expect(header.getText()).toMatch('Welcome To Trendycams!');
        });

        it('should update the url as #/', function() {
            expect(browser.getCurrentUrl()).toMatch('#/');
        });

    });
});
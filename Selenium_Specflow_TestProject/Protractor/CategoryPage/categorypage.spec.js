// JavaScript source code
describe('CategoryPage functionality: ', function() {  

        beforeEach(function() {
            browser.get('http://www.trendycams.com/');					
            browser.waitForAngular();
        });

        it('should display display Sony Brands on filtering through catetories page ', function() {
		   element(by.css('i.sidebar.icon')).click;				
           element(by.css('#side-menu > div:nth-child(4) > div.menu > div:nth-child(1) > a')).click;
		   element(by.css('body > div.pusher.dimmed')).click;
		   element(by.css('body > div.pusher')).isEnabled;		
		   var header = element(by.css('div.ui.segment.yellow > h1'));
           expect(header.getText()).toMatch('Sony Digital Camera');            
        });       
});
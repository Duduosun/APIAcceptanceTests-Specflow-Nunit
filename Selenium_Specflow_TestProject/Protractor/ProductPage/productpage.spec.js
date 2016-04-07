// JavaScript source code
describe('ProductPage functionality: ', function() { 
        beforeEach(function() {
            browser.get('http://www.trendycams.com/#/camera/olympus-pen-f');	           
			element(by.css('i.icon.heart.empty')).display;            
			element(by.css('i.icon.heart.empty')).click;
			browser.waitForAngular();					
        });   
	
		it('should display red icon heart on marking it as favourite ', function() {
            element(by.css('i.icon.heart.red')).display;            
			element(by.css('i.icon.heart.red')).click; 
		});	
});
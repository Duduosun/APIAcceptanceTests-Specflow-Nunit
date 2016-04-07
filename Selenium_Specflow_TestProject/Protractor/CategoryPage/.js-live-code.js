function test(){
console.log(function)
	string text = '';
	for(var i=1:i<= 10; i++)
		{
			if(i%3==0){
				text+= 'fizz';				
			}
			if(i%5==0){
				text+='buzz';
			}
			text += i;
		}
	alert(text);
}
test();
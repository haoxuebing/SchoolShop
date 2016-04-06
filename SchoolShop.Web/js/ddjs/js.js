// JavaScript Document
	window.onload=function(){ 
		var yc = document.getElementById('yc');
			var yc1=document.getElementById('yc1')
			var yc2=document.getElementById('yc2')
			var yc3=document.getElementById('yc3')

			yc.onclick = function(){
				yc1.style.display = 'none';	
				yc2.style.display = 'none';	
			}
			yc3.onclick = function(){
				yc1.style.display = 'block';	
				yc2.style.display = 'block';	
			}
			
	}
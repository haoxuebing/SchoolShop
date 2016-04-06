// JavaScript Document
window.onload=function(){
		var yc = document.getElementById('reply');
		var yc1=document.getElementById('reply1')
		yc.onclick = function(){
			if(yc1.style.display == 'none'){
				yc1.style.display = 'block'}
				else{
					yc1.style.display = 'none'}
			}
	}
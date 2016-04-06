// JavaScript Document
window.onload=function(){
var aDiv1=document.getElementById('div');
var yc=document.getElementById('yc1');
			aDiv1.onclick = function(){
			if(yc.className == 'i1'){
					yc.className = 'i';
			}else{
				yc.className = 'i1';
			}
		}
			var dj1=document.getElementById('div1')
			var dj2=document.getElementById('use')
			dj1.onclick = function(){
				if(dj2.style.display == 'none'){
					dj2.style.display = 'block';
					}else{
						dj2.style.display = 'none';
						}

			}
			var dj8=document.getElementById('dj')
			var dj9=document.getElementById('dj1')
			var dj3=document.getElementById('dj2')
			var dj4=document.getElementById('dj3')
			var dj5=document.getElementById('rec')
			var dj6=document.getElementById('di')
			var dj7=document.getElementById('xs')
			dj8.onclick = function(){
				dj9.style.display = 'block';
				dj3.style.display = 'block';

			}
			dj4.onclick = function(){
				dj9.style.display = 'none';
				dj3.style.display = 'none';

			}
			dj6.onclick = function(){
				dj5.style.display = 'block';
				dj9.style.display = 'block';

			}
			dj7.onclick = function(){
				dj5.style.display = 'none';
				dj9.style.display = 'none';

			}
			var More1=document.getElementById('More1')
			var More=document.getElementById('More')
			var Address=document.getElementById('Address')
			More.onclick = function(){
				More1.style.display = 'block';
				Address.style.display = 'block';
				More.style.display = 'none';
			}
			More1.onclick = function(){
				More1.style.display = 'none';
				Address.style.display = 'none';
				More.style.display = 'block';
			}












}

function checkEmpty(a) {
	if (a.value === '' || a.value === '请选择') {
		$(a).siblings(".Prompts").css("display", "inline-block");
	} else {
		$(a).siblings(".Prompts").css("display", "none");
	}
}

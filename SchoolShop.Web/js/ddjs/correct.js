// JavaScript Document
window.onload=function(){
		var corId=document.getElementById('correct')
		var imgId=document.getElementById('imgxiao')
		var peoId=document.getElementById('people')
		var noId=document.getElementById('none')
		corId.onclick = function(){
			alert("乱码");
				imgId.className = 'correct_dong correct_img';
			}
		imgId.onclick = function(){
				noId.style.display = 'block';
				this.style.display = 'none';
			}
	}
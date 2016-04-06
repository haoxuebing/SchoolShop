// JavaScript Document
function aa(){


		var aId=document.getElementById('box_top');
		var aLi1=aId.getElementsByTagName('a');
			for(var r=0;r<aLi1.length; r++){
			aLi1[r].onmouseover=function(){
				for(var t=0; t<aLi1.length; t++){
					aLi1[t].className='';}
				this.className ='box_sps';
				}
			}
			var dj1=document.getElementById('dj1')
			var dj2=document.getElementById('dj2')
			var dj3=document.getElementById('dj3')
			var dj4=document.getElementById('dj4')
			var dj5=document.getElementById('dj5')
			var chng5=document.getElementById('yc5')
			var chng2= document.getElementById('yc2')
			var chng3=document.getElementById('yc3')
			var chng4=document.getElementById('yc4')
			dj1.onclick = function(){
				
				chng5.style.display = 'none';
				chng2.style.display = 'block';
				chng3.style.display = 'block';
				chng4.style.display = 'block';
				dj1.className='navtop_li';
				dj2.className='';
				dj3.className='';
				dj4.className='';


			}
		dj2.onclick = function(){
				chng2.style.display = 'none';
				chng3.style.display = 'none';
				chng5.style.display = 'block';
				chng4.style.display = 'block';
				dj2.className='navtop_li';
				dj1.className='';
				dj3.className='';
				dj4.className='';
			}
		dj5.onclick = function(){
				chng2.style.display = 'none';
				chng3.style.display = 'none';
				chng5.style.display = 'block';
				chng4.style.display = 'block';
				dj2.className='navtop_li';
				dj1.className='';
				dj3.className='';
				dj4.className='';
			}
		dj3.onclick = function(){
				chng2.style.display = 'none';
				chng3.style.display = 'none';
				chng5.style.display = 'none';
				chng4.style.display = 'none';
				dj3.className='navtop_li';
				dj2.className='';
				dj1.className='';
				dj4.className='';
			}
		dj4.onclick = function(){
				chng2.style.display = 'none';
				chng3.style.display = 'none';
				chng5.style.display = 'none';
				chng4.style.display = 'block';
				dj4.className='navtop_li';
				dj2.className='';
				dj1.className='';
				dj3.className='';
			}
			if(document.getElementById('chngyc')){
				var chngyc = document.getElementById('chngyc');
					var chng1=document.getElementById('chng1')
					chngyc.onclick = function(){
						chng1.style.display = 'block';

					}
			}
			
			
		var chId=document.getElementById('chu')
		var jiId=document.getElementById('jie')
		var tiId=document.getElementById('ti')
		var guId=document.getElementById('guan')
		var xiId=document.getElementById('xing')
		chId.onclick = function(){
				this.className='fl';
				jiId.className='fl dp_yan'
			}
		jiId.onclick = function(){
				this.className='fl';
				chId.className='fl dp_yan'
			}
		guId.onclick = function(){
				tiId.style.display='none';
			}	
		xiId.onclick = function(){
				tiId.style.display='block';
			}	
			
			
			


	}


	
	
	
	
	
	
	
	
	
	
	
	

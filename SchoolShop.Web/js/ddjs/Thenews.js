// JavaScript Document
 function ac(){


		var aId=document.getElementById('bargain');
		var aLi1=aId.getElementsByTagName('li');
		var aId1=document.getElementById('mj');
		var aLi2=aId1.getElementsByTagName('ul');
			for(var r=0;r<aLi1.length; r++){
			aLi1[r].tx=r	
			aLi1[r].onclick=function(){
				for(var t=0; t<aLi1.length; t++){
					aLi1[t].className='';
					aLi2[t].style.display='none';}
				this.className ='mj_Bargain_li';
				aLi2[this.tx].style.display='block';}
			}
		var zId=document.getElementById('zong');	
			zId.onclick=function(){console.log(this);
				if(zId.className=='mj_zong_a'){
						zId.className='mj_zong_a1';
						aId1.style.display='none';
					}else{
						zId.className='mj_zong_a';
						aId1.style.display='block';
						}
				}
		}
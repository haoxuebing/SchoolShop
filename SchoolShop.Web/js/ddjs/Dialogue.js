// JavaScript Document
 function aa(){
	 tab('Detailed','li','com','li','block','zx_Common_li')
			}

function tab(t,y,u,f,h,j){
		var aId=document.getElementById(u);
		var aLi1=aId.getElementsByTagName(f);
		var aId1=document.getElementById(t);
		var aLi2=aId1.getElementsByTagName(y);
			for(var r=0;r<aLi1.length; r++){
			aLi1[r].tx=r	
			aLi1[r].onclick=function(){
				for(var t=0; t<aLi1.length; t++){
					aLi1[t].className='';
					aLi2[t].style.display='none';}
				this.className =j;
				aLi2[this.tx].style.display=h;}
			}
		}

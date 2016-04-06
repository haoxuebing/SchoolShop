// JavaScript Document
window.onload=function(){ 
		
		tab('nav','ul','nav_right','li','clearfix yc','nav_right_li')
		var aId=document.getElementById('box_top');
		var aLi1=aId.getElementsByTagName('a');
			for(var r=0;r<aLi1.length; r++){
			aLi1[r].onmouseover=function(){
				for(var t=0; t<aLi1.length; t++){
					aLi1[t].className='';}
				this.className ='box_sps';
				}
			}
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
					aLi2[t].className='';}
				this.className =j;
				aLi2[this.tx].className=h}
			}
		}
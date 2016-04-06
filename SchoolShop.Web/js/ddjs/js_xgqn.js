// JavaScript Document
	window.onload=function(){ 
		tab('habit','li','habit1','li','Habit_li','Habit_ul_li')
		
		
		var aId=document.getElementById('box_top');
		var aLi1=aId.getElementsByTagName('a');
			for(var r=0;r<aLi1.length; r++){
			aLi1[r].onmouseover=function(){
				for(var t=0; t<aLi1.length; t++){
					aLi1[t].className='';}
				this.className ='box_sps';
				}
			}
			
		var objm = document.getElementsByTagName("em");//先得到所有的SPAN标记
	for(var m=0;m<objm.length;m++)
	{
		if(objm[m].className == 'Color_em fl')
		 //找出span标记中class=a的那个标记
	{
		
		var getObm = objm[m];
		value = getObm.onclick = function(){
				this.parentElement.style.display = 'none';	
				
			}//获得他的innerHTML
	}
	}		
	}
	function tab(t,y,u,f,h,j){
		var aId=document.getElementById(u);
		var aLi1;
		if(aId)
{
			aLi1=aId.getElementsByTagName(f);
}
		var aId1=document.getElementById(t);
		var aLi2;
if(aId)
{
			aLi2=aId1.getElementsByTagName(y);
}
			for(var r=0;r<aLi1.length; r++){
			aLi1[r].tx=r	
			aLi1[r].onmouseover=function(){
				for(var t=0; t<aLi1.length; t++){
					aLi1[t].className='';
					aLi2[t].className='';}
				this.className =j;
				aLi2[this.tx].className=h}
			}
		}
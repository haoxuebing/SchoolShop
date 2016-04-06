// JavaScript Document
	window.onload=function(){ 
		
		tab('bargain','ul','point','li','clearfix Bargain_ul','Point_li')
		
		var aId=document.getElementById('box_top');
		var aLi1=aId.getElementsByTagName('a');
			for(var r=0;r<aLi1.length; r++){
			aLi1[r].onmouseover=function(){
				for(var t=0; t<aLi1.length; t++){
					aLi1[t].className='';}
				this.className ='box_sps';
				}
			}
		 var repId=document.getElementById('reply');
		var divId=document.getElementById('reply_div');
		var cxId=document.getElementById('reply_cx');
			repId.onclick=function(){
				repId.style.display = 'none';
				cxId.style.display = 'block';
				}
			divId.onclick=function(){
				repId.style.display = 'block';
				cxId.style.display = 'none';
				}
		 var Close=document.getElementById('Close');
		var cloId=document.getElementById('Close_div');
		var maId=document.getElementById('Close_ma');
		var Join1=document.getElementById('Join1');
			Close.onclick=function(){
				cloId.style.display = 'none';
				maId.style.display = 'none';
				}
			Join1.onclick=function(){
				cloId.style.display = 'block';
				maId.style.display = 'block';
				}

	}
	function tab(t,y,u,f,h,j){
		var aId=document.getElementById(u);
		var aLi1=aId.getElementsByTagName(f);
		var aId1=document.getElementById(t);
		var aLi2=aId1.getElementsByTagName(y);
			for(var r=0;r<aLi1.length; r++){
			aLi1[r].tx=r	
			aLi1[r].onmouseover=function(){
				for(var t=0; t<aLi1.length; t++){
					aLi1[t].className='';
					aLi2[t].className='clearfix';}
				this.className =j;
				aLi2[this.tx].className=h}
			}
		}

		
		
		
		
		
		
		
		
		
		
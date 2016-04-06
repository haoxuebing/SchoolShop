// JavaScript Document
window.onload=function(){
		var obj = document.getElementsByTagName("i");
		//先得到所有的SPAN标记
		for(var r=0;r<obj.length;r++)
		{
		if(obj[r].className == 'Industry_i quzhi')
		 //找出span标记中class=a的那个标记
		{
		var getObj = obj[r];
		
		value =getObj.onclick=function(){
			var pre = this.previousElementSibling || this.previousSibling;
			 if(pre.style.display=="none"){
       			 pre.style.display='block';
   			 	}else{
        		pre.style.display='none';	}

			}//获得他的innerHTML
		}
		}



		//var aId=document.getElementById('Industry');
		//var aId1=document.getElementById('duo');
			//aId.onclick=function(){
			 //if(aId1.style.display=="none"){
       			 //aId1.style.display='block';
   			 	//}else{
        		//aId1.style.display='none';
   			 //}
			//}






			var lBtn= document.getElementById('lBtn');
			var rBtn= document.getElementById('rBtn');
			var list= document.getElementById('list');
			var aList_li = list.getElementsByTagName('li');
			var i=0;
			var list_l = aList_li.length;

			lBtn.onclick = function(){
				if(list_l-3 == i){
					return false;
				}
				i++;
				//list.style.left = i*-145+'px';
				$(list).animate({'left':i*-350+'px'},1000)
			}

			rBtn.onclick = function(){
				if( i==0){
					return false;
				}
				i--;
				//list.style.left = i*-145+'px';
				$(list).animate({'left':i*-350+'px'},1000)
			}
			}
	var obj = document.getElementsByTagName("li");//先得到所有的SPAN标记
		for(var r=0;r<obj.length;r++)
	{
		if(obj[r].className == 'fl qz')
		 //找出span标记中class=a的那个标记
	{

		var aList_li = obj[r];
	}

	}

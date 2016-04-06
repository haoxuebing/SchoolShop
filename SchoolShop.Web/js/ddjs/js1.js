// JavaScript Document
	window.onload=function(){

			// var yc4=document.getElementById('yc4')
			var yc5=document.getElementById('yc5')
			// var zx=document.getElementById('zixun')

			// zx.onclick = function(){
			// 	yc4.style.display = 'block';
			// }
			yc5.onclick = function(){
				yc4.style.display = 'none';
			}
			
			var lBtn= document.getElementById('lBtn');
			var rBtn= document.getElementById('rBtn');
			var list= document.getElementById('list');
			var aList_li = list.getElementsByTagName('li');
			var i=0;
			var list_l = aList_li.length;

			lBtn.onclick = function(){
				if(list_l-4 == i){
					return false;
				}
				i++;
				//list.style.left = i*-145+'px';
				$(list).animate({'left':i*-215+'px'},1000)
			}

			rBtn.onclick = function(){
				if( i==0){
					return false;
				}
				i--;
				//list.style.left = i*-145+'px';
				$(list).animate({'left':i*-215+'px'},1000)
			}
			
	}


function show(a) {
	var yc4=document.getElementById('yc4');
	yc4.style.display = 'block';

	var $a = $(a);
	var id = $a.attr("data-id");
	var user = $a.attr("data-name");

	$(yc4).find(".expert-name").each(function(){
		$(this).html(user);
	});

	$(yc4).children(".Con_but").attr("data-id", id);
}

						function large(){
							var noId=document.getElementById('none')
							document.getElementById('large-img').src=event.target.src;
							noId.style.display='block';
						}
						function diapan(){
							none.style.display='none';
						}
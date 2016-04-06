// JavaScript Document

$(document).ready(function(){
	$("<div class='dotA div' id='div'></div><div class='nsparent' id='nsoa'></div><div id='divs' style='display:none; height:100%; position:fixed; left:0px; top:0px;'><div class='div1'id='div1' ><p class='dh_p'>100&nbsp;枚</p><i class='ia' id='i' style='display:none;'></i><a href='#none' id='ema1' class='ema1'></a><a href='#none'id='em' class='ema'></a></div></div><div id='ling' style='display:none; height:100%; position:fixed; left:0px; top:0px;'><div class='div1_s' id='div1' ><i class='ia' id='i'></i><p class='dh_p1'>100&nbsp;枚</p><a href='#none' id='ema' class='ema'></a><a href='#none' class='dh_yu'></a></div>	</div>").appendTo("body")
	
	var yc = document.getElementById('i');
			var yc1=document.getElementById('em')
			var yc2=document.getElementById('divs')
		    var sq3=document.getElementById('div');	
			var sq4=document.getElementById('nsoa');
			var sq5=document.getElementById('ema1');
			var ling=document.getElementById('ling');
			var ema=document.getElementById('ema');
			sq3.onclick=function(){
					sq3.className="none";
					sq3.style.display="none";
					yc2.style.display = 'block';
					}
			yc.onclick = function(){	
				yc2.style.display = 'none';	
				sq4.style.display = 'none';
			}
			yc1.onclick = function(){	
				yc2.style.display = 'none';
				sq4.style.display = 'none';	
			}
			sq5.onclick = function(){	
				ling.style.display = 'block';	
				yc2.style.display = 'none';
			}
			ema.onclick = function(){	
				ling.style.display = 'none';	
				sq4.style.display = 'none';
			}
});

var timer;
 $(function(){
       timer = setInterval("ab()",5000);
 		 
  
    })
   function ab(){
      $(".dotA").animate({right:'50%',bottom:'50%',width:'300px',height:'420px',},1000);
	  
    } 

function stop() {
	clearInterval(timer);
}









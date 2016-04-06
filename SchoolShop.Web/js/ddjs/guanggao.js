// JavaScript Document

$(document).ready(function(){
	$("<div class='dotA div' id='div'></div><div class='nsparent' id='nsoa'></div><div id='divs' style='display:none; height:100%; position:fixed; left:0px; top:0px;'><a href='#none'><div class='div1_guang div1' id='div1' ><i id='em' class='ema ema_guang'></i></div></a></div>").appendTo("body")
	
		
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
			yc1.onclick = function(){
				yc2.style.display = 'none';	
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









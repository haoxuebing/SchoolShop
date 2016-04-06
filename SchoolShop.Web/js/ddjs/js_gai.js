// JavaScript Document
window.onload=function(){ 
		var ChoId=document.getElementById('Choice');
		var ChoLi=ChoId.getElementsByTagName('li');
		var imgId=document.getElementById('Choice_img');
		var imgLi=imgId.getElementsByTagName('li');
			for(var q=0;q<ChoLi.length; q++){
			ChoLi[q].tx=q	
			ChoLi[q].onclick=function(){
				for(var w=0; w<ChoLi.length; w++){
					ChoLi[w].className='';
					imgLi[w].style.display = 'none';}
				this.className ='Choice_li';
				imgLi[this.tx].style.display = 'block'}
			}









var aDiv1=document.getElementById('Coms');
var yc=document.getElementById('Choices');
			aDiv1.onclick = function(){
			if(yc.style.display == 'none'){
					yc.style.display = 'block';
			}else{
				yc.style.display = 'none';
			}
		}
	
    var TjId=document.getElementById('tianjia');
	var guan=document.getElementById('guanb');
	var guanp=document.getElementById('guanp');
		TjId.onclick = function(){
			guan.style.display = "block";
			}	
		guanp.onclick = function(){
			guan.style.display = "none";
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

	 function fun(){
		var node=document.createElement("LI");
		node.className= "por fl";
		node.innerHTML= '<input type="checkbox" checked class="Sizes_input1" /><input type="text" id="input" value="" class="Sizes_input" /><em class="Color_em fl"></em>';	
		
		var list=document.getElementById("Size");
		
        list.insertBefore(node, list.children[list.children.length - 1]);
		
		var inpu=document.getElementById('input');
		inpu.value=document.getElementById('ddd').value;
		
		document.getElementById('guanb').style.display = "none";
		
		
	}
	//function myFunction(){
		//node.className= "por fl";
		//node.innerHTML= '<input type="checkbox" checked class="Sizes_input1" /><input type="text" value="50-54CM" class="Sizes_input" /><em class="Color_em"></em>';	
		//var textnode=document.createTextNode("")
         //   newItem.appendChild(textnode)
		//var list=document.getElementById("Size");
		//console.log(list.children[list.children.length - 1]);
		//console.log(list);
        //list.insertBefore(node, list.children[list.children.length - 1]);
	//}

function myFunction1(){
		var node1=document.createElement("LI");
		node1.className= "por fl";
		node1.innerHTML= '<input type="checkbox" checked class="Sizes_input1 fl"  /><input type="text" name="preferredHex"class="preferredHex" value="orangered" style="display: none;"><input type="text" value="空" class="Colors_input" /><em class="Color_em"></em>';	
		//var textnode=document.createTextNode("")
         //   newItem.appendChild(textnode)
		var list1=document.getElementById("color");
		//console.log(list);
        list1.insertBefore(node1, list1.children[list1.children.length - 1]);
		
		$(".preferredHex").each(function(){
		$(this).spectrum({
    preferredFormat: "hex",
    showInput: true,
    showPalette: true,
    palette: [["red", "rgba(0, 255, 0, .5)", "rgb(0, 0, 255)"]]
});
	})
	}







function checkEmpty(a) {
	if (a.value === '' || a.value === '请选择') {
		$(a).siblings(".Prompts").css("display", "inline-block");
	} else {
		$(a).siblings(".Prompts").css("display", "none");
	}
}














function showShadowBox() {
  var shadowBox = $(".shadow-box");
  shadowBox.css("display", "block");
  shadowBox.css("height", $(document).height());

  // var box = $(".show-box");
  var box = shadowBox.children(".show-box");
  var top = ($(window).height() - box.height())/2;
  var left = ($(window).width() - box.width())/2;
  box.css("top", top + $(document).scrollTop());
  box.css("left", left + $(document).scrollLeft());
}


// 隐藏 弹出层
function closeShadowBox(st) {
  $("." + st).css("display", "none");
}
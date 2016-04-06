// JavaScript Document
function djs(){
		var xyId=document.getElementById('xiaoyan');
		var VbId=document.getElementById('Verif_but');
		var VerId=document.getElementById('Verif1');
		VerId.style.display='none';
		xyId.style.display='block';
		VbId.style.display='block'
		var i = 60;
		var intervalid;

		intervalid = setInterval(function() {
			var aId=document.getElementById('divs');
			var imgId=document.getElementById('img');
				if (i == 0) {
					xyId.style.display ='none';
					VbId.style.display='none'
					//console.log(aId);
					clearInterval(intervalid);
					}
		document.getElementById("mes").innerHTML = i;
		i--;
		}, 1000);
		}
		
		
		
		function $$$$$(_sId){
		 return document.getElementById(_sId);
		 }
		function hide(_sId)
		 {$$$$$(_sId).style.display = $$$$$(_sId).style.display == "none" ? "" : "none";}
		function pick(v) {
		 document.getElementById('am').value=v;
		hide('HMF-1')
		}
		function bgcolor(id){
		 document.getElementById(id).style.background="#08ac29";
		 document.getElementById(id).style.color="#FFF";
		 
		}
		function nocolor(id){
		 document.getElementById(id).style.background="";
		 document.getElementById(id).style.color="#000";
		}
window.onload=function(){ 
		var a1Id=document.getElementById('you');
		var a2Id=document.getElementById('shou');
		var xg1Id=document.getElementById('xg_none');
		var xg2Id=document.getElementById('xg_none1');
		a1Id.onclick=function(){
				xg1Id.style.display='none';
				xg2Id.style.display='block';
			}
		a2Id.onclick=function(){
				xg1Id.style.display='block';
				xg2Id.style.display='none';
			}
}
























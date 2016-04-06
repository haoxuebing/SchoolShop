// JavaScript Document
window.onload=function(){ 
		var ConfirmId=document.getElementById('Confirm');
		var ModifyId=document.getElementById('Modify');
		var InforId=document.getElementById('Infor');
		var textId=document.getElementById('text');
		var tableId=document.getElementById('table');
		var tbodyId=document.getElementById('tbody');
		var tdId=tbodyId.getElementsByTagName('a');
		var SEI=document.getElementById('SE')
		var SEId=SEI.getElementsByTagName('li')
			InforId.onclick = function(){
				ModifyId.style.display = 'block';
				ConfirmId.style.display = 'none';
			}
			textId.onclick = function(){
				tableId.style.display = 'block';
			}
			
			for(var q=0;q<tdId.length; q++){
			tdId[q].onclick=function(){
				for(var w=0; w<tdId.length; w++){
					tdId[w].className='th_td1';}
				tableId.style.display = 'none';
				this.className='th_td';
				}
			}
			var SEI=document.getElementById('SE')
		var SEId=SEI.getElementsByTagName('li')
			for(var r=0;r<SEId.length; r++){
			SEId[r].onclick=function(){
				for(var t=0; t<SEId.length; t++){
					SEId[t].className='';}
				this.className ='th_Service_li';
				}
			}
}














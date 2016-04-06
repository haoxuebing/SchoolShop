// JavaScript Document
function djs(){
		var xyId=document.getElementById('xiaoyan');
		xyId.style.display='block';
		var i = 5;
		var intervalid;

		intervalid = setInterval(function() {
			var aId=document.getElementById('divs');
			var imgId=document.getElementById('img');
				if (i == 0) {
					xyId.style.display ='none';
					//console.log(aId);
					clearInterval(intervalid);
					}
		document.getElementById("mes").innerHTML = i;
		i--;
		}, 1000);
		}


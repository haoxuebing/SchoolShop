var times = 2;
var intervalid;


window.onload = function() {

  tab('Content', 'li', 'Comment', 'li', 'Content_li', 'Comment_zl')
  tab('Time_nr', 'ul', 'Time', 'li', 'clearfix Time_nr1', 'Panic')
  tab('Raingear', 'ul', 'Department_r', 'li', 'clearfix Raingears', 'Dr')
  tab('Kitchen_nr', 'ul', 'Kitchen', 'li', 'clearfix Raingears', 'Dr')
  tab('Fresh_nr', 'ul', 'Fresh', 'li', 'clearfix Raingears', 'Dr')
  tab('Wine_nr', 'ul', 'Wine', 'li', 'clearfix Raingears', 'Dr')
  tab('rainandoil_nr', 'ul', 'Grainandoil', 'li', 'clearfix Raingears', 'Dr')
  tab('Todays', 'a', 'h3_ty', 'li', 'Todays_a', 'h3_ty_li')
	
  lunbo('box','prev','next')
  lunbo('mian','prev1','next2')

  var aId = document.getElementById('box_top');
  var aLi1 = aId.getElementsByTagName('a');
  for (var r = 0; r < aLi1.length; r++) {
    aLi1[r].onmouseover = function() {
      for (var t = 0; t < aLi1.length; t++) {
        aLi1[t].className = '';
      }
      this.className = 'box_sps';
      document.getElementById('search').name = this.textContent;
    }
  }

  var yc = document.getElementById('Display');
  var yc1 = document.getElementById('Close')
  var yc2 = document.getElementById('Hide')
  var yc3 = document.getElementById('Hides')
  var yc4 = document.getElementById('bian')
  var yc5 = document.getElementById('shuqian')
  var yc6 = document.getElementById('yincang')
  var clId = document.getElementById('Clos')
    // yc.onclick = function() {
    //   yc3.style.display = 'block';
    //   yc2.style.display = 'block';
    // }

  // 关闭领取养老金动画
  yc1.onclick = function() {
    yc3.style.display = 'none';
    yc2.style.display = 'none';
    clearInterval(intervalid);  // 取消定时器
  };

  // 点击判断是否再次领取养老金
  yc4.onclick = function() {
    if (times > 0) {
      djs();
    } else {
      yc4.style.display = 'none';
      yc5.style.display = 'block';
      yc6.style.display = 'none';
    }

  };

  // 关闭养老金申请表单
  clId.onclick = function() {
    biaodan.style.display = 'none';
    yc3.style.display = 'none';

    // 测试倒计时动画
    djs();
  };

};

// 显示养老金申请表单
function join() {
  biaodan.style.display = 'block';
}

// 显示领养老金动画并倒计时
function djs() {

  document.getElementById('Hides').style.display = 'block';
  document.getElementById('Hide').style.display = 'block';

  if (times > 0) {
    times--;

    var aId = document.getElementById('divs');
    var imgId = document.getElementById('img');
    aId.src = 'img/Noname5.gif'; // 重置gif动画
    aId.style.display = 'block';
    imgId.style.display = 'none';

    var i = 9;

    intervalid = setInterval(function() {
      if (i === 0) {
        aId.style.display = 'none';
        imgId.style.display = 'block';
        clearInterval(intervalid);
      }
      document.getElementById("mes").innerHTML = i;
      i--;
    }, 1000);
  }
  
 

}

function lunbo(k,pr,nt) {
  var oBox=document.getElementById(k);
	var oUl=oBox.children[0];
	var oOl=oBox.children[0];
	var aLi=oUl.getElementsByTagName('li');
	var aBtn=oOl.getElementsByTagName('li');
	var oPrev=document.getElementById(pr);
	var oNext=document.getElementById(nt);
	var iNow=0;
	for(var i=0;i<aBtn.length;i++){
		aBtn[i].index=i;
		aBtn[i].onclick=function(){
			iNow = this.index;
			tab();
		}
	}
	function tab(){
		for(var i=0;i<aBtn.length;i++){
			aBtn[i].className='';
			aLi[i].style.display='none';
			//aLi[i].style.opacity='0';
			//aLi[i].style.filter='alpha(opacity:0)';
			//aLi[i].style.zIndex='0';
		}
		aBtn[iNow].className='on';
		aLi[iNow].style.display='block';
		//$(aLi[iNow]).animate({'opacity':1},500);
		//$(aLi[iNow]).animate({'filter':100},500);
		//aLi[iNow].style.zIndex='0';
	}
	oPrev.onclick=function(){
		iNow--;
		if(iNow<0){
			iNow=aBtn.length-1;
		}
		tab();
	};
	oNext.onclick=next;
	function next(){
		iNow++;
		if(iNow==aBtn.length){
			iNow=0;
		}
		tab();
	}
	var timer = setInterval(next,5000);
	oBox.onmouseover=function(){
		clearInterval(timer);
	};
	oBox.onmouseout=function(){
		timer = setInterval(next,5000);
	};	
}

function tab(t, y, u, f, h, j) {
  var aId = document.getElementById(u);
  var aLi1 = aId.getElementsByTagName(f);
  var aId1 = document.getElementById(t);
  var aLi2 = aId1.getElementsByTagName(y);
  for (var r = 0; r < aLi1.length; r++) {
    aLi1[r].tx = r
    aLi1[r].onmouseover = function() {
      for (var t = 0; t < aLi1.length; t++) {
        aLi1[t].className = '';
        aLi2[t].className = 'clearfix';
      }
      this.className = j;
      aLi2[this.tx].className = h
    }
  }
}

$(document).ready(function() {

  var select1 = '';
  var career = '';

  var buId = document.getElementById('buttom');
  var poId = document.getElementById('poab');
  var gud = document.getElementById('guanbi');
  var bxId = document.getElementById('buxian');
  var zhiye = document.getElementById('zhiye');
  var zhiye1 = document.getElementById('zhiye1');
  var guanbi1 = document.getElementById('guanbi1');
  var bxId1 = document.getElementById('buxian1');
  buId.onclick = function() {
    poab.style.display = 'block';
    location = '#buttom';
  }
  gud.onclick = function() {
    poab.style.display = 'none';
  }
  zhiye.onclick = function() {
    zhiye1.style.display = 'block';
    location = '#zhiye';
  }

  guanbi1.onclick = function() {
    zhiye1.style.display = 'none';
  };
  bxId1.onclick = function() {
    zhiye1.style.display = 'none';
    zhiye.value = career;
  };
  var obj = document.getElementsByTagName("span"); //先得到所有的SPAN标记
  for (var r = 0; r < obj.length; r++) {
    if (obj[r].className == 'Sale_li_span')
    //找出span标记中class=a的那个标记
    {

      var getObj = obj[r];
      getObj.onclick = function() {

        $(this).next().css("display", "block");
        this.className = 'Sale_li_span1 Sale_li_span';

        var p = this.previousElementSibling || this.previousSibling;
        p.className = 'Sale_li_i1 Sale_li_i';

      };
    }
  }



  var obj1 = document.getElementsByTagName("li");
  for (var y = 0; y < obj1.length; y++) {
    if (obj1[y].className == 'Subclass_li')
    //找出span标记中class=a的那个标记
    {

      var getObj1 = obj1[y];
      var cd = getObj1.children[0]

      //for(var n=0;n<cd.length; n++){
      //	value =cd[n].onclick=function(){
      //		for(var t=0; t<cd.length; t++){
      //			cd[t].className='';}
      //		cd.className ='Subcl_i';
      //		}
      //	}

      value = getObj1.onclick = function() {
          for (var i = 0; i < obj1.length; i++) {
            if (obj1[i].className == 'Subclass_li') {
              obj1[i].children[0].className = '';
            }
          }


          //if(this.children[0].className==''){
          this.children[0].className = 'Subcl_i';
          select1 = $(this).text();
          //	}else{this.children[0].className=''}


        } //获得他的innerHTML
    }
  }




  var divID = document.getElementsByTagName("div"); //先得到所有的SPAN标记

  for (var m = 0; m < divID.length; m++) {
    if (divID[m].className == 'Subclass_div clearfix') {

      var getdivID = divID[m];

      getdivID.children[1].onclick = function() {
        getdivID.parentElement.style.display = 'none';
      }
    }
  }



  var iID = $("i.Sale1_lii");

  for (var k = 0; k < iID.length; k++) {
    var getiID = iID[k];

    var t = getiID.nextElementSibling || getiID.nextSibling;
    t.onclick = function() {
      for (var k = 0; k < iID.length; k++) {
        iID[k].parentNode.className = 'Sale_li';
      }

      if (this.parentNode.className == 'Sale_li') {
        career = this.innerHTML;
        this.parentNode.className = 'Sale_l Sale_li';
      } else {
        this.parentNode.className = 'Sale_li';
      }

    };
  }

  // 确认 .Subclass_input
  var confirm = $("input.Subclass_input");
  for (var i = 0; i < confirm.length; i++) {
    confirm[i].onclick = function() {
      // var sub = this.parentNode.parentNode;
      // sub.style.display = "none";
      // var t = sub.previousElementSibling || sub.previousSibling;
      // t.innerHTML = select1;
      buId.value = select1;

      poab.style.display = 'none';
    };
  }


});

function han1(b) {
  b.children[1].className = 'Sale_li_span';
  b.children[0].className = 'Sale_li_i'
  b.children[2].style.display = 'none';
}

function test(a) {
  a.childNodes[1].className = 'Subcl_i';
}

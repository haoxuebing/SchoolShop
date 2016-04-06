// JavaScript Document
window.onload = function() {
  tab('love', 'ul', 'guess', 'li', 'love_ul clearfix', 'Guess_li')

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
        aLi2[t].className = '';
      }
      this.className = j;
      aLi2[this.tx].className = h
    }
  }

  var obj = document.getElementsByClassName("quzhi"); //先得到所有的SPAN标记
  var aDiv1 = document.getElementById('Menu');
  var aDiv2 = document.getElementById('Settl');
  //if (aDiv1) {
  //  aDiv1.onclick = function() {
  //    for (var r = 0; r < obj.length; r++) {

  //      if (obj[0].className == 'quzhi') {
  //        var getObj = obj[r];
  //        getObj.className = 'quzhi';
  //      } else {
  //        var getObj = obj[r];
  //        getObj.className = 'quzhi h3_i';
  //      }

  //    }
  //  }
  //}
  //if (aDiv2) {
  //  aDiv2.onclick = function() {
  //    for (var r = 0; r < obj.length; r++) {
  //      if (obj[0].className == 'quzhi')
  //      //找出span标记中class=a的那个标记
  //      {
  //        var getObj = obj[r];
  //        getObj.className = 'quzhi h3_i';
  //      } else {
  //        var getObj = obj[r];
  //        getObj.className = 'quzhi';
  //      }

  //      //	}//获得他的innerHTML
  //    }
  //  }
  //}
  //for (var r = 0; r < obj.length; r++) {
  //  if (obj[r].className == 'quzhi')
  //  //找出span标记中class=a的那个标记
  //  {
  //    var getObj = obj[r];
  //    getObj.onclick = function() {

  //      if (this.className == 'quzhi') {
  //        this.className = 'quzhi h3_i';
  //      } else {
  //        this.className = 'quzhi';
  //      }
  //    }
  //  }
  //}

  var obja = document.getElementsByTagName("a");
  for (var l = 0; l < obja.length; l++) {
    if (obja[l].className == 'Delete_a')
    //找出span标记中class=a的那个标记
    {
      var getObja = obja[l];
      getObja.onclick = function() {
        this.style.display = 'none'
      }


    }
  }
  var objd = document.getElementsByTagName("div");
  for (var y = 0; y < objd.length; y++) {
    if (objd[y].className == 'Earplug_divs_p1 por')
    //找出span标记中class=a的那个标记
    {
      var getObjd = objd[y];
      value = getObjd.onclick = function() {

        if (this.childNodes[3].style.display == 'none') {
          this.childNodes[3].style.display = 'block';
        } else {
          this.childNodes[3].style.display = 'none'
        }

      }
    }
  }


  // 自适应宽
  var loveUL = document.getElementById('love').children;
  for (var i = 0; i < loveUL.length; i++) {
    loveUL[i].style.width = (loveUL[i].children.length * 186) + 'px';
  }








}

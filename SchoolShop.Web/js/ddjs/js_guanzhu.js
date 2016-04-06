// JavaScript Document
//
$(document).ready(function(){

  $('.list').each(function(){
    var list = $(this);
    var li = $('li', list);
    var i = 0;

    $(this).parent().prev().click(function(){
      if (li.length - 4 === i) {
        return false;
      }
      i++;

      $(list).animate({
        'left': i * -144 + 'px'
      }, 1000);
    });

    $(this).parent().next().click(function(){
      if (i === 0) {
        return false;
      }
      i--;
      $(list).animate({
        'left': i * -144 + 'px'
      }, 1000);
    });

  });

});


function aa() {
  // var lBtn = document.getElementById('lBtn');
  // var rBtn = document.getElementById('rBtn');
  // var list = document.getElementById('list');;
  // var aList_li = list.getElementsByTagName('li');
  // var i = 0;
  // var list_l = aList_li.length;
  //
  // lBtn.onclick = function() {
  //   if (list_l - 4 == i) {
  //     return false;
  //   }
  //   i++;
  //   //list.style.left = i*-145+'px';
  //   $(list).animate({
  //     'left': i * -144 + 'px'
  //   }, 1000)
  //
  // }
  //
  // rBtn.onclick = function() {
  //   if (i == 0) {
  //     return false;
  //   }
  //   i--;
  //   //list.style.left = i*-145+'px';
  //   $(list).animate({
  //     'left': i * -144 + 'px'
  //   }, 1000)
  //
  // }
  // var lBtn1 = document.getElementById('lBtn1');
  // var rBtn1 = document.getElementById('rBtn1');
  // var list1 = document.getElementById('list1');;
  // var aList_li1 = list1.getElementsByTagName('li');
  // var i1 = 0;
  // var list_l1 = aList_li1.length;
  //
  // lBtn1.onclick = function() {
  //   if (list_l - 4 == i1) {
  //     return false;
  //   }
  //   i1++;
  //   //list.style.left = i*-145+'px';
  //   $(list1).animate({
  //     'left': i1 * -144 + 'px'
  //   }, 1000)
  //
  // }
  //
  // rBtn1.onclick = function() {
  //   if (i1 == 0) {
  //     return false;
  //   }
  //   i1--;
  //   //list.style.left = i*-145+'px';
  //   $(list1).animate({
  //     'left': i1 * -144 + 'px'
  //   }, 1000)
  //
  // }










  var obj = document.getElementsByClassName("Pay1_a"); //先得到所有的SPAN标记
  var aDiv1 = document.getElementById('Menu');
  var aDiv2 = document.getElementById('Settl');


  if (aDiv1) {
    aDiv1.onclick = function() {
      if (aDiv1.children[0].className == 'Shopping_i1') {
        aDiv1.children[0].className = '';
      } else {
        aDiv1.children[0].className = 'Shopping_i1';
      }

      for (var r = 0; r < obj.length; r++) {
        if (aDiv1.children[0].className == 'Shopping_i1') {
          var getObj = obj[r];
          getObj.children[0].className = 'Pay1_i';
        } else {
          var getObj = obj[r];
          getObj.children[0].className = '';
        }

      }
    }
  }

  for (var r = 0; r < obj.length; r++) {
    if (obj[r].className == 'Pay1_a')
    //找出span标记中class=a的那个标记
    {
      var getObj = obj[r];
      getObj.onclick = function() {

        if (this.children[0].className == 'Pay1_i') {
          this.children[0].className = '';
        } else {
          this.children[0].className = 'Pay1_i';
        }
      }
    }
  }

$(function(){
		$('.btn_list li').click(function(){
			$('.btn_list li').attr({'class':''});
			$(this).attr({'class':'Selling_li'});

      var sList = $(this).parent().parent().next();
			$('dl', sList).attr({'style':'display:none;'});
			$('dl', sList).eq($(this).index()).attr({'style':'display:block;'});
		});
	})

}

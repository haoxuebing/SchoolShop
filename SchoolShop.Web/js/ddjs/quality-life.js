window.onload = function(){

  // 搜索框 商品&商户 切换
  var aId=document.getElementById('box_top');
  var aLi1=aId.getElementsByTagName('a');
  for(var r=0;r<aLi1.length; r++){
    aLi1[r].onmouseover=function(){
      for(var t=0; t<aLi1.length; t++){
        aLi1[t].className='';
      }
      this.className ='box_sps';
      document.getElementById('search').name = this.textContent;
    }
  }


  carouselTimer = carouselInterval(0);
};

var indicator = 0;
var carouselTimer;

function carouselInterval(n){
  return setInterval(function() {
    if (n === 2) {
      n = 0;
    } else {
      n++;
    }
    carousel(n);
  }, 5000);
}

function carousel(num) {
  var t = document.querySelector('div.quality-life-carousel ul');
  var li = t.querySelector('li');
  var frame = 60;

  // if (num > indicator) {
    var left = 0;
    if (num === 1) {
      left = 0;
      li.style.left = "0px";
    }
    if (num === 2) {
      left = -1200;
      li.style.left = "0px";
    }
    if (num === 0) {
      left = -2400;
      li.style.position = "relative";
      li.style.left = "3600px";
    }
    // console.log(left);

    var arr = document.querySelectorAll('div.slide-indicator span');
    arr[indicator].className = '';
    arr[num].className = 'active';
    indicator = num;

    var timer = setInterval(function() {
      frame --;
      left -= 1200/60;
      t.style.left = left + 'px';
      if (frame === 0) {
        clearInterval(timer);
      }
    }, 600/60);

  // } else if (num < indicator) {
  //
  // }

}

function onIndicator(num) {
  carousel(num);
  clearInterval(carouselTimer);
  carouselTimer = carouselInterval(num);
}

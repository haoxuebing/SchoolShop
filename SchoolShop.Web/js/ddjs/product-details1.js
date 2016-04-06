
$(document).ready(function(){

  // 图片悬停事件
  var p = $(".NO1_div p");
  p.mouseover(function(){

    // 清空悬停图片框
    p.each(function(){
      $(this).children("img").removeClass("NO1_div_img");
    });

    var t = $(this).children("img");
    t.addClass("NO1_div_img");

    var src = t.attr("src");
	
	$(this).parent().siblings(".NO1_a").children("img").attr("src", src);
  });
	

});


$(document).ready(function(){

  // 图片悬停事件
  var li = $(".Chop_ul li");
  li.mouseover(function(){

    // 清空悬停图片框
    li.each(function(){
      $(this).children("img").removeClass("Chop_ul_img");
    });

    var t = $(this).children("img");
    t.addClass("Chop_ul_img");

    var src = t.attr("src");
    $("#selected-img").attr("src", src);
  });


});

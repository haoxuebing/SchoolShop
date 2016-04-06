
$(document).ready(function(){

  $(".help-tabs").each(function(){

    var $tabs = $(this);
    var $li = $tabs.children("li");
    var $items = $tabs.next(".sub").children(".item");

    // 给li添加name有序号
    $li.each(function(index){
      $(this).attr("name", index);
    });

    $li.mouseover(function(){

      // 移除样式
      $li.each(function(i){
        if ($(this).hasClass("active")) {
          $(this).removeClass("active");
          var n = $(this).attr("name");
          $items.each(function(k){
            if (n === k+'') {
              $(this).removeClass("active");
            }
          });
        }
      });

      // 添加样式
      $(this).addClass("active");
      var num = $(this).attr("name");
      $items.each(function(k){
        if (num === k+'') {
          $(this).addClass("active");
        }
      });

    });
  });



});


function showList(a) {
  var $parent = $(a).parent();
  if ($parent.hasClass("on")) {
    $parent.removeClass("on");
  } else {
    $(".left-tabs").children(".item").removeClass("on");
    $parent.addClass("on");
  }
}













//

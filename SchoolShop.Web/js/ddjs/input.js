
$(document).ready(function(){

  // console.log(location.href);

  // 判断输入的是否是手机号
  $("#phone-number").focus(function(){
    $(this).siblings(".alert").addClass("hidden");
  });
  $("#phone-number").blur(function(){
    var phoneNum = $(this).val();
    var reg = /\d{11}/.test(phoneNum);

    if (!reg) {
      $(this).siblings(".alert").removeClass("hidden");
    }
  });

  $(".img-box").on("click", "img", function(){
    var id = $(this).attr("id");
    $("#file-" + id).trigger('click');
  });

  $(".img-box").on("change", ":file", function(){
    var file = $(this).get(0).files[0];
    var id = $(this).attr("id");
    var img = $("#" + id.slice(5));
    var url;

//
//
//
// To do
// 不兼容 IE8;IE可以显示Alt。限定上传格式。
//
//
//
    if (window.navigator.userAgent.indexOf("MSIE") >= 1) {
      url = '';
    //   url = files[0].value;
      // files.select();
      // img.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);";
      // img.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = document.selection.createRange().text;
    } else {
      url = window.URL.createObjectURL(file);
    }
    img.attr("alt", file.name);
    img.attr("src", url);

  });

});


function getCaptchas() {
  var phoneNum = $("#phone-number").val();

}

$(document).ready(function(){


  // 注册页面注册方式切换
  $(".label-switch a").click(function(){
    // console.log("aaa");
    var siblings = $(this).siblings("a");
    $(this).addClass("active");
    siblings.removeClass("active");

    if ($(this).attr("title")==="signup-phone") {
      $(".signup-phone").css("display", "block");
      $(".signup-email").css("display", "none");
      $(".triangle-icon").css("border-bottom", "30px solid #e4e4e4");
    } else {
      $(".signup-phone").css("display", "none");
      $(".signup-email").css("display", "block");
      $(".triangle-icon").css("border-bottom", "31px solid #ffffff");
    }
  });



});

// 显示邮件已发送弹出层
function checkMail() {
  $(".mail-checking").css("display", "block");
}

// 显示 隐藏 许可协议
function showAgreement() {
  $(".registration-agreement").css("display", "block");
}
function closeAgreement() {
  $(".registration-agreement").css("display", "none");
}

// 发送验证码并倒计时
function getCaptchas(a) {
  var phoneNum = $("#phone-number").val();

  $(a).attr("disabled","disabled");
  $(a).addClass("inactive");
  $(a).val("10秒后可重新发送");

  var i = 10;
  var timer = setInterval(function() {
    i--;
    // console.log(i);
    $(a).val(i+"秒后可重新发送");

    // 清除计时器和样式
    if (i === 1) {
      clearInterval(timer);
      $(a).removeAttr("disabled");
      $(a).removeClass("inactive");
      $(a).val("获取验证码");
    }
  }, 1000);

}

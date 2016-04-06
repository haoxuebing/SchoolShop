
var star = 0;

$(document).ready(function(){

  $(".collapse").each(function(){
    addStar(this);
  });

  // 优化tag点击效果
  var $tags = $(".tags");
  $tags.on("click", ".tag", function(){
    var $check = $(this).children(":checkbox");
    if ($check.prop("checked") === true) {
      $check.prop("checked", false);
    } else {
      $check.prop("checked", true);
    }
  });
  $tags.on("click", ".tag :checkbox", function(event){
    event.stopPropagation();  // 停止事件的传播冒泡
  });


});


  // 星星评分 star
function addStar(a) {
  var li = $(a).find(".star-mark").children("li");
  // var li = $(".star-mark").children("li");
  li.each(function(i){
    $(this).attr("title", i+1);
  });

  li.mouseover(function(){
    var i = $(this).attr("title");
    li.each(function(index){
      if (index < i) {
        $(this).addClass("active");
      } else {
        $(this).removeClass("active");
      }
    });
  });

  li.mouseout(function(){
    li.each(function(index){
      if (index < star) {
        $(this).addClass("active");
      } else {
        $(this).removeClass("active");
      }
    });
  });

  li.click(function(){
    star = $(this).attr("title");
  });
}

// 评价框
function showCollapse(a) {
  var collapse = $(a).parent(".col-3").next(".collapse");

  if (collapse.css("display") === "none") {
    // 清空样式和评价框
    $(".collapse").css("display", "none");
    $(".show-collapse").next("i").css("display", "none");

    // 清空评价框已修改
    clearCollapse(a);

    collapse.css("display", "block");
    $(a).next("i").css("display", "block");

  } else {

    collapse.css("display", "none");
    $(a).next("i").css("display", "none");
  }
}

// 清空评价框已修改
function clearCollapse(a) {
  // var $collapse = $(".collapse");
  var $collapse = $(a).parent(".col-3").next(".collapse");

  star = 0;
  $collapse.find(".star-mark").children("li").each(function(){
      $(this).removeClass("active");
  });

  var pri = '<a class="add-tag" onclick="addTag(this);"><i></i><span>自定义</span></a>' +
            '<input type="text" title="回车添加" onkeypress="enterTag(event,this);">';
  $collapse.find(".tags").html(pri);
  $collapse.find("textarea").val('');
  // console.log($collapse.find(":file").val());
  $collapse.find(":file").val('');

}


function addTag(a) {
  var $a = $(a);
  var $input = $a.next("input");
  $a.css("display", "none");
  $input.css("display", "inline-block");
  $input.attr("autofocus", "autofocus");
}

function enterTag(event, a) {
  if(event.keyCode === 13) {
    // console.log(a.value);

    var $a = $(a);
    var $addTag = $a.prev(".add-tag");
    $a.css("display", "none");
    // $a.css("autofocus", "false");
    $addTag.css("display", "inline-block");

    // 添加Tag
    var tag = '<div class="tag">' +
      '<input type="checkbox" checked=ture value="' +a.value+ '">' +
      '<label>' +a.value+ '</label></div>';
    $(tag).insertBefore($addTag);

    $a.val("");
  }
}

// 触发文件上传 点击事件
// function uploadTrigger(a) {
//   $(a).next(":file").trigger('click');
// }

// 上传图片，并显示进度和上传后的图片
// function uploadImg(a) {
//   var $a = $(a);
//   var $parent = $a.parent(".upload");
//   var $progress = $parent.prev(".upload-progress");
//   $progress.removeClass("hidden");
//
//   // console.log($(this));
//   // console.log($a.val());
//
//   upload({
//     file: $a.get(0).files[0],
//     url: '',
//     progress: $progress.children("span"),
//     success: function(data) {
//       // console.log("success");
//       $progress.addClass("hidden");
//       var img = '<img src="' +data+ '" />';
//       $(img).insertBefore($progress);
//     }
//   });
//
// }

// 上传文件到服务器
// function upload(opts) {
//
//   var formData = new FormData();
//   // formData.append('key', opts.key);
//   formData.append('file', opts.file);
//
//   var xhr = new XMLHttpRequest();
//
//   if (opts.progress) {
//     // console.log(opts.progress.html());
//     // opts.progress.html("10%");
//     xhr.upload.onprogress = function(e) {
//       if (e.lengthComputable) {
//         if (e.loaded === e.total) {
//           opts.progress.html('0%');
//         } else {
//           var v = ((e.loaded / e.total) * 100).toFixed(2) + '%';
//           opts.progress.html(v);
//         }
//       }
//     };
//   }
//
//   xhr.onload = function() {
//     if (xhr.readyState === 4) {
//       if ((xhr.status >= 200 && xhr.status < 300) || xhr.status == 304) {
//         opts.success();
//       }
//     }
//   };
//
//   xhr.open('POST', opts.url, true);
//   xhr.send(formData);
// }


function add(a) {
  // console.log(a);
  var tags = '';

  var data='[{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"},{"name":"aaaa","sex":"asdfasd"}]';

  var t = JSON.parse(data); //强制转换一下json字符串，生成json对象
  $.each(t, function (i, n) {
    for (var name in n) {
      if(name=='sex') {
        var tag = '<div class="tag">' +
        '<input type="checkbox" value="'+n[name]+'">' +
        '<label>' + n[name] + '</label></div>';
        tags += tag;
      }
    }
  });

    // var tag = '<div class="tag">'+
    //   '<input type="checkbox" name="" value="">'+
    //   '<label>'+'abcd'+'</label></div>';
    // tags += tag;

  $(tags).prependTo($("#"+a));
}


// try
// function onSubmit(a) {
//
//   // alert(a.dataset.id);
//   alert($(a).attr("data-id"));
//
//   var $collapse = $(a).parent(".item").parent(".collapse");
//
// $collapse.parent(".td").css("display", "none");
// // $collapse.parent(".td").remove();
//   // 评价分
//   // console.log(star);
//
//   // 标签
//   var tags = [];
//   $collapse.find(".tags").find("input:checkbox:checked").each(function(){
//     // console.log($(this).val());
//     tags.push($(this).val());
//   });
//   // console.log(tags.join(','));
//
//   // 心得
//   // console.log($collapse.find("textarea").val());
//
//   // 图片地址
//   var src = [];
//   $collapse.find(".img-box").children("img").each(function(){
//     // console.log($(this).attr("src"));
//     src.push($(this).attr("src"));
//   });
//   // console.log(src.join(','));
//
//   // 是否匿名评价
//   // console.log($collapse.find("[name='agreement']:checkbox").prop("checked"));
//
//
//
// }

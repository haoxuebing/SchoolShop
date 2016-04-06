
$(document).ready(function(){

  $(".upload-box").on("change", ":file", function() {
    var id = $(this).attr("id");

    var file = $(this).get(0).files[0];
    var img = $(this).siblings("img");
    var url = window.URL.createObjectURL(file);
    img.attr("alt", file.name);
    img.attr("src", url);
    if (id === "identity0" && $("#identity1").val() || id === "identity1" && $("#identity0").val() || !id) {
      $(this).parent(".img-box").siblings(".signup-care").removeClass("hidden");
    }
  });

  $("#identification").focus(function(){
    $(this).siblings(".success-icon").addClass("hidden");
  });
  $("#identification").blur(function(){
    var num = $(this).val();
    var reg = /\d{18}/.test(num);

    if (reg) {
      $(this).siblings(".success-icon").removeClass("hidden");
    }
  });

 


});

function selectIMG(a) {
  // console.log($(a).siblings(":file").val());
  $(a).siblings(":file").trigger('click');
}

function addUploadBox(a) {
  var box = '<div class="upload"><img onclick="selectIMG(this);" src="/img/no_img.jpg" /><input class="hidden" type="file" value=""></div>';
  console.log($(a).parent());
  $(box).insertAfter($(a).parent());
}

function titleChange(a) {
  var length = $(a).val().length;
  $(a).siblings(".word-length").children("span").html(20-length);
}

function showShadowBox() {
  var shadowBox = $(".shadow-box");
  shadowBox.css("display", "block");
  shadowBox.css("height", $(document).height());
  var box = shadowBox.children(".show-box");
  var top = ($(window).height() - box.height())/2;
  var left = ($(window).width() - box.width())/2;
  box.css("top", top + $(document).scrollTop());
  box.css("left", left + $(document).scrollLeft());
}

function closeShadowBox() {
  $(".shadow-box").css("display", "none");
}

function getAddress() {
  closeShadowBox();
}

function rmImg(a) {
  var img = $(a).siblings("img");
  img.attr("alt", "");
  img.attr("src", "/img/no_img.jpg");
}


function DateSelector(selYear, selMonth, selDay) {
    this.selYear = selYear;
    this.selMonth = selMonth;
    this.selDay = selDay;
    this.selYear.Group = this;
    this.selMonth.Group = this;
    if (window.document.all != null) 
    {
        this.selYear.attachEvent("onchange", DateSelector.Onchange);
        this.selMonth.attachEvent("onchange", DateSelector.Onchange);
    }
    else 
    {
        this.selYear.addEventListener("change", DateSelector.Onchange, false);
        this.selMonth.addEventListener("change", DateSelector.Onchange, false);
    }

    if (arguments.length == 4) 
        this.InitSelector(arguments[3].getFullYear(), arguments[3].getMonth() + 1, arguments[3].getDate());
    else if (arguments.length == 6)
        this.InitSelector(arguments[3], arguments[4], arguments[5]);
    else 
    {
        var dt = new Date();
        this.InitSelector(dt.getFullYear(), dt.getMonth() + 1, dt.getDate());
    }
}

DateSelector.prototype.MinYear = 1900;

DateSelector.prototype.MaxYear = (new Date()).getFullYear();


DateSelector.prototype.InitYearSelect = function () {
    for (var i = this.MaxYear; i >= this.MinYear; i--) {
        var op = window.document.createElement("OPTION");
        op.value = i;
        op.innerHTML = i;
        this.selYear.appendChild(op);
    }
}


DateSelector.prototype.InitMonthSelect = function () {
    for (var i = 1; i < 13; i++) {
        var op = window.document.createElement("OPTION");
        op.value = i;
        op.innerHTML = i;
        this.selMonth.appendChild(op);
    }
}

DateSelector.DaysInMonth = function (year, month) {
    var date = new Date(year, month, 0);
    return date.getDate();
}

DateSelector.prototype.InitDaySelect = function () {
    var year = parseInt(this.selYear.value);
    var month = parseInt(this.selMonth.value);

    var daysInMonth = DateSelector.DaysInMonth(year, month);
    this.selDay.options.length = 0;
    for (var i = 1; i <= daysInMonth ; i++) {
        var op = window.document.createElement("OPTION");

        op.value = i;

        op.innerHTML = i;

        this.selDay.appendChild(op);
    }
}

DateSelector.Onchange = function (e) {
    var selector = window.document.all != null ? e.srcElement : e.target;
    selector.Group.InitDaySelect();
}
DateSelector.prototype.InitSelector = function (year, month, day) {
    this.selYear.options.length = 0;
    this.selMonth.options.length = 0;
    this.InitYearSelect();
    this.InitMonthSelect();
    this.selYear.selectedIndex = this.MaxYear - year;
    this.selMonth.selectedIndex = month - 1;
    this.InitDaySelect();
    this.selDay.selectedIndex = day - 1;
}











$(document).ready(function () {

    var select1 = '';
    var career = '';

    var buId = document.getElementById('buttom');
    var poId = document.getElementById('poab');
    var gud = document.getElementById('guanbi');
    var bxId = document.getElementById('buxian');
    var zhId = document.getElementById('zhezhao');
    var zhiye = document.getElementById('zhiye');
    var zhiye1 = document.getElementById('zhiye1');
    var guanbi1 = document.getElementById('guanbi1');
    var bxId1 = document.getElementById('buxian1');
    buId.onclick = function () {
        poab.style.display = 'block';
        zhId.style.display = 'block';
    };
    gud.onclick = function () {
        poab.style.display = 'none';
        zhId.style.display = 'none';
    };
    zhiye.onclick = function () {
        zhiye1.style.display = 'block';
        zhId.style.display = 'block';
    };

    guanbi1.onclick = function () {
        zhiye1.style.display = 'none';
        zhId.style.display = 'none';
    };
    bxId1.onclick = function () {
        zhiye1.style.display = 'none';
        zhId.style.display = 'none';
        zhiye.value = career;
    };

    $('.Sale_li_i + .Sale_li_span').click(function () {
        $(this).next()[0].style.display = 'block';
        this.className = 'Sale_li_span1 Sale_li_span';
        $(this).prev()[0].className = 'Sale_li_i1 Sale_li_i';
    });
  



    $('.Subclass_li').click(function () {
        $('.Subclass_li').each(function () {
            if (this.className == 'Subclass_li') {
                this.children[0].className = '';
            }
        });
        this.children[0].className = 'Subcl_i';
        select1 = $(this).text();
    }); 




    $('.Subclass_input1').click(function () {
        $(this).parent().parent().css('display', 'none');
    });

    $(".Subclass_input").click(function () {
   
        buId.value = select1;

        poab.style.display = 'none';
        zhId.style.display = 'none';
    });


    var iID = $("i.Sale1_lii");

    for (var k = 0; k < iID.length; k++) {
        var getiID = iID[k];

        $(getiID).next()[0].onclick = function () {
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




});

function han1(b) {
    b.children[1].className = 'Sale_li_span';
    b.children[0].className = 'Sale_li_i';
    b.children[2].style.display = 'none';
}

function test(a) {
    a.childNodes[1].className = 'Subcl_i';
}
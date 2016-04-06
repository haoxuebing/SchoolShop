
//$(document).ready(function(){

//  $(".upload-box").on("change", ":file", function() {
//    var id = $(this).attr("id");

//    var file = $(this).get(0).files[0];
//    var img = $(this).siblings("/img");
//    var url = window.URL.createObjectURL(file);
//    img.attr("alt", file.name);
//    img.attr("src", url);
//    if (id === "identity0" && $("#identity1").val() || id === "identity1" && $("#identity0").val() || !id) {
//      $(this).parent(".img-box").siblings(".signup-care").removeClass("hidden");
//    }
//  });

//  $("#identification").focus(function(){
//    $(this).siblings(".success-icon").addClass("hidden");
//  });
//  $("#identification").blur(function(){
//    var num = $(this).val();
//    var reg = /\d{18}/.test(num);

//    if (reg) {
//      $(this).siblings(".success-icon").removeClass("hidden");
//    }
//  });

 


//});

//function selectIMG(a) {
//  // console.log($(a).siblings(":file").val());
//  $(a).siblings(":file").trigger('click');
//}

//function addUploadBox(a) {
//  var box = '<div class="upload"><img onclick="selectIMG(this);" src="/img/no_img.jpg" /><input class="hidden" type="file" value=""></div>';
//  console.log($(a).parent());
//  $(box).insertAfter($(a).parent());
//}

function titleChange(a) {
  var length = $(a).val().length;
  $(a).siblings(".word-length").children("span").html(20-length);
}

function showShadowBox() {
  var shadowBox = $(".shadow-box");
  shadowBox.css("display", "block");
  shadowBox.css("height", $(document).height());

  // var box = $(".show-box");
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
    // ����ݡ��·������˵���Ӵ���onchange�¼��ĺ���
    if (window.document.all != null) // IE
    {
        this.selYear.attachEvent("onchange", DateSelector.Onchange);
        this.selMonth.attachEvent("onchange", DateSelector.Onchange);
    }
    else // Firefox
    {
        this.selYear.addEventListener("change", DateSelector.Onchange, false);
        this.selMonth.addEventListener("change", DateSelector.Onchange, false);
    }

    if (arguments.length == 4) // ��������������Ϊ4�����һ����������ΪDate����
        this.InitSelector(arguments[3].getFullYear(), arguments[3].getMonth() + 1, arguments[3].getDate());
    else if (arguments.length == 6) // ��������������Ϊ6�����������������Ϊ��ʼ����������ֵ
        this.InitSelector(arguments[3], arguments[4], arguments[5]);
    else // Ĭ��ʹ�õ�ǰ����
    {
        var dt = new Date();
        this.InitSelector(dt.getFullYear(), dt.getMonth() + 1, dt.getDate());
    }
}

// ����һ�������ݵ�����
DateSelector.prototype.MinYear = 1900;

// ����һ�������ݵ�����
DateSelector.prototype.MaxYear = (new Date()).getFullYear();

// ��ʼ�����
DateSelector.prototype.InitYearSelect = function () {
    // ѭ�����OPIONԪ�ص����select������
    for (var i = this.MaxYear; i >= this.MinYear; i--) {
        // �½�һ��OPTION����
        var op = window.document.createElement("OPTION");

        // ����OPTION�����ֵ
        op.value = i;

        // ����OPTION���������
        op.innerHTML = i;

        // ��ӵ����select����
        this.selYear.appendChild(op);
    }
}

// ��ʼ���·�
DateSelector.prototype.InitMonthSelect = function () {
    // ѭ�����OPIONԪ�ص��·�select������
    for (var i = 1; i < 13; i++) {
        // �½�һ��OPTION����
        var op = window.document.createElement("OPTION");

        // ����OPTION�����ֵ
        op.value = i;

        // ����OPTION���������
        op.innerHTML = i;

        // ��ӵ��·�select����
        this.selMonth.appendChild(op);
    }
}

// ����������·ݻ�ȡ���µ�����
DateSelector.DaysInMonth = function (year, month) {
    var date = new Date(year, month, 0);
    return date.getDate();
}

// ��ʼ������
DateSelector.prototype.InitDaySelect = function () {
    // ʹ��parseInt������ȡ��ǰ����ݺ��·�
    var year = parseInt(this.selYear.value);
    var month = parseInt(this.selMonth.value);

    // ��ȡ���µ�����
    var daysInMonth = DateSelector.DaysInMonth(year, month);

    // ���ԭ�е�ѡ��
    this.selDay.options.length = 0;
    // ѭ�����OPIONԪ�ص�����select������
    for (var i = 1; i <= daysInMonth ; i++) {
        // �½�һ��OPTION����
        var op = window.document.createElement("OPTION");

        // ����OPTION�����ֵ
        op.value = i;

        // ����OPTION���������
        op.innerHTML = i;

        // ��ӵ�����select����
        this.selDay.appendChild(op);
    }
}

// ������ݺ��·�onchange�¼��ķ���������ȡ�¼���Դ���󣨼�selYear��selMonth��
// ����������Group���󣨼�DateSelectorʵ����������캯�����ṩ��InitDaySelect�������³�ʼ������
// ����eΪevent����
DateSelector.Onchange = function (e) {
    var selector = window.document.all != null ? e.srcElement : e.target;
    selector.Group.InitDaySelect();
}

// ���ݲ�����ʼ�������˵�ѡ��
DateSelector.prototype.InitSelector = function (year, month, day) {
    // �����ⲿ�ǿ��Ե�������������������������ҲҪ��selYear��selMonth��ѡ����յ�
    // ������ΪInitDaySelect�����Ѿ���������������˵����������Ͳ����ظ�������
    this.selYear.options.length = 0;
    this.selMonth.options.length = 0;

    // ��ʼ���ꡢ��
    this.InitYearSelect();
    this.InitMonthSelect();

    // �����ꡢ�³�ʼֵ
    this.selYear.selectedIndex = this.MaxYear - year;
    this.selMonth.selectedIndex = month - 1;

    // ��ʼ������
    this.InitDaySelect();

    // ����������ʼֵ
    this.selDay.selectedIndex = day - 1;
}













$(document).ready(function () {

    var select1 = '';
    var career = '';

    var buId = $('#buttom');
    var poId = $('#poab');
    var gud = $('#guanbi');
    var bxId = $('#buxian');
    var zhId = $('#zhezhao');
    var zhiye = $('#zhiye');
    var zhiye1 = $('#zhiye1');
    var guanbi1 = $('#guanbi1');
    var bxId1 = $('#buxian1');
    buId.click = function () {
        poab.style.display = 'block';
        zhId.style.display = 'block';
    }
    gud.click = function () {
        poab.style.display = 'none';
        zhId.style.display = 'none';
    }
    zhiye.click = function () {
        zhiye1.style.display = 'block';
        zhId.style.display = 'block';
    }

    guanbi1.click = function () {
        zhiye1.style.display = 'none';
        zhId.style.display = 'none';
    };
    bxId1.click = function () {
        zhiye1.style.display = 'none';
        zhId.style.display = 'none';
        zhiye.value = career;
    };

    var obj = document.getElementsByTagName("span");//�ȵõ����е�SPAN���
    for (var r = 0; r < obj.length; r++) {
        if (obj[r].className == 'Sale_li_span')
            //�ҳ�span�����class=a���Ǹ����
        {

            var getObj = obj[r];
             $(getObj).click = function () {
                //console.log(this.previousSibling);
                this.nextElementSibling.style.display = 'block';
                this.className = 'Sale_li_span1 Sale_li_span'
                this.previousElementSibling.className = 'Sale_li_i1 Sale_li_i'


            }
        }
    }



    var obj1 = document.getElementsByTagName("li");
    for (var y = 0; y < obj1.length; y++) {
        if (obj1[y].className == 'Subclass_li')
            //�ҳ�span�����class=a���Ǹ����
        {

            var getObj1 = obj1[y];
            var cd = getObj1.children[0]

            //for(var n=0;n<cd.length; n++){
            //	value =cd[n].onclick=function(){
            //		for(var t=0; t<cd.length; t++){
            //			cd[t].className='';}
            //		cd.className ='Subcl_i';
            //		}
            //	}

            $(getObj1).click = function () {
                for (var i = 0; i < obj1.length; i++) {
                    if (obj1[i].className == 'Subclass_li') {
                        obj1[i].children[0].className = '';
                    }
                }


                //if(this.children[0].className==''){
                this.children[0].className = 'Subcl_i';
                select1 = $(this).text();
                //	}else{this.children[0].className=''}


            }//�������innerHTML
        }
    }




    var divID = document.getElementsByTagName("div");//�ȵõ����е�SPAN���

    for (var m = 0; m < divID.length; m++) {
        if (divID[m].className == 'Subclass_div clearfix')
            //�ҳ�span�����class=a���Ǹ����
        {

            var getdivID = divID[m];

            $(getdivID.children[1]).click = function () {
                //console.log(this.previousSibling);
                getdivID.parentElement.style.display = 'none';

            }//�������innerHTML
        }
    }



    var iID = $("i.Sale1_lii");

    for (var k = 0; k < iID.length; k++) {
        var getiID = iID[k];
        $(getiID.nextElementSibling).click = function () {
            for (var k = 0; k < iID.length; k++) {
                iID[k].parentNode.className = 'Sale_li';
            }

            if (this.parentNode.className == 'Sale_li') {
                career = this.innerHTML;
                this.parentNode.className = 'Sale_l Sale_li';
            } else { this.parentNode.className = 'Sale_li'; }

        };
    }

    // ȷ�� .Subclass_input
    var confirm = $("input.Subclass_input");
    for (var i = 0; i < confirm.length; i++) {
        $(confirm[i]).click = function () {
            // var sub = this.parentNode.parentNode;
            // sub.style.display = "none";
            // var t = sub.previousElementSibling || sub.previousSibling;
            // t.innerHTML = select1;
            buId.value = select1;

            poab.style.display = 'none';
            zhId.style.display = 'none';
        };
    }


});

function han1(b) {
    b.children[1].className = 'Sale_li_span';
    b.children[0].className = 'Sale_li_i'
    b.children[2].style.display = 'none';
}

function test(a) {
    a.childNodes[1].className = 'Subcl_i';
}


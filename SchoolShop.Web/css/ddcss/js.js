// JavaScript Document
	window.onload=function(){
		tab('js_Content','ul','suoyou','li','js_C_ul clearfix','SUOYOU_li');
		tab('js_Content1','ul','suoyou1','li','js_C_ul clearfix','SUOYOU_li');

		var aId=document.getElementById('box_top');
		var aLi1=aId.getElementsByTagName('a');
			for(var r=0;r<aLi1.length; r++){
			aLi1[r].onmouseover=function(){
				for(var t=0; t<aLi1.length; t++){
					aLi1[t].className='';}
				this.className ='box_sps';
				}
			}


		};


function tab(t,y,u,f,h,j){
		var aId=document.getElementById(u);
		var aLi1=aId.getElementsByTagName(f);
		var aId1=document.getElementById(t);
		var aLi2=aId1.getElementsByTagName(y);
			for(var r=0;r<aLi1.length; r++){
			aLi1[r].tx=r;
			aLi1[r].onmouseover=function(){
				for(var t=0; t<aLi1.length; t++){
					aLi1[t].className='';
					aLi2[t].className='';}
				this.className =j;
				aLi2[this.tx].className=h}
			}
		}


function Show_Hidden(trid){
    if(trid.style.display=="block"){
        trid.style.display='none';
    }else{
        trid.style.display='block';
    }
}

function Show_H(tria){
    if(tria.style.display=="none"){
        tria.style.display='block';
    }else{
        tria.style.display='none';
    }
}
function Show_Hi(tri3){
    if(tri3.style.height=="33px"){
        tri3.style.height='';
    }else{
        tri3.style.height='33px';
    }
}


function gengduo(gdi1){
    if(gdi1.style.display=="none"){
        gdi1.style.display='block';
    }else{
        gdi1.style.display='none';
    }
}
 function aa(){
		var sq3=document.getElementById('id1');
		var gd=document.getElementById('id2');
			//for(var n=0;n<sq3.length; n++){
			sq3.onclick=function(){
				//for(var m=0; m<sq3.length; m++){
					sq3.style.display="none";
					gd.style.display='block';};

			gd.onclick=function(){
				//for(var s=0; s<gd.length; s++){
					sq3.style.display="block";
					gd.style.display='none';}


 }

function ab(){
		var sq3=document.getElementById('id3');
		var gd=document.getElementById('id4');
			//for(var n=0;n<sq3.length; n++){
			sq3.onclick=function(){
				//for(var m=0; m<sq3.length; m++){
					sq3.style.display="none";
					gd.style.display='block';};

			gd.onclick=function(){
				//for(var s=0; s<gd.length; s++){
					sq3.style.display="block";
					gd.style.display='none';}


 }



var arr = [];			// 多种商品选择数组
var arrHTML = [];
// var keyword = [];	// 选择条件
// var keywordHTML = [];
var selectStatus = [];
var arrID = [];
var multiValue = '';

$(document).ready(function(){

	// 判断 列表方式
	if (localStorage.getItem("view") !== null) {
		var view = localStorage.getItem("view");
		// console.log(view);
		if (view === "0") {
			showThumbnail();
		} else {
			showColumn();
		}
	}

	// 选择条件
	$(".select-box").on("click", "li", function(){

		var id = $(this).attr("id");
		// console.log(id);

		var text = $(this).get(0).innerText;	// IE, Chrome
		if (!text) {
			text = $(this).get(0).textContent;	// Firefox
		}

		var parent = $(this).parent().attr("title");
		if (parent === undefined) {
			parent = $(this).parent().parent().attr("title");
		}

		// if (!selectStatus[parent]) {
		// 	showKeyword(text, parent);
		// } else {
				var hasItem = false;
				for (var i in arr) {
					if (text === arr[i]) {
		 			hasItem = true;
		 			arr.splice(i,1);
					arrID.splice(i,1);
					arrHTML.splice(i,1);
					$(this).removeClass("active");

					rmSelect(parent, text);
					}
				}
				if (!hasItem) {
		 			arr.push(text);
					arrID.push(id);

				// parent = $(this).parent().attr("title");
					var html = '<li class="active"><a>'+ text +'<i></i></a></li>';
					arrHTML.push(html);
		 			$(this).addClass("active");
				}

			var span = $(this).siblings("span");
			if (span.length === 0) {
				span = $(this).parent();
			}

			span.html(arrHTML.join(''));
		// }

		multiValue = parent+"="+arr.join(',')+"="+arrID.join(',');
		// console.log(multiValue);


	});


});


function rmSelect(parent, t) {
	$("#" + parent).find("li").each(function(){
		var text = $(this).get(0).innerText;	// IE, Chrome
		if (!text) {
			text = $(this).get(0).textContent;	// Firefox
		}
		if (text === t) {
			$(this).removeClass("active");
		}
	});
}


// 初始化
function initLi() {
	$(".select-box li").each(function(){
		$(this).removeClass("active");
	});

	$(".select-box span").html('');
}


// 清理 多选框
function clearSelect(selectStatus, x) {
	arr = [];
	arrID = [];
	arrHTML = [];
	initLi();

	for (var i in selectStatus) {
		if (selectStatus[i] && i !== x) {
			var parent = i;
			// var ul = $("#" + parent + " ul");
			var ul1 = $("#" + parent + " ul:first");
			var ul2 = $("#" + parent + " ul:last");
			var moreChoose = $("#" + parent).children(".more-choose");
			var selectButton = $("#" + parent).children(".select-button");
			// ul1.css("height", "33px");
			// ul.removeClass("select-box");
			ul1.css("display", "block");
			ul2.css("display", "none");
			moreChoose.css("display", "block");
			selectButton.css("display", "none");

			selectStatus[parent] = false;
		}
	}
}

function multiselect(parent) {
	$("#select-box").addClass("xiaoshi1");
	tr2.style.display='block';
	tr2a.style.display='block';
	tr1.style.display='none';

	clearSelect(selectStatus, parent);
	var ul1 = $("#" + parent + " ul:first");
	var ul2 = $("#" + parent + " ul:last");
	var moreChoose = $("#" + parent).children(".more-choose");
	var selectButton = $("#" + parent).children(".select-button");
	if (selectStatus[parent]) {
		moreChoose.css("display", "block");
		selectButton.css("display", "none");
		ul1.css("display", "block");
		ul2.css("display", "none");

		selectStatus[parent] = false;
	} else {
		ul1.css("display", "none");
		ul2.css("display", "block");
		moreChoose.css("display", "none");
		selectButton.css("display", "block");
		selectStatus[parent] = true;
	}

}

function showSelect() {
	if ($("#select-box").attr("class")==="xiaoshi1"){
		$("#select-box").removeClass("xiaoshi1");
		tr2.style.display='none';
	} else {
		$("#select-box").addClass("xiaoshi1");
		tr2.style.display='block';
		tr2a.style.display='block';
	}
	tr1.style.display='none';

	clearSelect(selectStatus, 'PPPPPP');
}

// 多项选择取消
function selectCancel2(parent) {
	$("#select-box").addClass("xiaoshi1");
	tr2a.style.display='block';
	tr2.style.display='block';
	tr1.style.display='none';
}
function selectCancel(parent) {
	multiselect(parent);
}

// 多项选择确认
// function selectEnsure2(parent) {
// 	if (arr.length !== 0) {
// 		var text = arr.join(',');
// 		showKeyword(text, parent);
// 		selectCancel2(parent);
// 	}
// }
// function selectEnsure(parent) {
// 	if (arr.length !== 0) {
// 		var text = arr.join(',');
// 		showKeyword(text, parent);
// 		multiselect(parent);
// 	}
// }


// 列视图
function showColumn() {
	$("#blocks1").css("display", "block");
	$("#blocks").css("display", "none");
	$("#a_xs").css("background-position", "-21px -182px");
	$("#a_xs1").css("background-position", "0 -199px");
	localStorage.setItem("view","1");
}

// 缩微图
function showThumbnail() {
	$("#blocks").css("display", "block");
	$("#blocks1").css("display", "none");
	$("#a_xs").css("background-position", "0 -182px");
	$("#a_xs1").css("background-position", "-21px -199px");
	localStorage.setItem("view","0");
}

//
// function showKeyword(text, parent) {
// 	var html = '<a id="'+ text +'" title="'+ parent +'" onclick="rmKeyword(this.id, this.title);"><b>' + parent + '</b>: ' + text +'<strong>&nbsp;&nbsp;x&nbsp;</strong></a></span>';
// 	keyword.push(parent+':'+text);
// 	keywordHTML.push(html);
//
// 	$("#select-filter div").html(keywordHTML.join(''));
// 	if (keyword.length !== 0) {
// 		$("#select-filter").css("display", "block");
// 	}
// 	document.getElementById(parent).style.display = "none";
//
// 	localStorage.setItem("keyword", JSON.stringify({"keyword":keyword}));
// }
//
// function rmKeyword(text, parent) {
// 	document.getElementById(parent).style.display = "block";
// 	for (var i in keyword) {
// 		if (parent+':'+text === keyword[i]) {
// 			keyword.splice(i,1);
// 			keywordHTML.splice(i,1);
// 			$("#select-filter div").html(keywordHTML.join(''));
// 		}
// 	}
// 	if (keyword.length === 0) {
// 		$("#select-filter").css("display", "none");
// 	}
//
// 	localStorage.setItem("keyword", JSON.stringify({"keyword":keyword}));
// }


// 价格范围
function custemValue(parent) {
	// todo 需要添加 数字过滤
	// console.log($("#low-price").val());
	var text = $("#low-price").val() + "-" + $("#high-price").val();
	$("#low-price").val("");
	$("#high-price").val("");

	// showKeyword(text, parent);
}

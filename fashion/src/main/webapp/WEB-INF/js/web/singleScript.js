function colorChange(obj){
	$("img.selected").removeClass("selected");
	$("span.selected").removeClass("selected");
	$(obj).addClass('selected');
	$("div[class^='sizeDiv'] ").attr("hidden", "true");
	$(".flexslider").attr("hidden", "true");
	$("p[class *='Qua'] ").attr("hidden", "true");
	
	var clas = $(obj).attr("class");
	var clases = clas.split(" ");
	clas = clases[clases.length-2];
	$(".sizeDiv"+clas).removeAttr("hidden");
	$(".sizeDiv"+clas + " span:first").addClass("selected");
	$(".flexslider.img"+clas).removeAttr("hidden");
	$("p.right.Qua"+clas).removeAttr("hidden");
}

function sizeChange(obj){
	$("span.selected").removeClass("selected");
	$(obj).addClass('selected');
	$("p[class*='Qua'] ").attr("hidden", "true");
	
	var clas = $(obj).attr("class");
	clas = clas.substr(5, clas.length-14);
	$("p.right.Qua"+clas).removeAttr("hidden");
}

$(document).ready(function() {
	var obj=$(".span.span2 img:first");
	//make first color is selected
	obj.addClass("selected");
	//get ID of color which is contained in class of Image div and Size div
	var clas = obj.attr("class");
	var clases = clas.split(" ");
	clas = clases[clases.length-2];
	//make Size div visible
	$(".sizeDiv"+clas).removeAttr("hidden");
	//make Size div selected
	$(".sizeDiv"+clas + " span:first").addClass("selected");
	//make Image div visible
	$(".flexslider.img"+clas).removeAttr("hidden");
	//get Size ID	
	var selector = $(".sizeDiv"+clas + " span.selected").attr("class");
	selector = selector.substr(5, selector.length-14);
	console.log(selector);
	//make suitable Quantity visible
	$("p.right.Qua"+selector).removeAttr("hidden");
});
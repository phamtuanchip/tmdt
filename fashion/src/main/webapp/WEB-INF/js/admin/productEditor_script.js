$(document).ready(function() {
	// start .ready()
	$("a.btn.btn-warning.btn-block").click(function() {

		if (validateForm()) {
			$("#proFrom").attr('action', 'subP');
			$("#proFrom").submit();
//			window.location.replace('/fashion/dataTables');
		}
	});

	$("input[name*='price']").keyup(function() {
		var x = $(this).val();
		$(this).val(commaSeparateNumber(x));
	});

	$("#rightDiv").on('click', 'i.fa-plus-circle', function() {
		if ($(this).attr("class").indexOf("image") >= 0) {
			addNewImage($(this));
		} else if ($(this).attr("class").indexOf("size") >= 0) {
			addNewSize($(this));
		} else if ($(this).attr("class").indexOf("color") >= 0) {
			addNewColor($(this));
		}
	});

	$("#rightDiv").on('click', 'i.fa-minus-circle', function() {
		if ($(this).attr("class").indexOf("image") >= 0) {
			removeImage($(this));
		} else if ($(this).attr("class").indexOf("size") >= 0) {
			removeSize($(this));
		} else if ($(this).attr("class").indexOf("color") >= 0) {
			removeColor($(this));
		}
	});

	$("#rightDiv").on('change', '#fileInput', function() {
		var imgTag = $(this).parent().next().children();
		imgTag.removeAttr('hidden');
		var filename = $(this).val();
		var arr = filename.split('\\');
		filename = arr[arr.length - 1];
		console.log(filename);
		$(this).next().val(filename);

		if (this.files && this.files[0]) {
			var reader = new FileReader();
			reader.onload = function(e) {
				imgTag.attr('src', e.target.result);
			};
			reader.readAsDataURL(this.files[0]);
		}
	});
	// end .ready()
});

function commaSeparateNumber(val) {
	val = val.replace(/,/g, "");
	while (/(\d+)(\d{3})/.test(val.toString())) {
		val = val.toString().replace(/(\d+)(\d{3})/, '$1' + ',' + '$2');
	}
	return val;
}

function addNewImage(button) {
	var trToAdd = button.parent().parent().parent().clone();
	var tbody = button.parent().parent().parent().parent();
	trToAdd.find('img').attr('src', '').attr('hidden', 'true');
	trToAdd.find("input").val("");
	var id = trToAdd.find("input[type='hidden']").attr('id');
	var name = trToAdd.find("input[type='hidden']").attr('name');
	var flag = false;
	out: for (var int = 0; int < 10; int++) {
		flag = false;
		var newId = id.substring(0, id.lastIndexOf('.') - 1) + int
				+ '.urlImage';
		var newName = name.substring(0, name.lastIndexOf('.') - 2) + int
				+ '].urlImage';
		count = ($('#rightDiv').html()).search(newId);
		if (count == -1) {
			trToAdd.find("input[type='hidden']").attr('id', newId);
			trToAdd.find("input[type='hidden']").attr('name', newName);
			flag = true;
			break out;
		}
	}
	if (flag) {
		tbody.append(trToAdd);
		button.removeClass('fa fa-plus-circle');
		button.addClass('fa fa-minus-circle');
	} else {
		alert("Không thể thêm quá 10 ảnh");
	}
}

function addNewSize(button) {
	var currentDiv = button.parent().parent().parent();
	var divToAdd = currentDiv.clone();
	var signal = 0;
	divToAdd.find("input[name*='product'], label[for*='product'], select[name*='product']").each(
			function() {
				var flag = false;
				out: for (var int = 0; int < 10; int++) {
					flag = false;
					var idOrFor = $(this).attr('id')==null?$(this).attr('for'):$(this).attr('id');
					idOrFor = idOrFor.substring(0, idOrFor.lastIndexOf('.') - 1) + int
							+ idOrFor.substring(idOrFor.lastIndexOf('.'));
					count = ($('#rightDiv').html()).search(idOrFor);
					
					if (count == -1) {
						signal ++;
						if($(this).attr('for')){
							$(this).attr('for', idOrFor);
						}else{
							var name = $(this).attr('name');
							var newName = name.substring(0, name.lastIndexOf(']') - 1)
							+ int + name.substring(name.lastIndexOf(']'));
							$(this).attr('id', idOrFor);
							$(this).attr('name', newName);
						}
						flag = true;
						break out;
					}
				}
			});
	if (signal >0) {
		divToAdd.insertAfter(currentDiv);
		button.removeClass('fa fa-plus-circle');
		button.addClass('fa fa-minus-circle');
	} else {
		alert("Lấy đâu ra nhiều size thế, spam ít thôi chứ");
	}

}

function addNewColor(button) {
	var currentDiv = button.parent().parent().parent();
	var divToAdd = currentDiv.clone();
	divToAdd.find('i').removeClass('fa fa-minus-circle').addClass('fa fa-plus-circle');
	//distinct all imageAttachments
	divToAdd.find('tbody').each(function() {
		$(this).children().slice(1).remove();
	});
	
	//distinct all Sizes
	var seen = {};
	divToAdd.find('.panel.panel-default.size').each(function() {
	    var txt = $(this).text();
	    if (seen[txt])
	        $(this).remove();
	    else
	        seen[txt] = true;
	});
	//set all input to default
	setAllInputsToDefault();
	
	//rename fors of label, ids and names of input or select
	var signal = 0;
	divToAdd.find("input[name*='es'], label[for*='es'], select[name*='es']").each(
			function() {
				var flag = false;
				out: for (var int = 0; int < 10; int++) {
					flag = false;
					var idOrFor = $(this).attr('id')==null?$(this).attr('for'):$(this).attr('id');
					idOrFor = idOrFor.replace(/\d+/g, 0);
					//
					idOrFor = idOrFor.substring(0, idOrFor.indexOf('rs') + 2) + int
							+ idOrFor.substring(idOrFor.indexOf('rs') + 3);
					count = ($('#rightDiv').html()).search(idOrFor);
					if (count == -1) {
						signal ++;
						if($(this).attr('for')){
							$(this).attr('for', idOrFor);
						}else{
							var name = $(this).attr('name');
							var newName = name.substring(0, name.indexOf(']') - 1)
							+ int + name.substring(name.indexOf(']'));
							$(this).attr('id', idOrFor);
							$(this).attr('name', newName);
						}
						divToAdd.find("input[id*='.urlColor']").each(function() {
							$(this).attr('id', 'product.colors'+int +'.urlColor');
							$(this).attr('name', 'product.colors['+int +'].urlColor');
						});
						flag = true;
						break out;
					}
				}
			});
	if (signal >0) {
		divToAdd.insertAfter(currentDiv);
		button.removeClass('fa fa-plus-circle');
		button.addClass('fa fa-minus-circle');
	} else {
		alert("Lấy đâu ra nhiều màu thế, spam ít thôi chứ");
	}
}


function removeColor(button) {
	var trToRemove = button.parent().parent().parent();
	trToRemove.remove();
}

function removeImage(button) {
	var trToRemove = button.parent().parent().parent();
	trToRemove.remove();
}

function removeSize(button) {
	var trToRemove = button.parent().parent().parent();
	trToRemove.remove();
}


function validateForm() {

	return true;
}

function genderChange(obj) {
	var gender = $(obj).val();
	var choice = $("select[name='product.smallerCat']").val();
	$(".smallerCat").attr("hidden");
	$(".smallerCat." + gender).removeAttr("hidden");
	$(".smallestCat").attr("hidden");
	$(".smallestCat." + gender + "." + choice).removeAttr("hidden");
}

function smallerCatChange(obj) {
	var choice = $(obj).val();
	var gender = $("select[name='product.gender']").val();
	$(".smallestCat").attr("hidden");
	$(".smallestCat." + gender + "." + choice).removeAttr("hidden");
}

function setAllInputsToDefault(){
	
}
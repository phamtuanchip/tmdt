$(document).ready(function() {
	productTable();
	colorTable();
	imageTable();
	sizeTable();
});

function productTable() {
	$('#pTable').DataTable({
		"dom" : '<"toolbar">frtip',
		"ajax" : {
			"url" : "getProducts/all",
			"dataSrc" : ""
		},
		//
		"columns" : [ {
			"data" : "code"
		}, {
			"data" : "name"
		}, {
			"data" : "gender"
		}, {
			"data" : "category",
		}, {
			"data" : "smallerCat"
		}, {
			"data" : "smallestCat"
		}, {
			"data" : "material"
		}
		// ,{
		// "data" : "impDate",
		// "visible" : false,
		// "searchable" : false
		// }, {
		// "data" : "description",
		// "visible" : false,
		// "searchable" : false
		// }, {
		// "data" : "importprice",
		// "visible" : false,
		// "searchable" : false
		// }, {
		// "data" : "price",
		// "visible" : false,
		// "searchable" : false
		// }, {
		// "data" : "saleoffprice",
		// "visible" : false,
		// "searchable" : false
		// }, {
		// "data" : "colors",
		// "visible" : false,
		// "searchable" : false
		// }, {
		// "data" : "sold",
		// "visible" : false,
		// "searchable" : false
		// }
		],
		"bLengthChange" : false
	});

	var buttonsDiv = "<div class='dt-buttons'><a class='dt-button buttons-create' tabindex='0' aria-controls='example'><span>New</span></a> <a class='dt-button buttons-selected buttons-edit disabled' tabindex='0' aria-controls='example'><span>Edit</span></a> <a class='dt-button buttons-selected buttons-remove disabled' tabindex='0' aria-controls='example'><span>Delete</span></a> </div>"
	$("#pTable_filter").prepend(buttonsDiv);
	$("#pTable_filter").attr("style", "width: 100%;");

	var table = $('#pTable').DataTable();

	$('#pTable tbody').on('click', 'tr', function() {
		var buts = $("#pTable_filter .buttons-selected");

		if ($(this).hasClass('selected')) {
			$(this).removeClass('selected');
			buts.addClass("disabled");
		} else {
			table.$('tr.selected').removeClass('selected');
			$(this).addClass('selected');
			buts.removeClass("disabled");
		}
		$("#pTable_filter .buttons-remove").click(function() {
			deleteProduct(table.row(this).data().code);
		});
	});

	$("#pTable_filter .buttons-create").click(function() {
		window.location.replace('newProduct');
	});
}
function colorTable() {
	$('#cTable').DataTable({
		"dom" : '<"toolbar">frtip',
		"ajax" : {
			"url" : "getColors/all",
			"dataSrc" : ""
		},
		//
		"columns" : [ {
			"data" : "id"
		}, {
			"data" : "code"
		}, {
			"data" : "urlColor"
		} ],
		"bLengthChange" : false,
	});

	var buttonsDiv = "<div class='dt-buttons'> 									<a class='dt-button buttons-create' tabindex='0' 										aria-controls='example'><span>New</span></a> 									<a class='dt-button buttons-selected buttons-edit disabled' 										tabindex='0' aria-controls='example'><span>Edit</span></a> 									<a class='dt-button buttons-selected buttons-remove disabled' 										tabindex='0' aria-controls='example'><span>Delete</span></a> 								</div>"
	$("#cTable_filter").prepend(buttonsDiv);
	$("#cTable_filter").attr("style", "width: 100%;");

	var table = $('#cTable').DataTable();

	$('#cTable tbody').on('click', 'tr', function() {
		var buts = $("#cTable_filter .buttons-selected");
		var data = table.row(this).data();
		if ($(this).hasClass('selected')) {
			$(this).removeClass('selected');
			buts.addClass('disabled');
		} else {
			table.$('tr.selected').removeClass('selected');
			$(this).addClass('selected');
			buts.removeClass('disabled');
		}
		$("#cTable_filter .buttons-remove").click(function() {
			deleteColor(table.row(this).data().id);
		});
	});

	$("#cTable_filter .buttons-create").click(function() {
		alert("NewColor");
	});
}

function imageTable() {
	$('#iTable').DataTable({
		"dom" : '<"toolbar">frtip',
		"ajax" : {
			"url" : "getImages/all",
			"dataSrc" : ""
		},
		//
		"columns" : [ {
			"data" : "id"
		}, {
			"data" : "urlImage"
		}, {
			"data" : "idColor"
		} ],
		"bLengthChange" : false,
	});

	var buttonsDiv = "<div class='dt-buttons'> 									<a class='dt-button buttons-create' tabindex='0' 										aria-controls='example'><span>New</span></a> 									<a class='dt-button buttons-selected buttons-edit disabled' 										tabindex='0' aria-controls='example'><span>Edit</span></a> 									<a class='dt-button buttons-selected buttons-remove disabled' 										tabindex='0' aria-controls='example'><span>Delete</span></a> 								</div>"
	$("#iTable_filter").prepend(buttonsDiv);
	$("#iTable_filter").attr("style", "width: 100%;");

	var table = $('#iTable').DataTable();

	$('#iTable tbody').on('click', 'tr', function() {
		var buts = $("#iTable_filter .buttons-selected");
		var data = table.row(this).data();
		if ($(this).hasClass('selected')) {
			$(this).removeClass('selected');
			buts.addClass('disabled');
		} else {
			table.$('tr.selected').removeClass('selected');
			$(this).addClass('selected');
			buts.removeClass('disabled');
		}
		$("#iTable_filter .buttons-remove").click(function() {
			deleteImage(table.row(this).data().id);
		});
	});

	$("#iTable_filter .buttons-create").click(function() {
		alert("newImage");
	});
}

function sizeTable() {
	$('#sTable').DataTable({
		"dom" : '<"toolbar">frtip',
		"ajax" : {
			"url" : "getSizes/all",
			"dataSrc" : ""
		},
		//
		"columns" : [ {
			"data" : "id"
		}, {
			"data" : "sizeValue"
		}, {
			"data" : "quantity"
		}, {
			"data" : "status"
		}, {
			"data" : "idColor"
		} ],
		"bLengthChange" : false,
	});

	var buttonsDiv = "<div class='dt-buttons'> 									<a class='dt-button buttons-create' tabindex='0' 										aria-controls='example'><span>New</span></a> 									<a class='dt-button buttons-selected buttons-edit disabled' 										tabindex='0' aria-controls='example'><span>Edit</span></a> 									<a class='dt-button buttons-selected buttons-remove disabled' 										tabindex='0' aria-controls='example'><span>Delete</span></a> 								</div>"
	$("#sTable_filter").prepend(buttonsDiv);
	$("#sTable_filter").attr("style", "width: 100%;");

	var table = $('#sTable').DataTable();

	$('#sTable tbody').on('click', 'tr', function() {
		var buts = $("#sTable_filter .buttons-selected");
		var data = table.row(this).data();
		if ($(this).hasClass('selected')) {
			$(this).removeClass('selected');
			buts.addClass('disabled');
		} else {
			table.$('tr.selected').removeClass('selected');
			$(this).addClass('selected');
			buts.removeClass('disabled');
		}
		$("#sTable_filter .buttons-remove").click(function() {
			deleteSize(table.row(this).data().id);
		});
	});

	$("#sTable_filter .buttons-create").click(function() {
		alert("NewSize");
	});
}

function deleteProduct(code) {
	$.ajax({
		url : '/fashion/deleteProduct/' + code,
		success : function() {
			window.location.replace('/fashion/dataTables');
		}
	});
}

function deleteColor(id) {
	$.ajax({
		url : '/fashion/deleteColor/' + id,
		success : function() {
			window.location.replace('/fashion/dataTables');
		}
	});
}

function deleteImage(id) {
	$.ajax({
		url : '/fashion/deleteImage/' + id,
		success : function() {
			window.location.replace('/fashion/dataTables');
		}
	});
}
function deleteSize(id) {
	$.ajax({
		url : '/fashion/deleteSize/' + id,
		success : function() {
			window.location.replace('/fashion/dataTables');
		}
	});
}
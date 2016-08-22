$(document).ready(function() {
	// start .ready()
	$("#saveBtn").click(function() {

		$("[class^='colorImgs']").each(function() {
			var filename = $(this).val();
			$(this).prev().val(filename);
		});
		//
		$("[class^='imageImgs']").each(function() {
			var fName = $(this).val();
			alert(fName);
			$(this).prev().val(fName);
		});
		
		$("#proFrom").submit();
	});

	$("input[name='price']").keyup(function() {
		var x = $("input[name='price']").val();
		$("input[name='price']").val(commaSeparateNumber(x));
	});

	$("input[name='saleoffprice']").keyup(function() {
		var x = $("input[name='saleoffprice']").val();
		$("input[name='saleoffprice']").val(commaSeparateNumber(x));
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
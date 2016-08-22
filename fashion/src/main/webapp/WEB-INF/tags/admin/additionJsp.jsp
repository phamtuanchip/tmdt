<%@ tag language="java" contentType="text/html; charset=utf-8"
	pageEncoding="utf-8"%%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<%@ taglib prefix="spring" uri="http://www.springframework.org/tags"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<tr>
	<td style="border: 2px solid rgba(128, 192, 255, 1)">
		<div>
			<fieldset>
				<legend style="color: blue; font-weight: bold; font-size: 150%">Màu</legend>
				<input id="fileInput" type="file" name="colorImgs" />
				<form:input type="hidden" path="product.colors[0].urlColor" />
				<img hidden="true"
					style="width: 40px; height: 40px; margin-bottom: -12px;" />
			</fieldset>
		</div>
		<div>
			<table>
				<tr>
					<td>
						<fieldset>
							<legend style="color: blue; font-weight: bold; font-size: 150%">Size & số lượng</legend>
							<div class="options">
								<form:label class="option_label"
									path="product.colors[0].sizes[0].sizeValue">Size</form:label>
								<div class="select">
									<form:select path="product.colors[0].sizes[0].sizeValue">
										<form:option value="S">S</form:option>
										<form:option value="M">M</form:option>
										<form:option value="XL">XL</form:option>
										<form:option value="XXL">XXL</form:option>
									</form:select>
								</div>
							</div>
							<div>
								<form:input path="product.colors[0].sizes[0].quantity"
									type="text" placeholder="Số lượng" data-trigger="change" />
								<form:label path="product.colors[0].sizes[0].quantity">Số lượng</form:label>
							</div>
							<div class="options">
								<form:label path="product.colors[0].sizes[0].status"
									class="option_label">Trạng thái</form:label>
								<div class="select">
									<form:select path="product.colors[0].sizes[0].status">
										<form:option value="0">Sắp về</form:option>
										<form:option value="1">Đang có</form:option>
										<form:option value="-1">Hết hàng</form:option>
									</form:select>
								</div>
							</div>
						</fieldset>
					</td>
					<td>
						<div class="modify">
							<i id="sizeAdd" class="fa fa-plus-circle"></i>
						</div>
					</td>
				</tr>
			</table>
		</div>
		<div id="imag" style="margin-top: 15px; margin-bottom: 15px;">
			<fieldset>
				<legend style="color: blue; font-weight: bold; font-size: 150%">Ảnh</legend>
				<table>
					<tr>
						<td><input id="fileInput" type="file" name="imageImgs" /> <form:input
								type="hidden" path="product.colors[0].images[0].urlImage" /></td>
						<td><img hidden="true"
							src="<c:url value='/resources/images/admin/64-64.jpg'/> "
							style="width: 40px; height: 40px;" /></td>
						<td><div class="modify" style="margin-bottom: 5px;">
								<i id="imgAdd" class="fa fa-plus-circle"></i>
							</div></td>
					</tr>
				</table>
			</fieldset>
		</div>
	</td>
	<td>
		<div class="modify">
			<i id="colAdd" class="fa fa-plus-circle"></i>
		</div>
	</td>
</tr>
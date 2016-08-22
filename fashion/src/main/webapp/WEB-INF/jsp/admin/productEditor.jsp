<%@ page language="java" contentType="text/html; charset=utf-8"
	pageEncoding="utf-8"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<%@ taglib prefix="spring" uri="http://www.springframework.org/tags"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8" />
<title>Sample Page by Designscrazed.com</title>

<link rel="stylesheet"
	href="<c:url value='/resources/css/admin/font-awesome.css' />">
<link rel="stylesheet"
	href="<c:url value='/resources/css/admin/productEditorStyle.css' />">
</head>
<body>
	<div class="headline">
		<h1>Chành House</h1>
		<br>
		<h1>Author: Nguyễn Tiến Nhật</h1>
	</div>
	<!--  Start here -->
	<form:form id ="proFrom" commandName="jSPForm" method="POST" enctype="multipart/form-data">
		<div id="wrap">
			<div id="accordian">
				<div class="step" id="step1" >
					<div class="number">
						<span>1</span>
					</div>
					<div class="title">
						<h1>Thông tin chung</h1>
					</div>
				</div>
				<div class="content" id="general">
					<map class="go-right">
						<div>
							<form:input path="product.code" placeholder="Mã"
								data-trigger="change" data-validation-minlength="1"
								data-type="name" data-required="true"
								data-error-message="Không được để trống." />
							<form:label path="product.code">Mã</form:label>
						</div>
						<div>
							<form:input path="product.name" placeholder="Tên"
								data-trigger="change" data-validation-minlength="1"
								data-type="name" data-required="true"
								data-error-message="Không được để trống." />
							<form:label path="product.name">Tên</form:label>
						</div>
						<div>
							<div class="options">
								<form:label class="option_label" path="product.gender">Giới tính</form:label>
								<div class="select">
									<form:select path="product.gender" onchange="genderChange(this)" >
										<form:option value="m">Đồ nam</form:option>
										<form:option value="wm">Đồ nữ</form:option>
										<form:option value="both">Đồ đôi</form:option>
									</form:select>
								</div>
							</div>
						</div>
						<div>
							<div class="options">
								<div class="select">
									<form:select path="product.category" >
										<form:option value="1">Đồ lót</form:option>
										<form:option value="2">Đồ ngủ</form:option>
										<form:option value="3">Đồ dạo phố</form:option>
										<form:option value="4">Đồ công sở</form:option>
									</form:select>
								</div>
								<label class="option_label">Category 1</label>
							</div>
						</div>
						<div >
							<div class="options">
								<div class="select">
									<form:select path="product.smallerCat"  onchange="smallerCatChange(this)">
										<form:option class= "smallerCat both" value="s">Áo</form:option>
										<form:option class= "smallerCat both" value="t">Quần</form:option>
										<form:option class= "smallerCat both" value="b">Bộ</form:option>
										<form:option class= "smallerCat wm" value="d">Váy</form:option>
									</form:select>
								</div>
								<form:label class="option_label" path="product.smallerCat">Category 2</form:label>
							</div>
						</div>
						<div >
							<div class="options">
								<div class="select">
									<form:select path="product.smallestCat">
										<form:option class= "smallestCat both s" value="0">Áo Sơ mi</form:option>
										<form:option class= "smallestCat both s" value="1">Áo lót</form:option>
										<form:option class= "smallestCat both t" value="2">Quần lót</form:option>
										<form:option class= "smallestCat both t" value="3">Quần Jeans</form:option>
										<form:option class= "smallestCat both b" value="4">Bộ pijama</form:option>
										<form:option class= "smallestCat wm d"   value="5">Váy ngủ</form:option>
									</form:select>
								</div>
								<form:label class="option_label" path="product.smallestCat">Category 3</form:label>
							</div>
						</div>
						<div >
							<div class="options">
								<div class="select">
									<form:select path="product.material">
										<form:option class= "both" value="0">Ren</form:option>
										<form:option class= "both" value="1">Jeans</form:option>
									</form:select>
								</div>
								<form:label class="option_label" path="product.material">Chất liệu</form:label>
							</div>
						</div>
						<div>
							<form:textarea path="product.description"
								placeholder="Giới thiệu" data-trigger="change" data-type="text" />
							<form:label path="product.description">Giới thiệu</form:label>
						</div>
					</map>
				</div>
				<div class="step" id="step2">
					<div class="number">
						<span>2</span>
					</div>
					<div class="title">
						<h1>Giá</h1>
					</div>
				</div>
				<div class="content" id="price">
					<map class="go-right">
						<div>
							<form:input path="product.importprice" type="text"
								placeholder="Giá nhập" data-trigger="change" />
							<label>Giá nhập</label>
						</div>
						<div>
							<form:input path="product.price" type="text"
								placeholder="Giá bán" data-trigger="change" />
							<label>Giá bán</label>
						</div>
						<div>
							<form:input path="product.saleoffprice" type="text"
								placeholder="Giá khuyến mại" data-trigger="change" />
							<form:label path="product.saleoffprice">Giá KM</form:label>
						</div>
					</map>
				</div>

				<div class="step" id="step2">
					<div class="number">
						<span>3</span>
					</div>
					<div class="title">
						<h1>Màu sắc</h1>
					</div>
				</div>
				<div class="content" id="colorDiv">
					<map class="go-right">
						<table id="tbl">
							<tr>
								<td style="border: 2px solid rgba(128, 192, 255, 1)">
									<div>
										<fieldset>
											<legend
												style="color: blue; font-weight: bold; font-size: 150%">Màu</legend>
											<table>
												<tr>
													<td><input id="fileInput" type="file" name="colorImgs" />
														<form:input type="hidden" path="product.colors[0].urlColor" /></td>
													<td><img hidden="hidden" style="width: 40px; height: 40px;" /></td>
												</tr>
											</table>
										</fieldset>
									</div>
									<div>
										<table class="sizTbl">
											<tr>
												<td>
													<fieldset>
														<legend style="color: blue; font-weight: bold; font-size: 150%">Size & số lượng</legend>
														<div class="options">
															<form:label class="option_label"
																path="product.colors[0].sizes[0].sizeValue" >Size</form:label>
															<div class="select">
																<form:select path="product.colors[0].sizes[0].sizeValue" >
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
																<form:select path="product.colors[0].sizes[0].status" >
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
														<i id="sizAdd" class="fa fa-plus-circle"></i>
													</div>
												</td>
											</tr>
										</table>
									</div>
									<div id="imag" style="margin-top: 15px; margin-bottom: 15px;">
										<fieldset>
											<legend
												style="color: blue; font-weight: bold; font-size: 150%">Ảnh</legend>
											<table class="imgTbl">
												<tr>
													<td><input id="fileInput" type="file" name="imageImgs" />
														<form:input type="hidden"
															path="product.colors[0].images[0].urlImage" /></td>
													<td><img hidden="hidden" style="width: 40px; height: 40px;" /></td>
													<td><div class="modify" style="margin-bottom: 5px;">
															<i id="imgAdd" class="fa fa-plus-circle"></i>
														</div>
													</td>
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
						</table>
					</map>
				</div>


				<div class="content" id="final_products">
					<div class="right" id="reviewed">
						<div id="complete">
							<a class="big_button" id="complete" href="#">Hoàn tất</a> <span
								class="sub">By selecting this button you agree to the
								purchase and subsequent payment for this order.</span>
						</div>


					</div>
				</div>
			</div>
		</div>
	</form:form>
	<script type="text/javascript"
		src=" <c:url value='/resources/js/admin/jquery-1.11.1.js' /> "></script>
	<script type="text/javascript"
		src=" <c:url value='/resources/js/admin/productEditor_script.js' /> "></script>
</body>
</html>
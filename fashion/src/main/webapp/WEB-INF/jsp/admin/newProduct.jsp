<%@ page language="java" contentType="text/html; charset=utf-8"
	pageEncoding="utf-8"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<%@ taglib prefix="spring" uri="http://www.springframework.org/tags"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta charset="utf-8" />
<meta name="viewport"
	content="width=device-width, initial-scale=1, maximum-scale=1" />
<meta name="description" content="" />
<meta name="author" content="" />
<!--[if IE]>
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
        <![endif]-->
<title>Free Responsive Admin Theme - ZONTAL</title>
<!-- BOOTSTRAP CORE STYLE  -->
<link href="<c:url value='/resources/css/admin/bootstrap.css'/>"
	rel="stylesheet" />
<!-- FONT AWESOME ICONS  -->
<link href="<c:url value='/resources/css/admin/font-awesome.css'/>"
	rel="stylesheet" />
<!-- CUSTOM STYLE  -->
<link href="<c:url value='/resources/css/admin/style.css'/>"
	rel="stylesheet" />
<link href="<c:url value='/resources/css/admin/popup.css'/>"
	rel="stylesheet" />
<!-- HTML5 Shiv and Respond.js for IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
	<header>
		<div class="container">
			<div class="row">
				<div class="col-md-12">
					<strong>Email: </strong>info@yourdomain.com &nbsp;&nbsp; <strong>Support:
					</strong>+90-897-678-44
				</div>

			</div>
		</div>
	</header>
	<!-- HEADER END-->
	<div class="navbar navbar-inverse set-radius-zero">
		<div class="container">
			<div class="navbar-header">
				<button type="button" class="navbar-toggle" data-toggle="collapse"
					data-target=".navbar-collapse">
					<span class="icon-bar"></span> <span class="icon-bar"></span> <span
						class="icon-bar"></span>
				</button>
				<a class="navbar-brand" href="index.html"> <img
					src="<c:url value = '/resources/images/admin/logo.png' />" />
				</a>

			</div>

			<div class="left-div">
				<div class="user-settings-wrapper">
					<ul class="nav">

						<li class="dropdown"><a class="dropdown-toggle"
							data-toggle="dropdown" href="#" aria-expanded="false"> <span
								class="glyphicon glyphicon-user" style="font-size: 25px;"></span>
						</a>
							<div class="dropdown-menu dropdown-settings">
								<div class="media">
									<a class="media-left" href="#"> <img
										src="<c:url value='/resources/images/admin/64-64.jpg'/> "
										alt="" class="img-rounded" />
									</a>
									<div class="media-body">
										<h4 class="media-heading">Jhon Deo Alex</h4>
										<h5>Developer & Designer</h5>

									</div>
								</div>
								<hr />
								<h5>
									<strong>Personal Bio : </strong>
								</h5>
								Anim pariatur cliche reprehen derit.
								<hr />
								<a href="#" class="btn btn-info btn-sm">Full Profile</a>&nbsp; <a
									href="login.html" class="btn btn-danger btn-sm">Logout</a>

							</div></li>


					</ul>
				</div>
			</div>
		</div>
	</div>
	<!-- LOGO HEADER END-->
	<section class="menu-section">
		<div class="container">
			<div class="row">
				<div class="col-md-12">
					<div class="navbar-collapse collapse ">
						<ul id="menu-top" class="nav navbar-nav navbar-right">
							<li><a href="<c:url value='/adminHome' />">Dashboard</a></li>
							<li><a href="<c:url value='/dataTables' />">Data Tables</a></li>
							<li><a class="menu-top-active"
								href="<c:url value='/newProduct' />">New Product</a></li>

						</ul>
					</div>
				</div>

			</div>
		</div>
	</section>
	<!-- MENU SECTION END-->
	<div class="content-wrapper">
		<div class="container">
			<div class="row">
				<div class="col-md-12">
					<h4 class="page-head-line">NEW PRODUCT</h4>

				</div>

			</div>
			<div class="row">
				<form:form id="proFrom" commandName="jSPForm" method="POST"
					enctype="multipart/form-data">
					<div class="col-md-6">
						<div class="Compose-Message">
							<div class="panel panel-custom">
								<div class="panel-heading">Thông tin chung</div>
								<div class="panel-body">

									<form:label path="product.code">Mã</form:label>
									<form:input path="product.code" class="form-control" />

									<form:label path="product.name">Tên</form:label>
									<form:input path="product.name" class="form-control" />

									<form:label class="option_label" path="product.gender">Giới tính</form:label>
									<form:select path="product.gender"
										onchange="genderChange(this)" class="form-control">
										<form:option value="m">Đồ nam</form:option>
										<form:option value="wm">Đồ nữ</form:option>
										<form:option value="both">Đồ đôi</form:option>
									</form:select>

									<label class="option_label">Category 1</label>
									<form:select path="product.category" class="form-control">
										<form:option value="underwear">Đồ lót    </form:option>
										<form:option value="sleepwear">Đồ ngủ    </form:option>
										<form:option value="casual">Đồ dạo phố</form:option>
										<form:option value="offical">Đồ công sở</form:option>
										<form:option value="sport">Đồ thể thao</form:option>
									</form:select>

									<form:label class="option_label" path="product.smallerCat">Category 2</form:label>
									<form:select path="product.smallerCat"
										onchange="smallerCatChange(this)" class="form-control">
										<form:option class="smallerCat both" value="s">Áo</form:option>
										<form:option class="smallerCat both" value="t">Quần</form:option>
										<form:option class="smallerCat both" value="b">Bộ</form:option>
										<form:option class="smallerCat wm" value="d">Váy</form:option>
									</form:select>

									<form:label class="option_label" path="product.smallestCat">Category 3</form:label>
									<form:select path="product.smallestCat" class="form-control">
										<form:option class="smallestCat both s" value="ao_so_mi">Áo Sơ mi</form:option>
										<form:option class="smallestCat both s" value="ao_lot">Áo lót</form:option>
										<form:option class="smallestCat both t" value="quan_lot">Quần lót</form:option>
										<form:option class="smallestCat both t" value="quan_jeans">Quần Jeans</form:option>
										<form:option class="smallestCat both b" value="bo_pijama">Bộ pijama</form:option>
										<form:option class="smallestCat wm d" value="vay_ngu">Váy ngủ</form:option>
										<form:option class="smallestCat wm d" value="quan_vai">Quần vải</form:option>
									</form:select>

									<form:label class="option_label" path="product.material">Chất liệu</form:label>
									<form:select path="product.material" class="form-control">
										<form:option class="both" value="ren">Ren</form:option>
										<form:option class="both" value="jeans">Jeans</form:option>
										<form:option class="both" value="silk">lụa</form:option>
										<form:option class="both" value="cotton">Cotton</form:option>
										<form:option class="both" value="vai_tho">Vải thô</form:option>
									</form:select>

									<form:label path="product.description">Giới thiệu</form:label>
									<form:textarea path="product.description" rows="5"
										class="form-control"></form:textarea>
								</div>
							</div>
						</div>
						<hr />

						<hr />
						<div class="Compose-Message">
							<div class="panel panel-custom">
								<div class="panel-heading">Giá</div>
								<div class="panel-body">
									<form:label path="product.importprice">Giá nhập</form:label>
									<form:input path="product.importprice" class="form-control" />

									<form:label path="product.price">Giá bán</form:label>
									<form:input path="product.price" class="form-control" />

									<form:label path="product.saleoffprice">Giá khuyến mại</form:label>
									<form:input path="product.saleoffprice" class="form-control" />
								</div>
							</div>
						</div>
					</div>
					<div class="col-md-6">
						<div id="rightDiv" class="Compose-Message">
							<div class="panel panel-custom color">
								<div class="panel-heading">
									Màu sắc
									<div class="modify pull-right">
										<i class="fa fa-plus-circle color"></i>
									</div>
								</div>
								<div class="panel-body">
									<form:label path="product.colors[0].urlColor">Ảnh màu </form:label>
									<table>
										<tr>
											<td><input id="fileInput" type="file" name="colorImgs" />
												<form:input type="hidden" path="product.colors[0].urlColor" /></td>
											<td><img hidden="hidden"
												style = "width: 40px; height: 40px; margin-left: 40px;" class="pull-right" /></td>
										</tr>
									</table>
									<br>

									<div class="panel panel-default size">
										<div class="panel-heading">
											Size & Số lượng
											<div class="modify pull-right">
												<i class="fa fa-plus-circle size"></i>
											</div>
										</div>
										<div class="panel-body">
											<form:label path="product.colors[0].sizes[0].sizeValue">Size</form:label>
											<form:select path="product.colors[0].sizes[0].sizeValue"
												class="form-control">
												<form:option value="S">S</form:option>
												<form:option value="M">M</form:option>
												<form:option value="XL">XL</form:option>
												<form:option value="XXL">XXL</form:option>
											</form:select>

											<form:label path="product.colors[0].sizes[0].quantity">Số lượng</form:label>
											<form:input path="product.colors[0].sizes[0].quantity"
												class="form-control" />

											<form:label path="product.colors[0].sizes[0].status">Trạng thái</form:label>
											<form:select path="product.colors[0].sizes[0].status"
												class="form-control">
												<form:option value="sap_ve">Sắp về  </form:option>
												<form:option value="dang_co">Đang có </form:option>
												<form:option value="het_hang">Hết hàng</form:option>
											</form:select>
										</div>
									</div>

									<div class="panel panel-default">
										<div class="panel-heading">Ảnh</div>
										<div class="panel-body">
											<table class="imgTbl">
												<tr>
													<td><input id="fileInput" type="file" name="imageImgs" />
														<form:input type="hidden" path="product.colors[0].images[0].urlImage" /></td>
													<td style="width: 60px;;"><img hidden="hidden" style="width: 40px; height: 40px;" /></td>
													<td><div class="modify" style="margin-top: 5.5px">
															<i class="fa fa-plus-circle image"></i>
														</div></td>
												</tr>
											</table>
										</div>
									</div>
									<hr />
									<div class="panel-footer text-muted">
										<strong>Hướng dẫn : </strong> Một sản phẩm có thể có nhiều màu
										sắc, mỗi màu sắc lại có nhiều size và ảnh tương ứng. Ấn dấu
										(+) để add thêm màu sắc hoặc kích thước hoặc hình ảnh khác
									</div>
								</div>
							</div>
						</div>
						<br>
						<hr />
						<hr />
						<div class="panel-footer">
							<a class="btn btn-warning btn-block" href="#" >
	                              Hoàn tất
	                    	</a>
                    	</div>
					</div>
				</form:form>
			</div>
	</div>
	<!-- CONTENT-WRAPPER SECTION END-->
	<footer>
		<div class="container">
			<div class="row">
				<div class="col-md-12">
					&copy; 2015 YourCompany | By : <a
						href="http://www.designbootstrap.com/" target="_blank">DesignBootstrap</a>
				</div>

			</div>
		</div>
	</footer>
	<!-- FOOTER SECTION END-->
	<!-- JAVASCRIPT AT THE BOTTOM TO REDUCE THE LOADING TIME  -->
	<!-- CORE JQUERY SCRIPTS -->
	<script type="text/javascript"
		src=" <c:url value='/resources/js/admin/jquery-1.11.1.js' /> "></script>
	<!-- BOOTSTRAP SCRIPTS  -->
	<script type="text/javascript"
		src=" <c:url value='/resources/js/admin/bootstrap.js' /> "></script>

	<script type="text/javascript"
		src=" <c:url value='/resources/js/admin/productEditor_script.js' /> "></script>
</body>
</html>
<%@ page language="java" contentType="text/html; charset=utf-8"
	pageEncoding="utf-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html>
<head>
<title>Eshop a Flat E-Commerce Bootstrap Responsive Website Template | Home :: w3layouts</title>
<link href="<c:url value ='/resources/css/web/bootstrap.css'/>" rel='stylesheet' type='text/css' />
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="<c:url value ='/resources/js/web/jquery.min.js'/> "></script>
<!-- Custom Theme files -->
<link href="<c:url value ='/resources/css/web/style.css'/>" rel="stylesheet" type="text/css" media="all" />
<!-- Custom Theme files -->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Eshop Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<!--webfont-->
<!-- for bootstrap working -->
	<script type="text/javascript" src="<c:url value ='/resources/js/web/bootstrap-3.1.1.min.js' />"></script>
<!-- //for bootstrap working -->
<!-- cart -->
	<script src="<c:url value ='/resources/js/web/simpleCart.min.js' />"> </script>
<!-- cart -->
<link rel="stylesheet" href="<c:url value ='/resources/css/web/flexslider.css'/>" type="text/css" media="screen" />
</head>
<body>
	<!-- header-section-starts -->
	<div class="header">
		<div class="header-top-strip">
			<div class="container">
				<div class="header-top-left">
					<ul>
						<li><a href="account.html"><span class="glyphicon glyphicon-user"> </span>Login</a></li>
<!-- 						<li><a href="register.html"><span class="glyphicon glyphicon-lock"> </span>Create an Account</a></li>			 -->
					</ul>
				</div>
				<div class="header-right">
						<div class="cart box_1">
							<a href="checkout.html">
<%-- 								<h3> <span class="simpleCart_total"> $0.00 </span> (<span id="simpleCart_quantity" class="simpleCart_quantity"> 0 </span>)<img src="<c:url value ="/resources/images/web/bag.png" />" alt=""></h3> --%>
							</a>	
<!-- 							<p><a href="javascript:;" class="simpleCart_empty">Empty cart</a></p> -->
							<div class="clearfix"> </div>
						</div>
				</div>
				<div class="clearfix"> </div>
			</div>
		</div>
	</div>
	<!-- header-section-ends -->
			<div class="banner-top">
		<div class="container">
				<nav class="navbar navbar-default" role="navigation">
	    <div class="navbar-header">
	        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
		        <span class="sr-only">Toggle navigation</span>
		        <span class="icon-bar"></span>
		        <span class="icon-bar"></span>
		        <span class="icon-bar"></span>
	        </button>
				<div class="logo">
					<h1><a href="<c:url value='/'/>"><span>E</span> -Chành house</a></h1>
				</div>
	    </div>
	    <!--/.navbar-header-->
	
	    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
	        <ul class="nav navbar-nav">
			<li><a href="index.html">Trang chủ</a></li>
		        <li class="dropdown">
		            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Nam <b class="caret"></b></a>
		            <ul class="dropdown-menu multi-column columns-3">
			            <div class="row">
				            <div class="col-sm-4">
					            <ul class="multi-column-dropdown">
									<h6>Mới</h6>
						            <li><a href="<c:url value='/mproducts/1/desc/date' />">Đồ lót mới</a></li>
						            <li><a href="<c:url value='/mproducts/2/desc/date' />">Đồ ngủ mới</a></li>
						            <li><a href="<c:url value='/mproducts/3/desc/date' />">Đồ công sở</a></li>
						            <li><a href="<c:url value='/mproducts/4/desc/date' />">Đồ dạo phố</a></li>
						            <li><a href="<c:url value='/mproducts/0/desc/date' />">Khác</a></li>
					            </ul>
				            </div>
				            <div class="col-sm-4">
					            <ul class="multi-column-dropdown">
									<h6>Quần áo</h6>
						            <li><a href="<c:url value='/mproducts/1/desc/date' />">Áo sơ mi</a></li>
						            <li><a href="<c:url value='/mproducts/1/desc/date' />">Quần Jeans</a></li>
						            <li><a href="<c:url value='/mproducts/1/desc/date' />">Quần soóc</a></li>
						            <li><a href="<c:url value='/mproducts/1/desc/date' />">Quấn áo bóng đá</a></li>
					            </ul>
				            </div>
							<div class="clearfix"></div>
			            </div>
		            </ul>
		        </li>
		        <li class="dropdown">
		            <a href="#" class="dropdown-toggle" data-toggle="dropdown">Nữ <b class="caret"></b></a>
		            <ul class="dropdown-menu multi-column columns-3">
			            <div class="row">
				            <div class="col-sm-4">
					            <ul class="multi-column-dropdown">
									<h6>NEW IN</h6>
						            <li><a href="<c:url value='/wproducts/1/desc/date' />">Đồ lót mới</a></li>
						            <li><a href="<c:url value='/wproducts/2/desc/date' />">Đồ ngủ mới</a></li>
						            <li><a href="<c:url value='/wproducts/3/desc/date' />">Đồ công sở</a></li>
						            <li><a href="<c:url value='/wproducts/4/desc/date' />">Đồ dạo phố</a></li>
					            </ul>
				            </div>
				            <div class="col-sm-4">
					            <ul class="multi-column-dropdown">
									<h6>Quần áo</h6>
						            <li><a href="products.html">Quần Jeans</a></li>
						            <li><a href="products.html">Quần soóc</a></li>
						            <li><a href="products.html">Áo sơ mi</a></li>
						            <li><a href="products.html">Tất</a></li>
					            </ul>
				            </div>
							<div class="clearfix"></div>
			            </div>
		            </ul>
		        </li>
<!-- 		        <li class="dropdown"> -->
<!-- 		        	<a href="#" class="dropdown-toggle" data-toggle="dropdown">kids <b class="caret"></b></a> -->
<!-- 		            <ul class="dropdown-menu multi-column columns-2"> -->
<!-- 			            <div class="row"> -->
<!-- 				            <div class="col-sm-6"> -->
<!-- 					            <ul class="multi-column-dropdown"> -->
<!-- 									<h6>NEW IN</h6> -->
<!-- 						            <li><a href="products.html">New In Boys Clothing</a></li> -->
<!-- 						            <li><a href="products.html">New In Girls Clothing</a></li> -->
<!-- 						            <li><a href="products.html">New In Boys Shoes</a></li> -->
<!-- 						            <li><a href="products.html">New In Girls Shoes</a></li> -->
<!-- 					            </ul> -->
<!-- 				            </div> -->
<!-- 				            <div class="col-sm-6"> -->
<!-- 					             <ul class="multi-column-dropdown"> -->
<!-- 									<h6>ACCESSORIES</h6> -->
<!-- 						            <li><a href="products.html">Bags</a></li> -->
<!-- 						            <li><a href="products.html">Watches</a></li> -->
<!-- 						            <li><a href="products.html">Sun Glasses</a></li> -->
<!-- 						            <li><a href="products.html">Jewellery</a></li> -->
<!-- 					            </ul> -->
<!-- 				            </div> -->
<!-- 							<div class="clearfix"></div> -->
<!-- 			            </div> -->
<!-- 		            </ul> -->
<!-- 		        </li> -->
					<li><a href="typography.html">TYPO</a></li>
					<li><a href="contact.html">CONTACT</a></li>
	        </ul>
	    </div>
	    <!--/.navbar-collapse-->
	</nav>
	<!--/.navbar-->
</div>
</div>
	<div class="banner">
		<div class="container">
<div class="banner-bottom">
	<div class="banner-bottom-left">
		<h2>B<br>U<br>Y</h2>
	</div>
	<div class="banner-bottom-right">
		<div  class="callbacks_container">
					<ul class="rslides" id="slider4">
					<li>
								<div class="banner-info">
									<h3>Smart But Casual</h3>
									<p>Start your shopping here...</p>
								</div>
							</li>
							<li>
								<div class="banner-info">
								   <h3>Shop Online</h3>
									<p>Start your shopping here...</p>
								</div>
							</li>
							<li>
								<div class="banner-info">
								  <h3>Pack your Bag</h3>
									<p>Start your shopping here...</p>
								</div>								
							</li>
						</ul>
					</div>
					<!--banner-->
	  			<script src="<c:url value ='/resources/js/web/responsiveslides.min.js'/>"></script>
			 <script>
			    // You can also use "$(window).load(function() {"
			    $(function () {
			      // Slideshow 4
			      $("#slider4").responsiveSlides({
			        auto: true,
			        pager:true,
			        nav:false,
			        speed: 500,
			        namespace: "callbacks",
			        before: function () {
			          $('.events').append("<li>before event fired.</li>");
			        },
			        after: function () {
			          $('.events').append("<li>after event fired.</li>");
			        }
			      });
			
			    });
			  </script>
	</div>
	<div class="clearfix"> </div>
</div>
	<div class="shop">
		<a href="single.html">SHOP COLLECTION NOW</a>
	</div>
	</div>
		</div>
		<!-- content-section-starts-here -->
		<div class="container">
			<div class="main-content">
				<div class="online-strip">
					<div class="col-md-4 follow-us">
						<h3>follow us : <a class="twitter" href="#"></a><a class="facebook" href="#"></a></h3>
					</div>
					<div class="col-md-4 shipping-grid">
						<div class="shipping">
							<img src="<c:url value ='/resources/images/web/shipping.png'/>" alt="" />
						</div>
						<div class="shipping-text">
							<h3>Free Shipping</h3>
							<p>on orders over $ 199</p>
						</div>
						<div class="clearfix"></div>
					</div>
					<div class="col-md-4 online-order">
						<p>Order online</p>
						<h3>Tel:999 4567 8902</h3>
					</div>
					<div class="clearfix"></div>
				</div>
				<div class="products-grid">
					<header>
						<h3 class="head text-center">Sản phẩm mới</h3>
					</header>
  					<c:if test="${end >0}">
					<c:forEach begin="0" end="${end -1}" var="i" step="1">
						<div class="col-md-4 product simpleCart_shelfItem text-center">
							<c:url value="/single/${newProducts[i].code}" var="url"/>
 							<a href="<c:out value='${url}'/>">
							<img src="<c:url value ='/images/${newProducts[i].colors[0].images[0].urlImage }'/>" alt="" /></a>
							<div class="mask">
								<a href="<c:out value='${url}'/>">Quick View</a>
							</div>
							<a class="product_name" href="<c:out value='${url}'/>">${newProducts[i].name }</a>
							<p><a class="item_add" href="#"><i></i> <span class="item_price">${newProducts[i].price } VND</span></a></p>
						</div>
					</c:forEach>
               </c:if>
					<div class="clearfix"></div>
				</div>
			</div>

		</div>
		<div class="other-products">
		<div class="container">
			<h3 class="like text-center">Sản phẩm mua nhiều nhất</h3>        			
				     <ul id="flexiselDemo3">
				     <c:if test="${end >0}">
				     <c:forEach begin="0" end="${end -1}" var="i" step="1">
				     <c:url value="/single/${bestSaleProducts[i].code}" var="url"/>
						<li><a href="<c:out value='${url}'/>"><img src="<c:url value ='/images/${bestSaleProducts[i].colors[0].images[0].urlImage }'/>" class="img-responsive" alt="" /></a>
							<div class="product liked-product simpleCart_shelfItem">
							<a class="like_name" href="<c:out value='${url}'/>">${bestSaleProducts[i].name }</a>
							<p><a class="item_add" href="#"><i></i> <span class=" item_price">${bestSaleProducts[i].price } VND</span></a></p>
							</div>
						</li>
					 </c:forEach>
					 </c:if>
				     </ul>
				    <script type="text/javascript">
					 $(window).load(function() {
						$("#flexiselDemo3").flexisel({
							visibleItems: 4,
							animationSpeed: 1000,
							autoPlay: true,
							autoPlaySpeed: 3000,    		
							pauseOnHover: true,
							enableResponsiveBreakpoints: true,
					    	responsiveBreakpoints: { 
					    		portrait: { 
					    			changePoint:480,
					    			visibleItems: 1
					    		}, 
					    		landscape: { 
					    			changePoint:640,
					    			visibleItems: 2
					    		},
					    		tablet: { 
					    			changePoint:768,
					    			visibleItems: 3
					    		}
					    	}
					    });
					    
					});
				   </script>
				   <script type="text/javascript" src="<c:url value ='/resources/js/web/jquery.flexisel.js'/>"></script>
				   </div>
				   </div>
		<!-- content-section-ends-here -->
		<div class="news-letter">
			<div class="container">
				<div class="join">
					<h6>JOIN OUR MAILING LIST</h6>
					<div class="sub-left-right">
						<form>
							<input type="text" value="Enter Your Email Here" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Enter Your Email Here';}" />
							<input type="submit" value="SUBSCRIBE" />
						</form>
					</div>
					<div class="clearfix"> </div>
				</div>
			</div>
		</div>
		<div class="footer">
		<div class="container">
		 <div class="footer_top">
			<div class="span_of_4">
				<div class="col-md-3 span1_of_4">
					<h4>Shop</h4>
					<ul class="f_nav">
						<li><a href="#">new arrivals</a></li>
						<li><a href="#">men</a></li>
						<li><a href="#">women</a></li>
						<li><a href="#">accessories</a></li>
						<li><a href="#">kids</a></li>
						<li><a href="#">brands</a></li>
						<li><a href="#">trends</a></li>
						<li><a href="#">sale</a></li>
						<li><a href="#">style videos</a></li>
					</ul>	
				</div>
				<div class="col-md-3 span1_of_4">
					<h4>help</h4>
					<ul class="f_nav">
						<li><a href="#">frequently asked  questions</a></li>
						<li><a href="#">men</a></li>
						<li><a href="#">women</a></li>
						<li><a href="#">accessories</a></li>
						<li><a href="#">kids</a></li>
						<li><a href="#">brands</a></li>
					</ul>	
				</div>
				<div class="col-md-3 span1_of_4">
					<h4>account</h4>
					<ul class="f_nav">
						<li><a href="account.html">login</a></li>
						<li><a href="register.html">create an account</a></li>
						<li><a href="#">create wishlist</a></li>
						<li><a href="checkout.html">my shopping bag</a></li>
						<li><a href="#">brands</a></li>
						<li><a href="#">create wishlist</a></li>
					</ul>				
				</div>
				<div class="col-md-3 span1_of_4">
					<h4>popular</h4>
					<ul class="f_nav">
						<li><a href="#">new arrivals</a></li>
						<li><a href="#">men</a></li>
						<li><a href="#">women</a></li>
						<li><a href="#">accessories</a></li>
						<li><a href="#">kids</a></li>
						<li><a href="#">brands</a></li>
						<li><a href="#">trends</a></li>
						<li><a href="#">sale</a></li>
						<li><a href="#">style videos</a></li>
						<li><a href="#">login</a></li>
						<li><a href="#">brands</a></li>
					</ul>			
				</div>
				<div class="clearfix"></div>
				</div>
		  </div>
		  <div class="cards text-center">
				<img src="<c:url value ='/resources/images/web/cards.jpg'/>" alt="" />
		  </div>
		  <div class="copyright text-center">
				<p>Â© 2015 Eshop. All Rights Reserved | Design by   <a href="http://w3layouts.com">  W3layouts</a></p>
		  </div>
		</div>
		</div>
</body>
</html>
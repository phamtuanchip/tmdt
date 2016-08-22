<%@ page language="java" contentType="text/html; charset=utf-8"
	pageEncoding="utf-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <!--[if IE]>
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
        <![endif]-->
    <title>Free Responsive Admin Theme - ZONTAL</title>
    <!-- BOOTSTRAP CORE STYLE  -->
    <link href="<c:url value='/resources/css/admin/bootstrap.css'/>" rel="stylesheet" />
    <!-- FONT AWESOME ICONS  -->
    <link href="<c:url value='/resources/css/admin/font-awesome.css'/>" rel="stylesheet" />
    <!-- CUSTOM STYLE  -->
    <link href="<c:url value='/resources/css/admin/style.css'/>" rel="stylesheet" />
    <link rel="stylesheet" href="<c:url value='/resources/css/admin/jQuery.dataTables.min.css' />">
    <link rel="stylesheet" href="<c:url value='/resources/css/admin/editor.css' />">
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
                    <strong>Email: </strong>info@yourdomain.com
                    &nbsp;&nbsp;
                    <strong>Support: </strong>+90-897-678-44
                </div>

            </div>
        </div>
    </header>
    <!-- HEADER END-->
    <div class="navbar navbar-inverse set-radius-zero">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="index.html">

                    <img src="<c:url value = '/resources/images/admin/logo.png' />" />
                </a>

            </div>

            <div class="left-div">
                <div class="user-settings-wrapper">
                    <ul class="nav">

                        <li class="dropdown">
                            <a class="dropdown-toggle" data-toggle="dropdown" href="#" aria-expanded="false">
                                <span class="glyphicon glyphicon-user" style="font-size: 25px;"></span>
                            </a>
                            <div class="dropdown-menu dropdown-settings">
                                <div class="media">
                                    <a class="media-left" href="#">
                                        <img src="<c:url value='/resources/images/admin/64-64.jpg'/> " alt="" class="img-rounded" />
                                    </a>
                                    <div class="media-body">
                                        <h4 class="media-heading">Jhon Deo Alex </h4>
                                        <h5>Developer & Designer</h5>

                                    </div>
                                </div>
                                <hr />
                                <h5><strong>Personal Bio : </strong></h5>
                                Anim pariatur cliche reprehen derit.
                                <hr />
                                <a href="#" class="btn btn-info btn-sm">Full Profile</a>&nbsp; <a href="login.html" class="btn btn-danger btn-sm">Logout</a>

                            </div>
                        </li>


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
                            <!-- <li><a href="ui.html">UI Elements</a></li> -->
                            <li><a class="menu-top-active" href="<c:url value='/dataTables' />">Data Tables</a></li>
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
                        <h4 class="page-head-line">Data Tables</h4>
                    </div>
                </div>
                <div class="row">
                <div class="col-md-6">
                  <!--   Kitchen Sink -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Thông tin cơ bản
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table id="pTable" class="table  table-striped table-hover" >
                                    <thead>
                                        <tr>
                                            <th>Mã</th>
											<th>Tên</th>
											<th>Giới tính</th>
											<th>Cat 1</th>
											<th>Cat 2</th>
											<th>Cat 3</th>
											<th>Chất liệu</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                            <th>Mã</th>
											<th>Tên</th>
											<th>Giới tính</th>
											<th>Cat 1</th>
											<th>Cat 2</th>
											<th>Cat 3</th>
											<th>Chất liệu</th>
                                        </tr>
                                    </tfoot>
                                    
                                </table>
                            </div>
                        </div>
                    </div>
                     <!-- End  Kitchen Sink -->
                </div>
                <div class="col-md-6">
                     <!--   Basic Table  -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Màu sắc
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                            <table id="cTable" class="table">
									<thead>
										<tr>
											<th>ID</th>
                                            <th>Mã</th>
                                            <th>Url</th>
										</tr>
									</thead>
									<tfoot>
										<tr>
											<th>ID</th>
                                            <th>Mã</th>
                                            <th>Url</th>
										</tr>
									</tfoot>
								</table>
                            </div>
                        </div>
                    </div>
                      <!-- End  Basic Table  -->
                </div>
            </div>
                <div class="row">
                <div class="col-md-6">
                      <!--    Striped Rows Table  -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Hình ảnh
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table id="iTable" class="table table-striped">
                                    <thead>
                                        <tr>
                                           <th>ID</th>
                                            <th>Url</th>
                                            <th>Color's ID</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                           <th>ID</th>
                                            <th>Url</th>
                                            <th>Color's ID</th>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                        </div>
                    </div>
                    <!--  End  Striped Rows Table  -->
                </div>
                <div class="col-md-6">
                    <!--    Bordered Table  -->
                    <div class="panel panel-default">
                        <div class="panel-heading">
                           Kích thước
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                                <table id="sTable" class="table">
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Size</th>
                                            <th>Số lượng</th>
                                            <th>Trạng thái</th>
                                            <th>Color's ID</th>
                                        </tr>
                                    </thead>
                                    <tfoot>
                                        <tr>
                                           <th>ID</th>
                                            <th>Size</th>
                                            <th>Số lượng</th>
                                            <th>Trạng thái</th>
                                            <th>Color's ID</th>
                                        </tr>
                                    </tfoot>
                                    
                                </table>
                            </div>
                        </div>
                    </div>
                     <!--  End  Bordered Table  -->
                </div>
            </div>

        </div>
    </div>
    <!-- CONTENT-WRAPPER SECTION END-->
    <footer>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    &copy; 2015 YourCompany | By : <a href="http://www.designbootstrap.com/" target="_blank">DesignBootstrap</a>
                </div>

            </div>
        </div>
    </footer>
    <!-- FOOTER SECTION END-->
    <!-- JAVASCRIPT AT THE BOTTOM TO REDUCE THE LOADING TIME  -->
    <!-- CORE JQUERY SCRIPTS -->
    <script src="<c:url value='/resources/js/admin/jquery-1.11.1.js' />"></script>
	<script src="<c:url value='/resources/js/admin/dataTables_1.10.10.js' />"></script>
	<script src="<c:url value='/resources/js/admin/bootstrap.js' />"></script>
	<script src="<c:url value='/resources/js/admin/table_functions.js' />"></script>
</body>
</html>
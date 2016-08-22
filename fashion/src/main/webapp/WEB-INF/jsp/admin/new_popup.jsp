<%@ page language="java" contentType="text/html; charset=utf-8" 
	pageEncoding="utf-8"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<%@ taglib prefix="spring" uri="http://www.springframework.org/tags" %>
<div id ="pop" hidden="true">
	<div class="DTED_Lightbox_Background" style="opacity: 1;"></div>
	<div class="DTED DTED_Lightbox_Wrapper" >
		<div class="DTED_Lightbox_Container">
			<div class="DTED_Lightbox_Content_Wrapper">
				<div class="DTED_Lightbox_Content" style="height: auto;">
					<div class="DTE DTE_Action_Edit">
						<div data-dte-e="head" class="DTE_Header">
							<div class="DTE_Header_Content">Thêm sản phẩm mới</div>
						</div>
						<div data-dte-e="processing" class="DTE_Processing_Indicator"></div>
						<div data-dte-e="body" class="DTE_Body">
							<div data-dte-e="body_content" class="DTE_Body_Content"
								style="max-height: 549px;">
								<form:form data-dte-e="form" method="post" action="submitP" id="proFrom" commandName="product" class="" style="display: block;"  enctype="multipart/form-data">
									<div data-dte-e="form_content" class="DTE_Form_Content" >
										<div class="DTE_Field">
											<fieldset>
	      										<legend style="color:blue;font-weight:bold;">Thông tin chung</legend>
	      										
	      										<table style="border-collapse:separate; border-spacing:1em; width: 100%">
	         										<tr>
														<td>
															<form:label path="code" data-dte-e="label" class="DTE_Label">Mã sản phẩm  </form:label>
														</td>
														<td>
															<form:input path="code"/>
														</td>
													</tr>
													<tr>
														<td>
															<form:label path="name" data-dte-e="label" class="DTE_Label" >Tên sản phẩm  </form:label>
														</td>
														<td>
															<form:input path="name"/>
														</td>
													</tr>
													<tr>
														<td>
															<form:label path="gender" data-dte-e="label" class="DTE_Label" >Giới tính  </form:label>
														</td>
														<td>
															<form:select path="gender">
																<form:option value="1">Nam</form:option>
																<form:option value="0">Nữ</form:option>
																<form:option value="2">Both</form:option>
															</form:select>
														</td>
													</tr>
													<tr>
														<td>
															<label data-dte-e="label" class="DTE_Label" >Loại sản phẩm  </label>
														</td>
														<td>
															<select id="typeOfProduct">
																<option value="1">Underwear</option>
															</select>
														</td>
													</tr>
													<tr>
														<td>
															<form:label path="name" data-dte-e="label" class="DTE_Label" >Category  </form:label>
														</td>
														<td>
															<form:select path="underwear.category">
																<form:option value="2">Áo</form:option>
																<form:option value="1">Quần</form:option>
																<form:option value="0">Bộ</form:option>
																<form:option value=""></form:option>
															</form:select>
														</td>
													</tr>
													<tr>
														<td>
															<form:label path="description"  class="DTE_Label" >Giới thiệu  </form:label>
														</td>
														<td>
															<form:textarea path="description" />
														</td>
													</tr>
												</table>
											</fieldset>
										</div>
										
										<!-- giá -->
										<div class="DTE_Field">
											<fieldset>
	      										<legend style="color:blue;font-weight:bold;">Giá</legend>
	      										
	      										<table style="border-collapse:separate; border-spacing:1em; width: 100%">
	         										<tr>
														<td>
															<form:label path="price" data-dte-e="label" class="DTE_Label" >Giá gốc  </form:label>
														</td>
														<td>
															<form:input path="price"/>
														</td>
													</tr>
													<tr>
														<td>
															<form:label path="saleoffprice" data-dte-e="label" class="DTE_Label" >Giá khuyến mại  </form:label>
														</td>
														<td>
															<form:input path="saleoffprice" />
														</td>
													</tr>
												</table>
											</fieldset>
										</div>
										<div class="DTE_Field">
											<fieldset>
												<legend style="color:blue;font-weight:bold;">Màu sắc</legend>
												<table style="border-collapse:separate; border-spacing:1em; width: 100%">
													<tr>
														<td><form:label path="colors[0].urlColor">Màu  </form:label></td>
														<td><form:input path="colors[0].urlColor" type="hidden"/>
															<input class="colorImgs0" name="colorImgs" type="file"/>
														</td>
														<td><img src="" type="hidden"/></td>
													</tr>
													<tr>
														<table  style="border-collapse:separate; border-spacing:1em; width: 100%">
															<tr>
																<td><form:label data-dte-e="label" class="DTE_Label" path="">Kích thước </form:label></td>
																<td><form:label data-dte-e="label" class="DTE_Label" path="">Số lượng </form:label></td>
																<td><form:label data-dte-e="label" class="DTE_Label" path="">Trạng thái </form:label></td>
															</tr>
															<tr>
																<td>
																	<form:select path="colors[0].sizes[0].sizeValue">
																		<form:option value="S">S</form:option>
																		<form:option value="M">M</form:option>
																		<form:option value="XL">XL</form:option>
																		<form:option value="XXL">XXL</form:option>
																	</form:select>
																</td>
																<td>
																	<form:input path="colors[0].sizes[0].quantity"/>
																</td>
																<td>
																	<form:select path="status">
																		<form:option value="1">Có hàng</form:option>
																		<form:option value="0">Sắp có</form:option>
																		<form:option value="-1">Hết hàng</form:option>
																	</form:select>
																</td>
															</tr>
														</table>
													</tr>
													<tr>
														<table style="border-collapse:separate; border-spacing:1em;width: 100%" >
															<tr>
																<td><form:label data-dte-e="label" class="DTE_Label" path="colors[0].images[0].urlImage">Ảnh</form:label></td>
																<td><form:input path="colors[0].images[0].urlImage" type="hidden"/>
																	<input class="imageImgs0" name="imageImgs" type="file"/>
																</td>
																<td><img alt="" id="imageImg" src="" type="hidden"></td>
															</tr>
														</table>
													</tr>
												</table>
											</fieldset>
										</div>
										<div>
										
										</div>
										
									</div>
								</form:form>
							</div>
						</div>
						<div data-dte-e="foot" class="DTE_Footer">
							<div data-dte-e="form_buttons" class="DTE_Form_Buttons">
								<button id="saveBtn" class="btn" tabindex="0">Hoàn Tất</button>
							</div>
						</div>
					</div>
					<div class="DTED_Lightbox_Close"></div>
				</div>
			</div>
		</div>
	</div>
</div>
<script src="<c:url value='/resources/js/admin/jquery-1.11.1.js' />"></script>
<script type="text/javascript" src="<c:url value='/resources/js/admin/popup_script.js' />"></script>

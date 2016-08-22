<%@ page language="java" contentType="text/html; charset=utf-8" 
	pageEncoding="utf-8"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<%@ taglib prefix="spring" uri="http://www.springframework.org/tags" %>
<div id ="pop" hidden="true">
	<div class="DTED_Lightbox_Background" style="opacity: 1;">
		<div></div>
	</div>
	<div class="DTED DTED_Lightbox_Wrapper" style="opacity: 1; top: 0px;">
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
								style="max-height: 749px;">
								<div data-dte-e="form_info" class="DTE_Form_Info" style="display: none;"></div>
								<form:form data-dte-e="form" method="post" action="submitP" id="proFrom" commandName="product" class="" style="display: block;"  enctype="multipart/form-data">
									<div data-dte-e="form_content" class="DTE_Form_Content">
										<div class="DTE_Field DTE_Field_Type_text DTE_Field_Name_signin-username ">
											<form:label path="code" data-dte-e="label" class="DTE_Label">
												Mã sản phẩm:
												<div data-dte-e="msg-label" class="DTE_Label_Info"></div>
											</form:label>
											<div data-dte-e="input" class="DTE_Field_Input">
												<div data-dte-e="input-control" class="DTE_Field_InputControl" style="display: block;">
													<form:input path="code" id="DTE_Field_signin-username" />
												</div>
												<div data-dte-e="multi-value" class="multi-value" style="display: none;">
													Multiple values
													<span data-dte-e="multi-info" class="multi-info" style="display: none;">
														The selected items contain different values for this input. To
														edit and set all items for this input to the same value,
														click or tap here, otherwise they will retain their
														individual values.
													</span>
												</div>
												<div data-dte-e="msg-multi" class="multi-restore">Undo changes</div>
												<div data-dte-e="msg-error" class="DTE_Field_Error"></div>
												<div data-dte-e="msg-message" class="DTE_Field_Message"></div>
												<div data-dte-e="msg-info" class="DTE_Field_Info"></div>
											</div>
										</div>
										<div class="DTE_Field DTE_Field_Type_password DTE_Field_Name_signin-password ">
											<form:label path="name" data-dte-e="label" class="DTE_Label" >
												Tên sản phẩm:
												<div data-dte-e="msg-label" class="DTE_Label_Info"></div>
											</form:label>
											<div data-dte-e="input" class="DTE_Field_Input">
												<div data-dte-e="input-control" class="DTE_Field_InputControl" style="display: block;">
													<form:input path="name" id="DTE_Field_signin-password" type="text"/>
												</div>
												<div data-dte-e="multi-value" class="multi-value" style="display: none;">
													Multiple values
													<span data-dte-e="multi-info" class="multi-info" style="display: none;">
														The	selected items contain different values for this input. To
														edit and set all items for this input to the same value,
														click or tap here, otherwise they will retain their
														individual values.</span>
												</div>
												<div data-dte-e="msg-multi" class="multi-restore">Undo
													changes</div>
												<div data-dte-e="msg-error" class="DTE_Field_Error"></div>
												<div data-dte-e="msg-message" class="DTE_Field_Message"></div>
												<div data-dte-e="msg-info" class="DTE_Field_Info">
												</div>
											</div>
										</div>
										<div class="DTE_Field DTE_Field_Type_title DTE_Field_Name_new-password " style="display: block;">
											<form:label path="price" data-dte-e="label" class="DTE_Label" >
												Giá:
												<div data-dte-e="msg-label" class="DTE_Label_Info"></div>
											</form:label>
											<div data-dte-e="input" class="DTE_Field_Input">
												<div data-dte-e="input-control" class="DTE_Field_InputControl" style="display: block;">
													<form:input path="price"/>
												</div>
												<div data-dte-e="multi-value" class="multi-value" style="display: none;">
													Multiple values
													<span data-dte-e="multi-info" class="multi-info" style="display: none;">
														The selected items contain different values for this input. To
														edit and set all items for this input to the same value,
														click or tap here, otherwise they will retain their
														individual values.</span>
												</div>
												<div data-dte-e="msg-multi" class="multi-restore">Undo
													changes</div>
												<div data-dte-e="msg-error" class="DTE_Field_Error"></div>
												<div data-dte-e="msg-message" class="DTE_Field_Message"></div>
												<div data-dte-e="msg-info" class="DTE_Field_Info"></div>
											</div>
										</div>
										<div class="DTE_Field DTE_Field_Type_text DTE_Field_Name_reset-username " style="display: block;">
											<form:label path="saleoffprice" data-dte-e="label" class="DTE_Label" >
												Giá khuyến mại:
												<div data-dte-e="msg-label" class="DTE_Label_Info"></div>
											</form:label>
											<div data-dte-e="input" class="DTE_Field_Input">
												<div data-dte-e="input-control" class="DTE_Field_InputControl" style="display: block;">
													<form:input path="saleoffprice" />
												</div>
												<div data-dte-e="multi-value" class="multi-value" style="display: none;">
													Multiple values
													<span data-dte-e="multi-info" class="multi-info" style="display: none;">
														The selected items contain different values for this input. To
														edit and set all items for this input to the same value,
														click or tap here, otherwise they will retain their
														individual values.</span>
												</div>
												<div data-dte-e="msg-multi" class="multi-restore">Undo changes</div>
												<div data-dte-e="msg-error" class="DTE_Field_Error"></div>
												<div data-dte-e="msg-message" class="DTE_Field_Message"></div>
												<div data-dte-e="msg-info" class="DTE_Field_Info">
												</div>
											</div>
										</div>
										
										<div class="DTE_Field DTE_Field_Type_text DTE_Field_Name_register-username ">
											<form:label data-dte-e="label" class="DTE_Label" path="status">
												Trạng Thái:
												<div data-dte-e="msg-label" class="DTE_Label_Info"></div>
											</form:label>
											<div data-dte-e="input" class="DTE_Field_Input">
												<div data-dte-e="input-control" class="DTE_Field_InputControl" style="display: block;">
													<form:select path="status">
														<form:option value="1">Có hàng</form:option>
														<form:option value="0">Sắp có</form:option>
														<form:option value="-1">Hết hàng</form:option>
													</form:select>
												</div>
												<div data-dte-e="multi-value" class="multi-value" style="display: none;">
													Multiple values
													<span data-dte-e="multi-info"
														class="multi-info" style="display: none;">The
														selected items contain different values for this input. To
														edit and set all items for this input to the same value,
														click or tap here, otherwise they will retain their
														individual values.</span>
												</div>
												<div data-dte-e="msg-multi" class="multi-restore">Undo
													changes</div>
												<div data-dte-e="msg-error" class="DTE_Field_Error"></div>
												<div data-dte-e="msg-message" class="DTE_Field_Message"></div>
												<div data-dte-e="msg-info" class="DTE_Field_Info"></div>
											</div>
										</div>
										<div class="DTE_Field DTE_Field_Type_text DTE_Field_Name_register-email ">
											<form:label data-dte-e="label" class="DTE_Label" path="gender">
												Giới tính:
												<div data-dte-e="msg-label" class="DTE_Label_Info"></div>
											</form:label>
											<div data-dte-e="input" class="DTE_Field_Input">
												<div data-dte-e="input-control" class="DTE_Field_InputControl" style="display: block;">
													<form:select path="gender">
														<form:option value="1">Nam</form:option>
														<form:option value="0">Nữ</form:option>
														<form:option value="2">Both</form:option>
													</form:select>
												</div>
												<div data-dte-e="multi-value" class="multi-value" style="display: none;">
													Multiple values
													<span data-dte-e="multi-info"
														class="multi-info" style="display: none;">The
														selected items contain different values for this input. To
														edit and set all items for this input to the same value,
														click or tap here, otherwise they will retain their
														individual values.</span>
												</div>
												<div data-dte-e="msg-multi" class="multi-restore">Undo changes</div>
												<div data-dte-e="msg-error" class="DTE_Field_Error"></div>
												<div data-dte-e="msg-message" class="DTE_Field_Message"></div>
												<div data-dte-e="msg-info" class="DTE_Field_Info"></div>
											</div>
										</div>
										
										<div class="DTE_Field DTE_Field_Type_text DTE_Field_Name_register-email ">
											<form:label data-dte-e="label" class="DTE_Label" path="colors[0].urlColor">
												Màu sắc:
												<div data-dte-e="msg-label" class="DTE_Label_Info"></div>
											</form:label>
											<div data-dte-e="input" class="DTE_Field_Input">
												<div data-dte-e="input-control" class="DTE_Field_InputControl" style="display: block;">
													<form:input path="colors[0].urlColor" type="hidden"/>
													<input class="colorImgs0" name="colorImgs" type="file"/>
												</div>
												<div data-dte-e="multi-value" class="multi-value" style="display: none;">
													Multiple values
													<span data-dte-e="multi-info"
														class="multi-info" style="display: none;">The
														selected items contain different values for this input. To
														edit and set all items for this input to the same value,
														click or tap here, otherwise they will retain their
														individual values.</span>
												</div>
												<div data-dte-e="msg-multi" class="multi-restore">Undo changes</div>
												<div data-dte-e="msg-error" class="DTE_Field_Error"></div>
												<div data-dte-e="msg-message" class="DTE_Field_Message"></div>
												<div data-dte-e="msg-info" class="DTE_Field_Info"></div>
											</div>
											<img alt="" id="colorImg" src="">
										</div>
										
										
										<div class="DTE_Field DTE_Field_Type_text DTE_Field_Name_register-email ">
											<form:label data-dte-e="label" class="DTE_Label" path="colors[0].sizes[0].sizeValue">
												Kích thước:
												<div data-dte-e="msg-label" class="DTE_Label_Info"></div>
											</form:label>
											<div data-dte-e="input" class="DTE_Field_Input">
												<div data-dte-e="input-control" class="DTE_Field_InputControl" style="display: block;">
													<form:select path="colors[0].sizes[0].sizeValue">
														<form:option value="S">S</form:option>
														<form:option value="M">M</form:option>
														<form:option value="XL">XL</form:option>
														<form:option value="XXL">XXL</form:option>
													</form:select>
												</div>
												<div data-dte-e="multi-value" class="multi-value" style="display: none;">
													Multiple values
													<span data-dte-e="multi-info"
														class="multi-info" style="display: none;">The
														selected items contain different values for this input. To
														edit and set all items for this input to the same value,
														click or tap here, otherwise they will retain their
														individual values.</span>
												</div>
												<div data-dte-e="msg-multi" class="multi-restore">Undo changes</div>
												<div data-dte-e="msg-error" class="DTE_Field_Error"></div>
												<div data-dte-e="msg-message" class="DTE_Field_Message"></div>
												<div data-dte-e="msg-info" class="DTE_Field_Info"></div>
											</div>
										</div>
										
										<div class="DTE_Field DTE_Field_Type_text DTE_Field_Name_register-email ">
											<form:label data-dte-e="label" class="DTE_Label" path="gender">
												Số lượng (ứng với màu sắc và kích thước trên):
												<div data-dte-e="msg-label" class="DTE_Label_Info"></div>
											</form:label>
											<div data-dte-e="input" class="DTE_Field_Input">
												<div data-dte-e="input-control" class="DTE_Field_InputControl" style="display: block;">
													<form:input path="colors[0].sizes[0].quantity"/>
												</div>
												<div data-dte-e="multi-value" class="multi-value" style="display: none;">
													Multiple values
													<span data-dte-e="multi-info"
														class="multi-info" style="display: none;">The
														selected items contain different values for this input. To
														edit and set all items for this input to the same value,
														click or tap here, otherwise they will retain their
														individual values.</span>
												</div>
												<div data-dte-e="msg-multi" class="multi-restore">Undo changes</div>
												<div data-dte-e="msg-error" class="DTE_Field_Error"></div>
												<div data-dte-e="msg-message" class="DTE_Field_Message"></div>
												<div data-dte-e="msg-info" class="DTE_Field_Info"></div>
											</div>
										</div>
										
										<div class="DTE_Field DTE_Field_Type_text DTE_Field_Name_register-email ">
											<form:label data-dte-e="label" class="DTE_Label" path="colors[0].images[0].urlImage">
												Ảnh:
												<div data-dte-e="msg-label" class="DTE_Label_Info"></div>
											</form:label>
											<div data-dte-e="input" class="DTE_Field_Input">
												<div data-dte-e="input-control" class="DTE_Field_InputControl" style="display: block;">
													<form:input path="colors[0].images[0].urlImage" type="hidden"/>
													<input class="imageImgs0" name="imageImgs" type="file"/>
												</div>
												<div data-dte-e="multi-value" class="multi-value" style="display: none;">
													Multiple values
													<span data-dte-e="multi-info"
														class="multi-info" style="display: none;">The
														selected items contain different values for this input. To
														edit and set all items for this input to the same value,
														click or tap here, otherwise they will retain their
														individual values.</span>
												</div>
												<div data-dte-e="msg-multi" class="multi-restore">Undo changes</div>
												<div data-dte-e="msg-error" class="DTE_Field_Error"></div>
												<div data-dte-e="msg-message" class="DTE_Field_Message"></div>
												<div data-dte-e="msg-info" class="DTE_Field_Info"></div>
											</div>
											<img alt="" id="imageImg" src="">
										</div>
										<div class="DTE_Field DTE_Field_Type_text DTE_Field_Name_register-email ">
											<form:label data-dte-e="label" class="DTE_Label" path="">
												Type:
												<div data-dte-e="msg-label" class="DTE_Label_Info"></div>
											</form:label>
											<div data-dte-e="input" class="DTE_Field_Input">
												<div data-dte-e="input-control" class="DTE_Field_InputControl" style="display: block;">
													<form:select path="" id="typeOfProduct">
														<form:option value="1">Underwear</form:option>
													</form:select>
												</div>
												<div data-dte-e="multi-value" class="multi-value" style="display: none;">
													Multiple values
													<span data-dte-e="multi-info"
														class="multi-info" style="display: none;">The
														selected items contain different values for this input. To
														edit and set all items for this input to the same value,
														click or tap here, otherwise they will retain their
														individual values.</span>
												</div>
												<div data-dte-e="msg-multi" class="multi-restore">Undo changes</div>
												<div data-dte-e="msg-error" class="DTE_Field_Error"></div>
												<div data-dte-e="msg-message" class="DTE_Field_Message"></div>
												<div data-dte-e="msg-info" class="DTE_Field_Info"></div>
											</div>
										</div>
										<div class="DTE_Field DTE_Field_Type_text DTE_Field_Name_register-email ">
											<form:label data-dte-e="label" class="DTE_Label" path="underwear.category">
												Category:
												<div data-dte-e="msg-label" class="DTE_Label_Info"></div>
											</form:label>
											<div data-dte-e="input" class="DTE_Field_Input">
												<div data-dte-e="input-control" class="DTE_Field_InputControl" style="display: block;">
													<form:select path="underwear.category">
														<form:option value="2">Áo</form:option>
														<form:option value="1">Quần</form:option>
														<form:option value="0">Bộ</form:option>
														<form:option value=""></form:option>
													</form:select>
												</div>
												<div data-dte-e="multi-value" class="multi-value" style="display: none;">
													Multiple values
													<span data-dte-e="multi-info"
														class="multi-info" style="display: none;">The
														selected items contain different values for this input. To
														edit and set all items for this input to the same value,
														click or tap here, otherwise they will retain their
														individual values.</span>
												</div>
												<div data-dte-e="msg-multi" class="multi-restore">Undo changes</div>
												<div data-dte-e="msg-error" class="DTE_Field_Error"></div>
												<div data-dte-e="msg-message" class="DTE_Field_Message"></div>
												<div data-dte-e="msg-info" class="DTE_Field_Info"></div>
											</div>
										</div>
										<div class="DTE_Field DTE_Field_Type_text DTE_Field_Name_reset-username " style="display: block;">
											<form:label path="description" data-dte-e="label" class="DTE_Label" >
												Giới thiệu:
												<div data-dte-e="msg-label" class="DTE_Label_Info"></div>
											</form:label>
											<div data-dte-e="input" class="DTE_Field_Input">
												<div data-dte-e="input-control" class="DTE_Field_InputControl" style="display: block;">
													<form:textarea path="description" />
												</div>
												<div data-dte-e="multi-value" class="multi-value" style="display: none;">
													Multiple values
													<span data-dte-e="multi-info" class="multi-info" style="display: none;">
														The selected items contain different values for this input. To
														edit and set all items for this input to the same value,
														click or tap here, otherwise they will retain their
														individual values.</span>
												</div>
												<div data-dte-e="msg-multi" class="multi-restore">Undo changes</div>
												<div data-dte-e="msg-error" class="DTE_Field_Error"></div>
												<div data-dte-e="msg-message" class="DTE_Field_Message"></div>
												<div data-dte-e="msg-info" class="DTE_Field_Info">
												</div>
											</div>
										</div>
									</div>
								</form:form>
							</div>
						</div>
						<div data-dte-e="foot" class="DTE_Footer">
							<div class="DTE_Footer_Content"></div>
							<div data-dte-e="form_error" class="DTE_Form_Error" style="display: none;"></div>
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

//==============================Menu=============================
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}
function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
//===================================================================
function swap(td_name,image)
{
	document.getElementById(td_name).style.background=image;
}

function bgoff(name,image)
{
	document.getElementById(name).style.background=image;
}
//==============================End Manu=============================
function checkAllGroupItem(groupID,obj){    
	var objValue =  obj.value;
	if(!isNaN(groupID)){
		if(objValue != "0"){
			for(var i=0;i<document.aspnetForm.elements.length;i++){
				if((document.aspnetForm.elements[i].type == "checkbox") && (document.aspnetForm.elements[i].id == groupID)){
					document.aspnetForm.elements[i].checked = true;
				}
			}
			obj.value = "0";
		}
		else{
			for(var i=0;i<document.aspnetForm.elements.length;i++){
				if((document.aspnetForm.elements[i].type == "checkbox") && (document.aspnetForm.elements[i].id == groupID)){
					document.aspnetForm.elements[i].checked = false;
				}
			}
			obj.value = "1";
		}
	}
}
//---------------------------------------------------------------	
function checkDeleteAll(aspnetForm){
    if(aspnetForm.chb_DeleteAll.checked == true){
	    for(var i=0;i<aspnetForm.elements.length;i++){
			    if((aspnetForm.elements[i].type == "checkbox") && (aspnetForm.elements[i].value == "delete")){
				    aspnetForm.elements[i].checked= true;
			    }
	    }
    }
    else{
	    for(var i=0;i<aspnetForm.elements.length;i++){
			    if((aspnetForm.elements[i].type == "checkbox") && (aspnetForm.elements[i].value == "delete")){
				    aspnetForm.elements[i].checked= false;
			    }
	    }
    }
}
//---------------------------------------------------------------
function checkDelete(aspnetForm)
{
	var check = false;
	for(var i=0;i<aspnetForm.elements.length;i++){
		if((aspnetForm.elements[i].type == "checkbox") && (aspnetForm.elements[i].checked == true) && (aspnetForm.elements[i].value == "delete")){
			check = true;
		}
	}
	
	if(!check){
		alert('Bạn phải chọn ít nhất một bản ghi cần xóa');
		return false;
	}
	answer = confirm('Bạn có muốn xóa không?');
	if(!answer){	    
		return false;
	}
	return true;
}
//---------------------------------------------------------------
function checkAddNew(aspnetForm)
{
	var check = false;
	if (aspnetForm.GroupName.value=='')
    {
        alert('Tên nhóm không thể trống!');
        aspnetForm.GroupName.focus();
        return false;
    }
	for(var i=0;i<aspnetForm.elements.length;i++){
		if((aspnetForm.elements[i].type == "checkbox") && (aspnetForm.elements[i].checked == true) && (aspnetForm.elements[i].value == "check")){
			check = true;
		}
	}
	
	if(!check){
		alert('Bạn phải chọn ít nhất một chức năng cho nhóm!');
		return false;
	}
	return true;
}
//---------------------------------------------------------------
function openwindow1(url,width,height)
{
	var top=(screen.height - height)/2;
	var left=(screen.width - width)/2;
	
	window.open(url,"","toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no,left=" + left + ", top=" + top + ", width=" + width + ", height=" + height)
}
//-------------------------Cat Order-----------------------------
function checkSubmit(frm){
			dohoi(frm,frm.SOrder);
			return true;
		}
function changeOrderCat(Cat_ID)
{    
	if(!isNaN(Cat_ID)){	
		document.aspnetForm.SCat_Id.value=Cat_ID;
		document.aspnetForm.submit();
	}
}
function moveOptionUp(obj)
{		
	var selectedCount=0;
	for (i=0; i<obj.options.length; i++) 
	{
		if (obj.options[i].selected) 
		{
			selectedCount++;
		}
	}
	if (selectedCount > 1) 
	{
		return;
	}	
	var i = obj.selectedIndex;
	if (i == 0) 
	{
		return;
	}
	swapOptions(obj,i,i-1);
	obj.options[i-1].selected = true;
}

function moveOptionDown(obj) 
{
	var selectedCount=0;
	for (i=0; i<obj.options.length; i++) 
	{
		if (obj.options[i].selected) 
		{
			selectedCount++;
		}
	}
	if (selectedCount > 1) 
	{
		return;
	}	
	var i = obj.selectedIndex;
	if (i == (obj.options.length-1)) 
	{
		return;
	}
	swapOptions(obj,i,i+1);
	obj.options[i+1].selected = true;
}
function swapOptions(obj,i,z) 
{

	var o = obj.options;
	var i_selected = o[i].selected;
	var z_selected = o[z].selected;

	var temp = new Option(o[i].text, o[i].value, o[i].defaultSelected, o[i].selected);
	var temp2= new Option(o[z].text, o[z].value, o[z].defaultSelected, o[z].selected);
	o[i] = temp2;
	o[z] = temp;
	o[i].selected = z_selected;
	o[z].selected = i_selected;
}
function dohoi(frm,obj)
{	
	var k;
	var tx;
	tx = "" ;
	
	for (k=0; k<obj.options.length; ++k)
	{						
		tx = tx  + obj.options[k].value +  "$"; 
	}
	
	frm.hiddenOrder.value = tx;
}
//-----------------------End Cat Order---------------------------
//---------------------------------------------------------------
var isIE = (document.getElementById && document.all);
function openImage(vLink, vHeight, vWidth)
{
	var sLink = (typeof(vLink.href) == 'undefined') ? vLink : vLink.href;
	if (sLink == '')
	{
		return false;
	}
	winDef = 'status=no,resizable=no,scrollbars=no,toolbar=no,location=no,fullscreen=no,titlebar=yes,height='.concat(vHeight).concat(',').concat('width=').concat(vWidth).concat(',');
	winDef = winDef.concat('top=').concat((screen.height - vHeight)/2).concat(',');
	winDef = winDef.concat('left=').concat((screen.width - vWidth)/2);
	newwin = open('', '_blank', winDef);
	newwin.document.writeln('<title>Xem ảnh</title>');
	newwin.document.writeln('<body topmargin="0" leftmargin="0" marginheight="0" marginwidth="0">');
	newwin.document.writeln('<a href="" onClick="window.close(); return false;"><img src="', sLink, '" alt="', (isIE) ? '' : '', '" border=0 title=\'Đóng lại\'></a>');
	newwin.document.writeln('</body>');
	if (typeof(vLink.href) != 'undefined')
	{
		return false;
	}
}
//---------------------------------------------------------------
function openwindow(url,width,height)
{
	var top=(screen.height - height)/2;
	var left=(screen.width - width)/2;
	var pop;
	if((pop!=null)&&(!pop.closed)){
		pop.close();
	}
	pop = window.open(url,"","toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=no, copyhistory=no,left=" + left + ", top=" + top + ", width=" + width + ", height=" + height)
}
//---------------------------------------------------------------
//==========================Popup Image==========================
function gen_Image(w,Thumb_W,Photo){
var szHTML, tf, it;
	it = '<img src="'+ Photo + '_T.jpg' +'" border="0">';
	szHTML='';
	szHTML+='<table cellSpacing=0 cellPadding=3 width=1 border=0>';
	szHTML+='<tr><td>';
	szHTML+= it;
	szHTML+='</td></tr>';
	szHTML+='<tr><td>';
	szHTML+='<input type="checkbox" value="Yes" name="CheckLeadImage" checked />&nbsp;<font class="ListContent">Hiển thị ảnh trong nội dung tin</font>';
	szHTML+='</td></tr>';
	szHTML+='</table>';
	
	return szHTML;
}
//===============================================
function removeLeadImage(){
		divImg.innerHTML = '';		
		document.aspnetForm.LeadImage.value = '';
		spanDeleteIcon.innerHTML = '';
}
//===============================================
function do_InsertImgEditor(w,Thumb_W,Photo, imageID)
{
	divImg.innerHTML = gen_Image(w,Thumb_W,Photo);
	document.aspnetForm.LeadImage.value = imageID;
	spanDeleteIcon.innerHTML = '<img style="cursor:hand" onclick=\"JavaScript:removeLeadImage()\" src=\"/Images/Admin/delete.gif\" border=\"0\" alt="Xóa ảnh">';
}	
//========================End Popup Image========================
//=======================Check Submit News=======================
function checkSubmitToAddNews(aspnetForm){
    //Tiêu đề tin
    if (aspnetForm.ctl00$ContentPlaceHolder1$txtSubject.value=='')
    {
        alert('Bạn phải nhập tiêu đề tin tức');
        aspnetForm.ctl00$ContentPlaceHolder1$txtSubject.focus();
        return false;
    }
    //Trạng thái
    if (aspnetForm.ctl00$ContentPlaceHolder1$DDL_Status.value=='')
    {
        alert('Bạn phải chọn trạng thái của tin');
        aspnetForm.ctl00$ContentPlaceHolder1$DDL_Status.focus();
        return false;
    }
    //Ngôn ngữ
    if (aspnetForm.ctl00$ContentPlaceHolder1$DDL_Language.value=='')
    {
        alert('Bạn phải chọn ngôn ngữ');
        aspnetForm.ctl00$ContentPlaceHolder1$DDL_Language.focus();
        return false;
    }
    //Danh mục tin tức
    if (aspnetForm.SCat_Id.value=='')
    {
        alert('Bạn phải chọn danh mục tin tức');
        aspnetForm.SCat_Id.focus();
        return false;
    }    
    //Tin liên quan
	var obj = document.getElementById("SRelateNews");
	var strNews_ID = ""
	for (var optionCounter = 0; optionCounter < obj.length; optionCounter++){
		if(strNews_ID!=""){strNews_ID = strNews_ID + ",";}
		strNews_ID = strNews_ID + obj.options[optionCounter].value;
	}	
	aspnetForm.hiddenRelateNewsID.value = strNews_ID;
	//Kết thúc
	return true;
}
//An hien tin lien quan
function Relate(){
    if (aspnetForm.ctl00$ContentPlaceHolder1$DDL_Language.value=='')
    {
        alert('Bạn phải chọn ngôn ngữ');
        aspnetForm.ctl00$ContentPlaceHolder1$DDL_Language.focus();
        return false;
    }
	if(document.all.divRelate.style.display == "none"){
		document.all.divRelate.style.display = "block";		
	}
	else{
		document.all.divRelate.style.display = "none";
	}
}
function displayRelateNewsIfExits()
{
    if(document.all.divRelate.style.display == "none"){
		document.all.divRelate.style.display = "block";
		}
}
function change_editor_cat(EditorCat_ID){
	var obj = document.getElementById("pEditorCatToRelate");
	var objHTTP = new ActiveXObject("Microsoft.XMLHTTP");
	var szURL = "Editor_Xml_Relate_News.aspx";
	var szHttpMethod = "POST";
	var szRequest = EditorCat_ID;
	objHTTP.Open(szHttpMethod, szURL, false);
	objHTTP.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
	objHTTP.Send(szRequest);
	var szReply = objHTTP.ResponseText;
	if (szReply!=''){
		obj.innerHTML = szReply;
	}
	objHTTP = null;
	szRequest = null;
	szReply	= null;
	return true;
}
/*Them moi tin lien quan*/
function AddNews(){
	var obj = document.getElementById("SRelateNewsSource");
	var obj1 = document.getElementById("SRelateNews");
	var optionCounter;
	var strText = "";
	var intID = "";
	var blAdd = true;
		
	if(obj!=null){
		for (optionCounter = 0; optionCounter < obj.length; optionCounter++){
			if(obj.options[optionCounter].value == obj.value){
				strText = obj.options[optionCounter].text;
				intID = obj.options[optionCounter].value;
			}
		}
		if(strText!="" && !isNaN(intID)){
			if(obj1!=null){
				for (optionCounter = 0; optionCounter < obj1.length; optionCounter++){
					if(obj1.options[optionCounter].value == intID){
						blAdd = false;
					}
				}
				if(blAdd){
					var myNewOption = new Option(strText,intID);
					obj1.options[obj1.length] = myNewOption;
				}
				else{
					alert("Bạn đã thêm tin này rồi.");
				}
			}
		}
	}
}
/*Xoa bo tin lien quan*/
function RemoveNews(){
	var obj = document.getElementById("SRelateNews");
	var blRemove = true;
		
	if(obj!=null){
		if(!isNaN(obj.value) && obj.value!=""){
			for (optionCounter = 0; optionCounter < obj.length; optionCounter++){
				if(obj.options[optionCounter].value == obj.value){
					obj.options[optionCounter] = null;
				}
			}
			
		}
	}
}
//=====================End Check Submit News=====================
function EmailToFriend(strOpen)
    {
        window.open(strOpen, "Info", "status=1, width=660,height=550,toolbar=no,menubar=no,location=no");
    }
function displayStatus(strStatus){
	window.status = strStatus;
}

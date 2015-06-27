var iReadStep=0, iDelay=20;
var sLoDID=',', sDate='';

function getNodeValue(o){	
	try	{
		return o.item(0).firstChild.nodeValue;
	}
	catch(err) {
		return '';
	}
}

function displayid(id,add){
	if (typeof(add)=='undefined') add=true;
	if (sLoDID.indexOf(id)<=0){
		if (add) sLoDID=sLoDID.concat(id).concat(',');		
		return true;
	}
	else{
		return false;
	}
}

function getimages(Id, FileName) {
	var number = new Number(Id);
	var hexId = Hexa(number);	
	return '/Files/Subject/'.concat(hexId.substring(0,2)).concat('/').concat(hexId.substring(2,4)).concat('/').concat(hexId.substring(4,6)).concat('/').concat(hexId.substring(6,8)).concat('/').concat(FileName);			
}

function RSSLink(sId)
{
	var strLink = '';
	var strRSS = 'RSS <img class="img-rss" src="/Images/rss.gif" alt="" />'
	if(PAGE_SITE == 0)
		strLink = '<a class="link-rss" href="/RSS/GL/';
	else if(PAGE_SITE == 1)
		strLink = '<a class="link-rss" href="/RSS/HN/';
	else if(PAGE_SITE == 2)
		strLink = '<a class="link-rss" href="/RSS/SG/';	
	switch (parseInt(sId)) 
	{
		case 18: 	strLink = strLink.concat('Xa-hoi.rss">').concat(strRSS).concat('</a>'); break;
		case 2: 	strLink = strLink.concat('The-gioi.rss">').concat(strRSS).concat('</a>'); break;
		case 3: 	strLink = strLink.concat('Kinh-doanh.rss">').concat(strRSS).concat('</a>'); break;
		case 51:	strLink = strLink.concat('Van-hoa.rss">').concat(strRSS).concat('</a>'); break;
		case 9:		strLink = strLink.concat('The-thao.rss">').concat(strRSS).concat('</a>'); break;
		case 47:	strLink = strLink.concat('Phap-luat.rss">').concat(strRSS).concat('</a>'); break;
		case 110:	strLink = strLink.concat('Doi-song.rss">').concat(strRSS).concat('</a>'); break;
		case 83:	strLink = strLink.concat('Khoa-hoc.rss">').concat(strRSS).concat('</a>'); break;
		case 89:	strLink = strLink.concat('Vi-tinh.rss">').concat(strRSS).concat('</a>'); break;
		case 38:	strLink = strLink.concat('Oto-Xe-may.rss">').concat(strRSS).concat('</a>'); break;
		case 109:	strLink = strLink.concat('Ban-doc-viet.rss">').concat(strRSS).concat('</a>'); break;
		case 127:	strLink = strLink.concat('Ban-doc-viet-Tam-su.rss">').concat(strRSS).concat('</a>'); break;		
		case 105:	strLink = strLink.concat('Cuoi.rss">').concat(strRSS).concat('</a>'); break;
		default: 	strLink = ''; break;
	}	
	return strLink;
}



function showtopstories() {
	var sTimeTS;
	var arItem = new Array();	
	var sLink = ''
	if(DOMESTIC_IP==0) {
		sLink = '/ListFile/Subject/'.concat(Right(Hexa(PAGE_SITE),2)).concat('/sd_ts.xml');
	}
	else {
		sLink = '/ListFile/Subject/'.concat(Right(Hexa(PAGE_SITE),2)).concat('/so_ts.xml');
	}	
	var iMaxTS = 4;
	AjaxRequest.get(
		{
		'url':sLink
		,'onSuccess':function(req){
			if (req.responseXML.getElementsByTagName('F').length>0){
				with(req.responseXML.getElementsByTagName('F').item(0)){
					sTimeTS = getNodeValue(getElementsByTagName('T'));					
				}
			}
			var iCount=0;
			for (var i=0;i<req.responseXML.getElementsByTagName('I').length;i++){
				with(req.responseXML.getElementsByTagName('I').item(i)){
					if (iCount<iMaxTS){
						var sTemp = getNodeValue(getElementsByTagName('I'));
						if (sTemp!='' && displayid(sTemp)){
							arItem[iCount] = new Array(19);
							arItem[iCount][0] = getNodeValue(getElementsByTagName('I'));
							arItem[iCount][1] = getNodeValue(getElementsByTagName('P')) + '/';
							arItem[iCount][2] = getNodeValue(getElementsByTagName('T'));
							arItem[iCount][3] = getNodeValue(getElementsByTagName('L'));
							arItem[iCount][4] = getNodeValue(getElementsByTagName('TI'));
							arItem[iCount][5] = getNodeValue(getElementsByTagName('TW'));
							arItem[iCount][6] = getNodeValue(getElementsByTagName('TH'));
							arItem[iCount][7] = getNodeValue(getElementsByTagName('SI'));
							arItem[iCount][8] = getNodeValue(getElementsByTagName('SW'));
							arItem[iCount][9] = getNodeValue(getElementsByTagName('SH'));
							arItem[iCount][10] = getNodeValue(getElementsByTagName('LI'));
							arItem[iCount][11] = getNodeValue(getElementsByTagName('LW'));
							arItem[iCount][12] = getNodeValue(getElementsByTagName('LH'));
							arItem[iCount][13] = getNodeValue(getElementsByTagName('HV'));
							arItem[iCount][14] = getNodeValue(getElementsByTagName('HI'));
							arItem[iCount][15] = getNodeValue(getElementsByTagName('HS'));
							arItem[iCount][16] = getNodeValue(getElementsByTagName('OI'));
							arItem[iCount][17] = getNodeValue(getElementsByTagName('OW'));
							arItem[iCount][18] = getNodeValue(getElementsByTagName('OH'));
							iCount++;
						}
					}
				}
			}			
			gmobj('top4').innerHTML=gettopstoriesitem(sTimeTS,arItem);
			iReadStep=2;
		}
		,'onError':function(req){
			gmobj('top4').innerHTML=req.statusText;
			iReadStep=2;
		}
		}
	)
}

function gettopstoriesitem(sTimeTS,arItem){	
	var i;
	var sHTML='';	
	dFormat(sTimeTS);			
	sHTML=sHTML.concat('<div class="hotnews-top fl">');
	sHTML=sHTML.concat('	<div class="fl"><img src="/Images/Background/hotnews-topleft.gif" alt="" class="alt" /></div>');
	sHTML=sHTML.concat('	<div class="hotnews-topright fl">&nbsp;</div>');
	sHTML=sHTML.concat('</div>');
	sHTML=sHTML.concat('<div class="hotnews-content fl">');
	sHTML=sHTML.concat('	<div class="hotnews-detail fl">');
	sHTML=sHTML.concat('<p>');
	if(arItem[0][4]!='') {
		sHTML=sHTML.concat('<a href="').concat(arItem[0][1]).concat('"><img class="img-topnews fl" src="').concat(getimages(arItem[0][0], arItem[0][4])).concat('" alt="" /></a>');		
	}
	sHTML = sHTML.concat('<a href="').concat(arItem[0][1]).concat('" class="link-topnews">').concat(arItem[0][2]).concat('</a>');
	sHTML=sHTML.concat(showMediaIcon(arItem[0][1], arItem[0][13], arItem[0][14], 3)).concat('</p>');
	sHTML=sHTML.concat('<p>').concat(arItem[0][3].replace(/class=Lead/ig,'class=Lead1')).concat('</p>');
	sHTML=sHTML.concat('	</div>');
	sHTML=sHTML.concat('</div>');
	sHTML=sHTML.concat('<div class="hotnews-bottom fl">');
	sHTML=sHTML.concat('	<div class="hbl he4 fl">&nbsp;</div>');
	sHTML=sHTML.concat('	<div class="hotnews-bottomright fl">&nbsp;</div>');
	sHTML=sHTML.concat('</div>');
	sHTML=sHTML.concat('<div class="t3 fl">');
	for (i=1;i<=arItem.length-1;i++){
		sHTML=sHTML.concat('	<div class="t3-content fl">');
		if(arItem[i][4]!='') {
			sHTML=sHTML.concat('<p><a href="').concat(arItem[i][1]).concat('"><img class="img-top3" src="').concat(getimages(arItem[i][0], arItem[i][4])).concat('.thumb150x0.ns.jpg" alt="" /></a></p>');
			sHTML=sHTML.concat('<p><a href="').concat(arItem[i][1]).concat('" class="link-title">').concat(arItem[i][2]).concat('</a>');
			sHTML=sHTML.concat(showMediaIcon(arItem[i][1], arItem[i][13], arItem[i][14], 3)).concat('</p>');
		}
		else {
			sHTML=sHTML.concat('<p><a href="').concat(arItem[i][1]).concat('" class="link-title">').concat(arItem[i][2]).concat('</a></p>');
			sHTML=sHTML.concat('<p>').concat(arItem[i][3].replace(/class=Lead/ig,'class=Lead1'));
			sHTML=sHTML.concat(showMediaIcon(arItem[i][1], arItem[i][13], arItem[i][14], 3)).concat('</p>');
		}
		sHTML=sHTML.concat('	</div>');
	}
	sHTML=sHTML.concat('</div>');	
	return sHTML;
}

function writeTopDate(){	
	if(gmobj("topnewsdate")&&sDate!=''){
		gmobj("topnewsdate").innerHTML = sDate;		
	}
	else {
		setTimeout(function(){writeTopDate();},iDelay);
	}
}

function showtoplistitem(){
	var sIdTD, sNameTN, sPathTN;
	var arItem = new Array();	
	var sLink = '';
	if(DOMESTIC_IP==0) {
		sLink = '/ListFile/Subject/'.concat(Right(Hexa(PAGE_SITE),2)).concat('/sd_tn.xml');
	}
	else {
		sLink = '/ListFile/Subject/'.concat(Right(Hexa(PAGE_SITE),2)).concat('/so_tn.xml');
	}	
	var iMaxTN = 10;
	AjaxRequest.get(
		{
		'url':sLink
		,'onSuccess':function(req){
			if (req.responseXML.getElementsByTagName('F').length>0){
				with(req.responseXML.getElementsByTagName('F').item(0)){
					sIdTN = getNodeValue(getElementsByTagName('I'));
					sNameTN = toUpper(getNodeValue(getElementsByTagName('N')));
					sPathTN = getNodeValue(getElementsByTagName('P'));
				}
			}
			var iCount=0;
			for (var i=0;i<req.responseXML.getElementsByTagName('I').length;i++){
				with(req.responseXML.getElementsByTagName('I').item(i)){
					if (iCount<iMaxTN){
						var sTemp = getNodeValue(getElementsByTagName('I'));
						if (sTemp!=''){
							arItem[iCount] = new Array(19);
							arItem[iCount][0] = getNodeValue(getElementsByTagName('I'));
							arItem[iCount][1] = getNodeValue(getElementsByTagName('P')) + '/';
							arItem[iCount][2] = getNodeValue(getElementsByTagName('T'));
							arItem[iCount][3] = getNodeValue(getElementsByTagName('L'));
							arItem[iCount][4] = getNodeValue(getElementsByTagName('TI'));
							arItem[iCount][5] = getNodeValue(getElementsByTagName('TW'));
							arItem[iCount][6] = getNodeValue(getElementsByTagName('TH'));
							arItem[iCount][7] = getNodeValue(getElementsByTagName('SI'));
							arItem[iCount][8] = getNodeValue(getElementsByTagName('SW'));
							arItem[iCount][9] = getNodeValue(getElementsByTagName('SH'));
							arItem[iCount][10] = getNodeValue(getElementsByTagName('LI'));
							arItem[iCount][11] = getNodeValue(getElementsByTagName('LW'));
							arItem[iCount][12] = getNodeValue(getElementsByTagName('LH'));
							arItem[iCount][13] = getNodeValue(getElementsByTagName('HV'));
							arItem[iCount][14] = getNodeValue(getElementsByTagName('HI'));
							arItem[iCount][15] = getNodeValue(getElementsByTagName('HS'));
							arItem[iCount][16] = getNodeValue(getElementsByTagName('OI'));
							arItem[iCount][17] = getNodeValue(getElementsByTagName('OW'));
							arItem[iCount][18] = getNodeValue(getElementsByTagName('OH'));
							iCount++;
						}
					}
				}
			}
			gmobj('toplist').innerHTML=gettoplistitem(sNameTN,sPathTN,arItem);			
		}
		,'onError':function(req){
			gmobj('toplist').innerHTML=req.statusText;			
		}
		}
	)
}

function gettoplistitem(sNameTN,sPathTN,arItem){		
	var sHTML='';	
	sHTML=sHTML.concat('<ul>');
	for (var i=0;i<=arItem.length-1;i++){
		sHTML=sHTML.concat('<li><a href="').concat(arItem[i][1]).concat('" class="link-toplist">').concat(arItem[i][2]).concat('</a>');
		if(arItem[i][13]>0){
			sHTML=sHTML.concat('&nbsp;<img src="/Images/video2.gif" alt="" />');
		}
		if(arItem[i][14]>0){
			sHTML=sHTML.concat('&nbsp;<img src="/Images/photo2.gif" alt="" />');
		}
		sHTML=sHTML.concat('</li>');
	}
	sHTML=sHTML.concat('</ul>');	
	return sHTML;	
}

function showhomefolderitem(sFolder){
	iReadStep = 2
	if (iReadStep<2) {	
		setTimeout(function(){showhomefolderitem(sFolder);},iDelay);
		return;
	}
	var sId, sName, sPath;
	var arItem = new Array();	
	var sLink = '';
	if(DOMESTIC_IP==0) {
		sLink = '/ListFile/Subject/'.concat(Right(Hexa(PAGE_SITE),2)).concat('/sd_').concat(sFolder).concat('.xml');
	}
	else {
		sLink = '/ListFile/Subject/'.concat(Right(Hexa(PAGE_SITE),2)).concat('/so_').concat(sFolder).concat('.xml');
	}
	var sHTML;
	var iMaxItem;
	switch (parseInt(sFolder)){
		case 15: case 16: case 25: 
			iMaxItem = 1; break;
		case 110: case 400: 
			iMaxItem = 4; break;
		case 2: case 3: case 9: case 18: case 38: case 47: case 51: case 83: case 89: case 127: 
			iMaxItem = 5; break;
		case 1001: 
			iMaxItem = 7;break;		
		case 105:
			iMaxItem = 2; break;		
		default: 
			iMaxItem = 3;
	}
	AjaxRequest.get(
		{
	    'url':sLink
	    ,'onSuccess':function(req){			
	    	if (req.responseXML.getElementsByTagName('F').length>0){				
	    		with(req.responseXML.getElementsByTagName('F').item(0)){
					sId = getNodeValue(getElementsByTagName('I'));
					sName = toUpper(getNodeValue(getElementsByTagName('N')));
					sPath = getNodeValue(getElementsByTagName('P'));					
	    		}
	    	}
	    	var iCount=0;
	    	for (var i=0;i<req.responseXML.getElementsByTagName('I').length;i++){
	    		with(req.responseXML.getElementsByTagName('I').item(i)){
	    			if (iCount<iMaxItem){
		    			var sTemp = getNodeValue(getElementsByTagName('I'));
		    			if (sTemp!='' && displayid(sTemp)){
			    			arItem[iCount] = new Array(19);
							arItem[iCount][0] = getNodeValue(getElementsByTagName('I'));
							arItem[iCount][1] = getNodeValue(getElementsByTagName('P')) + '/';
							arItem[iCount][2] = getNodeValue(getElementsByTagName('T'));
							arItem[iCount][3] = getNodeValue(getElementsByTagName('L'));
							arItem[iCount][4] = getNodeValue(getElementsByTagName('TI'));
							arItem[iCount][5] = getNodeValue(getElementsByTagName('TW'));
							arItem[iCount][6] = getNodeValue(getElementsByTagName('TH'));
							arItem[iCount][7] = getNodeValue(getElementsByTagName('SI'));
							arItem[iCount][8] = getNodeValue(getElementsByTagName('SW'));
							arItem[iCount][9] = getNodeValue(getElementsByTagName('SH'));
							arItem[iCount][10] = getNodeValue(getElementsByTagName('LI'));
							arItem[iCount][11] = getNodeValue(getElementsByTagName('LW'));
							arItem[iCount][12] = getNodeValue(getElementsByTagName('LH'));
							arItem[iCount][13] = getNodeValue(getElementsByTagName('HV'));
							arItem[iCount][14] = getNodeValue(getElementsByTagName('HI'));
							arItem[iCount][15] = getNodeValue(getElementsByTagName('HS'));		
							arItem[iCount][16] = getNodeValue(getElementsByTagName('OI'));
							arItem[iCount][17] = getNodeValue(getElementsByTagName('OW'));
							arItem[iCount][18] = getNodeValue(getElementsByTagName('OH'));
							iCount++;
						}
					}
	    		}
	    	}
	    	switch (parseInt(sFolder)){	    						
				case 400: sHTML = getphotofolder(sId,sName,sPath,arItem);break;
	    		default: sHTML = gethomefolderitem(sId,sName,sPath,arItem); break;
	    	}			
			gmobj('tdHomeFolder'+sFolder).innerHTML=sHTML;			
			switch (parseInt(sFolder)) {
				//case 3: showsubfolder(5); break;				
				//case 9: showsubfolder(121); break;						
				case 110: showsubfolder(151); break;				
				default: break;
			}			
	    }
	    ,'onError':function(req){
			gmobj('tdHomeFolder'.concat(sFolder)).innerHTML=req.statusText;			
			}
		}
	)
}

function gethomefolderitem(sId,sName,sPath,arItem) {
	var sHTML = '';
	var i=0;
	// sHTML = sHTML.concat(writeTabMenu(sId,0));
	// if(sId!=105) {
		// sHTML = sHTML.concat('<div class="folder-content">');
	// }
	// else {
		// sHTML = sHTML.concat('<div class="folder-content folder-smallcontent">');
	// }
	
	if(sId==105) {
		while(i<arItem.length) {
			sHTML = sHTML.concat('<p><a href="').concat(arItem[i][1]).concat('" class="link-title">').concat(arItem[i][2]).concat('</a></p> ');
			sHTML = sHTML.concat('<p>').concat(arItem[i][3].replace(/class=Lead/ig,'class=Lead1')).concat('</p>');			
			i++;
		}
	}	
	else if(sId==109) {
		while(i<arItem.length) {
			if(i==0) {
				sHTML = sHTML.concat('	<div class="folder-topnews2 fl">');
				if(arItem[i][7] != '') {			
					sHTML = sHTML.concat('<a href="').concat(arItem[i][1]).concat('"><img class="img-subject fl" src="').concat(getimages(arItem[i][0], arItem[i][7])).concat('" alt="" /></a>');					
				}
				sHTML = sHTML.concat('<p><a href="').concat(arItem[i][1]).concat('" class="link-title">').concat(arItem[i][2]).concat('</a>');
				sHTML = sHTML.concat(showMediaIcon(arItem[i][1], arItem[i][13], arItem[i][14], 0)).concat('</p>');
				sHTML = sHTML.concat('<p>').concat(arItem[i][3].replace(/class=Lead/ig,'class=Lead1')).concat('</p>');
				sHTML = sHTML.concat('	</div>');
			}
			else {
				if(i==1) {
					sHTML = sHTML.concat('	<div class="folder-othernews2 fl" style="padding-top:5px;">');
					sHTML = sHTML.concat('		<ul>');
					sHTML = sHTML.concat('			<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
				}
				else if(i!=arItem.length-1) {
					sHTML = sHTML.concat('			<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');					
				}
				else {
					sHTML = sHTML.concat('			<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
					sHTML = sHTML.concat('		</ul>');
					sHTML = sHTML.concat('	</div>');
				}
			}
			i++;
		}
	}
	else {			
		sHTML = sHTML.concat('	<div class="folder-topnews fl">');	
		if(arItem[i][7] != '') {			
			sHTML = sHTML.concat('<a href="').concat(arItem[i][1]).concat('"><img class="img-subject fl" src="').concat(getimages(arItem[i][0], arItem[i][7])).concat('" alt="" /></a>');					
		}
		sHTML = sHTML.concat('<p><a href="').concat(arItem[i][1]).concat('" class="link-title">').concat(arItem[i][2]).concat('</a>');
		sHTML = sHTML.concat(showMediaIcon(arItem[i][1], arItem[i][13], arItem[i][14], 0)).concat('</p>');
		sHTML = sHTML.concat('<p>').concat(arItem[i][3].replace(/class=Lead/ig,'class=Lead1')).concat('</p>');
		sHTML = sHTML.concat('	</div>');		
		// if(sId==9){
			// sHTML = sHTML.concat('<div class="folder-othernews fl" id="HomeFolder121">&nbsp;</div>');			
		// }
		// else{
			sHTML = sHTML.concat(getothernews(sId,sName,sPath,arItem));
		// }
	}
	if(sId!=110){
		sHTML = sHTML.concat('	<div class="rss fr">').concat(RSSLink(sId)).concat('</div>');
	}
	else {
		sHTML = sHTML.concat('	<div class="rss fr">');
		sHTML = sHTML.concat('<div class="fl"><img src="/Images/Menu/black-triangle.gif" alt="" />&nbsp;').concat('<a class="link-othernews3" href="/GL/Suc-khoe/Tu-van/">T&#432; v&#7845;n s&#7913;c kh&#7887;e</a>');
		sHTML = sHTML.concat('&nbsp;&nbsp;&nbsp;<img src="/Images/Menu/black-triangle.gif" alt="" />&nbsp;').concat('<a class="link-othernews3" href="/GL/Doi-song/Tu-van-nuoi-day-tre/">T&#432; v&#7845;n nu&#244;i d&#7841;y tr&#7867;</a></div>');
		sHTML = sHTML.concat(RSSLink(sId)).concat('</div>');
	}
	sHTML = sHTML.concat('</div>');
	// if(sId!=105) {
		// sHTML = sHTML.concat('<div class="folder-bottom">');
		// sHTML = sHTML.concat('	<div class="fl"><img src="/Images/Background/folder-bottomleft.gif" alt="" /></div>');
		// sHTML = sHTML.concat('	<div class="folder-bottomcenter fl">&nbsp;</div>');
		// sHTML = sHTML.concat('	<div class="fr"><img src="/Images/Background/folder-bottomright.gif" alt="" /></div>');
		// sHTML = sHTML.concat('</div>');
	// }
	// else {
		// sHTML = sHTML.concat('<div class="folder-bottom folder-smallbottom">');
		// sHTML = sHTML.concat('	<div class="fl"><img src="/Images/Background/folder-bottomleft.gif" alt="" /></div>');
		// sHTML = sHTML.concat('	<div class="folder-bottomcenter folder-smallbottomcenter fl">&nbsp;</div>');
		// sHTML = sHTML.concat('	<div class="fr"><img src="/Images/Background/folder-bottomright.gif" alt="" /></div>');
		// sHTML = sHTML.concat('</div>');
	// }
	return sHTML;
}

function getothernews(sId,sName,sPath,arItem) {
	var sHTML = '';
	var i=1;
	switch (parseInt(sId)){
		case 2: case 3: case 9: case 18: case 38: case 47: 
			while(i<arItem.length){
				if(i==1) {
					sHTML = sHTML.concat('	<div class="folder-othernews fl">');					
					if(arItem[i][7] != '' || arItem[i][10] != ''){
						sHTML = sHTML.concat('<div class="other-folder fl">');
						if(arItem[i][10] != '') {
						sHTML = sHTML.concat('<a href="').concat(arItem[i][1]).concat('"><img class="img-other fl" src="').concat(getimages(arItem[i][0], arItem[i][10])).concat('" alt="" /></a>');
						}
						else {
							sHTML = sHTML.concat('<a href="').concat(arItem[i][1]).concat('"><img class="img-other fl" src="').concat(getimages(arItem[i][0], arItem[i][7])).concat('" alt="" /></a>');
						}
						sHTML = sHTML.concat('<a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a>');
						sHTML = sHTML.concat(showMediaIcon(arItem[i][1], arItem[i][13], arItem[i][14], 0));
						sHTML = sHTML.concat('</div>');
						sHTML = sHTML.concat('<div class="fl">');
						sHTML = sHTML.concat('	<ul>');
					}	
					else{
						sHTML = sHTML.concat('		<div class="fl">');
						sHTML = sHTML.concat('			<ul>');
						sHTML = sHTML.concat('				<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
					}
				}
				else if(i!=arItem.length-1) {
					sHTML = sHTML.concat('				<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
				}
				else {
					sHTML = sHTML.concat('				<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
					sHTML = sHTML.concat('			</ul>');
					sHTML = sHTML.concat('		</div>');
					sHTML = sHTML.concat('	</div>');
				}
				i++;
			}
			break;
		// case 3:
			// while(i<arItem.length){
				// if(i==1) {
					// sHTML = sHTML.concat('	<div class="folder-othernews fl">');					
					// sHTML = sHTML.concat('		<div class="other-folder fl" id="HomeFolder5"></div>');					
					// sHTML = sHTML.concat('		<div class="fl">');
					// sHTML = sHTML.concat('			<ul>');
					// sHTML = sHTML.concat('				<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
				// }
				// else if(i!=arItem.length-1) {
					// sHTML = sHTML.concat('				<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
				// }
				// else {
					// sHTML = sHTML.concat('				<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
					// sHTML = sHTML.concat('			</ul>');
					// sHTML = sHTML.concat('		</div>');
					// sHTML = sHTML.concat('	</div>');
				// }
				// i++;
			// }
			// break;				
		case 110:
			while(i<arItem.length){
				if(i==1) {
					sHTML = sHTML.concat('	<div class="folder-othernews fl">');
					sHTML = sHTML.concat('		<div class="fl">');
					sHTML = sHTML.concat('			<ul>');
					sHTML = sHTML.concat('				<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
				}
				else if(i!=arItem.length-1) {
					sHTML = sHTML.concat('				<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
				}
				else {
					sHTML = sHTML.concat('				<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
					sHTML = sHTML.concat('			</ul>');
					sHTML = sHTML.concat('		</div>')
					sHTML = sHTML.concat('		<div class="other-folder2 fl" id="HomeFolder151"></div>');
					sHTML = sHTML.concat('	</div>');
				}
				i++;
			}
			break;		
		default:
			while(i<arItem.length){
				if(i==1) {
					sHTML = sHTML.concat('	<div class="folder-othernews fl">');
					sHTML = sHTML.concat('		<ul>');
					sHTML = sHTML.concat('			<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
				}
				else if(i!=arItem.length-1) {
					sHTML = sHTML.concat('			<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
				}
				else {
					sHTML = sHTML.concat('			<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
					sHTML = sHTML.concat('		</ul>');
					sHTML = sHTML.concat('	</div>');
				}
				i++;
			}
			break;
	}
	return	sHTML;
}

function getphotofolder(sId,sName,sPath,arItem){
	var sHTML = '';	
	var i=0;	
	while (i<arItem.length){
		if(i==0){
			sHTML = sHTML.concat('<div class="box-middle1 folder-photo fl">');
			sHTML = sHTML.concat('		<p><a href="').concat(arItem[i][1]).concat('">').concat(arItem[i][2]).concat('</a></p>');
			sHTML = sHTML.concat('		<p><a href="').concat(arItem[i][1]).concat('"><img src="').concat(getimages(arItem[i][0], arItem[i][16])).concat('"/></a></p>');
			sHTML = sHTML.concat('</div>');
		}		
		else {
			if(i==1) {	
				sHTML = sHTML.concat('<div class="box-middle1 list-item fl">');				
				sHTML = sHTML.concat('		<ul>');
				sHTML = sHTML.concat('			<li><a class="link-othernews3" href="').concat(arItem[i][1]).concat('">').concat(arItem[i][2]).concat('</a></li>');
			}			
			else if(i!=arItem.length-1) {
				sHTML = sHTML.concat('			<li><a class="link-othernews3" href="').concat(arItem[i][1]).concat('">').concat(arItem[i][2]).concat('</a></li>');
			}
			else {
				sHTML = sHTML.concat('			<li><a class="link-othernews3" href="').concat(arItem[i][1]).concat('">').concat(arItem[i][2]).concat('</a></li>');
				sHTML = sHTML.concat('		</ul>');
				sHTML = sHTML.concat('	</div>')				
			}
		}
		i++;
	}		
	return sHTML;
}

function showsubfolder(sFolder){		
	var sId, sName, sPath;
	var arItem = new Array();	
	var sLink = '';
	if(DOMESTIC_IP==0) {
		sLink = '/ListFile/Subject/'.concat(Right(Hexa(PAGE_SITE),2)).concat('/sd_').concat(sFolder).concat('.xml');
	}
	else {
		sLink = '/ListFile/Subject/'.concat(Right(Hexa(PAGE_SITE),2)).concat('/so_').concat(sFolder).concat('.xml');
	}
	var sHTML;
	var iMaxItem;
	switch (parseInt(sFolder)){
		case 10: case 14: iMaxItem = 2; break;		
		case 121: iMaxItem = 4; break;			
		default: iMaxItem = 1; break;
	}			
	AjaxRequest.get(
		{
	    'url':sLink
	    ,'onSuccess':function(req){			
	    	if (req.responseXML.getElementsByTagName('F').length>0){				
	    		with(req.responseXML.getElementsByTagName('F').item(0)){
					sId = getNodeValue(getElementsByTagName('I'));
					sName = toUpper(getNodeValue(getElementsByTagName('N')));
					sPath = getNodeValue(getElementsByTagName('P'));					
	    		}
	    	}
	    	var iCount=0;
	    	for (var i=0;i<req.responseXML.getElementsByTagName('I').length;i++){
	    		with(req.responseXML.getElementsByTagName('I').item(i)){
	    			if (iCount<iMaxItem){
		    			var sTemp = getNodeValue(getElementsByTagName('I'));
		    			if (sTemp!='' && displayid(sTemp)){
			    			arItem[iCount] = new Array(19);
							arItem[iCount][0] = getNodeValue(getElementsByTagName('I'));
							arItem[iCount][1] = getNodeValue(getElementsByTagName('P')) + '/';
							arItem[iCount][2] = getNodeValue(getElementsByTagName('T'));
							arItem[iCount][3] = getNodeValue(getElementsByTagName('L'));
							arItem[iCount][4] = getNodeValue(getElementsByTagName('TI'));
							arItem[iCount][5] = getNodeValue(getElementsByTagName('TW'));
							arItem[iCount][6] = getNodeValue(getElementsByTagName('TH'));
							arItem[iCount][7] = getNodeValue(getElementsByTagName('SI'));
							arItem[iCount][8] = getNodeValue(getElementsByTagName('SW'));
							arItem[iCount][9] = getNodeValue(getElementsByTagName('SH'));
							arItem[iCount][10] = getNodeValue(getElementsByTagName('LI'));
							arItem[iCount][11] = getNodeValue(getElementsByTagName('LW'));
							arItem[iCount][12] = getNodeValue(getElementsByTagName('LH'));
							arItem[iCount][13] = getNodeValue(getElementsByTagName('HV'));
							arItem[iCount][14] = getNodeValue(getElementsByTagName('HI'));
							arItem[iCount][15] = getNodeValue(getElementsByTagName('HS'));
							arItem[iCount][16] = getNodeValue(getElementsByTagName('OI'));
							arItem[iCount][17] = getNodeValue(getElementsByTagName('OW'));
							arItem[iCount][18] = getNodeValue(getElementsByTagName('OH'));
							iCount++;
						}
					}
	    		}
	    	}	
			sHTML = getsubfolder(sId, sName, sPath, arItem, sFolder);
			gmobj('HomeFolder'.concat(sFolder)).innerHTML=sHTML;			
	    }
	    ,'onError':function(req){
			gmobj('HomeFolder'.concat(sFolder)).innerHTML=req.statusText;			
			}
		}
	)
}

function getsubfolder(sId, sName, sPath, arItem, sFolder){
	var sHTML = '';
	var i=0;
	switch(parseInt(sFolder)){
		case 5: case 151:
			if(arItem[i][10] != '') {
				sHTML = sHTML.concat('<a href="').concat(arItem[i][1]).concat('"><img class="img-other fl" src="').concat(getimages(arItem[i][0], arItem[i][10])).concat('" alt="" /></a>');
			}
			else if(arItem[i][7] != '') {
				sHTML = sHTML.concat('<a href="').concat(arItem[i][1]).concat('"><img class="img-other fl" src="').concat(getimages(arItem[i][0], arItem[i][7])).concat('" alt="" /></a>');
			}
			if(parseInt(sFolder)==5){
				sHTML = sHTML.concat('<a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a>');
				sHTML = sHTML.concat(showMediaIcon(arItem[i][1], arItem[i][13], arItem[i][14], 1));
			}
			else {
				sHTML = sHTML.concat('<a href="').concat(arItem[0][1]).concat('" class="link-othernews" style="font-weight:bold;">').concat(arItem[0][2]).concat('</a>');	
			}			
			break;
		case 121:
			while(i<arItem.length){
				if(i==0) {
					sHTML = sHTML.concat('	<div class="folder-othernews fl">');					
					if(arItem[i][7] != '' || arItem[i][10] != ''){
						sHTML = sHTML.concat('<div class="other-folder fl">');
						if(arItem[i][10] != '') {
						sHTML = sHTML.concat('<a href="').concat(arItem[i][1]).concat('"><img class="img-other fl" src="').concat(getimages(arItem[i][0], arItem[i][10])).concat('" alt="" /></a>');
						}
						else {
							sHTML = sHTML.concat('<a href="').concat(arItem[i][1]).concat('"><img class="img-other fl" src="').concat(getimages(arItem[i][0], arItem[i][7])).concat('" alt="" /></a>');
						}
						sHTML = sHTML.concat('<a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a>');
						sHTML = sHTML.concat(showMediaIcon(arItem[i][1], arItem[i][13], arItem[i][14], 0));
						sHTML = sHTML.concat('</div>');
						sHTML = sHTML.concat('<div class="fl">');
						sHTML = sHTML.concat('	<ul>');
					}	
					else{
						sHTML = sHTML.concat('		<div class="fl">');
						sHTML = sHTML.concat('			<ul>');
						sHTML = sHTML.concat('				<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
					}
				}
				else if(i!=arItem.length-1) {
					sHTML = sHTML.concat('				<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
				}
				else {
					sHTML = sHTML.concat('				<li><a href="').concat(arItem[i][1]).concat('" class="link-othernews">').concat(arItem[i][2]).concat('</a></li>');
					sHTML = sHTML.concat('			</ul>');
					sHTML = sHTML.concat('		</div>');
					sHTML = sHTML.concat('	</div>');
				}
				i++;
			}
			break;
		case 10: case 14:
			sHTML = sHTML.concat('<ul>');
			while (i<arItem.length) {
				sHTML = sHTML.concat('	<li><a class="link-othernews" href="').concat(arItem[i][1]).concat('">').concat(arItem[i][2]).concat('</a></li>');
				i++;
			}
			sHTML = sHTML.concat('</ul>');
			break;
		default: break;
	}
	return sHTML;
}

function changeChannel(objObject){
	showIPTV(objObject.value);
}

function showIPTV(ExLocalID){	
	var sDate = '';
	var channel = '';
	var arItem = new Array();	
	var sLink = '/ListFile/iTV/' + ExLocalID + '.xml';
	AjaxRequest.get(
		{
		'url':sLink
		,'onSuccess':function(req){			
			sDate = getNodeValue(req.responseXML.getElementsByTagName('Date'));										    	
			if(req.responseXML.getElementsByTagName('Items').length>0) {				
				for(var i=0; i<req.responseXML.getElementsByTagName('Items').length; i++) {
					if(req.responseXML.getElementsByTagName('Items')[i].getAttribute("ID")==ExLocalID){
						channel = req.responseXML.getElementsByTagName('Items')[i].getAttribute("NAME");
						var iCount=0;
						for(var j=0; j<req.responseXML.getElementsByTagName('Items')[i].getElementsByTagName('Item').length; j++) {
							arItem[iCount] = new Array(2);
							arItem[iCount][0] = getNodeValue(req.responseXML.getElementsByTagName('Items')[i].getElementsByTagName('Item')[j].getElementsByTagName('TVTime'));
							arItem[iCount][1] = getNodeValue(req.responseXML.getElementsByTagName('Items')[i].getElementsByTagName('Item')[j].getElementsByTagName('Desc'));								
							iCount++;
						}
						
						break;
					}
				}
			}
			gmobj("iptv-channel").innerHTML=getIPTV(ExLocalID,sDate, channel, arItem);
			gmobj("iptv-channel").scrollTop=0;
		}
		,'onError':function(req){gmobj("iptv-channel").innerHTML=req.statusText;}
		}
	)
}

function getIPTV(ExLocalID,sDate, channel, arItem){	
	var sHTML = '';
	
	sHTML = sHTML.concat('<table border=0 cellpadding=0 cellspacing=3 width=100%>');
	sHTML = sHTML.concat('<tr height=20><td colspan=2 class="Time" style="padding-left:3;font-size:11px"><b>').concat(channel).concat(' (').concat(sDate).concat(')</b></td></tr>');
	sHTML = sHTML.concat('<tr height=1><td colspan=2 bgcolor="#666666"></td></tr>');
	if(arItem.length > 0) {
		for(var i=0; i<arItem.length; i++){
			sHTML = sHTML.concat('<tr>');
			sHTML = sHTML.concat('<td style="padding-left:3; padding-right:5;" valign=top width=15 align=center class="Image" style="font: 11px arial;"><b>').concat(arItem[i][0]).concat('</b></td>');
			sHTML = sHTML.concat('<td valign=top class="Image" width="100%"><font color="#06175D"  style="font:11px arial;">').concat(arItem[i][1]).concat('</font></td>');
			sHTML = sHTML.concat('</tr>');
		}
	}
	else {
		sHTML = sHTML.concat('<tr>');
		sHTML = sHTML.concat('<td colspan=2 style="padding-left:3; padding-right:5;" valign=top align=left class="Image" style="font-size:11px"><font color="#06175D">Ch&#432;a c&#243; l&#7883;ch</font></td>');
		sHTML = sHTML.concat('</tr>');	
	}
	sHTML = sHTML.concat('</table>');
	
	return sHTML;
}

function ShowTopicJS(vFolderID, vItemCount, vType1, vType2, vCustomTitle, vPageCheck, vObjectID, vShowHeader, vSubjectID){
	var sId, sTitle, iCount=0, iMaxItem=10;
	var arItem = new Array();
	var sLink = '';
	var vHId='';	
	vHId = Hexa(vFolderID);	
	vHId = vHId.substring(vHId.length-6,vHId.length);	
	vHId = vHId.substring(0,2) + "/" + vHId.substring(2,4) + "/" + vHId.substring(4,6) + "/";	
	if(DOMESTIC_IP==0) {		
		sLink = sLink + '/ListFile/Topic/' + vHId + 'sd_' + PAGE_SITE + '.xml';		
	}
	else {		
		sLink = sLink + '/ListFile/Topic/' + vHId + 'so_' + PAGE_SITE + '.xml';				
	}	
	
	var sHTML;

	AjaxRequest.get(
		{
			'url':sLink
			,'onSuccess':function(req){				
				if (req.responseXML.getElementsByTagName('T').length>0){
					with(req.responseXML.getElementsByTagName('T').item(0)){
						sId = getNodeValue(getElementsByTagName('I'));
						sTitle= getNodeValue(getElementsByTagName('T'));
						sDate = getNodeValue(getElementsByTagName('D'));
					}
				}
				var iCount=0;				
				for (var i=0;i<req.responseXML.getElementsByTagName('I').length;i++){
					with(req.responseXML.getElementsByTagName('I').item(i)){					
						if (iCount<iMaxItem && iCount<vItemCount){	
							var sTemp = getNodeValue(getElementsByTagName('P'));
							var sTemps = new Array();
							sTemps = sTemp.split('/');							
							if (sTemps[sTemps.length-1]!='' && displayid(HexToDec(sTemps[sTemps.length-1]))){								
								arItem[iCount] = new Array(3);
								arItem[iCount][0] = getNodeValue(getElementsByTagName('T'));
								arItem[iCount][1] = getNodeValue(getElementsByTagName('P')) + '/';
								arItem[iCount][2] = getNodeValue(getElementsByTagName('D'));							
								iCount++;							
							}
						}
					}
				}
			
				gmobj(vObjectID).innerHTML = GetTopicHTML(sId,sTitle,sDate,arItem,vType1,vType2,vCustomTitle,vShowHeader);
			}
			,'onError':function(req){gmobj(vObjectID).innerHTML=req.statusText;}
		}
	)
}

function GetTopicHTML(sId,sTitle,sDate,arItem,vType1,vType2,vCustomTitle,vShowHeader){
	var sHTML = '';
	var iCount=0, i=0;
	var sTdBullet='', sTableTopicTitle='';
	var sTopicTitle='Theo d&#242;ng s&#7921; ki&#7879;n'

	switch(vType2)
	{
		case 0: // ' 0 Default Title
			sTableTopicTitle += '<table border="0" cellpadding="0" cellspacing="0" width="100%">';
			sTableTopicTitle += '<tr><td class="OtherTitle" height="40" valign="middle">'+sTopicTitle+':</td></tr>';
			sTableTopicTitle += '</table>';
			sTdBullet='';
			break;
		case 1: // ' 1 User Defined Title
			sTableTopicTitle += '<table border="0" cellpadding="0" cellspacing="0" width="100%">';
			sTableTopicTitle += '<tr><td class="OtherTitle" height="40" valign="middle">'+vCustomTitle+':</td></tr>';
			sTableTopicTitle += '</table>';
			sTdBullet='';
			break;
		case 2: // ' 2 No Title
			sTrTopicTitle='';
			sTdBullet='';
			break;
		case 3: // ' 3 List Item Only
			sTrTopicTitle='';
			sTdBullet='<td width="7" valign="top" class="Normal">&#9642;</td>'
			break;
	}

	if (vShowHeader==0) sTableTopicTitle='';

	switch(vType1)
	{
		case 1: // ' Topic
			sHTML += sTableTopicTitle;
			sHTML += '<table border="0" cellpadding="2" cellspacing="0" width="96%">';
			//sHTML += '<tr><td><a href="/Topic/?ID='+sId+'" class="TopicTitle">'+sTitle+'</a><span class="ShowDate">&nbsp;('+sDate+')</span></td></tr>';
			if(PAGE_SITE==0) {
				sHTML += '<tr><td><a href="/GL/Topic/?ID='+sId+'" class="TopicTitle">'+sTitle+'</a><span class="ShowDate">&nbsp;('+dmy(sDate)+')</span></td></tr>';
			}
			else if(PAGE_SITE==1) {
				sHTML += '<tr><td><a href="/HN/Topic/?ID='+sId+'" class="TopicTitle">'+sTitle+'</a><span class="ShowDate">&nbsp;('+dmy(sDate)+')</span></td></tr>';
			}
			else if(PAGE_SITE==2) {
				sHTML += '<tr><td><a href="/SG/Topic/?ID='+sId+'" class="TopicTitle">'+sTitle+'</a><span class="ShowDate">&nbsp;('+dmy(sDate)+')</span></td></tr>';
			}
			sHTML += '</table>';
			break;
		case 2: // ' Subject
			sHTML += sTableTopicTitle;
			sHTML += '<table border="0" cellpadding="2" cellspacing="0" width="96%">';
			while (i<arItem.length)
			{
				sHTML += '<tr>'+sTdBullet+'<td><a class="Other" href="'+arItem[i][1]+'">'+arItem[i][0]+'</a><span class="ShowDate">&nbsp;('+dmy(arItem[i][2])+')</span></td></tr>';
				i++;
			}
			sHTML += '</table>';
			break;
		case 3: // ' Topic + Subject
			sHTML += sTableTopicTitle;
			sHTML += '<table border="0" cellpadding="2" cellspacing="0" width="96%">';			
			if(PAGE_SITE==0) {
				sHTML += '<tr><td><a href="/GL/Topic/?ID='+sId+'" class="TopicTitle">'+sTitle+'</a><span class="ShowDate">&nbsp;('+dmy(sDate)+')</span></td></tr>';
			}
			else if(PAGE_SITE==1) {
				sHTML += '<tr><td><a href="/HN/Topic/?ID='+sId+'" class="TopicTitle">'+sTitle+'</a><span class="ShowDate">&nbsp;('+dmy(sDate)+')</span></td></tr>';
			}
			else if(PAGE_SITE==2) {
				sHTML += '<tr><td><a href="/SG/Topic/?ID='+sId+'" class="TopicTitle">'+sTitle+'</a><span class="ShowDate">&nbsp;('+dmy(sDate)+')</span></td></tr>';
			}
			while (i<arItem.length)
			{
				sHTML += '<tr><td><table border="0" width="100%" cellpadding="2" cellspacing="0"><tr>'+sTdBullet+'<td><a class="Other" href="'+arItem[i][1]+'">'+arItem[i][0]+'</a><span class="ShowDate">&nbsp;('+dmy(arItem[i][2])+')</span></td></tr></table></td></tr>';
				i++;
			}
			sHTML += '</table>';
			break;
		case 4: // ' Subject (before)
			sHTML += sTableTopicTitle;
			sHTML += '<table border="0" cellpadding="2" cellspacing="0" width="96%">';
			while (i<arItem.length)
			{
				sHTML += '<tr><td><table border="0" width="100%" cellpadding="2" cellspacing="0"><tr>'+sTdBullet+'<td><a class="Other" href="'+arItem[i][1]+'">'+arItem[i][0]+'</a><span class="ShowDate">&nbsp;('+dmy(arItem[i][2])+')</span></td></tr></table></td></tr>';
				i++;
			}
			if(PAGE_SITE==0) {
				sHTML += '<tr><td><table border="0" width="100%" cellpadding="2" cellspacing="0"><tr><td align="right"><a class="Other" href="/GL/Topic/?ID='+sId+'">Xem ti&#7871;p</a></td></tr></table></td></tr>';
			}
			else if(PAGE_SITE==1) {
				sHTML += '<tr><td><table border="0" width="100%" cellpadding="2" cellspacing="0"><tr><td align="right"><a class="Other" href="/HN/Topic/?ID='+sId+'">Xem ti&#7871;p</a></td></tr></table></td></tr>';
			}
			else if(PAGE_SITE==2) {
				sHTML += '<tr><td><table border="0" width="100%" cellpadding="2" cellspacing="0"><tr><td align="right"><a class="Other" href="/SG/Topic/?ID='+sId+'">Xem ti&#7871;p</a></td></tr></table></td></tr>';
			}
			sHTML += '</table>';
			break;
		case 5: // ' Topic + Subject (before)
			sHTML += sTableTopicTitle;
			sHTML += '<table border="0" cellpadding="2" cellspacing="0" width="96%">';
			//sHTML += '<tr><td><a href="/Topic/?ID='+sId+'" class="TopicTitle">'+sTitle+'</a><span class="ShowDate">&nbsp;('+sDate+')</span></td></tr>';
			if(PAGE_SITE==0) {
				sHTML += '<tr><td><a href="/GL/Topic/?ID='+sId+'" class="TopicTitle">'+sTitle+'</a><span class="ShowDate">&nbsp;('+dmy(sDate)+')</span></td></tr>';
			}
			else if(PAGE_SITE==1) {
				sHTML += '<tr><td><a href="/HN/Topic/?ID='+sId+'" class="TopicTitle">'+sTitle+'</a><span class="ShowDate">&nbsp;('+dmy(sDate)+')</span></td></tr>';
			}
			else if(PAGE_SITE==2) {
				sHTML += '<tr><td><a href="/SG/Topic/?ID='+sId+'" class="TopicTitle">'+sTitle+'</a><span class="ShowDate">&nbsp;('+dmy(sDate)+')</span></td></tr>';
			}
			while (i<arItem.length)
			{
				sHTML += '<tr><td><table border="0" width="100%" cellpadding="2" cellspacing="0"><tr>'+sTdBullet+'<td><a class="Other" href="'+arItem[i][1]+'">'+arItem[i][0]+'</a><span class="ShowDate">&nbsp;('+dmy(arItem[i][2])+')</span></td></tr></table></td></tr>';
				i++;
			}			
			if(PAGE_SITE==0) {
				sHTML += '<tr><td align="right"><a class="Other" href="/GL/Topic/?ID='+sId+'">Xem ti&#7871;p</a></td></tr>';
			}
			else if(PAGE_SITE==1) {
				sHTML += '<tr><td align="right"><a class="Other" href="/HN/Topic/?ID='+sId+'">Xem ti&#7871;p</a></td></tr>';
			}
			else if(PAGE_SITE==2) {
				sHTML += '<tr><td align="right"><a class="Other" href="/SG/Topic/?ID='+sId+'">Xem ti&#7871;p</a></td></tr>';
			}
			sHTML += '</table>';
			break;
	}

	return sHTML;
}

function showVideo(VideoId) {
	var sLink = '';	
	var sList = '';
	var iMaxItem = 4;	
	sLink = '/ListFile/Video/tv' + PAGE_SITE + '.xml';
	AjaxRequest.get(
		{
		'url':sLink
		,'onSuccess':function(req){			
			sList = sList.concat('<ul>');			
			var iCount=0;			
			if(VideoId == 0) {				
				for (var i=0;i<req.responseXML.getElementsByTagName('I').length;i++) {					
					if(req.responseXML.getElementsByTagName('I')[i].getElementsByTagName('I').length > 0) {						
						with(req.responseXML.getElementsByTagName('I').item(i)) {
							if(iCount < iMaxItem) {
								if(i==0) {
									showVideoObject(getNodeValue(getElementsByTagName('T')),getNodeValue(getElementsByTagName('P')),getNodeValue(getElementsByTagName('IP')));
								}
								else {
									sList = sList.concat('<li><a href="javascript:showVideo(');
									sList = sList.concat(getNodeValue(getElementsByTagName('I')));
									sList = sList.concat(');" class="link-othernews2">');
									sList = sList.concat(getNodeValue(getElementsByTagName('T')));
									sList = sList.concat('</a></li>');
								}
								iCount++;
							}
							else {
								break;
							}
						}
					}
				}
			}
			else {
				for (var i=0;i<req.responseXML.getElementsByTagName('I').length;i++) {
					if(req.responseXML.getElementsByTagName('I')[i].getElementsByTagName('I').length > 0) {	
						with(req.responseXML.getElementsByTagName('I').item(i)) {
							if(iCount < iMaxItem) {
								if(parseInt(getNodeValue(getElementsByTagName('I'))) == VideoId) {
									showVideoObject(getNodeValue(getElementsByTagName('T')),getNodeValue(getElementsByTagName('P')),getNodeValue(getElementsByTagName('IP')));
								}
								else {
									sList = sList.concat('<li><a href="javascript:showVideo(');
									sList = sList.concat(getNodeValue(getElementsByTagName('I')));
									sList = sList.concat(');" class="link-othernews2">');
									sList = sList.concat(getNodeValue(getElementsByTagName('T')));
									sList = sList.concat('</a></li>');
								}
								iCount++;
							}	
							else {
								break;
							}
						}
					}
				}
			}
			sList = sList.concat('</ul>');			
			gmobj('MediaList').innerHTML = sList;				
		}
		,'onError':function(req){
			gmobj("divVideo").innerHTML=req.statusText;
			}
		}
	)
}

function showVideoObject(title,path,imagepath) {
	gmobj('video-title').innerHTML 	= title;					
	var so = new SWFObject('/Library/Common/Player/mediaplayer.swf','MediaPlayer','280','240','8');
	so.addParam('allowscriptaccess','always');
	so.addParam('allowfullscreen','true');
	so.addVariable('width','278');
	so.addVariable('height','238');
	so.addVariable('file','http://media.vnexpress.net/MediaStore/Video/' + path);		
	if(imagepath==''){
		so.addVariable('image','/Images/video-vne.jpg');
	}
	else{		
		so.addVariable('image','http://media.vnexpress.net/MediaStore/' + imagepath);
	}
	so.write('mediaspace');
}

function showMediaIcon(path, ivideo, iphoto, type) {
	var strIcon = ''
	if(type==0) {
		if(ivideo > 0 || iphoto > 0) {
			strIcon=strIcon.concat('&nbsp;<a style="text-decoration:none" href="').concat(path).concat('">');		
			if(ivideo > 0){
				strIcon=strIcon.concat('<img border="0" src="/Images/video.gif" />&nbsp;&nbsp;');
			}						
			if(iphoto > 0){
				strIcon=strIcon.concat('<img border="0" src="/Images/photo.gif" />&nbsp;&nbsp;');
			}
			strIcon = strIcon.concat('</a>');
		}
	}
	else if(type==1) {
		if(ivideo > 0){
			strIcon=strIcon.concat('&nbsp;&nbsp;<img border="0" src="/Images/video.gif" align="middle" />');
		}						
		if(iphoto > 0){
			strIcon=strIcon.concat('&nbsp;&nbsp;<img border="0" src="/Images/photo.gif" align="middle" />');
		}
	}
	else if(type==2) {
		if(ivideo > 0){
			strIcon=strIcon.concat('<img border="0" src="/Images/video.gif" />&nbsp;&nbsp;');
		}						
		if(iphoto > 0){
			strIcon=strIcon.concat('<img border="0" src="/Images/photo.gif" />&nbsp;&nbsp;');
		}		
	}
	else if(type==3) {
		if(ivideo > 0){
			strIcon=strIcon.concat('&nbsp;<img border="0" src="/Images/video.gif" />');
		}						
		if(iphoto > 0){
			strIcon=strIcon.concat('&nbsp;<img border="0" src="/Images/photo.gif" />');
		}		
	}
	return strIcon;
}

function showAdWord(FolderId) {
	if(FolderId < 0) {
		FolderId = 0;
	}
	var sLink = '';	
	var arItem = new Array();
	var iMaxItem = 16;
	sLink = '/ListFile/AdWord/' + FolderId + '.xml';	
	AjaxRequest.get(
		{
		'url':sLink
		,'onSuccess':function(req){				    	
			if(req.responseXML.getElementsByTagName('I').length>0) {				
				var iCount=0;				
		    	for (var i=0;i<req.responseXML.getElementsByTagName('I').length;i++){
					with(req.responseXML.getElementsByTagName('I').item(i)){
						if(iCount < iMaxItem){
							var sTemp = getNodeValue(getElementsByTagName('I'));
							if (sTemp!=''){
								arItem[iCount] = new Array(2);
								arItem[iCount][0] = getNodeValue(getElementsByTagName('I'));
								arItem[iCount][1] = getNodeValue(getElementsByTagName('T'));																				
								iCount++;
							}
						}
		    		}		    		
		    	}
			}
			gmobj("AdWord").innerHTML=getAdWord(arItem, FolderId);			
		}
		,'onError':function(req){}
		}
	)
}

function getAdWord(arItem, FolderId){
	var sHTML = '';
	var Link = '/User/Rao-vat/Source/View.Asp?ID=';
	var i=0;
	sHTML = sHTML.concat('<ul>');
	while(i<arItem.length) {				
		sHTML = sHTML.concat('<li><a class="link-othernews2" href="').concat(Link).concat(arItem[i][0]).concat('&c=').concat(FolderId).concat('">');
		sHTML = sHTML.concat(arItem[i][1]).concat('</a></li>');		
		i++;		
	}
	sHTML = sHTML.concat('</ul>');	
	return sHTML;
}

function showAdWordItem(FolderId, Items, iType){
	if(FolderId < 0) {
		FolderId = 0;
	}
	var sLink = '';	
	var arItem = new Array();
	var iMaxItem = 50;
	sLink = '/ListFile/AdWord/' + FolderId + '.xml';	
	AjaxRequest.get(
		{
		'url':sLink
		,'onSuccess':function(req){				    	
			if(req.responseXML.getElementsByTagName('I').length>0) {				
				var iCount=0;				
		    	for (var i=0;i<req.responseXML.getElementsByTagName('I').length;i++){
					with(req.responseXML.getElementsByTagName('I').item(i)){
						if(iCount < iMaxItem){
							var sTemp = getNodeValue(getElementsByTagName('I'));
							if (sTemp!=''){
								arItem[iCount] = new Array(5);
								arItem[iCount][0] = getNodeValue(getElementsByTagName('I'));
								arItem[iCount][1] = getNodeValue(getElementsByTagName('T'));																				
								arItem[iCount][2] = getNodeValue(getElementsByTagName('P'));																				
								arItem[iCount][3] = getNodeValue(getElementsByTagName('S'));																				
								arItem[iCount][4] = getNodeValue(getElementsByTagName('D'));																				
								iCount++;
							}
						}
		    		}		    		
		    	}
			}
			gmobj("adw_".concat(FolderId)).innerHTML=getAdWordItem(arItem, FolderId, iType, Items);			
		}
		,'onError':function(req){}
		}
	)
}

function getAdWordItem(arItem, FolderId, iType, Items){
	var sHTML = '';
	var Link = '';
	var i=0;
	var maxTop = 8;
	if(FolderId=='13_15'||FolderId=='12_14'){
		maxTop = 10;
	}
	sHTML = sHTML.concat('<ul>');
	var arItemTemp = new Array();
	var flag = false	
	while(i<arItem.length) {
		if(arItem[i][2]==1){
			arItemTemp[i] = new Array(5);
			arItemTemp[i][0] = arItem[i][0];
			arItemTemp[i][1] = arItem[i][1];
			arItemTemp[i][2] = arItem[i][2];
			arItemTemp[i][3] = arItem[i][3];
			arItemTemp[i][4] = arItem[i][4];
		}
		else{
			break;
		}
		i++;
	}
	i=0;
	if(arItemTemp.length > maxTop){
		flag = true;
	}
	if(flag==true){
		var len = arItemTemp.length;			
		while(arItemTemp.length > maxTop){			
			arItemTemp.splice(Math.round((arItemTemp.length-1)*Math.random()),1);							
		}
		while(i<arItemTemp.length){
			Link = '/User/Rao-vat/Source/View.Asp?ID='.concat(arItemTemp[i][0]).concat('&c=').concat(FolderId)
			sHTML = sHTML.concat('<li><a class="AdvLink2" href="').concat(Link).concat('" onClick="return openAdWord(\'').concat(arItemTemp[i][0]).concat('\',\'').concat(arItemTemp[i][2]).concat('\');">');
			sHTML = sHTML.concat(arItemTemp[i][1]).concat('</a>');
			if(iType==0){
				var sDates = arItemTemp[i][4].split(' ');
				sHTML = sHTML.concat('<label class="item-date"> - ').concat(dmy(sDates[0])).concat('</label>');
			}	
			sHTML = sHTML.concat('</li>');
			i++;
		}
		i = len;
		Items = Items + (i-maxTop);
		while(i<arItem.length && i<Items) {			
			Link = '/User/Rao-vat/Source/View.Asp?ID='.concat(arItem[i][0]).concat('&c=').concat(FolderId)
			sHTML = sHTML.concat('<li><a class="BoxLink2" href="').concat(Link).concat('" onClick="return openAdWord(\'').concat(arItem[i][0]).concat('\',\'').concat(arItem[i][2]).concat('\');">');
			sHTML = sHTML.concat(arItem[i][1]).concat('</a>');
			if(iType==0){
				var sDates = arItem[i][4].split(' ');
				sHTML = sHTML.concat('<label class="item-date"> - ').concat(dmy(sDates[0])).concat('</label>');
			}	
			sHTML = sHTML.concat('</li>');			
					
			i++;		
		}
	}
	else{
		while(i<arItem.length && i<Items) {
			if(arItem[i][2]==1){				
				Link = '/User/Rao-vat/Source/View.Asp?ID='.concat(arItem[i][0]).concat('&c=').concat(FolderId)
				sHTML = sHTML.concat('<li><a class="AdvLink2" href="').concat(Link).concat('" onClick="return openAdWord(\'').concat(arItem[i][0]).concat('\',\'').concat(arItem[i][2]).concat('\');">');
				sHTML = sHTML.concat(arItem[i][1]).concat('</a>');
				if(iType==0){
					var sDates = arItem[i][4].split(' ');
					sHTML = sHTML.concat('<label class="item-date"> - ').concat(dmy(sDates[0])).concat('</label>');
				}	
				sHTML = sHTML.concat('</li>');						
			}
			else{
				Link = '/User/Rao-vat/Source/View.Asp?ID='.concat(arItem[i][0]).concat('&c=').concat(FolderId)
				sHTML = sHTML.concat('<li><a class="BoxLink2" href="').concat(Link).concat('" onClick="return openAdWord(\'').concat(arItem[i][0]).concat('\',\'').concat(arItem[i][2]).concat('\');">');
				sHTML = sHTML.concat(arItem[i][1]).concat('</a>');
				if(iType==0){
					var sDates = arItem[i][4].split(' ');
					sHTML = sHTML.concat('<label class="item-date"> - ').concat(dmy(sDates[0])).concat('</label>');
				}	
				sHTML = sHTML.concat('</li>');	
			}
					
			i++;		
		}
	}	
	sHTML = sHTML.concat('</ul>');	
	return sHTML;
}

function ShowAdWordTitle(FolderId){
	var strTitle = ''
	switch(parseInt(FolderId)){
		case 1: strTitle = 'D&#7883;ch v&#7909; s&#7917;a ch&#7919;a gia d&#7909;ng'; break;
		case 2: strTitle = 'D&#7883;ch v&#7909; v&#259;n ph&#242;ng'; break;
		case 3: strTitle = 'B&#225;n thi&#7871;t b&#7883; v&#259;n ph&#242;ng v&#224; ph&#7909; ki&#7879;n'; break;
		case 4: strTitle = 'Mua thi&#7871;t b&#7883; v&#259;n ph&#242;ng v&#224; ph&#7909; ki&#7879;n'; break;
		case 5: strTitle = 'B&#225;n &#244;t&#244; xe m&#225;y'; break;
		case 6: strTitle = 'Mua &#244;t&#244; xe m&#225;y'; break;
		case 7: strTitle = 'Nh&#7855;n tin'; break;
		case 8: strTitle = 'B&#225;n &#273;i&#7879;n tho&#7841;i di &#273;&#7897;ng'; break;
		case 9: strTitle = 'Mua &#273;i&#7879;n tho&#7841;i di &#273;&#7897;ng'; break;
		case 10: strTitle = 'T&#236;m &#273;&#7889;i t&#225;c'; break;
		case 11: strTitle = 'Linh tinh'; break;
		case 12: strTitle = 'Cho thu&#234; nh&#224;'; break;
		case 13: strTitle = 'B&#225;n nh&#224;'; break;
		case 14: strTitle = 'C&#7847;n thu&#234; nh&#224;'; break;
		case 15: strTitle = 'C&#7847;n mua nh&#224;'; break;
		case 16: strTitle = 'T&#236;m vi&#7879;c l&#224;m'; break;
		case 17: strTitle = 'C&#7847;n tuy&#7875;n'; break;
		case 18: strTitle = 'Cho thu&#234; xe'; break;
		case 19: strTitle = 'V&#259;n h&#243;a ph&#7849;m'; break;
		case 20: strTitle = 'PM & TK Web'; break;
		case 21: strTitle = 'Tuy&#7875;n sinh'; break;
		default: break;
	}
	document.write(strTitle);
}

function ShowWeatherBox(vId){
	var sLink = '';
	sLink = '/ListFile/Weather/';
	switch (parseInt(vId)){	    	
		case 1: sLink = sLink.concat('Sonla.xml');break;
		case 2: sLink = sLink.concat('Viettri.xml');break;
		case 3: sLink = sLink.concat('Haiphong.xml');break;
		case 4: sLink = sLink.concat('Hanoi.xml');break;
		case 5: sLink = sLink.concat('Vinh.xml');break;
		case 6: sLink = sLink.concat('Danang.xml');break;
		case 7: sLink = sLink.concat('Nhatrang.xml');break;
		case 8: sLink = sLink.concat('Pleicu.xml');break;		
		case 9: sLink = sLink.concat('HCM.xml');break;	
		default: sLink = sLink.concat('Hanoi.xml');break;
	}
	AjaxRequest.get(
		{
			'url':sLink
			,'onSuccess':function(req){
				var vAdImg, vAdImg1, vAdImg2, vAdImg3, vAdImg4, vAdImg5, vWeather;
				vAdImg = req.responseXML.getElementsByTagName('AdImg').item(0).firstChild.nodeValue;
				vAdImg1 = req.responseXML.getElementsByTagName('AdImg1').item(0).firstChild.nodeValue;
				if(req.responseXML.getElementsByTagName('AdImg2').item(0).firstChild != null)
					vAdImg2 = req.responseXML.getElementsByTagName('AdImg2').item(0).firstChild.nodeValue;
				if(req.responseXML.getElementsByTagName('AdImg3').item(0).firstChild != null)
					vAdImg3 = req.responseXML.getElementsByTagName('AdImg3').item(0).firstChild.nodeValue;
				if(req.responseXML.getElementsByTagName('AdImg4').item(0).firstChild != null)
					vAdImg4 = req.responseXML.getElementsByTagName('AdImg4').item(0).firstChild.nodeValue;
				if(req.responseXML.getElementsByTagName('AdImg5').item(0).firstChild != null)
					vAdImg5 = req.responseXML.getElementsByTagName('AdImg5').item(0).firstChild.nodeValue;
				vWeather = req.responseXML.getElementsByTagName('Weather').item(0).firstChild.nodeValue;
				GetWeatherBox(vAdImg, vAdImg1, vAdImg2, vAdImg3, vAdImg4, vAdImg5, vWeather);				
				}
			,'onError':function(req){}
		}
	)
}

function GetWeatherBox(vImg, vImg1, vImg2, vImg3, vImg4, vImg5, vWeather){
	var sHTML = '';
	sHTML = sHTML.concat('<img src="/Images/Weather/').concat(vImg).concat('" class="img-weather" alt="" />&nbsp;');
	sHTML = sHTML.concat('<img src="/Images/Weather/').concat(vImg1).concat('" class="img-weather" alt="" />');
	if(vImg2!=null) sHTML = sHTML.concat('<img src="/Images/Weather/').concat(vImg2).concat('" class="img-weather" alt="" />');
	if(vImg3!=null) sHTML = sHTML.concat('<img src="/Images/Weather/').concat(vImg3).concat('" class="img-weather" alt="" />');
	if(vImg4!=null) sHTML = sHTML.concat('<img src="/Images/Weather/').concat(vImg4).concat('" class="img-weather" alt="" />');
	if(vImg5!=null) sHTML = sHTML.concat('<img src="/Images/Weather/').concat(vImg5).concat('" class="img-weather" alt="" />');
	sHTML = sHTML.concat('<img src="/Images/Weather/c.gif" class="img-weather" alt="" />');
	
	gmobj('img-Do').innerHTML = sHTML;
	gmobj('txt-Weather').innerHTML = vWeather;
}

function ShowGoldPrice(){
	var sHTML = '';
	sHTML = sHTML.concat('<table border="0px" cellpadding="2px" cellspacing="1px" class="tbl-goldprice">');
	sHTML = sHTML.concat('	<tr>');
	sHTML = sHTML.concat('		<td class="td-weather-title">Mua</td>');
	sHTML = sHTML.concat('		<td class="td-weather-data txtr">').concat(vGoldBuy).concat('</td>');
	sHTML = sHTML.concat('	</tr>');
	sHTML = sHTML.concat('	<tr>');
	sHTML = sHTML.concat('		<td class="td-weather-title">B&#225;n</td>');
	sHTML = sHTML.concat('		<td class="td-weather-data txtr">').concat(vGoldSell).concat('</td>');
	sHTML = sHTML.concat('	</tr>');
	sHTML = sHTML.concat('</table>');
	gmobj('eGold').innerHTML = sHTML;
}

function ShowForexRate(){
	var sHTML = '';
	sHTML = sHTML.concat('<table border="0px" cellpadding="2px" cellspacing="1px" class="tbl-weather">');
	for(var i=0;i<vForexs.length;i++){
		sHTML = sHTML.concat('	<tr>');
		sHTML = sHTML.concat('		<td class="td-weather-title">').concat(vForexs[i]).concat('</td>');
		sHTML = sHTML.concat('		<td class="td-weather-data txtr">').concat(vCosts[i]).concat('</td>');
		sHTML = sHTML.concat('	</tr>');
	}
	sHTML = sHTML.concat('</table>');
	gmobj('eForex').innerHTML = sHTML;
}

function showlistitem(sTemplate,sFolder,sListItems){		
	var sId, sName, sPath;
	var arItem = new Array();	
	var sLink = '';
	if(DOMESTIC_IP==0) {
		sLink = '/ListFile/Subject/'.concat(Right(Hexa(PAGE_SITE),2)).concat('/sd_').concat(sFolder).concat('.xml');
	}
	else {
		sLink = '/ListFile/Subject/'.concat(Right(Hexa(PAGE_SITE),2)).concat('/so_').concat(sFolder).concat('.xml');
	}
	
	var sHTML;
	var iMaxItem;
	iMaxItem = sListItems;		
	AjaxRequest.get(
		{
	    'url':sLink
	    ,'onSuccess':function(req){			
	    	if (req.responseXML.getElementsByTagName('F').length>0){				
	    		with(req.responseXML.getElementsByTagName('F').item(0)){
					sId = getNodeValue(getElementsByTagName('I'));
					sName = toUpper(getNodeValue(getElementsByTagName('N')));
					sPath = getNodeValue(getElementsByTagName('P'));					
	    		}
	    	}
	    	var iCount=0;
	    	for (var i=0;i<req.responseXML.getElementsByTagName('I').length;i++){
	    		with(req.responseXML.getElementsByTagName('I').item(i)){
	    			if (iCount<iMaxItem){
		    			var sTemp = getNodeValue(getElementsByTagName('I'));
		    			if (sTemp!='' && displayid(sTemp)){
			    			arItem[iCount] = new Array(19);
							arItem[iCount][0] = getNodeValue(getElementsByTagName('I'));
							arItem[iCount][1] = getNodeValue(getElementsByTagName('P')) + '/';
							arItem[iCount][2] = getNodeValue(getElementsByTagName('T'));
							arItem[iCount][3] = getNodeValue(getElementsByTagName('L'));
							arItem[iCount][4] = getNodeValue(getElementsByTagName('TI'));
							arItem[iCount][5] = getNodeValue(getElementsByTagName('TW'));
							arItem[iCount][6] = getNodeValue(getElementsByTagName('TH'));
							arItem[iCount][7] = getNodeValue(getElementsByTagName('SI'));
							arItem[iCount][8] = getNodeValue(getElementsByTagName('SW'));
							arItem[iCount][9] = getNodeValue(getElementsByTagName('SH'));
							arItem[iCount][10] = getNodeValue(getElementsByTagName('LI'));
							arItem[iCount][11] = getNodeValue(getElementsByTagName('LW'));
							arItem[iCount][12] = getNodeValue(getElementsByTagName('LH'));
							arItem[iCount][13] = getNodeValue(getElementsByTagName('HV'));
							arItem[iCount][14] = getNodeValue(getElementsByTagName('HI'));
							arItem[iCount][15] = getNodeValue(getElementsByTagName('HS'));	
							arItem[iCount][16] = getNodeValue(getElementsByTagName('OI'));
							arItem[iCount][17] = getNodeValue(getElementsByTagName('OW'));
							arItem[iCount][18] = getNodeValue(getElementsByTagName('OH'));
							iCount++;
						}
					}
	    		}
	    	}	
			sHTML = getlistitem(sId, sName, sPath, arItem, sTemplate);					
			gmobj('ListItem'.concat(sFolder)).innerHTML=sHTML;			
	    }
	    ,'onError':function(req){
			gmobj('ListItem'.concat(sFolder)).innerHTML=req.statusText;			
			}
		}
	)
}

function getlistitem(sId, sName, sPath, arItem, sTemplate) {	
	var sHTML = '';
	var i=0;
	switch (parseInt(sTemplate)) {
		case 1:			
			while (i<arItem.length) {
				if(i==0){
					sHTML = sHTML.concat('<div class="list-item1-content fl">');
					if(arItem[i][7] != ''){
						sHTML = sHTML.concat('	<a href="').concat(arItem[i][1]).concat('"><img class="fl" src="').concat(getimages(arItem[i][0],arItem[i][7])).concat('" alt="" /></a>');
					}
					sHTML = sHTML.concat('	<p><a class="link-listitem1-title" href="').concat(arItem[i][1]).concat('">').concat(arItem[i][2]).concat('</a></p>');
					sHTML = sHTML.concat('	<p>').concat(arItem[i][3].replace(/class=Lead/ig,'class=Lead2')).concat('</p>');
					sHTML = sHTML.concat('</div>');
				}
				else if(i==1) {
					sHTML = sHTML.concat('<div class="list-item1-content fl"><hr /></div>');
					sHTML = sHTML.concat('<div class="list-item1-content fl">');
					sHTML = sHTML.concat('	<ul>');
					sHTML = sHTML.concat('		<li><a class="link-listitem1-othernews" href="').concat(arItem[i][1]).concat('">').concat(arItem[i][2]).concat('</a></li>');
				}
				else if(i!=arItem.length-1){
					sHTML = sHTML.concat('		<li><a class="link-listitem1-othernews" href="').concat(arItem[i][1]).concat('">').concat(arItem[i][2]).concat('</a></li>');
				}
				else {
					sHTML = sHTML.concat('		<li><a class="link-listitem1-othernews" href="').concat(arItem[i][1]).concat('">').concat(arItem[i][2]).concat('</a></li>');
					sHTML = sHTML.concat('	</ul>');
					sHTML = sHTML.concat('</div>');
				}				
				i++;
			}
			sHTML = sHTML.concat('</div>');
			break;
		case 2: case 6:
			sHTML = sHTML.concat('<ul>');
			while (i<arItem.length) {
				sHTML = sHTML.concat('	<li><a class="link-othernews2" href="').concat(arItem[i][1]).concat('">').concat(arItem[i][2]).concat('</a></li>');
				i++;
			}
			sHTML = sHTML.concat('</ul>');
			break;
		case 3: case 4:
			while (i<arItem.length) {
				if(i==0){	
					sHTML = sHTML.concat('<div class="box-middle1 list-item fl">');
					if(arItem[0][7] != '') {
						sHTML = sHTML.concat('<a href="').concat(arItem[0][1]).concat('" ><img class="img-listitem3 fl" src="').concat(getimages(arItem[0][0],arItem[0][7])).concat('" alt="" /></a>');	
					}
					else if(arItem[0][10] != '') {
						sHTML = sHTML.concat('<a href="').concat(arItem[0][1]).concat('" ><img class="img-listitem3 fl" src="').concat(getimages(arItem[0][0],arItem[0][10])).concat('" alt="" /></a>');	
					}
					sHTML = sHTML.concat('<p><a class="link-title" href="').concat(arItem[0][1]).concat('">').concat(arItem[0][2]).concat('</a></p>');
					sHTML = sHTML.concat('<p>').concat(arItem[0][3].replace(/class=Lead/ig,'class=Lead1')).concat('</p>');
					sHTML = sHTML.concat('</div>');
				}
				else if(i==1){
					sHTML = sHTML.concat('<div class="box-middle1 list-item3 fl">');
					sHTML = sHTML.concat('	<ul>');
					sHTML = sHTML.concat('		<li><a class="link-othernews2" href="').concat(arItem[i][1]).concat('">').concat(arItem[i][2]).concat('</a></li>');
				}
				else if(i!=arItem.length-1){
					sHTML = sHTML.concat('		<li><a class="link-othernews2" href="').concat(arItem[i][1]).concat('">').concat(arItem[i][2]).concat('</a></li>');
					
				}
				else{
					sHTML = sHTML.concat('		<li><a class="link-othernews2" href="').concat(arItem[i][1]).concat('">').concat(arItem[i][2]).concat('</a></li>');
					sHTML = sHTML.concat('	</ul>');
					sHTML = sHTML.concat('</div>');					
				}
				i++;
			}
			break;
		case 5:			
			var iCount = 0;
			while (i<arItem.length) {
				if((iCount == 0) && (i < arItem.length -1)) {
					sHTML = sHTML.concat('<div class="box-middle1 list-item5 fl">');
					sHTML = sHTML.concat('	<div class="list-item5-content fl">');
					if(arItem[i][10] != ''){
						sHTML = sHTML.concat('		<a href="').concat(arItem[i][1]).concat('"><img src="').concat(getimages(arItem[i][0],arItem[i][10])).concat('" class="fl" alt=""/></a>');
					}
					sHTML = sHTML.concat('		<a href="').concat(arItem[i][1]).concat('">').concat(arItem[i][2]).concat('</a>');
					sHTML = sHTML.concat('	</div>');
					sHTML = sHTML.concat('	<img class="img-sep-listitem5 fl" src="/Images/Background/sep-listitem5.gif" alt="" />');
					iCount = 1;
				}
				else if((iCount == 0) && (i == arItem.length-1)) {
					sHTML = sHTML.concat('<div class="box-middle1 list-item5 fl">');
					sHTML = sHTML.concat('	<div class="list-item5-content fl">');
					if(arItem[i][10] != ''){
						sHTML = sHTML.concat('		<a href="').concat(arItem[i][1]).concat('"><img src="').concat(getimages(arItem[i][0],arItem[i][10])).concat('" class="fl" alt=""/></a>');
					}
					sHTML = sHTML.concat('		<a href="').concat(arItem[i][1]).concat('">').concat(arItem[i][2]).concat('</a>');
					sHTML = sHTML.concat('	</div>');
					sHTML = sHTML.concat('	<img class="img-sep-listitem5 fl" src="/Images/Background/sep-listitem5.gif" alt="" />');
					sHTML = sHTML.concat('</div>');					
				}
				else if(iCount == 1) {
					sHTML = sHTML.concat('	<div class="list-item5-content fl">');
					if(arItem[i][10] != ''){
						sHTML = sHTML.concat('		<a href="').concat(arItem[i][1]).concat('"><img src="').concat(getimages(arItem[i][0],arItem[i][10])).concat('" class="fl" alt=""/></a>');
					}
					sHTML = sHTML.concat('		<a href="').concat(arItem[i][1]).concat('">').concat(arItem[i][2]).concat('</a>');
					sHTML = sHTML.concat('	</div>');
					sHTML = sHTML.concat('</div>');
					iCount = 0;
				}
				i++;
			}
			break;
		default: break;
	}
	return sHTML;
}

function showhotitem(sFolder,sListItems) {
	var sId, sName, sPath;
	var arItem = new Array();
	sLink = '';
	if(DOMESTIC_IP==0) {
		sLink = '/ListFile/HotNews/'.concat(Right(Hexa(PAGE_SITE),2)).concat('/sd_').concat(sFolder).concat('.xml');
	}
	else {
		sLink = '/ListFile/HotNews/'.concat(Right(Hexa(PAGE_SITE),2)).concat('/so_').concat(sFolder).concat('.xml');
	}
	
	var sHTML;
	var iMaxItem;
	iMaxItem = sListItems;		
	AjaxRequest.get(
		{
	    'url':sLink
	    ,'onSuccess':function(req){			
	    	if (req.responseXML.getElementsByTagName('F').length>0){				
	    		with(req.responseXML.getElementsByTagName('F').item(0)){
					sId = getNodeValue(getElementsByTagName('I'));
					sName = toUpper(getNodeValue(getElementsByTagName('N')));
					sPath = getNodeValue(getElementsByTagName('P'));					
	    		}
	    	}
	    	var iCount=0;
	    	for (var i=0;i<req.responseXML.getElementsByTagName('I').length;i++){
	    		with(req.responseXML.getElementsByTagName('I').item(i)){
	    			if (iCount<iMaxItem){
		    			var sTemp = getNodeValue(getElementsByTagName('I'));
		    			if (sTemp!='' && displayid(sTemp)){
			    			arItem[iCount] = new Array(19);
							arItem[iCount][0] = getNodeValue(getElementsByTagName('I'));
							arItem[iCount][1] = getNodeValue(getElementsByTagName('P')) + '/';
							arItem[iCount][2] = getNodeValue(getElementsByTagName('T'));
							arItem[iCount][3] = getNodeValue(getElementsByTagName('L'));
							arItem[iCount][4] = getNodeValue(getElementsByTagName('TI'));
							arItem[iCount][5] = getNodeValue(getElementsByTagName('TW'));
							arItem[iCount][6] = getNodeValue(getElementsByTagName('TH'));
							arItem[iCount][7] = getNodeValue(getElementsByTagName('SI'));
							arItem[iCount][8] = getNodeValue(getElementsByTagName('SW'));
							arItem[iCount][9] = getNodeValue(getElementsByTagName('SH'));
							arItem[iCount][10] = getNodeValue(getElementsByTagName('LI'));
							arItem[iCount][11] = getNodeValue(getElementsByTagName('LW'));
							arItem[iCount][12] = getNodeValue(getElementsByTagName('LH'));
							arItem[iCount][13] = getNodeValue(getElementsByTagName('HV'));
							arItem[iCount][14] = getNodeValue(getElementsByTagName('HI'));
							arItem[iCount][15] = getNodeValue(getElementsByTagName('HS'));
							arItem[iCount][16] = getNodeValue(getElementsByTagName('OI'));
							arItem[iCount][17] = getNodeValue(getElementsByTagName('OW'));
							arItem[iCount][18] = getNodeValue(getElementsByTagName('OH'));
							iCount++;
						}
					}
	    		}
	    	}	    	
			sHTML = gethotitem(sId, sName, sPath, arItem);
			gmobj('HotItem'+sFolder).innerHTML=sHTML;						
	    }
	    ,'onError':function(req){
			gmobj('HotItem'.concat(sFolder)).innerHTML=req.statusText;			
			}
		}
	)
}

function gethotitem(sId, sName, sPath, arItem) {
	var sHTML = '';		
	sHTML = getlistitem(sId, sName, sPath, arItem, 5);
	return sHTML;
}
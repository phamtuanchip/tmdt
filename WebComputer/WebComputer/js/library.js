var fDSp=(typeof(document.getElementById)!='undefined');
if (typeof(PageHost) == 'undefined') var PageHost = '';

function AddHeader(Name, Header, Buttons, Symbol, AddChildTable)
{
	document.writeln('<table width="100%" border=0 cellspacing=0 cellpadding=1 ><tr><td>');

	if (Header!='')
	{
		document.writeln('<table width="100%" border=0 cellspacing=0 cellpadding=0>');
		document.writeln('<tr>');

		if (typeof(Symbol)!='undefined')
		{
			document.writeln('<td height=16 class=BoxHeader><img src="', Symbol, '" border=0></td>');
		}

		document.writeln('<td height=16 width="100%" align=left class=BoxHeader>&nbsp;', Header, '</td>');

		if ((Buttons & 1) && fDSp)
		{
			document.write('<td width=15 align=right style=padding-right:5px;>');
			document.write('<a href="javascript:ItemMinimize(\x27', Name, '\x27)">');
			document.write('<img src="Service/max.gif" name="IDI_', Name, '" border=0 alt="Minimize | Maximize">');
			document.write('</a></td>');
		}

		document.writeln('</tr></table>');
	}

	//document.writeln('<table width="100%" border=0 cellspacing=0 cellpadding=0 id="tIDM_', Name, '"><tr><td><div class=BreakLine id="IDM_', Name, '">');
	document.writeln('<table width="100%" border=0 cellspacing=0 cellpadding=0><tr><td id="IDM_', Name, '" style="display:none;">');
	if (typeof(AddChildTable)=='undefined')
	{
		document.writeln('<table align=center width="100%" cellspacing=0 cellpadding=0 border=0 class=fontNormal>');
		LastChild = 1;
	}
	else
	{
		LastChild = 0;
	}
	
	return true;
}

function AddFooter()
{
	if (LastChild)
	{
		document.writeln('<tr bgcolor="#EEEFF1"><td colspan=2 class=nguonVNEXthoitiet align=center height="22"><i>(Nguồn: Vnexpress )</td></tr>');
		document.writeln('</table></td></tr></table></td></tr></table>');
		/*document.writeln('</table>');
	<!--document.writeln('</div>');-->
	document.writeln('</td></tr>');
	document.writeln('<tr bgcolor="#FEEAD5"><td colspan=1 class=nguonVNEX align=center height="22"><i>(Nguồn: VNexpress)</td></tr>');
	document.writeln('</table>');
	document.writeln('</td></tr></table>');*/
	/*document.writeln('</td></tr></table>');*/
		
	}
	else
	{
		document.writeln('<tr bgcolor="#FEEAD5"><td colspan=2 class=nguonVNEXthoitiet align=center height="22"><i>(Nguồn: Ngân hàng ngoại thương )</td></tr>');
		document.writeln('</td></tr></table></td></tr></table>');

	}
}
function AddForexHeader(Name, Header, Buttons, Symbol, AddChildTable)
{
	document.writeln('<table width="100%" border=0 cellspacing=0 cellpadding=1><tr><td>');

	if (Header!='')
	{
		document.writeln('<table width="100%" border=0 cellspacing=0 cellpadding=0>');
		document.writeln('<tr>');

		if (typeof(Symbol)!='undefined')
		{
			document.writeln('<td height=16 class=BoxHeader><img src="', Symbol, '" border=0></td>');
		}

		document.writeln('<td height=16 width="100%" align=left class=BoxHeader>&nbsp;', Header, '</td>');

		if ((Buttons & 1) && fDSp)
		{
			document.write('<td width=15 align=right style=padding-right:5px;>');
			document.write('<a href="javascript:ItemMinimize(\x27', Name, '\x27)">');
			document.write('<img src="Service/max.gif" name="IDI_', Name, '" border=0 alt="Minimize | Maximize">');
			document.write('</a></td>');
		}

		document.writeln('</tr></table>');
	}

	document.writeln('<table width="100%" border=0 cellspacing=0 cellpadding=0><tr><td id="IDM_', Name, '" style="display:none;">');
	document.writeln('<table width="100%" border=0 cellspacing=0 cellpadding=0><tr><td>');
	if (typeof(AddChildTable)=='undefined')
	{
		<!--document.writeln('<div style="position:related; overflow-y: scroll;height:82;width:100%;">');-->
		document.writeln('<table align=center width="100%" cellspacing=0 cellpadding=0 border=0 class=styleTygia>');
		
		LastChild = 1;
	}
	else
	{
		LastChild = 0;
	}
	return true;
}
function AddForexHeader2(Name, Header, Buttons, Symbol, AddChildTable)
{
	document.writeln('<table width="100%" border=0 cellspacing=0 cellpadding=1><tr><td>');

	if (Header!='')
	{
		document.writeln('<table width="100%" border=0 cellspacing=0 cellpadding=0>');
		document.writeln('<tr>');

		if (typeof(Symbol)!='undefined')
		{
			document.writeln('<td height=16 class=BoxHeader><img src="', Symbol, '" border=0></td>');
		}

		document.writeln('<td height=16 width="100%" align=left class=BoxHeader>&nbsp;', Header, '</td>');

		if ((Buttons & 1) && fDSp)
		{
			document.write('<td width=15 align=right style=padding-right:5px;>');
			document.write('<a href="javascript:ItemMinimize(\x27', Name, '\x27)">');
			document.write('<img src="Service/min.gif" name="IDI_', Name, '" border=0 alt="Minimize | Maximize">');
			document.write('</a></td>');
		}

		document.writeln('</tr></table>');
	}

	document.writeln('<table width="100%" border=0 cellspacing=0 cellpadding=0><tr><td id="IDM_', Name, '" style="display:block;">');
	document.writeln('<table width="100%" border=0 cellspacing=0 cellpadding=0><tr><td>');
	if (typeof(AddChildTable)=='undefined')
	{
		<!--document.writeln('<div style="position:related; overflow-y: scroll;height:82;width:100%;">');-->
		document.writeln('<table align=center width="100%" cellspacing=0 cellpadding=0 border=0 class=styleTygia>');
		
		LastChild = 1;
	}
	else
	{
		LastChild = 0;
	}
	return true;
}
function AddForexFooter()
{
	document.writeln('</table>');
	<!--document.writeln('</div>');-->
	document.writeln('</td></tr>');
	document.writeln('<tr bgcolor="#FEEAD5"><td colspan=1 class=nguonVNEX align=center height="22"><i>(Nguồn: Ngân hàng Ngoại thương VN)</td></tr>');
	document.writeln('</table>');
	document.writeln('</td></tr></table>');
	document.writeln('</td></tr></table>');
}

function ItemMinimize(Name)
{
	if (!fDSp)
	{
		return;
	}

	var MItem=document.getElementById('IDM_'.concat(Name));
	var Image=document.getElementById('IDI_'.concat(Name));
	
	if (MItem.style.display!='')
	{
		//MItem.setAttribute('style','display:""');
		MItem.style.display='';
		Image.src='Service/min.gif';
	}
	else
	{
		//MItem.setAttribute('style','display:none');
		MItem.style.display='none';
		Image.src='Service/max.gif';
	}
}

function Trim(iStr)
{
	while (iStr.charCodeAt(0) <= 32)
	{
		iStr=iStr.substr(1);
	}

	while (iStr.charCodeAt(iStr.length - 1) <= 32)
	{
		iStr=iStr.substr(0, iStr.length - 1);
	}

	return iStr;
}

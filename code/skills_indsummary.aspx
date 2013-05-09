<%@ Register TagPrefix="uc1" TagName="SmfIndSummaryView" Src="SmfIndSummaryView.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SmfTopNavButtons" Src="SmfTopNavButtons.ascx" %>
<%@ Page language="c#" Codebehind="skills_indsummary.aspx.cs" AutoEventWireup="false" Inherits="SmfRewriteProject.skills_indsummary" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Individual Summary</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="skills_stylesheet.css" type="text/css" rel="stylesheet">
		<base target="_self">
		<LINK href="../js/skills_stylesheet.css" type="text/css" rel="Stylesheet">
		<LINK href="../js/css.aspx" type="text/css" rel="Stylesheet">
		<LINK href="../js/msdn.css" type="text/css" rel="Stylesheet">
		<LINK href="../js/mag.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body bottomMargin="0" bgColor="#ffffcc" leftMargin="0" topMargin="0" rightMargin="0"
		onload="javascript:window.scrollTo(0,0)">
		<div id="skills">
			<form id="Form1" method="post" runat="server">
				<center>
					<!--					<table width="javascript: screen.width" style="WIDTH: 711px; HEIGHT: 30px"> -->
					<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" bgColor="#ffffff" border="0">
						<TR>
							<TD vAlign="middle" noWrap align="center" bgColor="#ffffcc" colSpan="2">
								<TABLE id="Table4" style="WIDTH: 710px; BORDER-COLLAPSE: collapse; HEIGHT: 80px" borderColor="black"
									cellSpacing="0" cellPadding="4" width="710" border="0">
									<TR>
										<TD class="pagetitle" noWrap align="right" width="100%" bgColor="#ffffcc" colSpan="2">
											<uc1:SmfTopNavButtons id="SmfTopNavButtons1" runat="server"></uc1:SmfTopNavButtons></TD>
									</TR>
									<TR>
										<TD class="pagetitle" noWrap align="center" width="100%" bgColor="#ffffcc" colSpan="2">
											<HR SIZE="2">
											<FONT face="Verdana" color="#003399" size="4"><STRONG>Individual Summary</STRONG></FONT>
											<HR>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
					</TABLE>
					<table class="editform" border="0">
						<tr>
							<td class="editform" align="center">
								<uc1:SmfIndSummaryView id="SmfIndSummaryView1" runat="server"></uc1:SmfIndSummaryView>
							</td>
						</tr>
						<tr>
							<td class="editform" align="center" colSpan="2">
								<asp:LinkButton id="lbBack" runat="server">Back</asp:LinkButton></td>
						</tr>
					</table>
				</center>
		</div>
		</TD></TR></TABLE></FORM>
		<DIV></DIV>
	</body>
</HTML>

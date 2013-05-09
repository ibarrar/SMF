<%@ Register TagPrefix="uc1" TagName="SmfTopNavButtons" Src="SmfTopNavButtons.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SmfReportTab" Src="SmfReportTab.ascx" %>
<%@ Page language="c#" Codebehind="skills_repvisa.aspx.cs" AutoEventWireup="True" Inherits="SmfRewriteProject.skills_repvisa" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>My Skills</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="skills_stylesheet.css" type="text/css" rel="stylesheet">
		<script lang="javascript">
			//This function opens a modeless window
			function openName(aWindow){
				window.showModelessDialog(aWindow,window,'dialogWidth:765px;dialogHeight:400px;scroll:yes;edge:sunken;status:no;resizable:no;help:no;center:yes');
			}
		</script>
	</HEAD>
	<body bgColor="#ffffcc">
		<div id="skills">
			<form id="Form1" method="post" runat="server">
				<center></A>&nbsp;
					<table height="24" cellSpacing="0" cellPadding="0" width="80%" bgColor="#ffffff">
						<tr>
							<td vAlign="middle" noWrap align="right"><br>
								<uc1:SmfTopNavButtons id="SmfTopNavButtons1" runat="server"></uc1:SmfTopNavButtons>
								<br>
							</td>
						</tr>
					</table>
				</center>
				<CENTER>
					<uc1:SmfReportTab id="SmfReportTab1" tabactive="3" runat="server"></uc1:SmfReportTab></CENTER>
				<CENTER>&nbsp;</CENTER>
				<center>
					<table cellSpacing="0" cellPadding="0" width="80%" align="center">
						<TR>
							<td class="pagetitle" noWrap align="center" colSpan="2">
								<hr>
								Employee Travel Documentation
								<hr>
								<br>
								<br>
								<br>
							</td>
						</TR>
					</table>
				</center>
				<CENTER>
					<table class="simsearch" width="80%" align="center">
						<tr>
							<td align="right" width="500">
								<P align="center"><br>
									<span class="searchnote">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Search 
										Name:</span>&nbsp;&nbsp;&nbsp;
									<asp:textbox id="txtSearchName" runat="server"></asp:textbox>&nbsp;&nbsp;&nbsp;
									<asp:button id="btnSearch" runat="server" Text="Go" onclick="btnSearch_Click"></asp:button>&nbsp;
								</P>
							</td>
						</tr>
					</table>
				</CENTER>
				<CENTER>&nbsp;</CENTER>
				<center>&nbsp;</center>
				<center>&nbsp;
					<table width="80%">
						<TBODY>
							<TR>
								<TD>
									<asp:label id="lblNameList" runat="server"></asp:label>&nbsp;
								</TD>
							</TR>
							<TR>
								<TD align="right"></TD>
							</TR>
							<TR>
								<TD><asp:datagrid id="dgResults" runat="server" OnPageIndexChanged="dgResults_PageIndexChanged" width="100%"
										AlternatingItemStyle-CssClass="alternatingItem" CssClass="result" onselectedindexchanged="dgResults_SelectedIndexChanged">
										<AlternatingItemStyle CssClass="alternatingItem"></AlternatingItemStyle>
									</asp:datagrid></TD>
							</TR>
						</TBODY>
					</table>
				</center>
				<center>
					<table>
						<tr>
							<td>
								<asp:LinkButton id="lViewAll" runat="server" onclick="lViewAll_Click">ViewAll</asp:LinkButton></td>
							<td>
								<asp:LinkButton id="LinkButton1" runat="server" onclick="LinkButton1_Click">ExtractExcel</asp:LinkButton></td>
							<td>
								<asp:LinkButton id="hBack" runat="server" onclick="hBack_Click">Back</asp:LinkButton></td>
						</tr>
					</table>
				</center>
				<CENTER>
					<asp:Label id="lblExcel" runat="server"></asp:Label></CENTER>
			</form>
		</div>
	</body>
</HTML>

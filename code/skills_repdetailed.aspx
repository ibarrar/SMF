<%@ Register TagPrefix="uc1" TagName="SmfTopNavButtons" Src="SmfTopNavButtons.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SmfReportTab" Src="SmfReportTab.ascx" %>
<%@ Page language="c#" Codebehind="skills_repdetailed.aspx.cs" AutoEventWireup="false" Inherits="SmfRewriteProject.skills_repdetailed" %>
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
				<center>
					.
					<table height="24" cellSpacing="0" cellPadding="0" width="80%" bgColor="#ffffff">
						<tr>
							<td vAlign="middle" noWrap align="right"><br>
								<uc1:smftopnavbuttons id="SmfTopNavButtons1" runat="server" TabActive="2"></uc1:smftopnavbuttons><br>
							</td>
						</tr>
					</table>
				</center>
				<center>
					<uc1:smfreporttab id="tabReport" runat="server"></uc1:smfreporttab>
				</center>
				<center>
					<table cellSpacing="0" cellPadding="0" width="80%" border="0">
						<TR>
							<td class="pagetitle" noWrap align="center" colSpan="2">
								<hr>
								<asp:Label id="lblRepType" runat="server"></asp:Label>
								Skills Detailed Report
								<hr>
								<br>
								<br>
								<br>
							</td>
						</TR>
					</table>
				</center>
				<center>
					<table class="simsearch">
						<tr>
							<td align="right" width="500"><br>
								<span class="searchnote">Search Name:</span>&nbsp;&nbsp;&nbsp;
								<asp:textbox id="txtSearchName" runat="server"></asp:textbox>&nbsp;&nbsp;&nbsp;
								<asp:button id="btnSearch" runat="server" Text="Go"></asp:button>&nbsp;
							</td>
							<td vAlign="top" align="left" width="300"><br>
								<asp:LinkButton CssClass="asearch" id="lnkAdvanceSearch" runat="server">Advanced Search</asp:LinkButton>
							</td>
						</tr>
					</table>
				</center>
				<center>
					<table id="Result" cellSpacing="0" cellPadding="0" width="80%" bgColor="#ffffff" border="0">
						<tr>
							<td vAlign="bottom" width="30%" colSpan="3" height="50"><br>
								<span class="legend"><b>Legend:</b><br>
									<li>
										<b>&nbsp;&nbsp;&nbsp;&nbsp;1 - <i>&nbsp;&nbsp;Novice</i></b>
									- Trained; Understands and applies basic concepts
									<li>
										<b>&nbsp;&nbsp;&nbsp;&nbsp;2 - <i>&nbsp;&nbsp;Intermediate</i></b>
									- Understands and applies more advanced concepts
									<li>
										<b>&nbsp;&nbsp;&nbsp;&nbsp;3 - <i>&nbsp;&nbsp;Expert</i></b>
									- Sought out for deep expertise </span></LI>
							</td>
						</tr>
					</table>
				</center>
				<center>
					<table cellSpacing="0" cellPadding="0" width="80%" bgColor="#ffffff" border="1">
						<tr>
							<td></td>
						</tr>
					</table>
				</center>
				<center>&nbsp;
					<table>
						<TBODY>
							<TR>
								<TD style="HEIGHT: 17px" align="center">
									<asp:Label id="lblNameList" runat="server"></asp:Label>
								</TD>
							</TR>
							<TR>
								<TD align="right" bgcolor="white"><asp:placeholder id="plcLink" runat="server"></asp:placeholder></TD>
							</TR>
							<TR>
								<TD>
									<asp:datagrid id="dgResults" runat="server" AlternatingItemStyle-CssClass="alternatingItem" HeaderStyle-CssClass="tableHeader"
										OnPageIndexChanged="dgResults_PageIndexChanged" BorderWidth="0px" BorderColor="Black" BackColor="White"
										CellSpacing="1" AllowPaging="True" width="100%" CellPadding="4" BorderStyle="None">
										<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
										<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
										<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="White" HorizontalAlign="Center"></ItemStyle>
										<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
											ForeColor="Black" VerticalAlign="Middle" BackColor="LightSkyBlue"></HeaderStyle>
										<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
									</asp:datagrid></TD>
							</TR>
						</TBODY>
					</table>
				</center>
				<center>
					<table>
						<tr>
							<td>
								<asp:LinkButton id="lnkViewAll" runat="server">View All</asp:LinkButton></td>
							<td><asp:linkbutton id="lnkExtractExcel" runat="server">Extract Excel</asp:linkbutton></td>
							<td><asp:linkbutton id="lnkBack" runat="server">Back</asp:linkbutton></td>
							<td width="20%"></td>
							<td align="right"><asp:dropdownlist id="dropTeamList" runat="server" Width="220px" Font-Size="10pt" AutoPostBack="True"></asp:dropdownlist></td>
						</tr>
						<tr>
							<td colSpan="2" align="center"><asp:label id="lblExcel" runat="server"></asp:label></td>
						</tr>
					</table>
				</center>
			</form>
		</div>
	</body>
</HTML>

<%@ Page language="c#" Codebehind="EmpCatalogue.aspx.cs" AutoEventWireup="True" Inherits="SmfRewriteProject.EmpCatalogue" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SkillsRepDetailed</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Report.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="frmSearchInfo" name="frmSearchInfo" runat="server">
			<center>
				<table height="24" cellSpacing="0" cellPadding="0" width="80%" bgColor="#ffffff">
					<tr>
						<td vAlign="middle" noWrap align="right"><br>
							<A class="simple" href="skills_menu.pl?txtLoginID=test123#SkillsMenu"><IMG style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none"
									height="30" alt="Skills Home" src="../Images/skills_home.gif" width="30"><span align="top">Skills 
									Home</span></A>&nbsp;&nbsp; <A class="simple" href="skills_login.pl?Login=1&amp;Logout=1">
								<IMG style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none"
									height="30" alt="Sign out" src="../Images/skills_logout.gif" width="24">Sign 
								Out</A>
							<br>
							<br>
						</td>
					</tr>
				</table>
			</center>
			<center>
				<table cellSpacing="0" cellPadding="0" width="80%">
					<TR>
						<td class="pagetitle" noWrap align="center" colSpan="2">
							<hr>
							Employee&nbsp;Catalogue
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
							<asp:button id="btnSearch" runat="server" Text="Go" onclick="btnSearch_Click"></asp:button>&nbsp;
						</td>
						<td vAlign="top" align="left" width="300"><br>
							<A class="asearch" href="javascript: submitForm('skills_advancedsearch.pl')">Advanced 
								Search</A>
						</td>
					</tr>
				</table>
			</center>
			<center>
				<table id="Result" cellSpacing="0" cellPadding="0" width="80%" bgColor="#ffffff" border="1">
					<tr>
						<td vAlign="bottom" width="30%" colSpan="3" height="50"><span class="legend">
								<P>
							</span>&nbsp;</P></td>
					</tr>
				</table>
			</center>
			<center>
				<table cellSpacing="0" cellPadding="0" width="80%" bgColor="#ffffff" border="1">
					<tr>
						<td><span class="resultnotes">List of employees from
								<asp:label id="lblFromName" runat="server"></asp:label>&nbsp; to
								<asp:label id="lblToName" runat="server"></asp:label>(<b><asp:label id="lblCount" runat="server"></asp:label></b>
								<asp:label id="lblEntry" runat="server"></asp:label>)
								<br>
							</span>
						</td>
					</tr>
				</table>
			</center>
			<center><asp:datagrid id="dgResults" runat="server" AlternatingItemStyle-BackColor="#cccccc" ItemStyle-CssClass="tableItem"
					HeaderStyle-CssClass="tableHeader" OnPageIndexChanged="dgResults_PageIndexChanged" PagerStyle-Position="Bottom"
					PagerStyle-HorizontalAlign="Center" PagerStyle-Mode="NextPrev" PageSize="10" AllowSorting="True"
					AllowPaging="True" CellPadding="0" BorderWidth="1" Width="80%" onselectedindexchanged="dgResults_SelectedIndexChanged"></asp:datagrid></center>
			<center>
				<table>
					<tr>
						<td>Extract Excel</td>
						<td>Back</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>

<%@ Page language="c#" Codebehind="SkillsRepSummary.aspx.cs" AutoEventWireup="True" Inherits="SmfRewriteProject.SkillsRepSummary" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SkillsRepSummary</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link rel="stylesheet" href="Report.css" type="text/css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form name="frmSearchInfo" runat="server" ID="frmSearchInfo">
			<center>
				<asp:DataGrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 280px; POSITION: absolute; TOP: 400px"
					runat="server"></asp:DataGrid>
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
							Skills&nbsp;Summary Report
							<hr>
							<br>
							<br>
							<br>
						</td>
					</TR>
				</table>
			</center>
			<center>
			</center>
			<center>
			</center>
			<center>
			</center>
			<center>
				<asp:datagrid id="dgResults" runat="server" AlternatingItemStyle-BackColor="#cccccc" ItemStyle-CssClass="tableItem"
					HeaderStyle-CssClass="tableHeader" PagerStyle-Position="Bottom" PagerStyle-HorizontalAlign="Center"
					CellPadding="0" BorderWidth="1" Width="467px"></asp:datagrid>
			</center>
			<center>
				<table>
					<tr>
						<td style="WIDTH: 137px">Extract Excel</td>
						<td>Back</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>

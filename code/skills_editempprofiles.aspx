<%@ Page language="c#" Codebehind="skills_editempprofiles.aspx.cs" AutoEventWireup="True" Inherits="SmfRewriteProject.skills_editempprofiles" %>
<%@ Register TagPrefix="cc1" Namespace="SmfRewriteProject" Assembly="SmfRewriteProject" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Edit Employee Profile</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="skills_stylesheet.css" type="text/css" rel="stylesheet">
		<base target="_self">
	</HEAD>
	<body bottomMargin="0" bgColor="#ffffcc" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="WIDTH: 296px; HEIGHT: 32px" cellSpacing="0" cellPadding="0" border="0">
				<TR>
					<TD align="center" width="100%" bgColor="gainsboro" height="25%"><FONT class="infoexample" face="Book Antiqua" size="2"><STRONG>Edit 
								Profile of </STRONG>&nbsp;
							<asp:label id="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="X-Small"
								Font-Names="Book Antiqua">Unknown</asp:label></FONT></TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" style="WIDTH: 296px; HEIGHT: 88px" cellSpacing="0" cellPadding="0" border="0">
				<TR>
					<TD width="25%" bgColor="lemonchiffon"><FONT face="Book Antiqua" size="2">&nbsp;<STRONG>&nbsp; 
								Access:</STRONG></FONT></TD>
					<TD width="75%" bgColor="lemonchiffon"><asp:radiobutton id="RadioButton1" runat="server" Font-Size="X-Small" Font-Names="Book Antiqua" Text="Limited"
							GroupName="Access"></asp:radiobutton>&nbsp;<asp:radiobutton id="RadioButton2" runat="server" Font-Size="X-Small" Font-Names="Book Antiqua" Text="Supervisor"
							GroupName="Access"></asp:radiobutton>
						<asp:RadioButton id="RadioButton5" runat="server" Font-Names="Book Antiqua" Font-Size="X-Small" GroupName="Access"
							Text="Administrator"></asp:RadioButton></TD>
				</TR>
				<TR>
					<TD width="25%" bgColor="lemonchiffon"><FONT face="Book Antiqua" size="2"><STRONG>&nbsp;&nbsp; 
								Status:</STRONG></FONT></TD>
					<TD width="75%" bgColor="lemonchiffon"><asp:radiobutton id="RadioButton3" runat="server" Font-Size="X-Small" Font-Names="Book Antiqua" Text="Active"
							GroupName="Status"></asp:radiobutton>&nbsp;&nbsp;
						<asp:radiobutton id="RadioButton4" runat="server" Font-Size="X-Small" Font-Names="Book Antiqua" Text="Inactive"
							GroupName="Status"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD width="25%" bgColor="lemonchiffon"><STRONG><FONT face="Book Antiqua" size="2">&nbsp;&nbsp; 
								Password:</FONT></STRONG></TD>
					<TD align="center" width="75%" bgColor="lemonchiffon"><cc1:confirmlinkbutton id="ResetPassword" runat="server" ForeColor="Blue" PopupMessage="This will reset the password of the employee.  Are you sure you want to continue?" onclick="ResetPassword_Click">Click here to Reset Password</cc1:confirmlinkbutton>&nbsp;&nbsp;
						<cc1:confirmlinkbutton id="ResetAllEmployees" runat="server" ForeColor="Blue" PopupMessage="This will reset all employee passwords. Are you sure you want to continue?"
							Visible="False" onclick="ResetAllEmployees_Click">Reset All Employee Passwords</cc1:confirmlinkbutton></TD>
				</TR>
			</TABLE>
			<TABLE id="Table3" style="WIDTH: 296px; HEIGHT: 40px" cellSpacing="0" cellPadding="0" border="0">
				<TR>
					<TD align="center" width="100%" bgColor="gainsboro" height="25%"><asp:button id="Save" runat="server" Text="Save" CommandName="Save" Width="63px" onclick="Save_Click"></asp:button>&nbsp;
						<cc1:confirmbutton id="Delete" runat="server" Text="Delete" PopupMessage="This will delete this employee record permenantly.  Are you sure you want to continue?"
							CommandName="Delete" Width="63px" onclick="Delete_Click"></cc1:confirmbutton>&nbsp;
						<asp:button id="Cancel" runat="server" Text="Cancel" Width="63px" onclick="Cancel_Click"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>

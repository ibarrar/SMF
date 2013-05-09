<%@ Page language="c#" Codebehind="error.aspx.cs" AutoEventWireup="True" Inherits="MVCArch.error" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>error</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" href="skills_stylesheet.css">
	</HEAD>
	<body>
		<div id="skills">
			<form id="Form1" method="post" runat="server">
				Error occured during the operation, sorry for the inconvenience.<br>
				Please contact:
				<asp:Label ID="lbSiteAdminName" Runat="server" /><br>
				Phone:
				<asp:Label ID="lbPhone" Runat="server" /><br>
				Email:
				<asp:HyperLink id="hlEmail" runat="server"></asp:HyperLink>
			</form>
		</div>
	</body>
</HTML>

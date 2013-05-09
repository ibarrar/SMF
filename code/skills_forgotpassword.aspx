<%@ Page language="c#" Codebehind="skills_forgotpassword.aspx.cs" AutoEventWireup="True" Inherits="SmfRewriteProject.skills_forgotpassword" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>skills_forgotpassword</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body style="BACKGROUND-COLOR: #ffffcc" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center style="BACKGROUND-IMAGE: none; BACKGROUND-COLOR: #ffffcc">
				<table style="WIDTH: 640px; HEIGHT: 160px" cellSpacing="0" cellPadding="0" width="640">
					<TR>
						<TD class="pagetitle" style="WIDTH: 714px; HEIGHT: 82px" noWrap align="center" colSpan="2">
							<P>&nbsp;</P>
							<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="18pt" Font-Bold="True"
									ForeColor="Desktop">Forgot Password?</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD class="pagetitle" style="WIDTH: 714px" noWrap align="center" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="pagetitle" style="WIDTH: 714px" noWrap align="center" colSpan="2"></TD>
					</TR>
					<TR>
						<td class="pagetitle" style="WIDTH: 714px" noWrap align="center" colSpan="2"><FONT face="Verdana" size="2">
								<P>
								<P>&nbsp;</P>
								<P>Enter Login ID:&nbsp; &nbsp;
									<asp:TextBox id="txtEmailPassword" runat="server"></asp:TextBox>&nbsp;
									<asp:Button id="btnEmailPassword" runat="server" Width="133px" Text="Email Password" onclick="btnEmailPassword_Click"></asp:Button></P>
								<P>
									<asp:Label id="lblPasswordMsg" runat="server" Visible="False">Label</asp:Label></P>
								<P>
									<asp:LinkButton id="Back" runat="server" Font-Names="Verdana" Font-Size="Small" onclick="Back_Click">Back</asp:LinkButton></P>
							</FONT>
						</td>
					</TR>
				</table>
			</center>
			<!--Table for Employee Information--></form>
		</FORM>
	</body>
</HTML>

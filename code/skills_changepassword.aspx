<%@ Register TagPrefix="uc1" TagName="SmfTopNavButtons" Src="SmfTopNavButtons.ascx" %>
<%@ Page language="c#" Codebehind="skills_changepassword.aspx.cs" AutoEventWireup="True" Inherits="SmfRewriteProject.skills_changepassword" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>skills_changepassword</title>
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
							<P>&nbsp;<uc1:smftopnavbuttons id="SmfTopNavButtons1" runat="server"></uc1:smftopnavbuttons></P>
							<P></P>
						</TD>
					</TR>
					<TR>
						<td class="pagetitle" style="WIDTH: 714px" noWrap align="center" colSpan="2">
							<P><asp:label id="Label1" runat="server" ForeColor="Desktop" Font-Bold="True" Font-Size="18pt"
									Font-Names="Verdana">Change Password</asp:label>
							<P></P>
						</td>
					</TR>
				</table>
			</center>
			<!--Table for Employee Information-->
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" bgColor="#ffffff" border="0">
				<tr>
					<td style="BACKGROUND-COLOR: #ffffcc" vAlign="top" align="center" colSpan="2"><form name="frmLoginInfo" method="POST" action="skills_changepswd.pl" onSubmit="return checkFields()">
							<table class="editform" style="BORDER-COLLAPSE: collapse" borderColor="black" cellSpacing="2"
								cellPadding="4" width="500" bgColor="#eeeeee" border="0">
								<tr>
									<td style="COLOR: #ffffff; BACKGROUND-COLOR: #336699" noWrap align="left" width="500"
										colSpan="2"><b>Instruction:</b>
										<br>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To change your password, please 
										enter the following information<br>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;and click [Save].
									</td>
								</tr>
								<tr>
									<td align="center" colSpan="2">
										<table class="editform" style="BORDER-COLLAPSE: collapse" cellSpacing="2" cellPadding="4"
											width="400" border="0">
											<tr>
												<td align="left" width="200"><span class="infofield">&nbsp;<FONT face="Verdana" size="2"><STRONG>&nbsp;Login 
																ID:</STRONG></FONT> </span>
												</td>
												<td align="left">&nbsp;
													<asp:label id="lblLoginID" runat="server" Width="104px"></asp:label></td>
											</tr>
											<tr>
												<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Employee 
																ID:</STRONG></FONT> </span>
												</td>
												<td align="left"><span class="infoentry">&nbsp;
														<asp:label id="lblEmpID" runat="server" Width="104px"></asp:label></span></td>
											</tr>
											<tr>
												<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Current 
																Password:</STRONG></FONT> </span>
												</td>
												<td noWrap><asp:textbox id="txtCurrPassword" runat="server" Width="116px" TextMode="Password"></asp:textbox></td>
											</tr>
											<tr>
												<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>New 
																Password:</STRONG></FONT> </span>
												</td>
												<td noWrap><asp:textbox id="txtNewPassword" runat="server" Width="116px" TextMode="Password"></asp:textbox>&nbsp;&nbsp;<span class="infoexample">(minimum 
														of 6 characters)</span>
												</td>
											</tr>
											<tr>
												<td noWrap align="left" width="200"><span class="infofield">&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Re-enter 
																New Password:</STRONG></FONT> </span>
												</td>
												<td noWrap><asp:textbox id="txtNewPassword2" runat="server" Width="116px" TextMode="Password"></asp:textbox>&nbsp;&nbsp;<span class="infoexample">(minimum 
														of 6 characters)</span>
												</td>
											</tr>
										</table>
										<asp:label id="lblError" runat="server" Width="435px" ForeColor="Red"></asp:label></td>
								</tr>
								<tr>
									<td style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FONT-WEIGHT: bold; PADDING-BOTTOM: 5px; WIDTH: 100%; COLOR: #ffffff; PADDING-TOP: 5px; BACKGROUND-COLOR: #eeeeee"
										align="center" colSpan="2"><br>
										&nbsp;&nbsp;&nbsp;
										<asp:button id="Button1" runat="server" Width="84px" Text="Save" onclick="Button1_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:button id="Button2" runat="server" Width="84px" Text="Cancel" onclick="Button2_Click"></asp:button><br>
										<br>
									</td>
								</tr>
							</table>
						</form>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

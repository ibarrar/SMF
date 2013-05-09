<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="True" Inherits="SmfRewriteProject._default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Skills Management Facility</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link type="text/css" rel="stylesheet" href="skills_stylesheet.css">
	</HEAD>
	<body bgColor="#ffffcc">
		<div id="skills">
			<form id="Form1" method="post" runat="server">
				<TABLE border="0" id="Table1" width="100%" cellpadding="0" cellspacing="0">
					<TBODY>
						<TR>
							<TD align="center" valign="top">
								<TABLE border="0" id="Table2" cellSpacing="0" cellPadding="0" width="550">
									<TR>
										<TD height="50" colSpan="2"></TD>
									</TR>
									<TR>
										<TD vAlign="middle" align="right"><IMG height="80" src="Images/skills_main.gif" width="100"></TD>
										<TD id="SkillsMenu" vAlign="middle" noWrap align="center">
											<SPAN class="pagetitle">Skills Management Facility</SPAN><BR>
											<SPAN class="notes">(Product Development Team)</SPAN><BR>
										</TD>
									</TR>
								</TABLE>
							</TD>
						<tr>
							<td align="center" valign="top">
								<TABLE height="409" cellSpacing="0" cellPadding="0" width="859" border="0">
									<TBODY>
										<TR>
											<TD align="center" colSpan="2">
												<BR>
												<asp:Label id="lblError" runat="server" ForeColor="Red"></asp:Label>
												<BR>
												<BR>
												<TABLE borderColor="black" cellSpacing="0" cellPadding="4" width="325" bgColor="lightgrey"
													border="0">
													<TR>
														<TD align="left" bgColor="navy" colSpan="2" height="20"></TD>
													</TR>
													<TR>
														<TD class="editform" align="center" colSpan="2">
															<TABLE class="editform" id="Table5" style="BORDER-COLLAPSE: collapse" cellSpacing="2" cellPadding="4"
																width="100%" border="0">
																<TR>
																	<TD colSpan="2" height="20"></TD>
																</TR>
																<TR>
																	<TD width="100"><SPAN style="FONT-WEIGHT: bold; FONT-FAMILY: verdana">&nbsp;&nbsp;Login 
																			ID: </SPAN>
																	</TD>
																	<TD align="right"><asp:textbox id="txtLoginID" runat="server" Width="154px"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD width="100"><SPAN style="FONT-WEIGHT: bold; FONT-FAMILY: verdana">&nbsp;&nbsp;Password:
																		</SPAN>
																	</TD>
																	<TD align="right"><asp:textbox id="txtPassword" runat="server" TextMode="Password" Width="154px"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD align="center" colSpan="2" valign="middle">
																		<asp:button id="bLogin" Text="Sign In" Runat="server" onclick="bLogin_Click"></asp:button>&nbsp;
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD align="center" colSpan="2"><BR>
												<TABLE id="Table6" cellSpacing="0" cellPadding="10" width="325" border="0">
													<TR>
														<TD vAlign="top" noWrap><asp:linkbutton id="lbNewUser" Runat="server" onclick="lbNewUser_Click">New User</asp:linkbutton></TD>
														<TD>Register your information to get your SMF account.</TD>
													</TR>
													<TR>
														<TD vAlign="top"><asp:linkbutton id="lbForgotYourPassword" Runat="server" onclick="lbForgotYourPassword_Click">Forgot your password?</asp:linkbutton></TD>
														<TD>Click this link if you forgot your password.</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TBODY>
								</TABLE>
							</td>
						</tr>
					</TBODY>
				</TABLE>
			</form>
		</div>
	</body>
</HTML>

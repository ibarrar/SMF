<%@ Page language="c#" Codebehind="skills_myprofile.aspx.cs" AutoEventWireup="false" Inherits="SmfRewriteProject.skills_myprofile" %>
<%@ Register TagPrefix="uc1" TagName="SmfTopNavButtons" Src="SmfTopNavButtons.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Enter Page Title Here</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="skills_stylesheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bgColor="#ffffcc">
		<div id="skills">
			<form id="Form1" method="post" runat="server">
				&nbsp;
				<table style="WIDTH: 736px; HEIGHT: 87px" cellSpacing="0" cellPadding="0" width="736" align="center">
					<TR>
						<td class="pagetitle" style="HEIGHT: 139px" noWrap align="center" colSpan="2">
							<TABLE id="Table1" style="WIDTH: 752px; HEIGHT: 32px" cellSpacing="1" cellPadding="1" width="752"
								border="1">
							</TABLE>
							<uc1:smftopnavbuttons id="SmfTopNavButtons1" runat="server"></uc1:smftopnavbuttons><br>
							<P align="center"><asp:label id="Label1" runat="server" ForeColor="Desktop" Font-Size="18pt" Font-Names="Verdana">My Profile</asp:label></P>
						</td>
					</TR>
					<TR>
						<TD class="pagetitle" noWrap align="center" colSpan="2"></TD>
					</TR>
				</table>
				<!--Table for Employee Information-->
				<table style="WIDTH: 752px; HEIGHT: 1026px" cellSpacing="0" cellPadding="0" width="752"
					align="center" bgColor="#ffffff" border="0">
					<tr>
						<td style="WIDTH: 984px" vAlign="top" align="center" colSpan="2">
							<DIV align="center">
								<table style="BORDER-COLLAPSE: collapse" borderColor="black" cellSpacing="0" cellPadding="4"
									width="750" align="left" bgColor="#eeeeee" border="0">
									<tr>
										<td style="WIDTH: 670px" align="right" bgColor="#336699" colSpan="2">
											<P align="right"><A class="control" href="javascript: window.location='skills_myprofile.pl?txtLoginID=ismaelc&amp;pagemode=Edit'"></A><asp:linkbutton id="lbEditProfile" runat="server" ForeColor="White">Edit My Profile</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:linkbutton id="lbChangePassword" runat="server" ForeColor="White">Change Password</asp:linkbutton>&nbsp;&nbsp;
											</P>
										</td>
									</tr>
									<tr class="editform">
										<td class="editform" style="WIDTH: 671px" align="center" colSpan="2">
											<DIV align="center">
												<TABLE class="editform" style="BORDER-COLLAPSE: collapse" cellSpacing="2" cellPadding="4"
													width="100%" align="center" border="0">
													<TR>
														<TD style="WIDTH: 555px" align="left" colSpan="2">
															<HR>
															<span class="infotitle">&nbsp;&nbsp;<FONT size="2">Login Information</FONT> </span>
															<hr>
														</TD>
													</TR>
													<tr>
														<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Login 
																	ID:</FONT> </span>
														</td>
														<td style="WIDTH: 232px" align="left"><span class="infoentry"><asp:label id="lblLoginID" runat="server" Width="88px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Employee 
																	ID:</FONT> </span>
														</td>
														<td style="WIDTH: 232px" align="left"><span class="infoentry"><asp:label id="lblEmpID" runat="server" Width="64px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Office:</FONT>
															</span>
														</td>
														<td style="WIDTH: 232px" align="left"><span class="infoentry"><asp:label id="lblOffice" runat="server" Width="183px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Date 
																	Last Modified:</FONT> </span>
														</td>
														<td style="WIDTH: 232px" align="left"><span class="infoentry"><asp:label id="lblLastDateMod" runat="server" Width="161px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td style="WIDTH: 555px" align="left" colSpan="2">
															<hr>
															<span class="infotitle">&nbsp;&nbsp;<FONT size="2">Personal Profile</FONT> </span>
															<hr>
														</td>
													</tr>
													<tr>
														<td style="HEIGHT: 20px" align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Employee 
																	Name:</FONT> </span>
														</td>
														<td style="WIDTH: 232px; HEIGHT: 20px" align="left"><span class="infoentry"><asp:label id="lblEmpName" runat="server" Width="335px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Current 
																	Team/Role:</FONT> </span>
														</td>
														<td style="WIDTH: 232px" align="left"><span class="infoentry"><asp:label id="lblTeam" runat="server" Width="224px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<TR>
														<TD align="left" width="200">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2"><STRONG>Sub-Team:</STRONG></FONT>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														</TD>
														<TD style="WIDTH: 232px" align="left">
															<asp:Label id="lblSubTeam" runat="server">[lblSubTeam]</asp:Label></TD>
													</TR>
													<tr>
														<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Navitaire 
																	Start Date:</FONT> </span>
														</td>
														<td style="WIDTH: 232px" align="left"><span class="infoentry"><asp:label id="lblNavDate" runat="server" Width="160px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Nick 
																	Name:</FONT> </span>
														</td>
														<td style="WIDTH: 232px" align="left"><span class="infoentry"><asp:label id="lblNickName" runat="server" Width="192px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Gender:</FONT>
															</span>
														</td>
														<td style="WIDTH: 232px" align="left"><span class="infoentry"><asp:label id="lblGender" runat="server" Width="176px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td align="left" width="200" style="HEIGHT: 24px"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Birthday:</FONT>
															</span>
														</td>
														<td style="WIDTH: 232px; HEIGHT: 24px" align="left"><span class="infoentry"><asp:label id="lblBday" runat="server" Width="256px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">&nbsp;Home 
																	Number:</FONT> </span>
														</td>
														<td style="WIDTH: 232px" align="left"><span class="infoentry"><asp:label id="lblHomeNum" runat="server" Width="232px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Cellphone 
																	Number:</FONT> </span>
														</td>
														<td style="WIDTH: 232px" align="left"><span class="infoentry"><asp:label id="lblCellNum" runat="server" Width="240px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Other 
																	E-mail Address:</FONT> </span>
														</td>
														<td style="WIDTH: 232px" align="left"><span class="infoentry"><asp:label id="lblOtherEmail" runat="server" Width="248px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Home 
																	Address:</FONT> </span>
														</td>
														<td style="WIDTH: 232px" align="left"><span class="infoentry"><asp:label id="lblHomeAdd" runat="server" Width="380px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td style="HEIGHT: 20px" align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">&nbsp;City:</FONT>
															</span>
														</td>
														<td style="WIDTH: 232px; HEIGHT: 20px" align="left"><span class="infoentry"><asp:label id="lblCity" runat="server" Width="200px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td style="WIDTH: 555px; HEIGHT: 61px" align="left" colSpan="2">
															<hr>
															<span class="infotitle">&nbsp;&nbsp;<FONT size="2">Undergraduate Information</FONT> </span>
															<hr>
														</td>
													</tr>
													<tr>
														<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">School:</FONT>
															</span>
														</td>
														<td align="left"><span class="infoentry"><asp:label id="lblUGSchool" runat="server" Width="322px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td style="HEIGHT: 26px" align="left"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Degree:</FONT>
															</span>
														</td>
														<td style="HEIGHT: 26px" align="left" colSpan="2"><asp:label id="lblUGDegree" runat="server" Width="73px" Font-Size="10pt" Height="13px"></asp:label>&nbsp;
															<span class="infofield">&nbsp;&nbsp;<FONT size="2">Year:</FONT>&nbsp;&nbsp; </span>
															<asp:label id="lblUGYear" runat="server" Width="78px" Font-Size="10pt"></asp:label></td>
													</tr>
													<tr>
														<td style="WIDTH: 555px; HEIGHT: 71px" align="left" colSpan="2">
															<hr>
															<span class="infotitle">&nbsp;&nbsp;<FONT size="2">Graduate Information</FONT> </span>
															<hr>
														</td>
													</tr>
													<tr>
														<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">School:</FONT>
															</span>
														</td>
														<td style="WIDTH: 232px" align="left"><span class="infoentry"><asp:label id="lblGSSchool" runat="server" Width="205px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td align="left"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Degree:</FONT>
															</span>
														</td>
														<TD align="left"><asp:label id="lblGSDegree" runat="server" Width="73px" Font-Size="10pt"></asp:label>&nbsp;&nbsp;&nbsp;
															<span class="infofield"><FONT size="2">Year:</FONT>&nbsp;&nbsp; </span>
															<asp:label id="lblGSYear" runat="server" Width="74px" Font-Size="10pt"></asp:label></TD>
													</tr>
													<tr>
														<td style="WIDTH: 555px" align="left" colSpan="2">
															<hr>
															<span class="infotitle">&nbsp;&nbsp;<FONT size="2">Passport Information</FONT> </span>
															<hr>
														</td>
													</tr>
													<tr>
														<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Passport 
																	Number:</FONT> </span>
														</td>
														<td style="WIDTH: 232px" align="left"><span class="infoentry"><asp:label id="lblPassport" runat="server" Width="236px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td style="HEIGHT: 20px" noWrap align="left" width="250"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Passport 
																	Expiration Date:</FONT> </span>
														</td>
														<td style="WIDTH: 232px; HEIGHT: 20px" align="left"><span class="infoentry"><asp:label id="lblExpDate" runat="server" Width="233px" Font-Size="10pt"></asp:label></span></td>
													</tr>
													<tr>
														<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT size="2">Valid 
																	Visa: </FONT></span>
															<br>
															<br>
														</td>
														<td style="WIDTH: 232px" align="left"><span class="infoentry"></span><asp:label id="lblVisa" runat="server" Width="380px" Font-Size="10pt"></asp:label><br>
															<br>
														</td>
													</tr>
												</TABLE>
											</DIV>
										</td>
									</tr>
									<tr>
										<td style="WIDTH: 670px" align="right" bgColor="#336699" colSpan="2">
											<P align="right"><asp:linkbutton id="lbEditProfile2" runat="server" ForeColor="White">Edit My Profile</asp:linkbutton>&nbsp;&nbsp;&nbsp; 
												&nbsp;
												<asp:linkbutton id="blChangePassword2" runat="server" ForeColor="White">Change Password</asp:linkbutton></P>
										</td>
									</tr>
									<tr>
										<td class="bgndform" style="WIDTH: 670px" align="center" colSpan="2">
											<P align="center"><br>
												<asp:linkbutton id="LinkButton1" runat="server" ForeColor="MidnightBlue" Font-Size="10pt">Back</asp:linkbutton></P>
										</td>
									</tr>
								</table>
							</DIV>
							<DIV align="left">&nbsp;</DIV>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 984px" align="center" colSpan="2">&nbsp;</td>
					</tr>
				</table>
			</form>
		</div>
	</body>
</HTML>

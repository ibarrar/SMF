<%@ Page language="c#" Codebehind="skills_menu.aspx.cs" AutoEventWireup="false" Inherits="SmfRewriteProject.skills_menu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>skills_menu</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#ffffcc">
		<form id="Form1" method="post" runat="server">
			<P align="center">
				<table cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<td style="WIDTH: 103px">
							<P align="right"><IMG height="80" src="Images/skills_main.gif" width="100">
							</P>
						</td>
						<TD vAlign="middle" noWrap align="center" colSpan="1" rowSpan="1"><FONT color="darkblue"><SPAN class="pagetitle"><FONT face="Verdana" size="6">Skills 
										Management Facility</FONT></SPAN><BR>
							</FONT><FONT face="Verdana"><FONT size="2"><FONT color="steelblue"><SPAN class="notes">(Product 
											Development Team)</SPAN><BR>
										The SMF manages and stores employee profiles, skills and
										<BR>
										product knowledge information.</FONT></FONT></FONT>
						</TD>
					</tr>
				</table>
			</P>
			<P align="center"><asp:label id="Label1" runat="server"></asp:label></P>
			<P align="center">
				<TABLE cellSpacing="0" cellPadding="0" border="0">
					<TBODY>
						<TR>
							<TD vAlign="top" style="WIDTH: 310px; HEIGHT: 598px"><asp:panel id="UserOptions" runat="server" BorderStyle="None" HorizontalAlign="Center" Height="384px">
									<TABLE class="main" id="Table2" style="WIDTH: 293px; BORDER-COLLAPSE: collapse; HEIGHT: 444px"
										borderColor="black" cellSpacing="2" cellPadding="4" border="0">
										<TR>
											<TD align="center"><IMG height="70" src="Images/skills_myown.gif" width="60">
											</TD>
											<TD><FONT face="Verdana"><FONT size="2"><SPAN class="maintitle"><FONT color="mediumblue" size="4">My 
																Own</FONT></SPAN> </FONT></FONT>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 49px" align="right" width="60"><FONT size="2">&nbsp; </FONT>
											</TD>
											<TD style="HEIGHT: 49px" vAlign="top" align="left">
												<asp:linkbutton id="lbMyProfile" style="TEXT-DECORATION: none" Runat="server">
													<FONT face="Verdana" size="2" color="steelblue"><STRONG>My Profile</STRONG></FONT></asp:linkbutton><BR>
												<FONT face="Verdana"><SPAN class="common"><FONT size="2">Update your profile</FONT></SPAN>
												</FONT>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 50px" align="right" width="60">&nbsp;
											</TD>
											<TD style="HEIGHT: 50px" vAlign="top" align="left" width="300">
												<asp:linkbutton id="lbMySkills" style="TEXT-DECORATION: none" Runat="server">
													<FONT face="Verdana" size="2" color="steelblue"><STRONG>My Skills</STRONG></FONT></asp:linkbutton><BR>
												<FONT face="Verdana"><SPAN class="common"><FONT size="2">Update your skills information</FONT></SPAN>
												</FONT>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 64px" align="right" width="60"></TD>
											<TD style="HEIGHT: 64px" vAlign="top" align="left" width="300">
												<P><FONT face="Verdana"><SPAN class="common"><FONT size="2">
																<asp:linkbutton id="lblMyCert" style="TEXT-DECORATION: none" Runat="server">
																	<FONT face="Verdana" size="2" color="steelblue"><STRONG>My Certificates</STRONG></FONT></asp:linkbutton><BR>
																<FONT face="Verdana"><SPAN class="common"><FONT size="2">Update your&nbsp;acquired 
																			certificates/licenses</FONT></SPAN> </FONT></FONT></SPAN></FONT>
												</P>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 48px" align="right" width="60">&nbsp;
											</TD>
											<TD style="HEIGHT: 48px" vAlign="top" align="left" width="400">
												<asp:linkbutton id="lbIndividualSummary" style="TEXT-DECORATION: none" Runat="server">
													<FONT face="Verdana" size="2" color="steelblue"><STRONG>Individual Summary</STRONG></FONT></asp:linkbutton><BR>
												<FONT face="Verdana"><FONT size="2"><SPAN class="common">View summary of your skills 
															information and your profile</SPAN> </FONT></FONT>
											</TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center" height="150">
												<P>&nbsp;</P>
												<P><IMG height="70" src="Images/skills_logout.gif" width="60">
												</P>
											</TD>
											<TD width="300">
												<P>
													<asp:linkbutton id="lbSignOut" style="TEXT-DECORATION: none" Runat="server">
														<FONT face="Verdana" size="4" color="mediumblue">Sign Out</FONT></asp:linkbutton><BR>
													<SPAN class="common"><FONT face="Verdana" size="2">E</FONT></SPAN><SPAN class="common"><FONT face="Verdana" size="2">xit 
															Skills Management Facility</FONT></SPAN>
												</P>
											</TD>
										</TR>
									</TABLE>
								</asp:panel></TD>
							<TD vAlign="top" style="HEIGHT: 598px"><asp:panel id="AdminOptions" runat="server" BorderStyle="None" HorizontalAlign="Center" Height="480px"
									Width="453px">
									<TABLE class="main" style="WIDTH: 417px; BORDER-COLLAPSE: collapse; HEIGHT: 428px" borderColor="black"
										cellSpacing="2" cellPadding="4" border="0">
										<TR>
											<TD style="HEIGHT: 81px" align="center"><IMG height="70" src="Images/skills_admin.gif" width="80">
											</TD>
											<TD style="HEIGHT: 81px"><FONT size="4"><FONT color="mediumblue"><SPAN class="maintitle"><FONT face="Verdana">Administrator</FONT></SPAN>
													</FONT></FONT>
											</TD>
										</TR>
										<TR id="trChangePwd" runat="server">
											<TD align="right">&nbsp;
											</TD>
											<TD vAlign="bottom" align="left" width="300">
												<P>
													<asp:LinkButton id="lbChangePassword" style="TEXT-DECORATION: none" Runat="server">
														<FONT face="Verdana" size="2" color="steelblue"><STRONG>Change Password</STRONG></FONT></asp:LinkButton><BR>
													<SPAN class="common"><FONT face="Verdana" size="2">
															<asp:Label id="lblChangeLogin" runat="server">Change login information</asp:Label></FONT></SPAN></P>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 77px" align="right">&nbsp;
											</TD>
											<TD style="HEIGHT: 77px" vAlign="bottom" align="left" width="300">
												<asp:LinkButton id="lbReports" style="TEXT-DECORATION: none" Runat="server">
													<FONT face="Verdana" size="2" color="steelblue"><STRONG>Reports</STRONG></FONT></asp:LinkButton><BR>
												<SPAN class="common"><FONT face="Verdana" size="2">View Summary and Detailed Reports 
														and Employee Travel Information</FONT></SPAN>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 80px" align="right">&nbsp;
											</TD>
											<TD style="HEIGHT: 80px" vAlign="bottom" align="left" width="300">
												<asp:LinkButton id="lbAdvancedSearch" style="TEXT-DECORATION: none" Runat="server">
													<FONT face="Verdana" size="2" color="steelblue"><STRONG>Advanced Search</STRONG></FONT></asp:LinkButton><BR>
												<SPAN class="common"><FONT face="Verdana" size="2">View employee's profile and skills 
														information using different options</FONT></SPAN>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 81px" align="right">&nbsp;
											</TD>
											<TD style="HEIGHT: 81px" vAlign="bottom" align="left" width="300">
												<asp:LinkButton id="lbSkillCodeAdmin" style="TEXT-DECORATION: none" Runat="server">
													<FONT face="Verdana" size="2" color="steelblue"><STRONG>Skill Code / Team Admin</STRONG></FONT></asp:LinkButton><BR>
												<SPAN class="common"><FONT face="Verdana" size="2">Add, update and delete skill /team 
														codes used for displaying the survey</FONT></SPAN>
											</TD>
										</TR>
										<TR>
											<TD align="right">&nbsp;
											</TD>
											<TD vAlign="bottom" align="left" width="400">
												<asp:LinkButton id="lbEmployeeCatalogue" style="TEXT-DECORATION: none" Runat="server">
													<FONT face="Verdana" size="2" color="steelblue"><STRONG>Employee Catalogue</STRONG></FONT></asp:LinkButton><BR>
												<SPAN class="common"><FONT face="Verdana" size="2">View and Search employee profiles 
														and update their login information (Level of Access, Status and Password)</FONT></SPAN>
											</TD>
										</TR>
									</TABLE>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
								</asp:panel>
								<asp:panel id="pnlSignOut" runat="server" BorderStyle="None" Width="424px" Wrap="False" HorizontalAlign="Left"
									Height="120px">
									<TABLE class="main" style="WIDTH: 402px; BORDER-COLLAPSE: collapse; HEIGHT: 102px" borderColor="black"
										cellSpacing="2" cellPadding="4" border="0">
										<TR>
											<TD vAlign="middle" align="center" height="90"><IMG height="70" src="Images/skills_logout.gif" width="60"></TD>
											<TD width="300" height="90">
												<asp:linkbutton id="lbSignOut2" style="TEXT-DECORATION: none" Runat="server">
													<FONT face="Verdana" size="4" color="mediumblue">Sign Out</FONT></asp:linkbutton><BR>
												<SPAN class="common"><FONT face="Verdana" size="2">Exit Skills Management Facility</FONT></SPAN></TD>
										</TR>
									</TABLE>
								</asp:panel></TD>
						</TR>
					</TBODY>
				</TABLE>
			</P>
		</form>
	</body>
</HTML>

<%@ Page language="c#" Codebehind="IndSummary.aspx.cs" AutoEventWireup="false" Inherits="SmfRewriteProject.IndSummary" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IndSummary</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<table width="javascript: screen.width">
			<tr>
				<td>
					<link href="../js/skills_stylesheet.css" type="text/css" rel="Stylesheet">
					<div id="skills">
						<link href="../js/msdn.css" type="text/css" rel="Stylesheet">
						<link href="../js/css.aspx" type="text/css" rel="Stylesheet">
						<link href="../js/mag.css" type="text/css" rel="Stylesheet">
						<center>
							<table class="editform" border="0">
								<tr>
									<td align="center" class="editform">
										<table class="editform" bordercolor="black" bgcolor="#eeeeee" border="0" style="BORDER-COLLAPSE: collapse"
											cellspacing="0" cellpadding="4" width="100%">
											<tr>
												<td id="EmpInfo" colspan="2" align="left" bgColor="navy" style="FONT-WEIGHT: bold; COLOR: #ffffff; BACKGROUND-COLOR: #336699">Employee 
													Information</td>
											</tr>
											<tr>
												<td width="30%" align="left">
													<span class="infofield">&nbsp;&nbsp;Employee Name </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="EmpName" runat="server"></asp:Label>&nbsp; </span>
												</td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;Office </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="Office" runat="server"></asp:Label></span></td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;Current Team/Role </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="TeamRole" runat="server"></asp:Label></span></td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;Navitaire Start Date </span>
												</td>
												<td align="left">
													<asp:Label id="Start" runat="server"></asp:Label></td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;Nick Name </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="NickName" runat="server"></asp:Label></span></td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;Gender </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="Gender" runat="server"></asp:Label></span></td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;Birthday </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="Bday" runat="server"></asp:Label>
													</span>
												</td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;Home Number </span>
												</td>
												<td align="left">
													<asp:Label id="HomeNum" runat="server"></asp:Label>
												</td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;Cellphone Number </span>
												</td>
												<td align="left">
													<asp:Label id="CellNum" runat="server"></asp:Label>
												</td>
											</tr>
											<tr>
												<td width="200" align="left" nowrap>
													<span class="infofield">&nbsp;&nbsp;Other E-mail Address </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="OtherEmail" runat="server"></asp:Label></span></td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;Home Address </span>
												</td>
												<td width="450" align="left"><span class="infoentry">
														<asp:Label id="HomeAdd" runat="server"></asp:Label></span></td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;City </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="City" runat="server"></asp:Label></span></td>
											</tr>
											<tr>
												<td colspan="2" align="left" bgColor="navy" style="FONT-WEIGHT: bold; COLOR: #ffffff; BACKGROUND-COLOR: #336699">Academic 
													Background</td>
											</tr>
											<tr>
												<td colspan="2" align="left">
													<hr>
													<span class="infotitle">&nbsp;&nbsp;Undergraduate Information </span>
													<hr>
												</td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;School </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="UGSchool" runat="server"></asp:Label></span></td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;Degree </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="UGDegree" runat="server"></asp:Label></span></td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;Year </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="UGYear" runat="server"></asp:Label></span></td>
											</tr>
											<tr>
												<td colspan="2" align="left">
													<hr>
													<span class="infotitle">&nbsp;&nbsp;Graduate Information </span>
													<hr>
												</td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;School </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="GSchool" runat="server"></asp:Label></span></td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;Degree </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="GDegree" runat="server"></asp:Label></span></td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;Year </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="GYear" runat="server"></asp:Label></span></td>
											</tr>
											<tr>
												<td colspan="2" align="left" bgColor="navy" style="FONT-WEIGHT: bold; COLOR: #ffffff; BACKGROUND-COLOR: #336699">Passport 
													Information</td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;Passport Number: </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="PassportNum" runat="server"></asp:Label></span></td>
											</tr>
											<tr>
												<td width="250" align="left" nowrap>
													<span class="infofield">&nbsp;&nbsp;Passport Expiration Date: </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="PassportExp" runat="server"></asp:Label></span></td>
											</tr>
											<tr>
												<td width="200" align="left">
													<span class="infofield">&nbsp;&nbsp;Valid Visa: </span>
												</td>
												<td align="left"><span class="infoentry">
														<asp:Label id="Visa" runat="server"></asp:Label></span></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td colspan="2" align="center" class="editform">
										<table class="editform" border="0" cellspacing="0" bgcolor="#eeeeee" cellpadding="4" width="100%">
											<tr>
												<td colspan="5" align="left" bgColor="navy" style="FONT-WEIGHT: bold; COLOR: #ffffff; BACKGROUND-COLOR: #336699">Skills 
													Information</td>
											</tr>
											<tr>
												<td id="TechInfo" colspan="5" align="left">
													<hr>
													<span class="infotitle">&nbsp;&nbsp;Technical Skills </span>
													<hr>
												</td>
											</tr>
											<tr>
												<td align="center">
													&nbsp;
												</td>
												<td align="center">
													<span class="infotitle">&nbsp;&nbsp;Level of Proficiency </span>
												</td>
												<td align="center">
													<span class="infotitle">&nbsp;&nbsp;Year Last Used<br>
														(YYYY) </span>
												</td>
												<td align="center">
													<span class="infotitle">&nbsp;&nbsp;Experience<br>
														(in years) </span>
												</td>
												<td width="3" align="center">
													&nbsp;
												</td>
											</tr>
											<tr>
												<td align="left" nowrap><span class="infofield">&nbsp;&nbsp;JAVA&nbsp;&nbsp;</span></td>
												<td align="center"><span class="infoentry">Novice</span></td>
												<td align="center"><span class="infoentry">1999</span></td>
												<td align="center"><span class="infoentry">1.0</span></td>
											</tr>
											<tr>
												<td align="left" nowrap><span class="infofield">&nbsp;&nbsp;SQL&nbsp;&nbsp;</span></td>
												<td align="center"><span class="infoentry">Novice</span></td>
												<td align="center"><span class="infoentry">1999</span></td>
												<td align="center"><span class="infoentry">1.0</span></td>
											</tr>
											<tr>
												<td align="left" nowrap><span class="infofield">&nbsp;&nbsp;Visual Basic&nbsp;&nbsp;</span></td>
												<td align="center"><span class="infoentry">Novice</span></td>
												<td align="center"><span class="infoentry">2000</span></td>
												<td align="center"><span class="infoentry">1.0</span></td>
											</tr>
											<tr>
												<td colspan="4" align="left"><span class="notes">&nbsp;&nbsp;Has additional technical 
														skill in VBSCRIPT NOVICE 2004 .5.</span></td>
											</tr>
											<tr>
												<td id="ProdInfo" colspan="5" align="left">
													<hr>
													<span class="infotitle">&nbsp;&nbsp;Product Knowledge </span>
													<hr>
												</td>
											</tr>
											<tr>
												<td align="center">
													&nbsp;
												</td>
												<td align="center">
													<span class="infotitle">&nbsp;&nbsp;Level of Proficiency </span>
												</td>
												<td align="center">
													<span class="infotitle">&nbsp;&nbsp;Year Last Used<br>
														(YYYY) </span>
												</td>
												<td align="center">
													<span class="infotitle">&nbsp;&nbsp;Experience<br>
														(in years) </span>
												</td>
												<td width="3" align="center">
													&nbsp;
												</td>
											</tr>
											<tr>
												<td align="left" nowrap><span class="infofield">&nbsp;&nbsp;Open Skies&nbsp;&nbsp;</span></td>
												<td align="center"><span class="infoentry">Intermediate</span></td>
												<td align="center"><span class="infoentry">2004</span></td>
												<td align="center"><span class="infoentry">1.0</span></td>
											</tr>
											<tr>
												<td colspan="4" align="left" class="infosubsysnote" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Has 
													intermediate experience on the following Open Skies subsystems:<br>
												</td>
											</tr>
											<tr>
												<td>&nbsp;</td>
												<td align="left" class="infosubsys">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<li type="disc">CtlEdit/CtlPanel</li></td>
												<td align="left" class="infosubsys">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<li type="disc">Data 
														Extracts/XML</li></td>
												<td align="left" class="infosubsys">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<li type="disc">Fare 
														Manager</li></td>
											</tr>
											<tr>
												<td>&nbsp;</td>
												<td align="left" class="infosubsys">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<li type="disc">Flight 
														Speed</li></td>
												<td align="left" class="infosubsys">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<li type="disc">HP3000</li></td>
												<td align="left" class="infosubsys">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<li type="disc">Reports</li></td>
											</tr>
											<tr>
												<td>&nbsp;</td>
												<td align="left" class="infosubsys">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<li type="disc">Schedule 
														Manager</li></td>
												<td align="left" class="infosubsys">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<li type="disc">Schedule 
														Planning</li></td>
												<td align="left" class="infosubsys">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<li type="disc">Skylights</li></td>
											</tr>
											<tr>
												<td align="left" nowrap><span class="infofield">&nbsp;&nbsp;PRA&nbsp;&nbsp;</span></td>
												<td align="center"><span class="infoentry">Novice</span></td>
												<td align="center"><span class="infoentry">2003</span></td>
												<td align="center"><span class="infoentry">1.0</span></td>
											</tr>
											<tr>
												<td align="left" nowrap><span class="infofield">&nbsp;&nbsp;DotRez&nbsp;&nbsp;</span></td>
												<td align="center"><span class="infoentry">Novice</span></td>
												<td align="center"><span class="infoentry">2004</span></td>
												<td align="center"><span class="infoentry">0.5</span></td>
											</tr>
											<tr>
												<td colspan="4" align="center">
													<br>
													<br>
													<br>
												</td>
											</tr>
											<tr>
												<td colspan="4" align="center">
													<br>
													<a href="javascript: window.close()" class="simple">Close</a>
												</td>
											</tr>
										</table>
								</tr>
							</table>
						</center>
					</div>
			</tr>
		</table>
	</body>
</HTML>

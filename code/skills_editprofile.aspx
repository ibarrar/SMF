<%@ Page language="c#" Codebehind="skills_editprofile.aspx.cs" AutoEventWireup="false" Inherits="SmfRewriteProject.skills_editprofile" %>
<%@ Register TagPrefix="uc1" TagName="SmfTopNavButtons" Src="SmfTopNavButtons.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>emp_edit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body style="BACKGROUND-COLOR: #ffffcc" MS_POSITIONING="GridLayout" onload="changeList(document.forms['Form1'].elements['dropTeamList'])">
		<form id="Form1" method="post" runat="server">
			<table style="WIDTH: 984px; HEIGHT: 180px" cellSpacing="0" cellPadding="0" width="984"
				align="center">
				<TR>
					<TD class="pagetitle" style="WIDTH: 1008px; HEIGHT: 32px" noWrap borderColor="#000000"
						align="center" bgColor="#ffffcc" colSpan="2">
						<P align="center">&nbsp;&nbsp;<uc1:smftopnavbuttons id="SmfTopNavButtons1" runat="server"></uc1:smftopnavbuttons></P>
					</TD>
				</TR>
				<TR>
					<td class="pagetitle" style="WIDTH: 1008px" noWrap align="center" bgColor="#ffffcc"
						colSpan="2">
						<P>
						<P>&nbsp;&nbsp;<asp:label id="Label1" runat="server" Font-Bold="True" ForeColor="Desktop" Font-Size="18pt"
								Font-Names="Verdana">Edit My Profile</asp:label></P>
						<br>
						<P>
							<table height="100%" cellSpacing="0" cellPadding="0" width="100%" bgColor="#ffffff" border="0">
								<TR>
									<TD vAlign="top" align="center" bgColor="#ffffcc" colSpan="2"><FORM name="frmEmpInfo" method="POST" action="skills_myprofile.pl" onSubmit="return checkFields()">
											<TABLE style="BORDER-COLLAPSE: collapse" borderColor="black" cellSpacing="0" cellPadding="4"
												width="75%" bgColor="#eeeeee" border="0">
												<TR>
													<TD style="COLOR: #ffffff; BACKGROUND-COLOR: #336699" align="left" bgColor="navy" colSpan="2"><B>Instruction:</B>
														<BR>
														&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To edit your profile information, please 
														enter your new information and click [Save].
														<BR>
														&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Fields followed by <SPAN style="FONT-WEIGHT: bold; COLOR: red; FONT-FAMILY: verdana">
															*</SPAN> are required.
													</TD>
												</TR>
												<TR>
													<TD class="editform" style="WIDTH: 826px" align="center" colSpan="2">
														<TABLE class="editform" style="WIDTH: 865px; BORDER-COLLAPSE: collapse; HEIGHT: 1120px"
															cellSpacing="0" cellPadding="4" width="865" border="0">
															<TBODY>
																<TR>
																	<TD align="left" colSpan="2">
																		<HR>
																		<SPAN class="infotitle">&nbsp;&nbsp;<FONT face="Verdana" color="#000099" size="2"><STRONG>Login 
																					Information</STRONG></FONT> </SPAN>
																		<HR>
																	</TD>
																</TR>
																<TR>
																	<TD align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Login 
																					ID:</STRONG></FONT> </SPAN>
																	</TD>
																	<TD align="left"><asp:label id="lblLoginID" runat="server" Font-Size="11pt" Width="96px"></asp:label>&nbsp;
																	</TD>
																</TR>
																<TR>
																	<TD align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Employee 
																					ID:</STRONG></FONT> </SPAN>
																	</TD>
																	<TD align="left"><SPAN class="infoentry"><asp:label id="lblEmpID" runat="server" Font-Size="11pt" Width="80px"></asp:label></SPAN></TD>
																</TR>
																<TR>
																	<TD style="HEIGHT: 30px" align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Office:</STRONG></FONT>
																		</SPAN>
																	</TD>
																	<TD style="HEIGHT: 30px" align="left"><asp:dropdownlist id="dropOffice" runat="server" Font-Size="11pt" Width="136px">
																			<asp:ListItem Value="Manila">Manila</asp:ListItem>
																			<asp:ListItem Value="Minneapolis">Minneapolis</asp:ListItem>
																			<asp:ListItem Value="Salt Lake City">Salt Lake City</asp:ListItem>
																			<asp:ListItem Value="Sydney">Sydney</asp:ListItem>
																			<asp:ListItem Value="Austin">Austin</asp:ListItem>
																			<asp:ListItem Value="Others">Others</asp:ListItem>
																		</asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD align="left" colSpan="2">
																		<HR>
																		<SPAN class="infotitle">&nbsp;&nbsp;<FONT face="Verdana" color="#000099" size="2"><STRONG>Personal 
																					Profile</STRONG></FONT> </SPAN>
																		<HR>
																	</TD>
																</TR>
																<TR>
																	<TD align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>&nbsp;First 
																					Name:</STRONG></FONT> </SPAN>
																	</TD>
																	<TD align="left"><SPAN style="FONT-WEIGHT: bold; COLOR: red; FONT-FAMILY: verdana"><asp:textbox id="txtFirstName" runat="server" Font-Size="11pt" Width="216px"></asp:textbox>*</SPAN>
																		<asp:requiredfieldvalidator id="rfvFirstName" runat="server" Font-Size="XX-Small" Font-Names="Verdana" Display="Dynamic"
																			ControlToValidate="txtFirstName" ErrorMessage="First Name is a required field."></asp:requiredfieldvalidator></TD>
																</TR>
																<TR>
																	<TD align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Last 
																					Name:</STRONG></FONT> </SPAN>
																	</TD>
																	<TD><SPAN style="FONT-WEIGHT: bold; COLOR: red; FONT-FAMILY: verdana"><asp:textbox id="txtLastName" runat="server" Font-Size="11pt" Width="216px"></asp:textbox>*</SPAN>
																		<asp:requiredfieldvalidator id="rfvLastName" runat="server" Font-Size="XX-Small" Font-Names="Verdana" Display="Dynamic"
																			ControlToValidate="txtLastName" ErrorMessage="Last Name is a required field."></asp:requiredfieldvalidator></TD>
																</TR>
																<TR>
																	<TD align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Current 
																					Team/Role:</STRONG></FONT> </SPAN>
																	</TD>
																	<TD noWrap><SPAN style="FONT-WEIGHT: bold; COLOR: red; FONT-FAMILY: verdana"><asp:dropdownlist id="dropTeamList" runat="server" Font-Size="11pt" Width="216px"></asp:dropdownlist>*</SPAN>&nbsp;
																		<asp:requiredfieldvalidator id="rfvPosition" runat="server" Font-Size="XX-Small" Font-Names="Verdana" Display="Dynamic"
																			ControlToValidate="dropTeamList" ErrorMessage="Team/Role is a required field."></asp:requiredfieldvalidator></TD>
																</TR>
																<TR>
																	<TD align="left" width="200">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <FONT face="Verdana" size="2">
																			<STRONG>Subteam:</STRONG></FONT>
																	</TD>
																	<TD noWrap>
																		<asp:DropDownList id="dropSubTeamList" runat="server" Width="216px"></asp:DropDownList></TD>
																</TR>
																<TR>
																	<TD noWrap align="left"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Navitaire 
																					Start Date:</STRONG></FONT> </SPAN>
																	</TD>
																	<TD colSpan="2"><asp:dropdownlist id="dropNavMonth" runat="server" Font-Size="10pt" Width="96px">
																			<asp:ListItem Value="00">Month</asp:ListItem>
																			<asp:ListItem Value="01">January</asp:ListItem>
																			<asp:ListItem Value="02">February</asp:ListItem>
																			<asp:ListItem Value="03">March</asp:ListItem>
																			<asp:ListItem Value="04">April</asp:ListItem>
																			<asp:ListItem Value="05">May</asp:ListItem>
																			<asp:ListItem Value="06">June</asp:ListItem>
																			<asp:ListItem Value="07">July</asp:ListItem>
																			<asp:ListItem Value="08">August</asp:ListItem>
																			<asp:ListItem Value="09">September</asp:ListItem>
																			<asp:ListItem Value="10">October</asp:ListItem>
																			<asp:ListItem Value="11">November</asp:ListItem>
																			<asp:ListItem Value="12">December</asp:ListItem>
																		</asp:dropdownlist>&nbsp;
																		<asp:dropdownlist id="dropNavDD" runat="server" Font-Size="10pt" Width="48px">
																			<asp:ListItem Value="Day">Day</asp:ListItem>
																			<asp:ListItem Value="1">1</asp:ListItem>
																			<asp:ListItem Value="2">2</asp:ListItem>
																			<asp:ListItem Value="3">3</asp:ListItem>
																			<asp:ListItem Value="4">4</asp:ListItem>
																			<asp:ListItem Value="5">5</asp:ListItem>
																			<asp:ListItem Value="6">6</asp:ListItem>
																			<asp:ListItem Value="7">7</asp:ListItem>
																			<asp:ListItem Value="8">8</asp:ListItem>
																			<asp:ListItem Value="9">9</asp:ListItem>
																			<asp:ListItem Value="10">10</asp:ListItem>
																			<asp:ListItem Value="11">11</asp:ListItem>
																			<asp:ListItem Value="12">12</asp:ListItem>
																			<asp:ListItem Value="13">13</asp:ListItem>
																			<asp:ListItem Value="14">14</asp:ListItem>
																			<asp:ListItem Value="15">15</asp:ListItem>
																			<asp:ListItem Value="16">16</asp:ListItem>
																			<asp:ListItem Value="17">17</asp:ListItem>
																			<asp:ListItem Value="18">18</asp:ListItem>
																			<asp:ListItem Value="19">19</asp:ListItem>
																			<asp:ListItem Value="20">20</asp:ListItem>
																			<asp:ListItem Value="21">21</asp:ListItem>
																			<asp:ListItem Value="22">22</asp:ListItem>
																			<asp:ListItem Value="23">23</asp:ListItem>
																			<asp:ListItem Value="24">24</asp:ListItem>
																			<asp:ListItem Value="25">25</asp:ListItem>
																			<asp:ListItem Value="26">26</asp:ListItem>
																			<asp:ListItem Value="27">27</asp:ListItem>
																			<asp:ListItem Value="28">28</asp:ListItem>
																			<asp:ListItem Value="29">29</asp:ListItem>
																			<asp:ListItem Value="30">30</asp:ListItem>
																			<asp:ListItem Value="31">31</asp:ListItem>
																		</asp:dropdownlist><asp:textbox id="txtNavYYYY" runat="server" Width="56px"></asp:textbox><SPAN style="FONT-WEIGHT: bold; COLOR: red; FONT-FAMILY: verdana">*</SPAN>
																		<asp:requiredfieldvalidator id="rfvNavMonth" runat="server" Font-Size="XX-Small" Font-Names="Verdana" Display="Dynamic"
																			ControlToValidate="txtNavYYYY" ErrorMessage="Start Date is a required field."></asp:requiredfieldvalidator></TD>
																</TR>
																<TR>
																	<TD align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Nick 
																					Name:</STRONG></FONT> </SPAN>
																	</TD>
																	<TD align="left"><SPAN style="FONT-WEIGHT: normal; COLOR: red; FONT-FAMILY: verdana"><asp:textbox id="txtNickName" runat="server" Width="216px"></asp:textbox>*&nbsp;
																			<asp:requiredfieldvalidator id="rfvNickName" runat="server" Font-Size="XX-Small" Font-Names="Verdana" Display="Dynamic"
																				ControlToValidate="txtNickName" ErrorMessage="Nickname is  a required field."></asp:requiredfieldvalidator></SPAN></TD>
													</TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 53px" align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Gender:</STRONG></FONT>
														</SPAN>
													</TD>
													<TD style="HEIGHT: 53px" align="left"><SPAN class="infoentry"><LABEL><asp:radiobuttonlist id="radlstGender" runat="server" Width="96px" RepeatDirection="Horizontal">
																	<asp:ListItem Value="M">Male</asp:ListItem>
																	<asp:ListItem Value="F">Female</asp:ListItem>
																</asp:radiobuttonlist></LABEL></SPAN></TD>
												</TR>
												<TR>
													<TD align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>&nbsp;Birthday:</STRONG></FONT>
														</SPAN>
													</TD>
													<TD colSpan="2"><asp:dropdownlist id="dropBdayMonth" runat="server" Font-Size="10pt" Width="96px">
															<asp:ListItem Value="00">Month</asp:ListItem>
															<asp:ListItem Value="01">January</asp:ListItem>
															<asp:ListItem Value="02">February</asp:ListItem>
															<asp:ListItem Value="03">March</asp:ListItem>
															<asp:ListItem Value="04">April</asp:ListItem>
															<asp:ListItem Value="05">May</asp:ListItem>
															<asp:ListItem Value="06">June</asp:ListItem>
															<asp:ListItem Value="07">July</asp:ListItem>
															<asp:ListItem Value="08">August</asp:ListItem>
															<asp:ListItem Value="09">September</asp:ListItem>
															<asp:ListItem Value="10">October</asp:ListItem>
															<asp:ListItem Value="11">November</asp:ListItem>
															<asp:ListItem Value="12">December</asp:ListItem>
														</asp:dropdownlist>&nbsp;
														<asp:dropdownlist id="dropBdayDD" runat="server" Width="48px">
															<asp:ListItem Value="Day">Day</asp:ListItem>
															<asp:ListItem Value="1">1</asp:ListItem>
															<asp:ListItem Value="2">2</asp:ListItem>
															<asp:ListItem Value="3">3</asp:ListItem>
															<asp:ListItem Value="4">4</asp:ListItem>
															<asp:ListItem Value="5">5</asp:ListItem>
															<asp:ListItem Value="6">6</asp:ListItem>
															<asp:ListItem Value="7">7</asp:ListItem>
															<asp:ListItem Value="8">8</asp:ListItem>
															<asp:ListItem Value="9">9</asp:ListItem>
															<asp:ListItem Value="10">10</asp:ListItem>
															<asp:ListItem Value="11">11</asp:ListItem>
															<asp:ListItem Value="12">12</asp:ListItem>
															<asp:ListItem Value="13">13</asp:ListItem>
															<asp:ListItem Value="14">14</asp:ListItem>
															<asp:ListItem Value="15">15</asp:ListItem>
															<asp:ListItem Value="16">16</asp:ListItem>
															<asp:ListItem Value="17">17</asp:ListItem>
															<asp:ListItem Value="18">18</asp:ListItem>
															<asp:ListItem Value="19">19</asp:ListItem>
															<asp:ListItem Value="20">20</asp:ListItem>
															<asp:ListItem Value="21">21</asp:ListItem>
															<asp:ListItem Value="22">22</asp:ListItem>
															<asp:ListItem Value="23">23</asp:ListItem>
															<asp:ListItem Value="24">24</asp:ListItem>
															<asp:ListItem Value="25">25</asp:ListItem>
															<asp:ListItem Value="26">26</asp:ListItem>
															<asp:ListItem Value="27">27</asp:ListItem>
															<asp:ListItem Value="28">28</asp:ListItem>
															<asp:ListItem Value="29">29</asp:ListItem>
															<asp:ListItem Value="30">30</asp:ListItem>
															<asp:ListItem Value="31">31</asp:ListItem>
														</asp:dropdownlist>&nbsp;
														<asp:textbox id="txtBdayYYYY" runat="server" Width="56px"></asp:textbox>&nbsp;</TD>
												</TR>
												<TR>
													<TD noWrap align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Home 
																	Number:</STRONG></FONT> </SPAN>
													</TD>
													<TD><SPAN style="FONT-WEIGHT: bold; COLOR: red; FONT-FAMILY: verdana"><asp:textbox id="txtHomeNum" runat="server" Font-Size="10pt"></asp:textbox>*</SPAN>
														&nbsp;&nbsp; <SPAN class="infoexample">(ex. 630495557777)</SPAN>
														<asp:requiredfieldvalidator id="rfvHomeNum" runat="server" Font-Size="XX-Small" Font-Names="Verdana" Display="Dynamic"
															ControlToValidate="txtHomeNum" ErrorMessage="Home number is a required field."></asp:requiredfieldvalidator></TD>
												</TR>
												<TR>
													<TD align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Cellphone 
																	Number:</STRONG></FONT> </SPAN>
													</TD>
													<TD align="left" colSpan="2"><SPAN style="FONT-WEIGHT: bold; COLOR: red; FONT-FAMILY: verdana"><asp:textbox id="txtCellNum" runat="server" Font-Size="10pt"></asp:textbox>*</SPAN>
														&nbsp;&nbsp; <SPAN class="infoexample">(ex. 639208889999)</SPAN>
														<asp:requiredfieldvalidator id="rfvCellNum" runat="server" Font-Size="XX-Small" Font-Names="Verdana" Display="Dynamic"
															ControlToValidate="txtCellNum" ErrorMessage="Cellphone number is a required field."></asp:requiredfieldvalidator></TD>
												</TR>
												<TR>
													<TD noWrap align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Other 
																	E-mail Address:</STRONG></FONT> </SPAN>
													</TD>
													<TD><asp:textbox id="txtOtherEmail" runat="server" Width="296px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Home 
																	Address:</STRONG></FONT> </SPAN>
													</TD>
													<TD colSpan="2"><SPAN style="FONT-WEIGHT: bold; COLOR: red; FONT-FAMILY: verdana"><asp:textbox id="txtHomeAdd" runat="server" Width="416px"></asp:textbox>*</SPAN>
														<asp:requiredfieldvalidator id="rfvAddressSt" runat="server" Font-Size="XX-Small" Font-Names="Verdana" Display="Dynamic"
															ControlToValidate="txtHomeAdd" ErrorMessage="Home address is a required field."></asp:requiredfieldvalidator></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 31px" noWrap align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>City:</STRONG></FONT>
														</SPAN>
													</TD>
													<TD style="HEIGHT: 31px"><SPAN style="FONT-WEIGHT: bold; COLOR: red; FONT-FAMILY: verdana"><asp:textbox id="txtHomeCity" runat="server" Width="152px"></asp:textbox>*</SPAN>
														<asp:requiredfieldvalidator id="rfvAddressCity" runat="server" Font-Size="XX-Small" Font-Names="Verdana" Display="Dynamic"
															ControlToValidate="txtHomeCity" ErrorMessage="City is a required field."></asp:requiredfieldvalidator></TD>
												</TR>
												<TR>
													<TD align="left" colSpan="2">
														<HR>
														<SPAN style="FONT-WEIGHT: bold; COLOR: navy; FONT-FAMILY: verdana">&nbsp;&nbsp;<FONT size="2">Undergraduate 
																Information</FONT> </SPAN>
														<HR>
													</TD>
												</TR>
												<TR>
													<TD align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>&nbsp;School:</STRONG></FONT>
														</SPAN>
													</TD>
													<TD align="left"><SPAN style="FONT-WEIGHT: normal; COLOR: red; FONT-FAMILY: verdana"><asp:textbox id="txtUGSchool" runat="server" Width="344px"></asp:textbox>*&nbsp;
															<asp:requiredfieldvalidator id="rfvUGSchool" runat="server" Font-Size="XX-Small" Font-Names="Verdana" Display="Dynamic"
																ControlToValidate="txtUGSchool" ErrorMessage="School is a required field."></asp:requiredfieldvalidator></SPAN></TD>
												</TR>
												<TR>
													<TD align="left"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<STRONG><FONT face="Verdana" size="2">Degree:</FONT></STRONG>
														</SPAN>
													</TD>
													<TD align="left" colSpan="2"><SPAN style="FONT-WEIGHT: bold; COLOR: red; FONT-FAMILY: verdana"><asp:textbox id="txtUGDegree" runat="server"></asp:textbox>*</SPAN>
														<SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Year:</STRONG></FONT>
															<asp:textbox id="txtUGYear" runat="server" Width="72px"></asp:textbox></SPAN><SPAN style="FONT-WEIGHT: normal; COLOR: red; FONT-FAMILY: verdana">*
															<asp:requiredfieldvalidator id="rfvUGDegree" runat="server" Font-Size="XX-Small" Font-Names="Verdana" Display="Dynamic"
																ControlToValidate="txtUGDegree" ErrorMessage="Degree is a required field."></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="rfvUGYear" runat="server" Font-Size="XX-Small" Font-Names="Verdana" Display="Dynamic"
																ControlToValidate="txtUGYear" ErrorMessage="Year is a required field."></asp:requiredfieldvalidator></SPAN></TD>
												</TR>
												<TR>
													<TD align="left" colSpan="2">
														<HR>
														<SPAN class="infotitle">&nbsp;&nbsp;<FONT face="Verdana" color="#000099" size="2"><STRONG>Graduate 
																	Information</STRONG></FONT> </SPAN>
														<HR>
													</TD>
												</TR>
												<TR>
													<TD align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>School:</STRONG></FONT>
														</SPAN>
													</TD>
													<TD align="left"><asp:textbox id="txtGSSchool" runat="server" Width="344px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD align="left"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Degree:</STRONG></FONT>
														</SPAN>
													</TD>
													<TD align="left" colSpan="2"><asp:textbox id="txtGSDegree" runat="server"></asp:textbox><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
															<FONT face="Verdana" size="2"><STRONG>Year:</STRONG></FONT>&nbsp; </SPAN>
														<asp:textbox id="txtGSYear" runat="server" Width="72px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD align="left" colSpan="2">
														<HR>
														<SPAN style="FONT-WEIGHT: bold; COLOR: navy; FONT-FAMILY: verdana">&nbsp;&nbsp;<FONT size="2">Passport 
																Information</FONT> </SPAN>
														<HR>
													</TD>
												</TR>
												<TR>
													<TD align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Passport 
																	Number:</STRONG></FONT> </SPAN>
													</TD>
													<TD align="left"><asp:textbox id="txtPassportNum" runat="server" Width="216px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD noWrap align="left"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Passport 
																	Expiration Date:</STRONG></FONT> </SPAN>
													</TD>
													<TD colSpan="2"><asp:dropdownlist id="dropPassportMonth" runat="server" Width="96px">
															<asp:ListItem Value="00">Month</asp:ListItem>
															<asp:ListItem Value="01">January</asp:ListItem>
															<asp:ListItem Value="02">February</asp:ListItem>
															<asp:ListItem Value="03">March</asp:ListItem>
															<asp:ListItem Value="04">April</asp:ListItem>
															<asp:ListItem Value="05">May</asp:ListItem>
															<asp:ListItem Value="06">June</asp:ListItem>
															<asp:ListItem Value="07">July</asp:ListItem>
															<asp:ListItem Value="08">August</asp:ListItem>
															<asp:ListItem Value="09">September</asp:ListItem>
															<asp:ListItem Value="10">October</asp:ListItem>
															<asp:ListItem Value="11">November</asp:ListItem>
															<asp:ListItem Value="12">December</asp:ListItem>
														</asp:dropdownlist>&nbsp;
														<asp:dropdownlist id="dropPassportDD" runat="server" Width="48px">
															<asp:ListItem Value="Day">Day</asp:ListItem>
															<asp:ListItem Value="1">1</asp:ListItem>
															<asp:ListItem Value="2">2</asp:ListItem>
															<asp:ListItem Value="3">3</asp:ListItem>
															<asp:ListItem Value="4">4</asp:ListItem>
															<asp:ListItem Value="5">5</asp:ListItem>
															<asp:ListItem Value="6">6</asp:ListItem>
															<asp:ListItem Value="7">7</asp:ListItem>
															<asp:ListItem Value="8">8</asp:ListItem>
															<asp:ListItem Value="9">9</asp:ListItem>
															<asp:ListItem Value="10">10</asp:ListItem>
															<asp:ListItem Value="11">11</asp:ListItem>
															<asp:ListItem Value="12">12</asp:ListItem>
															<asp:ListItem Value="13">13</asp:ListItem>
															<asp:ListItem Value="14">14</asp:ListItem>
															<asp:ListItem Value="15">15</asp:ListItem>
															<asp:ListItem Value="16">16</asp:ListItem>
															<asp:ListItem Value="17">17</asp:ListItem>
															<asp:ListItem Value="18">18</asp:ListItem>
															<asp:ListItem Value="19">19</asp:ListItem>
															<asp:ListItem Value="20">20</asp:ListItem>
															<asp:ListItem Value="21">21</asp:ListItem>
															<asp:ListItem Value="22">22</asp:ListItem>
															<asp:ListItem Value="23">23</asp:ListItem>
															<asp:ListItem Value="24">24</asp:ListItem>
															<asp:ListItem Value="25">25</asp:ListItem>
															<asp:ListItem Value="26">26</asp:ListItem>
															<asp:ListItem Value="27">27</asp:ListItem>
															<asp:ListItem Value="28">28</asp:ListItem>
															<asp:ListItem Value="29">29</asp:ListItem>
															<asp:ListItem Value="30">30</asp:ListItem>
															<asp:ListItem Value="31">31</asp:ListItem>
														</asp:dropdownlist>&nbsp;
														<asp:textbox id="txtPassportYYYY" runat="server" Width="64px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD vAlign="top" align="left" width="200"><SPAN class="infofield">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="2"><STRONG>Valid 
																	Visa:</STRONG></FONT> </SPAN>
													</TD>
													<TD vAlign="top" align="left"><asp:textbox id="txtVisa" runat="server" Width="336px"></asp:textbox><BR>
														<SPAN class="infoexample">&nbsp;(format should be country-type of visa-expiration 
															date ex. &nbsp;US-B1-July 27, 2004)</SPAN></TD>
												</TR>
											</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FONT-WEIGHT: bold; PADDING-BOTTOM: 5px; WIDTH: 100%; COLOR: #ffffff; PADDING-TOP: 5px; BACKGROUND-COLOR: #eeeeee"
										align="center" colSpan="2"><BR>
										<asp:button id="btnSave" runat="server" Width="82px" Text="Save"></asp:button>&nbsp;&nbsp;&nbsp;
										<asp:button id="btnCancel" runat="server" Width="76px" Text="Cancel"></asp:button><BR>
										<BR>
									</TD>
								</TR>
							</table>
					</td>
				</TR>
				<TR>
					<TD vAlign="top" align="center" bgColor="#ffffcc" colSpan="2"><asp:linkbutton id="lbBack" runat="server" ForeColor="MidnightBlue">Back</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD style="BACKGROUND-COLOR: #ffffcc" align="center" colSpan="2">&nbsp;</TD>
				</TR>
			</table>
			</P></TD></TR></TBODY></TABLE>
			<CENTER></CENTER>
			<input type="hidden" id="HiddenValue" value="none" runat="server"> 
			<!--Table for Employee Information--></form>
		</FORM>
	</body>
</HTML>

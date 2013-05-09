<%@ Page language="c#" Codebehind="skills_empinfo.aspx.cs" AutoEventWireup="false" Inherits="SmfRewriteProject.skills_empinfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SMFNewUser</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="lemonchiffon" MS_POSITIONING="GridLayout" onload="changeList(document.forms['frmEmpInfo'].elements['dropTeamList'])">
		<P align="center"><BR>
			<BR>
			<BR>
			<FONT class="pagetitle" face="Verdana" color="mediumblue" size="4"><B>Register Employee 
					Information</B></FONT>
			<BR>
			<BR>
			<BR>
			<FORM id="frmEmpInfo" method="post" runat="server">
				&nbsp;
				<TABLE class="editform" id="Table1" borderColor="black" cellSpacing="2" cellPadding="4"
					width="648" bgColor="#eeeeee" border="0">
					<TBODY>
						<TR>
							<TD style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FILTER: progid: DXImageTransform.Microsoft.Gradient(GradientType=1, StartColorStr='#FF003399', EndColorStr='#FF6699CC'); PADDING-BOTTOM: 5px; WIDTH: 100%; COLOR: #ffffff; PADDING-TOP: 5px; BACKGROUND-COLOR: #003399"
								align="left" bgColor="navy" colSpan="2"><FONT face="Verdana"><FONT size="2"><B>Instruction:</B>
										&nbsp;&nbsp;Fields followed by <SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana">
											*</SPAN> are required.</FONT></FONT>
							</TD>
						</TR>
						<TR>
							<TD align="left" colSpan="2"><INPUT type="hidden" maxLength="7" value="10" name="Add">
							</TD>
						</TR>
						<TR>
							<TD align="center" colSpan="2">
								<TABLE class="editform" id="Table2" style="BORDER-COLLAPSE: collapse" cellSpacing="2" cellPadding="4"
									width="100%" border="0">
									<TBODY>
										<TR>
											<TD style="HEIGHT: 59px" align="left" colSpan="2"><FONT face="Verdana" size="2">
													<HR>
													<SPAN class="infotitle"><FONT color="mediumblue"><STRONG>&nbsp;&nbsp;Login Information</STRONG></FONT>
													</SPAN>
													<HR>
												</FONT>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 24px" align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
															Login ID: </STRONG></FONT></SPAN>
											</TD>
											<TD style="HEIGHT: 24px" align="left">
												<P><asp:textbox id="txtLoginID" onfocus="this.select()" maxLength="7" type="text" Runat="server"></asp:textbox><FONT size="1"><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana">*</SPAN><FONT face="Verdana">&nbsp;&nbsp;&nbsp;
															<SPAN class="infoexample">
																<asp:regularexpressionvalidator id="revLoginID" runat="server" Display="Dynamic" ValidationExpression="\w{7}" ControlToValidate="txtLoginID"
																	Font-Names="Verdana" ErrorMessage="Login ID is strictly 7 characters." Font-Size="XX-Small"></asp:regularexpressionvalidator><asp:requiredfieldvalidator id="rfvLoginID" runat="server" Display="Dynamic" ControlToValidate="txtLoginID"
																	Font-Names="Verdana" ErrorMessage="Login ID is a required field." Font-Size="XX-Small"></asp:requiredfieldvalidator></SPAN></FONT></FONT></P>
											</TD>
										</TR>
										<TR>
											<TD align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Employee 
															ID: </STRONG></FONT></SPAN>
											</TD>
											<TD align="left"><FONT size="1"><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana"><asp:textbox id="txtEmpID" runat="server" MaxLength="6"></asp:textbox>*</SPAN><FONT face="Verdana">&nbsp;
														<SPAN class="infoexample">&nbsp;&nbsp;
															<asp:regularexpressionvalidator id="revEmpID" runat="server" Display="Dynamic" ValidationExpression="\d{6}" ControlToValidate="txtEmpID"
																Font-Names="Verdana" ErrorMessage="Employee ID is strictly 6 digits." Font-Size="XX-Small"></asp:regularexpressionvalidator><asp:requiredfieldvalidator id="rfvEmpID" runat="server" Display="Dynamic" ControlToValidate="txtEmpID" Font-Names="Verdana"
																ErrorMessage="Employee ID is a required field." Font-Size="XX-Small"></asp:requiredfieldvalidator></SPAN></FONT></FONT></TD>
										</TR>
										<TR>
											<TD align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
															Password:</STRONG> </FONT></SPAN>
											</TD>
											<TD align="left"><FONT size="1"><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana">
														<P><asp:textbox id="txtPassword" runat="server" MaxLength="16" TextMode="Password"></asp:textbox>
														*</SPAN><FONT face="Verdana">&nbsp;</FONT><FONT face="Verdana">&nbsp; <SPAN class="infoexample">
															&nbsp;
															<asp:regularexpressionvalidator id="revPassword" runat="server" Display="Dynamic" ValidationExpression="\S{6,}"
																ControlToValidate="txtPassword" Font-Names="Verdana" ErrorMessage="Password should be at least 6 characters."
																Font-Size="XX-Small"></asp:regularexpressionvalidator><asp:requiredfieldvalidator id="rfvPassword" runat="server" Display="Dynamic" ControlToValidate="txtPassword"
																Font-Names="Verdana" ErrorMessage="Password is a required field." Font-Size="XX-Small"></asp:requiredfieldvalidator>
		</P>
		</SPAN></FONT></FONT></TD></TR>
		<TR>
			<TD style="HEIGHT: 32px" align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Re-enter 
							Password: </STRONG></FONT></SPAN>
			</TD>
			<TD style="FONT-WEIGHT: normal; HEIGHT: 32px" align="left"><SPAN style="COLOR: #cc0033; FONT-FAMILY: verdana"><FONT size="1"><asp:textbox id="txtRePassword" runat="server" MaxLength="16" TextMode="Password"></asp:textbox>*&nbsp;&nbsp;
						<asp:comparevalidator id="cvRePassword" runat="server" Display="Dynamic" ControlToValidate="txtRePassword"
							Font-Names="Verdana" ErrorMessage="Password doesn't match.  Try again." Font-Size="XX-Small" ControlToCompare="txtPassword"></asp:comparevalidator><asp:requiredfieldvalidator id="rfvRePassword" runat="server" Display="Dynamic" ControlToValidate="txtRePassword"
							Font-Names="Verdana" ErrorMessage="Please re-enter password." Font-Size="XX-Small"></asp:requiredfieldvalidator></FONT></SPAN></TD>
		</TR>
		<TR>
			<TD align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Office:
						</STRONG></FONT></SPAN>
			</TD>
			<TD align="left"><!--<label><input name="radOfc" type="radio" value="MNL" checked>MNL</label>
                <label><input name="radOfc" type="radio" value="MSP">MSP</label>
                <label><input name="radOfc" type="radio" value="SLC">SLC</label>
                <label><input name="radOfc" type="radio" value="AUS">AUS</label>
                <label><input name="radOfc" type="radio" value="SYD">SYD</label>
                <label><input name="radOfc" type="radio" value="Others">Others</label>--><FONT face="Verdana" size="1"><asp:dropdownlist id="ddlOffice" runat="server">
						<asp:ListItem Value="MNL">Manila</asp:ListItem>
						<asp:ListItem Value="MSP">Minneapolis</asp:ListItem>
						<asp:ListItem Value="SLC">Salt Lake City</asp:ListItem>
						<asp:ListItem Value="SYD">Sydney</asp:ListItem>
					</asp:dropdownlist></FONT></TD>
		</TR>
		<TR>
			<TD align="left" colSpan="2"><FONT face="Verdana" color="mediumblue" size="2"><STRONG>
						<HR>
						<SPAN class="infotitle">&nbsp;&nbsp;Personal Profile </SPAN>
						<HR>
					</STRONG></FONT>
			</TD>
		</TR>
		<TR>
			<TD align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;First 
							Name: </STRONG></FONT></SPAN>
			</TD>
			<TD align="left"><asp:textbox id="txtFirstName" runat="server" MaxLength="32" Width="215px"></asp:textbox><FONT size="1"><SPAN style="COLOR: #cc0033; FONT-FAMILY: verdana">*&nbsp;&nbsp;
						<asp:requiredfieldvalidator id="rfvFirstName" runat="server" Display="Dynamic" ControlToValidate="txtFirstName"
							Font-Names="Verdana" ErrorMessage="First Name is a required field." Font-Size="XX-Small"></asp:requiredfieldvalidator></SPAN><FONT face="Verdana">&nbsp;
					</FONT></FONT>
			</TD>
		</TR>
		<TR>
			<TD align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Last 
							Name: </STRONG></FONT></SPAN>
			</TD>
			<TD><FONT size="1"><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana"><asp:textbox id="txtLastName" runat="server" MaxLength="32" Width="215px"></asp:textbox>*</SPAN><FONT face="Verdana">&nbsp;&nbsp;
						<asp:requiredfieldvalidator id="rfvLastName" runat="server" Display="Dynamic" ControlToValidate="txtLastName"
							Font-Names="Verdana" ErrorMessage="Last Name is a required field." Font-Size="XX-Small"></asp:requiredfieldvalidator></FONT></FONT></TD>
		</TR>
		<TR>
			<TD align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Current 
							Team/Role: </STRONG></FONT></SPAN>
			</TD>
			<TD noWrap><FONT size="1"><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana"><asp:dropdownlist id="dropTeamList" runat="server" Width="216px" Font-Size="11pt"></asp:dropdownlist>*</SPAN><FONT face="Verdana">&nbsp;
						<SPAN class="infoexample">&nbsp;&nbsp;
							<asp:requiredfieldvalidator id="rfvPosition" runat="server" Display="Dynamic" ControlToValidate="dropTeamList"
								Font-Names="Verdana" ErrorMessage="Team/Role is a required field." Font-Size="XX-Small"></asp:requiredfieldvalidator></SPAN></FONT></FONT></TD>
		</TR>
		<TR>
			<TD align="left" width="200">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<FONT face="Verdana" size="1">&nbsp;<STRONG>Sub 
						Team:</STRONG></FONT>
			</TD>
			<TD noWrap>
				<asp:DropDownList id="dropSubTeamList" runat="server" Width="216px"></asp:DropDownList></TD>
		</TR>
		<TR>
			<TD noWrap align="left"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Navitaire 
							Start Date: </STRONG></FONT></SPAN>
			</TD>
			<TD colSpan="2"><FONT face="Verdana" size="1">
					<P><FONT size="1"><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana"></SPAN><FONT face="Verdana"><asp:dropdownlist id="ddlNavMonth" runat="server">
									<asp:ListItem Value="0">Month</asp:ListItem>
									<asp:ListItem Value="1">January</asp:ListItem>
									<asp:ListItem Value="2">February</asp:ListItem>
									<asp:ListItem Value="3">March</asp:ListItem>
									<asp:ListItem Value="4">April</asp:ListItem>
									<asp:ListItem Value="5">May</asp:ListItem>
									<asp:ListItem Value="6">June</asp:ListItem>
									<asp:ListItem Value="7">July</asp:ListItem>
									<asp:ListItem Value="8">August</asp:ListItem>
									<asp:ListItem Value="9">September</asp:ListItem>
									<asp:ListItem Value="10">October</asp:ListItem>
									<asp:ListItem Value="11">November</asp:ListItem>
									<asp:ListItem Value="12">December</asp:ListItem>
								</asp:dropdownlist>&nbsp;
								<asp:dropdownlist id="ddlNavDay" runat="server" Width="56px">
									<asp:ListItem Value="0">Day</asp:ListItem>
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
								</asp:dropdownlist>&nbsp;</FONT></FONT>
				</FONT><FONT size="1"><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana">
						<asp:textbox id="txtNavYear" runat="server" MaxLength="4" Width="68px">YYYY</asp:textbox>&nbsp;<FONT size="1"><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana">*</SPAN></FONT></SPAN></FONT><FONT size="1"><FONT face="Verdana">&nbsp;&nbsp;
						<asp:Label id="lblStartDateError" runat="server" Visible="False" ForeColor="Red">Invalid date.</asp:Label></P></FONT></FONT></TD>
		</TR>
		<TR>
			<TD align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Nick 
							Name: </STRONG></FONT></SPAN>
			</TD>
			<TD align="left"><asp:textbox id="txtNickName" runat="server" Width="215px" MaxLength="32"></asp:textbox><SPAN style="COLOR: #cc0033; FONT-FAMILY: verdana"><FONT size="1">*&nbsp;
						<asp:requiredfieldvalidator id="rfvNickName" runat="server" Display="Dynamic" ControlToValidate="txtNickName"
							Font-Names="Verdana" ErrorMessage="Nickname is  a required field." Font-Size="XX-Small"></asp:requiredfieldvalidator></FONT></SPAN></TD>
			</TD></TR>
		<TR>
			<TD style="HEIGHT: 33px" align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Gender:
						</STRONG></FONT></SPAN>
			</TD>
			<TD style="HEIGHT: 18px" align="left" colSpan="1" rowSpan="1"><FONT face="Verdana"><FONT size="1"><LABEL><asp:radiobuttonlist id="RadioButtonList1" runat="server" Font-Size="Larger" Width="150px" RepeatDirection="Horizontal"
								Height="18px">
								<asp:ListItem Value="M" Selected="True">Male</asp:ListItem>
								<asp:ListItem Value="F">Female</asp:ListItem>
							</asp:radiobuttonlist></LABEL></FONT></FONT></TD>
		</TR>
		<TR>
			<TD style="HEIGHT: 4px" align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Birthday:
						</STRONG></FONT></SPAN>
			</TD>
			<TD style="HEIGHT: 4px" colSpan="2"><FONT face="Verdana" size="1"><FONT face="Verdana" size="1">
						<P><FONT size="1"><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana"></SPAN><FONT face="Verdana"><asp:dropdownlist id="ddlBdayMonth" runat="server">
										<asp:ListItem Value="0">Month</asp:ListItem>
										<asp:ListItem Value="1">January</asp:ListItem>
										<asp:ListItem Value="2">February</asp:ListItem>
										<asp:ListItem Value="3">March</asp:ListItem>
										<asp:ListItem Value="4">April</asp:ListItem>
										<asp:ListItem Value="5">May</asp:ListItem>
										<asp:ListItem Value="6">June</asp:ListItem>
										<asp:ListItem Value="7">July</asp:ListItem>
										<asp:ListItem Value="8">August</asp:ListItem>
										<asp:ListItem Value="9">September</asp:ListItem>
										<asp:ListItem Value="10">October</asp:ListItem>
										<asp:ListItem Value="11">November</asp:ListItem>
										<asp:ListItem Value="12">December</asp:ListItem>
									</asp:dropdownlist>&nbsp;
									<asp:dropdownlist id="ddlBdayDay" runat="server" Width="56px">
										<asp:ListItem Value="0">Day</asp:ListItem>
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
									</asp:dropdownlist>&nbsp;</FONT></FONT>
					</FONT><FONT size="1"><SPAN style="COLOR: #cc0033; FONT-FAMILY: verdana">
							<asp:textbox id="txtBdayYear" runat="server" MaxLength="4" Width="68px">YYYY</asp:textbox><FONT size="1"><SPAN style="COLOR: #cc0033; FONT-FAMILY: verdana"><FONT size="1"><SPAN style="COLOR: #cc0033; FONT-FAMILY: verdana"><FONT size="1"><SPAN style="COLOR: #cc0033; FONT-FAMILY: verdana">*&nbsp;
													<asp:Label id="lblBirthdayError" runat="server" Visible="False" ForeColor="Red">Invalid date.</asp:Label></SPAN></FONT></SPAN></FONT></SPAN></FONT></SPAN></FONT><FONT size="1"><FONT face="Verdana"></P></FONT></FONT></FONT></TD>
		</TR>
		<TR>
			<TD noWrap align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Home 
							Number: </STRONG></FONT></SPAN>
			</TD>
			<TD>
				<P><asp:textbox id="txtHomeNum" runat="server" MaxLength="20"></asp:textbox><FONT size="1"><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana">*</SPAN><FONT face="Verdana">
							<SPAN class="infoexample">&nbsp;&nbsp; (ex. 639208889999)</SPAN>&nbsp;&nbsp;
							<asp:requiredfieldvalidator id="rfvHomeNum" runat="server" Display="Dynamic" ControlToValidate="txtHomeNum"
								Font-Names="Verdana" ErrorMessage="Home number is a required field." Font-Size="XX-Small"></asp:requiredfieldvalidator></FONT></FONT></P>
			</TD>
		</TR>
		<TR>
			<TD align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cellphone 
							Number: </STRONG></FONT></SPAN>
			</TD>
			<TD align="left" colSpan="2"><asp:textbox id="txtCellNum" runat="server" MaxLength="20"></asp:textbox><FONT size="1"><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana">*</SPAN><FONT face="Verdana">
						<SPAN class="infoexample">&nbsp;&nbsp; (ex. 630495557777)</SPAN>&nbsp; &nbsp;
						<asp:requiredfieldvalidator id="rfvCellNum" runat="server" Display="Dynamic" ControlToValidate="txtCellNum"
							Font-Names="Verdana" ErrorMessage="Cellphone number is a required field." Font-Size="XX-Small"></asp:requiredfieldvalidator></FONT></FONT></TD>
		</TR>
		<TR>
			<TD noWrap align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Other 
							E-mail Address: </STRONG></FONT></SPAN>
			</TD>
			<TD>
				<P><FONT face="Verdana" size="1"></FONT><asp:textbox id="txtOtherEmail" runat="server" MaxLength="50" Width="215px"></asp:textbox></P>
			</TD>
		</TR>
		<TR>
			<TD align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Home 
							Address: </STRONG></FONT></SPAN>
			</TD>
			<TD>
				<P><asp:textbox id="txtAddressSt" runat="server" MaxLength="150" Width="335px"></asp:textbox><FONT size="1"><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana">*</SPAN><FONT face="Verdana">&nbsp;&nbsp;
							<asp:requiredfieldvalidator id="rfvAddressSt" runat="server" Display="Dynamic" ControlToValidate="txtAddressSt"
								Font-Names="Verdana" ErrorMessage="Home address is a required field." Font-Size="XX-Small"></asp:requiredfieldvalidator></FONT></FONT></P>
			</TD>
		</TR>
		<TR>
			<TD noWrap align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;City:
						</STRONG></FONT></SPAN>
			</TD>
			<TD>
				<P><asp:textbox id="txtAddressCity" runat="server" Width="130px" MaxLength="50"></asp:textbox><FONT size="1"><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana">*</SPAN><FONT face="Verdana">&nbsp;&nbsp;
							<asp:requiredfieldvalidator id="rfvAddressCity" runat="server" Display="Dynamic" ControlToValidate="txtAddressCity"
								Font-Names="Verdana" ErrorMessage="City is a required field." Font-Size="XX-Small"></asp:requiredfieldvalidator>&nbsp;
						</FONT></FONT>
				</P>
			</TD>
		</TR>
		<TR>
			<TD align="left" colSpan="2"><FONT face="Verdana" color="mediumblue" size="2"><STRONG>
						<HR>
						<SPAN class="infotitle">&nbsp;&nbsp;Undergraduate Information </SPAN>
						<HR>
					</STRONG></FONT>
			</TD>
		</TR>
		<TR>
			<TD align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;School:
						</STRONG></FONT></SPAN>
			</TD>
			<TD align="left">
				<P><SPAN style="COLOR: #cc0033; FONT-FAMILY: verdana"><asp:textbox id="txtUGSchool" runat="server" Width="335px" MaxLength="50"></asp:textbox><SPAN style="COLOR: #cc0033; FONT-FAMILY: verdana"><FONT size="1">*&nbsp;&nbsp;
								<asp:requiredfieldvalidator id="rfvUGSchool" runat="server" Display="Dynamic" ControlToValidate="txtUGSchool"
									Font-Names="Verdana" ErrorMessage="School is a required field." Font-Size="XX-Small" EnableViewState="False"></asp:requiredfieldvalidator>&nbsp;</FONT></SPAN></SPAN></P>
			</TD>
		</TR>
		<TR>
			<TD align="left"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Degree
						</STRONG></FONT></SPAN>
			</TD>
			<TD align="left" colSpan="2">
				<P><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana"><asp:textbox id="txtUGDegree" runat="server" MaxLength="50"></asp:textbox></SPAN><FONT size="1"><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana">*</SPAN><FONT face="Verdana">
							<SPAN class="infofield">&nbsp;&nbsp;Year:
								<asp:textbox id="txtUGYear" runat="server" MaxLength="4" Width="70px"></asp:textbox></SPAN></FONT></FONT><SPAN style="COLOR: #cc0033; FONT-FAMILY: verdana"><FONT size="1">*&nbsp;
							<asp:requiredfieldvalidator id="rfvUGDegree" runat="server" Display="Dynamic" ControlToValidate="txtUGDegree"
								Font-Names="Verdana" ErrorMessage="Degree is a required field." Font-Size="XX-Small" EnableViewState="False"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="rfvUGYear" runat="server" Display="Dynamic" ControlToValidate="txtUGYear" Font-Names="Verdana"
								ErrorMessage="Year is a required field." Font-Size="XX-Small" EnableViewState="False"></asp:requiredfieldvalidator>
							<asp:RegularExpressionValidator id="revUGYear" runat="server" ErrorMessage="Invalid year (YYYY)." ControlToValidate="txtUGYear"
								ValidationExpression="\d{4}"></asp:RegularExpressionValidator></FONT></SPAN></P>
			</TD>
		</TR>
		<TR>
			<TD align="left" colSpan="2"><FONT face="Verdana" color="mediumblue" size="2"><STRONG>
						<HR>
						<SPAN class="infotitle">&nbsp;&nbsp;Graduate Information </SPAN>
						<HR>
					</STRONG></FONT>
			</TD>
		</TR>
		<TR>
			<TD align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;School:
						</STRONG></FONT></SPAN>
			</TD>
			<TD align="left">
				<P><FONT size="1"><asp:textbox id="txtGSchool" runat="server" Width="335px" MaxLength="50"></asp:textbox><FONT face="Verdana" size="2"></FONT></FONT></P>
			</TD>
		</TR>
		<TR>
			<TD align="left"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Degree
						</STRONG></FONT></SPAN>
			</TD>
			<TD align="left" colSpan="2">
				<P><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana"><asp:textbox id="txtGDegree" runat="server" MaxLength="50"></asp:textbox></SPAN><FONT size="1"><FONT face="Verdana">&nbsp;
							<SPAN class="infofield">&nbsp;&nbsp;Year:
								<asp:textbox id="txtGYear" runat="server" MaxLength="4" Width="70px"></asp:textbox></SPAN></FONT></FONT><SPAN style="FONT-WEIGHT: bold; COLOR: #cc0033; FONT-FAMILY: verdana"><FONT size="1"></FONT></SPAN><INPUT type="hidden" value="NewAccount" name="pagemode"></P>
			</TD>
		</TR>
		<TR>
			<TD align="left" colSpan="2"><FONT face="Verdana" color="mediumblue" size="2"><STRONG>
						<HR>
						<SPAN class="infotitle">&nbsp;&nbsp;Passport Information </SPAN>
						<HR>
					</STRONG></FONT>
			</TD>
		</TR>
		<TR>
			<TD align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Passport 
							Number: </STRONG></FONT></SPAN>
			</TD>
			<TD align="left">
				<P><FONT size="1"><asp:textbox id="txtPassportNum" runat="server" MaxLength="50" Width="215px"></asp:textbox><FONT face="Verdana" size="2"></FONT></FONT></P>
			</TD>
		</TR>
		<TR>
			<TD noWrap align="left"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Passport 
							Expiration Date: </STRONG></FONT></SPAN>
			</TD>
			<TD colSpan="2"><asp:dropdownlist id="ddlPassportMonth" runat="server">
					<asp:ListItem Value="0">Month</asp:ListItem>
					<asp:ListItem Value="1">January</asp:ListItem>
					<asp:ListItem Value="2">February</asp:ListItem>
					<asp:ListItem Value="3">March</asp:ListItem>
					<asp:ListItem Value="4">April</asp:ListItem>
					<asp:ListItem Value="5">May</asp:ListItem>
					<asp:ListItem Value="6">June</asp:ListItem>
					<asp:ListItem Value="7">July</asp:ListItem>
					<asp:ListItem Value="8">August</asp:ListItem>
					<asp:ListItem Value="9">September</asp:ListItem>
					<asp:ListItem Value="10">October</asp:ListItem>
					<asp:ListItem Value="11">November</asp:ListItem>
					<asp:ListItem Value="12">December</asp:ListItem>
				</asp:dropdownlist>&nbsp;
				<asp:dropdownlist id="ddlPassportDay" runat="server" Width="56px">
					<asp:ListItem Value="0">Day</asp:ListItem>
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
				<asp:textbox id="txtPassportYear" runat="server" MaxLength="4" Width="68px">YYYY</asp:textbox></TD>
		</TR>
		<TR>
			<TD align="left" width="200"><SPAN class="infofield"><FONT face="Verdana" size="1"><STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Valid 
							Visa: </STRONG></FONT></SPAN>
			</TD>
			<TD align="left"><FONT face="Verdana"><FONT size="1"><asp:textbox id="txtVisa" runat="server" Width="335px" MaxLength="150"></asp:textbox>&nbsp;<BR>
						<SPAN class="infoexample">&nbsp;(format should be country-type of visa-expiration 
							date ex. &nbsp;US-B1-July 27, 2004)</SPAN></FONT></FONT></TD>
		</TR>
		</TBODY></TABLE><FONT face="Verdana" size="2">
			<HR>
		</FONT></TD></TR>
		<TR>
			<TD style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; WIDTH: 100%; COLOR: #ffffff; PADDING-TOP: 5px; BACKGROUND-COLOR: #eeeeee"
				align="center" colSpan="2"><asp:button id="btnSave" runat="server" Width="90px" Text="Save"></asp:button>&nbsp;&nbsp;
				<input type="button" onclick="window.location.href='default.aspx'" style="WIDTH: 84px; HEIGHT: 24px"
					value="Cancel"></TD>
		</TR>
		</TBODY></TABLE> <input type="hidden" id="HiddenValue" value="none" runat="server" NAME="HiddenValue">
		</FORM></P>
	</body>
</HTML>

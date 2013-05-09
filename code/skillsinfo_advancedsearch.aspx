<%@ Register TagPrefix="uc1" TagName="SmfTopNavButtons" Src="SmfTopNavButtons.ascx" %>
<%@ Page language="c#" Codebehind="skillsinfo_advancedsearch.aspx.cs" AutoEventWireup="True" Inherits="SmfRewriteProject.skillsinfo_advancedsearch" smartNavigation="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Skills Advanced Search</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="skills_stylesheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" bgColor="#ffffcc" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" height="20" cellSpacing="0" cellPadding="0" width="100%" bgColor="#ffffff">
				<TR>
					<TD vAlign="middle" noWrap align="center" bgColor="#ffffcc">&nbsp;<BR>
						<TABLE id="Table2" style="BORDER-COLLAPSE: collapse" borderColor="black" height="20" cellSpacing="0"
							cellPadding="4" width="710" border="0">
							<TR>
								<TD class="pagetitle" noWrap align="right" width="100%" bgColor="#ffffcc" colSpan="2"
									height="20">&nbsp;
									<BR>
									<uc1:smftopnavbuttons id="SmfTopNavButtons1" runat="server"></uc1:smftopnavbuttons></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<CENTER></CENTER>
			<CENTER>
				<TABLE id="Table3" height="91" cellSpacing="0" cellPadding="0" width="100%" bgColor="#ffffff"
					border="0">
					<TR>
						<TD vAlign="middle" noWrap align="center" bgColor="#ffffcc" colSpan="2">
							<TABLE id="Table4" style="BORDER-COLLAPSE: collapse" borderColor="black" height="91" cellSpacing="0"
								cellPadding="4" width="710" border="0">
								<TR>
									<TD class="pagetitle" noWrap align="center" width="100%" bgColor="#ffffcc" colSpan="2"
										height="123">
										<P>
										<P>
											<HR SIZE="2">
											<FONT face="Verdana" color="#003399" size="4"><STRONG>Advanced Search</STRONG></FONT>
											<HR>
										<P></P>
										<P>&nbsp;</P>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
			<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" bgColor="#ffffcc"
				border="0">
				<TR>
					<TD vAlign="middle" noWrap align="center" bgColor="#ffffcc" colSpan="1">
						<table width="710">
							<tr>
								<td vAlign="top">
									<div id="tabmenusrch" absolute>
										<center><A class="inactive" href="skills_advancedsearch.aspx"><span>Employee Names</span></A>
											<A class="active"><span>Skills Information</span></A>
										</center>
									</div>
									<div id="contentsrchbox">
										<center>
											<table style="WIDTH: 600px; HEIGHT: 134px; BACKGROUND-COLOR: #eeeeee" width="600">
												<tr>
													<td align="center">
														<table style="WIDTH: 602px; HEIGHT: 308px; BACKGROUND-COLOR: #eeeeee" width="602" border="0">
															<TBODY>
																<tr>
																	<td style="HEIGHT: 121px" colSpan="2"><br>
																		<P>&nbsp;&nbsp;
																			<asp:label id="Label1" runat="server" Font-Bold="True">Search for</asp:label>&nbsp;&nbsp;&nbsp;
																			<br>
																			<br>
																			&nbsp;&nbsp;
																			<asp:label id="Label2" runat="server" Font-Size="X-Small" Font-Names="Verdana" Width="128px">Technical Skills</asp:label>&nbsp;&nbsp;
																			<asp:textbox id="TextBox1" runat="server" Width="400px"></asp:textbox><br>
																			&nbsp;&nbsp;
																			<asp:label id="Label3" runat="server" Font-Size="X-Small" Font-Names="Verdana" Width="128px">Product Knowledge</asp:label>&nbsp;&nbsp;
																			<asp:textbox id="TextBox2" runat="server" Width="400px"></asp:textbox>&nbsp;
																			<asp:button id="Button1" runat="server" Text="Go" onclick="Button1_Click"></asp:button></P>
																		<P><FONT style="FONT-WEIGHT: bold; COLOR: black; FONT-FAMILY: verdana" size="2">&nbsp;&nbsp;&nbsp;&nbsp;Options:</FONT>
																			<br>
																			<HR style="COLOR: black" noShade SIZE="1">
																	</td>
																</tr>
																<TR>
																	<TD vAlign="top" noWrap><FONT style="COLOR: black; FONT-FAMILY: verdana" size="2">&nbsp;&nbsp;&nbsp;&nbsp;</FONT><FONT style="COLOR: black; FONT-FAMILY: verdana" size="2">Find:</FONT>
																		<br>
																		<br>
																		<br>
																		<br>
																		<br>
																		<FONT style="COLOR: black; FONT-FAMILY: verdana" size="2">&nbsp;&nbsp;&nbsp;&nbsp;</FONT><FONT style="COLOR: black; FONT-FAMILY: verdana" size="2">Proficiency 
																			Level:</FONT>
																		<br>
																		<FONT style="COLOR: black; FONT-FAMILY: verdana" size="2">&nbsp;&nbsp;&nbsp;&nbsp;</FONT><FONT style="COLOR: black; FONT-FAMILY: verdana" size="2">Office:</FONT>
																		<br>
																		<FONT style="COLOR: black; FONT-FAMILY: verdana" size="2">&nbsp;&nbsp;&nbsp;&nbsp;</FONT><FONT style="COLOR: black; FONT-FAMILY: verdana" size="2">Status:</FONT>
																	</TD>
																	<TD vAlign="top" noWrap>
																		<P><asp:radiobutton id="RadioButton1" runat="server" Text="any of the words" Checked="True" GroupName="Search"></asp:radiobutton><BR>
																			<asp:radiobutton id="RadioButton2" runat="server" Text="all of the words" GroupName="Search"></asp:radiobutton><BR>
																			<BR>
																			&nbsp;use commas (,) to separate words or phrases</P>
																		<P>&nbsp;<asp:dropdownlist id="DropDownList1" runat="server" Width="160px">
																				<asp:ListItem Value="None">None</asp:ListItem>
																				<asp:ListItem Value="Novice">Novice</asp:ListItem>
																				<asp:ListItem Value="Novice-Expert" Selected="True">Novice-Expert</asp:ListItem>
																				<asp:ListItem Value="Intermediate">Intermediate</asp:ListItem>
																				<asp:ListItem Value="Intermediate-Expert">Intermediate-Expert</asp:ListItem>
																				<asp:ListItem Value="Expert">Expert</asp:ListItem>
																			</asp:dropdownlist>
																			<br>
																			&nbsp;<asp:dropdownlist id="drOffice" runat="server" Width="160px"></asp:dropdownlist>
																			<br>
																			&nbsp;<asp:dropdownlist id="DropDownList2" runat="server" Width="160px">
																				<asp:ListItem Value="All">All</asp:ListItem>
																				<asp:ListItem Value="Active" Selected="True">Active</asp:ListItem>
																				<asp:ListItem Value="Inactive">Inactive</asp:ListItem>
																			</asp:dropdownlist></P>
																	</TD>
																</TR>
												</tr>
											</table>
								</td>
							</tr>
						</table>
						</CENTER></DIV></TD>
				</TR>
			</TABLE>
			<TABLE id="Table6" style="BORDER-COLLAPSE: collapse" borderColor="black" height="50%" cellSpacing="0"
				cellPadding="4" width="100%" border="0">
				<TR>
					<TD class="pagequery" align="center" width="100%" bgColor="#ffffcc" colSpan="2" height="123">
						<P align="center"><asp:panel id="Panel1" runat="server" Width="100%" Height="0.01%" BackColor="Transparent" BorderColor="Transparent"
								BorderWidth="0px" HorizontalAlign="Center" Visible="False"><BR>
								<P align="left">
									<asp:Label id="lblQueryDetail" runat="server" Width="100%" Font-Names="Verdana" Font-Size="XX-Small"
										Height="4px" ForeColor="Navy">Label</asp:Label></P>
								<asp:datagrid id="DataGrid1" runat="server" Visible="False" CellSpacing="5" AllowPaging="True"
									AutoGenerateColumns="False" PageSize="12" width="100%" ShowHeader="False">
									<ItemStyle Font-Size="X-Small" Font-Names="Verdana"></ItemStyle>
									<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="Number" HeaderText="Number"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="LoginID" HeaderText="Login ID">
											<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="EmployeeName" HeaderText="Employee Name"></asp:BoundColumn>
										<asp:TemplateColumn>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="ViewSummary" runat="server" Font-Bold="True" CommandName="View">Employee Name</asp:LinkButton>&nbsp;
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<ItemTemplate>
												<P align="left">
													<asp:Label id="TechSkill" runat="server" ForeColor="Navy">Tech Skill:</asp:Label><BR>
													<asp:Label id="ProductSkill" runat="server" ForeColor="Purple">Product Skill:</asp:Label></P>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn Visible="False" DataField="TechnicalSkill" HeaderText="Technical Skill"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="ProductSkill" HeaderText="Product Skill"></asp:BoundColumn>
									</Columns>
									<PagerStyle NextPageText="More Employees..." Font-Size="XX-Small" Font-Names="Verdana" PrevPageText="Previous Employees"
										HorizontalAlign="Center" ForeColor="Navy" Position="TopAndBottom" PageButtonCount="100"
										Mode="NumericPages"></PagerStyle>
								</asp:datagrid>
							</asp:panel>
						<P align="center"><asp:linkbutton id="homelink" style="TEXT-DECORATION: none" runat="server" ForeColor="Navy" onclick="homelink_Click">Back</asp:linkbutton></P>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
	</body>
</HTML>

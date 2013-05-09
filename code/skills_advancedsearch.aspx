<%@ Register TagPrefix="uc1" TagName="SmfTopNavButtons" Src="SmfTopNavButtons.ascx" %>
<%@ Page language="c#" Codebehind="skills_advancedsearch.aspx.cs" AutoEventWireup="True" Inherits="SmfRewriteProject.skills_advancedsearch" smartNavigation="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Skills Advanced Search</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="skills_stylesheet.css" type="text/css" rel="stylesheet">
		<script>		
        function ShowDialog(login_id, dHeight)
        {
        	var retval="";
        	
        	var popUpPageArg = 'skills_editempprofiles.aspx?sLoginID=' + login_id;
            var popUpSetup = 'scroll:yes;edge:sunken;status:no;resizable:no;help:no;center:yes;dialogHeight:'+ dHeight + ';dialogWidth:306px';

            retval=window.showModalDialog
               (popUpPageArg,window,popUpSetup);

        	if(retval!="" && retval!=null)
        	{
        		document.getElementById("txtTransaction").value=retval;
        	}
        }
		</script>
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
										<center><a class="active"><span>Employee Names</span></a> <A class="inactive" href="skillsinfo_advancedsearch.aspx">
												<span>Skills Information</span> </A>&nbsp;
										</center>
									</div>
									<div id="contentsrchbox">
										<center>
											<table style="WIDTH: 600px; HEIGHT: 134px; BACKGROUND-COLOR: #eeeeee" width="600">
												<tr>
													<td align="center">
														<table style="WIDTH: 557px; HEIGHT: 130px; BACKGROUND-COLOR: #eeeeee" width="557" border="0">
															<TBODY>
																<tr>
																	<td style="HEIGHT: 121px" colSpan="2"><br>
																		<P>&nbsp;&nbsp;
																			<asp:label id="Label1" runat="server" Font-Bold="True">Search for</asp:label>&nbsp;
																			<asp:textbox id="TextBox1" runat="server" Width="402px"></asp:textbox>&nbsp;
																			<asp:button id="Button1" runat="server" Text="Go" onclick="Button1_Click"></asp:button></P>
																		<br>
																		<font style="FONT-WEIGHT: bold; COLOR: black; FONT-FAMILY: verdana" size="2">&nbsp;&nbsp;&nbsp;&nbsp;Options:</font>
																		<asp:textbox id="txtSearch" runat="server" Visible="False"></asp:textbox><asp:textbox id="txtOption" runat="server" Visible="False"></asp:textbox>
																		<hr style="COLOR: black" noShade SIZE="1">
																	</td>
																</tr>
																<tr>
																	<td vAlign="top" noWrap>&nbsp;&nbsp;&nbsp;&nbsp;<font style="COLOR: black; FONT-FAMILY: verdana" size="2">&nbsp;&nbsp;&nbsp;&nbsp;Find:</font>
																	</td>
																	<td noWrap><asp:radiobutton id="RadioButton1" runat="server" Text="any of the words" Checked="True" GroupName="Search"></asp:radiobutton><br>
																		<asp:radiobutton id="RadioButton2" runat="server" Text="exact words" GroupName="Search"></asp:radiobutton><br>
																		<br>
																		&nbsp;use commas (,) to separate words or phrases
																	</td>
																</tr>
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
						<P align="center"><asp:panel id="Panel1" runat="server" Width="100%" Visible="False" Height="0.01%" BackColor="Transparent"
								BorderColor="Transparent" BorderWidth="0px" HorizontalAlign="Center"><BR>
								<P align="left">
									<asp:Label id="lblQueryDetail" runat="server" Width="100%" Height="4px" Font-Size="XX-Small"
										Font-Names="Verdana" ForeColor="Navy">Label</asp:Label></P>
								<asp:datagrid id="DataGrid1" runat="server" Visible="False" BorderWidth="1px" BorderColor="Black"
									BackColor="White" CellSpacing="1" AllowPaging="True" AutoGenerateColumns="False" PageSize="12"
									width="100%" CellPadding="4" BorderStyle="None">
									<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
									<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
									<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
									<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="White"></ItemStyle>
									<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
										ForeColor="Black" VerticalAlign="Middle" BackColor="LightSkyBlue"></HeaderStyle>
									<Columns>
										<asp:BoundColumn DataField="Number" HeaderText="No.">
											<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="LoginID" HeaderText="Login ID">
											<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="EmployeeName" HeaderText="Employee Name">
											<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Status" HeaderText="Status">
											<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Access" HeaderText="Access">
											<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn>
											<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="ViewSummary" runat="server" CommandName="View">View Individual Summary</asp:LinkButton>&nbsp;
												<asp:LinkButton id="EditProfile" runat="server" CommandName="Edit">Edit Profile</asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle Font-Size="X-Small" Font-Names="Verdana" HorizontalAlign="Left" ForeColor="White"
										BackColor="#999999" PageButtonCount="1" Mode="NumericPages"></PagerStyle>
								</asp:datagrid>
								<asp:TextBox id="txtTransaction" runat="server" Width="0px" Height="0px"></asp:TextBox>
							</asp:panel>
						<P align="center"><asp:linkbutton id="homelink" style="TEXT-DECORATION: none" runat="server" ForeColor="Navy" onclick="homelink_Click">Back</asp:linkbutton></P>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TBODY></TABLE></form>
	</body>
</HTML>

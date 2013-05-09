<%@ Register TagPrefix="uc1" TagName="SmfTopNavButtons" Src="SmfTopNavButtons.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="SmfRewriteProject" Assembly="SmfRewriteProject" %>
<%@ Page CodeBehind="skills_admintech.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="SmfRewriteProject.skills_admintech" %>
<HEAD>
	<TITLE>Technical Skills Code</TITLE>
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
</HEAD>
<body bottomMargin="0" bgColor="#ffffcc" leftMargin="0" topMargin="0" rightMargin="0">
	<form id="skills_admintech" runat="server">
		<center>
			<table class="tabbgnd" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="tabbgnd" noWrap align="center" colSpan="2"><br>
						<div align="center"><font style="COLOR: navy" face="verdana" size="2"><b>Skill Code/Team 
									Admin</b></font></div>
					</td>
				</tr>
			</table>
			<table class="tabbgnd" id="top" cellSpacing="0" cellPadding="0" width="100%">
				<TBODY>
					<tr>
						<td class="tabbgnd">
							<div id="tabmenuskills">
								<center><span class="active"><font size="2">Technical Skill Code</font></span>&nbsp;<A class="inactive" style="TEXT-DECORATION: none" href="skills_adminprod.aspx"><font size="2">Product 
											Knowledge Code</font></A>&nbsp;<A class="inactive" style="TEXT-DECORATION: none" href="skills_adminteam.aspx"><FONT size="2">Team 
											Admin</FONT></A>
							</div>
		</center>
		</TD></TR></TBODY></TABLE>
		<table height="20" cellSpacing="0" cellPadding="0" width="100%" bgColor="#ffffff">
			<tr>
				<td vAlign="middle" noWrap align="center" bgColor="#ffffcc">&nbsp;<br>
					<table style="BORDER-COLLAPSE: collapse" borderColor="black" height="20" cellSpacing="0"
						cellPadding="4" width="710" border="0">
						<TR>
							<td class="pagetitle" noWrap align="right" width="100%" bgColor="#ffffcc" colSpan="2"
								height="20">&nbsp;
								<br>
								<uc1:smftopnavbuttons id="SmfTopNavButtons1" runat="server"></uc1:smftopnavbuttons></td>
						</TR>
					</table>
				</td>
			</tr>
		</table>
		</CENTER>
		<center>
			<table height="91" cellSpacing="0" cellPadding="0" width="100%" bgColor="#ffffff" border="0">
				<tr>
					<td vAlign="middle" noWrap align="center" bgColor="#ffffcc" colSpan="2">
						<table style="BORDER-COLLAPSE: collapse" borderColor="black" height="91" cellSpacing="0"
							cellPadding="4" width="710" border="0">
							<TR>
								<td class="pagetitle" noWrap align="center" width="100%" bgColor="#ffffcc" colSpan="2"
									height="123">
									<P>
									<P>
										<hr SIZE="2">
										<FONT face="Verdana" color="#003399" size="4"><STRONG>Technical Skill Code</STRONG></FONT>
										<hr>
									<P></P>
									<P>&nbsp;</P>
								</td>
							</TR>
						</table>
					</td>
				</tr>
			</table>
		</center>
		<center>
			<table height="503" cellSpacing="0" cellPadding="0" width="100%" bgColor="#ffffff" border="0">
				<TBODY>
					<tr>
						<td vAlign="top" bgColor="#ffffcc" colSpan="2" height="7"></td>
					</tr>
					<tr>
						<td vAlign="top" align="center" bgColor="#ffffcc" colSpan="2" height="512">
							<table style="BORDER-COLLAPSE: collapse" borderColor="black" height="434" cellSpacing="0"
								cellPadding="4" width="390" border="0">
								<TBODY>
									<tr>
										<td align="center" width="519" bgColor="#ffffcc" height="176"><asp:datagrid id="DataGrid1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="None"
												BorderWidth="1px" CellPadding="4" width="100%" AllowSorting="True">
												<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
												<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
												<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
												<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="White"></ItemStyle>
												<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
													ForeColor="Black" VerticalAlign="Middle" BackColor="LightSkyBlue"></HeaderStyle>
												<Columns>
													<asp:BoundColumn DataField="Skills" HeaderText="Skills"></asp:BoundColumn>
													<asp:BoundColumn DataField="Priority" HeaderText="Priority">
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn>
														<ItemTemplate>
															<asp:LinkButton id="Edit" runat="server" CommandName="Edit">Edit</asp:LinkButton>&nbsp;&nbsp;
															<asp:LinkButton id="Delete" runat="server" CommandName="Delete">Delete</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle Font-Size="X-Small" Font-Names="Verdana" HorizontalAlign="Left" ForeColor="White"
													BackColor="#999999" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></td>
									</tr>
									<tr>
										<td align="center" width="519" bgColor="#ffffcc" colSpan="2" height="105">
											<P><br>
												<asp:linkbutton id="AddNewTechSkill" style="TEXT-DECORATION: none" runat="server" ForeColor="Navy">Add</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:linkbutton id="homelink" style="TEXT-DECORATION: none" runat="server" ForeColor="Navy">Back</asp:linkbutton></P>
											<P>&nbsp;</P>
											<P><asp:panel id="Panel1" runat="server" BackColor="WhiteSmoke" BorderColor="Silver" BorderStyle="Solid"
													BorderWidth="1px" HorizontalAlign="Center" Width="360px" Height="181px" Visible="False"><BR>
													<asp:Label id="Label2" runat="server" Height="8px" Width="63px" Font-Size="X-Small" Font-Names="Verdana"
														Font-Bold="True">Mode:      </asp:Label>
													<asp:Label id="Label3" runat="server" Font-Size="X-Small" Font-Names="Tahoma">Unknown Mode</asp:Label>
													<P>
														<asp:Label id="Label1" runat="server" Height="18px" Width="61px" Font-Size="X-Small" Font-Names="Verdana"
															Font-Bold="True">Skill: </asp:Label>&nbsp;&nbsp;
														<asp:TextBox id="TextBox1" runat="server" Width="214px"></asp:TextBox><BR>
														<asp:Label id="Label6" runat="server" Height="18px" Width="61px" Font-Size="X-Small" Font-Names="Verdana"
															Font-Bold="True">Priority:</asp:Label>&nbsp;&nbsp;
														<asp:DropDownList id="dlPriority" runat="server" Width="214px">
															<asp:ListItem Value="1">1 - Highest</asp:ListItem>
															<asp:ListItem Value="2">2</asp:ListItem>
															<asp:ListItem Value="3">3</asp:ListItem>
															<asp:ListItem Value="4">4</asp:ListItem>
															<asp:ListItem Value="5">5</asp:ListItem>
															<asp:ListItem Value="6">6</asp:ListItem>
															<asp:ListItem Value="7">7</asp:ListItem>
															<asp:ListItem Value="8">8</asp:ListItem>
															<asp:ListItem Value="9" Selected="True">9 - Lowest</asp:ListItem>
														</asp:DropDownList></P>
													<P>
														<cc1:confirmbutton id="Confirmbutton1" runat="server" Width="100px" Text="Delete" CommandName="Delete"
															PopupMessage="This will delete entries of this skill in all employee profiles.  Are you sure you want to continue?"></cc1:confirmbutton>
														<asp:Button id="Button1" runat="server" Width="100px" Text="Save"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp; 
														&nbsp;
														<asp:Button id="Button2" runat="server" Width="100px" Text="Cancel"></asp:Button></P>
													<P>
														<asp:Label id="Label4" runat="server" ForeColor="Red" Width="356px" Font-Size="X-Small" Font-Bold="True">* Warning:  this also updates the employee table.</asp:Label></P>
												</asp:panel>
											<P><asp:textbox id="OldValue" runat="server" Visible="False"></asp:textbox></P>
										</td>
									</tr>
								</TBODY>
							</table>
							<P>&nbsp;</P>
						</td>
					</tr>
				</TBODY>
			</table>
		</center>
	</form>
</body>

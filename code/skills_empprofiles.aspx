<%@ Page language="c#" Codebehind="skills_empprofiles.aspx.cs" AutoEventWireup="True" Inherits="SmfRewriteProject.skills_empprofiles" %>
<%@ Register TagPrefix="uc1" TagName="SmfTopNavButtons" Src="SmfTopNavButtons.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Employee Catalog</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="skills_stylesheet.css" type="text/css" rel="stylesheet">
		<base target="_self">
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
	<body bgColor="#ffffcc">
		<div id="skills">
			<form id="Form1" method="post" runat="server">
				<center>
					<table height="24" cellSpacing="0" cellPadding="0" width="80%" bgColor="#ffffff">
						<tr>
							<td vAlign="middle" noWrap align="right"><br>
								<uc1:smftopnavbuttons id="SmfTopNavButtons1" runat="server"></uc1:smftopnavbuttons>&nbsp;
								<br>
								<br>
							</td>
						</tr>
					</table>
				</center>
				<center>
					<table cellSpacing="0" cellPadding="0" width="80%">
						<TR>
							<td class="pagetitle" noWrap align="center" colSpan="2">
								<hr>
								Employee&nbsp;Catalogue
								<hr>
								<br>
								<br>
								<br>
							</td>
						</TR>
					</table>
				</center>
				<center>
					<table class="simsearch">
						<tr>
							<td vAlign="middle" align="right" width="500"><span class="searchnote">Search Name:</span>&nbsp;&nbsp;
								<asp:textbox id="txtSearchName" runat="server"></asp:textbox>&nbsp;
								<asp:button id="btnSearch" runat="server" Text="Go" onclick="btnSearch_Click"></asp:button></td>
							<td align="left" width="500">
								<P>&nbsp;&nbsp;
									<asp:linkbutton id="LinkButton1" runat="server" Font-Size="Smaller" onclick="LinkButton1_Click">View All</asp:linkbutton>&nbsp;&nbsp;
									<asp:linkbutton id="LinkButton2" runat="server" Font-Size="Smaller" onclick="LinkButton2_Click">Advanced Search</asp:linkbutton>&nbsp;&nbsp;
								</P>
							</td>
						</tr>
					</table>
				</center>
				<center>
					<table id="Result" cellSpacing="0" cellPadding="0" width="80%" bgColor="#ffffff" border="1">
						<tr>
							<td vAlign="bottom" width="30%" colSpan="3" height="50"><span class="legend">
									<P>&nbsp;</P>
									<P>
								</span>&nbsp;</P></td>
						</tr>
					</table>
				</center>
				<center>
					<table cellSpacing="0" cellPadding="0" width="80%" bgColor="#ffffff" border="1">
						<tr>
							<td><span class="resultnotes"><asp:label id="lblFromName" runat="server"></asp:label>&nbsp;
									<asp:label id="lblToName" runat="server"></asp:label>&nbsp;(
									<asp:label id="lblCount" runat="server" Font-Bold="True"></asp:label>&nbsp;
									<asp:label id="lblEntry" runat="server"></asp:label>)
									<br>
								</span>
							</td>
						</tr>
					</table>
				</center>
				<center>&nbsp;</center>
				<table cellSpacing="0" cellPadding="0" width="80%" align="center" bgColor="#ffffcc" border="1">
					<tr>
						<td><asp:datagrid id="dgResults" runat="server" BackColor="White" BorderColor="Black" BorderWidth="1px"
								BorderStyle="None" CellPadding="4" width="100%" PageSize="12" AutoGenerateColumns="False"
								AllowPaging="True" CellSpacing="1">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
									ForeColor="Black" VerticalAlign="Middle" BackColor="LightSkyBlue"></HeaderStyle>
								<FooterStyle ForeColor="White" BackColor="#999999"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="Number" HeaderText="No.">
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="LoginID" HeaderText="Login ID">
										<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="EmpName" HeaderText="Employee Name">
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
								<PagerStyle Font-Size="X-Small" Font-Names="Verdana" BorderColor="White" HorizontalAlign="Left"
									ForeColor="White" BackColor="#999999" PageButtonCount="1" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><asp:textbox id="txtTransaction" runat="server" Width="0px" Height="0px"></asp:textbox></td>
					</tr>
				</table>
				<center>
					<table>
						<tr>
							<td>
								<asp:linkbutton id="LinkButton3" runat="server" Font-Size="Smaller" onclick="LinkButton3_Click">Back</asp:linkbutton></td>
						</tr>
					</table>
				</center>
			</form>
		</div>
		<asp:linkbutton id="LinkButton4" runat="server" Font-Size="Smaller" Visible="False" onclick="LinkButton4_Click">Extract Excel</asp:linkbutton>
	</body>
</HTML>

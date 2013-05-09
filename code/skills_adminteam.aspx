<%@ Register TagPrefix="uc1" TagName="SmfTopNavButtons" Src="SmfTopNavButtons.ascx" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="SmfRewriteProject" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<script runat="server">
 
		DataTable teamsTable = new DataTable();
  
		void Page_Load(Object sender, EventArgs e) 
		{
			
			// With a database, use an select query to retrieve the data. Because 
			// the data source in this example is an in-memory DataTable, retrieve
			// the data from session state if it exists; otherwise, create the data
			// source.
			GetSource();

			// The DataGrid control maintains state between posts to the server;
			// it only needs to be bound to a data source the first time the page
			// is loaded or when the data source is updated.
			if (!IsPostBack)
			{

				BindGrid();

			}
                   
		}
 
       void GetSource()
	   {
		
		teamsTable = GetTeamsData();

         return;

       }
      
      	DataTable GetTeamsData()
		{
			Teams oTeams = new Teams(((Employee)Session["User"]).ToString());
			WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(
				System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);

			DataSet dset = webAppDataHndlr.QueryRequest(oTeams);
			if (dset == null)
			{
				SMFLibrary.MessageBox(this, "Failed Query. Please contact your system administrator.");
				//return teamsTable;
			}
			DataTable ds = dset.Tables[0];
			
			DataTable teamsTable = new DataTable();
			teamsTable.Columns.Add(new DataColumn("Teams", typeof(string)));
			teamsTable.Columns.Add(new DataColumn("HiddenTeams", typeof(string)));
			teamsTable.Columns.Add(new DataColumn("SubTeams", typeof(string)));
			teamsTable.Columns.Add(new DataColumn("HiddenSubTeams", typeof(string)));

			DataColumn[] keys = new DataColumn[1];
			keys[0] = teamsTable.Columns["Teams"];
			//teamsTable.PrimaryKey = keys;

			DataRow dr;
			
			string tempTeam = "";
			int ctr = 0;
            int selectedTeam = dlistTeams.SelectedIndex;
			
			dlistTeams.Items.Clear();
			foreach (DataRow dbTeamRow in ds.Rows)
			{
				dr = teamsTable.NewRow();
				if ((tempTeam == dbTeamRow["Teams"].ToString()) 
				     && (dgTeams.EditItemIndex != ctr))
				{
					dr["Teams"] = " ";
				}
				else
				{
					dr["Teams"] = dbTeamRow["Teams"].ToString();
					dlistTeams.Items.Add(dbTeamRow["Teams"].ToString());
				}
				tempTeam = dbTeamRow["Teams"].ToString();
				dr["SubTeams"] = dbTeamRow["SubTeam"].ToString();
				dr["HiddenTeams"] = dbTeamRow["Teams"].ToString();
				dr["HiddenSubTeams"] = dbTeamRow["SubTeam"].ToString();
				teamsTable.Rows.Add(dr);
				ctr++;
			}
			
			if (this.dlistTeams.Items.Count > selectedTeam)
			{
			   dlistTeams.SelectedIndex = selectedTeam;
			}

			return teamsTable;
		}
		
		void BindGrid()
		{
			int CurrentPageIndex = dgTeams.CurrentPageIndex;
			//dgTeams.DataSource = teamsTable;
			dgTeams.DataSource = GetTeamsData();
			try
			{
				dgTeams.DataBind();
			}
			catch (System.Web.HttpException e)
			{
				if (e.Message == "Invalid CurrentPageIndex value. It must be >= 0 and < the PageCount.")
				{
					dgTeams.CurrentPageIndex = 0;
					//UpdateDataGrid();
				}
				else
				{
					throw e;
				}
			}
		}
 

 
      void ItemsGrid_Edit(Object sender, DataGridCommandEventArgs e) 
      {

         // Set the EditItemIndex property to the index of the item clicked 
         // in the DataGrid control to enable editing for that item. Be sure
         // to rebind the DateGrid to the data source to refresh the control.
         dgTeams.EditItemIndex = e.Item.ItemIndex;
         BindGrid();

      }
 
      void ItemsGrid_Cancel(Object sender, DataGridCommandEventArgs e) 
      {

         // Set the EditItemIndex property to -1 to exit editing mode. 
         // Be sure to rebind the DateGrid to the data source to refresh
         // the control.
         dgTeams.EditItemIndex = -1;
         BindGrid();

      }
 
      void ItemsGrid_Update(Object sender, DataGridCommandEventArgs e) 
      {
		 String sOldTeam = e.Item.Cells[1].Text;
		 String sOldSubTeam = e.Item.Cells[3].Text;
		 String sNewTeam, sNewSubTeam;
		 try
		 {
			TextBox sTeamBox = (TextBox)e.Item.Cells[0].Controls[0];
			sNewTeam = sTeamBox.Text;
			TextBox sSubTeamBox = (TextBox)e.Item.Cells[2].Controls[0];
			sNewSubTeam = sSubTeamBox.Text;
		 }
		 catch
		 {
			sNewTeam    = e.Item.Cells[0].Text;
			sNewSubTeam = e.Item.Cells[2].Text;
		 }
		  
		//ProductSkills prodSkills = new ProductSkills("ismaelc");
		Teams oTeams = new Teams(((Employee)Session["User"]).ToString());
		WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
		oTeams.updateTeam(sOldTeam, sNewTeam, sOldSubTeam, sNewSubTeam);
		
		//Response.Write(prodSkills.showSqls());
		if(!webAppDataHndlr.NonQueryRequest(oTeams))
		{	
			SMFLibrary.MessageBox(this, "Failed to update skill code. Please contact your system administrator.");
		}
		 
         dgTeams.EditItemIndex = -1;
         BindGrid();

      }
 
       void ItemsGrid_Command(Object sender, DataGridCommandEventArgs e)
      {

         switch(((LinkButton)e.CommandSource).CommandName)
         {

            case "Delete":
               DeleteItem(e);
               break;

            // Add other cases here, if there are multiple ButtonColumns in 
            // the DataGrid control.

            default:
               // Do nothing.
               break;

         }

      }

      void DeleteItem(DataGridCommandEventArgs e)
      {
        String sTeam = e.Item.Cells[1].Text;
        String sSubTeam = e.Item.Cells[3].Text;
        //String sSkill	  = e.Item.Cells[3].Text;
      
		//ProductSkills prodSkills = new ProductSkills("ismaelc");
		Teams oTeams = new Teams(((Employee)Session["User"]).ToString());
		WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
		oTeams.deleteTeam(sTeam, sSubTeam);
		
		//Response.Write(prodSkills.showSqls());
		if(!webAppDataHndlr.NonQueryRequest(oTeams))
		{	
			SMFLibrary.MessageBox(this, "Failed to delete skill code. Please contact your system administrator.");
		}
          // Rebind the data source to refresh the DataGrid control.
         BindGrid();

      }
 
	  void AddSkillType(object sender, EventArgs e)
	  {
	  		//ProductSkills prodSkills = new ProductSkills("ismaelc");
	  		Teams oTeams = new Teams(((Employee)Session["User"]).ToString());
			WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
			oTeams.addTeam(bxTeam.Text);
			bxTeam.Text = "";
			//Response.Write(bxTeam.Text);
			
			if(!webAppDataHndlr.NonQueryRequest(oTeams))
			{	
				SMFLibrary.MessageBox(this, "Failed to add team. Please contact your system administrator.");
			}
			// Rebind the data source to refresh the DataGrid control.
			BindGrid();
	  }
	  
	  void DeleteSkillType(object sender, EventArgs e)
	  {
	  		//ProductSkills prodSkills = new ProductSkills("ismaelc");
	  		Teams oTeams = new Teams(((Employee)Session["User"]).ToString());
			WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
			oTeams.deleteTeam(dlistTeams.SelectedItem.Text);
			//Response.Write(bxTeam.Text,"none");
			
			if(!webAppDataHndlr.NonQueryRequest(oTeams))
			{	
				SMFLibrary.MessageBox(this, "Failed to delete team. Please contact your system administrator.");
			}
			// Rebind the data source to refresh the DataGrid control.
			BindGrid();
	  }	  
	</script>
	<body bottomMargin="0" bgColor="#ffffcc" leftMargin="0" topMargin="0" rightMargin="0">
		<DIV align="center">
			<form id="Form1" runat="server">
				<center>
					<table class="tabbgnd" cellSpacing="0" cellPadding="0" width="100%">
						<TBODY>
							<tr>
								<td class="tabbgnd" noWrap align="center" colSpan="2">
									<div align="center"><font style="COLOR: navy" face="verdana" size="2"><b>
												<TABLE class="tabbgnd" id="Table1" cellSpacing="0" cellPadding="0" width="100%">
													<TR>
														<TD class="tabbgnd" noWrap align="center" colSpan="2"><BR>
															<DIV align="center"><FONT style="COLOR: navy" face="verdana" size="2"><B>Skill Code/Team 
																		Admin</B></FONT></DIV>
														</TD>
													</TR>
												</TABLE>
												<TABLE class="tabbgnd" id="top" cellSpacing="0" cellPadding="0" width="100%">
													<TBODY>
														<TR>
															<TD class="tabbgnd">
																<DIV id="tabmenuskills">
																	<CENTER><A class="inactive" style="TEXT-DECORATION: none" href="skills_admintech.aspx"><FONT size="2">Technical 
																				Skill Code</FONT></A>&nbsp;<A class="inactive" style="TEXT-DECORATION: none" href="skills_adminprod.aspx"><FONT size="2">Product 
																				Knowledge Code</FONT></A>
																		<SPAN class="active">
																			<FONT size="2">Team Admin</FONT></SPAN>
																</DIV>
				</center>
			</TD></TR></TBODY></TABLE></B></FONT></DIV>
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
										<FONT face="Verdana" color="#003399" size="4"><STRONG>Add/Delete Team</STRONG></FONT>
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
		<table align="center">
			<tr>
				<td align="left"><asp:textbox id="bxTeam" Width="120" Runat="server"></asp:textbox><asp:button id="btnSkillType" onclick="AddSkillType" Runat="server" Text="Add"></asp:button></td>
				<td align="right"><asp:dropdownlist id="dlistTeams" Runat="server"></asp:dropdownlist><asp:button id="btnDelSkillType" onclick="DeleteSkillType" Runat="server" Text="Delete"></asp:button></td>
			</tr>
			<tr>
				<td colSpan="2"><asp:datagrid id="dgTeams" runat="server" Height="166px" BackColor="White" BorderColor="Black"
						BorderWidth="1px" BorderStyle="None" CellPadding="4" AutoGenerateColumns="False" OnItemCommand="ItemsGrid_Command"
						OnUpdateCommand="ItemsGrid_Update" OnCancelCommand="ItemsGrid_Cancel" OnEditCommand="ItemsGrid_Edit">
						<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
						<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
							ForeColor="Black" VerticalAlign="Middle" BackColor="LightSkyBlue"></HeaderStyle>
						<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
						<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
						<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="White"></ItemStyle>
						<Columns>
							<asp:BoundColumn DataField="Teams" HeaderText="Teams"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="HiddenTeams" ReadOnly="True"></asp:BoundColumn>
							<asp:BoundColumn DataField="SubTeams" HeaderText="SubTeams"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="HiddenSubTeams" ReadOnly="True"></asp:BoundColumn>
							<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" HeaderText="Edit item" CancelText="Cancel"
								EditText="Edit">
								<HeaderStyle Wrap="False"></HeaderStyle>
								<ItemStyle Wrap="False"></ItemStyle>
							</asp:EditCommandColumn>
							<asp:ButtonColumn Text="Delete" HeaderText="Delete item" CommandName="Delete"></asp:ButtonColumn>
						</Columns>
					</asp:datagrid></td>
			</tr>
		</table>
		<P>&nbsp;</P>
		<center><A href="skills_menu.aspx">Back</A></center>
		</FORM></DIV>
	</body>
</HTML>

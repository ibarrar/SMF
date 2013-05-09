<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="SmfRewriteProject" %>
<%@ Register TagPrefix="uc1" TagName="SmfTopNavButtons" Src="SmfTopNavButtons.ascx" %>
<%@ Page %>
<HTML>
	<script runat="server">
 
		DataTable prodSkillsTable = new DataTable();
  
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
		
		prodSkillsTable = GetProdSkillsData();

         return;

       }
      
      	DataTable GetProdSkillsData()
		{
			// TechnicalSkills techSkills = new TechnicalSkills(((Employee)Session["User"]).ToString());
			ProductSkills prodSkills = new ProductSkills("ismaelc");
			WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(
				System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);

			DataSet dset = webAppDataHndlr.QueryRequest(prodSkills);
			if (dset == null)
			{
				SMFLibrary.MessageBox(this, "Failed Query. Please contact your system administrator.");
				//return prodSkillsTable;
			}
			DataTable ds = dset.Tables[0];
			
			DataTable prodSkillsTable = new DataTable();
			prodSkillsTable.Columns.Add(new DataColumn("Skills", typeof(string)));
			prodSkillsTable.Columns.Add(new DataColumn("HiddenSkills", typeof(string)));
			prodSkillsTable.Columns.Add(new DataColumn("SubSkills", typeof(string)));
			prodSkillsTable.Columns.Add(new DataColumn("HiddenSubSkills", typeof(string)));

			DataColumn[] keys = new DataColumn[1];
			keys[0] = prodSkillsTable.Columns["Skills"];
			//prodSkillsTable.PrimaryKey = keys;

			DataRow dr;
			
			string tempSkillType = "";
			int ctr = 0;
            int selectedSkillType = dlistSkillType.SelectedIndex;
			
			dlistSkillType.Items.Clear();
			foreach (DataRow dbSkillRow in ds.Rows)
			{
				dr = prodSkillsTable.NewRow();
				if ((tempSkillType == dbSkillRow["sSkillType"].ToString()) 
				     && (dgProdSkills.EditItemIndex != ctr))
				{
					dr["Skills"] = " ";
				}
				else
				{
					dr["Skills"] = dbSkillRow["sSkillType"].ToString();
					dlistSkillType.Items.Add(dbSkillRow["sSkillType"].ToString());
				}
				tempSkillType = dbSkillRow["sSkillType"].ToString();
				dr["HiddenSkills"] = dbSkillRow["sSkillType"].ToString();
				dr["SubSkills"] = dbSkillRow["sSkill"].ToString();
				dr["HiddenSubSkills"] = dbSkillRow["sSkill"].ToString();	
				prodSkillsTable.Rows.Add(dr);
				ctr++;
			}
			
			if (this.dlistSkillType.Items.Count > selectedSkillType)
			{
			   dlistSkillType.SelectedIndex = selectedSkillType;
			}

			return prodSkillsTable;
		}
		
		void BindGrid()
		{
			int CurrentPageIndex = dgProdSkills.CurrentPageIndex;
			//dgProdSkills.DataSource = prodSkillsTable;
			dgProdSkills.DataSource = GetProdSkillsData();
			try
			{
				dgProdSkills.DataBind();
			}
			catch (System.Web.HttpException e)
			{
				if (e.Message == "Invalid CurrentPageIndex value. It must be >= 0 and < the PageCount.")
				{
					dgProdSkills.CurrentPageIndex = 0;
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
         dgProdSkills.EditItemIndex = e.Item.ItemIndex;
         BindGrid();

      }
 
      void ItemsGrid_Cancel(Object sender, DataGridCommandEventArgs e) 
      {

         // Set the EditItemIndex property to -1 to exit editing mode. 
         // Be sure to rebind the DateGrid to the data source to refresh
         // the control.
         dgProdSkills.EditItemIndex = -1;
         BindGrid();

      }
 
      void ItemsGrid_Update(Object sender, DataGridCommandEventArgs e) 
      {
		 String sOldSkillType = e.Item.Cells[1].Text;
		 String sSkillType;
		 try
		 {
			TextBox sSkillBoxType = (TextBox)e.Item.Cells[0].Controls[0];
			sSkillType = sSkillBoxType.Text;
		 }
		 catch
		 {
			sSkillType    = e.Item.Cells[0].Text;
		 }
		  
		 TextBox sSkillBox = (TextBox)e.Item.Cells[2].Controls[0];
		 String sSkill = sSkillBox.Text;
		 String sOldSkill = e.Item.Cells[3].Text;
		 
		ProductSkills prodSkills = new ProductSkills("ismaelc");
		WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
		prodSkills.updateSkill(sOldSkillType, sSkillType, sOldSkill, sSkill);
		
		//Response.Write(prodSkills.showSqls());
		if(!webAppDataHndlr.NonQueryRequest(prodSkills))
		{	
			SMFLibrary.MessageBox(this, "Failed to update skill code. Please contact your system administrator.");
		}
		 
         dgProdSkills.EditItemIndex = -1;
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
        String sSkillType = e.Item.Cells[1].Text;
        String sSkill	  = e.Item.Cells[3].Text;
      
		ProductSkills prodSkills = new ProductSkills("ismaelc");
		WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
		prodSkills.deleteSkill(sSkillType, sSkill);
		
		//Response.Write(prodSkills.showSqls());
		if(!webAppDataHndlr.NonQueryRequest(prodSkills))
		{	
			SMFLibrary.MessageBox(this, "Failed to delete skill code. Please contact your system administrator.");
		}
          // Rebind the data source to refresh the DataGrid control.
         BindGrid();

      }
 
	  void AddSkillType(object sender, EventArgs e)
	  {
	  		ProductSkills prodSkills = new ProductSkills("ismaelc");
			WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
			prodSkills.addSkillType(bxSkillType.Text);
			bxSkillType.Text = "";
			//Response.Write(bxSkillType.Text);
			
			if(!webAppDataHndlr.NonQueryRequest(prodSkills))
			{	
				SMFLibrary.MessageBox(this, "Failed to add skill code. Please contact your system administrator.");
			}
			// Rebind the data source to refresh the DataGrid control.
			BindGrid();
	  }
	  
	  void DeleteSkillType(object sender, EventArgs e)
	  {
	  		ProductSkills prodSkills = new ProductSkills("ismaelc");
			WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
			prodSkills.deleteSkillType(dlistSkillType.SelectedItem.Text);
			//Response.Write(bxSkillType.Text);
			
			if(!webAppDataHndlr.NonQueryRequest(prodSkills))
			{	
				SMFLibrary.MessageBox(this, "Failed to delete skill code. Please contact your system administrator.");
			}
			// Rebind the data source to refresh the DataGrid control.
			BindGrid();
	  }	  
	</script>
	<body bottomMargin="0" bgColor="#ffffcc" leftMargin="0" topMargin="0" rightMargin="0">
		<form runat="server" ID="Form1">
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
									<center><A class="inactive" style="TEXT-DECORATION: none" href="skills_admintech.aspx"><font size="2">Technical 
												Skill Code</font></A>&nbsp;<span class="active"><font size="2">Product 
												Knowledge Code</font></span>
										<A class="inactive" style="TEXT-DECORATION: none" href="skills_adminteam.aspx"><FONT size="2">
												Team Admin</FONT></A>
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
											<FONT face="Verdana" color="#003399" size="4"><STRONG>Product Skill</STRONG></FONT>
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
					<td align="left">
						<asp:TextBox ID="bxSkillType" Runat="server" Width="120" /><asp:Button ID="btnSkillType" Runat="server" Text="Add" OnClick="AddSkillType" />
					</td>
					<td align="right">
						<asp:DropDownList ID="dlistSkillType" Runat="server" /><asp:Button ID="btnDelSkillType" Runat="server" Text="Delete" OnClick="DeleteSkillType" />
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:DataGrid id="dgProdSkills" BackColor="White" BorderColor="Black" BorderStyle="None" BorderWidth="1px"
							CellPadding="4" OnEditCommand="ItemsGrid_Edit" OnCancelCommand="ItemsGrid_Cancel" OnUpdateCommand="ItemsGrid_Update"
							OnItemCommand="ItemsGrid_Command" AutoGenerateColumns="False" runat="server" Height="166px">
							<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
								ForeColor="Black" VerticalAlign="Middle" BackColor="LightSkyBlue"></HeaderStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
							<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="White"></ItemStyle>
							<Columns>
								<asp:BoundColumn DataField="Skills" HeaderText="Skills"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="HiddenSkills" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn DataField="SubSkills" HeaderText="Sub Skills"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="HiddenSubSkills" ReadOnly="True"></asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" HeaderText="Edit item" CancelText="Cancel"
									EditText="Edit">
									<HeaderStyle Wrap="False"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:EditCommandColumn>
								<asp:ButtonColumn Text="Delete" HeaderText="Delete item" CommandName="Delete"></asp:ButtonColumn>
							</Columns>
						</asp:DataGrid>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

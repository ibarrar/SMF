<%@ Import Namespace="SmfRewriteProject" %>
<%@ Import Namespace="System.Data" %>
<%@ Register TagPrefix="uc1" TagName="SmfTopNavButtons" Src="SmfTopNavButtons.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<meta content="False" name="vs_snapToGrid">
	<meta content="True" name="vs_showGrid">
	<script runat="server">
 
		DataTable certsTable = new DataTable();
  
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
				lblUsername.Text = ((Employee)Session["User"]).ToString();
				dxMonth.SelectedItem.Selected = false;
				dxDay.SelectedItem.Selected = false;
				dxMonth.Items[DateTime.Now.Month].Selected = true;
				dxDay.Items[DateTime.Now.Day].Selected = true;
				txYear.Text = DateTime.Now.Year.ToString();				
			}
		}
 
       void GetSource()
	   {
		
		certsTable = GetCertsData();

         return;

       }
      
      	DataTable GetCertsData()
		{
			Certification oCert = new Certification(((Employee)Session["User"]).ToString());
			WebAppDataHandler webAppDataHndlr = new WebAppDataHandler();

			DataSet dset = webAppDataHndlr.QueryRequest(oCert);
			if (dset == null)
			{
				lblUsername.Text = "Failed Certification Query. Please contact your system administrator.";
				return new DataTable();
			}
			DataTable ds = dset.Tables[0];
			
			DataTable certsTable = new DataTable();
			certsTable.Columns.Add(new DataColumn("Certification", typeof(string)));//00
			certsTable.Columns.Add(new DataColumn("HiddenCertification", typeof(string)));//01
			certsTable.Columns.Add(new DataColumn("Month", typeof(int)));//02
			certsTable.Columns.Add(new DataColumn("sMonth", typeof(string)));//04
			certsTable.Columns.Add(new DataColumn("Day", typeof(int)));//05
			certsTable.Columns.Add(new DataColumn("Year", typeof(int)));//07
			certsTable.Columns.Add(new DataColumn("Sponsor", typeof(string)));

			DataColumn[] keys = new DataColumn[1];
			keys[0] = certsTable.Columns["Certification"];

			DataRow dr;
			
			string tempCert = "";
			int ctr = 0;
            int selectedCert = dlistCerts.SelectedIndex;
			
			dlistCerts.Items.Clear();
			foreach (DataRow dbCertRow in ds.Rows)
			{
				dr = certsTable.NewRow();
				if ((tempCert == dbCertRow["sCertnLic"].ToString()) 
				     && (dgCerts.EditItemIndex != ctr))
				{
					dr["Certification"] = " ";
				}
				else
				{
					dr["Certification"] = dbCertRow["sCertnLic"].ToString();
					dr["sMonth"] = getMonthMMM(dbCertRow["dComMM"].ToString());
					dr["Month"] = dbCertRow["dComMM"];
					dr["Day"]   = dbCertRow["dComDD"];
					dr["Year"]  = dbCertRow["dComYYYY"];
					dr["Sponsor"] = dbCertRow["sSponsor"];
					dlistCerts.Items.Add(dbCertRow["sCertnLic"].ToString());
				}
				tempCert = dbCertRow["sCertnLic"].ToString();
				dr["HiddenCertification"] = dbCertRow["sCertnLic"].ToString();
				certsTable.Rows.Add(dr);
				ctr++;
			}
			
			if (this.dlistCerts.Items.Count > selectedCert)
			{
			   dlistCerts.SelectedIndex = selectedCert;
			}

			return certsTable;
		}
		
		void BindGrid()
		{
			int CurrentPageIndex = dgCerts.CurrentPageIndex;
			dgCerts.DataSource = GetCertsData();
			try
			{
				dgCerts.DataBind();
			}
			catch (System.Web.HttpException e)
			{
				if (e.Message == "Invalid CurrentPageIndex value. It must be >= 0 and < the PageCount.")
				{
					dgCerts.CurrentPageIndex = 0;
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
         dgCerts.EditItemIndex = e.Item.ItemIndex;
         BindGrid();

      }
 
      void ItemsGrid_Cancel(Object sender, DataGridCommandEventArgs e) 
      {

         // Set the EditItemIndex property to -1 to exit editing mode. 
         // Be sure to rebind the DateGrid to the data source to refresh
         // the control.
         dgCerts.EditItemIndex = -1;
         BindGrid();

      }
 
      void ItemsGrid_Update(Object sender, DataGridCommandEventArgs e) 
      {
		 String sOldCert = e.Item.Cells[1].Text;
		 String sNewCert, sSponsor;
		 int month=0, day=0, year=0;
		
		 try
		 {
			TextBox sCertBox = (TextBox)e.Item.Cells[0].Controls[0];
			sNewCert = sCertBox.Text;
			DropDownList dMonth = (DropDownList)e.Item.Cells[2].Controls[1];
			DropDownList dDay   = (DropDownList)e.Item.Cells[2].Controls[3];
			TextBox      tYear   = (TextBox)     e.Item.Cells[2].Controls[5];
			month = Convert.ToInt32(dMonth.SelectedValue);
			day   = Convert.ToInt32(dDay.SelectedValue);
			year  = Convert.ToInt32(tYear.Text);
			TextBox sSponsorBox = (TextBox)e.Item.Cells[3].Controls[0];
			sSponsor = sSponsorBox.Text;
			 		 		  
			Certification oCert = new Certification(((Employee)Session["User"]).ToString());
			WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
			oCert.updateCert(sOldCert, sNewCert,month,day,year,sSponsor);
		
			if(!webAppDataHndlr.NonQueryRequest(oCert))
			{	
				SMFLibrary.MessageBox(this, "Failed to update certification/license. Please contact your system administrator.");
			}
		 }
		 catch(System.FormatException ex)
		 {
			SMFLibrary.MessageBox(this, "Input should be in numeric format");
		 }
		 catch
		 {
			sNewCert    = e.Item.Cells[0].Text;
		 }
		 finally
		 {
			dgCerts.EditItemIndex = -1;
			BindGrid();
         }

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
        String sCert = e.Item.Cells[1].Text;

		Certification oCert = new Certification(((Employee)Session["User"]).ToString());
		WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
		oCert.deleteCert(sCert);
		
		if(!webAppDataHndlr.NonQueryRequest(oCert))
		{	
			SMFLibrary.MessageBox(this, "Failed to delete skill code. Please contact your system administrator.");
		}
          // Rebind the data source to refresh the DataGrid control.
         BindGrid();

      }
 
	  void AddCert(object sender, EventArgs e)
	  {
			try
			{
				if(bxCert.Text == "")
				{
					return;
				}
	  			Certification oCert = new Certification(((Employee)Session["User"]).ToString());
				WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
				int month = Convert.ToInt32(dxMonth.SelectedValue);
				int day   = Convert.ToInt32(dxDay.SelectedValue);
				int year = Convert.ToInt32(txYear.Text);
				oCert.addCert(bxCert.Text, month, day, year, txSponsor.Text);
				bxCert.Text = "Enter Certification";
				txYear.Text = DateTime.Now.Year.ToString();
				txSponsor.Text = "Enter Sponsor";
						
				if(!webAppDataHndlr.NonQueryRequest(oCert))
				{	
					SMFLibrary.MessageBox(this, "Failed to add certification/license. Please contact your system administrator.");
				}
			}
			catch(System.FormatException ex)
			{
				SMFLibrary.MessageBox(this, "Input should be in numeric format");
			}
			catch
			{
			}
			finally
			{
				// Rebind the data source to refresh the DataGrid control.
				BindGrid();
			}
	  }
	  
	  void DeleteCert(object sender, EventArgs e)
	  {
	  		
	  		Certification oCert = new Certification(((Employee)Session["User"]).ToString());
			WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
			oCert.deleteCert(dlistCerts.SelectedItem.Text);
			//Response.Write(bxTeam.Text);
			
			if(!webAppDataHndlr.NonQueryRequest(oCert))
			{	
				SMFLibrary.MessageBox(this, "Failed to delete certification/license. Please contact your system administrator.");
			}
			// Rebind the data source to refresh the DataGrid control.
			BindGrid();
	  }	  
	  
	  private string getMonthMMM(string sMonthNum)
	  {
	        switch (sMonthNum)
			{
				case "1": return("Jan");
				case "2": return("Feb");
				case "3": return("Mar");
				case "4": return("Apr");
				case "5": return("May");
				case "6": return("Jun");
				case "7": return("Jul");
				case "8": return("Aug");
				case "9": return("Sep");
				case "10": return("Oct");
				case "11": return("Nov");
			    case "12": return("Dec");
				default: return("Mon");
								  
			}
		}
	</script>
	<body bottomMargin="0" bgColor="#ffffcc" leftMargin="0" topMargin="0" rightMargin="0">
		<DIV align="center">
			<form id="Form1" runat="server">
				<center>
					<table class="tabbgnd" cellSpacing="0" cellPadding="0" width="100%">
						<TBODY>
							<tr>
								<td class="tabbgnd" noWrap align="center" colSpan="2"></td>
							</tr>
						</TBODY>
					</table>
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
				</center>
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
												<FONT face="Verdana" color="#003399" size="4"><STRONG>
														<asp:label id="lblUsername" runat="server">[User's]</asp:label>'s&nbsp;Certifications/Licenses</STRONG></FONT>
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
				<table style="WIDTH: 338px; HEIGHT: 72px" align="center">
					<tr height="40">
						<td align="left" bgColor="green">&nbsp;<asp:textbox id="bxCert" Width="120" Runat="server">Enter Certification</asp:textbox>&nbsp;<asp:dropdownlist id="dxMonth" runat="server" Width="57px" Height="18px">
								<asp:ListItem Value="00">-</asp:ListItem>
								<asp:ListItem Value="01">Jan</asp:ListItem>
								<asp:ListItem Value="02">Feb</asp:ListItem>
								<asp:ListItem Value="03">Mar</asp:ListItem>
								<asp:ListItem Value="04">Apr</asp:ListItem>
								<asp:ListItem Value="05">May</asp:ListItem>
								<asp:ListItem Value="06">Jun</asp:ListItem>
								<asp:ListItem Value="07">Jul</asp:ListItem>
								<asp:ListItem Value="08">Aug</asp:ListItem>
								<asp:ListItem Value="09">Sep</asp:ListItem>
								<asp:ListItem Value="10">Oct</asp:ListItem>
								<asp:ListItem Value="11">Nov</asp:ListItem>
								<asp:ListItem Value="12">Dec</asp:ListItem>
							</asp:dropdownlist>&nbsp;<asp:dropdownlist id="dxDay" runat="server" Width="45px">
								<asp:ListItem Value="0">-</asp:ListItem>
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
							</asp:dropdownlist>&nbsp;<asp:textbox id="txYear" runat="server" Width="42px">YYYY</asp:textbox>&nbsp;<asp:textbox id="txSponsor" runat="server" Width="128px">Enter Sponsor</asp:textbox>&nbsp;<asp:button id="btnCert" onclick="AddCert" Text="Add" Runat="server" Height="22px"></asp:button></td>
						<td align="right" bgColor="red"><asp:dropdownlist id="dlistCerts" Runat="server"></asp:dropdownlist>&nbsp;<asp:button id="btnDelCert" onclick="DeleteCert" Text="Delete" Runat="server" Height="22px"></asp:button>&nbsp;</td>
					</tr>
					<tr>
						<td colSpan="2"><asp:datagrid id="dgCerts" runat="server" Width="651px" CellPadding="4" BorderColor="Black" OnEditCommand="ItemsGrid_Edit"
								OnCancelCommand="ItemsGrid_Cancel" OnUpdateCommand="ItemsGrid_Update" OnItemCommand="ItemsGrid_Command"
								AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BackColor="White" Height="103px">
								<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
								<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
									ForeColor="Black" VerticalAlign="Middle" BackColor="LightSkyBlue"></HeaderStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#F0F0F0"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="White"></ItemStyle>
								<Columns>
									<asp:BoundColumn DataField="Certification" HeaderText="Certification/License"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="HiddenCertification" ReadOnly="True"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Date Acquired">
										<ItemTemplate>
											<table>
												<tr>
													<td>
														<asp:Label ID="lblMonth" Font-Size="X-Small" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"sMonth") %>' />
														<asp:Label ID="lblDay" Font-Size="X-Small" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Day") %>' />
														<asp:Label ID="lblYear" Font-Size="X-Small" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Year") %>' />
													</td>
												</tr>
											</table>
										</ItemTemplate>
										<EditItemTemplate>
											<table>
												<tr>
													<td>
														<asp:DropDownList id="dropDownListMonth" SelectedIndex='<%# DataBinder.Eval(Container.DataItem,"Month")%>' Runat="server">
															<asp:ListItem Value="00"></asp:ListItem>
															<asp:ListItem Value="01">Jan</asp:ListItem>
															<asp:ListItem Value="02">Feb</asp:ListItem>
															<asp:ListItem Value="03">Mar</asp:ListItem>
															<asp:ListItem Value="04">Apr</asp:ListItem>
															<asp:ListItem Value="05">May</asp:ListItem>
															<asp:ListItem Value="06">Jun</asp:ListItem>
															<asp:ListItem Value="07">Jul</asp:ListItem>
															<asp:ListItem Value="08">Aug</asp:ListItem>
															<asp:ListItem Value="09">Sep</asp:ListItem>
															<asp:ListItem Value="10">Oct</asp:ListItem>
															<asp:ListItem Value="11">Nov</asp:ListItem>
															<asp:ListItem Value="12">Dec</asp:ListItem>
														</asp:DropDownList>
													</td>
													<td>
														<asp:DropDownList id="dropDownListDay" SelectedIndex='<%# DataBinder.Eval(Container.DataItem,"Day")%>' Runat="server">
															<asp:ListItem Value="0"></asp:ListItem>
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
														</asp:DropDownList>,</td>
													<td>
														<asp:TextBox ID="textBoxYear" runat="server" Width="40px" Text='<%# DataBinder.Eval(Container.DataItem,"Year")%>'>
														</asp:TextBox></td>
												</tr>
											</table>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="Sponsor" HeaderText="Company/Sponsor"></asp:BoundColumn>
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
			</form>
		</DIV>
	</body>
</HTML>

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SmfRewriteProject
{
	/// <summary>
	/// Summary description for SkillsRepDetailed.
	/// </summary>
	public partial class skills_empprofiles :  ViewController
	{



        private DataTable employeeTable;
		private int RecordCount;


		private DataTable GetReportData(string sSearchName) 
		{
			employeeTable = new DataTable();
			DataRow dr;

			/**** Use IStorable Objects ****/
			ReportGenerator rgTechDetail = new ReportGenerator();
			WebAppDataHandler wadTechDetail = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);			

			string sWhereClause = "";

			if (((Employee)Session["User"]).sEmpPermission == "A")
			{
				//employeeList.EmployeeRetrieve(this.TextBox1.Text, "All");
				if (sSearchName != "")
				{
					sSearchName = "%" + sSearchName.ToUpper() + "%";
					sWhereClause = " where (UPPER(sLastName) like '" + sSearchName + "' or "
						+ "UPPER(sFirstName) like '" + sSearchName + "') and sEmpPermission <> 'A'";
				}
				else
				{
					sWhereClause = " where sEmpPermission <> 'A'";
				}

			}
			else
			{
				//employeeList.EmployeeRetrieve(this.TextBox1.Text, ((Employee)Session["User"]).getEmpOfc());
				/* Create where clause to filter report*/
				if (sSearchName != "")
				{
					sSearchName = "%" + sSearchName.ToUpper() + "%";
					sWhereClause = " where (UPPER(sLastName) like '" + sSearchName + "' or "
						+ "UPPER(sFirstName) like '" + sSearchName + "') and sOfc = '" 
						+ ((Employee)Session["User"]).sOfc + "' and sEmpPermission <> 'A'";
				}
				else
				{
					sWhereClause = " where sOfc = '" 
						+ ((Employee)Session["User"]).sOfc + "' and sEmpPermission <> 'A'";
				}
			}
			


            employeeTable.Columns.Add(new DataColumn("Number", typeof(string)));
            employeeTable.Columns.Add(new DataColumn("LoginID", typeof(string)));
			employeeTable.Columns.Add(new DataColumn("EmpName", typeof(string)));
            employeeTable.Columns.Add(new DataColumn("Status", typeof(string)));
            employeeTable.Columns.Add(new DataColumn("Access", typeof(string)));

            DataColumn[] keys = new DataColumn[1];
            keys[0] = employeeTable.Columns["LoginID"];
            employeeTable.PrimaryKey = keys;
			
		    //dt.Columns.Add(new DataColumn("Edit Profile", typeof(string)));
			
			/**** SQL to get column headers and rows ****/			
			string[] arrSQL = {"select sLastName, sFirstName,sEmpStat,sEmpPermission, sLoginID, sEmpID from  T_SKILLS_EMPINFO" + sWhereClause + " order by sLastName, sFirstName"};
			
			rgTechDetail.getQueryRequest(arrSQL);

			// Execute both sql for columns and rows
			DataSet ds = wadTechDetail.CreateReport(rgTechDetail);

			int	count =0;
			lblFromName.Text = "";
			lblToName.Text = "";
			foreach (DataRow dbEmpRow in ds.Tables[0].Select(null,null,DataViewRowState.CurrentRows))
			{
				count++;
				dr = employeeTable.NewRow();
				dr["Number"] = count;
				dr["EmpName"] = dbEmpRow["sLastName"].ToString() + ", " + dbEmpRow["sFirstName"].ToString();
				
				string sStatus = dbEmpRow["sEmpStat"].ToString();
				switch (sStatus)
				{
					case "I" : dr["Status"] = "Inactive"; break;
					case "A" : dr["Status"] = "Active"; break;
				}

				
				string sAccess = dbEmpRow["sEmpPermission"].ToString();
				switch (sAccess)
				{
					case "S" : dr["Access"] = "Super"; break;
					case "O" : dr["Access"] = "Ordinary"; break;
				}

				string sLogin = dbEmpRow["sLoginID"].ToString();
				dr["LoginID"] = sLogin;
               //"<a href='skills_indsummary.aspx?LoginId=" + sLogin + "'>" + "View Individual Summary </a>";
				//dr["Edit Profile"] = "<a href='IndSummary.aspx?'>Edit Profile </a>";
				
//				if (lblFromName.Text == "")
//				{
//					lblFromName.Text = dbEmpRow["sLastName"].ToString();
//				}
//				lblToName.Text = dbEmpRow["sLastName"].ToString();
				
				employeeTable.Rows.Add(dr);
			}

            Session["EmployeesSearch"] = employeeTable;
			
//			DataView dv = new DataView(employeeTable);
//
//			//update labels
//			
//			lblEntry.Text = "entries";
//			if (dv.Count == 1)
//			{
//				lblEntry.Text = "entry";
//			}
//				
//			lblCount.Text = dv.Count.ToString();
		
            dgResults.CurrentPageIndex = 0;
						
			// populate the total count label
			this.RecordCount = employeeTable.Rows.Count;

			return (DataTable) Session["EmployeesSearch"];
		}


		private void UpdateNameList()
		{			
			if (dgResults.Items.Count > 0)
			{
				lblFromName.Text = "List of employees from " + dgResults.Items[0].Cells[2].Text;
				lblToName.Text = " to " + dgResults.Items[dgResults.Items.Count - 1].Cells[2].Text;			
			}
			else
			{	
				lblFromName.Text = "No records found";
				lblToName.Text = "";
			}
			lblCount.Text = this.RecordCount.ToString();
			lblEntry.Text = "entries";
			if (this.RecordCount == 1)
				lblEntry.Text = "entry";
		
		}



		protected void dgResults_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
         if (employeeTable != null)
         {
            dgResults.DataSource = employeeTable;
			this.RecordCount = employeeTable.Rows.Count;
            dgResults.CurrentPageIndex = e.NewPageIndex ;			
            dgResults.DataBind();
			UpdateNameList();
		    
         }
		}


      override protected void OnInit(EventArgs e)
      {
      	//
      	// CODEGEN: This call is required by the ASP.NET Web Form Designer.
      	//
      	InitializeComponent();
      	base.OnInit(e);
      }

		private void InitializeComponent()
		{
			this.dgResults.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgResults_ItemCreated);
			this.dgResults.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgResults_ItemCommand);
			this.dgResults.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgResults_PageIndexChanged);
			this.dgResults.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgResults_ItemDataBound);

		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			dgResults.DataSource = GetReportData(txtSearchName.Text);
			dgResults.CurrentPageIndex = 0;
			dgResults.DataBind();
			UpdateNameList();
			
		}

      private void dgResults_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
      {
   

		  if (e.CommandName == "View")
		  {
			  string transType = this.txtTransaction.Text;
			  if (transType != "")  // THIS IS IMPORTANT FOR THE “BACK” ISSUE I MENTIONED IN MY
			  {                     // PREVIOUS EMAIL
				  updateEmployeeGrid();
			  }
		  }
 
		  if (e.CommandName == "Edit")

		  {
			  string transType = this.txtTransaction.Text;
			  string  login_id = e.Item.Cells[1].Text;
			  if (transType == "Save")
			  {
				  SMFLibrary.MessageBox(this, "Saved employee information.");
				  updateEmployeeGrid();
			  }
 
			  if (transType == "Delete")
			  {
				  updateEmployeeGrid();
			  }
		  }
 		  this.txtTransaction.Text = "";
	  }

		private void updateEmployeeGrid()
		{
			int curPage = dgResults.CurrentPageIndex;
			string tempSearchString = txtSearchName.Text;
			//GenerateDataGrid(); // Or the method you use to extract records from the database.
            dgResults.DataSource = GetReportData(tempSearchString);
			dgResults.CurrentPageIndex = 0;
			this.dgResults.DataBind();
			UpdateNameList();
			
			if ((dgResults.PageCount - 1) >= curPage)
			{
				dgResults.CurrentPageIndex = curPage;
			}
			else
			{
				dgResults.CurrentPageIndex = dgResults.PageCount - 1;
			}
			UpdateDataGrid();
		}

		private void UpdateDataGrid()
		{
			if (employeeTable != null)
			{
				this.dgResults.DataSource = employeeTable;
				this.RecordCount = employeeTable.Rows.Count;
				this.dgResults.DataBind();
				UpdateNameList();
				
			}
		}


		private void dgResults_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType == ListItemType.Item) ||
				(e.Item.ItemType == ListItemType.AlternatingItem))
			{
				System.Web.UI.WebControls.LinkButton tempLink = 
					(System.Web.UI.WebControls.LinkButton) e.Item.Cells[5].FindControl("ViewSummary"); 

				tempLink.ControlStyle.ForeColor = Color.FromName(System.Drawing.KnownColor.Blue.ToString());

				String javascript = "";

				if (((Employee)Session["User"]).sEmpPermission == "A" ||
					((Employee)Session["User"]).sEmpPermission == "S")
				{
					javascript = "var w = window.open('window_" + System.Configuration.ConfigurationSettings.AppSettings["/IndividualSummary"] + "?sLoginID=" + e.Item.Cells[1].Text +"','window','width=763px,height=700px,toolbar=no,scrollbars=yes,location=no,status=yes,menubar=yes'); w.focus(); return false;";
				}
				else
				{
					javascript = "window.showModalDialog('window_" + System.Configuration.ConfigurationSettings.AppSettings["/IndividualSummary"] + "?sLoginID=" +
						e.Item.Cells[1].Text + "',window,'scroll:yes;edge:sunken;status:yes;resizable:no;help:no;center:yes;dialogHeight:700px;dialogWidth:763px;');";
				}

				tempLink.Attributes.Add("onclick", javascript);

				tempLink = (System.Web.UI.WebControls.LinkButton) e.Item.Cells[5].FindControl("EditProfile"); 
				tempLink.ControlStyle.ForeColor = Color.FromName(System.Drawing.KnownColor.Blue.ToString());

				string dHeight = "196px";
				if (e.Item.Cells[2].Text.Length > 30)
				{
					dHeight = "199px";
				}

				javascript = "ShowDialog('" + e.Item.Cells[1].Text + "', '" + dHeight + "')";
				tempLink.Attributes.Add("onclick", javascript);
			}
		}


      protected void Page_Load(object sender, System.EventArgs e)
      {
         if( this.IsPostBack )
         {
            employeeTable = (DataTable) Session["EmployeesSearch"];
         }
         else
         {
//            dgResults.AllowPaging = true;
//            dgResults.PagerStyle.Mode = PagerMode.NumericPages;
//            dgResults.PagerStyle.PageButtonCount = 5;
//            dgResults.PageSize = 12;
            if (txtSearchName.Text == "")
            {
               dgResults.DataSource = GetReportData("");
            }
            else
            {
               dgResults.DataSource = GetReportData(txtSearchName.Text);
            }

//			int iPageButtonCount = this.RecordCount / dgResults.PageSize;
//			if (this.RecordCount % dgResults.PageSize > 0) 
//				iPageButtonCount++;				
//			dgResults.PagerStyle.PageButtonCount = iPageButtonCount;

            dgResults.DataBind();   
			UpdateNameList();
         }
         SMFLibrary.SetFocus(this, this.dgResults);
      
      }



//      private void lnkExtactExcel_Click(object sender, System.EventArgs e)
//      {
//         string sVirtualFileName = "/SmfRewriteProject/Reports/skills_empprofiles_" + ((Employee)Session["User"]).getLoginID() + "_" + Session.SessionID.ToString() + ".xls";
//         string sFileName = Server.MapPath(sVirtualFileName) ;
//         // Use the extract excel object to create the excel file for the report
//         ExtractExcel xlReport = new ExtractExcel(sFileName, (DataTable)Session["EmployeesSearch"]);
//         // Write and save the excel report
//         string errorMsg = xlReport.WriteData();
//         if (errorMsg == "")            
//         {
//            Response.Redirect(sVirtualFileName);
//         }
//         else
//         {
//            SMFLibrary.MessageBox(this, errorMsg);
//         }      
//      }


		protected void LinkButton1_Click(object sender, System.EventArgs e)
		{
			//view all
			dgResults.DataSource = GetReportData("");
			dgResults.DataBind();
			UpdateNameList();
			txtSearchName.Text = "";
		}

		protected void LinkButton2_Click(object sender, System.EventArgs e)
		{
			//advanced search
			Server.Transfer(System.Configuration.ConfigurationSettings.AppSettings["/AdvancedSearch"]);
		}

		protected void LinkButton3_Click(object sender, System.EventArgs e)
		{
			//back
			Server.Transfer(System.Configuration.ConfigurationSettings.AppSettings["/Menu"]);
		}

		protected void LinkButton4_Click(object sender, System.EventArgs e)
		{
			//Extract Excel
			string sVirtualFileName = "/Reports/skills_empprofiles_" + ((Employee)Session["User"]).sLoginID + "_" + Session.SessionID.ToString() + ".xls";
			string sFileName = Server.MapPath(sVirtualFileName) ;
			// Use the extract excel object to create the excel file for the report
			ExtractExcel xlReport = new ExtractExcel(sFileName, (DataTable)Session["EmployeesSearch"]);
			// Write and save the excel report
			string errorMsg = xlReport.WriteData();
			if (errorMsg == "")            
			{
				Response.Redirect(sVirtualFileName);
			}
			else
			{
				SMFLibrary.MessageBox(this, errorMsg);
			}      
		}


		private void dgResults_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Pager)
			{
				System.Web.UI.WebControls.Label PageLabel = new Label();
				PageLabel.Text = "Page ";
				e.Item.Cells[0].Controls.AddAt(0, PageLabel);
			}

			if (employeeTable != null)
			{
				if (employeeTable.Rows.Count > 0)
				{
					int iPageButtonCount = employeeTable.Rows.Count / dgResults.PageSize;
					if (employeeTable.Rows.Count % dgResults.PageSize > 0) 
						iPageButtonCount++;				
					dgResults.PagerStyle.PageButtonCount = iPageButtonCount;
				}
			}
  		}




	}
}

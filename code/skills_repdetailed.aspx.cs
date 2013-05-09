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
using System.Runtime.InteropServices;


namespace SmfRewriteProject
{
	/// <summary>	
	/// Tech Skills Report Detailed
	/// </summary>
	public class skills_repdetailed : ViewController
	{
		protected System.Web.UI.WebControls.TextBox txtSearchName;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Button btnSearch;		
		protected System.Web.UI.WebControls.PlaceHolder plcLink;
		
		protected System.Web.UI.WebControls.LinkButton lnkExtractExcel;
		protected System.Web.UI.WebControls.Label lblExcel;
		protected System.Web.UI.WebControls.LinkButton lnkBack;
		protected SmfReportTab tabReport;
		protected System.Web.UI.WebControls.LinkButton lnkAdvanceSearch;

		protected System.Web.UI.WebControls.DataGrid dgResults;

		// these two properties saves the pages for the headers
		private int SkillPageSize;
		private int SkillCurrentPageIndex;
		private int RecordCount;
		protected System.Web.UI.WebControls.Label lblRepType;

		/* *********************************************
		 * Flag to choose between TECH or PRODUCT detail
		 * assign 0 for TECH and 1 for PRODUCT
		************************************************/
		private int ReportType;
		protected System.Web.UI.WebControls.Label lblNameList;
		protected System.Web.UI.WebControls.LinkButton lnkViewAll;
		protected System.Web.UI.WebControls.DropDownList dropTeamList;
		private ArrayList CustomSQL;  // this contains customized sql for TECH and PRODUCT
		
			
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			if (!Page.IsPostBack)
			{							
				dgResults.AllowPaging = true;
				dgResults.PagerStyle.Mode = PagerMode.NumericPages;				
				dgResults.PageSize = 12;
				dgResults.AutoGenerateColumns = true;				
				//get value of Search Name				
                if (Request.QueryString["sSearchName"] == null)
                {
                    txtSearchName.Text = currentUser.sLastName;
                }
                else
                {
					txtSearchName.Text = Request.QueryString["sSearchName"].ToString();
				}
				
				BindGrid();				
			}	

		}

		private void BindGrid()
		{
			
			dgResults.DataSource = GetReportData(txtSearchName.Text , false);
			dgResults.DataBind();
			UpdateNameList();
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			//setup page if report is TECH or PRODUCT
			CustomSQL = new ArrayList();
			this.ReportType = Convert.ToInt16(Request.QueryString["iType"]);			
			//update the report tab
			this.tabReport.TabActive = this.ReportType + 1;
			SetupPageType(this.ReportType);

			//set paging data for skills
			this.SkillPageSize = 8;	
			this.SkillCurrentPageIndex = Convert.ToInt16(Request.QueryString["iPage"]);			
			
			//set paging for row
			if (Convert.ToInt16(Request.QueryString["iPage"]) != 0)
				dgResults.CurrentPageIndex = Convert.ToInt16(Request.QueryString["iCurrPage"]);

			Teams oTeams = new Teams("");
			WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(
				System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);

			DataSet dset = webAppDataHndlr.QueryRequest(oTeams);
			if (dset == null)
			{
				SMFLibrary.MessageBox(this, "Failed T_TEAMS Query. Please contact your system administrator.");
			}
			else
			{
				if(!Page.IsPostBack)
				{
					dropTeamList.DataSource = dset;
					dropTeamList.DataTextField = "Teams";
					dropTeamList.DataValueField = "Teams";
					dropTeamList.DataBind();

					dropTeamList.Items.Insert(0, new ListItem("All Teams"));
				}
			}

		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.lnkAdvanceSearch.Click += new System.EventHandler(this.lnkAdvanceSearch_Click);
			this.dgResults.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgResults_ItemCreated);
			this.dgResults.DataBinding += new System.EventHandler(this.dgResults_DataBinding);
			this.lnkViewAll.Click += new System.EventHandler(this.btnSearch_Click);
			this.lnkExtractExcel.Click += new System.EventHandler(this.lnkExtractExcel_Click);
			this.lnkBack.Click += new System.EventHandler(this.lnkBack_Click);
			this.dropTeamList.SelectedIndexChanged += new System.EventHandler(this.dropTeamList_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		#region Tools for detailed report
		private string CreateSkillsWhere(ArrayList arrSkills)
		{
            string sReturn = "";
			if (!(arrSkills.Count == 0))
			{
				foreach ( string subSkills in arrSkills)
				{
					sReturn = sReturn + ("'" + (string)subSkills.ToString() + "',");
				}
				sReturn = sReturn.Trim(',').Trim();		
			}
			
			return sReturn;
		}

		/********************************************************
		 * Function Name: CreateLinkPages		 
		 * Purpose:
		 *	This creates the links for the paging on the headers
		 * Parameters:
		 *	iPageIndex	- current page
		 *	iPageSize	- paging size
		 *	iCount		- total number of data
		 * ******************************************************/
		private void CreateLinkPages(int iPageIndex, int iPageSize, int iCount)
		{
			int iLinkCount = iCount /iPageSize;
			if (iCount == 0)
				return;

			if (iCount % iPageSize > 0)
				iLinkCount++;

			for (int i=1; i <= iLinkCount; i++)
			{
				Control objSkillPage;				
				if (iPageIndex + 1 == i)
				{
					Label lblSkillPage = new Label();
					lblSkillPage.Text = i.ToString();
					objSkillPage = lblSkillPage;
				}
				else
				{
					HyperLink hlPager = new HyperLink();
					hlPager.Text = i.ToString();
					int iPage = (i - 1); 
					hlPager.NavigateUrl =  "skills_repdetailed.aspx?iPage=" + iPage.ToString() 
						+ "&iCurrPage=" + dgResults.CurrentPageIndex.ToString()
						+ "&iType=" + this.ReportType.ToString()
						+ "&sSearchName=" + Server.UrlEncode(txtSearchName.Text);					
					objSkillPage = hlPager;
				}
				plcLink.Controls.Add(objSkillPage);

				Label lblTemp = new Label();
				lblTemp.Text = "&nbsp;";
				plcLink.Controls.Add(lblTemp);
			}
		}

		private string SetFirstWhere(string sWhereClause)
		{
			if (sWhereClause.Length == 0)
			{
				sWhereClause = " where";
			}
			else
			{
				sWhereClause += " and";
			}
			return (sWhereClause);
		}


		private DataTable GetReportData(string sSearchName, bool bIsReport) 
		{
			/**** Use IStorable Objects ****/
			ReportGenerator rgTechDetail = new ReportGenerator();
			WebAppDataHandler wadTechDetail = new WebAppDataHandler();			
			ArrayList arrSkills = new ArrayList();
			DataTable dtReturn = new DataTable();
			string sWhereClause = "";
			
			if (sSearchName != "")            
			{

				sSearchName = "%" + sSearchName.ToUpper().Replace("'","''") + "%";
				sWhereClause = " where (UPPER(sLastName) like '" + sSearchName + "' or "
					+ "UPPER(sFirstName) like '" + sSearchName + "')";
			}
	
			if (this.currentUser.sEmpPermission == "S")			
			{
				sWhereClause = SetFirstWhere(sWhereClause) + " sOfc='" + this.currentUser.sOfc  + "'";
			}

			if (this.dropTeamList.SelectedValue.ToString() != "All Teams" )
			{
				sWhereClause += " and sEmpPosition ='" + this.dropTeamList.SelectedValue.ToString() + "'";
			}


			dtReturn.Columns.Add(new DataColumn(" "));
			dtReturn.Columns.Add(new DataColumn("Employee Name"));
			

			/**** SQL to get column headers and rows ****/			
			string[] arrSQL = {this.CustomSQL[0].ToString(), 
							   "select sLastName, sFirstName, sLoginID, sEmpID from  T_SKILLS_EMPINFO" + sWhereClause + " order by sLastName"};
			
			rgTechDetail.getQueryRequest(arrSQL);

			// Execute both sql for columns and rows
			DataSet ds = wadTechDetail.CreateReport(rgTechDetail);

			// Process data for column headers
			if(!(ds.Tables[0].Rows.Count == 0))
			{					
				int iStart = 0, iEnd = ds.Tables[0].Rows.Count;
				//Change the start and end of the loop if data is not for excel report
				if (!bIsReport)
				{
					iStart = this.SkillCurrentPageIndex * this.SkillPageSize;
					iEnd = iStart + this.SkillPageSize;
					if (iEnd > ds.Tables[0].Rows.Count)
						iEnd = ds.Tables[0].Rows.Count;		
				}

				// Used "for loop" instead of "for each" so as not to traverse all rows.	
				for (int iSkill = iStart; iSkill < iEnd; iSkill++)
				{
					DataRow drColHeader = ds.Tables[0].Rows[iSkill];
					DataColumn clHeader = new DataColumn(); 
					clHeader.DataType = typeof(string); 
					clHeader.AllowDBNull = false; 
					clHeader.Caption = drColHeader[0].ToString(); 
					clHeader.ColumnName = drColHeader[0].ToString(); 
					clHeader.DefaultValue = 0;
					clHeader.MaxLength = 1;
					
					dtReturn.Columns.Add(clHeader);				
					arrSkills.Add(drColHeader[0].ToString());
				}

				CreateLinkPages(this.SkillCurrentPageIndex, this.SkillPageSize, ds.Tables[0].Rows.Count );

			}
            
			// Process data for row data 
			if(!(ds.Tables[1].Rows.Count == 0))
			{						
				DataRow drReturn;
				int iRowCount = 1;
				foreach (DataRow dbEmpRow in ds.Tables[1].Select(null,null,DataViewRowState.CurrentRows))
				{
					drReturn = dtReturn.NewRow();
					drReturn[0] = iRowCount.ToString();
					iRowCount++;
			
					drReturn[1] = "<a href=\"javascript:openName('window_skills_indsummary.aspx" 
						+ "?sLoginId="+ dbEmpRow["sLoginID"] + "');\">" + dbEmpRow["sLastName"] + ", " + dbEmpRow["sFirstName"] + "</a>";

					//Change format of name if output is for excel file
					if (bIsReport)
						drReturn[1] = dbEmpRow["sLastName"] + ", " + dbEmpRow["sFirstName"];

									
					string[] sSQL = {this.CustomSQL[1].ToString() + " AND sEmpID=" + dbEmpRow["sEmpId"].ToString() 
										 + " AND " +  this.CustomSQL[2].ToString() + " IN (" + CreateSkillsWhere(arrSkills) + ")"};
										
					
					// Get Tech Skill of each employee using Report Generator					
					rgTechDetail.clearQueryRequest();
					rgTechDetail.getQueryRequest(sSQL);
					DataSet dsTechSkill = wadTechDetail.CreateReport(rgTechDetail);		
				
				if (!(dsTechSkill.Tables[0].Rows.Count == 0))
					{
						foreach (DataRow dbPerSkillRow in dsTechSkill.Tables[0].Select(null,null,DataViewRowState.CurrentRows) )
							drReturn[dbPerSkillRow[0].ToString()] = dbPerSkillRow["sLevel"];
					}
					dtReturn.Rows.Add(drReturn);
				}
			} 

			// populate the total count label
			this.RecordCount = dtReturn.Rows.Count;


			return dtReturn;		
		}

		/************************************************
		 * Name: UpdateNameList
		 * Purpose:
		 *	This routine updates the labels at the top of
		 *	the data grid
		 * ***********************************************/
		private void UpdateNameList()
		{	
			lblNameList.Text = "No records found.";

			if (dgResults.Items.Count > 0)
			{
				string txtEntry = "entry";
				if (this.RecordCount > 1) 
					txtEntry = "entries";
				lblNameList.Text = "List of Employees from " + dgResults.Items[0].Cells[1].Text
									+ " to " + dgResults.Items[dgResults.Items.Count - 1].Cells[1].Text
									+  " ( <b>" + this.RecordCount.ToString() + "</b> " + txtEntry + ")";
				
			}
		}

		private void SetupPageType(int iType)
		{
			if (iType == 0)
			{
				lblRepType.Text = "Technical";
				this.CustomSQL.Add("select distinct sSkill from T_SKILLS_CODE where UPPER(sSkillType)='TECH' order by sSkill");
				this.CustomSQL.Add("select sSkill, sLevel from  T_SKILLS_EMPSKILLS where UPPER(sSkillType)='TECH' ");
				this.CustomSQL.Add(" sSkill ");				
			}
			else 
			{
				lblRepType.Text = "Product";
				this.CustomSQL.Add("select distinct sSkillType from T_SKILLS_CODE where UPPER(sSkillType)<>'TECH' order by sSkillType");
				this.CustomSQL.Add("select sSkillType, sLevel from  T_SKILLS_EMPSKILLS where sSkill='main' ");
				this.CustomSQL.Add(" sSkillType ");
			}

		}

		#endregion


		#region Web Control Events
		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			if (sender.Equals(this.lnkViewAll))
			{
				txtSearchName.Text = "";
			}
			dgResults.DataSource = GetReportData(txtSearchName.Text, false);
			dgResults.CurrentPageIndex = 0;
			dgResults.DataBind();			
			UpdateNameList();
		}

		
		protected void dgResults_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgResults.CurrentPageIndex = e.NewPageIndex ;			
			dgResults.DataSource = GetReportData(txtSearchName.Text, false);
			dgResults.DataBind();			
			UpdateNameList();
		}

		private void dgResults_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Pager)
			{
				System.Web.UI.WebControls.Label PageLabel = new Label();
				PageLabel.Text = "Page ";
				e.Item.Cells[0].Controls.AddAt(0, PageLabel);				
			}
		}     

		private void lnkExtractExcel_Click(object sender, System.EventArgs e)
		{
			// Assign the FileName of the excel file
			string sVirtualFileName = "/SmfRewriteProject/Reports/skills_repdetailed_" + currentUser.sLoginID + "_" + Session.SessionID.ToString() + ".xls";
			string sFileName = Server.MapPath(sVirtualFileName) ;

			// Use the extract excel object to create the excel file for the report
			ExtractExcel xlReport = new ExtractExcel(sFileName, GetReportData("", true));
			// Write and save the excel report
			lblExcel.Text = xlReport.WriteData();

			if (lblExcel.Text == "")		
				Response.Redirect(sVirtualFileName);

			
		}


		private void dgResults_DataBinding(object sender, System.EventArgs e)
		{			
			int iPageButtonCount = this.RecordCount / dgResults.PageSize;
			if (iPageButtonCount > 0)
			{
				if (this.RecordCount % dgResults.PageSize > 0) 
					iPageButtonCount++;		
			
				dgResults.PagerStyle.PageButtonCount = iPageButtonCount;			
			}			
		}

		private void lnkAdvanceSearch_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/AdvancedSearch");
		}

		private void lnkBack_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/Menu");
		}
		#endregion

		private void dropTeamList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindGrid();
		}

				
	}
}

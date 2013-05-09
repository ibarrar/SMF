using System;
using System.IO;
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
	/// Travel Summary
	/// </summary>
	public partial class skills_repvisa : ViewController
	{
		private int RecordCount;
		//		private int SkillCurrentPageIndex;
		//		private int SkillPageSize;
	
		
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			if (!Page.IsPostBack)
			{							
				dgResults.AllowPaging = true;
				dgResults.PagerStyle.Mode = PagerMode.NumericPages;
				dgResults.PagerStyle.PageButtonCount = 10;
				dgResults.PageSize = 12;

				dgResults.DataSource = GetReportData("", false);
				dgResults.DataBind();

				UpdateNameList();

			}			


		}

		protected void Page_Load(object sender, System.EventArgs e)
		{

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

		}
		#endregion


		private DataTable GetReportData(string sSearchName, bool bIsReport) 
		{
			/**** Use IStorable Objects ****/
			ReportGenerator rgTechDetail = new ReportGenerator();
			WebAppDataHandler wadTechDetail = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);			
			ArrayList arrSkills = new ArrayList();
			DataTable dt = new DataTable();
			DataRow dr;
			string sWhereClause = "";
			int i = 0;

			if (sSearchName != "")
			{
				sSearchName = "%" + sSearchName.ToUpper() + "%";
				sWhereClause = " where sEmpStat <> 'I' and UPPER(sLastName) like '" + sSearchName + "' or "
					+ "UPPER(sFirstName) like '" + sSearchName + "'";
			}
			else
			{
				sWhereClause = " where sEmpStat <> 'I'";
			} 

			if (this.currentUser.sEmpPermission == "S")			
			{
				if (sWhereClause.Length == 0)
				{
					sWhereClause = " where ";
				}
				else
				{
					sWhereClause += " and ";
				}

				sWhereClause += "  sOfc='" + currentUser.sOfc  + "'";
			}


			//
			//			string currDate = System.DateTime.Now.Day.ToString() + " " +
			//							System.DateTime.Now.Month.ToString("MMM") + " " +
			//							System.DateTime.Now.Year.ToString();
			//			+System.DateTime.Now.ToString("dd MMM yyyy")

			/* Format table for Employee travel information */
			dt.Columns.Add(new DataColumn(" ", typeof(string)));
			dt.Columns.Add(new DataColumn("Name", typeof(string)));
			dt.Columns.Add(new DataColumn("Current Team/Role", typeof(string)));
			dt.Columns.Add(new DataColumn("Start Date", typeof(string)));
			dt.Columns.Add(new DataColumn("Tenure (in years) as of today", typeof(string)));
			dt.Columns.Add(new DataColumn("Passport (valid until)", typeof(string)));
			dt.Columns.Add(new DataColumn("Valid Visa", typeof(string)));

			/**** SQL to get column headers and rows ****/			
			string[] arrSQL = {"select sLastName, sFirstName, sEmpPosition, sNavMMM, sNavDD, sNavYYYY, sPassportExp, sValidVisa, sLoginID, sEmpPermission from T_SKILLS_EMPINFO" + sWhereClause + " ORDER BY sLastName", 
								  "select sLastName, sFirstName, sEmpPosition, sNavMMM, sNavDD, sNavYYYY, sPassportExp, sValidVisa, sLoginID, sEmpPermission from T_SKILLS_EMPINFO" + sWhereClause};
			
			rgTechDetail.getQueryRequest(arrSQL);

			// Execute both sql for columns and rows
			DataSet ds = wadTechDetail.CreateReport(rgTechDetail);

			string name = "";
			string startDate = "";

			// Process data for column headers
			if(!(ds.Tables[0].Rows.Count == 0) && (sSearchName == ""))
			{					
				foreach(DataRow drRes in ds.Tables[0].Select(null,null,DataViewRowState.CurrentRows ))
				{
					i++;
					if (!drRes[9].ToString().Equals("A"))
					{
						dr = dt.NewRow();

						name = drRes[0].ToString() + ", " + drRes[1].ToString();
						startDate = drRes[3].ToString() + " " + drRes[4].ToString() + " " + drRes[5].ToString();
						
						System.TimeSpan tenure;
						try 
						{
							tenure = (System.DateTime.Now - Convert.ToDateTime(startDate));
						}
						catch(Exception e) 
						{
							tenure = new TimeSpan(0,0,0);
                            SMFLibrary.MessageBox(this, e.Message);
						}

						dr[0] = i.ToString() + ".";
						dr[1] = "<a href=\"javascript:openName('window_skills_indsummary.aspx" + "?sLoginId="+ drRes[8] + "');\">" + name + "</a>";

						//Change format of name if output is for excel file
						if (bIsReport)
							dr[1] = name;

						dr[2] = drRes[2].ToString();
						dr[3] = startDate;
						dr[4] = Math.Round(tenure.TotalDays/365);

						if (drRes[6].ToString().Length>0)
							dr[5] = drRes[6].ToString();
						else
							dr[5] = "none";

						if (drRes[7].ToString().Length>0)
							dr[6] = drRes[7].ToString();
						else
							dr[6] = "none";
					
						dt.Rows.Add(dr);
						
					}
				}
			}
			// Process data for row data 
			if(!(ds.Tables[1].Rows.Count == 0) && (sSearchName != ""))
			{						
				foreach (DataRow drRes in ds.Tables[1].Select(null,null,DataViewRowState.CurrentRows))
				{
					i++;

					if (!drRes[9].ToString().Equals("A"))
					{
						dr = dt.NewRow();

						name = drRes[0].ToString() + ", " + drRes[1].ToString();
						startDate = drRes[3].ToString() + " " + drRes[4].ToString() + " " + drRes[5].ToString();
						System.TimeSpan tenure = (System.DateTime.Now - Convert.ToDateTime(startDate));

						dr[0] = i.ToString() + ".";
						dr[1] = "<a href=\"javascript:openName('window_skills_indsummary.aspx" + "?sLoginId="+ drRes[8] + "');\">" + name + "</a>";
						dr[2] = drRes[2].ToString();
						dr[3] = startDate;
						dr[4] = Math.Round(tenure.TotalDays/365);

						if (drRes[6].ToString().Length>0)
							dr[5] = drRes[6].ToString();
						else
							dr[5] = "none";

						if (drRes[7].ToString().Length>0)
							dr[6] = drRes[7].ToString();
						else
							dr[6] = "none";

						dt.Rows.Add(dr);
					}
					
				}
			}

			this.RecordCount = dt.Rows.Count;

			return dt;

			//			DataView dv = new DataView(dt);
			//			return dv;
		}

		private void UpdateNameList()
		{			
			//			lblFromName.Text = dgResults.Items[0].Cells[1].Text;
			//			lblToName.Text = dgResults.Items[dgResults.Items.Count - 1].Cells[1].Text;			
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

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			dgResults.DataSource = GetReportData(txtSearchName.Text, false);
			dgResults.CurrentPageIndex = 0;
			dgResults.DataBind();			
			UpdateNameList();
		}

		
		protected void dgResults_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgResults.CurrentPageIndex = e.NewPageIndex ;			
			dgResults.DataSource = GetReportData("", false);
			dgResults.DataBind();
			UpdateNameList();
		}

		protected void LinkButton1_Click(object sender, System.EventArgs e)
		{
			// Assign the FileName of the excel file
			string sVirtualFileName = "/SmfRewriteProject/Reports/skills_repvisa_" + currentUser.sLoginID + "_" + Session.SessionID.ToString() + ".xls";
			string sFileName = Server.MapPath(sVirtualFileName) ;

			// Use the extract excel object to create the excel file for the report
			ExtractExcel xlReport = new ExtractExcel(sFileName, GetReportData("", true));
			// Write and save the excel report
			lblExcel.Text = xlReport.WriteData();

			if (lblExcel.Text == "")            
				Response.Redirect(sVirtualFileName);

		}

		protected void hBack_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/Menu");
		}

		protected void dgResults_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void lViewAll_Click(object sender, System.EventArgs e)
		{
			txtSearchName.Text = "";
			dgResults.DataSource = GetReportData(txtSearchName.Text, false);
			dgResults.CurrentPageIndex = 0 ;
			dgResults.DataBind();
			UpdateNameList();

		}

	}
}

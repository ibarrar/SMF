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
	/// Tech Skills Report Detailed
	/// </summary>
	public class skills_repskills : ViewController
	{
		protected System.Web.UI.WebControls.DataGrid dgResults;
		protected System.Web.UI.WebControls.DataGrid dgProducts;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.Label lblExcel;
		protected System.Web.UI.WebControls.LinkButton hBack;
		protected System.Web.UI.WebControls.LinkButton LinkButton2;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		
		private string headerName = "";
		
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			dgResults.DataSource = GetReportData("a");
			dgResults.DataBind();
			dgProducts.DataSource = GetReportData("b");
			dgProducts.DataBind();
			
		}

		private void Page_Load(object sender, System.EventArgs e)
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
			this.hBack.Click += new System.EventHandler(this.hBack_Click);
			this.LinkButton2.Click += new System.EventHandler(this.LinkButton2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private DataTable GetReportData(string sSearchName) 
		{
			/**** Use IStorable Objects ****/
			ReportGenerator rgTechDetail = new ReportGenerator();
			WebAppDataHandler wadTechDetail = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);			
			ArrayList arrSkills = new ArrayList();
			DataTable dt = new DataTable();
			DataRow dr;
			int i = 0;

//			string sWhereClause = "";

//			if (this.currentUser.getEmpPermission() == "S")			
//			{
//				sWhereClause += " and T_SKILLS_EMPINFO.sOfc='" + currentUser.getEmpOfc()  + "'";
//			}

			if(sSearchName == "a")
				headerName = "Programming Language";
			else
				headerName = "Product List";

			/* Format table for Tech Skill Summary */
			dt.Columns.Add(new DataColumn(" ", typeof(string)));
			dt.Columns.Add(new DataColumn(headerName, typeof(string)));
			dt.Columns.Add(new DataColumn("Novice", typeof(string)));
			dt.Columns.Add(new DataColumn("Intermediate", typeof(string)));
			dt.Columns.Add(new DataColumn("Expert", typeof(string)));
			dt.Columns.Add(new DataColumn("Total", typeof(string)));

			/**** SQL to get tech and product skills summary ****/			
			string[] arrSQL = {"SELECT sSkill FROM T_SKILLS_CODE WHERE sSkillType='Tech' ORDER BY sSkill", 
							   "SELECT DISTINCT sSkillType FROM T_SKILLS_CODE WHERE sSkillType<>'Tech' ORDER BY sSkillType"};

			rgTechDetail.getQueryRequest(arrSQL);

			// Execute both sql for both tables
			DataSet ds = wadTechDetail.CreateReport(rgTechDetail);

			// Process data for column headers
			if(!(ds.Tables[0].Rows.Count == 0))
			{			
				if (sSearchName.Equals("a") || sSearchName.Equals("c"))
				{
					if (sSearchName.Equals("c"))
					{
						dr = dt.NewRow();
						dr[headerName] = " Technical Skills ";
						dt.Rows.Add(dr);
					}

					foreach(DataRow dbSkillRow in ds.Tables[0].Select(null,null,DataViewRowState.CurrentRows))
					{
						i++;
						dr = dt.NewRow();
						string Skill = dbSkillRow[0].ToString();
						dr[0] = Skill;

						string sWhereOfc;
						if (this.currentUser.sEmpPermission.Equals("A"))
							sWhereOfc = "";
						else
							sWhereOfc = " and sOfc='" + currentUser.sOfc  + "'";
					
						string[] indSQL = {"SELECT count(*) FROM T_SKILLS_EMPINFO where sEmpStat <> 'I' and sEmpId in " + 
											  "(SELECT sEmpId from T_SKILLS_EMPSKILLS where " +
											  "sLevel=1 AND sSkill='" + Skill + "') " + 
											  sWhereOfc,

											  "SELECT count(*) FROM T_SKILLS_EMPINFO where sEmpStat <> 'I' and sEmpId in " + 
											  "(SELECT sEmpId from T_SKILLS_EMPSKILLS where " +
											  "sLevel=2 AND sSkill='" + Skill + "') " + 
											  sWhereOfc,

											  "SELECT count(*) FROM T_SKILLS_EMPINFO where sEmpStat <> 'I' and sEmpId in " + 
											  "(SELECT sEmpId from T_SKILLS_EMPSKILLS where " +
											  "sLevel=3 AND sSkill='" + Skill + "') " + 
											  sWhereOfc};

						
						rgTechDetail.clearQueryRequest();
						rgTechDetail.getQueryRequest(indSQL);

						DataSet dsSkill = wadTechDetail.CreateReport(rgTechDetail);


						int iNov = Int32.Parse(dsSkill.Tables[0].Select(null,null,DataViewRowState.CurrentRows)[0][0].ToString());
						int iInt = Int32.Parse(dsSkill.Tables[1].Select(null,null,DataViewRowState.CurrentRows)[0][0].ToString());
						int iExp = Int32.Parse(dsSkill.Tables[2].Select(null,null,DataViewRowState.CurrentRows)[0][0].ToString());

						dr[" "] = i.ToString() + ".";
						dr[headerName] = Skill;
						if (sSearchName.Equals("c"))
						{

							dr["Novice"] = iNov.ToString();
							dr["Intermediate"] = iInt.ToString();
							dr["Expert"] = iExp.ToString();
							dr["Total"] = (iNov + iInt + iExp).ToString();
						}
						else
						{						
							dr["Novice"] = "<a href=# onclick=\"javascript:openName('NameList.aspx?skill=" +HttpUtility.UrlEncode(Skill)+ "&skilltype=tech&level=1')\">" +iNov.ToString()+ "</a>";
							dr["Intermediate"] = "<a href=# onclick=\"javascript:openName('NameList.aspx?skill=" +HttpUtility.UrlEncode(Skill)+ "&skilltype=tech&level=2')\">" + iInt.ToString() + "</a>";
							dr["Expert"] = "<a href=# onclick=\"javascript:openName('NameList.aspx?skill=" +HttpUtility.UrlEncode(Skill)+ "&skilltype=tech&level=3')\">" + iExp.ToString() + "</a>";
							dr["Total"] = "<a href=# onclick=\"javascript:openName('NameList.aspx?skill=" +HttpUtility.UrlEncode(Skill)+ "&skilltype=tech&level=0')\">" + (iNov + iInt + iExp).ToString() + "</a>";						
						}
						dt.Rows.Add(dr);
					}
				}
				if (sSearchName.Equals("b") || sSearchName.Equals("c"))
				{
					if (sSearchName.Equals("c"))
					{					
						dt.Rows.Add(dt.NewRow());
						dr = dt.NewRow();
						dr[headerName] = " Product Skills ";
						dt.Rows.Add(dr);
						i = 0;
					}
					foreach(DataRow dbSkillRow in ds.Tables[1].Select(null,null,DataViewRowState.CurrentRows))
					{
						i++;
						dr = dt.NewRow();
						string Skill = dbSkillRow[0].ToString();
						dr[0] = Skill;

						string sWhereOfc;
						if (this.currentUser.sEmpPermission.Equals("A"))
							sWhereOfc = "";
						else
							sWhereOfc = " and sOfc='" + currentUser.sOfc  + "'";
					
						string[] indSQL = {"SELECT count(*) FROM T_SKILLS_EMPINFO where sEmpStat <> 'I' and sEmpId in " + 
											  "(SELECT sEmpId from T_SKILLS_EMPSKILLS where " +
											  "sLevel=1 AND sSkillType='" + Skill + "') " + 
											  sWhereOfc,

											  "SELECT count(*) FROM T_SKILLS_EMPINFO where sEmpStat <> 'I' and sEmpId in " + 
											  "(SELECT sEmpId from T_SKILLS_EMPSKILLS where " +
											  "sLevel=2 AND sSkillType='" + Skill + "') " + 
											  sWhereOfc,

											  "SELECT count(*) FROM T_SKILLS_EMPINFO where sEmpStat <> 'I' and sEmpId in " + 
											  "(SELECT sEmpId from T_SKILLS_EMPSKILLS where " +
											  "sLevel=3 AND sSkillType='" + Skill + "') " + 
											  sWhereOfc};

						rgTechDetail.clearQueryRequest();
						rgTechDetail.getQueryRequest(indSQL);

						DataSet dsSkill = wadTechDetail.CreateReport(rgTechDetail);


						int iNov = Int32.Parse(dsSkill.Tables[0].Select(null,null,DataViewRowState.CurrentRows)[0][0].ToString());
						int iInt = Int32.Parse(dsSkill.Tables[1].Select(null,null,DataViewRowState.CurrentRows)[0][0].ToString());
						int iExp = Int32.Parse(dsSkill.Tables[2].Select(null,null,DataViewRowState.CurrentRows)[0][0].ToString());

						dr[" "] = i.ToString() + ".";
						dr[headerName] = Skill;
						if (sSearchName.Equals("c"))
						{							
							dr["Novice"] = iNov.ToString();
							dr["Intermediate"] = iInt.ToString();
							dr["Expert"] = iExp.ToString();
							dr["Total"] = (iNov + iInt + iExp).ToString();
						}
						else
						{
							dr["Novice"] = "<a href=# onclick=\"javascript:openName('NameList.aspx?skilltype=" +Skill+ "&skill=main&level=1')\">" +iNov.ToString()+ "</a>";
							dr["Intermediate"] = "<a href=# onclick=\"javascript:openName('NameList.aspx?skilltype=" +Skill+ "&skill=main&level=2')\">" + iInt.ToString() + "</a>";
							dr["Expert"] = "<a href=# onclick=\"javascript:window.openName('NameList.aspx?skilltype=" +Skill+ "&skill=main&level=3')\">" + iExp.ToString() + "</a>";
							dr["Total"] = "<a href=# onclick=\"javascript:window.openName('NameList.aspx?skilltype=" +Skill+ "&skill=main&level=0')\">" + (iNov + iInt + iExp).ToString() + "</a>";
						}
						dt.Rows.Add(dr);

					}
				}

			}

//			DataView dv = new DataView(dt);
//			return dv;
			return dt;
		}

		private void lbTechSkills_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("TechnicalSkillsDetailedReport");
		}

		private void lbProdSkills_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("ProductKnowledgeDetailedReport");
		}

		private void lbTravelDoc_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("EmployeeTravelDocumentation");
		}

		private void LinkButton2_Click(object sender, System.EventArgs e)
		{
			// Assign the FileName of the excel file
			lblExcel.Text="";
			string sVirtualFileName = "/SmfRewriteProject/Reports/skills_repskills_" + currentUser.sLoginID + "_" + Session.SessionID.ToString() + ".xls";
			string sFileName = Server.MapPath(sVirtualFileName) ;

			// Use the extract excel object to create the excel file for the report
			ExtractExcel xlReport = new ExtractExcel(sFileName, GetReportData("c"));
			// Write and save the excel report
			lblExcel.Text = xlReport.WriteData();

			if (lblExcel.Text == "")            
				Response.Redirect(sVirtualFileName);
		}

		private void hBack_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/Menu");
		}		
	}
}

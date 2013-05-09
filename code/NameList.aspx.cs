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
	/// Summary description for WebForm1.
	/// </summary>
	//public class NameList : System.Web.UI.Page
	public partial class NameList : ViewController
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{

		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			string sLevel = Request.QueryString["level"].ToString();
			string sSkill = Request.QueryString["skill"].ToString();
			string sSkillType = Request.QueryString["skilltype"].ToString();

			ReportGenerator rgTechDetail = new ReportGenerator();
			WebAppDataHandler wadTechDetail = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);			
			ArrayList arrSkills = new ArrayList();
			DataTable dt = new DataTable();
			DataRow dr;
			String sWhereClause;

			if (sLevel.Equals("0"))
                sWhereClause = "WHERE T_SKILLS_EMPINFO.sEmpStat <> 'I' and T_SKILLS_EMPINFO.sEmpID = T_SKILLS_EMPSKILLS.sEmpID " +
					          " AND T_SKILLS_EMPSKILLS.sLevel<>0 " + 
							  " AND T_SKILLS_EMPSKILLS.sSkillType='" + sSkillType + 
							  "' AND T_SKILLS_EMPSKILLS.sSkill='" + sSkill + "'";

			else
				sWhereClause = "WHERE T_SKILLS_EMPINFO.sEmpStat <> 'I' and T_SKILLS_EMPINFO.sEmpID = T_SKILLS_EMPSKILLS.sEmpID AND " +
							  "T_SKILLS_EMPSKILLS.sLevel=" + sLevel + 
							  " AND T_SKILLS_EMPSKILLS.sSkillType='" + sSkillType + 
							  "' AND T_SKILLS_EMPSKILLS.sSkill='" + sSkill + "'";

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

				sWhereClause += "  T_SKILLS_EMPINFO.sOfc='" + currentUser.sOfc  + "'";
			}


			string[] arrSQL = {"SELECT sLastName, sFirstName, sLoginID FROM T_SKILLS_EMPINFO, T_SKILLS_EMPSKILLS " + sWhereClause + " ORDER BY sLastName"};

			rgTechDetail.getQueryRequest(arrSQL);

			// Execute both sql for both tables
			DataSet ds = wadTechDetail.CreateReport(rgTechDetail);

			// Process data for column headers
			if(!(ds.Tables[0].Rows.Count == 0))
			{
				
				//if tech skill, display tech skill, else display product skill type.
				if (sSkillType.Equals("tech"))
					skillType.Text=sSkill;
				else
					skillType.Text=sSkillType;

				switch (sLevel)
				{
					case "0": skillLevel.Text="All"; break;
					case "1": skillLevel.Text="Novice"; break;
					case "2": skillLevel.Text="Intermediate"; break;
					case "3": skillLevel.Text="Expert"; break;
				}

				dt.Columns.Add(new DataColumn("Names"));
				string sName;

				foreach(DataRow dbEmpRow in ds.Tables[0].Select(null,null,DataViewRowState.CurrentRows))
				{
					sName = dbEmpRow["sLastName"].ToString() + ", " + dbEmpRow["sFirstName"].ToString();
					dr = dt.NewRow();
					dr["Names"] = "<a href=\"#\" onclick=\"javascript:openName('window_skills_indsummary.aspx" + "?sLoginId="+ dbEmpRow["sLoginID"] + "');\">" + sName + "</a>";
					dt.Rows.Add(dr);
				}

				dgNames.DataSource = dt;
				dgNames.DataBind();
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

		}
		#endregion

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script language='javascript'>window.close()</script>");
			Response.Close();
		}

		protected void dgNames_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}

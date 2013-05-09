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
	/// Summary description for SkillsRepSummary.
	/// </summary>
	public partial class SkillsRepSummary : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{

		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			dgResults.DataSource = GetReportData("");
			dgResults.DataBind();
		}


		private ICollection GetReportData(string sSearchName) 
		{
			DataTable dt = new DataTable();
			DataRow dr;

			string sqlString = "SELECT sSkill FROM T_SKILLS_CODE WHERE sSkillType='Tech'";

			Dbase dbSkills = new Dbase();

			/* Create where clause to filter report*/
			dt.Columns.Add(new DataColumn("Count", typeof(string)));
			dt.Columns.Add(new DataColumn("Programming Language", typeof(string)));
			dt.Columns.Add(new DataColumn("Novice", typeof(string)));
			dt.Columns.Add(new DataColumn("Intermediate", typeof(string)));
			dt.Columns.Add(new DataColumn("Expert", typeof(string)));
			dt.Columns.Add(new DataColumn("Total", typeof(string)));
			
			/* Grab the count of skill level for each skill type */
			int i=0;
			foreach(DataRow dbSkillRow in dbSkills.action(sqlString))
			{
				i++;
				dr = dt.NewRow();
				string Skill = dbSkillRow[0].ToString();
				dr[0] = Skill;

				string sqlNovice = "SELECT count(*) FROM T_SKILLS_EMPSKILLS where " +
					"sLevel=1 AND sSkill='" + Skill + "'";

				string sqlIntermediate = "SELECT count(*) FROM T_SKILLS_EMPSKILLS where " +
					"sLevel=1 AND sSkill='" + Skill + "'";

				string sqlExpert = "SELECT count(*) FROM T_SKILLS_EMPSKILLS where " +
					"sLevel=1 AND sSkill='" + Skill + "'";
/*
				string sqlNovice = "SELECT sLastName, sFirstName FROM T_SKILLS_EMPINFO, T_SKILLS_EMPSKILLS " +
					"WHERE T_SKILLS_EMPINFO.sEmpID = T_SKILLS_EMPSKILLS.sEmpID AND " +
					"T_SKILLS_EMPSKILLS.sLevel=1 AND T_SKILLS_EMPSKILLS.sSkill='" + Skill + "'";
				
				string sqlIntermediate = "SELECT sLastName, sFirstName FROM T_SKILLS_EMPINFO, T_SKILLS_EMPSKILLS " +
					"WHERE T_SKILLS_EMPINFO.sEmpID = T_SKILLS_EMPSKILLS.sEmpID AND " +
					"T_SKILLS_EMPSKILLS.sLevel=2 AND T_SKILLS_EMPSKILLS.sSkill='" + Skill + "'";

				string sqlExpert = "SELECT sLastName, sFirstName FROM T_SKILLS_EMPINFO, T_SKILLS_EMPSKILLS " +
					"WHERE T_SKILLS_EMPINFO.sEmpID = T_SKILLS_EMPSKILLS.sEmpID AND " +
					"T_SKILLS_EMPSKILLS.sLevel=3 AND T_SKILLS_EMPSKILLS.sSkill='" + Skill + "'";

				ArrayList aNovice = new ArrayList();
				foreach (DataRow dbEmpRow in dbSkills.action(sqlNovice))
				{
					string sName = dbEmpRow["sLastName"].ToString() + ", " + dbEmpRow["sFirstName"].ToString();
					aNovice.Add(sName);
				}

				ArrayList aIntermediate = new ArrayList();
				foreach (DataRow dbEmpRow in dbSkills.action(sqlIntermediate))
				{
					string sName = dbEmpRow["sLastName"].ToString() + ", " + dbEmpRow["sFirstName"].ToString();
					aIntermediate.Add(sName);
				}

				ArrayList aExpert = new ArrayList();
				foreach (DataRow dbEmpRow in dbSkills.action(sqlExpert))
				{
					string sName = dbEmpRow["sLastName"].ToString() + ", " + dbEmpRow["sFirstName"].ToString();
					aExpert.Add(sName);
				}
*/
				int iNov = Int32.Parse(dbSkills.action(sqlNovice)[0][0].ToString());
				int iInt = Int32.Parse(dbSkills.action(sqlIntermediate)[0][0].ToString());
				int iExp = Int32.Parse(dbSkills.action(sqlExpert)[0][0].ToString());

				dr["Count"] = i.ToString() + ".";
				dr["Programming Language"] = Skill;
				dr["Novice"] = "<a href=# onclick=\"javascript:window.open('NameList.aspx?skill=" +Skill+ "&level=1')\">" +iNov.ToString()+ "</a>";
				dr["Intermediate"] = "<a href=# onclick=\"javascript:window.open('NameList.aspx?skill=" +Skill+ "&level=2')\">" + iInt.ToString() + "</a>";
				dr["Expert"] = "<a href=# onclick=\"javascript:window.open('NameList.aspx?skill=" +Skill+ "&level=3')\">" + iExp.ToString() + "</a>";
				dr["Total"] = (iNov + iInt + iExp).ToString();
				dt.Rows.Add(dr);
			}
			DataView dv = new DataView(dt);
			return dv;
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

		protected void dgResults_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			//dgResults.DataSource = GetReportData(txtSearchName.Text);
//			dgResults.CurrentPageIndex = e.NewPageIndex ;			
//			dgResults.DataBind();
		}


	}
}

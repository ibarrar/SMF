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
	public partial class EmpCatalogue : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			/*
			dgResults.AllowPaging = true;
			dgResults.PagerStyle.Mode = PagerMode.NumericPages;
			dgResults.PagerStyle.PageButtonCount = 5;
			dgResults.PageSize = 12;
			*/

			dgResults.DataSource = GetReportData("");
			dgResults.DataBind();
			/*
			if (!Page.IsPostBack)
			{							
				dgResults.DataBind();
			}
			*/
		}

		private ICollection GetReportData(string sSearchName) 
		{
			DataTable dt = new DataTable();
			DataRow dr;
			string sWhereClause = "";
			
			Dbase dbSkills = new Dbase();


			/* Create where clause to filter report*/
			if (sSearchName != "")
			{
				sSearchName = "%" + sSearchName.ToUpper() + "%";
				sWhereClause = " where UPPER(sLastName) like '" + sSearchName + "' or "
					+ "UPPER(sFirstName) like '" + sSearchName + "'";
			}
				
			dt.Columns.Add(new DataColumn("Number", typeof(string)));
			dt.Columns.Add(new DataColumn("Employee Name", typeof(string)));
			dt.Columns.Add(new DataColumn("Status", typeof(string)));
			dt.Columns.Add(new DataColumn("Access", typeof(string)));
			dt.Columns.Add(new DataColumn("LoginID",typeof(string)));
			int	count =0;
			foreach (DataRow dbEmpRow in dbSkills.action("select sLastName, sFirstName,sEmpStat,sEmpPermission, sLoginID, sEmpID from  T_SKILLS_EMPINFO" + sWhereClause))
			{
				count++;
				dr = dt.NewRow();
				dr["Number"] = count;
				dr["Employee Name"] = dbEmpRow["sLastName"].ToString() + ", " + dbEmpRow["sFirstName"].ToString();
				
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
				//string temp = "<a href='IndSummary.aspx?LoginId=" + sLogin + "'>" + "View Individual Summary </a>";
				dr["LoginID"] = "<a href='IndSummary.aspx?LoginId=" + sLogin + "'>" + "View Individual Summary </a>";
				
				if (lblFromName.Text == "")
				{
					lblFromName.Text = dbEmpRow["sLastName"].ToString();
				}
				lblToName.Text = dbEmpRow["sLastName"].ToString();

				dt.Rows.Add(dr);
			

			}
			
			DataView dv = new DataView(dt);

			lblEntry.Text = "entries";
			if (dv.Count >= 1)
			{
				lblEntry.Text = "entry";
			}

			lblCount.Text = dv.Count.ToString();
			
			return dv;
		}

		private void SetName()
		{
			lblFromName.Text = "";
			lblToName.Text = "";
			lblEntry.Text = "entries";
			lblCount.Text = dgResults.DataKeys.Count.ToString();
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
			this.dgResults.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgResults_PageIndexChanged);

		}
		#endregion

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			dgResults.DataSource = GetReportData(txtSearchName.Text);
			dgResults.CurrentPageIndex = 0;
			dgResults.DataBind();
		}

		protected void dgResults_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			//dgResults.DataSource = GetReportData(txtSearchName.Text);
			dgResults.CurrentPageIndex = e.NewPageIndex ;			
			dgResults.DataBind();
		}

		protected void dgResults_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	
		
	}
}

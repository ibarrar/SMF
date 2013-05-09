using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

namespace SmfRewriteProject
{
	/// <summary>
	/// Summary description for skills_forgotpassword.
	/// </summary>
	public partial class skills_forgotpassword : ViewController
	{
	
		
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

		protected void Back_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/Start");
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			DataTable dt = new DataTable();
			//DataRow dr;

			WebAppDataHandler dhEmpList = new WebAppDataHandler(
				System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
			EmployeeList empList = new EmployeeList();
			empList.RetrieveAdmin();
			DataSet dsEmpList = dhEmpList.QueryRequest(empList);
			
//			dt.Columns.Add(new DataColumn("Number", typeof(string)));
//			dt.Columns.Add(new DataColumn("LastName", typeof(string)));
//			dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
//
//			for (int i = 0; i < dsEmpList.Tables[0].Rows.Count; i++) 
//			{
//				dr = dt.NewRow();
// 
//				dr[0] = i.ToString();
//				dr[1] = dsEmpList.Tables[0].C;
//				dr[2] = 1.23 * (i + 1);
// 
//				dt.Rows.Add(dr);
//			}

			//this.dgSupervisor.DataSource = dsEmpList;
		//	this.dgSupervisor.DataBind();
		}

		protected void btnEmailPassword_Click(object sender, System.EventArgs e)
		{
			Employee emp = new Employee(txtEmailPassword.Text);
			
			
			if( emp.sEmpID != null )
			{
				FE_Symmetric feService = new FE_Symmetric();
				SMFLibrary.SendEmail(emp.sLoginID + "@navitaire.com", "SMF Password", "Your password is:   " + feService.DecryptData("", emp.sEmpPswd));
				lblPasswordMsg.Text = "Your password will be emailed to you shortly.";
			}
			else
			{
				lblPasswordMsg.Text = "Sorry, no user with that ID exists.";
			}
			lblPasswordMsg.Visible = true;
		}
	}
}

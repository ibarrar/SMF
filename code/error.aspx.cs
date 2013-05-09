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

namespace MVCArch
{
	/// <summary>
	/// Summary description for error.
	/// </summary>
	public partial class error : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			this.lbSiteAdminName.Text = System.Configuration.ConfigurationSettings.AppSettings["SiteAdminContact"].ToString();
			this.lbPhone.Text = System.Configuration.ConfigurationSettings.AppSettings["SiteAdminPhone"].ToString();
			this.hlEmail.NavigateUrl = "mailto:" + System.Configuration.ConfigurationSettings.AppSettings["SiteAdminEmail"].ToString();
			this.hlEmail.Text = System.Configuration.ConfigurationSettings.AppSettings["SiteAdminEmail"].ToString();
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
	}
}

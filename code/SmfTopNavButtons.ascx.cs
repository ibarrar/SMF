namespace SmfRewriteProject
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for SmfTopNavButtons.
	/// </summary>
	public class SmfTopNavButtons : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.LinkButton logoutlink;
		protected System.Web.UI.WebControls.LinkButton homelink;

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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.homelink.Click += new System.EventHandler(this.homelink_Click);
			this.logoutlink.Click += new System.EventHandler(this.logoutlink_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void homelink_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(System.Configuration.ConfigurationSettings.AppSettings["/Menu"]);
		}

		private void logoutlink_Click(object sender, System.EventArgs e)
		{
			Session.Abandon();
			Response.Redirect(System.Configuration.ConfigurationSettings.AppSettings["/End"]);
		}
	}
}

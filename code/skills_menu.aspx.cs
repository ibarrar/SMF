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
	/// Summary description for skills_menu.
	/// </summary>
	public class skills_menu : ViewController
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.LinkButton lbReports;
		protected System.Web.UI.WebControls.LinkButton lbAdvancedSearch;
		protected System.Web.UI.WebControls.LinkButton lbSkillCodeAdmin;
		protected System.Web.UI.WebControls.Panel UserOptions;
		protected System.Web.UI.WebControls.Panel AdminOptions;
		protected System.Web.UI.WebControls.LinkButton lbMyProfile;
		protected System.Web.UI.WebControls.LinkButton lbMySkills;
		protected System.Web.UI.WebControls.LinkButton lbIndividualSummary;
		protected System.Web.UI.WebControls.LinkButton lbChangePassword;
		protected System.Web.UI.WebControls.Label lblChangeLogin;
		protected System.Web.UI.WebControls.Panel pnlSignOut;
		protected System.Web.UI.WebControls.LinkButton lbSignOut2;
		protected System.Web.UI.HtmlControls.HtmlTableRow trChangePwd;
		//protected System.Web.UI.WebControls.LinkButton lblTeamAdmin;
		protected System.Web.UI.WebControls.LinkButton lbSignOut;
		protected System.Web.UI.WebControls.LinkButton lblMyCert;
		protected System.Web.UI.WebControls.LinkButton lbEmployeeCatalogue;
	
		protected override void OnPreRender(EventArgs e)
		{
			this.UserOptions.Visible = true;
			this.AdminOptions.Visible = false;
			this.pnlSignOut.Visible = false;
			
			if (this.currentUser.sEmpPermission.Equals("A")) 
			{
				this.UserOptions.Visible = false;
				this.AdminOptions.Visible = true;
				this.pnlSignOut.Visible = true;
			}
			else if	(this.currentUser.sEmpPermission.Equals("S"))
			{
				this.AdminOptions.Visible = true;
				this.trChangePwd.Visible = false;
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
			this.lbMyProfile.Click += new System.EventHandler(this.lbMyProfile_Click);
			this.lbMySkills.Click += new System.EventHandler(this.lbMySkills_Click);
			this.lbIndividualSummary.Click += new System.EventHandler(this.lbIndividualSummary_Click);
			this.lbSignOut.Click += new System.EventHandler(this.lbSignOut_Click);
			this.lbChangePassword.Click += new System.EventHandler(this.lbChangePassword_Click);
			this.lbReports.Click += new System.EventHandler(this.lbReports_Click);
			this.lbAdvancedSearch.Click += new System.EventHandler(this.lbAdvancedSearch_Click);
			this.lbSkillCodeAdmin.Click += new System.EventHandler(this.lbSkillCodeAdmin_Click);
			this.lbEmployeeCatalogue.Click += new System.EventHandler(this.lbEmployeeCatalogue_Click);
			this.lbSignOut2.Click += new System.EventHandler(this.Linkbutton1_Click);
			this.lblMyCert.Click += new System.EventHandler(this.lblMyCert_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lbSignOut_Click(object sender, System.EventArgs e)
		{
			this.Logout();
			this.ActionForward("/End");
		}

		private void lbMyProfile_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/MyProfile");
		}

		private void lbMySkills_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/MySkills");
		}

		private void lbIndividualSummary_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/IndividualSummary");
		}

		private void lbReports_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/Reports");
		}

		private void lbAdvancedSearch_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/AdvancedSearch");
		}

		private void lbSkillCodeAdmin_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/SkillCodeAdmin");
		}

		private void lbEmployeeCatalogue_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/EmployeeCatalogue");
		}

		private void lbChangePassword_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/ChangePassword");
		}

		private void lbSignOut2_Click(object sender, System.EventArgs e)
		{
			this.Logout();
			this.ActionForward("/End");
		}

		private void Linkbutton1_Click(object sender, System.EventArgs e)
		{
			this.Logout();
			this.ActionForward("/End");
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
		
		}

		private void lblMyCert_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/MyCertificates");
		}

//		private void lblTeamAdmin_Click(object sender, System.EventArgs e)
//		{
//			this.ActionForward("/TeamsAdmin");
//		}

	}
}

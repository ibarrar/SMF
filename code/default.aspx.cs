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
	/// Summary description for _default.
	/// </summary>
	public partial class _default : ViewController{
	
		protected void Page_Load(object sender, System.EventArgs e){
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

		protected void bLogin_Click(object sender, System.EventArgs e)
		{
			if(this.txtLoginID.Text.Equals("") || this.txtPassword.Text.Equals("")){
				this.lblError.Text = "Please enter your login name and password.";
			}
			else{
				this.Login(this.txtLoginID.Text, this.txtPassword.Text);
				if(!(this.currentUser == null))
				{
					this.ActionForward("/Menu");
				}
				else
					this.lblError.Text = "You login name and password was not found.";
			}
		}

		private void bCancel_Click(object sender, System.EventArgs e)
		{
		
		}

		protected void lbNewUser_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/NewUser");
		}

		protected void lbForgotYourPassword_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/ForgotPassword");
		}
	}
}

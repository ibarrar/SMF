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
	/// Summary description for skills_changepassword.
	/// </summary>
	public partial class skills_changepassword : ViewController
	{
		public DataRow row;


		private static string sTempPassword;

		private void setRow(DataRow row)
		{
			this.row = row;
		}

		private string getString(string instring)
		{
			return (this.row[instring].ToString());
		}
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
		}

		protected override void OnPreRender(EventArgs e)
		{
			Employee empInfo;

            if (Session["User"] is Employee)
            {
                empInfo = ((Employee)(Session["User"]));

                if (empInfo == null)
                {
                    SMFLibrary.MessageBox(this, "Failed Query. Please contact your system administrator.");
                }
                else
                {
                    lblLoginID.Text = empInfo.sLoginID;
                    lblEmpID.Text = empInfo.sEmpID;
                    sTempPassword = empInfo.sEmpPswd;
                }
            }
            else
            {
                SMFLibrary.MessageBox(this, "Failed Query. Please contact your system administrator.");
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

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			if (this.currentUser.sEmpPermission.Equals("A"))
				this.ActionForward("/Menu");
			else
				this.ActionForward("/MyProfile");
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			if (txtCurrPassword.Text.Length == 0) 
			{
				lblError.Text = "";
				lblError.Text = "Please enter your Current Password...";
			}
			else if (txtNewPassword.Text.Length == 0)
			{
				lblError.Text = "";
				lblError.Text = "Please enter your New Password...";
			}
			else if (txtNewPassword2.Text.Length == 0)
			{
				lblError.Text = "";
				lblError.Text = "Please re-enter your New Password...";
			}
			else
			{
				//bool test = HashGenerator.VerifyHash(txtCurrPassword.Text, "MD5", sTempPassword);
				//if (test)
				FE_Symmetric feService = new FE_Symmetric();
				if(	feService.DecryptData("", sTempPassword).ToString() == txtCurrPassword.Text )
				{
					if (txtNewPassword.Text.Equals(txtNewPassword2.Text))
					{
						if (txtNewPassword.Text.Length < 6)
						{
							lblError.Text = "";
							lblError.Text = "Password must be 6 characters or more. Please re-enter Password...";
							txtCurrPassword.Text = "";
							txtNewPassword.Text = "";
							txtNewPassword2.Text = "";
						}
						else
						{
                            Employee emp = new Employee(lblLoginID.Text);

                            if (emp.Update_Password(lblLoginID.Text, txtNewPassword.Text))
							{
								lblError.Text = "";
								lblError.Text = "Change Password Success!";
								txtCurrPassword.Text = "";
								txtNewPassword.Text = "";
								txtNewPassword2.Text = "";
							}
							else
							{
								lblError.Text = "Change Password Failed!";
							}
						}
					}
					else
					{
						lblError.Text = "";
						lblError.Text = "New Password does not match re-entered new password! Please try again...";
					}
				}
				else
				{	
					lblError.Text = "";
					lblError.Text = "Incorrect Password. Try again!";
				}
			}
		}
	}
}

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
	/// Summary description for skills_editempprofiles.
	/// </summary>
	public partial class skills_editempprofiles : ViewController
	{
         
	    protected void Page_Load(object sender, System.EventArgs e)
	    {
             if( !this.IsPostBack )
             {
                 Employee empInfo = new Employee(Request.QueryString["sLoginID"].ToString());

                 if (empInfo != null)
                 {
                    if (((Employee)Session["User"]).sLoginID == empInfo.sLoginID)
                    {
                       this.Delete.Enabled = false;
                    }
                    else
                    {
                       this.Delete.Enabled = true;
                    }

                    if (empInfo.sEmpPermission == "S")
                    {       
                         this.RadioButton2.Checked = true;//           
                         this.RadioButton5.Visible = false;
                    }
                    else if (empInfo.sEmpPermission == "O")
                    {
                         this.RadioButton1.Checked = true;                     
                         this.RadioButton5.Visible = false;
                    }
                    else
                    {
                         this.RadioButton5.Checked = true;
                         this.RadioButton5.Visible = true;
                         if (((Employee)Session["User"]).sEmpPermission != "A")
                         {
                            this.RadioButton1.Enabled = false;
                            this.RadioButton2.Enabled = false;
                         }
                    }

                    if (empInfo.sEmpStat== "A")
                    {
                     this.RadioButton3.Checked = true;
                    }
                    else
                    {
                     this.RadioButton4.Checked = true;
                    }

                    this.Label1.Text = empInfo.sLastName + ", " + empInfo.sFirstName;

                    if (((Employee)Session["User"]).sEmpPermission == "A")
                    {
                     this.ResetAllEmployees.Visible = true;
                    }
               }
               else
               {
                  SMFLibrary.AlertAndExitMessageBox(this.Response, "Employee record not found.");
               }
            }
         
         Response.ExpiresAbsolute = DateTime.Now.AddDays (-1);
         Response.Cache.SetCacheability (System.Web.HttpCacheability.NoCache);
         Response.AppendHeader ("Pragma", "no-cache");
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

      protected void Cancel_Click(object sender, System.EventArgs e)
      {
         Response.Write("<script language=JScript>window.close();</script>");
      }

      protected void Save_Click(object sender, System.EventArgs e)
      {
         //Save Employee Record
         string sEmpPermission, sEmpStat;
         if (this.RadioButton2.Checked )
         {
            sEmpPermission = "S";
         }
         else if (this.RadioButton1.Checked)
         {
            sEmpPermission = "O";
         }
         else
         {
            sEmpPermission = "A";
         }

         if (this.RadioButton3.Checked)
         {
            sEmpStat = "A";
         }
         else
         {
            sEmpStat = "I";
         }

         if (((Employee)Session["User"]).Update_EmpProfile(Request.QueryString["sLoginID"].ToString(), sEmpPermission, sEmpStat))
         {
            Response.Write("<script language=JScript>top.returnValue = \"Save\";</script>");            
            Response.Write("<script language=JScript>window.close();</script>");
         }
         else
         {
            SMFLibrary.MessageBox(this, "Failed to save employee profile. Please contact your system administrator.");
         }
      }

      protected void ResetPassword_Click(object sender, System.EventArgs e)
      {
          ((Employee)Session["User"]).Update_Password(Request.QueryString["sLoginID"].ToString(), Request.QueryString["sLoginID"].ToString());
         string Message = "Employee password set to \"";
         Message += Request.QueryString["sLoginID"].ToString();
         Message += "\".";
         SMFLibrary.MessageBox(this, Message);
      }

      protected void Delete_Click(object sender, System.EventArgs e)
      {
         // Delete Employee Record
          if (((Employee)Session["User"]).Delete_Employee(Request.QueryString["sLoginID"].ToString()))
         {
            Response.Write("<script language=JScript>top.returnValue = \"Delete\";</script>");
            Response.Write("<script language=JScript>window.close();</script>");
         }
         else
         {
            SMFLibrary.MessageBox(this, "Failed to delete employee record. Please contact your system administrator.");
         }
      }

      protected void ResetAllEmployees_Click(object sender, System.EventArgs e)
      {
         ResetAllPasswords.ResetPasswords();
         SMFLibrary.MessageBox(this, "Reset of employee passwords complete.");
      }

	}
}

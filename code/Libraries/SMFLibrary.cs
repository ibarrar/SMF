using System;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.Mail;

namespace SmfRewriteProject
{
	/// <summary>
	/// Summary description for SMFLibrary.
	/// </summary>
	public class SMFLibrary
	{
		private SMFLibrary()
		{
		}

      public static void MessageBox(Page thisPage, string message)
      {
         string alertScript = "<script language=JavaScript>"; 
         alertScript += "alert('" + message +"');"; 
         alertScript += "</script>"; 

         if (!thisPage.IsStartupScriptRegistered ("alert")) 
            thisPage.RegisterStartupScript("alert", alertScript);
      }

      public static void AlertAndExitMessageBox(System.Web.HttpResponse Response, string message)
      {
         string alertScript = "<script language=JavaScript>"; 
         alertScript += "alert('" + message + "');"; 
         alertScript += "</script>"; 
         Response.Write(alertScript);
         Response.Write("<script language=JScript>window.close();</script>");
      }

      public static void AlertMessageBox(System.Web.HttpResponse Response, string message)
      {
         string alertScript = "<script language=JavaScript>"; 
         alertScript += "alert('" + message + "');"; 
         alertScript += "</script>"; 
         Response.Write(alertScript);
      }

      public static void SetFocus(Page thisPage, System.Web.UI.Control ctrl )
      {
         string focusScript = "<script language=JavaScript>" +
            "document.getElementById('" + ctrl.ID + "').focus() </script>"; 

         if (!thisPage.IsStartupScriptRegistered ("focus")) 
            thisPage.RegisterStartupScript("focus", focusScript);
      }

		public static void SendEmail(string strEmailAddress, string strSubject, string strMessage)
		{
			MailMessage mail = new MailMessage();
			mail.From = "Skills-Management-Facility";
			mail.To = strEmailAddress;
			mail.Subject = strSubject;
			mail.Body = strMessage;
			mail.BodyFormat = MailFormat.Html;
			//SmtpMail.SmtpServer = "navmpex111.corp.nt.navitaire.com";
			SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["EmailServer"];
			SmtpMail.Send(mail);
		}
	}

   public class ResetAllPasswords
   {
      private ResetAllPasswords()
      {
      }

      public static void ResetPasswords()
      {
         DataTable employeeTable = new DataTable();

         ReportGenerator rgEmployee = new ReportGenerator();
         WebAppDataHandler wEmployeeDetail = new WebAppDataHandler();

         employeeTable.Columns.Add(new DataColumn("LoginID", typeof(string)));

         string[] arrSQL = {"SELECT T_SKILLS_EMPINFO.sLoginID from T_SKILLS_EMPINFO"};
			
         rgEmployee.getQueryRequest(arrSQL);

         // Execute both sql for columns and rows
         DataSet ds = wEmployeeDetail.CreateReport(rgEmployee);

         foreach (DataRow dbEmpRow in ds.Tables[0].Select(null,null,DataViewRowState.CurrentRows))
         {
            string sLogin = dbEmpRow["sLoginID"].ToString();
            Employee emp = new Employee(sLogin);
            if (!emp.Update_Password(sLogin, sLogin))
            {
               throw new ApplicationException("Error in SMF application. Contact your system administrator.");
            }
         }
      }
   }

   /// <summary>
   /// Summary description for ConfirmButton.
   /// </summary>
   [DefaultProperty("Text"), 
   ToolboxData("<{0}:ConfirmButton runat=server></{0}:ConfirmButton>")]
   public class ConfirmButton : Button
   {
      [Bindable(true), 
      Category("Appearance"), 
      DefaultValue("")] 
      public string PopupMessage
      {
         get
         {
            // See if the item exists in the ViewState
            object popupMessage = this.ViewState["PopupMessage"];
            if (popupMessage != null)
               return this.ViewState["PopupMessage"].ToString();
            else
               return "Are you sure you want to continue?";
         }

         set
         {
            // Assign the ViewState variable
            ViewState["PopupMessage"] = value;
         }
      }


      protected override void AddAttributesToRender(HtmlTextWriter writer)
      {
         base.AddAttributesToRender(writer);

         string script = @"return confirm(""%%POPUP_MESSAGE%%"");";
         script = script.Replace("%%POPUP_MESSAGE%%", 
            this.PopupMessage.Replace("\"", "\\\""));

         writer.AddAttribute(HtmlTextWriterAttribute.Onclick, script);
      }
   }

   /// <summary>
   /// Summary description for ConfirmButton.
   /// </summary>
   [DefaultProperty("Text"), 
   ToolboxData("<{0}:ConfirmLinkButton runat=server></{0}:ConfirmLinkButton>")]
   public class ConfirmLinkButton : LinkButton
   {
      [Bindable(true), 
      Category("Appearance"), 
      DefaultValue("")] 
      public string PopupMessage
      {
         get
         {
            // See if the item exists in the ViewState
            object popupMessage = this.ViewState["PopupMessageLink"];
            if (popupMessage != null)
               return this.ViewState["PopupMessageLink"].ToString();
            else
               return "Are you sure you want to continue?";
         }

         set
         {
            // Assign the ViewState variable
            ViewState["PopupMessageLink"] = value;
         }
      }


      protected override void AddAttributesToRender(HtmlTextWriter writer)
      {
         base.AddAttributesToRender(writer);

         string script = @"return confirm(""%%POPUP_MESSAGE%%"");";
         script = script.Replace("%%POPUP_MESSAGE%%", 
            this.PopupMessage.Replace("\"", "\\\""));

         writer.AddAttribute(HtmlTextWriterAttribute.Onclick, script);
      }
   }
}

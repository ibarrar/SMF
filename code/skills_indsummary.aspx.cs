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
	/// Summary description for skills_indsummary.
	/// </summary>
	public class skills_indsummary : ViewController
	{
		protected System.Web.UI.WebControls.LinkButton lbBack;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;

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
         this.lbBack.Click += new System.EventHandler(this.lbBack_Click);

      }
		#endregion


      private void linkClose_Click(object sender, System.EventArgs e)
      {
          Response.Write("<script language=JScript>window.close()</script>");
      }

		private void lbBack_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/Menu");
		}
	}
}

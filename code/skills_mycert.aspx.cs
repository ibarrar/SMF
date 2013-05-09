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
using SmfRewriteProject.Util;

namespace SmfRewriteProject
{
	/// <summary>
	/// Summary description for skills_myskill.
	/// </summary>
	public class skills_mycert : ViewController
	{
		protected System.Web.UI.WebControls.Label lblAdditionalSkills;
		protected System.Web.UI.WebControls.PlaceHolder phTechSkills;
		protected System.Web.UI.WebControls.PlaceHolder phProdSkills;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Table ProdSkillsTable;
		protected System.Web.UI.WebControls.Button btnAddNewProd;
		protected System.Web.UI.WebControls.Label additionalProd;
		protected System.Web.UI.WebControls.TextBox inAdditionalProd;
		protected System.Web.UI.WebControls.Button btnAdditionalProd;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.Button btnSkillType;
		protected System.Web.UI.WebControls.Button btnDelSkillType;
		protected System.Web.UI.WebControls.DataGrid dgCerts;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.TextBox bxCert;
		protected System.Web.UI.WebControls.Button btnCert;
		protected System.Web.UI.WebControls.DropDownList dlistCerts;
		protected System.Web.UI.WebControls.Button btnDelCert;
		protected System.Web.UI.WebControls.Label lblUsername;
		protected System.Web.UI.WebControls.DropDownList dxMonth;
		protected System.Web.UI.WebControls.DropDownList dxDay;
		protected System.Web.UI.WebControls.TextBox txYear;
		protected System.Web.UI.WebControls.TextBox txSponsor;
		protected System.Web.UI.WebControls.Button btnAddTech;


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

		protected override void OnPreRender(EventArgs e)
		{

		}

	}
}
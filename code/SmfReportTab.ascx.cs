namespace SmfRewriteProject
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections;

	/// <summary>
	///		Name: SmfReportTab
	///		Purpose:
	///			This write the control tabs on the page.
	///		Instruction:
	///			Attach the user control on the page and set the "TabActive" property
	///			during the On_Load or OnPreRender of the page.
	///			
	///			TabActive Values
	///				 X - any positive number indicating the position of the tab
	///					 that will be active.  (0) for first tab
	///
	///		ToDo:
	///			Currently, the links and the action of the links are hardcoded
	///			Make this user control dynamic.  
	///			Make a method that will add link objects in this control
	///			
	///		
	/// </summary>
	public class SmfReportTab : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.LinkButton lnk1;
		protected System.Web.UI.WebControls.LinkButton lnk2;
		protected System.Web.UI.WebControls.LinkButton lnk3;
		protected System.Web.UI.WebControls.LinkButton lnk4;

		public int TabActive;
		protected System.Web.UI.WebControls.Table tblTab;
		private ArrayList LinkItems;

		private void OnPreRender(object sender, System.EventArgs e)
		{	
			InitTabs();
			if (!Page.IsPostBack)
			{				
				LinkButton lnkTemp = (LinkButton)LinkItems[TabActive];
				lnkTemp.CssClass = "active";
			}
		}

		private void InitTabs()
		{
			LinkItems = new ArrayList();
			LinkItems.Add(lnk1);
			LinkItems.Add(lnk2);
			LinkItems.Add(lnk3);
			LinkItems.Add(lnk4);
		}


		#region UNDER CONSTRUCTION: Routines for dynamic tab maker
		public void AddTabs(HyperLink aLinkItem)
		{			
			LinkItems.Add(aLinkItem);
		}

		public void DrawTabs(int iActiveTab)
		{			
			TableRow r = new TableRow();
			int i = 0;
			foreach (HyperLink lnkItem in LinkItems)
			{
				lnkItem.CssClass = "inactive";
				if (i == iActiveTab)
					lnkItem.CssClass = "active";
				TableCell c = new TableCell();
				c.Controls.Add(lnkItem);
				r.Cells.Add(c);
			}
			tblTab.Controls.Add(r);

		}
		# endregion
		

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
			this.lnk1.Click += new System.EventHandler(this.Link_Click);
			this.lnk2.Click += new System.EventHandler(this.Link_Click);
			this.lnk3.Click += new System.EventHandler(this.Link_Click);
			this.lnk4.Click += new System.EventHandler(this.Link_Click);

			this.Load += new System.EventHandler(this.OnPreRender);

		}
		#endregion

		// Copied from ViewController ActionForward
		protected void ActionForward(string action, string querystring)
		{
			string nextPage = 
				System.Configuration.ConfigurationSettings.AppSettings[action];
			if(!querystring.Equals(""))
			{
				nextPage = nextPage + "?" + querystring;
			}
			if(!(nextPage == null))
				Response.Redirect(nextPage);
		}

		private void Link_Click(object sender, System.EventArgs e)
		{
			LinkButton lnkTemp = (LinkButton)sender;

			switch (lnkTemp.ID)
			{
				case "lnk1":
					this.ActionForward("SkillsSummaryReport","");
					break;
				case "lnk2":
					this.ActionForward("TechnicalSkillsDetailedReport","");
					break;
				case "lnk3":
					this.ActionForward("ProductKnowledgeDetailedReport","");
					break;
				case "lnk4":
					this.ActionForward("EmployeeTravelDocumentation","");		
					break;			
			}
			
		}
	}
}

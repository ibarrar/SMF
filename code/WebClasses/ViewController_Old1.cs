//using System;
//using System.Data;
//using System.Web;
//
//namespace SmfRewriteProject
//{
//	/// <summary>
//	/// ViewController controls page flow.
//	/// </summary>
//	public class ViewController : System.Web.UI.Page
//	{
//		public Employee currentUser;
//
//		public ViewController(){}
//
//		protected override void OnPreRender(EventArgs e)
//		{
//
//		}
//
//
//		protected override void OnLoad(EventArgs e)
//		{
//			base.OnLoad (e);
//			HttpContext ctx = HttpContext.Current;
//			// is current page "/Start" (login)
//			bool IsStartPage = (ctx.Request.Path.ToString() == ctx.Request.ApplicationPath.ToString() + "/" +
//				System.Configuration.ConfigurationSettings.AppSettings["/Start"]);
//			// is current page "/NewUser"
//			bool IsNewUserPage = (ctx.Request.Path.ToString() == ctx.Request.ApplicationPath.ToString() + "/" +
//				System.Configuration.ConfigurationSettings.AppSettings["/NewUser"]);
//			if(!(IsStartPage || IsNewUserPage)){
//				if(!System.Configuration.ConfigurationSettings.AppSettings["AuthenticationMode"].ToString().Equals("debug"))
//				{
//					Employee user = (Employee)Session["User"];
//					if(user == null)
//						Response.Redirect(System.Configuration.ConfigurationSettings.AppSettings["/Start"]);
//					currentUser = user;
//				}
//			}
//		}
//
//
//		protected override void OnError(EventArgs e)
//		{
//			base.OnError (e);
//			HttpContext ctx = HttpContext.Current;
//			
//			if(!System.Configuration.ConfigurationSettings.AppSettings["ErrorHandlerMode"].ToString().Equals("development"))
//				Response.Redirect("error.aspx");
//			
//			Exception exception = ctx.Server.GetLastError();
//			ctx.Response.Write(
//				"<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\">" +
//				"<tr valign=\"top\"><td>Offending URL:</td><td>" + Request.Url.ToString() + "</td></tr>" +
//				"<tr valign=\"top\"><td>Source:</td><td>" + exception.Source + "</td></tr>" +
//				"<tr valign=\"top\"><td>Message:</td><td>" + exception.Message + "</td></tr>" +
//				"<tr valign=\"top\"><td>Stack trace:</td><td>" + exception.StackTrace + "</td></tr>" +
//				"</table>");
//			ctx.Server.ClearError();
//		}
//
//
//		protected void Login(string LoginName, string Password){
//			// TODO: implement ViewController.Login()
//			try{
//				ReportGenerator r = new ReportGenerator();
//				WebAppDataHandler db = new WebAppDataHandler(
//					System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
//				string[] sql = {"SELECT sEmpPswd FROM T_SKILLS_EMPINFO WHERE sLoginID='" + LoginName + "'"};
//				r.getQueryRequest(sql);
//				DataSet ds = db.CreateReport(r);
//				if(!(ds.Tables[0].Rows.Count == 0))
//				{
//					string hash = ds.Tables[0].Rows[0][0].ToString();
//					bool test = HashGenerator.VerifyHash(Password, "MD5", hash);
//					// Instantiate User
//					if(test)
//					{
//						Employee emp = new Employee(LoginName);
//						// for testing
//						emp.setEmpPermission("S");
//						this.currentUser = emp;
//						Session["User"] = emp;
//					}
//				}
//			}
//			catch(Exception ex){
//				throw ex;
//			}
//		}
//
//
//		protected void Logout(){
//			Session.Clear();
//			Session.Abandon();
//			this.ActionForward("/End");
//		}
//
//
//		protected void ActionForward(string action){
//			this.ActionForward(action, "");
//		}
//
//		protected void ActionForward(string action, string querystring){
//			string nextPage = 
//				System.Configuration.ConfigurationSettings.AppSettings[action];
//			if(!querystring.Equals("")){
//				nextPage = nextPage + "?" + querystring;
//			}
//			if(!(nextPage == null))
//				Response.Redirect(nextPage);
//		}
//
//	}
//}
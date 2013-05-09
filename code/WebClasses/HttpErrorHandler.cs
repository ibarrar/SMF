using System;
using System.Web;

namespace SmfRewriteProject
{
	/// <summary>
	/// HttpErrorHandler is the error trapping module for Http level errors.
	/// </summary>
	public class HttpErrorHandler : IHttpModule
	{
		public const string FONT_FACE = "courier new";
		public const string FONT_SIZE = "2";

		public void Init(HttpApplication app){
			app.Error += new System.EventHandler(OnError);
		}

		public void OnError(Object obj, EventArgs arg){
			HttpContext ctx = HttpContext.Current;
			
			if(!System.Configuration.ConfigurationSettings.AppSettings["ErrorHandlerMode"].ToString().Equals("development"))
				ctx.Server.Transfer("error.aspx");
			
			Exception exception = ctx.Server.GetLastError();
			ctx.Response.Write(
				"<table border=\"0\" cellspacing=\"2\" cellpadding=\"2\">" +
				"<tr valign=\"top\"><td>" + setText("Offending URL:") + "</td><td>" + setText(ctx.Request.Url.ToString()) + "</td></tr>" +
				"<tr valign=\"top\"><td>" + setText("Source:") + "</td><td>" + setText(exception.Source) + "</td></tr>" +
				"<tr valign=\"top\"><td>" + setText("Message:") + "</td><td>" + setText(exception.Message) + "</td></tr>" +
				"<tr valign=\"top\"><td>" + setText("Stack Trace:") + "</td><td>" + setText(exception.StackTrace) + "</td></tr>" +
				"<tr valign=\"top\"><td>" + setText("Inner Exception Source:") + "</td><td>" + setText(exception.InnerException.Source) + "</td></tr>" +
				"<tr valign=\"top\"><td>" + setText("Inner Exception Message:") + "</td><td>" + setText(exception.InnerException.Message) + "</td></tr>" +
				"<tr valign=\"top\"><td>" + setText("Inner Exception Stack Trace:") + "</td><td>" + setText(exception.InnerException.StackTrace) + "</td></tr>" +
				"<tr valign=\"top\"><td>" + setText("Help Link:") + "</td><td>" + setText(exception.HelpLink) + "</td></tr>" +
				"</table>");
			ctx.Server.ClearError();
		} 

		private string setText(string content){
			return "<font face=\"" + FONT_FACE + "\" size=\"" + FONT_SIZE + "\">"
				+ content + "</font>";
		}

		public void Dispose(){}
	}
}

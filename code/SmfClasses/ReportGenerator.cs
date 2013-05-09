using System;
using System.Data;
using System.Collections;

namespace SmfRewriteProject
{
	/// <summary>
	/// ReportGenerator class is used to generate reports
	/// by passing SQL strings and returning a DataSet.
	/// </summary>
	public class ReportGenerator : IReporter
	{

		public void getQueryRequest(string[] QueryString)
		{
			this.SqlStrings = new ArrayList();
			foreach(string s in QueryString)
				this.SqlStrings.Add(s);
		}

		public void clearQueryRequest()
		{
			this.SqlStrings.Clear();
		}

		


		#region " IReporter Implementation "

		public ArrayList getQueryRequest(){return this.SqlStrings;}

		public void getQueryStoredProc(
			// Implement for stored procedures
			out string ProcedureName, out string[] ParamNames, out string[] ParamValues)
		{
			ProcedureName = "";
			ParamNames = new string[]{"1", "2"};
			ParamValues = new string[]{"1", "2"};
		}
        
		#endregion

		#region " ReportGenerator Attributes "
		private ArrayList SqlStrings;
		#endregion
	}
}

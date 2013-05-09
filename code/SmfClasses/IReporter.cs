using System;
using System.Collections;

namespace SmfRewriteProject
{
	/// <summary>
	/// IReporter must be implemented by reporter modules to retrieve
	/// data using WebAppDataHandler.
	/// </summary>
	interface IReporter
	{
		ArrayList getQueryRequest();
		void getQueryStoredProc(
			out string strSpName, out string[] strParams, out string[] strValues);
	}
}

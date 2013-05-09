using System;
using System.Collections;

namespace SmfRewriteProject
{
	/// <summary>
	/// IDBAction must be implemented by classes that only
	/// need to perform data manipulation commands with
	/// WebAppDataHandler.
	/// </summary>
	public interface IDBAction{
		ArrayList getNonQueryRequest();
		void getNonQueryStoredProc(
			out string strSpName, out string[] strParams, out string[] strValues);
	}
}

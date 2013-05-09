using System.Collections;

namespace SmfRewriteProject
{
	/// <summary>
	/// IStorable interface must be implemented by objects that need to
	/// store data on the WebAppDataInterface database.
	/// </summary>
	interface IStorable{
		ArrayList getQueryRequest();
		ArrayList getNonQueryRequest();
		void getQueryStoredProc(
			out string strSpName, out string[] strParams, out string[] strValues);
		void getNonQueryStoredProc(
			out string strSpName, out string[] strParams, out string[] strValues);
	}
}
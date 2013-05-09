using System;
using System.Collections;
using System.Data;

namespace SmfRewriteProject
{
	/// <summary>
	/// Summary description for Certifications.
	/// </summary>
	[System.Serializable()]
	public class Certification : IStorable
	{
		private string _empID;
        private ArrayList _sqlStrings;	

		public Certification(string empID)
		{
			Employee emp = new Employee(empID);
            _empID = emp.sEmpID;
            _sqlStrings = new ArrayList();
		}

		public void updateCert(string oldCert, 
			                   string newCert, 
			                   int month,
							   int day,
							   int year,
							   string sponsor)
		{
			oldCert.Trim();
			newCert.Trim();
			sponsor.Trim();
			
			string sql = @"UPDATE T_CERT SET sCertnLic='{0}', dComMM={1}, dComDD={2}, dComYYYY={3}, sSponsor='{4}' WHERE sCertnLic='{5}' AND sEmpID={6}";
			
            _sqlStrings.Add(string.Format(sql,newCert,month,day,year,sponsor,oldCert,_empID));
			
		}

		public void deleteCert(string sCert)
		{

            _sqlStrings.Add("DELETE FROM T_CERT WHERE sCertnLic='" + sCert + "' AND sEmpID=" + _empID);

		}

		public void addCert(string sCert, int month, int day, int year, string sponsor)
		{
			string sql = @"INSERT INTO T_CERT VALUES({0},'{1}',{2},{3},{4},'{5}')";

            _sqlStrings.Add(string.Format(sql, _empID, sCert, month, day, year, sponsor));
		}

		#region IStorable Members

		public ArrayList getQueryRequest()
		{
			ArrayList returnArray = new ArrayList();         
			returnArray.Add("SELECT * FROM T_CERT where sEmpID =" + _empID);
            
            return returnArray;
		}

		public ArrayList getNonQueryRequest()
		{
			return _sqlStrings;
		}

		public void getQueryStoredProc(out string strSpName, out string[] strParams, out string[] strValues)
		{
			// TODO:  Add Certification.getQueryStoredProc implementation
			strSpName = null;
			strParams = null;
			strValues = null;
		}

		public void getNonQueryStoredProc(out string strSpName, out string[] strParams, out string[] strValues)
		{
			// TODO:  Add Certification.getNonQueryStoredProc implementation
			strSpName = null;
			strParams = null;
			strValues = null;
		}

		#endregion
	}
}

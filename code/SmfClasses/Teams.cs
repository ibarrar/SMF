using System;
using System.Collections;
using System.Data;

namespace SmfRewriteProject
{
	/// <summary>
	/// Summary description for Teams.
	/// </summary>
	[System.Serializable()]
	public class Teams : IStorable
	{
		private string LoginId;
		private ArrayList SqlStrings;
		bool queryUniqueOnly = false;

		//public Teams() : this(null) {}

		public Teams(string LoginId)
		{
			this.LoginId = LoginId;
			this.SqlStrings = new ArrayList();
		}

		public bool QueryUniqueOnly
		{
			set 
			{
				queryUniqueOnly = value;
			}
		}

		public void updateTeam(string oldTeam, string newTeam, string oldSubTeam, string newSubTeam)
		{
			//string NonQuery;

			oldTeam.Trim();
			newTeam.Trim();
			oldSubTeam.Trim();
			newSubTeam.Trim();

			if ( this.SqlStrings.Count > 0 )
			{
				this.SqlStrings.Clear();
			}
			//if( oldTeam != newTeam )
			//{
				this.SqlStrings.Add("UPDATE T_TEAMS SET Teams='" + newTeam + "' , SubTeam = '" + newSubTeam + "' WHERE Teams='" + oldTeam + "' AND SubTeam = '" + oldSubTeam + "'");
				this.SqlStrings.Add("UPDATE T_SKILLS_EMPINFO SET sEmpPosition='" + newTeam + "' where sEmpPosition='" + oldTeam + "' AND sSubTeam = '" + oldSubTeam + "'" );
			//}
		}

		public void deleteTeam(string sTeam, string sSubTeam)
		{
			if ( this.SqlStrings.Count > 0 )
			{
				this.SqlStrings.Clear();
			}
			this.SqlStrings.Add("DELETE FROM T_TEAMS WHERE Teams='" + sTeam + "' AND SubTeam = '" + sSubTeam + "'");
		}

		public void deleteTeam(string sTeam)
		{
			if ( this.SqlStrings.Count > 0 )
			{
				this.SqlStrings.Clear();
			}
			this.SqlStrings.Add("DELETE FROM T_TEAMS WHERE Teams='" + sTeam + "'");

		}

		public void addTeam(string sTeam)
		{
			if ( this.SqlStrings.Count > 0 )
			{
				this.SqlStrings.Clear();
			}
			this.SqlStrings.Add("INSERT INTO T_TEAMS VALUES('" + sTeam + "','none')");


		}


		#region IStorable Members

		public ArrayList getQueryRequest()
		{
			ArrayList returnArray = new ArrayList();  
			string query = ( queryUniqueOnly ? "DISTINCT Teams" : "*" );
			returnArray.Add("SELECT " + query + " FROM T_TEAMS order by Teams");
			return returnArray;
		}

		public ArrayList getNonQueryRequest()
		{
			return this.SqlStrings;
		}

		public void getQueryStoredProc(out string strSpName, out string[] strParams, out string[] strValues)
		{
			// TODO:  Add TechnicalSkills.getQueryStoredProc implementation
			strSpName = null;
			strParams = null;
			strValues = null;
		}

		public void getNonQueryStoredProc(out string strSpName, out string[] strParams, out string[] strValues)
		{
			// TODO:  Add TechnicalSkills.getNonQueryStoredProc implementation
			strSpName = null;
			strParams = null;
			strValues = null;
		}

		#endregion
	}
}


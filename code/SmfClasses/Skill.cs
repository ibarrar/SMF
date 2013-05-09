using System;
using System.Collections;

namespace SmfRewriteProject
{
	/// <summary>
	/// Skill is inherited by TechSkill and ProductSkill.
	/// </summary>
	public class Skill : IStorable
	{
		#region " EmployeeSkill Database Fields "
		/*
		 sEmpID, sSkillType, sSkill, sLevel, sDateLastUsed
		 sYrExperience, sCreateDate, sLastUpdateID, sLastUpdate
		 */
		#endregion

		public Skill(string sSkillType, string sSkill, string sLevel, 
			string sDateLastUsed, string sYrExperience)
		{
			this.SqlStrings = new ArrayList();
			this.sSkillType = sSkillType;
			this.sSkill = sSkill;
			this.sLevel = sLevel;
			this.sDateLastUsed = sDateLastUsed;
			this.sYrExperience = sYrExperience;
		}


		public Skill(string sSkillType, string sSkill, string sLevel, 
			string sDateLastUsed, string sYrExperience, string EmpId)
		{
			this.SqlStrings = new ArrayList();
			this.sSkillType = sSkillType;
			this.sSkill = sSkill;
			this.sLevel = sLevel;
			this.sDateLastUsed = sDateLastUsed;
			this.sYrExperience = sYrExperience;
			this.EmpId = EmpId;
		}


		public void Add()
		{
			this.SqlStrings.Clear();
			this.SqlStrings.Add("INSERT INTO T_SKILLS_EMPSKILLS VALUES('" +
				this.EmpId + "', '" + this.sSkillType + "', '" + this.sSkill + "', " +
				this.sLevel + "', '" + this.sDateLastUsed + "', '" +
				this.sYrExperience + "', '" + System.DateTime.Today + "', '" +
				this.EmpId + "', '" + System.DateTime.Today + "')");
		}

		public void Modify()
		{
			this.SqlStrings.Clear();
			this.SqlStrings.Add("UPDATE T_SKILLS_EMPSKILLS SET " + 
				"sLevel=" + this.sLevel + " " +
				"sDateLastUsed='" + this.sDateLastUsed + "' " +
				"sYrExperience=" + this.sYrExperience + " " +
				"sLastUpdateID='" + this.sLastUpdateID + "' " +
				"sLastUpdate='" + this.sLastUpdate + "' " +
				"WHERE EmployeeId='" + this.EmpId + "' " +
				"AND sSkill='" + this.sSkill + "'");
		}


		public void Delete()
		{
			this.SqlStrings.Clear();
			this.SqlStrings.Add(
				"DELETE FROM T_SKILLS_EMPSKILLS " +
				"WHERE sSkill='" + this.sSkill + "' " +
				"AND sEmpID='" + this.EmpId + "'");
		}


		#region " IStorable Implementation "

		public ArrayList getNonQueryRequest()
		{
			return this.SqlStrings;
		}


		public ArrayList getQueryRequest()
		{
			return this.SqlStrings;
		}


		public void getNonQueryStoredProc(
			// Implement for stored procedures
			out string ProcedureName, out string[] ParamNames, out string[] ParamValues)
		{
			ProcedureName = "";
			ParamNames = new string[]{"1", "2"};
			ParamValues = new string[]{"1", "2"};
		}


		public void getQueryStoredProc(
			// Implement for stored procedures
			out string ProcedureName, out string[] ParamNames, out string[] ParamValues)
		{
			ProcedureName = "";
			ParamNames = new string[]{"1", "2"};
			ParamValues = new string[]{"1", "2"};
		}
      
		#endregion

		#region " Skill Attributes "

		protected ArrayList SqlStrings;
		public string sSkillType, sSkill, sLevel, sDateLastUsed,
			sYrExperience, sCreateDate, sLastUpdateID, sLastUpdate;
		internal string EmpId = "";

		#endregion

	}
}

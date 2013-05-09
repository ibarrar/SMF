using System;
using System.Collections;

namespace SmfRewriteProject
{
	/// <summary>
	/// Summary description for SkillType.
	/// </summary>
	public class SkillCodes : IReporter
	{
		public SkillCodes(){}
		public void getTechSkills(){
			this.SqlStrings.Add(
				"SELECT sSkill FROM T_SKILLS_CODE " +
				"WHERE sSkillType='tech'");
		}
		public void getProductKnowledge(){
			this.SqlStrings.Add(
				"SELECT DISTINCT sSkillType FROM T_SKILLS_CODE " +
				"WHERE NOT sSkillType='tech'");
		}
		public void getSubSkills(){
			this.SqlStrings.Add(
				"SELECT sSkill FROM T_SKILLS_CODE " +
				"WHERE NOT sSkillType='tech'");
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

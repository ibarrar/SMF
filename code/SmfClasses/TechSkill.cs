using System;
using System.Collections;

namespace SmfRewriteProject
{
	/// <summary>
	/// TechSkill handles processing for employee
	/// technical skills information.
	/// </summary>
	public class TechSkill : Skill
	{
		public TechSkill(string sSkillType, string sSkill, string sLevel, 
			string sDateLastUsed, string sYrExperience) : base(sSkillType, sSkill, sLevel, sDateLastUsed, sYrExperience){
			this.SqlStrings = new ArrayList();
			this.sSkillType = "tech";
			this.sSkill = sSkill;
			this.sLevel = sLevel;
			this.sDateLastUsed = sDateLastUsed;
			this.sYrExperience = sYrExperience;
		}

		public TechSkill(string sSkillType, string sSkill, string sLevel, 
			string sDateLastUsed, string sYrExperience, string EmpId) : base(sSkillType, sSkill, sLevel, sDateLastUsed, sYrExperience, EmpId){
			this.SqlStrings = new ArrayList();
			this.sSkillType = "tech";
			this.sSkill = sSkill;
			this.sLevel = sLevel;
			this.sDateLastUsed = sDateLastUsed;
			this.sYrExperience = sYrExperience;
			this.EmpId = EmpId;
		}
	}
}

using System;
using System.Collections;

namespace SmfRewriteProject
{
	/// <summary>
	/// Summary description for TechnicalSkills.
	/// </summary>
	public class TechnicalSkills : IStorable
	{
      private string LoginId;
      public TechnicalSkills() : this(null) {}

		public TechnicalSkills(string LoginId)
		{
         this.LoginId = LoginId;
      }

      #region IStorable Members

      public ArrayList getQueryRequest()
      {
         ArrayList returnArray = new ArrayList();         
         returnArray.Add("SELECT T_SKILLS_CODE.sSkill, T_SKILLS_CODE.sPriority FROM T_SKILLS_CODE WHERE T_SKILLS_CODE.sSkillType = 'Tech' ORDER BY T_SKILLS_CODE.sPriority, T_SKILLS_CODE.sSkill");

         return returnArray;
      }

      public ArrayList getNonQueryRequest()
      {
         return null;
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

using System;
using System.Collections;
using SmfRewriteProject.Util;

namespace SmfRewriteProject
{
	/// <summary>
	/// Summary description for EmployeeList.
	/// </summary>
   [System.Serializable()]
	public class EmployeeList : IStorable
	{
      private string SqlString;

		public EmployeeList()
		{
         SqlString = null;
      }

      private void CreateEmployeeQuerySql(string queryString)
      {
         if (queryString.Trim().Length > 0)
         {
            SqlString = "SELECT T_SKILLS_EMPINFO.sLoginID, T_SKILLS_EMPINFO.sLastName, T_SKILLS_EMPINFO.sFirstName, T_SKILLS_EMPINFO.sEmpStat, T_SKILLS_EMPINFO.sEmpPermission FROM T_SKILLS_EMPINFO ";
            SqlString += "WHERE " + queryString + " ";
            SqlString += "ORDER BY T_SKILLS_EMPINFO.sLastName, T_SKILLS_EMPINFO.sFirstName";
         }
      }

      private void CreateEmployeeSkillQuerySql(string queryString)
      {
         if (queryString.Trim().Length > 0)
         {
            SqlString = "SELECT T_SKILLS_EMPINFO.sLoginID, T_SKILLS_EMPINFO.sLastName, T_SKILLS_EMPINFO.sFirstName, ";
            SqlString += "T_SKILLS_EMPSKILLS.sSkillType, T_SKILLS_EMPSKILLS.sSkill, T_SKILLS_EMPSKILLS.sLevel FROM T_SKILLS_EMPINFO ";
            SqlString += "INNER JOIN T_SKILLS_EMPSKILLS ON T_SKILLS_EMPINFO.sEmpID = T_SKILLS_EMPSKILLS.sEmpID ";
            SqlString += "WHERE " + queryString + " ";
            SqlString += "ORDER BY T_SKILLS_EMPINFO.sLastName, T_SKILLS_EMPINFO.sFirstName, T_SKILLS_EMPSKILLS.sSkillType, T_SKILLS_EMPSKILLS.sSkill";
         }
      }

      private string DetermineProficiencyLevel(string ProfLevel)
      {
         switch(ProfLevel.Trim().ToUpper())
         {
            case "NONE":
            {
               return "= 0";
            }
            case "NOVICE":
            {
               return "= 1";
            }
            case "NOVICE-EXPERT":
            {
               return ">= 1";
            }
            case "INTERMEDIATE":
            {
               return "= 2";
            }
            case "INTERMEDIATE-EXPERT":
            {
               return ">= 2";
            }
            case "EXPERT":
            {
               return "= 3";
            }
            default:
            {
               return "> 0";
            }
         }
      }

      private string EmployeeSkillRetrieveWord(string[] techSkills,
         string[] prodSkills, string ProfLevel)
      {
         string queryString = "";
         int QueryLevel = 0;

         if ((prodSkills.Length > 0) &&
             (techSkills.Length > 0))
         {
            if ((!prodSkills[0].Trim().Equals(String.Empty)) &&
               (!techSkills[0].Trim().Equals(String.Empty)))
            {
               QueryLevel = 1;
            }
         }

         foreach(string t in techSkills)
         {
            if (t.Trim().Length > 0)
            {
               if (QueryLevel == 1)
               {
                  queryString += CreateEmployeeSkillInnerQuerySql(ref QueryLevel, ProfLevel);
               }
               else if (queryString.Length > 0)
               {
                  queryString += " OR ";
               }
               queryString += "(T_SKILLS_EMPSKILLS.sSkillType = 'Tech' AND ";
               queryString += "T_SKILLS_EMPSKILLS.sSkill =";
               queryString += " '" + t.Trim() + "')";
            }
         }

         if (QueryLevel > 1)
         {
            queryString += CreateEmployeeSkillInnerQuerySql(ref QueryLevel, ProfLevel);
            QueryLevel = 1;
         }

         foreach(string t in prodSkills)
         {
            if (t.Trim().Length > 0)
            {
               if (QueryLevel == 1)
               {
                  queryString += " AND";
                  queryString += CreateEmployeeSkillInnerQuerySql(ref QueryLevel, ProfLevel);
               }
               else if (queryString.Length > 0)
               {
                  queryString += " OR ";
               }
               queryString += "(T_SKILLS_EMPSKILLS.sSkillType <> 'Tech' AND ";
               queryString += "T_SKILLS_EMPSKILLS.sSkillType =";
               queryString += " '" + t.Trim() + "')";
            }
         }

         if (QueryLevel > 1)
         {
            queryString += CreateEmployeeSkillInnerQuerySql(ref QueryLevel, ProfLevel);
         }

         return queryString;
      }

      private string CreateEmployeeSkillInnerQuerySql(ref int QueryLevel, string ProfLevel)
      {
         string queryString = "";

         if (QueryLevel == 1)
         {
            queryString += " T_SKILLS_EMPINFO.sEmpID in ";
            queryString += "(SELECT T_SKILLS_EMPINFO.sEmpID FROM T_SKILLS_EMPINFO INNER JOIN ";
            queryString += "T_SKILLS_EMPSKILLS ON T_SKILLS_EMPINFO.sEmpID = T_SKILLS_EMPSKILLS.sEmpID WHERE (";
            QueryLevel = 2;
         }
         else if (QueryLevel == 2)
         {
            queryString += ") AND T_SKILLS_EMPSKILLS.sLevel " + DetermineProficiencyLevel(ProfLevel);
            queryString += " GROUP BY T_SKILLS_EMPINFO.sEmpID)";
         }

         return queryString;
      }

      public void EmployeeListNoSkillRetrieve(string Office, string Status)
      {
         SqlString = "SELECT T_SKILLS_EMPINFO.sLoginID, T_SKILLS_EMPINFO.sLastName, T_SKILLS_EMPINFO.sFirstName ";
         SqlString += "FROM T_SKILLS_EMPINFO ";
         SqlString += "WHERE sEmpID NOT IN (SELECT DISTINCT sEmpID FROM T_SKILLS_EMPSKILLS)";

         if (Office.ToUpper().Trim() != "ALL")
         {
            SqlString += " AND T_SKILLS_EMPINFO.sOfc = '" + Office + "' ";
         }
         else
         {
            SqlString += " AND T_SKILLS_EMPINFO.sOfc <> 'ALL' ";
         }

         if (Status.ToUpper().Trim() != "ALL")
         {
            SqlString += " AND T_SKILLS_EMPINFO.sEmpStat = '" + MapStatus(Status) + "'";
         }  

         SqlString += " ORDER BY T_SKILLS_EMPINFO.sLastName, T_SKILLS_EMPINFO.sFirstName";
      }

      public void EmployeeListSkillsRetrieve(string Office, string Status)
      {
         SqlString = "SELECT T_SKILLS_EMPINFO.sLoginID, T_SKILLS_EMPINFO.sLastName, T_SKILLS_EMPINFO.sFirstName, T_SKILLS_EMPSKILLS.sSkillType, T_SKILLS_EMPSKILLS.sSkill, T_SKILLS_EMPSKILLS.sLevel ";
         SqlString += "FROM T_SKILLS_EMPINFO, T_SKILLS_EMPSKILLS ";
         SqlString += "WHERE T_SKILLS_EMPINFO.sEmpID = T_SKILLS_EMPSKILLS.sEmpID";

         if (Office.ToUpper().Trim() != "ALL")
         {
            SqlString += " AND T_SKILLS_EMPINFO.sOfc = '" + Office + "' ";
         }
         else
         {
            SqlString += " AND T_SKILLS_EMPINFO.sOfc <> 'ALL' ";
         }

         if (Status.ToUpper().Trim() != "ALL")
         {
            SqlString += " AND T_SKILLS_EMPINFO.sEmpStat = '" + MapStatus(Status) + "'";
         }      

         SqlString += " ORDER BY T_SKILLS_EMPINFO.sLastName, T_SKILLS_EMPINFO.sFirstName";
      }

      public void EmployeeSkillRetrieve(string TechSkillSearchString, 
         string ProdSkillSearchString, string ProfLevel, string Office, string Status)
      {
         string tempString = TechSkillSearchString;
         string queryString = "";
         string[] techSkills = tempString.Split(',');
         tempString = ProdSkillSearchString;
         string[] prodSkills = tempString.Split(',');
         
         SqlString = "";

         if (TechSkillSearchString.Trim().Length > 0 ||
             ProdSkillSearchString.Trim().Length > 0)
         {
            queryString = "(" + EmployeeSkillRetrieveWord(techSkills, 
               prodSkills, ProfLevel) + ")";
            queryString += " AND T_SKILLS_EMPSKILLS.sLevel " + DetermineProficiencyLevel(ProfLevel);

            if (Office.ToUpper().Trim() != "ALL")
            {
               queryString += " AND T_SKILLS_EMPINFO.sOfc = '" + Office + "'";
            }
            else
            {
               queryString += " AND T_SKILLS_EMPINFO.sOfc <> 'ALL'";
            }

            if (Status.ToUpper().Trim() != "ALL")
            {
               queryString += " AND T_SKILLS_EMPINFO.sEmpStat = '" + MapStatus(Status) + "'";
            }

            CreateEmployeeSkillQuerySql(queryString);
         }
      }

      private string MapStatus(string Status)
      {
         switch (Status)
         {
            case "Active":
               return "A";
            default:
               return "I";
         }
      }

      public void EmployeeRetrieve(string SearchString, string Office)
      {
         string tempString = SearchString;
         string delimStr = " ,";
         char [] delimiter = delimStr.ToCharArray();
         string queryString = "";
         string [] s = tempString.Split(delimiter);
         
         SqlString = "";

         if (SearchString.Trim().Length > 0)
         {
            foreach(string t in s)
            {
               if (t.Trim().Length > 0)
               {
                  if (queryString.Length > 0)
                  {
                     queryString += " OR ";
                  }
                  queryString += "T_SKILLS_EMPINFO.sFirstName Like '%" + t.Trim() + "%' OR ";
                  queryString += "T_SKILLS_EMPINFO.sLastName Like '%" + t.Trim() + "%'";
               }
            }

            if (Office.ToUpper().Trim() != "ALL")
            {
               queryString = "(" + queryString + ") AND T_SKILLS_EMPINFO.sOfc = '" + Office + "'";
            }
            else
            {
               queryString = "(" + queryString + ") AND T_SKILLS_EMPINFO.sOfc <> 'ALL'";
            }

            CreateEmployeeQuerySql(queryString);
         }
      }

	   public void EmployeeRetrieve(string month, string date, string year, int mode, string Office)
	   {
		   string queryString = "";
		   string searchMode = "Bday";

		   if (mode > -1)
		   {
			   searchMode = (mode == 0 ? "Bday" : "Nav");
		   }

		   if ((month != "") && (month != null) && (IsNumeric.check(month))) 
		   {
			   queryString += "T_SKILLS_EMPINFO.s" + searchMode + "MMM = " + month;
		   }
		   if ((date != "") && (date != null) && (IsNumeric.check(date)))
		   {
			   if( queryString != "" )
			   { 
				   queryString += " AND ";
			   }
			   queryString += "T_SKILLS_EMPINFO.s" + searchMode + "DD = " + date;
		   }
		   if ((year != "") && (year != null) && (IsNumeric.check(year)))
		   {
			   if( queryString != "" )
			   { 
				   queryString += " AND ";
			   }
			   queryString += "T_SKILLS_EMPINFO.s" + searchMode + "YYYY = " + year;
		   }

		   if (Office.ToUpper().Trim() != "ALL")
		   {
			   queryString = "(" + queryString + ") AND T_SKILLS_EMPINFO.sOfc = '" + Office + "'";
		   }
		   else
		   {
			   queryString = "(" + queryString + ") AND T_SKILLS_EMPINFO.sOfc <> 'ALL'";
		   }

		   CreateEmployeeQuerySql(queryString);
	   }

      public void OfficeRetrieve()
      {
         string queryString = "";
         queryString = "SELECT DISTINCT T_SKILLS_EMPINFO.sOfc FROM T_SKILLS_EMPINFO ";
         queryString += "WHERE T_SKILLS_EMPINFO.sOfc <> '' AND T_SKILLS_EMPINFO.sOfc <> 'ALL'";
         queryString += "ORDER BY T_SKILLS_EMPINFO.sOfc";

         SqlString = queryString;
      }
      
	   public void RetrieveAdmin()
	   {
		   this.SqlString = "select sLastName + ', ' + sFirstName + ' (' + sOfc + ')' as sName " +
			                "from T_SKILLS_EMPINFO " +
			                "where sEmpPermission = 'S' " +
			                "order by sLastName, sFirstName ";
	   }
      #region IStorable Members

      public System.Collections.ArrayList getQueryRequest()
      {
         ArrayList returnArray = new ArrayList();         
         returnArray.Add(SqlString);

         return returnArray;
      }

      public System.Collections.ArrayList getNonQueryRequest()
      {
         // TODO:  Add EmployeeList.getNonQueryRequest implementation
         return null;
      }

      public void getQueryStoredProc(out string strSpName, out string[] strParams, out string[] strValues)
      {
         // TODO:  Add EmployeeList.getQueryStoredProc implementation
         strSpName = null;
         strParams = null;
         strValues = null;
      }

      public void getNonQueryStoredProc(out string strSpName, out string[] strParams, out string[] strValues)
      {
         // TODO:  Add EmployeeList.getNonQueryStoredProc implementation
         strSpName = null;
         strParams = null;
         strValues = null;
      }

      #endregion
   }
}

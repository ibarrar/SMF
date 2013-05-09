using System;
using System.Collections;
using System.Data;

namespace SmfRewriteProject
{
	/// <summary>
	/// SkillCode defines each skill.
	/// </summary>
	
   [System.Serializable()]
   public class SkillCode : IStorable
	{
      private string LoginId;
      private string sSkillType;
      private string sSkill;
      private string sPriority;
      private string sOldSkill;
      private WebAppDataHandler.DB_HITS nonQueryType;

		private SkillCode() {}

      public SkillCode(string sLoginId,
         string sSkillType,
         string sSkill,
         string sPriority) : this ( sLoginId, sSkillType, sSkill, sPriority, null, WebAppDataHandler.DB_HITS.QUERY ) {}

      public SkillCode( string sLoginId,
         string sSkillType,
         string sSkill,
         string sPriority,
         string sOldSkill,
         WebAppDataHandler.DB_HITS nonQueryType)
      {
         this.LoginId = sLoginId;
         this.SkillType = sSkillType;
         this.Skill = sSkill;
         this.sPriority = sPriority;
         this.sOldSkill = sOldSkill;
         this.NonQueryType = nonQueryType;
      }

      public string SkillType
      {
         set
         {
            if ( value == null  || value.Equals(String.Empty) )
            {
               throw new ArgumentNullException("SkillCode: SkillType is a required field.");
            }
            else
            {
               this.sSkillType = value;
            }
         }

         get
         {
            return this.sSkillType;
         }
      }

      public string Skill
      {
         set
         {
            if ( value == null  || value.Equals(String.Empty) )
            {
               throw new ArgumentNullException("SkillCode: Skill is a required field.");
            }
            else
            {
               this.sSkill = value;
            }
         }

         get
         {
            return this.sSkill;
         }
      }

      public string Priority
      {
         set
         {
            if ( value == null  || value.Equals(String.Empty) )
            {
               throw new ArgumentNullException("SkillCode: Priority is a required field.");
            }
            else
            {
               this.sPriority = value;
            }
         }

         get
         {
            return this.sPriority;
         }
      }

      public string OldSkill
      {
         get
         {
            return this.sOldSkill == null ? "" : this.sOldSkill;
         }
      }

      public WebAppDataHandler.DB_HITS NonQueryType
      {
         set
         {
            nonQueryType = value;
         }

         get
         {
            return nonQueryType;
         }
      }

      #region IStorable Members

      public ArrayList getQueryRequest()
      {
         string Query =  "SELECT * FROM T_SKILLS_CODE WHERE ";
                Query += "sSkillType = '" + SkillType + "' ";
                Query += "sSkill = '" + Skill + "'";

         ArrayList returnArray = new ArrayList();
         returnArray.Add(Query);

         return returnArray;
      }

      public ArrayList getNonQueryRequest()
      {
         string NonQuery = "";
         ArrayList returnArray = new ArrayList();

         switch ( this.nonQueryType )
         {
            case WebAppDataHandler.DB_HITS.DELETE:
            {
               NonQuery = "DELETE FROM T_SKILLS_CODE WHERE ";
               NonQuery += "sSkillType = '" + SkillType + "' AND ";
               NonQuery += "sSkill = '" + Skill + "'";

               returnArray.Add(NonQuery);

               NonQuery = "DELETE FROM T_SKILLS_EMPSKILLS WHERE ";
               NonQuery += "sSkillType = '" + SkillType + "' AND ";
               NonQuery += "sSkill = '" + Skill + "'";

               returnArray.Add(NonQuery);

               break;
            }

            case WebAppDataHandler.DB_HITS.INSERT:
            {               
               NonQuery = "INSERT INTO T_SKILLS_CODE (sSkillType, sSkill, sPriority, sLastUpdateID, sLastUpdate) VALUES ";
               NonQuery += "('" + SkillType + "', '" + Skill + "', '" + Priority + "', '" + LoginId + "', '" + System.DateTime.Now.Date +  "')";

               returnArray.Add(NonQuery);

//               DataTable employeeTable = new DataTable();
//
//               ReportGenerator rgEmployee = new ReportGenerator();
//               WebAppDataHandler wEmployeeDetail = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
//
//               employeeTable.Columns.Add(new DataColumn("EmpID", typeof(string)));
//
//               string[] arrSQL = {"SELECT T_SKILLS_EMPINFO.sEmpID from T_SKILLS_EMPINFO"};
//			
//               rgEmployee.getQueryRequest(arrSQL);
//
//               // Execute both sql for columns and rows
//               DataSet ds = wEmployeeDetail.CreateReport(rgEmployee);
//
//               foreach (DataRow dbEmpRow in ds.Tables[0].Select(null,null,DataViewRowState.CurrentRows))
//               {
//                  string sEmpID = dbEmpRow["sEmpID"].ToString();
//                  NonQuery = "INSERT INTO T_SKILLS_EMPSKILLS" +
//                     " VALUES(" + sEmpID + ",'"+ SkillType +"','" + Skill + "',0,'',0,'" +
//                     DateTime.Today.ToShortDateString() + "','" + LoginId + "','" +
//                     DateTime.Today.ToShortDateString() + "')";
//                  returnArray.Add(NonQuery);
//               }

               break;
            }

            case WebAppDataHandler.DB_HITS.UPDATE:
            {
               NonQuery =  "UPDATE T_SKILLS_CODE SET ";
               NonQuery += "sSkill = '" + Skill + "', sPriority = " + Priority + ", sLastUpdateID = '" + LoginId + "', sLastUpdate = '" + System.DateTime.Now.Date + "'";
               NonQuery += "WHERE " + "sSkillType = '" + SkillType + "' AND ";
               NonQuery += "sSkill = '" + OldSkill + "'";

               returnArray.Add(NonQuery);

               NonQuery =  "UPDATE T_SKILLS_EMPSKILLS SET ";
               NonQuery += "sSkill = '" + Skill + "', sLastUpdateID = '" + LoginId + "', sLastUpdate = '" + System.DateTime.Now.Date + "'";
               NonQuery += "WHERE " + "sSkillType = '" + SkillType + "' AND ";
               NonQuery += "sSkill = '" + OldSkill + "'";

               returnArray.Add(NonQuery);

               break;
            }

            default:
            {
               throw new ApplicationException("SkillCode: Non-Query called with no update type.");
            }
         }

         this.NonQueryType = WebAppDataHandler.DB_HITS.QUERY;                  

         return returnArray;
      }

      public void getQueryStoredProc(out string strSpName, out string[] strParams, out string[] strValues)
      {
         // TODO:  Add SkillCode.getQueryStoredProc implementation
         strSpName = null;
         strParams = null;
         strValues = null;
      }

      public void getNonQueryStoredProc(out string strSpName, out string[] strParams, out string[] strValues)
      {
         // TODO:  Add SkillCode.getNonQueryStoredProc implementation
         strSpName = null;
         strParams = null;
         strValues = null;
      }

      #endregion
   }
}

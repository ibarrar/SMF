using System;
using System.Collections;
using System.Data;

namespace SmfRewriteProject
{
	/// <summary>
	/// Summary description for TechnicalSkills.
	/// </summary>
	[System.Serializable()]
	public class ProductSkills : IStorable
	{
		private string LoginId;
		private ArrayList SqlStrings;

		//public ProductSkills() : this(null) {}

		public ProductSkills(string LoginId)
		{
			this.LoginId = LoginId;
			this.SqlStrings = new ArrayList();
			//this.SqlStrings.Clear();
			//this.SqlStrings.Add("SELECT * FROM T_SKILLS_CODE");
		}

		public void updateSkill(string oldskillType, string newskillType, string oldskill, string newskill)
		{
         string NonQuery;

			oldskill.Trim();
			newskill.Trim();
			newskillType.Trim();
			oldskillType.Trim();
			if ( this.SqlStrings.Count > 0 )
			{
				this.SqlStrings.Clear();
			}
			if( oldskillType != newskillType )
			{
				this.SqlStrings.Add("UPDATE T_SKILLS_CODE SET sSkillType='" + newskillType + "' where sSkillType='" + oldskillType + "'");

            NonQuery =  "UPDATE T_SKILLS_EMPSKILLS SET ";
            NonQuery += "sSkillType = '" + newskillType + "', sLastUpdateID = '" + this.LoginId + "', sLastUpdate = '" + System.DateTime.Now.Date + "'";
            NonQuery += "WHERE " + "sSkillType = '" + oldskillType + "'";
            this.SqlStrings.Add(NonQuery);

            NonQuery =  "UPDATE T_SKILLS_EMPSUBSYS SET ";
            NonQuery += "sSkillType= '" + newskillType + "', sLastUpdateID = '" + this.LoginId + "', sLastUpdate = '" + System.DateTime.Now.Date + "'";
            NonQuery += "WHERE " + "sSkillType = '" + oldskillType + "'";
            this.SqlStrings.Add(NonQuery);

				oldskillType = newskillType;
			}
			this.SqlStrings.Add("UPDATE T_SKILLS_CODE SET sSkill='" + newskill + "', sSkillType='" + newskillType + "' WHERE sSkillType='" + oldskillType + "' AND sSkill='" + oldskill + "'");

         NonQuery =  "UPDATE T_SKILLS_EMPSUBSYS SET ";
         NonQuery += "sSkill = '" + newskill + "', sSkillType= '" + newskillType + "', sLastUpdateID = '" + this.LoginId + "', sLastUpdate = '" + System.DateTime.Now.Date + "'";
         NonQuery += "WHERE " + "sSkillType = '" + oldskillType + "' AND sSkill='" + oldskill + "'";
         this.SqlStrings.Add(NonQuery);
		}

		public void deleteSkill(string sSkillType, string sSkill)
		{
			if ( this.SqlStrings.Count > 0 )
			{
				this.SqlStrings.Clear();
			}
			this.SqlStrings.Add("DELETE FROM T_SKILLS_CODE WHERE sSkillType='" + sSkillType + "' AND sSkill='" + sSkill + "'");

         string NonQuery =  "DELETE FROM T_SKILLS_EMPSUBSYS ";
         NonQuery += "WHERE " + "sSkillType = '" + sSkillType + "' AND sSkill='" + sSkill + "'";
         this.SqlStrings.Add(NonQuery);

         DataTable empSkillTable = new DataTable();
         ReportGenerator rgEmpSkills = new ReportGenerator();
         WebAppDataHandler wEmpSkillDetail = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);

         empSkillTable.Columns.Add(new DataColumn("SkillType", typeof(string)));

         string[] arrSQLSkill = {"SELECT T_SKILLS_CODE.sSkillType from T_SKILLS_CODE WHERE T_SKILLS_CODE.sSkillType = '" + sSkillType + "'"};

         rgEmpSkills.getQueryRequest(arrSQLSkill);
         DataSet ds = wEmpSkillDetail.CreateReport(rgEmpSkills);
         
         if (ds.Tables[0].Rows.Count < 2)
         {
            NonQuery =  "DELETE FROM T_SKILLS_EMPSKILLS ";
            NonQuery += "WHERE " + "sSkillType = '" + sSkillType + "'";
            this.SqlStrings.Add(NonQuery);
         }

	     // ADDED BY ESC 3/8/05
		 NonQuery =  "DELETE FROM T_SKILLS_EMPSKILLS ";
		 NonQuery += "WHERE NOT EXISTS ";
         NonQuery += "(SELECT * FROM T_SKILLS_EMPSKILLS INNER JOIN T_SKILLS_EMPSUBSYS ";
	     NonQuery += "ON T_SKILLS_EMPSKILLS.sEmpID = T_SKILLS_EMPSUBSYS.sEmpID AND ";
		 NonQuery += "T_SKILLS_EMPSKILLS.sSkillType = T_SKILLS_EMPSUBSYS.sSkillType ";
	     NonQuery += "WHERE T_SKILLS_EMPSKILLS.sSkillType = '" + sSkillType + "')";
         NonQuery += " AND T_SKILLS_EMPSKILLS.sSkillType = '" + sSkillType + "'";
		 this.SqlStrings.Add(NonQuery);
      }

		public void addSkillType(string sSkillType)
		{
			if ( this.SqlStrings.Count > 0 )
			{
				this.SqlStrings.Clear();
			}
			this.SqlStrings.Add("INSERT INTO T_SKILLS_CODE VALUES('" + sSkillType + "', 'no subsys', '9', '" + this.LoginId + "', '" + DateTime.Now + "')");

//         DataTable empSkillTable = new DataTable();
//         ReportGenerator rgEmpSkills = new ReportGenerator();
//         WebAppDataHandler wEmpSkillDetail = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
//
//         empSkillTable.Columns.Add(new DataColumn("SkillType", typeof(string)));
//
//         string[] arrSQLSkill = {"SELECT T_SKILLS_CODE.sSkillType from T_SKILLS_CODE WHERE T_SKILLS_CODE.sSkillType = '" + sSkillType + "'"};
//
//         rgEmpSkills.getQueryRequest(arrSQLSkill);
//         DataSet ds = wEmpSkillDetail.CreateReport(rgEmpSkills);
//         
//         if (ds.Tables[0].Rows.Count < 1)
//         {
//            DataTable employeeTable = new DataTable();
//            ReportGenerator rgEmployee = new ReportGenerator();
//            WebAppDataHandler wEmployeeDetail = new WebAppDataHandler(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
//
//            employeeTable.Columns.Add(new DataColumn("EmpID", typeof(string)));
//
//            string[] arrSQL = {"SELECT T_SKILLS_EMPINFO.sEmpID from T_SKILLS_EMPINFO"};
//			
//            rgEmployee.getQueryRequest(arrSQL);
//            ds = wEmployeeDetail.CreateReport(rgEmployee);
//
//            foreach (DataRow dbEmpRow in ds.Tables[0].Select(null,null,DataViewRowState.CurrentRows))
//            {
//               string sEmpID = dbEmpRow["sEmpID"].ToString();
//               string NonQuery = "INSERT INTO T_SKILLS_EMPSKILLS" +
//                  " VALUES(" + sEmpID + ",'"+ sSkillType +"','main',0,'',0,'" +
//                  DateTime.Today.ToShortDateString() + "','" + this.LoginId + "','" +
//                  DateTime.Today.ToShortDateString() + "')";
//               this.SqlStrings.Add(NonQuery);
//            }
//         }
		}

		public void deleteSkillType(string sSkillType)
		{
			if ( this.SqlStrings.Count > 0 )
			{
				this.SqlStrings.Clear();
			}
			this.SqlStrings.Add("DELETE FROM T_SKILLS_CODE WHERE sSkillType='" + sSkillType + "'");

         string NonQuery =  "DELETE FROM T_SKILLS_EMPSUBSYS ";
         NonQuery += "WHERE " + "sSkillType = '" + sSkillType + "'";
         this.SqlStrings.Add(NonQuery);

         NonQuery =  "DELETE FROM T_SKILLS_EMPSKILLS ";
         NonQuery += "WHERE " + "sSkillType = '" + sSkillType + "'";
         this.SqlStrings.Add(NonQuery);
		}

		#region IStorable Members

		public ArrayList getQueryRequest()
		{
			ArrayList returnArray = new ArrayList();         
			returnArray.Add("SELECT sSkillType,sSkill FROM T_SKILLS_CODE WHERE sSkillType <> 'Tech' order by sSkillType,sSkill");
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

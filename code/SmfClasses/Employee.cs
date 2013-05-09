using System;
using System.Data.SqlClient;
using System.Collections;

namespace SmfRewriteProject
{
	/// <summary>
	/// Employee holds all data for employee information.
	/// </summary>
	[System.Serializable()]
	public class Employee : IStorable
	{
        #region " Employee Attributes "       
        private string _sLoginID, 
                       _sEmpID, 
                       _sEmpPswd, 
                       _sLastName, 
                       _sFirstName,
                       _sEmpPosition, 
                       _sSubTeam, 
                       _sNavYYYY,                        
                       _sNavMMM, 
                       _sNavDD, 
                       _sNickName, 
                       _sGender,
                       _sUGSchool, 
                       _sUGDegree, 
                       _sUGYear, 
                       _sGSchool, 
                       _sGSDegree, 
                       _sGSYear,
                       _sPassportNo, 
                       _sPassportExp, 
                       _sValidVisa, 
                       _sBdayYYYY, 
                       _sBdayMMM, 
                       _sBdayDD,
                       _sCellNo, 
                       _sHomeTel, 
                       _sOtherEmail, 
                       _sAddressStreet, 
                       _sAddressCity,
                       _sEmpStat, 
                       _sEmpPermission, 
                       _sOfc, 
                       _sAddTechSkills, 
                       _sAddProductKnowledge,
                       _sLastUpdateID, 
                       _sLastUpdate;

        private ArrayList _Skills;
        private ArrayList _Products;
        private ArrayList _sqlStrings;

        #endregion

        #region Properties

        public string sLoginID
        {
            get{ return _sLoginID; }
            set{ _sLoginID = value.Trim(); }
        }

        public string sEmpID
        {
            get{ return _sEmpID; }
            set { _sEmpID = value.Trim(); }          
        }
                        
        public string sEmpPswd
        {
            get{ return _sEmpPswd; }
            set{ _sEmpPswd = value; }
        }
                       
        public string sLastName
        {
            get{ return _sLastName; }
            set { _sLastName = value.Trim(); }
        }
                       
        public string sFirstName
        {
            get{ return _sFirstName; }
            set { _sFirstName = value.Trim(); }
        }
                       
        public string sEmpPosition
        {
            get{ return _sEmpPosition; }
            set { _sEmpPosition = value.Trim(); }
        }
                       
        public string sSubTeam
        {
            get{ return _sSubTeam; }
            set { _sSubTeam = value.Trim(); }
        }
                       
        public string sNavYYYY
        {
            get{ return _sNavYYYY; }
            set{ _sNavYYYY = value; }
        }
                                            
        public string sNavMMM
        {
            get{ return _sNavMMM; }
            set { _sNavMMM = value.Trim(); }
        }
                       
        public string sNavDD
        {
            get{ return _sNavDD; }
            set{ _sNavDD  = value; }
        }
                       
        public string sNickName
        {
            get{ return _sNickName; }
            set { _sNickName = value.Trim(); }
        }
                       
        public string sGender
        {
            get{ return _sGender; }
            set { _sGender = value.Trim(); }
        }
                       
        public string sUGSchool
        {
            get{ return _sUGSchool ; }
            set { _sUGSchool = value.Trim(); }
        }
                       
        public string sUGDegree
        {
            get{ return _sUGDegree; }
            set { _sUGDegree = value.Trim(); }
        }
                       
        public string sUGYear
        {
            get{ return _sUGYear; }
            set{ _sUGYear = value; }
        }
                       
        public string sGSchool
        {
            get{ return _sGSchool; }
            set { _sGSchool = value.Trim(); }
        }
                       
        public string sGSDegree
        {
            get{ return _sGSDegree; }
            set { _sGSDegree = value.Trim(); }
        }
                       
        public string sGSYear
        {
            get{ return _sGSYear; }
            set{ _sGSYear = value; }
        }
                       
        public string sPassportNo
        {
            get{ return _sPassportNo ; }
            set { _sPassportNo = value.Trim(); }
        }
                       
        public string sPassportExp
        {
            get{ return _sPassportExp; }
            set { _sPassportExp = value.Trim(); }
        }
                       
        public string sValidVisa
        {
            get{ return _sValidVisa; }
            set { _sValidVisa = value.Trim(); }
        }
                       
        public string sBdayYYYY
        {
            get{ return _sBdayYYYY; }
            set{ _sBdayYYYY = value; }
        }
                       
        public string sBdayMMM
        {
            get{ return _sBdayMMM; }
            set { _sBdayMMM = value.Trim(); }
        }
                       
        public string sBdayDD
        {
            get{ return _sBdayDD; }
            set{ _sBdayDD = value; }
        }
                       
        public string sCellNo
        {
            get{ return _sCellNo; }
            set { _sCellNo = value.Trim(); }
        }
                       
        public string sHomeTel
        {
            get{ return _sHomeTel; }
            set { _sHomeTel = value.Trim(); }
        }
                       
        public string sOtherEmail
        {
            get{ return _sOtherEmail; }
            set { _sOtherEmail = value.Trim(); }
        }
                       
        public string sAddressStreet
        {
            get{ return _sAddressStreet; }
            set { _sAddressStreet = value.Trim(); }
        }
                       
        public string sAddressCity
        {
            get{ return _sAddressCity; }
            set { _sAddressCity = value.Trim(); }
        }
                       
        public string sEmpStat
        {
            get{ return _sEmpStat; }
            set { _sEmpStat = value.Trim().ToUpper(); }
        }
                       
        public string sEmpPermission
        {
            get{ return _sEmpPermission; }
            set{ _sEmpPermission = value.Trim().ToUpper(); }
        }
                       
        public string sOfc
        {
            get{ return _sOfc; }
            set { _sOfc = value.Trim(); }
        }
                       
        public string sAddTechSkills
        {
            get{ return _sAddTechSkills; }
            set { _sAddTechSkills = value.Trim(); }
        }

        public string sAddProductKnowledge
        {
            get{ return _sAddProductKnowledge; }
            set { _sAddProductKnowledge = value.Trim(); }
        }
                       
        public string sLastUpdateID
        {
            get{ return _sLastUpdateID; }
            set { _sLastUpdateID = value.Trim(); }
        }
                       
        public string sLastUpdate
        {
            get{ return _sLastUpdate; }
            set{ _sLastUpdate = value; }
        }

        public ArrayList sqlStrings
        {
            get { return _sqlStrings; }
        }
        
        
        #endregion Properties

        #region Constructor

    	public Employee(string LoginID)
		{
            _Skills = new ArrayList();
            _Products = new ArrayList();
            _sqlStrings = new ArrayList();
            getEmployee(LoginID);

            _sqlStrings.Add( "SELECT * FROM T_SKILLS_EMPINFO " +
                             "WHERE sLoginID='" + this.sLoginID + "'");
		}

		public Employee(string pLoginID, string pEmpID, string pEmpPswd, string pLastName, string pFirstName,
			string pEmpPosition, string pSubTeam, string pNavYYYY, string pNavMMM, string pNavDD, string pNickName, string pGender,
			string pUGSchool, string pUGDegree, string pUGYear, string pGSchool, string pGSDegree, string pGSYear,
			string pPassportNo, string pPassportExp, string pValidVisa, string pBdayYYYY, string pBdayMMM, string pBdayDD,
			string pCellNo, string pHomeTel, string pOtherEmail, string pAddressStreet, string pAddressCity,
			string pEmpStat, string pEmpPermission, string pOfc, string pAddTechSkills, string pAddProductKnowledge,
			string pLastUpdateID, string pLastUpdate)
		{

            _Skills = new ArrayList();
            _Products = new ArrayList();
            _sqlStrings = new ArrayList();

			sLoginID = pLoginID;
			sEmpID = pEmpID;
			sEmpPswd = pEmpPswd;
			sLastName = pLastName;
			sFirstName = pFirstName;
			sEmpPosition = pEmpPosition;
			sSubTeam = pSubTeam;
			sNavYYYY = pNavYYYY;
			sNavMMM = pNavMMM;
			sNavDD = pNavDD;
			sNickName = pNickName;
			sGender = pGender;
			sUGSchool = pUGSchool;
			sUGDegree = pUGDegree;
			sUGYear = pUGYear;
			sGSchool = pGSchool;
			sGSDegree = pGSDegree;
			sGSYear = pGSYear;
			sGSYear = pGSYear;
			sPassportNo = pPassportNo;
			sPassportExp = pPassportExp;
			sValidVisa = pValidVisa;
			sBdayYYYY = pBdayYYYY;
			sBdayMMM = pBdayMMM;
			sBdayDD = pBdayDD;
			sCellNo = pCellNo;
			sHomeTel = pHomeTel;
			sOtherEmail = pOtherEmail;
			sAddressStreet = pAddressStreet;
			sAddressCity = pAddressCity;
			sEmpStat = pEmpStat;
			sEmpPermission = pEmpPermission;
			sOfc = pOfc;
			sAddTechSkills = pAddTechSkills;
			sAddProductKnowledge = pAddProductKnowledge;
			sLastUpdateID = pLastUpdateID;
			sLastUpdate = pLastUpdate;			
		}


        #endregion Constructor

        private void getEmployee(string LoginID)
        {
            _sLoginID = LoginID;


            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"];

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM T_SKILLS_EMPINFO WHERE sLoginID= @LoginName", connection))
                    {
                        command.Parameters.Add(new SqlParameter("LoginName", LoginID));

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            sEmpID = reader["sEmpID"].ToString();
                            sLoginID = reader["sLoginID"].ToString();
                            sEmpPswd = reader["sEmpPswd"].ToString();
                            sLastName = reader["sLastName"].ToString();
                            sFirstName = reader["sFirstName"].ToString();
                            sEmpPosition = reader["sEmpPosition"].ToString();
                            sSubTeam = reader["sSubTeam"].ToString();
                            sNavYYYY = reader["sNavYYYY"].ToString();
                            sNavMMM = reader["sNavMMM"].ToString();
                            sNavDD = reader["sNavDD"].ToString();
                            sNickName = reader["sNickName"].ToString();
                            sGender = reader["sGender"].ToString();
                            sUGSchool = reader["sUGSchool"].ToString();
                            sUGDegree = reader["sUGDegree"].ToString();
                            sUGYear = reader["sUGYear"].ToString();
                            sGSchool = reader["sGSchool"].ToString();
                            sGSDegree = reader["sGSDegree"].ToString();
                            sGSYear = reader["sGSYear"].ToString();
                            sPassportNo = reader["sPassportNo"].ToString();
                            sPassportExp = reader["sPassportExp"].ToString();
                            sValidVisa = reader["sValidVisa"].ToString();
                            sBdayYYYY = reader["sBdayYYYY"].ToString();
                            sBdayMMM = reader["sBdayMMM"].ToString();
                            sBdayDD = reader["sBdayDD"].ToString();
                            sCellNo = reader["sCellNo"].ToString();
                            sHomeTel = reader["sHomeTel"].ToString();
                            sOtherEmail = reader["sOtherEmail"].ToString();
                            sAddressStreet = reader["sAddressStreet"].ToString();
                            sAddressCity = reader["sAddressCity"].ToString();
                            sEmpStat = reader["sEmpStat"].ToString();
                            sEmpPermission = reader["sEmpPermission"].ToString();
                            sOfc = reader["sOfc"].ToString();
                            sAddTechSkills = reader["sAddTechSkills"].ToString();
                            sAddProductKnowledge = reader["sAddProdKnowledge"].ToString();
                            sLastUpdateID = reader["sLastUpdateID"].ToString();
                            sLastUpdate = reader["sLastUpdate"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            return;
        }

        public void Add()
		{
			if (sGSYear.Trim().Equals(""))
			{
				sGSYear = "0";
			}

            _sqlStrings.Add("INSERT INTO T_SKILLS_EMPINFO VALUES(" +
				"'" + sLoginID + "', " +
				sEmpID + ", " +
				"'" + sEmpPswd + "', " +
				"'" + sLastName + "', " +
				"'" + sFirstName + "', " +
				"'" + sEmpPosition + "', " +
				"'" + sSubTeam + "', " +
				sNavYYYY + ", " +
				"'" + sNavMMM + "', " +
				sNavDD + ", " +
				"'" + sNickName + "', " +
				"'" + sGender + "', " +
				"'" + sUGSchool + "', " +
				"'" + sUGDegree + "', " +
				sUGYear + ", " +
				"'" + sGSchool + "', " +
				"'" + sGSDegree + "', " +
				sGSYear + ", " +
				"'" + sPassportNo + "', " +
				"'" + sPassportExp + "', " +
				"'" + sValidVisa + "', " +
				sBdayYYYY + ", " +
				"'" + sBdayMMM + "', " +
				sBdayDD + ", " +
				"'" + sCellNo + "', " +
				"'" + sHomeTel + "', " +
				"'" + sOtherEmail + "', " +
				"'" + sAddressStreet + "', " +
				"'" + sAddressCity + "', " +
				"'" + sEmpStat + "', " +
				"'" + sEmpPermission + "', " +
				"'" + sOfc + "', " +
				"'" + sAddTechSkills + "', " +
				"'" + sAddProductKnowledge + "', " +
				"'" + sLastUpdateID + "', " +
				"'" + sLastUpdate + "')");
		}


		public void Update()
		{
            _sqlStrings.Add("UPDATE T_SKILLS_EMPINFO SET " +
				"sOfc = '" + sOfc + "', " +
				"sFirstName = '" + sFirstName + "', " +
				"sLastName = '" + sLastName + "', " +
				"sEmpPosition = '" + sEmpPosition + "', " +
				"sSubTeam = '" + sSubTeam + "', " +
				"sNavYYYY = " + sNavYYYY + ", " +
				"sNavMMM = '" + sNavMMM + "', " +
				"sNavDD = " + sNavDD + ", " +
				"sNickName = '" + sNickName + "', " +
				"sGender = '" + sGender + "', " +
				"sBdayYYYY = " + sBdayYYYY + ", " +
				"sBdayMMM = '" + sBdayMMM + "', " +
				"sBdayDD = " + sBdayDD + ", " +
				"sCellNo = '" + sCellNo + "', " +
				"sHomeTel = '" + sHomeTel + "', " +
				"sOtherEmail = '" + sOtherEmail + "', " +
				"sAddressStreet = '" + sAddressStreet + "', " +
				"sAddressCity = '" + sAddressCity + "', " +
				"sUGSchool = '" + sUGSchool + "', " +
				"sUGDegree = '" + sUGDegree + "', " +
				"sUGYear = " + sUGYear + ", " +
				"sGSchool = '" + sGSchool + "', " +
				"sGSDegree = '" + sGSDegree + "', " +
				"sGSYear = " + sGSYear + "," +
				"sPassportNo = '" + sPassportNo + "', " +
				"sPassportExp = '" + sPassportExp + "'," +
				"sValidVisa = '" + sValidVisa + "', " +
				"sLastUpdateID = '" + sLoginID + "', " + 
				"sLastUpdate = '" + sLastUpdate + "' " +
				"WHERE sLoginID = '" + sLoginID + "'");
				
		}

        public void Update_Password()
        {
            _sqlStrings.Add("UPDATE T_SKILLS_EMPINFO SET " +
                "sEmpPswd = '" + sEmpPswd + "' " +
                "WHERE sLoginID = '" + sLoginID + "'");

        }

		public  bool Update_Password(string LoginID, string Password)
		{
            WebAppDataHandler wdh = new WebAppDataHandler();
			FE_Symmetric feService = new FE_Symmetric();

            Employee empInfo = new Employee(LoginID);
            empInfo.sEmpPswd = feService.EncryptData("", Password);
            empInfo.Update_Password();
            return wdh.NonQueryRequest(empInfo);

		}
      public bool Update_EmpProfile(string LoginID, string EmpPermission, string EmpStat)
      {
          WebAppDataHandler wdh = new WebAppDataHandler();
          wdh.SQLexecute("UPDATE T_SKILLS_EMPINFO SET " +
            "sEmpPermission = '" + EmpPermission + "', " +
            "sEmpStat = '" + EmpStat + "' " +
            "WHERE sLoginID = '" + LoginID + "'");
         
         return true;
      }

      public bool Delete_Employee(string LoginID)
      {
         WebAppDataHandler wdh = new WebAppDataHandler();
         getEmployee(LoginID);
         wdh.SQLexecute("DELETE FROM T_SKILLS_EMPSUBSYS " +
            "WHERE sEmpID = " + _sEmpID);
         wdh.SQLexecute("DELETE FROM T_SKILLS_EMPSKILLS " +
            "WHERE sEmpID = " + _sEmpID);
         wdh.SQLexecute("DELETE FROM T_SKILLS_EMPINFO " +
            "WHERE sLoginID = '" + _sLoginID + "'");

         return true;
      }


        public override string ToString()
        {
            return sLoginID;
        }

        #region " IStorable implementation "

        public ArrayList getNonQueryRequest()
        {
            return this._sqlStrings;
        }


        public ArrayList getQueryRequest()
        {
            return this._sqlStrings;
        }


        public void getNonQueryStoredProc(
            // Implement for stored procedures
            out string ProcedureName, out string[] ParamNames, out string[] ParamValues)
        {
            ProcedureName = "";
            ParamNames = new string[] { "1", "2" };
            ParamValues = new string[] { "1", "2" };
        }


        public void getQueryStoredProc(
            // Implement for stored procedures
            out string ProcedureName, out string[] ParamNames, out string[] ParamValues)
        {
            ProcedureName = "";
            ParamNames = new string[] { "1", "2" };
            ParamValues = new string[] { "1", "2" };
        }

        #endregion
        
	}
}

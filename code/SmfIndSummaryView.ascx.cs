namespace SmfRewriteProject
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for SmfIndSummaryView.
	/// </summary>
	public class SmfIndSummaryView : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Label lblEmpName;
		protected System.Web.UI.WebControls.Label lblOffice;
		protected System.Web.UI.WebControls.Label lblTeam;
		protected System.Web.UI.WebControls.Label lblNavDate;
		protected System.Web.UI.WebControls.Label lblNickName;
		protected System.Web.UI.WebControls.Label lblGender;
		protected System.Web.UI.WebControls.Label lblBday;
		protected System.Web.UI.WebControls.Label lblHomeNum;
		protected System.Web.UI.WebControls.Label lblCellNum;
		protected System.Web.UI.WebControls.Label lblOtherEmail;
		protected System.Web.UI.WebControls.Label lblHomeAdd;
		protected System.Web.UI.WebControls.Label lblCity;
		protected System.Web.UI.WebControls.Label lblUGSchool;
		protected System.Web.UI.WebControls.Label lblUGDegree;
		protected System.Web.UI.WebControls.Label lblUGYear;
		protected System.Web.UI.WebControls.Label lblGSSchool;
		protected System.Web.UI.WebControls.Label lblGSDegree;
		protected System.Web.UI.WebControls.Label lblGSYear;
		protected System.Web.UI.WebControls.Label lblPassport;
		protected System.Web.UI.WebControls.Label lblExpDate;
		protected System.Web.UI.WebControls.Label lblVisa;
		protected System.Web.UI.WebControls.DataGrid dgTechnicalSkills;
		protected System.Web.UI.WebControls.Label lblAdditionalSkills;
		protected System.Web.UI.WebControls.DataGrid dgPrdKnowledge;

		public DataRow row;
		private string sOffice;
		private string sLstUpdtDate;
		private string sTempExpDate;
		public string[ ] sTempDate;
		private string sTempMonth;
		private string EmpID;
		protected System.Web.UI.WebControls.Label lblAdditionalPrdKnowledge;
		protected System.Web.UI.WebControls.DataGrid dgCerts;
		protected System.Web.UI.WebControls.Label lblSubTeam;
		
		private Employee currentUser;

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dgTechnicalSkills.SelectedIndexChanged += new System.EventHandler(this.dgTechnicalSkills_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		protected override void OnPreRender(EventArgs e)
		{
         if( !this.IsPostBack )
         {
            base.OnPreRender (e);
            this.currentUser = (Employee)Session["User"];
            if (DisplayEmpInfo())
            {
               DisplayTechSkills();
               DisplayPrdKnowledge();
			   DisplayCertificates();
            }
         }
		}

		protected void DisplayPrdKnowledge()
		{
			// Put user code to initialize the page here
			WebAppDataHandler wdh = new WebAppDataHandler();

            DataTable dt = wdh.CreateTable(
                "SELECT sSkillType, sLevel, sDateLastUsed, sYrExperience" +
                " FROM T_SKILLS_EMPSKILLS" +
                " WHERE sEmpID = " + EmpID.ToString() + " AND sSkillType <> 'Tech' and sLevel > 0" +
                " ORDER BY sSkillType ASC");

			dgPrdKnowledge.DataSource=dt;
			dgPrdKnowledge.DataBind();

			for(int i = 0; i < dt.Rows.Count; i++)
			{
				int nLevel = int.Parse(dt.Rows[i].ItemArray[1].ToString());
				Label lbl = (Label)dgPrdKnowledge.Items[i].FindControl("lblLevel");

				switch(nLevel)
				{
					case 1: lbl.Text = "Novice"; break;
					case 2: lbl.Text = "Intermediate"; break;
					case 3: lbl.Text = "Expert"; break;
				}

				Label lbl2 = (Label)dgPrdKnowledge.Items[i].FindControl("lblYrLastUsed");
				lbl2.Text = dt.Rows[i].ItemArray[2].ToString();
//				if(!lbl2.Text.Trim().Equals(""))
//					lbl2.Text = lbl2.Text.Substring(3);
			}

			for(int i = 0; i < dt.Rows.Count; i++)
			{
				string strProduct = dt.Rows[i].ItemArray[0].ToString();
				
				DataTable dtSubsystems = wdh.CreateTable("SELECT * FROM T_SKILLS_EMPSUBSYS WHERE sEMPID = " + EmpID.ToString() + " AND sSkillType = '" + strProduct + "' ORDER BY sSkill ASC");

				Label lbl = (Label)dgPrdKnowledge.Items[i].FindControl("lblProd");
				DataGrid dg = (DataGrid)dgPrdKnowledge.Items[i].FindControl("dgSubsystem");

				lbl.Text = "Has experience on the following " + strProduct + " subsystems:";

				dg.DataSource = dtSubsystems;
				dg.DataBind();

				if(dtSubsystems.Rows.Count == 0)
				{
					lbl.Visible=false;
					dg.Visible=false;
				}
			}

			// get additional Product knowledge
			
			currentUser.sqlStrings.Add("SELECT sAddProdKnowledge" +
				" FROM T_SKILLS_EMPINFO" +
				" WHERE sEmpID = " + EmpID.ToString());		
	
            DataSet dss = wdh.QueryRequest(currentUser);

			if (!(dss.Tables[0].Rows[0][0].ToString() == ""))
			{
				this.lblAdditionalPrdKnowledge.Text = "Has additional Product Knowledge in " + dss.Tables[0].Rows[0][0].ToString();
			}
	
			
		}

		protected void DisplayTechSkills()
		{
            WebAppDataHandler wdh = new WebAppDataHandler();
            DataTable dt = wdh.CreateTable("SELECT sSkill, sLevel, sDateLastUsed, sYrExperience" +
                " FROM T_SKILLS_EMPSKILLS" +
                " WHERE sEmpID = " + EmpID + " AND sSkillType = 'Tech' and sLevel > 0");
			
			dgTechnicalSkills.DataSource = dt;
			dgTechnicalSkills.DataBind();

			for(int i = 0; i < dt.Rows.Count; i++)
			{
				int nLevel = int.Parse(dt.Rows[i].ItemArray[1].ToString());
				Label lbl = (Label)dgTechnicalSkills.Items[i].FindControl("lblLvl");

				switch(nLevel)
				{
					case 1: lbl.Text = "Novice"; break;
					case 2: lbl.Text = "Intermediate"; break;
					case 3: lbl.Text = "Expert"; break;
				}

				Label lbl2 = (Label)dgTechnicalSkills.Items[i].FindControl("lblYrUsed");
				lbl2.Text = dt.Rows[i].ItemArray[2].ToString();
//				if(!lbl2.Text.Trim().Equals(""))
//					lbl2.Text = lbl2.Text.Substring(3);
			}

			// get additional technical skills
            currentUser.sqlStrings.Add("SELECT sAddTechSkills" +
				" FROM T_SKILLS_EMPINFO" +
				" WHERE sEmpID = " + EmpID.ToString());
            
            DataSet dss = wdh.QueryRequest(currentUser);
            
			if (!(dss.Tables[0].Rows[0][0].ToString() == ""))
			{
				lblAdditionalSkills.Text = "Has additional technical skills in " + dss.Tables[0].Rows[0][0].ToString();
			}

		}

		protected void DisplayCertificates()
        {
			//Certification oCert = new Certification(((Employee)Session["User"]).ToString());
			string sLoginID;
			try
			{
				sLoginID = Request.QueryString["sLoginID"].ToString();
			}
			catch (Exception)
			{
				sLoginID = this.currentUser.sLoginID;
			}
            Certification oCert = new Certification(sLoginID);
			WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(
				System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);

			DataSet dset = webAppDataHndlr.QueryRequest(oCert);
			if (dset == null)
			{
				//SMFLibrary.MessageBox(this, "Failed Query. Please contact your system administrator.");
			}
			DataTable ds = dset.Tables[0];
			
			DataTable certsTable = new DataTable();
			certsTable.Columns.Add(new DataColumn("Certification", typeof(string)));
			certsTable.Columns.Add(new DataColumn("Date", typeof(string)));
			certsTable.Columns.Add(new DataColumn("Sponsor", typeof(string)));

			DataColumn[] keys = new DataColumn[1];
			keys[0] = certsTable.Columns["Certification"];

			DataRow dr;
			
			string tempCert = "";
			int ctr = 0;
			//int selectedCert = dlistCerts.SelectedIndex;
			
			//dlistCerts.Items.Clear();
			foreach (DataRow dbCertRow in ds.Rows)
			{
				dr = certsTable.NewRow();
				if ((tempCert == dbCertRow["sCertnLic"].ToString()) 
					&& (dgCerts.EditItemIndex != ctr))
				{
					dr["Certification"] = " ";
				}
				else
				{
					dr["Certification"] = dbCertRow["sCertnLic"].ToString();
					//dr["sMonth"] = getMonthMMM(dbCertRow["dComMM"].ToString());
					//dr["Month"] = dbCertRow["dComMM"];
					//dr["Day"]   = dbCertRow["dComDD"];
					//dr["Year"]  = dbCertRow["dComYYYY"];
					dr["Date"] = getMonthMMM(dbCertRow["dComMM"].ToString()) + " " + dbCertRow["dComDD"].ToString() + ", " + dbCertRow["dComYYYY"].ToString();
					dr["Sponsor"] = dbCertRow["sSponsor"];
					
				}
				tempCert = dbCertRow["sCertnLic"].ToString();
				certsTable.Rows.Add(dr);
				ctr++;
			}
			
			//if (this.dlistCerts.Items.Count > selectedCert)
			//{
			//	dlistCerts.SelectedIndex = selectedCert;
			//}

			dgCerts.DataSource = certsTable;
			dgCerts.DataBind();
		}

		private string getMonthMMM(string sMonthNum)
		{
			switch (sMonthNum)
			{
				case "1": return("Jan");
				case "2": return("Feb");
				case "3": return("Mar");
				case "4": return("Apr");
				case "5": return("May");
				case "6": return("Jun");
				case "7": return("Jul");
				case "8": return("Aug");
				case "9": return("Sep");
				case "10": return("Oct");
				case "11": return("Nov");
				case "12": return("Dec");
				default: return("Mon");
								  
			}
		}
	
		protected bool DisplayEmpInfo()
		{

 ;

			WebAppDataHandler webAppDataHndlr = new WebAppDataHandler();

			DataTable empInfoTable = new DataTable();
			

			DataSet dset = webAppDataHndlr.QueryRequest(currentUser);

         if (dset == null || dset.Tables.Count == 0)
         {
            SMFLibrary.AlertMessageBox(this.Response, "No rows found!");
            return false;
         }

         if (dset.Tables[0].Rows.Count > 0)
         {
            this.setRow(dset.Tables[0].Rows[0]);

            switch (currentUser.sOfc)
            {
               case "MNL": this.sOffice = "Manila";
                  break;
               case "SLC": this.sOffice = "Salt Lake City";
                  break;
               case "MSP": this.sOffice = "Minneapolis";
                  break;
               case "AUS": this.sOffice = "Austin, Texas";
                  break;
               case "SYD": this.sOffice = "Sydney, Australia";
                  break;
               case "Others": this.sOffice = "Others";
                  break;
            }

            lblOffice.Text = sOffice;
			
            this.sLstUpdtDate = currentUser.sLastUpdate;
            this.sTempDate = this.sLstUpdtDate.Split('/');
            this.sTempMonth = setMonth(this.sTempDate[0]);
            //lblLastDateMod.Text = this.sTempDate[1] + " " + this.sTempMonth + " " + this.sTempDate[2].Substring(0, 4);

            lblEmpName.Text = currentUser.sLastName + ", " + currentUser.sFirstName;
            lblTeam.Text = currentUser.sEmpPosition;
			lblSubTeam.Text = currentUser.sSubTeam;
            lblNickName.Text = currentUser.sNickName;
            lblHomeNum.Text = currentUser.sHomeTel;
            lblCellNum.Text = currentUser.sCellNo;
            lblOtherEmail.Text = currentUser.sOtherEmail;
            lblHomeAdd.Text = currentUser.sAddressStreet;
            lblCity.Text = currentUser.sAddressCity;


            this.sTempMonth = setMonth(currentUser.sNavMMM);
            lblNavDate.Text = currentUser.sNavDD + " " + sTempMonth + " " + currentUser.sNavYYYY;

            switch (currentUser.sGender)
            {
               case "M": lblGender.Text = "Male"; break;
               case "F": lblGender.Text = "Female"; break;
            }
            
			this.sTempMonth = setMonth(currentUser.sBdayMMM);
			lblBday.Text = currentUser.sBdayDD + " " + this.sTempMonth; 
		    if (currentUser.sOfc == "MNL") lblBday.Text += " " + currentUser.sBdayYYYY;
	
            if (currentUser.sUGSchool.Length == 0)
            {
               lblUGSchool.Text = "none";
            }
            else
            {
               lblUGSchool.Text = currentUser.sUGSchool;
            }

            if (currentUser.sUGDegree.Length == 0)
            {
               lblUGDegree.Text = "none";
            }
            else
            {
               lblUGDegree.Text = currentUser.sUGDegree;
            }

            if (currentUser.sUGYear.Equals("0"))
            {
               lblUGYear.Text = "none";
            }
            else
            {
               lblUGYear.Text = currentUser.sUGYear;
            }

            if (currentUser.sGSchool.Length == 0)
            {
               lblGSSchool.Text = "none";
            }
            else
            {
               lblGSSchool.Text = currentUser.sGSchool;
            }

            if (currentUser.sGSDegree.Length == 0)
            {
               lblGSDegree.Text = "none";
            }
            else
            {
               lblGSDegree.Text = currentUser.sGSDegree;
            }

            if (currentUser.sGSYear.Equals("0"))
            {
               lblGSYear.Text = "none";
            }
            else
            {
               lblGSYear.Text = currentUser.sGSYear;
            }

            if (currentUser.sPassportNo.Length == 0)
            {
               lblPassport.Text = "none";
            }
            else
            {
               lblPassport.Text = currentUser.sPassportNo;
            }

            if (currentUser.sPassportExp.Length == 0)
            {
               lblExpDate.Text = "none";
            }
            else
            {
               this.sTempExpDate = currentUser.sPassportExp;
               this.sTempDate = this.sTempExpDate.Split('|');
               this.sTempMonth = setMonth(sTempDate[0]);
               string sDay = "";
               if (this.sTempDate.Length > 1)
               {
                  sDay = this.sTempDate[1];
               }
               string sYear = "";
               if (this.sTempDate.Length > 2)
               {
                  sYear = this.sTempDate[2].Substring(0, 4);
               }
               lblExpDate.Text = sDay + " " + this.sTempMonth + " " + sYear;
            }

            if (currentUser.sValidVisa.Length == 0)
            {
               lblVisa.Text = "none";
            }
            else
            {
               lblVisa.Text = currentUser.sValidVisa;
            }

            // Added by Emil - use EmpID of chosen employee
            EmpID = currentUser.sEmpID;
         }
         else
         {
            if (this.Parent.ID == "PopUp_IndSumm")
            {
               SMFLibrary.AlertAndExitMessageBox(this.Response, "Employee record not found.");
            }
            else
            {
               SMFLibrary.AlertMessageBox(this.Response, "Employee record not found.");
            }
            return false;
         }

         return true;
		}

		private void setRow(DataRow row)
		{
			this.row = row;
		}

		private string setMonth(string month)
		{
			switch(month)
			{
				case "Jan": 
				case "1": return("January"); 
				case "Feb": 
				case "2": return("February"); 
				case "Mar": 
				case "3": return("March"); 
				case "Apr": 
				case "4": return("April");
				case "May": 
				case "5": return("May");
				case "Jun": 
				case "6": return("June"); 
				case "Jul": 
				case "7": return("July"); 
				case "Aug": 
				case "8": return("August");
				case "Sep": 
				case "9": return("September"); 
				case "Oct": 
				case "10": return("October"); 
				case "Nov": 
				case "11": return("November"); 
				case "Dec": 
				case "12" : return("December"); 
				default:return("Invalid");
			}
		}

		private string getString(string instring)
		{
			return (this.row[instring].ToString());
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
		
		}

		private void dgTechnicalSkills_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SmfRewriteProject
{
	/// <summary>
	/// Summary description for IndSummary.
	/// </summary>
	public class IndSummary : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label EmpName;
		protected System.Web.UI.WebControls.Label Office;
		protected System.Web.UI.WebControls.Label TeamRole;
		protected System.Web.UI.WebControls.Label Start;
		protected System.Web.UI.WebControls.Label NickName;
		protected System.Web.UI.WebControls.Label Gender;
		protected System.Web.UI.WebControls.Label Bday;
		protected System.Web.UI.WebControls.Label CellNum;
		protected System.Web.UI.WebControls.Label OtherEmail;
		protected System.Web.UI.WebControls.Label HomeAdd;
		protected System.Web.UI.WebControls.Label City;
		protected System.Web.UI.WebControls.Label PassportNum;
		protected System.Web.UI.WebControls.Label Visa;
		protected System.Web.UI.WebControls.Label UGSchool;
		protected System.Web.UI.WebControls.Label UGDegree;
		protected System.Web.UI.WebControls.Label UGYear;
		protected System.Web.UI.WebControls.Label GSchool;
		protected System.Web.UI.WebControls.Label GDegree;
		protected System.Web.UI.WebControls.Label GYear;
		protected System.Web.UI.WebControls.Label PassportExp;
		protected System.Web.UI.WebControls.Label HomeNum;
	
		public DataRow dbEmpRow;

		private void Page_Load(object sender, System.EventArgs e)
		{
			string sTempMonth;
			string sTempExpDate;
			string[ ] sTempDate;
            //Dbase db = new Dbase();

            if (Request.QueryString["LoginId"] == null)
            {                
                return;
            }

            string sLoginID = Request.QueryString["LoginId"].ToString();
            //string strQuery = "Select * from T_SKILLS_EMPINFO where sLoginID = " + "'" + sLoginID + "'";
            //DataRowCollection rows = db.action(strQuery);
            //setRow(rows[0]);

            Employee empInfo = new Employee(sLoginID);

            if (empInfo == null)
            {
                SMFLibrary.AlertMessageBox(this.Response, "Employee "+sLoginID+" not found\n. Please contact your system administrator.");
            }

			switch (empInfo.sOfc)
			{
				case "MNL": Office.Text = "Manila";
					break;
				case "SLC": Office.Text = "Salt Lake City";
					break;
				case "MSP": Office.Text = "Minneapolis";
					break;
				case "AUS": Office.Text = "Austin, Texas";
					break;
				case "SYD": Office.Text = "Sydney, Australia";
					break;
				case "Others": Office.Text = "Others";
					break;
			}

			EmpName.Text = empInfo.sLastName + ", " + empInfo.sFirstName;

			sTempMonth = setMonth(empInfo.sNavMMM);
			Start.Text = empInfo.sNavDD + " " + sTempMonth + " " + empInfo.sNavYYYY;
			NickName.Text = dbEmpRow["sNickName"].ToString();

			switch (empInfo.sGender)
			{
				case "M": Gender.Text = "Male"; break;
				case "F": Gender.Text = "Female"; break;
			}
            
			sTempMonth = setMonth(empInfo.sBdayMMM);
			Bday.Text = empInfo.sBdayDD + " " + sTempMonth + " " + empInfo.sBdayYYYY;
			HomeNum.Text = dbEmpRow["sHomeTel"].ToString();
			CellNum.Text = dbEmpRow["sCellNo"].ToString();
			OtherEmail.Text = dbEmpRow["sOtherEmail"].ToString();
			HomeAdd.Text = dbEmpRow["sAddressStreet"].ToString();
			City.Text = dbEmpRow["sAddressCity"].ToString();

			
			if (empInfo.sGSchool.Length == 0)
			{
				UGSchool.Text = "none";
			}
			else
			{
				UGSchool.Text = empInfo.sGSchool;
			}

			if (empInfo.sGSDegree.Length == 0)
			{
				UGDegree.Text = "none";
			}
			else
			{
				UGDegree.Text= empInfo.sGSDegree;
			}

			if (empInfo.sGSYear.Equals("0"))
			{
				UGYear.Text = "none";
			}
			else
			{
				UGYear.Text= empInfo.sGSYear;
			}

			if (empInfo.sGSchool.Length == 0)
			{
				GSchool.Text = "none";
			}
			else
			{
				GSchool.Text = empInfo.sGSchool;
			}

			if (empInfo.sGSDegree.Length == 0)
			{
				GDegree.Text = "none";
			}
			else
			{
				GDegree.Text= empInfo.sGSDegree;
			}

			if (empInfo.sGSYear.Equals("0"))
			{
				GYear.Text = "none";
			}
			else
			{
				GYear.Text= empInfo.sGSYear;
			}

			if (empInfo.sPassportNo.Length == 0)
			{
				PassportNum.Text = "none";
			}
			else
			{
				PassportNum.Text= empInfo.sPassportNo;
			}

			if (empInfo.sPassportExp.Length == 0)
			{
				PassportExp.Text = "none";
			}
			else
			{
				sTempExpDate = empInfo.sPassportExp;
				sTempDate = sTempExpDate.Split('|'); 
				sTempMonth = setMonth(sTempDate[0]);
				PassportExp.Text = sTempDate[1] + " " + sTempMonth + " " + sTempDate[2].Substring(0, 4);
			}

			if (empInfo.sValidVisa.Length == 0)
			{
				Visa.Text = "none";
			}
			else
			{
				Visa.Text = empInfo.sValidVisa;
			}

			  		
			//sLstUpdtDate = empInfo.sLastUpdate;
			//sTempDate = sLstUpdtDate.Split('/');
			//sTempMonth = setMonth(sTempDate[0]);
			//sTempLstUpdtDate = sTempDate[1] + " " + sTempMonth + " " + sTempDate[2].Substring(0, 4);


			
		}

		private void setRow(DataRow row)
		{
			this.dbEmpRow = row;
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}

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
	/// Summary description for skills_myprofile.
	/// </summary>
	public class skills_myprofile : ViewController
	{
		protected System.Web.UI.WebControls.Label lblLoginID;
		protected System.Web.UI.WebControls.Label lblEmpID;
		protected System.Web.UI.WebControls.Label lblOffice;
		protected System.Web.UI.WebControls.Label lblLastDateMod;
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
		protected System.Web.UI.WebControls.Label lblGSSchool;
		protected System.Web.UI.WebControls.Label lblPassport;
		protected System.Web.UI.WebControls.Label lblExpDate;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;

		public DataRow row;
		private string sOffice;
		private string sLstUpdtDate;
		private string sTempExpDate;
		public string[ ] sTempDate;
		protected System.Web.UI.WebControls.Label lblEmpName;
		protected System.Web.UI.WebControls.Label lblUGSchool;
		protected System.Web.UI.WebControls.Label lblUGDegree;
		protected System.Web.UI.WebControls.Label lblUGYear;
		protected System.Web.UI.WebControls.Label lblGSDegree;
		protected System.Web.UI.WebControls.Label lblGSYear;
		protected System.Web.UI.WebControls.Label lblVisa;
		protected System.Web.UI.WebControls.LinkButton lbEditProfile;
		protected System.Web.UI.WebControls.LinkButton lbChangePassword;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.LinkButton lbEditProfile2;
		protected System.Web.UI.WebControls.LinkButton blChangePassword2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblSubTeam;
		private string sTempMonth;

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

        //private string getString(string instring)
        //{
        //    return (this.row[instring].ToString());
        //}

		private void Page_Load(object sender, System.EventArgs e)
		{
		}

	
		protected override void OnPreRender(EventArgs e)
		{
			//Employee empInfo = new Employee(((Employee) Session["User"]).getLoginID());

            Employee empInfo = Session["User"] as Employee;

            //WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(
            //    System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);

			//DataSet dset = webAppDataHndlr.QueryRequest(empInfo);
            //if (dset == null)
            //{
            //    SMFLibrary.MessageBox(this, "Failed Query. Please contact your system administrator.");
				
            //}
            //else
            //{
            //    this.setRow(dset.Tables[0].Rows[0]);
            //}

			lblLoginID.Text = empInfo.sLoginID;
			lblEmpID.Text = empInfo.sEmpID;

            

			switch (empInfo.sOfc)
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
				default: this.sOffice = "Others";
					break;
			}

			lblOffice.Text = sOffice;

            this.sLstUpdtDate = empInfo.sLastUpdate;
			this.sTempDate = this.sLstUpdtDate.Split('/');
			this.sTempMonth = setMonth(this.sTempDate[0]);
			lblLastDateMod.Text = this.sTempDate[1] + " " + this.sTempMonth + " " + this.sTempDate[2].Substring(0, 4);

			lblEmpName.Text = empInfo.sLastName + ", " + empInfo.sFirstName;
            lblTeam.Text = empInfo.sEmpPosition;
			lblSubTeam.Text = empInfo.sSubTeam;
			lblNickName.Text = empInfo.sNickName;
			lblHomeNum.Text = empInfo.sHomeTel;
			lblCellNum.Text = empInfo.sCellNo;
			lblOtherEmail.Text = empInfo.sOtherEmail;
			lblHomeAdd.Text = empInfo.sAddressStreet;
			lblCity.Text = empInfo.sAddressCity;


			this.sTempMonth = setMonth(empInfo.sNavMMM);
			lblNavDate.Text = empInfo.sNavDD + " " + sTempMonth + " " + empInfo.sNavYYYY;

			switch (empInfo.sGender)
			{
				case "M": lblGender.Text = "Male"; break;
				case "F": lblGender.Text = "Female"; break;
			}
            
			this.sTempMonth = setMonth(empInfo.sBdayMMM);
			lblBday.Text = empInfo.sBdayDD + " " + this.sTempMonth + " " + empInfo.sBdayYYYY;

			if (empInfo.sUGSchool.Length == 0)
			{
				lblUGSchool.Text = "none";
			}
			else
			{
				lblUGSchool.Text = empInfo.sUGSchool;
			}

			if (empInfo.sUGDegree.Length == 0)
			{
				lblUGDegree.Text = "none";
			}
			else
			{
				lblUGDegree.Text = empInfo.sUGDegree;
			}

			if (empInfo.sUGYear.Equals("0"))
			{
				lblUGYear.Text = "none";
			}
			else
			{
				lblUGYear.Text = empInfo.sUGYear;
			}

			if (empInfo.sGSchool.Length == 0)
			{
				lblGSSchool.Text = "none";
			}
			else
			{
				lblGSSchool.Text = empInfo.sGSchool;
			}

			if (empInfo.sGSDegree.Length == 0)
			{
				lblGSDegree.Text = "none";
			}
			else
			{
				lblGSDegree.Text = empInfo.sGSDegree;
			}

			if (empInfo.sGSYear.Equals("0"))
			{
				lblGSYear.Text = "none";
			}
			else
			{
				lblGSYear.Text = empInfo.sGSYear;
			}

			if (empInfo.sPassportNo.Length == 0)
			{
				lblPassport.Text = "none";
			}
			else
			{
				lblPassport.Text = empInfo.sPassportNo;
			}

			if ((empInfo.sPassportExp.Length == 0) ||
				(empInfo.sPassportExp.Equals("none")))
			{
				lblExpDate.Text = "none";
			}
			else
			{
				this.sTempExpDate = empInfo.sPassportExp;
				this.sTempDate = this.sTempExpDate.Split('|');
				this.sTempMonth = setMonth(sTempDate[0]);
				lblExpDate.Text = this.sTempDate[1] + " " + this.sTempMonth + " " + this.sTempDate[2].Substring(0, 4);
			}

			if (empInfo.sValidVisa.Length == 0)
			{
				lblVisa.Text = "none";
			}
			else
			{
				lblVisa.Text = empInfo.sValidVisa;
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
			this.lbEditProfile.Click += new System.EventHandler(this.lbEditProfile_Click);
			this.lbChangePassword.Click += new System.EventHandler(this.lbChangePassword_Click);
			this.lbEditProfile2.Click += new System.EventHandler(this.lbEditProfile2_Click);
			this.blChangePassword2.Click += new System.EventHandler(this.blChangePassword2_Click);
			this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);

		}
		#endregion

		
		private void lbEditProfile_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/EditProfile");
		}

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/Menu");
		}

		private void lbEditProfile2_Click(object sender, System.EventArgs e)
		{
		    this.ActionForward("/EditProfile");
		}

		private void lbChangePassword_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/ChangePassword");
		}

		private void blChangePassword2_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/ChangePassword");
		}
	}
}

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
	/// Summary description for emp_edit.
	/// </summary>
	public class skills_editprofile : ViewController
	{
		public static string loginID;
		public DataRow row;
		private char ctempGender;
		private string sOffice;
		private int iTempIdx;
		private int iTempIdxMonth;
		private int iTempIdxDay;

		private string sTempNavMMM;
		private string sTempBdayMMM;
		private string sTempPassportExp;
		private string sTempOffice;
		
		private string sTempExpDate;
		private string[ ] sTempDate;
		private string sTempUpdateDate;

		bool boolReturn = false;

			

		protected System.Web.UI.WebControls.Label lblEmpID;
		protected System.Web.UI.WebControls.DropDownList dropOffice;
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.TextBox txtNickName;
		protected System.Web.UI.WebControls.TextBox txtHomeNum;
		protected System.Web.UI.WebControls.TextBox txtCellNum;
		protected System.Web.UI.WebControls.TextBox txtOtherEmail;
		protected System.Web.UI.WebControls.TextBox txtHomeAdd;
		protected System.Web.UI.WebControls.TextBox txtHomeCity;
		protected System.Web.UI.WebControls.TextBox txtUGSchool;
		protected System.Web.UI.WebControls.TextBox txtUGDegree;
		protected System.Web.UI.WebControls.TextBox txtUGYear;
		protected System.Web.UI.WebControls.TextBox txtGSSchool;
		protected System.Web.UI.WebControls.TextBox txtGSDegree;
		protected System.Web.UI.WebControls.TextBox txtGSYear;
		protected System.Web.UI.WebControls.TextBox txtPassportNum;
		protected System.Web.UI.WebControls.TextBox txtVisa;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.RadioButtonList radlstGender;
		protected System.Web.UI.WebControls.DropDownList dropNavMonth;
		protected System.Web.UI.WebControls.DropDownList dropTeamList;
		protected System.Web.UI.WebControls.DropDownList dropNavDD;
		protected System.Web.UI.WebControls.TextBox txtNavYYYY;
		protected System.Web.UI.WebControls.DropDownList dropBdayMonth;
		protected System.Web.UI.WebControls.DropDownList dropBdayDD;
		protected System.Web.UI.WebControls.TextBox txtBdayYYYY;
		protected System.Web.UI.WebControls.DropDownList dropPassportMonth;
		protected System.Web.UI.WebControls.DropDownList dropPassportDD;
		protected System.Web.UI.WebControls.TextBox txtPassportYYYY;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.LinkButton lbBack;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvFirstName;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvLastName;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPosition;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvNavMonth;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvNickName;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvHomeNum;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvCellNum;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvAddressSt;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvAddressCity;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvUGSchool;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvUGDegree;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvUGYear;
		protected System.Web.UI.WebControls.DropDownList dropSubTeamList;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenValue;
		//protected System.Web.UI.WebControls.DropDownList dropTeamList;
		protected System.Web.UI.WebControls.Label lblLoginID;

//		public static void CreateMessageAlert(System.Web.UI.Page senderPage, 
//			string alertMsg, string alertKey)
//		{
//			string strScript = "<script language=JavaScript>alert('" + 
//				alertMsg + "')</script>";
//			if (!(senderPage.IsStartupScriptRegistered(alertKey)))
//				senderPage.RegisterStartupScript(alertKey, strScript);
//		}



		private void setRow(DataRow row)
		{
			this.row = row;
		}
	
        //private string getString(string instring)
        //{
        //    return (this.row[instring].ToString());
        //}

		private string getOffice(string instring)
		{
			switch (instring)
			{
				case "MNL": sOffice = "Manila";
					break;
				case "SLC": sOffice = "Salt Lake City";
					break;
				case "MSP": sOffice = "Minneapolis";
					break;
				case "AUS": sOffice = "Austin";
					break;
				case "SYD": sOffice = "Sydney";
					break;
				case "Others": sOffice = "Others";
					break;
			}

			return(sOffice);
		}

		private int getMonth(string instring)
		{
			switch (instring)
			{
				case "JAN": return(1);
				case "FEB": return(2);
				case "MAR": return(3);
				case "APR": return(4);
				case "MAY": return(5);
				case "JUN": return(6);
				case "JUL": return(7);
				case "AUG": return(8);
				case "SEP": return(9);
				case "OCT": return(10);
				case "NOV": return(11);
				case "DEC": return(12);
				default: return(0);
			}
		}

		private string getMonthMMM(int iMonthNum)
		{
			switch (iMonthNum)
			{
				case 1: return("Jan");
				case 2: return("Feb");
				case 3: return("Mar");
				case 4: return("Apr");
				case 5: return("May");
				case 6: return("Jun");
				case 7: return("Jul");
				case 8: return("Aug");
				case 9: return("Sep");
				case 10: return("Oct");
				case 11: return("Nov");
			    case 12: return("Dec");
				default: return("Mon");
								  
			}
		}

		private string getOfficeString(string instring)
		{
			switch (instring)
			{
				case "Manila": return("MNL");
				case "Salt Lake City": return("SLC");
				case "Minneapolis": return("MSP");
				case "Austin": return("AUS");
				case "Sydney": return("SYD");
				case "Others": return("OTH");
				default: return("OTH");
			}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				string script = @"<script language=""javascript"" type=""text/javascript""><!--";
				script +="\n var lists = new Array();";

                if (((Employee)Session["User"]) == null)
                {
                    this.ActionForward("/default.aspx");
                    return;
                }

				Teams oTeams = new Teams(((Employee)Session["User"]).ToString());
				WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(
					System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);

				DataSet dset = webAppDataHndlr.QueryRequest(oTeams);
				if (dset == null)
				{
					SMFLibrary.MessageBox(this, "Failed Query. Please contact your system administrator.");
					//return teamsTable;
				}
				DataTable ds = dset.Tables[0];

				string tempTeam = "";
				string script2  = "";
				bool first = true;
				foreach (DataRow dbTeamRow in ds.Rows)
				{
					if( tempTeam == dbTeamRow["Teams"].ToString() )
					{
						script  += ",'" + dbTeamRow["SubTeam"].ToString() + "'";
						script2 += ",'" + dbTeamRow["SubTeam"].ToString() + "'";
					}
					else
					{
						if( !first ) 
						{
							script += ");";
							script2 += ");";
							script += script2;
							script2 = "";
						}
						script += "lists['" + dbTeamRow["Teams"].ToString() + "'] = new Array();";
						script += "lists['" + dbTeamRow["Teams"].ToString() + "'][0] = new Array('" + dbTeamRow["SubTeam"].ToString() + "'";
						script2 += "lists['" + dbTeamRow["Teams"].ToString() + "'][1] = new Array('" + dbTeamRow["SubTeam"].ToString() + "'";
						first = false;
					}

					tempTeam = dbTeamRow["Teams"].ToString();
				}

				script += ");";
				script2 += ");";
				script += script2;

				script += @"
					function changeList( box ) {
						list = lists[box.options[box.selectedIndex].value];
						emptyList( box.form.dropSubTeamList );
						fillList( box.form.dropSubTeamList, list );
					}
					function emptyList( box ) {
						while ( box.options.length ) box.options[0] = null;
					}
					function fillList( box, arr ) {
						for ( i = 0; i < arr[0].length; i++ ) {
							option = new Option( arr[0][i], arr[1][i] );
							box.options[box.length] = option;
						}
						box.selectedIndex=0;
					}
					//-->
					</script>";

				// javascript driven yeah
				if(!this.Page.IsClientScriptBlockRegistered("dropUpdateScript"))
					this.Page.RegisterClientScriptBlock("dropUpdateScript",script);
			}
			else
			{
			}
		}

		protected override void OnPreRender(EventArgs e)
		{
			Teams oTeams = new Teams("");
			oTeams.QueryUniqueOnly = true;
			WebAppDataHandler webAppDataHndlr = new WebAppDataHandler();

			DataSet dset = webAppDataHndlr.QueryRequest(oTeams);
			
			if (dset == null)
			{
				SMFLibrary.MessageBox(this, "Failed T_TEAMS Query. Please contact your system administrator.");
			}
			else
			{
				dropTeamList.Attributes.Add("onChange","changeList(this)");
				dropTeamList.DataSource = dset;
				dropTeamList.DataTextField = "Teams";
				dropTeamList.DataValueField = "Teams";
				dropTeamList.DataBind();

				btnSave.Attributes.Add("onClick","document.getElementById('HiddenValue').value = document.getElementById('dropSubTeamList').value;");
			}

			Employee empInfo = new Employee(((Employee) Session["User"]).sLoginID);
            //webAppDataHndlr = new WebAppDataHandler();

            //DataTable empInfoTable = new DataTable();
			

            //dset = webAppDataHndlr.QueryRequest(empInfo);
            //if (dset == null)
            //{
            //    SMFLibrary.MessageBox(this, "Failed Query. Please contact your system administrator.");
				
            //}
            //else
            //{
            //    this.setRow(dset.Tables[0].Rows[0]);
            //}

            if (empInfo == null)
            {
                SMFLibrary.MessageBox(this, "Failed Query. Please contact your system administrator.");
            }

			lblLoginID.Text = empInfo.sLoginID;
			lblEmpID.Text = empInfo.sEmpID;
			
			iTempIdx = dropOffice.Items.IndexOf(dropOffice.Items.FindByText(getOffice(empInfo.sOfc)));
			dropOffice.Items[iTempIdx].Selected = true;

			txtFirstName.Text = empInfo.sFirstName;
			txtLastName.Text = empInfo.sLastName;
			dropTeamList.SelectedItem.Selected = false;
			iTempIdx = dropTeamList.Items.IndexOf(dropTeamList.Items.FindByText(empInfo.sEmpPosition));
			if (iTempIdx < 0 ) iTempIdx = 0;
			dropTeamList.Items[iTempIdx].Selected = true;

			txtNickName.Text = empInfo.sNickName;
			ctempGender = char.Parse(empInfo.sGender.ToUpper());

			if (ctempGender == 'M')
			{
				radlstGender.Items[0].Selected = true;
			}
			else
				if (ctempGender == 'F')
			{
				radlstGender.Items[1].Selected = true;
			}

			txtHomeNum.Text = empInfo.sHomeTel;
			txtCellNum.Text = empInfo.sCellNo;
			txtOtherEmail.Text = empInfo.sOtherEmail;
			txtHomeAdd.Text = empInfo.sAddressStreet;
			txtHomeCity.Text = empInfo.sAddressCity;
			txtUGSchool.Text = empInfo.sUGSchool;
			txtUGDegree.Text = empInfo.sUGDegree;
			txtUGYear.Text = empInfo.sUGYear;
			txtGSSchool.Text = empInfo.sGSchool;
			txtGSDegree.Text = empInfo.sGSDegree;

			if (!empInfo.sGSYear.Equals("0"))
			{
				txtGSYear.Text = empInfo.sGSYear;
			}
			txtPassportNum.Text = empInfo.sPassportNo;
			txtVisa.Text = empInfo.sValidVisa;

			//dropNavMonth.SelectedItem.Selected = false;
			//iTempIdx = Convert.ToInt32(empInfo.sNavMMM"));
			if( empInfo.sNavMMM != "" && empInfo.sNavMMM != null)
			{
				//iTempIdx = getMonth(empInfo.sNavMMM").ToUpper());
				iTempIdx = Convert.ToInt32(empInfo.sNavMMM);
			}
			else
			{
				iTempIdx = 0;
			}
			dropNavMonth.SelectedItem.Selected = false;
			dropNavMonth.Items[iTempIdx].Selected = true;
			if (empInfo.sNavDD.Trim() != null)
			{
				iTempIdx = Int32.Parse(empInfo.sNavDD);
			}
			else
			{
				iTempIdx = 0;
			}
			dropNavDD.Items[iTempIdx].Selected = true;

			if (empInfo.sNavYYYY.Equals("0"))
			{
				txtNavYYYY.Text = "YYYY";
			}
			else
			{
				txtNavYYYY.Text = empInfo.sNavYYYY;
			}
			
			//iTempIdx = Convert.ToInt32(empInfo.sBdayMMM"));
			if( empInfo.sBdayMMM != "" && empInfo.sBdayMMM != null)
			{
				//iTempIdx = getMonth(empInfo.sBdayMMM").ToUpper());
				iTempIdx = Convert.ToInt32(empInfo.sBdayMMM);
			}
			else
			{
				iTempIdx = 0;
			}
			dropBdayMonth.SelectedItem.Selected = false;
			dropBdayMonth.Items[iTempIdx].Selected = true;

			if (empInfo.sBdayDD.Trim() != null)
			{
				iTempIdx = Int32.Parse(empInfo.sBdayDD);
			}
			else
			{
				iTempIdx = 0;
			}
			dropBdayDD.SelectedItem.Selected = false;
			dropBdayDD.Items[iTempIdx].Selected = true;

			if (empInfo.sBdayYYYY.Equals("0"))
			{
				txtBdayYYYY.Text = "YYYY";
			}
			else
			{
				txtBdayYYYY.Text = empInfo.sBdayYYYY;
			}

//			iTempIdx = getMonth(empInfo.sBdayMMM").ToUpper());
//			dropBdayMonth.Items[iTempIdx].Selected = true;
//			if (empInfo.sBdayDD").Trim() != null)
//			{
//				iTempIdx = Int32.Parse(empInfo.sBdayDD"));
//			}
//			else
//			{
//				iTempIdx = 0;
//			}
//			dropBdayDD.Items[iTempIdx].Selected = true;
//
//			if (empInfo.sBdayYYYY").Equals("0"))
//			{
//				txtBdayYYYY.Text = "YYYY";
//			}
//			else
//			{
//				txtBdayYYYY.Text = empInfo.sBdayYYYY;
//			}

			if ((empInfo.sPassportExp.Length == 0) ||
				 (empInfo.sPassportExp.Equals("none")))
			{
				dropPassportMonth.Items[0].Selected = true;
				dropPassportDD.Items[0].Selected = true;
				txtPassportYYYY.Text = "YYYY";
			}
			else
			{
				sTempExpDate = empInfo.sPassportExp;
				sTempDate = sTempExpDate.Split('|');
				
				iTempIdx = getMonth(sTempDate[0].ToUpper());
				dropPassportMonth.Items[iTempIdx].Selected = true;
							
				iTempIdx = Int32.Parse(sTempDate[1]);
				dropPassportDD.Items[iTempIdx].Selected = true;

				txtPassportYYYY.Text = sTempDate[2];
								
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
			this.dropTeamList.SelectedIndexChanged += new System.EventHandler(this.dropTeamList_SelectedIndexChanged);
			this.dropNavMonth.SelectedIndexChanged += new System.EventHandler(this.dropNavMonth_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.lbBack.Click += new System.EventHandler(this.lbBack_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			//			if (txtFirstName.Text.Trim() == null)
			//			{
			//				string alertmessage = "Thank You for visiting DotNetSpider.com";
			//				emp_edit.CreateMessageAlert(this,alertmessage,"alertKey");
			//			}

//			if (this.txtFirstName.Text.Length == 0)
//			{
//				this.lblError.Text = "";
//				this.lblError.Text = "Please complete the information. Enter your First Name...";
//			}
//			else if (txtLastName.Text.Length == 0)
//			{
//				this.lblError.Text = "";
//				this.lblError.Text = "Please complete the information. Enter your Last Name...";
//			}
//			else if (txtTeam.Text.Length == 0)
//			{
//				this.lblError.Text = "";
//				this.lblError.Text = "Please complete the information. Enter your Team/Role...";
//			}
//			else if (this.dropNavMonth.SelectedIndex.Equals(0) ||
//				this.dropNavDD.SelectedItem.Text.Equals("Day") ||
//				this.txtNavYYYY.Text.Length == 0)
//			{
//				lblError.Text = "";
//				lblError.Text = "Please complete the information. Enter a Valid Navitaire Start Date...";
//			}
//			else if (this.txtNickName.Text.Length == 0)
//			{
//				lblError.Text = "";
//				lblError.Text = "Please complete the information. Enter your Nick name...";
//			}
//			else if (this.txtHomeNum.Text.Length == 0)
//			{
//				lblError.Text = "";
//				lblError.Text = "Please complete the information. Enter your Home number...";
//			}
//			else if (this.txtCellNum.Text.Length == 0)
//			{
//				lblError.Text = "";
//				lblError.Text = "Please complete the information. Enter your Cell number...";
//			}
//			else if (this.txtHomeAdd.Text.Length == 0)
//			{
//				lblError.Text = "";
//				lblError.Text = "Please complete the information. Enter your Home address...";
//			}
//			else if (this.txtHomeCity.Text.Length == 0)
//			{
//				lblError.Text = "";
//				lblError.Text = "Please complete the information. Enter your Home city...";
//			}
//			else if (this.txtUGSchool.Text.Length == 0)
//			{
//				lblError.Text = "";
//				lblError.Text = "Please complete the information. Enter your Undergraduate School...";
//			}
//			else if (this.txtUGDegree.Text.Length == 0)
//			{
//				lblError.Text = "";
//				lblError.Text = "Please complete the information. Enter your Undergraduate Degree ...";
//			}
//			else if (this.txtUGYear.Text.Length == 0)
//			{
//				lblError.Text = "";
//				lblError.Text = "Please complete the information. Enter your Undergraduate Year...";
//			}
//			else				
//			{

				//sTempNavMMM = getMonthMMM(this.dropNavMonth.SelectedIndex);
				//sTempBdayMMM = getMonthMMM(this.dropBdayMonth.SelectedIndex);
				sTempNavMMM = this.dropNavMonth.SelectedValue;
				sTempBdayMMM = this.dropBdayMonth.SelectedValue;
				sTempPassportExp = getMonthMMM(this.dropPassportMonth.SelectedIndex) + '|' +
					this.dropPassportDD.SelectedIndex.ToString() + '|' +
					this.txtPassportYYYY.Text;
				sTempOffice = getOfficeString(this.dropOffice.SelectedValue.ToString());
				sTempUpdateDate = System.DateTime.Now.ToShortDateString();

			    iTempIdxMonth = this.dropPassportMonth.SelectedIndex;
			    iTempIdxDay = this.dropPassportDD.SelectedIndex;

				if (this.txtGSYear.Text.Length == 0)
				{
					this.txtGSYear.Text = "0";
				}

				if (iTempIdxMonth == 0 || iTempIdxDay == 0)
				{
					sTempPassportExp = "none";
				}

				//this.dropSubTeamList.SelectedValue = HiddenValue.Value;
			
				WebAppDataHandler webAppDataHndlr = new WebAppDataHandler();
				
				Employee empInfo = new Employee(this.lblLoginID.Text,
					this.lblEmpID.Text,
					(((Employee) Session["User"]).sEmpPswd),
					this.txtLastName.Text,
					this.txtFirstName.Text,
					this.dropTeamList.SelectedValue.ToString(),
					this.HiddenValue.Value.ToString(),
					this.txtNavYYYY.Text,
					sTempNavMMM,
					this.dropNavDD.SelectedIndex.ToString(),
					this.txtNickName.Text,
					this.radlstGender.SelectedValue,
					this.txtUGSchool.Text,
					this.txtUGDegree.Text,
					this.txtUGYear.Text,
					this.txtGSSchool.Text,
					this.txtGSDegree.Text,
					this.txtGSYear.Text,
					this.txtPassportNum.Text,
					sTempPassportExp,
					this.txtVisa.Text,
					this.txtBdayYYYY.Text,
					sTempBdayMMM,
					this.dropBdayDD.SelectedIndex.ToString(),
					this.txtCellNum.Text,
					this.txtHomeNum.Text,
					this.txtOtherEmail.Text,
					this.txtHomeAdd.Text,
					this.txtHomeCity.Text,
					"",
					"",
					sTempOffice,
					"",
					"",
					this.lblLoginID.Text,
					sTempUpdateDate);


				empInfo.Update();

				boolReturn = webAppDataHndlr.NonQueryRequest(empInfo);

				if (boolReturn == true)
				{
					this.ActionForward("/MyProfile");
				}
//			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/MyProfile");
		}

		private void lbBack_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/MyProfile");
		}

		private void txtTeam_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dropTeamList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}

		private void dropNavMonth_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		

			
	}
}

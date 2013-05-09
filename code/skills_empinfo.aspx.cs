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
using System.Text;

namespace SmfRewriteProject
{
	/// <summary>
	/// Summary description for SMFNewUser.
	/// </summary>
	public class skills_empinfo : ViewController
	{
		protected System.Web.UI.HtmlControls.HtmlForm frmEmpInfo;
		protected System.Web.UI.WebControls.RadioButtonList RadioButtonList1;
		protected System.Web.UI.WebControls.TextBox txtEmpID;
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.DropDownList ddlOffice;
		protected System.Web.UI.WebControls.DropDownList ddlNavMonth;
		protected System.Web.UI.WebControls.DropDownList ddlNavDay;
		protected System.Web.UI.WebControls.TextBox txtNavYear;
		protected System.Web.UI.WebControls.TextBox txtBdayYear;
		protected System.Web.UI.WebControls.DropDownList ddlBdayDay;
		protected System.Web.UI.WebControls.DropDownList ddlBdayMonth;
		protected System.Web.UI.WebControls.TextBox txtNickName;
		protected System.Web.UI.WebControls.TextBox txtHomeNum;
		protected System.Web.UI.WebControls.TextBox txtCellNum;
		protected System.Web.UI.WebControls.TextBox txtOtherEmail;
		protected System.Web.UI.WebControls.TextBox txtAddressSt;
		protected System.Web.UI.WebControls.TextBox txtAddressCity;
		protected System.Web.UI.WebControls.TextBox txtUGSchool;
		protected System.Web.UI.WebControls.TextBox txtUGDegree;
		protected System.Web.UI.WebControls.TextBox txtUGYear;
		protected System.Web.UI.WebControls.TextBox txtGSchool;
		protected System.Web.UI.WebControls.TextBox txtGDegree;
		protected System.Web.UI.WebControls.TextBox txtGYear;
		protected System.Web.UI.WebControls.TextBox txtPassportNum;
		protected System.Web.UI.WebControls.DropDownList ddlPassportMonth;
		protected System.Web.UI.WebControls.DropDownList ddlPassportDay;
		protected System.Web.UI.WebControls.TextBox txtPassportYear;
		protected System.Web.UI.WebControls.TextBox txtVisa;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.TextBox txtRePassword;
		protected System.Web.UI.WebControls.TextBox txtLoginID;
		protected System.Web.UI.WebControls.RegularExpressionValidator revLoginID;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvLoginID;
		protected System.Web.UI.WebControls.RegularExpressionValidator revEmpID;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvEmpID;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPassword;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPassword;
		protected System.Web.UI.WebControls.CompareValidator cvRePassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvRePassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvFirstName;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvLastName;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPosition;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvNickName;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvHomeNum;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvCellNum;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvAddressSt;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvAddressCity;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvUGSchool;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvUGDegree;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvUGYear;
		protected System.Web.UI.WebControls.Label lblBirthdayError;
		protected System.Web.UI.WebControls.Label lblStartDateError;
		protected System.Web.UI.WebControls.DropDownList dropTeamList;
		protected System.Web.UI.WebControls.DropDownList dropSubTeamList;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenValue;
		protected System.Web.UI.WebControls.RegularExpressionValidator revUGYear;
		//protected System.Web.UI.WebControls.TextBox txtPosition;

		protected override void OnPreRender(EventArgs e)
		{
			Teams oTeams = new Teams("");
			oTeams.QueryUniqueOnly = true;
			WebAppDataHandler webAppDataHndlr = new WebAppDataHandler();

			DataSet dset = webAppDataHndlr.QueryRequest(oTeams);
			
			if (dset == null)
			{
				SMFLibrary.MessageBox(this, "Failed T_TEAMS Query. Please contact your system administrator.");
                this.ActionForward("/default.aspx");
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
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			string script = @"<script language=""javascript"" type=""text/javascript""><!--";
			script +="\n var lists = new Array();";

			Teams oTeams = new Teams("");
			WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(
				System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);

			DataSet dset = webAppDataHndlr.QueryRequest(oTeams);
			if (dset == null)
			{
				SMFLibrary.MessageBox(this, "Failed T_TEAMS Query. Please contact your system administrator.");
                this.ActionForward("/default.aspx");
			}
			else
			{
				if(!Page.IsPostBack)
				{
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
			this.txtRePassword.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void RadioButtonList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void TextBox1_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.ActionForward("/Start");
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.lblStartDateError.Visible = false;
				this.lblBirthdayError.Visible = false;
			
				DateTime tempDateTime = DateTime.Parse(this.ddlNavMonth.SelectedValue.ToString() + "/" + this.ddlNavDay.SelectedValue.ToString() + "/" + this.txtNavYear.Text);
			
				try
				{
					tempDateTime = DateTime.Parse(this.ddlBdayMonth.SelectedValue.ToString() + "/" + this.ddlBdayDay.SelectedValue.ToString() + "/" + this.txtBdayYear.Text);
					string tempLoginID = this.txtLoginID.Text; 
					string tempPassword = this.txtPassword.Text;
					FE_Symmetric feService = new FE_Symmetric();
										
					WebAppDataHandler dhSMF = new WebAppDataHandler(
						System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
					Employee emp = new Employee(this.txtLoginID.Text, 
						this.txtEmpID.Text,
						feService.EncryptData("", this.txtPassword.Text),
						this.txtLastName.Text,
						this.txtFirstName.Text, 
						this.dropTeamList.SelectedValue.ToString(),
						this.HiddenValue.Value.ToString(),
						this.txtNavYear.Text,
						this.ddlNavMonth.SelectedValue.ToString(),
						this.ddlNavDay.SelectedValue.ToString(),
						this.txtNickName.Text,
						this.RadioButtonList1.SelectedValue.ToString(),
						this.txtUGSchool.Text,
						this.txtUGDegree.Text,
						this.txtUGYear.Text,
						this.txtGSchool.Text,
						this.txtGDegree.Text,
						this.txtGYear.Text,
						this.txtPassportNum.Text,
						this.ddlPassportMonth.SelectedValue.ToString() + "|" + this.ddlPassportDay.SelectedValue.ToString() + "|" + this.txtPassportYear.Text,
						this.txtVisa.Text,
						this.txtBdayYear.Text,
						this.ddlBdayMonth.SelectedValue.ToString(),
						this.ddlBdayDay.SelectedValue.ToString(),
						this.txtCellNum.Text,
						this.txtHomeNum.Text,
						this.txtOtherEmail.Text,
						this.txtAddressSt.Text,
						this.txtAddressCity.Text,
						"A",
						"O",
						this.ddlOffice.SelectedValue.ToString(),
						"",
						"",
						this.txtLoginID.Text,
						DateTime.Now.ToShortDateString());
					emp.Add();
					dhSMF.NonQueryRequest(emp);

					this.Login(tempLoginID, tempPassword);
					if(!(this.currentUser == null))
					{
						this.ActionForward("/Menu");
					}
				}
				catch (FormatException fe)
				{
					this.lblBirthdayError.Visible = true;
                    SMFLibrary.MessageBox(this,fe.Message);
				}
			}
			catch (FormatException fe)
			{
				this.lblStartDateError.Visible = true;
                SMFLibrary.MessageBox(this,fe.Message);
			}
		}

		private void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}

	}
}

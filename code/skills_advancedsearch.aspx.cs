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
	/// Summary description for skills_advancedsearch.
	/// </summary>
	public partial class skills_advancedsearch : ViewController
	{
   
      private DataTable employeeTable;

		protected void Page_Load(object sender, System.EventArgs e)
		{
         this.txtTransaction.Visible = true;
         this.txtTransaction.Width = 0;
         this.txtTransaction.Height = 0;

         if( this.IsPostBack )
         {
            employeeTable = (DataTable) Session["EmployeesSearch"];
            if (this.Panel1.Visible)
            {
               SMFLibrary.SetFocus(this, this.DataGrid1);
            }
         }
         else
         {
            SMFLibrary.SetFocus(this, this.TextBox1);            
         }
		}

//      protected override void OnPreRender(EventArgs e)
//      {
//         base.OnPreRender (e);
//         if (employeeTable != null)
//         {
//            if (employeeTable.Rows.Count > 0)
//            {
//               int iPageButtonCount = employeeTable.Rows.Count / DataGrid1.PageSize;
//               if (employeeTable.Rows.Count % DataGrid1.PageSize > 0) 
//                  iPageButtonCount++;				
//               DataGrid1.PagerStyle.PageButtonCount = iPageButtonCount;
//            }
//         }
//      }

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
         this.DataGrid1.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemCreated);
         this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
         this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
         this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);

      }
		#endregion

      protected void homelink_Click(object sender, System.EventArgs e)
      {
         Server.Transfer(System.Configuration.ConfigurationSettings.AppSettings["/Menu"]);
      }


      protected void Button1_Click(object sender, System.EventArgs e)
      {
         if (this.TextBox1.Text.Trim().Length > 0)
         {
            this.Panel1.Visible = true;
            this.DataGrid1.Visible = true;
            DataGrid1.CurrentPageIndex = 0;
            GenerateDataGrid();
            UpdateDataGrid();
            this.txtSearch.Text = this.TextBox1.Text;
            this.txtOption.Text = this.RadioButton1.Checked.ToString();
            SMFLibrary.SetFocus(this, this.DataGrid1);
         }
         else
         {
            this.Panel1.Visible = false;
            this.DataGrid1.Visible = false;
            DataGrid1.CurrentPageIndex = 0;
         }
      }

      private void RetrieveData(DataTable employeeTable)
      {         
         if (this.TextBox1.Text.Trim().Length > 0)
         {
            WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(
               System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
            EmployeeList employeeList = new EmployeeList();

            if (((Employee)Session["User"]).sEmpPermission == "A")
            {
               employeeList.EmployeeRetrieve(this.TextBox1.Text, "All");
            }
            else
            {
               employeeList.EmployeeRetrieve(this.TextBox1.Text, ((Employee)Session["User"]).sOfc);
            }

            DataSet dset = webAppDataHndlr.QueryRequest(employeeList);
            if (dset == null)
            {
               SMFLibrary.MessageBox(this, "Failed Query. Please contact your system administrator.");
               this.ActionForward("/default.aspx");
               return;
            }

            DataTable ds = dset.Tables[0];            
            int i = 1;

            foreach (DataRow dbSkillRow in ds.Rows)
            {
               generateDataRow(dbSkillRow, ref i);
            }
         }
      }

      private void generateDataRow(DataRow dbSkillRow, ref int i)
      {
         DataRow dr;

         if (validateDataRow(dbSkillRow, this.TextBox1.Text, this.RadioButton1.Checked))
         {
            dr = employeeTable.NewRow();
            dr["Number"] = i.ToString();
            dr["LoginID"] = dbSkillRow["sLoginID"].ToString();
            dr["EmployeeName"] = dbSkillRow["sLastName"].ToString().Trim() + ", " + dbSkillRow["sFirstName"].ToString().Trim();
            if (dbSkillRow["sEmpStat"].ToString().Trim().ToUpper() == "A")
            {
               dr["Status"] = "Active";
            }
            else
            {
               dr["Status"] = "Inactive";
            }
            if (dbSkillRow["sEmpPermission"].ToString().Trim().ToUpper() == "O")
            {
               dr["Access"] = "Limited";
            }
            else if (dbSkillRow["sEmpPermission"].ToString().Trim().ToUpper() == "S")
            {
               dr["Access"] = "Supervisor";
            }
            else
            {
               dr["Access"] = "Admin";
            }

            employeeTable.Rows.Add(dr);
            i++;
         }
      }

      private bool validateDataRow(DataRow dbSkillRow, 
         string SearchString, bool AnySubstringOfName)
      {
         bool retVal = false;
         string tempString = SearchString;
         string [] s = tempString.Split(',');
         string FirstName = " " + dbSkillRow["sLastName"].ToString().Trim().ToUpper() + " ";
         string LastName = " " + dbSkillRow["sFirstName"].ToString().Trim().ToUpper() + " ";
         string foundString = Session["FoundString"].ToString();

         if (SearchString.Trim().Length > 0)
         {
            foreach(string t in s)
            {
               if (t.Trim().Length > 0)
               {
                  bool InName = true;
                  tempString = t.ToUpper().Trim();
                  string [] s1 = tempString.Split(' ');
                  foreach(string t1 in s1)
                  {
                     if (t1.Trim().Length > 0)
                     {
                        tempString = t1.Trim();
                        if (!AnySubstringOfName)
                        {
                           tempString = " " + tempString + " ";
                        }

                        if ((FirstName.IndexOf(tempString) == -1) &&
                           (LastName.IndexOf(tempString) == -1))
                        {
                           InName = false;
                        }
                     }
                  }

                  if (InName)
                  {
                     string [] sFound = foundString.Split(',');
                     bool StringInLabel = false;

                     foreach(string sF in sFound)
                     {
                        if (sF.Trim() == t.Trim())
                        {
                           StringInLabel = true;
                           break;
                        }
                     }

                     if (!StringInLabel)
                     {
                        if (!foundString.Trim().Equals(String.Empty))
                        {
                           foundString += ", ";
                        }
                        foundString += t.Trim();
                     }

                     retVal = true;
                  }
               }
            }
         }

         Session["FoundString"] = foundString;

         return retVal;
      }

      private void GenerateDataGrid()
      {
         if (this.TextBox1.Text.Trim().Length > 0)
         {
            Session["FoundString"] = "";
            employeeTable = new DataTable();
            employeeTable.Columns.Add(new DataColumn("Number", typeof(string)));
            employeeTable.Columns.Add(new DataColumn("LoginID", typeof(string)));
            employeeTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
            employeeTable.Columns.Add(new DataColumn("Status", typeof(string)));
            employeeTable.Columns.Add(new DataColumn("Access", typeof(string)));

            DataColumn[] keys = new DataColumn[1];
            keys[0] = employeeTable.Columns["LoginID"];
            employeeTable.PrimaryKey = keys;

            RetrieveData(employeeTable);

            Session["EmployeesSearch"] = employeeTable;
         }
      }

      private void UpdateDataGrid()
      {
         if (employeeTable != null)
         {
            this.DataGrid1.DataSource = employeeTable;
            this.DataGrid1.DataBind();
            this.lblQueryDetail.Text = UpdateLabel();
         }
      }

      private string UpdateLabel()
      {
         string resultStr = "";
         string foundString = Session["FoundString"].ToString();

         if (!foundString.Trim().Equals(String.Empty))
         {            
            string startNum = this.DataGrid1.Items[0].Cells[0].Text;
            string endNum = this.DataGrid1.Items[this.DataGrid1.Items.Count - 1].Cells[0].Text;
            resultStr = "Results " + startNum.Trim() + "-" + endNum.Trim() + " of ";
            resultStr += this.employeeTable.Rows.Count.ToString();
            resultStr += " employee names containing: ";
            resultStr += "'"+ foundString + "'";
         }
         else
         {
            resultStr = "No records found.";
         }

         return resultStr;
      }

      private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
      {
         DataGrid1.CurrentPageIndex=e.NewPageIndex;
         UpdateDataGrid();
      }

      private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
      {

         if (e.CommandName == "View")
         {
            string transType = this.txtTransaction.Text;
            if (transType != "")
            {
               updateEmployeeGrid();
            }
         }

         if (e.CommandName == "Edit")
         {
            string transType = this.txtTransaction.Text;
            string  login_id = e.Item.Cells[1].Text;

            if (transType == "Save")
            {
               SMFLibrary.MessageBox(this, "Saved employee information.");
               updateEmployeeGrid();
            }

            if (transType == "Delete")
            {
               updateEmployeeGrid();
            }
         }

         this.txtTransaction.Text = "";
      }

      private void updateEmployeeGrid()
      {
         string SearchTextBox = this.TextBox1.Text;
         string OptionRadioButton = this.RadioButton1.Checked.ToString();

         this.TextBox1.Text = this.txtSearch.Text;
         if (this.txtOption.Text.Trim().ToUpper() == "TRUE")
         {
            this.RadioButton1.Checked = true;
            this.RadioButton2.Checked = false;
         }
         else
         {
            this.RadioButton1.Checked = false;
            this.RadioButton2.Checked = true;
         }

         int curPage = DataGrid1.CurrentPageIndex;
         GenerateDataGrid();
         this.DataGrid1.DataSource = employeeTable;
         DataGrid1.CurrentPageIndex = 0;
         this.DataGrid1.DataBind();
         if ((DataGrid1.PageCount - 1) >= curPage)
         {
            DataGrid1.CurrentPageIndex = curPage;
         }
         else
         {
            DataGrid1.CurrentPageIndex = DataGrid1.PageCount - 1;
         }
         UpdateDataGrid();

         this.TextBox1.Text = SearchTextBox;
         if (OptionRadioButton.Trim().ToUpper() == "TRUE")
         {
            this.RadioButton1.Checked = true;
            this.RadioButton2.Checked = false;
         }
         else
         {
            this.RadioButton1.Checked = false;
            this.RadioButton2.Checked = true;
         }
      }

      private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
         if ((e.Item.ItemType == ListItemType.Item) ||
            (e.Item.ItemType == ListItemType.AlternatingItem))
         {
            System.Web.UI.WebControls.LinkButton tempLink = 
               (System.Web.UI.WebControls.LinkButton) e.Item.Cells[5].FindControl("ViewSummary"); 
            tempLink.ControlStyle.ForeColor = Color.FromName(System.Drawing.KnownColor.Blue.ToString());

            String javascript = "window.showModalDialog('window_" + System.Configuration.ConfigurationSettings.AppSettings["/IndividualSummary"] + "?sLoginID=" +
                                 e.Item.Cells[1].Text + "',window,'scroll:yes;edge:sunken;status:no;resizable:no;help:no;center:yes;dialogHeight:700px;dialogWidth:763px');";
            tempLink.Attributes.Add("onclick", javascript);

            tempLink = 
               (System.Web.UI.WebControls.LinkButton) e.Item.Cells[5].FindControl("EditProfile"); 
            tempLink.ControlStyle.ForeColor = Color.FromName(System.Drawing.KnownColor.Blue.ToString());

            string dHeight = "196px";
//            if ( (((Employee)Session["User"]).getEmpPermission() == "A") &&
//               (e.Item.Cells[2].Text.Length > 30) )
//            {
//               dHeight = "209px";
//            }
//            else if (((Employee)Session["User"]).getEmpPermission() == "A")
//            {
//               dHeight = "206px";
//            }
//            else if (e.Item.Cells[2].Text.Length > 30)
//            {
//               dHeight = "199px";
//            }
            if (e.Item.Cells[2].Text.Length > 30)
            {
               dHeight = "199px";
            }

            javascript = "ShowDialog('" + e.Item.Cells[1].Text + "', '" + dHeight + "')";
            tempLink.Attributes.Add("onclick", javascript);

         }
      }

      private void DataGrid1_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
         if (employeeTable != null)
         {
            if (employeeTable.Rows.Count > 0)
            {
               int iPageButtonCount = employeeTable.Rows.Count / DataGrid1.PageSize;
               if (employeeTable.Rows.Count % DataGrid1.PageSize > 0) 
                  iPageButtonCount++;				
               DataGrid1.PagerStyle.PageButtonCount = iPageButtonCount;
            }
         }
         if (e.Item.ItemType == ListItemType.Pager)
         {
            System.Web.UI.WebControls.Label PageLabel = new Label();
            PageLabel.Text = "Page ";
            e.Item.Cells[0].Controls.AddAt(0, PageLabel);
            //            foreach (Control cntrl in e.Item.Cells[0].Controls)
            //            {
            //               if (cntrl.GetType().ToString() == "System.Web.UI.WebControls.DataGridLinkButton")
            //               {
            //                  if (((System.Web.UI.WebControls.LinkButton)cntrl).Text == "1")
            //                  {
            //                     ((System.Web.UI.WebControls.LinkButton)cntrl).Text = "Page " + 
            //                        ((System.Web.UI.WebControls.LinkButton)cntrl).Text;
            //                  }
            //               }
            //               else if (cntrl.GetType().ToString() == "System.Web.UI.WebControls.Label")
            //               {
            //                  if (((System.Web.UI.WebControls.Label)cntrl).Text == "1")
            //                  {
            //                     ((System.Web.UI.WebControls.Label)cntrl).Text = "Page " + 
            //                        ((System.Web.UI.WebControls.Label)cntrl).Text;
            //                  }
            //               }
            //            }
         }      
      }
	}
}

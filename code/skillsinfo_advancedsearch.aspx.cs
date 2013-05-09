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
	/// Summary description for skillsinfo_advancedsearch.
	/// </summary>
	public partial class skillsinfo_advancedsearch : ViewController
	{

      private DataTable employeeTable;

		protected void Page_Load(object sender, System.EventArgs e)
		{
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
            RetrieveOffice();
            SMFLibrary.SetFocus(this, this.TextBox1);
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
         this.DataGrid1.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemCreated);
         this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
         this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);

      }
		#endregion

      private void RetrieveOffice()
      {

         if (((Employee)Session["User"]).sEmpPermission == "A")
         {
            WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(
               System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
            EmployeeList employeeList = new EmployeeList();
            employeeList.OfficeRetrieve();

            DataSet dset = webAppDataHndlr.QueryRequest(employeeList);
            if (dset == null)
            {
               SMFLibrary.MessageBox(this, "Failed Query. Please contact your system administrator.");
               this.ActionForward("/default.aspx");
               return;
            }

            DataTable ds = dset.Tables[0];

            this.drOffice.Items.Add("All");
            this.drOffice.Items[0].Selected = true;
            foreach (DataRow dbSkillRow in ds.Rows)
            {
               this.drOffice.Items.Add(dbSkillRow["sOfc"].ToString());
            }
         }
         else
         {
            this.drOffice.Items.Add(((Employee)Session["User"]).sOfc);
            this.drOffice.Items[0].Selected = true;
            this.drOffice.Enabled = false;
         }
      }

      protected void Button1_Click(object sender, System.EventArgs e)
      {
         if (this.TextBox1.Text.Trim().Length > 0 ||
             this.TextBox2.Text.Trim().Length > 0)
         {
            this.Panel1.Visible = true;
            this.DataGrid1.Visible = true;
            DataGrid1.CurrentPageIndex = 0;
            GenerateDataGrid();
            UpdateDataGrid();
         }
         else
         {
            this.Panel1.Visible = false;
            this.DataGrid1.Visible = false;
            DataGrid1.CurrentPageIndex = 0;
         }      
      }

      protected void homelink_Click(object sender, System.EventArgs e)
      {
         Server.Transfer(System.Configuration.ConfigurationSettings.AppSettings["/Menu"]);      
      }

      private void RetrieveData()
      {         
         if (this.TextBox1.Text.Trim().Length > 0 ||
             this.TextBox2.Text.Trim().Length > 0)
         {            
            if (this.DropDownList1.SelectedValue.ToUpper().Trim() != "NONE")
            {
               WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(
                  System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
               EmployeeList employeeList = new EmployeeList();

               employeeList.EmployeeSkillRetrieve(this.TextBox1.Text, 
                  this.TextBox2.Text, this.DropDownList1.SelectedItem.Text, this.drOffice.SelectedItem.Text, this.DropDownList2.SelectedItem.Text);
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
            else // No Skills
            {
               processNoSkill();
            }
         }
      }

      private void retrieveTechSkills(ref string techSkillSearchString)
      {
         WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(
            System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
                  
         if (this.TextBox1.Text.Trim().Length > 0)
         {
            TechnicalSkills techSkills = new TechnicalSkills(((Employee)Session["User"]).ToString());
            DataSet skillDSet = webAppDataHndlr.QueryRequest(techSkills);
            if (skillDSet == null)
            {
               SMFLibrary.MessageBox(this, "Failed Query. Please contact your system administrator.");
               return;
            }

            string[] s = this.TextBox1.Text.Split(',');
            string str = " ";
            foreach (string t in s)
            {
               str += t + " ";
            }

            DataTable dsSkill = skillDSet.Tables[0];

            foreach (DataRow dbSkillRow in dsSkill.Rows)
            {
               if (searchSkills(str, dbSkillRow["sSkill"].ToString()))
               {
                  if (!techSkillSearchString.Trim().Equals(String.Empty))
                  {
                     techSkillSearchString += " , ";
                  }
                  techSkillSearchString += dbSkillRow["sSkill"].ToString();
               }
            }
         }
      }

      private void retrieveProdSkills(ref string prodSkillSearchString)
      {
         WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(
            System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);

         if (this.TextBox2.Text.Trim().Length > 0)
         {
            ProductSkills prodSkills = new ProductSkills(((Employee)Session["User"]).ToString());
            DataSet prodSkillDSet = webAppDataHndlr.QueryRequest(prodSkills);
            if (prodSkillDSet == null)
            {
               SMFLibrary.MessageBox(this, "Failed Query. Please contact your system administrator.");
               return;
            }

            string[] s = this.TextBox2.Text.Split(',');
            string str = " ";
            foreach (string t in s)
            {
               str += t + " ";
            }

            DataTable dsSkill = prodSkillDSet.Tables[0];

            foreach (DataRow dbSkillRow in dsSkill.Rows)
            {
               if (!searchSkills(prodSkillSearchString, dbSkillRow["sSkillType"].ToString()) ||
                   prodSkillSearchString.Trim().Equals(String.Empty))
               {
                  if (searchSkills(str, dbSkillRow["sSkillType"].ToString()))
                  {
                     if (!prodSkillSearchString.Trim().Equals(String.Empty))
                     {
                        prodSkillSearchString += " , ";
                     }
                     prodSkillSearchString += dbSkillRow["sSkillType"].ToString();
                  }
               }
            }
         }
      }

      private void findInsertPointEmployeeTable(DataTable employeesNoSkillTable, 
                                                DataRow dbSkillRow, ref int insertPoint)
      {
         DataRowCollection rc;
         bool foundInsertPoint = false;
         int i;

         if (employeesNoSkillTable != null)
         {
            rc = employeesNoSkillTable.Rows;
            for (i = insertPoint; i < rc.Count && !foundInsertPoint; i++)
            {
               DataRow thisRow = rc[i];
               string currentName = thisRow["sLastName"].ToString().Trim().ToUpper() + ", " + thisRow["sFirstName"].ToString().Trim().ToUpper();
               string nameToInsert = dbSkillRow["sLastName"].ToString().Trim().ToUpper() + ", " + dbSkillRow["sFirstName"].ToString().Trim().ToUpper();
               if (nameToInsert.CompareTo(currentName) <= 0 )
               {
                  foundInsertPoint = true;
                  insertPoint = i;
               }
            }            

            if (!foundInsertPoint)
            {
               insertPoint = rc.Count - 1;
            }
         }
      }

      private void retrieveEmployeesWithNoSkills(ref DataTable employeesNoSkillTable, 
         string techSkillSearchString,
         string prodSkillSearchString)
      {
         string[] techSkills = techSkillSearchString.Split(',');
         string[] prodSkills = prodSkillSearchString.Split(',');
         int i = 0;

         WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(
            System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
         EmployeeList employeeList = new EmployeeList();

         employeeList.EmployeeListNoSkillRetrieve(this.drOffice.SelectedItem.Text, 
            this.DropDownList2.SelectedItem.Text);

         DataSet dset = webAppDataHndlr.QueryRequest(employeeList);
         if (dset == null)
         {
            SMFLibrary.MessageBox(this, "Failed Query. Please contact your system administrator.");
            return;
         }

         DataTable ds = dset.Tables[0];
         DataRow dr;

         foreach (DataRow dbSkillRow in ds.Rows)
         {
            findInsertPointEmployeeTable(employeesNoSkillTable, dbSkillRow, ref i);
            foreach(string t in techSkills)
            {
               if (t.Trim().Length > 0)
               {
                  dr = employeesNoSkillTable.NewRow();
                  dr["sLoginID"] = dbSkillRow["sLoginID"].ToString();
                  dr["sLastName"] = dbSkillRow["sLastName"].ToString().Trim();
                  dr["sFirstName"] =  dbSkillRow["sFirstName"].ToString().Trim();
                  dr["sSkillType"] = "Tech";
                  dr["sSkill"] = t;
                  dr["sLevel"] = "0";
                  employeesNoSkillTable.Rows.InsertAt(dr, i);
               }
            }

            foreach(string p in prodSkills)
            {
               if (p.Trim().Length > 0)
               {
                  dr = employeesNoSkillTable.NewRow();
                  dr["sLoginID"] = dbSkillRow["sLoginID"].ToString();
                  dr["sLastName"] = dbSkillRow["sLastName"].ToString().Trim();
                  dr["sFirstName"] =  dbSkillRow["sFirstName"].ToString().Trim();
                  dr["sSkillType"] = p;
                  dr["sSkill"] = "main";
                  dr["sLevel"] = "0";
                  employeesNoSkillTable.Rows.InsertAt(dr, i);
               }
            }
         }
      }

      private void retrieveEmployeesWithoutSomeSkills(ref DataTable employeesNoSkillTable, 
         string techSkillSearchString,
         string prodSkillSearchString)
      {
         string[] techSkills = techSkillSearchString.Split(',');
         string[] prodSkills = prodSkillSearchString.Split(',');

         WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(
            System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);
         EmployeeList employeeList = new EmployeeList();

         employeeList.EmployeeListSkillsRetrieve(this.drOffice.SelectedItem.Text, 
            this.DropDownList2.SelectedItem.Text);

         DataSet dset = webAppDataHndlr.QueryRequest(employeeList);
         if (dset == null)
         {
            SMFLibrary.MessageBox(this, "Failed Query. Please contact your system administrator.");
            return;
         }

         DataTable ds = dset.Tables[0];
         DataColumn[] keys = new DataColumn[3];
         keys[0] = ds.Columns["sLoginID"];
         keys[1] = ds.Columns["sSkillType"];
         keys[2] = ds.Columns["sSkill"];
         ds.PrimaryKey = keys;

         DataRow dr;

         foreach (DataRow dbSkillRow in ds.Rows)
         {
            object [] tempEmpSkillKey = {dbSkillRow["sLoginID"].ToString().ToUpper(), 
                                         dbSkillRow["sSkillType"].ToString().Trim().ToUpper(),
                                         dbSkillRow["sSkill"].ToString().Trim().ToUpper()};

            if (!employeesNoSkillTable.Rows.Contains(tempEmpSkillKey))
            {
               bool inSearchStr = false;
               if (dbSkillRow["sSkillType"].ToString().Trim().ToUpper() == "TECH")
               {
                  inSearchStr = searchSkills(techSkillSearchString, dbSkillRow["sSkill"].ToString());
               }
               else
               {
                  inSearchStr = searchSkills(prodSkillSearchString, dbSkillRow["sSkillType"].ToString());
               }

               if ( inSearchStr &&
                    Int32.Parse(dbSkillRow["sLevel"].ToString().Trim()) == 0 )
               {
                  dr = employeesNoSkillTable.NewRow();
                  dr["sLoginID"] = dbSkillRow["sLoginID"].ToString();
                  dr["sLastName"] = dbSkillRow["sLastName"].ToString().Trim();
                  dr["sFirstName"] =  dbSkillRow["sFirstName"].ToString().Trim();
                  dr["sSkillType"] = dbSkillRow["sSkillType"].ToString().Trim();
                  dr["sSkill"] = dbSkillRow["sSkill"].ToString().Trim().ToUpper();
                  dr["sLevel"] = "0";
                  employeesNoSkillTable.Rows.Add(dr);
               }
            }

            foreach(string t in techSkills)
            {               
               if (t.Trim().Length > 0)
               {
                  object [] tempKey = {dbSkillRow["sLoginID"].ToString().ToUpper(), 
                                       "TECH",
                                       t.Trim().ToUpper()};
                  if (!ds.Rows.Contains(tempKey))
                  {
                     if (!employeesNoSkillTable.Rows.Contains(tempKey))
                     {
                        dr = employeesNoSkillTable.NewRow();
                        dr["sLoginID"] = dbSkillRow["sLoginID"].ToString();
                        dr["sLastName"] = dbSkillRow["sLastName"].ToString().Trim();
                        dr["sFirstName"] =  dbSkillRow["sFirstName"].ToString().Trim();
                        dr["sSkillType"] = "tech";
                        dr["sSkill"] = t.Trim();
                        dr["sLevel"] = "0";
                        employeesNoSkillTable.Rows.Add(dr);
                     }
                  }
               }
            }

            foreach(string p in prodSkills)
            {
               if (p.Trim().Length > 0)
               {
                  object [] tempKey = {dbSkillRow["sLoginID"].ToString().ToUpper(), 
                                         p.Trim().ToUpper(),
                                         "MAIN"};
                  if (!ds.Rows.Contains(tempKey))
                  {
                     if (!employeesNoSkillTable.Rows.Contains(tempKey))
                     {
                        dr = employeesNoSkillTable.NewRow();
                        dr["sLoginID"] = dbSkillRow["sLoginID"].ToString();
                        dr["sLastName"] = dbSkillRow["sLastName"].ToString().Trim();
                        dr["sFirstName"] =  dbSkillRow["sFirstName"].ToString().Trim();
                        dr["sSkillType"] = p.Trim();
                        dr["sSkill"] = "main";
                        dr["sLevel"] = "0";
                        employeesNoSkillTable.Rows.Add(dr);
                     }
                  }
               }
            }
         }
      }

      private void processNoSkill()
      {
         string techSkillSearchString = "";
         string prodSkillSearchString = ""; 
         DataTable employeesNoSkillTable = new DataTable();
         employeesNoSkillTable.Columns.Add(new DataColumn("sLoginID", typeof(string)));
         employeesNoSkillTable.Columns.Add(new DataColumn("sLastName", typeof(string)));
         employeesNoSkillTable.Columns.Add(new DataColumn("sFirstName", typeof(string)));
         employeesNoSkillTable.Columns.Add(new DataColumn("sSkillType", typeof(string)));
         employeesNoSkillTable.Columns.Add(new DataColumn("sSkill", typeof(string)));
         employeesNoSkillTable.Columns.Add(new DataColumn("sLevel", typeof(string)));

         DataColumn[] keys = new DataColumn[3];
         keys[0] = employeesNoSkillTable.Columns["sLoginID"];
         keys[1] = employeesNoSkillTable.Columns["sSkillType"];
         keys[2] = employeesNoSkillTable.Columns["sSkill"];
         employeesNoSkillTable.PrimaryKey = keys;

         retrieveTechSkills(ref techSkillSearchString);
         retrieveProdSkills(ref prodSkillSearchString);
         
         if ( !(techSkillSearchString.Trim().Equals(String.Empty)) ||
              !(prodSkillSearchString.Trim().Equals(String.Empty)) )
         {
            retrieveEmployeesWithoutSomeSkills(ref employeesNoSkillTable, techSkillSearchString, prodSkillSearchString);
            retrieveEmployeesWithNoSkills(ref employeesNoSkillTable, techSkillSearchString, prodSkillSearchString);            

            if (employeesNoSkillTable.Rows.Count > 0)
            {
               int i = 1;
               foreach (DataRow dbSkillRow in employeesNoSkillTable.Rows)
               {
                  generateDataRow(dbSkillRow, ref i);
               }
            }
         }
      }

      private void generateDataRow(DataRow dbSkillRow, ref int i)
      {
         DataRow dr;
         if (employeeTable.Rows.Contains(dbSkillRow["sLoginID"].ToString()))
         {
            string techSkill = employeeTable.Rows.Find(dbSkillRow["sLoginID"].ToString())["TechnicalSkill"].ToString();
            string prodSkill = employeeTable.Rows.Find(dbSkillRow["sLoginID"].ToString())["ProductSkill"].ToString();
            validateCurrentSkill(dbSkillRow["sSkillType"].ToString(), dbSkillRow["sSkill"].ToString(), ref prodSkill, ref techSkill, dbSkillRow["sLevel"].ToString().Trim());
            employeeTable.Rows.Find(dbSkillRow["sLoginID"].ToString())["TechnicalSkill"] = techSkill;
            employeeTable.Rows.Find(dbSkillRow["sLoginID"].ToString())["ProductSkill"] = prodSkill;
         }
         else
         {
            string techSkill = "";
            string prodSkill = "";
            dr = employeeTable.NewRow();
            dr["Number"] = i.ToString();
            dr["LoginID"] = dbSkillRow["sLoginID"].ToString();
            dr["EmployeeName"] = dbSkillRow["sLastName"].ToString().Trim() + ", " + dbSkillRow["sFirstName"].ToString().Trim();
            validateCurrentSkill(dbSkillRow["sSkillType"].ToString(), dbSkillRow["sSkill"].ToString(), ref prodSkill, ref techSkill, dbSkillRow["sLevel"].ToString().Trim());
            dr["TechnicalSkill"] = techSkill;
            dr["ProductSkill"] = prodSkill;            
            employeeTable.Rows.Add(dr);
            i++;
         }
      }

      private string mapLevel(string currentLevel)
      {
         switch (currentLevel)
         {
            case "3":
               return "Expert";
            case "2":
               return "Intermediate";
            case "1":
               return "Novice";
            default:
               return "None";
         }
      }

      private void validateCurrentSkill(string sSkillType, string sSkill,
         ref string prodSkill, ref string techSkill, string currentLevel)
      {
         if (sSkillType.Trim().ToUpper() == "TECH")
         {
            string currentSkill = sSkill;
            if (validateDataRow(currentSkill, "TECH", this.TextBox1.Text))
            {
               if (!techSkill.Trim().Equals(String.Empty))
               {
                  techSkill += ", ";
               }
               techSkill += currentSkill + " (" + mapLevel(currentLevel) + ")";
            }
         }
         else
         {
            string currentSkill = sSkillType;
            if (validateDataRow(currentSkill, "PROD", this.TextBox2.Text))
            {
               if (!prodSkill.Trim().Equals(String.Empty))
               {
                  prodSkill += ", ";
               }
               prodSkill += currentSkill + " (" + mapLevel(currentLevel) + ")";
            }
         }
      }

      private bool validateDataRow(string currentSkill, 
         string currentSkillType, string SearchString)
      {

         bool retVal = false;

         retVal = validateExactWord(currentSkill, currentSkillType, SearchString);

         return retVal;
      }

      private bool validateExactWord(string currentSkill, 
         string currentSkillType, string SearchString)
      {
         bool retVal = false;

         string tempString = SearchString;
         string [] s = tempString.Split(',');
         currentSkill = currentSkill.Trim().ToUpper();

         if (SearchString.Trim().Length > 0)
         {
            foreach(string t in s)
            {
               bool InSkill = false;
               tempString = t.ToUpper().Trim();

               if (currentSkill == tempString)
               {
                  InSkill = true;
               }

               if (InSkill)
               {
                  if (currentSkillType == "TECH")
                  {
                     Session["TechSkillFoundString"] = UpdateFoundSkill(currentSkill, Session["TechSkillFoundString"].ToString());
                  }
                  else
                  {
                     Session["ProdSkillFoundString"] = UpdateFoundSkill(currentSkill, Session["ProdSkillFoundString"].ToString());
                  }
                  retVal = true;
                  break;
               }
            }            
         }

         return retVal;
      }

      private string UpdateFoundSkill(string t, string currentSkill)
      {
         string foundString = currentSkill;
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

         return foundString;
      }

      private void GenerateDataGrid()
      {
         if (this.TextBox1.Text.Trim().Length > 0 ||
             this.TextBox2.Text.Trim().Length > 0)
         {
            Session["TechSkillFoundString"] = "";
            Session["ProdSkillFoundString"] = "";
            employeeTable = new DataTable();
            employeeTable.Columns.Add(new DataColumn("Number", typeof(string)));
            employeeTable.Columns.Add(new DataColumn("LoginID", typeof(string)));
            employeeTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
            employeeTable.Columns.Add(new DataColumn("TechnicalSkill", typeof(string)));
            employeeTable.Columns.Add(new DataColumn("ProductSkill", typeof(string)));

            DataColumn[] keys = new DataColumn[1];
            keys[0] = employeeTable.Columns["LoginID"];
            employeeTable.PrimaryKey = keys;

            RetrieveData();

            if (this.RadioButton2.Checked)
            {
               rectifyEmployeeTable();
            }

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
            SMFLibrary.SetFocus(this, this.DataGrid1);
         }
      }

      private bool searchSkills(string currentSkills, string SearchString)
      {
         bool retVal = true;

         string tempString = SearchString;
         string [] s = tempString.Split(',');
         currentSkills = " " + currentSkills.Trim().ToUpper() + " ";

         if (SearchString.Trim().Length > 0)
         {
            foreach(string t in s)
            {
               tempString = t.ToUpper().Trim();
               if (!tempString.Equals(String.Empty))
               {
                  tempString = " " + t.ToUpper().Trim() + " ";
                  if (currentSkills.IndexOf(tempString) == -1)
                  {
                     retVal = false;
                     break;
                  }
               }
            }
         }

         return retVal;
      }

      private void rectifyEmployeeTable()
      {
         bool modsMade = false;
         if (employeeTable != null)
         {
            DataRowCollection rc = employeeTable.Rows;
            for (int i = 0; i < rc.Count; i++)
            {
               DataRow thisRow = rc[i];
               bool deleteRow = false;
               string techSkills = thisRow["TechnicalSkill"].ToString();
               string prodSkills = thisRow["ProductSkill"].ToString();

               deleteRow = !searchSkills(techSkills, this.TextBox1.Text);
               if (!deleteRow)
               {
                  deleteRow = !searchSkills(prodSkills, this.TextBox2.Text);
               }

               if (deleteRow)
               {
                  thisRow.Delete();
                  i--;
                  modsMade = true;
               }
            }

            if (modsMade)
            {
               this.employeeTable.AcceptChanges();
               if (employeeTable != null)
               {
                  rc = employeeTable.Rows;
                  for (int i = 0; i < rc.Count; i++)
                  {
                     DataRow thisRow = rc[i];
                     thisRow["Number"] = (i + 1).ToString();
                  }
               }
            }
         }
      }

      private string UpdateLabel()
      {
         string resultStr = "";

         if (this.DataGrid1.Items.Count > 0)
         {
            string startNum = this.DataGrid1.Items[0].Cells[0].Text;
            string endNum = this.DataGrid1.Items[this.DataGrid1.Items.Count - 1].Cells[0].Text;
            resultStr = "Results " + startNum.Trim() + "-" + endNum.Trim() + " of ";
            resultStr += this.employeeTable.Rows.Count.ToString();
            resultStr += " employees that have ";

            if (this.DropDownList1.SelectedItem.Text.ToUpper().Trim() == "NONE")
            {
               resultStr += "no ";
            }

            if (!Session["TechSkillFoundString"].ToString().Trim().Equals(String.Empty))
            {
               if (this.RadioButton1.Checked)
               {
                  resultStr += "knowledge in any of the skills ";
               }
               else
               {
                  resultStr += "skills in ";
               }
               resultStr += "'" + Session["TechSkillFoundString"].ToString().Trim() + "' ";
            }

            if (!Session["TechSkillFoundString"].ToString().Trim().Equals(String.Empty) && 
               !Session["ProdSkillFoundString"].ToString().Trim().Equals(String.Empty))
            {
               if (this.DropDownList1.SelectedItem.Text.ToUpper().Trim() == "NONE")
               {
                  resultStr += " and no ";
               }
               else
               {
                  resultStr += " and ";
               }
            }

            if (!Session["ProdSkillFoundString"].ToString().Trim().Equals(String.Empty))
            {
               if (this.RadioButton1.Checked)
               {
                  resultStr += "knowledge in any of the products ";
               }
               else
               {
                  resultStr += "knowledge in ";
               }
               resultStr += "'" + Session["ProdSkillFoundString"].ToString().Trim() + "' ";
            }

            if (this.DropDownList1.SelectedItem.Text.ToUpper().Trim() != "NONE")
            {
               resultStr += " (Proficiency Level: " + this.DropDownList1.SelectedItem.Text.Trim() + ")";
            }
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

      private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
         if ((e.Item.ItemType == ListItemType.Item) ||
            (e.Item.ItemType == ListItemType.AlternatingItem))
         {
            System.Web.UI.WebControls.LinkButton tempLink = 
               (System.Web.UI.WebControls.LinkButton) e.Item.Cells[3].FindControl("ViewSummary"); 
            tempLink.Text = e.Item.Cells[2].Text;
            tempLink.ControlStyle.ForeColor = Color.FromName(System.Drawing.KnownColor.DarkBlue.ToString());

            String javascript = "window.showModalDialog('window_" + System.Configuration.ConfigurationSettings.AppSettings["/IndividualSummary"] + "?sLoginID=" +
               e.Item.Cells[1].Text + "',window,'scroll:yes;edge:sunken;status:no;resizable:no;help:no;center:yes;dialogHeight:700px;dialogWidth:763px');";
            tempLink.Attributes.Add("onclick", javascript);

            e.Item.Cells[3].Attributes["width"] = "25%";
            e.Item.Cells[4].Attributes["width"] = "75%";

            System.Web.UI.WebControls.Label tempLabel = 
               (System.Web.UI.WebControls.Label) e.Item.Cells[4].FindControl("TechSkill"); 
            tempLabel.Text = String.Empty;
            if (e.Item.Cells[5].Text != "&nbsp;")
            {
               tempLabel.Text = "Technical Skills: " + e.Item.Cells[5].Text;
               tempLabel.Visible = true;
            }
            else
            {
               tempLabel.Visible = false;
            }

            if (!tempLabel.Text.Equals(String.Empty))
            {
               tempLabel = (System.Web.UI.WebControls.Label) e.Item.Cells[4].FindControl("ProductSkill"); 
            }
            else
            {
               ((System.Web.UI.WebControls.Label) e.Item.Cells[4].FindControl("ProductSkill")).Visible = false;
            }

            if (e.Item.Cells[6].Text != "&nbsp;")
            {
               tempLabel.Text = "Product Skills: " + e.Item.Cells[6].Text;
               tempLabel.Visible = true;
            }
            else
            {
               tempLabel.Visible = false;
            }
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

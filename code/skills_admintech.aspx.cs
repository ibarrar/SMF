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
   /// Summary description for skills_admintech.
   /// </summary>
   public class skills_admintech : ViewController
   {
      protected System.Web.UI.WebControls.Panel Panel1;
      protected System.Web.UI.WebControls.TextBox TextBox1;
      protected System.Web.UI.WebControls.Label Label1;
      protected System.Web.UI.WebControls.Button Button1;
      protected System.Web.UI.WebControls.Button Button2;
      protected System.Web.UI.WebControls.Label Label2;
      protected System.Web.UI.WebControls.Label Label3;
      protected System.Web.UI.WebControls.DataGrid DataGrid1;
      protected System.Web.UI.WebControls.TextBox OldValue;
      protected System.Web.UI.WebControls.Label Label4;
      protected System.Web.UI.WebControls.LinkButton AddNewTechSkill;
      protected System.Web.UI.WebControls.LinkButton homelink;      
      protected System.Web.UI.WebControls.Label Label5;
      protected System.Web.UI.WebControls.Label Label6;
      protected System.Web.UI.WebControls.DropDownList dlPriority;
      protected SmfRewriteProject.ConfirmButton Confirmbutton1;
   
      private DataTable techSkillsTable;

      private void Page_Load(object sender, System.EventArgs e)
      {
         if( this.IsPostBack )
         {
            techSkillsTable = (DataTable) Session["DsTechSkills"];
         }
         else
         {
            CreateDataGrid();
            Session["DsTechSkills"] = techSkillsTable;
         }
      }

      private void CreateDataGrid()
      {
         this.DataGrid1.AutoGenerateColumns = false;
         this.DataGrid1.DataKeyField = "Skills";
         this.DataGrid1.AllowPaging = true;  
         techSkillsTable = GetTechSkillsData( );
         UpdateDataGrid();         
      }

      private DataTable GetTechSkillsData( )
      {
         TechnicalSkills techSkills = new TechnicalSkills(((Employee)Session["User"]).ToString());
         WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(
            System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);


         DataTable techSkillsTable = new DataTable();
         DataRow dr;

         DataSet dset = webAppDataHndlr.QueryRequest(techSkills);
         if (dset == null)
         {
            SMFLibrary.MessageBox(this, "Failed Query. Please contact your system administrator.");
            return techSkillsTable;
         }

         DataTable ds = dset.Tables[0];
         techSkillsTable.Columns.Add(new DataColumn("Skills", typeof(string)));
         techSkillsTable.Columns.Add(new DataColumn("Priority", typeof(string)));

         DataColumn[] keys = new DataColumn[1];
         keys[0] = techSkillsTable.Columns["Skills"];
         techSkillsTable.PrimaryKey = keys;

         foreach (DataRow dbSkillRow in ds.Rows)
         {
            dr = techSkillsTable.NewRow();
            this.FormatDataRow(dr, "Skills", dbSkillRow["sSkill"].ToString());
            this.FormatDataRow(dr, "Priority", validatePriorityCode(dbSkillRow["sPriority"].ToString().Trim()));
            techSkillsTable.Rows.Add(dr);
         }

         return techSkillsTable;
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
         this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
         this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
         this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
         this.AddNewTechSkill.Click += new System.EventHandler(this.AddNewTechSkill_Click);
         this.homelink.Click += new System.EventHandler(this.homelink_Click);
         this.Confirmbutton1.Click += new System.EventHandler(this.Confirmbutton1_Click);
         this.Button1.Click += new System.EventHandler(this.Button1_Click);
         this.Button2.Click += new System.EventHandler(this.Button2_Click);
         this.ID = "skills_admintech";
         this.Load += new System.EventHandler(this.Page_Load);

      }
      #endregion

      private string validatePriorityCode( string priorityCode )
      {
         string validCode = priorityCode;
         string validPriorityCodes = "|1|2|3|4|5|6|7|8|9|";
         if (validPriorityCodes.IndexOf("|" + priorityCode + "|") == -1) 
         {
            validCode = "9";
         }
         return validCode;
      }

      private void AddNewTechSkill_Click(object sender, System.EventArgs e)
      {
         this.Label3.Text = "Adding a technical skill";
         this.TextBox1.Enabled = true;
         this.TextBox1.Text = String.Empty;
         
         this.Label6.Visible = true;
         this.dlPriority.SelectedValue = "9";
         this.dlPriority.Visible = true;
         this.dlPriority.Enabled = true;

         this.Button1.Visible = true;
         this.Confirmbutton1.Visible = false;
         this.Button1.Text = "Save";
         this.Label4.Visible = false;
         this.Panel1.Visible = true;
         SMFLibrary.SetFocus(this, this.Panel1);
      }

      private void Button2_Click(object sender, System.EventArgs e)
      {
         ClosePanel();
      }

      private void ClosePanel()
      {
         this.Label3.Text = "Unknown Mode";
         this.Panel1.Visible = false;
         this.TextBox1.Text = String.Empty;
         this.TextBox1.Enabled = false;
         this.Button1.Text = "Unknown";
         SMFLibrary.SetFocus(this, this.DataGrid1);
      }

      private void Button1_Click(object sender, System.EventArgs e)
      {
         if (this.Label3.Text == "Adding a technical skill")
         {
            AddEntry();
         }

         if (this.Label3.Text == "Edit a technical skill")
         {
            EditEntry();
            ClosePanel();
         }
      } 

      private void AddEntry()
      {
         if ( DataValid() )
         {
            InsertNewEntry();
         }
      }

      private bool DataValid()
      {
         if (this.TextBox1.Text.Equals(String.Empty))
         {
            SMFLibrary.MessageBox(this, "Skills is a required field.");
            SMFLibrary.SetFocus(this, this.Panel1);
            return false;
         }

         if (this.techSkillsTable.Rows.Find(this.TextBox1.Text) != null)
         {
            if (!(this.Label3.Text == "Edit a technical skill") ||
               !(this.TextBox1.Text.Trim() == this.OldValue.Text.Trim()))
            {
               SMFLibrary.MessageBox(this, "Skill Code " + this.TextBox1.Text.Trim() + " already exists.");
               SMFLibrary.SetFocus(this, this.Panel1);
               return false;
            }
         }

         return true;
      }

      private void InsertNewEntry()
      {
         SkillCode techSkill = new SkillCode(((Employee)Session["User"]).ToString(),
                                             "Tech", this.TextBox1.Text.Trim(), 
                                             this.dlPriority.SelectedValue);
         techSkill.NonQueryType = WebAppDataHandler.DB_HITS.INSERT;
         UpdateData(techSkill);
      }

      private void EditClicked(string Skill, string priority)
      {
         this.Label3.Text = "Edit a technical skill";
         this.TextBox1.Enabled = true;
         this.TextBox1.Text = Skill.Trim();
         this.OldValue.Text = Skill.Trim();

         this.Label6.Visible = true;
         this.dlPriority.SelectedValue = priority.Trim();
         this.dlPriority.Visible = true;
         this.dlPriority.Enabled = true;

         this.Button1.Visible = true;
         this.Confirmbutton1.Visible = false;
         this.Button1.Text = "Save";
         this.Label4.Visible = true;
         this.Panel1.Visible = true;
         SMFLibrary.SetFocus(this, this.Panel1);
      }

      private void EditEntry()
      {
         if ( DataValid() )
         {
            EditExistingEntry();
         }
      }

      private void EditExistingEntry()
      {
         SkillCode techSkill = new SkillCode(((Employee)Session["User"]).ToString(),
                                             "Tech", this.TextBox1.Text.Trim(), 
                                             this.dlPriority.SelectedValue,
                                             this.OldValue.Text, 
                                             WebAppDataHandler.DB_HITS.UPDATE);
         UpdateData(techSkill);
      }

      private void DeleteClicked(string Skill)
      {
         this.Label3.Text = "Delete a technical skill";
         this.TextBox1.Enabled = false;
         this.TextBox1.Text = Skill.Trim();

         this.Label6.Visible = false;
         this.dlPriority.Visible = false;
         this.dlPriority.Enabled = false;

         this.Button1.Visible = false;
         this.Confirmbutton1.Visible = true;
         this.Label4.Visible = true;
         this.Panel1.Visible = true;
         SMFLibrary.SetFocus(this, this.Panel1);
      }

      private void DeleteEntry()
      {
         DeleteExistingEntry();
      }

      private void DeleteExistingEntry()
      {
         SkillCode techSkill = new SkillCode(((Employee)Session["User"]).ToString(),
                                             "Tech", this.TextBox1.Text.Trim(),
                                             null);
         techSkill.NonQueryType = WebAppDataHandler.DB_HITS.DELETE;
         UpdateData(techSkill);
      }

      private void UpdateData(SkillCode techSkill)
      {
         WebAppDataHandler.DB_HITS NonQueryType = techSkill.NonQueryType;
         WebAppDataHandler webAppDataHndlr = new WebAppDataHandler(
            System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]);

         if (!webAppDataHndlr.NonQueryRequest(techSkill))
         {
            SMFLibrary.MessageBox(this, "Failed to " + NonQueryType + " skill code. Please contact your system administrator.");
         }
         else
         {
            switch (NonQueryType)
            {
               case (WebAppDataHandler.DB_HITS.INSERT) :
                  AddDataTable();
                  this.TextBox1.Text = String.Empty;
                  this.dlPriority.SelectedValue = "9";
                  SMFLibrary.SetFocus(this, this.Panel1);
                  break;
               case (WebAppDataHandler.DB_HITS.UPDATE) :
                  UpdateDataTable(techSkill.Skill, techSkill.Priority);
                  break;
               case (WebAppDataHandler.DB_HITS.DELETE) :
                  DeleteDataTable(techSkill.Skill);
                  break;
               default:
                  // Impossible!
                  break;
            }
         }
         Session["DsTechSkills"] = techSkillsTable;
         UpdateDataGrid();         
      }

      private void DeleteDataTable(string Skill)
      {
         DataRow thisRow;
         thisRow = this.techSkillsTable.Rows.Find(Skill);
         if (thisRow != null)
         {
            thisRow.Delete();
            this.techSkillsTable.AcceptChanges();
         }
      }

      private void UpdateDataTable(string Skill, string Priority)
      {
         DataRow thisRow;
         thisRow = this.techSkillsTable.Rows.Find(this.OldValue.Text);
         if (thisRow != null)
         {
            thisRow.BeginEdit();
            thisRow[0] = Skill;
            thisRow[1] = Priority;
            thisRow.EndEdit();
            thisRow.AcceptChanges();
            this.techSkillsTable.AcceptChanges();
         }
      }

      private void AddDataTable()
      {
         DataRow dr = techSkillsTable.NewRow();
         this.FormatDataRow(dr, "Skills", this.TextBox1.Text.Trim());
         this.FormatDataRow(dr, "Priority", this.dlPriority.SelectedValue.Trim());
         techSkillsTable.Rows.Add(dr);
      }

      private void FormatDataRow(DataRow dr, string rowName, string rowValue)
      {
         dr[rowName] = rowValue;
      }

      private void UpdateDataGrid()
      {
         DataView dv = new DataView(techSkillsTable, null, "Priority, Skills", DataViewRowState.CurrentRows); 
         int CurrentPageIndex = DataGrid1.CurrentPageIndex;
         this.DataGrid1.DataSource = dv;
         try
         {
            this.DataGrid1.DataBind();
         }
         catch (System.Web.HttpException e)
         {
            if (e.Message == "Invalid CurrentPageIndex value. It must be >= 0 and < the PageCount.")
            {
               DataGrid1.CurrentPageIndex = 0;
               UpdateDataGrid();
            }
            else
            {
               throw e;
            }
         }
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
            e.Item.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Item.Cells[2].Attributes["width"] = "50%";
            System.Web.UI.WebControls.LinkButton tempLink = 
               (System.Web.UI.WebControls.LinkButton) e.Item.Cells[1].FindControl("Edit"); 
            tempLink.ControlStyle.ForeColor = Color.FromName(System.Drawing.KnownColor.Blue.ToString());
            tempLink = 
               (System.Web.UI.WebControls.LinkButton) e.Item.Cells[1].FindControl("Delete"); 
            tempLink.ControlStyle.ForeColor = Color.FromName(System.Drawing.KnownColor.Blue.ToString());

         }      
      }

      private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
      {
         if (e.CommandName == "Edit")
         {
            EditClicked(e.Item.Cells[0].Text, e.Item.Cells[1].Text);
         }

         if (e.CommandName == "Delete")
         {
            DeleteClicked(e.Item.Cells[0].Text);
         }
      }

      private void homelink_Click(object sender, System.EventArgs e)
      {
         Server.Transfer(System.Configuration.ConfigurationSettings.AppSettings["/Menu"]);
      }

      private void DataGrid1_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
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

      private void Confirmbutton1_Click(object sender, System.EventArgs e)
      {
         if (this.Label3.Text == "Delete a technical skill")
         {
            DeleteEntry();
            ClosePanel();
         }      
      }
   }
}

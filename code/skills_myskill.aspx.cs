using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SmfRewriteProject.Util;

namespace SmfRewriteProject
{
	/// <summary>
	/// Summary description for skills_myskill.
	/// </summary>
	public class skills_myskill : ViewController
	{
		protected System.Web.UI.WebControls.Label lblUsername;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label lblAdditionalSkills;
		protected System.Web.UI.WebControls.PlaceHolder phTechSkills;
		protected System.Web.UI.WebControls.PlaceHolder phProdSkills;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Table TechSkillTable;
		protected System.Web.UI.WebControls.Table ProdSkillsTable;
		protected System.Web.UI.WebControls.Button btnAddNewProd;
		protected System.Web.UI.WebControls.Label additionalTech;
		protected System.Web.UI.WebControls.TextBox inAdditionalTech;
		protected System.Web.UI.WebControls.Label additionalProd;
		protected System.Web.UI.WebControls.TextBox inAdditionalProd;
		protected System.Web.UI.WebControls.Button btnAdditionalTech;
		protected System.Web.UI.WebControls.Button btnAdditionalProd;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.LinkButton btnBack;
		protected System.Web.UI.WebControls.Button btnAddTech;


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
			this.btnAdditionalTech.Click += new System.EventHandler(this.btnAdditionalTech_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.btnAdditionalProd.Click += new System.EventHandler(this.btnAdditionalProd_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

		}
		#endregion

		protected override void OnPreRender(EventArgs e)
		{
			this.lblUsername.Text = this.currentUser.sLoginID.ToUpper();
			this.getMySkills();
			this.getNotMySkills();
			this.getMyProdSkills();
			this.AddAdditionalTech();
			this.AddAddtionalProd();
			if(Request.QueryString.Count == 0)
				this.initializeScripts();
			else
			{
				// do the action
				string action = Request.QueryString["action"];
				string TechSkill, level, yr, Exp, Product, SubSysList, skill;
				switch(action)
				{
					case "SaveTech":
						TechSkill = Request.QueryString["TechSkill"].ToString();
						level = Request.QueryString["level"].ToString();
						yr = Request.QueryString["yr"].ToString();
						Exp = Request.QueryString["Exp"].ToString();
						if(TechSkill.ToLower() == "none" || TechSkill == "" || 
							level == "" || yr == "" || !IsNumeric.check(yr) ||
							Exp == "" || !IsNumeric.check(yr))
							break;
						this.addTech(TechSkill, level, yr, Exp);
						break;
					case "SaveProd":
						Product = Request.QueryString["Product"].ToString();
						level = Request.QueryString["level"].ToString();
						yr = Request.QueryString["yr"].ToString();
						Exp = Request.QueryString["Exp"].ToString();
						SubSysList = Request.QueryString["SubSysList"].ToString();
						if(Product == "" || level == "" || 
							yr == "" || !IsNumeric.check(yr) || 
							Exp == "" || !IsNumeric.check(Exp) || SubSysList == "")
							break;
						this.addProd(Product, level, yr, Exp, SubSysList);
						break;
					case "EditTech":
						TechSkill = Request.QueryString["skill"].ToString();
						level = Request.QueryString["level"].ToString();
						yr = Request.QueryString["yr"].ToString();
						Exp = Request.QueryString["Exp"].ToString();
						if(TechSkill == "" || level == "" || yr == "" || Exp == "" ||
							!IsNumeric.check(yr) || !IsNumeric.check(Exp))
							break;
						this.editTech(TechSkill, level, yr, Exp);
						break;
					case "EditProd":
						skill = Request.QueryString["skill"].ToString();
						level = Request.QueryString["level"].ToString();
						Exp = Request.QueryString["Exp"].ToString();
						yr = Request.QueryString["yr"].ToString();
						SubSysList = Request.QueryString["sub"].ToString();
						if(skill == "" || level == "" || yr == "" || Exp == "" || 
							SubSysList == "" || !IsNumeric.check(yr) || !IsNumeric.check(Exp))
							break;
						this.deleteProd(skill);
						this.addProd(skill, level, yr, Exp, SubSysList);
						break;
					case "DeleteTech":
						skill = Request.QueryString["skill"].ToString();
						if(skill == "")
							break;
						this.deleteTech(skill);
						break;
					case "DeleteProd":
						skill = Request.QueryString["skill"].ToString();
						if(skill == "")
							break;
						this.deleteProd(skill);
						break;
				}
				Response.Redirect("skills_myskill.aspx");
			}
		}


		private void initializeScripts()
		{
			this.buildDropDownGenerator(this.getNotMyProdSkills(),
				"CreateAddProdSelection()", "Products");
			this.makeSubSysEditViewBuilder();
		}


		private void deleteProd(string product)
		{
			string sql = "DELETE FROM T_SKILLS_EMPSUBSYS WHERE sEmpID=" + currentUser.sEmpID + " " +
				" AND sSkillType='" + product + "'";
			execute(sql);
			sql = "DELETE FROM T_SKILLS_EMPSKILLS WHERE sEmpID=" + currentUser.sEmpID + " AND sSkillType='" + product + "'";
			execute(sql);
		}


		private void addProd(string product, string level, string yr, string Exp, string subsys)
		{
			string sql = "INSERT INTO T_SKILLS_EMPSKILLS" +
				" VALUES(" + currentUser.sEmpID + ",'" + product + "','main'," +
				level + ",'"+ yr + "'," + Exp + ",'" +
				DateTime.Today.ToShortDateString() + "','" + currentUser.sLoginID + "','" +
				DateTime.Today.ToShortDateString() + "')";
			execute(sql);
			foreach(string s in subsys.Split(",".ToCharArray()[0]))
				execute("INSERT INTO T_SKILLS_EMPSUBSYS VALUES(" + currentUser.sEmpID + ", " +
					"'" + product + "', '" + s + "', '" + currentUser.sLoginID + "', '" + DateTime.Today.ToShortDateString() + "')");
		}

		private void addTech(string TechSkill, string level,
			string yr, string Exp)
		{
			string sql = "INSERT INTO T_SKILLS_EMPSKILLS" +
				" VALUES(" + currentUser.sEmpID + ",'Tech','" + TechSkill + "'," +
				level + ",'"+ yr + "'," + Exp + ",'" +
				DateTime.Today.ToShortDateString() + "','" + currentUser.sLoginID + "','" +
				DateTime.Today.ToShortDateString() + "')";
			execute(sql);
		}

		private void deleteTech(string skill)
		{
			string sql = "DELETE FROM T_SKILLS_EMPSKILLS WHERE sSkill='" + skill + "' " +
				"AND sEmpID=" + currentUser.sEmpID;
			execute(sql);
		}

		private void editTech(string skill, string level, string yr, string exp)
		{
			string sql = "UPDATE T_SKILLS_EMPSKILLS" +
				" SET sLevel=" + level + ", sDateLastUsed = '" + yr + "'," +
				" sYrExperience = " + exp + ", sLastUpdate = '" + DateTime.Today.ToShortDateString() + "'" +
				" WHERE sEMPID = " + this.currentUser.sEmpID + " and sSkillType = 'Tech'" +
				" and sSkill = '" + skill + "'";
			execute(sql);
		}

		private void AddAdditionalTech()
		{
			string sql = "SELECT sAddTechSkills FROM T_SKILLS_EMPINFO WHERE sEmpID=" + this.currentUser.sEmpID;
			DataSet ds = this.getData(sql);
			this.additionalTech.Text = ds.Tables[0].Rows[0][0].ToString();
		}

		private void AddAddtionalProd()
		{
			string sql = "SELECT sAddProdKnowledge FROM T_SKILLS_EMPINFO WHERE sEmpID=" + this.currentUser.sEmpID;
			DataSet ds = this.getData(sql);
			this.additionalProd.Text = ds.Tables[0].Rows[0][0].ToString();
		}

		#region " scripts for tech table "

		private void getMySkills()
		{
			string myId = this.currentUser.sEmpID;
			string sql = "SELECT sSkill, sLevel, sDateLastUsed, sYrExperience" +
				" FROM T_SKILLS_EMPSKILLS" +
				" WHERE sEmpID = " + myId + " AND sSkillType = 'Tech' " +
				" ORDER BY sSkill ASC";
			DataSet ds = this.getData(sql);
			int i = 0;
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				i += 1;
				TableRow row = new TableRow();
				TableCell skill = new TableCell();
				TableCell level = new TableCell();
				TableCell datelastused = new TableCell();
				TableCell yrsexp = new TableCell();
				TableCell btns = new TableCell();
				skill.Text = r["sSkill"].ToString() + this.makeTechValuePlaceHolder(i, "TechSkill", r["sSkill"].ToString());
				level.Text = this.getSkillLevel(r["sLevel"].ToString()) + this.makeTechValuePlaceHolder(i, "TechLevel", r["sLevel"].ToString());
				datelastused.Text = r["sDateLastUsed"].ToString() + this.makeTechValuePlaceHolder(i, "TechDateLastUsed", r["sDateLastUsed"].ToString());
				yrsexp.Text = r["sYrExperience"].ToString() + this.makeTechValuePlaceHolder(i, "TechYrExperience", r["sYrExperience"].ToString());
				btns.Text = this.makeTechEditButton(i) + " " + this.makeTechDelButton(i);
				row.Cells.Add(skill);
				row.Cells.Add(level);
				row.Cells.Add(datelastused);
				row.Cells.Add(yrsexp);
				row.Cells.Add(btns);
				this.TechSkillTable.Rows.Add(row);
			}
		}

		
		private string makeTechDelButton(int rowNum)
		{
			return "<input type='button' value='Delete' class='buttonStyle' id='TechDel" + rowNum + "' onclick='doTechDel(" + rowNum + ")'>";
		}


		private string makeTechEditButton(int rowNum)
		{
			return "<input type='button' value='Edit' class='buttonStyle' id='TechEdit" + rowNum + "' onclick='doTechEdit(" + rowNum + ")'>";
		}


		private string makeTechValuePlaceHolder(int rowNum, string id, string val)
		{
			return "<input type='hidden' id='" + id + rowNum + "' value='" + val + "'>";
		}


		private void getNotMySkills()
		{
			string myId = this.currentUser.sEmpID;
			string sql = "SELECT sSkill FROM T_SKILLS_CODE " +
				"WHERE sSkill NOT IN (" +
				"SELECT sSkill FROM T_SKILLS_EMPSKILLS " +
				"WHERE sEmpID=" + this.currentUser.sEmpID + ") " +
				"AND sSkillType='Tech'";
			DataSet ds = this.getData(sql);
			string options = "";
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				options = options + "<option value=\"" + r[0].ToString() + "\">" + r[0].ToString() + "</option>";
			}
			string script = "<script language='javascript'>" +
				"function getNotMySkills(){" +
				"return '<select id=techskills><option selected value=\"none\">choose one</option>" + options + "</select>';" +
				"}" +
				"</script>";
			Page.RegisterStartupScript("TechSkillScript", script);
		}


		#endregion

		private DataSet getExtraTech()
		{
			string sql = "SELECT sAddTechSkills" +
				" FROM T_SKILLS_EMPINFO" +
				" WHERE sEmpID = " + this.currentUser.sEmpID;
			return this.getData(sql);
		}


		private DataSet getExtraProd()
		{
			string sql = "SELECT sAddProdKnowledge" +
				" FROM T_SKILLS_EMPINFO" +
				" WHERE sEmpID = " + this.currentUser.sEmpID;
			return this.getData(sql);
		}


		#region " scripts for product knowledge table behavior "

		private void getMyProdSkills()
		{
			string sqlmain = "SELECT sSkillType, sLevel, sDateLastUsed, sYrExperience " +
				"FROM T_SKILLS_EMPSKILLS WHERE sEmpID=" + this.currentUser.sEmpID + " " +
				"AND sSkill='main'";
			string sqlsub = "SELECT sSkillType, sSkill FROM T_SKILLS_EMPSUBSYS " +
				"WHERE sSkillType IN(" +
				"SELECT sSkillType " +
				"FROM T_SKILLS_EMPSKILLS WHERE sEmpID=" + this.currentUser.sEmpID + " " +
				"AND sSkill='main')" + 
				"AND sEmpID=" + this.currentUser.sEmpID;
			DataSet ds = this.getData(sqlmain);
			DataSet dsSub = this.getData(sqlsub);
			int i = 0;
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				i += 1;
				TableCell skill = new TableCell();
				TableCell sub = new TableCell();
				TableCell level = new TableCell();
				TableCell datelastused = new TableCell();
				TableCell yrsexp = new TableCell();
				TableCell btns = new TableCell();
				skill.Text = r["sSkillType"].ToString() + this.makeTechValuePlaceHolder(i, "ProdSkill", r["sSkillType"].ToString());
				string subText = "";
				foreach(DataRow rSub in dsSub.Tables[0].Select("sSkillType='" + r["sSkillType"].ToString() + "'"))
				{
					subText = subText + rSub["sSkill"].ToString() + ", ";
				}

				// ADDED BY ESC 3/8/05
				if (subText.Length > 0)
				{
					sub.Text = subText.Substring(0, subText.Length - 2);
				}
				else
				{
					sub.Text = "";
				}
				level.Text = this.getSkillLevel(r["sLevel"].ToString());
				datelastused.Text = r["sDateLastUsed"].ToString() + this.makeTechValuePlaceHolder(i, "ProdYrLastUsed", r["sDateLastUsed"].ToString());
				yrsexp.Text = r["sYrExperience"].ToString() + this.makeTechValuePlaceHolder(i, "ProdYrExperience", r["sYrExperience"].ToString());
				btns.Text = "<table border='0' cellspacing='1' cellpadding='0'>" +
					"<tr><td>" + this.makeProdEditButton(i) + "</td><td>" +
					this.makeProdDelButton(i) + "</td></tr></table>";
				TableRow row = new TableRow();
				row.Cells.Add(skill);
				row.Cells.Add(sub);
				row.Cells.Add(level);
				row.Cells.Add(datelastused);
				row.Cells.Add(yrsexp);
				row.Cells.Add(btns);
				this.ProdSkillsTable.Rows.Add(row);
			}
		}


		private string SubSysEditViewScript = "";
		private void makeSubSysEditViewBuilder()
		{
			DataSet mySubSys = this.getData("SELECT DISTINCT sSkill FROM T_SKILLS_EMPSUBSYS WHERE sEmpID=" + this.currentUser.sEmpID);
			DataSet allprod = this.getData("SELECT DISTINCT sSkillType FROM T_SKILLS_CODE WHERE sSkillType <> 'Tech'");
			DataSet allsubsys = this.getData("SELECT sSkill, sSkillType FROM T_SKILLS_CODE WHERE sSkillType <> 'Tech'");
			string script = "switch(product){\n";
			foreach(DataRow r in allprod.Tables[0].Rows)
			{
				script = script + "case '" + r[0].ToString() + "':\n";
				script = script + "return '" + makeSubSysEdit(r[0].ToString().Trim(), allsubsys, mySubSys) + "';\n";
			}
			script = script + "}\n";
			this.SubSysEditViewScript = this.CreateScriptTag(this.CreateFunctionBody("CreateEditList(product)", script));
			Page.RegisterStartupScript("SubsysEdits", this.SubSysEditViewScript);
		}
		private string makeSubSysEdit(string product, DataSet allsubsys, DataSet mySubSys)
		{
			string script = "";
			int i = 0;
			foreach(DataRow r in allsubsys.Tables[0].Select("sSkillType='" + product + "'"))
			{
				i += 1;
				script = script + "<input type=\"checkbox\" " + this.SubsysCheck(mySubSys, r[0].ToString()) + " id=\"Subsys" + i + "\" value=\"" + r[0].ToString() + "\">" + r[0].ToString() + "<br>";
			}
			script = script + "<input type=\"hidden\" id=\"" + product + "subsyscount\" value=\"" + i + "\">";
			return script;
		}
		private string SubsysCheck(DataSet mySubSys, string subsystem)
		{
			foreach(DataRow r in mySubSys.Tables[0].Rows)
				if(r["sSkill"].ToString().Equals(subsystem))
					return "checked";
			return " ";
		}


		private string makeProdDelButton(int rowNum)
		{
			return "<input type='button' value='Delete' class='buttonStyle' id='ProdDel" + rowNum + "' onclick='doProdDel(" + rowNum + ")'>";
		}


		private string makeProdEditButton(int rowNum)
		{
			return "<input type='button' value='Edit' class='buttonStyle' id='ProdEdit" + rowNum + "' onclick='doProdEdit(" + rowNum + ")'>";
		}


		private DataSet getNotMyProdSkills()
		{
			string sql = "SELECT DISTINCT sSkillType FROM T_SKILLS_CODE " +
				"WHERE sSkillType NOT IN (SELECT DISTINCT sSkillType FROM T_SKILLS_EMPSKILLS WHERE sSkill='main' " +
				"AND sEmpID=" + this.currentUser.sEmpID + ") " +
				"AND sSkillType <> 'Tech' " +
				"ORDER BY sSkillType ASC";
			return this.getData(sql);
		}


		private string getSkillLevel(string level)
		{
			switch(level)
			{
				case("1"):
					return "Novice";
				case("2"):
					return "Intermediate";
				case("3"):
					return "Expert";
				default:
					return "N/A";
			}
		}


		private DataSet getSubSkills(string product)
		{
			string sql = "SELECT sSkill FROM T_SKILLS_CODE " +
				"WHERE sSkillType = '" + product + "' ORDER BY sSkill ASC";
			return this.getData(sql);
		}


		private void buildDropDownGenerator(DataSet ds, string functionName, string controlId)
		{
			string opts = "<option selected value=\"none\">choose one</option>";
			foreach(DataRow r in ds.Tables[0].Rows)
				opts = opts + "<option value=\"" + r[0].ToString() + "\">" + r[0].ToString() + "</option>";
			string script = "\n<script language='javascript'>" +
				"\nfunction " + functionName + "{" +
				"\nreturn '<select id=" + controlId + " onchange=showSubDrop()>" + opts + "</select>';" +
				"}";
			script = script + "\nfunction CreateAddSubSelection(selected){";
			script = script + "\nswitch(selected){\n";
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				script = script + "case '" + r[0].ToString() + "':\n" +
					"return '" + this.buildSubDropDown(
					this.getSubSkills(r[0].ToString()), "Subsystem", r[0].ToString()) + "';\n";
			}
			script = script + "default:\n";
			script = script + "return 'choose a product';\n";
			script = script + "}\n";
			script = script + "}\n</script>";
			Page.RegisterStartupScript("dropdowngen", script);
		}


		private string buildSubDropDown(DataSet ds, string controlId, string ParentItem)
		{
			string script = "";
			int i = 0;
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				i += 1;
				script = script + "<input type=\"checkbox\" id=\"" + controlId + i + "\" value=\"" + r[0].ToString() + "\">" + r[0].ToString() + "<br>";
			}
			script = script + "<input type=\"hidden\" id=\"" + ParentItem + "subsyscount\" value=\"" + i + "\">";
			return script;
		}


		#endregion

		#region " script helper functions "

		private string CreateScriptTag(string content)
		{
			return "<script language=\"javascript\">\n" + content + "</script>\n";
		}


		private string CreateFunctionBody(string functionHeader, string content)
		{
			return "function " + functionHeader + "{\n" + content + "\n}\n";
		}


		#endregion

        public void execute(string sql)
        {
            using ( SqlConnection _connection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]))
                {
                    try
                    {
                        if (_connection.State == ConnectionState.Closed)
                        {
                            _connection.Open();
                        }
                        using ( SqlCommand _command = new SqlCommand(sql, _connection))
                        {
                                _command.ExecuteNonQuery();
                        }                        
                    }
                    catch (Exception ex)
                    {
                        SMFLibrary.MessageBox(this, ex.Message);
                        return;
                    }
                    finally
                    {
                        if (_connection.State == ConnectionState.Open)
                            _connection.Close();
                    }
                }
            
        }

		private DataSet getData(string sql)
		{
			// Put user code to initialize the page here
            using ( SqlConnection _connection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["SqlConnection"]))
            {
			    DataSet ds = new DataSet();
			    try
			    {
                    if (_connection.State == ConnectionState.Closed)
                    {
                        _connection.Open();
                    }
                    using ( SqlCommand _command = new SqlCommand(sql, _connection))
                    {
                        DataTable tbl = new DataTable();
                                        tbl.Load( _command.ExecuteReader());
                                        ds.Tables.Add(tbl);
                           
                    }
					return ds;
	            }
                catch(Exception ex)
                {
	                SMFLibrary.MessageBox(this,ex.Message);
                }
                finally
                {
	                if(_connection.State == ConnectionState.Open)
		                _connection.Close();
                }
            }
        return null;
        }

		private void btnAdditionalTech_Click(object sender, System.EventArgs e)
		{
			if(this.btnAdditionalTech.Text == "Save"){
				string sql = "UPDATE T_SKILLS_EMPINFO SET sAddTechSkills='" + this.inAdditionalTech.Text + "' " +
					"WHERE sEmpID=" + this.currentUser.sEmpID;
				this.execute(sql);
				Response.Redirect("skills_myskill.aspx");
			}else{
				this.btnAdditionalTech.Text = "Save";
				this.additionalTech.Visible = false;
				this.inAdditionalTech.Visible = true;
				this.inAdditionalTech.Text = this.additionalTech.Text;
				this.Button2.Visible = true;
			}
		}

		private void btnAdditionalProd_Click(object sender, System.EventArgs e)
		{
			if(this.btnAdditionalProd.Text == "Save")
			{
				string sql = "UPDATE T_SKILLS_EMPINFO SET sAddProdKnowledge='" + this.inAdditionalProd.Text + "' " +
					"WHERE sEmpID=" + this.currentUser.sEmpID;
				this.execute(sql);
				Response.Redirect("skills_myskill.aspx");
			}
			else
			{
				this.btnAdditionalProd.Text = "Save";
				this.additionalProd.Visible = false;
				this.inAdditionalProd.Visible = true;
				this.inAdditionalProd.Text = this.additionalProd.Text;
				this.Button3.Visible = true;
			}
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("skills_myskill.aspx");
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("skills_myskill.aspx");
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(System.Configuration.ConfigurationSettings.AppSettings["/Menu"]);
		}
	}
}
<%@ Page language="c#" Codebehind="skills_myskill.aspx.cs" AutoEventWireup="false" Inherits="SmfRewriteProject.skills_myskill" %>
<%@ Register TagPrefix="uc1" TagName="SmfTopNavButtons" Src="SmfTopNavButtons.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>skills_myskill</title>
		<meta content="SharePoint.WebPartPage.Document" name="ProgId">
		<meta content="full" name="WebPartPageExpansion">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="skills_stylesheet.css" type="text/css" rel="stylesheet">
		<style type="text/css">
		TD { VERTICAL-ALIGN: top }
		.buttonStyle { border-style: solid;
                border-color: inherit;
                border-width: 1px;
                padding: 1px 4px;
            }
		</style>
		<script language="javascript">
		function doAction(action, table, index){
			if(document.getElementById("lock").getAttribute("value") == "false"){
				document.getElementById("lock").setAttribute("value", "true");
				if(action == "AddTech")
					createTechSkillInput();
				if(action == "AddProd")
					createProdSkillInput();
			}
		}
		
		function doTechEdit(i){
			if(document.getElementById("lock").getAttribute("value") == "false"){
				document.getElementById("lock").setAttribute("value", "true");
				var row = document.getElementById("TechSkillTable").rows[i];
				row.cells[1].innerHTML = getProficiency(i + "tech");
				row.cells[2].innerHTML = "<input type='text' id='techYrLastUsed" + i + "' size='4' maxlength='4' " +
					"value='" + document.getElementById("TechDateLastUsed" + i).getAttribute("value") + "'>";
				row.cells[3].innerHTML = "<input type='text' id='techYrExperience" + i + "' size='2' maxlength='4' " +
					"value='" + document.getElementById("TechYrExperience" + i).getAttribute("value") + "'>";
				row.cells[4].innerHTML = "<table border='0' cellspadding='0' cellspacing='1'>" +
					"<tr><td>" + makeTechEditSaveButton(i) + "</td><td>" + makeTechEditCancelButton(i) + "</td></tr></table>";
			}
		}
		
		function doTechEditSave(i){
			// send data to server
			var loc = "skills_myskill.aspx?action=EditTech" +
				"&level=" + document.getElementById(i + "techproficiency").getAttribute("value") +
				"&yr=" + document.getElementById("techYrLastUsed" + i).getAttribute("value") +
				"&Exp=" + document.getElementById("techYrExperience" + i).getAttribute("value") +
				"&skill=" + escape(document.getElementById("TechSkill" + i).getAttribute("value"));
			window.location.href = loc.replace("++", "%2B%2B");
		}
		
		function doTechEditCancel(i){
			// refresh
			window.location.href = "skills_myskill.aspx";
		}
		
		function doTechDel(i){
			if(document.getElementById("lock").getAttribute("value") == "false"){
				document.getElementById("lock").setAttribute("value", "true");
				var loc = "skills_myskill.aspx?action=DeleteTech" +
					"&skill=" + escape(document.getElementById("TechSkill" + i).getAttribute("value"));
				window.location.href = loc.replace("++", "%2B%2B");
			}
		}
		
		function doTechSave(){
			// send data to server
			if(ValidTechInfo()){
				var loc = "skills_myskill.aspx?" +
					"TechSkill=" + escape(document.getElementById("techskills").options[document.getElementById("techskills").selectedIndex].value) +
					"&level=" + document.getElementById("techproficiency").options[document.getElementById("techproficiency").selectedIndex].value +
					"&Exp=" + document.getElementById("techYrExperience").getAttribute("value") +
					"&yr=" + document.getElementById("techYrLastUsed").getAttribute("value") +
					"&action=SaveTech";
				window.location.href = loc.replace("++", "%2B%2B");
			}
		}
		
		function ValidTechInfo(){
			var test = true;
			var rowind = document.getElementById("TechSkillTable").rows.length - 1;
			var regex = "/^\d+$/";
			if(document.getElementById("TechYrExperience").getAttribute("value") == ""){
				document.getElementById("TechSkillTable").rows[rowind].cells[3].innerHTML = "<input type='text' id='TechYrExperience' maxlength='4' size='2'>" +
					"<br><font color='#ff0000'>You must enter a valid number</font>";
				test = false;
			}else
				document.getElementById("TechSkillTable").rows[rowind].cells[3].innerHTML = "<input type='text' id='TechYrExperience' maxlength='4' size='2' " +
					"value='" + document.getElementById("TechYrExperience").getAttribute("value") + "'>";
			if(document.getElementById("techYrLastUsed").getAttribute("value") == ""){
				document.getElementById("TechSkillTable").rows[rowind].cells[2].innerHTML = "<input type='text' id='techYrLastUsed' maxlength='4' size='2'>" +
					"<br><font color='#ff0000'>You must enter a valid year</font>";
				test = false;
			}else
				document.getElementById("TechSkillTable").rows[rowind].cells[2].innerHTML = "<input type='text' id='techYrLastUsed' maxlength='4' size='2' " +
					"value='" + document.getElementById("techYrLastUsed").getAttribute("value") + "'>";
			return test;
		}
		
		function doTechCancel(i){
			document.getElementById("lock").setAttribute("value", "false");
			document.getElementById("TechSkillTable").deleteRow(i);
			document.getElementById("btnAddTech").style.display = "";
		}
		
		function createTechSkillInput(){
			var row = document.getElementById("TechSkillTable").insertRow();
			createCell(row, getNotMySkills());
			createCell(row, getProficiency("tech"));
			createCell(row, "<input type='text' id='techYrLastUsed' size='4' maxlength='4'>");
			createCell(row, "<input type='text' id='techYrExperience' size='2' maxlength='4'>");
			createCell(row, "<table border='0' cellpadding='1' cellspacing='0'><tr><td>" + makeTechSaveButton(row.rowIndex) + "</td><td>" + makeTechCancelButton(row.rowIndex) + "</td></tr></table>");
			document.getElementById("btnAddTech").style.display = "none";
		}
		
		function getProficiency(type){
			return "<select id=" + type + "proficiency>" +
				"<option value='1'>Novice</option>" +
				"<option value='2'>Intermediate</option>" +
				"<option value='3'>Expert</option>" +
				"</select>";
		}
			
		function makeTechSaveButton(rowNum){
			return "<input type='button' value='Save' class='buttonStyle' id='TechSave' onclick='doTechSave(" + rowNum + ")'>";
		}
		
		function makeTechEditButton(rowNum){
			return "<input type='button' value='Edit' class='buttonStyle' id='TechEdit" + rowNum + "' onclick='doTechEdit(" + rowNum + ")'>";
		}
		
		function makeTechEditSaveButton(rowNum){
			return "<input type='button' value='Save' class='buttonStyle' id='TechEditSave" + rowNum + "' onclick='doTechEditSave(" + rowNum + ")'>";
		}
		
		function makeTechEditCancelButton(rowNum){
			return "<input type='button' value='Cancel' class='buttonStyle' id='TechEditCancel" + rowNum + "' onclick='doTechEditCancel(" + rowNum + ")'>";
		}
		
		function makeTechDelButton(rowNum){
			return "<input type='button' value='Delete' class='buttonStyle' id='TechDel" + rowNum + "' onclick='doTechDel(" + rowNum + ")'>";
		}
		
		function makeTechCancelButton(rowNum){
			return "<input type='button' value='Cancel' class='buttonStyle' id='TechCancel" + rowNum + "' onclick='doTechCancel(" + rowNum + ")'>";
		}
		
		function createCell(row, content){
			var cell = row.insertCell();
			cell.innerHTML = content;
		}
		function createProdSkillInput(){
			var row = document.getElementById("ProdSkillsTable").insertRow();
			var prd = row.insertCell();
			var sub = row.insertCell();
			var prof = row.insertCell();
			var yr = row.insertCell();
			var exp = row.insertCell();
			var pad = row.insertCell();
			prd.innerHTML = CreateAddProdSelection();
			sub.innerHTML = "choose a product";
			prof.innerHTML = "<select id='level'><option value='1'>Novice</option><option value='2'>Intermediate</option><option value='3'>Expert</option></select>";
			exp.innerHTML = "<input type='text' id='exp' maxlength='4' size='2'>";
			yr.innerHTML = "<input type='text' id='yr' maxlength='4' size='2'>";
			pad.innerHTML = "<table border='0' cellpadding='1' cellspacing='0'><tr><td>" + 
				makeProdSaveButton() + "</td><td>" + makeProdCancelButton(row.rowIndex) + "</td></tr></table>";
			document.getElementById("productknowcount").setAttribute("value", row.rowIndex);
			document.getElementById("btnAddProd").style.display = "none";
		}
		function makeProdSaveButton(){
			return "<input type='button' id='saveprod' value='Save' onclick='doProdSave()' class='buttonStyle'>";
		}
		function makeProdCancelButton(i){
			return "<input type='button' id='cancelprod' value='Cancel' onclick='doCancelProd(" + i + ")' class='buttonStyle'>";
		}
		function makeProdEditSaveButton(rowNum){
			return "<input type='button' value='Save' class='buttonStyle' id='ProdEditSave" + rowNum + "' onclick='doProdEditSave(" + rowNum + ")'>";
		}
		function doProdSave(){
			if(ValidProdInfo()){
				var subsyscount = parseInt(document.getElementById("subsyscount").getAttribute("value"));
				var selectedsubsys = "";
				for(var i = 1; i <= subsyscount; i++){
					if(document.getElementById("Subsystem" + i).checked)
						selectedsubsys = selectedsubsys + document.getElementById("Subsystem" + i).getAttribute("value") + ",";
				}
				selectedsubsys = selectedsubsys.substring(0, selectedsubsys.length - 1);
				var loc = "skills_myskill.aspx?SubSysList=" + selectedsubsys +
					"&Product=" + document.getElementById("Products").options[document.getElementById("Products").selectedIndex].value +
					"&level=" + document.getElementById("level").options[document.getElementById("level").selectedIndex].value +
					"&Exp=" + document.getElementById("exp").getAttribute("value") +
					"&yr=" + document.getElementById("yr").getAttribute("value") +
					"&action=SaveProd";
				window.location.href = loc.replace("++", "%2B%2B");
			}
		}
		function doCancelProd(i){
			document.getElementById("lock").setAttribute("value", "false");
			document.getElementById("ProdSkillsTable").deleteRow();
			document.getElementById("btnAddProd").style.display = "";
		}
		function doProdEdit(i){
			if(document.getElementById("lock").getAttribute("value") == "false"){
				document.getElementById("lock").setAttribute("value", "true");
				var product = document.getElementById("ProdSkill" + i).getAttribute("value");
				var row = document.getElementById("ProdSkillsTable").rows[i];
				row.cells[1].innerHTML = CreateEditList(product);
				row.cells[2].innerHTML = getProficiency(i + "prod");
				row.cells[3].innerHTML = "<input type='text' id='ProdYrLastUsed" + i + "' size='4' maxlength='4' " +
					"value='" + document.getElementById("ProdYrLastUsed" + i).getAttribute("value") + "'>";
				row.cells[4].innerHTML = "<input type='text' id='ProdYrExperience" + i + "' size='2' maxlength='4' " +
					"value='" + document.getElementById("ProdYrExperience" + i).getAttribute("value") + "'>";
				row.cells[5].innerHTML = "<table border='0' cellspadding='0' cellspacing='1'>" +
					"<tr><td>" + makeProdEditSaveButton(i) + "</td><td>" + makeTechEditCancelButton(i) + "</td></tr></table>";
			}
		}
		function doProdEditSave(i){
			var product = document.getElementById("ProdSkill" + i).getAttribute("value");
			var subsyscount = parseInt(document.getElementById(product + "subsyscount").getAttribute("value"));
			var selectedsubsys = "";
			for(var j = 1; j <= subsyscount; j++){
				if(document.getElementById("Subsys" + j).checked)
					selectedsubsys = selectedsubsys + document.getElementById("Subsys" + j).getAttribute("value") + ",";
			}
			selectedsubsys = selectedsubsys.substring(0, selectedsubsys.length - 1);
			var loc = "skills_myskill.aspx?action=EditProd" +
				"&skill=" + product +
				"&sub=" + selectedsubsys +
				"&level=" + document.getElementById(i + "prodproficiency").getAttribute("value") +
				"&Exp=" + document.getElementById("ProdYrExperience" + i).getAttribute("value") +
				"&yr=" + document.getElementById("ProdYrLastUsed" + i).getAttribute("value");
			window.location.href = loc.replace("++", "%2B%2B");
		}
		function doProdEditCancel(i){
			window.location.href = "skills_myskill.aspx";
		}
		function doProdDel(i){
			if(document.getElementById("lock").getAttribute("value") == "false"){
				document.getElementById("lock").setAttribute("value", "true");
				var loc = "skills_myskill.aspx?action=DeleteProd" +
					"&skill=" + document.getElementById("ProdSkill" + i).getAttribute("value");
				window.location.href = loc.replace("++", "%2B%2B");
			}
		}
		function ValidProdInfo(){
			var test = true;
			var rowind = document.getElementById("productknowcount").getAttribute("value");
			if(document.getElementById("exp").getAttribute("value") == ""){
				document.getElementById("ProdSkillsTable").rows[rowind].cells[4].innerHTML = "<input type='text' id='exp' maxlength='4' size='2'>" +
					"<br><font color='#ff0000'>You must enter a valid number</font>";
				test = false;
			}else
				document.getElementById("ProdSkillsTable").rows[rowind].cells[4].innerHTML = "<input type='text' id='exp' maxlength='4' size='2' " +
					"value='" + document.getElementById("exp").getAttribute("value") + "'>";
			if(document.getElementById("yr").getAttribute("value") == ""){
				document.getElementById("ProdSkillsTable").rows[rowind].cells[3].innerHTML = "<input type='text' id='yr' maxlength='4' size='2'>" +
					"<br><font color='#ff0000'>You must enter a valid year</font>";
				test = false;
			}else
				document.getElementById("ProdSkillsTable").rows[rowind].cells[3].innerHTML = "<input type='text' id='yr' maxlength='4' size='2' " +
					"value='" + document.getElementById("yr").getAttribute("value") + "'>";
			return test;
		}
		function showSubDrop(rownum){
			var product = document.getElementById("Products").getAttribute("value");
			var tablerows = document.getElementById("ProdSkillsTable").rows;
			var cells = tablerows[document.getElementById("productknowcount").getAttribute("value")].cells;
			if(product == "none"){
				cells[1].innerHTML = "choose a product";
				return;
			}
			cells[1].innerHTML = CreateAddSubSelection(product);
			var count = document.getElementById(product + "subsyscount").getAttribute("value");
			document.getElementById("subsyscount").setAttribute("value", count);
		}
		</script>
	</HEAD>
	<body bgColor="#ffffcc" MS_POSITIONING="FlowLayout">
		<DIV id="skills">
			<form id="Form1" method="post" runat="server">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TBODY>
						<TR>
							<TD style="HEIGHT: 21px">
								<uc1:SmfTopNavButtons id="SmfTopNavButtons1" runat="server"></uc1:SmfTopNavButtons></TD>
						<TR>
							<TD style="HEIGHT: 21px" class="pagetitle">
								<hr>
								<P align="center"><asp:label id="lblUsername" runat="server">[Username]</asp:label>'s 
									Technical Skills and
									<BR>
									Product Knowledge Information
								</P>
								<hr>
							</TD>
						</TR>
						<TR>
							<TD align="center">
								<table class="editform" height="100%" cellSpacing="0" cellPadding="4" width="100%" bgColor="#eeeeee"
									border="0">
									<tr>
										<td style="FONT-WEIGHT: bold; COLOR: #ffffff; BACKGROUND-COLOR: #336699" align="left"
											bgColor="navy" colSpan="5">Skills Information
										</td>
									</tr>
									<tr>
										<td id="TechInfo" align="left" colSpan="5">
											<hr>
											<table class="editform" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<tr>
													<td align="left"><span class="infotitle">&nbsp;&nbsp;Technical Skills </span>
													</td>
													<td align="right"></td>
												</tr>
											</table>
											<div align="center"><asp:table id="TechSkillTable" runat="server" CssClass="editform" CellPadding="2" Width="90%">
													<asp:TableRow>
														<asp:TableHeaderCell Text="Skill" Width="25%"></asp:TableHeaderCell>
														<asp:TableHeaderCell Text="Proficiency" Width="25%"></asp:TableHeaderCell>
														<asp:TableHeaderCell Text="Year Last Used" Width="15%"></asp:TableHeaderCell>
														<asp:TableHeaderCell Text="Years Experience" Width="15%"></asp:TableHeaderCell>
														<asp:TableHeaderCell Width="20%">&nbsp;</asp:TableHeaderCell>
													</asp:TableRow>
												</asp:table>
												<table border="0" cellpadding="0" width="90%" class="editform" cellSpacing="0">
													<tr>
														<td colspan="5"><input type="button" value="Add" class="buttonStyle" id="btnAddTech" onclick="doAction('AddTech', 'TechSkillTable')"></td>
													</tr>
												</table>
											</div>
											<P>
												<table class="editform" id="table2" cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td>Additional Tech Skills:&nbsp;</td>
														<td id="AdditionalTechSkillsPanel"></td>
														<td>
															<asp:Label id="additionalTech" runat="server"></asp:Label>
															<asp:TextBox id="inAdditionalTech" runat="server" Visible="False"></asp:TextBox>
															<asp:Button id="btnAdditionalTech" runat="server" Width="88px" CssClass="buttonStyle" Text="Add/Modify"></asp:Button>&nbsp;
															<asp:Button id="Button2" runat="server" CssClass="buttonStyle" Visible="False" Text="Cancel"></asp:Button></td>
													</tr>
												</table>
											</P>
										</td>
									</tr>
									<tr>
										<td align="left" colSpan="5">
											<hr>
											<table class="editform" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<tr>
													<td align="left"><span class="infotitle">&nbsp;&nbsp;Product Knowledge </span>
													</td>
													<td align="right"></td>
												</tr>
											</table>
											<div align="center"><asp:table id="ProdSkillsTable" runat="server" BorderColor="1" CssClass="editform" CellPadding="2"
													Width="90%">
													<asp:TableRow>
														<asp:TableHeaderCell Text="Product" Width="20%"></asp:TableHeaderCell>
														<asp:TableHeaderCell Text="Subsystem" Width="20%"></asp:TableHeaderCell>
														<asp:TableHeaderCell Text="Proficiency" Width="20%"></asp:TableHeaderCell>
														<asp:TableHeaderCell Text="Year Last Used" Width="15%"></asp:TableHeaderCell>
														<asp:TableHeaderCell Text="Years Experience" Width="15%"></asp:TableHeaderCell>
														<asp:TableHeaderCell Width="10%">&nbsp;</asp:TableHeaderCell>
													</asp:TableRow>
												</asp:table>
												<table border="0" cellpadding="0" cellspacing="0" class="editform" width="90%">
													<tr>
														<td colspan="6"><input type="button" class="buttonStyle" value="Add" id="btnAddProd" onclick="doAction('AddProd', 'ProdSkillsTable')"></td>
													</tr>
												</table>
											</div>
											<DIV align="center">&nbsp;</DIV>
											<DIV align="left">
												<table class="editform" id="" cellpadding="0" cellspacing="0" border="0" align="center">
													<tr>
														<td><FONT color="#ff0000" size="3">Note: upon choosing a product you must also select 
																all applicable subsystem/s.</FONT></td>
													</tr>
												</table>
											</DIV>
											<DIV align="left">&nbsp;</DIV>
											<DIV align="left">
												<TABLE class="editform" id="Table3" cellSpacing="0" cellPadding="0" border="0">
													<TR>
														<TD>
															<P>Additional&nbsp;Product Skills:&nbsp;</P>
														</TD>
														<TD id="Td1"></TD>
														<TD>
															<asp:Label id="additionalProd" runat="server"></asp:Label>
															<asp:TextBox id="inAdditionalProd" runat="server" Visible="False"></asp:TextBox>
															<asp:Button id="btnAdditionalProd" runat="server" Width="88px" CssClass="buttonStyle" Text="Add/Modify"></asp:Button>&nbsp;
															<asp:Button id="Button3" runat="server" CssClass="buttonStyle" Visible="False" Text="Cancel"></asp:Button></TD>
													</TR>
												</TABLE>
											</DIV>
											<hr>
										</td>
									</tr>
									<tr>
										<td>
											<P align="center"><asp:LinkButton ID="btnBack" Runat="server">Back</asp:LinkButton></P>
										</td>
									</tr>
								</table>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
			</form>
		</DIV>
		<input type="hidden" id="productknowcount" value="0"><input type="hidden" id="subsyscount" value="0">
		<input type="hidden" id="lock" value="false">
	</body>
</HTML>

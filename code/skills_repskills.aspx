<%@ Register TagPrefix="uc1" TagName="SmfReportTab" Src="SmfReportTab.ascx" %>
<%@ Page language="c#" Codebehind="skills_repskills.aspx.cs" AutoEventWireup="false" Inherits="SmfRewriteProject.skills_repskills" %>
<%@ Register TagPrefix="uc1" TagName="SmfTopNavButtons" Src="SmfTopNavButtons.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>My Skills</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="skills_stylesheet.css" type="text/css" rel="stylesheet">
		<script lang="javascript">
			//This function opens a modeless window
			function openName(aWindow){
				window.showModelessDialog(aWindow,window,'dialogWidth:550px;dialogHeight:500px;scroll:yes;edge:sunken;status:no;resizable:yes;help:no;center:yes');
			}
		</script>
	</HEAD>
	<BODY bgColor="#ffffcc">
		&nbsp;&nbsp;
		<div id="skills">
			<form id="Form1" method="post" runat="server">
				<DIV align="center">
					<TABLE id="Table10" height="20" cellSpacing="0" cellPadding="0" width="80%" align="center"
						bgColor="#ffffff">
						<TR>
							<TD vAlign="middle" noWrap align="center" bgColor="#ffffcc" height="60">
								<P align="right">&nbsp;
									<uc1:smftopnavbuttons id="SmfTopNavButtons1" runat="server"></uc1:smftopnavbuttons><BR>
								</P>
							</TD>
						</TR>
					</TABLE>
				</DIV>
				<center><uc1:smfreporttab id="SmfReportTab1" runat="server" tabactive="0"></uc1:smfreporttab></center>
				<P align="center">
					<TABLE id="Table2" height="24" cellSpacing="1" cellPadding="1" width="80%" border="1">
						<TR>
							<TD align="center" bgColor="#ffffcc">
								<TABLE id="Table4" style="BORDER-COLLAPSE: collapse" borderColor="black" height="91" cellSpacing="0"
									cellPadding="4" width="710" border="0">
									<TR>
										<TD class="pagetitle" noWrap align="center" width="100%" bgColor="#ffffcc" colSpan="2"
											height="123">
											<P align="center">
											<P align="center">
												<DIV align="center">
													<HR SIZE="2">
												</DIV>
											<P align="center"><FONT face="Verdana" color="#003399" size="4"><STRONG>Skills Summary 
														Report</STRONG></FONT>
											</P>
											<DIV align="center">
												<HR>
											</DIV>
											<P align="center"></P>
											<P align="center">&nbsp;</P>
											<P align="center">
												<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="1">
													<TR>
														<TD>
															<P align="center">Technical Skills</P>
														</TD>
													</TR>
												</TABLE>
											</P>
											<P>
												<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="1">
													<TR>
														<TD>
															<P align="center"><asp:datagrid id="dgResults" runat="server" Width="100%"></asp:datagrid></P>
														</TD>
													</TR>
												</TABLE>
											</P>
											<P>
												<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="1">
													<TR>
														<TD>
															<P align="center">Product Knowledge</P>
														</TD>
													</TR>
												</TABLE>
											</P>
											<P align="center">
												<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="1">
													<TR>
														<TD>
															<P align="center"><asp:datagrid id="dgProducts" runat="server" Width="100%"></asp:datagrid></P>
														</TD>
													</TR>
												</TABLE>
											</P>
											<P>
												<TABLE id="Table1">
													<TR>
														<TD width="60">
															<P><asp:linkbutton id="LinkButton2" runat="server">ExtractExcel</asp:linkbutton></P>
														</TD>
														<TD><asp:linkbutton id="hBack" runat="server">Back</asp:linkbutton></TD>
													</TR>
												</TABLE>
												&nbsp;
												<asp:label id="lblExcel" runat="server"></asp:label></P>
											<P>&nbsp;</P>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
					</TABLE>
				</P>
			</form>
		</div>
	</BODY>
</HTML>

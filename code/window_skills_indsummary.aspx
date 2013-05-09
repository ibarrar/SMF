<%@ Page language="c#" Codebehind="window_skills_indsummary.aspx.cs" AutoEventWireup="false" Inherits="SmfRewriteProject.window_skills_indsummary" %>
<%@ Register TagPrefix="uc1" TagName="SmfIndSummaryView" Src="SmfIndSummaryView.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Individual Summary</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="skills_stylesheet.css" type="text/css" rel="stylesheet">
		<base target="_self">
		<LINK href="../js/skills_stylesheet.css" type="text/css" rel="Stylesheet">
		<LINK href="../js/css.aspx" type="text/css" rel="Stylesheet">
		<LINK href="../js/msdn.css" type="text/css" rel="Stylesheet">
		<LINK href="../js/mag.css" type="text/css" rel="Stylesheet">
	</HEAD>
	<body bottomMargin="0" bgColor="#ffffcc" leftMargin="0" topMargin="0" rightMargin="0"
		onload="javascript:window.scrollTo(0,0)">
		<div id="skills">
			<form id="PopUp_IndSumm" method="post" runat="server">
				<table width="javascript: screen.width">
					<tr>
						<td>
							<div id="skills">
								<center>
									<table class="editform" border="0">
										<tr>
											<td class="editform" align="center">
												<uc1:SmfIndSummaryView id="SmfIndSummaryView1" runat="server"></uc1:SmfIndSummaryView>
											</td>
										</tr>
										<tr>
											<td class="editform" align="center" colSpan="2">
												<asp:LinkButton id="lbClose" runat="server">Close</asp:LinkButton></td>
										</tr>
									</table>
								</center>
							</div>
						</td>
					</tr>
				</table>
			</form>
		</div>
	</body>
</HTML>

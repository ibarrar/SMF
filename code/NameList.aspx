<%@ Page language="c#" Codebehind="NameList.aspx.cs" AutoEventWireup="True" Inherits="SmfRewriteProject.NameList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SkillsRepSummary</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Report.css" type="text/css" rel="stylesheet">
		<script lang="javascript">
			//This function opens a modeless window
			function openName(aWindow){
				window.showModelessDialog(aWindow,window,'dialogWidth:765px;dialogHeight:400px;scroll:yes;edge:sunken;status:no;resizable:no;help:no;center:yes');
			}
		</script>
	</HEAD>
	<body bgColor="#ffffcc" MS_POSITIONING="GridLayout">
		<form id="frmSearchInfo" name="frmSearchInfo" runat="server">
			<center></center>
			<center>
				<table style="WIDTH: 502px; HEIGHT: 345px" cellSpacing="0" cellPadding="0" align="center">
					<TR>
						<td class="pagetitle" noWrap align="center" colSpan="2">
							<P>
							<P></P>
							<P>&nbsp;</P>
							<P><FONT face="Verdana" color="#003399" size="4"><STRONG>List of Employees with Skill in</STRONG></FONT>
								<asp:label id="skillType" runat="server" Font-Bold="True" Height="14px" Width="85px">skillType</asp:label></P>
							<P align="center">&nbsp; <STRONG>(Proficiency level : </STRONG>
								<asp:label id="skillLevel" runat="server" Font-Bold="True" Height="16px" Width="80px">skillLevel</asp:label><STRONG>)</STRONG></P>
							<P>
							<P></P>
							<P><asp:datagrid id="dgNames" runat="server" Width="250px" HorizontalAlign="Center" onselectedindexchanged="dgNames_SelectedIndexChanged"></asp:datagrid><br>
							</P>
							<CENTER>&nbsp;</CENTER>
							<br>
							<br>
						</td>
					</TR>
				</table>
			</center>
			<center>
				<table>
					<tr>
						<!--<td style="WIDTH: 1px"><asp:linkbutton id="LinkButton1" runat="server">Close</asp:linkbutton></td>-->
						<td style="WIDTH: 1px"><a href="#" onclick="window.close()">Close</a></td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>

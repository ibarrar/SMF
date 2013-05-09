<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SmfReportTab.ascx.cs" Inherits="SmfRewriteProject.SmfReportTab" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<div id="tabmenusrch">
	<center>
		<asp:linkbutton id="lnk1" Runat="server" CssClass="inactive">Skills Summary Report</asp:linkbutton>
		<asp:linkbutton id="lnk2" Runat="server" CssClass="inactive">Technical Skills Detailed Report</asp:linkbutton>
		<asp:linkbutton id="lnk3" Runat="server" CssClass="inactive">Product Knowledge Detailed Report</asp:linkbutton>
		<asp:linkbutton id="lnk4" Runat="server" CssClass="inactive">Employee Travel Documentation</asp:linkbutton>
	</center>
</div>
<asp:Table id="tblTab" runat="server" CssClass="tabmenusrch" width="100%" HorizontalAlign="Center"
	BorderColor="0"></asp:Table>

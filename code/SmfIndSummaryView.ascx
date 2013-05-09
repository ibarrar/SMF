<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SmfIndSummaryView.ascx.cs" Inherits="SmfRewriteProject.SmfIndSummaryView" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="../js/mag.css" type="text/css" rel="Stylesheet">
<table height="1" width="1" bgColor="#f0f0f0">
	<tr>
		<td width="1" height="1">
			<div id="skills">
				<center>
					<table class="editform" height="1" width="1" border="0">
						<tr>
							<td class="editform" align="center">
								<table class="editform" style="BORDER-COLLAPSE: collapse" borderColor="black" cellSpacing="0"
									cellPadding="4" width="100%" bgcolor="#eeeeee" border="0">
									<tr>
										<td id="EmpInfo" style="FONT-WEIGHT: bold; COLOR: #ffffff; BACKGROUND-COLOR: #336699"
											align="left" bgColor="navy" colSpan="2">Employee Information</td>
									</tr>
									<tr>
										<td align="left" width="30%"><span class="infofield">&nbsp;&nbsp;Employee Name </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblEmpName" runat="server"></asp:label></span></td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;Office </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblOffice" runat="server"></asp:label></span></td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;Current Team/Role </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblTeam" runat="server"></asp:label></span></td>
									</tr>
									<TR>
										<TD align="left" width="200">&nbsp; Sub-Team</TD>
										<TD align="left">
											<asp:Label id="lblSubTeam" runat="server">[lblSubTeam]</asp:Label></TD>
									</TR>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;Navitaire Start Date </span>
										</td>
										<td align="left"><asp:label id="lblNavDate" runat="server"></asp:label></td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;Nick Name </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblNickName" runat="server"></asp:label></span></td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;Gender </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblGender" runat="server"></asp:label></span></td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;Birthday </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblBday" runat="server"></asp:label></span></td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;Home Number </span>
										</td>
										<td align="left"><asp:label id="lblHomeNum" runat="server"></asp:label></td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;Cellphone Number </span>
										</td>
										<td align="left"><asp:label id="lblCellNum" runat="server"></asp:label></td>
									</tr>
									<tr>
										<td noWrap align="left" width="200"><span class="infofield">&nbsp;&nbsp;Other E-mail 
												Address </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblOtherEmail" runat="server"></asp:label></span></td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;Home Address </span>
										</td>
										<td align="left" width="450"><span class="infoentry"><asp:label id="lblHomeAdd" runat="server"></asp:label></span></td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;City </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblCity" runat="server"></asp:label></span></td>
									</tr>
									<tr>
										<td style="FONT-WEIGHT: bold; COLOR: #ffffff; BACKGROUND-COLOR: #336699" align="left"
											bgColor="navy" colSpan="2">Academic Background</td>
									</tr>
									<tr>
										<td align="left" colSpan="2">
											<hr>
											<span class="infotitle">&nbsp;&nbsp;Undergraduate Information </span>
											<hr>
										</td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;School </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblUGSchool" runat="server"></asp:label></span></td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;Degree </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblUGDegree" runat="server"></asp:label></span></td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;Year </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblUGYear" runat="server"></asp:label></span></td>
									</tr>
									<tr>
										<td align="left" colSpan="2">
											<hr>
											<span class="infotitle">&nbsp;&nbsp;Graduate Information </span>
											<hr>
										</td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;School </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblGSSchool" runat="server"></asp:label></span></td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;Degree </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblGSDegree" runat="server"></asp:label></span></td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;Year </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblGSYear" runat="server"></asp:label></span></td>
									</tr>
									<tr>
										<td style="FONT-WEIGHT: bold; COLOR: #ffffff; BACKGROUND-COLOR: #336699" align="left"
											bgColor="navy" colSpan="2">Passport Information</td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;Passport Number: </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblPassport" runat="server"></asp:label></span></td>
									</tr>
									<tr>
										<td noWrap align="left" width="250"><span class="infofield">&nbsp;&nbsp;Passport 
												Expiration Date: </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblExpDate" runat="server"></asp:label></span></td>
									</tr>
									<tr>
										<td align="left" width="200"><span class="infofield">&nbsp;&nbsp;Valid Visa: </span>
										</td>
										<td align="left"><span class="infoentry"><asp:label id="lblVisa" runat="server"></asp:label></span></td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td class="editform" align="center" colSpan="2">
								<table class="editform" height="100%" cellSpacing="0" cellPadding="4" width="100%" bgColor="#eeeeee"
									border="0">
									<tr>
										<td style="FONT-WEIGHT: bold; COLOR: #ffffff; BACKGROUND-COLOR: #336699" align="left"
											bgColor="navy" colSpan="5">Skills Information</td>
									</tr>
									<tr>
										<td id="TechInfo" align="left" colSpan="5">
											<hr>
											<span class="infotitle">&nbsp;&nbsp;Technical Skills </span>
											<hr>
											<asp:datagrid id="dgTechnicalSkills" runat="server" Width="704px" GridLines="None" BackColor="#F0F0F0"
												AutoGenerateColumns="False">
												<HeaderStyle Font-Bold="True"></HeaderStyle>
												<Columns>
													<asp:BoundColumn DataField="sSkill"></asp:BoundColumn>
													<asp:TemplateColumn HeaderText="Level of Proficiency">
														<ItemTemplate>
															<asp:Label id="lblLvl" runat="server"></asp:Label>
														</ItemTemplate>
														<EditItemTemplate>
															<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.sLevel") %>'>
															</asp:TextBox>
														</EditItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="Year last used (YYYY)">
														<ItemTemplate>
															<asp:Label id="lblYrUsed" runat="server"></asp:Label>
														</ItemTemplate>
														<EditItemTemplate>
															<asp:TextBox id=TextBox2 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.sDateLastUsed") %>'>
															</asp:TextBox>
														</EditItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="sYrExperience" HeaderText="Experience in Years"></asp:BoundColumn>
												</Columns>
											</asp:datagrid>
											<P><asp:label id="lblAdditionalSkills" runat="server" Font-Italic="True" ForeColor="#8080FF"></asp:label></P>
										</td>
									</tr>
									<tr>
										<td id="TechInfo" align="left" colSpan="5">
											<hr>
											<span class="infotitle">&nbsp;&nbsp;Product Knowledge </span>
											<hr>
											<asp:datagrid id="dgPrdKnowledge" runat="server" Width="704px" GridLines="None" BackColor="#F0F0F0"
												AutoGenerateColumns="False">
												<Columns>
													<asp:TemplateColumn>
														<ItemStyle BackColor="#F0F0F0"></ItemStyle>
														<ItemTemplate>
															<P>
																<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" bgColor="#f0f0f0" border="0">
																	<TR>
																		<TD style="WIDTH: 100px" width="100" bgColor="#f0f0f0">
																			<asp:Label id=lblProduct runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.sSkillType") %>'>
																			</asp:Label></TD>
																		<TD width="28%" bgColor="#f0f0f0">
																			<asp:Label id="lblLevel" runat="server"></asp:Label></TD>
																		<TD width="30%" bgColor="#f0f0f0">
																			<asp:Label id="lblYrLastUsed" runat="server"></asp:Label></TD>
																		<TD bgColor="#f0f0f0">
																			<asp:Label id=lblYrsExp runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.sYrExperience") %>'>
																			</asp:Label></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 77px" bgColor="#f0f0f0"></TD>
																		<TD bgColor="#f0f0f0" colSpan="3">
																			<asp:Label id="lblProd" runat="server" BackColor="#f0f0f0" Font-Italic="True" ForeColor="#8080FF"
																				Font-Size="X-Small"></asp:Label></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 77px" bgColor="#f0f0f0"></TD>
																		<TD bgColor="#f0f0f0" colSpan="3">
																			<P>
																				<asp:DataGrid id="dgSubsystem" runat="server" BackColor="#f0f0f0" AutoGenerateColumns="False"
																					ShowHeader="False" BorderStyle="Solid" BorderWidth="0px">
																					<Columns>
																						<asp:TemplateColumn>
																							<ItemStyle BackColor="#f0f0f0"></ItemStyle>
																							<ItemTemplate>
																								-
																								<asp:Label id="lblSubsystem" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.sSkill") %>'>
																								</asp:Label>
																							</ItemTemplate>
																							<EditItemTemplate>
																								<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.sSkill") %>' ID="Textbox3">
																								</asp:TextBox>
																							</EditItemTemplate>
																						</asp:TemplateColumn>
																					</Columns>
																				</asp:DataGrid></P>
																		</TD>
																	</TR>
																</TABLE>
															</P>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
											</asp:datagrid>
											<P><asp:label id="lblAdditionalPrdKnowledge" runat="server" Font-Italic="True" ForeColor="#8080FF"></asp:label></P>
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
					<TABLE id="Table1" style="WIDTH: 720px; HEIGHT: 1px" cellSpacing="1" cellPadding="1" bgColor="#f0f0f0"
						border="0">
						<TR>
							<td style="FONT-WEIGHT: bold; COLOR: #ffffff; HEIGHT: 29px; BACKGROUND-COLOR: #336699"
								align="left" bgColor="navy">Certificate/Licenses Information</td>
						</TR>
						<TR>
							<td bgColor="#f0f0f0"><asp:datagrid id="dgCerts" runat="server" Width="712px" GridLines="None" BackColor="#F0F0F0" AutoGenerateColumns="False">
									<HeaderStyle Font-Bold="True"></HeaderStyle>
									<Columns>
										<asp:BoundColumn ItemStyle-Width="40%" DataField="Certification" HeaderText=""></asp:BoundColumn>
										<asp:BoundColumn ItemStyle-Width="30%" DataField="Date" HeaderText="Date Acquired"></asp:BoundColumn>
										<asp:BoundColumn ItemStyle-Width="30%" DataField="Sponsor" HeaderText="Sponsor"></asp:BoundColumn>
									</Columns>
								</asp:datagrid></td>
						</TR>
					</TABLE>
				</center>
			</div>
		</td>
	</tr>
</table>

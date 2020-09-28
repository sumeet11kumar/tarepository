<%@ Page Title="" Language="C#" MasterPageFile="~/TAADM/adminWebMaster.Master" AutoEventWireup="true" CodeBehind="adminDashboard.aspx.cs" Inherits="TAAPP16_12_2019.TAADM.adminDashboard" ViewStateEncryptionMode="Always" EnableViewStateMac="true" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <%--<div class="container">--%>
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-12">
                    <h4 class="mb-3">Dashboard</h4>
                    <form class="needs-validation" runat="server" id="form1" autocomplete="off">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <HeaderTemplate>
                                <table class="table table-bordered">
                                    <tr><td class="headbg"><strong>SNo</strong></td><td class="headbg"><strong>Districts</strong></td><td class="headbg"><strong>Threat Posters</strong></td><td colspan="4" class="headbg"><strong>Gernade Attack</strong></td><td colspan="4" class="headbg"><strong>IED/Explosion</strong></td><td colspan="6" class="headbg"><strong>Cross Firing/Encounter</strong></td><td colspan="6" class="headbg"><strong>Random Firing</strong></td></tr>
                                    <tr><td colspan="3" class="headbg"></td><td colspan="2" class="headbg"><strong>Civilian</strong></td><td colspan="2" class="headbg"><strong>Forces</strong></td><td colspan="2" class="headbg"><strong>Civilian</strong></td><td colspan="2" class="headbg"><strong>Forces</strong></td><td colspan="2" class="headbg"><strong>Civilian</strong></td><td colspan="2" class="headbg"><strong>Forces</strong></td><td colspan="2" class="headbg"><strong>Terrorist/OGWs</strong></td><td colspan="2" class="headbg"><strong>Civilian</strong></td><td colspan="2" class="headbg"><strong>Forces</strong></td><td colspan="2" class="headbg"><strong>Terrorist/OGWs</strong></td></tr>
                                    <tr><td colspan="3" class="headbg"></td><td class="headbg"><strong>Injured</strong></td><td class="headbg"><strong>Dead</strong></td><td class="headbg"><strong>Injured</strong></td><td class="headbg"><strong>Dead</strong></td><td class="headbg"><strong>Injured</strong></td><td class="headbg"><strong>Dead</strong></td><td class="headbg"><strong>Injured</strong></td><td class="headbg"><strong>Dead</strong></td><td class="headbg"><strong>Injured</strong></td><td class="headbg"><strong>Dead</strong></td><td class="headbg"><strong>Injured</strong></td><td class="headbg"><strong>Dead</strong></td><td class="headbg"><strong>Arrested</strong></td><td class="headbg"><strong>Dead</strong></td><td class="headbg"><strong>Injured</strong></td><td class="headbg"><strong>Dead</strong></td><td class="headbg"><strong>Injured</strong></td><td class="headbg"><strong>Dead</strong></td><td class="headbg"><strong>Arrested</strong></td><td class="headbg"><strong>Dead</strong></td></tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("str") as String %>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <%--<asp:Chart ID="Chart1" runat="server" Height="300px" Width="400px" Visible="false">
                        <Titles>
                            <asp:Title ShadowOffset="3" Name="Items" />
                        </Titles>
                        <Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                                LegendStyle="Row" />
                        </Legends>
                        <Series>
                            <asp:Series Name="Default" />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                        </ChartAreas>
                    </asp:Chart>--%>
                    </form>
                </div>
            </div>
        </div>
    <%--</div>--%>
</asp:Content>

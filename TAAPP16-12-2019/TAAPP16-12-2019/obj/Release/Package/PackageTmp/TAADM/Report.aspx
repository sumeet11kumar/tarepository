<%@ Page Title="" Language="C#" MasterPageFile="~/TAADM/adminWebMaster.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="TAAPP16_12_2019.TAADM.Report" ViewStateEncryptionMode="Always" EnableViewStateMac="true" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
    <link href="css/custom.css" rel="stylesheet" />
    <script src="js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src='js/bootstrap.min.js'></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" media="screen" />
    <script type="text/javascript">
        function ShowPopup(body) {
            $("#MyPopup .modal-body").html(body);
            $("#MyPopup").modal("show");
        }
    </script>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=panelReport.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<style tyle="text/css">table{border-collapse:collapse;border:solid 1px #a4a4a3}table tr td{border:solid 1px #a4a4a3}.headingrow {background-color:#ebebeb;font-weight:bold;font-family:Arial;font-size:13px;padding:6px;}.celldata {padding:6px;color:#4e4e4e;background-color:#ffffff;font-family:Arial;font-size:13px;border:solid 1px #a4a4a3;}</style>');
            printWindow.document.write('</head><body>');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <!-- Modal Popup -->
    <div id="MyPopup" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <%--<div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">Message...</h4>
                    </div>--%>
                <div class="modal-body">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- End Modal Popup -->
    <div class="container">

        <div class="row">
            <div class="col-md-12">
                <h4 class="mb-3">Report</h4>
                <form class="needs-validation" runat="server" id="form1" autocomplete="off">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-md-4 mb-3">
                                    <label for="country">District<span class="required"> *</span></label>
                                    <asp:DropDownList ID="ddldistrict" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged"></asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="ddldistrictRequiredFieldValidator1" runat="server" ErrorMessage="*Required" InitialValue="0" ValidationGroup="attack" ControlToValidate="ddldistrict" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label for="country">Tehsil</label>
                                    <asp:DropDownList ID="ddltehsil" CssClass="form-control" runat="server"></asp:DropDownList>

                                </div>
                                <div class="col-md-4 mb-3">
                                    <label for="country">
                                        <br />
                                        <br />
                                        <br />
                                    </label>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Show" CssClass="btn btn-primary" ValidationGroup="attack" OnClick="btnSubmit_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <asp:Panel ID="Panel1" runat="server" Visible="false">
                                    <div class="col-md-12 mb-3">
                                        <a style="text-decoration:none; font-size:14px;font-weight:bold;color:#4e4e4e;" href="#" onclick="PrintPanel();"><i class="icon-printer"></i></a>
                                         
                                    </div>
                                </asp:Panel>

                                <div class="col-md-12 mb-3">
                                    <div style="width: 100%; overflow-y: scroll; overflow-x:scroll; height: auto;">
                                        <asp:Panel ID="panelReport" runat="server">
                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <HeaderTemplate>
                                                    <table class="table table-striped table-bordered">
                                                        <tr class="">
                                                            <td colspan="17" align="center" valign="middle" class="headingrow"><strong>Terrorist Attack Report</strong></td>
                                                        </tr>
                                                        <tr class="">
                                                            <td align="left" valign="middle" class="headingrow"><strong>S.No.</strong></td>
                                                            <td align="left" valign="middle" class="headingrow"><strong>Date</strong></td>
                                                            <td align="left" valign="middle" class="headingrow"><strong>Incident</strong></td>
                                                            <td align="left" valign="middle" class="headingrow"><strong>No of Terrorist Involved</strong></td>
                                                            <td align="left" valign="middle" class="headingrow"><strong>Name of Terrorist Group Involved</strong></td>
                                                            <td align="left" valign="middle" class="headingrow"><strong>District</strong></td>
                                                            <td align="left" valign="middle" class="headingrow"><strong>Location</strong></td>
                                                            <td align="center" valign="middle" colspan="2" class="headingrow"><strong>Casualities</strong></td>
                                                            <td align="center" valign="middle" colspan="2" class="headingrow"><strong>Injuries</strong></td>
                                                            <td align="center" valign="middle" colspan="3" class="headingrow"><strong>Terrorist/OGW</strong></td>
                                                            <td align="left" valign="middle" class="headingrow"><strong>Ammunation Recovered</strong></td>
                                                            <td align="left" valign="middle" class="headingrow"><strong>Infrastructure/Property Affected</strong></td>
                                                            <td align="left" valign="middle" class="headingrow"><strong>Remarks</strong></td>
                                                        </tr>
                                                        <tr class="">
                                                            <td colspan="7" class="headingrow"></td>
                                                            <td align="center" valign="middle" class="headingrow"><strong>Civilian</strong></td>
                                                            <td align="center" valign="middle" class="headingrow"><strong>Forces</strong></td>
                                                            <td align="center" valign="middle" class="headingrow"><strong>Civilian</strong></td>
                                                            <td align="center" valign="middle" class="headingrow"><strong>Forces</strong></td>
                                                            <td align="center" valign="middle" class="headingrow"><strong>Death</strong></td>
                                                            <td align="center" valign="middle" class="headingrow"><strong>Injured</strong></td>
                                                            <td align="center" valign="middle" class="headingrow"><strong>Arrested</strong></td>
                                                            <td colspan="3" class="headingrow"></td>
                                                        </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="datarow">
                                                        <td align="left" valign="middle" class="celldata"><%# Container.ItemIndex + 1 %></td>
                                                        <td align="left" valign="middle" class="celldata"><%# HttpUtility.HtmlEncode(Eval("DateAndTimeofIncident").ToString()) %></td>
                                                        <td align="left" valign="middle" class="celldata"><%# HttpUtility.HtmlEncode(Eval("IncidentName").ToString()) %></td>
                                                        <td align="left" valign="middle" class="celldata"><%# HttpUtility.HtmlEncode(Eval("NumberofTerroristInvolved").ToString()) %></td>
                                                        <td align="left" valign="middle" class="celldata"><%# HttpUtility.HtmlEncode(Eval("TerroristGroup").ToString()) %></td>
                                                        <td align="left" valign="middle" class="celldata"><%# HttpUtility.HtmlEncode(Eval("DistrictName").ToString()) %></td>
                                                        <td align="left" valign="middle" class="celldata"><%# HttpUtility.HtmlEncode(Eval("LocationName").ToString()) %></td>
                                                        <td align="left" valign="middle" class="celldata"><%# HttpUtility.HtmlEncode(Eval("CivilianCasuality").ToString()) %></td>
                                                        <td align="left" valign="middle" class="celldata"><%# HttpUtility.HtmlEncode(Eval("ForceCasuality").ToString()) %></td>
                                                        <td align="left" valign="middle" class="celldata"><%# HttpUtility.HtmlEncode(Eval("CivilianInjury").ToString()) %></td>
                                                        <td align="left" valign="middle" class="celldata"><%# HttpUtility.HtmlEncode(Eval("ForceInjury").ToString()) %></td>
                                                        <td align="left" valign="middle" class="celldata"><%# HttpUtility.HtmlEncode(Eval("TerroristDeath").ToString()) %></td>
                                                        <td align="left" valign="middle" class="celldata"><%# HttpUtility.HtmlEncode(Eval("TerroristInjured").ToString()) %></td>
                                                        <td align="left" valign="middle" class="celldata"><%# HttpUtility.HtmlEncode(Eval("TerroristArrested").ToString()) %></td>
                                                        <td align="left" valign="middle" class="celldata"><%# HttpUtility.HtmlEncode(Eval("AmunitionRecovered").ToString()) %></td>
                                                        <td align="left" valign="middle" class="celldata"><%# HttpUtility.HtmlEncode(Eval("InfectedArea").ToString()) %></td>
                                                        <td align="left" valign="middle" class="celldata"><%# HttpUtility.HtmlEncode(Eval("Remarks").ToString()) %></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </form>
            </div>
        </div>
    </div>

</asp:Content>

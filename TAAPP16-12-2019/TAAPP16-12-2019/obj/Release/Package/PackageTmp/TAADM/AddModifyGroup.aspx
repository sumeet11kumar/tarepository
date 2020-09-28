<%@ Page Title="" Language="C#" MasterPageFile="~/TAADM/adminWebMaster.Master" AutoEventWireup="true" CodeBehind="AddModifyGroup.aspx.cs" Inherits="TAAPP16_12_2019.TAADM.AddModifyGroup" ViewStateEncryptionMode="Always" EnableViewStateMac="true" %>
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
                <h4 class="mb-3">Add/Modify Group Name</h4>
                <form class="needs-validation" runat="server" id="form1" autocomplete="off">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <table align="center">
                                     
                                    <tr>
                                        <td>
                                            <div class="col-md-12 mb-3">
                                                <label>Group Name<span class="required"> *</span></label>
                                                <asp:TextBox ID="TextBoxGroup" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="TextBoxGroupRequiredFieldValidator1" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxGroup" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>

                            <div class="row">
                                <div class="col-md-12 mb-3">
                                    <center>
                                       <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="attack" OnClick="btnSubmit_Click"/>
                                    </center>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12 mb-3">
                                    <table align="center">
                                        <tr>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="locationGridView" CssClass="table table-striped table-bordered table-condensed" runat="server" EmptyDataText="No Record Found" AllowPaging="True" AutoGenerateColumns="False" Width="160px" OnPageIndexChanging="locationGridView_PageIndexChanging" OnRowCommand="locationGridView_RowCommand" PageSize="5">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Incident Type">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncident" runat="server" Text='<%# Server.HtmlEncode(Eval("GroupName") as string) %>'></asp:Label>
                                                                <asp:HiddenField ID="hfIncidentId" runat="server" Value='<%# Server.HtmlEncode(Eval("GroupId") as string) %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update_1" CommandArgument='<%# HttpUtility.HtmlEncode(Eval("GroupId").ToString()) %>'>Select</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerSettings PageButtonCount="5" />
                                                    <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <%--<asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />--%>
                            <asp:PostBackTrigger ControlID="btnSubmit" />
                        </Triggers>
                    </asp:UpdatePanel>
                </form>
            </div>
        </div>
    </div>
</asp:Content>

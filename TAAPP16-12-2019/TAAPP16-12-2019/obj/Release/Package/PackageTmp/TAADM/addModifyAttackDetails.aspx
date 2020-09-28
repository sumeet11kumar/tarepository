<%@ Page Title="" Language="C#" MasterPageFile="~/TAADM/adminWebMaster.Master" AutoEventWireup="true" CodeBehind="addModifyAttackDetails.aspx.cs" Inherits="TAAPP16_12_2019.TAADM.addModifyAttackDetails" ViewStateEncryptionMode="Always" EnableViewStateMac="true" EnableEventValidation="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
    <script>
        function ShowWindow(url) {
            window.open(url, "popup_window", "width=600,height=400,top=100,left=100,toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no");
        }
    </script>
    <%--<script type="text/javascript" src='js/jquery.min.js'></script>
    <script>
        $(function () {
            $("[id*=lnkView]").click(function () {
                var rowIndex = $(this).closest("tr")[0].rowIndex;
                window.open("InsertSubDetails.aspx?rowIndex=" + rowIndex, "popup_window", "width=600,height=400,top=100,left=100,toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no");
            });
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceHolder" runat="server">
    <form class="needs-validation" runat="server" id="form1" autocomplete="off">
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <!-- Modal Popup -->
                <!-- Small Message Dialog -->
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
                            <h4 class="mb-3">Add/Modify Details</h4>
                            <div class="row">
                                <div class="col-md-4 mb-3">
                                    <label for="country">District<span class="required"> *</span></label>
                                    <asp:DropDownList ID="ddldistrict" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ddldistrictRequiredFieldValidator1" runat="server" ErrorMessage="*Required" InitialValue="0" ValidationGroup="attack" ControlToValidate="ddldistrict" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label for="country">Tehsil</label>
                                    <asp:DropDownList ID="ddltehsil" CssClass="form-control" runat="server"></asp:DropDownList>
                                    
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label>Date(dd-MMM-yyyy) &amp; Time of Incident<span class="required"> *</span></label>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="TextBoxDatetimeofIncident" autocomplete="off" CssClass="form-control" runat="server" Width="120px"></asp:TextBox></td>
                                            <td>
                                                <asp:DropDownList ID="ddlHour" runat="server" CssClass="form-control" Width="70px"></asp:DropDownList></td>
                                            <td>
                                                <asp:DropDownList ID="ddlMinute" runat="server" CssClass="form-control" Width="70px"></asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxDatetimeofIncident" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="ddlHourRequiredFieldValidator2" runat="server" ErrorMessage="*Required" InitialValue="0" ValidationGroup="attack" ControlToValidate="ddlHour" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator></td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="ddlMinuteRequiredFieldValidator2" runat="server" ErrorMessage="*Required" InitialValue="0" ValidationGroup="attack" ControlToValidate="ddlMinute" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator></td>
                                        </tr>
                                    </table>
                                    <cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="TextBoxDatetimeofIncident" Format="dd-MMM-yyyy" CssClass="cal_Theme1"></cc1:CalendarExtender>
                                </div>
                                
                                                                

                            </div>

                            <div class="row">
                                <div class="col-md-4 mb-3">
                                    <label>Incident<span class="required"> *</span></label>
                                    <asp:DropDownList ID="ddlIncident" CssClass="form-control" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ddlIncidentRequiredFieldValidator3" runat="server" ErrorMessage="*Required" InitialValue="0" ValidationGroup="attack" ControlToValidate="ddlIncident" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="ddlIncidentNoItemRequiredFieldValidator3" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="ddlIncident" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>
                                </div>
                                
                                
                            </div>

                            <div class="row">
                                <div class="col-md-8 mb-3">
                                    <label>Location<span class="required"> *Max 160 Char</span></label>
                                    <asp:TextBox ID="TextBoxLocation" autocomplete="off" CssClass="form-control" runat="server" MaxLength="160"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="TextBoxLocationRequiredFieldValidator1" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxLocation" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>
                                </div>
                                
                            </div>

                            <div class="row">
                                <div class="col-md-4 mb-3">
                                    <label for="country">Terrorist Group Involved<span class="required"> *</span></label>
                                    <asp:DropDownList ID="ddlterroristgroup" CssClass="form-control" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ddlterroristgroupRequiredFieldValidator2" runat="server" ErrorMessage="*Required" InitialValue="0" ValidationGroup="attack" ControlToValidate="ddldistrict" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="ddlterroristgroupNoItemRequiredFieldValidator3" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="ddlterroristgroup" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label>Number of Terrorist Involved<span class="required"> *</span></label>
                                    <asp:TextBox ID="TextBoxNumberofTerroristInvolved" autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="TextBoxNumberofTerroristInvolvedRequiredFieldValidator3" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxNumberofTerroristInvolved" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4 mb-3">
                                    <label>Ammunition Recovered<span class="required"> *Max 200 Char</span></label>
                                    <asp:TextBox ID="TextBoxAmmunationRecovered" autocomplete="off" CssClass="form-control" runat="server" MaxLength="200"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="TextBoxAmmunationRecoveredRequiredFieldValidator3" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxAmmunationRecovered" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>
                                </div>

                                <div class="col-md-4 mb-3">
                                    <label for="country">Infra Affected<span class="required"> *Max 200 Char</span></label>
                                    <asp:TextBox ID="TextBoxInfectedArea" CssClass="form-control" runat="server" MaxLength="200" autocomplete="off"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="TextBoxInfectedAreaRequiredFieldValidator3" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxInfectedArea" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label>Remarks<span class="required"> *</span><span class="required">Max 1000 Chars</span></label>
                                    <asp:TextBox ID="TextBoxRemarks" CssClass="form-control" runat="server" MaxLength="1000" TextMode="MultiLine" Height="100px" autocomplete="off"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="TextBoxRemarksRequiredFieldValidator4" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxRemarks" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12 mb-3">
                                    <center>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" ValidationGroup="attack" OnClick="btnSubmit_Click"/>&nbsp;
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary" CausesValidation="false" OnClick="btnReset_Click"/>
                                </center>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12 mb-3">
                                    <asp:GridView ID="attackGridView" CssClass="table table-striped table-bordered table-condensed" runat="server" EmptyDataText="No Record Found" AllowPaging="True" AutoGenerateColumns="False" PageSize="6" OnRowCommand="attackGridView_RowCommand" OnPageIndexChanging="attackGridView_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="District">
                                                <ItemTemplate>
                                                    <asp:Label ID="ldistrict" runat="server" Text='<%# Server.HtmlEncode(Eval("DistrictName") as string) %>'></asp:Label>
                                                    <asp:HiddenField Value='<%# Server.HtmlEncode(Eval("DistrictId") as string) %>' ID="hfdid" runat="server" />
                                                    
                                                    <asp:HiddenField Value='<%# Server.HtmlEncode(Eval("AttackId") as string) %>' ID="hfaid" runat="server" />
                                                    <asp:HiddenField Value='<%# Server.HtmlEncode(Eval("IncidentId") as string) %>' ID="hfinid" runat="server" />
                                                    <asp:HiddenField Value='<%# Server.HtmlEncode(Eval("TerroristGroupInvolved") as string) %>' ID="hftrrid" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Location">
                                                <ItemTemplate>
                                                    <asp:Label ID="llocation" runat="server" Text='<%# Server.HtmlEncode(Eval("LocationName") as string) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Incident">
                                                <ItemTemplate>
                                                    <asp:Label ID="lincident" runat="server" Text='<%# Server.HtmlEncode(Eval("IncidentName") as string) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="IncidentDateTime">
                                                <ItemTemplate>
                                                    <asp:Label ID="lDateAndTimeofIncident" runat="server" Text='<%# Server.HtmlEncode(Eval("DateAndTimeofIncident") as string) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TerroristGroup">
                                                <ItemTemplate>
                                                    <asp:Label ID="lTerroristGroup" runat="server" Text='<%# Server.HtmlEncode(Eval("TerroristGroup") as string) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="InfectedArea">
                                                <ItemTemplate>
                                                    <asp:Label ID="lInfectedArea" runat="server" Text='<%# Server.HtmlEncode(Eval("InfectedArea") as string) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="AmunitionRecovered">
                                                <ItemTemplate>
                                                    <asp:Label ID="lAmunitionRecovered" runat="server" Text='<%# Server.HtmlEncode(Eval("AmunitionRecovered") as string) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Edit" CommandName="Edit_1" CommandArgument='<%# Server.HtmlEncode(Eval("AttackId").ToString()) %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkBtnEdit_" runat="server" Text="Upload Sub Details" OnClientClick=' <%# Eval("AttackId", "window.open(\"UploadSubDetails.aspx?q={0}\", null, \"width=900,height=600,top=160,left=300\", \"true\");") %>'></asp:LinkButton>                                                                                                      
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                        </Columns>
                                        <PagerStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddldistrict" EventName="SelectedIndexChanged" />
                <%--<asp:AsyncPostBackTrigger ControlID="" />--%>
                <asp:PostBackTrigger ControlID="attackGridView" />
                <asp:PostBackTrigger ControlID="btnSubmit" />
                <asp:PostBackTrigger ControlID="btnReset" />
                <%--<asp:AsyncPostBackTrigger ControlID="attackGridView" />--%>
            </Triggers>
        </asp:UpdatePanel>

        <%--<asp:GridView ID="Gridview1" runat="server" ShowFooter="true"
            AutoGenerateColumns="false"
            OnRowCreated="Gridview1_RowCreated">
            <Columns>
                <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
                <asp:TemplateField HeaderText="Header 1">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Header 2">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Header 3">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server"
                            AppendDataBoundItems="true">
                            <asp:ListItem Value="-1">Select</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Header 4">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server"
                            AppendDataBoundItems="true">
                            <asp:ListItem Value="-1">Select</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Right" />
                    <FooterTemplate>
                        <asp:Button ID="ButtonAdd" runat="server"
                            Text="Add New Row"
                            OnClick="ButtonAdd_Click" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server"
                            OnClick="LinkButton1_Click">Remove</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>--%>



    </form>
</asp:Content>

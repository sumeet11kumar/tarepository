<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="TAAPP16_12_2019.TAADM.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TA :: PANEL</title>

    <style type="text/css">
        label {
            font-weight: bold;
        }

        .dataShow {
            color: #4f4f4f;
        }

        #tablelayout table, #tablelayout2 table {
            border-collapse: collapse;
        }

            #tablelayout table tr td, #tablelayout2 table tr td {
                border: solid 1px #ededed;
                padding: 5px;
                font-family: Arial;
                font-size: 13px;
            }

        .required {
            color: red;
            font-weight: bold;
        }

        .validation {
            color: #dc3030;
            background-color: #f3dede;
            font-style: italic;
        }

        input[type="text"], select {
            padding: 3px 4px;
            border-radius: 3px;
            color: #4e4e4e;
        }

        *:focus {
            outline: none;
        }

        #radiobuttonlistCII tr td, #radiobuttonlistCF tr td, #radiobuttonlistDIA tr td,#radiobuttonlistLocalNonLocal tr td {
            border-style: none!important;
            border-width: 0px!important;
        }
    </style>
    <script>
        function CloseRedirect() {
            window.opener.location = 'logout.aspx';
            window.close();
        }
        function ShowPopup(a) {
            alert(a);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center" valign="top">
                            <div id="tablelayout">
                                <table width="100%">
                                    <tr>
                                        <td align="left" valign="top">
                                            <label>District</label><br />
                                            <asp:Label ID="ldistrict" runat="server" Text="" CssClass="dataShow"></asp:Label>
                                        </td>
                                        <td align="left" valign="top">
                                            <label>Tehsil</label><br />
                                            <asp:Label ID="ltehsil" runat="server" Text="" CssClass="dataShow"></asp:Label>
                                        </td>
                                        <td align="left" valign="top">
                                            <label>Date & Time of Incident</label><br />
                                            <asp:Label ID="ldatetime" runat="server" Text="" CssClass="dataShow"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="3">
                                            <label>Type of Incident</label><br />
                                            <asp:Label ID="lincident" runat="server" Text="" CssClass="dataShow"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <label>Location</label><br />
                                            <asp:Label ID="llocation" runat="server" Text="" CssClass="dataShow"></asp:Label>
                                        </td>
                                        <td align="left" valign="top">
                                            <label>Terrorist Group Involved</label><br />
                                            <asp:Label ID="ltgi" runat="server" Text="" CssClass="dataShow"></asp:Label>
                                        </td>
                                        <td align="left" valign="top">
                                            <label>No. Of Terrorist Involved</label><br />
                                            <asp:Label ID="lnti" runat="server" Text="" CssClass="dataShow"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top">
                                            <label>Ammunition Recovered</label><br />
                                            <asp:Label ID="lammo" runat="server" Text="" CssClass="dataShow"></asp:Label>
                                        </td>
                                        <td align="left" valign="top">
                                            <label>Infra Affected</label><br />
                                            <asp:Label ID="linfra" runat="server" Text="" CssClass="dataShow"></asp:Label>
                                        </td>
                                        <td align="left" valign="top">
                                            <label>Remarks</label><br />
                                            <asp:Label ID="lremarks" runat="server" Text="" CssClass="dataShow"></asp:Label>
                                        </td>
                                    </tr>

                                </table>
                            </div>

                        </td>
                    </tr>

                    <tr>
                        <td align="center" valign="top">

                            <div id="tablelayout2">
                                <table width="100%" align="center">
                                    <tr>
                                        <td align="center" valign="middle" bgcolor="#ededed" colspan="2"><font color="#4e4e4e"><strong>Upload Sub Details</strong></font></td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="middle" width="25%">
                                            <label>Select<span class="required"> *</span></label></td>
                                        <td align="left" valign="middle">
                                            <asp:RadioButtonList ID="radiobuttonlistCII" CssClass="form-control" runat="server" AutoPostBack="True" Font-Bold="False" RepeatDirection="Horizontal" OnSelectedIndexChanged="radiobuttonlistCII_SelectedIndexChanged">
                                                <asp:ListItem Value="1">Casuality</asp:ListItem>
                                                <asp:ListItem Value="2">Injury</asp:ListItem>
                                                <asp:ListItem Value="3">Terrorist</asp:ListItem>
                                            </asp:RadioButtonList><br />
                                            <asp:RequiredFieldValidator ID="radiobuttonlistCIIRequiredFieldValidator1" runat="server" ErrorMessage="*Required" CssClass="validation" Display="Dynamic" SetFocusOnError="true" ControlToValidate="radiobuttonlistCII" ValidationGroup="attack"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <asp:Panel ID="panelCasualityInjury" runat="server" Visible="false">
                                        <tr>
                                            <td align="left" valign="middle">
                                                <label>Select<span class="required"> *</span></label></td>
                                            <td align="left" valign="top" colspan="2">
                                                <asp:RadioButtonList ID="radiobuttonlistCF" CssClass="form-control" runat="server" AutoPostBack="True" Font-Bold="False" RepeatDirection="Horizontal" OnSelectedIndexChanged="radiobuttonlistCF_SelectedIndexChanged">
                                                    <asp:ListItem Value="1">Civilian</asp:ListItem>
                                                    <asp:ListItem Value="2">Forces</asp:ListItem>
                                                </asp:RadioButtonList><br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" CssClass="validation" Display="Dynamic" SetFocusOnError="true" ControlToValidate="radiobuttonlistCF" ValidationGroup="attack"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <asp:Panel ID="panelCivilian" runat="server" Visible="false">
                                            <tr>
                                                <td align="left" valign="middle">
                                                    <label>Enter Number of Casuality<span class="required"> *</span></label></td>
                                                <td align="left" valign="top" colspan="2">
                                                    <asp:TextBox ID="TextBoxCivilian1" CssClass="form-control" runat="server" MaxLength="4"></asp:TextBox><br />
                                                    <asp:RequiredFieldValidator ID="TextBoxCivilian1RequiredFieldValidator4" runat="server" ErrorMessage="*Required" CssClass="validation" Display="Dynamic" SetFocusOnError="true" ControlToValidate="TextBoxCivilian1" ValidationGroup="attack"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="TextBoxCivilian1RegularExpressionValidator1" runat="server" ErrorMessage="*Only Numbers" CssClass="validation" Display="Dynamic" SetFocusOnError="true" ValidationGroup="attack" ValidationExpression="\d+" ControlToValidate="TextBoxCivilian1"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <asp:Panel ID="panelForce" runat="server" Visible="false">
                                            <tr>
                                                <td align="left" valign="middle">
                                                    <label>Select Force<span class="required"> *</span></label></td>
                                                <td align="left" valign="top" colspan="2">
                                                    <asp:DropDownList ID="DropDownListForce" CssClass="form-control" runat="server"></asp:DropDownList><br />
                                                    <asp:RequiredFieldValidator ID="DropDownListForceRequiredFieldValidator4" runat="server" ErrorMessage="*Required" CssClass="validation" Display="Dynamic" SetFocusOnError="true" ControlToValidate="DropDownListForce" ValidationGroup="attack" InitialValue="0"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle">
                                                    <asp:Label ID="LabelTitle" runat="server" Text=""></asp:Label><span class="required"> *</span></td>
                                                <td align="left" valign="top" colspan="2">
                                                    <asp:TextBox ID="TextBoxForce1" CssClass="form-control" runat="server" MaxLength="4" autocomplete="off"></asp:TextBox><br />
                                                    <asp:RequiredFieldValidator ID="TextBoxForce1RequiredFieldValidator2" runat="server" ErrorMessage="*Required" CssClass="validation" Display="Dynamic" SetFocusOnError="true" ControlToValidate="TextBoxForce1" ValidationGroup="attack"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Only Numbers" CssClass="validation" Display="Dynamic" SetFocusOnError="true" ValidationGroup="attack" ValidationExpression="\d+" ControlToValidate="TextBoxForce1"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                    </asp:Panel>

                                    <asp:Panel ID="panelTerrorist" runat="server" Visible="false">
                                        <tr>
                                            <td align="left" valign="middle">
                                                <label>Select<span class="required"> *</span></label></td>
                                            <td align="left" valign="top" colspan="2">
                                                <asp:RadioButtonList ID="radiobuttonlistDIA" runat="server" AutoPostBack="True" Font-Bold="False" RepeatDirection="Horizontal" OnSelectedIndexChanged="radiobuttonlistDIA_SelectedIndexChanged">
                                                    <asp:ListItem Value="1">Death</asp:ListItem>
                                                    <asp:ListItem Value="2">Injury</asp:ListItem>
                                                    <asp:ListItem Value="3">Arrested</asp:ListItem>
                                                </asp:RadioButtonList><br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" CssClass="validation" Display="Dynamic" SetFocusOnError="true" ControlToValidate="radiobuttonlistDIA" ValidationGroup="attack"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </asp:Panel>

                                    <asp:Panel ID="panelTerroristLNL" runat="server" Visible="false">
                                        <tr>
                                            <td align="left" valign="middle">
                                                <label>Select<span class="required"> *</span></label></td>
                                            <td align="left" valign="top" colspan="2">
                                                <asp:RadioButtonList ID="radiobuttonlistLocalNonLocal" runat="server" AutoPostBack="True" Font-Bold="False" RepeatDirection="Horizontal" OnSelectedIndexChanged="radiobuttonlistLocalNonLocal_SelectedIndexChanged">
                                                    <asp:ListItem Value="1">Local</asp:ListItem>
                                                    <asp:ListItem Value="2">Non-Local</asp:ListItem>
                                                </asp:RadioButtonList><br />
                                                <asp:RequiredFieldValidator ID="radiobuttonlistLocalNonLocalRequiredFieldValidator2" runat="server" ErrorMessage="*Required" CssClass="validation" Display="Dynamic" SetFocusOnError="true" ControlToValidate="radiobuttonlistLocalNonLocal" ValidationGroup="attack"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                            <tr>
                                                <td align="left" valign="middle">
                                                    <asp:Label ID="Labeltitle2" runat="server" Text="" Font-Bold="true"></asp:Label><span class="required"> *</span></td>
                                                <td align="left" valign="top" colspan="2">
                                                    <asp:TextBox ID="TextBoxLocalNonLocal" CssClass="form-control" runat="server" MaxLength="4" autocomplete="off"></asp:TextBox><br />
                                                    <asp:RequiredFieldValidator ID="TextBoxLocalNonLocalRequiredFieldValidator4" runat="server" ErrorMessage="*Required" CssClass="validation" Display="Dynamic" SetFocusOnError="true" ControlToValidate="TextBoxLocalNonLocal" ValidationGroup="attack"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="TextBoxLocalNonLocalRegularExpressionValidator2" runat="server" ErrorMessage="*Only Numbers" CssClass="validation" Display="Dynamic" SetFocusOnError="true" ValidationGroup="attack" ValidationExpression="\d+" ControlToValidate="TextBoxLocalNonLocal"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                    </asp:Panel>

                                    <tr>
                                        <td align="center" valign="middle" colspan="2">
                                            <asp:Button ID="Button1" runat="server" Text="Submit" ValidationGroup="attack" OnClick="Button1_Click" /></td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <asp:GridView ID="GridViewCasualityCivilian" runat="server" Visible="false" Style="font-family: Arial; font-size: 13px;" EmptyDataText="No Record Found">
                            </asp:GridView>
                            <asp:GridView ID="GridViewCasualityForce" runat="server" Visible="false" Style="font-family: Arial; font-size: 13px;" EmptyDataText="No Record Found">
                            </asp:GridView>
                            <asp:GridView ID="GridViewInjuryCivilian" runat="server" Visible="false" Style="font-family: Arial; font-size: 13px;" EmptyDataText="No Record Found">
                            </asp:GridView>
                            <asp:GridView ID="GridViewInjuryForce" runat="server" Visible="false" Style="font-family: Arial; font-size: 13px;" EmptyDataText="No Record Found">
                            </asp:GridView>
                            <asp:GridView ID="GridView5" runat="server" Visible="false" Style="font-family: Arial; font-size: 13px;" EmptyDataText="No Record Found">
                            </asp:GridView>
                        </td>
                    </tr>

                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="radiobuttonlistCII" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="radiobuttonlistCF" EventName="SelectedIndexChanged" />
                <asp:PostBackTrigger ControlID="Button1" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>

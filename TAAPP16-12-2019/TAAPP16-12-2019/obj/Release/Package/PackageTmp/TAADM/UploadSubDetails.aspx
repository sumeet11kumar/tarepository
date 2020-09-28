<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadSubDetails.aspx.cs" Inherits="TAAPP16_12_2019.TAADM.UploadSubDetails" %>

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
                border: solid 1px #e3e3e3;
                padding: 5px;
                font-family: Arial;
                font-size: 13px;
            }
        #tablelayout2 .subhead {
            background-color:#f5f5f5;
            font-weight:bold;
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
        .note {
            width:auto;
        }
        .note span {
            font-weight:bold;
        }
        input[type="text"], select {
            padding: 3px 4px;
            border-radius: 3px;
            color: #4e4e4e;
        }

        *:focus {
            outline: none;
        }

        #radiobuttonlistCII tr td, #radiobuttonlistCF tr td, #radiobuttonlistDIA tr td, #radiobuttonlistLocalNonLocal tr td {
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
                                        <td align="center" valign="middle" bgcolor="#ededed" colspan="8"><font color="#4e4e4e"><strong>Upload Sub Details</strong></font></td>
                                    </tr>
                                     
                                    <tr>
                                        <td align="center" valign="middle"colspan="8" class="validation">
                                            <div class="validation note"><span>Note: </span> To update, click on 'Edit' link provided below. Insert values only in those column which is applicable. Blank fields would be assigned '0' automatically.</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="middle" colspan="8"class="subhead"><span>Casuality</span></td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="middle" colspan="2" class="subhead"><span>Civilian</span></td>
                                        <td align="center" valign="middle" colspan="6" class="subhead"><span>Forces</span></td>
                                    </tr>

                                    <tr>
                                        <td align="center" valign="middle" class="subhead"><span>Local</span></td>
                                        <td align="center" valign="middle" class="subhead"><span>Non-Local</span></td>

                                        <td align="center" valign="middle" class="subhead"><span>CRPF</span></td>
                                        <td align="center" valign="middle" class="subhead"><span>CISF</span></td>
                                        <td align="center" valign="middle" class="subhead"><span>JKP</span></td>
                                        <td align="center" valign="middle" class="subhead"><span>ITBP</span></td>
                                        <td align="center" valign="middle" class="subhead"><span>BSF</span></td>
                                        <td align="center" valign="middle" class="subhead"><span>SSB</span></td>
                                    </tr>

                                    <tr>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxCivilianLocal" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxCivilianLocal" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxCivilianLocal" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxCivilianNonLocal" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxCivilianNonLocal" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxCivilianNonLocal" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>

                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxForceCRPF" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxForceCRPF" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxForceCRPF" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxForceCISF" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxForceCISF" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxForceCISF" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxForceJKP" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxForceJKP" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxForceJKP" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxForceITBP" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxForceITBP" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxForceITBP" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxForceBSF" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxForceBSF" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxForceBSF" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxForceSSB" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxForceSSB" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxForceSSB" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="middle"colspan="8" height="15"></td>
                                    </tr>
                                    <!-- INJURY PANEL -->
                                    <tr>
                                        <td align="center" valign="middle" colspan="8"class="subhead"><span>Injury</span></td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="middle" colspan="2" class="subhead"><span>Civilian</span></td>
                                        <td align="center" valign="middle" colspan="6" class="subhead"><span>Forces</span></td>
                                    </tr>

                                    <tr>
                                        <td align="center" valign="middle" class="subhead"><span>Local</span></td>
                                        <td align="center" valign="middle" class="subhead"><span>Non-Local</span></td>

                                        <td align="center" valign="middle" class="subhead"><span>CRPF</span></td>
                                        <td align="center" valign="middle" class="subhead"><span>CISF</span></td>
                                        <td align="center" valign="middle" class="subhead"><span>JKP</span></td>
                                        <td align="center" valign="middle" class="subhead"><span>ITBP</span></td>
                                        <td align="center" valign="middle" class="subhead"><span>BSF</span></td>
                                        <td align="center" valign="middle" class="subhead"><span>SSB</span></td>
                                    </tr>

                                    <tr>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxInjuryLocal" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxInjuryLocal" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxInjuryLocal" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxInjuryNonLocal" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxInjuryNonLocal" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxInjuryNonLocal" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>

                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxInjuryForceCRPF" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceCRPF" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceCRPF" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxInjuryForceCISF" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceCISF" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceCISF" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxInjuryForceJKP" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceJKP" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceJKP" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxInjuryForceITBP" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceITBP" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceITBP" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxInjuryForceBSF" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceBSF" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceBSF" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxInjuryForceSSB" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceSSB" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceSSB" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="center" valign="middle"colspan="8" height="15"></td>
                                    </tr>
                                    <!-- TERRORIST PANEL -->
                                    <tr>
                                        <td align="center" valign="middle" colspan="8" class="subhead"><span>Terrorist</span></td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="middle" class="subhead" colspan="4"><span>Death</span></td>
                                        <td align="center" valign="middle" class="subhead" colspan="2"><span>Injuries</span></td>
                                        <td align="center" valign="middle" class="subhead" colspan="2"><span>Arrested</span></td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="middle" class="subhead" colspan="2"><span>Local</span></td>
                                        <td align="center" valign="middle" class="subhead" colspan="2"><span>Non-Local</span></td>
                                        <td align="center" valign="middle" class="subhead"><span>Local</span></td>
                                        <td align="center" valign="middle" class="subhead"><span>Non-Local</span></td>
                                        <td align="center" valign="middle" class="subhead"><span>Local</span></td>
                                        <td align="center" valign="middle" class="subhead"><span>Non-Local</span></td>
                                    </tr>

                                    <tr>
                                        <td align="center" valign="middle" colspan="2">
                                            <asp:TextBox ID="TextBoxTerroristDeathLocal" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceSSB" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxTerroristDeathLocal" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle" colspan="2">
                                            <asp:TextBox ID="TextBoxTerroristDeathNonLocal" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceSSB" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxTerroristDeathLocal" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxTerroristInjuriesLocal" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceSSB" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceSSB" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxTerroristInjuriesNonLocal" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceSSB" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceSSB" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxTerroristArrestedLocal" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceSSB" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceSSB" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" valign="middle">
                                            <asp:TextBox ID="TextBoxTerroristArrestedNonLocal" runat="server" MaxLength="4" Width="50"></asp:TextBox>
                                            <br />
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*Required" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceSSB" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ErrorMessage="*Only Numbers" ValidationExpression="\d+" ValidationGroup="attack" ControlToValidate="TextBoxInjuryForceSSB" Display="Dynamic" SetFocusOnError="true" CssClass="validation"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>



                                    <tr>
                                        <td align="center" valign="middle" colspan="8">
                                            <asp:Button ID="Button1" runat="server" Text="Submit" ValidationGroup="attack" OnClick="Button1_Click" /></td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <div style="width: 800px; height:100px; overflow-x: scroll; overflow-y: hidden;">
                                <asp:GridView ID="GridView1" runat="server" Style="font-family: Arial; font-size: 13px;" EmptyDataText="No Record Found" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" HorizontalAlign="Center">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit_1">Edit</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CasualityCivilianLocal" HeaderText="CasualityCivilianLocal" ReadOnly="true" />
                                        <asp:BoundField DataField="CasualityCivilianNonLocal" HeaderText="CasualityCivilianNonLocal" ReadOnly="true" />
                                        <asp:BoundField DataField="CasualityForceCRPF" HeaderText="CasualityForceCRPF" ReadOnly="true" />
                                        <asp:BoundField DataField="CasualityForceCISF" HeaderText="CasualityForceCISF" ReadOnly="true" />
                                        <asp:BoundField DataField="CasualityForceJKP" HeaderText="CasualityForceJKP" ReadOnly="true" />
                                        <asp:BoundField DataField="CasualityForceITBP" HeaderText="CasualityForceITBP" ReadOnly="true" />
                                        <asp:BoundField DataField="CasualityForceBSF" HeaderText="CasualityForceBSF" ReadOnly="true" />
                                        <asp:BoundField DataField="CasualityForceSSB" HeaderText="CasualityForceSSB" ReadOnly="true" />
                                        <asp:BoundField DataField="InjuryCivilianLocal" HeaderText="InjuryCivilianLocal" ReadOnly="true" />
                                        <asp:BoundField DataField="InjuryCivilianNonLocal" HeaderText="InjuryCivilianNonLocal" ReadOnly="true" />
                                        <asp:BoundField DataField="InjuryForceCRPF" HeaderText="InjuryForceCRPF" ReadOnly="true" />
                                        <asp:BoundField DataField="InjuryForceCISF" HeaderText="InjuryForceCISF" ReadOnly="true" />
                                        <asp:BoundField DataField="InjuryForceJKP" HeaderText="InjuryForceJKP" ReadOnly="true" />
                                        <asp:BoundField DataField="InjuryForceITBP" HeaderText="InjuryForceITBP" ReadOnly="true" />
                                        <asp:BoundField DataField="InjuryForceBSF" HeaderText="InjuryForceBSF" ReadOnly="true" />
                                        <asp:BoundField DataField="InjuryForceSSB" HeaderText="InjuryForceSSB" ReadOnly="true" />
                                        <asp:BoundField DataField="TerroristDeathLocal" HeaderText="TerroristDeathLocal" ReadOnly="true" />
                                        <asp:BoundField DataField="TerroristDeathNonLocal" HeaderText="TerroristDeathNonLocal" ReadOnly="true" />
                                        <asp:BoundField DataField="TerroristInjuryLocal" HeaderText="TerroristInjuryLocal" ReadOnly="true" />
                                        <asp:BoundField DataField="TerroristInjuryNonLocal" HeaderText="TerroristInjuryNonLocal" ReadOnly="true" />
                                        <asp:BoundField DataField="TerroristArrestedLocal" HeaderText="TerroristArrestedLocal" ReadOnly="true" />
                                        <asp:BoundField DataField="TerroristArrestedNonLocal" HeaderText="TerroristArrestedNonLocal" ReadOnly="true" />
                                        
                                    </Columns>
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td height="20"></td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                
                <asp:PostBackTrigger ControlID="Button1" />
                <asp:PostBackTrigger ControlID="GridView1" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>

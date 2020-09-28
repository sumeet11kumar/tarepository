<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TAAPP16_12_2019.WebForm1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%">
            <tr>
                <td align="center">
                    <asp:Chart ID="Chart1" runat="server" Width="1200px" Visible="false" OnClick="Chart1_Click">
                        <Titles>
                            <asp:Title ShadowOffset="2" Name="Items"/>
                        </Titles>
                        <%--<Legends>
                            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="legendDefault" LegendStyle="Row" />
                        </Legends>--%>
                        <Series>
                            <asp:Series Name="Default"  />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
                        </ChartAreas>
                    </asp:Chart>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

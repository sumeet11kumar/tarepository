<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertSubDetails.aspx.cs" Inherits="TAAPP16_12_2019.TAADM.InsertSubDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TA :: PANEL</title>
    <script type="text/javascript" src='js/bootstrap.min.js'></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" media="screen" />
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            if (window.opener != null && !window.opener.closed) {
                var rowIndex = window.location.href.split("?")[1].split("=")[1];
                var parent = $(window.opener.document).contents();
                var row = parent.find("[id*=attackGridView]").find("tr").eq(rowIndex);
                $("#dt").html(row.find("td").eq(3).html());
                $("#incident").html(row.find("td").eq(2).html());
                //$("#description").html(row.find("td").eq(2).html());
            }
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            Date: <span id="dt"></span><br />
            Incident: <span id="incident"></span><br />
        </div>
    </form>
</body>
</html>

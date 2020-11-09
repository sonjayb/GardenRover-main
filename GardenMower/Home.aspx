<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="GardenMower.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">  
        var Res;
        function generate_table() {
            debugger;
            var tbl = document.getElementById("tblInputTable");
            var tblBody = document.createElement("tbody");
            var noOfSquad = document.getElementById("txtSquad").value;
            for (var i = 0; i < noOfSquad; i++) {
                var row = document.createElement("tr");
                for (var j = 0; j < 4; j++) {

                    var cell = document.createElement("td");

                    if (j == 2) {
                        var feld = document.createElement("input");
                        feld.setAttribute("id", "btn" + i.toString() + j.toString());
                        feld.setAttribute("type", "button");
                        feld.setAttribute("value", "Go!!!");
                        feld.setAttribute("onclick", "GetMowerPosition(" + i.toString() + ");");
                        cell.appendChild(feld);
                    }
                    else {
                        var txtBox = document.createElement("input");
                        txtBox.setAttribute("id", "txtInput" + i.toString() + j.toString());
                        txtBox.setAttribute("type", "text");
                        cell.appendChild(txtBox);
                    }
                    row.appendChild(cell);
                }

                // add the row to the end of the table body
                tblBody.appendChild(row);
            }

            // put the <tbody> in the <table>
            tbl.appendChild(tblBody);

            tbl.setAttribute("border", "2");
        }

        function GetMowerPosition(i) {

            try {
                debugger;
                var xGarden = document.getElementById("txtXCoordinate").value;
                var yGarden = document.getElementById("txtYCoordinate").value;
                var x = "txtInput" + i.toString() + "0";
                var y = "txtInput" + i.toString() + "1";
                var strMowerPosition = document.getElementById(x).value;
                var strCommandLine = document.getElementById(y).value;
                Res = "txtInput" + i.toString() + "3";
                PageMethods.ReloadData(xGarden, yGarden, strMowerPosition, strCommandLine, OnSuccess, OnFailure);
            }
            catch (err) {
                alert(err.toString());
            }
        }
        function OnSuccess(result) {
            if (result) {
                document.getElementById(Res).value = result.toString();
            }
        }
        function OnFailure(error) {

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
        </asp:ScriptManager>
        <table style="width: 100%;">
            <tr>
                <td colspan="2">This is Gardenrover puzzle!!! </td>
            </tr>
            <tr>
                <td>Please enter your squad number : </td>
                <td>
                    <input id="txtSquad" type="text" /></td>

            </tr>
            <tr>
                <td>Please enter X Coordinate of Garden : </td>
                <td>
                    <input id="txtXCoordinate" type="text" />
                </td>

            </tr>
            <tr>
                <td>Please enter Y Coordinate of Garden : </td>

                <td>
                    <input id="txtYCoordinate" type="text" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <input type="button" value="Generate Mower Input Sheet " onclick="generate_table()" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table id="tblInputTable"></table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

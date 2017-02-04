<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebClient.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>Id</td>
            <td><asp:TextBox ID="TxtId" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Vendor</td>
            <td><asp:TextBox ID="TxtVendor" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Model</td>
            <td><asp:TextBox ID="TxtModel" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Vendor</td>
            <td><asp:TextBox ID="TxtYear" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Button ID="BtnSetCar" runat="server" Text="Set Car" OnClick="BtnSetCar_Click" /></td>
            <td><asp:Button ID="BtnGetCar" runat="server" Text="Get Car" OnClick="BtnGetCar_Click" /></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>

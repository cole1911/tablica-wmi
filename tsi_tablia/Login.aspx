<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="tsi_tablica.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="LoginBox" runat="server"></asp:TextBox>
        <asp:TextBox TextMode="Password" ID="PassBox" runat="server"></asp:TextBox>
        <asp:Button ID="loginBtn" Text="Zaloguj" runat="server" />
    </div>
        <div id="divResultSubmitted" runat="server" />
    </form>
      
</body>
</html>

<%@ Page Language="C#" MaintainScrollPositionOnPostback="false" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WAR.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 472px;
            text-align: left;
        }
    </style>
</head>
<body >
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="GameStartLabel" runat="server" Text="Click to Play!"></asp:Label>
            &nbsp;<br />
            Player One Name:
            <asp:TextBox ID="Player1Name" runat="server">1</asp:TextBox>
            <br />
            Player Two Name:<asp:TextBox ID="Player2Name" runat="server">2</asp:TextBox>
            <br />
            <br />
        </div>
        <asp:Label ID="GameResultsLabel" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <p>
            <asp:Button ID="GamePlayButton" runat="server" OnClick="GamePlayButton_Click" Text="Play Until A Win" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="GamePlay20Button" runat="server" Text="Winner After 20 Rounds" OnClick="GamePlay20Button_Click" />
        </p>
        <p class="auto-style1">
            <strong>Caution! Playing to win may take 1000s of iterations
                <br />
                and may take some time on a slower machine.</strong>
        </p>
    </form>
    
    

</body>
</html>

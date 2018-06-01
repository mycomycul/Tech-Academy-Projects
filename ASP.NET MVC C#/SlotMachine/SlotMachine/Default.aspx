<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SlotMachine.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Image ID="slotImageOne" runat="server" Height="100px" Width="100px" />
            <asp:Image ID="slotImageTwo" runat="server" Height="100px" Width="100px" />
            <asp:Image ID="slotImageThree" runat="server" Height="100px" Width="100px" />
        </div>
        <p>
            Your Bet
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="leverButton" runat="server" OnClick="leverButton_Click" Text="Pull The Lever!" />
        </p>
        <p>
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="moneyLabel" runat="server"></asp:Label>
        </p>
        <p>
            1 Cherry -&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; x2 Your Bet</p>
        <p>
            2 Cherries -&nbsp;&nbsp;&nbsp;&nbsp; x3 Your Bet</p>
        <p>
            3 Cherries -&nbsp;&nbsp;&nbsp;&nbsp; x4 Your Bet</p>
        <p>
            3 7&#39;s - Jackpot -x100 Your Bet</p>
        <p>
            HOWEVER ... a BAR in any position means you win nothing.</p>
    </form>
</body>
</html>

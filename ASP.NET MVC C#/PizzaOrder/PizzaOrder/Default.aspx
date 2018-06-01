<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PizzaOrder.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 200px;
            height: 200px;
        }
        .auto-style2 {
            font-family: "Franklin Gothic Medium", "Arial Narrow", Arial, sans-serif;
        }
        .auto-style3 {
            color: #CC0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <img alt="Papa Bob Logo" class="auto-style1" src="PapaBob.png" /><h1><span class="auto-style2">Papa Bob&#39;s Pizza Software</span></h1>
            <br />
            <asp:RadioButtonList ID="sizeList" runat="server">
                <asp:ListItem Selected="True">Baby Bob Size (10&quot;) - $10</asp:ListItem>
                <asp:ListItem>Mama Bob Size (13&quot;) - $13</asp:ListItem>
                <asp:ListItem>Papa Bob Size(16&quot;) - $16</asp:ListItem>
            </asp:RadioButtonList>
            <br />
        </div>
        <asp:RadioButtonList ID="crustList" runat="server">
            <asp:ListItem Selected="True">Thin Crust</asp:ListItem>
            <asp:ListItem>Deep Dish (+$2)</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        <asp:CheckBoxList ID="toppingCheckList" runat="server">
            <asp:ListItem Value="1.5">Pepperoni (+$1.50)</asp:ListItem>
            <asp:ListItem Value=".75">Onions (+$0.75)</asp:ListItem>
            <asp:ListItem Value=".5">Green Peppers (+$0.50)</asp:ListItem>
            <asp:ListItem Value=".75">Red Peppers (+$0.75)</asp:ListItem>
            <asp:ListItem Value="2">Anchovies (+$2)</asp:ListItem>
        </asp:CheckBoxList>
        <br />
        <h2>
            <br />
            Papa Bob&#39;s <span class="auto-style3">Special Deal</span></h2>
        <p>
            Save $2 when you add Pepperoni, Green Peppers, and Anchovies OR Pepperoni, Red Peppers, and Onions</p>
        <p>
            <asp:Button ID="purchaseButton" runat="server" OnClick="purchaseButton_Click" Text="Purchase" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <strong>
            <asp:Label ID="resultLabel" runat="server" Text="Total: $0.00"></asp:Label>
            </strong>
        </p>
        <p>
            Sorry, at this time you can only order one pizza online, and pick only ... we need a better website!</p>
    </form>
</body>
</html>

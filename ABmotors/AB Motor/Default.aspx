<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AB Motors</title>
    <link href="CSS/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="wrapper" style="width: 1024px; margin: 0px auto;">
            
            <div style="float: left; width: 170px;">
                <img src="Images/bhagatgroupheader28.png" /></div>
        </div>
        <div class="logintop">
        </div>
   
     <div style="min-height: 400px; margin: 0px auto; width: 1024px; background-color: #ffffff;">
        <center>
        <h3>
                        Please Login here</h3>
            <div class="rightbox">
                <div style="float: left; width: 220px;">
                   
                    User-ID:<br />
                    <asp:TextBox ID="txtid" runat="server" CssClass="boxshadow" ValidationGroup="login" TabIndex="1" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtid" ValidationGroup="login"></asp:RequiredFieldValidator>
                    <br />
                    Password:<br />
                    <asp:TextBox ID="txtpass" runat="server" TextMode="Password" CssClass="boxshadow" ValidationGroup="login" TabIndex="2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtpass" ValidationGroup="login"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="Button1_Click" CssClass="but" ValidationGroup="login" TabIndex="3" />
                    <br />
                    <asp:Label ID="lblMsg" runat="server" Visible="False" ForeColor="Red" Font-Size="Medium"></asp:Label>
                </div>
                <div style="float: left; width: 180px;  ">
                    <img src="Images/main_icon_1.png" height="200px" width="180px" alt="user" />
                </div>
            </div>
        </center>
    </div>
        <div class="footerdiv" >
             Developed by Pratikshat Solutions
        </div>
    </div>
    </form>
</body>
</html>

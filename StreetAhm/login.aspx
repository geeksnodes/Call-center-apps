<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Complaint Management System</title>
    <link href="style/StyleSheet.css" rel="stylesheet" type="text/css" /> 

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="height: 170px; background-color: #fff;">
            <div class="wrapper">
           
                <img src="img/Logo%20Citelum%20INDIA-small.jpg" />
            <h1 style="color:#014E9E;">Complaint Management System</h1>
            <br />
            
            </div>
        </div>
        <div style="height: 5px; background-color: #65B7BC;">
        </div>
        <div style="background:url(img/grd_nav.png) ; height: 35px;">
        </div>
        <div class="wrapper">
        </div>
    </div>
    <div style="min-height: 400px; margin: 0px auto; width: 1024px; background-color: #ffffff;">
        <center>
            <br />
            <br />
            <div class="rightbox">
                <div style="float: left; width: 220px;">
                    <h3>
                        Please Login here</h3>
                    User-ID:<br />
                    <asp:TextBox ID="txtUser" runat="server" CssClass="txt" ValidationGroup="login" TabIndex="1" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUser" ValidationGroup="login"></asp:RequiredFieldValidator>
                    <br />
                    Password:<br />
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="txt" ValidationGroup="login" TabIndex="2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPass" ValidationGroup="login"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="Button1_Click" CssClass="btn" ValidationGroup="login" TabIndex="3" />
                    <br />
                    <asp:Label ID="lblMsg" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
                </div>
                <div style="float: left; width: 180px;  ">
                    <img src="img/main_icon_1.png" height="200px" width="180px" alt="user" />
                </div>
            </div>
        </center>
    </div>
    <div style="height: 35px; background-color: #65B7BC;">
    </div>
    </form>
</body>
</html>

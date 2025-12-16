<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/sparkstyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="wrapper">
            <br /> <div style="float:left; width:170px; "><img src="img/sfblogo.png" alt="Squarekart" /></div> 
         </div></div>  
    <div class="logintop">
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
                    <asp:TextBox ID="txtid" runat="server" CssClass="txt" ValidationGroup="login" TabIndex="1" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtid" ValidationGroup="login"></asp:RequiredFieldValidator>
                    <br />
                    Password:<br />
                    <asp:TextBox ID="txtpass" runat="server" TextMode="Password" CssClass="txt" ValidationGroup="login" TabIndex="2"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtpass" ValidationGroup="login"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="Button1_Click" CssClass="btn" ValidationGroup="login" TabIndex="3" />
                    <br />
                    <asp:Label ID="lblMsg" runat="server" Visible="False" ForeColor="Red" Font-Size="Medium"></asp:Label>
                </div>
                <div style="float: left; width: 180px;  ">
                    <img src="img/main_icon_1.png" height="200px" width="180px" alt="user" />
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

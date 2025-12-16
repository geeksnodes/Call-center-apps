<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <%--<div style=" float:left ">
        <asp:Image ID="Image1" runat="server" Height="100px" Width="175px" ImageUrl="~/images/vlogo.png"  />
    </div>--%>

    <div >
<center>
    <table style=" margin-top:200px; background-color:White; border-spacing:5px;outline: #0B0B61 solid;" >
       <tbody style=" float:left;"> <tr><td>
             <asp:Image ID="Image2" runat="server" Height="150px" Width="200px" ImageUrl="~/images/vlogo.png"  />
            </td>
        </tr>

        </tbody>
        <%--<tbody style="float:none;" >
            <asp:Label ID="Label3" runat="server" Text="Sign In"></asp:Label>
        </tbody>--%>
        <tbody style=" float:left;"> 
        <tr><td></td>
           <td>
              <b> <asp:Label ID="Label3" runat="server" Text="SIGN IN"></asp:Label></b>
           </td>
         </tr>
         <tr>
         
         </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="User name"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox" ></asp:TextBox>
            </td>
        </tr>
        <tr>
        
            <td>
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" CssClass="txtbox" ></asp:TextBox>
            </td>
        </tr>
        <tr>
        
            <td >
                <asp:Button ID="Button1" runat="server" CssClass="btnd" Text="Submit" onclick="Button1_Click" 
                    style="height: 26px" />
           </td> 
           <td>
                <asp:Button ID="Button2" runat="server" CssClass="btnd" Text="Reset" onclick="Button2_Click" style="height: 26px" />
            </td>
        </tr>
        </tbody>
    </table>
</center>
</div><center>
<div style="height:22px; color:#ffffff; width:100%; margin-top:10px; position:absolute; bottom:0;left:0;background:#0B0B61;">
           @2014 Developed and Designed by Pratikshat Solutions
    </div>
    </center>
   </form>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="seller.aspx.cs" Inherits="seller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

      <link href="css/constyle.css" rel="stylesheet" type="text/css" />
   
      <style type="text/css">
          .style1
          {
              width: 200px;
              font-size:13px;
          }
          
          .style2
          {
              width: 391px;
              
          }
          
          .saller_textbox
          {
             
          }
          
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<table class="txtd" ><%--style="margin: 0 auto; "--%>


<tr>
      
        <b>Welcome to Vphone - Customer Acquisition Form</b>
         
    </tr>
     <tr>
        <td class="style1" >
            <asp:Label ID="Label1" runat="server" Text="DID"></asp:Label>
        </td>

        <td class="style2">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="itemHighlighted" >
                <asp:ListItem>New</asp:ListItem>
              
            </asp:DropDownList>
        </td><td></td>
    </tr>
      <tr>
        <td class="style1" >
            <asp:Label ID="Label2" runat="server" Text="First Name"></asp:Label>
        </td>
        <td class="style2" >
            <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox" ></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                ControlToValidate="TextBox1" ErrorMessage="Please enter valid Name" 
                ForeColor="Red" ValidationExpression="^[a-zA-Z]+"></asp:RegularExpressionValidator>
        </td><td></td>
    </tr>
      <tr>
        <td class="style1">
            <asp:Label ID="Label3" runat="server" Text="Last Name"></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="TextBox2" runat="server" CssClass="txtbox" ></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                ErrorMessage="Please enter valid name" ForeColor="Red" 
                ValidationExpression="^[a-zA-Z]+" ControlToValidate="TextBox2"></asp:RegularExpressionValidator>
        </td><td></td>
    </tr>
      <tr>
        <td class="style1">
            <asp:Label ID="Label4" runat="server" Text="Email Address"  ></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="TextBox3" runat="server" CssClass="txtbox"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ControlToValidate="TextBox3" ErrorMessage="Please enter valid  Email address" 
                ForeColor="Red" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td><td></td>
    </tr>
      <tr>
        <td class="style1">
            <asp:Label ID="Label5" runat="server" Text="Mobile No."></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="TextBox4" runat="server" MaxLength="10" CssClass="txtbox" ></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="TextBox4" ErrorMessage="Please Enter valid Mobile no." 
                ForeColor="Red" ValidationExpression="^([7-9]{1})([0-9]{9})"></asp:RegularExpressionValidator>
        </td><td></td>
    </tr>
      <tr>
        <td class="style1">
            <asp:Label ID="Label6" runat="server" Text="Alternate No."></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="TextBox5" runat="server" CssClass="txtbox" MaxLength="10"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                ControlToValidate="TextBox5" ErrorMessage="Please enter valid no." 
                ForeColor="Red" ValidationExpression="^([7-9]{1})([0-9]{9})"></asp:RegularExpressionValidator>
        </td><td></td>
    </tr>
      <tr>
        <td class="style1">
            <asp:Label ID="Label7" runat="server" Text="Product"></asp:Label>
        </td>
        <td class="style2">
            <asp:DropDownList ID="DropDownList2" CssClass="itemHighlighted" runat="server">
                <asp:ListItem Value=null>--Select--</asp:ListItem>
                <asp:ListItem>Missed Call</asp:ListItem>
                <asp:ListItem>Vphone</asp:ListItem>
            </asp:DropDownList>
        </td><td></td>
    </tr>
      <tr>
        <td class="style1">
            <asp:Label ID="Label8" runat="server" Text="Plan Type"></asp:Label>
        </td>
        <td class="style2">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal" AutoPostBack="True" 
                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" style="font-size:13px;">
                <asp:ListItem>Postpaid</asp:ListItem>
                <asp:ListItem>Prepaid</asp:ListItem>
            </asp:RadioButtonList>
        </td><td></td>
    </tr>
      <tr>
        <td class="style1">
            <asp:Label ID="Label9" runat="server" Text="Choose a plan"></asp:Label>
        </td>
        <td class="style2">
            <asp:DropDownList ID="DropDownList3"  CssClass="itemHighlighted" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList3_SelectedIndexChanged">
                <asp:ListItem Value="Null">--Select--</asp:ListItem>
            </asp:DropDownList>
        </td><td></td>
    </tr>
      <tr>
        <td class="style1">
            <asp:Label ID="Label10" runat="server" Text="City"></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="TextBox6" runat="server" CssClass="txtbox" ></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                ControlToValidate="TextBox6" ErrorMessage="Please enter valid City name " 
                ForeColor="Red" ValidationExpression="^[a-zA-Z_ ]+"></asp:RegularExpressionValidator>
        </td><td></td>
    </tr>
      <tr>
        <td class="style1">
            <asp:Label ID="Label11" runat="server" Text="State"></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="TextBox7" runat="server" CssClass="txtbox" ></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                ControlToValidate="TextBox7" ErrorMessage="Please enter valid State name" 
                ForeColor="Red" ValidationExpression="^[a-zA-Z_ ]+"></asp:RegularExpressionValidator>
        </td><td></td>
    </tr>
      <tr>
        <td class="style1">
            <asp:Label ID="Label12" runat="server" Text="Profession"></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="TextBox8" runat="server" CssClass="txtbox" ></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                ControlToValidate="TextBox8" ErrorMessage="Please enter valid Profession name" 
                ForeColor="Red" ValidationExpression="^[a-zA-Z_ ]+"></asp:RegularExpressionValidator>
        </td><td></td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label13" runat="server" Text="Call Credit"></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="TextBox9" runat="server" CssClass="txtbox" AutoPostBack="True" 
                ontextchanged="TextBox9_TextChanged"></asp:TextBox>
      <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" 
                ControlToValidate="TextBox9" ErrorMessage="Please enter valid call credits" 
                ForeColor="Red" ValidationExpression="^[0-9]+" SetFocusOnError="True"></asp:RegularExpressionValidator>--%>
        </td><td></td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label14" runat="server" Text="Validity Period"></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="TextBox10" runat="server" CssClass="txtbox" 
                AutoPostBack="True" ontextchanged="TextBox10_TextChanged" ></asp:TextBox>days
            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" 
                runat="server" ControlToValidate="TextBox10" 
                ErrorMessage="Please enter correct  validity period" ForeColor="Red" 
                ValidationExpression="^[0-9]+"></asp:RegularExpressionValidator>
        </td><td>
            <asp:Label ID="Label22" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label15" runat="server" Text="Mode"></asp:Label>
        </td>
        <td class="style2">
            <asp:RadioButtonList ID="RadioButtonList2" CssClass=".radio" runat="server" 
                RepeatDirection="Horizontal" style="font-size:13px;" >
                <asp:ListItem>Single</asp:ListItem>
                <asp:ListItem>Multilevel</asp:ListItem>
            </asp:RadioButtonList>
        </td><td></td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label16" runat="server" Text="Concurrent-Call"></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="TextBox11" runat="server" CssClass="txtbox" AutoPostBack="True" 
                ontextchanged="TextBox11_TextChanged"></asp:TextBox>
            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator10" 
                runat="server" ControlToValidate="TextBox11" 
                ErrorMessage="Please Enter valid concurrent call details" ForeColor="Red" 
                ValidationExpression="^[0-9]"></asp:RegularExpressionValidator>--%>
        </td><td></td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label17" runat="server" Text="Welcome Message"></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="TextBox12" runat="server" CssClass="txtbox" Height="20px" 
                Width="140px" TextMode="MultiLine" ></asp:TextBox>
        </td><td></td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label18" runat="server" Text="Record Every Call"></asp:Label>
        </td>
        <td class="style2">
            <asp:RadioButtonList ID="RadioButtonList3" runat="server" 
                RepeatDirection="Horizontal" style="font-size:13px;" >
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:RadioButtonList>
        </td><td></td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label20" runat="server" Text="Amount"></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="TextBox13"  CssClass="txtbox" runat="server" 
                ontextchanged="TextBox13_TextChanged" AutoPostBack="True"></asp:TextBox>
            <asp:Label ID="Label21" runat="server" Text=""></asp:Label></td>
        
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label19" runat="server" Text="Payment Mode"></asp:Label>
        </td>
        <td class="style2">
            <asp:RadioButtonList ID="RadioButtonList4" runat="server" 
                RepeatDirection="Horizontal" style="font-size:13px;" >
                <asp:ListItem>Cash</asp:ListItem>
                <asp:ListItem>Cheque</asp:ListItem>
                <asp:ListItem>Online</asp:ListItem>
            </asp:RadioButtonList>
        </td><td></td>
    </tr>
      <tr>
        <td class="style1">
            
        </td>
        <td class="style2">
        <asp:Button ID="Button1" runat="server" CssClass="button_grey" Text="Submit" onclick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" CssClass="button_grey" Text="Reset" onclick="Button2_Click" />
        </td>
    </tr>
  
</table>
<br /><br />
</center>

</asp:Content>


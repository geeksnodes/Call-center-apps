<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="operate1.aspx.cs" Inherits="operate1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<%--<script type="text/javascript">
    function look() {
        var param = document.getElementById('ContentPlaceHolder1LinkButton1'); 
        if (param != "") {
            param.style = 'block';
            console.log(param);
        }
        console.log('test') ;
       </script>--%>
<center>
<table style="margin-top:40px;border-spacing:10px;outline: #D8D8D8 solid; " >
 <tr>
            <td>
                <asp:Label ID="Label37" runat="server" Text="DID"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label38" runat="server" Text="Label"></asp:Label>
            </td>
            </tr>
   <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Ticket Id"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Mobile"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="Alternate No."></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Product"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label13" runat="server" Text="Type"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label15" runat="server" Text="Choose Plan"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label17" runat="server" Text="City"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="Label19" runat="server" Text="State"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="Label21" runat="server" Text="Profession"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="Label23" runat="server" Text="Call Credit"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="Label25" runat="server" Text="Period"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="Label27" runat="server" Text="Mode"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="Label29" runat="server" Text="Concurrent Call"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label30" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="Label31" runat="server" Text="Message "></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label32" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="Label33" runat="server" Text="Recovery"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label34" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="Label35" runat="server" Text="Payment"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label36" runat="server" Text="Label"></asp:Label>
            </td>
            </tr>
            <tr>
            <td>
                <asp:Label ID="Label39" runat="server" Text="Status"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label43" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
           <tr>
            <td>
                <asp:Label ID="Label40" runat="server" Text="Voice Prompt"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal" 
                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                    AutoPostBack="True">
                    <asp:ListItem>Received</asp:ListItem>
                    <asp:ListItem>Not Received</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label41" runat="server" Text="Configuration Process"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                    RepeatDirection="Horizontal" EnableTheming="True" 
                    onselectedindexchanged="RadioButtonList2_SelectedIndexChanged" 
                    AutoPostBack="True">
                    <asp:ListItem>Process</asp:ListItem>
                    <asp:ListItem>Hold</asp:ListItem>
                    <asp:ListItem>Completed</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label42" runat="server" Text="Testing"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList3" runat="server" 
                    RepeatDirection="Horizontal" EnableTheming="True">
                    <asp:ListItem>Process</asp:ListItem>
                    <asp:ListItem>Done</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
          <tr>
            <td>
               
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
            </td>
        </tr>

       </table>
       <br /><br />
       </center>
</asp:Content>
<%--</div>--%>

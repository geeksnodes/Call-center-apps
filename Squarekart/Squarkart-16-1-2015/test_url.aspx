<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="test_url.aspx.cs" Inherits="test_url" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <center> <div style="margin-top:25px;" >
        <asp:Panel ID="Paneltest" runat="server">
           <table>
               <tr>
                   <td>
                       Mobile No.
                   </td>
                   <td>
                       <asp:TextBox ID="txtmob" runat="server" MaxLength="10" ></asp:TextBox>
                       </td>
                   <td>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmob" ErrorMessage="*" ForeColor="Red" ValidationGroup="valtest"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmob" ErrorMessage="*" ForeColor="Red" ValidationExpression="^(([7-9]{1})([0-9]{9}))+" ValidationGroup="valtest"></asp:RegularExpressionValidator>
                   
                   </td>
               </tr>
               <tr>
                   <td>
                       Agent ID
                   </td>
                   <td>
                       <asp:TextBox ID="txtagent" runat="server"></asp:TextBox>
                   </td>
                   <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtagent" ErrorMessage="*" ForeColor="Red" ValidationGroup="valtest"></asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr>
                   <td>
                       Call ID
                   </td>
                   <td>
                       <asp:TextBox ID="txtcall" runat="server"></asp:TextBox>
                   </td>
                   <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtcall" ErrorMessage="*" ForeColor="Red" ValidationGroup="valtest"></asp:RequiredFieldValidator>
                   </td>
               </tr>
               <tr>
                   <td align="center" colspan="3">
                       <asp:Button ID="btn_test" runat="server" Text="Call" OnClick="btn_test_Click" style="height: 26px" ValidationGroup="valtest" />
                   </td>
                   
               </tr>
           </table>
              
        </asp:Panel>
    </div>
       </center>
</asp:Content>


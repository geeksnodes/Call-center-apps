<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="accountmain.aspx.cs" Inherits="accountmain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<%--<div style=" margin-top:80px; ">--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<center>
    <table>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" CssClass=".btnSearch" 
                    Text="New Records" onclick="Button1_Click" />
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" CssClass=".btnSearch" 
                    Text="Old Records" onclick="Button2_Click" />
            </td>
        </tr>
    </table>
</center>

</asp:Content>
<%--</div>--%>

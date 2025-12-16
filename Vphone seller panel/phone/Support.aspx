<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Support.aspx.cs" Inherits="Support" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<%--<div style=" margin-top:80px; ">--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center>
<asp:GridView ID="GridView1" runat="server" CssClass="mGrid" AutoGenerateColumns="False" 
            onpageindexchanged="GridView1_PageIndexChanged" 
            onpageindexchanging="GridView1_PageIndexChanging" 
            onrowcommand="GridView1_RowCommand" PageSize="20" 
            AllowPaging="True">
            <Columns>
                
                <asp:TemplateField>
                    <HeaderTemplate>
                        Ticket no.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="open" CommandArgument='<%#Eval("ticket") %>'> <%#Eval("ticket") %></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Name
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label18" runat="server" Text='<%#Eval("name1") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Email
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label19" runat="server" Text='<%#Eval("email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Mobile no.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label20" runat="server" Text='<%#Eval("mobile") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Date
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label21" runat="server" Text='<%#Eval("dat") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField>
                    <HeaderTemplate>
                        Time
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label22" runat="server" Text='<%#Eval("tim") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
         </center>
</asp:Content>
<%--</div>--%>
 

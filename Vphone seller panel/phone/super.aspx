<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="super.aspx.cs" Inherits="super" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<%--<div style=" margin-top:80px; ">--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" AutoGenerateColumns="False" 
        AllowPaging="True" onpageindexchanged="GridView1_PageIndexChanged" 
        onpageindexchanging="GridView1_PageIndexChanging" 
        onrowcommand="GridView1_RowCommand" PageSize="20" 
    onrowdatabound="GridView1_RowDataBound">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    Date
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("dat") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Time
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("tim") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    DID
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("did") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
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
                    <asp:Label ID="Label15" runat="server" Text='<%#Eval("name1") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Amount
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Seller
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("seller_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Status
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("status1") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField>
                <HeaderTemplate>
                    Accountant
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label12" runat="server" Text='<%#Eval("accountant_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    Configuration
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("config") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Testing
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("test") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField>
                <HeaderTemplate>
                    Operation
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label13" runat="server" Text='<%#Eval("operator_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField>
                <HeaderTemplate>
                    Answer
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("super") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>
    <center>
        <table>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" CssClass="button_grey" Text="Click here for Notification " 
                        onclick="Button1_Click" />  
                </td>
            </tr>
        </table>
    </center>
   
    <br /><br />
</asp:Content>
<%--</div>--%>


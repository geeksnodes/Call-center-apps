<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="super2.aspx.cs" Inherits="super2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<%--<div style=" margin-top:80px; ">--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" AutoGenerateColumns="False" 
            onpageindexchanged="GridView1_PageIndexChanged" 
            onpageindexchanging="GridView1_PageIndexChanging" 
            onrowcommand="GridView1_RowCommand" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" 
            onselectedindexchanging="GridView1_SelectedIndexChanging" PageSize="20" 
            AllowPaging="True" onrowdatabound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Ticket no.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="open" CommandArgument='<%#Eval("ticket") %>' > <%#Eval("ticket") %></asp:LinkButton>
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
                        Plan
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label23" runat="server" Text='<%#Eval("choose_plan") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField>
                    <HeaderTemplate>
                      Validity Period
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label25" runat="server" Text='<%#Eval("period") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Amount
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label24" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
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
                  <asp:TemplateField>
                <HeaderTemplate>
                    Answer
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("super1") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            </Columns>
        </asp:GridView>
    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Click here for back</asp:LinkButton>
    <br /><br />
</asp:Content>

<%--</div>--%>
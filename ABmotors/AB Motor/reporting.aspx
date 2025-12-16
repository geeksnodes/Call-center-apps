<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="reporting.aspx.cs" Inherits="reporting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>

<div>
    
     <div>
          <b><asp:Label ID="Label1" runat="server" Font-Size="22px" Text="Mapping"></asp:Label></b>
 </div>


<div style="padding-top:10px;">

       <asp:GridView ID="GridView1" runat="server" Width = "100%"
AutoGenerateColumns = "false"  CssClass="mGrid" PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt"   AllowPaging ="true"  ShowFooter = "true" 
OnPageIndexChanging = "OnPaging" onrowediting="EditCustomer"
onrowupdating="UpdateCustomer"  onrowcancelingedit="CancelEdit"
PageSize = "10" >
<RowStyle  HorizontalAlign="Center"/>
<AlternatingRowStyle HorizontalAlign="Center"/>
   <Columns>
       
        <asp:TemplateField HeaderText="User ID">
        <ItemTemplate>
          <asp:Label ID="lblID" runat="server" Text='<%# Eval("user_id")%>'></asp:Label>
        </ItemTemplate>
       
        <FooterTemplate>
         <asp:TextBox ID="txtid" runat="server" Text=""></asp:TextBox>
        </FooterTemplate>
        </asp:TemplateField>
       <asp:TemplateField HeaderText="Role">
           <ItemTemplate>
               <asp:Label ID="lblCnum" runat="server" Text='<%# Eval("role")%>'></asp:Label>
           </ItemTemplate>
           <EditItemTemplate>
               <asp:TextBox ID="txtCnum" runat="server" Text='<%# Eval("role")%>'></asp:TextBox>
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox ID="txtCnum" runat="server"></asp:TextBox>
           </FooterTemplate>
       </asp:TemplateField>
       <asp:TemplateField HeaderText="Password">
           <ItemTemplate>
               <asp:Label ID="lblpass" runat="server" Text='<%# Eval("password")%>'></asp:Label>
           </ItemTemplate>
           <EditItemTemplate>
               <asp:TextBox ID="txtpass" runat="server" Text='<%# Eval("password")%>'></asp:TextBox>
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox ID="txtpass" runat="server"></asp:TextBox>
           </FooterTemplate>
       </asp:TemplateField>
         <asp:TemplateField HeaderText="Activate/deactivate">
           <ItemTemplate>
               <asp:Label ID="lblAgList" runat="server" Text='<%# Eval("is_active")%>'></asp:Label>
           </ItemTemplate>
           <EditItemTemplate>
               <asp:TextBox ID="txtAgList" runat="server" Text='<%# Eval("is_active")%>'></asp:TextBox>
           </EditItemTemplate>
           <FooterTemplate>
           <asp:TextBox ID="txtAgList" runat="server" ></asp:TextBox>
           </FooterTemplate>
       </asp:TemplateField>
       <asp:TemplateField>
    <ItemTemplate>
        <asp:LinkButton ID="lnkRemove" runat="server"
            CommandArgument = '<%# Eval("user_id")%>'
         OnClientClick = "return confirm('Do you want to delete this row?')"
        Text = "" OnClick = "DeleteCustomer"  ><img src="Images/Close.png" /></asp:LinkButton>
    </ItemTemplate>
    <FooterTemplate>
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick = "AddNewCustomer"  />
    </FooterTemplate>
</asp:TemplateField>
<asp:CommandField  ShowEditButton="True" EditImageUrl="~/Images/Edit.png"  UpdateImageUrl="~/Images/Ok.png" CancelImageUrl="~/Images/cancel.png"  ButtonType="Image"/>
   </Columns>
    </asp:GridView>

</div> </div>
  <div style="float:right;margin-right:0px;margin-top:10px;">
        <asp:Button ID="Button1" runat="server" Text="Download Bulk Data" CssClass="but" OnClick="Button1_Click"></asp:Button>
    </div>
   
        </center>
</asp:Content>


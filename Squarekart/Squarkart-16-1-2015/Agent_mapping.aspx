<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Agent_mapping.aspx.cs" Inherits="Agent_mapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div style="width:500px; text-align:center; margin:0px auto;">
<br /><h3 style="text-align:center;">Agent Mapping</h3><br />
</div>
<div class="lightbox" style="width:580px; margin:0px auto; padding-top:10px; text-align:center;">

  <center>  <asp:GridView ID="GridView1" runat="server" Width = "550px"
AutoGenerateColumns = "false"  CssClass="mGrid" PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt"   AllowPaging ="true"  ShowFooter = "true" 
OnPageIndexChanging = "OnPaging" onrowediting="EditCustomer"
onrowupdating="UpdateCustomer"  onrowcancelingedit="CancelEdit"
PageSize = "10" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
<RowStyle  HorizontalAlign="Center"/>
<AlternatingRowStyle HorizontalAlign="Center"/>
   <Columns>
       
        <asp:TemplateField HeaderText="ID">
        <ItemTemplate>
          <asp:Label ID="lblID" runat="server" Text='<%# Container.DataItemIndex+1  %>'></asp:Label>
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
        </asp:TemplateField>
       <asp:TemplateField HeaderText="Called Number">
           <ItemTemplate>
               <asp:Label ID="lblCnum" runat="server" Text='<%# Eval("knumber")%>'></asp:Label>
           </ItemTemplate>
           <EditItemTemplate>
               <asp:TextBox ID="txtCnum" runat="server" Text='<%# Eval("knumber")%>'></asp:TextBox>
           </EditItemTemplate>
           <FooterTemplate>
            <asp:TextBox ID="txtCnum" runat="server"></asp:TextBox>
           </FooterTemplate>
       </asp:TemplateField>
         <asp:TemplateField HeaderText="Agent List">
           <ItemTemplate>
               <asp:Label ID="lblAgList" runat="server" Text='<%# Eval("agent_list")%>'></asp:Label>
           </ItemTemplate>
           <EditItemTemplate>
               <asp:TextBox ID="txtAgList" runat="server" Text='<%# Eval("agent_list")%>'></asp:TextBox>
           </EditItemTemplate>
           <FooterTemplate>
           <asp:TextBox ID="txtAgList" runat="server" ></asp:TextBox>
           </FooterTemplate>
       </asp:TemplateField>
       <asp:TemplateField>
    <ItemTemplate>
        <asp:LinkButton ID="lnkRemove" runat="server"
            CommandArgument = '<%# Eval("knumber")%>'
         OnClientClick = "return confirm('Do you want to delete this row?')"
        Text = "" OnClick = "DeleteCustomer"  ><img src="img/Close.png" /></asp:LinkButton>
    </ItemTemplate>
    <FooterTemplate>
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick = "AddNewCustomer"  />
    </FooterTemplate>
</asp:TemplateField>
<asp:CommandField  ShowEditButton="True" EditImageUrl="~/img/Edit.png"  UpdateImageUrl="~/img/Ok.png" CancelImageUrl="~/img/cancel.png"  ButtonType="Image"/>
   </Columns>
    </asp:GridView></center>

</div>

</asp:Content>


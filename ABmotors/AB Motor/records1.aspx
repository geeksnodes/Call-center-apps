<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="records1.aspx.cs" Inherits="records1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <div>
        <table>
             
              <tr>
                  <td>
                    <asp:TextBox ID="txtstart" runat="server" CssClass="boxshadow" placeholder="From"  ></asp:TextBox>
                      <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtstart" CssClass="cal_Theme1"></asp:CalendarExtender>
                        </td>
                  <td>
                      <asp:TextBox ID="txtend" runat="server" CssClass="boxshadow" placeholder="To" ></asp:TextBox>
                       <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtend" CssClass="cal_Theme1" ></asp:CalendarExtender>
                     
                        </td>
                  <td class="fldControl">
                  <asp:DropDownList ID="DropDownstatus"  CssClass="boxshadowdrop" runat="server">
                      <asp:ListItem Selected="True">--</asp:ListItem>
                      <asp:ListItem>Missed</asp:ListItem>
                      <asp:ListItem>Connected</asp:ListItem>
                      <asp:ListItem>Called Back</asp:ListItem>
                      <asp:ListItem>Not Connected</asp:ListItem>
                   </asp:DropDownList>
                   </td>
                  <td>
                    <asp:Button ID="btnsearch" runat="server" CssClass="but" Text="Search" OnClick="btnsearch_Click" ></asp:Button>
                  </td>
              </tr>
          </table>
        <asp:GridView ID="gvrecords" runat="server" CssClass="mGrid" AllowPaging="True" 
            AutoGenerateColumns="False" OnPageIndexChanging="gvrecords_PageIndexChanging" 
            PageSize="20" onrowdatabound="gvrecords_RowDataBound">
            <Columns>
                   <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton_calllog" runat="server" OnClick="Call_log_details_edit" CommandName='<%# Eval("key_pressed")%>' CommandArgument = '<%# Eval("id")%>' ><img src="Images/Close.png" height="20px" width="20px" /></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:TemplateField>
                    <HeaderTemplate>
                        ##
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnUpdate" runat="server" OnClick="btnup" CommandName='<%# Eval("key_pressed")%>' CommandArgument = '<%# Eval("id")%>' ><img src="Images/incoming.png" height="20px" width="20px" /></asp:LinkButton>
                     
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        ID
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Extention ID
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("key_pressed") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Status
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("caller_status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField>
                    <HeaderTemplate>
                       Called No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcalled" runat="server" Text='<%#Eval("called_number") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Caller Name
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcaller_name" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField>
                    <HeaderTemplate>
                        Caller No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcaller" runat="server" Text='<%#Eval("caller_number") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField>
                    <HeaderTemplate>
                        Duration
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("caller_duration") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField>
                    <HeaderTemplate>
                        Date
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Labeldate" runat="server" Text='<%#Eval("date") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField>
                    <HeaderTemplate>
                        Time
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("time") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
              
            </Columns>
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <EmptyDataTemplate>
             <center><h3>No records found..</h3></center>
            </EmptyDataTemplate>
            
        </asp:GridView>
        <br />
   
    <asp:Panel ID="Panel1" runat="server">
         <asp:ModalPopupExtender ID="ModalPopup_call_log" runat="server" TargetControlID="calllog_open"
                        PopupControlID="Panel_edit_details" BackgroundCssClass="modalBackground" DropShadow="true">
                    </asp:ModalPopupExtender>
    <asp:Panel ID="Panel_edit_details" runat="server" CssClass="pnlBackGround">
          <br /><br />
          Reference No.<asp:TextBox ID="txt_reference" runat="server" CssClass="boxshadow"></asp:TextBox><br />
        <br />
          
          <br /><br /><center>
              
              <asp:Button ID="btncalllog_ok" runat="server" Text="OK" CssClass="button_green" OnClick="calllog_ok"  ></asp:Button>
              <asp:Button id="btncalllog_cancel" runat="server" Text="Cancel" CssClass="button_red"></asp:Button><br />
              <asp:Label id="calllog_err" runat="server" Text="" Color="red" ></asp:Label>
              <asp:HiddenField id="calllog_open" runat="server"></asp:HiddenField>
               <asp:HiddenField id="hidden_missed" runat="server"></asp:HiddenField>
          </center>

    </asp:Panel>
        </asp:Panel>
         </div>
</asp:Content>


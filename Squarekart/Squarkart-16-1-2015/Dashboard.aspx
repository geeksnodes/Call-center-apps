<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard"  EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script>

        function PrintContent() {

            var DocumentContainer = document.getElementById('print_ticket');
            var printButton = document.getElementById('printButton');
            printButton.style.visibility = 'hidden';
            var closeButton = document.getElementById('btnClose');
            closeButton.style.visibility = 'hidden';
            var WindowObject = window.open("", "PrintWindow", "width=750,height=650,top=50,left=50,toolbars=no,scrollbars=yes,status=no,resizable=yes");
            WindowObject.document.write();
            WindowObject.document.writeln(DocumentContainer.innerHTML);
            WindowObject.document.close();
            WindowObject.focus();
            WindowObject.print();
            printButton.style.visibility = 'visible';
            closeButton.style.visibility = 'visible';
            WindowObject.close();
        }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <center>
        <div>
            
            <div>
            <table>
                <tr>
                    <td>
                    From
                    </td>
                    <td>
                    To
                    </td>
                    <td>
                    Mobile No.
                    </td>
                    <td>
                    Name
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <asp:TextBox ID="txtfrom" runat="server"></asp:TextBox>
                          <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtfrom" 
                        Format="yyyy-MM-dd" CssClass="cal_Theme1" />
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ValidationExpression="^(19|20)\d\d[\- /.](0[1-9]|1[012])[\- /.](0[1-9]|[12][0-9]|3[01])$" ValidationGroup="valsearch" ControlToValidate="txtfrom"></asp:RegularExpressionValidator>
                              
                    </td>
                    <td>
                     <asp:TextBox ID="txtto" runat="server"></asp:TextBox>
                          <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtto" 
                        Format="yyyy-MM-dd" CssClass="cal_Theme1" />
                         <asp:RegularExpressionValidator ID="RegularExpressionValidatorfatdob" runat="server" ErrorMessage="*" ForeColor="Red" ValidationExpression="^(19|20)\d\d[\- /.](0[1-9]|1[012])[\- /.](0[1-9]|[12][0-9]|3[01])$" ValidationGroup="valsearch" ControlToValidate="txtto"></asp:RegularExpressionValidator>
                              
                    </td>
                    
                    <td>
                     <asp:TextBox ID="txtmob" runat="server" MaxLength="10"></asp:TextBox>
                    </td>
                    <td>
                     <asp:TextBox ID="txtname" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnsearch" runat="server" Text="Search" 
                           ValidationGroup="valsearch" onclick="btnsearch_Click" class="button_grey" />
                    </td>
                </tr>
            </table>
<br>
            </div>
            <div>
                <asp:Button ID="btnadd" runat="server" Text="Add" OnClick="btnadd_Click" class="button_grey" />
                <asp:Button ID="btnedit" runat="server" Text="Edit" OnClick="btnedit_Click" class="button_grey" />
                <asp:Button ID="btnview" runat="server" Text="View" OnClick="btnview_Click" class="button_grey" />
                <asp:Button ID="btnXls" runat="server" Text="Export to Excel"   CssClass="button_grey" Enabled="true" OnClick="btnXls_Click"  />
            </div>
    <div style="padding:10px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="mGrid" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="25" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                       ##
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField>
                    <HeaderTemplate>
                       Ticket No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblticket" runat="server" Text='<%#Eval("ticket_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Customer Name
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("uname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Customer No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("mobile_no") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        Alternate No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("alternate_no") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Email
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Date of Birth
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("dob") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Credit Card No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("credit_card_no") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                     <HeaderTemplate>
                       
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="print" CommandArgument='<%#Eval("ticket_id") %>'>Print</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
            <center><h3>No records found..</h3></center>
            </EmptyDataTemplate>
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
        <br />
    </div>
           <div>
                <asp:Button ID="Button1" runat="server" Text="Add" OnClick="btnadd_Click" class="button_grey" />
                <asp:Button ID="Button2" runat="server" Text="Edit" OnClick="btnedit_Click" class="button_grey" />
                <asp:Button ID="Button3" runat="server" Text="View" OnClick="btnview_Click" class="button_grey" />
                 <asp:Button ID="Button4" runat="server" Text="Export to Excel"   CssClass="button_grey" Enabled="true" OnClick="btnXls_Click"  />
                </div>
            <br />
        </div>
</center>
       <asp:LinkButton Style="display: none" ID="_mLinkButton" runat="server"></asp:LinkButton>
                    <asp:ModalPopupExtender ID="mpePrint" runat="server" TargetControlID="_mLinkButton"
                        PopupControlID="pnlPrint" BackgroundCssClass="modalBackground" DropShadow="true" CancelControlID="btnClose">
                    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPrint" runat="server" CssClass="pnlBackGround" Height="550px" Width="650px">
    <div id="print_ticket">
    <center> <img src="img/sfblogo.png" alt="Citelum" /></center>
    <center>
        <asp:DetailsView ID="DetailsView1" runat="server" Height="350px" CellPadding="2"
            CellSpacing="2" Width="650px" CssClass="mGrid" AutoGenerateRows="false" RowStyle-HorizontalAlign="Left"
            GridLines="Both">
            <Fields>
                <asp:BoundField HeaderText="Ticket ID" DataField="ticket_id" ControlStyle-Font-Bold="true" />
                <asp:BoundField HeaderText="Customer Number" DataField="mobile_no" />
                <asp:BoundField HeaderText="Customer Name" DataField="uname" />
                <asp:BoundField HeaderText="Email" DataField="email" />
                <asp:BoundField HeaderText="Alternate No." DataField="alternate_no" />
                <asp:BoundField HeaderText="Date" DataField="dat" />
                <asp:BoundField HeaderText="DOB" DataField="dob" />
                <asp:BoundField HeaderText="Spouse Name" DataField="spouse_name" />
                <asp:BoundField HeaderText="Spouse No." DataField="spouse_mobile" />
                <asp:BoundField HeaderText="Address" DataField="resident_add" />

            </Fields>
        </asp:DetailsView></center>
        <center>
            <input id="printButton" value="Print" type="button"  class="button_grey"  onclick="PrintContent()" />&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="btnClose" type="button" value="Close" class="button_grey" />
          
        </center>
    </div>
    </asp:Panel>
</asp:Content>


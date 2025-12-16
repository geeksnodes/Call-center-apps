<%@ Page Title="" Language="C#" MasterPageFile="~/FirstPage.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="dashboard" EnableEventValidation="false" %>

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
         var WindowObject = window.open("", "PrintWindow","width=750,height=650,top=50,left=50,toolbars=no,scrollbars=yes,status=no,resizable=yes");
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
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
 <div class="noprint">
    <div class="topbox" style="width:1000px; height:100px !important;  color:#888; margin-top:5px;  " >
        <table cellpadding="2" cellspacing="2">
            <tr>
                <td>
                    <span>From Date</span><br />
                    <asp:TextBox ID="txtDate" runat="server" Width="110px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" 
                        Format="yyyy-MM-dd" CssClass="cal_Theme1">
                    </asp:CalendarExtender>
                </td>
                <td>
                    <span>To Date</span><br />
                    <asp:TextBox ID="txtTo" runat="server" Width="110px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                        Format="yyyy-MM-dd" CssClass="cal_Theme1">
                    </asp:CalendarExtender>
                </td>
                <td>
                    Classification:<br />
                    <asp:DropDownList ID="ddlClassification" runat="server" CssClass="tb10" Width="110px">
                        <asp:ListItem Value="">All</asp:ListItem>
                        <asp:ListItem Value="AMC">AMC</asp:ListItem>
                        <asp:ListItem Value="CCRS">CCRS</asp:ListItem>
                        <asp:ListItem Value="Night Round">Night Round</asp:ListItem>
                        <asp:ListItem Value="Toll Free">Toll Free</asp:ListItem>
                        <asp:ListItem Value="Other">Other</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    Zone:<br />
                    <asp:DropDownList ID="ddlZone" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged"
                        CssClass="tb10" Width="110px">
                        <asp:ListItem Value="">All</asp:ListItem>
                        <asp:ListItem Value="A">Central</asp:ListItem>
                        <asp:ListItem Value="B">East</asp:ListItem>
                        <asp:ListItem Value="C">New West</asp:ListItem>
                        <asp:ListItem Value="D">North</asp:ListItem>
                        <asp:ListItem Value="E">South</asp:ListItem>
                        <asp:ListItem Value="F">West</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    Ward:<br />
                    <asp:DropDownList ID="ddlWard" runat="server" CssClass="tb10" Width="110px">
                    </asp:DropDownList>
                </td>
                <td>
                    Ticket Status:<br />
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="tb10" Width="110px">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem Value="0">Open</asp:ListItem>
                        <asp:ListItem Value="1">WIP</asp:ListItem>
                        <asp:ListItem Value="2">Hold</asp:ListItem>
                        <asp:ListItem Value="3">Closed</asp:ListItem>
                    </asp:DropDownList>
                </td>
            <td>Ticket Number<br />
                <asp:TextBox ID="txtTicketNo" runat="server" Width="110px"></asp:TextBox>
            </td>
            <td>
            Call Transfer Status:<br />
                <asp:DropDownList ID="ddlCallTrans" runat="server" CssClass="tb10" Width="110px">
                     <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem Value="Missed">Missed</asp:ListItem>
                        <asp:ListItem Value="Connected">Connected</asp:ListItem>
                        <asp:ListItem Value="NoCallTransfer">NoCallTransfer</asp:ListItem>
                </asp:DropDownList>
            </td>
            </tr>
            <tr>
           
                <td colspan="8" align="center">
                    <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="button_grey" Width="130px" OnClick="btnShow_Click"  />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnXls" runat="server" Text="Export to Excel" OnClick="btnXls_Click"
                        CssClass="button_grey" Width="130px" Enabled="true" />
                </td>
            </tr>
        </table>
      
    </div>
    <div style="width: 980px;  padding: 10px; margin:0px auto;">
        <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
        <center>
            <asp:GridView ID="GridView1" runat="server" CellPadding="10" AllowPaging="true" PageSize="50"
                PagerSettings-Mode="Numeric"  AutoGenerateColumns="false" Width="980px"
                GridLines="None" CssClass="mGrid" PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt" 
                OnPageIndexChanging="GridView1_PageIndexChanging" 
                onrowcommand="GridView1_RowCommand"  >
                <RowStyle HorizontalAlign="Center"/>
                <AlternatingRowStyle HorizontalAlign="Center" />
                <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="Check" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ticket_id" HeaderText="Ticket No" />
                <asp:BoundField DataField="date" HeaderText="Date"  ItemStyle-Wrap="false" />
                <asp:BoundField DataField="time" HeaderText="Time" />
                <asp:BoundField DataField="customer_number" HeaderText="Customer Number" />
                <asp:BoundField DataField="customer_name" HeaderText="Customer Name" />
                <asp:BoundField DataField="zone_description" HeaderText="Zone" />
                <asp:BoundField DataField="ward_description" HeaderText="Ward" />
                <asp:BoundField DataField="poll_number" HeaderText="Pole Number" />
                <asp:BoundField DataField="ticket_status_description" HeaderText="Ticket Status" />
                    <asp:TemplateField HeaderText="Print">
                        <ItemTemplate>
                             
                            <asp:LinkButton ID="btnPrint" runat="server" Text="Print" CssClass="btnd" CommandName="print"
                                CommandArgument="<%# Container.DataItemIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            <EmptyDataTemplate>
            <h3>No records found..</h3>
            </EmptyDataTemplate>
        </asp:GridView>
         <table width="300px" style="margin:0px auto;" cellpadding="8" cellspacing="8">
            <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" CssClass="button_grey" />
                </td>
                <td>
                    <asp:Button ID="btnView" runat="server" Text="View" onclick="btnView_Click" CssClass="button_grey" />
                </td>
                <td>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" onclick="btnEdit_Click" CssClass="button_grey" />
                </td>
            </tr>
        </table></center>
    </div>
   </div>
   <asp:LinkButton Style="display: none" ID="_mLinkButton" runat="server"></asp:LinkButton>
                    <asp:ModalPopupExtender ID="mpePrint" runat="server" TargetControlID="_mLinkButton"
                        PopupControlID="pnlPrint" BackgroundCssClass="modalBackground" DropShadow="true" CancelControlID="btnClose">
                    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlPrint" runat="server" CssClass="pnlBackGround" Height="550px" Width="650px">
    <div id="print_ticket">
    <center>  <img src="http://knowlarity.drivesu.in/img/Citelum-small.jpg" alt="Citelum" /></center>
    <center>
        <asp:DetailsView ID="DetailsView1" runat="server" Height="350px" CellPadding="2"
            CellSpacing="2" Width="650px" CssClass="mGrid" AutoGenerateRows="false" RowStyle-HorizontalAlign="Left"
            GridLines="Both">
            <Fields>
                <asp:BoundField HeaderText="Ticket ID" DataField="ticket_id" ControlStyle-Font-Bold="true" />
                <asp:BoundField HeaderText="Customer Number" DataField="customer_number" />
                <asp:BoundField HeaderText="Customer Name" DataField="customer_name" />
                <asp:BoundField HeaderText="Date" DataField="Date" />
                <asp:BoundField HeaderText="Time" DataField="time" />
                <asp:BoundField HeaderText="Zone" DataField="zone_description" />
                <asp:BoundField HeaderText="Ward" DataField="ward_description" />
                <asp:BoundField HeaderText="Poll Number" DataField="poll_number" />
                <asp:BoundField HeaderText="Classification" DataField="classification" />
                <asp:BoundField HeaderText="Address" DataField="landmark" />
                <asp:BoundField HeaderText="Ticket Status" DataField="ticket_status_description" />
                <asp:BoundField HeaderText="Remarks" DataField="remark" />
            </Fields>
        </asp:DetailsView></center>
        <center>
            <input id="printButton" value="Print" type="button"  class="button_grey"  onclick="PrintContent()" />&nbsp;&nbsp;&nbsp;&nbsp;
            <input id="btnClose" type="button" value="Close" class="button_grey" />
          
        </center>
    </div>
    </asp:Panel>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="dashboard_service.aspx.cs" Inherits="dashboard_service" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function validate_search() {
            var mobile = document.getElementById('<%= txtmob.ClientID %>').value;
            if (mobile != "") {
                var pattern = /^\+?\d+[0-9]+$/;
                if (!pattern.test(mobile)) {
                    document.getElementById('<%= txtmob.ClientID %>').focus();
                    document.getElementById('<%= txtmob.ClientID %>').setAttribute("style", "border:1px solid red");

                    return false;
                }
                else {
                    document.getElementById('<%= txtmob.ClientID %>').setAttribute("style", "border:1px solid #dedede");

                }
            }
            else {
                document.getElementById('<%= txtmob.ClientID %>').setAttribute("style", "border:1px solid #dedede");

            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
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
                  <td>
                    <asp:TextBox ID="txtmob" runat="server" MaxLength="13" CssClass="boxshadow" placeholder="Mobile No." ></asp:TextBox>
                  </td>
                  <td>
                    <asp:Button ID="btnsearch" runat="server" CssClass="but" Text="Search" OnClick="btnsearch_Click" OnClientClick="return validate_search()" ></asp:Button>
                  </td>
              </tr>
          </table>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btn_add" runat="server" CssClass="but" Text="ADD" OnClick="btn_add_Click" Visible="false"></asp:Button>
                    </td>
                    <td>
                        <asp:Button ID="btnedit" runat="server" CssClass="but" Text="EDIT" OnClick="btnedit_Click" Visible="false"></asp:Button>
                    </td>
                    <td>
                        <asp:Button ID="btndelete" runat="server" CssClass="but" Text="DELETE" OnClick="btndelete_Click" Visible="false"></asp:Button>
                    </td>
                    <td>
                        <asp:Button ID="btn_export" runat="server" CssClass="but" Text="Export in CSV" OnClick="btn_export_Click"></asp:Button>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblerr" runat="server" Text="" ForeColor="Red" ></asp:Label>
                    </td>
                </tr>
            </table>
        <asp:Panel ID="Panel1" runat="server">
            <asp:GridView ID="GridView1" runat="server" CssClass="mGrid" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            ##
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chk1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Ticket No.
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("ticket") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Name
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Mobile No.
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("alternate_no") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                        <HeaderTemplate>
                            Alternate No.
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_alternate" runat="server" Text='<%#Eval("alternate_no2") %>'></asp:Label>
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
                           Location
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblloc" runat="server" Text='<%#Eval("location") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                        <HeaderTemplate>
                           Source of Enq
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblsource" runat="server" Text='<%#Eval("source") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Type
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbldiesel" runat="server" Text='<%#Eval("diesel_petrol") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Car Model
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblcarmodel" runat="server" Text='<%#Eval("car_model") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Model Year
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblmodel_year" runat="server" Text='<%#Eval("model_year") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                           Km Done
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblkm" runat="server" Text='<%#Eval("km_done") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Prefer Date Time
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblpreferdate" runat="server" Text='<%#Eval("prefer_date_time") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Pick Up
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblpickup" runat="server" Text='<%#Eval("required_pickup") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                        <HeaderTemplate>
                            Agent ID
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Labelag" runat="server" Text='<%#Eval("executive_id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Sale/service
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("role") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                           Date
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("date_of_entry") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                           Time
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbltime" runat="server" Text='<%#Eval("time_of_entry") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                 <EmptyDataTemplate>
            <center><h3>No records found..</h3></center>
            </EmptyDataTemplate>
                <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
            </asp:GridView>
        </asp:Panel>
            </div>
    </center>
      <br />
</asp:Content>



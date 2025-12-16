<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="customer_profile.aspx.cs" Inherits="complaint" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    --%>
    <div style="margin-left: 10px; margin-right: 10px;">
        <center>
            <asp:Panel ID="Panelbasic" runat="server">
                <fieldset style="border: 1px solid #000; margin-top: 10px;">
                    <legend>Customer Details</legend>
                    <center>
                        <table align="center" style="margin-top: 15px; width: 1000px;" cellpadding="4" cellspacing="4">
                            <tr>
                                <td width="200px">
                                    <span>First Name</span>
                                </td>
                                <td width="200px" align="right">
                                    <asp:TextBox ID="txtname" runat="server" CssClass="txt"></asp:TextBox>
                                </td>
                                <td width="100px">
                                    <asp:RequiredFieldValidator ID="reqfvName" runat="server" ErrorMessage="*" ControlToValidate="txtname"
                                        Font-Bold="True" ForeColor="Red" ValidationGroup="valcomp"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regvName" runat="server" ErrorMessage="*" ControlToValidate="txtname"
                                        Font-Bold="True" ForeColor="Red" ValidationExpression="^[a-zA-Z_ ]+" ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                                </td>
                                <td width="200px">
                                    <span>Last Name</span>
                                </td>
                                <td align="right" width="200px">
                                    <asp:TextBox ID="txtname2" runat="server" CssClass="txt"></asp:TextBox>
                                </td>
                                <td width="100px">
                                    <asp:RequiredFieldValidator ID="reqfvName2" runat="server" ErrorMessage="*" ControlToValidate="txtname2"
                                        Font-Bold="True" ForeColor="Red" ValidationGroup="valcomp"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regvName2" runat="server" ErrorMessage="*" ControlToValidate="txtname2"
                                        Font-Bold="True" ForeColor="Red" ValidationExpression="^[a-zA-Z_ ]+" ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Mobile No.</span>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtmob" runat="server" MaxLength="10" CssClass="txt"></asp:TextBox>
                                </td>
                                <td>
                                     <asp:Label ID="lblerr" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    <asp:RequiredFieldValidator ID="reqfvMob" runat="server" ErrorMessage="*" ControlToValidate="txtmob"
                                        Font-Bold="True" ForeColor="Red" ValidationGroup="valcomp"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="regvMob" runat="server" ErrorMessage="*" ControlToValidate="txtmob"
                                        Font-Bold="True" ForeColor="Red" ValidationExpression="^(([7-9]{1})([0-9]{9}))+"
                                        ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                                </td>
                                <td>
                                    <span>Alternate No.</span>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtalternate" runat="server" MaxLength="10" CssClass="txt"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="regvAlt" runat="server" ErrorMessage="*" ControlToValidate="txtalternate"
                                        Font-Bold="True" ForeColor="Red" ValidationExpression="^(([7-9]{1})([0-9]{9}))+"
                                        ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Email</span>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtemail" runat="server" CssClass="txt"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="reqfvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtemail"
                                        Font-Bold="True" ForeColor="Red" ValidationGroup="valcomp"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                            ID="regvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtemail" Font-Bold="True"
                                            ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                                </td>
                                <td>
                                    <span>Date of Birth</span>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtdob" runat="server" CssClass="txt"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdob"
                                        Format="yyyy-MM-dd" CssClass="cal_Theme1">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="reqfvDob" runat="server" ErrorMessage="*" ControlToValidate="txtdob"
                                        Font-Bold="True" ForeColor="Red" ValidationGroup="valcomp"></asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ValidationExpression="^(19|20)\d\d[\- /.](0[1-9]|1[012])[\- /.](0[1-9]|[12][0-9]|3[01])$" ValidationGroup="valcomp" ControlToValidate="txtdob"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Gender</span>
                                </td>
                                <td align="right">
                                    <asp:RadioButtonList ID="Radiogender" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <span>Marital Status</span>
                                </td>
                                <td align="right">
                                    <asp:RadioButtonList ID="Radiomarital" runat="server" RepeatDirection="Horizontal"
                                        OnSelectedIndexChanged="Radiomarital_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem>Married</asp:ListItem>
                                        <asp:ListItem Selected="True">Unmarried</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldmarital" runat="server" ErrorMessage="*"
                                        ControlToValidate="Radiomarital" Font-Bold="True" ForeColor="Red" ValidationGroup="valcomp"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: middle;">
                                    <span>Residential Address</span>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtresident" runat="server" CssClass="mtxt" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="reqfvResAdd" runat="server" ErrorMessage="*" ControlToValidate="txtresident"
                                        Font-Bold="True" ForeColor="Red" ValidationGroup="valcomp"></asp:RequiredFieldValidator>
                                </td>
                                <td style="vertical-align: middle;">
                                    <span>Official Address </span>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtofficial" runat="server" CssClass="mtxt" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Delivery Address same as Residential</span>
                                </td>
                                <td align="center">
                                    <asp:CheckBox ID="Checkadd" runat="server" AutoPostBack="True" OnCheckedChanged="Checkadd_CheckedChanged" />
                                </td>
                                <td>
                                </td>
                                <td style="vertical-align: middle;">
                                    <span>Delivery Address</span>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtdelivery" runat="server" CssClass="mtxt" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </center>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="pnlSpouse" runat="server" Visible="False">
                <fieldset style="border: 1px solid #000; margin-top: 10px;">
                    <legend>Spouse and Children Details</legend>
                    <center>
                        <table style="margin-top: 15px; width: 1000px;">
                            <tr>
                                <td width="200px">
                                    <span>Spouse Name </span>
                                </td>
                                <td width="200px" align="right">
                                    <asp:TextBox ID="txtspouse" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                                </td>
                                <td width="100px">
                                </td>
                                <td width="200px">
                                    <span>Mobile No.</span>
                                </td>
                                <td align="right" width="200px">
                                    <asp:TextBox ID="txtspouse_mob" runat="server" MaxLength="10" Enabled="False"></asp:TextBox>
                                </td>
                                <td width="100px">
                                    <asp:RegularExpressionValidator ID="regvSp_Mob" runat="server" ErrorMessage="*" ControlToValidate="txtspouse_mob"
                                        Font-Bold="True" ForeColor="Red" ValidationExpression="^(([7-9]{1})([0-9]{9}))+"
                                        ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Alternate No. </span>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtspouse_alternate" runat="server" MaxLength="10" CssClass="txt"
                                        Enabled="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RegularExpressionValidator ID="regvSp_Alt" runat="server" ErrorMessage="*" ControlToValidate="txtspouse_alternate"
                                        Font-Bold="True" ForeColor="Red" ValidationExpression="^(([7-9]{1})([0-9]{9}))+"
                                        ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                                </td>
                                <td>
                                    <span>Date of Birth</span>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtspouse_dob" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtspouse_dob"
                                        Format="yyyy-MM-dd" CssClass="cal_Theme1">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2anniver" runat="server" ErrorMessage="*" ForeColor="Red" ValidationExpression="^(19|20)\d\d[\- /.](0[1-9]|1[012])[\- /.](0[1-9]|[12][0-9]|3[01])$" ValidationGroup="valcomp" ControlToValidate="txtspouse_dob"></asp:RegularExpressionValidator>
                              
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Aniversary Date</span>
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtanniversary" runat="server" CssClass="txt"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtanniversary"
                                        Format="yyyy-MM-dd" CssClass="cal_Theme1">
                                    </asp:CalendarExtender>
                                </td>
                                <td>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidatoranndat2" runat="server" ErrorMessage="*" ForeColor="Red" ValidationExpression="^(19|20)\d\d[\- /.](0[1-9]|1[012])[\- /.](0[1-9]|[12][0-9]|3[01])$" ValidationGroup="valcomp" ControlToValidate="txtanniversary"></asp:RegularExpressionValidator>
                              
                                </td>
                                <td>
                                    <span>No. of Children</span>
                                </td>
                                <td align="right">
                                    <asp:DropDownList ID="DropDownchildren" runat="server" CssClass="txt" AutoPostBack="True"
                                        OnSelectedIndexChanged="DropDownchildren_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="Panelhigh" runat="server" Visible="False">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="900px"  BackColor="#f2f2f2">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            S.No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("child") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Child Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtname1" runat="server" MaxLength="25" Text='<%#Eval("tname") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Mobile No.
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtmobile1" runat="server" MaxLength="10" Text='<%#Eval("tmob") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            School Name
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtschool1" runat="server" MaxLength="45" CssClass="txt" Text='<%#Eval("tschool") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle  HorizontalAlign="Center"/>
                                <RowStyle HorizontalAlign="Center" />
                            </asp:GridView>
                        </asp:Panel>
                    </center>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Paneladditional" runat="server">
                <fieldset style="border: 1px solid #000; margin-top: 10px;">
                    <legend>Ownership Details</legend>
                    <table align="center" style="margin-top: 15px; width: 1000px;">
                        <tr>
                            <td>
                                <span style="padding-right: 40px;">Credit card No.(Last 4 digit) </span>
                            </td>
                            <td colspan="5" align="left">
                                <asp:TextBox ID="txtcredit" runat="server" MaxLength="4" CssClass="txt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="padding-right: 40px;">Car Owner</span>
                            </td>
                            <td align="left">
                                <asp:RadioButtonList ID="Radiocar" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                    OnSelectedIndexChanged="Radiocar_SelectedIndexChanged">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <span style="padding-right: 20px; padding-left: 40px;">Brand</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbrand" runat="server" CssClass="txt" Enabled="false"></asp:TextBox>
                            </td>
                            <td>
                                <span style="padding-right: 30px; padding-left: 50px;">Car No.</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtcar_no" runat="server" CssClass="txt" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panelmedium" runat="server">
                <fieldset style="border: 1px solid #000; margin-top: 10px;">
                    <legend>Family Details</legend>
                    <table align="center" style="margin-top: 15px; width: 1000px;">
                        <tr>
                            <td>
                                <span style="padding-right: 40px;">Father Name</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtfather_name" runat="server" CssClass="txt"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <span style="padding-right: 20px; padding-left: 40px;">Mobile No.</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtfather_mob" runat="server" MaxLength="10" CssClass="txt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtfather_mob" Font-Bold="True" ForeColor="Red" ValidationExpression="^(([7-9]{1})([0-9]{9}))+"
                                    ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <span style="padding-right: 20px; padding-left: 40px;">Date of Birth</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtfather_dob" runat="server" CssClass="txt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtfather_dob"
                                    Format="yyyy-MM-dd" CssClass="cal_Theme1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidatorfatdob" runat="server" ErrorMessage="*" ForeColor="Red" ValidationExpression="^(19|20)\d\d[\- /.](0[1-9]|1[012])[\- /.](0[1-9]|[12][0-9]|3[01])$" ValidationGroup="valcomp" ControlToValidate="txtfather_dob"></asp:RegularExpressionValidator>
                              
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="padding-right: 40px;">Mother Name</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtmother_name" runat="server" CssClass="txt"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <span style="padding-right: 20px; padding-left: 40px;">Mobile No.</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtmother_mob" runat="server" MaxLength="10" CssClass="txt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                    ErrorMessage="*" ControlToValidate="txtmother_mob" Font-Bold="True" ForeColor="Red"
                                    ValidationExpression="^(([7-9]{1})([0-9]{9}))+" ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <span style="padding-right: 20px; padding-left: 40px;">Date of Birth</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtmotherdob" runat="server" CssClass="txt"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtmotherdob"
                                    Format="yyyy-MM-dd" CssClass="cal_Theme1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidatormomdob" runat="server" ErrorMessage="*" ForeColor="Red" ValidationExpression="^(19|20)\d\d[\- /.](0[1-9]|1[012])[\- /.](0[1-9]|[12][0-9]|3[01])$" ValidationGroup="valcomp" ControlToValidate="txtmotherdob"></asp:RegularExpressionValidator>
                              
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="padding-right: 40px;">Brother Name</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbrother_name" runat="server" CssClass="txt"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <span style="padding-right: 20px; padding-left: 40px;">Mobile No.</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbrother_mob" runat="server" MaxLength="10" CssClass="txt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtbrother_mob" Font-Bold="True" ForeColor="Red" ValidationExpression="^(([7-9]{1})([0-9]{9}))+"
                                    ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <span style="padding-right: 20px; padding-left: 40px;">Date of Birth</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtbrother_dob" runat="server" CssClass="txt"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtbrother_dob"
                                    Format="yyyy-MM-dd" CssClass="cal_Theme1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidatorbrodob" runat="server" ErrorMessage="*" ForeColor="Red" ValidationExpression="^(19|20)\d\d[\- /.](0[1-9]|1[012])[\- /.](0[1-9]|[12][0-9]|3[01])$" ValidationGroup="valcomp" ControlToValidate="txtbrother_dob"></asp:RegularExpressionValidator>
                         
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="padding-right: 40px;">Sister Name</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsister_name" runat="server" CssClass="txt"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <span style="padding-right: 20px; padding-left: 40px;">Mobile No.</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsister_mob" runat="server" MaxLength="10" CssClass="txt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                    ErrorMessage="*" ControlToValidate="txtsister_mob" Font-Bold="True" ForeColor="Red"
                                    ValidationExpression="^(([7-9]{1})([0-9]{9}))+" ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <span style="padding-right: 20px; padding-left: 40px;">Date of Birth</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsister_dob" runat="server" CssClass="txt"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtsister_dob"
                                    Format="yyyy-MM-dd" CssClass="cal_Theme1">
                                </asp:CalendarExtender>
                            </td>
                            <td>
                           <asp:RegularExpressionValidator ID="RegularExpressionValidatorsisdob" runat="server" ErrorMessage="*" ForeColor="Red" ValidationExpression="^(19|20)\d\d[\- /.](0[1-9]|1[012])[\- /.](0[1-9]|[12][0-9]|3[01])$" ValidationGroup="valcomp" ControlToValidate="txtsister_dob"></asp:RegularExpressionValidator>
                         
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panel1" runat="server" Style="margin-top: 10px;">
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click"
                    ValidationGroup="valcomp" class="button_grey" />
            </asp:Panel>
        </center>
    </div>
    <br />
    <br />
</asp:Content>

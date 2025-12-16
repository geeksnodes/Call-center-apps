<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="service.aspx.cs" Inherits="service" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function formvalidation() {
            // Name validation
            var fname = document.getElementById('<%= txtname.ClientID %>').value;
            if (fname == "") {
                document.getElementById('<%= txtname.ClientID %>').focus();
                document.getElementById('<%= txtname.ClientID %>').setAttribute("style", "border:1px solid red");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "*Please Enter name";
                return false;
            }

            else {
                document.getElementById('<%= txtname.ClientID %>').setAttribute("style", "border:1px solid #dedede");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "";
            }

            //Mobile Number Validation
            var mobile = document.getElementById('<%= txtalternate.ClientID %>').value;
            var pattern = /^\+?\d+[0-9]+$/;
            if (!pattern.test(mobile)) {
                document.getElementById('<%= txtalternate.ClientID %>').focus();
                document.getElementById('<%= txtalternate.ClientID %>').setAttribute("style", "border:1px solid red");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "*Invalid Mobile no.";
                return false;
            }
            else {
                document.getElementById('<%= txtalternate.ClientID %>').setAttribute("style", "border:1px solid #dedede");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "";
            }
            //alternate no.
            var mobile2 = document.getElementById('<%= txtalternate2.ClientID %>').value;
            var pattern = /^\+?\d+[0-9]+$/;
            if (mobile2 == "") {
                document.getElementById('<%= txtalternate2.ClientID %>').setAttribute("style", "border:1px solid #dedede");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "";
            }
            else {
                if (!pattern.test(mobile2)) {
                    document.getElementById('<%= txtalternate2.ClientID %>').focus();
                    document.getElementById('<%= txtalternate2.ClientID %>').setAttribute("style", "border:1px solid red");
                    document.getElementById('<%= lblerr.ClientID %>').innerHTML = "*Invalid Alternate no. ";
                    return false;
                }
                else {
                    document.getElementById('<%= txtalternate2.ClientID %>').setAttribute("style", "border:1px solid #dedede");
                    document.getElementById('<%= lblerr.ClientID %>').innerHTML = "";
                }
            }
            //Email Id validation
            var email = document.getElementById('<%= txtemail.ClientID %>').value;
            var pattern = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            if (email == "") {
                document.getElementById('<%= txtemail.ClientID %>').setAttribute("style", "border:1px solid #dedede");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "";
            }
            else {
                if (!pattern.test(email)) {
                    document.getElementById('<%= txtemail.ClientID %>').focus();
                    document.getElementById('<%= txtemail.ClientID %>').setAttribute("style", "border:1px solid red");
                    document.getElementById('<%= lblerr.ClientID %>').innerHTML = "*Invalid Email address ";
                    return false;
                }
                else {
                    document.getElementById('<%= txtemail.ClientID %>').setAttribute("style", "border:1px solid #dedede");
                    document.getElementById('<%= lblerr.ClientID %>').innerHTML = "";
                }
            }

            // source of enquiry
            var source_enq = document.getElementById('<%=DropDownsourceenq.ClientID%>').value;
            if (source_enq == "--") {
                document.getElementById('<%= DropDownsourceenq.ClientID %>').focus();
                document.getElementById('<%= DropDownsourceenq.ClientID %>').setAttribute("style", "border:1px solid red");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "*Select Source of Enq. ";
                return false;
            }
            else {
                document.getElementById('<%= DropDownsourceenq.ClientID %>').setAttribute("style", "border:1px solid #dedede");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "";
            }
            // location validation

            var loc = document.getElementById('<%= DropDownloc.ClientID %>').value;
            if (loc == "--") {
                document.getElementById('<%= DropDownloc.ClientID %>').focus();
                document.getElementById('<%= DropDownloc.ClientID %>').setAttribute("style", "border:1px solid red");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "*Select Location. ";
                return false;
            }
            else {
                document.getElementById('<%= DropDownloc.ClientID %>').setAttribute("style", "border:1px solid #dedede");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "";
            }
            //model interested
            var model_int = document.getElementById('<%=DropDownmodel.ClientID%>').value;
            if (model_int == "--") {
                document.getElementById('<%= DropDownmodel.ClientID %>').focus();
                document.getElementById('<%= DropDownmodel.ClientID %>').setAttribute("style", "border:1px solid red");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "*Select Car Model. ";
                return false;
            }
            else {
                document.getElementById('<%= DropDownmodel.ClientID %>').setAttribute("style", "border:1px solid #dedede");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "";
            }
            //Model year
            var yr = document.getElementById('<%= txtyear.ClientID %>').value;
            var pattern = /^[0-9]{4}$/;
            if (!pattern.test(yr)) {
                document.getElementById('<%= txtyear.ClientID %>').focus();
                document.getElementById('<%= txtyear.ClientID %>').setAttribute("style", "border:1px solid red");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "*Invalid Model Year";
                return false;
            }
            else {
                document.getElementById('<%= txtyear.ClientID %>').setAttribute("style", "border:1px solid #dedede");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "";
            }

            //kilometer done
            var km = document.getElementById('<%= txtkm.ClientID %>').value;
            var pattern = /^[0-9]+$/;
            if (!pattern.test(km)) {
                document.getElementById('<%= txtkm.ClientID %>').focus();
                document.getElementById('<%= txtkm.ClientID %>').setAttribute("style", "border:1px solid red");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "*Invalid Kilometer.";
                return false;
            }
            else {
                document.getElementById('<%= txtkm.ClientID %>').setAttribute("style", "border:1px solid #dedede");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "";
            }
            //Customer location
            var cust_loc = document.getElementById('<%= txtcustomer_loc.ClientID %>').value;
            if (cust_loc == "") {
                document.getElementById('<%= txtcustomer_loc.ClientID %>').focus();
                document.getElementById('<%= txtcustomer_loc.ClientID %>').setAttribute("style", "border:1px solid red");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "*Please Enter Customer location";
                return false;
            }

            else {
                document.getElementById('<%= txtcustomer_loc.ClientID %>').setAttribute("style", "border:1px solid #dedede");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "";
            }
            //Remark
            var remark = document.getElementById('<%= txtremark.ClientID %>').value;
            if (remark == "") {
                document.getElementById('<%= txtremark.ClientID %>').focus();
                document.getElementById('<%= txtremark.ClientID %>').setAttribute("style", "border:1px solid red");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "*Please Enter remark field.";
                return false;
            }

            else {
                document.getElementById('<%= txtremark.ClientID %>').setAttribute("style", "border:1px solid #dedede");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "";
            }
            var remark1 = document.getElementById('<%= txtremark.ClientID %>').value;
            if (remark1.length > 200) {
                document.getElementById('<%= txtremark.ClientID %>').focus();
                document.getElementById('<%= txtremark.ClientID %>').setAttribute("style", "border:1px solid red");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "*Maximum 200 character allow";
                return false;
            }

            else {
                document.getElementById('<%= txtremark.ClientID %>').setAttribute("style", "border:1px solid #dedede");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "";
            }

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" runat="server">
        <fieldset style="margin-left: 3%; margin-right: 3%; margin-bottom: 2%; margin-top: 2%">
            <legend><b>Service Enquiry</b></legend>
            <table align="center" width="70%" cellpadding="5" cellspacing="5" style="margin-top: 20px;">
                <tr>
                    <td class="fldName">
                        Name :
                    </td>
                    <td class="fldControl">
                        <asp:TextBox ID="txtname" runat="server" CssClass="boxshadow"></asp:TextBox>
                    </td>
                    <td class="fldName">
                        Mobile No. :
                    </td>
                    <td class="fldControl">
                        <asp:TextBox ID="txtalternate" runat="server" CssClass="boxshadow" MaxLength="14"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="fldName">
                        Alternate No. :
                    </td>
                    <td class="fldControl">
                        <asp:TextBox ID="txtalternate2" runat="server" CssClass="boxshadow" MaxLength="14"></asp:TextBox>
                    </td>
                    <td class="fldName">
                        Email :
                    </td>
                    <td class="fldControl">
                        <asp:TextBox ID="txtemail" runat="server" CssClass="boxshadow"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="fldName">
                        Source of enq. :
                    </td>
                    <td class="fldControl">
                        <asp:DropDownList ID="DropDownsourceenq" CssClass="boxshadowdrop" runat="server">
                            <asp:ListItem>--</asp:ListItem>
                            <asp:ListItem>Event</asp:ListItem>
                            <asp:ListItem>Internet/E-Lead</asp:ListItem>
                            <asp:ListItem>Media Advertisement</asp:ListItem>
                            <asp:ListItem>Phone-in</asp:ListItem>
                            <asp:ListItem>Previous Customer</asp:ListItem>
                            <asp:ListItem>Referral</asp:ListItem>
                            <asp:ListItem>Others</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="fldName">
                        Location :
                    </td>
                    <td class="fldControl">
                        <asp:DropDownList ID="DropDownloc" CssClass="boxshadowdrop" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="fldName">
                        Car Model. :
                    </td>
                    <td class="fldControl">
                        <asp:DropDownList ID="DropDownmodel" CssClass="boxshadowdrop" runat="server">
                            <asp:ListItem>--</asp:ListItem>
                            <asp:ListItem>Classic</asp:ListItem>
                            <asp:ListItem>Eco Sport</asp:ListItem>
                            <asp:ListItem>Endeavour</asp:ListItem>
                            <asp:ListItem>Fiesta</asp:ListItem>
                            <asp:ListItem>Figo</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="fldName">
                        Model Year :
                    </td>
                    <td class="fldControl">
                        <asp:TextBox ID="txtyear" runat="server" CssClass="boxshadow"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="fldName">
                        Type :
                    </td>
                    <td class="fldControl">
                        <asp:RadioButtonList ID="Radiodiesel" runat="server" Font-Size="14px" RepeatDirection="Horizontal">
                            <asp:ListItem>Diesel</asp:ListItem>
                            <asp:ListItem>Petrol</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="fldName">
                        Kilometer done :
                    </td>
                    <td class="fldControl">
                        <asp:TextBox ID="txtkm" runat="server" CssClass="boxshadow"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="fldName">
                        Prefer Date/Time :
                    </td>
                    <td class="fldControl">
                        <asp:TextBox ID="txtprefer_dat" runat="server" CssClass="boxshadowdat"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtprefer_dat"
                            CssClass="cal_Theme1">
                        </asp:CalendarExtender>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="boxshadowdat">
                            <asp:ListItem Selected="True" Value="0">00:00</asp:ListItem>
                            <asp:ListItem>01:00</asp:ListItem>
                            <asp:ListItem>01:15</asp:ListItem>
                            <asp:ListItem>01:30</asp:ListItem>
                            <asp:ListItem>01:45</asp:ListItem>
                            <asp:ListItem>02:00</asp:ListItem>
                            <asp:ListItem>02:15</asp:ListItem>
                            <asp:ListItem>02:30</asp:ListItem>
                            <asp:ListItem>02:45</asp:ListItem>
                            <asp:ListItem>03:00</asp:ListItem>
                            <asp:ListItem>03:15</asp:ListItem>
                            <asp:ListItem>03:30</asp:ListItem>
                            <asp:ListItem>03:45</asp:ListItem>
                            <asp:ListItem>04:00</asp:ListItem>
                            <asp:ListItem>04:15</asp:ListItem>
                            <asp:ListItem>04:30</asp:ListItem>
                            <asp:ListItem>04:45</asp:ListItem>
                            <asp:ListItem>05:00</asp:ListItem>
                            <asp:ListItem>05:15</asp:ListItem>
                            <asp:ListItem>05:30</asp:ListItem>
                            <asp:ListItem>05:45</asp:ListItem>
                            <asp:ListItem>06:00</asp:ListItem>
                            <asp:ListItem>06:15</asp:ListItem>
                            <asp:ListItem>06:30</asp:ListItem>
                            <asp:ListItem>06:45</asp:ListItem>
                            <asp:ListItem>07:00</asp:ListItem>
                            <asp:ListItem>07:15</asp:ListItem>
                            <asp:ListItem>07:30</asp:ListItem>
                            <asp:ListItem>07:45</asp:ListItem>
                            <asp:ListItem>08:00</asp:ListItem>
                            <asp:ListItem>08:15</asp:ListItem>
                            <asp:ListItem>08:30</asp:ListItem>
                            <asp:ListItem>08:45</asp:ListItem>
                            <asp:ListItem>09:00</asp:ListItem>
                            <asp:ListItem>09:15</asp:ListItem>
                            <asp:ListItem>09:30</asp:ListItem>
                            <asp:ListItem>09:45</asp:ListItem>
                            <asp:ListItem>10:00</asp:ListItem>
                            <asp:ListItem>10:15</asp:ListItem>
                            <asp:ListItem>10:30</asp:ListItem>
                            <asp:ListItem>10:45</asp:ListItem>
                            <asp:ListItem>11:00</asp:ListItem>
                            <asp:ListItem>11:15</asp:ListItem>
                            <asp:ListItem>11:30</asp:ListItem>
                            <asp:ListItem>11:45</asp:ListItem>
                            <asp:ListItem>12:00</asp:ListItem>
                            <asp:ListItem>12:15</asp:ListItem>
                            <asp:ListItem>12:30</asp:ListItem>
                            <asp:ListItem>12:45</asp:ListItem>
                            <asp:ListItem>13:00</asp:ListItem>
                            <asp:ListItem>13:15</asp:ListItem>
                            <asp:ListItem>13:30</asp:ListItem>
                            <asp:ListItem>13:45</asp:ListItem>
                            <asp:ListItem>14:00</asp:ListItem>
                            <asp:ListItem>14:15</asp:ListItem>
                            <asp:ListItem>14:30</asp:ListItem>
                            <asp:ListItem>14:45</asp:ListItem>
                            <asp:ListItem>15:00</asp:ListItem>
                            <asp:ListItem>15:15</asp:ListItem>
                            <asp:ListItem>15:30</asp:ListItem>
                            <asp:ListItem>15:45</asp:ListItem>
                            <asp:ListItem>16:00</asp:ListItem>
                            <asp:ListItem>16:15</asp:ListItem>
                            <asp:ListItem>16:30</asp:ListItem>
                            <asp:ListItem>16:45</asp:ListItem>
                            <asp:ListItem>17:00</asp:ListItem>
                            <asp:ListItem>17:15</asp:ListItem>
                            <asp:ListItem>17:30</asp:ListItem>
                            <asp:ListItem>17:45</asp:ListItem>
                            <asp:ListItem>18:00</asp:ListItem>
                            <asp:ListItem>18:15</asp:ListItem>
                            <asp:ListItem>18:30</asp:ListItem>
                            <asp:ListItem>18:45</asp:ListItem>
                            <asp:ListItem>19:00</asp:ListItem>
                            <asp:ListItem>19:15</asp:ListItem>
                            <asp:ListItem>19:30</asp:ListItem>
                            <asp:ListItem>19:45</asp:ListItem>
                            <asp:ListItem>20:00</asp:ListItem>
                            <asp:ListItem>20:15</asp:ListItem>
                            <asp:ListItem>20:30</asp:ListItem>
                            <asp:ListItem>20:45</asp:ListItem>
                            <asp:ListItem>21:00</asp:ListItem>
                            <asp:ListItem>21:15</asp:ListItem>
                            <asp:ListItem>21:30</asp:ListItem>
                            <asp:ListItem>21:45</asp:ListItem>
                            <asp:ListItem>22:00</asp:ListItem>
                            <asp:ListItem>22:15</asp:ListItem>
                            <asp:ListItem>22:30</asp:ListItem>
                            <asp:ListItem>22:45</asp:ListItem>
                            <asp:ListItem>23:00</asp:ListItem>
                            <asp:ListItem>23:15</asp:ListItem>
                            <asp:ListItem>23:30</asp:ListItem>
                            <asp:ListItem>23:45</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="fldName">
                        Req. pick up :
                    </td>
                    <td class="fldControl">
                        <asp:RadioButtonList ID="Radiopick" runat="server" Font-Size="14px" RepeatDirection="Horizontal">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="fldName1">
                        Customer Location:
                    </td>
                    <td class="fldControl">
                        <asp:TextBox ID="txtcustomer_loc" CssClass="boxshadow" runat="server"></asp:TextBox>
                    </td>
                    <td class="fldName">
                        Vehicle Reg. No. :
                    </td>
                    <td class="fldControl">
                        <asp:TextBox ID="txtVhRegNo" CssClass="boxshadow" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="fldName1">
                        Remark :
                    </td>
                    <td class="fldControl" colspan="3">
                        <asp:TextBox ID="txtremark" runat="server" CssClass="boxshadow" TextMode="MultiLine"
                            Width="630px" Height="50px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click"
                            OnClientClick="return formvalidation()" CssClass="but" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Label ID="lblerr" runat="server" Text="" class="fldName" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>
    <br />
</asp:Content>

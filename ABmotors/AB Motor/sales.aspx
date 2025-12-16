<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="sales.aspx.cs" Inherits="sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
            // location validation
            
            var loc = document.getElementById('<%= DropDownloc.ClientID %>').value;
            if (loc == "--")
            {
                document.getElementById('<%= DropDownloc.ClientID %>').focus();
                document.getElementById('<%= DropDownloc.ClientID %>').setAttribute("style", "border:1px solid red");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "*Select Location. ";
                return false;
            }
            else {
                document.getElementById('<%= DropDownloc.ClientID %>').setAttribute("style", "border:1px solid #dedede");
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
            //model interested
            var model_int = document.getElementById('<%=DropDownmodel.ClientID%>').value;
            if (model_int == "--") {
                document.getElementById('<%= DropDownmodel.ClientID %>').focus();
                document.getElementById('<%= DropDownmodel.ClientID %>').setAttribute("style", "border:1px solid red");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "*Select Model interested. ";
                return false;
            }
            else {
                document.getElementById('<%= DropDownmodel.ClientID %>').setAttribute("style", "border:1px solid #dedede");
                document.getElementById('<%= lblerr.ClientID %>').innerHTML = "";
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
            //remark
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<div width="70%" >
    <asp:Panel ID="Panel1" runat="server">
        <fieldset style="margin-left:3%;margin-right:3%;margin-bottom:2%;margin-top:2%" ><legend><b>Sale Enquiry</b></legend>
     
            <table align="center" cellpadding="5" cellspacing="0" width="70%">
                        <tr>
                            <td class="fldName">
                                Name :
                            </td>
                            <td class="fldControl">
                                <asp:TextBox ID="txtname" runat="server" CssClass="boxshadow" ></asp:TextBox>
                            </td>
                       
                            <td class="fldName">
                                Mobile No. :
                            </td>
                            <td class="fldControl">
                               <asp:TextBox ID="txtalternate" runat="server" CssClass="boxshadow" 
                                 MaxLength="14" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="fldName">
                                Alternate No. :
                            </td>
                            <td class="fldControl">
                                <asp:TextBox ID="txtalternate2" runat="server" CssClass="boxshadow" 
                                    MaxLength="14" ></asp:TextBox>
                            </td>
                       
                            <td class="fldName">
                                Email :
                            </td>
                            <td class="fldControl">
                                <asp:TextBox ID="txtemail" runat="server" CssClass="boxshadow" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            
                            <td class="fldName">
                                Profession :
                            </td>
                            <td class="fldControl">
                                <asp:TextBox ID="txtprof" runat="server" CssClass="boxshadow" ></asp:TextBox>
                            </td>
                        
                            <td class="fldName">
                                Location :
                            </td>
                            <td class="fldControl">
                                <asp:DropDownList ID="DropDownloc"  CssClass="boxshadowdrop" runat="server">
                                </asp:DropDownList>
                               </td>
                        </tr>
                         <tr>
                              <td class="fldName1">Customer Location:</td>
                             <td class="fldControl"><asp:TextBox ID="txtcustomer_loc" CssClass="boxshadow" runat="server"></asp:TextBox></td>
               
                            <td class="fldName">
                               Model Interested In :
                            </td>
                            <td class="fldControl">
                                <asp:DropDownList ID="DropDownmodel"  CssClass="boxshadowdrop" runat="server">
                                     <asp:ListItem>--</asp:ListItem>
                                    <asp:ListItem>Classic</asp:ListItem>
                                    <asp:ListItem>Eco Sport</asp:ListItem>
                                   <asp:ListItem>Endeavour</asp:ListItem>
                                    <asp:ListItem>Fiesta</asp:ListItem>
                                    <asp:ListItem>Figo</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
               
                <tr>
                     <td class="fldName">
                                Source of Enq. :
                            </td>
                            <td class="fldControl">
                               <asp:DropDownList ID="DropDownsourceenq"  CssClass="boxshadowdrop" runat="server">
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
                Diesel/Petrol : 
                </td>
                <td class="fldControl">
                <asp:RadioButtonList ID="Radiodiesel" runat="server" Font-Size="14px" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">Diesel</asp:ListItem>
                <asp:ListItem>Petrol</asp:ListItem>
                </asp:RadioButtonList>
                </td>
               
                </tr>
                <tr >
                     <td class="fldName">
                Test Drive : </td> 
                <td class="fldControl">
                <asp:RadioButtonList ID="Radiotest" runat="server" Font-Size="14px" RepeatDirection="Horizontal">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem  Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
                </td>
                   <td class="fldName">
                Interested In Exchange : 
                </td> 

                <td class="fldControl">
                <asp:RadioButtonList ID="Radioexchange" runat="server" Font-Size="14px" RepeatDirection="Horizontal">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
                </td>
                
                </tr>
               <tr>
                            <td class="fldName">
                               Current Vehicle Info.:
                            </td>
                            <td class="fldControl" >
                                <asp:TextBox ID="txtvehicle" runat="server" CssClass="boxshadow" TextMode="MultiLine" ></asp:TextBox>
                            </td>
                            <td class="fldName"">
                             Remark :
                            </td>
                            <td class="fldControl" >
                                <asp:TextBox ID="txtremark" runat="server" CssClass="boxshadow" 
                                   TextMode="MultiLine" ></asp:TextBox>
                             </td>
                        </tr>
               </table>
       <table align="center" cellpadding="5" cellspacing="0" width="70%" style="margin-top:10px;">
                        <tr>
                            <td align="center">
                                <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" OnClientClick="return formvalidation()" />
                                 </td>
                        </tr>
                         <tr>
                            <td  align="center">
                                <asp:Label ID="lblerr" runat="server" Text="" class="fldName" ForeColor="Red" ></asp:Label>
                            </td>
                        </tr>
                    </table>
        </fieldset>
    </asp:Panel>
   
    </div> <br /> <br />
    </center>
</asp:Content>


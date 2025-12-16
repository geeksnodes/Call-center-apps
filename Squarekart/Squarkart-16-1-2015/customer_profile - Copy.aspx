<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="customer_profile.aspx.cs" Inherits="complaint" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%-- <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
--%>
    <div style="margin-left:10px; margin-right:10px; " >
        <center>
        
           
            <asp:Panel ID="Panelbasic" runat="server" style="border: 1px solid #000; margin-top:10px;" >
                 <fieldset><legend></legend><center>
            <table align="center"  style="margin-left:45px;margin-top:15px;width:1050px;"  >
                    <tr>
                        <td>
                            <span>First Name</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtname" runat="server"  CssClass="txt" ></asp:TextBox>
                        </td>
                         <td>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                 ErrorMessage="*" ControlToValidate="txtname" Font-Bold="True" ForeColor="Red" 
                                 ValidationGroup="valcomp"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                     ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" 
                                 ControlToValidate="txtname" Font-Bold="True" ForeColor="Red" 
                                 ValidationExpression="^[a-zA-Z_ ]+" ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                        </td>
                        <td>
                             <span style="padding-right:20px; padding-left:80px;">Last Name</span>
                        </td>
                         <td>
                             <asp:TextBox ID="txtname2" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                 ErrorMessage="*" ControlToValidate="txtname2" Font-Bold="True" ForeColor="Red" 
                                 ValidationGroup="valcomp"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator
                                     ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" 
                                 ControlToValidate="txtname2" Font-Bold="True" ForeColor="Red" 
                                 ValidationExpression="^[a-zA-Z_ ]+" ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                <tr>
                        <td>
                            <span style="padding-right:20px;">Mobile No.</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtmob" runat="server" MaxLength="10" CssClass="txt"></asp:TextBox>
                        </td>
                         <td>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                 ErrorMessage="*" ControlToValidate="txtmob" Font-Bold="True" ForeColor="Red" 
                                 ValidationGroup="valcomp"></asp:RequiredFieldValidator>
                                  <asp:RegularExpressionValidator
                                     ID="RegularExpressionValidator3" runat="server" ErrorMessage="*" 
                                 ControlToValidate="txtmob" Font-Bold="True" ForeColor="Red" 
                                 ValidationExpression="^(([7-9]{1})([0-9]{9}))+" ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                       
                        </td>
                        <td>
                             <span style="padding-right:20px; padding-left:80px;">Alternate No.</span>
                        </td>
                         <td>
                             <asp:TextBox ID="txtalternate" runat="server" MaxLength="10" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                         <asp:RegularExpressionValidator
                                     ID="RegularExpressionValidator4" runat="server" ErrorMessage="*" 
                                 ControlToValidate="txtalternate" Font-Bold="True" ForeColor="Red" 
                                 ValidationExpression="^(([7-9]{1})([0-9]{9}))+" ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                       
                        </td>
                    </tr>
                <tr>
                        <td>
                             <span style="padding-right:20px;">Email</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtemail" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                         <td>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                 ErrorMessage="*" ControlToValidate="txtemail" Font-Bold="True" ForeColor="Red" 
                                 ValidationGroup="valcomp"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                     ID="RegularExpressionValidator5" runat="server" ErrorMessage="*" 
                                 ControlToValidate="txtemail" Font-Bold="True" ForeColor="Red" 
                                 ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                 ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                      
                        </td>
                        <td>
                             <span style="padding-right:20px; padding-left:80px;">Date of Birth</span>
                        </td>
                         <td>
                             <asp:TextBox ID="txtdob" runat="server" CssClass="txt"></asp:TextBox>
                               <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdob" 
                        Format="yyyy-MM-dd" CssClass="cal_Theme1">
                    </asp:CalendarExtender>
                        </td>
                        <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatordob" runat="server" 
                                 ErrorMessage="*" ControlToValidate="txtdob" Font-Bold="True" ForeColor="Red" 
                                 ValidationGroup="valcomp"></asp:RequiredFieldValidator>
                          
  
                        </td>
                    </tr>
                <tr>
                        <td>
                             <span style="padding-right:20px;">Gender</span>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="Radiogender" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                         <td>

                        </td>
                        <td>
                          <span style="padding-right:20px; padding-left:80px;">   Marital Status</span>
                        </td>
                         <td>
                             <asp:RadioButtonList ID="Radiomarital" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="Radiomarital_SelectedIndexChanged" AutoPostBack="True">
                                 <asp:ListItem>Married</asp:ListItem>
                                 <asp:ListItem Selected="True">Unmarried</asp:ListItem>
                             </asp:RadioButtonList>
                        </td>
                        <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldmarital" runat="server" 
                                 ErrorMessage="*" ControlToValidate="Radiomarital" Font-Bold="True" ForeColor="Red" 
                                 ValidationGroup="valcomp"></asp:RequiredFieldValidator>
                          
                        </td>
                    </tr>
                <tr>
                        <td>
                             <span style="padding-right:25px;">Spouse Name </span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtspouse" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                        </td>
                         <td>

                        </td>
                        <td>
                             <span style="padding-right:20px; padding-left:80px;">Mobile No.</span>
                        </td>
                         <td>
                             <asp:TextBox ID="txtspouse_mob" runat="server" MaxLength="10" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                              <asp:RegularExpressionValidator
                                     ID="RegularExpressionValidator6" runat="server" ErrorMessage="*" 
                                 ControlToValidate="txtspouse_mob" Font-Bold="True" ForeColor="Red" 
                                 ValidationExpression="^(([7-9]{1})([0-9]{9}))+" ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                   
                        </td>
                    </tr>
                <tr>
                        <td>
                             <span style="padding-right:25px;">Alternate No. </span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtspouse_alternate" runat="server" MaxLength="10" CssClass="txt" Enabled="False"></asp:TextBox>
                        </td>
                         <td>
                         <asp:RegularExpressionValidator
                                     ID="RegularExpressionValidator7" runat="server" ErrorMessage="*" 
                                 ControlToValidate="txtspouse_alternate" Font-Bold="True" ForeColor="Red" 
                                 ValidationExpression="^(([7-9]{1})([0-9]{9}))+" ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                       
                        </td>
                        <td>
                             <span style="padding-right:20px; padding-left:80px;">Date of Birth</span>
                        </td>
                         <td>
                             <asp:TextBox ID="txtspouse_dob" runat="server" CssClass="txt" Enabled="False"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtspouse_dob" 
                        Format="yyyy-MM-dd" CssClass="cal_Theme1">
                    </asp:CalendarExtender>
                        </td>
                        <td>
                         
  
                        </td>
                    </tr>


               <tr>
                        <td style="vertical-align:middle;">
                             <span style="padding-right:20px;">Residential Address</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtresident" runat="server" CssClass="mtxt"  TextMode="MultiLine"></asp:TextBox>
                        </td>
                         <td>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                 ErrorMessage="*" ControlToValidate="txtresident" Font-Bold="True" ForeColor="Red" 
                                 ValidationGroup="valcomp"></asp:RequiredFieldValidator>
                      
                        </td>
                        <td style="vertical-align:middle;">
                          <span style="padding-right:20px; padding-left:80px;"> Official Address </span>
                        </td>
                         <td>
                             <asp:TextBox ID="txtofficial" runat="server" CssClass="mtxt" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td>

                        </td>
                    </tr>
                <tr>
                        <td >
                             <span style="padding-right:25px;padding-top:-10px;"> Delivery Address same as Residential</span>
                        </td>
                        <td>
                           <asp:CheckBox ID="Checkadd" runat="server" AutoPostBack="True" OnCheckedChanged="Checkadd_CheckedChanged" />
                        </td>
                         <td>

                        </td>
                        <td style="vertical-align:middle;">
                              <span style="padding-right:20px; padding-left:80px;">Delivery Address</span>
                        </td>
                         <td>
                            <asp:TextBox ID="txtdelivery" runat="server" CssClass="mtxt" TextMode="MultiLine" ></asp:TextBox>
                        </td>
                        <td>

                        </td>
                    </tr>
                    
            </table></center>
               </fieldset>
            </asp:Panel>
            <asp:Panel ID="Paneladditional" runat="server" style="border: 1px solid #000; margin-top:10px;">
              <fieldset><legend></legend>
                  <table align="center" style="margin-top:15px;width:1000px;">
                   <tr>
                        <td>
                             <span style="padding-right:25px;">Credit card No.(Last 4 digit) </span>
                        </td>
                        <td>
                             <asp:TextBox ID="txtcredit" runat="server" MaxLength="4" CssClass="txt"></asp:TextBox>
                        </td>
                         <td>

                        </td>
                        <td>
                             
                        </td>
                         <td>
                          
                        </td>
                        <td>

                        </td>
                    </tr>
                    <tr>
                        <td>
                             <span style="padding-right:40px;">Car Owner</span>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="Radiocar" runat="server" RepeatDirection="Horizontal" 
                                AutoPostBack="True" onselectedindexchanged="Radiocar_SelectedIndexChanged">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                         <td>

                        </td>
                        <td>
                             <span style="padding-right:20px; padding-left:40px;"> Brand</span>
                        </td>
                         <td>
                             <asp:TextBox ID="txtbrand" runat="server" CssClass="txt" Enabled="false"></asp:TextBox>
                        </td>
                        <td>

                        </td>
                          <td>
                             <span style="padding-right:20px; padding-left:40px;"> Car No.</span>
                        </td>
                         <td>
                             <asp:TextBox ID="txtcar_no" runat="server" CssClass="txt" Enabled="false"></asp:TextBox>
                        </td>
                        <td>

                        </td>
                    </tr>
               </table>
                   </fieldset>
            </asp:Panel>
            <asp:Panel ID="Panelmedium" runat="server" style="border: 1px solid #000; margin-top:10px;" >
                <fieldset><legend></legend>
                <table align="center" style="margin-top:15px;width:1000px;">
                   
                     <tr>
                        <td>
                             <span style="padding-right:40px;">Father Name</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtfather_name" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                         <td>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                 ErrorMessage="*" ControlToValidate="txtfather_name" Font-Bold="True" ForeColor="Red" 
                                 ValidationGroup="valcomp"></asp:RequiredFieldValidator>
                      
                        </td>
                        <td>
                             <span style="padding-right:20px; padding-left:40px;"> Mobile No.</span>
                        </td>
                         <td>
                             <asp:TextBox ID="txtfather_mob" runat="server" MaxLength="10" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                        <asp:RegularExpressionValidator
                                     ID="RegularExpressionValidator8" runat="server" ErrorMessage="*" 
                                 ControlToValidate="txtfather_mob" Font-Bold="True" ForeColor="Red" 
                                 ValidationExpression="^(([7-9]{1})([0-9]{9}))+" ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                       
                        </td>
                          <td>
                             <span style="padding-right:20px; padding-left:40px;"> Date of Birth</span>
                        </td>
                         <td>
                             <asp:TextBox ID="txtfather_dob" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtfather_dob" 
                        Format="yyyy-MM-dd" CssClass="cal_Theme1">
                    </asp:CalendarExtender>
                        </td>
                    </tr>
                     <tr>
                        <td>
                             <span style="padding-right:40px;">Mother Name</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtmother_name" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                         <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                 ErrorMessage="*" ControlToValidate="txtmother_name" Font-Bold="True" ForeColor="Red" 
                                 ValidationGroup="valcomp"></asp:RequiredFieldValidator>
                                   
                      
                        </td>
                        <td>
                             <span style="padding-right:20px; padding-left:40px;">   Mobile No.</span>
                        </td>
                         <td>
                             <asp:TextBox ID="txtmother_mob" runat="server" MaxLength="10" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                        <asp:RegularExpressionValidator
                                     ID="RegularExpressionValidator10" runat="server" ErrorMessage="*" 
                                 ControlToValidate="txtmother_mob" Font-Bold="True" ForeColor="Red" 
                                 ValidationExpression="^(([7-9]{1})([0-9]{9}))+" ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                      
                        </td>
                          <td>
                             <span style="padding-right:20px; padding-left:40px;"> Date of Birth</span>
                        </td>
                         <td>
                             <asp:TextBox ID="txtmotherdob" runat="server" CssClass="txt"></asp:TextBox>
                             
                        <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtmotherdob" 
                        Format="yyyy-MM-dd" CssClass="cal_Theme1">
                    </asp:CalendarExtender>
                        </td>
                        <td>

                        </td>
                    </tr>
                    <tr>
                        <td>
                             <span style="padding-right:40px;">Brother Name</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtbrother_name" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                         <td>

                        </td>
                        <td>
                             <span style="padding-right:20px; padding-left:40px;">Mobile No.</span>
                        </td>
                         <td>
                             <asp:TextBox ID="txtbrother_mob" runat="server" MaxLength="10" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                        <asp:RegularExpressionValidator
                                     ID="RegularExpressionValidator9" runat="server" ErrorMessage="*" 
                                 ControlToValidate="txtbrother_mob" Font-Bold="True" ForeColor="Red" 
                                 ValidationExpression="^(([7-9]{1})([0-9]{9}))+" ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                      
                        </td>
                         <td>
                             <span style="padding-right:20px; padding-left:40px;"> Date of Birth</span>
                        </td>
                         <td>
                             <asp:TextBox ID="txtbrother_dob" runat="server" CssClass="txt"></asp:TextBox>
                             
                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtbrother_dob" 
                        Format="yyyy-MM-dd" CssClass="cal_Theme1">
                    </asp:CalendarExtender>
                        </td>
                        <td>

                        </td>
                    </tr>
                     <tr>
                        <td>
                             <span style="padding-right:40px;">Sister Name</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtsister_name" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                         <td>

                        </td>
                        <td>
                             <span style="padding-right:20px; padding-left:40px;">Mobile No.</span>
                        </td>
                         <td>
                             <asp:TextBox ID="txtsister_mob" runat="server" MaxLength="10" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                         <asp:RegularExpressionValidator
                                     ID="RegularExpressionValidator11" runat="server" ErrorMessage="*" 
                                 ControlToValidate="txtsister_mob" Font-Bold="True" ForeColor="Red" 
                                 ValidationExpression="^(([7-9]{1})([0-9]{9}))+" ValidationGroup="valcomp"></asp:RegularExpressionValidator>
                      
                        </td>
                         <td>
                             <span style="padding-right:20px; padding-left:40px;"> Date of Birth</span>
                        </td>
                         <td>
                             <asp:TextBox ID="txtsister_dob" runat="server" CssClass="txt"></asp:TextBox>
                             
                        <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtsister_dob" 
                        Format="yyyy-MM-dd" CssClass="cal_Theme1">
                    </asp:CalendarExtender>
                        </td>
                        <td>

                        </td>
                    </tr>
                   
                </table>
                   
                    </fieldset>
            </asp:Panel>

            <asp:Panel ID="Panelhigh" runat="server" Visible="False" style="border: 1px solid #000; margin-top:10px;">
             
                <table align="center" >
                     
                      <tr>
                        <td>
                             <span style="padding-right:28px; padding-left:-35px;">Aniversary Date</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtanniversary" runat="server" CssClass="txt"></asp:TextBox>
                            
                        <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtanniversary" 
                        Format="yyyy-MM-dd" CssClass="cal_Theme1">
                    </asp:CalendarExtender>
                        </td>
                         <td>
                        </td>
                        <td>
                        </td>
                        <td>
                             <span style="padding-right:20px; padding-left:340px;">No. of Children</span>
                        </td>
                         <td>
                             <asp:DropDownList ID="DropDownchildren" runat="server" CssClass="itemHighlighted" AutoPostBack="True" OnSelectedIndexChanged="DropDownchildren_SelectedIndexChanged">
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
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
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
                </asp:GridView>
                
            </asp:Panel>
            <asp:Panel ID="Panel1" runat="server"  style="margin-top:10px;" >
            <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" ValidationGroup="valcomp" />
            </asp:Panel>
            
        </center>
    </div>
    <br /><br />
</asp:Content>


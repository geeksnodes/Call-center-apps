<%@ Page Title="" Language="C#" MasterPageFile="~/FirstPage.master" MaintainScrollPositionOnPostback="true"
    AutoEventWireup="true" CodeFile="oncall.aspx.cs" Inherits="oncall" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/jplayer.blue.monday.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js">
    </script>
    <script src="js/jquery.jplayer.min.js" type="text/javascript"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <br />
    <center>
        <h3>
            ADD/VIEW/EDIT Complaint
        </h3>
    </center>
    <br />
    <asp:Panel ID="pnlForm" runat="server">
        <table cellpadding="8" cellspacing="8" width="900px" style="margin: 0px auto; padding: 20px;
            border: 2px solid #c1c1c1; border-radius: 5px; color: #888;">
            <tr>
                <td>
                    Customer Number:
                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ForeColor="Red" ErrorMessage="*" ControlToValidate="txtCustNo" ValidationGroup="newcomp"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtCustNo" runat="server" TabIndex="1" ValidationGroup="newcomp"></asp:TextBox>
                    <asp:HiddenField ID="hfCallID" runat="server" />
                </td>
                <td>
                    Customer Name:
                </td>
                <td>
                    <asp:TextBox ID="txtCustName" runat="server" TabIndex="2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Classification:
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" 
                    ControlToValidate="ddlClassification" InitialValue="0" ValidationGroup="newcomp"  ForeColor="Red" ></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlClassification" runat="server" TabIndex="3" CssClass="tb10" ValidationGroup="newcomp">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                        <asp:ListItem Value="AMC">AMC</asp:ListItem>
                        <asp:ListItem Value="CCRS">CCRS</asp:ListItem>
                        <asp:ListItem Value="Night Round">Night Round</asp:ListItem>
                        <asp:ListItem Value="Toll Free">Toll Free</asp:ListItem>
                        <asp:ListItem Value="Other">Other</asp:ListItem>
                    </asp:DropDownList>
                   
                </td>
                <td>
                    Zone:
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" 
                    ControlToValidate="ddlZone" InitialValue="0" ValidationGroup="newcomp"  ForeColor="Red" ></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlZone" runat="server" TabIndex="4" AutoPostBack="true" CssClass="tb10"
                     OnSelectedIndexChanged="ddlZone_SelectedIndexChanged" ValidationGroup="newcomp">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                        <asp:ListItem Value="A">Central</asp:ListItem>
                        <asp:ListItem Value="B">East</asp:ListItem>
                        <asp:ListItem Value="C">New West</asp:ListItem>
                        <asp:ListItem Value="D">North</asp:ListItem>
                        <asp:ListItem Value="E">South</asp:ListItem>
                        <asp:ListItem Value="F">West</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Ward:
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" 
                    ControlToValidate="ddlWard" InitialValue="select" ValidationGroup="newcomp" ForeColor="Red" ></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlWard" runat="server" TabIndex="5" CssClass="tb10" ValidationGroup="newcomp">
                    
                    </asp:DropDownList>
                </td>
                <td>
                    Pole Number:
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" 
                     ErrorMessage="*" ControlToValidate="txtPoleNo" ValidationGroup="newcomp"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtPoleNo" runat="server" TabIndex="6" ValidationGroup="newcomp"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Address:
                </td>
                <td>
                    <asp:TextBox ID="txtLandmark" runat="server" TabIndex="7"></asp:TextBox>
                </td>
                <td>
                    Customer Contact No:
                </td>
                <td>
                    <asp:TextBox ID="txtContact" runat="server" TabIndex="8"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Ticket Closed Date
                    <br />
                    if Any
                </td>
                <td>
                    <asp:TextBox ID="txtCloseDate" runat="server"></asp:TextBox>
                </td>
                <td>
                    Ticket Status:
                </td>
                <td>
                    <asp:DropDownList ID="ddlTicketStatus" runat="server" TabIndex="9" CssClass="tb10">
                        <asp:ListItem Value="0">Open</asp:ListItem>
                        <asp:ListItem Value="1">WIP</asp:ListItem>
                        <asp:ListItem Value="2">Hold</asp:ListItem>
                        <asp:ListItem Value="3">Closed</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    Remarks:
                </td>
                <td>
                    <asp:TextBox ID="txtRemarks" runat="server" TabIndex="10" Width="250px" Height="50px"
                        TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>Recording:
                </td>
                <td>
                    <asp:Literal ID="ltlPlay" runat="server"></asp:Literal>
                    <div id="jquery_jplayer_1">
                    </div>
                    <div id="jp_container_1" style="width:160px;">
                        <div class="jp-type-single">
                            <div class="jp-gui jp-interface">
                                <ul class="jp-controls">
                                    <li><a href="javascript:;" class="jp-play" tabindex="12">play</a></li>
                                    <li><a href="javascript:;" class="jp-pause" tabindex="13">pause</a></li>
                                    <li><a href="javascript:;" class="jp-stop" tabindex="14">stop</a></li>
                                </ul>
                                <div class="jp-progress">
                                    <div class="jp-seek-bar">
                                        <div class="jp-play-bar">
                                        </div>
                                    </div>
                                </div>
                                <div class="jp-volume-bar">
                                    <div class="jp-volume-bar-value">
                                    </div>
                                </div>
                                <div class="jp-time-holder">
                                    <div class="jp-current-time">
                                    </div>
                                    <div class="jp-duration">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <br />
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit"  Width="150px"
                         CssClass="button_grey" TabIndex="11" OnClick="btnSubmit_Click" ValidationGroup="newcomp" />
                </td>
            </tr>
        </table>

    </asp:Panel>
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>--%>
          <%--  <asp:Label ID="lblCounter" runat="server" Text="00:00:00"></asp:Label>--%>
           <%-- <asp:LinkButton Style="display: none" ID="_modalLinkButton" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="_modalLinkButton"
                PopupControlID="pnlAgents" BackgroundCssClass="modalBackground" DropShadow="true">
            </asp:ModalPopupExtender>
            <asp:Timer ID="Timer2" runat="server" Interval="5000" OnTick="chk">
            </asp:Timer>
            <asp:Panel ID="pnlAgents" runat="server" CssClass="pnlBackGround">
                <h4>
                    Incoming call from
                    <asp:Label ID="lblPop" runat="server" Text=""></asp:Label></h4>
                <br />
                <asp:Label ID="lblid" runat="server" Text="" Visible="false"></asp:Label>
                <asp:HiddenField ID="hfUid" runat="server" />
                <img src="img/incoming.png" height="60px" />
                <br />
                <center>
                    <asp:Button ID="btnDone" runat="server" Text="Accept" OnClick="btnDone_Click" BackColor="YellowGreen" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="I Am Busy" OnClick="btnCancel_Click"  BackColor="Red" /></center>
            </asp:Panel>--%>
              <asp:HiddenField ID="hfUid" runat="server" />
            <asp:LinkButton Style="display: none" ID="LinkButton1" runat="server"></asp:LinkButton>
            <asp:ModalPopupExtender ID="mpeSuccess" runat="server" TargetControlID="LinkButton1"
                PopupControlID="pnlSuccess" BackgroundCssClass="modalBackground" DropShadow="true">
            </asp:ModalPopupExtender>
    <asp:Panel ID="pnlSuccess" runat="server" CssClass="pnlBackGround" Height="120px">
        <br />
        <h2>
            <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label></h2>
        <br />
        <h3>
            <asp:Label ID="lblTicketId" runat="server" Text=""></asp:Label></h3>
        <br />
        <center>
            <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" /></center>
    </asp:Panel>
    <%--    </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

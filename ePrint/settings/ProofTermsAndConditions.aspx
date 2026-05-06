<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.Master" AutoEventWireup="true" CodeBehind="ProofTermsAndConditions.aspx.cs" Inherits="ePrint.settings.ProofTermsAndConditions" %>
<%--<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <script type="text/javascript" language="javascript" src="<%=strSitepath%>js/jquery-1.7.2.min.js?VN='<%=VersionNumber%>'"></script>
    <script src="<%=strSitepath%>js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'"
        type="text/javascript" language="javascript"></script>
    <link href="../css/smoothness/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <script src="<%=strSitepath%>js/js_ShowHide.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script>
        var AccountID = '<%=AccountID %>';
    </script>
    <div style="float: left;" class="estore_settingBox" id="pnldetails">
        <div align="left">
<div style="border-bottom: 1px solid rgb(218, 218, 218);">
    <div class="DivButtonsHeader" style="border-radius: 5px 5px 5px 5px">
        <div>
            <div>
                <div class="divpadding" style="height: 20px;">
                    <div style="float: left; margin-top: 3px;">
                        <b>
                            <asp:Label ID="lblSettingName" runat="server"></asp:Label>:&nbsp; </b>
                    </div>
                    <div style="float: left; margin: 3px 0px 1px 0px;">
                        <asp:Label ID="lbleStore" runat="server"></asp:Label></div>
                    <div id="divdrpdn" align="left" runat="server" onmouseover="javascript:OpenMoreActions(); return false;"
                        onmouseout="javascript:ClosedMoreActions(); return false;" style="float: left;
                        margin: -2px 0px 0px 0px; display: none;" nowrap="nowrap">
                        <div id="divbtn" class="btnstyle" style="width: 250px; padding-left: 13px; text-align: left;"
                            onmouseover="javascript:OpenMoreActions(); return false;">
                            <asp:Label ID="lbleStore2" runat="server" Text=""></asp:Label>
                            <div style="width: 5px; float: right; padding-top: 2.5px">
                                <asp:Image ID="imgArrow" runat="server" ImageUrl="~/images/ArrowDown.gif" />
                            </div>
                        </div>
                        <div id="Div_AccountList" runat="server" class="Div_AccountList" onmouseover="javascript:OpenMoreActions(); return false;"
                            onmouseout="javascript:ClosedMoreActions(); return false;">
                            <asp:PlaceHolder ID="plhAccountList" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                    <div style="float: left; margin: 3px 0px 0px 10px;">
                        <a id="spn_change" runat="server" onclick="javascript:OpenMoreActions(); return false;"
                            style="text-decoration: underline; cursor: pointer; color: #10357F;">Select</a></div>
                </div>
            </div>
        </div>
    </div>
</div>            <%--<div style="width: 100%; display: none;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <span class="navigatorpanel">
                                       Store Credit;
                                        <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp; <a id="A1"
                                            href="#" style="color: White; text-decoration: underline" runat="server" onclick="Show_accountListDiv();">
                                            <asp:Label ID="lbl_change" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Change") %></asp:Label>
                                        </a></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>--%>
            <div style="padding: 0px 10px 10px 10px">
                <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid red">
                    <div style="width: 60%; margin: 5px 0px 0px 5px">
                        <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div style="background-repeat: repeat-x; width: 58%;">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div style="width: 663px;">
                                    <table cellpadding="3" cellspacing="0" width="800px" class="PrilivegeTab" style="padding-top: 1px;">
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div id="div1" runat="server">
                        <table width="100%" class="PrilivegeTab" style="padding-top: 8px;">
                            <tr>
                                <td width="2%">
                                    <asp:CheckBox ID="chkTerms" runat="server" onclick="EnableDisable()" />
                                </td>
                                <td>
                                    <asp:Label ID="lblTerms" runat="server"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td colspan="2">
                                    <textarea class="txtbox" rows="3" placeholder="Add Terms & Conditions" style="margin-left:4px;" cols="55" name="txtTermsDescription" id="txtTermsDescription"
                                     runat="server" ></textarea>                
                                    &nbsp;&nbsp;<span runat="server" id="terms_error" style="color:red;display:none;margin-left:4px;">Please add terms & conditions.</span>
                                </td>
                            </tr>
                        </table>
                      <%--  <table width="100%" style="padding-bottom: 6px; margin-top: -5px; margin-left: 20px;">
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdoPerUser1" runat="server" GroupName="spendlimit" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButton ID="rdoPerdept" runat="server" GroupName="spendlimit" />
                                </td>
                            </tr>
                        </table>--%>
                    </div>
                </div>
                <div style="clear: both; padding-top: 10px">
                </div>
                <div style="padding-left: 24px">
                    <asp:Button ID="btnSaveSettings" runat="server" CssClass="button" OnClick="btnSaveSettings_Click"
                        OnClientClick="javascript:loadingimage(this.id,'div_btnsaveprocess');"  Text="Save" />
                    <div id="div_btnsaveprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript"></script>
    <asp:Button ID="btnSave" runat="server" OnClick="Save_OnClick" Style="display: none" />
<asp:HiddenField ID="hdnAccountId" runat="server" Value="" />
    <script type="text/javascript" language="javascript">

        function OpenMoreActions() {
            document.getElementById('<%=divdrpdn.ClientID %>').style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_Div_AccountList").style.display = "block";
        document.getElementById('<%=lbleStore.ClientID %>').style.display = "none";
    }

    function ClosedMoreActions() {
        document.getElementById("ctl00_ContentPlaceHolder1_Div_AccountList").style.display = "none";
    }

        function AccountSelect(Id) {
            debugger;
        var AccountId = document.getElementById('<%=hdnAccountId.ClientID %>');
        AccountId.value = Id;
        document.getElementById('<%=btnSave.ClientID %>').click();
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

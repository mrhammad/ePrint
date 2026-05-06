<%@ page title="" language="C#" masterpagefile="~/Templates/settingsEstore.master" autoeventwireup="true"  CodeBehind="numbering_system.aspx.cs" Inherits="ePrint.StoreSettings.numbering_system" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script src="../js/Item/general.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>--%>
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>--%>
    <script type="text/javascript">
        var path = "<%=strSitepath %>";
    </script>
    <div align="left">
        <div style="width: 100%; display: none;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <span class="navigatorpanel">
                                    <%=objlang.GetLanguageConversion("Settings")%>:&nbsp;<%=objlang.GetLanguageConversion("Numbering_System")%></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
        <div class="estore_settingBox">
            <div id="">
                <UC:Header_MIS ID="header" runat="server" />
                <div align="left" class="manageedit" style="width: 98%">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div align="left" style="width: 100%;">
                        <div align="left" style="width: 100%">
                            <div align="left" style="width: 100%">
                                <div id="diverror" align="center" style="padding-top: 5px; display: none">
                                    <asp:Label ID="lblerror" runat="server" Text="Please enter numeric value" CssClass="errorMsg"></asp:Label>
                                </div>
                                <div>
                                    <asp:RadioButton ID="rbauto" runat="server" GroupName="number" Text="Auto" onclick="javascript:enablegroup('a');" /><%--OnCheckedChanged="rbauto_OnCheckedChanged"--%>
                                </div>
                                <div style="clear: both;">
                                </div>
                                <div>
                                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="number" Text="Custom"
                                        onclick="javascript:enablegroup('i');" />
                                </div>
                            </div>
                            <div style="clear: both;">
                            </div>
                            <div align="left" style="margin-left: 20px;">
                                <div style="float: left;">
                                    <asp:RadioButton ID="RadioButton2" runat="server" CssClass="normaltext" GroupName="custom"
                                        Text="Set this as starting value for the eStore Orders:" />
                                </div>
                                <div style="float: left">
                                    &nbsp;
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="txtBox" onblur="javascript:AllowNumber(this,this.value);"
                                        MaxLength="7"></asp:TextBox>
                                </div>
                            </div>
                            <div style="padding-top: 10px">
                                &nbsp;
                            </div>
                            <div style="clear: both;">
                            </div>
                            <div class="only10px">
                            </div>
                            <div align="left" style="width: 100%;">
                                <div style="float: left; padding-left: 27%;">
                                    <div id="div_btn_cancel" style="display: block">
                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btn_cancel"
                                            runat="server" Text="Cancel" OnClick="btn_cancel_OnClick" />
                                        <%--OnClick="btn_cancel_OnClick"--%>
                                    </div>
                                    <div id="div_btn_cancelprocess" class="button" align="center" style="height: 14px;
                                        width: 44px; display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                                <div style="float: left;">
                                    <asp:Button CssClass="button" ID="btn_save" runat="server" Text="Save & Lock" OnClick="btn_save_OnClick" />
                                    <asp:HiddenField runat="server" ID="hdnType" Value="0" />
                                </div>
                            </div>
                            <div style="height: 10px; clear: both;">
                                &nbsp;
                            </div>
                        </div>
                    </div>
                    <span class="smallgraytext" style="font-size: 9px">
                        <p>
                            <%=objlang.GetLanguageConversion("When_You_Have_To_Set_Your_Custom_Numbering_Click_The_Save_And_Lock_Button")%>
                            <br />
                            <span style="padding-left: 30px">
                                <%=objlang.GetLanguageConversion("You_Will_Not_Able_To_Alter_These_Numbers_Again_Without_Contacting")%>
                            </span>
                            <br />
                            <span style="padding-left: 30px">
                                <%=objlang.GetLanguageConversion("As_Alterations_To_The_Numbering_Seqence_Can_Cause_Duplicate_Numbers_In_Estimates_Etc")%>
                            </span>
                        </p>
                    </span>
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidDbValue" runat="server" />
    <script type="text/javascript" language="javascript">

        function enablegroup(type) {
            var RadioButton1 = document.getElementById("<%=RadioButton1.ClientID %>");
            var RadioButton2 = document.getElementById("<%=RadioButton2.ClientID %>");

            if (type == "a") {
                RadioButton2.disabled = true;
                RadioButton2.checked = false;
            }
            else if (type == "i") {
                RadioButton2.disabled = false;
                RadioButton2.checked = true;
            }
        }
        function btnSave_Confirmation() {            
            var IsLock=<%=IsLock%>;
            if(IsLock==true)
            {
                return false;
            }
            else
            {
                return confirm("You will not be able to alter these numbers again. Do you want to save?");
            }
        }
        function checkvalidation() {
            var r1 = document.getElementById("<%=RadioButton1.ClientID %>");
            var rb2 = document.getElementById("<%=RadioButton2.ClientID %>");

            var txt1 = document.getElementById("<%=TextBox1.ClientID %>");
            var span = document.getElementById("<%=lblerror.ClientID %>");
            var hdntype = document.getElementById("<%=hdnType.ClientID %>");
            var isempty = "";
            if (r1.checked) {
                if (rb2.checked) {
                    if (txt1.value == "") {
                        isempty = "yes";
                        span.innerHTML = "Please enter numeric value";
                    }
                    hdntype.value = "same"
                }
                else {

                    span.innerHTML = "Please select at least one option";
                    isempty = "yes";
                }
                if (isempty == "yes") {
                    document.getElementById("diverror").style.display = "block";

                    return false;
                }
                else {
                    document.getElementById("diverror").style.display = "none";
                    return true;
                }
            }
            else {
                return true;
            }

        }

        function checkIsnumeric(val, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_lblerror").innerHTML = "Please enter numeric value";
            IsIntegerParameter(val, id);
        }

        function AllowNumber(obj, val) {
            if (!isNaN(val)) {
                return true;
            }
            else {
                obj.value = ''; obj.focus();
                return false;
            }
        }

        function Validation() {
            var IsCorrect = true;



            return IsCorrect;
        }
        
    </script>
    <asp:Panel ID="pnlShowOnEdit" runat="server" Visible="false">
        <script>
            enablegroup('<%=NumberType %>');
        </script>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


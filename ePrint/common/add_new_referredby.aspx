<%@ page title="Add New Referred By" language="C#" masterpagefile="~/Templates/loginPopoupMaster.master" autoeventwireup="true" CodeBehind="add_new_referredby.aspx.cs" Inherits="ePrint.common.add_new_referredby" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
    <asp:ScriptManager ID="scrmgr" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript" language="javascript">

       
         
    </script>
    <script>
        function ddl() {            
            var ddl = parent.window.document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_ddl_Referencedby');
            var hdn = parent.window.document.getElementById('ctl00_ContentPlaceHolder1_ClientAddID_hdn_Referencedby');
            hdn.value = <%=ReferredByID%>;
            var txt = document.getElementById('ctl00_ContentPlaceHolder1_txtRefferedBy');            
            //alert(<%=ReferredByID%>);
            ddl.options.add(new Option(txt.value, <%=ReferredByID%>, ddl.options.length));
            ddl.selectedIndex = ddl.options.length-1;
            Close();
        }


        function Close() {
            var oWindow = GetRadWindow();
            oWindow.close();
            return false;
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function btnSaveValidate()
        {
            var txtRefferedBy = document.getElementById("<%=txtRefferedBy.ClientID %>");
            var txtCommision = document.getElementById("<%=txtCommision.ClientID %>");
            if (txtRefferedBy.value == "" || txtRefferedBy.value.trim() == "" || txtCommision.value == "" || txtCommision.value.trim() == "") {
                document.getElementById("ReqRefBy").style.display = "block";
                document.getElementById("ReqCommision").style.display = "block";
                txtRefferedBy.focus();
            }else{
                document.getElementById("ReqRefBy").style.display = "none";
                document.getElementById("ReqCommision").style.display = "none";}
            return true;
        }
    </script>
    <div id="divMain" style="margin-top: -10px;">
        <table>
            <tr>
                <td valign="top">
                    <div>
                        <asp:Label ID="lblReferedBy" runat="server" Style="margin-left: -5%;" Text="" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Referred_By")%><span style="color: red"> *</span></asp:Label>
                    </div>
                </td>
                <td>
                    <div style="margin-bottom: 3px;">
                        <asp:TextBox ID="txtRefferedBy" runat="server" Width="160px" CssClass="textboxnew"
                            Style="padding-top: -8px"></asp:TextBox>
                        <span id="ReqRefBy" style="display: none;">
                            <asp:RequiredFieldValidator ID="ReqRefered" Class="spanerrorMsg" Display="Dynamic" ControlToValidate="txtRefferedBy"
                                ErrorMessage="Please Enter The Value" runat="server" Style="color: black; padding-left: 4px; padding-right: 4px; width: auto"><%=objLanguage.GetLanguageConversion("Please_Enter_Reffered_By")%></asp:RequiredFieldValidator>
                        </span>
                    </div>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <div>
                        <asp:Label ID="lblCommision" runat="server" Style="margin-left: -5%;" Text="" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Commission_Without_Percentage")%><span style="color: red"> *</span></asp:Label>
                    </div>
                </td>
                <td>
                    <div>
                        <telerik:RadNumericTextBox runat="server" ID="txtCommision" Width="40px" Style="text-align: right">
                        </telerik:RadNumericTextBox>
                        <span>%</span>
                        <br />
                        <span id="ReqCommision" style="display: none; width: auto">
                            <asp:RequiredFieldValidator ID="ReqField" ControlToValidate="txtCommision" Display="Dynamic" class="spanerrorMsg"
                                ErrorMessage="Please Enter The Commission" runat="server" Style="color: black; padding-left: 4px; padding-right: 4px; width: 180px;"><%=objLanguage.GetLanguageConversion("Please_Enter_Commission")%></asp:RequiredFieldValidator>
                        </span>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-left: -4px">
                        <asp:Label ID="lblDefault" runat="server" Text="" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Default")%></asp:Label>
                    </div>
                </td>
                <td>
                    <div style="margin-left: -3px">
                        <asp:CheckBox ID="chkDefault" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <div>
                        <asp:Button ID="btnSaveReffered" runat="server" Text="Save" CssClass="button" OnClick="btnSaveReffered_Click"
                            OnClientClick="javascript:var a=btnSaveValidate();if(a)loadingimage(this.id,'div_btnSaveReffered');return a" />
                        <div id="div_btnSaveReffered" style="display: none">
                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


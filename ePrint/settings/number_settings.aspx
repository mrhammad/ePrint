<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="number_settings.aspx.cs" Inherits="ePrint.settings.number_settings" title="Setting: Numbering System" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div>
                <div align="left" style="width: 98%" class="mis_header_panel">
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
                                        onclick="javascript:enablegroup('');" />
                                </div>
                            </div>
                            <div style="clear: both;">
                            </div>
                            <div align="left" style="margin-left: 20px;">
                                <div style="float: left;">
                                    <asp:RadioButton ID="RadioButton2" runat="server" CssClass="normaltext" GroupName="custom"
                                        Text="Set this as starting value for the Estimates, Jobs, Purchases, Invoices and Delivery:" />
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
                            <div align="left" style="width: 100%">
                                <div align="left" style="width: 100%; margin-left: 20px;">
                                    <div style="float: left; width: 28%;" nowrap="nowrap">
                                        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="custom" Text="Set the starting value for Individuals:" />
                                    </div>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                                <div align="left" style="width: 100%; padding-top: 8px; margin-left: 20px;">
                                    <div align="left" style="width: 100%">
                                        <div style="float: left; width: 5%;">
                                            &nbsp;</div>
                                        <div style="float: left; width: 72%">
                                            <div style="float: left; width: 10%; padding-top: 3px;" class="bglabel">
                                                <%=objLanguage.GetLanguageConversion("Estimates")%>
                                            </div>
                                            <div style="float: left; width: 19%; margin-top: -2px; padding-left: 2px;">
                                                <asp:TextBox ID="txtestimate" runat="server" CssClass="txtBox" onblur="javascript:AllowNumber(this,this.value);"
                                                    MaxLength="7">0</asp:TextBox>
                                                <span id="spn_txtEstimate" class="spanerrorMsg" style="display: none; width: 200px;">
                                                    <%=objlang.GetLanguageConversion("Estimate_Value_Not_Balnk")%>
                                                </span>
                                            </div>
                                            <div style="float: left; width: 12%;">
                                                &nbsp;
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                                <div align="left" style="width: 100%; margin-left: 20px;">
                                    <div align="left" style="width: 100%">
                                        <div style="float: left; width: 5%;">
                                            &nbsp;</div>
                                        <div style="float: left; width: 72%">
                                            <div style="float: left; width: 10%; padding-top: 3px" align="left" class="bglabel">
                                                <%=objlang.GetLanguageConversion("Jobs")%>
                                            </div>
                                            <div style="float: left; width: 15%; margin-top: -2px; padding-left: 2px">
                                                <asp:TextBox ID="txtjobs" onblur="javascript:AllowNumber(this,this.value);" runat="server"
                                                    CssClass="txtBox" MaxLength="7">0</asp:TextBox>
                                                <span id="spn_txtjob" class="spanerrorMsg" style="display: none; width: 200px;">
                                                    <%=objlang.GetLanguageConversion("Job_Value_Not_Balnk")%>
                                                </span>
                                            </div>
                                            <div style="float: left; width: 12%;">
                                                &nbsp;
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                                <div align="left" style="width: 100%; margin-left: 20px;">
                                    <div align="left" style="width: 100%">
                                        <div style="float: left; width: 5%;">
                                            &nbsp;</div>
                                        <div style="float: left; width: 72%;">
                                            <div style="float: left; width: 10%; padding-top: 3px" class="bglabel">
                                                <%=objlang.GetLanguageConversion("Purchases")%></div>
                                            <div style="float: left; width: 19%; margin-top: -2px; padding-left: 2px">
                                                <asp:TextBox ID="txtpurchases" onblur="javascript:AllowNumber(this,this.value);"
                                                    runat="server" CssClass="txtBox" MaxLength="7">0</asp:TextBox>
                                                <span id="spn_txtpurchase" class="spanerrorMsg" style="display: none; width: 200px;">
                                                    <%=objlang.GetLanguageConversion("Purchase_Value_Not_Balnk")%></span>
                                            </div>
                                            <div style="float: left; width: 12%; white-space: nowrap">
                                                &nbsp;
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                                <div align="left" style="width: 100%; margin-left: 20px;">
                                    <div align="left" style="width: 100%">
                                        <div style="float: left; width: 5%;">
                                            &nbsp;</div>
                                        <div style="float: left; width: 72%;">
                                            <div style="float: left; width: 10%; padding-top: 3px;" align="left" class="bglabel">
                                                <%=objlang.GetLanguageConversion("Invoices")%></div>
                                            <div style="float: left; width: 15%; margin-top: -2px; padding-left: 2px">
                                                <asp:TextBox ID="txtinvoices" onblur="javascript:AllowNumber(this,this.value);" runat="server"
                                                    CssClass="txtBox" MaxLength="7">0</asp:TextBox>
                                                <span id="spn_txtinvoice" class="spanerrorMsg" style="display: none; width: 200px;">
                                                    <%=objlang.GetLanguageConversion("Invoice_Value_Not_Balnk")%></span>
                                            </div>
                                            <div style="float: left; width: 12%; white-space: nowrap">
                                                &nbsp;
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="onlyEmpty">
                                </div>
                                <div align="left" style="width: 100%; margin-left: 20px;">
                                    <div align="left" style="width: 100%">
                                        <div style="float: left; width: 5%;">
                                            &nbsp;</div>
                                        <div style="float: left; width: 72%">
                                            <div style="float: left; width: 10%; padding-top: 3px;" align="left" class="bglabel">
                                                <%=objlang.GetLanguageConversion("Delivery")%></div>
                                            <div style="float: left; width: 19%; margin-top: -2px; padding-left: 2px">
                                                <asp:TextBox ID="txtdelivery" onblur="javascript:AllowNumber(this,this.value);" runat="server"
                                                    CssClass="txtBox" MaxLength="7">0</asp:TextBox>
                                                <span id="spn_txtdelivery" class="spanerrorMsg" style="display: none; width: 200px;">
                                                    <%=objlang.GetLanguageConversion("Delivery_Value_Not_Balnk")%></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%-- Start --%>

                                <div class="onlyEmpty">
                                </div>
                                <div align="left" style="width: 100%; margin-left: 20px;">
                                    <div align="left" style="width: 100%">
                                        <div style="float: left; width: 5%;">
                                            &nbsp;</div>
                                        <div style="float: left; width: 72%">
                                            <div style="float: left; width: 10%; padding-top: 3px;" align="left" class="bglabel">
                                                <%=objlang.GetLanguageConversion("Customer_Account_Number")%></div>
                                            <div style="float: left; width: 19%; margin-top: -2px; padding-left: 2px">
                                                <asp:TextBox ID="txtAccountNumber" onblur="javascript:AllowNumber(this,this.value);" runat="server"
                                                    CssClass="txtBox" MaxLength="7">0</asp:TextBox>
                                                <span id="spn_txtaccntnumber" class="spanerrorMsg" style="display: none; width: 200px;">
                                                    <%=objlang.GetLanguageConversion("Account_Value_Not_Balnk")%></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <%-- End --%>


                            </div>
                            <div class="only10px">
                            </div>
                            <div align="left" style="width: 100%;">
                                <div style="float: left; padding-left: 15.3%">
                                    <div id="div_btncancel" style="display: block">
                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btn_cancel"
                                            runat="server" Text="Cancel" OnClick="btn_cancel_OnClick" />
                                    </div>
                                    <div id="div_btncancelprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" style="padding-top: 2px" class="loadingimg"
                                            alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="float: left; width: 10px">
                                    &nbsp;
                                </div>
                                <div style="float: left;">
                                    <asp:Button CssClass="button" ID="btn_save" runat="server" Text="Save & Lock" OnClick="btn_save_OnClick"
                                        Style="padding-bottom: 4px;" />
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
                                <%=objlang.GetLanguageConversion("NumberingSequence_Alteration_Email")%>
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
        var txtestimate = document.getElementById("<%=txtestimate.ClientID %>");
        var txtjob = document.getElementById("<%=txtjobs.ClientID %>");
        var txtinvoice = document.getElementById("<%=txtinvoices.ClientID %>");
        var txtpurchases = document.getElementById("<%=txtpurchases.ClientID %>");
        var txtdelivery = document.getElementById("<%=txtdelivery.ClientID %>");

        function enablegroup(type) {
            var rb2 = document.getElementById("<%=RadioButton2.ClientID %>");
            var rb3 = document.getElementById("<%=RadioButton3.ClientID %>");

            if (type == "a") {
                rb2.disabled = true;
                rb3.disabled = true;
            }
            else {
                rb2.disabled = false;
                rb3.disabled = false;
            }
        }
        function btnSave_Confirmation() {
            
            //return confirm("You will not be able to alter these numbers again. Do you want to save?");
            var IsLock=<%=IsLock%>;
            if(IsLock==true)
            {
               return false;
            }
            else
            {
                return confirm('<%=objlang.GetLanguageConversion("Number_Save_Confirmation") %>');
                Number_Save_Confirmation
            }
        }
        function checkvalidation() {
            var r1 = document.getElementById("<%=RadioButton1.ClientID %>");
            var rb2 = document.getElementById("<%=RadioButton2.ClientID %>");
            var rb3 = document.getElementById("<%=RadioButton3.ClientID %>");
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
                else if (rb3.checked) {
                    if ((txtestimate.value == "") && (txtjob.value == "") && (txtinvoice.value == "") && (txtpurchases.value == "") && (txtdelivery.value == "")) {
                        isempty = "yes";
                        span.innerHTML = "Please enter numeric value";
                    }
                    hdntype.value = "individual"
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
            if (CheckStringMandatory(txtestimate.value, 'spn_txtEstimate')) {
                IsCorrect = false;
            }
            if (CheckStringMandatory(txtjob.value, 'spn_txtjob')) {
                IsCorrect = false;
            }
            if (CheckStringMandatory(txtpurchases.value, 'spn_txtpurchase')) {
                IsCorrect = false;
            }
            if (CheckStringMandatory(txtinvoice.value, 'spn_txtinvoice')) {
                IsCorrect = false;
            }
            if (CheckStringMandatory(txtdelivery.value, 'spn_txtdelivery')) {
                IsCorrect = false;
            }           
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

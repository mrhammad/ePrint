<%@ page title="Archive Status" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="archivestatus.aspx.cs" Inherits="ePrint.settings.archivestatus"  enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function PurchaseCheck1() {
            var chkPurchase1 = document.getElementById("ctl00_ContentPlaceHolder1_chkPurchase1");
            var chkPurchase2 = document.getElementById("ctl00_ContentPlaceHolder1_chkPurchase2");
            if (chkPurchase1.checked == true) {
                chkPurchase2.checked = false;
            }
            else {
                chkPurchase2.checked = true;
            }
        }

        function PurchaseCheck2() {
            var chkPurchase1 = document.getElementById("ctl00_ContentPlaceHolder1_chkPurchase1");
            var chkPurchase2 = document.getElementById("ctl00_ContentPlaceHolder1_chkPurchase2");
            if (chkPurchase2.checked == true) {
                chkPurchase1.checked = false;
            }
            else {
                chkPurchase1.checked = true;
            }
        }

        function CheckBox() {
            var ChkJob1 = document.getElementById("ctl00_ContentPlaceHolder1_chkcase");
            var ChkJob2 = document.getElementById("ctl00_ContentPlaceHolder1_chkauot");
            var chkPurchase1 = document.getElementById("ctl00_ContentPlaceHolder1_chkPurchase1");
            var chkPurchase2 = document.getElementById("ctl00_ContentPlaceHolder1_chkPurchase2");
            if (ChkJob1.checked == true) {
                ChkJob2.checked = false;

            }
            else {
                ChkJob2.checked = true;

            }
        }

        function AutoCheckbox() {
            var ChkJob1 = document.getElementById("ctl00_ContentPlaceHolder1_chkcase");
            var ChkJob2 = document.getElementById("ctl00_ContentPlaceHolder1_chkauot");
            var chkPurchase1 = document.getElementById("ctl00_ContentPlaceHolder1_chkPurchase1");
            var chkPurchase2 = document.getElementById("ctl00_ContentPlaceHolder1_chkPurchase2");
            if (ChkJob2.checked == true) {
                ChkJob1.checked = false;

            }
            else {
                ChkJob1.checked = true;

            }
        }

    </script>
    <style type="text/css">
        .DropDown
        {
            width: 110px;
        }
        .chkbox
        {
            vertical-align: middle;
            padding-bottom: 8px;
            font-size: 0.8em; /*font-weight: bold;*/
            color: Gray;
        }
        .BackgroungCorner
        {
            background-color: #F2F3F5;
            border-radius: 5px;
            border: 1px solid #BDBDBD;
            background-image: url(../images/StatusHeader.png);
        }
        .module1
        {
            width: 150px;
            vertical-align: top;
        }
        .module2
        {
            width: 550px;
            vertical-align: top;
        }
        .module3
        {
            width: 200px;
            vertical-align: top;
        }
        .module4
        {
            width: 150px;
            vertical-align: top;
        }
        .table
        {
            width: 1000px;
        }
        .innertable
        {
            vertical-align: top;
            padding-left: 5px;
            margin-top: -7px;
        }
        .hrcolor
        {
            width: 98%;
            color: #F2F3F5;
            float: left;
        }
        .style2
        {
            width: 127px;
            padding-top: 6px;
        }
        .style3
        {
            width: 126px;
            vertical-align: top;
            padding-top: 6px;
        }
        .style4
        {
            width: 123px;
            padding-top: 6px;
        }
        .style5
        {
            width: 121px;
            padding-top: 6px;
        }
        .style6
        {
            width: 530px;
            vertical-align: top;
        }
        .style7
        {
            width: 540px;
            vertical-align: top;
        }
        .style8
        {
            width: 514px;
        }
        .style9
        {
            width: 563px;
            vertical-align: top;
        }
        .style10
        {
            width: 60px;
        }
        .style11
        {
            width: 280px;
            padding-left: 27px;
        }
        .style12
        {
            width: 57px;
        }
        .style13
        {
            width: 120px;
            padding-top: 6px;
        }
        .style14
        {
            width: 154px;
            vertical-align: top;
        }
    </style>
    <div class="navigatorpanel" style="display: none;">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"><%=objLanguage.GetLanguageConversion("Settings") %> : <%=objLanguage.GetLanguageConversion("Archive_Status") %></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="z-index: -20000;" class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div align="left" style="width: 100%;" class="mis_header_panel">
            <div style="width: 100%;">
                <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <table cellpadding="0" cellspacing="4" style="width: 90%; margin: -10px 0px 10px 10px;">
            <tr>
                <td colspan="4">
                    <div>
                        <table class="table">
                            <tr>
                                <td style="font-weight: bold;" class="style10">
                                    <%=objLanguage.GetLanguageConversion("Module") %>
                                </td>
                                <td style="font-weight: bold;" class="style11">
                                    <%=objLanguage.GetLanguageConversion("Event") %>
                                </td>
                                <td style="font-weight: bold; padding-left: 27px" class="style12">
                                    <%=objLanguage.GetLanguageConversion("Archive") %>
                                </td>
                                <td style="width: 102px; font-weight: bold; padding-left: 37px">
                                    <%=objLanguage.GetLanguageConversion("Status") %>
                                </td>
                            </tr>
                        </table>
                        <table class="table">
                            <tr>
                                <td style="vertical-align: top" class="style2">
                                    <asp:Label ID="lblEstimate" class="normalText" Style="font-weight: bold; vertical-align: top;
                                        color: #606060" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="style6">
                                    <table cellpadding="3" cellspacing="2">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblEstEvent_1" runat="server" Text="  "><%=objLanguage.GetLanguageConversion("When_you_manually_archive_an_estimate") %></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 11px;">
                                                <asp:Label ID="lblEstEvent_2" runat="server" Text="  "><%=objLanguage.GetLanguageConversion("When_you_progress_an_estimate_to_a_job") %></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="smallgraytext">
                                                    <%=objLanguage.GetLanguageConversion("Estimate_To_Job_Please_Note") %>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 11px;">
                                                <asp:Label ID="lblEstEvent_3" runat="server" Text="  "><%=objLanguage.GetLanguageConversion("Prompt_User_to_archive")%></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="module4">
                                    <table cellpadding="3" cellspacing="2" class="innertable">
                                        <tr>
                                            <td style="height: 15px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; padding-top: 11px;">
                                                <asp:CheckBox ID="chkEst2" CssClass="DropDown" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 12px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; padding-top: 3px;">
                                                <asp:CheckBox ID="chkEst3" CssClass="DropDown" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top" class="module3">
                                    <table cellpadding="3" cellspacing="2">
                                        <tr>
                                            <td style="vertical-align: top">
                                                <asp:DropDownList ID="ddlEst1" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlEst2" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div>
                            <hr class="hrcolor" />
                        </div>
                        <table class="table">
                            <tr>
                                <td style="vertical-align: top" class="style2">
                                    <asp:Label ID="lblOrder" runat="server" class="normalText" Style="font-weight: bold;
                                        vertical-align: top; color: #606060" Text=""></asp:Label>
                                </td>
                                <td class="style6">
                                    <table cellpadding="3" cellspacing="2">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="  "><%=objLanguage.GetLanguageConversion("When_you_manually_archive_an_order")%></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 11px;">
                                                <asp:Label ID="Label3" runat="server" Text="  "><%=objLanguage.GetLanguageConversion("When_you_progress_an_order_to_a_job")%></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="smallgraytext">
                                                    <%=objLanguage.GetLanguageConversion("Order_To_Job_Please_Note")%>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 11px;">
                                                <asp:Label ID="Label4" runat="server" Text="  "><%=objLanguage.GetLanguageConversion("Prompt_User_to_archive")%></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="module4">
                                    <table cellpadding="3" cellspacing="2" class="innertable">
                                        <tr>
                                            <td style="height: 15px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; padding-top: 11px;">
                                                <asp:CheckBox ID="chkorder2" CssClass="DropDown" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 12px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; padding-top: 3px;">
                                                <asp:CheckBox ID="chkorder3" CssClass="DropDown" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top" class="module3">
                                    <table cellpadding="3" cellspacing="2">
                                        <tr>
                                            <td style="vertical-align: top">
                                                <asp:DropDownList ID="ddlorder1" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlorder2" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>


                           
                        </table>
                        <div>
                            <hr class="hrcolor" />
                        </div>
                        <table class="table">
                            <tr>
                                <td class="style3">
                                    <asp:Label ID="lblJob" class="normalText" Style="color: #606060; font-weight: bold"
                                        runat="server" Text=""></asp:Label>
                                </td>
                                <td class="style7">
                                    <table cellpadding="3" cellspacing="4">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblJobEvent_1" runat="server" Text=""><%=objLanguage.GetLanguageConversion("When_you_manually_archive_a_Job")%></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 11px;">
                                                <asp:Label ID="lblJobEvent_2" runat="server" Text=""><%=objLanguage.GetLanguageConversion("When_you_progress_a_job_to_an_invoice")%></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="module4">
                                    <table cellpadding="2" cellspacing="4" class="innertable">
                                        <tr>
                                            <td style="height: 15px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 11px;">
                                                <asp:CheckBox ID="chkJob2" CssClass="DropDown" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="module3">
                                    <table cellpadding="2" cellspacing="4">
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlJob1" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlJob2" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                             <tr>
                                <td class="style3">
                                    <asp:Label ID="Label1" class="normalText" Style="color: #606060; font-weight: bold"
                                        runat="server" Text=""></asp:Label>
                                </td>
                                <td class="style7">
                                    <table cellpadding="3" cellspacing="4">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="">Lock the job when this status is selected</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 11px;">
                                                <asp:Label ID="Label6" runat="server" Text="">Unlock the job when this status is selected</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="module4">
                                    <table cellpadding="2" cellspacing="4" class="innertable">
                                        <tr>
                                            <td style="height: 15px">
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td style="padding-top: 11px;">
                                                <asp:CheckBox ID="CheckBox1" CssClass="DropDown" runat="server" />
                                            </td>
                                        </tr>--%>
                                    </table>
                                </td>
                                <td class="module3">
                                    <table cellpadding="2" cellspacing="4">
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlLock" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlUnlock" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                        </table>
                        <div>
                            <hr class="hrcolor" />
                        </div>
                        <table class="table">
                            <tr>
                                <td style="vertical-align: top" class="style4">
                                    <asp:Label ID="lblInvoice" class="normalText" Style="font-weight: bold; color: #606060"
                                        runat="server" Text="">

                                    </asp:Label>
                                </td>
                                <td class="module2">
                                    <table cellpadding="3" cellspacing="4">
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lblInvEvent_1" runat="server" Text=""><%=objLanguage.GetLanguageConversion("When_you_manually_archive_an_Invoice")%></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style8" style="padding-top: 11px;">
                                                <asp:Label ID="lblInvEvent_2" runat="server" Text=" "><%=objLanguage.GetLanguageConversion("When_you_mark_the_Invoice_as_Paid")%></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style8" style="padding-top: 11px;">
                                                <asp:Label ID="lblInvEvent_3" runat="server" Text=""><%=objLanguage.GetLanguageConversion("When_you_export_Invoice_to_an_Accounting_Package")%></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                <span class="smallgraytext">
                                                    <%=objLanguage.GetLanguageConversion("Accounting_Export_Note")%></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="module4">
                                    <table cellpadding="2" cellspacing="4" class="innertable">
                                        <tr>
                                            <td style="height: 15px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 13px;">
                                                <asp:CheckBox ID="chkInv2" CssClass="DropDown" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 3px;">
                                                <asp:CheckBox ID="chkInv3" CssClass="DropDown" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="module3">
                                    <table cellpadding="2" cellspacing="4">
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlInvoice1" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlInvoice2" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlInvoice3" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div>
                            <hr class="hrcolor" />
                        </div>
                        <table class="table">
                            <tr>
                                <td style="vertical-align: top" class="style5">
                                    <asp:Label ID="lblPurchase" class="normalText" Style="font-weight: bold; color: #606060"
                                        runat="server" Text="">
                                    </asp:Label>
                                </td>
                                <td class="module2">
                                    <table cellpadding="3" cellspacing="4">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPurchaseEvent_1" runat="server" Text=""><%=objLanguage.GetLanguageConversion("When_you_manually_archive_a_Purchase_Order")%></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 11px;">
                                                <asp:Label ID="lblPurchaseEvent_2" runat="server" Text=""><%=objLanguage.GetLanguageConversion("When_you_mark_the_invoice_received")%></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 11px;">
                                                <asp:Label ID="lblPurchaseEvent_3" runat="server" Text=""><%=objLanguage.GetLanguageConversion("When_you_mark_the_goods_received")%></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 11px;">
                                                <asp:Label ID="lblPurchaseEvent_4" runat="server" Text=""><%=objLanguage.GetLanguageConversion("When_you_export_Purchase_Order_to_an_Accounting_Package")%></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="smallgraytext">
                                                    <%=objLanguage.GetLanguageConversion("Accounting_Export_Note")%></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="module4">
                                    <table cellpadding="2" cellspacing="4" class="innertable">
                                        <tr>
                                            <td style="height: 12px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 16px;">
                                                <asp:CheckBox ID="chkPur2" CssClass="DropDown" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 6px;">
                                                <asp:CheckBox ID="chkPur3" CssClass="DropDown" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 2px;">
                                                <asp:CheckBox ID="chkPur4" CssClass="DropDown" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="module3">
                                    <table cellpadding="2" cellspacing="4">
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlPurchase1" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlPurchase2" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlPurchase3" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlPurchase4" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div>
                            <hr class="hrcolor" />
                        </div>
                        <table class="table">
                            <tr>
                                <td style="vertical-align: top" class="style13">
                                    <asp:Label ID="lblDelivery" class="normalText" Style="font-weight: bold; color: #606060"
                                        runat="server" Text="">
                                    </asp:Label>
                                </td>
                                <td class="style9">
                                    <table cellpadding="3" cellspacing="4">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDeliveryEvent_1" runat="server" Text=" "><%=objLanguage.GetLanguageConversion("When_you_manually_archive_a_Delivery_Note")%></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 11px;">
                                                <asp:Label ID="lblDeliveryEvent_2" runat="server" Text=""><%=objLanguage.GetLanguageConversion("When_you_mark_the_goods_delivered")%></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="style14">
                                    <table cellpadding="2" cellspacing="4" class="innertable">
                                        <tr>
                                            <td style="height: 15px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 15px;">
                                                <asp:CheckBox ID="chkDeli2" CssClass="DropDown" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="module3">
                                    <table cellpadding="2" cellspacing="4">
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlDelivery1" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlDelivery2" CssClass="DropDown" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div style="height: 20px">
                        </div>
                        <div style="float: right; width: 47%">
                            <div id="div_btnSave" style="display: block">
                                <asp:Button ID="btnSave" runat="server" Text="Update" CssClass="button" OnClick="btnUpdate_OnClick" />
                            </div>
                            <div id="div_btnSaveprocess" style="display: none">
                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

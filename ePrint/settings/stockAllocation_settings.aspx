<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true"  CodeBehind="stockAllocation_settings.aspx.cs" Inherits="ePrint.settings.stockAllocation_settings" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .Header
        {
            background-image: url(../images/header_bg.png);
            background-repeat: repeat-x;
            height: 26px;
            font-family: Verdana,Arial,Helvetica,sans-serif;
            font-size: 10px;
            font-weight: bold;
            color: #454545;
        }
        
        .divRightsNPrivileges
        {
            width: 100%;
            margin-top: 5px;
            padding-bottom: 5px;
            background-color: #EFEFEF;
        }
        .Body
        {
            background-color: #FCFCFC;
            font-family: Verdana,Arial,Helvetica,sans-serif;
        }
    </style>
    <div class="navigatorpanel" style="display: none;">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel" Text=""><%=objLanguage.GetLanguageConversion("Stock_Management") %></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div style="padding-bottom: 40px;" class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div class="mis_header_panel">
            <fieldset>
                <legend>
                    <%=objLanguage.GetLanguageConversion("Stock_is_Allocated_From_the_warehouse_when") %></legend>
                <table cellpadding="2" cellspacing="0" width="900px">
                    <tr class="Header">
                        <td width="175px" class="Font">
                            <asp:Label ID="lblRecordView" runat="server" Text="ePrint MIS Jobs"><%=objLanguage.GetLanguageConversion("ePrint_MIS_Jobs")%></asp:Label>
                        </td>
                        <td width="650px">
                        </td>
                    </tr>
                </table>
                <table class="Body" width="900px">
                    <tr>
                        <td>
                            <asp:RadioButton ID="rdbeprintjobprogressstojob" runat="server" Checked="true" GroupName="jobprggrp"
                                Text="Estimate is progressed to a Job" />
                        </td>
                    </tr>
                </table>
                <div style="height: 15px; width: 100%">
                </div>
                <table cellpadding="2" cellspacing="0" width="900px">
                    <tr class="Header">
                        <td width="175px" class="Font">
                            <asp:Label ID="Label1" runat="server" Text="eStore Orders and Jobs"><%=objLanguage.GetLanguageConversion("eStore_Orders_and_Jobs") %></asp:Label>
                        </td>
                        <td width="650px">
                        </td>
                    </tr>
                </table>
                <table class="Body" width="900px">
                    <tr>
                        <td>
                            <asp:RadioButton ID="rdbestore_orderplaced" runat="server" GroupName="ordplcd" Text="An eStore order is placed" Checked="true" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <div style="clear: both; height: 10px">
            </div>
            <fieldset>
                <legend>
                    <%=objLanguage.GetLanguageConversion("Stock_Reduction") %></legend>
                <table cellpadding="2" cellspacing="0" width="900px">
                    <tr class="Header">
                        <td width="310px" class="Font">
                            <asp:Label ID="Label3" runat="server" Text="Stock Reduction Method"><%=objLanguage.GetLanguageConversion("Stock_Reduction_Method") %></asp:Label>
                        </td>
                        <td width="650px">
                        </td>
                    </tr>
                </table>
                <table class="Body" width="900px">
                    <tr>
                        <td>
                            <asp:RadioButton ID="rdbfifo" runat="server" Checked="true" GroupName="stkreduction"
                                Text="FIFO (First in first out)" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="rdblifo" runat="server" GroupName="stkreduction" Text="LIFO (Last in first out)" />
                        </td>
                    </tr>
                    <tr style="margin-top: 10px">
                        <td>
                            <asp:CheckBox ID="chk_onestocklocation" runat="server" GroupName="stkreduction" Text="Pick the stock from one location" />
                        </td>
                    </tr>
                </table>
                <div style="height: 15px; width: 100%">
                </div>
                <table cellpadding="2" cellspacing="0" width="900px">
                    <tr class="Header">
                        <td width="310px" class="Font">
                            <asp:Label ID="Label2" runat="server" Text="Stock is Reduced When"><%=objLanguage.GetLanguageConversion("Stock_is_Reduced_When") %></asp:Label>
                        </td>
                        <td width="650px">
                        </td>
                    </tr>
                </table>
                <table class="Body" width="900px">
                    <tr style="display: none">
                        <td>
                            <asp:RadioButton ID="rdb_sr_estimateprgtojob" runat="server" GroupName="stkgrp" Text="Estimate or eStore Order is progressed to a Job" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="rdb_sr_jobconvertedinvoice" runat="server" Checked="true" GroupName="stkgrp"
                                Text="Job is Converted to an Invoice" />
                            <div style="margin-left:220px; margin-top:-11.5px;height:20px;">
                            <span class="smallgraytext" style="color:#000000">
                                Note: If a product does not have enough stock to enable the reduction to take place the invoice will not be able to be created.
                            </span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="float: left;">
                                <asp:RadioButton ID="rdb_sr_jobstatus" runat="server" GroupName="stkgrp" Text="Job Status changes to" />
                                <asp:DropDownList Style="margin-left: 8px;" CssClass="textboxnew" ID="ddlstkreduction"
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                            <div style="float: left; margin: 3px 0px 0px 10px;">
                                <span id="errmsg3" class="RFV_Message" style="display: none;">
                                    <%=objLanguage.GetLanguageConversion("Please_Select_Job_Status")%>
                                </span>
                            </div>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <div style="float: left;">
                                <asp:RadioButton ID="rdoStockReductionScanFile" runat="server"  Text="Scan file is uploaded" GroupName="stkgrp" />
                                
                            </div>
                           
                        </td>
                    </tr>
                </table>
            </fieldset>
            <div style="clear: both; height: 10px">
            </div>
            <fieldset style="display: none; margin: 0px 0px 0px 0px;">
                <legend>
                    <%=objLanguage.GetLanguageConversion("Stock_Cancellation") %>
                </legend>
                <table cellpadding="2" cellspacing="0" width="900px">
                    <tr class="Header">
                        <td width="310px" class="Font">
                            <asp:Label ID="Label4" runat="server" Text="When a Job is Cancelled"><%=objLanguage.GetLanguageConversion("When_a_Job_is_Cancelled") %></asp:Label>
                        </td>
                        <td width="650px">
                        </td>
                    </tr>
                </table>
                <table class="Body" width="900px">
                    <tr>
                        <td>
                            <asp:RadioButton ID="rdbaddstockback" runat="server" GroupName="cancelgrp" Text="Add stock back to the Product, if the stock has already been reduced" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="rdbdontaddstockback" runat="server" GroupName="cancelgrp" Text="Do not add stock back to the Product" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButton ID="rdbpromptuser" runat="server" Checked="true" GroupName="cancelgrp"
                                Text="Prompt user to decide if stock should be added back to the system" />
                        </td>
                    </tr>
                </table>
                <div style="height: 8px; width: 100%">
                </div>
                <div align="left" style="width: 65%; float: left">
                    <div class="smallgraytext">
                        <asp:Label ID="lblprompt" runat="server"><%=objLanguage.GetLanguageConversion("Prompt_Will_Appears_When") %></asp:Label>
                        <br />
                        <span style="float: left; padding-left: 3%">
                            <%=objLanguage.GetLanguageConversion("Job_Invoice_Status_Is_Changed_To_Cancelled") %>
                        </span>
                        <br />
                        <span style="float: left; padding-left: 3%">
                            <%=objLanguage.GetLanguageConversion("An_Item_Is_Deleted_Through_ReRun_Whose_Quantity_Is_Allocated") %>
                        </span>
                        <br />
                        <span style="float: left; padding-left: 3%">
                            <%=objLanguage.GetLanguageConversion("Job_Is_Reverted_To_Estimate") %>
                        </span>
                        <br />
                        <span style="float: left; padding-left: 3%">
                            <%=objLanguage.GetLanguageConversion("An_Item_Is_Deleted_Directly_From_Job_Invoice") %>
                        </span>
                        <br />
                        <span style="float: left; padding-left: 3%; display: none">
                            <%=objLanguage.GetLanguageConversion("When_Job_Progressed_To_Invoice_Without_Reducing_The_Stock_Which_Is_Allocated") %>
                        </span>
                        <br />
                    </div>
                </div>
            </fieldset>
            <fieldset>
                <legend>
                    <%=objLanguage.GetLanguageConversion("Stock_Replenish") %>
                </legend>
                <table cellpadding="2" cellspacing="0" width="900px">
                    <tr class="Header">
                        <td width="310px" class="Font">
                            <asp:Label ID="lblstkreplenishtxt" runat="server" Text="Stock is Replenished When"></asp:Label>
                        </td>
                        <td width="650px">
                        </td>
                    </tr>
                </table>
                <table class="Body" style="margin-top: 4px" width="900px">
                    <tr>
                        <td>
                            <div style="float: left;">
                                <asp:RadioButton ID="rdbstkreplenishtxt" runat="server" Checked="true" Text="Job Status changes to" GroupName="RepStock" />
                                <asp:DropDownList Style="margin-left: 8px;" CssClass="textboxnew" ID="ddlreplenishstatus"
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                            <div style="float: left; margin: 3px 0px 0px 10px;">
                                <span id="errmsg5" class="RFV_Message" style="display: none;">
                                    <%=objLanguage.GetLanguageConversion("Please_Select_Job_Status")%></span>
                            </div>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <div style="float: left;">
                                <asp:RadioButton ID="rdoStocReplenishScanFile" runat="server" Checked="true" Text="Scan file is uploaded" GroupName="RepStock" />
                               
                            </div>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="float: left; padding-top: 10px;">
                                <span class="smallgraytext">
                                    <asp:Label ID="lblstckreplnshmsg" style="color:#000000" runat="server"><%=objLanguage.GetLanguageConversion("Warehouse_stock_replenish_note")%></asp:Label>
                                </span>
                            </div>
                        </td>
                    </tr>
                </table>
                <%--  <div style="height: 8px; width: 100%">
                </div>--%>
            </fieldset>
            <div align="left" style="display: inline; width: 50%; margin-top: 80px">
                <span class="smallgraytext" style="float: left; width: 50%; margin-left: 5px; margin-top: 10px">
                    <asp:Label ID="lblmsg" runat="server"><%=objLanguage.GetLanguageConversion("save_lock_warning_msg") %>.</asp:Label>
                </span>
            </div>
            <div style="float: right; display: inline; width: 21%; padding-top: 10px; margin-right: 28%">
                <div style="display: inline; float: left">
                    <div id="div_btncancel" style="display: block">
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClientClick="loadingimage(this.id,'div_cancelprocess')"
                            OnClick="btnCancel_OnClick" CssClass="button" />
                    </div>
                    <div id="div_cancelprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
                <div style="display: inline; float: left">
                    <asp:Label ID="Label5" Width="8px" runat="server" Style="visibility: hidden">spc</asp:Label></div>
                <div style="display: inline; float: left">
                    <asp:Button ID="btn_Save" runat="server" OnClick="btn_Saveonclick" OnClientClick="javascript:return validate();" Text="Save" CssClass="button" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function validate() {
            var rdb_sr_jobstatus = document.getElementById("<%=rdb_sr_jobstatus.ClientID %>");
            var ddlstkreduction = document.getElementById("<%=ddlstkreduction.ClientID %>");
            var chk = 0;

            if (rdb_sr_jobstatus.checked) {
                if (ddlstkreduction.options[ddlstkreduction.selectedIndex].value == 0) {
                    document.getElementById("errmsg3").style.display = "block";
                    chk = 1;
                }
                else {
                    document.getElementById("errmsg3").style.display = "none";
                }
            }
            else {
                document.getElementById("errmsg3").style.display = "none";
            }

            if (chk == 1) {
                return false;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


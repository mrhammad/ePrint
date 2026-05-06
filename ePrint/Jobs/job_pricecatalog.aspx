<%@ page title="" language="C#" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" autoeventwireup="true" CodeBehind="job_pricecatalog.aspx.cs" Inherits="ePrint.Jobs.job_pricecatalog" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagName="PriceCatalog" TagPrefix="UC" Src="~/usercontrol/Item/estimate_price_catalogueNew.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%-- <div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" nowrap="nowrap">
                            <span class="navigatorpanel" id="lblheader"></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <div id="content" class="div_spacing3">
        <%--<div class="borderWithoutTop">--%>
            <div class="onlyEmpty">
            </div>
            <div id="div_price_catalogue">
                <div id="div_price_valid" style="display: none;" align="center">
                    <div align="center" style="width: 50%; padding: 3px;">
                        <span id="span_none" class="spanerrorMsg" style="width: 100%">Please select Price Catalogue</span>
                    </div>
                </div>
                <div align="left" class="onlyEmpty" style="padding-top: 5px;">
                    <UC:PriceCatalog ID="PriceCatalog" runat="server" />
                </div>
            </div>
            <div class="only5px">
            </div>
       <%-- </div>--%>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


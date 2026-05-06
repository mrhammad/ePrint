<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withoutPanel.master" autoeventwireup="true" CodeBehind="estimate_pricecatalog.aspx.cs" Inherits="ePrint.Estimates.estimate_pricecatalog" title="Add Estimate" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagName="PriceCatalog" TagPrefix="UC" Src="~/usercontrol/Item/estimate_price_catalogueNew.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <%--  <div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" nowrap="nowrap">
                            <span class="navigatorpanel">
                                <asp:Label runat="server" ID="lblheaderr"></asp:Label></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <div id="content">
      <%--  <div class="borderWithoutTop">--%>
            <div class="onlyEmpty">
            </div>
            <div id="div_price_catalogue">
                <div id="div_price_valid" style="display: none;" align="center">
                    <div align="center" style="width: 50%; padding: 3px;">
                        <span id="span_none" class="spanerrorMsg" style="width: 100%">Please select Price Catalogue</span>
                    </div>
                </div>
                <div align="left" class="onlyEmpty">
                    <UC:PriceCatalog ID="PriceCatalog" runat="server" />
                </div>
            </div>
            <div class="only5px">
            </div>
      <%--  </div>--%>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

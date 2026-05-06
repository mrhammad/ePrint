<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Paging.ascx.cs" Inherits="ePrint.usercontrol.Paging" %>


<div class="paging1">
    <%--<tfoot>--%>
    <div style="float: left; width: 58px; margin-left: 15px">
        <div style="padding-top: 3px;">
            <%=objLangClass.GetLanguageConversion("Jump_To")%>:
        </div>
    </div>
    <div style="float: left; padding-right: 5px; padding-left: 5px">
        <%--GetCurrentPageNumber: javascript is on the same page--%>
        <asp:DropDownList ID="ddlPageNo" CausesValidation="false" runat="server" Width="50px"
            SkinID="onlyDDL" onchange="javascript:GetCurrentPageNumber(this);">
        </asp:DropDownList>
    </div>
    <div style="float: left; color: #858585; padding-right: 10px">
        <div style="padding-top: 1px;">
            <asp:Panel ID="divStart" runat="server" CssClass="paging_style">
                <asp:LinkButton ID="lnkStart" CausesValidation="false" CssClass="Paging_enable" OnClick="btn_Command"
                    runat="server" Text="[<">
                </asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="divPrev" runat="server" CssClass="paging_style">
                <asp:LinkButton ID="lnkPrev" CausesValidation="false" CssClass="Paging_enable" OnClick="btn_Command"
                    Text="<" runat="server">
                </asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="divFirst" runat="server" CssClass="paging_style">
                <asp:LinkButton ID="lnkFirst" CausesValidation="false" CssClass="Paging_enable" OnClick="btn_Command"
                    Visible="false" runat="server">
                </asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="divSecond" runat="server" CssClass="paging_style">
                <asp:LinkButton OnClick="btn_Command" CausesValidation="false" CssClass="Paging_enable"
                    Visible="false" ID="lnkSecond" runat="server">
                </asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="divThird" runat="server" CssClass="paging_style">
                <asp:LinkButton ID="lnkThird" CausesValidation="false" CssClass="Paging_enable" OnClick="btn_Command"
                    Visible="false" runat="server">
                </asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="divFour" runat="server" CssClass="paging_style">
                <asp:LinkButton ID="lnkFour" CausesValidation="false" CssClass="Paging_enable" OnClick="btn_Command"
                    Visible="false" runat="server">
                </asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="divFive" runat="server" CssClass="paging_style">
                <asp:LinkButton ID="lnkFive" CausesValidation="false" CssClass="Paging_enable" OnClick="btn_Command"
                    Visible="false" runat="server">
                </asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="divNext" runat="server" CssClass="paging_style">
                <asp:LinkButton ID="lnkNext" CausesValidation="false" CssClass="Paging_enable" Text=">"
                    runat="server" OnClick="btn_Command">
                </asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="divEnd" runat="server" CssClass="paging_style">
                <asp:LinkButton ID="lnkEnd" CausesValidation="false" CssClass="Paging_enable" Text=">]"
                    runat="server" OnClick="btn_Command">
                </asp:LinkButton>
            </asp:Panel>
        </div>
    </div>
    <div style="float: left; width: 30px;" class="formheader">
        <div style="padding-top: 3px;">
            <%=objLangClass.GetLanguageConversion("View")%>:
        </div>
    </div>
    <div style="float: left; padding-left: 10px;">
        <asp:DropDownList ID="ddlPageSize" CausesValidation="false" AutoPostBack="true" runat="server"
            Width="50px" SkinID="onlyDDL">
        </asp:DropDownList>
    </div>
    <div style="float: left; width: 30px; margin-left: 5px" class="formheader">
        <div style="padding-top: 3px;">
            <%=objLangClass.GetLanguageConversion("Rows")%>
        </div>
    </div>
    <div style="float: left;">
        <div class="limit">
            <%--<span class="limitNew">Page</span>--%>
            <asp:Label ID="lblPageNumber" Font-Bold="true" ForeColor="Gray" runat="server" Visible="false"></asp:Label>
            <%--<span class="limitNew">of</span>--%>
            <asp:Label ID="lblTotalPage" Font-Bold="true" ForeColor="Gray" runat="server" Visible="false"></asp:Label></div>
        <input type="hidden" name="limitstart" value="0" />
    </div>
    <%--</tfoot>--%>
    <asp:HiddenField ID="hdnPageNumberonChange" Value="0" runat="server" />
    <asp:LinkButton ID="lnkPageChangeNoWay" OnClick="ddlPageNo_SelectedIndexChanged"
        runat="server"></asp:LinkButton>
</div>
<script language="javascript" type="text/javascript">
    ////    function GetCurrentPageNumber() {
    // var ddlPageNo = document.getElementById(ddlID.id);
    // document.getElementById("ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_usrPagingInv_hdnPageNumberonChange").value = ddlPageNo.options[ddlPageNo.selectedIndex].value;
    // __doPostBack('ctl00$ContentPlaceHolder1$InventoryStoreCustomerView2$usrPagingInv$lnkPageChangeNoWay', '')

    //        var ddlPageNo = document.getElementById("<%=ddlPageNo.ClientID%>");
    //        document.getElementById("<%=hdnPageNumberonChange.ClientID%>").value = ddlPageNo.options[ddlPageNo.selectedIndex].value;
    //        
    //        __doPostBack('<%=lnkPageChangeNoWay.UniqueID%>', '')
    //    }

    function GetCurrentPageNumber(ddlID) {
        var ddlPageNo = document.getElementById(ddlID.id);

        var totalPaging = document.getElementById("aspnetForm")
        var paginghidden = 'ctl00_ContentPlaceHolder1_usrPaging_hdnPageNumberonChange';
        var paginglink = 'ctl00$ContentPlaceHolder1$usrPaging$lnkPageChangeNoWay';


        var totalPagingCount = totalPaging.getElementsByTagName("input")
        for (b = 0; b < totalPagingCount.length; b++) {
            if (totalPagingCount[b].type == 'hidden' && totalPagingCount[b].id.indexOf('hdnPageNumberonChange') != -1) {
                paginghidden = totalPagingCount[b].id;
                paginglink = totalPagingCount[b].name;
            }
        }
        //alert(paginghidden);
        document.getElementById(paginghidden).value = ddlPageNo.options[ddlPageNo.selectedIndex].value;

        paginglink = paginglink.replace('hdnPageNumberonChange', 'lnkPageChangeNoWay');
        //alert(paginglink);
        __doPostBack(paginglink, '')

    }

</script>


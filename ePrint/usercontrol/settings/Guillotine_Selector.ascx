<%@ control language="C#" autoeventwireup="true" CodeBehind="Guillotine_Selector.ascx.cs" Inherits="ePrint.usercontrol.settings.Guillotine_Selector" %>
<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register Src="~/usercontrol/Settings/guillotine_add.ascx" TagName="GuillotineAdd"
    TagPrefix="UC" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<%--<script type="text/javascript" src="<%=strSitepath %>js/Item/general.js"></script>--%>

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="GridGuillotine">
            <UpdatedControls>
                <%--<telerik:AjaxUpdatedControl ControlID="GridGuillotine" LoadingPanelID="RadAjaxLoadingPanel1" />--%>
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
<div id="ds00" style="display: block;">
</div>
<div id="div_Load" style="display: block; width: 200px; height: 50px; position: absolute;
    top: 45%; left: 45%">
    <UC:Loading ID="ucLoading" runat="server" />
</div>

<script>
    document.getElementById("ds00").style.width = document.getElementById("outerTable").offsetWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    document.getElementById("ds00").style.display = "block";
</script>

<script type="text/javascript">
    setLoadingPositionOfDivMove(div_Load);
</script>

<div id="div_plant_selctor" style="width: 100%;">
    <%--<div style="width: 100%;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel"><%=objlang.GetLanguageConversion("Guillotine_Selector")%> </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <div ><%--class="borderWithoutTop"--%>
        <div align="left" style="width: 99%;">
            <div >  <%--id="padding"--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div style="float: left; width: 100%;">
                            <%--    <div style="float: left; padding-bottom: 5px">
                                        <asp:Button ID="btnAdd" runat="server" Text="Add New Guillotine" CssClass="button"
                                            Width="130px" OnClientClick="javascript:ShowguillotineAddDiv();return false;" /></div>--%>
                            <div id="div_TotalRec" style="float: right; padding-right: 5px">
                                <span class="normalText"><%=objlang.GetLanguageConversion("Total_Records")%>:</span><b>
                                    <asp:Label ID="lblTotalRecords" runat="server"></asp:Label></b></div>
                            <div class="onlyempty">
                            </div>
                            <div id="div_Main" runat="server" align="left" style="width: 100%;">
                                <div id="div_Grid" class="gridborder">
                                    <%--By Jagat on 27/July/2012--%>
                                    <telerik:RadGrid ID="GridGuillotine" runat="server" GridLines="None" Visible="true"
                                        ShowHeader="true" ShowStatusBar="true" AutoGenerateColumns="false" HeaderStyle-HorizontalAlign="Left"
                                        HeaderStyle-Font-Bold="true" AllowFilteringByColumn="true" Width="100%" PagerStyle-AlwaysVisible="true"
                                        AllowPaging="true" PageSize="50" OnNeedDataSource="GridGuillotine_OnNeedDataSource" GroupingSettings-CaseSensitive="false">
                                        <PagerStyle Mode="NextPrevAndNumeric" />
                                        <MasterTableView DataKeyNames="GuillotineID" AllowFilteringByColumn="true" Width="100%"
                                            OverrideDataSourceControlSorting="true" CommandItemDisplay="Top">
                                            <CommandItemTemplate>
                                                <table class="rgCommandTable" border="0" style="width: 100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Button ID="btnAdd" runat="server" class="rgAdd" OnClientClick="javascript:ShowguillotineAddDiv();return false;" />
                                                            <a href="#" onclick="javascript:ShowguillotineAddDiv();return false;">
                                                              <%=AddNewText%></a>
                                                        </td>
                                                        <td align="right">
                                                            <asp:LinkButton ID="btnclrFilters" runat="server" Style="text-decoration: underline;
                                                                cursor: pointer;" OnClick="btnclrFilters_Click"><%=objlang.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </CommandItemTemplate>
                                            <Columns>
                                                <telerik:GridTemplateColumn  UniqueName="GuillotineName"
                                                    DataField="GuillotineName" ItemStyle-Width="30%" HeaderStyle-Width="30%" SortExpression="GuillotineName"
                                                    AllowFiltering="true" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
                                                    <ItemTemplate>
                                                        <div style="float: left; overflow: hidden">
                                                            <a title='<%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.GuillotineName","{0}"))%>' id='<%#Eval("GuillotineID")%>' href='#' onclick="javascript:SelectGuillotine('<%#Eval("GuillotineID")%>','<%#Eval("GuillotineName")%>', '<%#Eval("DefaultFirstTrim")%>','<%#Eval("DefaultSecondTrim")%>')">
                                                                <%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.LimitGuillotineName","{0}"))%>
                                                            </a>
                                                        </div>
                                                        <asp:Label ID="lblGuillotineID" runat="server" Text='<%#Eval("GuillotineID")%>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblGuillotineName" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.GuillotineName","{0}"))%>'
                                                            Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-Width="45%" HeaderStyle-Width="45%"
                                                    UniqueName="Description" DataField="Description" SortExpression="Description"
                                                    AllowFiltering="true" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
                                                    <ItemTemplate>
                                                        <a title='<%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.GuillotineName","{0}"))%>' id='<%#Eval("GuillotineID")%>' href='#' onclick="javascript:SelectGuillotine('<%#Eval("GuillotineID")%>','<%#Eval("GuillotineName")%>', '<%#Eval("DefaultFirstTrim")%>','<%#Eval("DefaultSecondTrim")%>')">
                                                            <asp:Label ID="lblDescription" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.Description","{0}"))%>'></asp:Label>
                                                        </a>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <NoRecordsTemplate>
                                                <div style="padding: 0px 0px 0px 10px">
                                                    No records found
                                                </div>
                                            </NoRecordsTemplate>
                                        </MasterTableView>
                                        <ClientSettings EnableRowHoverStyle="true">
                                            <Selecting AllowRowSelect="True" />
                                            <ClientEvents />
                                        </ClientSettings>
                                        <ClientSettings Scrolling-AllowScroll="true" AllowColumnsReorder="false" AllowRowsDragDrop="false">
                                            <ClientEvents />
                                            <Scrolling ScrollHeight="230" UseStaticHeaders="true" />
                                        </ClientSettings>
                                    </telerik:RadGrid>
                                    <%--<asp:GridView ID="GridGuillotine" runat="server" Visible="true" AutoGenerateColumns="false"
                                                AllowPaging="true" PageSize="100" SkinID="GridStyle" GridLines="Horizontal">
                                            
                                                <HeaderStyle CssClass="bgcustomize" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Guillotine Name" HeaderStyle-CssClass="navigatorpanel"
                                                        ItemStyle-Wrap="false" ItemStyle-Width="30%">
                                                        <HeaderStyle HorizontalAlign="Left" Width="30%" Wrap="false" />
                                                        <ItemTemplate>
                                                            <a title='<%#Eval("GuillotineName")%>' id='<%#Eval("GuillotineID")%>' href='#' onclick="javascript:SelectGuillotine('<%#Eval("GuillotineID")%>','<%#Eval("GuillotineName")%>')">
                                                                <%#Eval("LimitGuillotineName")%>
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="navigatorpanel"
                                                        ItemStyle-Wrap="false" ItemStyle-Width="45%">
                                                        <HeaderStyle HorizontalAlign="Left" Width="45%" Wrap="false" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <div id="padding" class="emptyrecords" align="center">
                                                        <span class="HeaderText" style="text-align: center"><%=objlang.GetValueOnLang("No Records Found")%></span>
                                                    </div>
                                                </EmptyDataTemplate>
                                                <PagerTemplate>
                                                </PagerTemplate>
                                            </asp:GridView>--%>
                                    <%-- <asp:ObjectDataSource ID="odsGuillotine" runat="server"></asp:ObjectDataSource>--%>
                                </div>
                                <%-- <div align="left" >
                                                <UC:Paging ID="usrPaging" runat="server" />
                                        </div>--%>
                            </div>
                            <%-- <asp:Panel ID="pnlEmptyRecords" runat="server" Visible="false">
                                        <div id="Div1" class="emptyrecords" align="center">
                                            <span class="HeaderText" style="text-align: center"><%=objlang.GetValueOnLang("No record(s) found")%></span>
                                        </div>
                                    </asp:Panel>--%>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <%-- </div>--%>
                <div style="clear: both">
                </div>
                <%--</div>--%>
            </div>
        </div>
    </div>
</div>
<div align="left" id="div_GuillotineAdd" style="width: 96%; display: none;">
    <UC:GuillotineAdd ID="UCGuillotine_Add" runat="server" />
</div>
<div id="div_test_1" style="width: 100%; overflow-y: scroll; border: solid 1px red;
    display: none">
    <div id="div_test_2" style="width: 100%; border: solid 1px red;">
        Loading...</div>
</div>
<asp:HiddenField ID="hidGridCount" runat="server" Value="" />

<script>
    function CallScroll() {
        var GridID = document.getElementById("<%=GridGuillotine.ClientID%>");
        var div_HeaderID = document.getElementById("a");
        var div_BodyID = document.getElementById("div_Grid");
        var OuterDivID = document.getElementById("div_test_1");
        var InnerDivID = document.getElementById("div_test_2");
        var DivTotalRecID = document.getElementById("div_TotalRec");
        start(GridID, div_HeaderID, div_BodyID, OuterDivID, InnerDivID, DivTotalRecID);
    }
    if ('<%=totalrec %>' != 0) {
        window.onload = CallScroll
    }
    var clsTimeID = '';
    var TakeTimaeCount = 0;
    var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");
</script>

<script type="text/javascript">
    //*** Function to make gridview scrollable ***//
    function start(GridID, div_HeaderID, div_BodyID, OuterDivID, InnerDivID, DivTotalRecID) {
        var t = GridID;
        var t2 = t.cloneNode(true)
        for (i = t2.rows.length - 1; i > 0; i--)
            t2.deleteRow(i)
        t.deleteRow(0)
        div_HeaderID.appendChild(t2);

        if (t.rows.length < 19) {
            div_BodyID.style.overflowY = "auto";
            DivTotalRecID.style.paddingRight = "5px";
        }
        else {
            var divObj = document.getElementById("a");
            var aWidth = divObj.offsetWidth;
            //SetWidth(divObj);

            div = t.parentNode;
            //alert(div.style.width);
            if (div.tagName == "DIV") {
                div.className = "WrapperDiv";
                div.style.overflowY = "scroll";

                OuterDivID.style.display = "block";
                var OuterDivWidth = OuterDivID.offsetWidth;
                var InnerDivWidth = InnerDivID.offsetWidth
                var MinusThisWidth = Number(OuterDivWidth) - Number(InnerDivWidth);
                OuterDivID.style.display = "none";

                DivTotalRecID.style.paddingRight = Number(MinusThisWidth) + "px";
                if (navigator.appName == "Microsoft Internet Explorer") {
                    div_HeaderID.style.width = Number(aWidth) - Number(MinusThisWidth - 1) + "px";
                    div_BodyID.style.width = Number(aWidth - 1) + "px";
                }
                else {
                    div_HeaderID.style.width = Number(aWidth) - Number(MinusThisWidth) + "px";
                    div_BodyID.style.width = Number(aWidth) + "px";
                }
            }
        }
        div_BodyID.style.display = "block";
    }
    //*** Function to make gridview scrollable ***//
</script>

<script>
    function SelectGuillotine(id, value, FirstTrim, SecondTrim) {
        FirstTrim = FirstTrim == "True" ? true : false;
        SecondTrim = SecondTrim == "True" ? true : false;
        var pw = window.parent;

        pw.SendGuillotineIDandName(id, value, FirstTrim, SecondTrim);
        setTimeout("TakeOut()", 700);
        return false;
    }
    function TakeOut() {
        window.close();
    }

    document.getElementById("ds00").style.display = "none";
    document.getElementById("div_Load").style.display = "none";


    function ShowguillotineAddDiv() {
        document.getElementById("div_GuillotineAdd").style.display = "block";
        document.getElementById("div_plant_selctor").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_UCGuillotine_Add_txtGuillotineName").focus();
        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_UCGuillotine_Add_colourPanel").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_UCGuillotine_Add_Content").removeAttribute("class");
        document.getElementById("ctl00_ContentPlaceHolder1_ctl00_UCGuillotine_Add_padding").removeAttribute("class");
    }
</script>



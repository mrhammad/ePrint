<%@ Page Language="C#" MasterPageFile="~/Templates/popUpMasterPage.master" AutoEventWireup="true" CodeBehind="phrase_book.aspx.cs" Inherits="ePrint.common.phrase_book" Title="Untitled Page" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>

<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="<%=strSitepath %>js/item/general.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript" src="<%=strSitepath %>js/encode.js?VN='<%=VersionNumber%>'"></script>
    <div id="ds00" style="display: block;">
    </div>
    <div id="div_Load" style="display: block; width: 200px; height: 50px; position: absolute; top: 45%; left: 45%">
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
    <div id="content">

        <div runat="server" id="divAddNew" visible="false">
            <table class="rgCommandTable" border="0" style="width: 100%;">
                <tr>
                    <td align="left" style="width: 49%;">

                        <input onclick="javascript: addNewDepartment(); return false;" type="image" name="btnAddHeaderFooter" id="btnHeadFoot" title="" src="../images/plus.gif" style="vertical-align: top;">
                        Add new record
                        <%--<button id="Button1" runat="server" onserverclick="Button1_ServerClick"><img src="../images/plus.gif" />Save</button>--%>
                        <div style="float: left;">
                        </div>
                    </td>
                </tr>
            </table>
        </div>



        <div>
            <%--class="borderWithoutTop" class="borderWithoutTop"--%>
            <div id="padding">
                <div style="width: 100%">
                    <div style="float: left; width: 100%; display: block">
                        <div id="div_TotalRec" style="float: right; padding-right: 5px">
                            <span class="normalText">
                                <%=objLanguage.GetLanguageConversion("Total_Records")%>:</span><b>
                                    <asp:Label ID="lblTotalRecords" runat="server"></asp:Label></b>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                        <div id="a">
                        </div>
                        <div id="div_Grid">
                            <asp:GridView ID="GridHeaderFoooter" runat="server" AutoGenerateColumns="false" DataSourceID="odsHeaderFooter"
                                AllowPaging="false" PageSize="100" GridLines="Horizontal" SkinID="GridStyle"
                                OnRowDataBound="GridHeaderFoooter_OnRowDataBound" Style="table-layout: fixed">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="left" ItemStyle-Wrap="false" ItemStyle-Height="20px">
                                        <HeaderStyle HorizontalAlign="left" Width="1%" Wrap="false" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblgrdHeader" Text="Select Phrase" runat="server"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <a title='<%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.PhraseText","{0}")) %>'
                                                id='<%# DataBinder.Eval(Container.DataItem, "PhraseBookID") %>' href="javascript://"
                                                onclick="GetPhraseIDName(this.id,this.innerHTML,this.title);return false;">
                                                <%#objBase.SpecialDecode(DataBinder.Eval(Container,"DataItem.PhraseText", "{0}"))%>
                                            </a>
                                            <asp:HiddenField ID="hdnPhraseBookID" runat="server" Value='<%#Eval("PhraseText") %>' />
                                            <asp:Label ID="lblPhraseBookID" Text='<%#Eval("PhraseBookID") %>' Visible="false"
                                                runat="server"></asp:Label>
                                            <span id='spn_<%#Eval("PhraseBookID") %>' style="display: none">
                                                <%#Eval("PhraseText")%>
                                            </span>
                                            <asp:Label ID="lblFull" Text='<%#Eval("PhraseText") %>' Visible="false" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div id="padding" class="emptyrecords" align="center">
                                        <span class="HeaderText" style="text-align: center">
                                            <%=objLanguage.GetLanguageConversion("No_Record_Found")%></span>
                                    </div>
                                </EmptyDataTemplate>
                                <PagerTemplate>
                                </PagerTemplate>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsHeaderFooter" runat="server" TypeName="Printcenter.UI.Setting.SettingsBasePage"
                                SelectMethod="settings_phrasebook_select">
                                <SelectParameters>
                                    <asp:SessionParameter Name="companyID" DefaultValue="0" SessionField="companyId"
                                        Type="int32" />
                                    <asp:QueryStringParameter Name="PhraseType" DefaultValue="Estimate Header" QueryStringField="type"
                                        Type="string" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                        <div id="div_test_1" style="width: 100%; overflow-y: scroll; border: solid 1px blue; display: none">
                            <div id="div_test_2" style="width: 100%; border: solid 1px red;">
                                Loading...
                            </div>
                        </div>
                        <div align="left" class="divpaging" style="display: none">
                            <UC:Paging ID="usrPaging" runat="server" Visible="false" />
                        </div>
                    </div>
                </div>
                <div style="clear: both">
                </div>


                <%-- start new code --%>
                <br />
                <br />
                <div id="divAddNewRecord" style="display: none;">
                    <table border="0" cellpadding="2" width="" style="margin-top: 2px; margin-bottom: 7px;">
                        <tr>
                            <td style="float: left; width: 200px; margin-top: 2px; vertical-align: top;" class="bglabel">
                                <asp:Label ID="Lbl1" Text="" runat="server"><%=objLanguage.GetLanguageConversion("Phrase_Text") %></asp:Label>
                                <span style="color: Red">*</span>
                            </td>
                            <td align="left" valign="top" style="margin-left: -10px">
                                <asp:TextBox ID="txtPhraseText" TextMode="MultiLine" Height="95px" Width="500px"
                                    Text='<%# Bind("PhraseText") %>' runat="server" SkinID="textPad">
                                </asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="requiredfieldvalidator1" runat="server" ControlToValidate="txtPhraseText"
                                    ErrorMessage="Please Enter Phrase Text " CssClass="RFV_Message" Style="width: auto; padding-left: 4px; padding-right: 4px;"
                                    ForeColor=""></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr valign="top" style="vertical-align: top;">
                            <td style="float: left; width: 200px" class="bglabel" align="left">
                                <asp:Label ID="Lbl12" Text="" runat="server"><%=objLanguage.GetLanguageConversion("Default_Phrase")%></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkedit" runat="server" />
                            </td>
                        </tr>

                        <tr>
                            <td style="width: 100px">&nbsp;
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" />
                                <input type="button" onclick="javascript: hidedivfun(); return false;" value="Cancel"/>
                            </td>
                        </tr>
                    </table>
                </div>
                <%-- end new code --%>
            </div>
        </div>
    </div>
    <script>
        //*** Function to make gridview scrollable ***//
        function start() {
            document.getElementById("div_test_1").style.display = "none";
            var t = document.getElementById("<%=GridHeaderFoooter.ClientID%>");
            var t2 = t.cloneNode(true)
            for (i = t2.rows.length - 1; i > 0; i--)
                t2.deleteRow(i)
            t.deleteRow(0)
            document.getElementById("a").appendChild(t2);

            if (t.rows.length < 19) {
                document.getElementById("div_Grid").style.overflowY = "auto";
                document.getElementById("div_TotalRec").style.paddingRight = "5px";
            }
            else {
                var divObj = document.getElementById("a");
                var aWidth = divObj.offsetWidth;

                div = t.parentNode;
                if (div.tagName == "DIV") {
                    div.className = "WrapperDiv";
                    div.style.overflowY = "scroll";

                    document.getElementById("div_test_1").style.display = "block";
                    var OuterDivWidth = document.getElementById("div_test_1").offsetWidth;
                    var InnerDivWidth = document.getElementById("div_test_2").offsetWidth
                    var MinusThisWidth = Number(OuterDivWidth) - Number(InnerDivWidth);
                    document.getElementById("div_test_1").style.display = "none";

                    document.getElementById("div_TotalRec").style.paddingRight = Number(MinusThisWidth) + "px";
                    if (navigator.appName == "Microsoft Internet Explorer") {
                        document.getElementById("a").style.width = Number(aWidth) - Number(MinusThisWidth - 1) + "px";
                        document.getElementById("div_Grid").style.width = Number(aWidth - 1) + "px";
                    }
                    else {
                        document.getElementById("a").style.width = Number(aWidth) - Number(MinusThisWidth) + "px";
                        document.getElementById("div_Grid").style.width = Number(aWidth) + "px";
                    }
                }
            }
            document.getElementById("div_Grid").style.display = "block";
        }
        if ('<%=totalrec %>' != 0) {
            window.onload = start
        }
        //*** Function to make gridview scrollable ***//
    </script>
    <script type="text/javascript">
        //*** to get the address for Estimate add page ****//
        function GetPhraseIDName(id, value, tooltip) {

            Encoder.EncodeType = "entity";
            var txtPhData = document.getElementById("spn_" + id + "").innerHTML;
            // for bugid - 4346
            var div = document.createElement('div');
            div.innerHTML = txtPhData;
            var decoded = div.firstChild.nodeValue;

            txtPhData = trim12(decoded);
            value = SpecialDecode(txtPhData);
            tooltip = SpecialDecode(txtPhData);
            var type = '<%=type%>';

            var pw = window.parent;
            if (type == 'Estimate Header' || type == 'Estimate Footer' || type == 'Invoice Header' || type == 'Invoice Footer'
                || type == 'Purchase Footer' || type == 'Delivery Note Header' || type == 'Delivery Note Footer' || type == 'Delivery Instructions' || type == 'Job Header' || type == 'Job Footer' || type == 'Purchase Header') {
                pw.SendPhraseIDandName(id, value, type, tooltip);
            }
            else if (type == 'PrintBroker Header' || type == 'PrintBroker Footer') {
                pw.Send_PrintBroker_Phrases(id, value, type, tooltip);
            }
            else {
                if (pw.estimateType == '' || pw.estimateType == 'printbroker') {
                    pw.SendPhraseBookToPB(id, value, type, tooltip);
                }
                else {
                    window.parent.document.getElementById('<%=PhraseItemTo %>').value = tooltip; // Directly assiging values to Summary screen ItemDescn textbox.
                    // pw.SendPhraseBook(id, value, type, tooltip); 
                }
            }
            window.close();
        }
        //*** End of to get the address for Estimate add page ****//
        document.getElementById("ds00").style.display = "none";
        document.getElementById("div_Load").style.display = "none";
    </script>
    <script type="text/javascript">
        var GridItemTitle = document.getElementById("<%=GridHeaderFoooter.ClientID %>");
        function CallOverflow() {

            SetGridOverflow(GridItemTitle);
        }
        CallOverflow();



        function addNewDepartment() {

            $("#divAddNewRecord").css("display", "block");
            return false;
        };

        function hidedivfun() {
            $("#divAddNewRecord").css("display", "none");
            return false;
        };

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


<%@ control language="C#" autoeventwireup="true" CodeBehind="item_stockonly_po.ascx.cs" Inherits="ePrint.usercontrol.Item.item_stockonly_po" %>
<%@ Register Src="~/usercontrol/warehouse/inventory_add.ascx" TagName="Inventory" TagPrefix="UC" %>
<div id="divstockonly_po" style="display: block;">
    <div id="tdpaperheader" style="width: 100%; display: none;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">Paper Selector</span></div>
                        <div style="width: 50px; float: right;">
                            <a href="javascript:closewindow('dstock_only');" class="subnavigator">Close X</a></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="tdinkheader" style="width: 100%; display: none;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">Ink Selector</span></div>
                        <div style="width: 50px; float: right;">
                            <a href="javascript:closewindow('dstock_only');" class="subnavigator">Close X</a></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="tdfilmheader" style="width: 100%; display: none;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">Film Selector</span></div>
                        <div style="width: 50px; float: right;">
                            <a href="javascript:closewindow('dstock_only');" class="subnavigator">Close X</a></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="tdplateheader" style="width: 100%; display: none;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">Plate Selector</span></div>
                        <div style="width: 50px; float: right;">
                            <a href="javascript:closewindow('dstock_only');" class="subnavigator">Close X</a></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--Used for more paper, film and plate selection--%>
    <div id="divpaper" runat="server" style="width: 100%; display: none;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">Paper Selector</span></div>
                        <%--<div style="width: 50px; float: right;">
                            <a href="javascript:closewindow('dstock_only');" class="subnavigator">Close X</a></div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divink" runat="server" style="width: 100%; display: none;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">Ink Selector</span></div>
                        <%--<div style="width: 50px; float: right;">
                            <a href="javascript:closewindow('dstock_only');" class="subnavigator">Close X</a></div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divfilm" runat="server" style="width: 100%; display: none;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">Film Selector</span></div>
                        <%--<div style="width: 50px; float: right;">
                            <a href="javascript:closewindow('dstock_only');" class="subnavigator">Close X</a></div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divplate" runat="server" style="width: 100%; display: none;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">Plate Selector</span></div>
                        <%-- <div style="width: 50px; float: right;">
                            <a href="javascript:closewindow('dstock_only');" class="subnavigator">Close X</a></div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--End of Used for more paper, film and plate selection--%>
    <div id="divborder" class="divBorderItem" style="display: block;">
        <div style="float: left; width: 97%">
            <div id="tblsearch" style="float: left; display: block; width: 100%; border: 0px solid">
                <div style="float: left; width: 12%" class="normalText">
                    Search Criteria
                </div>
                <div style="float: left; width: 20%" class="normalText">
                    <asp:TextBox ID="txtsearch" CssClass="txtbox" runat="server"></asp:TextBox></div>
                <div style="float: left; width: 8%" class="normalText">
                    Category</div>
                <div style="float: left; width: 10%" class="normalText">
                    <asp:DropDownList ID="ddlcategory" runat="server" CssClass="MaskDDL">
                        <asp:ListItem Value="0" Text="All"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Plain"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Silk"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Graphic"></asp:ListItem>
                        <asp:ListItem Value="4" Text="Gloss"></asp:ListItem>
                        <asp:ListItem Value="5" Text="Matt"></asp:ListItem>
                    </asp:DropDownList></div>
                <div style="float: left;">
                    <asp:Button ID="btnsearch" CssClass="button" runat="server" Text="Search" Width="65px"
                        OnClientClick="return false;" /></div>
                <div style="float: left; width: 10px">
                    &nbsp;</div>
                <div id="tdaddnew" runat="server" style="float: left; display: block">
                    <asp:Button ID="btnaddnewpaper" CssClass="button" runat="server" Text="Add New Paper"
                        Width="110px" OnClientClick="javascript:ShowAddStock('paper');return false;" />
                    <%-- <input type="button" id="btnaddnewpaper" name="btnaddnewpaper" value="Add New Paper" width="70px" class="button" onclick="javascript:window.open('<%=strSitepath%>item/item_paper_add.aspx','','width=800px,height=400px,status=no,align=center,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=170,top=100')" />--%>
                </div>
                <div id="div_addFilm" style="float: left; display: none">
                    <%-- <div style="float: left; width: 10px">
                        &nbsp;</div>--%>
                    <asp:Button ID="Button3" CssClass="button" runat="server" Text="Add New Film" Width="110px"
                        OnClientClick="javascript:ShowAddStock('film');return false;" />
                </div>
                <div id="div_addPlate" style="float: left; display: none">
                    <asp:Button ID="Button4" CssClass="button" runat="server" Text="Add New Plate" Width="110px"
                        OnClientClick="javascript:ShowAddStock('plate');return false;" />
                </div>
                <div style="float: left; width: 10px">
                    &nbsp;</div>
                <div id="tdbtnSupplier" style="float: left; display: none;">
                    <asp:Button ID="btnshow_supplier" runat="server" Text="Show All Papers" CssClass="button"
                        Width="100px" OnClientClick="javascript:return false;" /></div>
                <div id="divbtn_allfilms" style="float: left; display: none;">
                    <asp:Button ID="Button1" runat="server" Text="Show All Films" CssClass="button" Width="100px"
                        OnClientClick="javascript:return false;" /></div>
                <div id="divbtn_allplates" style="float: left; display: none;">
                    <asp:Button ID="Button2" runat="server" Text="Show All Plates" CssClass="button"
                        Width="100px" OnClientClick="javascript:return false;" /></div>
                <div style="clear: both;">
                </div>
            </div>
            <div id="div_inksearch" style="float: left; width: 100%; display: none">
                <div style="float: left; width: 8%; vertical-align: middle">
                    Ink Name
                </div>
                <div style="float: left; width: 25%">
                    <asp:TextBox ID="txtinkname" runat="server" CssClass="txtbox" Width="100%"></asp:TextBox>
                </div>
                <div style="float: left; width: 10px">
                    &nbsp;</div>
                <div style="float: left; width: 10%; vertical-align: middle">
                    <asp:CheckBox ID="chkcoated" runat="server" Text="Coated" />
                </div>
                <div style="float: left; width: 5%; vertical-align: middle">
                    Pack
                </div>
                <div style="float: left; width: 10%">
                    <asp:TextBox ID="txtpack" runat="server" CssClass="txtbox" Width="100%"></asp:TextBox>
                </div>
                <div style="float: left; width: 10px">
                    &nbsp;</div>
                <div style="float: left;">
                    <asp:Button ID="btn_inksearch" CssClass="button" runat="server" Text="Search" Width="65px"
                        OnClientClick="return false;" /></div>
                <div style="float: left; width: 10px">
                    &nbsp;</div>
                <div id="div_addInk" style="float: left; display: block">
                    <asp:Button ID="btnaddnewink" CssClass="button" runat="server" Text="Add New Ink"
                        Width="110px" OnClientClick="javascript:ShowAddStock('ink');return false;" />
                </div>
            </div>
            <div id="tblnote" style="float: left; display: block; width: 100%; display: none">
                <div id="tdpaper" style="float: left; width: 100%; display: none">
                    (Use '+' for AND ';' for OR to search for Name, Weight, Size or Color)</div>
                <div id="tdfilm" style="float: left; width: 100%; display: none">
                    (Use '+' for AND ';' for OR to search for Name and Size)</div>
                <div style="clear: both">
                </div>
            </div>
            <div style="clear: both;">
                &nbsp;
            </div>
            <div style="float: left; width: 95%; display: block">
                <table id="tblpaper" cellpadding="2" cellspacing="0" width="95%" style="float: left;
                    display: block;">
                    <tr style="background-color: #f0f0f0; font-weight: bold;">
                        <td class="tdall" style="color: #0B55C4;">
                            Action
                        </td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Code</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Paper</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Weight</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Size</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Pack Qty</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Pack Price('<%=commclass.GetCurrencyinRequiredFormate("",true) %>')</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Cost Price</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Supplier</td>
                    </tr>
                    <tr>
                        <td class="tdrightleftbottom">
                            <a href="#" id="lnkselect_paper" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a>
                            <%-- <img src="<%=strImagepath %>plus.gif" title="Add" onclick="javascript:staticbar('div_cylindersize');showhideDDL('hide');return false;" />--%>
                        </td>
                        <td class="tdrightbottom">
                            ABL250SR2BW</td>
                        <td class="tdrightbottom">
                            ADVOCATE BOARD LAID-BRIGHT WHITE</td>
                        <td class="tdrightbottom">
                            250</td>
                        <td class="tdrightbottom">
                            SAR2</td>
                        <td class="tdrightbottom">
                            200</td>
                        <td class="tdrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'33.92</td>
                        <td class="tdrightbottom">
                            169.62 Per 100</td>
                        <td class="tdrightbottom">
                            MY PRINTING CO</td>
                    </tr>
                    <tr style="background-color: #f9f9f9;">
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            ITM-000078</td>
                        <td class="tdnrightbottom">
                            BAKERS BM506 SEMIGLOSS MC80 Perm</td>
                        <td class="tdnrightbottom">
                            90</td>
                        <td class="tdnrightbottom">
                            1000x110</td>
                        <td class="tdnrightbottom">
                            1</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'36</td>
                        <td class="tdnrightbottom">
                            39.62 Per 100</td>
                        <td class="tdnrightbottom">
                            MY PRINTING CO</td>
                    </tr>
                    <tr>
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            ITM-000056</td>
                        <td class="tdnrightbottom">
                            CB 57 WHITE Idem Superior 330mm</td>
                        <td class="tdnrightbottom">
                            57</td>
                        <td class="tdnrightbottom">
                            7200x330</td>
                        <td class="tdnrightbottom">
                            1</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'4.69</td>
                        <td class="tdnrightbottom">
                            111.43 Per 1</td>
                        <td class="tdnrightbottom">
                            INKING LTD</td>
                    </tr>
                    <tr style="background-color: #f9f9f9;">
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            ITM-000028</td>
                        <td class="tdnrightbottom">
                            GLOSS ART 150 SRA2</td>
                        <td class="tdnrightbottom">
                            157</td>
                        <td class="tdnrightbottom">
                            SRA2</td>
                        <td class="tdnrightbottom">
                            500</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'16.00</td>
                        <td class="tdnrightbottom">
                            32 Per 1000</td>
                        <td class="tdnrightbottom">
                            MY PRINTING CO</td>
                    </tr>
                    <tr>
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            ITM-000045</td>
                        <td class="tdnrightbottom">
                            NCR MIDDLE SHEET PINK SRA3 CFB</td>
                        <td class="tdnrightbottom">
                            65</td>
                        <td class="tdnrightbottom">
                            SRA3</td>
                        <td class="tdnrightbottom">
                            500</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'25.00</td>
                        <td class="tdnrightbottom">
                            50 Per 1000</td>
                        <td class="tdnrightbottom">
                            ROBERT HORNE PAPER SUPPLIES</td>
                    </tr>
                </table>
                <table id="tblink" cellpadding="2" cellspacing="0" style="float: left; display: none;"
                    width="95%">
                    <tr style="background-color: #f0f0f0; font-weight: bold;">
                        <td class="tdall" style="color: #0B55C4;">
                            Action
                        </td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Ink Name</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Coated/Uncoated</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Pack Qty</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Pack Price('<%=commclass.GetCurrencyinRequiredFormate("",true) %>')</td>
                    </tr>
                    <tr>
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            BLACK C</td>
                        <td class="tdnrightbottom">
                            Uncoated</td>
                        <td class="tdnrightbottom">
                            1</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'8.00</td>
                    </tr>
                    <tr style="background-color: #f9f9f9;">
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            BLACK</td>
                        <td class="tdnrightbottom">
                            Uncoated</td>
                        <td class="tdnrightbottom">
                            1</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'10.00</td>
                    </tr>
                    <tr>
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            YELLOW C</td>
                        <td class="tdnrightbottom">
                            Uncoated</td>
                        <td class="tdnrightbottom">
                            1</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'9.00</td>
                    </tr>
                    <tr style="background-color: #f9f9f9;">
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            RHODAMINE RED C</td>
                        <td class="tdnrightbottom">
                            Uncoated</td>
                        <td class="tdnrightbottom">
                            1</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'4.00</td>
                    </tr>
                    <tr>
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            ORANGE 021 C</td>
                        <td class="tdnrightbottom">
                            Uncoated</td>
                        <td class="tdnrightbottom">
                            1</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'9.00</td>
                    </tr>
                </table>
                <table id="tblfilm" cellpadding="2" cellspacing="0" style="float: left; display: none;"
                    width="100%">
                    <tr style="background-color: #f0f0f0; font-weight: bold;">
                        <td class="tdall" style="color: #0B55C4;">
                            Action
                        </td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Film Name</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Size</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Height</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Width</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Exposure</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Pack Qty</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Pack Price('<%=commclass.GetCurrencyinRequiredFormate("",true) %>')</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Unit Selling Price</td>
                    </tr>
                    <tr>
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            SRA3 Film
                        </td>
                        <td class="tdnrightbottom">
                            100</td>
                        <td class="tdnrightbottom">
                            10</td>
                        <td class="tdnrightbottom">
                            10</td>
                        <td class="tdnrightbottom">
                            Positive</td>
                        <td class="tdnrightbottom">
                            60</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'60.00</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'10.00</td>
                    </tr>
                    <tr style="background-color: #f9f9f9;">
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            SRA4 Film
                        </td>
                        <td class="tdnrightbottom">
                            50</td>
                        <td class="tdnrightbottom">
                            15</td>
                        <td class="tdnrightbottom">
                            15</td>
                        <td class="tdnrightbottom">
                            Positive</td>
                        <td class="tdnrightbottom">
                            30</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'50.00</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'5.00</td>
                    </tr>
                    <tr>
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            RA3 Film
                        </td>
                        <td class="tdnrightbottom">
                            100</td>
                        <td class="tdnrightbottom">
                            10</td>
                        <td class="tdnrightbottom">
                            10</td>
                        <td class="tdnrightbottom">
                            Positive</td>
                        <td class="tdnrightbottom">
                            200</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'89.00</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'8.00</td>
                    </tr>
                    <tr style="background-color: #f9f9f9;">
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            A4 Film
                        </td>
                        <td class="tdnrightbottom">
                            50</td>
                        <td class="tdnrightbottom">
                            15</td>
                        <td class="tdnrightbottom">
                            15</td>
                        <td class="tdnrightbottom">
                            Positive</td>
                        <td class="tdnrightbottom">
                            30</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'50.00</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'5.00</td>
                    </tr>
                </table>
                <table id="tblplate" cellpadding="2" cellspacing="0" style="float: left; display: none;"
                    width="80%">
                    <tr style="background-color: #f0f0f0; font-weight: bold;">
                        <td class="tdall" style="color: #0B55C4;">
                            Action
                        </td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Plate Name</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Size</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Height</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Width</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Exposure</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Pack Qty</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Pack Price('<%=commclass.GetCurrencyinRequiredFormate("",true) %>')</td>
                        <td class="tdtopnrightbottom" style="color: #0B55C4;">
                            Unit Selling Price</td>
                    </tr>
                    <tr>
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            Komori Plate
                        </td>
                        <td class="tdnrightbottom">
                            100</td>
                        <td class="tdnrightbottom">
                            0</td>
                        <td class="tdnrightbottom">
                            0</td>
                        <td class="tdnrightbottom">
                            Positive</td>
                        <td class="tdnrightbottom">
                            1</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'1.13</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'10.00</td>
                    </tr>
                    <tr style="background-color: #f9f9f9;">
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            PrintMaster Plate
                        </td>
                        <td class="tdnrightbottom">
                            50</td>
                        <td class="tdnrightbottom">
                            15</td>
                        <td class="tdnrightbottom">
                            15</td>
                        <td class="tdnrightbottom">
                            Positive</td>
                        <td class="tdnrightbottom">
                            100</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'100.00</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'15.00</td>
                    </tr>
                    <tr>
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            SpeedMaster Plate
                        </td>
                        <td class="tdnrightbottom">
                            100</td>
                        <td class="tdnrightbottom">
                            0</td>
                        <td class="tdnrightbottom">
                            0</td>
                        <td class="tdnrightbottom">
                            Positive</td>
                        <td class="tdnrightbottom">
                            100</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'200</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'7.00</td>
                    </tr>
                    <tr style="background-color: #f9f9f9;">
                        <td class="tdrightleftbottom">
                            <a href="#" onclick="javascript:staticbar('divStockQuentity');showhideDDL('hide');return false;">
                                Select</a></td>
                        <td class="tdnrightbottom">
                            Heidelberg Plate
                        </td>
                        <td class="tdnrightbottom">
                            50</td>
                        <td class="tdnrightbottom">
                            15</td>
                        <td class="tdnrightbottom">
                            15</td>
                        <td class="tdnrightbottom">
                            Positive</td>
                        <td class="tdnrightbottom">
                            1</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'3.00</td>
                        <td class="tdnrightbottom">
                            '<%=commclass.GetCurrencyinRequiredFormate("",true) %>'15.00</td>
                    </tr>
                </table>
            </div>
            <div style="clear: both;">
                &nbsp;
            </div>
            <div id="divbtn" style="float: left; display: none">
                <asp:Button ID="btncancel" CssClass="button" runat="server" Text="Cancel" Width="65px"
                    OnClientClick="javascript:closewindow('dstock_only');return false;" /></div>
            <div style="clear: both;">
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div style="clear: both;">
    </div>
    <div style="clear: both;">
        &nbsp;
    </div>
    <div id="divStockQuentity" class="topbar" style="width: 400px;">
        <div align="center" class="bgcustomize" style="width: 100%; padding: 3px">
            <div style="float: left; width: 95%; border: 0px solid">
                <span class="navigatorpanel" style="vertical-align: middle">Stock Quantity</span></div>
            <div style="float: right; border: 0px solid">
                <a href="" onclick="javascript:closebar('divStockQuentity');showhideDDL('show');return false;">
                    <img src="<%=strImagepath%>close1.jpg" border="0" /></a></div>
            <div style="clear: both">
            </div>
        </div>
        <div align="left" class="border1px" style="width: 100%; padding: 2px">
            <div class="bglabel">
                <asp:Label ID="lblRollName" runat="server" CssClass="normalText">Required Stock Qty</asp:Label></div>
            <div class="box">
                <asp:TextBox ID="txtRollName" runat="server" Width="150px" CssClass="textboxnew"></asp:TextBox>
            </div>
            <div align="left" class="header" style="width: 90%">
                <div style="float: left; width: 47%">
                    &nbsp;</div>
                <div style="float: left">
                    <%--<asp:Button ID="btnMarkupRatesSave" runat="server" Text="Save" CssClass="button"
                    Width="65px" OnClientClick="changeCssItem('spnEst_3')return false;" CausesValidation="false" />--%>
                    <input type="button" value="Save" onclick="javascript: changeCssItem('spnEst_4'); closebar('divStockQuentity'); showhideDDL('show');"
                        class="button" />
                </div>
                <div style="float: left; width: 10px">
                    &nbsp;</div>
                <div style="float: left">
                    <asp:Button ID="btnMarkupRatesCancel" runat="server" Text="Cancel" CssClass="button"
                        Width="65px" OnClientClick="javascript:closebar('divStockQuentity');showhideDDL('show');return false;" /></div>
            </div>
            <div style="clear: both">
            </div>
        </div>
    </div>
</div>
<div id="divinventoryadd" style="display: none">
    <UC:Inventory ID="inventoryadd" runat="server" />
</div>
<div style="float: left; width: 950px">
    &nbsp;</div>

<script>
    function selectFilm(val) {

        alert(window.location.pathname)

        if (window.location.pathname == '/Epro_Ecrm/common/common_popup.aspx') {
            if (opener.location.pathname == '/Epro_Ecrm/Settings/plantpresses_lithosheet_add.aspx') {
                window.opener.document.getElementById("ctl00_ContentPlaceHolder1_lblFilm").innerHTML = val;
                window.close();
            }
            else {
                window.close();
            }
        }
        else {
            closewindow('div_stock_only');
        }
    }

    function GetButton_tdaddnew() {
        var dd = document.getElementById("<%=tdaddnew.ClientID %>").id;
     return dd;
 }
 function closestock_only() {

     // alert(urls);
     closewindow('' + urls + '');
     //   if(urls == "/Epro_Ecrm/purchase/purchase_add.aspx")
     //   {  
     //        closewindow('dstock_only');
     //   }
     //   else 
     //   {    
     //        closewindow('div_stock_only');
     //   }
     return false;
 }



</script>


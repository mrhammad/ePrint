<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="job_card_new.aspx.cs" Inherits="ePrint.Jobs.job_card_new"  masterpagefile="~/Templates/popUpMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        DateFormat = '<%=DateFormat %>';
        var CompanyID = '<%=CompanyID %>';
        var UserID = '<%=userID %>';
    </script>
    <script src="../js/Item/general.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <div>
        <%--id="content"--%>
        <div>
            <%--class="borderWithoutTop"--%>
            <div>
                <div style="width: 100%">
                    <div align="center" style="width: 100%; border: solid 0px red; margin-left: 5px;
                        margin-right: 0px;">
                        <table cellpadding="1" cellspacing="1" width="100%" border="0">
                            <tr>
                                <td width="15%">
                                    &nbsp;
                                </td>
                                <td width="42%">
                                    &nbsp;
                                </td>
                                <td width="42%">
                                    <span style="float: right; padding-right: 10px">
                                        <asp:Button runat="server" ID="btnSaveAndPrint" Text="Save & Print/Email" CssClass="button"
                                            OnClick="btnSave_OnClick" OnClientClick="javascript:CallPrint();" /></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="padding-left: 5px;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td class="bglabel1" width="40%">
                                                <span class="normalText">
                                                    <%=objLangauge.GetLanguageConversion("Job_Number") %></span>
                                            </td>
                                            <td style="padding-left: 5px">
                                                <asp:Label ID="lblJCjobNumber" CssClass="normalText" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bglabel1">
                                                <span id="spnEstimateNumber" runat="server" class="normalText"></span>
                                            </td>
                                            <td style="padding-left: 5px">
                                                <asp:Label ID="lblJCEstNumber" CssClass="normalText" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <asp:Panel ID="pnlFinishedQty" runat="server">
                                            <tr>
                                                <td class="bglabel1">
                                                    <span class="normalText">
                                                        <%=objLangauge.GetLanguageConversion("Finished_Quantity") %></span>
                                                </td>
                                                <td style="padding-left: 5px;">
                                                    <asp:Label ID="lblJCquantity" CssClass="normalText" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <tr>
                                            <td class="bglabel1">
                                                <span class="normalText">
                                                    <%=objLangauge.GetLanguageConversion("Item_Title") %></span>
                                            </td>
                                            <td style="padding-left: 5px">
                                                <asp:Label ID="lblJCtitle" CssClass="normalText" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bglabel1">
                                                <span class="normalText">
                                                    <%=objLangauge.GetLanguageConversion("Customer") %></span>
                                            </td>
                                            <td style="padding-left: 5px">
                                                <asp:Label ID="lblJCcustomer" CssClass="normalText" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bglabel1">
                                                <span class="normalText">
                                                    <%=objLangauge.GetLanguageConversion("Delivery_Address") %></span>
                                            </td>
                                            <td style="padding-left: 5px">
                                                <asp:Label ID="lblDeliveryAddress" CssClass="normalText" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="98%" border="0">
                                        <tr id="trheader" runat="server">
                                            <td width="40%">
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <div align="left">
                                                    <div style="float: left; width: 85px;">
                                                        <span class="normalText">
                                                            <%=objLangauge.GetLanguageConversion("Estimated") %></span>
                                                    </div>
                                                    <div style="float: left;">
                                                        <span class="normalText" style="color: Red;">
                                                            <%=objLangauge.GetLanguageConversion("Actual") %></span>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="trArtworkDate" runat="server">
                                            <td class="bglabel1">
                                                <span class="normalText">
                                                    <%=objLangauge.GetLanguageConversion("Artwork_Date")%></span>
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox runat="server" ID="txtReqArtwork" SkinID="textPad" Width="80px"></asp:TextBox>
                                                <span id="spn_txtReqArtwork" class="spanerrorMsg" style="display: none; width: 100px">
                                                </span>
                                                <asp:TextBox runat="server" ID="txtActArtwork" SkinID="textPad" Width="80px"></asp:TextBox>
                                                <span id="spn_txtActArtwork" class="spanerrorMsg" style="display: none; width: 100px">
                                                </span>
                                            </td>
                                        </tr>
                                        <tr id="trProofDate" runat="server">
                                            <td class="bglabel1">
                                                <span class="normalText">
                                                    <%=objLangauge.GetLanguageConversion("Proof_Date") %></span>
                                            </td>
                                            <td style="padding-left: 5px">
                                                <asp:TextBox runat="server" ID="txtReqProof" SkinID="textPad" Width="80px"></asp:TextBox>
                                                <span id="spn_txtReqProof" class="spanerrorMsg" style="display: none; width: 100px">
                                                </span>
                                                <asp:TextBox runat="server" ID="txtActProof" SkinID="textPad" Width="80px"></asp:TextBox>
                                                <span id="spn_txtActProof" class="spanerrorMsg" style="display: none; width: 100px">
                                                </span>
                                            </td>
                                        </tr>
                                        <tr id="div_ApprovalNew" runat="server">
                                            <td class="bglabel1">
                                                <span class="normalText">
                                                    <%=objLangauge.GetLanguageConversion("Approval_Date") %></span>
                                            </td>
                                            <td style="padding-left: 5px">
                                                <asp:TextBox runat="server" ID="txtReqApproval" SkinID="textPad" Width="80px"></asp:TextBox>
                                                <span id="spn_txtReqApproval" class="spanerrorMsg" style="display: none; width: 100px">
                                                </span>
                                                <asp:TextBox runat="server" ID="txtActApproval" SkinID="textPad" Width="80px"></asp:TextBox>
                                                <span id="spn_txtActApproval" class="spanerrorMsg" style="display: none; width: 100px">
                                                </span>
                                            </td>
                                        </tr>
                                        <tr id="divProductionDate" runat="server">
                                            <td class="bglabel1">
                                                <span class="normalText">
                                                    <%=objLangauge.GetLanguageConversion("Production_Date") %></span>
                                            </td>
                                            <td style="padding-left: 5px">
                                                <asp:TextBox runat="server" ID="txtReqProduction" SkinID="textPad" Width="80px"></asp:TextBox>
                                                <span id="spn_txtReqProduction" class="spanerrorMsg" style="display: none; width: 100px">
                                                </span>
                                                <asp:TextBox runat="server" ID="txtActProduction" SkinID="textPad" Width="80px"></asp:TextBox>
                                                <span id="spn_txtActProduction" class="spanerrorMsg" style="display: none; width: 100px">
                                                </span>
                                            </td>
                                        </tr>
                                        <tr id="div_JobcardDeliverydate" runat="server">
                                            <td class="bglabel1">
                                                <span class="normalText">
                                                    <%=objLangauge.GetLanguageConversion("Delivery_Date") %></span>
                                            </td>
                                            <td style="padding-left: 5px">
                                                <asp:TextBox runat="server" ID="txtReqDelivery" SkinID="textPad" Width="80px"></asp:TextBox>
                                                <span id="spn_txtReqDelivery" class="spanerrorMsg" style="display: none; width: 100px">
                                                </span>
                                                <asp:TextBox runat="server" ID="txtActDelivery" SkinID="textPad" Width="80px"></asp:TextBox>
                                                <span id="spn_txtActDelivery" class="spanerrorMsg" style="display: none; width: 100px">
                                                </span>
                                            </td>
                                        </tr>
                                        <tr id="jobtime_tr" runat="server">
                                            <td class="bglabel1">
                                                <span class="normalText">
                                                    <%=objLangauge.GetLanguageConversion("Job_Time_min")%></span>
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtEstJobTime" runat="server" SkinID="textPad" Width="80px" ReadOnly="true"></asp:TextBox>
                                                <asp:TextBox ID="txtActJobTime" runat="server" SkinID="textPad" Width="80px" onclick="javascript:this.select();"
                                                    onblur="javascript:AllowNumber(this,this.value);todecimal_function(this,this.value);MarkupOnBlur_Press(this);"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <div class="only10px">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="normalText"><b>
                                        <%=objLangauge.GetLanguageConversion("Item_Details") %></b></span>
                                </td>
                                <td style="padding-left: 5px">
                                    <span class="normalText"><b>
                                        <%=objLangauge.GetLanguageConversion("Estimated") %></b></span>
                                </td>
                                <td>
                                    <span class="normalText" style="color: Red;"><b>
                                        <%=objLangauge.GetLanguageConversion("Actual") %></b></span>
                                </td>
                            </tr>
                            <tr valign="top" runat="server" id="tr_Pre_Press">
                                <td style="vertical-align: top">
                                    <asp:Label ID="lbl_prepress" runat="server" Text="Pre Press" CssClass="bglabel1"
                                        Width="95%"><%=objLangauge.GetLanguageConversion("Pre_Press") %></asp:Label>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:TextBox ID="txtReqPrePress" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                        Width="97%"></asp:TextBox>
                                    <asp:Label ID="lblReqPrePress" runat="server" CssClass="normalText"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtActPrePress" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                        Width="97%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr valign="top" id="tr_Press" runat="server">
                                <td style="vertical-align: top">
                                    <asp:Label ID="lbl_press" runat="server" Text="Press" CssClass="bglabel1" Width="95%"><%=objLangauge.GetLanguageConversion("Press") %></asp:Label>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:TextBox ID="txtReqPress" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                        Width="97%"></asp:TextBox>
                                    <asp:Label ID="lblReqPress" runat="server" CssClass="normalText"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtActPress" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                        Width="97%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr valign="top" id="tr_Post_Press" runat="server">
                                <td style="vertical-align: top">
                                    <asp:Label ID="lbl_postpress" runat="server" Text="Post Press" CssClass="bglabel1"
                                        Width="95%"><%=objLangauge.GetLanguageConversion("Post_Press") %></asp:Label>
                                </td>
                                <td style="padding-left: 5px">
                                    <asp:TextBox ID="txtReqPostPress" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                        Width="97%"></asp:TextBox>
                                    <asp:Label ID="lblReqPostPress" runat="server" CssClass="normalText"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtActPostPress" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                        Width="97%">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <asp:Panel ID="pnlWarehouse" Visible="true" runat="server">
                                <tr valign="top">
                                    <td style="vertical-align: top">
                                        <asp:Label ID="lbl_Warehouse" runat="server" Text="Warehouse" CssClass="bglabel1"
                                            Width="95%"><%=objLangauge.GetLanguageConversion("Warehouse_Report") %></asp:Label>
                                    </td>
                                    <td style="padding-left: 5px">
                                        <asp:TextBox ID="txtReqWarehouse" runat="server" TextMode="MultiLine" Rows="4" SkinID="textPad"
                                            Width="97%"></asp:TextBox>
                                        <asp:Label ID="lblReqWarehouse" runat="server" CssClass="normalText"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtActwarehouse" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="pnlPriceCatalogue" Visible="true" runat="server">
                                <tr valign="top">
                                    <td style="vertical-align: top">
                                        <asp:Label ID="lbl_PriceCatalogue" runat="server" Text="Product Catalogue" CssClass="bglabel1"
                                            Width="95%"><%=objLangauge.GetLanguageConversion("Product_Catalogue") %></asp:Label>
                                    </td>
                                    <td style="padding-left: 5px">
                                        <asp:TextBox ID="txtReqPriceCatalogue" runat="server" TextMode="MultiLine" Rows="6"
                                            SkinID="textPad" Width="97%"></asp:TextBox>
                                        <asp:Label ID="lblReqPriceCatalogue" runat="server" CssClass="normalText"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtActPriceCatalogue" runat="server" TextMode="MultiLine" Rows="6"
                                            SkinID="textPad" Width="97%">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="pnlOutwork" Visible="true" runat="server">
                                <tr valign="top">
                                    <td style="vertical-align: top">
                                        <asp:Label ID="lbl_Outwork" runat="server" Text="Outwork" CssClass="bglabel1" Width="95%"><%=objLangauge.GetLanguageConversion("Outwork") %></asp:Label>
                                    </td>
                                    <td style="padding-left: 5px">
                                        <asp:TextBox ID="txtReqOutwork" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%"></asp:TextBox>
                                        <asp:Label ID="lblReqOutwork" runat="server" CssClass="normalText"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtActOutwork" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="pnlAdmin" Visible="true" runat="server">
                                <tr valign="top">
                                    <td style="vertical-align: top">
                                        <asp:Label ID="Label1" runat="server" Text="Admin" CssClass="bglabel1" Width="95%"><%=objLangauge.GetLanguageConversion("Admin") %></asp:Label>
                                    </td>
                                    <td style="padding-left: 5px">
                                        <asp:TextBox ID="txtReqAdmin" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%"></asp:TextBox>
                                        <asp:Label ID="lblreqAdmin" runat="server" CssClass="normalText" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtActAdmin" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="PnlPaper" Visible="true" runat="server">
                                <tr valign="top" id="tr_Paper" runat="server">
                                    <td style="vertical-align: top">
                                        <asp:Label ID="Label2" runat="server" Text="Paper" CssClass="bglabel1" Width="95%"><%=objLangauge.GetLanguageConversion("Paper") %></asp:Label>
                                    </td>
                                    <td style="padding-left: 5px">
                                        <asp:TextBox ID="txtReqPaper" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%"></asp:TextBox>
                                        <asp:Label ID="lblreqPaper" runat="server" CssClass="normalText" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtActPaper" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="PnlInk" Visible="true" runat="server">
                                <tr valign="top" id="tr_ink" runat="server">
                                    <td style="vertical-align: top">
                                        <asp:Label ID="Label3" runat="server" Text="Ink" CssClass="bglabel1" Width="95%"><%=objLangauge.GetLanguageConversion("Ink") %></asp:Label>
                                    </td>
                                    <td style="padding-left: 5px">
                                        <asp:TextBox ID="txtReqInk" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%"></asp:TextBox>
                                        <asp:Label ID="lblreqInk" runat="server" CssClass="normalText" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtActInk" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="PnlPlates" Visible="true" runat="server">
                                <tr valign="top" id="tr_Plates" runat="server">
                                    <td style="vertical-align: top">
                                        <asp:Label ID="Label4" runat="server" Text="Plates" CssClass="bglabel1" Width="95%"><%=objLangauge.GetLanguageConversion("Plates") %></asp:Label>
                                    </td>
                                    <td style="padding-left: 5px">
                                        <asp:TextBox ID="txtReqPlates" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%"></asp:TextBox>
                                        <asp:Label ID="lblreqPlates" runat="server" CssClass="normalText" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtActPlates" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="PnlGuillotine" Visible="true" runat="server">
                                <tr valign="top" id="tr_Guillotine" runat="server">
                                    <td style="vertical-align: top">
                                        <asp:Label ID="Label5" runat="server" Text="Guillotine" CssClass="bglabel1" Width="95%"><%=objLangauge.GetLanguageConversion("Guillotine")%></asp:Label>
                                    </td>
                                    <td style="padding-left: 5px">
                                        <asp:TextBox ID="txtReqGuillotine" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%"></asp:TextBox>
                                        <asp:Label ID="lblreqGuillotine" runat="server" CssClass="normalText" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtActGuillotine" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="PnlWashUp" Visible="true" runat="server">
                                <tr valign="top" id="tr_washup" runat="server">
                                    <td style="vertical-align: top">
                                        <asp:Label ID="Label6" runat="server" Text="Wash up" CssClass="bglabel1" Width="95%"><%=objLangauge.GetLanguageConversion("Wash_Up")%></asp:Label>
                                    </td>
                                    <td style="padding-left: 5px">
                                        <asp:TextBox ID="txtReqWashUp" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%"></asp:TextBox>
                                        <asp:Label ID="lblreqWashUp" runat="server" CssClass="normalText" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtActWashUp" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="PnlMakeReady" Visible="true" runat="server">
                                <tr valign="top" id="tr_makeready" runat="server">
                                    <td style="vertical-align: top">
                                        <asp:Label ID="Label7" runat="server" Text="Make Ready" CssClass="bglabel1" Width="95%"><%=objLangauge.GetLanguageConversion("Make_Ready")%></asp:Label>
                                    </td>
                                    <td style="padding-left: 5px">
                                        <asp:TextBox ID="txtReqMakeReady" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%"></asp:TextBox>
                                        <asp:Label ID="lblreqMakeReady" runat="server" CssClass="normalText" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtActMakeReady" runat="server" TextMode="MultiLine" Rows="6" SkinID="textPad"
                                            Width="97%">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                        </table>
                        <table cellpadding="0" cellspacing="2" border="0" align="center" width="100%" style="margin-top: 10px;">
                            <tr id="tr_allbuttons" runat="server">
                                <td colspan="3" align="right" style="padding-right: 12px;">
                                    <asp:Button runat="server" ID="btncancel" Text="Cancel" Width="65px" CssClass="button"
                                        OnClientClick="javascript:window.close();return false;" /><span style="margin-left: 10px">&nbsp;</span>
                                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="button" Width="65px"
                                        OnClick="btnSave_OnClick" />
                                    <span style="margin-right: 10px">&nbsp;</span>
                                    <asp:Button runat="server" ID="btn1" Text="Save & Print/Email" CssClass="button"
                                        Width="130px" OnClick="btnSave_OnClick" OnClientClick="javascript:CallPrint();" />
                                    <asp:HiddenField ID="hidSaveType" runat="server" Value="save" />
                                    <asp:HiddenField ID="hidCompanyID" runat="server" Value="0" />
                                </td>
                            </tr>
                            <tr id="tr_okbutton" runat="server" visible="false">
                                <td colspan="3" align="right" style="padding-right: 12px;">
                                    <asp:Button runat="server" ID="btnOk" Text="Ok" Width="65px" CssClass="button" OnClientClick="javascript:window.close();return false;" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="only10px">
                </div>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlPrint" runat="server" Visible="false">
        <script>
            var CompID = document.getElementById("<%=hidCompanyID.ClientID %>").value;
            if ('<%=ordid %>' != '') {
                parent.parent.window.location.href = "templates_view1.aspx?sectionid=" + CompID + "&sectionname=Job&type=Customer&page=Job&ordid=<%=ordid %>&EstID=<%=EstimateID %>&EstItemID=<%=EstimateItemID %>&jID=<%=JobID %>";
            }
            else {
                parent.parent.window.location.href = "templates_view1.aspx?sectionid=" + CompID + "&sectionname=Job&type=Customer&page=Job&EstID=<%=EstimateID %>&EstItemID=<%=EstimateItemID %>&jID=<%=JobID %>";
            }
            window.close();
            
        </script>
    </asp:Panel>
    <script>
        var hidSaveType = document.getElementById("<%=hidSaveType.ClientID%>");
        function CallPrint() { // changes for bugid : 1316
            hidSaveType.value = "print";
        }

       

    </script>
    <script>
        var currentdate = '<%=newdate %>';
        var spn_txtReqArtwork = document.getElementById("spn_txtReqArtwork");
        var spn_txtReqProof = document.getElementById("spn_txtReqProof");
        var spn_txtReqApproval = document.getElementById("spn_txtReqApproval");
        var spn_txtReqProduction = document.getElementById("spn_txtReqProduction");
        var spn_txtReqDelivery = document.getElementById("spn_txtReqDelivery");

        var txtReqArtwork = document.getElementById("<%=txtReqArtwork.ClientID%>");
        var txtReqProof = document.getElementById("<%=txtReqProof.ClientID %>");
        var txtReqApproval = document.getElementById("<%=txtReqApproval.ClientID %>");
        var txtReqProduction = document.getElementById("<%=txtReqProduction.ClientID %>");
        var txtReqDelivery = document.getElementById("<%=txtReqDelivery.ClientID%>");
        var txtActArtwork = document.getElementById("<%=txtActArtwork.ClientID%>");
        var txtActProof = document.getElementById("<%=txtActProof.ClientID %>");
        var txtActApproval = document.getElementById("<%=txtActApproval.ClientID %>");
        var txtActProduction = document.getElementById("<%=txtActProduction.ClientID %>");
        var txtActDelivery = document.getElementById("<%=txtActDelivery.ClientID%>");
        var checkwhat = false;

        function checkvalidation() {
            document.getElementById("<%=hidSaveType.ClientID%>").value = "save";
            checkwhat = true;
            spn_txtReqArtwork.style.display = "none";
            spn_txtReqProof.style.display = "none";
            spn_txtReqApproval.style.display = "none";
            spn_txtReqProduction.style.display = "none";
            spn_txtReqDelivery.style.display = "none";
            spn_txtActArtwork.style.display = "none";
            spn_txtActProof.style.display = "none";
            spn_txtActApproval.style.display = "none";
            spn_txtActProduction.style.display = "none";
            spn_txtActDelivery.style.display = "none";
            if (txtReqArtwork.value == '') {
                spn_txtReqArtwork.innerHTML = "Please enter ArtWork Date";
                spn_txtReqArtwork.style.display = "block";
                checkwhat = false;
            }
            else {
                if (ValidateForm(txtReqArtwork, 'spn_txtReqArtwork', DateFormat) == false)
                    checkwhat = false;
            }
            if (txtReqProof.value == '') {
                spn_txtReqProof.innerHTML = "Please enter Proof Date";
                spn_txtReqProof.style.display = "block";
                checkwhat = false;
            }
            else {
                if (ValidateForm(txtReqProof, 'spn_txtReqProof', DateFormat) == false)
                    checkwhat = false;
            }
            if (txtReqApproval.value == '') {
                spn_txtReqApproval.innerHTML = "Please enter Approval Date";
                spn_txtReqApproval.style.display = "block";
                checkwhat = false;
            }
            else {
                if (ValidateForm(txtReqApproval, 'spn_txtReqApproval', DateFormat) == false)
                    checkwhat = false;
            }
            if (txtReqProduction.value == '') {
                spn_txtReqProduction.innerHTML = "Please enter Production Date";
                spn_txtReqProduction.style.display = "block";
                checkwhat = false;
            }
            else {
                if (ValidateForm(txtReqProduction, 'spn_txtReqProduction', DateFormat) == false)
                    checkwhat = false;
            }
            if (txtReqDelivery.value == '') {
                spn_txtReqDelivery.innerHTML = "Please enter Delivery Date";
                spn_txtReqDelivery.style.display = "block";
                checkwhat = false;
            }
            else {
                if (ValidateForm(txtReqDelivery, 'spn_txtReqDelivery', DateFormat) == false)
                    checkwhat = false;
            }





            if (txtActArtwork.value != '') {
                if (ValidateForm(txtActArtwork, 'spn_txtActArtwork', DateFormat) == false)
                    checkwhat = false;
            }

            if (txtActProof.value != '') {
                if (ValidateForm(txtActProof, 'spn_txtActProof', DateFormat) == false)
                    checkwhat = false;
            }

            if (txtActApproval.value != '') {
                if (ValidateForm(txtActApproval, 'spn_txtActApproval', DateFormat) == false)
                    checkwhat = false;
            }

            if (txtActProduction.value != '') {
                if (ValidateForm(txtActProduction, 'spn_txtActProduction', DateFormat) == false)
                    checkwhat = false;
            }

            if (txtActDelivery.value != '') {
                if (ValidateForm(txtActDelivery, 'spn_txtActDelivery', DateFormat) == false)
                    checkwhat = false;
            }
            //     } 
            if (checkwhat) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <script type="text/javascript" src="../common/swazz_calendar.js?VN='<%#VersionNumber%>'"></script>
    <script type="text/javascript" src="../js/Item/general.js?VN='<%#VersionNumber%>'"></script>
    <script>
        //Price Catalogue
        var lblReqPrePress = document.getElementById("<%=lblReqPrePress.ClientID %>");
        var txtActPrePressID = document.getElementById("<%=txtActPrePress.ClientID %>").id;

        var lblReqPress = document.getElementById("<%=lblReqPress.ClientID %>");
        var txtActPressID = document.getElementById("<%=txtActPress.ClientID %>").id;

        var lblReqPostPress = document.getElementById("<%=lblReqPostPress.ClientID %>");
        var txtActPostPressID = document.getElementById("<%=txtActPostPress.ClientID %>").id;

        var lblReqWarehouse = document.getElementById("<%=lblReqWarehouse.ClientID %>");
        var txtActwarehouseID = document.getElementById("<%=txtActwarehouse.ClientID %>").id;

        var lblReqPriceCatalogue = document.getElementById("<%=lblReqPriceCatalogue.ClientID %>");
        var txtActPriceCatalogueID = document.getElementById("<%=txtActPriceCatalogue.ClientID %>").id;

        var lblReqOutwork = document.getElementById("<%=lblReqOutwork.ClientID %>");
        var txtActOutworkID = document.getElementById("<%=txtActOutwork.ClientID %>").id;

        function CallAfterLoad() {

        }
        function CommonCall(lbl, divObj, txtActID) {
            if (lbl.innerHTML == '') {
                divObj.style.height = "50px";
            }
            TextArea_Increase(txtActID);
        }
        CallAfterLoad();
    </script>
    <asp:Panel ID="pnl_closePopup" runat="server" Visible="false">
        <script type="text/javascript">
            function CallNow() {
                setTimeout("TakeOut()", 700);
                return false;
            }
            function TakeOut() {
                window.close();
            }
            CallNow();
        </script>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


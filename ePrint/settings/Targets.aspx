<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.Master" AutoEventWireup="true" CodeBehind="Targets.aspx.cs" Inherits="ePrint.settings.Targets" %>

<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="estore_settingBox" style="min-height: 400px; width: 99%;">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div id="Div_Msg" style="padding: 10px 0px 0px 10px; margin-bottom: -10px;">
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="width: 100%; margin-top: -18px" class="mis_header_panel">
            <div id="">
                <asp:UpdatePanel ID="UpdatePnl" ChildrenAsTriggers="false" UpdateMode="Conditional"
                    RenderMode="Inline" runat="server">
                    <ContentTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="left" style="width: 150px;">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server"
                                        onclick="javascript:TargetChange();">
                                        <asp:ListItem Text="Daily Target" Value="Daily" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Monthly Target" Value="Monthly"></asp:ListItem>
                                    </asp:RadioButtonList>

                                </td>

                            </tr>
                            <tr id="trDailyTarget">
                                <td style="padding: 9px">
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label1" runat="server">Day 1</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label2" runat="server">Day 2</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label3" runat="server">Day 3</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label4" runat="server">Day 4</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label5" runat="server">Day 5</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label6" runat="server">Day 6</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label7" runat="server">Day 7</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label8" runat="server">Day 8</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label9" runat="server">Day 9</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label10" runat="server">Day 10</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label11" runat="server">Day 11</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label12" runat="server">Day 12</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label13" runat="server">Day 13</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label14" runat="server">Day 14</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label15" runat="server">Day 15</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label16" runat="server">Day 16</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label17" runat="server">Day 17</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label18" runat="server">Day 18</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label19" runat="server">Day 19</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label20" runat="server">Day 20</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label21" runat="server">Day 21</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label22" runat="server">Day 22</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label23" runat="server">Day 23</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label24" runat="server">Day 24</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label25" runat="server">Day 25</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label26" runat="server">Day 26</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label27" runat="server">Day 27</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label28" runat="server">Day 28</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label29" runat="server">Day 29</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label30" runat="server">Day 30</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label31" runat="server">Day 31</asp:Label>

                                    </div>
                                </td>
                                <td>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget1" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget2" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget3" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget4" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget5" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget6" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget7" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget8" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget9" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget10" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget11" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget12" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget13" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget14" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget15" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget16" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget17" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget18" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget19" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget20" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget21" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget22" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget23" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget24" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget25" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget26" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget27" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget28" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget29" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget30" runat="server" /><br>
                                    <asp:TextBox type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="DailyTarget31" runat="server" /><br>
                                </td>


                            </tr>
                            <tr id="trMonthlyTarget" style="display: none">
                                <td style="padding: 9px">
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label33" runat="server">January</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label34" runat="server">February</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label35" runat="server">March</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label36" runat="server">April</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label37" runat="server">May</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label38" runat="server">June</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label39" runat="server">July</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label40" runat="server">August</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label41" runat="server">September</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label42" runat="server">October</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label43" runat="server">November</asp:Label>

                                    </div>
                                    <div class="bglabel" style="width: 150px;">
                                        <asp:Label ID="Label44" runat="server">December</asp:Label>

                                    </div>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="MonthlyTarget1" /><br>
                                    <asp:TextBox runat="server" type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="MonthlyTarget2" /><br>
                                    <asp:TextBox runat="server" type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="MonthlyTarget3" /><br>
                                    <asp:TextBox runat="server" type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="MonthlyTarget4" /><br>
                                    <asp:TextBox runat="server" type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="MonthlyTarget5" /><br>
                                    <asp:TextBox runat="server" type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="MonthlyTarget6" /><br>
                                    <asp:TextBox runat="server" type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="MonthlyTarget7" /><br>
                                    <asp:TextBox runat="server" type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="MonthlyTarget8" /><br>
                                    <asp:TextBox runat="server" type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="MonthlyTarget9" /><br>
                                    <asp:TextBox runat="server" type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="MonthlyTarget10" /><br>
                                    <asp:TextBox runat="server" type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="MonthlyTarget11" /><br>
                                    <asp:TextBox runat="server" type="number" Style="width: 110px; margin-bottom: 2px; padding: 2px;" ID="MonthlyTarget12" /><br>
                                </td>


                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSaveTarget" runat="server" CssClass="button" Text="Save" CausesValidation="False"
                                        OnClick="btnSaveTarget_Click" OnClientClick="javascript:var a=CheckValidation();if(a) loadingimage(this.id,'div_btnSave');return a;" Style="margin-left: 8px;"></asp:Button>
                                    <div id="div_btnSave" style="display: none; float: left">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>
        <div style="clear: both;">
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        function CheckValidation() {
            return true;
        }

        function TargetChange() {
            debugger;
            var rdolist = document.getElementById("<%=RadioButtonList1.ClientID %>");
            var options = rdolist.getElementsByTagName("input");
            for (var i = 0; i < options.length; i++) {

                if (options[i].type == "radio" && options[i].checked) {

                    if (options[i].value == "Daily") {
                        LoadTargets(options[i].value);
                        $("#trDailyTarget").css('display', 'block');
                        $("#trMonthlyTarget").css('display', 'none');
                    }
                    else if (options[i].value == "Monthly") {
                        LoadTargets(options[i].value);
                        $("#trDailyTarget").css('display', 'none');
                        $("#trMonthlyTarget").css('display', 'block');
                    }
                }
            }
        }
        function LoadTargets(DataType) {
            var dataValue = { "DataType": DataType };
            $.ajax({
                type: "POST",
                url: "Targets.aspx/LoadTargetData",
                data: JSON.stringify(dataValue),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                },
                success: function (result) {
                    debugger;
                    var data = JSON.parse(result.d);
                    $.each(data, function (ind, val) {
                        document.getElementById("ctl00_ContentPlaceHolder1_MonthlyTarget1").value = val.MonthlyTarget1;
                        document.getElementById("ctl00_ContentPlaceHolder1_MonthlyTarget2").value = val.MonthlyTarget2;
                        document.getElementById("ctl00_ContentPlaceHolder1_MonthlyTarget3").value = val.MonthlyTarget3;
                        document.getElementById("ctl00_ContentPlaceHolder1_MonthlyTarget4").value = val.MonthlyTarget4;
                        document.getElementById("ctl00_ContentPlaceHolder1_MonthlyTarget5").value = val.MonthlyTarget5;
                        document.getElementById("ctl00_ContentPlaceHolder1_MonthlyTarget6").value = val.MonthlyTarget6;
                        document.getElementById("ctl00_ContentPlaceHolder1_MonthlyTarget7").value = val.MonthlyTarget7;
                        document.getElementById("ctl00_ContentPlaceHolder1_MonthlyTarget8").value = val.MonthlyTarget8;
                        document.getElementById("ctl00_ContentPlaceHolder1_MonthlyTarget9").value = val.MonthlyTarget9;
                        document.getElementById("ctl00_ContentPlaceHolder1_MonthlyTarget10").value = val.MonthlyTarget10;
                        document.getElementById("ctl00_ContentPlaceHolder1_MonthlyTarget11").value = val.MonthlyTarget11;
                        document.getElementById("ctl00_ContentPlaceHolder1_MonthlyTarget12").value = val.MonthlyTarget12;

                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget1").value = val.DailyTarget1;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget2").value = val.DailyTarget2;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget3").value = val.DailyTarget3;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget4").value = val.DailyTarget4;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget5").value = val.DailyTarget5;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget6").value = val.DailyTarget6;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget7").value = val.DailyTarget7;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget8").value = val.DailyTarget8;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget9").value = val.DailyTarget9;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget10").value = val.DailyTarget10;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget11").value = val.DailyTarget11;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget12").value = val.DailyTarget12;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget13").value = val.DailyTarget13;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget14").value = val.DailyTarget14;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget15").value = val.DailyTarget15;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget16").value = val.DailyTarget16;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget17").value = val.DailyTarget17;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget18").value = val.DailyTarget18;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget19").value = val.DailyTarget19;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget20").value = val.DailyTarget20;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget21").value = val.DailyTarget21;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget22").value = val.DailyTarget22;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget23").value = val.DailyTarget23;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget24").value = val.DailyTarget24;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget25").value = val.DailyTarget25;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget26").value = val.DailyTarget26;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget27").value = val.DailyTarget27;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget28").value = val.DailyTarget28;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget29").value = val.DailyTarget29;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget30").value = val.DailyTarget30;
                        document.getElementById("ctl00_ContentPlaceHolder1_DailyTarget31").value = val.DailyTarget31;



                    })
                    //    window.open(result.d, '_blank');
                }
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>


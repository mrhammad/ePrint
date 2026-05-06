<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="spentlimit.aspx.cs" Inherits="ePrint.common.spentlimit" %>--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/popUpMasterPage.master" AutoEventWireup="true" CodeBehind="spentlimit.aspx.cs" Inherits="ePrint.common.spentlimit" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">

        var ddlRollOverLimit = document.getElementById("<%=ddlRollOverLimit.ClientID %>");
        var chkRollover = document.getElementById("<%=chkRollover.ClientID %>");
        var dtpRollOverDate = document.getElementById("<%=dtpRollOverDate.ClientID %>");
                          
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
            //oWindow.close();
        }

        function clientClose(arg) {
            GetRadWindow().close(arg);
        }

        function btnSaveValidate() {
            var txtAmount = document.getElementById("ctl00_ContentPlaceHolder1_txt_SpendAmount").value;
            if (txtAmount = "" || txtAmount.trim() == "") {
                document.getElementById("spnSpendAmount").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_Div_Save").style.paddingLeft = "23%";
                return false;
            }
        }
        function onlyNos(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    return false;
                }
                return true;
            }
            catch (err) {
                alert(err.Description);
            }
        }
        
        function enableDsableRollOver(checkbox) {
         
            if (checkbox.checked) {
                ctl00_ContentPlaceHolder1_ddlRollOverLimit.disabled = false;;

                ctl00_ContentPlaceHolder1_dtpRollOverDate.disabled = false;
            } else {
                ctl00_ContentPlaceHolder1_dtpRollOverDate.disabled = true;
                ctl00_ContentPlaceHolder1_ddlRollOverLimit.disabled = true;
            }
        }

    </script>
    <asp:Panel ID="pnlLoadContactPanel" runat="server" Visible="false">
        <script type="text/javascript" language="javascript">
            var Type = '<%=Type %>';
            if (Type == 'user') {
                Type = 'contacts';
            }
            else {
                Type = 'dept';
            }
            function LoadContactPanel() {
                var pw = window.parent;
                pw.SetTabs(Type, 'yes');
                GetRadWindow().close();
                return false;
            }
            LoadContactPanel();
        </script>
    </asp:Panel>
    <div align="left" style="width: 100%;">
        <div align="left">
            <div id="div_CompanyType" runat="server" align="left">
                <div class="bglabel" style="width: 20%;">
                    <asp:Label ID="lblPeriod" runat="server" Text="Select Period" CssClass="normaltext"></asp:Label>
                </div>
                <div class="ddlsetting" runat="server">
                    <asp:DropDownList ID="ddlPeriod" runat="server" OnSelectedIndexChanged="ddlPeriod_SelectedIndexChanged"  Width="120px" Style="padding-top: -8px; height: 20px;" AutoPostBack="true">
                        <asp:ListItem>Calendar Year</asp:ListItem>
                        <asp:ListItem>Financial Year</asp:ListItem>
                        <asp:ListItem>Month</asp:ListItem>
                        <asp:ListItem>Week</asp:ListItem>
                        <asp:ListItem>Day</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div align="left">
                <div class="bglabel" style="width: 20%;">
                    <asp:Label ID="lblAmount" runat="server" Text="Amount" CssClass="normaltext"></asp:Label>
                    <span style="color: Red;">*</span>
                </div>
                <div class="box" style="padding-left: 5px;">
                    <asp:TextBox ID="txt_SpendAmount" onkeypress="return onlyNos(event,this);" onKeydown="Javascript: if(event.keyCode==13) return false;"
                        runat="server" Width="120px" class="textboxnew"></asp:TextBox>
                    <span id="spnSpendAmount" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"
                        class="spanerrorMsg">
                        <%=objLanguage.GetLanguageConversion("Please_enter_amount")%>
                    </span>
                </div>
            </div>

            <div id="div1" runat="server" align="left">
                <div class="bglabel" style="width: 20%;">
                    <asp:Label ID="Label1" runat="server" Text="Roll Over" CssClass="normaltext"></asp:Label>
                </div>
                <div class="ddlsetting">

                    <asp:CheckBox ID="chkRollover" runat="server" onclick="enableDsableRollOver(this)" />
                </div>
            </div>

            <div id="div2" runat="server" align="left">
                <div class="bglabel" style="width: 20%;">
                    <asp:Label ID="Label2" runat="server" Text="Roll Over Limit" CssClass="normaltext"></asp:Label>
                </div>
                <div class="ddlsetting">
                    <asp:DropDownList ID="ddlRollOverLimit" runat="server" Width="120px" Style="padding-top: -8px; height: 20px;" Enabled="false">
                    </asp:DropDownList>
                </div>
            </div>
            <div id="div3" runat="server" align="left">
                <div class="bglabel" style="width: 20%;">
                    <asp:Label ID="Label3" runat="server" Text="Roll Over Start" CssClass="normaltext"></asp:Label>
                </div>
                <div class="box">
                    <asp:TextBox ID="dtpRollOverDate" runat="server" Width="120px" Style="padding-top: -8px; height: 20px;" Enabled="false">
                       
                    </asp:TextBox>
                </div>
            </div>
            <div align="left">
                <div id="Div_Save" runat="server" class="box" style="padding-top: 10px;">
                    <asp:Button ID="btnSaveSpendlimit" runat="server" Text="Save" CssClass="button" OnClientClick="javascript:var a=btnSaveValidate();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;"
                        OnClick="btnSaveSpendlimit_Click" />
                    <div id="div_btnsaveprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


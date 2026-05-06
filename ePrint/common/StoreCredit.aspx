<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoreCredit.aspx.cs" MasterPageFile="~/Templates/popUpMasterPage.master"  Inherits="ePrint.common.StoreCredit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">

       
                          
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

        //function btnSaveValidate() {
        //    var txtAmount = document.getElementById("ctl00_ContentPlaceHolder1_txt_SpendAmount").value;
        //    if (txtAmount = "" || txtAmount.trim() == "") {
        //        document.getElementById("spnSpendAmount").style.display = "block";
        //        document.getElementById("ctl00_ContentPlaceHolder1_Div_Save").style.paddingLeft = "23%";
        //        return false;
        //    }
        
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
        
        

    </script>

    <div align="left" style="width: 100%;">
        <div align="left">
            <div id="div_CompanyType" runat="server" align="left">
                <div class="bglabel" style="width: 20%;">
                    <asp:Label ID="lblCredit" runat="server" Text="Store Credit" CssClass="normaltext"></asp:Label>
                </div>
                 <div class="box" style="padding-left: 5px;">
                    <asp:TextBox ID="txt_CreditAmount" onkeypress="return onlyNos(event,this);" onKeydown="Javascript: if(event.keyCode==13) return false;"
                        runat="server" Width="120px" class="textboxnew"></asp:TextBox>
                    <span id="spnSpendAmount" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;"
                        class="spanerrorMsg">
                        <%=objLanguage.GetLanguageConversion("Please_enter_amount")%>
                    </span>
                </div>
            </div>
            
            <div align="left">
                <div id="Div_Save" runat="server" class="box" style="padding-top: 10px;">
                    <asp:Button ID="btnSaveSpendlimit" runat="server" Text="Save" CssClass="button" OnClientClick="javascript:var a=if(a)loadingimage(this.id,'div_btnsaveprocess');return a;"
                      OnClick="btnSaveSpendlimit_Click"   />
                    <div id="div_btnsaveprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
            </div>
        </div>
    </div>
        <asp:Panel ID="pnlLoadContactPanel" runat="server" Visible="false">
        <script type="text/javascript" language="javascript">
            
            function LoadContactPanel() {
                var pw = window.parent;
                pw.SetTabs(Type, 'yes');
                GetRadWindow().close();
                return false;
            }
            LoadContactPanel();
        </script>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.Master" AutoEventWireup="true" CodeBehind="StripeSettings.aspx.cs" Inherits="ePrint.settings.StripeSettings" %>

<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100; width: 50%"
        align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Height="610" OnClientClose="RadWinClose"
            Behaviors="Close,Move,Reload,Resize">
        </telerik:RadWindowManager>
        <telerik:RadWindowManager ID="RadWindowManager3" runat="server">
            <Windows>
                <telerik:RadWindow ID="RadWindow1" runat="server" Opacity="100" Title="Product Image"
                    OnClientClose="bindUploadimgname" KeepInScreenBounds="true" VisibleTitlebar="true"
                    VisibleStatusbar="true" Modal="true" ShowContentDuringLoad="false" Behaviors="Close,Move,Reload,Resize,Maximize">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </div>





    <div align="left">
        <div align="left">
            <div id="content" style="padding-bottom: 10px;" class="estore_settingBox">
                <UC:Header_MIS ID="header_mis" runat="server" />
                <div id="Div_Msg" style="padding: 10px 0px 0px 10px; margin-bottom: -10px;">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="mis_header_panel">
                    <div align="left" style="width: 100%">
                        <div style="width: 34%">
                            <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div style="width: 99%;">
                        <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">Stripe Secret Key</span>
                            </div>
                            <div class="DefaultSettingsbox">
                                <asp:TextBox ID="StripeKey" type="Password" runat="server" placeholder="Enter Stripe Secret Key (e.g., sk_live_)" CssClass="txtbox" Width="97%"></asp:TextBox>
                                <div><span class="normaltext">Use your Live secret key when in production. Live keys start with sk_live_</span>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                    <div style="width: 99%;">
                        <div align="left">
                            <div class="bglabel" style="width: 200px;">
                                <span class="normaltext">Upload Stripe Image</span>
                            </div>
                            <div class="DefaultSettingsbox" style="margin-top: 4px;">
                                <a runat="server" id="StripeUploadimage" href="javascript:void(0);" onclick="javascript:openPopupCrop();">
                                    <%=objlang.GetLanguageConversion("Upload_Image") %></a>
                                 <div id="div_uploadedimagename" style="display: none">
                                        <a href="javascript:void(0);" id="lnkUpimagepath" runat="server"></a>
                                 </div>
                                <asp:Label ID="lblStripeImage" runat="server" Style="display: none" CssClass="Normaltext"></asp:Label>
                                <asp:HiddenField ID="hid_StripeImage" runat="server" Value="" />

                            </div>
                        </div>
                    </div>

                    
                </div>
                <div style="width: 10%;">
                        <div align="left">
                            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" CausesValidation="False" style="margin-left:10px;margin-top:5px;"
                                OnClientClick="javascript:var a=CheckValidation();if(a) loadingimage(this.id,'div_btnSave');return a;" OnClick="btnSave_Click"></asp:Button>
                            <div id="div_btnSave" style="display: none; float: left">
                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                            </div>
                        </div>
                    </div>
            </div>
            
        </div>
        


        <script type="text/javascript" language="javascript">
            var path = "<%=strSitepath %>";
            var lblStripeImage = document.getElementById("<%=lblStripeImage.ClientID %>");
            var hid_StripeImage = document.getElementById("<%=hid_StripeImage.ClientID%>");
            var StripeUploadimage = document.getElementById("<%=StripeUploadimage.ClientID%>");
            function CheckValidation() {
                return true;
            }
            function openPopupCrop() {
                var oWnd = $find("<%= RadWindow1.ClientID %>");
                oWnd.setUrl(path + "UploadAndCrop.aspx?from=stripe");
                oWnd.setSize(700, 490);
                oWnd.center();
                oWnd.show();
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
            function RemoveImage(type) {
                if (type == "image") {
                    lblStripeImage.innerHTML = "";
                    hid_StripeImage.value = "";
                    lblStripeImage.style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_StripeUploadimage").style.display = "block";
                    //  uplImage.style.display = "block";
                }
            }
            function bindUploadimgname() {
                debugger;
                RadWinClose();
                var imagenameCookie = readCookie("UploadedImageName");
                // Get all the cookies pairs in an array
                cookiearray = imagenameCookie.split('&');
                ckiename = cookiearray[0].split('=')[0];
                upimagename = cookiearray[0].split('=')[1];
                displyUpimageName(upimagename);
                //to delete the cookie
                clearCookie(imagenameCookie);
            }

            function clearCookie(name) {
                var date = new Date();
                date.setDate(date.getDate() - 1);
                document.cookie = name + "=''; expires=" + date + "; path=/";
            }
            function displyUpimageName(upimagename) {
                document.getElementById("div_uploadedimagename").style.display = "block";
                lblStripeImage.style.display = "block";
                document.getElementById('<%= StripeUploadimage.ClientID %>').style.display = "none";
                  document.getElementById('<%= lnkUpimagepath.ClientID %>').innerHTML = upimagename;

                  document.getElementById('<%= lnkUpimagepath.ClientID %>').target = "_blank";

                document.getElementById('<%= lnkUpimagepath.ClientID %>').href = '<%=strSitePath %>' + "DocManager.ashx?doctype=stripenew&filename=" + upimagename;
              }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

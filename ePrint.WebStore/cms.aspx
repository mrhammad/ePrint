<%@ page title="" language="C#" masterpagefile="~/Templates/masterPageDefault.master" autoeventwireup="true" CodeBehind="cms.aspx.cs" Inherits="ePrint.WebStore.cms" enableEventValidation="false" viewStateEncryptionMode="Never" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="csm_div">
        <asp:Label ID="lbl_cms" runat="server" CssClass="DisplayNone"></asp:Label>
        <div align="center" id="csm_background">
            <div align="center" id="csm_Content_div">
                <table class="width100p">
                    <tr>
                        <td class="widthAuto">
                            <div id="csm_left">
                                <asp:PlaceHolder ID="plhLeftBanner" runat="server"></asp:PlaceHolder>
                            </div>
                        </td>
                        <td class="width100p">
                            <div id="csm_center">
                                <div id="csm_heading" class="Header_Background">
                                    <strong class="floatLeft">
                                        <asp:Label ID="lbl_csm_heading" CssClass="lbl_csm_heading" runat="server" Text=""></asp:Label>
                                    </strong>
                                </div>
                                <div class="csm_content">
                                    <asp:PlaceHolder ID="ph_csm_content" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                        </td>
                        <td class="widthAuto">
                            <div id="csm_right">
                                <asp:PlaceHolder ID="plhRightBanner" runat="server"></asp:PlaceHolder>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

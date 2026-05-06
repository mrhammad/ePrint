<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cms.aspx.cs" Inherits="ePrint.MyPublicStore.cms" masterpagefile="~/Templates/MasterPageDefault.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .common-sprite
        {
            background-image: url('../images/common_sprite_v1.png');
            background-repeat: no-repeat;
        }
    </style>
    <div id="csm_div" class="contentArea_Background">
        <div class="navigation_div">
            <a href="<%=strSitePath %>Default.aspx">
                <asp:Label ID="lbl_home" runat="server"></asp:Label>
            </a>
            <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label>
            <asp:Label ID="lbl_cms" runat="server"></asp:Label>
        </div>
        <div id="csm_background">
            <div id="csm_Content_div">
                <div id="csm_left">
                    <asp:PlaceHolder ID="plhLeftBanner" runat="server"></asp:PlaceHolder>
                </div>
                <div id="csm_center">
                    <div id="csm_heading" class="Header_Background">
                        <strong>
                            <asp:Label ID="lbl_csm_heading" runat="server" Text=""></asp:Label>
                        </strong>
                    </div>
                    <div class="csm_content">
                        <asp:PlaceHolder ID="ph_csm_content" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
                <div id="csm_right">
                    <asp:PlaceHolder ID="plhRightBanner" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">

        var csm_left = document.getElementById("csm_left")
        var cnt_left = '<%=cnt_left %>';

        var csm_right = document.getElementById("csm_right")
        var cnt_right = '<%=cnt_right %>';

        var csm_center = document.getElementById("csm_center")

        if (cnt_left == 0) {

            csm_left.style.border = "none";
            csm_left.style.width = "0px";
            csm_center.style.width = "740px";
            csm_center.style.margin = "5px 2px 5px 0px";
        }

        if (cnt_right == 0) {
            csm_right.style.border = "none";
            csm_right.style.width = "0px";
            csm_center.style.width = "735px";
        }

        if (cnt_right == 0) {
            if (cnt_left == 0) {
                csm_center.style.width = "936px";
                csm_center.style.margin = "6px 2px 5px 0px";
            }
        }
        
    </script>
</asp:Content>



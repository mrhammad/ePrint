<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.Master" AutoEventWireup="true" CodeBehind="FTPRoute.aspx.cs" Inherits="ePrint.settings.FTPRoute" %>

<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <style>
        .setting-section {
            margin-bottom: 30px;
        }

            .setting-section h3 {
                margin: 0;
                font-size: 13px;
                color: #333;
            }

            .setting-section h4 {
                margin: 10px 0;
                font-size: 12px;
                color: #555;
            }

        .radio-options {
            gap: 25px;
            margin-top: 8px;
            align-items: center;
        }

            .radio-options label {
                margin-left: 5px;
                margin-right: 15px;
                color: #333;
            }

        .radio-group {
            display: flex;
            align-items: center;
            padding: 2px;
        }
        .radio-group label {
        display: inline-block;
        width: 160px; /* Fixed width to align dropdowns */
        margin-left: 8px;
    }

    .radio-group select {
        min-width: 180px;
    }
    .success-message {
            font-weight: bold;
            background-color: #d4edda;
            border: 1px solid #28a745;
            padding: 10px 15px;
            border-radius: 5px;
            color: #155724;
            display: block;
            margin-top: 10px;
            text-align: center;
            width:50%;
        }
    </style>
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
            <%--  <h3>Online Order</h3><br/>
            <h4>Route to FTP on:</h4><br/>
            <asp:RadioButton ID="rdoOrderCreation" runat="server"  />
            <label>Order Creation</label>
             <asp:RadioButton ID="rdoJobCreation" runat="server"  />
            <label>Job Creation</label>


              <h3>Product Estimate</h3><br/>
            <h4>Route to FTP on:</h4><br/>
            <asp:RadioButton ID="rdoProductEstimateCreation" runat="server"  />
            <label>Estimate Creation</label>
             <asp:RadioButton ID="rdoProductJobCreation" runat="server"  />
            <label>Job Creation</label>--%>
            <asp:Label ID="lblMessage" runat="server" CssClass="success-message" Visible="false" />
            <div class="setting-section">
                <h3>Online Order</h3>
                <h4>Route to FTP on:</h4>
                <div class="radio-options">
                    <div class="radio-group">
                        <asp:RadioButton ID="rdoOrderCreation" runat="server" GroupName="OnlineOrder" />
                        <label for="rdoOrderCreation">Order Creation</label>
                    </div>
                    <div class="radio-group">
                        <asp:RadioButton ID="rdoJobCreation" runat="server" GroupName="OnlineOrder" />
                        <label for="rdoJobCreation">Job Creation</label>
                    </div>
                    <div class="radio-group">
                        <asp:RadioButton ID="rdoInvoiceCreation" runat="server" GroupName="OnlineOrder" />
                        <label for="rdoInvoiceCreation">Invoice Creation</label>
                    </div>
                    <div class="radio-group">
                        <asp:RadioButton ID="rdoOrderStatus" runat="server" GroupName="OnlineOrder" />
                        <label for="rdoOrderStatus">Order Status</label>
                        <asp:DropDownList ID="ddlOrderStatus" runat="server" />
                    </div>
                    <div class="radio-group">
                        <asp:RadioButton ID="rdoJobStatus" runat="server" GroupName="OnlineOrder" />
                        <label for="rdoJobStatus">Job Status</label>
                        <asp:DropDownList ID="ddlJobStatus" runat="server" />
                    </div>
                    <div class="radio-group">
                        <asp:RadioButton ID="rdoInvoiceStatus" runat="server" GroupName="OnlineOrder" />
                        <label for="rdoInvoiceStatus">Invoice Status</label>
                        <asp:DropDownList ID="ddlInvoiceStatus" runat="server" />
                    </div>
                    <div class="radio-group">
                        <asp:RadioButton ID="rdoOrderNone" runat="server" GroupName="OnlineOrder" />
                        <label for="rdoOrderNone">None</label>
                    </div>
                </div>
            </div>

            <div class="setting-section">
                <h3>Product Estimate</h3>
                <h4>Route to FTP on:</h4>
                <div class="radio-options">
                    <div class="radio-group">
                        <asp:RadioButton ID="rdoProductEstimateCreation" runat="server" GroupName="ProductEstimate" />
                        <label for="rdoProductEstimateCreation">Estimate Creation</label>
                    </div>
                    <div class="radio-group">
                        <asp:RadioButton ID="rdoProductJobCreation" runat="server" GroupName="ProductEstimate" />
                        <label for="rdoProductJobCreation">Job Creation</label>
                    </div>

                    <div class="radio-group">
                        <asp:RadioButton ID="rdoProductInvoiceCreation" runat="server" GroupName="ProductEstimate" />
                        <label for="rdoProductInvoiceCreation">Invoice Creation</label>
                    </div>
                    <div class="radio-group">
                        <asp:RadioButton ID="rdoProductEstimateStatus" runat="server" GroupName="ProductEstimate" />
                        <label for="rdoProductEstimateStatus">Estimate Status</label>
                        <asp:DropDownList ID="ddlProductEstimateStatus" runat="server" />
                    </div>
                    <div class="radio-group">
                        <asp:RadioButton ID="rdoProductJobStatus" runat="server" GroupName="ProductEstimate" />
                        <label for="rdoProductJobStatus">Job Status</label>
                        <asp:DropDownList ID="ddlProductJobStatus" runat="server" />

                    </div>
                    <div class="radio-group">
                        <asp:RadioButton ID="rdoProductInvoiceStatus" runat="server" GroupName="ProductEstimate" />
                        <label for="rdoProductInvoiceStatus">Invoice Status</label>
                        <asp:DropDownList ID="ddlProductInvoiceStatus" runat="server" />

                    </div>
                    <div class="radio-group">
                        <asp:RadioButton ID="rdoProductNone" runat="server" GroupName="ProductEstimate" />
                        <label for="rdoProductNone">None</label>
                    </div>
                </div>
                <br />
                <div id="div_btnsave" style="display: block; margin-top: -1px;">
                    <asp:Button ID="btnSave" CssClass="button" Text="Update" Width="65px" runat="server"
                        OnClick="btnUpdate_Click" OnClientClick="if(CheckValidation()){javascript:loadingimage(this.id,'div_btnsaveprocess');}else{return false;}" />
                </div>
                <div id="div_btnsaveprocess" class="button" align="center" style="height: 14px; width: 33px; display: none">
                     <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                </div>

            </div>
            <div style="clear: both;">
            </div>
        </div>
         <script type="text/javascript">
        function CheckValidation() {
            return true;
        }
         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

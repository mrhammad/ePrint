<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.Master" AutoEventWireup="true" CodeBehind="FTPFolder.aspx.cs" Inherits="ePrint.settings.FTPFolder" %>

<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    .ftp-form-group {
        margin-bottom: 15px;
    }

        .ftp-form-group label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }

        .ftp-form-group input[type="text"],
        .ftp-form-group input[type="password"] {
            width: 50%;
            padding: 8px 12px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .ftp-form-group select {
            width: 51.7%;
            padding: 8px 12px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

    .ftp-buttons {
        margin-top: 20px;
    }

    .ftp-folder-list {
        width: 50%;
        max-height: 200px;
        overflow-y: auto;
        background-color: #fff;
        padding: 10px;
        border: 1px solid #ccc;
        border-radius: 5px;
        margin-top: 10px;
    }

    .ftp-success {
        color: green;
    }

    .ftp-error {
        color: red;
    }

    .ftp-checkbox {
        margin-top: 10px;
    }

    .ftp-button {
        padding: 5px 20px;
        border: none;
        background-color: black;
        color: white;
        border-radius: 5px;
        cursor: pointer;
        margin-right: 10px;
    }

        .ftp-button:hover {
            background-color: #004c99;
        }

    .folder-checkbox-list input[type="checkbox"] {
        margin-right: 6px;
    }

    .folder-checkbox-list input[type="checkbox"],
    .folder-checkbox-list label {
        vertical-align: middle;
    }

    .folder-checkbox-list label {
        margin-right: 20px; /* space between items */
        display: inline-block;
    }

    .folder-checkbox-list {
        user-select: none; /* Standard */
        -webkit-user-select: none; /* Chrome/Safari */
        -moz-user-select: none; /* Firefox */
        -ms-user-select: none; /* IE/Edge */
    }

    #loadingSpinner {
        margin-top: 10px;
        font-size: 14px;
        padding: 10px;
        background-color: #eaf5ea;
        border: 1px solid #c3e6cb;
        border-radius: 5px;
        width: 50%;
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
        width: 50%;
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
        <div style="width: 100%; margin-top: -18px"
            class="mis_header_panel">
            <div id="">
                <div id="loadingSpinner" style="display: none; color: green; font-weight: bold;">
                    Connecting to FTP server... Please wait.
                </div>
                <asp:Label ID="lblMessage1" runat="server" CssClass="success-message" Visible="false" />
                <asp:Panel ID="pnlFTPSettings" runat="server">
                    <label style="font-size: medium; font-weight: bold;">
                        FTP Settings</label><br />
                    <label>Configure FTP connection to make folders available within HexiHub</label>
                    <br />
                    <br />
                    <br />
                    <div class="ftp-form-group">
                        <label for="txtFtpAddress">FTP Address</label>
                        <asp:TextBox ID="txtFtpAddress" runat="server" CssClass="form-control" />
                    </div>

                    <div class="ftp-form-group">
                        <label for="txtFtpUsername">Username</label>
                        <asp:TextBox ID="txtFtpUsername" runat="server" autocomplete="off" Placeholder="username" CssClass="form-control" />
                    </div>

                    <div class="ftp-form-group">
                        <label for="txtFtpPassword">Password</label>
                        <asp:TextBox ID="txtFtpPassword" runat="server" autocomplete="off" Placeholder="********" TextMode="Password" CssClass="form-control" />
                        <asp:HiddenField ID="hdnPassword" runat="server" />
                    </div>
                    <div class="ftp-form-group">
                        <label for="txtFtpPort">Port</label>
                        <asp:TextBox ID="txtFtpPort" runat="server" autocomplete="off" CssClass="form-control" />
                    </div>
                    <div class="ftp-form-group">
                        <label for="txtFtpRootFolder">Root Folder Name</label>
                        <asp:TextBox ID="txtFtpRootFolder" runat="server" autocomplete="off" CssClass="form-control" />
                    </div>
                    <div class="ftp-form-group">
                        <label for="ddlProtocol">Protocol</label>
                        <asp:DropDownList ID="ddlProtocol" runat="server" CssClass="form-control">
                            <asp:ListItem Text="-- Select Protocol --" Value="" />
                            <asp:ListItem Text="SFTP" Value="SFTP" />
                            <asp:ListItem Text="FTPS" Value="FTPS" />
                        </asp:DropDownList>
                    </div>

                    <div class="ftp-buttons">
                        <asp:Button ID="btnRefreshFolders" runat="server" Text="🔄 Refresh Folders"
                            OnClientClick="return showLoading('<%= btnRefreshFolders.UniqueID %>');" CssClass="button" OnClick="btnRefreshFolders_Click" />
                    </div>

                    <asp:Label ID="lblMessage" runat="server" CssClass="ftp-error" Visible="false" />
                    <br />
                    <div class="ftp-form-group">
                        <label>
                            Available FTP Folders<span style="margin-left: 398px; font-weight: normal;">Select folders to make available in HexiHub </span>
                        </label>
                        <div class="ftp-folder-list">
                            <%--            <asp:CheckBoxList ID="chkFolderList" runat="server" />--%>
                            <%--<asp:CheckBoxList ID="chkFolderList" runat="server"
                                RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="folder-checkbox-list" />--%>
                            <asp:Repeater ID="rptFolderList" runat="server">
                                <ItemTemplate>
                                    <div style="display: flex; align-items: center; margin-bottom: 6px;">
                                        <asp:CheckBox ID="chkFolder" runat="server" Text='<%# Eval("Name") %>'
                                            Checked='<%# Eval("IsSelected") %>' CssClass="folder-checkbox-list" />
                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

                    <div class="ftp-buttons">
                        <asp:Button ID="btnSaveFtpSettings" runat="server" Text="💾 Save" CssClass="button"
                            OnClientClick="javascript:var a=CheckValidation();if(a) loadingimage(this.id,'div_btnSave');return a;"
                            OnClick="btnSaveFtpSettings_Click" />
                        <div id="div_btnSave" style="display: none; float: left">
                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                        </div>
                    </div>
                    <%--<div class="ftp-checkbox">
        <asp:CheckBox ID="chkEnableHexihub" runat="server" Text="Enable FTP folders in Hexihub" />
    </div>--%>
                </asp:Panel>
            </div>

        </div>
        <div style="clear: both;">
        </div>
    </div>
    <script type="text/javascript">
        function showLoading(buttonUniqueId) {
            debugger;
            document.getElementById('loadingSpinner').style.display = 'block';
        }
        function CheckValidation() {
            return true;
        }
        function hideSuccessMessage() {
            setTimeout(function () {
                var msg = document.getElementById('<%= lblMessage1.ClientID %>');
                if (msg) {
                    msg.style.display = 'none';
                }
            }, 3500); // 3.5 seconds
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

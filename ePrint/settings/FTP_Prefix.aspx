<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.Master" AutoEventWireup="true" CodeBehind="FTP_Prefix.aspx.cs" Inherits="ePrint.settings.FTP_Prefix" %>

<%--<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>--%>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .page-filename-settings .table-container {
            margin: 20px;
            font-family: Arial;
            font-size: 14px;
            position: relative;
        }

        .page-filename-settings table {
            width: 100%;
            border: 1px solid lightgrey;
            border-collapse: collapse;
        }

        .page-filename-settings th {
            text-align: left;
            padding: 10px;
            background-color: #f5f5f5;
            border-bottom: 1px solid #ccc;
        }

        .page-filename-settings td {
            padding: 10px;
            vertical-align: top;
            border: 1px solid lightgrey;
        }

        .page-filename-settings .option-group {
            margin-top: 10px;
        }

         .page-filename-settings .option-group input {
                margin-right: 5px;
            }

        .page-filename-settings .option-description {
            margin-left: 20px;
        }

        .page-filename-settings .section-title {
            font-weight: bold;
            margin: 10px 0;
            font-size: 13px;
            color: #004488;
        }

        .page-filename-settings .save-button-container {
            margin-top: 20px;
        }

        .page-filename-settings .save-button {
            padding: 5px 20px;
            border: none;
            background-color: black;
            color: white;
            border-radius: 5px;
            cursor: pointer;
            margin-right: 10px;
        }

           .page-filename-settings .save-button:hover {
/*                background-color: #005fa3;
*/
                background-color: #004c99;
           }
           .page-filename-settings input[type="radio"] {
              vertical-align: middle;
              position: relative;
              bottom: 3px; 
            }
    </style>


    <div class="estore_settingBox" style="min-height: 400px; width: 99%;">
<%--        <UC:Header_MIS ID="header_mis" runat="server" />--%>
        <div id="Div_Msg" style="padding: 10px 0px 0px 10px; margin-bottom: -10px;">
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="width: 100%; margin-top: -18px;width:75%;" class="mis_header_panel">
            <div class="page-filename-settings">
                <div class="table-container">
                    <div class="section-title">Filename Handling Mode</div>
                    <table>
                        <tr>
                            <th style="width: 200px;">Setting</th>
                            <th>Option &amp; Description</th>
                        </tr>
                        <tr>
                            <td style="font-weight:bold;">File Naming Convention</td>
                            <td>
                                <div class="option-group">
                                    <asp:RadioButton ID="rbNone" runat="server" GroupName="Naming" Text="None" style="font-weight:bold;vertical-align: middle;" Checked="true" />
                                    <div class="option-description">
                                        No changes applied to the uploaded file’s name. The original filename will be used. This is the default behavior.
                                    </div>
                                </div>
                                <div class="option-group">
                                    <asp:RadioButton ID="rbPrefix" runat="server" GroupName="Naming" style="font-weight:bold;" Text="Prefix" />
                                    <div class="option-description">
                                        Select this to add text to the beginning of the uploaded file’s name. This enables a text input field in the "FTP product tab" where the desired prefix can be entered.<br />
                                        <em>Example: If prefix is "ProjectX.", "filename.pdf" becomes "ProjectX.filename.pdf".</em>
                                    </div>
                                </div>
                                <div class="option-group">
                                    <asp:RadioButton ID="rbOverwrite" runat="server" GroupName="Naming" style="font-weight:bold;" Text="Overwrite" />
                                    <div class="option-description">
                                        Select this to completely replace the uploaded file’s name with custom text. This enables a text input field in the "FTP product tab" where the new filename can be entered.<br />
                                        <em>Example: If new name is "ReportFinal.docx", any uploaded file will be renamed to "ReportFinal.docx".</em>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>

                    <div class="save-button-container">
                        <asp:Button ID="btnSave" runat="server" Text="💾 Save" CssClass="save-button"
                            OnClientClick="javascript:var a=CheckValidation();if(a) loadingimage(this.id,'div_btnSave');return a;"
                            OnClick="btnSave_Click" />
                      <div id="div_btnSave" style="display: none; float: left">
                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                        </div>
                    </div>
                </div>

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

<%@ page language="C#" autoeventwireup="true" CodeBehind="artwork_common.aspx.cs" Inherits="ePrint.WebStore.common.artwork_common" enableEventValidation="false" viewStateEncryptionMode="Never" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%#StyleSheetPathMaster +"/Themes/StyleSheet_B2B.css"%>" id="Link1" rel="Stylesheet"
        type="text/css" />
    <link href="<%#StyleSheetPath +"/Themes/StyleSheet_B2B.css"%>" id="MainStyle2" rel="Stylesheet"
        type="text/css" />
    <style type="text/css">
        html
        {
            /*added to prevent scroll bars in radwindow*/
            overflow: hidden;
        }
    </style>
    <style type="text/css">
        body
        {
            background-color: #FFFFFF;
            min-width: 100%;
        }
        .RadGrid .rgMasterTable
        {
            border-collapse: collapse !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
    </asp:ScriptManager>
    <div>
        <telerik:RadGrid ID="grdFilesUploaded" GridLines="none" runat="server" AllowSorting="true"
            ShowGroupPanel="True" EnableEmbeddedSkins="true" EnableTheming="false" GroupingEnabled="False"
            AutoGenerateColumns="False" Width="100%" GroupingSettings-CaseSensitive="false"
            HeaderStyle-BorderWidth="0" ItemStyle-BorderWidth="0" HeaderStyle-Font-Bold="true"
            AllowPaging="true" HeaderStyle-BackColor="White" CellPadding="0" CellSpacing="0"
            BorderStyle="None" ShowFooter="false" AlternatingItemStyle-BackColor="White"
            HeaderStyle-ForeColor="#525252" Skin="Default" HeaderStyle-BorderColor="#000000"
            HeaderStyle-Font-Size="13px" HeaderStyle-Height="20px" HeaderStyle-BorderStyle="Double"
            OnItemDataBound="grdFilesUploaded_ItemDataBound" CssClass="AddBorders">
            <AlternatingItemStyle BackColor="White" />
            <MasterTableView CssClass="MasterTableView">
                <Columns>
                    <telerik:GridTemplateColumn HeaderText="File Name" HeaderStyle-HorizontalAlign="Left"
                        HeaderStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Middle"
                        ItemStyle-Width="1%" HeaderStyle-Width="1%" ItemStyle-Height="20px" DataField="FileName"
                        UniqueName="FileName">
                        <ItemTemplate>
                            <div>
                                <asp:LinkButton ID="lbl_FileName" runat="server" Style="display: none;" Text='<%#Eval("OriginalFileName")%>'></asp:LinkButton>
                                <a id="ancFileName" href="#" name='<%#Eval("OriginalFileName")%>' onclick='javascript:OpenAttach(&#039;<%#Eval("UploadFile")%>&#039,&#039;<%#Eval("IsFromStoreAttach")%>&#039;);'
                                    title='<%#Eval("OriginalFileName")%>'>
                                    <%#Eval("OriginalFileName")%></a></div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <%-- <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        HeaderStyle-VerticalAlign="Middle" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="1%"
                        HeaderStyle-Width="1%" ItemStyle-Height="20px" DataField="UserName" HeaderText="Uploaded By"
                        SortExpression="UserName" UniqueName="UserName">
                        <ItemTemplate>
                            <div>
                                <asp:Label ID="lbl_UplBy" Text='<%#Eval("CreatedBy")%>' runat="server"></asp:Label></div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>--%>
                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                        HeaderStyle-VerticalAlign="Middle" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="1%"
                        HeaderStyle-Width="1%" ItemStyle-Height="20px" DataField="CreatedDate" HeaderText="Uploaded On"
                        UniqueName="CreatedDate">
                        <ItemTemplate>
                            <div>
                                <asp:Label ID="lbl_UpldOn" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CreatedON", "{0}") %>'></asp:Label></div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
    <script type="text/javascript">
        var AccountID = '<%=AccountID %>';
        var CompanyID = '<%=CompanyID %>';
        function OpenAttach(Imagename, fromattachment) {
            
            var OpenNewInmage = '<%=strSitepath %>' + "ImageHandler.ashx?ImageName=" + Imagename + "&type=a&aid=" + AccountID + "&cid=" + CompanyID + "&fromattachment=" + fromattachment;
            window.open(OpenNewInmage);
        }
   
    </script>
    </form>
</body>
</html>

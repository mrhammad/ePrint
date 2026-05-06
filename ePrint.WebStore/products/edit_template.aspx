<%@ page title="" language="C#" masterpagefile="~/templates/MasterPageDefault.master" autoeventwireup="true" CodeBehind="edit_template.aspx.cs" Inherits="ePrint.WebStore.edit_template" enableEventValidation="false" viewStateEncryptionMode="Never" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="width100p">
        <div class="editable_Template_frame_OuterDiv">
            <div class="editable_Template_frame_div">
                <iframe id="Iframe1" runat="server" frameborder="1" marginwidth="1" class="editable_Template_frame">
                </iframe>
            </div>
        </div>
    </div>
    <a name="EditTemplate"></a>
</asp:Content>

<%--style="width: 97%; height: 100%;" class="EditProduct"--%>

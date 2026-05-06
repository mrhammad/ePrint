<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Templates/popUpMasterPage_new.master" CodeBehind="CartAdditionalOption.aspx.cs" Inherits="ePrint.common.CartAdditionalOption" enableviewstatemac="false" enableEventValidation="false" %>

<%@ Register TagName="CartAdditionalOptions" TagPrefix="UC" Src="~/usercontrol/Item/CartAdditionalOptions.ascx" %>
<%@ Register Src="~/usercontrol/CallClass.ascx" TagName="callClass" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <UC:callClass ID="CallClass" runat="server" />
    </div>
    <div>
        <UC:CartAdditionalOptions ID="CartAdditionalOptions" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

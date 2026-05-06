
<%@ page title="" language="C#" masterpagefile="~/Templates/UserEditProfile.master" autoeventwireup="true" CodeBehind="UserEditProfile.aspx.cs" Inherits="ePrint.settings.UserEditProfile" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div align="left" id="pnldetails">
        <div align="left">
          
            <div style="height: 290px">
                <div>
                    <span>
                        <%=objLanguage.GetLanguageConversion("Please_Choose_The_Options_From_The_Left_Hand_Panel_To_Proceed")%></span>
                </div>
                <div style="clear: both;">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
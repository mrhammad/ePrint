<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ePrint.Printcenter.Views.SignUp" Theme="Theme1" EnableViewStateMac="false" EnableEventValidation="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%#strCompany%></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <style type="text/css">
        :root {
            --primary-color: #2563eb;
            --bg-color: #f3f4f6;
            --text-dark: #1f2937;
            --text-light: #6b7280;
            --error-red: #ef4444;
            --success-green: #059669;
        }
        body {
            margin: 0;
            padding: 1rem 0;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: var(--bg-color);
            display: flex;
            align-items: center;
            justify-content: center;
            min-height: 100vh;
        }
        .login-container {
            background: #ffffff;
            width: 100%;
            max-width: 460px;
            padding: 2.5rem;
            border-radius: 12px;
            box-shadow: 0 10px 25px rgba(0, 0, 0, 0.05);
            text-align: center;
        }
        .login-title {
            font-size: 1.5rem;
            font-weight: 600;
            color: var(--text-dark);
            margin-bottom: 0.25rem;
        }
        .login-subtitle {
            font-size: 0.875rem;
            color: var(--text-light);
            margin-bottom: 1.5rem;
        }
        .input-group {
            text-align: left;
            margin-bottom: 1rem;
        }
        .input-group label {
            display: block;
            font-size: 0.875rem;
            font-weight: 500;
            margin-bottom: 0.5rem;
            color: var(--text-dark);
        }
        .LoginText {
            width: 100%;
            padding: 12px 16px;
            border: 1px solid #d1d5db;
            border-radius: 6px;
            font-size: 1rem;
            box-sizing: border-box;
        }
        .LoginText:focus {
            outline: none;
            border-color: var(--primary-color);
            box-shadow: 0 0 0 3px rgba(37, 99, 235, 0.1);
        }
        .validation-msg, .field-error {
            font-size: 11px;
            color: var(--error-red);
            margin-top: 4px;
            display: block;
        }
        #div_InvalidMsg {
            background-color: #fee2e2;
            border: 1px solid #fecaca;
            padding: 10px;
            border-radius: 6px;
            margin-bottom: 1rem;
            color: var(--error-red);
            font-size: 0.875rem;
            text-align: left;
        }
        #div_SuccessMsg {
            background-color: #d1fae5;
            border: 1px solid #a7f3d0;
            padding: 10px;
            border-radius: 6px;
            margin-bottom: 1rem;
            color: var(--success-green);
            font-size: 0.875rem;
            text-align: left;
        }
        .Loginbuttoscss {
            background: linear-gradient(135deg, #ff8c00 0%, #ee0979 100%) !important;
            color: white !important;
            border: none;
            padding: 12px 24px;
            border-radius: 6px;
            font-weight: 600;
            cursor: pointer;
            width: 100% !important;
            height: 45px;
            box-sizing: border-box;
        }
        .auth-footer {
            margin-top: 1.25rem;
            font-size: 0.875rem;
            color: var(--text-light);
        }
        .auth-footer a {
            color: var(--primary-color);
            text-decoration: none;
            font-weight: 500;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <asp:PlaceHolder ID="plhFooter" runat="server" Visible="false"></asp:PlaceHolder>
            <div class="brand-header">
                <asp:PlaceHolder ID="plhLoginImg" runat="server"></asp:PlaceHolder>
                <div class="login-title">Create your account</div>
                <div class="login-subtitle">Register a new company on this system</div>
            </div>

            <div id="div_SuccessMsg" runat="server" visible="false">
                <asp:Label ID="lblSuccess" runat="server"></asp:Label>
            </div>

            <div id="div_InvalidMsg" runat="server" style="display: none;">
                <asp:Label ID="lblerror" runat="server" Visible="false"></asp:Label>
            </div>

            <asp:Panel ID="pnlSignUpForm" runat="server">
                <div class="input-group">
                    <asp:Label ID="lblCompanyName" runat="server" Text="Company name" AssociatedControlID="txtCompanyName"></asp:Label>
                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="LoginText" MaxLength="250"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ControlToValidate="txtCompanyName"
                        Display="Dynamic" ErrorMessage="Enter company name" CssClass="validation-msg"></asp:RequiredFieldValidator>
                </div>

                <div class="input-group">
                    <asp:Label ID="lblFirstName" runat="server" Text="First name" AssociatedControlID="txtFirstName"></asp:Label>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="LoginText" MaxLength="200"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                        Display="Dynamic" ErrorMessage="Required" CssClass="validation-msg"></asp:RequiredFieldValidator>
                </div>

                <div class="input-group">
                    <asp:Label ID="lblLastName" runat="server" Text="Last name" AssociatedControlID="txtLastName"></asp:Label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="LoginText" MaxLength="200"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                        Display="Dynamic" ErrorMessage="Required" CssClass="validation-msg"></asp:RequiredFieldValidator>
                </div>

                <div class="input-group">
                    <asp:Label ID="lblEmail" runat="server" Text="Email" AssociatedControlID="txtEmail"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="LoginText" MaxLength="300" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="Enter email" CssClass="validation-msg"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="Invalid email" CssClass="validation-msg"
                        ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
                </div>

                <div class="input-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Password" AssociatedControlID="txtPassword"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="LoginText" TextMode="Password" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="Enter password" CssClass="validation-msg"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="At least 6 characters" CssClass="validation-msg"
                        ValidationExpression=".{6,}"></asp:RegularExpressionValidator>
                </div>

                <div class="input-group">
                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm password" AssociatedControlID="txtConfirmPassword"></asp:Label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="LoginText" TextMode="Password" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                        Display="Dynamic" ErrorMessage="Confirm password" CssClass="validation-msg"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvPassword" runat="server" ControlToValidate="txtConfirmPassword"
                        ControlToCompare="txtPassword" Operator="Equal" Display="Dynamic"
                        ErrorMessage="Passwords do not match" CssClass="validation-msg"></asp:CompareValidator>
                </div>

                <div style="margin-top: 1.25rem;">
                    <asp:Button ID="btnSignUp" runat="server" Text="Sign up" CssClass="Loginbuttoscss"
                        OnClick="btnSignUp_Click" OnClientClick="if(Page_ClientValidate()) { return true; } return false;" />
                </div>
            </asp:Panel>

            <div class="auth-footer">
                Already have an account? <a href="~/Login/Login.aspx">Sign in</a>
            </div>
        </div>
    </form>
</body>
</html>

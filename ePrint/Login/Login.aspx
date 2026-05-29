<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ePrint.Printcenter.Views.Login" EnableViewStateMac="false" EnableEventValidation="false" StyleSheetTheme="" Theme="" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%= strCompany %></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <style type="text/css">
        :root {
            --primary-color: #2563eb;
            --bg-color: #f3f4f6;
            --text-dark: #1f2937;
            --text-light: #6b7280;
            --error-red: #ef4444;
        }

        body {
            margin: 0;
            padding: 0;
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
            max-width: 420px;
            padding: 2.5rem;
            border-radius: 12px;
            box-shadow: 0 10px 25px rgba(0, 0, 0, 0.05);
            text-align: center;
        }

        .brand-header {
            margin-bottom: 2rem;
        }

        .brand-header img {
            max-width: 180px;
            margin-bottom: 1rem;
        }

        .login-title {
            font-size: 1.5rem;
            font-weight: 600;
            color: var(--text-dark);
            margin-bottom: 0.5rem;
        }

        .input-group {
            text-align: left;
            margin-bottom: 1.25rem;
            position: relative;
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
            transition: border-color 0.2s;
        }

        .LoginText:focus {
            outline: none;
            border-color: var(--primary-color);
            box-shadow: 0 0 0 3px rgba(37, 99, 235, 0.1);
        }

        .validation-msg {
            font-size: 11px;
            color: var(--error-red);
            margin-top: 4px;
            display: block;
        }

        .login-actions {
            display: flex;
            align-items: center;
            justify-content: space-between;
            margin-top: 1.5rem;
        }

.Loginbuttoscss {
            /* Sunrise Radiant Gradient */
            background: linear-gradient(135deg, #ff8c00 0%, #ee0979 100%) !important;
            
            color: white !important;
            border: none;
            padding: 12px 24px;
            border-radius: 6px;
            font-weight: 600;
            cursor: pointer;
            width: 100% !important;
            height: 45px;
            
            /* Warm shadow to match the sunrise */
            box-shadow: 0 4px 15px rgba(238, 9, 121, 0.2);
            
            display: flex;
            align-items: center;
            justify-content: center;
            transition: all 0.3s ease;
            box-sizing: border-box;
        }

        .Loginbuttoscss:hover {
            /* Brightens like the sun coming up */
            filter: brightness(1.1);
            box-shadow: 0 8px 20px rgba(238, 9, 121, 0.3);
            transform: translateY(-1px);
        }

        .Loginbuttoscss:active {
            transform: translateY(0px);
            filter: brightness(0.95);
        }

        .remember-me {
            display: flex;
            align-items: center;
            font-size: 0.875rem;
            color: var(--text-light);
            cursor: pointer;
        }

        .remember-me input {
            margin-right: 8px;
        }

        #div_InvalidMsg {
            background-color: #fee2e2;
            border: 1px solid #fecaca;
            padding: 10px;
            border-radius: 6px;
            margin-bottom: 1.5rem;
            color: var(--error-red);
            font-size: 0.875rem;
        }

        /* Modal / System Upgrade styling */
        #loginmodal {
            background: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 20px 40px rgba(0,0,0,0.2);
        }


        /* Force the button container to stay full width */
        #div_btnlogin {
            width: 100%;
            display: block;
            text-align: center; /* Centers the content inside */
        }

        /* Ensure the button doesn't shrink when text changes to an image */
        .Loginbuttoscss {
            width: 100% !important;
            min-width: 100%; 
            display: flex;
            align-items: center;
            justify-content: center;
            height: 45px; /* Set a fixed height so it doesn't 'jump' vertically */
            box-sizing: border-box;
        }

        /* If the script puts the image inside the button, center it */
        .Loginbuttoscss img {
            margin: 0 auto;
            display: block;
            vertical-align: middle;
        }

    </style>
    
    <script src="/js/commonloading.js?VN=<%= VersionNumber %>" type="text/javascript"></script>
    <script src="/js/default.js?VN=<%= VersionNumber %>" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            
            <div style="display:none;">
            <%-- This literal is used for dynamic updates from the server --%>
            <asp:Literal runat="server" ID="ltrLoginPageUpdates"></asp:Literal>
    
            <%-- This label is used for the 'Remember Me' note logic --%>
            <asp:Label ID="lblRemembermeNote" runat="server"></asp:Label>
            </div>

            <div class="brand-header">
                <asp:PlaceHolder ID="plhLoginImg" runat="server"></asp:PlaceHolder>
                <div class="login-title"><%#objLanguage.GetLanguageConversion("Login")%></div>
            </div>

            <div id="div_InvalidMsg" runat="server" style="display: none;">
                <asp:Image ID="ImgError" runat="server" ImageUrl="~/Images/error.gif" style="vertical-align:middle; margin-right:5px;"/>
                <asp:Label ID="lblerror" runat="server" Visible="false" Text="Invalid login details"></asp:Label>
            </div>

            <div class="input-group">
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                <input type="text" id="email" runat="server" name="useremail" class="LoginText" placeholder="you@example.com" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="email" 
                    Display="Dynamic" ErrorMessage="Enter Email" CssClass="validation-msg"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email"
                    Display="Dynamic" ErrorMessage="Invalid Email" CssClass="validation-msg"
                    ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
            </div>

            <div class="input-group">
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                <asp:TextBox runat="server" ID="password" CssClass="LoginText" TextMode="Password" placeholder="••••••••"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password"
                    Display="Dynamic" ErrorMessage="Enter Password" CssClass="validation-msg"></asp:RequiredFieldValidator>
            </div>

            <div style="margin-bottom: 1.5rem; display: flex; align-items: center;">
                 <label class="remember-me">
                    <input type="checkbox" id="chkremember" runat="server" /> 
                    <asp:Label ID="lblRememberMe" runat="server" Text="Remember Me"></asp:Label>
                </label>
            </div>

<%--            <div id="div_btnlogin">
                <asp:Button ID="btnlogin" runat="server" Text="Login" OnClientClick="if(Page_ClientValidate()) {loadingimagelogin('btnlogin','div_process');} else {return false;}"
                    OnClick="btnLogIN_Click" CssClass="Loginbuttoscss" />
            </div>

            <div id="div_process" style="display: none; margin-top: 10px;">
                <img src="Images/radimg1.gif" alt="loading" />
            </div>--%>

            <div id="div_btnlogin" style="width: 100%; height: 45px;">
                <asp:Button ID="btnlogin" runat="server" Text="Login" 
                    OnClientClick="if(Page_ClientValidate()) { this.style.display='none'; document.getElementById('div_process').style.display='block'; } else {return false;}"
                    OnClick="btnLogIN_Click" CssClass="Loginbuttoscss" />
    
                <div id="div_process" style="display: none; width: 100%; text-align: center;">
                    <%-- We use the same class so the "box" stays the same size/color --%>
                    <div class="Loginbuttoscss" style="background: linear-gradient(135deg, #2563eb 0%, #1d4ed8 100%); opacity: 0.9;">
                        <asp:Image ID="imgLoader" runat="server" ImageUrl="~/Images/radimg1.gif" AlternateText="loading" style="height: 20px; width: auto; display: inline-block;" />
                    </div>
                </div>
            </div>

            <div class="auth-footer" style="margin-top: 1.25rem; font-size: 0.875rem; color: #6b7280;">
                Don't have an account? <a href="~/Login/SignUp.aspx" runat="server" id="lnkSignUp" style="color: #2563eb; font-weight: 500; text-decoration: none;">Sign up</a>
            </div>

            <div id="div_RegisteredMsg" runat="server" visible="false" style="margin-top: 1rem; background-color: #d1fae5; border: 1px solid #a7f3d0; padding: 10px; border-radius: 6px; color: #059669; font-size: 0.875rem; text-align: left;">
                <asp:Label ID="lblRegistered" runat="server"></asp:Label>
            </div>

            <asp:PlaceHolder ID="plhFooter" Visible="false" runat="server"></asp:PlaceHolder>
        </div>

        <div id="loginmodal" style="display:none; max-width: 700px; margin: 20px;">
             <h3>System Upgrade Notification</h3>
             <p>Your ePrint MIS system has been upgraded to version 3.5.</p>
             <a href="#" class="close">Close</a>
        </div>

        <script src="js/jquery(1.7.1).min.js" type="text/javascript"></script>
        <script src="js/jquery.reveal.js" type="text/javascript"></script>
        <script type="text/javascript">
            // Your existing cookie/modal logic
            remember();
        </script>

        <div style="display:none;">
            <asp:HiddenField ID="hdnpassword" runat="server" Value="" />
            <asp:HiddenField ID="hdn_login" runat="server" />
            <asp:HiddenField ID="hdn_pass" runat="server" />
        </div>

    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ePrint._Default" Theme="Theme1" EnableViewStateMac="false" EnableEventValidation="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%=strCompany%></title>
    
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;600&display=swap" rel="stylesheet" />
    
    <style type="text/css">
        :root {
            --primary-color: #2563eb;
            --error-red: #dc2626;
            --text-main: #1f2937;
            --bg-gray: #f3f4f6;
        }

        body {
            margin: 0;
            padding: 0;
            font-family: 'Inter', sans-serif;
            background-color: var(--bg-gray);
            display: flex;
            align-items: center;
            justify-content: center;
            min-height: 100vh;
        }

        .login-card {
            background: #ffffff;
            padding: 2.5rem;
            border-radius: 12px;
            box-shadow: 0 10px 25px rgba(0,0,0,0.1);
            width: 100%;
            max-width: 400px;
            box-sizing: border-box;
        }

        .logo-section {
            text-align: center;
            margin-bottom: 2rem;
        }

        .login-title {
            font-size: 1.5rem;
            font-weight: 600;
            color: var(--text-main);
            text-align: center;
            margin-bottom: 1.5rem;
        }

        .form-group {
            margin-bottom: 1.25rem;
        }

        .form-group label {
            display: block;
            font-size: 0.875rem;
            font-weight: 500;
            margin-bottom: 0.5rem;
            color: #4b5563;
        }

        .LoginText, input[type="text"], input[type="password"] {
            width: 100% !important; /* Forces it to stay 100% of the parent container */
            max-width: 100% !important;
            padding: 0.75rem !important;
            border: 1px solid #d1d5db;
            border-radius: 6px;
            font-size: 1rem;
            box-sizing: border-box !important; /* Critical: includes padding in the width calculation */
            transition: border-color 0.2s;
            display: block;
        }

        /* This prevents the "jumping" when the browser tries to highlight the field */
        .LoginText:focus, input[type="text"]:focus {
            outline: none;
            border-color: #2563eb;
            width: 100% !important;
        }


        .Loginbuttoscss {
            width: 100%;
            padding: 0.75rem;
            background-color: var(--primary-color);
            color: white;
            border: none;
            border-radius: 6px;
            font-size: 1rem;
            font-weight: 600;
            cursor: pointer;
            transition: background 0.2s;
        }

        .Loginbuttoscss:hover {
            background-color: #1d4ed8;
        }

        .remember-me-container {
            display: flex;
            align-items: center;
            margin-top: 1rem;
            font-size: 0.875rem;
        }

        .error-message {
            background: #fee2e2;
            color: var(--error-red);
            padding: 0.75rem;
            border-radius: 6px;
            margin-bottom: 1rem;
            font-size: 0.875rem;
            display: flex;
            align-items: center;
        }

        .Redver7 {
            color: var(--error-red);
            font-size: 0.75rem;
            display: block;
            margin-top: 0.25rem;
        }

        /* Legacy reveal modal styles (minimized for modern look) */
        #loginmodal { visibility: hidden; position: fixed; top: 100px; left: 50%; margin-left: -300px; width: 600px; background: #fff; z-index: 101; padding: 30px; border-radius: 8px; box-shadow: 0 0 20px rgba(0,0,0,0.2); }
    </style>

    <script src="js/commonloading.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
    <script src="js/default.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="login-card">
            <div class="logo-section">
                <asp:PlaceHolder ID="plhLoginImg" EnableViewState="false" runat="server"></asp:PlaceHolder>
            </div>

            <div class="login-title">
                <%#objLanguage.GetLanguageConversion("Login")%>
            </div>

            <div id="div_InvalidMsg" runat="server" class="error-message" style="display: none;">
                <asp:Image ID="ImgError" runat="server" ImageUrl="~/Images/error.gif" style="margin-right: 8px;" />
                <asp:Label ID="lblerror" runat="server" Visible="false" Text="Invalid login details"></asp:Label>
            </div>

            <div class="form-group">
                <asp:Label ID="lblEmail" runat="server" AssociatedControlID="email"></asp:Label>
                <input type="text" id="email" runat="server" name="useremail" class="LoginText" placeholder="Email Address" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="email" Display="Dynamic" ErrorMessage="Enter Email" CssClass="Redver7"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email" Display="Dynamic" ErrorMessage="Invalid Email" CssClass="Redver7" ValidationExpression="^((['\w])*[0-9a-zA-Z]([-.'\w]*[0-9a-zA-Z])*(['\w])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="password"></asp:Label>
                <asp:TextBox runat="server" ID="password" placeholder="Password" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password" Display="Dynamic" ErrorMessage="Enter Password" CssClass="Redver7"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <div id="div_btnlogin">
                    <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnLogIN_Click" CssClass="Loginbuttoscss"
                        OnClientClick="if(Page_ClientValidate()) {javascript:loadingimagelogin('btnlogin','div_process');} else {return false;}" />
                </div>
                
                <div id="div_process" style="display: none; text-align: center; margin-top: 10px;">
                    <img src="<%= strImagepath.ToString().Length > 0 ? strImagepath :"Images/" %>radimg1.gif" alt="loading" />
                </div>
            </div>

            <div class="remember-me-container">
                <input type="checkbox" id="chkremember" runat="server" name="save_password" />
                <asp:Label ID="lblRememberMe" runat="server" style="margin-left: 8px;"></asp:Label>
            </div>
        </div>

        <div style="display:none;">
            <asp:HiddenField ID="hdnScreenWidth" runat="server" />
            <asp:HiddenField ID="hdnpassword" runat="server" Value="" />
            <asp:HiddenField ID="hdn_login" runat="server" />
            <asp:HiddenField ID="hdn_pass" runat="server" />
            <asp:Literal runat="server" ID="ltrLoginPageUpdates"></asp:Literal>
            <asp:Label ID="lblRemembermeNote" runat="server"></asp:Label>
            <asp:PlaceHolder ID="plhFooter" Visible="false" EnableViewState="false" runat="server"></asp:PlaceHolder>
            <div id="error_email"></div>
            <div id="error_password"></div>
            <div id="test"></div>
        </div>

        <div id="loginmodal">
            <div id="loginheading">System Upgrade Notification</div>
            <div id="logincontent_ppup">
                <p>Your system has been upgraded to the latest version 3.9.5...</p>
                <a href="#" class="close">Close</a>
            </div>
        </div>

        <script src="js/jquery(1.7.1).min.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
        <script src="js/jquery.reveal.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
        
        <script type="text/javascript">
            // Core Logic preservation
            remember();
            $(document).ready(function () {
                document.getElementById("hdnScreenWidth").value = screen.width;
            });

            // Re-map modal logic if needed
            var ServerName = '<%=ServerName%>';
            // ... (rest of your date comparison logic remains here)
        </script>
    </form>
</body>
</html>
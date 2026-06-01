<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ePrint.Printcenter.Views.Login" EnableViewState="false" EnableViewStateMac="false" EnableEventValidation="false" StyleSheetTheme="" Theme="" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head id="Head1" runat="server">
    <title><%= strCompany %></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <style type="text/css">
        :root {
            --eprint-navy: #1a2332;
            --eprint-navy-muted: #94a3b8;
            --eprint-orange: #e67e22;
            --eprint-orange-dark: #c2410c;
            --eprint-bg: #f8fafc;
            --eprint-surface: #ffffff;
            --eprint-text: #0f172a;
            --eprint-muted: #64748b;
            --eprint-border: #e2e8f0;
            --eprint-error: #dc2626;
        }

        * { box-sizing: border-box; }

        body {
            margin: 0;
            min-height: 100vh;
            font-family: Inter, "Segoe UI", system-ui, sans-serif;
            color: var(--eprint-text);
        }

        .eprint-login-shell {
            display: flex;
            min-height: 100vh;
        }

        .eprint-login-brand-panel {
            flex: 1;
            min-width: 280px;
            background: var(--eprint-navy);
            color: #e2e8f0;
            padding: 48px 40px;
            display: flex;
            flex-direction: column;
            justify-content: center;
        }

        .eprint-login-brand-logo-wrap {
            margin-bottom: 24px;
        }

        .eprint-login-brand-logo-wrap .eprint-login-logo {
            max-width: 160px;
            max-height: 56px;
            width: auto;
            height: auto;
            display: block;
            border-radius: 8px;
        }

        .eprint-login-brand-logo-wrap .eprint-login-brand {
            font-size: 1.75rem;
            font-weight: 700;
            color: #fff;
            letter-spacing: -0.02em;
            line-height: 1.2;
        }

        .eprint-login-brand-fallback {
            width: 56px;
            height: 56px;
            border-radius: 12px;
            background: var(--eprint-orange);
            color: #fff;
            font-weight: 700;
            font-size: 0.75rem;
            display: none;
            align-items: center;
            justify-content: center;
        }

        .eprint-login-brand-panel h1 {
            margin: 0 0 12px;
            font-size: 1.75rem;
            color: #fff;
            font-weight: 700;
            letter-spacing: -0.02em;
        }

        .eprint-login-brand-panel:has(.eprint-login-brand) h1 {
            display: none;
        }

        .eprint-login-brand-panel .eprint-login-tagline {
            margin: 0;
            font-size: 0.95rem;
            line-height: 1.6;
            color: var(--eprint-navy-muted);
            max-width: 36ch;
        }

        .eprint-login-features {
            margin: 28px 0 0;
            padding: 0;
            list-style: none;
            font-size: 0.875rem;
            color: #cbd5e1;
        }

        .eprint-login-features li {
            padding: 6px 0;
            padding-left: 20px;
            position: relative;
        }

        .eprint-login-features li::before {
            content: "";
            position: absolute;
            left: 0;
            top: 12px;
            width: 6px;
            height: 6px;
            border-radius: 50%;
            background: var(--eprint-orange);
        }

        .eprint-login-form-side {
            flex: 1;
            background: var(--eprint-bg);
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 32px;
        }

        .eprint-login-form-card {
            width: 100%;
            max-width: 380px;
            background: var(--eprint-surface);
            border: 1px solid var(--eprint-border);
            border-radius: 12px;
            padding: 32px 28px;
        }

        .eprint-login-form-card h2 {
            margin: 0 0 6px;
            font-size: 1.35rem;
            font-weight: 700;
        }

        .eprint-login-form-card .eprint-login-sub {
            margin: 0 0 24px;
            color: var(--eprint-muted);
            font-size: 0.875rem;
        }

        .input-group {
            margin-bottom: 16px;
        }

        .input-group label {
            display: block;
            font-size: 0.8125rem;
            font-weight: 600;
            margin-bottom: 6px;
            color: var(--eprint-text);
        }

        .LoginText {
            width: 100%;
            padding: 11px 12px;
            border: 1px solid var(--eprint-border);
            border-radius: 8px;
            font-size: 1rem;
            box-sizing: border-box;
        }

        .LoginText:focus {
            outline: 2px solid #fed7aa;
            border-color: var(--eprint-orange);
        }

        .validation-msg {
            font-size: 0.75rem;
            color: var(--eprint-error);
            margin-top: 4px;
            display: block;
        }

        .remember-me {
            display: flex;
            align-items: center;
            gap: 8px;
            margin-bottom: 20px;
            font-size: 0.875rem;
            color: var(--eprint-muted);
            cursor: pointer;
        }

        .remember-me input {
            margin: 0;
        }

        #div_InvalidMsg {
            background-color: #fee2e2;
            border: 1px solid #fecaca;
            padding: 10px 12px;
            border-radius: 8px;
            margin-bottom: 16px;
            color: var(--eprint-error);
            font-size: 0.875rem;
        }

        #div_btnlogin {
            width: 100%;
        }

        .Loginbuttoscss {
            width: 100% !important;
            min-width: 100%;
            padding: 12px 24px;
            border: none;
            border-radius: 8px;
            background: var(--eprint-orange) !important;
            color: #fff !important;
            font-weight: 600;
            font-size: 1rem;
            cursor: pointer;
            height: 45px;
            display: flex;
            align-items: center;
            justify-content: center;
            box-sizing: border-box;
            box-shadow: none;
            transition: background 0.15s ease;
        }

        .Loginbuttoscss:hover {
            background: var(--eprint-orange-dark) !important;
            filter: none;
            transform: none;
            box-shadow: none;
        }

        .Loginbuttoscss:active {
            transform: none;
            filter: none;
        }

        .Loginbuttoscss img {
            margin: 0 auto;
            display: block;
            height: 20px;
            width: auto;
        }

        .eprint-login-loader {
            display: none;
            width: 100%;
            text-align: center;
        }

        .eprint-login-loader .Loginbuttoscss {
            opacity: 0.92;
            cursor: wait;
        }

        .auth-footer {
            margin-top: 20px;
            text-align: center;
            font-size: 0.875rem;
            color: var(--eprint-muted);
        }

        .auth-footer a {
            color: var(--eprint-orange-dark);
            font-weight: 600;
            text-decoration: none;
        }

        .auth-footer a:hover {
            text-decoration: underline;
        }

        #div_RegisteredMsg {
            margin-top: 16px;
            background-color: #ecfdf5;
            border: 1px solid #a7f3d0;
            padding: 10px 12px;
            border-radius: 8px;
            color: #047857;
            font-size: 0.875rem;
        }

        @media (max-width: 768px) {
            .eprint-login-shell {
                flex-direction: column;
            }

            .eprint-login-brand-panel {
                padding: 32px 24px;
                min-height: auto;
            }

            .eprint-login-features {
                display: none;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="eprint-login-shell">
            <aside class="eprint-login-brand-panel" aria-label="Product information">
                <div class="eprint-login-brand-logo-wrap">
                    <asp:PlaceHolder ID="plhLoginImg" runat="server"></asp:PlaceHolder>
                    <div class="eprint-login-brand-fallback" id="eprintBrandFallback" aria-hidden="true">eP</div>
                </div>
                <h1><%= strCompany %></h1>
                <p class="eprint-login-tagline">Estimates, jobs, and production — one place for your print business.</p>
                <ul class="eprint-login-features">
                    <li>Customer &amp; estimate management</li>
                    <li>Line items and pricing</li>
                    <li>Jobs, invoices, and delivery</li>
                </ul>
            </aside>

            <main class="eprint-login-form-side">
                <div class="eprint-login-form-card">
                    <div style="display:none;">
                        <asp:Literal runat="server" ID="ltrLoginPageUpdates"></asp:Literal>
                        <asp:Label ID="lblRemembermeNote" runat="server"></asp:Label>
                    </div>

                    <h2><asp:Label ID="lblLoginTitle" runat="server" Text="Login"></asp:Label></h2>
                    <p class="eprint-login-sub">Use your work email to access the MIS.</p>

                    <div id="div_InvalidMsg" runat="server" style="display: none;">
                        <asp:Image ID="ImgError" runat="server" ImageUrl="~/Images/error.gif" style="vertical-align:middle; margin-right:5px;" />
                        <asp:Label ID="lblerror" runat="server" Visible="false" Text="Invalid login details"></asp:Label>
                    </div>

                    <div class="input-group">
                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                        <input type="text" id="email" runat="server" name="useremail" class="LoginText" placeholder="you@company.com" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="email"
                            Display="Dynamic" ErrorMessage="Enter Email" CssClass="validation-msg" EnableClientScript="false"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email"
                            Display="Dynamic" ErrorMessage="Invalid Email" CssClass="validation-msg"
                            ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" EnableClientScript="false"></asp:RegularExpressionValidator>
                    </div>

                    <div class="input-group">
                        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                        <asp:TextBox runat="server" ID="password" CssClass="LoginText" TextMode="Password" placeholder="••••••••"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password"
                            Display="Dynamic" ErrorMessage="Enter Password" CssClass="validation-msg" EnableClientScript="false"></asp:RequiredFieldValidator>
                    </div>

                    <label class="remember-me">
                        <input type="checkbox" id="chkremember" runat="server" />
                        <asp:Label ID="lblRememberMe" runat="server" Text="Remember Me"></asp:Label>
                    </label>

                    <div id="div_btnlogin">
                        <asp:Button ID="btnlogin" runat="server" Text="Login"
                            OnClientClick="this.style.display='none'; document.getElementById('div_process').style.display='block'; return true;"
                            OnClick="btnLogIN_Click" CssClass="Loginbuttoscss" />

                        <div id="div_process" class="eprint-login-loader">
                            <div class="Loginbuttoscss">
                                <asp:Image ID="imgLoader" runat="server" ImageUrl="~/Images/radimg1.gif" AlternateText="loading" />
                            </div>
                        </div>
                    </div>

                    <div class="auth-footer">
                        Don't have an account? <a href="~/Login/SignUp.aspx" runat="server" id="lnkSignUp">Sign up</a>
                    </div>

                    <div id="div_RegisteredMsg" runat="server" visible="false">
                        <asp:Label ID="lblRegistered" runat="server"></asp:Label>
                    </div>

                    <asp:PlaceHolder ID="plhFooter" Visible="false" runat="server"></asp:PlaceHolder>
                </div>
            </main>
        </div>

        <script type="text/javascript">
            (function () {
                var hp = document.getElementById('<%= hdnpassword.ClientID %>');
                var pw = document.getElementById('<%= password.ClientID %>');
                if (hp && pw && hp.value) {
                    pw.value = hp.value;
                }
                var wrap = document.querySelector('.eprint-login-brand-logo-wrap');
                var fb = document.getElementById('eprintBrandFallback');
                if (wrap && fb) {
                    var hasLogo = wrap.querySelector('.eprint-login-logo, .eprint-login-brand');
                    fb.style.display = hasLogo ? 'none' : 'flex';
                }
            })();
        </script>

        <div style="display:none;">
            <asp:HiddenField ID="hdnpassword" runat="server" Value="" />
            <asp:HiddenField ID="hdn_login" runat="server" />
            <asp:HiddenField ID="hdn_pass" runat="server" />
        </div>
    </form>
</body>
</html>

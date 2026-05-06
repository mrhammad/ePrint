<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accessdenied.aspx.cs" Inherits="ePrint.accessdenied" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Access Denied</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background: #f9f9f9;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }
        .card {
            background: #fff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 4px 10px rgba(0,0,0,0.1);
            text-align: center;
            max-width: 400px;
            width: 100%;
        }
        .icon {
            font-size: 40px;
            color: #e74c3c;
            margin-bottom: 15px;
        }
        h2 {
            margin: 0;
            font-size: 22px;
            color: #333;
        }
        p {
            color: #666;
            margin: 10px 0;
            font-size: 14px;
        }
        .contact {
            margin-top: 20px;
            font-weight: bold;
            color: #333;
        }
        .contact-box {
            margin-top: 8px;
            padding: 8px;
            border: 1px solid #ddd;
            border-radius: 6px;
            background: #fafafa;
            display: inline-block;
            min-width: 180px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="card">
            <div class="icon">⚠️</div>
            <h2>Access Denied</h2>
            <p>You do not have permission to access this page</p>
            <p>If you believe this is an error, please contact your system administrator or reach out to our support team.</p>
            <div class="contact">
                Support Contact:
                <div class="contact-box">
                    support@hexicomsoftware.com
                </div>
            </div>
        </div>
    </form>
</body>
</html>

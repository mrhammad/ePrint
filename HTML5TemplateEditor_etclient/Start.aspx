<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="HTML5TemplateEditor_etclient.Start" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Front End Templates</title>
    <style type="text/css">
        .TemplateDiv {
            border-radius: 5px;
            width: 18.75em;
            display: inline-block;
            height: 100px;
            text-align: center;
            line-height: 100px;
            margin: 2px;
        }

            .TemplateDiv:hover {
                -webkit-box-shadow: inset 0px 1px 30px 5px rgba(0,0,0,.5);
                -moz-box-shadow: inset 0px 1px 30px 5px rgba(0,0,0,.5);
                box-shadow: inset 0px 0px 1px 30px 5px rgba(0,0,0,.5);
                transition: .25s;
                cursor: pointer;
                text-decoration: underline;
            }

        .linkfonts {
            font-family: Calibri;
            color: #FFFFFF;
            font-size: 20px;
            cursor: pointer;
            text-decoration: none;
            font-weight: bold;
        }

            .linkfonts:hover {
                text-decoration: underline;
            }

        .maindiv {
            width: 93%;
            text-align: center;
            margin: 0px auto 0px auto;
        }

        .heading {
            border: 2px solid white;
            margin: 0px auto 0px auto;
            height: 100px;
            line-height: 100px;
            vertical-align: middle;
            width: 98%;
            padding-bottom: 10px;
            text-align: center;
            border-radius: 5px;
        }

        .TemplateDiv, .heading {
            background: rgba(136,181,211,1);
            background: -moz-linear-gradient(top, rgba(136,181,211,1) 0%, rgba(79,137,181,1) 81%, rgba(79,137,181,1) 100%);
            background: -webkit-gradient(left top, left bottom, color-stop(0%, rgba(136,181,211,1)), color-stop(81%, rgba(79,137,181,1)), color-stop(100%, rgba(79,137,181,1)));
            background: -webkit-linear-gradient(top, rgba(136,181,211,1) 0%, rgba(79,137,181,1) 81%, rgba(79,137,181,1) 100%);
            background: -o-linear-gradient(top, rgba(136,181,211,1) 0%, rgba(79,137,181,1) 81%, rgba(79,137,181,1) 100%);
            background: -ms-linear-gradient(top, rgba(136,181,211,1) 0%, rgba(79,137,181,1) 81%, rgba(79,137,181,1) 100%);
            background: linear-gradient(to bottom, rgba(136,181,211,1) 0%, rgba(79,137,181,1) 81%, rgba(79,137,181,1) 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#88b5d3', endColorstr='#4f89b5', GradientType=0 );
        }

        body {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="maindiv">
            <div class="heading">
                <span style="font-size: 30px; font-weight:bold; font-family: Calibri; color: white;">Front End Templates</span>
            </div>
            <div id="Templatesdiv" style="height: 100%; width: 100%; text-align: center;" runat="server">
                <asp:PlaceHolder ID="plhTemplates" runat="server" EnableTheming="true"></asp:PlaceHolder>
            </div>
        </div>
    </form>
</body>
</html>

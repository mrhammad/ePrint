<%@ Control Language="C#" %>
<div id="InsertTableLight" class="reInsertTableLightWrapper" style="display: none;">
    <table cellspacing="0" cellpadding="0" border="0" class="reControlsLayout">
        <tr>
            <td colspan="2" class="reTablePropertyControlCell">
                <fieldset class="lightTable">
                    <legend>[layout] </legend>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <label class="reDialogLabelLight" for="TableColumns">
                                    <span class="short">[columns]</span>
                                </label>
                            </td>
                            <td>
                                <input type="text" id="Columns" class="rfdIgnore" />
                            </td>
                            <td>
                                <label class="reDialogLabelLight" for="CellPadding">
                                    <span class="short">[cellpadding]</span>
                                </label>
                            </td>
                            <td>
                                <input type="text" id="CellPadding" class="rfdIgnore" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="reDialogLabelLight" for="TableRows">
                                    <span class="short">[rows]</span>
                                </label>
                            </td>
                            <td>
                                <input type="text" id="Rows" class="rfdIgnore" />
                            </td>
                            <td>
                                <label class="reDialogLabelLight" for="CellSpacing">
                                    <span class="short">[cellspacing]</span>
                                </label>
                            </td>
                            <td>
                                <input type="text" id="CellSpacing" class="rfdIgnore" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="reDialogLabelLight" for="TableAlignment">
                                    <span>[alignment]</span>
                                </label>
                            </td>
                            <td>
                                <div class="reDialog reToolWrapper">
                                    <a id="AlignmentSelectorTable" title="AlignmentSelector" class="reTool reSplitButton"
                                        href="#"><span class="AlignmentSelector">&nbsp;</span><span class="split_arrow">&nbsp;</span></a>
                                </div>
                            </td>
                            <td>
                                <label class="reDialogLabelLight" for="BorderWidth">
                                    <span class="short">[border]</span>
                                </label>
                            </td>
                            <td>
                                <input type="text" id="BorderWidth" class="rfdIgnore" />&nbsp;&nbsp;px
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" class="reConfirmCancelButtonsTblLight">
                    <tr>
                        <td class="reAllPropertiesLight" style="padding-left: 3px;">
                            <button type="button" id="itlAllProperties" class="button">
                                [allproperties]
                            </button>
                        </td>
                        <td>
                            <button type="button" id="itlInsertBtn" class="button">
                                [ok]
                            </button>
                        </td>
                        <td>
                            <button type="button" id="itlCancelBtn" class="button">
                                [cancel]
                            </button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <style type="text/css">
        .button
        {
            display: inline-block;
            outline: none;
            cursor: pointer;
            text-align: center;
            text-decoration: none;
            font: 11px "Verdana" , Verdana, Arial, Helvetica, sans-serif;
            padding-left: 6px;
            padding-top: 2px;
            padding-bottom: 4px;
            padding-right: 6px;
            text-shadow: 0 1px 1px rgba(0,0,0,.3);
            -webkit-border-radius: .5em;
            -moz-border-radius: .5em;
            border-radius: .5em;
            -webkit-box-shadow: 0 1px 2px rgba(0,0,0,.2);
            -moz-box-shadow: 0 1px 2px rgba(0,0,0,.2);
            box-shadow: 0 1px 2px rgba(0,0,0,.2);
            color: #2C2B2B;
            border: solid 1px #a3a3a3;
            background: #EEEEEE;
            background: -webkit-gradient(linear, left top, left bottom, from(#E8E8E8), to(#F9F8F8));
            background: -moz-linear-gradient(top,  #E8E8E8,  #F9F8F8);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#E8E8E8', endColorstr='#F9F8F8');
        }
        .button:hover
        {
            text-decoration: none;
            background: #C9C9C9;
            border: 1px #3C7FB1 solid;
            background: -webkit-gradient(linear, left top, left bottom, from(#A7D9F5), to(#EAF6FD));
            background: -moz-linear-gradient(top,  #A7D9F5,  #EAF6FD);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#A7D9F5', endColorstr='#EAF6FD');
        }
    </style>
</div>

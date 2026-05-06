<%@ Control Language="C#" %>
<style type="text/css">
    body
    {
        font-family: "Verdana" ,​Verdana,​Arial,​Helvetica;
        font-size: 11px;
        /*color: #696969;*/
    }
    
    
    
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
<div id="InsertLink" class="reInsertLinkWrapper" style="display: none;">
    <table border="0" cellpadding="0" cellspacing="0" class="reControlsLayout">
        <tr>
            <td>
                <label for="LinkURL" class="reDialogLabelLight">
                    <span>[linkurl]</span>
                </label>
            </td>
            <td class="reControlCellLight">
                <input type="text" id="LinkUrl" class="rfdIgnore" />
            </td>
        </tr>
        <tr id="texTextBoxParentNode">
            <td>
                <label for="LinkText" class="reDialogLabelLight">
                    <span>[linktext]</span>
                </label>
            </td>
            <td class="reControlCellLight">
                <input type="text" id="LinkText" class="rfdIgnore" />
            </td>
        </tr>
        <tr>
            <td>
                <label for="LinkTargetCombo" class="reDialogLabelLight">
                    <span>[linktarget]</span>
                </label>
            </td>
            <td class="reControlCellLight">
                <select id="LinkTargetCombo" class="rfdIgnore">
                    <optgroup label="PresetTargets">
                        <option value="_none">[none]</option>
                        <option value="_self">[targetself]</option>
                        <option value="_blank">[targetblank]</option>
                        <option value="_parent">[targetparent]</option>
                        <option value="_top">[targettop]</option>
                        <option value="_search">[targetsearch]</option>
                        <option value="_media">[targetmedia]</option>
                    </optgroup>
                    <optgroup label="CustomTargets">
                        <option value="_custom">[addcustomtarget]</option>
                    </optgroup>
                </select>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" class="reConfirmCancelButtonsTblLight">
                    <tr>
                        <td class="reAllPropertiesLight">
                            <button type="button" id="lmlAllProperties" class="button">
                                [allproperties]
                            </button>
                        </td>
                        <td>
                            <button type="button" id="lmlInsertBtn" class="button">
                                [ok]
                            </button>
                        </td>
                        <td>
                            <button type="button" id="lmlCancelBtn" class="button">
                                [cancel]
                            </button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>

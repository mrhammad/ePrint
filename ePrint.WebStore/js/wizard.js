/*
* SmartWizard 3.3.1 plugin
* jQuery Wizard control Plugin
* by Dipu
*
* Refactored and extended:
* https://github.com/mstratman/jQuery-Smart-Wizard
*
* Original URLs:
* http://www.techlaboratory.net
* http://tech-laboratory.blogspot.com
*/



function SmartWizard(target, options) {
    this.target = target;
    this.options = options;
    this.curStepIdx = options.selected;
    this.steps = $(target).children("ul").children("li").children("a"); // Get all anchors
    this.contentWidth = 0;
    this.msgBox = $('<div class="msgBox"><div class="content"></div><a href="#" class="close">X</a></div>');
    this.elmStepContainer = $('<div style="height:100%;"></div>').addClass("stepContainer");
    this.loader = $('<div>Loading</div>').addClass("loader");
    this.buttons = {
        next: $('<a>' + options.labelNext + '</a>').attr("href", "#").addClass("buttonNext"),
        previous: $('<a>' + options.labelPrevious + '</a>').attr("href", "#").addClass("buttonPrevious"),
        finish: $('<a style="display:none;">' + options.labelFinish + '</a>').attr("href", "#").addClass("buttonFinish")
    };

    /*
    * Private functions
    */

    var _init = function ($this) {
        var elmActionBar = $('<div style="margin-bottom:10px;"></div>').addClass("actionBar");
        elmActionBar.append($this.msgBox);
        $('.close', $this.msgBox).click(function () {
            $this.msgBox.fadeOut("normal");
            return false;
        });

        var allDivs = $this.target.children('div');
        $this.target.children('ul').addClass("anchor");
        allDivs.addClass("content");

        // highlight steps with errors
        if ($this.options.errorSteps && $this.options.errorSteps.length > 0) {
            $.each($this.options.errorSteps, function (i, n) {
                $this.setError({ stepnum: n, iserror: true });
            });
        }

        $this.elmStepContainer.append(allDivs);
        elmActionBar.append($this.loader);
        $this.target.append($this.elmStepContainer);
        elmActionBar.append($this.buttons.previous)
            .append($this.buttons.next)
            .append($this.buttons.finish);
        $this.target.append(elmActionBar);
        this.contentWidth = $this.elmStepContainer.width();

        $(parent).load(function () {
            if (ApprovalType == "u") {
                document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_txtDesigApprover").focus();
            }
            else {
                txt_orderTitle.focus();
            }
        });

        $($this.buttons.next).click(function () {
            var flag = false;
            var txtDesigApprover = document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_txtDesigApprover");
            var divApproverEmail = document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_divApproverEmail");

            var tr_OrderNumber = document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_tr_OrderNumber");
            var tr_DeliveryRequiredBy = document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_tr_DeliveryRequiredBy");
            var OrderTitle_Mandatory = document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_OrderTitle_Mandatory");
            var OrderNumber_Mandatory = document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_OrderNumber_Mandatory");
            var DeliveryRequiredBy_Mandatory = document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_DeliveryRequiredBy_Mandatory");
            var Comments_Mandatory = document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_Comments_Mandatory");
            var ddlCostCenter = document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_ddlCostCenter");
            var tdCostCentre = document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_tdCostCentre");
            var re = '';

            if (txtRequiredBy.value != "") {

                if (ValidateForm(txtRequiredBy, 'spn_txtRequiredBy', DateFormat) == false) {
                    flag = true;
                }
            }
            else {
                flag = false;
            }

            if (divApproverEmail.style.display == "block") {
                if (txtDesigApprover.value == "") {
                    document.getElementById("reqemail").style.display = "block";
                    flag = true;
                } else if (txtDesigApprover.value != "") {
                    document.getElementById("reqemail").style.display = "none";
                    //re = /\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
                    re = /^([a-zA-Z0-9_\.\-'])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

                    if (!re.test(txtDesigApprover.value)) {
                        document.getElementById("RegularExpressionValidator1").style.display = "block";
                        flag = true;
                    }
                    else {
                        document.getElementById("RegularExpressionValidator1").style.display = "none";
                        if (ApprovalType == "u" && approverEmailcontains != "") {
                            if (_emailcontails(txtDesigApprover.value, approverEmailcontains)) {
                                document.getElementById("reqapproveremailcontains").style.display = "none";
                                flag = false;
                            }
                            else {
                                document.getElementById("reqapproveremailcontains").style.display = "block";
                                document.getElementById("reqapproveremailcontains").innerHTML = approverEmailcontains_Validation;
                                flag = true;
                            }
                        }
                        else {
                            flag = false;
                        }
                    }
                }
            }

            if (OrderTitle_Mandatory.style.display != "none") {
                if ((txt_orderTitle.value == "") || (txt_orderTitle.value.trim() == "")) {
                    spn_orderTitle.style.display = "block";
                    txt_orderTitle.focus();
                    flag = true;
                }
                else {
                    spn_orderTitle.style.display = "none";
                }
            }

            if (tdCostCentre.style.display != "none") {

                var result = ddlCostCenter.options[ddlCostCenter.selectedIndex].text;

                if (result == "--Select--") {
                    Span_Costcenter.style.display = "block";
                    Span_Costcenter.focus();
                    flag = true;
                }
                else {
                    Span_Costcenter.style.display = "none";
                }
            }

            if (OrderNumber_Mandatory.style.display != "none" && tr_OrderNumber.style.display != "none") {
                if ((txt_orderNumber.value == "") || (txt_orderNumber.value.trim() == "")) {
                    spn_orderNumber.style.display = "block";
                    txt_orderNumber.focus();
                    flag = true;
                }
                else {
                    spn_orderNumber.style.display = "none";
                }
            }

            if (DeliveryRequiredBy_Mandatory.style.display != "none" && tr_DeliveryRequiredBy.style.display != "none") {
                if ((txtRequiredBy.value == "") || (txtRequiredBy.value.trim() == "")) {
                    spn_DeliveryRequiredBy.style.display = "block";
                    txtRequiredBy.focus();
                    flag = true;
                }
                else {
                    spn_DeliveryRequiredBy.style.display = "none";
                }
            }

            if (Comments_Mandatory.style.display != "none") {
                if ((txtComments.value == "") || (txtComments.value.trim() == "")) {
                    spn_Comments.style.display = "block";
                    txtComments.focus();
                    flag = true;
                }
                else {
                    spn_Comments.style.display = "none";
                }
            }
            if (document.getElementById('ctl00_ContentPlaceHolder1_hdn_isOrderInformationAccessible').value == '0') {
                flag = false;
            }
            if (flag) {
                return false;
            }
            else {
                if ($this.curStepIdx < 1) {

                    $this.goForward();
                    return false;
                }
                else {
                    if (document.getElementById('ctl00_ContentPlaceHolder1_hdnservername').value == 'smp' && document.getElementById('ctl00_ContentPlaceHolder1_hdnaccountid').value == '276') {
                        var DNAddressID = document.getElementById('ctl00_ContentPlaceHolder1_ucAddressInfo_hdnshippingaddr');
                        if (DNAddressID.value == '' || DNAddressID.value == '0') {
                            alert('Please select address');
                        }
                        else {

                            $($this.buttons.next).removeClass('buttonNext').addClass('buttonNextLoading');
                            $($this.buttons.next).html('');
                            $($this.buttons.next).css({ 'height': '16px' });
                            // $("#overlay").show(); masking
                            document.getElementById("ctl00_ContentPlaceHolder1_btn_billingAddress").click();
                        }
                    }
                    else {
                        var DeliveryAddressID = document.getElementById('ctl00_ContentPlaceHolder1_ucAddressInfo_hdnshippingaddr');
                        var hdnChkInvAddress = document.getElementById('ctl00_ContentPlaceHolder1_ucAddressInfo_hdnChkInvAddress');

                        if ((hdnChkInvAddress.value == "0" && isCheckInvoiceInfo == "true" && is_InvoiceAddress_Mandatory == "true") || (DeliveryAddressID.value == "0" && isCheckDeliveryInfo == "true" && is_DeliveryAddress_Mandatory == "true")) {
                            if (hdnChkInvAddress.value == "0" && isCheckInvoiceInfo == "true" && is_InvoiceAddress_Mandatory == "true") {
                                alert('Please add/select Invoice Address');
                                return false;
                            }
                            if (DeliveryAddressID.value == "0" && isCheckDeliveryInfo == "true" && is_DeliveryAddress_Mandatory == "true") {
                                alert('Please add/select Delivery Address');
                                return false;
                            }

                        }
                        // added on 15-12-2017 by shehzad to chekc if delivery/invocie address are empty
                        else if (is_InvoiceAddress_Mandatory == "true" && document.getElementById('ctl00_ContentPlaceHolder1_ucAddressInfo_lblBillingAddress').innerText == "") {
                            alert('Please add/select Invoice Address');
                            return false;
                        }

                        else if (is_DeliveryAddress_Mandatory == "true" && document.getElementById('ctl00_ContentPlaceHolder1_ucAddressInfo_lblShippingAddress').innerText == "") {
                            alert('Please add/select Delivery Address');
                            return false;
                        }

                        else {

                            $($this.buttons.next).removeClass('buttonNext').addClass('buttonNextLoading');
                            $($this.buttons.next).html('');
                            $($this.buttons.next).css({ 'height': '16px' });
                            // $("#overlay").show(); masking
                            document.getElementById("ctl00_ContentPlaceHolder1_btn_billingAddress").click();
                        }
                    }
                }
            }

        });



        $($this.buttons.previous).click(function () {
            var isOrderInformationAccessible = document.getElementById('ctl00_ContentPlaceHolder1_hdn_isOrderInformationAccessible').value;
            if (isOrderInformationAccessible.toString() == '0' || 0 >= $this.curStepIdx) {
                $($this.buttons.previous).removeClass('buttonPrevious').addClass('buttonNextLoading');
                $($this.buttons.previous).html('');
                $($this.buttons.previous).css({ 'height': '16px' });
                document.getElementById("ctl00_ContentPlaceHolder1_btn_BackShop").click();
                return false;
            }
            if (0 >= $this.curStepIdx) {
                $($this.buttons.previous).removeClass('buttonPrevious').addClass('buttonNextLoading');
                $($this.buttons.previous).html('');
                $($this.buttons.previous).css({ 'height': '16px' });
                document.getElementById("ctl00_ContentPlaceHolder1_btn_BackShop").click();
            }
            $this.goBackward();
            return false;
        });


        $($this.buttons.finish).click(function () {

            if (!$(this).hasClass('buttonDisabled')) {

                var flag = false;

                if (txtRequiredBy.value != "") {

                    if (ValidateForm(txtRequiredBy, 'spn_txtRequiredBy', DateFormat) == false) {
                        flag = true;
                    }
                }
                else {
                    flag = false;
                }

                if ((txt_orderTitle.value == "") || (txt_orderTitle.value.trim() == "")) {

                    spn_orderTitle.style.display = "block";
                    flag = true;
                }
                else {
                    spn_orderTitle.style.display = "none";
                }

                if (flag) {
                    txt_orderTitle.focus();
                    return false;
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_btn_billingAddress").click();
                }

                //                if ($.isFunction($this.options.onFinish)) {
                //                    var context = { fromStep: $this.curStepIdx + 1 };
                //                    if (!$this.options.onFinish.call(this, $($this.steps), context)) {
                //                        return false;
                //                    }
                //                } else {
                //                    var frm = $this.target.parents('form');
                //                    if (frm && frm.length) {
                //                        frm.submit();
                //                    }
                //                }
            }
            return false;
        });

        $($this.steps).bind("click", function (e) {
            //            if ($this.steps.index(this) == $this.curStepIdx) {
            //                return false;
            //            }
            //            var nextStepIdx = $this.steps.index(this);

            //        if(nextStepIdx==2)
            //        {
            //           document.getElementById("ctl00_ContentPlaceHolder1_btn_billingAddress").click();
            //        }
            //            var isDone = $this.steps.eq(nextStepIdx).attr("isDone") - 0;
            //            if (isDone == 1) {
            //                var flag = false;

            //                
            //                if (txtRequiredBy.value != "") {

            //                    if (ValidateForm(txtRequiredBy, 'spn_txtRequiredBy', DateFormat) == false) {
            //                        flag = true;
            //                    }
            //                }
            //                else {
            //                    flag = false;
            //                }

            //                if ((txt_orderTitle.value == "") || (txt_orderTitle.value.trim() == "")) {

            //                    spn_orderTitle.style.display = "block";
            //                    flag = true;
            //                }
            //                else {
            //                    spn_orderTitle.style.display = "none";
            //                }

            //                if (flag) {
            //                    txt_orderTitle.focus();
            //                    return false;
            //                }
            //                else {
            //                    _loadContent($this, nextStepIdx);
            //                }
            //            }
            return false;
        });

        // Enable keyboard navigation
        //        if ($this.options.keyNavigation) {
        //            $(document).keyup(function (e) {
        //                if (e.which == 39) { // Right Arrow
        //                    $this.goForward();
        //                } else if (e.which == 37) { // Left Arrow
        //                    $this.goBackward();
        //                }
        //            });
        //        }
        //  Prepare the steps
        _prepareSteps($this);
        // Show the first slected step
        _loadContent($this, $this.curStepIdx);
    };

    var _prepareSteps = function ($this) {

        if (!$this.options.enableAllSteps) {
            $($this.steps, $this.target).removeClass("selected").removeClass("done").addClass("disabled");
            $($this.steps, $this.target).attr("isDone", 0);
        } else {
            $($this.steps, $this.target).removeClass("selected").removeClass("disabled").addClass("done");
            $($this.steps, $this.target).attr("isDone", 1);
        }

        $($this.steps, $this.target).each(function (i) {
            $($(this).attr("href").replace(/^.+#/, '#'), $this.target).hide();
            $(this).attr("rel", i + 1);
        });
    };

    var _step = function ($this, selStep) {
        return $(
            $(selStep, $this.target).attr("href").replace(/^.+#/, '#'),
            $this.target
        );
    };

    var _emailcontails = function (str, suffix) {
        return str.indexOf(suffix, str.length - suffix.length) !== -1;
    }

    var _loadContent = function ($this, stepIdx) {

        var selStep = $this.steps.eq(stepIdx);
        var ajaxurl = $this.options.contentURL;
        var ajaxurl_data = $this.options.contentURLData;
        var hasContent = selStep.data('hasContent');
        var stepNum = stepIdx + 1;
        if (ajaxurl && ajaxurl.length > 0) {
            if ($this.options.contentCache && hasContent) {
                _showStep($this, stepIdx);
            } else {
                var ajax_args = {
                    url: ajaxurl,
                    type: "POST",
                    data: ({ step_number: stepNum }),
                    dataType: "text",
                    beforeSend: function () {
                        $this.loader.show();
                    },
                    error: function () {
                        $this.loader.hide();
                    },
                    success: function (res) {
                        $this.loader.hide();
                        if (res && res.length > 0) {
                            selStep.data('hasContent', true);
                            _step($this, selStep).html(res);
                            _showStep($this, stepIdx);
                        }
                    }
                };
                if (ajaxurl_data) {
                    ajax_args = $.extend(ajax_args, ajaxurl_data(stepNum));
                }
                $.ajax(ajax_args);
            }
        } else {
            _showStep($this, stepIdx);
        }
    };

    var _showStep = function ($this, stepIdx) {
        var selStep = $this.steps.eq(stepIdx);
        var curStep = $this.steps.eq($this.curStepIdx);
        if (stepIdx != $this.curStepIdx) {
            if ($.isFunction($this.options.onLeaveStep)) {
                var context = { fromStep: $this.curStepIdx + 1, toStep: stepIdx + 1 };
                if (!$this.options.onLeaveStep.call($this, $(curStep), context)) {
                    return false;
                }
            }
        }
        //$this.elmStepContainer.height(_step($this, selStep).outerHeight());
        var prevCurStepIdx = $this.curStepIdx;
        $this.curStepIdx = stepIdx;
        if ($this.options.transitionEffect == 'slide') {
            _step($this, curStep).slideUp("fast", function (e) {
                _step($this, selStep).slideDown("fast");
                _setupStep($this, curStep, selStep);
            });
        } else if ($this.options.transitionEffect == 'fade') {
            _step($this, curStep).fadeOut("fast", function (e) {
                _step($this, selStep).fadeIn("fast");
                _setupStep($this, curStep, selStep);
            });
        } else if ($this.options.transitionEffect == 'slideleft') {
            var nextElmLeft = 0;
            var nextElmLeft1 = null;
            var nextElmLeft = null;
            var curElementLeft = 0;
            if (stepIdx > prevCurStepIdx) {
                nextElmLeft1 = $this.contentWidth + 10;
                nextElmLeft2 = 0;
                curElementLeft = 0 - _step($this, curStep).outerWidth();
            } else {
                nextElmLeft1 = 0 - _step($this, selStep).outerWidth() + 20;
                nextElmLeft2 = 0;
                curElementLeft = 10 + _step($this, curStep).outerWidth();
            }
            if (stepIdx == prevCurStepIdx) {
                nextElmLeft1 = $($(selStep, $this.target).attr("href"), $this.target).outerWidth() + 20;
                nextElmLeft2 = 0;
                curElementLeft = 0 - $($(curStep, $this.target).attr("href"), $this.target).outerWidth();
            } else {
                $($(curStep, $this.target).attr("href"), $this.target).animate({ left: curElementLeft }, "fast", function (e) {
                    $($(curStep, $this.target).attr("href"), $this.target).hide();
                });
            }

            _step($this, selStep).css("left", nextElmLeft1).show().animate({ left: nextElmLeft2 }, "fast", function (e) {
                _setupStep($this, curStep, selStep);
            });
        } else {
            _step($this, curStep).hide();
            _step($this, selStep).show();
            _setupStep($this, curStep, selStep);
        }
        return true;
    };

    var _setupStep = function ($this, curStep, selStep) {
        $(curStep, $this.target).removeClass("selected");
        $(curStep, $this.target).addClass("done");

        $(selStep, $this.target).removeClass("disabled");
        $(selStep, $this.target).removeClass("done");
        $(selStep, $this.target).addClass("selected");

        $(selStep, $this.target).attr("isDone", 1);

        _adjustButton($this);

        if ($.isFunction($this.options.onShowStep)) {
            var context = { fromStep: parseInt($(curStep).attr('rel')), toStep: parseInt($(selStep).attr('rel')) };
            if (!$this.options.onShowStep.call(this, $(selStep), context)) {
                return false;
            }
        }
        if ($this.options.noForwardJumping) {
            // +2 == +1 (for index to step num) +1 (for next step)
            for (var i = $this.curStepIdx + 2; i <= $this.steps.length; i++) {
                $this.disableStep(i);
            }
        }
    };

    var _adjustButton = function ($this) {
        if (!$this.options.cycleSteps) {
            if (0 >= $this.curStepIdx) {
                //                $($this.buttons.previous).addClass("buttonDisabled");
                //                if ($this.options.hideButtonsOnDisabled) {
                $($this.buttons.previous).show();
                //}
            } else {
                $($this.buttons.previous).removeClass("buttonDisabled");
                if ($this.options.hideButtonsOnDisabled) {
                    $($this.buttons.previous).show();
                }
            }
            if (($this.steps.length - 1) <= $this.curStepIdx) {
                $($this.buttons.next).addClass("buttonDisabled");
                if ($this.options.hideButtonsOnDisabled) {
                    $($this.buttons.next).hide();
                }
            } else {
                $($this.buttons.next).removeClass("buttonDisabled");
                if ($this.options.hideButtonsOnDisabled) {
                    $($this.buttons.next).show();
                }
            }
        }
        // Finish Button
        if (!$this.steps.hasClass('disabled') || $this.options.enableFinishButton) {
            $($this.buttons.finish).removeClass("buttonDisabled");
            if ($this.options.hideButtonsOnDisabled) {
                $($this.buttons.finish).show();
            }
        } else {
            $($this.buttons.finish).addClass("buttonDisabled");
            if ($this.options.hideButtonsOnDisabled) {
                $($this.buttons.finish).hide();
            }
        }
    };

    /*
    * Public methods
    */

    SmartWizard.prototype.goForward = function () {

        var nextStepIdx = this.curStepIdx + 1;
        if (this.steps.length <= nextStepIdx) {
            if (!this.options.cycleSteps) {
                return false;
            }
            nextStepIdx = 0;
        }
        _loadContent(this, nextStepIdx);
    };

    SmartWizard.prototype.goBackward = function () {
        var nextStepIdx = this.curStepIdx - 1;
        if (0 > nextStepIdx) {
            if (!this.options.cycleSteps) {
                return false;
            }
            nextStepIdx = this.steps.length - 1;
        }
        _loadContent(this, nextStepIdx);
    };

    SmartWizard.prototype.goToStep = function (stepNum) {
        var stepIdx = stepNum - 1;
        if (stepIdx >= 0 && stepIdx < this.steps.length) {
            _loadContent(this, stepIdx);
        }
    };
    SmartWizard.prototype.enableStep = function (stepNum) {

        var stepIdx = stepNum - 1;
        if (stepIdx == this.curStepIdx || stepIdx < 0 || stepIdx >= this.steps.length) {
            return false;
        }
        var step = this.steps.eq(stepIdx);
        $(step, this.target).attr("isDone", 1);
        $(step, this.target).removeClass("disabled").removeClass("selected").addClass("done");
    }
    SmartWizard.prototype.disableStep = function (stepNum) {
        var stepIdx = stepNum - 1;
        if (stepIdx == this.curStepIdx || stepIdx < 0 || stepIdx >= this.steps.length) {
            return false;
        }
        var step = this.steps.eq(stepIdx);
        $(step, this.target).attr("isDone", 0);
        $(step, this.target).removeClass("done").removeClass("selected").addClass("disabled");
    }
    SmartWizard.prototype.currentStep = function () {
        return this.curStepIdx + 1;
    }

    SmartWizard.prototype.showMessage = function (msg) {
        $('.content', this.msgBox).html(msg);
        this.msgBox.show();
    }
    SmartWizard.prototype.hideMessage = function () {
        this.msgBox.fadeOut("normal");
    }
    SmartWizard.prototype.showError = function (stepnum) {
        this.setError(stepnum, true);
    }
    SmartWizard.prototype.hideError = function (stepnum) {
        this.setError(stepnum, false);
    }
    SmartWizard.prototype.setError = function (stepnum, iserror) {
        if (typeof stepnum == "object") {
            iserror = stepnum.iserror;
            stepnum = stepnum.stepnum;
        }

        if (iserror) {
            $(this.steps.eq(stepnum - 1), this.target).addClass('error')
        } else {
            $(this.steps.eq(stepnum - 1), this.target).removeClass("error");
        }
    }

    SmartWizard.prototype.fixHeight = function () {
        //        var height = 0;

        //        var selStep = this.steps.eq(this.curStepIdx);
        //        var stepContainer = _step(this, selStep);
        //        stepContainer.children().each(function () {
        //            height += $(this).outerHeight();
        //        });

        //         These values (5 and 20) are experimentally chosen.
        //        stepContainer.height(height + 5);
        //        this.elmStepContainer.height(height + 20);
    }

    _init(this);
};



(function ($) {

    $.fn.smartWizard = function (method) {
        var args = arguments;
        var rv = undefined;
        var allObjs = this.each(function () {
            var wiz = $(this).data('smartWizard');
            if (typeof method == 'object' || !method || !wiz) {
                var options = $.extend({}, $.fn.smartWizard.defaults, method || {});
                if (!wiz) {
                    wiz = new SmartWizard($(this), options);
                    $(this).data('smartWizard', wiz);
                }
            } else {
                if (typeof SmartWizard.prototype[method] == "function") {
                    rv = SmartWizard.prototype[method].apply(wiz, Array.prototype.slice.call(args, 1));
                    return rv;
                } else {
                    $.error('Method ' + method + ' does not exist on jQuery.smartWizard');
                }
            }
        });
        if (rv === undefined) {
            return allObjs;
        } else {
            return rv;
        }
    };

    //    // Default Properties and Events
    //    $.fn.smartWizard.defaults = {
    //        selected: 0,  // Selected Step, 0 = first step
    //        keyNavigation: true, // Enable/Disable key navigation(left and right keys are used if enabled)
    //        enableAllSteps: false,
    //        transitionEffect: 'fade', // Effect on navigation, none/fade/slide/slideleft
    //        contentURL: null, // content url, Enables Ajax content loading
    //        contentCache: true, // cache step contents, if false content is fetched always from ajax url
    //        cycleSteps: false, // cycle step navigation
    //        enableFinishButton: false, // make finish button enabled always
    //        hideButtonsOnDisabled: false, // when the previous/next/finish buttons are disabled, hide them instead?
    //        errorSteps: [],    // Array Steps with errors
    //        labelNext: 'Continue',//Next
    //        labelPrevious: 'Back',//Previous
    //        labelFinish: 'Continue',//Finish
    //        noForwardJumping: false,
    //        onLeaveStep: null, // triggers when leaving a step
    //        onShowStep: null,  // triggers when showing a step
    //        onFinish: null  // triggers when Finish button is clicked
    //    };

})(jQuery);
/* Perfect estimate/job/order/invoice summary layout */
(function (window) {
    "use strict";

    function getRoot() {
        return document.getElementById("eprintPerfectSummaryRoot");
    }

    function escapeHtml(s) {
        return String(s)
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;");
    }

    function getHiddenAccordionIndex() {
        var hdn = document.querySelector("[id$='_hdnaccordionIndex']");
        if (!hdn || hdn.value === "" || hdn.value == null) {
            return 1;
        }
        var n = parseInt(hdn.value, 10);
        return isNaN(n) ? 1 : n;
    }

    /** All line-item headers (h3 may be nested inside .sortingdivs wrappers) */
    function getAccordionHeaders($accordion) {
        if (!$accordion || !$accordion.length) {
            return window.jQuery();
        }
        return $accordion.find("h3");
    }

    /** Legacy indices included customer panel at 0; line items start at 1 */
    function resolveLineItemIndex(itemCount) {
        if (itemCount <= 0) {
            return 0;
        }
        var legacy = getHiddenAccordionIndex();
        var idx = legacy <= 0 ? 0 : legacy - 1;
        if (idx < 0) {
            idx = 0;
        }
        if (idx >= itemCount) {
            idx = itemCount - 1;
        }
        return idx;
    }

    function isTotalsHeader($h) {
        if (!$h || !$h.length) {
            return false;
        }
        if ($h.attr("data-value") === "sortable") {
            return false;
        }
        var text = ($h.text() || "").replace(/\s+/g, " ");
        if (text.indexOf("All Items") >= 0 || text.indexOf("All_Items") >= 0) {
            return true;
        }
        return $h.find("#spnAllItems").length > 0;
    }

    function syncBadge() {
        var badge = document.getElementById("eprintDocBadge");
        if (!badge) {
            return;
        }
        var mod = (typeof window.Module !== "undefined" && window.Module) ? window.Module : "";
        if (!mod && typeof window.Pgtype !== "undefined") {
            mod = window.Pgtype;
        }
        mod = (mod || "DOC").toString().toUpperCase();
        if (mod.indexOf("ESTIMATE") >= 0 || mod === "ESTIMATE") {
            mod = "EST";
        } else if (mod.length > 3) {
            mod = mod.substring(0, 3);
        }
        badge.textContent = mod;
    }

    function getCompanyName() {
        var el = document.querySelector("[id$='_LblCompanyName']");
        return el ? (el.textContent || "").trim() : "";
    }

    function getDocNumber() {
        var el = document.querySelector("[id$='_lblEstJobInvNo']");
        return el ? (el.textContent || "").trim() : "";
    }

    function syncHeaderMeta() {
        var sub = document.getElementById("eprintDocSubtitle");
        if (sub) {
            var company = getCompanyName();
            sub.innerHTML = company
                ? "Customer: <b>" + escapeHtml(company) + "</b>"
                : "";
        }
        var title = document.getElementById("eprintDocTitle");
        if (title) {
            var num = getDocNumber();
            if (num) {
                title.textContent = num;
            }
        }
    }

    function getLineItemCount() {
        var nav = document.getElementById("eprintLineItemTabsNav");
        if (nav) {
            var tabBtns = nav.querySelectorAll("button[data-line-index]");
            if (tabBtns.length) {
                return tabBtns.length;
            }
        }
        var panelsWrap = document.getElementById("eprintLineItemPanels");
        if (panelsWrap) {
            var panels = panelsWrap.querySelectorAll(".eprint-line-item-panel[data-line-index]");
            if (panels.length) {
                return panels.length;
            }
        }
        var acc = document.getElementById("accordion");
        if (!acc) {
            return 0;
        }
        var blocks = acc.querySelectorAll(".sortingdivs[data-value='sortable']");
        if (blocks.length) {
            return blocks.length;
        }
        return acc.querySelectorAll("h3[data-value='sortable']").length;
    }

    function syncLineItemsKpi() {
        var n = getLineItemCount();
        var kpiEl = document.getElementById("eprintKpiLineItems");
        if (kpiEl) {
            kpiEl.textContent = String(n);
        }
        updateItemCountBadge();
    }

    function getGrossProfitKpi() {
        var root = getRoot();
        if (!root) {
            return "—";
        }
        var orderGp = root.querySelector("#div_OrderGrossProft");
        if (orderGp) {
            var pctNodes = orderGp.querySelectorAll("div[style*='padding-top']");
            var i;
            for (i = 0; i < pctNodes.length; i++) {
                var pctText = (pctNodes[i].textContent || "").replace(/\s+/g, " ").trim();
                var pctMatch = pctText.match(/(\d+(?:\.\d+)?)\s*%/);
                if (pctMatch) {
                    return pctMatch[1] + "%";
                }
            }
            var blockMatch = (orderGp.textContent || "").replace(/\s+/g, " ").match(/(\d+(?:\.\d+)?)\s*%/);
            if (blockMatch) {
                return blockMatch[1] + "%";
            }
        }
        var spnPct = root.querySelector("[id^='spnGrossProfitPercentage1_']");
        if (spnPct) {
            var spnText = (spnPct.textContent || "").replace(/\s+/g, " ").trim();
            var spnMatch = spnText.match(/(\d+(?:\.\d+)?)/);
            if (spnMatch) {
                return spnMatch[1] + "%";
            }
        }
        return "—";
    }

    function buildKpis() {
        var row = document.getElementById("eprintKpiRow");
        if (!row) {
            return;
        }
        var totalEl = document.getElementById("TabSellingPrice");
        var totalText = "—";
        if (totalEl) {
            totalText = (totalEl.textContent || "").replace(/\s+/g, " ").trim() || "—";
        }
        var itemCount = getLineItemCount();
        var profitText = getGrossProfitKpi();

        row.innerHTML =
            "<div class=\"eprint-kpi highlight\"><span class=\"lbl\">Sub total (ex)</span><span class=\"val\" id=\"eprintKpiSubtotal\">" + escapeHtml(totalText) + "</span></div>" +
            "<div class=\"eprint-kpi\"><span class=\"lbl\">Line items</span><span class=\"val\" id=\"eprintKpiLineItems\">" + itemCount + "</span></div>" +
            "<div class=\"eprint-kpi\"><span class=\"lbl\">Gross profit</span><span class=\"val\" id=\"eprintKpiProfit\">" + escapeHtml(profitText) + "</span></div>" +
            "<div class=\"eprint-kpi\"><span class=\"lbl\">Status</span><span class=\"val\" id=\"eprintKpiStatus\">—</span></div>";

        syncStatusKpi();
    }

    function syncStatusKpi() {
        var statusLabel = document.querySelector("[id$='_lblStatusTitle']");
        var kpi = document.getElementById("eprintKpiStatus");
        var foot = document.getElementById("eprintFootStatus");
        var text = statusLabel ? (statusLabel.textContent || "").trim() : "";
        if (kpi) {
            kpi.textContent = text || "—";
        }
        if (foot) {
            foot.textContent = text || "—";
        }
    }

    function syncFooterTotals() {
        var footSub = document.getElementById("eprintFootSubtotal");
        var totalEl = document.getElementById("TabSellingPrice");
        if (footSub && totalEl) {
            footSub.textContent = (totalEl.textContent || "").trim() || "—";
        }
    }

    function isCustomerFieldRowExcluded(el) {
        if (!el) {
            return false;
        }
        if (el.classList && el.classList.contains("eprint-invoice-only-field")) {
            return true;
        }
        if (!el.id) {
            return false;
        }
        return el.id === "Div_Status" || el.id === "divInvoice"
            || el.id === "Div_JobEstNo" || el.id.indexOf("Div_JobEstNo") >= 0
            || el.id.indexOf("Div_InvoicePaid") >= 0
            || el.id.indexOf("div_InvoiceDueDate") >= 0;
    }

    /** URL is authoritative — avoids stale static Module from server */
    function getCustomerDocType() {
        var href = window.location.href.toLowerCase();
        if (href.indexOf("/jobs/job") >= 0 || href.indexOf("job_summary") >= 0) {
            return "job";
        }
        if (href.indexOf("/invoice/") >= 0 || href.indexOf("invoice_summary") >= 0) {
            return "invoice";
        }
        if (href.indexOf("/orders/order") >= 0 || href.indexOf("order_summary") >= 0) {
            return "order";
        }
        if (href.indexOf("/estimates/") >= 0 || href.indexOf("estimate_summary") >= 0) {
            return "estimate";
        }
        var mod = (typeof window.Module !== "undefined" && window.Module) ? String(window.Module).toLowerCase() : "";
        if (!mod && typeof window.Pgtype !== "undefined") {
            mod = String(window.Pgtype).toLowerCase();
        }
        return mod || "estimate";
    }

    function syncCustomerDocTypeOnRoot() {
        var root = getRoot();
        if (!root) {
            return;
        }
        root.setAttribute("data-doc-type", getCustomerDocType());
    }

    /** Hide invoice-only blocks; flex CSS must not override display:none on Estimate/Job */
    function hideInvoiceOnlyCustomerFields() {
        var host = document.querySelector(".eprint-customer-details-host");
        if (!host) {
            return;
        }
        var mod = getCustomerDocType();
        var isInvoice = mod === "invoice";
        var jobEstNo = host.querySelector("#Div_JobEstNo, [id$='Div_JobEstNo']");
        if (jobEstNo) {
            jobEstNo.style.display = mod === "job" ? "block" : "none";
            if (mod !== "job") {
                jobEstNo.classList.remove("eprint-cust-field-row");
            }
        }
        var nodes = host.querySelectorAll(
            "#Div_Status, #divInvoice, .eprint-invoice-only-field, [id$='Div_InvoicePaid'], [id$='div_InvoiceDueDate']"
        );
        var i, el;
        for (i = 0; i < nodes.length; i++) {
            el = nodes[i];
            if (el.id === "Div_Status" || el.id === "divInvoice") {
                el.style.display = "none";
                el.classList.remove("eprint-cust-field-row");
                continue;
            }
            if (isInvoice) {
                el.style.display = "block";
            } else {
                el.style.display = "none";
                el.style.visibility = "hidden";
                el.classList.remove("eprint-cust-field-row");
            }
        }
    }

    /** Mark each .bglabel + .box pair so label and value stay on one row (Estimated Artwork dates, etc.) */
    function markCustomerFieldRows(scope) {
        if (!scope) {
            return;
        }
        var nodes = scope.querySelectorAll("div[id], div[align]");
        var n, el, c, ch, label, box;
        for (n = 0; n < nodes.length; n++) {
            el = nodes[n];
            if (isCustomerFieldRowExcluded(el)) {
                continue;
            }
            label = null;
            box = null;
            for (c = 0; c < el.children.length; c++) {
                ch = el.children[c];
                if (!ch.classList) {
                    continue;
                }
                if (!label && (ch.classList.contains("bglabel") || ch.classList.contains("bgLabel"))) {
                    label = ch;
                } else if (!box && ch.classList.contains("box")) {
                    box = ch;
                }
            }
            if (!label || !box) {
                continue;
            }
            el.classList.add("eprint-cust-field-row");
            label.style.cssFloat = "none";
            label.style.clear = "none";
            label.style.width = "";
            box.style.cssFloat = "none";
            box.style.clear = "none";
            box.style.width = "";
            box.style.marginLeft = "0";
        }
    }

    /** Re-apply estimate / invoice / job field visibility from Item_Summary_CustomerDetails.ascx */
    function applyCustomerModuleFields() {
        syncCustomerDocTypeOnRoot();
        if (typeof window.eprintLoadCustomerPageInformation === "function") {
            window.eprintLoadCustomerPageInformation();
        }
    }

    /** Legacy Item_Summary_CustomerDetails uses float:left + width 99% on the right <td> */
    function fixCustomerDetailsLayout() {
        applyCustomerModuleFields();
        var table = document.querySelector(".eprint-customer-details-host #tbl_CutaomerDetails");
        if (!table) {
            return;
        }
        var row = table.querySelector("tr:nth-child(2)");
        if (!row) {
            return;
        }
        var cells = row.querySelectorAll("td");
        var i, j, k;
        for (i = 0; i < cells.length; i++) {
            cells[i].style.float = "none";
            cells[i].style.width = "";
            cells[i].style.maxWidth = "";
            if (cells[i].getAttribute("width")) {
                cells[i].removeAttribute("width");
            }
        }
        var inner = row.querySelectorAll("td > div[style]");
        for (j = 0; j < inner.length; j++) {
            inner[j].style.width = "100%";
            inner[j].style.maxWidth = "100%";
            inner[j].style.float = "none";
        }
        var boxes = row.querySelectorAll(".box[style]");
        for (k = 0; k < boxes.length; k++) {
            boxes[k].style.marginLeft = "0";
        }
        markCustomerFieldRows(row);
        hideInvoiceOnlyCustomerFields();
    }

    function normalizeTabKey(tabKey) {
        if (tabKey === "overview" || tabKey === "activity" || tabKey === "notes") {
            return "customer";
        }
        return tabKey;
    }

    function parseItemFromHeader($h3) {
        var text = $h3.text().replace(/\s+/g, " ").trim();
        var code = "";
        var $code = $h3.find("label[id*='lblItem_Number']");
        if ($code.length) {
            code = $code.first().text().trim();
        }
        var desc = "";
        var $desc = $h3.find("label[id*='lblHeaderPanelTitle']");
        if ($desc.length) {
            desc = $desc.first().text().trim();
        }
        var qty = "";
        var $qty = $h3.find("span.HeaderText").parent();
        $h3.find("td").each(function () {
            var t = window.jQuery(this).text();
            if (t.indexOf("Quantity") >= 0 || t.match(/Qty/i)) {
                qty = t.replace(/.*?:\s*/, "").trim();
            }
        });
        var sub = "";
        var spans = $h3.find("span");
        spans.each(function () {
            var t = window.jQuery(this).text();
            if (t.indexOf("$") >= 0 && t.length < 20) {
                sub = t.trim();
            }
        });
        if (!code && text.length < 80) {
            code = text.substring(0, 30);
        }
        return { code: code, desc: desc, qty: qty, sub: sub, text: text };
    }

    function collectLineItemBlocks($acc) {
        var $ = window.jQuery;
        var $blocks = $acc.children(".sortingdivs[data-value='sortable']");
        if ($blocks.length) {
            return $blocks;
        }
        $blocks = $();
        $acc.find("h3[data-value='sortable']").each(function () {
            var $h = $(this);
            var $wrap = $h.closest(".sortingdivs");
            if ($wrap.length) {
                if ($blocks.index($wrap[0]) < 0) {
                    $blocks = $blocks.add($wrap[0]);
                }
            }
        });
        return $blocks;
    }

    function activateLineItemTab(idx) {
        if (!window.jQuery) {
            return;
        }
        var $ = window.jQuery;
        $("#eprintLineItemTabsNav button").removeClass("active");
        $("#eprintLineItemTabsNav button[data-line-index='" + idx + "']").addClass("active");
        $(".eprint-line-item-panel").hide().removeClass("active");
        var $active = $(".eprint-line-item-panel[data-line-index='" + idx + "']").show().addClass("active");
        try {
            window.sessionStorage.setItem("eprintLineItemTab", String(idx));
        } catch (e1) { /* ignore */ }
    }

    function setupLineItemTabs() {
        if (!window.jQuery) {
            return;
        }
        var $ = window.jQuery;
        var $acc = $("#accordion.eprint-perfect-items-accordion");
        var $nav = $("#eprintLineItemTabsNav");
        var $panelsWrap = $("#eprintLineItemPanels");
        var $totalsBody = $("#eprintAllItemsTotalsBody");
        if (!$acc.length || !$nav.length || !$panelsWrap.length || !$totalsBody.length) {
            return;
        }
        if ($acc.attr("data-eprint-tabs-built") === "1") {
            return;
        }

        if ($acc.data("accordion")) {
            try {
                $acc.accordion("destroy");
            } catch (e2) { /* ignore */ }
        }

        $nav.empty();
        $panelsWrap.empty();
        $totalsBody.empty();

        var $lineBlocks = collectLineItemBlocks($acc);
        var itemCount = $lineBlocks.length;
        var activeIdx = resolveLineItemIndex(itemCount);
        var savedLi = "";
        try {
            savedLi = window.sessionStorage.getItem("eprintLineItemTab") || "";
        } catch (e3) { /* ignore */ }
        if (savedLi !== "" && !isNaN(parseInt(savedLi, 10))) {
            var savedN = parseInt(savedLi, 10);
            if (savedN >= 0 && savedN < itemCount) {
                activeIdx = savedN;
            }
        }
        if (window.location.href.indexOf("EstItemID") >= 0 && itemCount > 0) {
            activeIdx = resolveLineItemIndex(itemCount);
        }

        var i;
        for (i = 0; i < itemCount; i++) {
            var $block = $($lineBlocks[i]).detach();
            var $h3 = $block.find("h3").first();
            var info = parseItemFromHeader($h3);
            var itemId = $block.attr("id") || ("li-" + i);

            var $btn = $("<button type='button'></button>");
            $btn.attr("data-line-index", String(i));
            $btn.attr("data-item-id", itemId);
            if (i === activeIdx) {
                $btn.addClass("active");
            }
            var tabLabel = info.code || "Item " + (i + 1);
            $btn.attr("title", tabLabel);
            $btn.append($("<span class='tab-code'></span>").text(tabLabel));
            (function (idx) {
                $btn.on("click", function (evt) {
                    evt.preventDefault();
                    activateLineItemTab(idx);
                });
            })(i);

            $h3.addClass("eprint-li-header-hidden");
            $block.children("table").first().addClass("eprint-li-legacy-header-hidden");

            var $panel = $("<div class='eprint-line-item-panel'></div>");
            $panel.attr("data-line-index", String(i));
            $panel.attr("data-item-id", itemId);
            if (i !== activeIdx) {
                $panel.hide();
            } else {
                $panel.addClass("active");
            }
            $panel.append($block);
            $nav.append($btn);
            $panelsWrap.append($panel);
        }

        var $remain = $acc.children().detach();
        $totalsBody.append($remain);
        $acc.find(".ui-accordion-content").appendTo($totalsBody);

        $acc.attr("data-eprint-tabs-built", "1");
        $("#eprintItemsSource").addClass("eprint-items-source-done");
        syncLineItemsKpi();
        restoreItemActionsRail(document.getElementById("eprintLineItemPanels") || document);
        releaseLineItemOverflowClipping(document.getElementById("eprintLineItemPanels") || document);
        normalizeGrossProfitRows(document.getElementById("eprintLineItemPanels") || document);
    }

    function setActiveTab(tabKey) {
        var root = getRoot();
        if (!root) {
            return;
        }
        tabKey = normalizeTabKey(tabKey);
        var buttons = root.querySelectorAll(".eprint-doc-tabs button");
        var panels = root.querySelectorAll(".eprint-panel");
        var i;
        for (i = 0; i < buttons.length; i++) {
            buttons[i].classList.toggle("active", buttons[i].getAttribute("data-tab") === tabKey);
        }
        for (i = 0; i < panels.length; i++) {
            panels[i].classList.toggle("active", panels[i].getAttribute("data-panel") === tabKey);
        }
        root.setAttribute("data-active-tab", tabKey);
        if (tabKey === "customer") {
            applyCustomerModuleFields();
            fixCustomerDetailsLayout();
        }
        if (tabKey === "items") {
            setupLineItemTabs();
        }
        try {
            window.sessionStorage.setItem("eprintSummaryTab", tabKey);
        } catch (e3) { /* ignore */ }
    }

    function bindTabs() {
        var root = getRoot();
        if (!root || root.getAttribute("data-tabs-bound")) {
            return;
        }
        root.setAttribute("data-tabs-bound", "1");
        root.addEventListener("click", function (evt) {
            var btn = evt.target && evt.target.closest ? evt.target.closest(".eprint-doc-tabs button") : null;
            if (!btn) {
                return;
            }
            var tab = btn.getAttribute("data-tab");
            if (tab) {
                setActiveTab(tab);
            }
        });
    }

    function updateItemCountBadge() {
        var badge = document.getElementById("eprintItemTabCount");
        if (!badge) {
            return;
        }
        badge.textContent = String(getLineItemCount());
    }

    function getStatusTriggerEl() {
        var root = getRoot();
        if (!root) {
            return document.querySelector("[id$='_ddlStatus']");
        }
        return root.querySelector("[id$='_ddlStatus']");
    }

    function getStatusMenuEl() {
        var root = getRoot();
        if (!root) {
            return document.querySelector("[id$='_Div_StatusList']");
        }
        return root.querySelector("[id$='_Div_StatusList']");
    }

    function layoutStatusMenuLinks(menu) {
        if (!menu || menu.getAttribute("data-eprint-links-stacked")) {
            return;
        }
        var links = menu.querySelectorAll("a");
        var i;
        for (i = 0; i < links.length; i++) {
            links[i].style.display = "block";
            links[i].style.width = "100%";
            links[i].style.boxSizing = "border-box";
            links[i].style.whiteSpace = "normal";
            links[i].style.marginBottom = "4px";
        }
        menu.setAttribute("data-eprint-links-stacked", "1");
    }

    function positionStatusMenu() {
        var menu = getStatusMenuEl();
        var trigger = getStatusTriggerEl();
        if (!menu || !trigger) {
            return;
        }
        layoutStatusMenuLinks(menu);
        var rect = trigger.getBoundingClientRect();
        menu.style.position = "fixed";
        menu.style.top = Math.round(rect.bottom + 6) + "px";
        menu.style.left = "auto";
        menu.style.right = Math.max(8, Math.round(window.innerWidth - rect.right)) + "px";
        menu.style.width = "260px";
        menu.style.minWidth = "240px";
        menu.style.maxWidth = "320px";
        menu.style.height = "auto";
        menu.style.minHeight = "0";
        menu.style.maxHeight = "min(380px, 70vh)";
        menu.style.overflowX = "hidden";
        menu.style.overflowY = "auto";
        menu.style.float = "none";
        menu.style.margin = "0";
        menu.style.padding = "8px";
        menu.style.zIndex = "10050";
        menu.style.display = "block";
        menu.classList.add("eprint-status-menu-open");
    }

    function hideStatusMenu() {
        var menu = getStatusMenuEl();
        if (!menu) {
            return;
        }
        menu.style.display = "none";
        menu.classList.remove("eprint-status-menu-open");
    }

    function getSideAccordionHeaderType(h1) {
        var id = h1.id || "";
        if (id.indexOf("AddSubItem_") === 0) {
            return 3;
        }
        if (id.indexOf("Action_") === 0) {
            return 1;
        }
        if (id.indexOf("QL_") === 0) {
            return 4;
        }
        return 0;
    }

    function getSideAccordionItemId(h1) {
        var id = h1.id || "";
        var parts = id.split("_");
        if (parts.length < 2) {
            return "";
        }
        return parts[parts.length - 1];
    }

    function syncSideAccordionArrows(h1, shouldOpen) {
        if (typeof window.rotatearrow !== "function") {
            return;
        }
        var header = getSideAccordionHeaderType(h1);
        var itemId = getSideAccordionItemId(h1);
        if (!header || !itemId) {
            return;
        }
        var suffix = header === 1 ? "1" : header === 3 ? "3" : "4";
        var imgdown = document.getElementById("imgdown" + suffix + "_" + itemId);
        var isOpen = imgdown && imgdown.style.display !== "none";
        if (shouldOpen && !isOpen) {
            window.rotatearrow(itemId, header);
        } else if (!shouldOpen && isOpen) {
            window.rotatearrow(itemId, header);
        }
    }

    function findSideAccordionList(h1) {
        var ul = h1.nextElementSibling;
        if (ul && ul.tagName === "UL") {
            return ul;
        }
        var hid = h1.id || "";
        var parts = hid.split("_");
        var itemId = parts.length > 1 ? parts[parts.length - 1] : "";
        if (hid.indexOf("AddSubItem_") === 0) {
            return document.getElementById("Ul7_" + itemId);
        }
        if (hid.indexOf("QL_") === 0) {
            return document.getElementById("Ul3_" + itemId);
        }
        if (hid.indexOf("Action_") === 0) {
            return document.getElementById("Ul5_" + itemId);
        }
        return null;
    }

    function toggleSideAccordionSection(h1) {
        var ul = findSideAccordionList(h1);
        if (!ul) {
            return;
        }
        var accordion = h1.closest(".eprint-estore-accordion, #estoreaccordion");
        if (!accordion) {
            return;
        }
        var wasHidden = window.getComputedStyle(ul).display === "none";
        var lists = accordion.querySelectorAll(":scope > li > ul");
        var i;
        for (i = 0; i < lists.length; i++) {
            lists[i].style.display = "none";
        }
        if (wasHidden) {
            ul.style.display = "block";
            syncSideAccordionArrows(h1, true);
        } else {
            syncSideAccordionArrows(h1, false);
        }
    }

    function getDocRailIcon(label) {
        var l = (label || "").toLowerCase();
        if (l.indexOf("job") >= 0) {
            return "\uD83D\uDCCB";
        }
        if (l.indexOf("invoice") >= 0) {
            return "\uD83E\uDDFE";
        }
        if (l.indexOf("delivery") >= 0) {
            return "\uD83D\uDE9A";
        }
        if (l.indexOf("purchase") >= 0 || l.indexOf("order") >= 0 && l.indexOf("purchase") >= 0) {
            return "\uD83D\uDCE6";
        }
        if (l.indexOf("proof") >= 0) {
            return "\uD83D\uDCEE";
        }
        if (l.indexOf("catalogue") >= 0 || l.indexOf("catalog") >= 0 || l.indexOf("product") >= 0) {
            return "\uD83C\uDFF7";
        }
        if (l.indexOf("estimate") >= 0) {
            return "\uD83D\uDCC4";
        }
        return "\u2022";
    }

    function extractRailLabel(el, rawText) {
        var html = el.innerHTML || "";
        var match = html.match(/>\s*([^<:]+?)\s*:\s*(?:<br\s*\/?>|&nbsp;)/i);
        if (match) {
            return normalizeRailLabel(match[1]);
        }
        match = (rawText || "").match(/^([^:]+):/);
        if (match) {
            return normalizeRailLabel(match[1]);
        }
        var lower = (rawText || "").toLowerCase();
        if (lower.indexOf("invoice") >= 0) {
            return "Invoice";
        }
        if (lower.indexOf("delivery") >= 0) {
            return "Delivery note";
        }
        if (lower.indexOf("purchase") >= 0) {
            return "Purchase order";
        }
        if (lower.indexOf("proof") >= 0) {
            return "Proofs";
        }
        if (lower.indexOf("catalogue") >= 0 || lower.indexOf("catalog") >= 0) {
            return "Catalogue";
        }
        if (/^job\s*:/i.test(rawText || "") || lower.indexOf("job") === 0 || lower === "job") {
            return "Job";
        }
        return normalizeRailLabel((rawText || "").split(/\s+/)[0]);
    }

    function isRailCatalogueRow(el) {
        var rawText = (el.textContent || "").replace(/\s+/g, " ").trim();
        var label = extractRailLabel(el, rawText);
        var l = (label || "").toLowerCase();
        if (l.indexOf("catalogue") >= 0 || l.indexOf("catalog") >= 0) {
            return true;
        }
        if (el.querySelector("a[onclick*='Open_ProductCatalogue']")) {
            return true;
        }
        return false;
    }

    function isStandardRailDocLabel(label) {
        var l = (label || "").toLowerCase();
        return l === "job" || l === "invoice" || l.indexOf("delivery") >= 0
            || l.indexOf("purchase") >= 0 || l.indexOf("proof") >= 0;
    }

    function extractRailDateSub(rawText) {
        var m = (rawText || "").match(/Date:\s*([0-9][0-9\/\-\.\s,]+)/i);
        return m ? m[1].trim() : "";
    }

    function isRailLiVisible(li) {
        if (!li || li.nodeType !== 1) {
            return false;
        }
        if (li.getAttribute("data-rail-force-hidden") === "1") {
            return false;
        }
        var st = window.getComputedStyle(li);
        if (st.display === "none" || st.visibility === "hidden") {
            return false;
        }
        return true;
    }

    function syncRailActionsSection(acc) {
        if (!acc) {
            return;
        }
        var cardActions = acc.querySelector(".eprint-rail-actions");
        if (!cardActions) {
            return;
        }
        var secActions = cardActions.closest(".eprint-rail-section");
        if (!secActions) {
            return;
        }
        var kids = cardActions.children;
        var anyVisible = false;
        var i;
        for (i = 0; i < kids.length; i++) {
            if (isRailLiVisible(kids[i])) {
                anyVisible = true;
                break;
            }
        }
        secActions.style.display = anyVisible ? "" : "none";
    }

    function relayoutMisplacedRailItems(acc) {
        var extra = acc.querySelector(".eprint-rail-extra");
        var cardActions = acc.querySelector(".eprint-rail-actions");
        var cardDocs = acc.querySelector(".eprint-rail-documents");
        var moved = [];
        if (extra) {
            moved = moved.concat(Array.prototype.slice.call(extra.children));
        }
        var topLi = acc.querySelectorAll(":scope > li");
        var t;
        for (t = 0; t < topLi.length; t++) {
            moved.push(topLi[t]);
        }
        if (!moved.length) {
            return;
        }
        var i;
        for (i = 0; i < moved.length; i++) {
            var li = moved[i];
            if (!li || li.tagName !== "LI") {
                continue;
            }
            var lid = li.id || "";
            if (lid.indexOf("liReRun") >= 0 && cardActions) {
                li.classList.add("eprint-rail-rerun");
                cardActions.appendChild(li);
            } else if ((lid.indexOf("liChangeFile") >= 0 || lid.indexOf("liManualApprove") >= 0 || lid.indexOf("liManualReject") >= 0) && cardActions) {
                li.classList.add("eprint-rail-proof-action");
                cardActions.appendChild(li);
            } else if (lid.indexOf("liaddItemhead") >= 0 && cardActions) {
                li.classList.add("eprint-rail-addsub");
                cardActions.appendChild(li);
            } else if (lid.indexOf("liQl") >= 0 && cardDocs) {
                li.classList.add("eprint-rail-documents-li");
                cardDocs.appendChild(li);
            }
        }
    }

    function transformRailDocuments(cardDocs) {
        if (!cardDocs) {
            return;
        }
        var liQl = cardDocs.querySelector(".eprint-rail-documents-li, [id$='liQl']");
        if (liQl && liQl.getAttribute("data-rail-flat") !== "1") {
            flattenQuickLinksMarkup(liQl);
        }
        var lists = cardDocs.querySelectorAll(".activity-list");
        var a;
        for (a = 0; a < lists.length; a++) {
            lists[a].removeAttribute("data-rail-transformed");
            lists[a].classList.remove("eprint-rail-doc-legacy", "eprint-rail-doc-empty");
            transformActivityListRow(lists[a]);
        }
        pruneEmptyRailRows(cardDocs);
        styleCatalogueBlocks(cardDocs);
    }

    function isActivityListEmpty(el) {
        var rawText = (el.textContent || "").replace(/\s+/g, " ").trim();
        var label = extractRailLabel(el, rawText);
        if (isStandardRailDocLabel(label)) {
            if (el.querySelector("a[onclick], a.create, a[id^='lnk'], input[type='submit'], button")) {
                return false;
            }
            var docAnchors = el.querySelectorAll("a");
            var da;
            for (da = 0; da < docAnchors.length; da++) {
                var docTxt = (docAnchors[da].textContent || "").replace(/\s+/g, " ").trim();
                if (docTxt && docTxt.toLowerCase() !== "create") {
                    return false;
                }
            }
            return true;
        }
        var anchors = el.querySelectorAll("a");
        var hasVisibleAction = false;
        var i;
        for (i = 0; i < anchors.length; i++) {
            var a = anchors[i];
            var t = (a.textContent || "").replace(/\s+/g, " ").trim();
            if (a.getAttribute("onclick") && !t) {
                a.textContent = "Create";
                t = "Create";
            }
            if (t.length > 0 && t.toLowerCase() !== "create") {
                hasVisibleAction = true;
                break;
            }
            if (t.toLowerCase() === "create" || a.classList.contains("create")) {
                hasVisibleAction = true;
                break;
            }
        }
        var inputs = el.querySelectorAll("input[type=button], input[type=submit], button");
        for (i = 0; i < inputs.length; i++) {
            var v = (inputs[i].value || inputs[i].textContent || "").replace(/\s+/g, " ").trim();
            if (v.length > 0) {
                hasVisibleAction = true;
                break;
            }
        }
        if (!hasVisibleAction) {
            if (/^[\w\s\-\/]+:\s*$/i.test(rawText)) {
                return !isStandardRailDocLabel(label);
            }
            if (/:\s*none\s*$/i.test(rawText)) {
                return true;
            }
            var stripped = rawText.replace(/^[\w\s\-\/]+:\s*/i, "").trim();
            if (!stripped || stripped === ":") {
                return !isStandardRailDocLabel(label);
            }
        }
        return false;
    }

    function normalizeRailLabel(text) {
        var label = (text || "").replace(/\s+/g, " ").trim();
        if (!label) {
            return "Document";
        }
        if (label.toLowerCase().indexOf("product") >= 0 && label.toLowerCase().indexOf("catalogue") >= 0) {
            return "Catalogue";
        }
        if (label.toLowerCase().indexOf("catalog") >= 0) {
            return "Catalogue";
        }
        if (label.toLowerCase().indexOf("proof") >= 0) {
            return "Proofs";
        }
        if (label.toLowerCase().indexOf("delivery") >= 0) {
            return "Delivery note";
        }
        if (label.toLowerCase().indexOf("purchase") >= 0) {
            return "Purchase order";
        }
        if (label.toLowerCase().indexOf("invoice") >= 0) {
            return "Invoice";
        }
        return label;
    }

    function buildRailDocRow(label, sub, createLink, docLinks) {
        var parts = [];
        var main = document.createElement("div");
        main.className = "eprint-rail-doc-main";

        var left = document.createElement("div");
        left.className = "eprint-rail-doc-left";
        var icon = document.createElement("span");
        icon.className = "eprint-rail-doc-icon";
        icon.setAttribute("aria-hidden", "true");
        icon.textContent = getDocRailIcon(label);
        var textWrap = document.createElement("div");
        var title = document.createElement("div");
        title.className = "eprint-rail-doc-title";
        title.textContent = normalizeRailLabel(label);
        textWrap.appendChild(title);
        left.appendChild(icon);
        left.appendChild(textWrap);
        main.appendChild(left);

        var chips = document.createElement("div");
        chips.className = "eprint-rail-doc-chips";
        if (createLink) {
            createLink.classList.add("eprint-rail-chip", "eprint-rail-chip-create");
            if (createLink.tagName === "INPUT" && !createLink.value) {
                createLink.value = "Create";
            }
            chips.appendChild(createLink);
        }
        var j;
        for (j = 0; j < docLinks.length; j++) {
            docLinks[j].classList.add("eprint-rail-chip", "eprint-rail-chip-link");
            chips.appendChild(docLinks[j]);
        }
        if (chips.childNodes.length) {
            main.appendChild(chips);
        }
        if (docLinks.length && !createLink) {
            main.classList.add("eprint-rail-doc-main--stacked");
        }
        parts.push(main);

        if (sub) {
            var subEl = document.createElement("div");
            subEl.className = "eprint-rail-doc-subline";
            subEl.textContent = sub;
            parts.push(subEl);
        }
        return parts;
    }

    function transformActivityListRow(el) {
        if (!el) {
            return;
        }
        if (el.getAttribute("data-rail-transformed") === "1" && el.classList.contains("eprint-rail-doc-row")) {
            return;
        }
        if (isRailCatalogueRow(el)) {
            el.classList.add("eprint-rail-doc-empty");
            return;
        }
        if (isActivityListEmpty(el)) {
            el.classList.add("eprint-rail-doc-empty");
            return;
        }

        var rawText = (el.textContent || "").replace(/\s+/g, " ").trim();
        var label = extractRailLabel(el, rawText);

        var createLink = null;
        var docLinks = [];
        var anchors = el.querySelectorAll("a");
        var j;
        for (j = 0; j < anchors.length; j++) {
            var a = anchors[j];
            var at = (a.textContent || "").replace(/\s+/g, " ").trim();
            if (!at && (a.getAttribute("onclick") || a.classList.contains("create") || (a.id || "").indexOf("lnk") === 0)) {
                a.textContent = "Create";
                at = "Create";
            }
            if (a.classList.contains("create") || at.toLowerCase() === "create" || (a.id || "").indexOf("lnkjobInvoice") >= 0 || (a.id || "").indexOf("lnk") === 0 && at.toLowerCase() === "create") {
                if (!createLink) {
                    createLink = a;
                }
                continue;
            }
            if (at && at.toLowerCase() !== "create") {
                docLinks.push(a);
            }
        }
        var submitBtns = el.querySelectorAll("input[type='submit']");
        for (j = 0; j < submitBtns.length; j++) {
            if (!createLink) {
                createLink = submitBtns[j];
            }
        }

        var sub = extractRailDateSub(rawText);
        if (!sub && !isStandardRailDocLabel(label)) {
            var alignDivs = el.querySelectorAll("div[align='left'], div[align=\"left\"]");
            if (alignDivs.length >= 1) {
                sub = (alignDivs[0].textContent || "").replace(":", "").trim();
            }
        }
        if (sub && docLinks.length) {
            var dl;
            for (dl = 0; dl < docLinks.length; dl++) {
                var linkTxt = (docLinks[dl].textContent || "").replace(/\s+/g, " ").trim();
                if (linkTxt && sub.indexOf(linkTxt) >= 0) {
                    sub = extractRailDateSub(rawText);
                    break;
                }
            }
        }

        var hiddenInputs = el.querySelectorAll("input[type='hidden']");
        var hiddenNodes = [];
        for (j = 0; j < hiddenInputs.length; j++) {
            hiddenNodes.push(hiddenInputs[j]);
        }
        if (createLink && createLink.parentNode) {
            createLink.parentNode.removeChild(createLink);
        }
        for (j = 0; j < docLinks.length; j++) {
            if (docLinks[j].parentNode) {
                docLinks[j].parentNode.removeChild(docLinks[j]);
            }
        }
        for (j = 0; j < hiddenNodes.length; j++) {
            if (hiddenNodes[j].parentNode) {
                hiddenNodes[j].parentNode.removeChild(hiddenNodes[j]);
            }
        }
        while (el.firstChild) {
            el.removeChild(el.firstChild);
        }

        var parts = buildRailDocRow(label, sub, createLink, docLinks);
        el.className = "eprint-rail-doc-row activity-list";
        if (docLinks.length) {
            el.classList.add("eprint-rail-doc-row--has-link");
        }
        for (j = 0; j < parts.length; j++) {
            el.appendChild(parts[j]);
        }
        for (j = 0; j < hiddenNodes.length; j++) {
            hiddenNodes[j].style.display = "none";
            el.appendChild(hiddenNodes[j]);
        }
        el.setAttribute("data-rail-transformed", "1");
    }

    function flattenQuickLinksMarkup(liQl) {
        if (!liQl || liQl.getAttribute("data-rail-flat") === "1") {
            return;
        }
        liQl.setAttribute("data-rail-flat", "1");
        var inner = document.createElement("div");
        inner.className = "eprint-rail-documents-inner";
        var h1 = liQl.querySelector("h1[id^='QL_']");
        if (h1) {
            h1.style.display = "none";
        }
        var ul = liQl.querySelector("ul[id^='Ul3_']");
        if (ul) {
            while (ul.firstChild) {
                inner.appendChild(ul.firstChild);
            }
            ul.parentNode.removeChild(ul);
        }
        var divQl = liQl.querySelector("[id^='divqlItems']");
        if (divQl) {
            while (divQl.firstChild) {
                inner.appendChild(divQl.firstChild);
            }
            divQl.parentNode.removeChild(divQl);
        }
        Array.prototype.slice.call(liQl.childNodes).forEach(function (node) {
            if (node.nodeType !== 1) {
                return;
            }
            if (node === inner || node.classList.contains("eprint-rail-documents-inner")) {
                return;
            }
            if (node.tagName === "H1") {
                node.style.display = "none";
                return;
            }
            if (node.tagName === "UL") {
                while (node.firstChild) {
                    inner.appendChild(node.firstChild);
                }
                node.parentNode.removeChild(node);
                return;
            }
            inner.appendChild(node);
        });
        liQl.appendChild(inner);
    }

    function styleCatalogueBlocks(container) {
        var kids = container.querySelectorAll(".eprint-rail-documents-inner > div");
        var i;
        for (i = 0; i < kids.length; i++) {
            var ch = kids[i];
            if (ch.classList.contains("activity-list") || ch.classList.contains("eprint-rail-doc-row")) {
                continue;
            }
            if ((ch.textContent || "").toLowerCase().indexOf("catalogue") >= 0
                || ch.querySelector("a[onclick*='Open_ProductCatalogue']")) {
                ch.classList.add("eprint-rail-doc-empty");
                continue;
            }
            if (ch.querySelector("div[align]")) {
                ch.classList.add("eprint-rail-doc-legacy");
            }
        }
    }

    function pruneEmptyRailRows(container) {
        var rows = container.querySelectorAll(".activity-list");
        var i;
        for (i = 0; i < rows.length; i++) {
            if (rows[i].classList.contains("eprint-rail-doc-row") || rows[i].classList.contains("eprint-rail-doc-legacy")) {
                if (isActivityListEmpty(rows[i]) && !rows[i].querySelector(".eprint-rail-chip-link")) {
                    rows[i].classList.add("eprint-rail-doc-empty");
                }
                continue;
            }
            if (isActivityListEmpty(rows[i])) {
                rows[i].classList.add("eprint-rail-doc-empty");
            }
        }
    }

    function bindAddSubItemToggle(panel) {
        var addSub = panel.querySelector(".eprint-rail-addsub");
        if (!addSub || addSub.getAttribute("data-rail-toggle-bound") === "1") {
            return;
        }
        var hd = addSub.querySelector("h1[id^='AddSubItem_']");
        if (!hd) {
            return;
        }
        addSub.setAttribute("data-rail-toggle-bound", "1");
        hd.addEventListener("click", function (evt) {
            evt.preventDefault();
            evt.stopImmediatePropagation();
            addSub.classList.toggle("eprint-rail-open");
        }, true);
    }

    /** Undo item rail redesign — restore legacy #estoreaccordion quick links markup */
    function restoreItemActionsRail(rootScope) {
        var panels = rootScope
            ? (rootScope.classList && rootScope.classList.contains("eprint-line-item-panel")
                ? [rootScope]
                : rootScope.querySelectorAll
                    ? rootScope.querySelectorAll(".eprint-line-item-panel")
                    : [])
            : document.querySelectorAll(".eprint-perfect-summary .eprint-line-item-panel, .eprint-line-item-panel");

        var railOrder = ["liChangeFile", "RCM_Options", "liaddItemhead", "liReRun", "liQl", "liViewJobAllocation", "liViewHistory"];
        var p;
        for (p = 0; p < panels.length; p++) {
            var acc = panels[p].querySelector("#estoreaccordion");
            if (!acc || (acc.getAttribute("data-eprint-rail-enhanced") !== "1" && !acc.querySelector(".eprint-item-rail"))) {
                continue;
            }

            var rail = acc.querySelector(".eprint-item-rail");
            var extra = acc.querySelector(".eprint-rail-extra");
            var cardActions = acc.querySelector(".eprint-rail-actions");
            var cardDocs = acc.querySelector(".eprint-rail-documents");
            var collected = [];
            var sources = [cardActions, cardDocs, extra, rail];
            var s;
            for (s = 0; s < sources.length; s++) {
                if (!sources[s]) {
                    continue;
                }
                var ch = sources[s].children;
                var i;
                for (i = 0; i < ch.length; i++) {
                    if (ch[i].tagName === "LI") {
                        collected.push(ch[i]);
                    }
                }
            }

            var li;
            for (li = 0; li < collected.length; li++) {
                var node = collected[li];
                node.classList.remove(
                    "eprint-rail-rerun", "eprint-rail-addsub", "eprint-rail-documents-li",
                    "eprint-rail-proof-action", "eprint-rail-open"
                );
                node.removeAttribute("data-rail-toggle-bound");
                node.style.display = "";
            }

            var liQl = null;
            var c;
            for (c = 0; c < collected.length; c++) {
                if ((collected[c].id || "").indexOf("liQl") >= 0) {
                    liQl = collected[c];
                    break;
                }
            }
            if (liQl) {
                var inner = liQl.querySelector(".eprint-rail-documents-inner");
                if (inner) {
                    var h1 = liQl.querySelector("h1[id^='QL_']");
                    if (h1) {
                        h1.style.display = "";
                    }
                    var host = liQl.querySelector("[id^='divqlItems']");
                    if (!host) {
                        host = document.createElement("div");
                        host.id = "divqlItems";
                        host.setAttribute("align", "left");
                        liQl.appendChild(host);
                    }
                    while (inner.firstChild) {
                        host.appendChild(inner.firstChild);
                    }
                    inner.parentNode.removeChild(inner);
                }
                liQl.removeAttribute("data-rail-flat");
            }

            var ordered = [];
            var o;
            for (o = 0; o < railOrder.length; o++) {
                var key = railOrder[o];
                var f;
                for (f = 0; f < collected.length; f++) {
                    if ((collected[f].id || "").indexOf(key) >= 0 && ordered.indexOf(collected[f]) < 0) {
                        ordered.push(collected[f]);
                    }
                }
            }
            for (o = 0; o < collected.length; o++) {
                if (ordered.indexOf(collected[o]) < 0) {
                    ordered.push(collected[o]);
                }
            }

            if (rail) {
                rail.parentNode.removeChild(rail);
            }
            if (extra) {
                extra.parentNode.removeChild(extra);
            }
            for (o = 0; o < ordered.length; o++) {
                acc.appendChild(ordered[o]);
            }
            acc.removeAttribute("data-eprint-rail-enhanced");
        }
    }

    function enhanceItemActionsRail(rootScope) {
        restoreItemActionsRail(rootScope);
    }

    function bindLineItemSideAccordion() {
        if (window._eprintSideAccordionBound) {
            return;
        }
        window._eprintSideAccordionBound = true;

        if (window.jQuery) {
            window.jQuery(document).off("click.eprintSideAccordion", ".eprint-estore-accordion > li > h1, #estoreaccordion > li > h1");
            window.jQuery(".eprint-estore-accordion > li > h1, #estoreaccordion > li > h1").off("click");
        }

        document.addEventListener("click", function (evt) {
            var h1 = evt.target && evt.target.closest
                ? evt.target.closest(".eprint-estore-accordion > li > h1, #estoreaccordion > li > h1")
                : null;
            if (!h1) {
                return;
            }
            var hid = h1.id || "";
            if (hid.indexOf("AddSubItem_") === 0 || hid.indexOf("QL_") === 0 || hid.indexOf("Action_") === 0) {
                evt.preventDefault();
                evt.stopImmediatePropagation();
                toggleSideAccordionSection(h1);
                return;
            }
            if (h1.closest(".eprint-rail-addsub, .eprint-rail-documents")) {
                return;
            }
            evt.preventDefault();
            evt.stopImmediatePropagation();
            toggleSideAccordionSection(h1);
        }, true);
    }

    function bindDocumentStatusDropdown() {
        var root = getRoot();
        if (!root || root.getAttribute("data-status-bound")) {
            return;
        }
        var trigger = getStatusTriggerEl();
        var menu = getStatusMenuEl();
        if (!trigger || !menu) {
            return;
        }
        root.setAttribute("data-status-bound", "1");
        layoutStatusMenuLinks(menu);

        window.eprintGetStatusListEl = getStatusMenuEl;

        window.OpenStatus = function () {
            positionStatusMenu();
        };

        window.CloseStatus = function () {
            hideStatusMenu();
        };

        trigger.addEventListener("mouseenter", window.OpenStatus);
        trigger.addEventListener("mouseleave", function (e) {
            if (!menu.contains(e.relatedTarget)) {
                window.CloseStatus();
            }
        });
        menu.addEventListener("mouseenter", window.OpenStatus);
        menu.addEventListener("mouseleave", function (e) {
            if (!trigger.contains(e.relatedTarget)) {
                window.CloseStatus();
            }
        });
    }

    function ensureRootVisible() {
        var root = getRoot();
        if (root) {
            root.style.display = "block";
            root.style.visibility = "visible";
        }
        var legacyTabs = document.getElementById("tabs");
        if (legacyTabs && legacyTabs.classList.contains("eprint-legacy-tabs-hook")) {
            legacyTabs.style.height = "1px";
            legacyTabs.style.overflow = "hidden";
            legacyTabs.style.visibility = "hidden";
        }
    }

    function lockSummaryFinancialFields(scope) {
        var root = scope || getRoot() || document;
        if (!root.querySelectorAll) {
            return;
        }
        var selectors = [
            "input[id^='txtQtydesc']",
            "input[id^='txtProfitMarginPercentage']",
            "input[id^='txtProfitMarginPrice']",
            "input[id^='txtSubTotal']"
        ];
        var nodes = root.querySelectorAll(selectors.join(","));
        var i;
        for (i = 0; i < nodes.length; i++) {
            var inp = nodes[i];
            if (inp.id && inp.id.indexOf("txtSubTotal_PricePerUnit") >= 0) {
                continue;
            }
            inp.readOnly = true;
            inp.setAttribute("readonly", "readonly");
            inp.removeAttribute("disabled");
            inp.classList.add("eprint-field-readonly");
            inp.style.cursor = "default";
        }
    }

    /** Legacy markup wraps each line item in overflow:hidden, which clips the gross-profit % row. */
    function releaseLineItemOverflowClipping(scope) {
        var root = scope || getRoot() || document;
        if (!root || !root.querySelectorAll) {
            return;
        }
        var wrappers = root.querySelectorAll(".eprint-line-item-panel > .sortingdivs > div");
        var i;
        for (i = 0; i < wrappers.length; i++) {
            var el = wrappers[i];
            var inline = el.getAttribute("style") || "";
            if (/overflow\s*:\s*hidden/i.test(inline)) {
                el.style.overflow = "visible";
            }
            el.style.maxWidth = "100%";
        }
    }

    /** Stack dollar + percent in a flex column (float layout collapses table row height). */
    function normalizeGrossProfitRows(scope) {
        var root = scope || getRoot() || document;
        if (!root || !root.querySelectorAll) {
            return;
        }
        var rows = root.querySelectorAll("#tblTotal tr#trGrossProfit");
        var r;
        for (r = 0; r < rows.length; r++) {
            var cells = rows[r].querySelectorAll("td:not(#td36):not(#tdborder)");
            var c;
            for (c = 0; c < cells.length; c++) {
                var td = cells[c];
                if (td.querySelector(".eprint-gp-stack")) {
                    continue;
                }
                var divs = td.querySelectorAll(":scope > div");
                if (!divs.length) {
                    continue;
                }
                var stack = document.createElement("div");
                stack.className = "eprint-gp-stack";
                var d;
                for (d = 0; d < divs.length; d++) {
                    stack.appendChild(divs[d]);
                }
                td.appendChild(stack);
            }
        }
    }

    function normalizeSummarySaveButtons(scope) {
        var root = scope || getRoot() || document;
        var panels = root.querySelectorAll
            ? root.querySelectorAll(".eprint-line-item-panel, .sortingdivs[data-value='sortable']")
            : [];
        var p;
        for (p = 0; p < panels.length; p++) {
            var panel = panels[p];
            var itemId = panel.id || "";
            if (!itemId) {
                var stayDiv = panel.querySelector('[id^="div_btnstay_"]');
                if (stayDiv && stayDiv.id) {
                    itemId = stayDiv.id.replace("div_btnstay_", "");
                }
            }
            if (!itemId) {
                continue;
            }
            var descTable = panel.querySelector('table[id^="tblDescription"]');
            if (!descTable) {
                continue;
            }
            var saveBar = panel.querySelector("#summarySaveBar_" + itemId + ", .eprint-summary-save-bar");
            var footer = panel.querySelector(".summaryFooter");
            var stayHost = panel.querySelector("#div_btnstay_" + itemId);
            if (!saveBar && footer && stayHost) {
                saveBar = document.createElement("div");
                saveBar.className = "eprint-summary-save-bar";
                saveBar.id = "summarySaveBar_" + itemId;
                var wrap = document.createElement("div");
                wrap.style.cssText = "float:right;text-align:right;";
                while (footer.firstChild) {
                    wrap.appendChild(footer.firstChild);
                }
                saveBar.appendChild(wrap);
                descTable.parentNode.insertBefore(saveBar, descTable);
                footer.style.display = "none";
            }
            if (saveBar && descTable && saveBar.nextElementSibling !== descTable) {
                descTable.parentNode.insertBefore(saveBar, descTable);
            }
            var closeContainers = panel.querySelectorAll('[id^="div_btnsave_"], [id$="_btnSave"]');
            var c;
            for (c = 0; c < closeContainers.length; c++) {
                closeContainers[c].style.display = "none";
            }
            var buttons = panel.querySelectorAll(
                ".eprint-summary-save-bar input.button, .eprint-summary-save-bar button.button, " +
                ".summaryFooter input.button, .summaryFooter button.button"
            );
            var b;
            for (b = 0; b < buttons.length; b++) {
                var btn = buttons[b];
                var label = (btn.value || btn.textContent || "").replace(/\s+/g, " ").trim();
                if (/save\s*&\s*close/i.test(label)) {
                    btn.style.display = "none";
                    if (btn.parentElement) {
                        btn.parentElement.style.display = "none";
                    }
                    continue;
                }
                if (/save/i.test(label)) {
                    if (btn.tagName === "INPUT") {
                        btn.value = "Save";
                    } else {
                        btn.textContent = "Save";
                    }
                }
            }
        }
    }

    function init() {
        ensureRootVisible();
        var root = getRoot();
        if (!root) {
            return;
        }
        syncBadge();
        syncHeaderMeta();
        buildKpis();
        syncFooterTotals();
        fixCustomerDetailsLayout();
        bindTabs();
        bindDocumentStatusDropdown();
        setupLineItemTabs();
        enhanceItemActionsRail();
        bindLineItemSideAccordion();
        if (typeof window.initAddSubItemDropdown === "function") {
            window.initAddSubItemDropdown();
        }
        normalizeSummarySaveButtons(root);
        releaseLineItemOverflowClipping(root);
        normalizeGrossProfitRows(root);
        lockSummaryFinancialFields(root);
        updateItemCountBadge();

        if (!root.getAttribute("data-active-tab")) {
            root.setAttribute("data-active-tab", "customer");
        }
        if (!root.getAttribute("data-initialized")) {
            root.setAttribute("data-initialized", "1");
            var saved = "";
            try {
                saved = normalizeTabKey(window.sessionStorage.getItem("eprintSummaryTab") || "");
            } catch (e5) { /* ignore */ }
            if (window.location.href.indexOf("EstItemID") >= 0) {
                setActiveTab("items");
            } else if (saved && root.querySelector(".eprint-panel[data-panel=\"" + saved + "\"]")) {
                setActiveTab(saved);
            } else {
                setActiveTab("customer");
            }
        } else if (!root.querySelector(".eprint-panel.active")) {
            setActiveTab("customer");
        }

        if (!window._eprintPerfectStatusInterval) {
            window._eprintPerfectStatusInterval = window.setInterval(syncStatusKpi, 2000);
        }

        if (!window._eprintPerfectDelayedInit) {
            window._eprintPerfectDelayedInit = true;
            window.setTimeout(function () {
                setupLineItemTabs();
                restoreItemActionsRail();
                buildKpis();
                syncLineItemsKpi();
                fixCustomerDetailsLayout();
                bindDocumentStatusDropdown();
                normalizeSummarySaveButtons(getRoot());
                releaseLineItemOverflowClipping(getRoot());
                normalizeGrossProfitRows(getRoot());
                lockSummaryFinancialFields(getRoot());
            }, 400);
        }
    }

    window.eprintPerfectSummary = {
        init: init,
        setActiveTab: setActiveTab,
        setupLineItemTabs: setupLineItemTabs,
        activateLineItemTab: activateLineItemTab,
        patchAccordion: setupLineItemTabs,
        bindLineItemSideAccordion: bindLineItemSideAccordion,
        restoreItemActionsRail: restoreItemActionsRail,
        enhanceItemActionsRail: restoreItemActionsRail,
        releaseLineItemOverflowClipping: releaseLineItemOverflowClipping,
        normalizeGrossProfitRows: normalizeGrossProfitRows
    };

    function bindPrm() {
        if (typeof Sys === "undefined" || !Sys.WebForms || !Sys.WebForms.PageRequestManager) {
            return;
        }
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm._eprintPerfectSummaryBound) {
            return;
        }
        prm._eprintPerfectSummaryBound = true;
        prm.add_endRequest(function () {
            if (window.jQuery) {
                window.jQuery("#accordion.eprint-perfect-items-accordion").removeAttr("data-eprint-tabs-built");
                window.jQuery("#estoreaccordion").removeAttr("data-eprint-rail-enhanced data-rail-flat");
            }
            init();
        });
    }

    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", function () {
            init();
            bindPrm();
        });
    } else {
        init();
        bindPrm();
    }
})(window);

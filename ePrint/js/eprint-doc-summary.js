/* Estimate / Job / Order / Invoice summary — Variant A tab layout */
(function (window) {
    "use strict";

    var TAB_META = {
        overview: { title: "Overview", sub: "document", meta: "Summary at a glance" },
        items: { title: "Line items", sub: "document", meta: "Edit, reorder, expand details" },
        customer: { title: "Customer details", sub: "customer", meta: "Billing and delivery" },
        attachments: { title: "Attachments", sub: "document", meta: "Files and proofs" },
        activity: { title: "Activity", sub: "document", meta: "Notes and history" }
    };

    function getRoot() {
        return document.getElementById("eprintDocSummaryRoot");
    }

    function getAccordionIndex() {
        var hdn = document.querySelector("[id$='_hdnaccordionIndex']");
        if (!hdn || !hdn.value) {
            return 0;
        }
        var idx = parseInt(hdn.value, 10);
        if (isNaN(idx)) {
            return 0;
        }
        /* Legacy: index 0 = customer panel; line items started at 1 */
        return idx <= 0 ? 0 : idx - 1;
    }

    function resolveActivateIndex($accordion) {
        var headers = $accordion.find("h3");
        var idx = getAccordionIndex();
        if (idx >= headers.length) {
            idx = Math.max(0, headers.length - 1);
        }
        return idx;
    }

    function markTotalsHeader($accordion) {
        $accordion.find("h3").each(function () {
            var $h = window.jQuery(this);
            if ($h.attr("data-value") === "sortable") {
                return;
            }
            var text = $h.text() || "";
            if (text.indexOf("All Items") >= 0 || text.indexOf("All_Items") >= 0) {
                $h.addClass("eprint-doc-totals-header");
            }
        });
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
        mod = (mod || "document").toString();
        badge.textContent = mod.charAt(0).toUpperCase() + mod.slice(1);
    }

    function syncHero(tabKey, companyName) {
        var meta = TAB_META[tabKey] || TAB_META.overview;
        var titleEl = document.getElementById("eprintDocHeroTitle");
        var subEl = document.getElementById("eprintDocHeroSub");
        var metaEl = document.getElementById("eprintDocHeroMeta");
        if (!titleEl) {
            return;
        }
        var modLabel = (document.getElementById("eprintDocBadge") || {}).textContent || "Document";
        titleEl.textContent = meta.title;
        if (subEl) {
            subEl.textContent = meta.sub === "customer" && companyName
                ? companyName
                : modLabel + (companyName ? " · " + companyName : "");
        }
        if (metaEl) {
            metaEl.textContent = meta.meta;
        }
    }

    function buildKpis() {
        var row = document.getElementById("eprintDocKpiRow");
        if (!row) {
            return;
        }
        var totalEl = document.getElementById("TabSellingPrice");
        var totalText = totalEl ? (totalEl.textContent || "").trim() : "—";
        var itemCount = 0;
        var acc = document.getElementById("accordion");
        if (acc) {
            var sortable = acc.querySelectorAll("h3[data-value='sortable']");
            itemCount = sortable ? sortable.length : 0;
        }
        row.innerHTML =
            "<div class=\"eprint-doc-kpi\"><label>Subtotal (ex tax)</label><div class=\"val\">" + escapeHtml(totalText) + "</div></div>" +
            "<div class=\"eprint-doc-kpi\"><label>Line items</label><div class=\"val\">" + itemCount + "</div></div>" +
            "<div class=\"eprint-doc-kpi\"><label>Document</label><div class=\"val\">" + escapeHtml((document.getElementById("eprintDocBadge") || {}).textContent || "") + "</div></div>";
    }

    function escapeHtml(s) {
        return String(s)
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;");
    }

    function getCompanyName() {
        var labels = document.querySelectorAll("[id$='_LblCompanyName']");
        for (var i = 0; i < labels.length; i++) {
            var t = (labels[i].textContent || "").trim();
            if (t) {
                return t;
            }
        }
        return "";
    }

    function setActiveTab(tabKey) {
        var root = getRoot();
        if (!root) {
            return;
        }
        var buttons = root.querySelectorAll(".eprint-doc-nav button");
        var panels = root.querySelectorAll(".eprint-doc-panel");
        var i;
        for (i = 0; i < buttons.length; i++) {
            buttons[i].classList.toggle("active", buttons[i].getAttribute("data-tab") === tabKey);
        }
        for (i = 0; i < panels.length; i++) {
            panels[i].classList.toggle("active", panels[i].getAttribute("data-panel") === tabKey);
        }
        syncHero(tabKey, getCompanyName());
        if (tabKey === "items" && window.jQuery) {
            var $acc = window.jQuery("#accordion.eprint-doc-items-accordion");
            if ($acc.length && $acc.data("accordion")) {
                try {
                    $acc.accordion("resize");
                } catch (e1) { /* ignore */ }
            }
        }
    }

    function bindTabs() {
        var root = getRoot();
        if (!root || root.getAttribute("data-tabs-bound")) {
            return;
        }
        root.setAttribute("data-tabs-bound", "1");
        root.addEventListener("click", function (evt) {
            var btn = evt.target && evt.target.closest ? evt.target.closest(".eprint-doc-nav button") : null;
            if (!btn) {
                return;
            }
            var tab = btn.getAttribute("data-tab");
            if (tab) {
                setActiveTab(tab);
            }
        });
        var goItems = document.getElementById("eprintDocGoItems");
        if (goItems) {
            goItems.addEventListener("click", function () {
                setActiveTab("items");
            });
        }
    }

    function patchAccordionActivate() {
        if (!window.jQuery || !window.jQuery.fn.accordion) {
            return;
        }
        var $accordion = window.jQuery("#accordion.eprint-doc-items-accordion");
        if (!$accordion.length) {
            return;
        }
        markTotalsHeader($accordion);
        var idx = resolveActivateIndex($accordion);
        if ($accordion.data("accordion")) {
            try {
                $accordion.accordion("activate", idx);
            } catch (e2) {
                /* ignore */
            }
        }
    }

    function syncStatusMirror() {
        var mirror = document.getElementById("eprintDocStatusMirror");
        var statusLabel = document.querySelector("[id$='_lblStatusTitle']");
        if (!mirror || !statusLabel) {
            return;
        }
        var text = (statusLabel.textContent || "").trim();
        mirror.textContent = text ? " · " + text : "";
    }

    function init() {
        var root = getRoot();
        if (!root) {
            return;
        }
        syncBadge();
        syncStatusMirror();
        buildKpis();
        bindTabs();
        if (!root.getAttribute("data-initialized")) {
            root.setAttribute("data-initialized", "1");
            setActiveTab("overview");
        }
        patchAccordionActivate();
    }

    window.eprintDocSummary = {
        init: init,
        setActiveTab: setActiveTab,
        patchAccordionActivate: patchAccordionActivate
    };

    function bindPrm() {
        if (typeof Sys === "undefined" || !Sys.WebForms || !Sys.WebForms.PageRequestManager) {
            return;
        }
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm._eprintDocSummaryBound) {
            return;
        }
        prm._eprintDocSummaryBound = true;
        prm.add_endRequest(function () {
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

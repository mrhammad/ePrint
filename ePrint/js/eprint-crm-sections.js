/* Option 4 — CRM section pilots (all tabs) */
(function (window) {
    "use strict";

    function getSectionRoot(sectionKey) {
        if (!sectionKey) {
            return document.querySelector(".eprint-crm-section-pilot-root:not([style*='display: none'])") ||
                document.querySelector(".eprint-crm-section-pilot-root");
        }
        return document.querySelector('.eprint-crm-section-pilot-root[data-crm-section="' + sectionKey + '"]') ||
            (sectionKey === "contacts" ? document.querySelector(".eprint-crm-contacts-pilot-root") : null);
    }

    function isVisible(el) {
        if (!el) {
            return false;
        }
        return el.offsetParent !== null || (el.getClientRects && el.getClientRects().length > 0);
    }

    function syncCompanyName(root) {
        var target = root.querySelector(".eprint-crm-section-company, .eprint-crm-contacts-company");
        if (!target) {
            return;
        }
        var titleLabel = document.querySelector("[id$='_lbltitlecompanyname']");
        if (titleLabel && titleLabel.textContent) {
            target.textContent = titleLabel.textContent.trim();
        }
    }

    function findGrid(root) {
        return root.querySelector(".eprint-crm-section-grid") ||
            root.querySelector(".eprint-crm-contacts-grid") ||
            root.querySelector(".RadGrid") ||
            root.querySelector("[id*='RadGrid']") ||
            root.querySelector("[id*='grdcostcentre']");
    }

    function parseGridCount(grid) {
        if (!grid) {
            return null;
        }
        var statusParts = grid.querySelectorAll(".rgInfoPart, .rgPager .rgInfo");
        var i, text, match;
        for (i = 0; i < statusParts.length; i++) {
            text = (statusParts[i].textContent || "").replace(/\s+/g, " ");
            match = text.match(/(\d+)\s+items?/i);
            if (match) {
                return parseInt(match[1], 10);
            }
        }
        var rows = grid.querySelectorAll(".rgMasterTable .rgRow, .rgMasterTable .rgAltRow");
        var visible = 0;
        for (i = 0; i < rows.length; i++) {
            if (!rows[i].classList.contains("eprint-crm-section-row-hidden") &&
                !rows[i].classList.contains("eprint-crm-contacts-row-hidden")) {
                visible++;
            }
        }
        return visible;
    }

    function updateCount(root) {
        var countEl = root.querySelector(".eprint-crm-section-count, .eprint-crm-contacts-count");
        if (!countEl) {
            return;
        }
        var grid = findGrid(root);
        var count = parseGridCount(grid);
        if (count !== null) {
            countEl.textContent = String(count);
        }
    }

    function applyGridQuickSearch(root, query) {
        var grid = findGrid(root);
        if (!grid) {
            return false;
        }
        var q = (query || "").toLowerCase().trim();
        var rows = grid.querySelectorAll(".rgMasterTable .rgRow, .rgMasterTable .rgAltRow");
        var i, row, text;
        for (i = 0; i < rows.length; i++) {
            row = rows[i];
            if (!q) {
                row.classList.remove("eprint-crm-section-row-hidden");
                row.classList.remove("eprint-crm-contacts-row-hidden");
                continue;
            }
            text = (row.textContent || "").toLowerCase();
            if (text.indexOf(q) >= 0) {
                row.classList.remove("eprint-crm-section-row-hidden");
                row.classList.remove("eprint-crm-contacts-row-hidden");
            } else {
                row.classList.add("eprint-crm-section-row-hidden");
                row.classList.add("eprint-crm-contacts-row-hidden");
            }
        }
        return true;
    }

    function applyFormQuickSearch(root, query) {
        var inner = root.querySelector(".eprint-crm-section-form-inner") || root.querySelector(".eprint-crm-section-body-card--form");
        if (!inner) {
            return false;
        }
        var q = (query || "").toLowerCase().trim();
        var blocks = inner.querySelectorAll("tr, .divpadding, fieldset, table.border");
        if (blocks.length === 0) {
            blocks = inner.querySelectorAll("div, table");
        }
        var i, block, text;
        for (i = 0; i < blocks.length; i++) {
            block = blocks[i];
            if (block.closest(".eprint-crm-section-toolbar")) {
                continue;
            }
            if (!q) {
                block.classList.remove("eprint-crm-section-filter-hidden");
                continue;
            }
            text = (block.textContent || "").toLowerCase();
            if (text.indexOf(q) >= 0 && text.length < 800) {
                block.classList.remove("eprint-crm-section-filter-hidden");
            } else if (block.tagName === "TR" || block.classList.contains("divpadding")) {
                block.classList.add("eprint-crm-section-filter-hidden");
            }
        }
        return true;
    }

    function applyQuickSearch(root, query) {
        if (applyGridQuickSearch(root, query)) {
            updateCount(root);
            return;
        }
        applyFormQuickSearch(root, query);
    }

    function bindQuickSearch(root) {
        var input = root.querySelector(".eprint-crm-section-search, .eprint-crm-contacts-search");
        if (!input || input.getAttribute("data-bound")) {
            return;
        }
        input.setAttribute("data-bound", "1");
        input.addEventListener("input", function () {
            applyQuickSearch(root, input.value);
        });
        input.addEventListener("search", function () {
            applyQuickSearch(root, input.value);
        });
    }

    function refreshSection(sectionKey) {
        var root = getSectionRoot(sectionKey);
        if (!root || !isVisible(root)) {
            return;
        }
        syncCompanyName(root);
        bindQuickSearch(root);
        var input = root.querySelector(".eprint-crm-section-search, .eprint-crm-contacts-search");
        if (input && (sectionKey === "client" || sectionKey === "address")) {
            input.value = "";
        }
        applyQuickSearch(root, input ? input.value : "");
        updateCount(root);
    }

    function refreshVisible() {
        var roots = document.querySelectorAll(".eprint-crm-section-pilot-root, .eprint-crm-contacts-pilot-root");
        var i;
        for (i = 0; i < roots.length; i++) {
            if (isVisible(roots[i])) {
                refreshSection(roots[i].getAttribute("data-crm-section"));
            }
        }
    }

    function bindPrm() {
        if (typeof Sys === "undefined" || !Sys.WebForms || !Sys.WebForms.PageRequestManager) {
            return;
        }
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm._eprintCrmSectionsBound) {
            return;
        }
        prm._eprintCrmSectionsBound = true;
        prm.add_endRequest(function () {
            refreshVisible();
        });
    }

    window.eprintCrmSections = {
        refresh: refreshSection,
        refreshVisible: refreshVisible
    };

    window.eprintCrmContacts = {
        refresh: function () {
            refreshSection("contacts");
        },
        applyQuickSearch: function (query) {
            var root = getSectionRoot("contacts");
            if (root) {
                applyQuickSearch(root, query);
            }
        }
    };

    function init() {
        bindPrm();
        refreshVisible();
    }

    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", init);
    } else {
        init();
    }
})(window);

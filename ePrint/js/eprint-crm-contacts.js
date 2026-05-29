/* Option 3 — Contacts tab pilot (quick search, stats, company name) */
(function (window) {
    "use strict";

    function getRoot() {
        return document.querySelector(".eprint-crm-contacts-pilot-root");
    }

    function getGrid() {
        var root = getRoot();
        if (!root) {
            return null;
        }
        return root.querySelector(".eprint-crm-contacts-grid") ||
            root.querySelector("[id$='_RadGrid_Contact']");
    }

    function syncCompanyName() {
        var target = document.getElementById("eprintCrmContactsCompanyName");
        if (!target) {
            return;
        }
        var titleLabel = document.querySelector("[id$='_lbltitlecompanyname']");
        if (titleLabel && titleLabel.textContent) {
            target.textContent = titleLabel.textContent.trim();
        }
    }

    function parseContactCount() {
        var grid = getGrid();
        if (!grid) {
            return 0;
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
            if (!rows[i].classList.contains("eprint-crm-contacts-row-hidden")) {
                visible++;
            }
        }
        return visible;
    }

    function updateCount() {
        var el = document.getElementById("eprintCrmContactsCount");
        if (el) {
            el.textContent = String(parseContactCount());
        }
    }

    function applyQuickSearch(query) {
        var grid = getGrid();
        if (!grid) {
            return;
        }
        var q = (query || "").toLowerCase().trim();
        var rows = grid.querySelectorAll(".rgMasterTable .rgRow, .rgMasterTable .rgAltRow");
        var i, row, text, show;
        for (i = 0; i < rows.length; i++) {
            row = rows[i];
            if (!q) {
                row.classList.remove("eprint-crm-contacts-row-hidden");
                continue;
            }
            text = (row.textContent || "").toLowerCase();
            show = text.indexOf(q) >= 0;
            if (show) {
                row.classList.remove("eprint-crm-contacts-row-hidden");
            } else {
                row.classList.add("eprint-crm-contacts-row-hidden");
            }
        }
        updateCount();
    }

    function bindQuickSearch() {
        var input = document.getElementById("eprintCrmContactsQuickSearch");
        if (!input || input.getAttribute("data-bound")) {
            return;
        }
        input.setAttribute("data-bound", "1");
        input.addEventListener("input", function () {
            applyQuickSearch(input.value);
        });
        input.addEventListener("search", function () {
            applyQuickSearch(input.value);
        });
    }

    function bindPrm() {
        if (typeof Sys === "undefined" || !Sys.WebForms || !Sys.WebForms.PageRequestManager) {
            return;
        }
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm._eprintCrmContactsBound) {
            return;
        }
        prm._eprintCrmContactsBound = true;
        prm.add_endRequest(function () {
            var root = getRoot();
            if (root && root.offsetParent !== null) {
                refresh();
            }
        });
    }

    function refresh() {
        var root = getRoot();
        if (!root) {
            return;
        }
        syncCompanyName();
        bindQuickSearch();
        var input = document.getElementById("eprintCrmContactsQuickSearch");
        applyQuickSearch(input ? input.value : "");
        updateCount();
    }

    window.eprintCrmContacts = {
        refresh: refresh,
        applyQuickSearch: applyQuickSearch
    };

    function init() {
        bindPrm();
        if (getRoot()) {
            refresh();
        }
    }

    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", init);
    } else {
        init();
    }
})(window);

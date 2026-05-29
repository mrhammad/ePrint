/* CRM customer detail — Option 2 layout helpers (nav active state, filter toggle) */
(function (window) {
    "use strict";

    var TAB_TO_NAV = {
        client: "client",
        dept: "dept",
        costcentre: "costcentre",
        contacts: "contacts",
        address: "address",
        b2b: "estore",
        products: "products",
        emails: "emails",
        activities: "records",
        jobs: "records",
        invoices: "records",
        estore: "records",
        notes: "records"
    };

    function getRoot() {
        return document.querySelector(".eprint-crm-customer.eprint-crm-layout-v2");
    }

    function getTabFromCookie(clientId) {
        if (!clientId && typeof window.ClientID === "undefined" && typeof window.eprintCrmTabClientId === "undefined") {
            return "client";
        }
        var id = clientId || window.eprintCrmTabClientId || window.ClientID;
        var key = "CRMTabName" + id;
        var parts = document.cookie.split("; ");
        for (var i = 0; i < parts.length; i++) {
            if (parts[i].indexOf(key + "=") === 0) {
                return parts[i].substring(key.length + 1);
            }
        }
        return "client";
    }

    function getActiveCrmTab() {
        var hdnTab = document.querySelector("[id$='_hdnActiveCrmTab']");
        if (hdnTab && hdnTab.value) {
            return hdnTab.value.toLowerCase();
        }
        var root = document.querySelector(".eprint-crm-customer.eprint-crm-layout-v2");
        if (root && root.getAttribute("data-crm-active-tab")) {
            return root.getAttribute("data-crm-active-tab").toLowerCase();
        }
        return getTabFromCookie();
    }

    function updateActiveNav() {
        var root = getRoot();
        if (!root) {
            return;
        }
        var tab = getActiveCrmTab();
        var navKey = TAB_TO_NAV[tab] || tab;
        var items = root.querySelectorAll(".eprint-crm-nav-item");
        for (var i = 0; i < items.length; i++) {
            var item = items[i];
            var isActive = item.getAttribute("data-crm-nav") === navKey;
            item.classList.toggle("eprint-crm-nav-active", isActive);
        }
    }

    function ensureFilterToggle() {
        var root = getRoot();
        if (!root) {
            return;
        }
        var toolbar = root.querySelector(".eprint-crm-header-toolbar");
        if (!toolbar || toolbar.querySelector(".eprint-crm-filter-toggle")) {
            return;
        }
        var btn = document.createElement("button");
        btn.type = "button";
        btn.className = "eprint-crm-filter-toggle headerbutton white";
        btn.textContent = "Column filters";
        btn.setAttribute("aria-expanded", root.classList.contains("eprint-crm-filters-expanded") ? "true" : "false");
        btn.onclick = function () {
            var expanded = root.classList.toggle("eprint-crm-filters-expanded");
            root.classList.toggle("eprint-crm-filters-collapsed", !expanded);
            btn.setAttribute("aria-expanded", expanded ? "true" : "false");
            btn.textContent = expanded ? "Hide column filters" : "Column filters";
        };
        toolbar.insertBefore(btn, toolbar.firstChild);
        if (!root.classList.contains("eprint-crm-filters-expanded")) {
            root.classList.add("eprint-crm-filters-collapsed");
        }
    }

    function refresh() {
        updateActiveNav();
        ensureFilterToggle();
    }

    function bindPrm() {
        if (typeof Sys === "undefined" || !Sys.WebForms || !Sys.WebForms.PageRequestManager) {
            return;
        }
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm.get_isInAsyncPostBack && prm.get_isInAsyncPostBack()) {
            return;
        }
        if (prm._eprintCrmCustomerBound) {
            return;
        }
        prm._eprintCrmCustomerBound = true;
        prm.add_endRequest(function () {
            applyTabPreview(getActiveCrmTab());
            refresh();
        });
    }

    window.eprintCrmUi = {
        refresh: refresh,
        updateActiveNav: updateActiveNav
    };

    var TAB_LAYOUTS = {
        client: { mains: ["clientMain"], toolbars: [], search: true, edit: true, another: false },
        dept: { mains: ["departmentMain"], toolbars: ["deptControls"], another: true },
        contacts: { mains: ["contactMain"], toolbars: ["contactControls"], another: true },
        address: { mains: ["addressMain"], toolbars: ["addressControls"], another: true },
        costcentre: { mains: ["costcentreMain"], toolbars: ["costcenterControls"], another: true },
        b2b: { mains: ["b2bMain"], toolbars: [], another: true },
        products: { mains: ["productsMain"], toolbars: ["productsControls"], another: true },
        emails: { mains: ["emailMain"], toolbars: ["emailControls"], another: true },
        activities: { mains: ["activitiesMain"], toolbars: ["estimateControls"], another: true },
        jobs: { mains: ["activitiesMain"], toolbars: ["jobControls"], another: true },
        invoices: { mains: ["activitiesMain"], toolbars: ["invoiceControls"], another: true },
        estore: { mains: ["activitiesMain"], toolbars: ["eStoreControls"], another: true }
    };

    var ALL_MAIN_KEYS = [
        "clientMain", "contactMain", "departmentMain", "addressMain", "b2bMain",
        "productsMain", "notesMain", "emailMain", "activitiesMain", "costcentreMain"
    ];

    var ALL_TOOLBAR_KEYS = [
        "deptControls", "contactControls", "addressControls", "costcenterControls",
        "productsControls", "emailControls", "estimateControls", "jobControls",
        "invoiceControls", "eStoreControls"
    ];

    function setPanelVisible(panels, key, visible) {
        if (!panels || !key || !panels[key]) {
            return;
        }
        var el = document.getElementById(panels[key]);
        if (el) {
            el.style.display = visible ? "block" : "none";
        }
    }

    function applyTabPreview(tabKey) {
        var panels = window.eprintCrmPanels;
        if (!panels) {
            return;
        }
        var tab = (tabKey || "client").toLowerCase();
        var layout = TAB_LAYOUTS[tab] || TAB_LAYOUTS.client;
        var i;

        for (i = 0; i < ALL_MAIN_KEYS.length; i++) {
            setPanelVisible(panels, ALL_MAIN_KEYS[i], false);
        }
        for (i = 0; i < ALL_TOOLBAR_KEYS.length; i++) {
            setPanelVisible(panels, ALL_TOOLBAR_KEYS[i], false);
        }
        setPanelVisible(panels, "another", false);
        setPanelVisible(panels, "searchButton", false);
        setPanelVisible(panels, "btnEdit", false);
        setPanelVisible(panels, "btnDelete", false);

        for (i = 0; i < layout.mains.length; i++) {
            setPanelVisible(panels, layout.mains[i], true);
        }
        for (i = 0; i < layout.toolbars.length; i++) {
            setPanelVisible(panels, layout.toolbars[i], true);
        }
        if (layout.another) {
            setPanelVisible(panels, "another", true);
        }
        if (layout.search) {
            setPanelVisible(panels, "searchButton", true);
        }
        if (layout.edit) {
            setPanelVisible(panels, "btnEdit", true);
            setPanelVisible(panels, "btnDelete", true);
        }

        var root = getRoot();
        if (root) {
            root.setAttribute("data-crm-active-tab", tab);
        }
    }

    window.eprintCrmTabs = {
        applyPreview: applyTabPreview
    };

    function bindNavClicks() {
        var root = getRoot();
        if (!root || root.getAttribute("data-nav-bound")) {
            return;
        }
        root.setAttribute("data-nav-bound", "1");
        root.addEventListener("click", function (evt) {
            if (evt.target && evt.target.closest && evt.target.closest(".eprint-crm-nav-item")) {
                setTimeout(updateActiveNav, 50);
            }
        });
    }

    function init() {
        applyTabPreview(getActiveCrmTab());
        refresh();
        bindPrm();
        bindNavClicks();
    }

    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", init);
    } else {
        init();
    }
})(window);

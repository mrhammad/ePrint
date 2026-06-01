/**
 * Estimate item screens (single + booklet) — Option B cards. Build once; never destroy moved nodes.
 */
(function (window, document) {
    "use strict";

    var SINGLE_CONFIG = {
        sectionMeta: {
            item: { title: "Item", hint: "Title for this line", grid: "eprint-si-field-grid" },
            quantity: { title: "Quantity", hint: "Finished quantities", grid: "eprint-si-field-grid" },
            press: { title: "Press & paper", hint: "Press, stock and spoilage", grid: "eprint-si-field-grid" },
            sizes: { title: "Sheet & finished size", hint: "Sizes, gutters and restrictions", grid: "eprint-si-field-grid" },
            layout: { title: "Print layout & finishing", hint: "Layout, guillotine and options", grid: "eprint-si-field-grid" }
        },
        sectionOrder: ["item", "quantity", "press", "sizes", "layout"],
        controlSection: {
            txtItemTitle: "item",
            txtQuantity: "quantity", txtQuantity_2: "quantity", txtQuantity_3: "quantity",
            txtQuantity_4: "quantity", txtRunOnQty: "quantity", div_FinishedQty: "quantity",
            div_qty12: "quantity", div_Qty_2to4: "quantity", div_Pads_1: "quantity", div_SectionRef: "quantity",
            ddlPress: "press", lblDefaultPaper: "press", lblPaperWeight: "press", Divplus: "press",
            txtSetupSpoilage: "press", txtRunningSpoilage: "press",
            ddlColors: "press", ddlColors_2: "press", chkDoubleSided: "press",
            ChkPriceForWholePack: "press", ChkPaperSupplied: "press",
            ddlPrintSheetSize: "sizes", ddlJobItemSize: "sizes", chkPrintSheet: "sizes",
            chkGutters: "sizes", ChkPressRestrictions: "sizes", div_chkPrintSheet: "sizes",
            div_GuttersCustomSize: "sizes", div_Booklet_Format: "sizes",
            div_booklet_NoOfPagesInSection: "sizes",
            div_PrintLayout: "layout", lblGuillotine: "layout", div_Trim: "layout",
            Div_ItemDescn: "layout", Div_Productcatalogue: "layout"
        },
        blockSection: { div_PrintLayout: "layout" },
        fullWidth: { div_PrintLayout: true, Div_ItemDescn: true, Div_Productcatalogue: true },
        orders: {
            item: ["txtItemTitle"],
            quantity: ["div_FinishedQty", "div_qty12", "div_Qty_2to4", "div_Pads_1", "div_SectionRef", "txtQuantity"],
            press: ["ddlPress", "lblDefaultPaper", "txtSetupSpoilage", "txtRunningSpoilage", "ddlColors"],
            sizes: ["ddlPrintSheetSize", "ddlJobItemSize", "chkGutters", "ChkPressRestrictions"],
            layout: ["div_PrintLayout", "lblGuillotine", "Div_ItemDescn", "Div_Productcatalogue"]
        },
        isBooklet: false
    };

    var BOOKLET_CONFIG = {
        sectionMeta: {
            item: { title: "Item", hint: "Title for this section", grid: "eprint-si-field-grid" },
            quantity: { title: "Quantity", hint: "Booklet quantities", grid: "eprint-si-field-grid" },
            booklet: { title: "Booklet", hint: "Type and pages per section", grid: "eprint-si-field-grid" },
            press: { title: "Press & paper", hint: "Press, stock and spoilage", grid: "eprint-si-field-grid" },
            sizes: { title: "Sizes & format", hint: "Sheet, finished and flat sizes", grid: "eprint-si-field-grid" },
            layout: { title: "Print layout & finishing", hint: "Layout, sheets per section, guillotine", grid: "eprint-si-field-grid" }
        },
        sectionOrder: ["item", "quantity", "booklet", "press", "sizes", "layout"],
        controlSection: {
            txtItemTitle: "item",
            txtQuantity: "quantity", txtQuantity_2: "quantity", txtQuantity_3: "quantity",
            txtQuantity_4: "quantity", txtRunOnQty: "quantity", div_FinishedQty: "quantity",
            div_BookletQty: "quantity", div_qty12: "quantity", div_Qty_2to4: "quantity",
            div_SectionRef: "quantity", txtSectionRef: "quantity",
            ddlBookletType: "booklet", lblBookletType: "booklet", txtNoOfPagesInSection: "booklet",
            div_booklet_NoOfPagesInSection: "booklet",
            ddlPress: "press", lblDefaultPaper: "press", lblPaperWeight: "press",
            txtSetupSpoilage: "press", txtRunningSpoilage: "press",
            ddlColors: "press", ddlColors_2: "press", chkDoubleSided: "press",
            ChkPriceForWholePack: "press", ChkPaperSupplied: "press",
            ddlPrintSheetSize: "sizes", ddlJobItemSize: "sizes", chkPrintSheet: "sizes",
            chkGutters: "sizes", ChkPressRestrictions: "sizes", div_chkPrintSheet: "sizes",
            div_GuttersCustomSize: "sizes", div_Booklet_Format: "sizes", ddlBookletFormat: "sizes",
            div_Booklet_itemSize: "sizes", div_Flatbookletitemsize: "sizes",
            txtFlatbookletitemsizeHeight: "sizes", txtFlatbookletitemsizeWidth: "sizes",
            div_PrintLayout: "layout", div_plusimg: "layout", div_booklet_NoOfSignatures: "layout",
            txtPagesPerSignature: "layout", txtNoOfSignatures: "layout", chkIsSilling: "layout",
            lblGuillotine: "layout", div_Trim: "layout", Div_ItemDescn: "layout", Div_Productcatalogue: "layout"
        },
        blockSection: { div_PrintLayout: "layout", div_booklet_NoOfSignatures: "layout" },
        fullWidth: {
            div_PrintLayout: true, div_booklet_NoOfSignatures: true, div_Booklet_itemSize: true,
            Div_ItemDescn: true, Div_Productcatalogue: true
        },
        orders: {
            item: ["txtItemTitle"],
            quantity: ["div_FinishedQty", "div_BookletQty", "div_qty12", "div_Qty_2to4", "div_SectionRef", "txtQuantity"],
            booklet: ["ddlBookletType", "div_booklet_NoOfPagesInSection", "txtNoOfPagesInSection"],
            press: ["ddlPress", "lblDefaultPaper", "txtSetupSpoilage", "txtRunningSpoilage", "ddlColors"],
            sizes: ["ddlPrintSheetSize", "ddlJobItemSize", "div_Booklet_Format", "div_Booklet_itemSize", "chkGutters", "ChkPressRestrictions"],
            layout: ["div_PrintLayout", "div_booklet_NoOfSignatures", "lblGuillotine", "Div_ItemDescn", "Div_Productcatalogue"]
        },
        isBooklet: true
    };

    var SECTION_META;
    var SECTION_ORDER;
    var CONTROL_SECTION;
    var BLOCK_SECTION;
    var FULL_WIDTH;
    var ORDERS;
    var activeIsBooklet = false;

    function getStageRoot() {
        return document.getElementById("eprint-single-item-root") ||
            document.getElementById("eprint-booklet-item-root");
    }

    function applyConfig(root) {
        var cfg = root.id === "eprint-booklet-item-root" ? BOOKLET_CONFIG : SINGLE_CONFIG;
        SECTION_META = cfg.sectionMeta;
        SECTION_ORDER = cfg.sectionOrder;
        CONTROL_SECTION = cfg.controlSection;
        BLOCK_SECTION = cfg.blockSection;
        FULL_WIDTH = cfg.fullWidth;
        ORDERS = cfg.orders;
        activeIsBooklet = cfg.isBooklet;
    }

    function findByIdSuffix(id) {
        var el = document.getElementById(id);
        if (el) {
            return el;
        }
        var all = document.querySelectorAll("[id$='" + id + "']");
        return all.length ? all[0] : null;
    }

    function rowContainsId(row, id) {
        return row && (row.id === id || !!row.querySelector("[id$='" + id + "']"));
    }

    function rowContainsScheduleLike(row) {
        return false;
    }

    function classifyRow(row) {
        if (!row) {
            return "layout";
        }
        if (row.id && BLOCK_SECTION[row.id]) {
            return BLOCK_SECTION[row.id];
        }
        var id;
        for (id in CONTROL_SECTION) {
            if (CONTROL_SECTION.hasOwnProperty(id) && rowContainsId(row, id)) {
                return CONTROL_SECTION[id];
            }
        }
        return "layout";
    }

    function isVisible(el) {
        if (!el) {
            return false;
        }
        if (el.style.display === "none") {
            return false;
        }
        try {
            var st = window.getComputedStyle(el);
            return st.display !== "none" && st.visibility !== "hidden";
        } catch (e) {
            return true;
        }
    }

    function isFieldRow(node) {
        if (!node || node.nodeType !== 1) {
            return false;
        }
        if (/only\d+px|onlyEmpty/i.test(node.className || "")) {
            return false;
        }
        if (node.querySelector("[id$='btnSave'], [id$='btnPrevious']")) {
            return false;
        }
        if (!(node.querySelector(".bglabelnew") || node.querySelector(".bglabelnewLarge"))) {
            return false;
        }
        return isVisible(node);
    }

    function collectRowsFromColumn(col, bucket, used) {
        if (!col) {
            return;
        }
        var i;
        var ch = col.children;
        for (i = 0; i < ch.length; i++) {
            tryAddRow(ch[i], bucket, used, col);
        }
        var inner = col.querySelector("#div_only_digitals_left");
        if (inner) {
            for (i = 0; i < inner.children.length; i++) {
                tryAddRow(inner.children[i], bucket, used, col);
            }
        }
        var printLayout = document.getElementById("div_PrintLayout");
        if (printLayout && col.contains(printLayout)) {
            tryAddRow(printLayout, bucket, used, col);
        }
    }

    function tryAddRow(node, bucket, used, rootCol) {
        if (!node || node.nodeType !== 1 || used.indexOf(node) >= 0) {
            return;
        }
        if (node.id === "div_only_digitals_left") {
            return;
        }
        if (node.id === "div_PrintLayout" && isVisible(node)) {
            addToBucket(node, bucket, used);
            return;
        }
        if (!isFieldRow(node)) {
            return;
        }
        if (!rootCol.contains(node)) {
            return;
        }
        addToBucket(node, bucket, used);
    }

    function addToBucket(row, bucket, used) {
        var sec = classifyRow(row);
        if (!bucket[sec]) {
            sec = "layout";
        }
        bucket[sec].push(row);
        used.push(row);
    }

    function rowKey(row) {
        var id;
        if (row.id && (CONTROL_SECTION[row.id] || BLOCK_SECTION[row.id])) {
            return row.id;
        }
        for (id in CONTROL_SECTION) {
            if (CONTROL_SECTION.hasOwnProperty(id) && rowContainsId(row, id)) {
                return id;
            }
        }
        return row.id || "";
    }

    function sortRows(rows, order) {
        var rank = {};
        var i;
        for (i = 0; i < order.length; i++) {
            rank[order[i]] = i;
        }
        return rows.slice().sort(function (a, b) {
            var ra = rank.hasOwnProperty(rowKey(a)) ? rank[rowKey(a)] : 999;
            var rb = rank.hasOwnProperty(rowKey(b)) ? rank[rowKey(b)] : 999;
            return ra - rb;
        });
    }

    function groupPaperCheckboxes(row) {
        var wholePack = findByIdSuffix("ChkPriceForWholePack");
        var supplied = findByIdSuffix("ChkPaperSupplied");
        if (!wholePack || !supplied || !row.contains(wholePack)) {
            return;
        }
        var wrap = row.querySelector(".eprint-si-paper-options");
        if (!wrap) {
            wrap = document.createElement("div");
            wrap.className = "eprint-si-paper-options";
        }
        var wholeParent = wholePack.closest(".onlyEmpty") || wholePack.parentNode;
        var suppliedParent = supplied.parentNode;
        if (wholeParent && wholeParent.parentNode !== wrap) {
            wrap.appendChild(wholeParent);
        }
        if (suppliedParent && suppliedParent !== wholeParent && suppliedParent.parentNode !== wrap) {
            wrap.appendChild(suppliedParent);
        }
        var control = row.querySelector(".eprint-si-field-control");
        if (control && wrap.parentNode !== control) {
            control.appendChild(wrap);
        } else if (!wrap.parentNode) {
            row.appendChild(wrap);
        }
    }

    function normalizePrintLayoutRow(row) {
        if (!row || row.id !== "div_PrintLayout" || row.getAttribute("data-eprint-si-normalized") === "1") {
            return;
        }
        var labelBlock = row.querySelector(".bglabelnewLarge");
        if (!labelBlock) {
            return;
        }

        var header = document.createElement("div");
        header.className = "eprint-si-print-layout-head";
        var body = document.createElement("div");
        body.className = "eprint-si-print-layout-body";

        var previewHost = row.querySelector("#div_plusimg, a[onclick*='popup_layout']");
        if (previewHost) {
            previewHost = previewHost.closest("#div_plusimg") || previewHost.parentNode;
            previewHost.className = (previewHost.className || "") + " eprint-si-layout-preview-btn";
            previewHost.className = previewHost.className.trim();
            if (previewHost.parentNode) {
                previewHost.parentNode.removeChild(previewHost);
            }
            header.appendChild(previewHost);
        }

        var labelKids = Array.prototype.slice.call(labelBlock.childNodes);
        var i;
        for (i = 0; i < labelKids.length; i++) {
            var lc = labelKids[i];
            if (lc.nodeType !== 1 || lc === previewHost) {
                continue;
            }
            var lst = lc.getAttribute("style") || "";
            if (/float:\s*right/i.test(lst)) {
                lc.className = (lc.className || "") + " eprint-si-layout-preview-btn";
                lc.className = lc.className.trim();
                header.appendChild(lc);
            } else if (/float:\s*left/i.test(lst) || lc.tagName === "TABLE") {
                header.appendChild(lc);
            }
        }

        var rowKids = Array.prototype.slice.call(row.childNodes);
        for (i = 0; i < rowKids.length; i++) {
            var ch = rowKids[i];
            if (ch.nodeType !== 1 || ch === labelBlock) {
                continue;
            }
            if (/only\d+px/i.test(ch.className || "")) {
                continue;
            }
            ch.style.float = "none";
            ch.style.width = "100%";
            ch.style.maxWidth = "100%";
            body.appendChild(ch);
        }

        if (labelBlock.parentNode) {
            labelBlock.parentNode.removeChild(labelBlock);
        }
        row.appendChild(header);
        row.appendChild(body);
        row.setAttribute("data-eprint-si-normalized", "1");
    }

    function normalizeFieldRow(row) {
        if (!row || row.getAttribute("data-eprint-si-normalized") === "1") {
            return;
        }
        if (row.id === "div_PrintLayout") {
            normalizePrintLayoutRow(row);
            return;
        }
        var labelBlock = row.querySelector(".bglabelnew, .bglabelnewLarge");
        if (!labelBlock) {
            return;
        }

        var actionWrap = document.createElement("div");
        actionWrap.className = "eprint-si-field-with-action";
        var controlWrap = document.createElement("div");
        controlWrap.className = "eprint-si-field-control";

        var floatRights = labelBlock.querySelectorAll('[style*="float: right"], [style*="float:right"]');
        var i;
        for (i = 0; i < floatRights.length; i++) {
            actionWrap.appendChild(floatRights[i]);
        }

        var children = Array.prototype.slice.call(row.childNodes);
        for (i = 0; i < children.length; i++) {
            var c = children[i];
            if (c.nodeType !== 1 || c === labelBlock) {
                continue;
            }
            if (/only\d+px|onlyEmpty/i.test(c.className || "")) {
                continue;
            }
            c.style.float = "none";
            c.style.width = "100%";
            c.style.maxWidth = "100%";
            controlWrap.appendChild(c);
        }

        if (controlWrap.childNodes.length) {
            if (actionWrap.childNodes.length) {
                actionWrap.insertBefore(controlWrap, actionWrap.firstChild);
                row.appendChild(actionWrap);
            } else {
                row.appendChild(controlWrap);
            }
        } else if (actionWrap.childNodes.length) {
            row.appendChild(actionWrap);
        }

        row.setAttribute("data-eprint-si-normalized", "1");
    }

    function decorateRow(row, fullWidth) {
        row.className = (row.className || "").replace(/\beprint-si-field-row\b/g, "").trim();
        row.className = (row.className + " eprint-si-field-row").trim();
        if (fullWidth || row.id === "div_PrintLayout" || rowContainsId(row, "div_FinishedQty")) {
            row.className += " full-width eprint-si-block-row";
        }
        if (rowContainsId(row, "Divplus") || rowContainsId(row, "lblDefaultPaper")) {
            row.className += " eprint-si-paper-row full-width";
        }
        normalizeFieldRow(row);
        if (rowContainsId(row, "ChkPriceForWholePack") || rowContainsId(row, "lblDefaultPaper")) {
            groupPaperCheckboxes(row);
        }
    }

    function createCard(key) {
        var meta = SECTION_META[key];
        var card = document.createElement("section");
        card.className = "eprint-si-card";
        card.setAttribute("data-eprint-section", key);
        card.innerHTML =
            "<div class=\"eprint-si-card-head\"><h3>" + meta.title + "</h3><p>" + meta.hint + "</p></div>" +
            "<div class=\"eprint-si-card-body\"><div class=\"" + meta.grid + "\"></div></div>";
        return { card: card, grid: card.querySelector(".eprint-si-card-body > div") };
    }

    function moveBookletSectionNav(stage) {
        var nav = document.getElementById("div_btn_booklet_sections");
        var host = document.getElementById("eprint_si_booklet_sections_host");
        var bar = document.getElementById("eprint_si_booklet_sections_bar");
        if (!nav || !host) {
            return;
        }
        if (nav.parentNode !== host) {
            host.appendChild(nav);
        }
        nav.style.display = "block";
        nav.style.visibility = "visible";
        nav.style.whiteSpace = "normal";
        if (bar) {
            bar.style.display = "flex";
        }
        var breaks = nav.querySelectorAll(".only5px");
        var i;
        for (i = 0; i < breaks.length; i++) {
            breaks[i].style.display = "block";
            breaks[i].style.height = "0";
            breaks[i].style.width = "100%";
            breaks[i].style.float = "none";
        }
    }

    function appendActionGroup(actions, wrapId, btnSuffix, primary) {
        var wrap = document.getElementById(wrapId);
        if (!wrap) {
            return;
        }
        var group = wrap.parentNode;
        if (!group || group.parentNode === actions) {
            return;
        }
        actions.appendChild(group);
        if (btnSuffix) {
            var btn = findByIdSuffix(btnSuffix);
            if (btn) {
                btn.className = (btn.className || "button") + (primary ? " eprint-si-btn-primary" : " eprint-si-btn-ghost");
            }
        }
    }

    function moveFooterActions(stage) {
        var header = stage.querySelector(".eprint-si-page-header");
        if (!header) {
            return;
        }
        var actions = header.querySelector(".eprint-si-header-actions");
        if (!actions) {
            return;
        }

        if (activeIsBooklet) {
            moveBookletSectionNav(stage);
            appendActionGroup(actions, "div_btnstage", "btnStage2_Previous", false);
            var bookletExtra = document.getElementById("div_BookletDelete");
            if (bookletExtra && bookletExtra.parentNode !== actions) {
                actions.appendChild(bookletExtra);
            }
            appendActionGroup(actions, "div_btnfinish", "btnSave", true);
            var footerRow = findByIdSuffix("btnSave");
            footerRow = footerRow && footerRow.closest("[align='left']");
            if (footerRow) {
                footerRow.style.display = "none";
            }
            return;
        }

        appendActionGroup(actions, "div_btnprev", "btnPrevious", false);
        appendActionGroup(actions, "div_btnsave", "btnSave", true);
        var footerRowSingle = findByIdSuffix("btnSave");
        footerRowSingle = footerRowSingle && footerRowSingle.closest("[align='left']");
        if (footerRowSingle) {
            footerRowSingle.style.display = "none";
        }
    }

    function countBucket(bucket) {
        var n = 0;
        var k;
        for (k in bucket) {
            if (bucket.hasOwnProperty(k)) {
                n += bucket[k].length;
            }
        }
        return n;
    }

    function buildLayout() {
        try {
            var root = getStageRoot();
            if (!root) {
                return;
            }
            applyConfig(root);
            if (root.getAttribute("data-eprint-si-layout") === "1" && root.querySelector(".eprint-si-layout")) {
                moveFooterActions(root);
                if (activeIsBooklet) {
                    moveBookletSectionNav(root);
                }
                return;
            }

            var left = document.getElementById("eprint_si_col_left");
            var right = document.getElementById("div_only_digitals_right");
            var legacy = document.getElementById("eprint_si_legacy_columns");
            if (!left || !right) {
                return;
            }

            var bucket = {};
            var used = [];
            var i;
            for (i = 0; i < SECTION_ORDER.length; i++) {
                bucket[SECTION_ORDER[i]] = [];
            }

            collectRowsFromColumn(left, bucket, used);
            collectRowsFromColumn(right, bucket, used);

            if (countBucket(bucket) < 3) {
                return;
            }

            var layout = document.createElement("div");
            layout.className = "eprint-si-layout";
            var grids = {};
            var cards = {};
            for (i = 0; i < SECTION_ORDER.length; i++) {
                var built = createCard(SECTION_ORDER[i]);
                grids[SECTION_ORDER[i]] = built.grid;
                cards[SECTION_ORDER[i]] = built.card;
                layout.appendChild(built.card);
            }

            var placed = 0;

            for (i = 0; i < SECTION_ORDER.length; i++) {
                var key = SECTION_ORDER[i];
                var rows = sortRows(bucket[key], ORDERS[key] || []);
                var j;
                for (j = 0; j < rows.length; j++) {
                    var row = rows[j];
                    var fw = false;
                    var q;
                    for (q in FULL_WIDTH) {
                        if (FULL_WIDTH.hasOwnProperty(q) && rowContainsId(row, q)) {
                            fw = true;
                        }
                    }
                    if (row.id === "div_PrintLayout" || row.id === "div_booklet_NoOfSignatures" ||
                            row.id === "div_Booklet_itemSize" || rowContainsId(row, "div_FinishedQty")) {
                        fw = true;
                    }
                    decorateRow(row, fw);
                    grids[key].appendChild(row);
                    placed++;
                }
                if (!grids[key].childNodes.length && cards[key]) {
                    cards[key].style.display = "none";
                }
            }

            if (placed < 3) {
                return;
            }

            if (legacy) {
                legacy.parentNode.insertBefore(layout, legacy);
                legacy.className = (legacy.className || "") + " eprint-si-legacy-columns-hidden";
            } else {
                root.appendChild(layout);
            }

            moveFooterActions(root);
            root.setAttribute("data-eprint-si-layout", "1");
            root.classList.add("eprint-si-layout-ready");
            patchPopupHelpers();
            if (activeIsBooklet) {
                moveBookletSectionNav(root);
            }
        } catch (err) {
            if (window.console && window.console.warn) {
                window.console.warn("eprint-single-item-add layout skipped", err);
            }
        }
    }

    function run() {
        buildLayout();
    }

    function ensureModalHosts() {
        var hosts = [
            document.getElementById("divBackGroundNew"),
            document.getElementById("divrad")
        ];
        var i;
        for (i = 0; i < hosts.length; i++) {
            if (hosts[i] && hosts[i].parentNode !== document.body) {
                document.body.appendChild(hosts[i]);
            }
        }
    }

    function reflowActiveRadWindow(width, height) {
        var mgr = window.RadWindowManager1;
        var wnd = null;
        if (mgr) {
            if (typeof mgr.get_activeWindow === "function") {
                wnd = mgr.get_activeWindow();
            } else if (typeof mgr.GetActiveWindow === "function") {
                wnd = mgr.GetActiveWindow();
            }
        }
        if (wnd) {
            try {
                wnd.setSize(width || 1275, height || 500);
                wnd.center();
                var bounds = wnd.getWindowBounds ? wnd.getWindowBounds() : null;
                if (bounds && bounds.y < 0 && wnd.moveTo) {
                    wnd.moveTo(bounds.x, 57);
                }
            } catch (e1) {
                /* keep legacy behaviour if Telerik API differs */
            }
        }
    }

    function showRadHostCentered(divId, width, height) {
        ensureModalHosts();
        var host = document.getElementById(divId);
        var backdrop = document.getElementById("divBackGroundNew");
        if (backdrop) {
            backdrop.style.display = "block";
            backdrop.style.position = "fixed";
            backdrop.style.left = "0";
            backdrop.style.top = "0";
            backdrop.style.right = "0";
            backdrop.style.bottom = "0";
            backdrop.style.width = "100%";
            backdrop.style.height = "100%";
            backdrop.style.zIndex = "10050";
        }
        if (host) {
            host.style.display = "block";
            host.style.position = "fixed";
            host.style.left = "50%";
            host.style.top = "50%";
            host.style.transform = "translate(-50%, -50%)";
            host.style.margin = "0";
            host.style.zIndex = "10051";
        }
        document.body.classList.add("eprint-si-modal-open");
        reflowActiveRadWindow(width, height);
        window.setTimeout(function () { reflowActiveRadWindow(width, height); }, 80);
        window.setTimeout(function () { reflowActiveRadWindow(width, height); }, 250);
    }

    function scheduleRadReflow(width, height) {
        showRadHostCentered("divrad", width, height);
        window.setTimeout(function () { reflowActiveRadWindow(width, height); }, 80);
        window.setTimeout(function () { reflowActiveRadWindow(width, height); }, 250);
    }

    function patchBookletSectionHooks() {
        var root = getStageRoot();
        if (!root || root.id !== "eprint-booklet-item-root") {
            return;
        }
        moveBookletSectionNav(root);
        ["GenerateSection", "SectionsData"].forEach(function (fnName) {
            if (typeof window[fnName] !== "function" || window[fnName]._eprintSiNavPatched) {
                return;
            }
            var original = window[fnName];
            window[fnName] = function () {
                var result = original.apply(this, arguments);
                moveBookletSectionNav(getStageRoot());
                return result;
            };
            window[fnName]._eprintSiNavPatched = true;
        });
    }

    function patchPopupHelpers() {
        if (!getStageRoot()) {
            return;
        }
        ensureModalHosts();
        patchBookletSectionHooks();

        if (!window._eprintSiShowDivPopupCenterPatched && typeof window.showDivPopupCenter === "function") {
            var origShow = window.showDivPopupCenter;
            window.showDivPopupCenter = function (divId, divHeight) {
                if (divId === "divrad") {
                    showRadHostCentered(divId);
                    return;
                }
                return origShow.apply(this, arguments);
            };
            window._eprintSiShowDivPopupCenterPatched = true;
        }

        if (!window._eprintSiSetRadWindowPatched && typeof window.SetRadWindow === "function") {
            var origSet = window.SetRadWindow;
            window.SetRadWindow = function (divMaskID, divBackgroundID, divHeight) {
                if (divMaskID === "divrad" && getStageRoot()) {
                    /* OpenPaperPopUp always opens — do not toggle closed if host is already visible */
                    showRadHostCentered(divMaskID);
                    return;
                }
                return origSet.apply(this, arguments);
            };
            window._eprintSiSetRadWindowPatched = true;
        }

        if (typeof window.OpenPaperPopUp === "function" && !window.OpenPaperPopUp._eprintSiPatched) {
            var origPaper = window.OpenPaperPopUp;
            window.OpenPaperPopUp = function (Type) {
                ensureModalHosts();
                var ret = origPaper.apply(this, arguments);
                scheduleRadReflow(1275, 500);
                return ret;
            };
            window.OpenPaperPopUp._eprintSiPatched = true;
        }

        if (typeof window.popup_layout === "function" && !window.popup_layout._eprintSiPatched) {
            var origLayout = window.popup_layout;
            window.popup_layout = function () {
                ensureModalHosts();
                var ret = origLayout.apply(this, arguments);
                scheduleRadReflow(1050, 525);
                return ret;
            };
            window.popup_layout._eprintSiPatched = true;
        }

        if (typeof window.GuillotineSelect === "function" && !window.GuillotineSelect._eprintSiPatched) {
            var origGuillotine = window.GuillotineSelect;
            window.GuillotineSelect = function () {
                ensureModalHosts();
                var ret = origGuillotine.apply(this, arguments);
                scheduleRadReflow(1000, 500);
                return ret;
            };
            window.GuillotineSelect._eprintSiPatched = true;
        }

        if (typeof window.RadWinClose === "function" && !window._eprintSiRadWinClosePatched) {
            var origClose = window.RadWinClose;
            window.RadWinClose = function () {
                document.body.classList.remove("eprint-si-modal-open");
                var divrad = document.getElementById("divrad");
                if (divrad) {
                    divrad.style.transform = "";
                }
                return origClose.apply(this, arguments);
            };
            window._eprintSiRadWinClosePatched = true;
        }
    }

    function init() {
        if (document.readyState === "loading") {
            document.addEventListener("DOMContentLoaded", run);
        } else {
            run();
        }
        window.setTimeout(run, 400);
        window.setTimeout(patchPopupHelpers, 500);
        window.setTimeout(patchPopupHelpers, 1200);
        window.addEventListener("load", patchPopupHelpers);
    }

    init();
    window.eprintSingleItemLayout = { rebuild: run, patchPopups: patchPopupHelpers };
    window.eprintBookletItemLayout = window.eprintSingleItemLayout;
})(window, document);

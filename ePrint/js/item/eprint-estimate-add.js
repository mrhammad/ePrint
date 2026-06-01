/**
 * Stage 1 estimate add/edit — Option B (Schedule + Document blocks match design mockup).
 */
(function (window, document) {
    "use strict";

    var SECTION_META = {
        customer: { title: "Customer & contacts", hint: "Who is this estimate for?", grid: "eprint-est-field-grid" },
        addresses: { title: "Addresses", hint: "Contact, delivery and invoice", grid: "eprint-est-field-grid cols-3" },
        estimate: { title: "Estimate details", hint: "Type, title and ownership", grid: "eprint-est-field-grid" },
        schedule: { title: "Schedule", hint: "Key dates — collapsible \"More dates\" in implementation", grid: "eprint-est-schedule-grid" },
        document: { title: "Document text & notes", hint: "Optional — header, footer, comments", grid: "eprint-est-field-grid eprint-est-document-grid" }
    };

    var SECTION_ORDER = ["customer", "addresses", "estimate", "schedule", "document"];

    var SCHEDULE_IDS = [
        "txtEstimateDate", "txtEstimateartworkDate", "txtproofdate", "txtapprovaldate",
        "txtproductiondate", "txtjobcompletiondate", "txtEstimatedeliveryDate",
        "txtCustomDate1", "txtCustomDate2", "txtCustomDate3", "txtCustomDate4", "txtCustomDate5",
        "txtInvoiceDueDate", "txtinvoicenumber"
    ];

    var DOCUMENT_IDS = ["lblHeader", "lblFooter", "div_comment", "txtcomments"];

    var CUSTOMER_ORDER = [
        "txtName", "lblAccountNumber", "ddlcontact", "ddlinvoicecontact",
        "txtGreeting", "txtCompany", "div_costcentre"
    ];

    var ESTIMATE_ORDER = [
        "ddlEstimateType", "ddlProductType", "ddlCalcType", "ddlStatus", "ddlpriority",
        "txtEstimateTitle", "txtOrderNumber", "ddlSalesPerson", "ddlEstimator",
        "divSalesPerson", "dvEstimator", "txtValidFor", "divJobNumInfo", "divEstNo", "divProgressdOn"
    ];

    var ADDRESS_ORDER = ["lblAddress", "div_DeliveryAddress", "div_InvoiceAddress"];

    var DOCUMENT_ORDER = ["lblHeader", "lblFooter", "div_comment", "txtcomments"];

    var FULL_WIDTH = { txtEstimateTitle: true, div_comment: true, txtcomments: true };

    function findByIdSuffix(id) {
        var el = document.getElementById(id);
        if (el) {
            return el;
        }
        var all = document.querySelectorAll("[id$='" + id + "']");
        return all.length ? all[0] : null;
    }

    function ensureStageVisible() {
        var stage = document.getElementById("divStage1");
        if (stage) {
            stage.style.display = "block";
        }
    }

    function rowContainsId(row, id) {
        return row && (row.id === id || !!row.querySelector("[id$='" + id + "']"));
    }

    function rowContainsScheduleInput(row) {
        var i;
        if (!row) {
            return false;
        }
        for (i = 0; i < SCHEDULE_IDS.length; i++) {
            if (rowContainsId(row, SCHEDULE_IDS[i])) {
                return true;
            }
        }
        return false;
    }

    function rowContainsDocumentInput(row) {
        var i;
        if (!row) {
            return false;
        }
        for (i = 0; i < DOCUMENT_IDS.length; i++) {
            if (rowContainsId(row, DOCUMENT_IDS[i])) {
                return true;
            }
        }
        return false;
    }

    function classifyRow(row) {
        if (!row) {
            return null;
        }
        if (rowContainsScheduleInput(row)) {
            return "schedule";
        }
        if (rowContainsId(row, "txtValidFor")) {
            return "estimate";
        }
        if (rowContainsDocumentInput(row)) {
            return "document";
        }
        var id;
        var map = {
            txtName: "customer", ddlcontact: "customer", ddlinvoicecontact: "customer",
            txtGreeting: "customer", txtCompany: "customer", div_costcentre: "customer",
            lblAccountNumber: "customer",
            lblAddress: "addresses", div_DeliveryAddress: "addresses", div_InvoiceAddress: "addresses",
            ddlEstimateType: "estimate", ddlProductType: "estimate", ddlCalcType: "estimate",
            txtEstimateTitle: "estimate", txtOrderNumber: "estimate", ddlStatus: "estimate",
            ddlpriority: "estimate", ddlSalesPerson: "estimate", ddlEstimator: "estimate",
            divSalesPerson: "estimate", dvEstimator: "estimate",
            div_ProductType: "estimate", div_calcType: "estimate", divJobNumInfo: "estimate",
            divEstNo: "estimate", div_priority: "estimate", divProgressdOn: "estimate"
        };
        if (row.id && map[row.id]) {
            return map[row.id];
        }
        for (id in map) {
            if (map.hasOwnProperty(id) && rowContainsId(row, id)) {
                return map[id];
            }
        }
        return "estimate";
    }

    function scheduleFieldRow(el) {
        if (!el) {
            return null;
        }
        var n = el;
        var dateRow = null;
        while (n && n.parentNode) {
            if (n.id === "div_comment") {
                return null;
            }
            if (n.getAttribute && n.getAttribute("align") === "left" && n.querySelector(".bglabelnew")) {
                if (rowContainsId(n, "txtValidFor")) {
                    return null;
                }
                if (rowContainsScheduleInput(n)) {
                    dateRow = n;
                }
            }
            if (n.id === "divEstiDateInfo") {
                return dateRow;
            }
            n = n.parentNode;
        }
        return null;
    }

    function collectScheduleRows() {
        var root = document.getElementById("divEstiDateInfo");
        var rows = [];
        var seen = [];
        var i;
        var row;
        if (!root) {
            return rows;
        }
        for (i = 0; i < SCHEDULE_IDS.length; i++) {
            var el = findByIdSuffix(SCHEDULE_IDS[i]);
            if (!el || !root.contains(el)) {
                continue;
            }
            row = scheduleFieldRow(el);
            if (row && seen.indexOf(row) < 0) {
                seen.push(row);
                rows.push(row);
            }
        }
        return rows;
    }

    function rowKey(row) {
        var i;
        if (!row) {
            return "";
        }
        for (i = 0; i < SCHEDULE_IDS.length; i++) {
            if (rowContainsId(row, SCHEDULE_IDS[i])) {
                return SCHEDULE_IDS[i];
            }
        }
        for (i = 0; i < DOCUMENT_IDS.length; i++) {
            if (rowContainsId(row, DOCUMENT_IDS[i])) {
                return DOCUMENT_IDS[i];
            }
        }
        if (row.id) {
            return row.id;
        }
        return "";
    }

    function sortRows(rows, order) {
        var rank = {};
        var i;
        for (i = 0; i < order.length; i++) {
            rank[order[i]] = i;
        }
        return rows.slice().sort(function (a, b) {
            var ka = rowKey(a);
            var kb = rowKey(b);
            var ra = rank.hasOwnProperty(ka) ? rank[ka] : 999;
            var rb = rank.hasOwnProperty(kb) ? rank[kb] : 999;
            return ra - rb;
        });
    }

    function isInsideDateBlock(node) {
        var n = node;
        while (n) {
            if (n.id === "divEstiDateInfo") {
                return true;
            }
            n = n.parentNode;
        }
        return false;
    }

    function documentFieldRow(el) {
        if (!el) {
            return null;
        }
        var n = el;
        while (n) {
            if (n.id === "leftcol" || n.id === "rightcol") {
                if (n.getAttribute && n.getAttribute("align") === "left" && n.querySelector(".bglabelnew")) {
                    return n;
                }
                return null;
            }
            if (n.getAttribute && n.getAttribute("align") === "left" && n.querySelector(".bglabelnew") &&
                    rowContainsDocumentInput(n) && !rowContainsScheduleInput(n)) {
                return n;
            }
            n = n.parentNode;
        }
        return null;
    }

    function collectDocumentRows() {
        var rows = [];
        var seen = [];
        var i;
        for (i = 0; i < DOCUMENT_IDS.length; i++) {
            var el = findByIdSuffix(DOCUMENT_IDS[i]);
            var row = documentFieldRow(el);
            if (row && seen.indexOf(row) < 0) {
                seen.push(row);
                rows.push(row);
            }
        }
        return rows;
    }

    function isLayoutRow(node) {
        if (!node || node.nodeType !== 1) {
            return false;
        }
        if (/only\d+px|onlyEmpty/i.test(node.className || "")) {
            return false;
        }
        if (node.id === "div_only_for_add" || node.id === "div_Estimate_btnEdit" || node.id === "divEstiDateInfo") {
            return false;
        }
        if (isInsideDateBlock(node)) {
            return false;
        }
        return !!node.querySelector(".bglabelnew") || node.id === "div_costcentre" ||
            node.id === "div_DeliveryAddress" || node.id === "div_InvoiceAddress";
    }

    function collectRows(col) {
        var rows = [];
        if (!col) {
            return rows;
        }
        var ch = col.children;
        var i;
        for (i = 0; i < ch.length; i++) {
            if (isLayoutRow(ch[i])) {
                rows.push(ch[i]);
            }
        }
        return rows;
    }

    function clearFloatStyles(el) {
        if (!el || el.nodeType !== 1) {
            return;
        }
        var s = el.getAttribute("style") || "";
        if (/float\s*:\s*left/i.test(s)) {
            el.style.float = "none";
            el.style.width = "100%";
            el.style.maxWidth = "100%";
        }
        var kids = el.children;
        var i;
        for (i = 0; i < kids.length; i++) {
            clearFloatStyles(kids[i]);
        }
    }

    function normalizeFieldRow(row) {
        if (!row || row.getAttribute("data-eprint-normalized") === "1") {
            return;
        }
        var labelBlock = row.querySelector(".bglabelnew");
        if (!labelBlock) {
            return;
        }

        var actionNodes = [];
        var floatRights = labelBlock.querySelectorAll('[style*="float: right"], [style*="float:right"]');
        var i;
        for (i = 0; i < floatRights.length; i++) {
            var inputs = floatRights[i].querySelectorAll('input[type="image"], img[src*="plus"]');
            var j;
            for (j = 0; j < inputs.length; j++) {
                actionNodes.push(inputs[j]);
            }
        }

        var children = Array.prototype.slice.call(row.childNodes);
        var contentNodes = [];
        for (i = 0; i < children.length; i++) {
            var c = children[i];
            if (c.nodeType !== 1) {
                continue;
            }
            if (c === labelBlock || /only\d+px|onlyEmpty/i.test(c.className || "")) {
                continue;
            }
            contentNodes.push(c);
        }

        var actionWrap = document.createElement("div");
        actionWrap.className = "eprint-est-field-with-action";
        var controlWrap = document.createElement("div");
        controlWrap.className = "eprint-est-field-control";

        for (i = 0; i < contentNodes.length; i++) {
            clearFloatStyles(contentNodes[i]);
            controlWrap.appendChild(contentNodes[i]);
        }

        for (i = 0; i < actionNodes.length; i++) {
            var btnWrap = actionNodes[i].parentNode;
            if (btnWrap && labelBlock.contains(btnWrap)) {
                actionWrap.appendChild(btnWrap);
            } else {
                actionWrap.appendChild(actionNodes[i]);
            }
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

        row.setAttribute("data-eprint-normalized", "1");
    }

    function wrapScheduleRow(row) {
        if (!row) {
            return;
        }
        row.className = (row.className || "").replace(/\beprint-est-field-row\b/g, "").trim();
        row.className = (row.className + " eprint-est-date-chip").trim();
        row.setAttribute("data-eprint-field-wrapped", "1");
        normalizeFieldRow(row);
    }

    function decorateRow(row, fullWidth) {
        if (!row) {
            return;
        }
        row.className = (row.className || "").replace(/\beprint-est-date-chip\b/g, "").trim();
        row.className = (row.className || "").replace(/\beprint-est-field-row\b/g, "").trim();
        row.className = (row.className + " eprint-est-field-row").trim();
        if (fullWidth) {
            row.className += " full-width";
        }
        row.setAttribute("data-eprint-field-wrapped", "1");
        normalizeFieldRow(row);
    }

    function createCard(key) {
        var meta = SECTION_META[key];
        var card = document.createElement("section");
        card.className = "eprint-est-card";
        card.setAttribute("data-eprint-section", key);
        card.innerHTML =
            "<div class=\"eprint-est-card-head\"><h3>" + meta.title + "</h3><p>" + meta.hint + "</p></div>" +
            "<div class=\"eprint-est-card-body\"><div class=\"" + meta.grid + "\"></div></div>";
        return { card: card, grid: card.querySelector(".eprint-est-card-body > div") };
    }

    function moveHeaderActions(stage) {
        var header = stage.querySelector(".eprint-est-page-header");
        if (!header) {
            return;
        }
        var headerActions = header.querySelector(".eprint-est-header-actions");
        if (!headerActions) {
            headerActions = document.createElement("div");
            headerActions.className = "eprint-est-header-actions";
            header.appendChild(headerActions);
        }
        var nextWrap = document.getElementById("div_next");
        var editBar = document.getElementById("div_Estimate_btnEdit");
        var useEdit = editBar && editBar.style.display !== "none" &&
            window.getComputedStyle(editBar).display !== "none";

        if (useEdit) {
            if (editBar.parentNode !== headerActions) {
                headerActions.appendChild(editBar);
            }
            editBar.style.display = "block";
            editBar.style.cssFloat = "none";
            var saveBtn = findByIdSuffix("btnEditSave");
            if (saveBtn) {
                saveBtn.className = (saveBtn.className || "button") + " eprint-est-btn-primary";
            }
            var editCancel = findByIdSuffix("btnEditCancel");
            if (editCancel) {
                editCancel.className = (editCancel.className || "button") + " eprint-est-btn-ghost";
            }
        } else if (nextWrap && nextWrap.parentNode !== headerActions) {
            headerActions.appendChild(nextWrap);
            var btn = nextWrap.querySelector("input, button");
            if (btn) {
                btn.className = (btn.className || "button") + " eprint-est-btn-primary";
            }
        }

        var cancel = findByIdSuffix("btnCancel");
        if (cancel && cancel.parentNode !== headerActions && cancel.style.display !== "none") {
            cancel.className = (cancel.className || "button") + " eprint-est-btn-ghost";
            headerActions.insertBefore(cancel, headerActions.firstChild);
        }
        var addRow = document.getElementById("div_only_for_add");
        if (addRow && !useEdit) {
            addRow.style.display = "none";
        }
    }

    function rowUsesFullWidth(row) {
        var q;
        for (q in FULL_WIDTH) {
            if (FULL_WIDTH.hasOwnProperty(q) && rowContainsId(row, q)) {
                return true;
            }
        }
        return false;
    }

    function filterBucket(rows, section) {
        var out = [];
        var i;
        for (i = 0; i < rows.length; i++) {
            if (classifyRow(rows[i]) === section) {
                out.push(rows[i]);
            }
        }
        return out;
    }

    function countBucketRows(bucket) {
        var n = 0;
        var k;
        for (k in bucket) {
            if (bucket.hasOwnProperty(k) && bucket[k]) {
                n += bucket[k].length;
            }
        }
        return n;
    }

    function buildLayout() {
        try {
            var stage = document.getElementById("divStage1");
            if (!stage) {
                return;
            }

            if (stage.getAttribute("data-eprint-est-layout") === "1" && stage.querySelector(".eprint-est-layout")) {
                ensureStageVisible();
                moveHeaderActions(stage);
                return;
            }

            var left = stage.querySelector("#leftcol");
            var right = stage.querySelector("#rightcol");
            var columns = stage.querySelector(".eprint-est-columns");
            if (!left || !right) {
                return;
            }

            if (columns) {
                columns.classList.remove("eprint-est-columns-hidden");
            }

            ensureStageVisible();
            stage.classList.add("eprint-estimate-stage1");

            var layout = document.createElement("div");
            layout.className = "eprint-est-layout";

            var grids = {};
            var i;
            for (i = 0; i < SECTION_ORDER.length; i++) {
                var built = createCard(SECTION_ORDER[i]);
                grids[SECTION_ORDER[i]] = built.grid;
                layout.appendChild(built.card);
            }

            var used = [];
            var bucket = { customer: [], addresses: [], estimate: [], schedule: [], document: [] };

            function addRow(row) {
                if (!row || used.indexOf(row) >= 0) {
                    return;
                }
                var sec = classifyRow(row);
                if (!bucket[sec]) {
                    sec = "estimate";
                }
                bucket[sec].push(row);
                used.push(row);
            }

            function removeRowFromBuckets(row) {
                var k;
                if (!row) {
                    return;
                }
                for (k in bucket) {
                    if (bucket.hasOwnProperty(k)) {
                        bucket[k] = bucket[k].filter(function (r) { return r !== row; });
                    }
                }
                used = used.filter(function (r) { return r !== row; });
            }

            var leftRows = collectRows(left);
            var rightRows = collectRows(right);
            var scheduleRows = collectScheduleRows();
            var documentRows = collectDocumentRows();

            for (i = 0; i < leftRows.length; i++) {
                addRow(leftRows[i]);
            }
            for (i = 0; i < rightRows.length; i++) {
                addRow(rightRows[i]);
            }
            for (i = 0; i < scheduleRows.length; i++) {
                removeRowFromBuckets(scheduleRows[i]);
                addRow(scheduleRows[i]);
            }
            for (i = 0; i < documentRows.length; i++) {
                removeRowFromBuckets(documentRows[i]);
                addRow(documentRows[i]);
            }

            var validEl = findByIdSuffix("txtValidFor");
            if (validEl) {
                var validRow = null;
                var v = validEl.parentNode;
                while (v) {
                    if (v.getAttribute && v.getAttribute("align") === "left" &&
                            v.querySelector(".bglabelnew") && rowContainsId(v, "txtValidFor")) {
                        validRow = v;
                        break;
                    }
                    if (v.id === "divEstiDateInfo") {
                        break;
                    }
                    v = v.parentNode;
                }
                if (validRow) {
                    removeRowFromBuckets(validRow);
                    bucket.estimate.push(validRow);
                    used.push(validRow);
                }
            }

            bucket.schedule = filterBucket(bucket.schedule, "schedule");
            bucket.document = filterBucket(bucket.document, "document");
            bucket.customer = filterBucket(bucket.customer, "customer");
            bucket.estimate = filterBucket(bucket.estimate, "estimate");
            bucket.addresses = filterBucket(bucket.addresses, "addresses");

            if (countBucketRows(bucket) < 5) {
                return;
            }

            var placed = 0;

            function placeBucket(key, order) {
                var rows = bucket[key] || [];
                if (order) {
                    rows = sortRows(rows, order);
                }
                for (i = 0; i < rows.length; i++) {
                    var row = rows[i];
                    if (key === "schedule") {
                        wrapScheduleRow(row);
                    } else {
                        decorateRow(row, rowUsesFullWidth(row));
                    }
                    grids[key].appendChild(row);
                    placed++;
                }
            }

            placeBucket("customer", CUSTOMER_ORDER);
            placeBucket("addresses", ADDRESS_ORDER);
            placeBucket("estimate", ESTIMATE_ORDER);
            placeBucket("schedule", SCHEDULE_IDS);
            placeBucket("document", DOCUMENT_ORDER);

            var comment = document.getElementById("div_comment") || findByIdSuffix("div_comment");
            if (comment) {
                comment.style.display = "block";
            }

            if (placed < 5) {
                if (columns) {
                    columns.classList.remove("eprint-est-columns-hidden");
                }
                return;
            }

            if (columns) {
                columns.parentNode.insertBefore(layout, columns);
                columns.className = (columns.className || "") + " eprint-est-columns-hidden";
            } else {
                stage.appendChild(layout);
            }

            moveHeaderActions(stage);
            stage.setAttribute("data-eprint-est-layout", "1");
            stage.classList.add("eprint-est-layout-ready");
            window.setTimeout(function () { moveHeaderActions(stage); }, 50);
            window.setTimeout(function () { moveHeaderActions(stage); }, 400);
        } catch (err) {
            ensureStageVisible();
            var cols = document.querySelector("#divStage1 .eprint-est-columns");
            if (cols) {
                cols.classList.remove("eprint-est-columns-hidden");
            }
            if (window.console && window.console.warn) {
                window.console.warn("eprint-estimate-add layout skipped", err);
            }
        }
    }

    function tryBuild() {
        ensureStageVisible();
        buildLayout();
    }

    function init() {
        function run() {
            tryBuild();
        }
        if (document.readyState === "loading") {
            document.addEventListener("DOMContentLoaded", run);
        } else {
            run();
        }
        window.setTimeout(run, 300);
    }

    init();
    window.eprintEstimateAddLayout = {
        rebuild: function () {
            var stage = document.getElementById("divStage1");
            if (stage) {
                stage.removeAttribute("data-eprint-est-layout");
            }
            tryBuild();
        },
        ensureStageVisible: ensureStageVisible
    };
})(window, document);

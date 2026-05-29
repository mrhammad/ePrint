(function () {
  function normalizePath(path) {
    if (!path) return "";
    path = path.toLowerCase().split("?")[0];
    var idx = path.lastIndexOf("/");
    return idx >= 0 ? path.substring(idx + 1) : path;
  }

  function initSidebar() {
    var root = document.getElementById("eprintSidebar");
    if (!root) return;

    var currentFile = normalizePath(window.location.pathname);
    var activeSection = (root.getAttribute("data-active-section") || "").toUpperCase();

    var sectionMap = {
      HOME: ["dashboard.aspx", "welcome.aspx"],
      CLIENTS: ["client_view.aspx", "client_add.aspx", "client_detail.aspx", "client_report.aspx", "activity_callreport.aspx", "customviewcrm.aspx"],
      ESTIMATES: ["estimate_view.aspx", "estimates_add.aspx", "estimate_report.aspx", "estimate_summary", "proofs.aspx"],
      JOBS: ["jobs_view.aspx", "job_add.aspx", "job_report.aspx", "job_summary"],
      WebStoreorder: ["order_view.aspx", "order_report.aspx"],
      INVENTORY: ["warehouse.aspx", "inventory_add.aspx", "inventoryexport.aspx", "inventory_report.aspx", "customviewinv.aspx"],
      Warehouse: ["warehouse.aspx", "inventory_add.aspx", "inventoryexport.aspx"],
      Invoices: ["invoice_view.aspx", "invoices_add.aspx", "invoice_report.aspx"],
      PURCHASES: ["purchase_view.aspx", "purchase_report.aspx", "purchase_add.aspx"],
      DELIVERYNOTE: ["delivery_view.aspx", "delivery_report.aspx", "delivery_add.aspx"],
      PRODUCTCATALOGUE: ["pricecatalogue.aspx", "productcatalogue", "othercost_webstore", "pricecatalog_import.aspx", "productcatalogue_report.aspx"],
      Settings: ["settings.aspx", "storesettings.aspx"]
    };

    function fileMatchesSection(file, section) {
      var sectionKey = null;
      var target = (section || "").toUpperCase();
      for (var key in sectionMap) {
        if (sectionMap.hasOwnProperty(key) && key.toUpperCase() === target) {
          sectionKey = key;
          break;
        }
      }
      if (!sectionKey) return false;
      var keys = sectionMap[sectionKey];
      for (var i = 0; i < keys.length; i++) {
        if (file.indexOf(keys[i]) >= 0) return true;
      }
      return false;
    }

    root.querySelectorAll(".eprint-nav-item[data-section]").forEach(function (item) {
      var section = item.getAttribute("data-section") || "";
      if (activeSection && section.toUpperCase() === activeSection.toUpperCase()) {
        item.classList.add("active-module", "open");
      } else if (!activeSection && fileMatchesSection(currentFile, section)) {
        item.classList.add("active-module", "open");
      }
    });

    root.querySelectorAll(".eprint-nav-sub a[href]").forEach(function (link) {
      var href = link.getAttribute("href");
      if (!href || href === "#") return;
      var linkFile = normalizePath(href);
      if (linkFile && currentFile === linkFile) {
        link.classList.add("active");
        var parentItem = link.closest(".eprint-nav-item");
        if (parentItem) {
          parentItem.classList.add("open", "active-module");
        }
      }
    });

    root.querySelectorAll(".eprint-nav-toggle").forEach(function (btn) {
      btn.addEventListener("click", function (e) {
        e.preventDefault();
        var item = btn.closest(".eprint-nav-item");
        if (!item) return;
        var isOpen = item.classList.contains("open");
        root.querySelectorAll(".eprint-nav-item.open").forEach(function (other) {
          if (other !== item) other.classList.remove("open");
        });
        if (!isOpen) item.classList.add("open");
        else item.classList.remove("open");
      });
    });
  }

  if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", initSidebar);
  } else {
    initSidebar();
  }
})();

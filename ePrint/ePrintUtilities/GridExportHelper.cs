using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Telerik.Web.UI;

namespace ePrint.ePrintUtilities
{
    public class GridExportHelper
    {
        /// <summary>
        /// Exports a RadGrid to Excel (XLSX) file using ClosedXML.
        /// Handles filter visibility, paging, and export settings.
        /// </summary>
        /// <param name="grid">The Telerik RadGrid to export.</param>
        /// <param name="fileName">The output Excel file name (without extension).</param>
        /// <param name="data">The DataTable or data source to export.</param>
        /// <param name="response">The current HttpResponse (usually Response object).</param>
        public static void ExportGridToExcel(RadGrid grid, string fileName, DataTable data, HttpResponse response)
        {
            // Hide filtering rows
            GridItem[] filteringItems = grid.MasterTableView.GetItems(new GridItemType[] { GridItemType.FilteringItem });
            foreach (GridItem item in filteringItems)
            {
                ((GridFilteringItem)item).Visible = false;
            }

            // Adjust filtering and paging
            if (string.IsNullOrEmpty(grid.MasterTableView.FilterExpression))
            {
                grid.MasterTableView.AllowFilteringByColumn = false;
                grid.ExportSettings.IgnorePaging = true;
            }
            else
            {
                grid.ExportSettings.IgnorePaging = false;
                grid.MasterTableView.AllowFilteringByColumn = true;
            }

            // Basic export configurations
            grid.MasterTableView.GridLines = System.Web.UI.WebControls.GridLines.Both;
            grid.ExportSettings.ExportOnlyData = true;
            grid.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Bottom;

            // Clear filters for export
            foreach (GridColumn col in grid.MasterTableView.Columns)
            {
                col.CurrentFilterFunction = GridKnownFunction.NoFilter;
                col.CurrentFilterValue = string.Empty;
            }

            // Prepare dataset
            DataSet ds = new DataSet();
            ds.Tables.Add(data.Copy());

            // Build Excel workbook
            using (XLWorkbook wb = new XLWorkbook())
            {
                foreach (DataTable dt in ds.Tables)
                {
                    wb.Worksheets.Add(dt);
                }

                // Send as Excel file
                response.Clear();
                response.Buffer = true;
                response.Charset = "";
                response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                response.AddHeader("content-disposition", $"attachment;filename={fileName}.xlsx");

                using (MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    ms.WriteTo(response.OutputStream);
                    response.Flush();
                    response.End();
                }
            }
        }
    }
}
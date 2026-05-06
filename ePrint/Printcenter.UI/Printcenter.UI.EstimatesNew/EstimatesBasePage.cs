using nmsCommon;
using nmsConnectionClass;
using Printcenter.BusinessAccessLayer.Estimates;
using Printcenter.BusinessAccessLayer.EstimatesNew;
using Printcenter.UI.Estimates;
using Printcenter.UI.Jobs;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace Printcenter.UI.EstimatesNew
{
    public class EstimatesBasePage
    {
        public EstimatesBasePage()
        {
        }

        public static void AccountCode_Update_InSummary(int CompanyID, long EstimateItemID, string EstimateType, int AccountCodeID)
        {
            EstimateNew.AccountCode_Update_InSummary(CompanyID, EstimateItemID, EstimateType, AccountCodeID);
        }

        public static void Update_EstimateItems_SortingOrder(long EstimateItemID, int SortingOrderId, string pageName)
        {
            EstimateNew.Update_EstimateItems_SortingOrder(EstimateItemID, SortingOrderId, pageName);
        }

        public static DataTable AccountingCode_Select_forRerun(long EstimateID, long EstimateItemID, string estimatetype)
        {
            return EstimateNew.AccountingCode_Select_forRerun(EstimateID, EstimateItemID, estimatetype);
        }

        public static void AddMore_Supplier(long SupplierID, long SupplierContactID, long EstimateItemID)
        {
            EstimateNew.AddMore_Supplier(SupplierID, SupplierContactID, EstimateItemID);
        }

        public void Bind_Press(DropDownList ddl, int sqlParameter1, string defaultValue)
        {
            BaseClass baseClass = new BaseClass();
            DataTable dataTable = EstimatesBasePage.estimate_press_select(sqlParameter1);
            ddl.DataSource = dataTable;
            ddl.DataTextField = "PressName";
            ddl.DataValueField = "PressID";
            ddl.DataBind();
            foreach (DataRow row in dataTable.Rows)
            {
                if (!Convert.ToBoolean(row["IsDefaultPress"].ToString()))
                {
                    continue;
                }
                ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByText(row["PressName"].ToString()));
                break;
            }
            ddl.Items.Insert(0, " ");
            ddl.Items[0].Text = defaultValue;
            ddl.Items[0].Value = "0";
        }

        public static void booklet_delete(int CompanyID, long EstimateBookletItemID, string EstType)
        {
            EstimateNew.booklet_delete(CompanyID, EstimateBookletItemID, EstType);
        }

        public static long booklet_item_insert(EstimatesItem item)
        {
            return EstimateNew.booklet_item_insert(item);
        }

        public static DataTable booklet_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.booklet_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable booklet_job_qty(int CompanyID, long EstimateItemID, long EstimateBookletItemID)
        {
            return EstimateNew.booklet_job_qty(CompanyID, EstimateItemID, EstimateBookletItemID);
        }

        public static decimal Booklet_Print_Sheet_Calculation(int Quantity, decimal NoOfSignature, decimal SetupSpoilage, decimal RunningSpoilage, out decimal SpoilageSheets)
        {
            decimal quantity = Quantity * NoOfSignature;
            decimal runningSpoilage = (quantity * RunningSpoilage) / new decimal(100);
            decimal setupSpoilage = (quantity + runningSpoilage) + SetupSpoilage;
            setupSpoilage = Math.Ceiling(setupSpoilage);
            SpoilageSheets = Math.Ceiling(runningSpoilage + SetupSpoilage);
            return setupSpoilage;
        }

        public static DataSet Booklet_SelectSubsectioniddetail_byEstimateBookletItemID(int CompanyID, long EstimateItemID, string Estimationtype, long EstimateBookletItemID)
        {
            return EstimateNew.Booklet_SelectSubsectioniddetail_byEstimateBookletItemID(CompanyID, EstimateItemID, Estimationtype, EstimateBookletItemID);
        }

        public static DataSet bookletncr_subtotal_all_select(int CompanyID, long EstimateItemID, string EstimateType)
        {
            return EstimateNew.bookletncr_subtotal_all_select(CompanyID, EstimateItemID, EstimateType);
        }

        public static long calculation_insert_estimate(int CompanyID, string Data)
        {
            return EstimateNew.calculation_insert_estimate(CompanyID, Data);
        }

        public static string Check_EstimateItem_Transaction(long EstimateItemID)
        {
            return EstimateNew.Check_EstimateItem_Transaction(EstimateItemID);
        }

        public static bool Check_SpecialPrivilege_For_User(long UserID, long CompanyID)
        {
            return EstimateNew.Check_SpecialPrivilege_For_User(UserID, CompanyID);
        }

        public static DataTable CheckSubitemPresentsorNotinItemDescriptionpage(long ParentItemID, string ParentItemType)
        {
            return EstimateNew.CheckSubitemPresentsorNotinItemDescriptionpage(ParentItemID, ParentItemType);
        }

        public static decimal Click_Charge_Zone_Cost(int CompanyID, long EstimateCalculationID, decimal PaperForPress, string Colour, ref decimal ZoneMarkup)
        {
            ZoneMarkup = new decimal(0);
            DataTable dataTable = EstimateNew.estimate_click_charge_zone_range_check(CompanyID, EstimateCalculationID, PaperForPress, Colour);
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            foreach (DataRow row in dataTable.Rows)
            {
                int num2 = Convert.ToInt32(row["ZoneFrom"]);
                int num3 = Convert.ToInt32(row["ZoneTo"]);
                int num4 = num3 - num2;
                decimal num5 = new decimal(0);
                if (num4 <= 0)
                {
                    if (PaperForPress <= new decimal(0))
                    {
                        continue;
                    }
                    decimal num6 = Convert.ToDecimal(row["Markup"]) * PaperForPress;
                    ZoneMarkup = ZoneMarkup + num6;
                    decimal num7 = Convert.ToDecimal(row["cost"]) * PaperForPress;
                    num1 = num1 + num7;
                    num5 = EstimatesBasePage.PressCostPerClick(PaperForPress, Convert.ToDecimal(row["cost"]), Convert.ToInt32(row["ChargeableSheets"]));
                    num = num + num5;
                    break;
                }
                else
                {
                    decimal paperForPress = PaperForPress;
                    PaperForPress = PaperForPress - num4;
                    if (PaperForPress <= new decimal(0))
                    {
                        decimal num8 = Convert.ToDecimal(row["Markup"]) * paperForPress;
                        ZoneMarkup = ZoneMarkup + num8;
                        decimal num9 = Convert.ToDecimal(row["cost"]) * paperForPress;
                        num1 = num1 + num9;
                        num5 = EstimatesBasePage.PressCostPerClick(paperForPress, Convert.ToDecimal(row["cost"]), Convert.ToInt32(row["ChargeableSheets"]));
                        num = num + num5;
                        break;
                    }
                    else
                    {
                        decimal num10 = Convert.ToDecimal(row["Markup"]) * num4;
                        ZoneMarkup = ZoneMarkup + num10;
                        decimal num11 = Convert.ToDecimal(row["cost"]) * num4;
                        num1 = num1 + num11;
                        num5 = EstimatesBasePage.PressCostPerClick(num4, Convert.ToDecimal(row["cost"]), Convert.ToInt32(row["ChargeableSheets"]));
                        num = num + num5;
                    }
                }
            }
            if (num1 <= new decimal(0))
            {
                ZoneMarkup = new decimal(0);
            }
            else
            {
                ZoneMarkup = (ZoneMarkup * new decimal(100)) / num1;
            }
            return num;
        }

        public static decimal Click_Charge_Zone_Cost(int CompanyID, long EstimateCalculationID, decimal PaperForPress, string Colour, ref decimal ZoneMarkup, bool isDoubleSided, int PressID, int EstimateItemID, int QuantityNumber)
        {
            ZoneMarkup = new decimal(0);
            DataTable dataTable = EstimateNew.estimate_click_charge_zone_range_check(CompanyID, EstimateCalculationID, PaperForPress, Colour);
            dataTable.Rows[dataTable.Rows.Count - 1]["ZoneTo"] = 99999999;
            dataTable.AcceptChanges();
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            DataRow[] dataRowArray = dataTable.Select();
            decimal num2 = new decimal(0);
            int num3 = 0;
            DataTable item = new DataTable("Table1");
            if (HttpContext.Current.Session[string.Concat("ZoneMarkupCalcDetails", EstimateItemID.ToString())] != null)
            {
                item = (DataTable)HttpContext.Current.Session[string.Concat("ZoneMarkupCalcDetails", EstimateItemID.ToString())];
                string[] str = new string[] { " QuantityNumber=", QuantityNumber.ToString(), " and  EstimateItemID=", EstimateItemID.ToString(), " and PressID=", PressID.ToString(), " and Color='", Colour, "'" };
                DataRow[] dataRowArray1 = item.Select(string.Concat(str));
                if ((int)dataRowArray1.Length > 0)
                {
                    num2 = Convert.ToInt32(dataRowArray1[0]["RemainingQuantity"]);
                    num3 = Convert.ToInt32(dataRowArray1[0]["EstimateClickChargeZoneID"]);
                    if (num2 > new decimal(0))
                    {
                        dataRowArray = dataTable.Select(string.Concat(" RowNumber >=", num3));
                        if ((int)dataRowArray.Length > 0)
                        {
                            dataRowArray[0]["ZoneFrom"] = (Convert.ToInt32(dataRowArray[0].ItemArray[2]) - num2) + 1;
                        }
                    }
                    else if (num2 == new decimal(0) || num3 > 0)
                    {
                        dataRowArray = dataTable.Select(string.Concat(" RowNumber >", num3));
                    }
                }
            }
            else
            {
                item.Columns.Add("EstimateItemID", typeof(int));
                item.Columns.Add("RemainingQuantity", typeof(int));
                item.Columns.Add("EstimateClickChargeZoneID", typeof(int));
                item.Columns.Add("PressID", typeof(int));
                item.Columns.Add("Color", typeof(string));
                item.Columns.Add("QuantityNumber", typeof(int));
                HttpContext.Current.Session[string.Concat("ZoneMarkupCalcDetails", EstimateItemID.ToString())] = item;
            }
            if ((int)dataRowArray.Length == 0)
            {
                dataRowArray = dataTable.Select(" EstimateClickChargeZoneID = max(EstimateClickChargeZoneID)");
            }
            DataRow[] dataRowArray2 = dataRowArray;
            for (int i = 0; i < (int)dataRowArray2.Length; i++)
            {
                DataRow dataRow = dataRowArray2[i];
                int num4 = Convert.ToInt32(dataRow["ZoneFrom"]);
                int num5 = Convert.ToInt32(dataRow["ZoneTo"]);
                int num6 = num5 - (num4 - 1);
                decimal num7 = new decimal(0);
                if (num6 > 0)
                {
                    decimal paperForPress = PaperForPress;
                    PaperForPress = PaperForPress - num6;
                    if (PaperForPress <= new decimal(0))
                    {
                        decimal num8 = Convert.ToDecimal(dataRow["Markup"]) * paperForPress;
                        ZoneMarkup = ZoneMarkup + num8;
                        decimal num9 = Convert.ToDecimal(dataRow["cost"]) * paperForPress;
                        num1 = num1 + num9;
                        num7 = EstimatesBasePage.PressCostPerClick(paperForPress, Convert.ToDecimal(dataRow["cost"]), Convert.ToInt32(dataRow["ChargeableSheets"]));
                        num = num + num7;
                        num2 = num5 - (num4 + paperForPress) - 1;
                        num3 = Convert.ToInt32(dataRow["RowNumber"]);
                        break;
                    }
                    else
                    {
                        decimal num10 = Convert.ToDecimal(dataRow["Markup"]) * num6;
                        ZoneMarkup = ZoneMarkup + num10;
                        decimal num11 = Convert.ToDecimal(dataRow["cost"]) * num6;
                        num1 = num1 + num11;
                        num7 = EstimatesBasePage.PressCostPerClick(num6, Convert.ToDecimal(dataRow["cost"]), Convert.ToInt32(dataRow["ChargeableSheets"]));
                        num = num + num7;
                        num2 = num5 - (num4 + num6 - 1);
                        num3 = Convert.ToInt32(dataRow["RowNumber"]);
                    }
                }
            }
            item = (DataTable)HttpContext.Current.Session[string.Concat("ZoneMarkupCalcDetails", EstimateItemID.ToString())];
            string[] strArrays = new string[] { " QuantityNumber=", QuantityNumber.ToString(), " and  EstimateItemID=", EstimateItemID.ToString(), " and PressID=", PressID.ToString(), " and Color='", Colour, "'" };
            DataRow[] dataRowArray3 = item.Select(string.Concat(strArrays));
            if ((int)dataRowArray3.Length > 0)
            {
                item.Rows.Remove(dataRowArray3[0]);
            }
            object[] estimateItemID = new object[] { EstimateItemID, num2, num3, PressID, Colour, QuantityNumber };
            item.Rows.Add(estimateItemID);
            HttpContext.Current.Session[string.Concat("ZoneMarkupCalcDetails", EstimateItemID.ToString())] = item;
            if (num1 <= new decimal(0))
            {
                ZoneMarkup = new decimal(0);
            }
            else
            {
                ZoneMarkup = (ZoneMarkup * new decimal(100)) / num1;
            }
            return num;
        }

        public static decimal Click_Charge_Zone_Cost_new(int CompanyID, long EstCalculationID, int PaperForPress, string Colour)
        {
            DataTable dataTable = EstimatesBasePage.estimate_zone_calculation_1(CompanyID, EstCalculationID, PaperForPress, Colour);
            decimal num = new decimal(0);
            foreach (DataRow row in dataTable.Rows)
            {
                int num1 = Convert.ToInt32(row["ZoneFrom"]);
                int num2 = Convert.ToInt32(row["ZoneTo"]);
                int num3 = num2 - num1;
                decimal num4 = new decimal(0);
                if (num3 <= 0)
                {
                    if (PaperForPress <= 0)
                    {
                        continue;
                    }
                    num4 = EstimatesBasePage.PressCostPerClick(PaperForPress, Convert.ToDecimal(row["ChargeableRate"]), Convert.ToInt32(row["ChargeableSheets"]));
                    num = num + num4;
                    break;
                }
                else
                {
                    int paperForPress = PaperForPress;
                    PaperForPress = PaperForPress - num3;
                    if (PaperForPress <= 0)
                    {
                        num4 = EstimatesBasePage.PressCostPerClick(paperForPress, Convert.ToDecimal(row["ChargeableRate"]), Convert.ToInt32(row["ChargeableSheets"]));
                        num = num + num4;
                        break;
                    }
                    else
                    {
                        num4 = EstimatesBasePage.PressCostPerClick(num3, Convert.ToDecimal(row["ChargeableRate"]), Convert.ToInt32(row["ChargeableSheets"]));
                        num = num + num4;
                    }
                }
            }
            return num;
        }

        public static DataTable client_tax_select(int CompanyID, int CustomerID)
        {
            return EstimateNew.client_tax_select(CompanyID, CustomerID);
        }

        public static DataTable Clients_New_Contact_Select(int CompanyID, int ClientID)
        {
            return EstimateNew.Clients_New_Contact_Select(CompanyID, ClientID);
        }

        public static long copy_booklet_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return EstimateNew.copy_booklet_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long Copy_Estimate(int CompanyID, long Old_EstimateID, string moduleType, ref bool IsJobAdded)
        {
            long num = (long)0;
            int num1 = 0;
            if (moduleType == "invoice")
            {
                if (JobBasePage.job_check_estimate(CompanyID, Old_EstimateID) != (long)0)
                {
                    IsJobAdded = true;
                }
                else
                {
                    IsJobAdded = false;
                }
            }
            DateTime now = DateTime.Now;
            num = EstimatesBasePage.Estimate_Copy_Estimate_Insert(CompanyID, Old_EstimateID, "", num1, now.ToString(), ConnectionClass.IsHandy, "", (long)0);
            foreach (DataRow row in EstimatesBasePage.Estimate_Item_ID_Select(CompanyID, Old_EstimateID).Rows)
            {
                string str = row["EstimateType"].ToString();
                long num2 = Convert.ToInt64(row["EstimateItemID"]);
                long num3 = (long)0;
                string str1 = row["IsParentItem"].ToString();
                if (string.Compare(str, "S", true) == 0)
                {
                    num3 = EstimatesBasePage.SingelItem_Inset_By_Copy(CompanyID, Old_EstimateID, num, num2, str1);
                }
                if (!(moduleType == "job") || num2 == (long)0 || num3 == (long)0)
                {
                    if (!(moduleType == "invoice") || !IsJobAdded)
                    {
                        continue;
                    }
                    JobBasePage.copy_jobcard(CompanyID, num2, num3);
                }
                else
                {
                    JobBasePage.copy_jobcard(CompanyID, num2, num3);
                }
            }
            return num;
        }

        public static long copy_large_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return EstimateNew.copy_large_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long copy_othercost_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return EstimateNew.copy_othercost_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long copy_outwork_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return EstimateNew.copy_outwork_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long copy_pad_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return EstimateNew.copy_pad_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long copy_price_catalogue(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return EstimateNew.copy_price_catalogue(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static long copy_warehouse_item(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID)
        {
            return EstimateNew.copy_warehouse_item(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID);
        }

        public static DataTable CopyesttitletoitemTitle(int Companyid, long EstimateID)
        {
            return EstimateNew.CopyesttitletoitemTitle(Companyid, EstimateID);
        }

        public static DataTable Copying_ArtworkFile(long CompanyID, long EstimateItemID)
        {
            return EstimateNew.Copying_ArtworkFile(CompanyID, EstimateItemID);
        }

        public static void copyJobInvoice_isdirect(int CompanyID, long EstimateID, string Isdirect)
        {
            EstimateNew.copyJobInvoice_isdirect(CompanyID, EstimateID, Isdirect);
        }

        public static DataTable cost_view_for_booklet(int CompanyID, long EstimateItemID, long EstimateBookletItemID)
        {
            return EstimateNew.cost_view_for_booklet(CompanyID, EstimateItemID, EstimateBookletItemID);
        }

        public static void delete_on_booklet(int CompanyID, long EstimateItemID)
        {
            EstimateNew.delete_on_booklet(CompanyID, EstimateItemID);
        }

        public static void deletencrsection(long Estimateitemid, int DelPartsCount)
        {
            EstimateNew.deletencrsection(Estimateitemid, DelPartsCount);
        }

        public static void Estimate_AccountingCode_Insert(int AccountCodeID, long EstimateID, long CompanyID)
        {
            EstimateNew.Estimate_AccountingCode_Insert(AccountCodeID, EstimateID, CompanyID);
        }

        public static int Estimate_AccountingCode_Select(long EstimateID, long CompanyID)
        {
            return EstimateNew.Estimate_AccountingCode_Select(EstimateID, CompanyID);
        }

        public static DataTable estimate_booklet_item_onQtyNumber_select(int CompanyID, long EstimateItemID, int QtyNumber)
        {
            return EstimateNew.estimate_booklet_item_onQtyNumber_select(CompanyID, EstimateItemID, QtyNumber);
        }

        public static DataTable estimate_booklet_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_booklet_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_Calculation_select(int CompanyID, long EstimateItemID, long EstimateBNLBItemID)
        {
            return EstimateNew.estimate_Calculation_select(CompanyID, EstimateItemID, EstimateBNLBItemID);
        }

        public static DataTable estimate_click_charge_zone_2nd_calculation(int CompanyID, long EstimateCalculationID, decimal TotalSheets, string ZoneType)
        {
            return EstimateNew.estimate_click_charge_zone_2nd_calculation(CompanyID, EstimateCalculationID, TotalSheets, ZoneType);
        }

        public static void estimate_click_charge_zone_insert(int CompanyID, long EstimateCalculationID, long PressID)
        {
            EstimateNew.estimate_click_charge_zone_insert(CompanyID, EstimateCalculationID, PressID);
        }

        public static DataTable estimate_click_charge_zone_range_check(int CompanyID, long EstimateCalculationID, int TotalSheets, string ZoneType)
        {
            return EstimateNew.estimate_click_charge_zone_range_check(CompanyID, EstimateCalculationID, TotalSheets, ZoneType);
        }

        public static void Estimate_Copy(int CompanyID, long EstimateID, string EstimateNumber, int UserID)
        {
            EstimateNew.Estimate_Copy(CompanyID, EstimateID, EstimateNumber, UserID);
        }

        public static long estimate_copy_all(int CompanyID, long ModuleID, long NewEstimateID, string pgType, string DirectJObOrInvoice, string Date, bool IsHandy, int newCustomer)
        {
            return EstimateNew.estimate_copy_all(CompanyID, ModuleID, NewEstimateID, pgType, DirectJObOrInvoice, Date, IsHandy, newCustomer);
        }

        public static long Estimate_Copy_Estimate_Insert(int CompanyID, long Old_EstimateID, string DirectJObOrInvoice, int UserID, string Date, bool IsHandy, string Pgtype, long ModuleID)
        {
            return EstimateNew.Estimate_Copy_Estimate_Insert(CompanyID, Old_EstimateID, DirectJObOrInvoice, UserID, Date, IsHandy, Pgtype, ModuleID);
        }
        public static long EstimateCopyEstimateInsert(int CompanyID, long Old_EstimateID, string DirectJObOrInvoice, int UserID, string Date, bool IsHandy, string Pgtype, long ModuleID,DateTime Estimateartworkdate,DateTime Estimatedeliverydate,DateTime JobCompletionDate,DateTime ProofDate,DateTime ApprovalDate,DateTime ProductionDate)
        {
            return EstimateNew.EstimateCopyEstimateInsert(CompanyID, Old_EstimateID, DirectJObOrInvoice, UserID, Date, IsHandy, Pgtype, ModuleID,Estimateartworkdate,Estimatedeliverydate,JobCompletionDate,ProofDate,ApprovalDate,ProductionDate);
        }
        public static DataTable estimate_delivery_quantity_details_select(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, string PageType)
        {
            return EstimateNew.estimate_delivery_quantity_details_select(CompanyID, EstimateID, EstimateItemID, EstimateType, PageType);
        }

        public static DataTable estimate_deliverynote_ByJobID_selectall(int CompanyID, long JobID)
        {
            return EstimateNew.estimate_deliverynote_ByJobID_selectall(CompanyID, JobID);
        }

        public static DataTable estimate_deliverynote_onitemid_selectall(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType)
        {
            return EstimateNew.estimate_deliverynote_onitemid_selectall(CompanyID, EstimateID, EstimateItemID, EstimateType);
        }

        public static DataTable estimate_deliverynote_onitemid_selectIndividual(int CompanyID, long EstimateID, long EstimateItemID)
        {
            return EstimateNew.estimate_deliverynote_onitemid_selectIndividual(CompanyID, EstimateID, EstimateItemID);
        }

        public static DataTable estimate_deliverynote_Select_ByDeleveryID(int CompanyID, long DeleveryID)
        {
            return EstimateNew.estimate_deliverynote_Select_ByDeleveryID(CompanyID, DeleveryID);
        }

        public static DataTable Estimate_ESTID_JOBID_INVID_Select(long EstimateItemID)
        {
            return EstimateNew.Estimate_ESTID_JOBID_INVID_Select(EstimateItemID);
        }

        public static DataTable estimate_EstimateID_select_reeng_ByInvoice(int CompanyID, long InvoiceID, string Pgtype)
        {
            return EstimateNew.estimate_EstimateID_select_reeng_ByInvoice(CompanyID, InvoiceID, Pgtype);
        }

        public static DataTable estimate_EstTotalPriceDetails_Update(long EstimateItemID)
        {
            return EstimateNew.estimate_EstTotalPriceDetails_Update(EstimateItemID);
        }

        public static DataSet estimate_for_litho_add_all(int CompanyID)
        {
            return EstimateNew.estimate_for_litho_add_all(CompanyID);
        }

        public static DataSet estimate_for_Digital_add_all(int CompanyID)
        {
            return EstimateNew.estimate_for_Digital_add_all(CompanyID);
        }

        public static long Estimate_Insert(int CompanyID, int UserID, int CustomerID, long AttentionID, string Greeting, string Company, long Address, string Header, string Footer, int SalesPerson, string EstimateTitle, string EstimateNumber, string OrderNumber, int StatusID, DateTime EstimateDate, int ValidFor, long DeliveryAddress, bool IsConvertedToJob, DateTime ModifiedDate, int ModifiedBy, long EstimateID, bool IsForInvoice, string AddressType, string DelAddressType, long CurrentEstNo, DateTime EstimatedArtwork, DateTime EstimatedDelivery, string PageType, DateTime JobCompletionDate, DateTime ProofDate, DateTime ApprovalDate, DateTime ProdcnDate, long InvoiceAddressID, long DepartmentID, long CostCentreID, int estimatorid, string comments, long InvoiceContactId, string priority, DateTime? customDate1, DateTime? customDate2, DateTime? customDate3, DateTime? customDate4, DateTime? customDate5)
        {
            return EstimateNew.Estimate_Insert(CompanyID, UserID, CustomerID, AttentionID, Greeting, Company, Address, Header, Footer, SalesPerson, EstimateTitle, EstimateNumber, OrderNumber, StatusID, EstimateDate, ValidFor, DeliveryAddress, IsConvertedToJob, ModifiedDate, ModifiedBy, EstimateID, IsForInvoice, AddressType, DelAddressType, CurrentEstNo, EstimatedArtwork, EstimatedDelivery, PageType, JobCompletionDate, ProofDate, ApprovalDate, ProdcnDate, InvoiceAddressID, DepartmentID, CostCentreID, estimatorid,comments,  InvoiceContactId,  priority, customDate1, customDate2, customDate3, customDate4, customDate5);
        }

        public static int estimate_iscompleted_select(int CompanyID, long EstimateID)
        {
            return EstimateNew.estimate_iscompleted_select(CompanyID, EstimateID);
        }

        public static void Estimate_Item_AccountCode_Insert(long EstimateItemID, int AccountCodeID)
        {
            EstimateNew.Estimate_Item_AccountCode_Insert(EstimateItemID, AccountCodeID);
        }

        public static DataTable estimate_item_detail_outwork_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_item_detail_outwork_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_item_detail_quantities_select(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, long EstimateBookletItemID)
        {
            return EstimateNew.estimate_item_detail_quantities_select(CompanyID, EstimateID, EstimateItemID, EstimateType, EstimateBookletItemID);
        }

        public static void estimate_item_details_insert(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType)
        {
            EstimateNew.estimate_item_details_insert(CompanyID, EstimateID, EstimateItemID, EstimateType);
        }

        public static DataTable estimate_item_details_select(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType)
        {
            return EstimateNew.estimate_item_details_select(CompanyID, EstimateID, EstimateItemID, EstimateType);
        }

        public static DataTable estimate_item_details_selectall(int CompanyID, long EstimateItemID, string EstimateType)
        {
            return EstimateNew.estimate_item_details_selectall(CompanyID, EstimateItemID, EstimateType);
        }

        public static void estimate_item_details_update(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, int Qty1, int Qty2, int Qty3, int Qty4, string ReqPrePress, string ReqPress, string ReqPostPress, string ReqPriceCatalogue, string ReqOutwork, string ReqWarehouse, string ReqAdmin)
        {
            EstimateNew.estimate_item_details_update(CompanyID, EstimateID, EstimateItemID, EstimateType, Qty1, Qty2, Qty3, Qty4, ReqPrePress, ReqPress, ReqPostPress, ReqPriceCatalogue, ReqOutwork, ReqWarehouse, ReqAdmin);
        }

        public static DataTable Estimate_Item_ID_Select(int CompanyID, long EstimateID)
        {
            return EstimateNew.Estimate_Item_ID_Select(CompanyID, EstimateID);
        }

        public static DataSet estimate_item_info_select_by_qtynumber_new(int CompanyID, long EstimateItemID, int QtyNumber, string ItemType)
        {
            return EstimateNew.estimate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
        }

        public static DataSet estimate_item_info_select_by_qtynumber_new_SubItem_LargFormt(int CompanyID, long EstimateItemID, int QtyNumber, string ItemType, long EstimateItemIDForRaisePO)
        {
            return EstimateNew.estimate_item_info_select_by_qtynumber_new_SubItem_LargFormt(CompanyID, EstimateItemID, QtyNumber, ItemType, EstimateItemIDForRaisePO);
        }

        public static long Estimate_Item_Insert(int CompanyID, long EstimateID, string EstimateType, bool IsParentItem, long ParentItemID, long ProductID = 0)
        {
            return EstimateNew.Estimate_Item_Insert(CompanyID, EstimateID, EstimateType, IsParentItem, ParentItemID, ProductID);
        }

        public static string estimate_item_quantity_fordelivery_select(int CompanyID, long EstimateItemID, long ItemID, string ItemType, int QtyNumber)
        {
            return EstimateNew.estimate_item_quantity_fordelivery_select(CompanyID, EstimateItemID, ItemID, ItemType, QtyNumber);
        }

        public static DataTable estimate_item_select(int CompanyID, long EstimateID)
        {
            return EstimateNew.estimate_item_select(CompanyID, EstimateID);
        }

        public static DataTable estimate_item_select_ByModule(int CompanyID, long ModuleID, string Pgtype)
        {
            return EstimateNew.estimate_item_select_ByModule(CompanyID, ModuleID, Pgtype);
        }

        public static DataTable estimate_item_select_reeng(int CompanyID, long EstimateID, string Pgtype)
        {
            return EstimateNew.estimate_item_select_reeng(CompanyID, EstimateID, Pgtype);
        }
        public static DataTable estimate_summary_select(long ModuleID, string ModuleType)
        {
            return EstimateNew.estimate_summary_total(ModuleID, ModuleType);
        }

        public static DataTable estimate_item_select_reeng_ByInvoice(int CompanyID, long InvoiceID, string Pgtype)
        {
            return EstimateNew.estimate_item_select_reeng_ByInvoice(CompanyID, InvoiceID, Pgtype);
        }

        public static DataTable estimate_item_select_reeng_ByJob(int CompanyID, long JobID, string Pgtype)
        {
            return EstimateNew.estimate_item_select_reeng_ByJob(CompanyID, JobID, Pgtype);
        }

        public static void estimate_item_title_update(int CompanyID, long EstimateItemID, string ItemTitle, string EstimateType)
        {
            EstimateNew.estimate_item_title_update(CompanyID, EstimateItemID, ItemTitle, EstimateType);
        }

        public static DataTable estimate_item_total_price_details_select(int CompanyID, long EstimateItemID, string EstimateType)
        {
            return EstimateNew.estimate_item_total_price_details_select(CompanyID, EstimateItemID, EstimateType);
        }

        public static DataTable estimate_item_total_price_details_update(long EstimateID, long EstimateItemID, long SectionID, string EstimateType, decimal TotalProfitMarginPercentage1, decimal TotalProfitMarginPercentage2, decimal TotalProfitMarginPercentage3, decimal TotalProfitMarginPercentage4, decimal TotalProfitMarginPrice1, decimal TotalProfitMarginPrice2, decimal TotalProfitMarginPrice3, decimal TotalProfitMarginPrice4, decimal TotalSubTotal1, decimal TotalSubTotal2, decimal TotalSubTotal3, decimal TotalSubTotal4, int TotalTaxID1, int TotalTaxID2, int TotalTaxID3, int TotalTaxID4, decimal TotalTaxPercentage1, decimal TotalTaxPercentage2, decimal TotalTaxPercentage3, decimal TotalTaxPercentage4, decimal TotalTaxPrice1, decimal TotalTaxPrice2, decimal TotalTaxPrice3, decimal TotalTaxPrice4, decimal TotalSellingPrice1, decimal TotalSellingPrice2, decimal TotalSellingPrice3, decimal TotalSellingPrice4, decimal TotalGrossProfitPercentage1, decimal TotalGrossProfitPercentage2, decimal TotalGrossProfitPercentage3, decimal TotalGrossProfitPercentage4, decimal TotalGrossProfitPrice1, decimal TotalGrossProfitPrice2, decimal TotalGrossProfitPrice3, decimal TotalGrossProfitPrice4, bool IsSubTotalLocked, decimal SellingPricePerSQM1, decimal SellingPricePerSQM2, decimal SellingPricePerSQM3, decimal SellingPricePerSQM4, decimal SubTotalUnitPrice1, decimal SubTotalUnitPrice2, decimal SubTotalUnitPrice3, decimal SubTotalUnitPrice4)
        {
            return EstimateNew.estimate_item_total_price_details_update(EstimateID, EstimateItemID, SectionID, EstimateType, TotalProfitMarginPercentage1, TotalProfitMarginPercentage2, TotalProfitMarginPercentage3, TotalProfitMarginPercentage4, TotalProfitMarginPrice1, TotalProfitMarginPrice2, TotalProfitMarginPrice3, TotalProfitMarginPrice4, TotalSubTotal1, TotalSubTotal2, TotalSubTotal3, TotalSubTotal4, TotalTaxID1, TotalTaxID2, TotalTaxID3, TotalTaxID4, TotalTaxPercentage1, TotalTaxPercentage2, TotalTaxPercentage3, TotalTaxPercentage4, TotalTaxPrice1, TotalTaxPrice2, TotalTaxPrice3, TotalTaxPrice4, TotalSellingPrice1, TotalSellingPrice2, TotalSellingPrice3, TotalSellingPrice4, TotalGrossProfitPercentage1, TotalGrossProfitPercentage2, TotalGrossProfitPercentage3, TotalGrossProfitPercentage4, TotalGrossProfitPrice1, TotalGrossProfitPrice2, TotalGrossProfitPrice3, TotalGrossProfitPrice4, IsSubTotalLocked,  SellingPricePerSQM1,  SellingPricePerSQM2,  SellingPricePerSQM3,  SellingPricePerSQM4, SubTotalUnitPrice1, SubTotalUnitPrice2, SubTotalUnitPrice3, SubTotalUnitPrice4);
        }

        public static DataTable estimate_itemandsubitem_select(long EstimateID)
        {
            return EstimateNew.estimate_itemandsubitem_select(EstimateID);
        }

        public static int Estimate_Items_Count_Select(int CompanyID, long EstimateID)
        {
            return EstimateNew.Estimate_Items_Count_Select(CompanyID, EstimateID);
        }

        public static void Estimate_Items_Delete(int CompanyID, long EstimateItemID, string Estimatetype)
        {
            EstimateNew.Estimate_Items_Delete(CompanyID, EstimateItemID, Estimatetype);
        }

        public static DataTable Estimate_Items_Quantity_Select(int CompanyID, int EstimateItemID, string EstType)
        {
            return EstimateNew.Estimate_Items_Quantity_Select(CompanyID, EstimateItemID, EstType);
        }

        public static DataTable Estimate_Items_RFQdescription_Select(int CompanyID, long EstimateID, string ModuleType)
        {
            return EstimateNew.Estimate_Items_RFQdescription_Select(CompanyID, EstimateID, ModuleType);
        }

        public static DataTable Estimate_ProofItems_RFQdescription_Select(int CompanyID, long EstimateID, string ModuleType)
        {
            return EstimateNew.Estimate_ProofItems_RFQdescription_Select(CompanyID, EstimateID, ModuleType);
        }
        // create delivery note
        public static DataTable Estimate_ByEstimateItemId_Select(int CompanyID, long EstimateItemID, string ModuleType)
        {
            return EstimateNew.Estimate_ByEstimateItemId_Select(CompanyID, EstimateItemID, ModuleType);
        }
        public static DataTable Estimate_Items_Select(int CompanyID, long EstimateID)
        {
            return EstimateNew.Estimate_Items_Select(CompanyID, EstimateID);
        }

        public static DataSet estimate_itemtitle_select(int CompanyID, long EstimateItemID, string ItemType, int qtynumber)
        {
            return EstimateNew.estimate_itemtitle_select(CompanyID, EstimateItemID, ItemType, qtynumber);
        }

        public static void estimate_itemtitle_update(long EstimateID, string EstimateTitle)
        {
            EstimateNew.estimate_itemtitle_update(EstimateID, EstimateTitle);
        }

        public static DataTable estimate_large_item_ink(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_large_item_ink(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_large_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_large_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_largeitemMetarals_select(long EstimateItemID)
        {
            return EstimateNew.estimate_largeitemMetarals_select(EstimateItemID);
        }

        public static DataTable estimate_litho_booklet_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_litho_booklet_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_Litho_ink_select(int CompanyID, long PressID)
        {
            return EstimateNew.estimate_Litho_ink_select(CompanyID, PressID);
        }

        public static DataTable estimate_litho_ink_select_inkcost_popup(int CompanyID, long EstimateItemID, string SectionName, string CalType)
        {
            return EstimateNew.estimate_litho_ink_select_inkcost_popup(CompanyID, EstimateItemID, SectionName, CalType);
        }

        public static long estimate_litho_NCR_item_insert(int CompanyID, int EstimateLithoNcrItemID, long EstimateItemID, long PressID, long PaperID, bool IsPricePerPack, bool IsPaperSupplied, decimal SetUpSpoilage, decimal RunningSpoilage, string sidesprinted, string side1Color, string side2Color, long PlateID, string Noofplates, string NoofMakeReady, string NoofWashup, int PrintSheetSizeID, bool IsSheetCustom, decimal SheetHeight, decimal SheetWidth, int JobFlatSizeID, bool IsJobCustom, decimal JobHeight, decimal JobWidth, bool IsIncludeGutters, decimal GutterHorizontal, decimal GutterVertical, bool IsPressRestrictions, long GuillotineID, int CreatedBy, int ModifiedBy, DateTime CreatedDate, bool IsDeleted, string ItemTitle, string ItemDescription, bool IsFirstTrim, bool IsSecondTrim, bool WorknTurn, bool WorknTumble, int ParentItemID, string ParentItemType, string SectionReference, decimal NcrPartsPerSet, decimal NcrSetsPerPad, string NcrImageType, string NcrPadFormat, string PrintLayout, decimal PortraitValue, decimal LandscapeValue, string Ncrcommonfrom, bool Perfecting, decimal ManualValue,bool sheetwork)
        {
            return EstimateNew.estimate_litho_NCR_item_insert(CompanyID, EstimateLithoNcrItemID, EstimateItemID, PressID, PaperID, IsPricePerPack, IsPaperSupplied, SetUpSpoilage, RunningSpoilage, sidesprinted, side1Color, side2Color, PlateID, Noofplates, NoofMakeReady, NoofWashup, PrintSheetSizeID, IsSheetCustom, SheetHeight, SheetWidth, JobFlatSizeID, IsJobCustom, JobHeight, JobWidth, IsIncludeGutters, GutterHorizontal, GutterVertical, IsPressRestrictions, GuillotineID, CreatedBy, ModifiedBy, CreatedDate, IsDeleted, ItemTitle, ItemDescription, IsFirstTrim, IsSecondTrim, WorknTurn, WorknTumble, ParentItemID, ParentItemType, SectionReference, NcrPartsPerSet, NcrSetsPerPad, NcrImageType, NcrPadFormat, PrintLayout, PortraitValue, LandscapeValue, Ncrcommonfrom, Perfecting, ManualValue, sheetwork);
        }

        public static DataTable estimate_litho_ncr_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_litho_ncr_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_digital_ncr_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_digital_ncr_item_select(CompanyID, EstimateItemID);
        }

        public static long estimate_litho_pad_item_insert(int CompanyID, long EstimateLithoPadItemID, long EstimateItemID, long PressID, long PaperID, bool IsPricePerPack, bool IsPaperSupplied, decimal SetupSpoilage, decimal RunningSpoilage, decimal LeavesPerPad, string SidesPrinted, string Side1Color, string Side2Color, long PlateID, string Noofplates, string NoofMakeReady, string NoofWashup, int PrintSheetSizeID, bool IsSheetCustom, decimal SheetHeight, decimal SheetWidth, int JobFlatSizeID, bool IsJobCustom, decimal JobHeight, decimal JobWidth, bool IsIncludeGutters, decimal GutterHorizontal, decimal GutterVertical, bool IsPressRestrictions, string PrintLayout, decimal PortraitValue, decimal LandscapeValue, long GuillotineID, string ItemTitle, int CreatedBy, int ModifiedBy, DateTime ModifiedDate, bool IsFirstTrim, bool IsSecondTrim, bool WorknTurn, bool WorknTumble, int ParentItemID, string ParentItemType, bool Perfecting, decimal ManualValue,bool worksheet)
        {
            return EstimateNew.estimate_litho_pad_item_insert(CompanyID, EstimateLithoPadItemID, EstimateItemID, PressID, PaperID, IsPricePerPack, IsPaperSupplied, SetupSpoilage, RunningSpoilage, LeavesPerPad, SidesPrinted, Side1Color, Side2Color, PlateID, Noofplates, NoofMakeReady, NoofWashup, PrintSheetSizeID, IsSheetCustom, SheetHeight, SheetWidth, JobFlatSizeID, IsJobCustom, JobHeight, JobWidth, IsIncludeGutters, GutterHorizontal, GutterVertical, IsPressRestrictions, PrintLayout, PortraitValue, LandscapeValue, GuillotineID, ItemTitle, CreatedBy, ModifiedBy, ModifiedDate, IsFirstTrim, IsSecondTrim, WorknTurn, WorknTumble, ParentItemID, ParentItemType, Perfecting, ManualValue, worksheet);
        }

        public static DataTable estimate_litho_pad_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_litho_pad_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_litho_pad_item_select_reeng(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_litho_pad_item_select_reeng(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_litho_plate_select_popup(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_litho_plate_select_popup(CompanyID, EstimateItemID);
        }

        public static DataTable Estimate_Litho_Press_Select(int CompanyID, long PressID)
        {
            return EstimateNew.Estimate_Litho_Press_Select(CompanyID, PressID);
        }

        public static DataTable Estimate_Digital_Press_Select_byPressID(int CompanyID, long PressID)
        {
            return EstimateNew.Estimate_Digital_Press_Select_byPressID(CompanyID, PressID);
        }

        public static DataTable estimate_litho_single_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_litho_single_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_lithobooklet_ink_select_inkcost_popup(int CompanyID, long EstimateItemID, long TypeID, string SectionName, string CalType)
        {
            return EstimateNew.estimate_lithobooklet_ink_select_inkcost_popup(CompanyID, EstimateItemID, TypeID, SectionName, CalType);
        }

        public static DataTable estimate_lithobooklet_plateswashupmakeready_popup(int CompanyID, long EstimateItemID, long EstimateLithoBookletItemID)
        {
            return EstimateNew.estimate_lithobooklet_plateswashupmakeready_popup(CompanyID, EstimateItemID, EstimateLithoBookletItemID);
        }

        public static DataTable estimate_lithoNCR_ink_select_inkcost_popup(int CompanyID, long EstimateItemID, long TypeID, string SectionName, string CalType)
        {
            return EstimateNew.estimate_lithoNCR_ink_select_inkcost_popup(CompanyID, EstimateItemID, TypeID, SectionName, CalType);
        }

        public static DataTable estimate_lithoNCR_select_popup(int CompanyID, long EstimateItemID, long EstimateLithoNcrItemID)
        {
            return EstimateNew.estimate_lithoNCR_select_popup(CompanyID, EstimateItemID, EstimateLithoNcrItemID);
        }

        public static DataTable estimate_lithoPad_ink_select_inkcost_popup(int CompanyID, long EstimateItemID, string SectionName, string CalType)
        {
            return EstimateNew.estimate_lithoPad_ink_select_inkcost_popup(CompanyID, EstimateItemID, SectionName, CalType);
        }

        public static DataTable estimate_lithoPad_plate_select_popup(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_lithoPad_plate_select_popup(CompanyID, EstimateItemID);
        }

        public static void estimate_lithopress_delete_ink(int CompanyID, long PressID, long EstimateItemID, string EstType, long EstimateLithoItemID)
        {
            EstimateNew.estimate_lithopress_delete_ink(CompanyID, PressID, EstimateItemID, EstType, EstimateLithoItemID);
        }

        public static IDataReader estimate_lithopress_select_ink_count(int CompanyID, long LithoPressID, long EstimateItemID, string side, long EstimateLithoNCRItemID, long EstimateLithobookletItemID)
        {
            return EstimateNew.estimate_lithopress_select_ink_count(CompanyID, LithoPressID, EstimateItemID, side, EstimateLithoNCRItemID, EstimateLithobookletItemID);
        }

        public static DataTable estimate_lithopress_select_ink_name_item_desc(int CompanyID, long EstimateItemID, string side, long EstimateLithoNCRItemID, long EstimateLithobookletItemID, string esttype)
        {
            return EstimateNew.estimate_lithopress_select_ink_name_item_desc(CompanyID, EstimateItemID, side, EstimateLithoNCRItemID, EstimateLithobookletItemID, esttype);
        }

        public static IDataReader estimate_lithopress_select_ink_rownum(int CompanyID, long LithoPressID, int rownum, long EstimateItemID, string side, long EstimateLithoNCRItemID, long EstimateLithobookletItemID, string sidenumber)
        {
            return EstimateNew.estimate_lithopress_select_ink_rownum(CompanyID, LithoPressID, rownum, EstimateItemID, side, EstimateLithoNCRItemID, EstimateLithobookletItemID, sidenumber);
        }

        public static void estimate_number_update(int CompanyID, long EstimateID, bool IsHandy)
        {
            EstimateNew.estimate_number_update(CompanyID, EstimateID, IsHandy);
        }

        public static DataTable estimate_othercost_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_othercost_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_othercost_press_details_select(long CompanyID, long EstimateItemID, string EstimateType, long BookletSectionID)
        {
            return EstimateNew.estimate_othercost_press_details_select(CompanyID, EstimateItemID, EstimateType, BookletSectionID);
        }

        public static DataTable estimate_othercost_ProfitTax_select(long EstimateItemID, long EstOthercostID)
        {
            return EstimateNew.estimate_othercost_ProfitTax_select(EstimateItemID, EstOthercostID);
        }

        public static string estimate_othercost_select_new(int CompanyID, string EstimateType, long TypeID, string MainOrSubItem)
        {
            return EstimateNew.estimate_othercost_select_new(CompanyID, EstimateType, TypeID, MainOrSubItem);
        }

        public static DataTable estimate_othercost_subitem_costview(int CompanyID, long EstOtherCostID)
        {
            return EstimateNew.estimate_othercost_subitem_costview(CompanyID, EstOtherCostID);
        }

        public static DataTable estimate_othercost_subitem_select(int CompanyID, long TypeID)
        {
            return EstimateNew.estimate_othercost_subitem_select(CompanyID, TypeID);
        }

        public static void estimate_othercost_typeid_update(int CompanyID, long EstimateItemID, string EstimateType, long TypeID)
        {
            EstimateNew.estimate_othercost_typeid_update(CompanyID, EstimateItemID, EstimateType, TypeID);
        }

        public static long estimate_othercost_variableqty_insert(int CompanyID, long EstOtherCostVariableID, long EstOtherCostID, long EstQuantityID, decimal HoursOrQty, decimal Cost, string EstType, string FormulaWithActual, int Quantity, int qtynumber, string FinalFormulaTag)
        {
            return EstimateNew.estimate_othercost_variableqty_insert(CompanyID, EstOtherCostVariableID, EstOtherCostID, EstQuantityID, HoursOrQty, Cost, EstType, FormulaWithActual, Quantity, qtynumber, FinalFormulaTag);
        }

        public static DataSet estimate_Othercostitem_info(int CompanyID, long EstimateID, int QtyNumber, string ItemType)
        {
            return EstimateNew.estimate_Othercostitem_info(CompanyID, EstimateID, QtyNumber, ItemType);
        }

        public static void Estimate_OtherWare_MainItems_Pricing_Update(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, decimal CostPrice1ExMarkup, decimal TotalMarkupPrice1, int QtyNumber, long EstOutworkSupplierID)
        {
            EstimateNew.Estimate_OtherWare_MainItems_Pricing_Update(CompanyID, EstimateID, EstimateItemID, EstimateType, CostPrice1ExMarkup, TotalMarkupPrice1, QtyNumber, EstOutworkSupplierID);
        }

        public static void Estimate_Outwork_Insert(int CompanyID, string Query)
        {
            EstimateNew.Estimate_Outwork_Insert(CompanyID, Query);
        }

        public static DataTable estimate_outwork_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_outwork_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_pad_item_onQtyNumber_select(int CompanyID, long EstimateItemID, int QtyNumber)
        {
            return EstimateNew.estimate_pad_item_onQtyNumber_select(CompanyID, EstimateItemID, QtyNumber);
        }

        public static DataTable estimate_pad_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_pad_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_press_select(int companyID)
        {
            return EstimateNew.estimate_press_select(companyID);
        }

        public static DataTable estimate_Digital_press_select(int companyID)
        {
            return EstimateNew.estimate_Digital_press_select(companyID);
        }

        public static DataTable estimate_price_catalogue_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_price_catalogue_item_select(CompanyID, EstimateItemID);
        }

        public static string estimate_printbroker_itemdescription_select(int CompanyID, long EstimateItemID, string EstimateType, string SelectType)
        {
            return EstimateNew.estimate_printbroker_itemdescription_select(CompanyID, EstimateItemID, EstimateType, SelectType);
        }

        public static DataTable estimate_printbroker_select(int CompanyID, long EstOutworkID)
        {
            return EstimateNew.estimate_printbroker_select(CompanyID, EstOutworkID);
        }

        public static DataTable estimate_printbroker_select_new(int CompanyID, long EstOutworkID, int rownumber)
        {
            return EstimateNew.estimate_printbroker_select_new(CompanyID, EstOutworkID, rownumber);
        }

        public static DataTable estimate_printbroker_subitem_select(int CompanyID, long EstOutworkID)
        {
            return EstimateNew.estimate_printbroker_subitem_select(CompanyID, EstOutworkID);
        }

        public static DataTable estimate_printbroker_suppliers_count(int CompanyID, string Estype, long TypeID)
        {
            return EstimateNew.estimate_printbroker_suppliers_count(CompanyID, Estype, TypeID);
        }

        public static DataTable estimate_qty_onQtyNumber_select(int CompanyID, long EstimateItemID, long EstimateBookletItemID, int QtyNumber)
        {
            return EstimateNew.estimate_qty_onQtyNumber_select(CompanyID, EstimateItemID, EstimateBookletItemID, QtyNumber);
        }

        public static DataTable estimate_qty_select(int CompanyID, long EstimateItemID, long EstimateBookletItemID)
        {
            return EstimateNew.estimate_qty_select(CompanyID, EstimateItemID, EstimateBookletItemID);
        }

        public static DataTable estimate_qty_select_for_booklet(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_qty_select_for_booklet(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_quantity_forcostview_select(int CompanyID, long EstimateItemID, string EstimateType)
        {
            return EstimateNew.estimate_quantity_forcostview_select(CompanyID, EstimateItemID, EstimateType);
        }

        public static DataTable estimate_quantity_select_new(int CompanyID, long EstimateItemID, long EstimateBookletItemID)
        {
            return EstimateNew.estimate_quantity_select_new(CompanyID, EstimateItemID, EstimateBookletItemID);
        }

        public static DataTable estimate_quick_quote_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_quick_quote_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_DeliveryCost_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_DeliveryCost_item_select(CompanyID, EstimateItemID);
        }

        public static void Estimate_quickquote_insert(EstimatesItem item, bool IsHandy)
        {
            EstimateNew.Estimate_quickquote_insert(item, IsHandy);
        }

        public static void Estimate_DeliveryCost_insert(EstimatesItem item, bool IsHandy)
        {
            EstimateNew.Estimate_DeliveryCost_insert(item, IsHandy);
        }

        public static DataTable estimate_RaisePoOrders_Selectitems(long EstimateID)
        {
            return EstimateNew.estimate_RaisePoOrders_Selectitems(EstimateID);
        }

        public static DataTable estimate_select_litho_details_all(int CompanyID, int LithoPressID)
        {
            return EstimateNew.estimate_select_litho_details_all(CompanyID, LithoPressID);
        }

        public static DataTable estimate_select_litho_ink_count(int CompanyID, int LithoPressID)
        {
            return EstimateNew.estimate_select_litho_ink_count(CompanyID, LithoPressID);
        }

        public static DataTable estimate_select_paper_size(int CompanyID)
        {
            return EstimateNew.estimate_select_paper_size(CompanyID);
        }

        public static DataTable estimate_select_summary(int CompanyID, long EstimateID)
        {
            return EstimateNew.estimate_select_summary(CompanyID, EstimateID);
        }

        public static DataTable order_select_summary(int CompanyID, long EstimateID)
        {
            return EstimateNew.order_select_summary(CompanyID, EstimateID);
        }
        public static DataTable estimate_select_summary_new(int CompanyID, long EstimateID)
        {
            return EstimateNew.estimate_select_summary_new(CompanyID, EstimateID);
        }

        public static DataTable PC_Proof_select_summary_new(int CompanyID, long EstimateID)
        {
            return EstimateNew.PC_Proof_select_summary_new(CompanyID, EstimateID);
        }

        public static DataTable estimate_select_summary_PerItem(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_select_summary_PerItem(CompanyID, EstimateItemID);
        }

        public static DataTable proof_select_summary_PerItem(int CompanyID, long ProofItemID)
        {
            return EstimateNew.proof_select_summary_PerItem(CompanyID, ProofItemID);
        }

        public static DataTable estimate_single_item_onQtyNumber_select(int CompanyID, long EstimateItemID, int QtyNumber)
        {
            return EstimateNew.estimate_single_item_onQtyNumber_select(CompanyID, EstimateItemID, QtyNumber);
        }

        public static DataTable estimate_single_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_single_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable Estimate_Single_Item_Select_By_EstimateItemID(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.Estimate_Single_Item_Select_By_EstimateItemID(CompanyID, EstimateItemID);
        }

        public static DataTable Estimate_SingleItem_Subitem_By_EstimateItemID(int CompanyID, long EstimateItemID, string esttype)
        {
            return EstimateNew.Estimate_SingleItem_Subitem_By_EstimateItemID(CompanyID, EstimateItemID, esttype);
        }

        public static void estimate_speed_weight_insert(int CompanyID, long EstimateCalculationID, long PressID)
        {
            EstimateNew.estimate_speed_weight_insert(CompanyID, EstimateCalculationID, PressID);
        }

        public static DataTable estimate_speedweight_select(int CompanyID, long EstimateCalculationID)
        {
            return EstimateNew.estimate_speedweight_select(CompanyID, EstimateCalculationID);
        }

        public static void estimate_sub_item_delete(string EstimateType, long EstimateItemID, long ItemTypeID)
        {
            EstimateNew.estimate_sub_item_delete(EstimateType, EstimateItemID, ItemTypeID);
        }

        public static void estimate_subitem_delete(string EstimateType, long EstimateItemID, long EstimateSPLBWOCU)
        {
            EstimateNew.estimate_subitem_delete(EstimateType, EstimateItemID, EstimateSPLBWOCU);
        }

        public static void estimate_subitem_delete_FromSummary(string EstimateType, long EstimateItemID)
        {
            EstimateNew.estimate_subitem_delete_FromSummary(EstimateType, EstimateItemID);
        }

        public static DataTable estimate_subitem_select(long EstimateID, long ParentItemID)
        {
            return EstimateNew.estimate_subitem_select(EstimateID, ParentItemID);
        }

        public static DataTable estimate_subitem_select_New(long ParentItemID)
        {
            return EstimateNew.estimate_subitem_select_New(ParentItemID);
        }

        public static DataSet Estimate_Subitem_showonItemdesc(int CompanyID, long EstimateItemID, string Estimationtype)
        {
            return EstimateNew.Estimate_Subitem_showonItemdesc(CompanyID, EstimateItemID, Estimationtype);
        }

        public static DataTable Estimate_Summary_Calculation_Select_By_EstimateItem_ID(int CompanyID, long EstimateItemID, long EstBookletSectionID)
        {
            return EstimateNew.Estimate_Summary_Calculation_Select_By_EstimateItem_ID(CompanyID, EstimateItemID, EstBookletSectionID);
        }

        public static void Estimate_Summary_EstimateValues_Update(int CompanyID, long EstimateID, decimal EstimateValue, decimal EstimateSubTotal, int EstimateTotalQuantity)
        {
            EstimateNew.Estimate_Summary_EstimateValues_Update(CompanyID, EstimateID, EstimateValue, EstimateSubTotal, EstimateTotalQuantity);
        }

        public static decimal Estimate_Summary_Guillotine_Standard_Table(int CompanyID, decimal Printlayout, string IsGutter)
        {
            return EstimateNew.Estimate_Summary_Guillotine_Standard_Table(CompanyID, Printlayout, IsGutter);
        }

        public static string Estimate_Summary_Item_Warehouse_Cost(int CompanyID, long TypeID, string ItemType)
        {
            return EstimateNew.Estimate_Summary_Item_Warehouse_Cost(CompanyID, TypeID, ItemType);
        }

        public static DataTable estimate_summary_items_othercost_select_new(int CompanyID, string EstimateType, long TypeID, long EstOtherCostID)
        {
            return EstimateNew.estimate_summary_items_othercost_select_new(CompanyID, EstimateType, TypeID, EstOtherCostID);
        }

        public static DataTable Estimate_Summary_Items_select_by_EstimateID(int CompanyID, long EstimateID)
        {
            return EstimateNew.Estimate_Summary_Items_select_by_EstimateID(CompanyID, EstimateID);
        }

        public static DataTable Estimate_Summary_Large_Item_By_EstimateItem_ID(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.Estimate_Summary_Large_Item_By_EstimateItem_ID(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_summary_othercost_by_estimateitem_id_new(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_summary_othercost_by_estimateitem_id_new(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_summary_outwork_taxprofitmargin_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_summary_outwork_taxprofitmargin_select(CompanyID, EstimateItemID);
        }

        public static DataTable Estimate_Summary_Pad_Item_By_EstimateItem_ID(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.Estimate_Summary_Pad_Item_By_EstimateItem_ID(CompanyID, EstimateItemID);
        }

        public static void Estimate_Warehouse_Insert(int CompanyID, string Query, long EstimateItemID)
        {
            EstimateNew.Estimate_Warehouse_Insert(CompanyID, Query, EstimateItemID);
        }

        public static DataTable estimate_warehouse_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.estimate_warehouse_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable estimate_zone_calculation_1(int CompanyID, long EstimateCalculationID, int TotalSheets, string ZoneType)
        {
            return EstimateNew.estimate_zone_calculation_1(CompanyID, EstimateCalculationID, TotalSheets, ZoneType);
        }

        public static void estimate_zone_markup_update(int CompanyID, long EstimateCalculationID, decimal Markup)
        {
            EstimateNew.estimate_zone_markup_update(CompanyID, EstimateCalculationID, Markup);
        }

        public static DataTable EstimateHistory(long SupplierID, long EstimateItemID)
        {
            return EstimateNew.EstimateHistory(SupplierID, EstimateItemID);
        }

        public static void EstimateItem_Archive(int CompanyID, long EstimateItemID, string ModuleType)
        {
            EstimateNew.EstimateItem_Archive(CompanyID, EstimateItemID, ModuleType);
        }
        public static void ProofItem_Archive(int CompanyID, long ProofItemID)
        {
            EstimateNew.ProofItem_Archive(CompanyID, ProofItemID);
        }
        public static void EstimateItem_Delete(int CompanyID, long EstimateItemID, string ModuleType, bool Keep_EstimateJOB_LIVE)
        {
            EstimateNew.EstimateItem_Delete(CompanyID, EstimateItemID, ModuleType, Keep_EstimateJOB_LIVE);
        }
        public static void ProofItem_Delete(int CompanyID, long ProofItemID, string ModuleType, bool Keep_EstimateJOB_LIVE)
        {
            EstimateNew.ProofItem_Delete(CompanyID, ProofItemID, ModuleType, Keep_EstimateJOB_LIVE);
        }

        public static void EstimateItem_UnArchive(int CompanyID, long EstimateItemID, string ModuleType)
        {
            EstimateNew.EstimateItem_UnArchive(CompanyID, EstimateItemID, ModuleType);
        }

        public static DataTable EstimateitemIDList_PerEstID(long EstimateID)
        {
            return EstimateNew.EstimateitemIDList_PerEstID(EstimateID);
        }

        public static DataTable EstimateitemIDList_PerEstItemID(long EstimateItemID)
        {
            return EstimateNew.EstimateitemIDList_PerEstItemID(EstimateItemID);
        }

        public static DataTable estimateitemselect_reeng(int CompanyID, long EstimateItemID, string Pgtype)
        {
            return EstimateNew.estimateitemselect_reeng(CompanyID, EstimateItemID, Pgtype);
        }

        public static long EstimateItemsOnCheck_Status_Update(int CompanyID, string EstimateItemIDs, int StatusID, string Module)
        {
            return EstimateNew.EstimateItemsOnCheck_Status_Update(CompanyID, EstimateItemIDs, StatusID, Module);
        }

        public static void estimatenumberupdateandiscomplete(int CompanyID, long EstimateID, long EstimateItemID, bool IsHandy)
        {
            EstimateNew.estimatenumberupdateandiscomplete(CompanyID, EstimateID, EstimateItemID, IsHandy);
        }

        public static void EstimateOnCheck_Status_Update(int CompanyID, string EstimateIDs, int StatusID, string Module)
        {
            Estimate.EstimateOnCheck_Status_Update(CompanyID, EstimateIDs, StatusID, Module);
        }

        public static DataSet estimatePlate_item_info_select_by_qtynumber_new(int CompanyID, long EstimateItemID, int QtyNumber, string ItemType)
        {
            return EstimateNew.estimatePlate_item_info_select_by_qtynumber_new(CompanyID, EstimateItemID, QtyNumber, ItemType);
        }

        public static void estimates_litho_markup_calculation_insert(int CompanyID, long EstimateCalculationID)
        {
            EstimateNew.estimates_litho_markup_calculation_insert(CompanyID, EstimateCalculationID);
        }
        public static void estimates_litho_markup_calculation_insertnew(int CompanyID, long EstimateCalculationID,long PressID)
        {
            EstimateNew.estimates_litho_markup_calculation_insertnew(CompanyID, EstimateCalculationID,PressID);
        }
        public static void estimates_litho_markup_calculation_update(int CompanyID, long EstimateItemID, decimal Markup, string EstCalType, long EstimateBookletItemID, string EstimateType)
        {
            EstimateNew.estimates_litho_markup_calculation_update(CompanyID, EstimateItemID, Markup, EstCalType, EstimateBookletItemID, EstimateType);
        }

        public static DataTable estimates_litho_press_matrix_select_By_ID(int CompanyID, long EstimateCalculationID)
        {
            return EstimateNew.estimates_litho_press_matrix_select_By_ID(CompanyID, EstimateCalculationID);
        }

        public static void estimates_markup_calculation_update(int CompanyID, long EstimateCalculationID, decimal Markup, string EstCalType, long EstimateBookletItemID, string EstimateType, decimal Markup2, decimal Markup3, decimal Markup4, decimal MarkupPrice1, decimal MarkupPrice2, decimal MarkupPrice3, decimal MarkupPrice4, decimal CostExMarkup1, decimal CostExMarkup2, decimal CostExMarkup3, decimal CostExMarkup4, string Module, decimal CostExMarkup_Actual1, decimal CostExMarkup_Actual2, decimal CostExMarkup_Actual3, decimal CostExMarkup_Actual4)
        {
            EstimateNew.estimates_markup_calculation_update(CompanyID, EstimateCalculationID, Markup, EstCalType, EstimateBookletItemID, EstimateType, Markup2, Markup3, Markup4, MarkupPrice1, MarkupPrice2, MarkupPrice3, MarkupPrice4, CostExMarkup1, CostExMarkup2, CostExMarkup3, CostExMarkup4, Module, CostExMarkup_Actual1, CostExMarkup_Actual2, CostExMarkup_Actual3, CostExMarkup_Actual4);
        }

        public static void estimates_markup_calculation_update_ForPressZone(int CompanyID, long EstimateCalculationID, long TypeID, string EstimateType, decimal Zone_Side1_PressMarkupPercentage1, decimal Zone_Side1_PressMarkupPercentage2, decimal Zone_Side1_PressMarkupPercentage3, decimal Zone_Side1_PressMarkupPercentage4, decimal Zone_Side2_PressMarkupPercentage1, decimal Zone_Side2_PressMarkupPercentage2, decimal Zone_Side2_PressMarkupPercentage3, decimal Zone_Side2_PressMarkupPercentage4, decimal Zone_Side1_PressMarkupPrice1, decimal Zone_Side1_PressMarkupPrice2, decimal Zone_Side1_PressMarkupPrice3, decimal Zone_Side1_PressMarkupPrice4, decimal Zone_Side2_PressMarkupPrice1, decimal Zone_Side2_PressMarkupPrice2, decimal Zone_Side2_PressMarkupPrice3, decimal Zone_Side2_PressMarkupPrice4, decimal PressMarkupPrice1, decimal PressMarkupPrice2, decimal PressMarkupPrice3, decimal PressMarkupPrice4, string Module, decimal PressCostExMarkup1, decimal PressCostExMarkup2, decimal PressCostExMarkup3, decimal PressCostExMarkup4, decimal PressCostExMarkup_Actual1, decimal PressCostExMarkup_Actual2, decimal PressCostExMarkup_Actual3, decimal PressCostExMarkup_Actual4)
        {
            EstimateNew.estimates_markup_calculation_update_ForPressZone(CompanyID, EstimateCalculationID, TypeID, EstimateType, Zone_Side1_PressMarkupPercentage1, Zone_Side1_PressMarkupPercentage2, Zone_Side1_PressMarkupPercentage3, Zone_Side1_PressMarkupPercentage4, Zone_Side2_PressMarkupPercentage1, Zone_Side2_PressMarkupPercentage2, Zone_Side2_PressMarkupPercentage3, Zone_Side2_PressMarkupPercentage4, Zone_Side1_PressMarkupPrice1, Zone_Side1_PressMarkupPrice2, Zone_Side1_PressMarkupPrice3, Zone_Side1_PressMarkupPrice4, Zone_Side2_PressMarkupPrice1, Zone_Side2_PressMarkupPrice2, Zone_Side2_PressMarkupPrice3, Zone_Side2_PressMarkupPrice4, PressMarkupPrice1, PressMarkupPrice2, PressMarkupPrice3, PressMarkupPrice4, Module, PressCostExMarkup1, PressCostExMarkup2, PressCostExMarkup3, PressCostExMarkup4, PressCostExMarkup_Actual1, PressCostExMarkup_Actual2, PressCostExMarkup_Actual3, PressCostExMarkup_Actual4);
        }

        public static void estimates_Materialmarkup_calculation_update(int CompanyID, long EstimateCalculationID, string EstimateType, decimal Markup1, decimal Markup2, decimal Markup3, decimal Markup4, decimal MarkupPrice1, decimal MarkupPrice2, decimal MarkupPrice3, decimal MarkupPrice4, decimal CostExMarkup1, decimal CostExMarkup2, decimal CostExMarkup3, decimal CostExMarkup4, string Module)
        {
            EstimateNew.estimates_Materialmarkup_calculation_update(CompanyID, EstimateCalculationID, EstimateType, Markup1, Markup2, Markup3, Markup4, MarkupPrice1, MarkupPrice2, MarkupPrice3, MarkupPrice4, CostExMarkup1, CostExMarkup2, CostExMarkup3, CostExMarkup4, Module);
        }

        public static string estimates_outworkdescription_printemail_select(int CompanyID, long EstOutworkID)
        {
            return EstimateNew.estimates_outworkdescription_printemail_select(CompanyID, EstOutworkID);
        }

        public static string estimates_quantity_select(int CompanyID, long EstimateItemID, string EstimateType)
        {
            return EstimateNew.estimates_quantity_select(CompanyID, EstimateItemID, EstimateType);
        }

        public static void estimates_zonemarkup_update(int CompanyID, long EstimateCalculationID, decimal Markup, string EstCalType, long EstimateBookletItemID, string EstimateType, string ZoneType)
        {
            EstimateNew.estimates_zonemarkup_update(CompanyID, EstimateCalculationID, Markup, EstCalType, EstimateBookletItemID, EstimateType, ZoneType);
        }

        public static void estimateslitho_popup_ink_insert(int CompanyID, long estimateitemid, long inkid, decimal coverage, long PressID, string Side, long LithoItemID, string EstimateType, string sidenumber, string SectionName, decimal InkCostExMarkup1, decimal InkCostExMarkup2, decimal InkCostExMarkup3, decimal InkCostExMarkup4, decimal InkMarkup1, decimal InkMarkup2, decimal InkMarkup3, decimal InkMarkup4, decimal InkMarkupPrice1, decimal InkMarkupPrice2, decimal InkMarkupPrice3, decimal InkMarkupPrice4, decimal InkSetupCharge, decimal InkMinimumCharge, decimal InkCostExMarkup_Actual1, decimal InkCostExMarkup_Actual2, decimal InkCostExMarkup_Actual3, decimal InkCostExMarkup_Actual4)
        {
            EstimateNew.estimateslitho_popup_ink_insert(CompanyID, estimateitemid, inkid, coverage, PressID, Side, LithoItemID, EstimateType, sidenumber, SectionName, InkCostExMarkup1, InkCostExMarkup2, InkCostExMarkup3, InkCostExMarkup4, InkMarkup1, InkMarkup2, InkMarkup3, InkMarkup4, InkMarkupPrice1, InkMarkupPrice2, InkMarkupPrice3, InkMarkupPrice4, InkSetupCharge, InkMinimumCharge, InkCostExMarkup_Actual1, InkCostExMarkup_Actual2, InkCostExMarkup_Actual3, InkCostExMarkup_Actual4);
        }

        public static DataTable EstimatItem_Details_Select(int CompanyID, long EstimateID, string PageType)
        {
            return EstimateNew.EstimatItem_Details_Select(CompanyID, EstimateID, PageType);
        }

        public static DataTable estitem_select_ToConvertProductCatalogue(int CompanyID, long EstimateID, long PrarentItemID, string Pgtype)
        {
            return EstimateNew.estitem_select_ToConvertProductCatalogue(CompanyID, EstimateID, PrarentItemID, Pgtype);
        }

        public static DataTable EstPriceCatAddOptionDetailsSelect(long EstimateItemID)
        {
            return EstimateNew.EstPriceCatAddOptionDetailsSelect(EstimateItemID);
        }

        public static DataTable Get_Details_EstimateItems_PriceCatalogueType(long EstimateItemID, int QtyNumber)
        {
            return EstimateNew.Get_Details_EstimateItems_PriceCatalogueType(EstimateItemID, QtyNumber);
        }

        public static DataTable Get_EstimateItems_Type_PriceCatalogue(long EstimateID)
        {
            return EstimateNew.Get_EstimateItems_Type_PriceCatalogue(EstimateID);
        }

        public static DataTable Get_KitDetails_EstimateItems_PriceCatalogueType(long PriceCatalogueID, int Quantity)
        {
            return EstimateNew.Get_KitDetails_EstimateItems_PriceCatalogueType(PriceCatalogueID, Quantity);
        }

        public static string GetEstimateType_EstimateItemID(long EstimateItemID)
        {
            return EstimateNew.GetEstimateType_EstimateItemID(EstimateItemID);
        }
        public static int GetPriceCatalogueIDByEstimateItemID(long EstimateItemID)
        {
            return EstimateNew.GetPriceCatalogueIDByEstimateItemID(EstimateItemID);
        }
        public static DataTable GetPriceCatalogueIDByEstimateID(int CompanyID, long EstimateID)
        {
            return EstimateNew.GetPriceCatalogueIDByEstimateID(CompanyID, EstimateID);
        }
        public static StringBuilder getExactValues(StringBuilder col1, StringBuilder col2)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] strArrays = new string[] { "," };
            string[] strArrays1 = col1.ToString().Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
            string[] strArrays2 = col2.ToString().Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                for (int i = 0; i < (int)strArrays1.Length; i++)
                {
                    stringBuilder.Append(string.Concat((Convert.ToInt32(strArrays1[i].ToString()) + Convert.ToInt32(strArrays2[i].ToString())) / 2, ","));
                }
            }
            catch
            {
            }
            return stringBuilder;
        }

        public static StringBuilder GetGsm(StringBuilder gsm)
        {
            string[] strArrays = new string[] { "," };
            string[] strArrays1 = gsm.ToString().Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < (int)strArrays1.Length; i++)
            {
                if (i == 0 || i == 5 || i == 10)
                {
                    stringBuilder.Append(string.Concat(strArrays1[i].ToString(), ','));
                }
            }
            return stringBuilder;
        }

        public static decimal GetPrintSheetCalulation(int Quantity, decimal PrintLayoutvalue, decimal Setupspoilage, decimal RunningSpoilage, decimal Supportvalue, string EstimateType, decimal CustomVal, string Customval2, out decimal SpoilageSheets)
        {
            decimal num = new decimal(0);
            decimal runningSpoilage = new decimal(0);
            decimal num1 = new decimal(0);
            if (EstimateType.ToLower() == "singleitem")
            {
                if (PrintLayoutvalue > new decimal(0))
                {
                    num = Quantity / PrintLayoutvalue;
                }
            }
            else if (EstimateType.ToLower() == "booklet")
            {
                num = Quantity * Supportvalue;
            }
            else if (PrintLayoutvalue > new decimal(0))
            {
                num = (Quantity * Supportvalue) / PrintLayoutvalue;
            }
            runningSpoilage = (num * RunningSpoilage) / new decimal(100);
            SpoilageSheets = Math.Ceiling(Setupspoilage + runningSpoilage);
            return Math.Ceiling(num) + SpoilageSheets;
        }

        public static int GetProductId_ByEstimatetItemId(int CompanyId, int EstimateItemId)
        {
            return EstimateNew.GetProductId_ByEstimatetItemId(CompanyId, EstimateItemId);
        }

        public static decimal GetProfitMargin(int CompanyID, long EstimateID)
        {
            decimal num = new decimal(0);
            try
            {
                foreach (DataRow row in EstimateNew.Profit_Margin_By_Client_System(CompanyID, EstimateID).Rows)
                {
                    num = (Convert.ToDecimal(row["CustomerProfit"]) > new decimal(0) || Convert.ToDecimal(row["CustomerProfit"]) < new decimal(0) ? Convert.ToDecimal(row["CustomerProfit"].ToString().Replace("%", "")) : Convert.ToDecimal(row["SystemProfit"].ToString().Replace("%", "")));
                }
            }
            catch
            {
            }
            return num;
        }

        public static decimal GetProfitMargin_InvoiceID(int CompanyID, long InvoiceID)
        {
            decimal num = new decimal(0);
            try
            {
                foreach (DataRow row in EstimateNew.Profit_Margin_By_Client_System_InvoiceID(CompanyID, InvoiceID).Rows)
                {
                    num = (Convert.ToDecimal(row["CustomerProfit"]) > new decimal(0) || Convert.ToDecimal(row["CustomerProfit"]) < new decimal(0) ? Convert.ToDecimal(row["CustomerProfit"].ToString().Replace("%", "")) : Convert.ToDecimal(row["SystemProfit"].ToString().Replace("%", "")));
                }
            }
            catch
            {
            }
            return num;
        }

        public static bool TaxPrecedence_Select(long EsTimateId)
        {
            bool num = false;
            try
            {
                foreach (DataRow row in EstimateNew.TaxPrecedence_Select(EsTimateId).Rows)
                {
                    num = (Convert.ToBoolean(row["TaxPrecedence"]));
                }
            }
            catch
            {
            }
            return num;
        }

        public static DataTable getQuantity_for_items(long ParentEstimateItemID, string ParentEstimateType, string estimate)
        {
            return EstimateNew.getQuantity_for_items(ParentEstimateItemID, ParentEstimateType, estimate);
        }

        public static StringBuilder GetSheetperhour(int sheettofind, StringBuilder sheets, StringBuilder sheetsperhour)
        {
            string[] strArrays = new string[] { "," };
            string[] strArrays1 = sheets.ToString().Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
            string[] strArrays2 = sheetsperhour.ToString().Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            for (int i = 0; i < (int)strArrays1.Length; i++)
            {
                if (strArrays1[i].ToString() == sheettofind.ToString())
                {
                    stringBuilder.Append(string.Concat(i, ","));
                }
            }
            string[] strArrays3 = stringBuilder.ToString().Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < (int)strArrays3.Length; j++)
            {
                string str = strArrays3[j].ToString();
                stringBuilder1.Append(string.Concat(strArrays2[Convert.ToInt32(str)].ToString(), ','));
            }
            return stringBuilder1;
        }

        public static DataTable GetTaxDetails_ByEstimateItemId(int EstimateItemId)
        {
            return EstimateNew.GetTaxDetails_ByEstimateItemId(EstimateItemId);
        }

        public static int GetTaxID(int CompanyID, long EstimateID)
        {
            int num = 0;
            try
            {
                foreach (DataRow row in EstimateNew.Profit_Margin_By_Client_System(CompanyID, EstimateID).Rows)
                {
                    num = (string.Compare(row["CustomerTaxID"].ToString(), "0", true) != 0 ? Convert.ToInt32(row["CustomerTaxid"].ToString()) : Convert.ToInt32(row["SystemTaxId"].ToString()));
                }
            }
            catch
            {
            }
            return num;
        }

        public static int GetTaxID__Customer(int CompanyID, long EstimateID)
        {
            int num = 0;
            try
            {
                foreach (DataRow row in EstimateNew.Profit_Margin_By_Client_System(CompanyID, EstimateID).Rows)
                {
                    num = Convert.ToInt32(row["SystemTaxId"].ToString());
                }
            }
            catch
            {
            }
            return num;
        }

        public static int GetTaxID_InvoiceID(int CompanyID, long InvoiceID)
        {
            int num = 0;
            try
            {
                foreach (DataRow row in EstimateNew.Profit_Margin_By_Client_System_InvoiceID(CompanyID, InvoiceID).Rows)
                {
                    num = (string.Compare(row["CustomerTaxID"].ToString(), "0", true) != 0 ? Convert.ToInt32(row["CustomerTaxid"].ToString()) : Convert.ToInt32(row["SystemTaxId"].ToString()));
                }
            }
            catch
            {
            }
            return num;
        }

        public static int GetTaxIDByProductID(int CompanyID, long productid)
        {
            int num = 0;
            try
            {
                foreach (DataRow row in EstimateNew.Profit_Margin_By_ProductCatalogue(CompanyID, productid).Rows)
                {
                    num = (string.Compare(row["TaxId"].ToString(), "0", true) == 0 ? 0 : Convert.ToInt32(row["TaxId"].ToString().Replace("%", "")));
                }
            }
            catch
            {
            }
            return num;
        }

        public static decimal GetTaxRate(int CompanyID, long EstimateID)
        {
            decimal num = new decimal(0);
            try
            {
                foreach (DataRow row in EstimateNew.Profit_Margin_By_Client_System(CompanyID, EstimateID).Rows)
                {
                    num = (string.Compare(row["CustomerTaxID"].ToString(), "0", true) != 0 ? Convert.ToDecimal(row["CustomerTaxValue"].ToString().Replace("%", "")) : Convert.ToDecimal(row["SystemTaxValue"].ToString().Replace("%", "")));
                }
            }
            catch
            {
            }
            return num;
        }

        public static decimal GetTaxRate_InvoiceID(int CompanyID, long InvoiceID)
        {
            decimal num = new decimal(0);
            try
            {
                foreach (DataRow row in EstimateNew.Profit_Margin_By_Client_System_InvoiceID(CompanyID, InvoiceID).Rows)
                {
                    num = (string.Compare(row["CustomerTaxID"].ToString(), "0", true) != 0 ? Convert.ToDecimal(row["CustomerTaxValue"].ToString().Replace("%", "")) : Convert.ToDecimal(row["SystemTaxValue"].ToString().Replace("%", "")));
                }
            }
            catch
            {
            }
            return num;
        }

        public static decimal GetTaxRateByProductID(int CompanyID, long productid)
        {
            decimal num = new decimal(0);
            try
            {
                foreach (DataRow row in EstimateNew.Profit_Margin_By_ProductCatalogue(CompanyID, productid).Rows)
                {
                    num = (string.Compare(row["TaxRate"].ToString(), "0", true) == 0 ? new decimal(0) : Convert.ToDecimal(row["TaxRate"].ToString().Replace("%", "")));
                }
            }
            catch
            {
            }
            return num;
        }

        public static StringBuilder getvalues(int sheettofind, int CompanyID, long EstimateCalculationID)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            StringBuilder stringBuilder3 = new StringBuilder();
            foreach (DataRow row in EstimatesBasePage.estimates_litho_press_matrix_select_By_ID(CompanyID, EstimateCalculationID).Rows)
            {
                stringBuilder1.Append(string.Concat(row["GSM"].ToString(), ","));
                stringBuilder2.Append(string.Concat(row["sheets"].ToString(), ","));
                stringBuilder3.Append(string.Concat(row["sheetsperhour"].ToString(), ","));
            }
            string str = EstimatesBasePage.sheetExactMatchFind(sheettofind, stringBuilder2);
            stringBuilder.Append(EstimatesBasePage.GetGsm(stringBuilder1));
            if (!str.ToString().Contains(","))
            {
                stringBuilder.Append(EstimatesBasePage.GetSheetperhour(Convert.ToInt32(str), stringBuilder2, stringBuilder3));
            }
            else
            {
                string[] strArrays = new string[] { "," };
                string[] strArrays1 = str.ToString().Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sheetperhour = EstimatesBasePage.GetSheetperhour(Convert.ToInt32(strArrays1[0]), stringBuilder2, stringBuilder3);
                StringBuilder sheetperhour1 = EstimatesBasePage.GetSheetperhour(Convert.ToInt32(strArrays1[1]), stringBuilder2, stringBuilder3);
                stringBuilder.Append(EstimatesBasePage.getExactValues(sheetperhour, sheetperhour1));
            }
            return stringBuilder;
        }

        public static decimal Guillotine_Calculation(int CompanyID, decimal TotalSheets, decimal ThroatValue, decimal PrintlayoutValue, decimal GuillotineSetCharge, decimal GuillotineMinimumCharge, decimal GuillotineMarkUp, decimal CostPerCut, bool IsGutterSelected, int Quantity)
        {
            if (PrintlayoutValue == new decimal(0))
            {
                return new decimal(0);
            }
            decimal num = new decimal(0);
            if (ThroatValue != new decimal(0))
            {
                num = Convert.ToDecimal(Math.Ceiling(TotalSheets / Convert.ToDecimal(ThroatValue)));
            }
            if (num == new decimal(0))
            {
                num = new decimal(1);
            }
            decimal num1 = new decimal(0);
            string str = (IsGutterSelected ? "yes" : "no");
            decimal num2 = EstimatesBasePage.Estimate_Summary_Guillotine_Standard_Table(CompanyID, Math.Ceiling(PrintlayoutValue), str);
            num1 = num2 * num;
            CostPerCut = CostPerCut * num1;
            if (CostPerCut.ToString().ToLower() == "nan" || CostPerCut.ToString().ToLower() == "infinity")
            {
                CostPerCut = new decimal(0);
            }
            return CostPerCut;
        }

        public static decimal Guillotine_Calculation(int CompanyID, decimal TotalSheets, decimal ThroatValue, decimal PrintlayoutValue, decimal GuillotineSetCharge, decimal GuillotineMinimumCharge, decimal GuillotineMarkUp, decimal CostPerCut, bool IsGutterSelected, int Quantity, ref decimal SecondTrimCuts, ref decimal SecondTrimNoOfBundles,string GuillotineType)
        {
            if (PrintlayoutValue == new decimal(0))
            {
                return new decimal(0);
            }
            decimal num = new decimal(0);
            if (ThroatValue != new decimal(0))
            {
                num = Convert.ToDecimal(Math.Ceiling(TotalSheets / Convert.ToDecimal(ThroatValue)));
            }
            if (num == new decimal(0))
            {
                num = new decimal(1);
            }
            decimal num1 = new decimal(0);
            string str = (IsGutterSelected ? "yes" : "no");
            if (Math.Ceiling(PrintlayoutValue) == new decimal(1))
            {
                str = "no";
            }
            decimal num2 = EstimatesBasePage.Estimate_Summary_Guillotine_Standard_Table(CompanyID, Math.Ceiling(PrintlayoutValue), str);
            if(GuillotineType == "Advanced")
            {
                num2 = SecondTrimNoOfBundles;
            }
            num1 = num2 * num;
            CostPerCut = CostPerCut * num1;
            if (CostPerCut.ToString().ToLower() == "nan" || CostPerCut.ToString().ToLower() == "infinity")
            {
                CostPerCut = new decimal(0);
            }
            SecondTrimCuts = num1;
            SecondTrimNoOfBundles = num;
            return CostPerCut;
        }

        public static decimal Guillotine_Calculation_Roll(int CompanyID, decimal PrintSheetsRequired, decimal ThroatValue, decimal PrintlayoutValue, decimal GuillotineSetCharge, decimal GuillotineMinimumCharge, decimal GuillotineMarkUp, decimal CostPerCut, bool IsGutterSelected, int Quantity, ref decimal NoOfCuts, ref decimal NoOfBundles)
        {
            if (PrintlayoutValue == new decimal(0))
            {
                return new decimal(0);
            }
            decimal num = new decimal(0);
            if (ThroatValue != new decimal(0))
            {
                num = Convert.ToDecimal(Math.Ceiling(PrintSheetsRequired / Convert.ToDecimal(ThroatValue)));
            }
            if (num == new decimal(0))
            {
                num = new decimal(1);
            }
            decimal num1 = new decimal(0);
            decimal num2 = EstimatesBasePage.Estimate_Summary_Guillotine_Standard_Table(CompanyID, PrintlayoutValue, (IsGutterSelected ? "yes" : "no"));
            num1 = num2 * num;
            NoOfCuts = num1;
            NoOfBundles = num;
            CostPerCut = CostPerCut * num1;
            return CostPerCut;
        }

        public static decimal Guillotine_First_Trim_Cut_Roll(decimal InvPaperHeight, decimal InvPaperWidth, decimal SheetHeight, decimal SheetWidth, decimal BasisWeight, string PrintLayout, decimal TotalpaperLength, decimal GuillotinePaperWeight1, decimal GuillotineMaximumThroat1, decimal GuillotinePaperWeight2, decimal GuillotineMaximumThroat2, decimal GuillotinePaperWeight3, decimal GuillotineMaximumThroat3, ref decimal BundlesOfFirstTrim)
        {
            int num = 0;
            decimal guillotineMaximumThroat1 = new decimal(0);
            decimal num1 = new decimal(0);
            int num2 = 0;
            int num3 = 0;
            bool flag = false;
            if (string.Compare(PrintLayout, "P", true) == 0 || PrintLayout.Trim().ToLower() == "portrait")
            {
                if (SheetWidth > new decimal(0))
                {
                    num2 = Convert.ToInt32(Math.Truncate(InvPaperHeight / SheetWidth));
                }
                if (SheetHeight > new decimal(0))
                {
                    num3 = Convert.ToInt32(Math.Truncate(InvPaperWidth / SheetHeight));
                }
                num = num2 * num3;
                if (SheetHeight == InvPaperHeight && InvPaperWidth == SheetWidth)
                {
                    flag = true;
                }
            }
            else if (string.Compare(PrintLayout, "L", true) == 0 || PrintLayout.Trim().ToLower() == "landscape")
            {
                if (SheetHeight > new decimal(0))
                {
                    num2 = Convert.ToInt32(Math.Truncate(InvPaperHeight / SheetHeight));
                }
                if (SheetWidth > new decimal(0))
                {
                    num3 = Convert.ToInt32(Math.Truncate(InvPaperWidth / SheetWidth));
                }
                if (SheetHeight == InvPaperHeight && InvPaperWidth == SheetWidth)
                {
                    flag = true;
                }
                num = num2 * num3;
            }
            num1 = EstimatesBasePage.Guillotine_Inventory_Cut(num, flag);
            if (num <= 0)
            {
                BundlesOfFirstTrim = new decimal(0);
                return new decimal(0);
            }
            if (BasisWeight <= GuillotinePaperWeight1)
            {
                guillotineMaximumThroat1 = GuillotineMaximumThroat1;
            }
            else if (BasisWeight <= GuillotinePaperWeight2)
            {
                guillotineMaximumThroat1 = GuillotineMaximumThroat2;
            }
            else if (BasisWeight <= GuillotinePaperWeight3 || BasisWeight > GuillotinePaperWeight3)
            {
                guillotineMaximumThroat1 = GuillotineMaximumThroat3;
            }
            decimal num4 = Math.Ceiling(TotalpaperLength / num);
            if (guillotineMaximumThroat1 > new decimal(0))
            {
                BundlesOfFirstTrim = Math.Ceiling(num4 / guillotineMaximumThroat1);
            }
            return num1 * BundlesOfFirstTrim;
        }

        public static int Guillotine_Inventory_Cut(int NoOfSheets, bool isSheetsEqual)
        {
            int num = 0;
            string[] strArrays = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50" };
            string[] strArrays1 = strArrays;
            string[] strArrays2 = new string[] { "0", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53" };
            string[] strArrays3 = strArrays2;
            for (int i = 0; i < (int)strArrays1.Length; i++)
            {
                if (NoOfSheets == Convert.ToInt32(strArrays1[i]))
                {
                    num = Convert.ToInt32(strArrays3[i]);
                }
            }
            if (NoOfSheets == 1 && !isSheetsEqual)
            {
                num = 4;
            }
            return num;
        }

        public static void Ink_Delete_BasedOn_estimateitemID(long EstimateItemID)
        {
            EstimateNew.Ink_Delete_BasedOn_estimateitemID(EstimateItemID);
        }

        public static DataTable Ink_Select_BasedOn_estimateitemID(long EstimateItemID)
        {
            return EstimateNew.Ink_Select_BasedOn_estimateitemID(EstimateItemID);
        }

        public static string inkMatrixGetValues(int Quantity, int CompanyID, long InventoryID)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string empty = string.Empty;
            StringBuilder stringBuilder1 = new StringBuilder();
            StringBuilder stringBuilder2 = new StringBuilder();
            foreach (DataRow row in EstimatesBasePage.warehouse_inventoryinkMatrix_select(CompanyID, InventoryID).Rows)
            {
                stringBuilder1.Append(string.Concat(row["InventorysheetsFrom"].ToString(), ",", row["Inventorysheetsto"].ToString(), ","));
            }
            return EstimatesBasePage.InkMatrixQtytoFind(Quantity, stringBuilder1);
        }

        public static string InkMatrixQtytoFind(int Qtytofind, StringBuilder Qtyfrom)
        {
            string empty = string.Empty;
            string[] strArrays = new string[] { "," };
            string[] strArrays1 = Qtyfrom.ToString().Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < (int)strArrays1.Length; i++)
            {
                if (Qtytofind == Convert.ToInt32(strArrays1[i]))
                {
                    empty = Qtytofind.ToString();
                }
            }
            if (empty == "")
            {
                if (Qtytofind < Convert.ToInt32(strArrays1[0].ToString()))
                {
                    empty = strArrays1[0].ToString();
                }
                else if (Qtytofind <= Convert.ToInt32(strArrays1[(int)strArrays1.Length - 2].ToString()))
                {
                    for (int j = 0; j < (int)strArrays1.Length - 3; j++)
                    {
                        if (Qtytofind > Convert.ToInt32(strArrays1[j].ToString()) && Qtytofind < Convert.ToInt32(strArrays1[j + 1].ToString()))
                        {
                            empty = strArrays1[j].ToString();
                        }
                    }
                }
                else
                {
                    empty = strArrays1[(int)strArrays1.Length - 2].ToString();
                }
            }
            return empty;
        }

        public static DataTable inkselectfromdatabase(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.inkselectfromdatabase(CompanyID, EstimateItemID);
        }

        public static void Insert_EstPriceCatAddOptionDetails(long EstimateAdditionalItemID, long EstimateID, string CalculationType, long EstimateItemID, string SelectedValue, decimal MarkupPercentage1, decimal MarkupPercentage2, decimal MarkupPercentage3, decimal MarkupPercentage4, decimal CostPriceInMarkup1, decimal CostPriceInMarkup2, decimal CostPriceInMarkup3, decimal CostPriceInMarkup4, long SelectedID, decimal MarkupValue1, decimal MarkupValue2, decimal MarkupValue3, decimal MarkupValue4, int SortOrderNo, decimal SelectedPrice1, decimal SelectedPrice2, decimal SelectedPrice3, decimal SelectedPrice4, string EstimateOtherCostName, decimal TotalPriceExMarkup1, decimal TotalPriceExMarkup2, decimal TotalPriceExMarkup3, decimal TotalPriceExMarkup4, decimal TotalPriceIncMarkup1, decimal TotalPriceIncMarkup2, decimal TotalPriceIncMarkup3, decimal TotalPriceIncMarkup4, int IsFirst, long WebOtherCostID, long ParentWebOtherCostID, string WebOtherCostType, string FreeTextQuestionLong = "")
        {
            EstimateNew.Insert_EstPriceCatAddOptionDetails(EstimateAdditionalItemID, EstimateID, CalculationType, EstimateItemID, SelectedValue, MarkupPercentage1, MarkupPercentage2, MarkupPercentage3, MarkupPercentage4, CostPriceInMarkup1, CostPriceInMarkup2, CostPriceInMarkup3, CostPriceInMarkup4, SelectedID, MarkupValue1, MarkupValue2, MarkupValue3, MarkupValue4, SortOrderNo, SelectedPrice1, SelectedPrice2, SelectedPrice3, SelectedPrice4, EstimateOtherCostName, TotalPriceExMarkup1, TotalPriceExMarkup2, TotalPriceExMarkup3, TotalPriceExMarkup4, TotalPriceIncMarkup1, TotalPriceIncMarkup2, TotalPriceIncMarkup3, TotalPriceIncMarkup4, IsFirst, WebOtherCostID, ParentWebOtherCostID, WebOtherCostType, FreeTextQuestionLong);
        }

        public static void insert_largeitem_quantity(long EstimateItemID, long QuantityID, long MaterialID, decimal InvSheets1, decimal InvSheets2, decimal InvSheets3, decimal InvSheets4, decimal PrintSheets1, decimal PrintSheets2, decimal PrintSheets3, decimal PrintSheets4, decimal MaterialLength1, decimal MaterialLength2, decimal MaterialLength3, decimal MaterialLength4, decimal MaterialMarkupPrice1, decimal MaterialCostExMarkup1, decimal MaterialMarkupPrice2, decimal MaterialCostExMarkup2, decimal MaterialMarkupPrice3, decimal MaterialCostExMarkup3, decimal MaterialMarkupPrice4, decimal MaterialCostExMarkup4, int MaterialNo, string savetype)
        {
            EstimateNew.insert_largeitem_quantity(EstimateItemID, QuantityID, MaterialID, InvSheets1, InvSheets2, InvSheets3, InvSheets4, PrintSheets1, PrintSheets2, PrintSheets3, PrintSheets4, MaterialLength1, MaterialLength2, MaterialLength3, MaterialLength4, MaterialMarkupPrice1, MaterialCostExMarkup1, MaterialMarkupPrice2, MaterialCostExMarkup2, MaterialMarkupPrice3, MaterialCostExMarkup3, MaterialMarkupPrice4, MaterialCostExMarkup4, MaterialNo, savetype);
        }

        public static DataTable Invoice_DeliveryNote_QuickLinks_Select(int CompanyID, long InvoiceID, long EstimateItemID)
        {
            return EstimateNew.Invoice_DeliveryNote_QuickLinks_Select(CompanyID, InvoiceID, EstimateItemID);
        }

        public static long Item_Copy_AllMainItem_withallAdditionItems(long EstimateItemID, string EstimateType)
        {
            return EstimateNew.Item_Copy_AllMainItem_withallAdditionItems(EstimateItemID, EstimateType);
        }

        public static long Item_Copy_AllMainItem_withallAdditionItems_reeng(long EstimateItemID, string EstimateType, string Module)
        {
            return EstimateNew.Item_Copy_AllMainItem_withallAdditionItems_reeng(EstimateItemID, EstimateType, Module);
        }

        public static DataTable item_cost_view_sub_item_outwork(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.item_cost_view_sub_item_outwork(CompanyID, EstimateItemID);
        }

        public static void item_description_update(int CompanyID, long EstimateItemID, string EstimateType, string ItemDescription)
        {
            EstimateNew.item_description_update(CompanyID, EstimateItemID, EstimateType, ItemDescription);
        }

        public static void item_description_update_new(int CompanyID, long EstimateItemID, string EstimateType, string ItemDescription, long EstimateID, string Itemtitle)
        {
            EstimateNew.item_description_update_new(CompanyID, EstimateItemID, EstimateType, ItemDescription, EstimateID, Itemtitle);
        }

        public static DataTable item_select_itemDescription_foralltypes(int CompanyID, long EstimateItemID, string EstimateType)
        {
            return EstimateNew.item_select_itemDescription_foralltypes(CompanyID, EstimateItemID, EstimateType);
        }

        public static DataSet itemdescription_selectall_fromSettings_foralltypes(int CompanyID, string EstimateType)
        {
            return EstimateNew.itemdescription_selectall_fromSettings_foralltypes(CompanyID, EstimateType);
        }

        public static void itemTitleUpdate_for_eStoreOtherCost(int CompanyID, long EstimateID, long EstimateItemID, string ItemTitle)
        {
            EstimateNew.itemTitleUpdate_for_eStoreOtherCost(CompanyID, EstimateID, EstimateItemID, ItemTitle);
        }

        public static DataTable Job_item_select(int CompanyID, long JobID)
        {
            return EstimateNew.Job_item_select(CompanyID, JobID);
        }

        public static int Job_Items_Count_Select(int CompanyID, long JobID)
        {
            return EstimateNew.Job_Items_Count_Select(CompanyID, JobID);
        }

        public static DataTable job_othercost_subitem_select(int CompanyID, string EstimateType, long TypeID, long EstOtherCostID, int Quantity)
        {
            return EstimateNew.job_othercost_subitem_select(CompanyID, EstimateType, TypeID, EstOtherCostID, Quantity);
        }

        public static DataTable jobcard_select_directjob(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.jobcard_select_directjob(CompanyID, EstimateItemID);
        }

        public static long large_item_insert(EstimatesItem item)
        {
            return EstimateNew.large_item_insert(item);
        }

        public static DataTable large_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.large_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable large_item_select_forMaterials(long CompanyID, long EstimateItemID, long MaterialID, int MaterialNo)
        {
            return EstimateNew.large_item_select_forMaterials(CompanyID, EstimateItemID, MaterialID, MaterialNo);
        }

        public static decimal Large_Press_Cost_Ex_SetupCharge(string PrintQuality, decimal Low, decimal Medium, decimal High, decimal HourlyCharge, decimal PaperLength_Required, decimal Totalpaper, string PressPaperType, string LargeFormatCalculation, out decimal Time_Required)
        {
            decimal num = new decimal(0);
            Time_Required = new decimal(0);
            decimal timeRequired = new decimal(0);
            if (string.Compare(PrintQuality, "low", true) == 0)
            {
                num = Low;
            }
            else if (string.Compare(PrintQuality, "medium", true) == 0)
            {
                num = Medium;
            }
            else if (string.Compare(PrintQuality, "high", true) == 0)
            {
                num = High;
            }
            if (string.Compare(PressPaperType, "roll", true) == 0 || string.Compare(PressPaperType, "web printing", true) == 0)
            {
                try
                {
                    Time_Required = (PaperLength_Required * new decimal(60)) / num;
                }
                catch
                {
                }
            }
            //else if (LargeFormatCalculation.ToString().ToLower() != "square" || LargeFormatCalculation.ToString().ToLower() != "tilling")
            else if (LargeFormatCalculation.ToString().ToLower() == "linear" )
            {
                try
                {
                    Time_Required = (Totalpaper * new decimal(60)) / num;
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    Time_Required = (PaperLength_Required * new decimal(60)) / num;
                }
                catch
                {
                }
            }
            Time_Required = EstimatesBasePage.ReturnExact2Decimal(Time_Required);
            timeRequired = (Time_Required * HourlyCharge) / new decimal(60);
            return timeRequired;
        }

        public static DataTable LargeItem_Ink_Details_Select(int CompanyID, long EstimateItemID, string color, string sidecolor, bool IsDoubleSided)
        {
            return EstimateNew.LargeItem_Ink_Details_Select(CompanyID, EstimateItemID, color, sidecolor, IsDoubleSided);
        }

        public static DataTable LargeItem_ink_UnitPrice_MinimumCost_Select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.LargeItem_ink_UnitPrice_MinimumCost_Select(CompanyID, EstimateItemID);
        }

        public static void LargeItemCalculation_insert(long EstimateCalculationID, long EstimateItemID, long MaterialID, decimal MaterialUnitPrice, decimal MaterialWeight, decimal MaterialPackedInQty, decimal MaterialMarkup1, decimal MaterialMarkup2, decimal MaterialMarkup3, decimal MaterialMarkup4, int MaterialNo, string savetype)
        {
            EstimateNew.LargeItemCalculation_insert(EstimateCalculationID, EstimateItemID, MaterialID, MaterialUnitPrice, MaterialWeight, MaterialPackedInQty, MaterialMarkup1, MaterialMarkup2, MaterialMarkup3, MaterialMarkup4, MaterialNo, savetype);
        }

        public static DataTable litho_estimate_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.litho_estimate_select(CompanyID, EstimateItemID);
        }

        public static DataTable litho_pad_estimate_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.litho_pad_estimate_select(CompanyID, EstimateItemID);
        }

        public static long litho_press_insert(int CompanyID, long EstLithoItemID, long EstimateItemID, long PressID, long PaperID, bool IsPricePerPack, bool IsPaperSupplied, decimal SetupSpoilage, decimal RunningSpoilage, string sidesprinted, string side1Color, string side2Color, long PlateID, string Noofplates, string NoofMakeReady, string NoofWashup, int PrintSheetSizeID, bool IsSheetCustom, decimal SheetHeight, decimal SheetWidth, int JobFlatSizeID, bool IsJobCustom, decimal JobHeight, decimal JobWidth, bool IsIncludeGutters, decimal GutterHorizontal, decimal GutterVertical, bool IsPressRestrictions, string PrintLayout, decimal PortraitValue, decimal LandscapeValue, long GuillotineID, string ItemTitle, int CreatedBy, int ModifiedBy, DateTime ModifiedDate, bool IsFirstTrim, bool IsSecondTrim, bool WorknTurn, bool WorknTumble, int ParentItemID, string ParentItemType, bool Perfecting, decimal ManualValue, bool sheetwork)
        {
            return EstimateNew.litho_press_insert(CompanyID, EstLithoItemID, EstimateItemID, PressID, PaperID, IsPricePerPack, IsPaperSupplied, SetupSpoilage, RunningSpoilage, sidesprinted, side1Color, side2Color, PlateID, Noofplates, NoofMakeReady, NoofWashup, PrintSheetSizeID, IsSheetCustom, SheetHeight, SheetWidth, JobFlatSizeID, IsJobCustom, JobHeight, JobWidth, IsIncludeGutters, GutterHorizontal, GutterVertical, IsPressRestrictions, PrintLayout, PortraitValue, LandscapeValue, GuillotineID, ItemTitle, CreatedBy, ModifiedBy, ModifiedDate, IsFirstTrim, IsSecondTrim, WorknTurn, WorknTumble, ParentItemID, ParentItemType, Perfecting, ManualValue, sheetwork);
        }

        public static void litho_speed_weight_insert(int CompanyID, long EstimateCalculationID, long PressID)
        {
            EstimateNew.litho_speed_weight_insert(CompanyID, EstimateCalculationID, PressID);
        }

        public static long Lithobooklet_item_insert(EstimatesItem item)
        {
            return EstimateNew.Lithobooklet_item_insert(item);
        }

        public static DataTable lithobooklet_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.lithobooklet_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable lithobooklet_item_select_othercostasadditional(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.lithobooklet_item_select_othercostasadditional(CompanyID, EstimateItemID);
        }

        public static DataTable lithobooklet_item_select_popup_paperpressinkguillotine(int CompanyID, long EstimateItemID, long EstimateLithoNcrItemID)
        {
            return EstimateNew.lithobooklet_item_select_popup_paperpressinkguillotine(CompanyID, EstimateItemID, EstimateLithoNcrItemID);
        }

        public static decimal LithoBooklet_Print_Sheet_Calculation(int Quantity, decimal NoOfSignature, decimal SetupSpoilage, decimal RunningSpoilage, out decimal SpoilageSheets)
        {
            decimal quantity = Quantity;
            decimal num = (Quantity * RunningSpoilage) / new decimal(100);
            decimal setupSpoilage = (quantity + num) + SetupSpoilage;
            setupSpoilage = Math.Ceiling(setupSpoilage * NoOfSignature);
            SpoilageSheets = Math.Ceiling(num + SetupSpoilage);
            return setupSpoilage;
        }

        public static void LithoBookletquantity_insert(int CompanyID, long EstimateItemID, int Qty1, int Qty2, int Qty3, int Qty4, double SubTotal1, double SubTotal2, double SubTotal3, double SubTotal4, int TaxID, double Tax, string QueryType, long EstimateLithobookletItemID)
        {
            EstimateNew.LithoBookletquantity_insert(CompanyID, EstimateItemID, Qty1, Qty2, Qty3, Qty4, SubTotal1, SubTotal2, SubTotal3, SubTotal4, TaxID, Tax, QueryType, EstimateLithobookletItemID);
        }

        public static DataTable lithoncr_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.lithoncr_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable digitalncr_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.digitalncr_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable lithoncr_item_select_othercostasadditional(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.lithoncr_item_select_othercostasadditional(CompanyID, EstimateItemID);
        }

        public static DataTable lithoncr_item_select_popup_paperpressinkguillotine(int CompanyID, long EstimateItemID, long EstimateLithoNcrItemID)
        {
            return EstimateNew.lithoncr_item_select_popup_paperpressinkguillotine(CompanyID, EstimateItemID, EstimateLithoNcrItemID);
        }

        public static decimal LithoSpeedWeightLookup_Cost(int CompanyID, int Totalpaper, decimal PaperWeight, decimal HourlyCharge, long EstimateCalculationID, decimal PressSetCharge, decimal PressMinimumCharge, decimal PressMarkUp, ref decimal JobTime)
        {
            JobTime = new decimal(0);
            int num = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            StringBuilder stringBuilder = EstimatesBasePage.getvalues(Totalpaper, CompanyID, EstimateCalculationID);
            string[] strArrays = new string[] { "," };
            string[] strArrays1 = stringBuilder.ToString().Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
            num = Convert.ToInt32(strArrays1[0]);
            num1 = Convert.ToInt32(strArrays1[1]);
            num2 = Convert.ToInt32(strArrays1[2]);
            num3 = Convert.ToInt32(strArrays1[3]);
            num4 = Convert.ToInt32(strArrays1[4]);
            num5 = Convert.ToInt32(strArrays1[5]);
            decimal num6 = new decimal(0);
            int num7 = 0;
            decimal num8 = new decimal(0);
            decimal paperWeight = new decimal(0);
            decimal paperWeight1 = new decimal(0);
            if (PaperWeight <= num)
            {
                if (PaperWeight != num)
                {
                    decimal num9 = new decimal(0);
                    try
                    {
                        num9 = num3 / num;
                        paperWeight1 = PaperWeight * num9;
                    }
                    catch
                    {
                        num9 = new decimal(0);
                    }
                }
                else
                {
                    paperWeight1 = num3;
                }
            }
            else if (PaperWeight > num && PaperWeight <= num1)
            {
                if (PaperWeight >= num1)
                {
                    paperWeight1 = num4;
                }
                else
                {
                    try
                    {
                        num6 = num1 - num;
                        num7 = num4 - num3;
                        paperWeight = PaperWeight - num;
                        num8 = (num7 / num6) * paperWeight;
                        paperWeight1 = num8 + num3;
                    }
                    catch
                    {
                    }
                }
            }
            else if (PaperWeight > num1 && PaperWeight <= num2)
            {
                if (PaperWeight >= num2)
                {
                    paperWeight1 = num5;
                }
                else
                {
                    try
                    {
                        num6 = num2 - num1;
                        num7 = num5 - num4;
                        paperWeight = PaperWeight - num1;
                        num8 = (num7 / num6) * paperWeight;
                        paperWeight1 = num8 + num4;
                    }
                    catch
                    {
                    }
                }
            }
            else if (PaperWeight > num2)
            {
                if (PaperWeight != num2)
                {
                    decimal num10 = new decimal(0);
                    try
                    {
                        num10 = num5 / num2;
                        paperWeight1 = PaperWeight * num10;
                    }
                    catch
                    {
                        num10 = new decimal(0);
                    }
                }
                else
                {
                    paperWeight1 = num5;
                }
            }
            decimal num11 = Convert.ToDecimal(Totalpaper);
            decimal num12 = paperWeight1 / new decimal(60);
            decimal num13 = new decimal(0);
            try
            {
                num13 = num11 / num12;
            }
            catch
            {
                num13 = new decimal(0);
            }
            JobTime = num13;
            decimal hourlyCharge = (HourlyCharge / new decimal(60)) * num13;
            decimal num14 = hourlyCharge;
            num14 = hourlyCharge;
            if (num14.ToString().ToLower() == "nan" || num14.ToString().ToLower() == "infinity")
            {
                num14 = new decimal(0);
            }
            return num14;
        }

        public static void LockItemStatus(long EstimateItemID, string Module)
        {
            EstimateNew.LockItemStatus(EstimateItemID, Module);
        }

        public static decimal MarkupfromSettings_forinventoryitems(int CompanyID, string inventorytype, long CalcID)
        {
            decimal num = new decimal(0);
            if (inventorytype.ToLower().Trim() == "paper")
            {
                DataTable dataTable = SettingsBasePage.settings_system_markup_select(CompanyID);
                if (dataTable.Rows.Count > 0)
                {
                    num = Convert.ToDecimal(dataTable.Rows[0]["Paper"].ToString());
                }
            }
            else if (inventorytype.ToLower().Trim() == "press")
            {
                DataTable dataTable1 = EstimateBasePage.Estimate_Digital_Press_Select(CompanyID, CalcID);
                if (dataTable1.Rows.Count > 0)
                {
                    num = Convert.ToDecimal(dataTable1.Rows[0]["markup"].ToString());
                }
            }
            else if (inventorytype.ToLower().Trim() == "guillotine")
            {
                DataTable dataTable2 = EstimateBasePage.Estimate_Guillotine_Select_By_ID(CompanyID, CalcID);
                if (dataTable2.Rows.Count > 0)
                {
                    num = Convert.ToDecimal(dataTable2.Rows[0]["markup"].ToString());
                }
            }
            else if (inventorytype.ToLower().Trim() == "largepress")
            {
                DataTable dataTable3 = EstimateBasePage.Estimate_Large_Format_Press_Charge_Select(CompanyID, CalcID);
                if (dataTable3.Rows.Count > 0)
                {
                    num = Convert.ToDecimal(dataTable3.Rows[0]["markup"].ToString());
                }
            }
            else if (inventorytype.ToLower().Trim() == "largeguillotine")
            {
                DataTable dataTable4 = EstimateBasePage.Estimate_Guillotine_Select_By_ID(CompanyID, CalcID);
                if (dataTable4.Rows.Count > 0)
                {
                    num = Convert.ToDecimal(dataTable4.Rows[0]["markup"].ToString());
                }
            }
            else if (inventorytype.ToLower().Trim() == "lithopress")
            {
                DataTable dataTable5 = EstimatesBasePage.Estimate_Litho_Press_Select(CompanyID, CalcID);
                if (dataTable5.Rows.Count > 0)
                {
                    num = Convert.ToDecimal(dataTable5.Rows[0]["markup"].ToString());
                }
            }
            else if (inventorytype.ToLower().Trim() == "inks")
            {
                DataTable dataTable6 = SettingsBasePage.settings_system_markup_select(CompanyID);
                if (dataTable6.Rows.Count > 0)
                {
                    num = Convert.ToDecimal(dataTable6.Rows[0]["inks"].ToString());
                }
            }
            if (inventorytype.ToLower().Trim() == "inventoryitems")
            {
                DataTable dataTable7 = SettingsBasePage.settings_system_markup_select(CompanyID);
                if (dataTable7.Rows.Count > 0)
                {
                    num = Convert.ToDecimal(dataTable7.Rows[0]["InventoryItems"].ToString());
                }
            }
            return num;
        }

        public static DataTable Materials_select_ForPOCreate(long EstimateItemID)
        {
            return EstimateNew.Materials_select_ForPOCreate(EstimateItemID);
        }

        public static long Module_IsConverted_To_NextModule(long ModuleId, string ModuleType)
        {
            return EstimateNew.Module_IsConverted_To_NextModule(ModuleId, ModuleType);
        }

        public static DataTable NCR_item_quantity_select(int CompanyID, int EstimateItemID, string EstType, int EstimateBookletItemID)
        {
            return EstimateNew.NCR_item_quantity_select(CompanyID, EstimateItemID, EstType, EstimateBookletItemID);
        }

        public static void NCRquantity_insert(int CompanyID, long EstimateItemID, int Qty1, int Qty2, int Qty3, int Qty4, double SubTotal1, double SubTotal2, double SubTotal3, double SubTotal4, int TaxID, double Tax, string QueryType, long EstimateLithoNCRItemID)
        {
            EstimateNew.NCRquantity_insert(CompanyID, EstimateItemID, Qty1, Qty2, Qty3, Qty4, SubTotal1, SubTotal2, SubTotal3, SubTotal4, TaxID, Tax, QueryType, EstimateLithoNCRItemID);
        }

        public static DataTable OrderItemID_Select(long OrderID, long EstimateItemID)
        {
            return EstimateNew.OrderItemID_Select(OrderID, EstimateItemID);
        }

        public static DataTable Orders_Othercostitem_select(int CompanyID, long EstimateID, string Pgtype)
        {
            return EstimateNew.Orders_Othercostitem_select(CompanyID, EstimateID, Pgtype);
        }

        public static void othercost_formula_tag_update(int CompanyID, long EstOthercostID, long EstimateItemID, string FormulaTag, int QtyNumber)
        {
            EstimateNew.othercost_formula_tag_update(CompanyID, EstOthercostID, EstimateItemID, FormulaTag, QtyNumber);
        }

        public static long OtherCostSequence_GetCountBy_EstimatType(int CompanyID, string Estimatetype)
        {
            return EstimateNew.OtherCostSequence_GetCountBy_EstimatType(CompanyID, Estimatetype);
        }

        public static DataSet OtherCostSequenceDetails(long CompanyID, string EstimateType)
        {
            return EstimateNew.OtherCostSequenceDetails(CompanyID, EstimateType);
        }

        public static long pad_item_insert(EstimatesItem item)
        {
            return EstimateNew.pad_item_insert(item);
        }

        public static DataTable pad_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.pad_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable pad_item_summary(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.pad_item_summary(CompanyID, EstimateItemID);
        }

        public static DataTable PaperSupplied_select_ForPOCreate(long EstimateItemID, string EstimateItemType)
        {
            return EstimateNew.PaperSupplied_select_ForPOCreate(EstimateItemID, EstimateItemType);
        }

        public static DataSet PC_EstimateLargeItem_InkCalID_Select(long EstimateItemID)
        {
            return EstimateNew.PC_EstimateLargeItem_InkCalID_Select(EstimateItemID);
        }

        public static void PC_EstimateLargeItem_InkMarkUp_Insert(long EstimateItemID, decimal InkMarkup)
        {
            EstimateNew.PC_EstimateLargeItem_InkMarkUp_Insert(EstimateItemID, InkMarkup);
        }

        public static void PC_update_Estimate_Iswarehouse_Subitem_By_Estimatesingleitemid(int CompanyID, long ParentItemID, string ParentItemType, string SubItemType)
        {
            EstimateNew.PC_update_Estimate_Iswarehouse_Subitem_By_Estimatesingleitemid(CompanyID, ParentItemID, ParentItemType, SubItemType);
        }

        public static DataTable PCR_Estimate_InkMarkup_Select(int CompanyID, long EstimateItemID, long InventoryID, long TypeID, string EstimateType, int QuantityNumber)
        {
            return EstimateNew.PCR_Estimate_InkMarkup_Select(CompanyID, EstimateItemID, InventoryID, TypeID, EstimateType, QuantityNumber);
        }

        public static void PCR_Estimate_InkMarkup_Update(decimal InkCostExMarkup, decimal InkMarkup, decimal InkMarkupPrice, decimal InkSetupCharge, decimal InkMinimumCharge, decimal InkCostExMarkup_Actual, int QuantityNumber, long EstimateInkCalcID)
        {
            EstimateNew.PCR_Estimate_InkMarkup_Update(InkCostExMarkup, InkMarkup, InkMarkupPrice, InkSetupCharge, InkMinimumCharge, InkCostExMarkup_Actual, QuantityNumber, EstimateInkCalcID);
        }

        public static void PCR_Estimate_Large_Ink_Insert(long EstimateItemID, string ActionType, int CompanyID, string Color, string sidecolor, bool IsDoubleSided,long PressID)
        {
            EstimateNew.PCR_Estimate_Large_Ink_Insert(EstimateItemID, ActionType, CompanyID, Color, sidecolor, IsDoubleSided,PressID);
        }

        public static void PCR_estimates_markup_calculation_update_forInk(decimal InkCostExMarkup, decimal InkMarkup, decimal InkMarkupPrice, decimal InkCostExMarkup_Actual, int QtyNo, long EstimateInkCalcID, string Module)
        {
            EstimateNew.PCR_estimates_markup_calculation_update_forInk(InkCostExMarkup, InkMarkup, InkMarkupPrice, InkCostExMarkup_Actual, QtyNo, EstimateInkCalcID, Module);
        }

        public static void PCR_estimates_Update_SetupCharge_Or_MakeReady(long EstimateInkCalcID, decimal SetUpCharge_OrMake_ReadyValue, string SetUpCharge_OrMake_Ready)
        {
            EstimateNew.PCR_estimates_Update_SetupCharge_Or_MakeReady(EstimateInkCalcID, SetUpCharge_OrMake_ReadyValue, SetUpCharge_OrMake_Ready);
        }

        public static DataTable PCR_Guillotine_Cost_ViewOnPopUp(long GuillotineID, long EstimateItemID, string EstimateType, long TypeID, string Module)
        {
            return EstimateNew.PCR_Guillotine_Cost_ViewOnPopUp(GuillotineID, EstimateItemID, EstimateType, TypeID, Module);
        }

        public static DataSet PCR_Ink_Cost_ViewOnPopUp(long PressID, long EstimateItemID, string EstimateType, long TypeID, string Module, string Section)
        {
            return EstimateNew.PCR_Ink_Cost_ViewOnPopUp(PressID, EstimateItemID, EstimateType, TypeID, Module, Section);
        }

        public static DataTable PCR_MakeReady_Cost_ViewOnPopUp(long EstimateItemID, string EstimateType, long TypeID, string Module)
        {
            return EstimateNew.PCR_MakeReady_Cost_ViewOnPopUp(EstimateItemID, EstimateType, TypeID, Module);
        }

        public static DataTable PCR_OtherCostSequence_GetIDSToValidate(int CompanyID, string ParentEstimateType)
        {
            return EstimateNew.PCR_OtherCostSequence_GetIDSToValidate(CompanyID, ParentEstimateType);
        }

        public static DataTable PCR_Paper_Cost_ViewOnPopUp(int PaperID, long EstimateItemID, string EstimateType, long TypeID, string Module, int MaterialNo)
        {
            return EstimateNew.PCR_Paper_Cost_ViewOnPopUp(PaperID, EstimateItemID, EstimateType, TypeID, Module, MaterialNo);
        }

        public static DataTable PCR_Plate_Cost_ViewOnPopUp(long PlateID, long EstimateItemID, string EstimateType, long TypeID, string Module)
        {
            return EstimateNew.PCR_Plate_Cost_ViewOnPopUp(PlateID, EstimateItemID, EstimateType, TypeID, Module);
        }

        public static DataSet PCR_Press_Cost_ViewOnPopUp(long PressID, long EstimateItemID, string EstimateType, long TypeID, string Module)
        {
            return EstimateNew.PCR_Press_Cost_ViewOnPopUp(PressID, EstimateItemID, EstimateType, TypeID, Module);
        }

        public static DataTable PCR_WashUp_Cost_ViewOnPopUp(long EstimateItemID, string EstimateType, long TypeID, string Module)
        {
            return EstimateNew.PCR_WashUp_Cost_ViewOnPopUp(EstimateItemID, EstimateType, TypeID, Module);
        }

        public static decimal PressCostPerClick(decimal PrintSheets, decimal ChargeableRate, int ChargeableSheets)
        {
            decimal num = new decimal(0);
            if (ChargeableSheets != 0)
            {
                num = ChargeableRate / Convert.ToDecimal(ChargeableSheets);
            }
            return num * PrintSheets;
        }

        public static void price_catalogue_insert(int CompanyID, string Data)
        {
            EstimateNew.price_catalogue_insert(CompanyID, Data);
        }

        public static DataTable price_catalogue_select_by_estimateitem_id_new(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.price_catalogue_select_by_estimateitem_id_new(CompanyID, EstimateItemID);
        }

        public static DataTable Pricecatalog_selecttiemdescription_byestimateitemid(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.Pricecatalog_selecttiemdescription_byestimateitemid(CompanyID, EstimateItemID);
        }

        public static void PrintReadyfile_Insert(long EstimateID, long EstimateItemID, long UserID, string ModuleType, string AttachmentType)
        {
            EstimateNew.PrintReadyfile_Insert(EstimateID, EstimateItemID, UserID, ModuleType, AttachmentType);
        }

        public static DataTable PrintReadyFile_Select(long PriceCatalogueID, int CompanyId)
        {
            return EstimateNew.PrintReadyFile_Select(PriceCatalogueID, CompanyId);
        }

        public static decimal PrintSheets_Calculation_For_PadItem(int Quantity, decimal LeavesPerpad, decimal Printlayout, decimal Setupspoilage, decimal RunningSpoilage, out decimal SpoilageSheets)
        {
            if (Printlayout <= new decimal(0))
            {
                SpoilageSheets = new decimal(0);
                return new decimal(0);
            }
            decimal quantity = (Quantity * LeavesPerpad) / Printlayout;
            decimal runningSpoilage = (quantity * RunningSpoilage) / new decimal(100);
            SpoilageSheets = Setupspoilage + runningSpoilage;
            return Math.Ceiling(quantity + SpoilageSheets);
        }

        public static decimal PrintSheets_Calculation_For_SingleItem(int Quantity, decimal Printlayout, decimal Setupspoilage, decimal RunningSpoilage, out decimal SpoilageSheets)
        {
            if (Printlayout <= new decimal(0))
            {
                SpoilageSheets = new decimal(0);
                return new decimal(0);
            }
            decimal quantity = Quantity / Printlayout;
            decimal runningSpoilage = (quantity * RunningSpoilage) / new decimal(100);
            SpoilageSheets = Setupspoilage + runningSpoilage;
            return Math.Ceiling(quantity + SpoilageSheets);
        }

        public static DataTable Product_CatalogueQty_Select(long PriceCatalogueID)
        {
            return EstimateNew.Product_CatalogueQty_Select(PriceCatalogueID);
        }

        public static DataTable ProductOROrder_Item_Qty_Select(long EstimateItemID)
        {
            return EstimateNew.ProductOROrder_Item_Qty_Select(EstimateItemID);
        }

        public static DataTable productsDetails_Select(long PriceCatalogueID)
        {
            return EstimateNew.productsDetails_Select(PriceCatalogueID);
        }

        public static void qty_delete(int CompanyID, long EstimateItemID, long EstimateBookletItemID, string EstimateType, int QtyNumber)
        {
            EstimateNew.qty_delete(CompanyID, EstimateItemID, EstimateBookletItemID, EstimateType, QtyNumber);
        }

        public static void quantity_insert(int CompanyID, long EstimateItemID, int Qty1, int Qty2, int Qty3, int Qty4, double SubTotal1, double SubTotal2, double SubTotal3, double SubTotal4, int TaxID, double Tax, string QueryType, long EstimateBookletItemID)
        {
            EstimateNew.quantity_insert(CompanyID, EstimateItemID, Qty1, Qty2, Qty3, Qty4, SubTotal1, SubTotal2, SubTotal3, SubTotal4, TaxID, Tax, QueryType, EstimateBookletItemID);
        }

        public static void quantity_insert_large_item(int CompanyID, long EstimateItemID, int Qty1, decimal InvSheets1, decimal PrintSheets1, decimal PaperCostExMarkup1, decimal PaperMarkupPrice1, decimal PressCostExMarkup1, decimal PressMarkupPrice1, decimal FirstTrimCuts1, decimal FirstTrimNoOfBundles1, decimal SecondTrimCuts1, decimal SecondTrimNoOfBundles1, decimal GuillotineCostExMarkup1, decimal GuillotineMarkupPrice1, decimal InkCostExMarkup1, decimal InkMarkupPrice1, int Qty2, decimal InvSheets2, decimal PrintSheets2, decimal PaperCostExMarkup2, decimal PaperMarkupPrice2, decimal PressCostExMarkup2, decimal PressMarkupPrice2, decimal FirstTrimCuts2, decimal FirstTrimNoOfBundles2, decimal SecondTrimCuts2, decimal SecondTrimNoOfBundles2, decimal GuillotineCostExMarkup2, decimal GuillotineMarkupPrice2, decimal InkCostExMarkup2, decimal InkMarkupPrice2, int Qty3, decimal InvSheets3, decimal PrintSheets3, decimal PaperCostExMarkup3, decimal PaperMarkupPrice3, decimal PressCostExMarkup3, decimal PressMarkupPrice3, decimal FirstTrimCuts3, decimal FirstTrimNoOfBundles3, decimal SecondTrimCuts3, decimal SecondTrimNoOfBundles3, decimal GuillotineCostExMarkup3, decimal GuillotineMarkupPrice3, decimal InkCostExMarkup3, decimal InkMarkupPrice3, int Qty4, decimal InvSheets4, decimal PrintSheets4, decimal PaperCostExMarkup4, decimal PaperMarkupPrice4, decimal PressCostExMarkup4, decimal PressMarkupPrice4, decimal FirstTrimCuts4, decimal FirstTrimNoOfBundles4, decimal SecondTrimCuts4, decimal SecondTrimNoOfBundles4, decimal GuillotineCostExMarkup4, decimal GuillotineMarkupPrice4, decimal InkCostExMarkup4, decimal InkMarkupPrice4, string QueryType, long EstimateBookletItemID, decimal PressJobTimeSide11, decimal PressJobTimeSide12, decimal PressJobTimeSide13, decimal PressJobTimeSide14, decimal PressJobTimeSide21, decimal PressJobTimeSide22, decimal PressJobTimeSide23, decimal PressJobTimeSide24, decimal Zone_Side1_PressMarkupPercentage1, decimal Zone_Side1_PressMarkupPercentage2, decimal Zone_Side1_PressMarkupPercentage3, decimal Zone_Side1_PressMarkupPercentage4, decimal Zone_Side2_PressMarkupPercentage1, decimal Zone_Side2_PressMarkupPercentage2, decimal Zone_Side2_PressMarkupPercentage3, decimal Zone_Side2_PressMarkupPercentage4, decimal Zone_Side1_PressMarkupPrice1, decimal Zone_Side1_PressMarkupPrice2, decimal Zone_Side1_PressMarkupPrice3, decimal Zone_Side1_PressMarkupPrice4, decimal Zone_Side2_PressMarkupPrice1, decimal Zone_Side2_PressMarkupPrice2, decimal Zone_Side2_PressMarkupPrice3, decimal Zone_Side2_PressMarkupPrice4, decimal Zone_Side1_PressCostExMarkup1, decimal Zone_Side1_PressCostExMarkup2, decimal Zone_Side1_PressCostExMarkup3, decimal Zone_Side1_PressCostExMarkup4, decimal Zone_Side2_PressCostExMarkup1, decimal Zone_Side2_PressCostExMarkup2, decimal Zone_Side2_PressCostExMarkup3, decimal Zone_Side2_PressCostExMarkup4, decimal PaperLength1, decimal PaperLength2, decimal PaperLength3, decimal PaperLength4, decimal PressCostExMarkup_Actual1, decimal PressCostExMarkup_Actual2, decimal PressCostExMarkup_Actual3, decimal PressCostExMarkup_Actual4, decimal GuillotineCostExMarkup_Actual1, decimal GuillotineCostExMarkup_Actual2, decimal GuillotineCostExMarkup_Actual3, decimal GuillotineCostExMarkup_Actual4)
        {
            EstimateNew.quantity_insert_large_item(CompanyID, EstimateItemID, Qty1, InvSheets1, PrintSheets1, PaperCostExMarkup1, PaperMarkupPrice1, PressCostExMarkup1, PressMarkupPrice1, FirstTrimCuts1, FirstTrimNoOfBundles1, SecondTrimCuts1, SecondTrimNoOfBundles1, GuillotineCostExMarkup1, GuillotineMarkupPrice1, InkCostExMarkup1, InkMarkupPrice1, Qty2, InvSheets2, PrintSheets2, PaperCostExMarkup2, PaperMarkupPrice2, PressCostExMarkup2, PressMarkupPrice2, FirstTrimCuts2, FirstTrimNoOfBundles2, SecondTrimCuts2, SecondTrimNoOfBundles2, GuillotineCostExMarkup2, GuillotineMarkupPrice2, InkCostExMarkup2, InkMarkupPrice2, Qty3, InvSheets3, PrintSheets3, PaperCostExMarkup3, PaperMarkupPrice3, PressCostExMarkup3, PressMarkupPrice3, FirstTrimCuts3, FirstTrimNoOfBundles3, SecondTrimCuts3, SecondTrimNoOfBundles3, GuillotineCostExMarkup3, GuillotineMarkupPrice3, InkCostExMarkup3, InkMarkupPrice3, Qty4, InvSheets4, PrintSheets4, PaperCostExMarkup4, PaperMarkupPrice4, PressCostExMarkup4, PressMarkupPrice4, FirstTrimCuts4, FirstTrimNoOfBundles4, SecondTrimCuts4, SecondTrimNoOfBundles4, GuillotineCostExMarkup4, GuillotineMarkupPrice4, InkCostExMarkup4, InkMarkupPrice4, QueryType, EstimateBookletItemID, PressJobTimeSide11, PressJobTimeSide12, PressJobTimeSide13, PressJobTimeSide14, PressJobTimeSide21, PressJobTimeSide22, PressJobTimeSide23, PressJobTimeSide24, Zone_Side1_PressMarkupPercentage1, Zone_Side1_PressMarkupPercentage2, Zone_Side1_PressMarkupPercentage3, Zone_Side1_PressMarkupPercentage4, Zone_Side2_PressMarkupPercentage1, Zone_Side2_PressMarkupPercentage2, Zone_Side2_PressMarkupPercentage3, Zone_Side2_PressMarkupPercentage4, Zone_Side1_PressMarkupPrice1, Zone_Side1_PressMarkupPrice2, Zone_Side1_PressMarkupPrice3, Zone_Side1_PressMarkupPrice4, Zone_Side2_PressMarkupPrice1, Zone_Side2_PressMarkupPrice2, Zone_Side2_PressMarkupPrice3, Zone_Side2_PressMarkupPrice4, Zone_Side1_PressCostExMarkup1, Zone_Side1_PressCostExMarkup2, Zone_Side1_PressCostExMarkup3, Zone_Side1_PressCostExMarkup4, Zone_Side2_PressCostExMarkup1, Zone_Side2_PressCostExMarkup2, Zone_Side2_PressCostExMarkup3, Zone_Side2_PressCostExMarkup4, PaperLength1, PaperLength2, PaperLength3, PaperLength4, PressCostExMarkup_Actual1, PressCostExMarkup_Actual2, PressCostExMarkup_Actual3, PressCostExMarkup_Actual4, GuillotineCostExMarkup_Actual1, GuillotineCostExMarkup_Actual2, GuillotineCostExMarkup_Actual3, GuillotineCostExMarkup_Actual4);
        }

        public static void quantity_insert_new(int CompanyID, long EstimateItemID, int Qty1, decimal InvSheets1, decimal PrintSheets1, decimal PaperCostExMarkup1, decimal PaperMarkupPrice1, decimal PressCostExMarkup1, decimal PressMarkupPrice1, decimal FirstTrimCuts1, decimal FirstTrimNoOfBundles1, decimal SecondTrimCuts1, decimal SecondTrimNoOfBundles1, decimal GuillotineCostExMarkup1, decimal GuillotineMarkupPrice1, int Qty2, decimal InvSheets2, decimal PrintSheets2, decimal PaperCostExMarkup2, decimal PaperMarkupPrice2, decimal PressCostExMarkup2, decimal PressMarkupPrice2, decimal FirstTrimCuts2, decimal FirstTrimNoOfBundles2, decimal SecondTrimCuts2, decimal SecondTrimNoOfBundles2, decimal GuillotineCostExMarkup2, decimal GuillotineMarkupPrice2, int Qty3, decimal InvSheets3, decimal PrintSheets3, decimal PaperCostExMarkup3, decimal PaperMarkupPrice3, decimal PressCostExMarkup3, decimal PressMarkupPrice3, decimal FirstTrimCuts3, decimal FirstTrimNoOfBundles3, decimal SecondTrimCuts3, decimal SecondTrimNoOfBundles3, decimal GuillotineCostExMarkup3, decimal GuillotineMarkupPrice3, int Qty4, decimal InvSheets4, decimal PrintSheets4, decimal PaperCostExMarkup4, decimal PaperMarkupPrice4, decimal PressCostExMarkup4, decimal PressMarkupPrice4, decimal FirstTrimCuts4, decimal FirstTrimNoOfBundles4, decimal SecondTrimCuts4, decimal SecondTrimNoOfBundles4, decimal GuillotineCostExMarkup4, decimal GuillotineMarkupPrice4, string QueryType, long EstimateBookletItemID, decimal PressJobTimeSide11, decimal PressJobTimeSide12, decimal PressJobTimeSide13, decimal PressJobTimeSide14, decimal PressJobTimeSide21, decimal PressJobTimeSide22, decimal PressJobTimeSide23, decimal PressJobTimeSide24, decimal Zone_Side1_PressMarkupPercentage1, decimal Zone_Side1_PressMarkupPercentage2, decimal Zone_Side1_PressMarkupPercentage3, decimal Zone_Side1_PressMarkupPercentage4, decimal Zone_Side2_PressMarkupPercentage1, decimal Zone_Side2_PressMarkupPercentage2, decimal Zone_Side2_PressMarkupPercentage3, decimal Zone_Side2_PressMarkupPercentage4, decimal Zone_Side1_PressMarkupPrice1, decimal Zone_Side1_PressMarkupPrice2, decimal Zone_Side1_PressMarkupPrice3, decimal Zone_Side1_PressMarkupPrice4, decimal Zone_Side2_PressMarkupPrice1, decimal Zone_Side2_PressMarkupPrice2, decimal Zone_Side2_PressMarkupPrice3, decimal Zone_Side2_PressMarkupPrice4, decimal Zone_Side1_PressCostExMarkup1, decimal Zone_Side1_PressCostExMarkup2, decimal Zone_Side1_PressCostExMarkup3, decimal Zone_Side1_PressCostExMarkup4, decimal Zone_Side2_PressCostExMarkup1, decimal Zone_Side2_PressCostExMarkup2, decimal Zone_Side2_PressCostExMarkup3, decimal Zone_Side2_PressCostExMarkup4, decimal Zone_Side1_ChargeableRate1, decimal Zone_Side1_ChargeableRate2, decimal Zone_Side1_ChargeableRate3, decimal Zone_Side1_ChargeableRate4, decimal Zone_Side2_ChargeableRate1, decimal Zone_Side2_ChargeableRate2, decimal Zone_Side2_ChargeableRate3, decimal Zone_Side2_ChargeableRate4, decimal PressCostExMarkup_Actual1, decimal PressCostExMarkup_Actual2, decimal PressCostExMarkup_Actual3, decimal PressCostExMarkup_Actual4, decimal GuillotineCostExMarkup_Actual1, decimal GuillotineCostExMarkup_Actual2, decimal GuillotineCostExMarkup_Actual3, decimal GuillotineCostExMarkup_Actual4, decimal Zone_Side1_Cost1, decimal Zone_Side1_Cost2, decimal Zone_Side1_Cost3, decimal Zone_Side1_Cost4, decimal Zone_Side2_Cost1, decimal Zone_Side2_Cost2, decimal Zone_Side2_Cost3, decimal Zone_Side2_Cost4)
        {
            EstimateNew.quantity_insert_new(CompanyID, EstimateItemID, Qty1, InvSheets1, PrintSheets1, PaperCostExMarkup1, PaperMarkupPrice1, PressCostExMarkup1, PressMarkupPrice1, FirstTrimCuts1, FirstTrimNoOfBundles1, SecondTrimCuts1, SecondTrimNoOfBundles1, GuillotineCostExMarkup1, GuillotineMarkupPrice1, Qty2, InvSheets2, PrintSheets2, PaperCostExMarkup2, PaperMarkupPrice2, PressCostExMarkup2, PressMarkupPrice2, FirstTrimCuts2, FirstTrimNoOfBundles2, SecondTrimCuts2, SecondTrimNoOfBundles2, GuillotineCostExMarkup2, GuillotineMarkupPrice2, Qty3, InvSheets3, PrintSheets3, PaperCostExMarkup3, PaperMarkupPrice3, PressCostExMarkup3, PressMarkupPrice3, FirstTrimCuts3, FirstTrimNoOfBundles3, SecondTrimCuts3, SecondTrimNoOfBundles3, GuillotineCostExMarkup3, GuillotineMarkupPrice3, Qty4, InvSheets4, PrintSheets4, PaperCostExMarkup4, PaperMarkupPrice4, PressCostExMarkup4, PressMarkupPrice4, FirstTrimCuts4, FirstTrimNoOfBundles4, SecondTrimCuts4, SecondTrimNoOfBundles4, GuillotineCostExMarkup4, GuillotineMarkupPrice4, QueryType, EstimateBookletItemID, PressJobTimeSide11, PressJobTimeSide12, PressJobTimeSide13, PressJobTimeSide14, PressJobTimeSide21, PressJobTimeSide22, PressJobTimeSide23, PressJobTimeSide24, Zone_Side1_PressMarkupPercentage1, Zone_Side1_PressMarkupPercentage2, Zone_Side1_PressMarkupPercentage3, Zone_Side1_PressMarkupPercentage4, Zone_Side2_PressMarkupPercentage1, Zone_Side2_PressMarkupPercentage2, Zone_Side2_PressMarkupPercentage3, Zone_Side2_PressMarkupPercentage4, Zone_Side1_PressMarkupPrice1, Zone_Side1_PressMarkupPrice2, Zone_Side1_PressMarkupPrice3, Zone_Side1_PressMarkupPrice4, Zone_Side2_PressMarkupPrice1, Zone_Side2_PressMarkupPrice2, Zone_Side2_PressMarkupPrice3, Zone_Side2_PressMarkupPrice4, Zone_Side1_PressCostExMarkup1, Zone_Side1_PressCostExMarkup2, Zone_Side1_PressCostExMarkup3, Zone_Side1_PressCostExMarkup4, Zone_Side2_PressCostExMarkup1, Zone_Side2_PressCostExMarkup2, Zone_Side2_PressCostExMarkup3, Zone_Side2_PressCostExMarkup4, Zone_Side1_ChargeableRate1, Zone_Side1_ChargeableRate2, Zone_Side1_ChargeableRate3, Zone_Side1_ChargeableRate4, Zone_Side2_ChargeableRate1, Zone_Side2_ChargeableRate2, Zone_Side2_ChargeableRate3, Zone_Side2_ChargeableRate4, PressCostExMarkup_Actual1, PressCostExMarkup_Actual2, PressCostExMarkup_Actual3, PressCostExMarkup_Actual4, GuillotineCostExMarkup_Actual1, GuillotineCostExMarkup_Actual2, GuillotineCostExMarkup_Actual3, GuillotineCostExMarkup_Actual4, Zone_Side1_Cost1, Zone_Side1_Cost2, Zone_Side1_Cost3, Zone_Side1_Cost4, Zone_Side2_Cost1, Zone_Side2_Cost2, Zone_Side2_Cost3, Zone_Side2_Cost4);
        }

        public static void quantity_insert_offset_item(int CompanyID, long EstimateItemID, string EstimateType, int Qty1, decimal InvSheets1, decimal PrintSheets1, decimal PaperCostExMarkup1, decimal PaperMarkupPrice1, decimal PressCostExMarkup1, decimal PressMarkupPrice1, decimal FirstTrimCuts1, decimal FirstTrimNoOfBundles1, decimal SecondTrimCuts1, decimal SecondTrimNoOfBundles1, decimal GuillotineCostExMarkup1, decimal GuillotineMarkupPrice1, decimal InkCostExMarkup1, decimal InkMarkupPrice1, decimal PlatesCostExMarkup1, decimal PlatesMarkupPrice1, decimal MakeReadyCostExMarkup1, decimal MakeReadyMarkupPrice1, decimal WashUpCostExMarkup1, decimal WashUpMarkupPrice1, int Qty2, decimal InvSheets2, decimal PrintSheets2, decimal PaperCostExMarkup2, decimal PaperMarkupPrice2, decimal PressCostExMarkup2, decimal PressMarkupPrice2, decimal FirstTrimCuts2, decimal FirstTrimNoOfBundles2, decimal SecondTrimCuts2, decimal SecondTrimNoOfBundles2, decimal GuillotineCostExMarkup2, decimal GuillotineMarkupPrice2, decimal InkCostExMarkup2, decimal InkMarkupPrice2, decimal PlatesCostExMarkup2, decimal PlatesMarkupPrice2, decimal MakeReadyCostExMarkup2, decimal MakeReadyMarkupPrice2, decimal WashUpCostExMarkup2, decimal WashUpMarkupPrice2, int Qty3, decimal InvSheets3, decimal PrintSheets3, decimal PaperCostExMarkup3, decimal PaperMarkupPrice3, decimal PressCostExMarkup3, decimal PressMarkupPrice3, decimal FirstTrimCuts3, decimal FirstTrimNoOfBundles3, decimal SecondTrimCuts3, decimal SecondTrimNoOfBundles3, decimal GuillotineCostExMarkup3, decimal GuillotineMarkupPrice3, decimal InkCostExMarkup3, decimal InkMarkupPrice3, decimal PlatesCostExMarkup3, decimal PlatesMarkupPrice3, decimal MakeReadyCostExMarkup3, decimal MakeReadyMarkupPrice3, decimal WashUpCostExMarkup3, decimal WashUpMarkupPrice3, int Qty4, decimal InvSheets4, decimal PrintSheets4, decimal PaperCostExMarkup4, decimal PaperMarkupPrice4, decimal PressCostExMarkup4, decimal PressMarkupPrice4, decimal FirstTrimCuts4, decimal FirstTrimNoOfBundles4, decimal SecondTrimCuts4, decimal SecondTrimNoOfBundles4, decimal GuillotineCostExMarkup4, decimal GuillotineMarkupPrice4, decimal InkCostExMarkup4, decimal InkMarkupPrice4, decimal PlatesCostExMarkup4, decimal PlatesMarkupPrice4, decimal MakeReadyCostExMarkup4, decimal MakeReadyMarkupPrice4, decimal WashUpCostExMarkup4, decimal WashUpMarkupPrice4, string QueryType, long EstimateBookletItemID, decimal PressJobTimeSide11, decimal PressJobTimeSide12, decimal PressJobTimeSide13, decimal PressJobTimeSide14, decimal PressJobTimeSide21, decimal PressJobTimeSide22, decimal PressJobTimeSide23, decimal PressJobTimeSide24, decimal Zone_Side1_PressMarkupPercentage1, decimal Zone_Side1_PressMarkupPercentage2, decimal Zone_Side1_PressMarkupPercentage3, decimal Zone_Side1_PressMarkupPercentage4, decimal Zone_Side2_PressMarkupPercentage1, decimal Zone_Side2_PressMarkupPercentage2, decimal Zone_Side2_PressMarkupPercentage3, decimal Zone_Side2_PressMarkupPercentage4, decimal Zone_Side1_PressMarkupPrice1, decimal Zone_Side1_PressMarkupPrice2, decimal Zone_Side1_PressMarkupPrice3, decimal Zone_Side1_PressMarkupPrice4, decimal Zone_Side2_PressMarkupPrice1, decimal Zone_Side2_PressMarkupPrice2, decimal Zone_Side2_PressMarkupPrice3, decimal Zone_Side2_PressMarkupPrice4, decimal Zone_Side1_PressCostExMarkup1, decimal Zone_Side1_PressCostExMarkup2, decimal Zone_Side1_PressCostExMarkup3, decimal Zone_Side1_PressCostExMarkup4, decimal Zone_Side2_PressCostExMarkup1, decimal Zone_Side2_PressCostExMarkup2, decimal Zone_Side2_PressCostExMarkup3, decimal Zone_Side2_PressCostExMarkup4, decimal PressCostExMarkup_Actual1, decimal PressCostExMarkup_Actual2, decimal PressCostExMarkup_Actual3, decimal PressCostExMarkup_Actual4, decimal GuillotineCostExMarkup_Actual1, decimal GuillotineCostExMarkup_Actual2, decimal GuillotineCostExMarkup_Actual3, decimal GuillotineCostExMarkup_Actual4)
        {
            EstimateNew.quantity_insert_offset_item(CompanyID, EstimateItemID, EstimateType, Qty1, InvSheets1, PrintSheets1, PaperCostExMarkup1, PaperMarkupPrice1, PressCostExMarkup1, PressMarkupPrice1, FirstTrimCuts1, FirstTrimNoOfBundles1, SecondTrimCuts1, SecondTrimNoOfBundles1, GuillotineCostExMarkup1, GuillotineMarkupPrice1, InkCostExMarkup1, InkMarkupPrice1, PlatesCostExMarkup1, PlatesMarkupPrice1, MakeReadyCostExMarkup1, MakeReadyMarkupPrice1, WashUpCostExMarkup1, WashUpMarkupPrice1, Qty2, InvSheets2, PrintSheets2, PaperCostExMarkup2, PaperMarkupPrice2, PressCostExMarkup2, PressMarkupPrice2, FirstTrimCuts2, FirstTrimNoOfBundles2, SecondTrimCuts2, SecondTrimNoOfBundles2, GuillotineCostExMarkup2, GuillotineMarkupPrice2, InkCostExMarkup2, InkMarkupPrice2, PlatesCostExMarkup2, PlatesMarkupPrice2, MakeReadyCostExMarkup2, MakeReadyMarkupPrice2, WashUpCostExMarkup2, WashUpMarkupPrice2, Qty3, InvSheets3, PrintSheets3, PaperCostExMarkup3, PaperMarkupPrice3, PressCostExMarkup3, PressMarkupPrice3, FirstTrimCuts3, FirstTrimNoOfBundles3, SecondTrimCuts3, SecondTrimNoOfBundles3, GuillotineCostExMarkup3, GuillotineMarkupPrice3, InkCostExMarkup3, InkMarkupPrice3, PlatesCostExMarkup3, PlatesMarkupPrice3, MakeReadyCostExMarkup3, MakeReadyMarkupPrice3, WashUpCostExMarkup3, WashUpMarkupPrice3, Qty4, InvSheets4, PrintSheets4, PaperCostExMarkup4, PaperMarkupPrice4, PressCostExMarkup4, PressMarkupPrice4, FirstTrimCuts4, FirstTrimNoOfBundles4, SecondTrimCuts4, SecondTrimNoOfBundles4, GuillotineCostExMarkup4, GuillotineMarkupPrice4, InkCostExMarkup4, InkMarkupPrice4, PlatesCostExMarkup4, PlatesMarkupPrice4, MakeReadyCostExMarkup4, MakeReadyMarkupPrice4, WashUpCostExMarkup4, WashUpMarkupPrice4, QueryType, EstimateBookletItemID, PressJobTimeSide11, PressJobTimeSide12, PressJobTimeSide13, PressJobTimeSide14, PressJobTimeSide21, PressJobTimeSide22, PressJobTimeSide23, PressJobTimeSide24, Zone_Side1_PressMarkupPercentage1, Zone_Side1_PressMarkupPercentage2, Zone_Side1_PressMarkupPercentage3, Zone_Side1_PressMarkupPercentage4, Zone_Side2_PressMarkupPercentage1, Zone_Side2_PressMarkupPercentage2, Zone_Side2_PressMarkupPercentage3, Zone_Side2_PressMarkupPercentage4, Zone_Side1_PressMarkupPrice1, Zone_Side1_PressMarkupPrice2, Zone_Side1_PressMarkupPrice3, Zone_Side1_PressMarkupPrice4, Zone_Side2_PressMarkupPrice1, Zone_Side2_PressMarkupPrice2, Zone_Side2_PressMarkupPrice3, Zone_Side2_PressMarkupPrice4, Zone_Side1_PressCostExMarkup1, Zone_Side1_PressCostExMarkup2, Zone_Side1_PressCostExMarkup3, Zone_Side1_PressCostExMarkup4, Zone_Side2_PressCostExMarkup1, Zone_Side2_PressCostExMarkup2, Zone_Side2_PressCostExMarkup3, Zone_Side2_PressCostExMarkup4, PressCostExMarkup_Actual1, PressCostExMarkup_Actual2, PressCostExMarkup_Actual3, PressCostExMarkup_Actual4, GuillotineCostExMarkup_Actual1, GuillotineCostExMarkup_Actual2, GuillotineCostExMarkup_Actual3, GuillotineCostExMarkup_Actual4);
        }

        public static void quantity_insert_digital_item(int CompanyID, long EstimateItemID, string EstimateType, int Qty1, decimal InvSheets1, decimal PrintSheets1, decimal PaperCostExMarkup1, decimal PaperMarkupPrice1, decimal PressCostExMarkup1, decimal PressMarkupPrice1, decimal FirstTrimCuts1, decimal FirstTrimNoOfBundles1, decimal SecondTrimCuts1, decimal SecondTrimNoOfBundles1, decimal GuillotineCostExMarkup1, decimal GuillotineMarkupPrice1, decimal InkCostExMarkup1, decimal InkMarkupPrice1, decimal PlatesCostExMarkup1, decimal PlatesMarkupPrice1, decimal MakeReadyCostExMarkup1, decimal MakeReadyMarkupPrice1, decimal WashUpCostExMarkup1, decimal WashUpMarkupPrice1, int Qty2, decimal InvSheets2, decimal PrintSheets2, decimal PaperCostExMarkup2, decimal PaperMarkupPrice2, decimal PressCostExMarkup2, decimal PressMarkupPrice2, decimal FirstTrimCuts2, decimal FirstTrimNoOfBundles2, decimal SecondTrimCuts2, decimal SecondTrimNoOfBundles2, decimal GuillotineCostExMarkup2, decimal GuillotineMarkupPrice2, decimal InkCostExMarkup2, decimal InkMarkupPrice2, decimal PlatesCostExMarkup2, decimal PlatesMarkupPrice2, decimal MakeReadyCostExMarkup2, decimal MakeReadyMarkupPrice2, decimal WashUpCostExMarkup2, decimal WashUpMarkupPrice2, int Qty3, decimal InvSheets3, decimal PrintSheets3, decimal PaperCostExMarkup3, decimal PaperMarkupPrice3, decimal PressCostExMarkup3, decimal PressMarkupPrice3, decimal FirstTrimCuts3, decimal FirstTrimNoOfBundles3, decimal SecondTrimCuts3, decimal SecondTrimNoOfBundles3, decimal GuillotineCostExMarkup3, decimal GuillotineMarkupPrice3, decimal InkCostExMarkup3, decimal InkMarkupPrice3, decimal PlatesCostExMarkup3, decimal PlatesMarkupPrice3, decimal MakeReadyCostExMarkup3, decimal MakeReadyMarkupPrice3, decimal WashUpCostExMarkup3, decimal WashUpMarkupPrice3, int Qty4, decimal InvSheets4, decimal PrintSheets4, decimal PaperCostExMarkup4, decimal PaperMarkupPrice4, decimal PressCostExMarkup4, decimal PressMarkupPrice4, decimal FirstTrimCuts4, decimal FirstTrimNoOfBundles4, decimal SecondTrimCuts4, decimal SecondTrimNoOfBundles4, decimal GuillotineCostExMarkup4, decimal GuillotineMarkupPrice4, decimal InkCostExMarkup4, decimal InkMarkupPrice4, decimal PlatesCostExMarkup4, decimal PlatesMarkupPrice4, decimal MakeReadyCostExMarkup4, decimal MakeReadyMarkupPrice4, decimal WashUpCostExMarkup4, decimal WashUpMarkupPrice4, string QueryType, long EstimateBookletItemID, decimal PressJobTimeSide11, decimal PressJobTimeSide12, decimal PressJobTimeSide13, decimal PressJobTimeSide14, decimal PressJobTimeSide21, decimal PressJobTimeSide22, decimal PressJobTimeSide23, decimal PressJobTimeSide24, decimal Zone_Side1_PressMarkupPercentage1, decimal Zone_Side1_PressMarkupPercentage2, decimal Zone_Side1_PressMarkupPercentage3, decimal Zone_Side1_PressMarkupPercentage4, decimal Zone_Side2_PressMarkupPercentage1, decimal Zone_Side2_PressMarkupPercentage2, decimal Zone_Side2_PressMarkupPercentage3, decimal Zone_Side2_PressMarkupPercentage4, decimal Zone_Side1_PressMarkupPrice1, decimal Zone_Side1_PressMarkupPrice2, decimal Zone_Side1_PressMarkupPrice3, decimal Zone_Side1_PressMarkupPrice4, decimal Zone_Side2_PressMarkupPrice1, decimal Zone_Side2_PressMarkupPrice2, decimal Zone_Side2_PressMarkupPrice3, decimal Zone_Side2_PressMarkupPrice4, decimal Zone_Side1_PressCostExMarkup1, decimal Zone_Side1_PressCostExMarkup2, decimal Zone_Side1_PressCostExMarkup3, decimal Zone_Side1_PressCostExMarkup4, decimal Zone_Side2_PressCostExMarkup1, decimal Zone_Side2_PressCostExMarkup2, decimal Zone_Side2_PressCostExMarkup3, decimal Zone_Side2_PressCostExMarkup4, decimal PressCostExMarkup_Actual1, decimal PressCostExMarkup_Actual2, decimal PressCostExMarkup_Actual3, decimal PressCostExMarkup_Actual4, decimal GuillotineCostExMarkup_Actual1, decimal GuillotineCostExMarkup_Actual2, decimal GuillotineCostExMarkup_Actual3, decimal GuillotineCostExMarkup_Actual4, decimal Zone_Side1_ChargeableRate1, decimal Zone_Side1_ChargeableRate2, decimal Zone_Side1_ChargeableRate3, decimal Zone_Side1_ChargeableRate4, decimal Zone_Side2_ChargeableRate1, decimal Zone_Side2_ChargeableRate2, decimal Zone_Side2_ChargeableRate3, decimal Zone_Side2_ChargeableRate4)
        {
            EstimateNew.quantity_insert_digital_item(CompanyID, EstimateItemID, EstimateType, Qty1, InvSheets1, PrintSheets1, PaperCostExMarkup1, PaperMarkupPrice1, PressCostExMarkup1, PressMarkupPrice1, FirstTrimCuts1, FirstTrimNoOfBundles1, SecondTrimCuts1, SecondTrimNoOfBundles1, GuillotineCostExMarkup1, GuillotineMarkupPrice1, InkCostExMarkup1, InkMarkupPrice1, PlatesCostExMarkup1, PlatesMarkupPrice1, MakeReadyCostExMarkup1, MakeReadyMarkupPrice1, WashUpCostExMarkup1, WashUpMarkupPrice1, Qty2, InvSheets2, PrintSheets2, PaperCostExMarkup2, PaperMarkupPrice2, PressCostExMarkup2, PressMarkupPrice2, FirstTrimCuts2, FirstTrimNoOfBundles2, SecondTrimCuts2, SecondTrimNoOfBundles2, GuillotineCostExMarkup2, GuillotineMarkupPrice2, InkCostExMarkup2, InkMarkupPrice2, PlatesCostExMarkup2, PlatesMarkupPrice2, MakeReadyCostExMarkup2, MakeReadyMarkupPrice2, WashUpCostExMarkup2, WashUpMarkupPrice2, Qty3, InvSheets3, PrintSheets3, PaperCostExMarkup3, PaperMarkupPrice3, PressCostExMarkup3, PressMarkupPrice3, FirstTrimCuts3, FirstTrimNoOfBundles3, SecondTrimCuts3, SecondTrimNoOfBundles3, GuillotineCostExMarkup3, GuillotineMarkupPrice3, InkCostExMarkup3, InkMarkupPrice3, PlatesCostExMarkup3, PlatesMarkupPrice3, MakeReadyCostExMarkup3, MakeReadyMarkupPrice3, WashUpCostExMarkup3, WashUpMarkupPrice3, Qty4, InvSheets4, PrintSheets4, PaperCostExMarkup4, PaperMarkupPrice4, PressCostExMarkup4, PressMarkupPrice4, FirstTrimCuts4, FirstTrimNoOfBundles4, SecondTrimCuts4, SecondTrimNoOfBundles4, GuillotineCostExMarkup4, GuillotineMarkupPrice4, InkCostExMarkup4, InkMarkupPrice4, PlatesCostExMarkup4, PlatesMarkupPrice4, MakeReadyCostExMarkup4, MakeReadyMarkupPrice4, WashUpCostExMarkup4, WashUpMarkupPrice4, QueryType, EstimateBookletItemID, PressJobTimeSide11, PressJobTimeSide12, PressJobTimeSide13, PressJobTimeSide14, PressJobTimeSide21, PressJobTimeSide22, PressJobTimeSide23, PressJobTimeSide24, Zone_Side1_PressMarkupPercentage1, Zone_Side1_PressMarkupPercentage2, Zone_Side1_PressMarkupPercentage3, Zone_Side1_PressMarkupPercentage4, Zone_Side2_PressMarkupPercentage1, Zone_Side2_PressMarkupPercentage2, Zone_Side2_PressMarkupPercentage3, Zone_Side2_PressMarkupPercentage4, Zone_Side1_PressMarkupPrice1, Zone_Side1_PressMarkupPrice2, Zone_Side1_PressMarkupPrice3, Zone_Side1_PressMarkupPrice4, Zone_Side2_PressMarkupPrice1, Zone_Side2_PressMarkupPrice2, Zone_Side2_PressMarkupPrice3, Zone_Side2_PressMarkupPrice4, Zone_Side1_PressCostExMarkup1, Zone_Side1_PressCostExMarkup2, Zone_Side1_PressCostExMarkup3, Zone_Side1_PressCostExMarkup4, Zone_Side2_PressCostExMarkup1, Zone_Side2_PressCostExMarkup2, Zone_Side2_PressCostExMarkup3, Zone_Side2_PressCostExMarkup4, PressCostExMarkup_Actual1, PressCostExMarkup_Actual2, PressCostExMarkup_Actual3, PressCostExMarkup_Actual4, GuillotineCostExMarkup_Actual1, GuillotineCostExMarkup_Actual2, GuillotineCostExMarkup_Actual3, GuillotineCostExMarkup_Actual4, Zone_Side1_ChargeableRate1, Zone_Side1_ChargeableRate2, Zone_Side1_ChargeableRate3, Zone_Side1_ChargeableRate4, Zone_Side2_ChargeableRate1, Zone_Side2_ChargeableRate2, Zone_Side2_ChargeableRate3, Zone_Side2_ChargeableRate4);
        }

        public static DataTable quantity_Select_forOtherCost(long EstimateItemID, string QueryType, long EstimateBookletItemID)
        {
            return EstimateNew.quantity_Select_forOtherCost(EstimateItemID, QueryType, EstimateBookletItemID);
        }

        public static DataTable DeliveryCost_Description_Select(int CompanyID, long EstimateID, long EstimateItemID)
        {
            return EstimateNew.DeliveryCost_Description_Select(CompanyID, EstimateID, EstimateItemID);
        }

        public static DataTable deliverycost_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.deliverycost_item_select(CompanyID, EstimateItemID);
        }

        public static DataTable QuickQuote_Description_Select(int CompanyID, long EstimateID, long EstimateItemID)
        {
            return EstimateNew.QuickQuote_Description_Select(CompanyID, EstimateID, EstimateItemID);
        }

        public static DataTable quickquote_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.quickquote_item_select(CompanyID, EstimateItemID);
        }

        public static void Update_InvStock_calculation(long EstimateItemID, decimal InvStock)
        {
             EstimateNew.Update_InvStock_calculation(EstimateItemID, InvStock);
        }

        public static decimal required_length_calculation(int Qty, string PrintLayout, decimal PrintLayoutValue, decimal JobHeight, decimal JobWidth, decimal SheetHeight, decimal SheetWidth, bool IsGuttersOn, decimal HorizontalGutter, decimal SetupSpoilage, decimal RunningSpoialge, decimal Row, decimal Col, string PaperMeasure, string spoilagetype)
        {
            
            decimal num = new decimal(0);
            if (PrintLayoutValue != new decimal(0))
            {
                num = Convert.ToDecimal(Qty) / Convert.ToDecimal(PrintLayoutValue);
            }
            decimal jobWidth = new decimal(0);
            decimal jobHeight = new decimal(0);
            if (JobWidth <= JobHeight)
            {
                jobHeight = JobHeight;
                jobWidth = JobWidth;
            }
            else
            {
                jobHeight = JobWidth;
                jobWidth = JobHeight;
            }
            if (string.Compare(PrintLayout, "L", true) == 0)
            {
                if (Qty >= PrintLayoutValue)
                {
                    num = (SheetHeight * Qty) / PrintLayoutValue;
                }
                else
                {
                    decimal num1 = new decimal(0);
                    if (!IsGuttersOn)
                    {
                        num1 = jobWidth;
                    }
                    else
                    {
                        num1 = (Qty <= 1 ? jobWidth : jobWidth + HorizontalGutter);
                    }
                    decimal num2 = Math.Ceiling(Convert.ToDecimal(Qty) / Convert.ToDecimal(Col));
                    num = num1 * num2;
                }
            }
            else if (Qty >= PrintLayoutValue)
            {
                if (jobHeight > (SheetHeight / 2))
                {
                    num = (jobHeight * Qty) / PrintLayoutValue;
                }
                else
                {
                    num = (SheetHeight * Qty) / PrintLayoutValue;
                }
                //num = (SheetHeight * Qty) / PrintLayoutValue;
            }
            else
            {
                decimal num3 = new decimal(0);
                if (!IsGuttersOn)
                {
                    num3 = jobHeight;
                }
                else
                {
                    num3 = (Qty <= 1 ? jobHeight : jobHeight + HorizontalGutter);
                }
                decimal num4 = Math.Ceiling(Convert.ToDecimal(Qty) / Convert.ToDecimal(Col));
                num = num3 * num4;
            }
            decimal runningSpoialge = (num * RunningSpoialge) / new decimal(100);
            if (PrintLayout == "L")
            {
                
                if (PaperMeasure != "In." && PaperMeasure != "mm")
                {
                    num = num + (SetupSpoilage * SheetHeight);
                }
                else
                {
                    num = num + SetupSpoilage;
                }

            }
            else
            {
                if (spoilagetype == "sheet")
                {
                    num = num;
                }
                else
                {
                    num = num + SetupSpoilage;
                }

            }

            //num = num + SetupSpoilage;
            num = num + runningSpoialge;
            num = (PaperMeasure != "In." ? num / new decimal(1000) : num / new decimal(12));

            if (spoilagetype == "sheet")
            {
                num = num + SetupSpoilage;
            }

            num = EstimatesBasePage.ReturnExact2Decimal(num);
            return num;
        }

        public static decimal ReturnExact2Decimal(decimal Amount)
        {
            return Amount;
        }

        public static void SaveQtyDescription(long EstimateItemID, string Qtydesc1, string Qtydesc2, string Qtydesc3, string Qtydesc4, int CompanyID)
        {
            EstimateNew.SaveQtyDescription(EstimateItemID, Qtydesc1, Qtydesc2, Qtydesc3, Qtydesc4, CompanyID);
        }

        public static DataTable Select_AccountingCode_For_Summary(int CompanyID, long EstimateItemID, string EstimateType, long EstimateID)
        {
            return EstimateNew.Select_AccountingCode_For_Summary(CompanyID, EstimateItemID, EstimateType, EstimateID);
        }

        public static DataTable select_AdditionalItem_IDs(int CompanyID, long EstimateItemID, string EstimateItemType)
        {
            return EstimateNew.select_AdditionalItem_IDs(CompanyID, EstimateItemID, EstimateItemType);
        }

        public static DataTable select_Converted_Prodect(int CompanyID, long EstimateItemID, string Esttype)
        {
            return EstimateNew.select_Converted_Prodect(CompanyID, EstimateItemID, Esttype);
        }

        public static DataTable select_details_for_Activity_History(int CompanyID, long EstimateID, string PgType, long POID)
        {
            return EstimateNew.select_details_for_Activity_History(CompanyID, EstimateID, PgType, POID);
        }

        public static DataTable select_details_for_JobActivity_History(int CompanyID, long JobID)
        {
            return EstimateNew.select_details_for_JobActivity_History(CompanyID, JobID);
        }

        public static DataTable select_EstimateItemID(long EstimateID)
        {
            return EstimateNew.select_EstimateItemID(EstimateID);
        }

        public static DataTable select_InventoryInkMatrix_SetUpCost(int CompanyID, long InventoryID)
        {
            return EstimateNew.select_InventoryInkMatrix_SetUpCost(CompanyID, InventoryID);
        }

        public static DataTable select_InventoryInkMatrixDetails_inkCal(int CompanyID, long InventoryID, string InventorySheetsFromTo)
        {
            return EstimateNew.select_InventoryInkMatrixDetails_inkCal(CompanyID, InventoryID, InventorySheetsFromTo);
        }

        public static DataTable Select_Item_Number_Title_basedonModule(int ComanyID, long EstimateItemID, string Module)
        {
            return EstimateNew.Select_Item_Number_Title_basedonModule(ComanyID, EstimateItemID, Module);
        }

        public static DataTable Select_OrderIDAdditionalitemID_Select(long PriceCatalogueID)
        {
            return EstimateNew.Select_OrderIDAdditionalitemID_Select(PriceCatalogueID);
        }

        public static DataSet Select_OrderItems_WithAdditionalItems(long OrderItemID)
        {
            return EstimateNew.Select_OrderItems_WithAdditionalItems(OrderItemID);
        }

        public static DataSet select_othercost_parentdetails(long EstimateID, long EstimateItemID)
        {
            return EstimateNew.select_othercost_parentdetails(EstimateID, EstimateItemID);
        }

        public static DataSet Select_OtherCostAdditional_ItemsDetail(long WebOtherCostID)
        {
            return EstimateNew.Select_OtherCostAdditional_ItemsDetail(WebOtherCostID);
        }

        public static DataTable Select_OtherCostAdditional_ItemsIDs(long PriceCatalogueID)
        {
            return EstimateNew.Select_OtherCostAdditional_ItemsIDs(PriceCatalogueID);
        }

        public static DataTable Select_OtherCostItemQty(long EstimateID, long EstimateItemID)
        {
            return EstimateNew.Select_OtherCostItemQty(EstimateID, EstimateItemID);
        }

        public static DataTable Select_ProductCatalogueQty(long EstimateItemID, string EstimateType)
        {
            return EstimateNew.Select_ProductCatalogueQty(EstimateItemID, EstimateType);
        }

        public static DataTable Select_Prompt_Archive(int CompanyID, string Event)
        {
            return EstimateNew.Select_Prompt_Archive(CompanyID, Event);
        }

        public static DataTable selectEstimatetype_estimateitemid(long EstimateItemID, long EstimateID)
        {
            return EstimateNew.selectEstimatetype_estimateitemid(EstimateItemID, EstimateID);
        }

        public static DataTable SelectItemDescFrmEsOutwork(long EstimateItemID)
        {
            return EstimateNew.SelectItemDescFrmEsOutwork(EstimateItemID);
        }

        public static DataTable selectoutworkQtyType(int EstimateItemID)
        {
            return EstimateNew.selectoutworkQtyType(EstimateItemID);
        }

        public static DataTable SelectPlateunitprice_eachSectin(int InventoryID)
        {
            return EstimateNew.SelectPlateunitprice_eachSectin(InventoryID);
        }

        public static void SendingNewArtWorkFilenames(int CompanyID, long EstimateItemID, string SaveNewfilenames, string SaveOriginalFileNames, long NewEstimateItemID)
        {
            EstimateNew.SendingNewArtWorkFilenames(CompanyID, EstimateItemID, SaveNewfilenames, SaveOriginalFileNames, NewEstimateItemID);
        }

        public static DataTable SentForQuoteStatus_SupQuoteDet(long SupplierID, long Estoutworkid, int QuantityNumber)
        {
            return EstimateNew.SentForQuoteStatus_SupQuoteDet(SupplierID, Estoutworkid, QuantityNumber);
        }

        public static string settings_jobViewColor_SelectedDateType(int CompanyId)
        {
            return EstimateNew.settings_jobViewColor_SelectedDateType(CompanyId);
        }

        public static DataTable settings_lithopress_InkSelect(int CompanyID, long LithoPressID)
        {
            return EstimateNew.settings_lithopress_InkSelect(CompanyID, LithoPressID);
        }

        public static DataSet settings_Product_CatalogueAdditional_Select(int CompanyID, long PriceCatalogueID)
        {
            return EstimateNew.settings_Product_CatalogueAdditional_Select(CompanyID, PriceCatalogueID);
        }

        public static string sheetExactMatchFind(int sheettofind, StringBuilder sheets)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string[] strArrays = new string[] { "," };
            string[] strArrays1 = sheets.ToString().Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
            string[] strArrays2 = sheets.ToString().Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < (int)strArrays2.Length; i++)
            {
                if (sheettofind == Convert.ToInt32(strArrays2[i]))
                {
                    empty = sheettofind.ToString();
                }
            }
            if (empty == "")
            {
                if (sheets.Length <= 0)
                {
                    empty = "0";
                }
                else if (sheettofind < Convert.ToInt32(strArrays1[0].ToString()))
                {
                    empty = strArrays1[0].ToString();
                }
                else if (sheettofind <= Convert.ToInt32(strArrays1[(int)strArrays1.Length - 1].ToString()))
                {
                    for (int j = 0; j < (int)strArrays1.Length; j++)
                    {
                        if (sheettofind > Convert.ToInt32(strArrays1[j].ToString()) && sheettofind < Convert.ToInt32(strArrays1[j + 1].ToString()))
                        {
                            empty = string.Concat(strArrays1[j].ToString(), ',', strArrays1[j + 1].ToString());
                        }
                    }
                }
                else
                {
                    empty = strArrays1[(int)strArrays1.Length - 1].ToString();
                }
            }
            return empty;
        }

        public static long SingelItem_Inset_By_Copy(int CompanyID, long OldEstimateID, long NewEstimateID, long Old_EstimateItemID, string IsParentItem)
        {
            return EstimateNew.SingelItem_Inset_By_Copy(CompanyID, OldEstimateID, NewEstimateID, Old_EstimateItemID, IsParentItem);
        }

        public static long single_item_insert(EstimatesItem item)
        {
            return EstimateNew.single_item_insert(item);
        }

        public static DataTable single_item_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.single_item_select(CompanyID, EstimateItemID);
        }

        public static decimal SpeedWeightLookup_Cost(int CompanyID, decimal Totalpaper, decimal PaperWeight, decimal HourlyCharge, long EstimateCalculationID, string ColorType, decimal PressSetCharge, decimal PressMinimumCharge, decimal PressMarkUp, ref decimal JobTime)
        {
            JobTime = new decimal(0);
            decimal num = new decimal(0);
            int num1 = 0;
            decimal num2 = new decimal(0);
            int num3 = 0;
            decimal num4 = new decimal(0);
            int num5 = 0;
            decimal num6 = new decimal(0);
            int num7 = 0;
            decimal num8 = new decimal(0);
            int num9 = 0;
            decimal num10 = new decimal(0);
            int num11 = 0;
            foreach (DataRow row in EstimateNew.estimate_speedweight_select(CompanyID, EstimateCalculationID).Rows)
            {
                num = Convert.ToDecimal(row["BlackGSM1"]);
                num1 = Convert.ToInt32(row["BlackPagesPerMinute1"]);
                num2 = Convert.ToDecimal(row["BlackGSM2"]);
                num3 = Convert.ToInt32(row["BlackPagesPerMinute2"]);
                num4 = Convert.ToDecimal(row["BlackGSM3"]);
                num5 = Convert.ToInt32(row["BlackPagesPerMinute3"]);
                num6 = Convert.ToDecimal(row["ColorGSM1"]);
                num7 = Convert.ToInt32(row["ColorPagesPerMinute1"]);
                num8 = Convert.ToDecimal(row["ColorGSM2"]);
                num9 = Convert.ToInt32(row["ColorPagesPerMinute2"]);
                num10 = Convert.ToDecimal(row["ColorGSM3"]);
                num11 = Convert.ToInt32(row["ColorPagesPerMinute3"]);
            }
            decimal num12 = new decimal(0);
            int num13 = 0;
            decimal num14 = new decimal(0);
            decimal paperWeight = new decimal(0);
            decimal paperWeight1 = new decimal(0);
            if (ColorType != "color")
            {
                if (PaperWeight <= num)
                {
                    if (PaperWeight != num)
                    {
                        paperWeight1 = PaperWeight * (num1 / num);
                    }
                    else
                    {
                        paperWeight1 = num1;
                    }
                }
                else if (PaperWeight > num && PaperWeight <= num2)
                {
                    if (PaperWeight >= num2)
                    {
                        paperWeight1 = num3;
                    }
                    else
                    {
                        num12 = num2 - num;
                        num13 = num3 - num1;
                        paperWeight = PaperWeight - num;
                        num14 = (num13 / num12) * paperWeight;
                        paperWeight1 = num14 + num1;
                    }
                }
                else if (PaperWeight > num2 && PaperWeight <= num4)
                {
                    if (PaperWeight >= num4)
                    {
                        paperWeight1 = num5;
                    }
                    else
                    {
                        num12 = num4 - num2;
                        num13 = num5 - num3;
                        paperWeight = PaperWeight - num2;
                        num14 = (num13 / num12) * paperWeight;
                        paperWeight1 = num14 + num3;
                    }
                }
                else if (PaperWeight > num4)
                {
                    if (PaperWeight != num4)
                    {
                        paperWeight1 = PaperWeight * (num5 / num4);
                    }
                    else
                    {
                        paperWeight1 = num5;
                    }
                }
                decimal num15 = Convert.ToDecimal(Totalpaper);
                decimal num16 = num15 / (paperWeight1 / new decimal(60));
                JobTime = num16;
                decimal hourlyCharge = (HourlyCharge / new decimal(60)) * num16;
                return hourlyCharge;
            }
            if (PaperWeight <= num6)
            {
                if (PaperWeight != num6)
                {
                    paperWeight1 = PaperWeight * (num7 / num6);
                }
                else
                {
                    paperWeight1 = num7;
                }
            }
            else if (PaperWeight > num6 && PaperWeight <= num8)
            {
                if (PaperWeight >= num8)
                {
                    paperWeight1 = num9;
                }
                else
                {
                    num12 = num8 - num6;
                    num13 = num9 - num7;
                    paperWeight = PaperWeight - num6;
                    num14 = (num13 / num12) * paperWeight;
                    paperWeight1 = num14 + num7;
                }
            }
            else if (PaperWeight > num8 && PaperWeight <= num10)
            {
                if (PaperWeight >= num10)
                {
                    paperWeight1 = num11;
                }
                else
                {
                    num12 = num10 - num8;
                    num13 = num11 - num9;
                    paperWeight = PaperWeight - num8;
                    num14 = (num13 / num12) * paperWeight;
                    paperWeight1 = num14 + num9;
                }
            }
            else if (PaperWeight > num10)
            {
                if (PaperWeight != num10)
                {
                    decimal num17 = new decimal(0);
                    if (num10 > new decimal(0))
                    {
                        num17 = num11 / num10;
                    }
                    paperWeight1 = PaperWeight * num17;
                }
                else
                {
                    paperWeight1 = num11;
                }
            }
            decimal num18 = Convert.ToDecimal(Totalpaper);
            decimal num19 = paperWeight1 / new decimal(60);
            decimal num20 = new decimal(0);
            if (num19 > new decimal(0))
            {
                num20 = num18 / num19;
            }
            JobTime = num20;
            decimal hourlyCharge1 = (HourlyCharge / new decimal(60)) * num20;
            return hourlyCharge1;
        }

        public static void sub_item_outwork_markup_update(int CompanyID, long EstOutworkSupplierID, decimal Markup, decimal TotalPrice)
        {
            EstimateNew.sub_item_outwork_markup_update(CompanyID, EstOutworkSupplierID, Markup, TotalPrice);
        }

        public static DataSet sub_item_summary(int CompanyID, long EstimateItemID, string Estimatetype)
        {
            return EstimateNew.sub_item_summary(CompanyID, EstimateItemID, Estimatetype);
        }

        public static DataTable sub_warehouse_in_summary(long CompanyID, long ParentItemID, string ParentItemType)
        {
            return EstimateNew.sub_warehouse_in_summary(CompanyID, ParentItemID, ParentItemType);
        }

        public static void subtotal_update(int CompanyID, long EstimateItemID, int Qty, decimal SubTotal, decimal Tax, decimal ProfitMargin, int TaxID, int orderNumber, long EstimateBookletItemID, decimal CostPriceExMarkup, decimal MarkupPrice)
        {
            if (SubTotal.ToString().ToLower().Trim() == "nan")
            {
                SubTotal = new decimal(0);
            }
            EstimateNew.subtotal_update(CompanyID, EstimateItemID, Qty, SubTotal, Tax, ProfitMargin, TaxID, orderNumber, EstimateBookletItemID, CostPriceExMarkup, MarkupPrice);
        }

        public static void subtotal_update_new(int CompanyID, long EstimateItemID, int Qty, decimal SubTotal, decimal Tax, decimal ProfitMargin, int TaxID, int orderNumber, long EstimateBookletItemID, decimal CostPriceExMarkup, decimal MarkupPrice, decimal ProfitMarginPrice, int QtyNumber, decimal TaxValue, decimal SellingPrice)
        {
            EstimateNew.subtotal_update_new(CompanyID, EstimateItemID, Qty, SubTotal, Tax, ProfitMargin, TaxID, orderNumber, EstimateBookletItemID, CostPriceExMarkup, MarkupPrice, ProfitMarginPrice, QtyNumber, TaxValue, SellingPrice);
        }

        public static void subtotal_update_OnSave(int CompanyID, long EstimateItemID, int Qty, decimal SubTotal, decimal Tax, decimal ProfitMargin, int TaxID, int orderNumber, long EstimateBookletItemID, decimal CostPriceExMarkup, decimal MarkupPrice, int QtyNumber)
        {
            EstimateNew.subtotal_update_OnSave(CompanyID, EstimateItemID, Qty, SubTotal, Tax, ProfitMargin, TaxID, orderNumber, EstimateBookletItemID, CostPriceExMarkup, MarkupPrice, QtyNumber);
        }

        public static DataTable summary_outwork_select(int CompanyID, long EstimateItemID)
        {
            return EstimateNew.summary_outwork_select(CompanyID, EstimateItemID);
        }

        public static void summary_sub_ware_markup_update(int CompanyID, long EstWarehouseItemID, decimal Markup)
        {
            EstimateNew.summary_sub_ware_markup_update(CompanyID, EstWarehouseItemID, Markup);
        }

        public static DataSet SupplierID_PerQty(long EstimateItemID, string Type)
        {
            return EstimateNew.SupplierID_PerQty(EstimateItemID, Type);
        }

        public static string TakeLithoInkDetails(string sidesprinted, string esttype, long estimateitemid, long estimatelithoncritemid, long estimatelithobooketitemid, int count, string Sectionreference, int CompanyID)
        {
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string regionalSettings = (new BasePage()).GetRegionalSettings(CompanyID, "colour");
            DataTable dataTable = EstimatesBasePage.inkselectfromdatabase(CompanyID, estimateitemid);
            int num = 0;
            if (dataTable.Rows.Count > 0)
            {
                int num1 = 0;
                DataRow[] dataRowArray = dataTable.Select(string.Concat("sidenumber='side1' and sectionname='Parts", count, "'"));
                for (int i = 0; i < (int)dataRowArray.Length; i++)
                {
                    DataRow dataRow = dataRowArray[i];
                    if (num1 == 0)
                    {
                        string str2 = empty1;
                        string[] sectionreference = new string[] { str2, Sectionreference, " : Side1: Side1Colour ", regionalSettings, " - " };
                        empty1 = string.Concat(sectionreference);
                    }
                    empty1 = string.Concat(empty1, dataRow["InkName"].ToString(), ", ");
                    num1++;
                }
                int num2 = 0;
                DataRow[] dataRowArray1 = dataTable.Select(string.Concat("sidenumber='side2' and sectionname='Parts", count, "'"));
                for (int j = 0; j < (int)dataRowArray1.Length; j++)
                {
                    DataRow dataRow1 = dataRowArray1[j];
                    if (num2 == 0)
                    {
                        string str3 = str1;
                        string[] strArrays = new string[] { str3, Sectionreference, " : Side2: Side2Colour ", regionalSettings, " - " };
                        str1 = string.Concat(strArrays);
                    }
                    str1 = string.Concat(str1, dataRow1["InkName"].ToString(), ", ");
                    num2++;
                }
                empty2 = (!(empty1 != "") || !(str1 != "") ? string.Concat(empty1.Replace("Side1Colour", num1.ToString()), "\n", str1.Replace("Side2Colour", num2.ToString())) : string.Concat(empty1.Replace("Side1Colour", num1.ToString()), "\n", str1.Replace("Side2Colour", num2.ToString()), "\n"));
                if (empty2.Length > 0)
                {
                    empty2 = empty2.Remove(empty2.Length - 2, 2);
                }
                empty = string.Concat(empty2, " \n");
                num++;
            }
            return empty;
        }

        public static string TakeLithoInkDetails_jobcard(long estimateitemid, int count, int CompanyID)
        {
            string empty = string.Empty;
            DataTable dataTable = EstimatesBasePage.inkselectfromdatabase(CompanyID, estimateitemid);
            if (dataTable.Rows.Count > 0)
            {
                DataRow[] dataRowArray = dataTable.Select(string.Concat("sidenumber='side1' and sectionname='Parts", count, "'"));
                for (int i = 0; i < (int)dataRowArray.Length; i++)
                {
                    DataRow dataRow = dataRowArray[i];
                    empty = string.Concat(empty, dataRow["InkName"].ToString(), ", ");
                }
                if (empty.Length > 0)
                {
                    empty = empty.Remove(empty.Length - 2, 2);
                }
            }
            return empty;
        }

        public static string TakeLithoInkDetails_jobcardNew(long estimateitemid, int count, int CompanyID)
        {
            string empty = string.Empty;
            DataTable dataTable = EstimatesBasePage.inkselectfromdatabase(CompanyID, estimateitemid);
            if (dataTable.Rows.Count > 0)
            {
                DataRow[] dataRowArray = dataTable.Select(string.Concat("sidenumber='side2' and sectionname='Parts", count, "'"));
                for (int i = 0; i < (int)dataRowArray.Length; i++)
                {
                    DataRow dataRow = dataRowArray[i];
                    empty = string.Concat(empty, dataRow["InkName"].ToString(), ", ");
                }
                if (empty.Length > 0)
                {
                    empty = empty.Remove(empty.Length - 2, 2);
                }
            }
            return empty;
        }

        public static string TakeLithoInkDetails_old(string sidesprinted, string esttype, int CompanyID, long EstimateItemID)
        {
            BasePage basePage = new BasePage();
            string empty = string.Empty;
            string str = string.Empty;
            string empty1 = string.Empty;
            string str1 = string.Empty;
            string empty2 = string.Empty;
            string str2 = string.Empty;
            string empty3 = string.Empty;
            string regionalSettings = basePage.GetRegionalSettings(CompanyID, "colour");
            DataTable dataTable = EstimatesBasePage.estimate_lithopress_select_ink_name_item_desc(CompanyID, EstimateItemID, "", (long)0, (long)0, esttype);
            if (dataTable.Rows.Count > 0)
            {
                DataRow[] dataRowArray = dataTable.Select("sidenumber='side1'");
                for (int i = 0; i < (int)dataRowArray.Length; i++)
                {
                    DataRow dataRow = dataRowArray[i];
                    str2 = dataRow["side1Color"].ToString();
                    str = string.Concat(str, dataRow["InkName"].ToString(), ", ");
                }
                if (str.Length > 0)
                {
                    str = str.Remove(str.Length - 2, 2);
                    string[] strArrays = new string[] { "Side1: ", str2, " ", regionalSettings, " - " };
                    str1 = string.Concat(strArrays);
                }
                DataRow[] dataRowArray1 = dataTable.Select("sidenumber='side2'");
                for (int j = 0; j < (int)dataRowArray1.Length; j++)
                {
                    DataRow dataRow1 = dataRowArray1[j];
                    empty3 = dataRow1["side2Color"].ToString();
                    empty1 = string.Concat(empty1, dataRow1["InkName"].ToString(), ", ");
                }
                if (empty1.Length > 0)
                {
                    string[] strArrays1 = new string[] { "\nSide2: ", empty3, " ", regionalSettings, " - " };
                    empty2 = string.Concat(strArrays1);
                    empty1 = empty1.Remove(empty1.Length - 2, 2);
                }
            }
            return string.Concat(str1, str, empty2, empty1);
        }

        public static DataTable Tax_Bind(int companyID)
        {
            return EstimateNew.Tax_Bind(companyID);
        }

        public static void taxprofit_update(int CompanyID, long EstimateItemID, string EstimateType, int TaxID, decimal Tax, decimal ProfitMargin, long EstimateBookletItemID)
        {
            EstimateNew.taxprofit_update(CompanyID, EstimateItemID, EstimateType, TaxID, Tax, ProfitMargin, EstimateBookletItemID);
        }

        public static decimal TotalPrintSheets(int Quantity, decimal PrintLayoutValue, decimal SpoilageSheets, decimal RunningSpoilage)
        {
            decimal num = new decimal(0);
            decimal runningSpoilage = new decimal(0);
            decimal spoilageSheets = new decimal(0);
            if (PrintLayoutValue > new decimal(0))
            {
                num = Quantity / PrintLayoutValue;
            }
            runningSpoilage = (num * RunningSpoilage) / new decimal(100);
            spoilageSheets = (num + SpoilageSheets) + runningSpoilage;
            return Math.Ceiling(spoilageSheets);
        }

        public static void UnLockItemStatus(long EstimateItemID, string Module)
        {
            EstimateNew.UnLockItemStatus(EstimateItemID, Module);
        }

        public static void Update_customer_details_forNew_copy_estimate(int CompanyID, long EstimateID, long CustomerID, long AttentionID, string Greeting, string Company, long Address, long DeliveryAddress, int UserID, long InvAddressID)
        {
            EstimateNew.Update_customer_details_forNew_copy_estimate(CompanyID, EstimateID, CustomerID, AttentionID, Greeting, Company, Address, DeliveryAddress, UserID, InvAddressID);
        }

        public static void update_Materialcost_onLockUnitPrice(long qtyID, long estCalculationID, decimal PaperUnitPrice, bool islock, decimal PaperCostExMarkup1, decimal PaperCostExMarkup2, decimal PaperCostExMarkup3, decimal PaperCostExMarkup4, decimal PaperMarkupPrice1, decimal PaperMarkupPrice2, decimal PaperMarkupPrice3, decimal PaperMarkupPrice4)
        {
            EstimateNew.update_Materialcost_onLockUnitPrice(qtyID, estCalculationID, PaperUnitPrice, islock, PaperCostExMarkup1, PaperCostExMarkup2, PaperCostExMarkup3, PaperCostExMarkup4, PaperMarkupPrice1, PaperMarkupPrice2, PaperMarkupPrice3, PaperMarkupPrice4);
        }

        public static void update_OtherCostItemQty(long EstimateItemID, string EstimateType, int Qty1, int Qty2, int Qty3, int Qty4)
        {
            EstimateNew.update_OtherCostItemQty(EstimateItemID, EstimateType, Qty1, Qty2, Qty3, Qty4);
        }

        public static void update_papercost_onLockUnitPrice(long qtyID, long estCalculationID, decimal PaperUnitPrice, bool islock, decimal PaperCostExMarkup1, decimal PaperCostExMarkup2, decimal PaperCostExMarkup3, decimal PaperCostExMarkup4, decimal PaperMarkupPrice1, decimal PaperMarkupPrice2, decimal PaperMarkupPrice3, decimal PaperMarkupPrice4, string Module, int QtyNumber)
        {
            EstimateNew.update_papercost_onLockUnitPrice(qtyID, estCalculationID, PaperUnitPrice, islock, PaperCostExMarkup1, PaperCostExMarkup2, PaperCostExMarkup3, PaperCostExMarkup4, PaperMarkupPrice1, PaperMarkupPrice2, PaperMarkupPrice3, PaperMarkupPrice4, Module, QtyNumber);
        }

        public static void updateitemdescription_forink_litho(long EstimateItemID, string EstimateType, string ItemDescription, long Estimatelithoncritemid, long Estimatelithobookletitemid)
        {
            EstimateNew.updateitemdescription_forink_litho(EstimateItemID, EstimateType, ItemDescription, Estimatelithoncritemid, Estimatelithobookletitemid);
        }

        public static void updateProfitmargin_OnCustomerChange(long CompanyID, long EstimateID)
        {
            EstimateNew.updateProfitmargin_OnCustomerChange(CompanyID, EstimateID);
        }

        public static void updateSubTotalLock(long EstimateItemID)
        {
            EstimateNew.updateSubTotalLock(EstimateItemID);
        }

        public static void updatetotalTax_and_sellingPrice_forOtherCost(long EstTotalID, decimal TaxValue, decimal SellingPrice, long taxID, decimal taxpercent)
        {
            EstimateNew.updatetotalTax_and_sellingPrice_forOtherCost(EstTotalID, TaxValue, SellingPrice, taxID, taxpercent);
        }

        public static bool Views_IsItemDetailsSelected(long ViewID)
        {
            return EstimateNew.Views_IsItemDetailsSelected(ViewID);
        }

        public static string Views_RecordsToDisplay(long ViewID)
        {
            return EstimateNew.Views_RecordsToDisplay(ViewID);
        }

        public static DataTable warehouse_inventoryinkMatrix_select(int CompanyID, long InventoryID)
        {
            return EstimateNew.warehouse_inventoryinkMatrix_select(CompanyID, InventoryID);
        }

        public static string Warehouse_Markup(int CompanyID, int InventoryNo)
        {
            return EstimateNew.Warehouse_Markup(CompanyID, InventoryNo);
        }

        public static string warehouse_perquantity_select(int CompanyID, string WarehouseType, long WarehouseTypeID)
        {
            return EstimateNew.warehouse_perquantity_select(CompanyID, WarehouseType, WarehouseTypeID);
        }

        public static DataTable estimateCalculationSelect(long ID)
        {
            return EstimateNew.estimateCalculationSelect(ID);
        }

        public static bool PC_select_JobLocking_Status(long ID)
        {

            return EstimateNew.PC_select_JobLocking_Status(ID);
        }

        public static void PC_update_JobLocking_Status(long ID, Boolean Status)
        {

            EstimateNew.PC_update_JobLocking_Status(ID, Status);
        }

        public static void update_multiple_product_categories(long PriceCatalogueID, int PriceCatalogueCategoryID_2, int PriceCatalogueCategoryID_3, int PriceCatalogueCategoryID_4, int PriceCatalogueCategoryID_5, int PriceCatalogueCategoryID_6)
        {
            EstimateNew.update_multiple_product_categories(PriceCatalogueID, PriceCatalogueCategoryID_2, PriceCatalogueCategoryID_3, PriceCatalogueCategoryID_4, PriceCatalogueCategoryID_5, PriceCatalogueCategoryID_6);
        }

        public static void Import_otherstore_deliveryCost(long PriceCatalogueID, int PriceCatalogueCategoryID_2)
        {
            EstimateNew.Import_otherstore_deliveryCost(PriceCatalogueID, PriceCatalogueCategoryID_2);
        }

        public static void Import_MIS_deliveryCost(long PriceCatalogueID, int PriceCatalogueCategoryID_2)
        {
            EstimateNew.Import_MIS_deliveryCost(PriceCatalogueID, PriceCatalogueCategoryID_2);
        }

        internal static void updatePrintSheets(decimal printSheet1, decimal printSheet2, decimal printSheet3, decimal printSheet4, long QuantityID, decimal printSheetPrize1, decimal printSheetPrize2, decimal printSheetPrize3, decimal printSheetPrize4)
        {
            EstimateNew.updatePrintSheets(printSheet1, printSheet2, printSheet3, printSheet4, QuantityID, printSheetPrize1, printSheetPrize2, printSheetPrize3, printSheetPrize4);

        }

        public static DataTable GetEstimateQty(long EstimateItemID)
        {
            return EstimateNew.GetEstimateQty(EstimateItemID);
        }
    }
}
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Linq;
using System.Collections.Generic;

namespace ePrint.settings
{
    public partial class itemDescription_New : BaseClass, IRequiresSessionState
    {
        public string strImagepath = global.strimagepath;

        public string strSitepath = global.sitePath();

        private Global gloobj = new Global();

        public int CompanyID;

        public long ItemDescriptionID;

        public string colorformat = string.Empty;

        public string SaveType = string.Empty;

        public string EstType = string.Empty;

        public string SheetFedDigital = ConnectionClass.SheetFedDigital;

        public string largeformat = ConnectionClass.LargeFormat;

        public string printbroker = ConnectionClass.PrintBroker;

        public string warehouse = ConnectionClass.Warehouse;

        public string othercost = ConnectionClass.OtherCosts;

        public string pricecatalogue = ConnectionClass.PriceCatalogue;

        public string SheetFedOffset = ConnectionClass.SheetFedOffset;

        public string QuickQuote = ConnectionClass.QuickQuote;

        public string DeliveryCost = ConnectionClass.DeliveryCost;

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public itemDescription_New()
        {
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Concat(this.strSitepath, "settings/settings.aspx"));
        }

        protected void btnEstType_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            this.GridBind(linkButton.CommandName.ToString());
            System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", string.Concat("javascript:CangeCssTab('", linkButton.ID, "');"), true);
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            List<ItemDescriptionModel> refreshedItems = new List<ItemDescriptionModel>();
            int displayOrder = 1;
            foreach (GridDataItem item in this.GridItemDescription.MasterTableView.Items)
            {
                HiddenField hiddenField = (HiddenField)item.FindControl("hdnDescriptionID");
                HiddenField hiddenField1 = (HiddenField)item.FindControl("hdnEstimateType");
                HiddenField hiddenField2 = (HiddenField)item.FindControl("hdnFieldName");
                TextBox textBox = (TextBox)item.FindControl("txtScreenName");
                Label label = (Label)item.FindControl(" lblFieldName");
                CheckBox checkBox = (CheckBox)item.FindControl("isChecked");
                this.EstType = hiddenField1.Value;
                refreshedItems.Add(new ItemDescriptionModel
                {
                    ItemDescriptionID = Convert.ToInt32(hiddenField.Value),
                    EstimateType = hiddenField1.Value,
                    DatabaseFieldName = hiddenField2.Value,
                    ScreenName = textBox.Text,
                    IsChecked = checkBox.Checked,
                    DisplayOrder = displayOrder
                });
                SettingsBasePage.settings_itemdescription_insert(this.CompanyID, Convert.ToInt64(hiddenField.Value), hiddenField1.Value.ToString(), hiddenField2.Value.ToString(), base.SpecialEncode(textBox.Text.ToString()), checkBox.Checked, displayOrder);
                displayOrder++;
            }
            Session["GridData"] = refreshedItems;
            this.GridItemDescription.Rebind();
            base.Message_Display(this.objLanguage.GetLanguageConversion("Item_Descriptions_Updated_Successfully"), "msg-success", this.plhMessage);
        }

        public string findEstimateType()
        {
            if (ConnectionClass.SheetFedDigital != null)
            {
                return "S";
            }
            if (ConnectionClass.LargeFormat != null)
            {
                return "L";
            }
            if (ConnectionClass.PrintBroker != null)
            {
                return "O";
            }
            if (ConnectionClass.Warehouse != null)
            {
                return "W";
            }
            if (ConnectionClass.OtherCosts != null)
            {
                return "U";
            }
            if (ConnectionClass.PriceCatalogue != null)
            {
                return "C";
            }
            if (ConnectionClass.SheetFedOffset != null)
            {
                return "F";
            }
            if (ConnectionClass.QuickQuote != null)
            {
                return "Q";
            }
            if (ConnectionClass.DeliveryCost != null)
            {
                return "T";
            }
            return "";
        }

        public void GridBind(string EstimateType)
        {
            this.GridItemDescription.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Field_Name");
            this.GridItemDescription.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Screen_Name");
            DataTable dataTable = SettingsBasePage.settings_itemdescriptionNew_select(this.CompanyID, EstimateType);

            List<ItemDescriptionModel> items = dataTable.AsEnumerable()
            .Select(row => new ItemDescriptionModel
            {
                ItemDescriptionID = row["ItemDescriptionID"] != DBNull.Value ? Convert.ToInt32(row["ItemDescriptionID"]) : 0,
                ScreenName = row["ScreenName"] != DBNull.Value ? row["ScreenName"].ToString() : string.Empty,
                DisplayOrder = row["DisplayOrder"] != DBNull.Value ? Convert.ToInt32(row["DisplayOrder"]) : 0,
                EstimateType = row["EstimateType"] != DBNull.Value ? row["EstimateType"].ToString() : string.Empty,
                IsChecked = row["IsChecked"] != DBNull.Value && Convert.ToBoolean(row["IsChecked"]),
                DatabaseFieldName = row["DatabaseFieldName"] != DBNull.Value ? row["DatabaseFieldName"].ToString() : string.Empty
            }).ToList();

            Session["GridData"] = items;
            this.GridItemDescription.DataSource = dataTable;
            this.GridItemDescription.DataBind();
        }

        protected void OnItemDataBound_GridItemDescription(object sender, GridItemEventArgs e)
        {
            try
            {
                if (((HiddenField)e.Item.FindControl("hdnFieldName")).Value.ToLower() == "itemtitle")
                {
                    CheckBox checkBox = (CheckBox)e.Item.FindControl("isChecked");
                    Image image = (Image)e.Item.FindControl("ImgisChecked");
                    TextBox textBox = (TextBox)e.Item.FindControl("txtScreenName");
                    checkBox.Visible = false;
                    image.Visible = true;
                    textBox.Focus();
                }
            }
            catch
            {
            }
        }

        //protected void grdScreenName_RowDrop(object sender, GridDragDropEventArgs e)
        //{
        //    try
        //    {
        //        if (e.DraggedItems != null && e.DraggedItems.Count > 0)
        //        {
        //            var draggedItem = e.DraggedItems[0] as GridDataItem;

        //            if (e.DestDataItem != null)
        //            {
        //                int draggedId = Convert.ToInt32(draggedItem.GetDataKeyValue("ItemDescriptionID"));
        //                int destId = Convert.ToInt32((e.DestDataItem as GridDataItem).GetDataKeyValue("ItemDescriptionID"));
        //                List<ItemDescriptionModel> items = GetGridData();
        //                var draggedItemData = items.FirstOrDefault(i => i.ItemDescriptionID == draggedId);
        //                var destItemData = items.FirstOrDefault(i => i.ItemDescriptionID == destId);
        //                if (draggedItemData != null && destItemData != null)
        //                {
        //                    int tempOrder = draggedItemData.DisplayOrder;
        //                    draggedItemData.DisplayOrder = destItemData.DisplayOrder;
        //                    destItemData.DisplayOrder = tempOrder;

        //                    items = items.OrderBy(i => i.DisplayOrder).ToList();

        //                    SaveGridData(items);

        //                    GridItemDescription.DataSource = items;
        //                    GridItemDescription.Rebind();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        protected void grdScreenName_RowDrop(object sender, GridDragDropEventArgs e)
        {
            try
            {
                if (e.DraggedItems != null && e.DraggedItems.Count > 0)
                {
                    var draggedItem = e.DraggedItems[0] as GridDataItem;

                    if (e.DestDataItem != null)
                    {
                        int draggedId = Convert.ToInt32(draggedItem.GetDataKeyValue("ItemDescriptionID"));
                        int destId = Convert.ToInt32((e.DestDataItem as GridDataItem).GetDataKeyValue("ItemDescriptionID"));

                        List<ItemDescriptionModel> items = GetGridData();

                        var draggedItemData = items.FirstOrDefault(i => i.ItemDescriptionID == draggedId);
                        var destItemData = items.FirstOrDefault(i => i.ItemDescriptionID == destId);

                        if (draggedItemData != null && destItemData != null)
                        {
                            // Remove dragged item
                            items.Remove(draggedItemData);

                            // Get index of destination item
                            int destIndex = items.IndexOf(destItemData);

                            // Insert dragged item before or after destination item
                            bool dropAbove = e.DropPosition == GridItemDropPosition.Above;
                            if (!dropAbove)
                            {
                                destIndex++; // insert below
                            }

                            items.Insert(destIndex, draggedItemData);

                            // Reassign DisplayOrder
                            int displayOrder = 1;
                            foreach (var item in items)
                            {
                                item.DisplayOrder = displayOrder++;
                            }

                            SaveGridData(items);

                            GridItemDescription.DataSource = items;
                            GridItemDescription.Rebind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Optionally log the error
            }
        }

        private List<ItemDescriptionModel> GetGridData()
        {
            return Session["GridData"] as List<ItemDescriptionModel> ?? new List<ItemDescriptionModel>();
        }

        private void SaveGridData(List<ItemDescriptionModel> items)
        {
            Session["GridData"] = items;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            if (!base.IsPostBack)
            {
                bool isNonPrintingSystem = ConnectionClass.Is_Non_Printing_System;
                if (!ConnectionClass.Is_Non_Printing_System)
                {
                    this.li_Inventory.Attributes.Add("style", "display:block");
                    this.li3.Attributes.Add("style", "display:block");
                    this.li4.Attributes.Add("style", "display:block");
                    this.li11.Attributes.Add("style", "display:block");
                    this.li_StoreSupply.Attributes.Add("style", "display:block");
                    this.li9.Attributes.Add("style", "display:block");
                    this.li8.Attributes.Add("style", "display:block");
                    this.li6.Attributes.Add("style", "display:block");
                    this.li10.Attributes.Add("style", "display:block");
                    this.li12.Attributes.Add("style", "display:block");
                    if (ConnectionClass.SheetFedDigital == null)
                    {
                        this.li_Inventory.Attributes.Add("style", "display:none");
                        this.li3.Attributes.Add("style", "display:none");
                        this.li4.Attributes.Add("style", "display:none");
                        this.li11.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.li_Inventory.Attributes.Add("style", "display:block");
                        this.li3.Attributes.Add("style", "display:block");
                        this.li4.Attributes.Add("style", "display:block");
                        this.li11.Attributes.Add("style", "display:block");
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", string.Concat("javascript:CangeCssTab('", this.lnkEstType_1.ID, "');"), true);
                    }
                    if (ConnectionClass.LargeFormat == null)
                    {
                        this.li_StoreSupply.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.li_StoreSupply.Attributes.Add("style", "display:block");
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", string.Concat("javascript:CangeCssTab('", this.lnkEstType_4.ID, "');"), true);
                    }
                    if (ConnectionClass.PrintBroker == null)
                    {
                        this.li1.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.li1.Attributes.Add("style", "display:block");
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", string.Concat("javascript:CangeCssTab('", this.lnkEstType_6.ID, "');"), true);
                    }
                    if (ConnectionClass.Warehouse == null)
                    {
                        this.li_CustomerItem.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.li_CustomerItem.Attributes.Add("style", "display:block");
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", string.Concat("javascript:CangeCssTab('", this.lnkEstType_5.ID, "');"), true);
                    }
                    if (ConnectionClass.OtherCosts == null)
                    {
                        this.li2.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.li2.Attributes.Add("style", "display:block");
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", string.Concat("javascript:CangeCssTab('", this.lnkEstType_7.ID, "');"), true);
                    }
                    if (ConnectionClass.PriceCatalogue == null)
                    {
                        this.li5.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.li5.Attributes.Add("style", "display:block");
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", string.Concat("javascript:CangeCssTab('", this.lnkEstType_8.ID, "');"), true);
                    }
                    if (ConnectionClass.SheetFedOffset == null)
                    {
                        this.li6.Attributes.Add("style", "display:none");
                        this.li8.Attributes.Add("style", "display:none");
                        this.li9.Attributes.Add("style", "display:none");
                        this.li10.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.li6.Attributes.Add("style", "display:block");
                        this.li8.Attributes.Add("style", "display:block");
                        this.li9.Attributes.Add("style", "display:block");
                        this.li10.Attributes.Add("style", "display:block");
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", string.Concat("javascript:CangeCssTab('", this.lnkEstType_9.ID, "');"), true);
                    }
                    if (ConnectionClass.QuickQuote == null)
                    {
                        this.li7.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.li7.Attributes.Add("style", "display:block");
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", string.Concat("javascript:CangeCssTab('", this.lnkEstType_10.ID, "');"), true);
                    }
                    if (ConnectionClass.DeliveryCost == null)
                    {
                        this.li12.Attributes.Add("style", "display:none");
                    }
                    else
                    {
                        this.li12.Attributes.Add("style", "display:block");
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", string.Concat("javascript:CangeCssTab('", this.lnkEstType_15.ID, "');"), true);
                    }
                    this.EstType = this.findEstimateType();
                }
                else
                {
                    this.li_Inventory.Attributes.Add("style", "display:none");
                    this.li3.Attributes.Add("style", "display:none");
                    this.li4.Attributes.Add("style", "display:none");
                    this.li11.Attributes.Add("style", "display:none");
                    this.li_StoreSupply.Attributes.Add("style", "display:none");
                    this.li9.Attributes.Add("style", "display:none");
                    this.li8.Attributes.Add("style", "display:none");
                    this.li6.Attributes.Add("style", "display:none");
                    this.li10.Attributes.Add("style", "display:none");
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, base.GetType(), "", string.Concat("javascript:CangeCssTab('", this.lnkEstType_5.ID, "');"), true);
                    this.EstType = "W";
                }
                this.GridBind(this.EstType);
            }
            this.btnCancel.Text = this.objLanguage.GetLanguageConversion("Cancel");
            this.btnSave.Text = this.objLanguage.GetLanguageConversion("Save");
            this.btnSave.Attributes.Add("onclick", "javascript:loadingimg('div_btnsave','div_btnsaveprocess');");
            this.btnCancel.Attributes.Add("onclick", "javascript:loadingimg('div_btncancel','div_btncancelprocess');");
            this.gloobj.setpagename("setting");
            string[] languageConversion = new string[] { "<a href=../welcome.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Home_Page_Details"), "</a>&nbsp;>&nbsp;<a href=../settings/settings.aspx class='subnavigator'  style='text-decoration:underline;'>", this.objLanguage.GetLanguageConversion("Settings"), "</a>" };
            base.Navigation_Path(string.Concat(languageConversion), string.Concat("&nbsp;>&nbsp;", this.objLanguage.GetLanguageConversion("Item_Descriptions")));
            base.Title = this.objLanguage.convert(global.pageTitle("Item Descriptions", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
            this.colorformat = this.objpage.GetRegionalSettings(this.CompanyID, "colour");
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Item_Descriptions");
        }
        [Serializable]
        public class ItemDescriptionModel
        {
            public int ItemDescriptionID { get; set; }
            public int DisplayOrder { get; set; }
            public string ScreenName { get; set; }
            public string EstimateType { get; set; }
            public string DatabaseFieldName { get; set; }
            public bool IsChecked { get; set; }
        }

    }

}
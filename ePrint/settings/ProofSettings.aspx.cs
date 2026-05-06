using nmsLanguage;
using Printcenter.UI.Setting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ePrint.settings
{
    public partial class ProofSettings : BaseClass, IRequiresSessionState
    {
        public languageClass objlang = new languageClass();

        private BaseClass objbase = new BaseClass();

        public int CompanyID;

        public int UserID;
        public bool IsItemTitle = false;
        public bool IsDescription = false;
        public bool IsArtwork = false;
        public bool IsColour = false;
        public bool IsSize = false;
        public bool IsMaterial = false;
        public bool IsFinishing = false;
        public bool IsPacking = false;
        public bool IsInstructions = false;
        public bool IsProofs = false;
        public bool IsDelivery = false;
        public bool IsNotes = false;

        public bool isCustomDescription1 = false;
        public bool isCustomDescription2 = false;
        public bool isCustomDescription3 = false;
        public bool isCustomDescription4 = false;
        public bool isCustomDescription5 = false;
        public bool isCustomDescription6 = false;
        public bool isCustomDescription7 = false;
        public bool isCustomDescription8 = false;
        public bool isCustomDescription9 = false;
        public bool isCustomDescription10 = false;
        public bool isCustomDescription11 = false;
        public bool isCustomDescription12 = false;
        public bool isCustomDescription13 = false;
        public bool isCustomDescription14 = false;
        public bool isCustomDescription15 = false;
        public bool isCustomDescription16 = false;
        public bool isCustomDescription17 = false;
        public bool isCustomDescription18 = false;
        public bool isCustomDescription19 = false;
        public bool isCustomDescription20 = false;
        public bool isCustomDescription21 = false;
        public bool isCustomDescription22 = false;
        public bool isCustomDescription23 = false;
        public bool isCustomDescription24 = false;
        public bool isCustomDescription25 = false;

        public void btnSave_Click(object sender, EventArgs e)
        {
            bool _chkDisplyModuleNumber = (!this.chkDisplyModuleNumber.Checked ? false : true);
            bool _chkItemPanelState = (!this.chkItemPanelState.Checked ? false : true);
            bool _chkProofItemDescription = (!this.chkProofItemDescription.Checked ? false : true);
            bool _chkDownloadFileBeforeApprove = (!this.chkDownloadFileBeforeApprove.Checked ? false : true);
            bool _chkMultiApproval = (!this.chkMultiApproval.Checked ? false : true);
            bool _chkChangeProofDescription = (!this.chkChangeProofDescription.Checked ? false : true);
            bool _chkProofCustomerComment = (!this.chkProofCustomerComment.Checked ? false : true);

            List<string> selectedItems = new List<string>();

            foreach (GridDataItem item in RadGrid1.Items)
            {
                CheckBox checkBox = item.FindControl("CheckBox1") as CheckBox;
                if (checkBox.Checked)
                {
                    string column1Value = item["Column1"].Text; // Get the value from the corresponding column
                    selectedItems.Add(column1Value);
                }
            }
            this.IsItemTitle = true;
            if (selectedItems.Contains("Description"))
            {
                this.IsDescription = true;
            }
            if (selectedItems.Contains("Artwork"))
            {
                this.IsArtwork = true;
            }
            if (selectedItems.Contains("Colour"))
            {
                this.IsColour = true;
            }
            if (selectedItems.Contains("Size"))
            {
                this.IsSize = true;
            }
            if (selectedItems.Contains("Material"))
            {
                this.IsMaterial = true;
            }
            if (selectedItems.Contains("Delivery"))
            {
                this.IsDelivery = true;
            }
            if (selectedItems.Contains("Finishing"))
            {
                this.IsFinishing = true;
            }
            if (selectedItems.Contains("Proofs"))
            {
                this.IsProofs = true;
            }
            if (selectedItems.Contains("Packing"))
            {
                this.IsPacking = true;
            }
            if (selectedItems.Contains("Notes"))
            {
                this.IsNotes = true;
            }
            if (selectedItems.Contains("Instructions"))
            {
                this.IsInstructions = true;
            }
            if (selectedItems.Contains("Custom Description 1"))
            {
                this.isCustomDescription1 = true;
            }
            if (selectedItems.Contains("Custom Description 2"))
            {
                this.isCustomDescription2 = true;
            }
            if (selectedItems.Contains("Custom Description 3"))
            {
                this.isCustomDescription3 = true;
            }
            if (selectedItems.Contains("Custom Description 4"))
            {
                this.isCustomDescription4 = true;
            }
            if (selectedItems.Contains("Custom Description 5"))
            {
                this.isCustomDescription5 = true;
            }
            if (selectedItems.Contains("Custom Description 6"))
            {
                this.isCustomDescription6 = true;
            }
            if (selectedItems.Contains("Custom Description 7"))
            {
                this.isCustomDescription7 = true;
            }
            if (selectedItems.Contains("Custom Description 8"))
            {
                this.isCustomDescription8 = true;
            }
            if (selectedItems.Contains("Custom Description 9"))
            {
                this.isCustomDescription9 = true;
            }
            if (selectedItems.Contains("Custom Description 10"))
            {
                this.isCustomDescription10 = true;
            }
            if (selectedItems.Contains("Custom Description 11"))
            {
                this.isCustomDescription11 = true;
            }
            if (selectedItems.Contains("Custom Description 12"))
            {
                this.isCustomDescription12 = true;
            }
            if (selectedItems.Contains("Custom Description 13"))
            {
                this.isCustomDescription13 = true;
            }
            if (selectedItems.Contains("Custom Description 14"))
            {
                this.isCustomDescription14 = true;
            }
            if (selectedItems.Contains("Custom Description 15"))
            {
                this.isCustomDescription15 = true;
            }
            if (selectedItems.Contains("Custom Description 16"))
            {
                this.isCustomDescription16 = true;
            }
            if (selectedItems.Contains("Custom Description 17"))
            {
                this.isCustomDescription17 = true;
            }
            if (selectedItems.Contains("Custom Description 18"))
            {
                this.isCustomDescription18 = true;
            }
            if (selectedItems.Contains("Custom Description 19"))
            {
                this.isCustomDescription19 = true;
            }
            if (selectedItems.Contains("Custom Description 20"))
            {
                this.isCustomDescription20 = true;
            }
            if (selectedItems.Contains("Custom Description 21"))
            {
                this.isCustomDescription21 = true;
            }
            if (selectedItems.Contains("Custom Description 22"))
            {
                this.isCustomDescription22 = true;
            }
            if (selectedItems.Contains("Custom Description 23"))
            {
                this.isCustomDescription23 = true;
            }
            if (selectedItems.Contains("Custom Description 24"))
            {
                this.isCustomDescription24 = true;
            }
            if (selectedItems.Contains("Custom Description 25"))
            {
                this.isCustomDescription25 = true;
            }

            SettingsBasePage.Save_Proof_Settings(this.CompanyID, this.UserID, _chkDisplyModuleNumber, _chkItemPanelState, _chkProofItemDescription,this.IsItemTitle,this.IsDescription,this.IsArtwork,this.IsSize,this.IsColour,this.IsMaterial,this.IsDelivery,this.IsFinishing,this.IsProofs,this.IsPacking,this.IsNotes,this.IsInstructions,this.isCustomDescription1, this.isCustomDescription2, this.isCustomDescription3, this.isCustomDescription4, this.isCustomDescription5, this.isCustomDescription6, this.isCustomDescription7, this.isCustomDescription8, this.isCustomDescription9, this.isCustomDescription10, this.isCustomDescription11, this.isCustomDescription12, this.isCustomDescription13, this.isCustomDescription14, this.isCustomDescription15, this.isCustomDescription16, this.isCustomDescription17, this.isCustomDescription18, this.isCustomDescription19, this.isCustomDescription20, this.isCustomDescription21, this.isCustomDescription22, this.isCustomDescription23, this.isCustomDescription24, this.isCustomDescription25,_chkDownloadFileBeforeApprove,_chkMultiApproval,_chkChangeProofDescription,_chkProofCustomerComment);
            this.objbase.Message_Display(this.objlang.GetLanguageConversion("Proof_setting_saved_Successfully"), "msg-success", this.plhMessage);
            base.Response.Redirect(base.Request.Url.ToString());
        }

        protected void OnItemDataBound_GridItemDescription(object sender, GridItemEventArgs e)
        {
            try
            {
                if (((HiddenField)e.Item.FindControl("hdnFieldName")).Value.ToLower() == "itemtitle")
                {
                    CheckBox checkBox = (CheckBox)e.Item.FindControl("isChecked");
                    Image image = (Image)e.Item.FindControl("ImgisChecked");
                    //TextBox textBox = (TextBox)e.Item.FindControl("txtScreenName");
                    checkBox.Visible = false;
                    image.Visible = true;
                    //textBox.Focus();
                }
            }
            catch
            {
            }
        }
        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                CheckBox checkBox = item.FindControl("CheckBox1") as CheckBox;

                bool checkboxValue = Convert.ToBoolean(DataBinder.Eval(item.DataItem, "CheckboxValue"));

                if (item.ItemIndex == 0)
                {
                    checkBox.Checked = true;
                    checkBox.Enabled = false;
                }
                else
                {
                    checkBox.Checked = checkboxValue;
                }
            }
        }
        //protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        //{
        //    if (e.Item is GridHeaderItem)
        //    {
        //        GridHeaderItem headerItem = (GridHeaderItem)e.Item;
        //        TableCell cell = new TableCell();

        //        // Add checkbox
        //        CheckBox headerCheckBox = new CheckBox();
        //        headerCheckBox.ID = "HeaderCheckBox";
        //        headerCheckBox.Attributes.Add("onclick", "HeaderCheckboxClicked(this)");
        //        cell.Controls.Add(headerCheckBox);
        //        headerItem.Cells.Add(cell);
        //    }
        //}
        public void GridBind(string EstimateType)
        {
            DataTable dt = new DataTable();
            DataTable ProofSetting = SettingsBasePage.Select_Proof_Settings(this.CompanyID, this.UserID);

            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Column1"), new DataColumn("CheckboxValue", typeof(bool)) });
            foreach (DataRow dr in ProofSetting.Rows)
            {
                dt.Rows.Add(dr["ItemTitleLabel"].ToString(), Convert.ToBoolean(dr["IsItemTitle"].ToString()));
                dt.Rows.Add(dr["DescriptionLabel"].ToString(), Convert.ToBoolean(dr["IsDescription"].ToString()));
                dt.Rows.Add(dr["ArtworkLabel"].ToString(), Convert.ToBoolean(dr["IsArtwork"].ToString()));
                dt.Rows.Add(dr["ColourLabel"].ToString(), Convert.ToBoolean(dr["IsColour"].ToString()));
                dt.Rows.Add(dr["SizeLabel"].ToString(), Convert.ToBoolean(dr["IsSize"].ToString()));
                dt.Rows.Add(dr["MaterialLabel"].ToString(), Convert.ToBoolean(dr["IsMaterial"].ToString()));
                dt.Rows.Add(dr["DeliveryLabel"].ToString(), Convert.ToBoolean(dr["IsDelivery"].ToString()));
                dt.Rows.Add(dr["FinishingLabel"].ToString(), Convert.ToBoolean(dr["IsFinishing"].ToString()));
                dt.Rows.Add(dr["ProofsLabel"].ToString(), Convert.ToBoolean(dr["IsProofs"].ToString()));
                dt.Rows.Add(dr["PackingLabel"].ToString(), Convert.ToBoolean(dr["IsPacking"].ToString()));
                dt.Rows.Add(dr["NotesLabel"].ToString(), Convert.ToBoolean(dr["IsNotes"].ToString()));
                dt.Rows.Add(dr["InstructionsLabel"].ToString(), Convert.ToBoolean(dr["IsInstructions"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel1"].ToString(), Convert.ToBoolean(dr["isCustomDescription1"].ToString()));

                dt.Rows.Add(dr["CustomDescriptionLabel2"].ToString(), Convert.ToBoolean(dr["isCustomDescription2"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel3"].ToString(), Convert.ToBoolean(dr["isCustomDescription3"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel4"].ToString(), Convert.ToBoolean(dr["isCustomDescription4"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel5"].ToString(), Convert.ToBoolean(dr["isCustomDescription5"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel6"].ToString(), Convert.ToBoolean(dr["isCustomDescription6"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel7"].ToString(), Convert.ToBoolean(dr["isCustomDescription7"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel8"].ToString(), Convert.ToBoolean(dr["isCustomDescription8"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel9"].ToString(), Convert.ToBoolean(dr["isCustomDescription9"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel10"].ToString(), Convert.ToBoolean(dr["isCustomDescription10"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel11"].ToString(), Convert.ToBoolean(dr["isCustomDescription11"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel12"].ToString(), Convert.ToBoolean(dr["isCustomDescription12"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel13"].ToString(), Convert.ToBoolean(dr["isCustomDescription13"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel14"].ToString(), Convert.ToBoolean(dr["isCustomDescription14"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel15"].ToString(), Convert.ToBoolean(dr["isCustomDescription15"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel16"].ToString(), Convert.ToBoolean(dr["isCustomDescription16"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel17"].ToString(), Convert.ToBoolean(dr["isCustomDescription17"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel18"].ToString(), Convert.ToBoolean(dr["isCustomDescription18"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel19"].ToString(), Convert.ToBoolean(dr["isCustomDescription19"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel20"].ToString(), Convert.ToBoolean(dr["isCustomDescription20"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel21"].ToString(), Convert.ToBoolean(dr["isCustomDescription21"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel22"].ToString(), Convert.ToBoolean(dr["isCustomDescription22"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel23"].ToString(), Convert.ToBoolean(dr["isCustomDescription23"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel24"].ToString(), Convert.ToBoolean(dr["isCustomDescription24"].ToString()));
                dt.Rows.Add(dr["CustomDescriptionLabel25"].ToString(), Convert.ToBoolean(dr["isCustomDescription25"].ToString()));


            }


            // Bind the DataTable to the RadGrid
            RadGrid1.DataSource = dt;
            RadGrid1.DataBind();
            //this.GridItemDescription.Columns[0].HeaderText = this.objLanguage.GetLanguageConversion("Field_Name");
            ////this.GridItemDescription.Columns[2].HeaderText = this.objLanguage.GetLanguageConversion("Screen_Name");
            //DataTable dataTable = SettingsBasePage.settings_itemdescriptionNew_select(this.CompanyID, EstimateType);
            //this.GridItemDescription.DataSource = dataTable;
            ////DataTable dataTable = SettingsBasePage.settings_proofdescription_select(this.CompanyID);
            ////DataTable dataTable1 = new DataTable();
            //this.GridItemDescription.DataSource = dataTable;
            //this.GridItemDescription.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.header_mis.SettingName = this.objLanguage.GetLanguageConversion("Proofing");
            this.CompanyID = Convert.ToInt32(this.Session["CompanyID"].ToString());
            this.UserID = Convert.ToInt32(this.Session["UserID"]);
            base.Title = this.objlang.GetLanguageConversion("Proofing");
            base.Session["pagename"] = "setting";
            this.lblModuleNumber.Text = this.objLanguage.GetLanguageConversion("Label_Module_Number");
            this.lblItemPanelState.Text = this.objLanguage.GetLanguageConversion("Label_Item_Panel_State");
            this.lblProofItemDescription.Text = this.objLanguage.GetLanguageConversion("Label_Update_description_fields");
            this.Label1.Text = this.objLanguage.GetLanguageConversion("select_the_description_fields_to_be_selected_by_default_in_the_proofing_module.");
            this.lblDownloadFileBeforeApprove.Text = this.objLanguage.GetLanguageConversion("user_must_download_the_proof_file_before_approving_it");
            this.lblMultiApproval.Text = this.objLanguage.GetLanguageConversion("user_muliti_approval");
            this.lblChangeProofDescription.Text = this.objLanguage.GetLanguageConversion("change_proof_description_settings");
            this.lblProofCustomerComment.Text = this.objLanguage.GetLanguageConversion("Label_Customer_Comment");

            if (!base.IsPostBack)
            {
                SettingsBasePage.InsertProofSettingIfNotExist(this.CompanyID, this.UserID);
                this.GridBind("S");
                DataTable ProofSetting = SettingsBasePage.Select_Proof_Settings(this.CompanyID, this.UserID);
                foreach (DataRow dr in ProofSetting.Rows)
                {
                    if (dr["IsDisplayModuleNumber"].ToString() == "True")
                    {
                        this.chkDisplyModuleNumber.Checked = true;
                    }
                    else
                    {
                        this.chkDisplyModuleNumber.Checked = false;
                    }
                    if (dr["ItemPanelStatus"].ToString() == "True")
                    {
                        this.chkItemPanelState.Checked = true;
                    }
                    else
                    {
                        this.chkItemPanelState.Checked = false;
                    }

                    if (dr["ProofDescriptionStatus"].ToString() == "True")
                    {
                        this.chkProofItemDescription.Checked = true;
                    }
                    else
                    {
                        this.chkProofItemDescription.Checked = false;
                    }

                    if (dr["ProofDescriptionStatus"].ToString() == "True")
                    {
                        this.chkProofItemDescription.Checked = true;
                    }
                    else
                    {
                        this.chkProofItemDescription.Checked = false;
                    }

                    if (dr["IsDownloadFileBeforeApprove"].ToString() == "True")
                    {
                        this.chkDownloadFileBeforeApprove.Checked = true;
                    }
                    else
                    {
                        this.chkDownloadFileBeforeApprove.Checked = false;
                    }

                    if (dr["IsMultiApprovals"].ToString() == "True")
                    {
                        this.chkMultiApproval.Checked = true;
                    }
                    else
                    {
                        this.chkMultiApproval.Checked = false;
                    }
                    if (dr["IsChangeProofDescriptions"].ToString() == "True")
                    {
                        this.chkChangeProofDescription.Checked = true;
                    }
                    else
                    {
                        this.chkChangeProofDescription.Checked = false;
                    }
                    if (dr["chkProofCustomerComment"].ToString() == "True")
                    {
                        this.chkProofCustomerComment.Checked = true;
                    }
                    else
                    {
                        this.chkProofCustomerComment.Checked = false;
                    }
                }
            }

        }
    }
}
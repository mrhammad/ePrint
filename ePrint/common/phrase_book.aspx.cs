using ePrint.usercontrol;
using nmsCommon;
using nmsConnectionClass;
using nmsLanguage;
using Printcenter.UI.Setting;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.common
{
    public partial class phrase_book : BaseClass, IRequiresSessionState
    {
        public string strSitepath = global.sitePath();

        public string strImagepath = global.imagePath();

        public languageClass objLangClass = new languageClass();

        private Global gloobj = new Global();

        public string type = string.Empty;

        public int totalrec;

        public string colorformat = string.Empty;

        public int PageSize = 25;

        public string PhraseItemTo = string.Empty;

        public string VersionNumber = ConnectionClass.VersionNumber;

        public BaseClass objBase = new BaseClass();

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

        public phrase_book()
        {
        }

        protected void GridHeaderFoooter_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label)e.Row.FindControl("lblPhraseBookID");
                Label label1 = (Label)e.Row.FindControl("lblFull");
                label1.Text = label1.Text.Replace("&", "&");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.QueryString.ToString().ToLower().Contains("pg"))
            {
                string str = base.Request.QueryString["pg"].ToString();
                this.gloobj.setpagename(str);
            }
            if (base.Request.QueryString["phraseto"] != null)
            {
                this.PhraseItemTo = base.Request.QueryString["phraseto"].ToString();
            }
            this.type = base.Request.Params["type"].ToString();
            this.colorformat = this.objpage.GetRegionalSettings(Convert.ToInt32(this.Session["CompanyID"].ToString()), "colour");
            string str1 = base.Request.Params["type"].ToLower().ToString();
            string str2 = str1;
            if (str1 != null)
            {
                switch (str2)
                {
                    case "estimate header":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion.Text = this.objLanguage.GetLanguageConversion("Header");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle(this.objLangClass.GetLanguageConversion("Header_Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            divAddNew.Visible = true;
                            break;
                        }
                    case "estimate footer":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label.Text = this.objLanguage.GetLanguageConversion("Footer");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle(this.objLangClass.GetLanguageConversion("Footer_Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            divAddNew.Visible = true;
                            break;
                        }
                    case "estimate title":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion1 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion1.Text = this.objLanguage.GetLanguageConversion("Title");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Title Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate description":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label1 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label1.Text = this.objLanguage.GetLanguageConversion("Description");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate artwork":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion2 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion2.Text = this.objLanguage.GetLanguageConversion("Artwork");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Artwork Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate colours":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label2 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label2.Text = this.colorformat;
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle(string.Concat(this.colorformat, " Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate size":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion3 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion3.Text = this.objLanguage.GetLanguageConversion("Size");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Size Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate material":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label3 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label3.Text = this.objLanguage.GetLanguageConversion("Material");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Material Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate delivery":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion4 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion4.Text = this.objLanguage.GetLanguageConversion("Delivery");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Delivery Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate finishing":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label4 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label4.Text = this.objLanguage.GetLanguageConversion("Finishing");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Finishing Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate notes":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion5 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion5.Text = this.objLanguage.GetLanguageConversion("Notes");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Notes Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate terms":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label5 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label5.Text = this.objLanguage.GetLanguageConversion("Terms_Instructions");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Terms/Instructions Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate proofs":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion6 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion6.Text = this.objLanguage.GetLanguageConversion("Proofs");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Proofs Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate packing":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label6 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label6.Text = this.objLanguage.GetLanguageConversion("Packing");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Packing Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "job header":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label7 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label7.Text = "Header";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle(this.objLangClass.GetLanguageConversion("Header_Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            divAddNew.Visible = true;
                            break;
                        }
                    case "job footer":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label8 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label8.Text = "Footer";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle(this.objLangClass.GetLanguageConversion("Footer_Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            divAddNew.Visible = true;
                            break;
                        }
                    case "invoice header":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label9 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label9.Text = "Header";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle(this.objLangClass.GetLanguageConversion("Header_Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            divAddNew.Visible = true;
                            break;
                        }
                    case "invoice footer":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label10 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label10.Text = "Footer";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle(this.objLangClass.GetLanguageConversion("Footer_Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            divAddNew.Visible = true;
                            break;
                        }
                    case "purchase header":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label11 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label11.Text = "Header";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle(this.objLangClass.GetLanguageConversion("Header_Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "purchase footer":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label12 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label12.Text = "Footer";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle(this.objLangClass.GetLanguageConversion("Footer_Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "delivery note header":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label13 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label13.Text = "Header";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle(this.objLangClass.GetLanguageConversion("Header_Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "delivery note footer":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label14 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label14.Text = "Footer";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle(this.objLangClass.GetLanguageConversion("Footer_Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "delivery instructions":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion7 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion7.Text = this.objLangClass.GetLanguageConversion("Instructions");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Delivery Instructions Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker title":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label15 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label15.Text = "Title";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Title Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker description":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label16 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label16.Text = "Description";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker artwork":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label17 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label17.Text = "Artwork";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Artwork Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker colours":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label18 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label18.Text = this.colorformat;
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle(string.Concat(this.colorformat, " Selector"), int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker size":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label19 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label19.Text = "Size";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Size Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker material":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label20 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label20.Text = "Material";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Material Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker delivery":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label21 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label21.Text = "Delivery";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Delivery Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker finishing":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label22 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label22.Text = "Finishing";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Finishing Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker notes":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion8 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion8.Text = this.objLanguage.GetLanguageConversion("Notes");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Notes Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker terms":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion9 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion9.Text = this.objLanguage.GetLanguageConversion("Terms_Instructions");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Terms/Instructions Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker header":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label23 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label23.Text = "Outwork Header";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("PrintBroker Header Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker footer":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion10 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion10.Text = this.objLanguage.GetLanguageConversion("Outwork_Footer");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("PrintBroker Footer Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker proofs":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label24 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label24.Text = "Outwork Proofs";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Proofs Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker packing":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label25 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label25.Text = "Outwork Packing";
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Proofs Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription1":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion11 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion11.Text = this.objLanguage.GetLanguageConversion("Custom_Description1");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription2":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion12 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion12.Text = this.objLanguage.GetLanguageConversion("Custom_Description2");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription3":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion13 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion13.Text = this.objLanguage.GetLanguageConversion("Custom_Description3");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription4":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion14 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion14.Text = this.objLanguage.GetLanguageConversion("Custom_Description4");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription5":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion15 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion15.Text = this.objLanguage.GetLanguageConversion("Custom_Description5");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription6":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion16 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion16.Text = this.objLanguage.GetLanguageConversion("Custom_Description6");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription7":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion17 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion17.Text = this.objLanguage.GetLanguageConversion("Custom_Description7");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription8":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion18 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion18.Text = this.objLanguage.GetLanguageConversion("Custom_Description8");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription9":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion19 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion19.Text = this.objLanguage.GetLanguageConversion("Custom_Description9");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription10":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion20 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion20.Text = this.objLanguage.GetLanguageConversion("Custom_Description10");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription11":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion21 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion21.Text = this.objLanguage.GetLanguageConversion("Custom_Description11");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription12":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion22 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion22.Text = this.objLanguage.GetLanguageConversion("Custom_Description12");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription13":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion23 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion23.Text = this.objLanguage.GetLanguageConversion("Custom_Description13");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription14":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion24 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion24.Text = this.objLanguage.GetLanguageConversion("Custom_Description14");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription15":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion25 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion25.Text = this.objLanguage.GetLanguageConversion("Custom_Description15");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription16":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion26 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion26.Text = this.objLanguage.GetLanguageConversion("Custom_Description16");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription17":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label26 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label26.Text = this.objLanguage.GetLanguageConversion("Custom_Description17");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription18":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion27 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion27.Text = this.objLanguage.GetLanguageConversion("Custom_Description18");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription19":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label27 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label27.Text = this.objLanguage.GetLanguageConversion("Custom_Description19");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription20":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion28 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion28.Text = this.objLanguage.GetLanguageConversion("Custom_Description20");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription21":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label28 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label28.Text = this.objLanguage.GetLanguageConversion("Custom_Description21");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription22":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion29 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion29.Text = this.objLanguage.GetLanguageConversion("Custom_Description22");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription23":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label29 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label29.Text = this.objLanguage.GetLanguageConversion("Custom_Description23");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription24":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion30 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion30.Text = this.objLanguage.GetLanguageConversion("Custom_Description24");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "printbroker customdescription25":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label30 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label30.Text = this.objLanguage.GetLanguageConversion("Custom_Description25");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription1":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion31 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion31.Text = this.objLanguage.GetLanguageConversion("Custom_Description1");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription2":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label31 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label31.Text = this.objLanguage.GetLanguageConversion("Custom_Description2");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription3":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion32 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion32.Text = this.objLanguage.GetLanguageConversion("Custom_Description3");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription4":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label32 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label32.Text = this.objLanguage.GetLanguageConversion("Custom_Description4");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription5":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion33 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion33.Text = this.objLanguage.GetLanguageConversion("Custom_Description5");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription6":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label33 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label33.Text = this.objLanguage.GetLanguageConversion("Custom_Description6");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription7":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion34 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion34.Text = this.objLanguage.GetLanguageConversion("Custom_Description7");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription8":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label34 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label34.Text = this.objLanguage.GetLanguageConversion("Custom_Description8");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription9":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion35 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion35.Text = this.objLanguage.GetLanguageConversion("Custom_Description9");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription10":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label35 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label35.Text = this.objLanguage.GetLanguageConversion("Custom_Description10");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription11":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion36 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion36.Text = this.objLanguage.GetLanguageConversion("Custom_Description11");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription12":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label36 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label36.Text = this.objLanguage.GetLanguageConversion("Custom_Description12");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription13":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion37 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion37.Text = this.objLanguage.GetLanguageConversion("Custom_Description13");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription14":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label37 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label37.Text = this.objLanguage.GetLanguageConversion("Custom_Description14");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription15":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion38 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion38.Text = this.objLanguage.GetLanguageConversion("Custom_Description15");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription16":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label38 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label38.Text = this.objLanguage.GetLanguageConversion("Custom_Description16");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription17":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion39 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion39.Text = this.objLanguage.GetLanguageConversion("Custom_Description17");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription18":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label39 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label39.Text = this.objLanguage.GetLanguageConversion("Custom_Description18");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription19":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion40 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion40.Text = this.objLanguage.GetLanguageConversion("Custom_Description19");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription20":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label40 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label40.Text = this.objLanguage.GetLanguageConversion("Custom_Description20");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription21":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion41 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion41.Text = this.objLanguage.GetLanguageConversion("Custom_Description21");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription22":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label41 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label41.Text = this.objLanguage.GetLanguageConversion("Custom_Description22");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription23":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion42 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion42.Text = this.objLanguage.GetLanguageConversion("Custom_Description23");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription24":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label label42 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                label42.Text = this.objLanguage.GetLanguageConversion("Custom_Description24");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                    case "estimate customdescription25":
                        {
                            if (this.GridHeaderFoooter.Rows.Count > 0)
                            {
                                Label languageConversion43 = (Label)this.GridHeaderFoooter.HeaderRow.FindControl("lblgrdHeader");
                                languageConversion43.Text = this.objLanguage.GetLanguageConversion("Custom_Description25");
                            }
                            base.Title = this.objLanguage.convert(global.pageTitle("Custom Description Selector", int.Parse(this.Session["companyid"].ToString()), this.Session["companyName"].ToString()));
                            break;
                        }
                }
            }
            if (this.GridHeaderFoooter.Rows.Count != 0)
            {
                this.usrPaging.Visible = true;
                DataTable table = ((DataView)this.odsHeaderFooter.Select()).Table;
                this.totalrec = table.Rows.Count;
                Paging.intCurrentPage = this.GridHeaderFoooter.PageIndex + 1;
                Paging.intPageCount = this.GridHeaderFoooter.PageCount;
            }
            else
            {
                this.usrPaging.Visible = false;
                this.totalrec = 0;
            }
            this.lblTotalRecords.Text = this.totalrec.ToString();
            this.usrPaging.CreatePaging();
            this.usrPaging.OnPageChange += new PagingEventHandler(this.paging_OnPageChange);
        }

        private void paging_OnPageChange(int PageNumber)
        {
            if (PageNumber <= 0)
            {
                this.GridHeaderFoooter.PageIndex = PageNumber;
            }
            else
            {
                this.GridHeaderFoooter.PageIndex = PageNumber - 1;
            }
            this.GridHeaderFoooter.DataBind();
            Paging.intCurrentPage = this.GridHeaderFoooter.PageIndex + 1;
            Paging.intPageCount = this.GridHeaderFoooter.PageCount;
            this.usrPaging.CreatePaging();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string str1 = base.Request.Params["type"].ToString();

            string str22 = "";

            if (str1.ToLower().Contains("estimate"))
            {
                str22 = "estimate";
            }
            else if (str1.ToLower().Contains("job"))
            {
                str22 = "job";
            }
            else if (str1.ToLower().Contains("invoice"))
            {
                str22 = "invoice";
            }

            bool isDefault = false;
            if (this.chkedit.Checked == true)
            {
                isDefault = true;
            }
            else
            {
                isDefault = false;
            }

            SettingsBasePage.settings_phrasebook_insert(Convert.ToInt32(base.Session["CompanyID"]), str1, this.txtPhraseText.Text, isDefault, "estimate", "estimate");

            this.txtPhraseText.Text = "";
            this.GridHeaderFoooter.DataBind();

        }
    }
}
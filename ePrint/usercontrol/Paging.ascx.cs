using nmsLanguage;
using System;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint.usercontrol
{
    public partial class Paging : System.Web.UI.UserControl
    {

        public static int intCurrentPage;

        public static int intPageCount;

        public languageClass objLangClass = new languageClass();

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        public DropDownList DDPageSize
        {
            get
            {
                return this.ddlPageSize;
            }
            set
            {
                this.ddlPageSize = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        static Paging()
        {
            Paging.intCurrentPage = -1;
            Paging.intPageCount = -1;
        }

        public Paging()
        {
        }

        private void AssignPageNumberAndCount()
        {
            if (Paging.intCurrentPage != -1)
            {
                base.Session["CurrentPage"] = Paging.intCurrentPage.ToString();
            }
            if (Paging.intPageCount != -1)
            {
                base.Session["PageCount"] = Paging.intPageCount.ToString();
            }
            if (base.Session["CurrentPage"] != null)
            {
                Paging.intCurrentPage = Convert.ToInt32(base.Session["CurrentPage"]);
            }
            if (base.Session["PageCount"] != null)
            {
                Paging.intPageCount = Convert.ToInt32(base.Session["PageCount"]);
            }
        }

        private void BindPageNumber()
        {
            this.ddlPageNo.Items.Clear();
            for (int i = 0; i < Paging.intPageCount; i++)
            {
                this.ddlPageNo.Items.Insert(i, "");
                this.ddlPageNo.Items[i].Value = Convert.ToString(i + 1);
                this.ddlPageNo.Items[i].Text = Convert.ToString(i + 1);
            }
            this.SetDDLValue(this.ddlPageNo, Paging.intCurrentPage.ToString().Trim());
        }

        protected void btn_Command(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            this.ChangeDisplayOfPaging(linkButton.Text.ToString().Trim().ToLower());
        }

        public void ChangeDisplayOfPaging(string currentlySelected)
        {
            this.BindPageNumber();
            int num = Paging.intCurrentPage;
            string empty = string.Empty;
            string str = currentlySelected;
            string str1 = str;
            if (str == null)
            {
                goto Label0;
            }
            else if (str1 == "[<")
            {
                empty = "1";
            }
            else if (str1 == "<")
            {
                empty = Convert.ToString(num - 1);
            }
            else if (str1 == ">")
            {
                empty = Convert.ToString(num + 1);
            }
            else
            {
                if (str1 != ">]")
                {
                    goto Label0;
                }
                empty = Paging.intPageCount.ToString();
            }
        Label2:
            Paging.intCurrentPage = Convert.ToInt32(empty);
            if (empty == "1")
            {
                this.lnkStart.CssClass = "Paging_disable";
                this.lnkPrev.CssClass = "Paging_disable";
                this.lnkNext.CssClass = "Paging_enable";
                this.lnkEnd.CssClass = "Paging_enable";
                this.lnkStart.Enabled = false;
                this.lnkPrev.Enabled = false;
                this.lnkNext.Enabled = true;
                this.lnkEnd.Enabled = true;
            }
            else if (empty != Paging.intPageCount.ToString())
            {
                this.lnkStart.CssClass = "Paging_enable";
                this.lnkPrev.CssClass = "Paging_enable";
                this.lnkNext.CssClass = "Paging_enable";
                this.lnkEnd.CssClass = "Paging_enable";
                this.lnkStart.Enabled = true;
                this.lnkPrev.Enabled = true;
                this.lnkNext.Enabled = true;
                this.lnkEnd.Enabled = true;
            }
            else
            {
                this.lnkStart.CssClass = "Paging_enable";
                this.lnkPrev.CssClass = "Paging_enable";
                this.lnkNext.CssClass = "Paging_disable";
                this.lnkEnd.CssClass = "Paging_disable";
                this.lnkStart.Enabled = true;
                this.lnkPrev.Enabled = true;
                this.lnkNext.Enabled = false;
                this.lnkEnd.Enabled = false;
            }
            this.ChangePageNumber(Convert.ToInt32(empty));
            this.lblPageNumber.Text = empty;
            this.lblTotalPage.Text = Paging.intPageCount.ToString();
            this.SetDDLValue(this.ddlPageNo, empty.ToString().Trim().ToLower());
            if (empty == this.lnkFirst.Text)
            {
                this.lnkFirst.Attributes.Add("style", "color:red");
                this.lnkSecond.Attributes.Add("style", "color:blue");
                this.lnkThird.Attributes.Add("style", "color:blue");
                this.lnkFour.Attributes.Add("style", "color:blue");
                this.lnkFive.Attributes.Add("style", "color:blue");
                this.lnkFirst.Enabled = false;
                this.lnkSecond.Enabled = true;
                this.lnkThird.Enabled = true;
                this.lnkFour.Enabled = true;
                this.lnkFive.Enabled = true;
                return;
            }
            if (empty == this.lnkSecond.Text)
            {
                this.lnkFirst.Attributes.Add("style", "color:blue");
                this.lnkSecond.Attributes.Add("style", "color:red");
                this.lnkThird.Attributes.Add("style", "color:blue");
                this.lnkFour.Attributes.Add("style", "color:blue");
                this.lnkFive.Attributes.Add("style", "color:blue");
                this.lnkFirst.Enabled = true;
                this.lnkSecond.Enabled = false;
                this.lnkThird.Enabled = true;
                this.lnkFour.Enabled = true;
                this.lnkFive.Enabled = true;
                return;
            }
            if (empty == this.lnkThird.Text)
            {
                this.lnkFirst.Attributes.Add("style", "color:blue");
                this.lnkSecond.Attributes.Add("style", "color:blue");
                this.lnkThird.Attributes.Add("style", "color:red");
                this.lnkFour.Attributes.Add("style", "color:blue");
                this.lnkFive.Attributes.Add("style", "color:blue");
                this.lnkFirst.Enabled = true;
                this.lnkSecond.Enabled = true;
                this.lnkThird.Enabled = false;
                this.lnkFour.Enabled = true;
                this.lnkFive.Enabled = true;
                return;
            }
            if (empty == this.lnkFour.Text)
            {
                this.lnkFirst.Attributes.Add("style", "color:blue");
                this.lnkSecond.Attributes.Add("style", "color:blue");
                this.lnkThird.Attributes.Add("style", "color:blue");
                this.lnkFour.Attributes.Add("style", "color:red");
                this.lnkFive.Attributes.Add("style", "color:blue");
                this.lnkFirst.Enabled = true;
                this.lnkSecond.Enabled = true;
                this.lnkThird.Enabled = true;
                this.lnkFour.Enabled = false;
                this.lnkFive.Enabled = true;
                return;
            }
            if (empty == this.lnkFive.Text)
            {
                this.lnkFirst.Attributes.Add("style", "color:blue");
                this.lnkSecond.Attributes.Add("style", "color:blue");
                this.lnkThird.Attributes.Add("style", "color:blue");
                this.lnkFour.Attributes.Add("style", "color:blue");
                this.lnkFive.Attributes.Add("style", "color:red");
                this.lnkFirst.Enabled = true;
                this.lnkSecond.Enabled = true;
                this.lnkThird.Enabled = true;
                this.lnkFour.Enabled = true;
                this.lnkFive.Enabled = false;
            }
            return;
        Label0:
            empty = currentlySelected;
            goto Label2;
        }

        private void ChangePageNumber(int PageNumber)
        {
            if (this.OnPageChange != null)
            {
                this.OnPageChange(PageNumber);
            }
        }

        public void CreatePaging()
        {
            this.BindPageNumber();
            int num = Paging.intPageCount;
            this.PagingOff();
            int num1 = Paging.intCurrentPage;
            switch (num)
            {
                case 0:
                    {
                        if (num1 > 3 && num1 + 2 < num)
                        {
                            this.lnkFirst.Text = Convert.ToString(num1 - 2);
                            this.lnkFirst.CommandArgument = Convert.ToString(num1 - 2);
                            this.lnkSecond.Text = Convert.ToString(num1 - 1);
                            this.lnkSecond.CommandArgument = Convert.ToString(num1 - 1);
                            this.lnkThird.Text = Convert.ToString(num1);
                            this.lnkThird.CommandArgument = Convert.ToString(num1);
                            this.lnkFour.Text = Convert.ToString(num1 + 1);
                            this.lnkFour.CommandArgument = Convert.ToString(num1 + 1);
                            this.lnkFive.Text = Convert.ToString(num1 + 2);
                            this.lnkFive.CommandArgument = Convert.ToString(num1 + 2);
                        }
                        else if (num1 <= 3)
                        {
                            this.lnkFirst.Text = "1";
                            this.lnkSecond.Text = "2";
                            this.lnkThird.Text = "3";
                            this.lnkFour.Text = "4";
                            this.lnkFive.Text = "5";
                        }
                        else if (num1 != 4 || num != 4)
                        {
                            this.lnkFirst.Text = Convert.ToString(num - 4);
                            this.lnkSecond.Text = Convert.ToString(num - 3);
                            this.lnkThird.Text = Convert.ToString(num - 2);
                            this.lnkFour.Text = Convert.ToString(num - 1);
                            this.lnkFive.Text = Convert.ToString(num);
                        }
                        else
                        {
                            this.lnkFirst.Text = "1";
                            this.lnkSecond.Text = "2";
                            this.lnkThird.Text = "3";
                            this.lnkFour.Text = "4";
                            this.lnkFive.Text = "5";
                        }
                        this.lblPageNumber.Text = Paging.intCurrentPage.ToString();
                        this.lblTotalPage.Text = Paging.intPageCount.ToString();
                        if (num1 == Convert.ToInt32(this.lnkFirst.Text))
                        {
                            this.lnkFirst.Attributes.Add("style", "color:red");
                            this.lnkSecond.Attributes.Add("style", "color:blue");
                            this.lnkThird.Attributes.Add("style", "color:blue");
                            this.lnkFour.Attributes.Add("style", "color:blue");
                            this.lnkFive.Attributes.Add("style", "color:blue");
                            this.lnkFirst.Enabled = false;
                            this.lnkSecond.Enabled = true;
                            this.lnkThird.Enabled = true;
                            this.lnkFour.Enabled = true;
                            this.lnkFive.Enabled = true;
                        }
                        else if (num1 == Convert.ToInt32(this.lnkSecond.Text))
                        {
                            this.lnkFirst.Attributes.Add("style", "color:blue");
                            this.lnkSecond.Attributes.Add("style", "color:red");
                            this.lnkThird.Attributes.Add("style", "color:blue");
                            this.lnkFour.Attributes.Add("style", "color:blue");
                            this.lnkFive.Attributes.Add("style", "color:blue");
                            this.lnkFirst.Enabled = true;
                            this.lnkSecond.Enabled = false;
                            this.lnkThird.Enabled = true;
                            this.lnkFour.Enabled = true;
                            this.lnkFive.Enabled = true;
                        }
                        else if (num1 == Convert.ToInt32(this.lnkThird.Text))
                        {
                            this.lnkFirst.Attributes.Add("style", "color:blue");
                            this.lnkSecond.Attributes.Add("style", "color:blue");
                            this.lnkThird.Attributes.Add("style", "color:red");
                            this.lnkFour.Attributes.Add("style", "color:blue");
                            this.lnkFive.Attributes.Add("style", "color:blue");
                            this.lnkFirst.Enabled = true;
                            this.lnkSecond.Enabled = true;
                            this.lnkThird.Enabled = false;
                            this.lnkFour.Enabled = true;
                            this.lnkFive.Enabled = true;
                        }
                        else if (num1 == Convert.ToInt32(this.lnkFour.Text))
                        {
                            this.lnkFirst.Attributes.Add("style", "color:blue");
                            this.lnkSecond.Attributes.Add("style", "color:blue");
                            this.lnkThird.Attributes.Add("style", "color:blue");
                            this.lnkFour.Attributes.Add("style", "color:red");
                            this.lnkFive.Attributes.Add("style", "color:blue");
                            this.lnkFirst.Enabled = true;
                            this.lnkSecond.Enabled = true;
                            this.lnkThird.Enabled = true;
                            this.lnkFour.Enabled = false;
                            this.lnkFive.Enabled = true;
                        }
                        else if (num1 == Convert.ToInt32(this.lnkFive.Text))
                        {
                            this.lnkFirst.Attributes.Add("style", "color:blue");
                            this.lnkSecond.Attributes.Add("style", "color:blue");
                            this.lnkThird.Attributes.Add("style", "color:blue");
                            this.lnkFour.Attributes.Add("style", "color:blue");
                            this.lnkFive.Attributes.Add("style", "color:red");
                            this.lnkFirst.Enabled = true;
                            this.lnkSecond.Enabled = true;
                            this.lnkThird.Enabled = true;
                            this.lnkFour.Enabled = true;
                            this.lnkFive.Enabled = false;
                        }
                        this.AssignPageNumberAndCount();
                        return;
                    }
                case 1:
                    {
                        this.lnkFirst.Visible = true;
                        this.lnkSecond.Visible = false;
                        this.lnkThird.Visible = false;
                        this.lnkFour.Visible = false;
                        this.lnkFive.Visible = false;
                        goto Label0;
                    }
                case 2:
                    {
                        this.lnkFirst.Visible = true;
                        this.lnkSecond.Visible = true;
                        this.lnkThird.Visible = false;
                        this.lnkFour.Visible = false;
                        this.lnkFive.Visible = false;
                        goto Label0;
                    }
                case 3:
                    {
                        this.lnkFirst.Visible = true;
                        this.lnkSecond.Visible = true;
                        this.lnkThird.Visible = true;
                        this.lnkFour.Visible = false;
                        this.lnkFive.Visible = false;
                        goto Label0;
                    }
                case 4:
                    {
                        this.lnkFirst.Visible = true;
                        this.lnkSecond.Visible = true;
                        this.lnkThird.Visible = true;
                        this.lnkFour.Visible = true;
                        this.lnkFive.Visible = false;
                        goto Label0;
                    }
                case 5:
                    {
                        this.lnkFirst.Visible = true;
                        this.lnkSecond.Visible = true;
                        this.lnkThird.Visible = true;
                        this.lnkFour.Visible = true;
                        this.lnkFive.Visible = true;
                        goto Label0;
                    }
                default:
                    {
                        this.lnkFirst.Visible = true;
                        this.lnkSecond.Visible = true;
                        this.lnkThird.Visible = true;
                        this.lnkFour.Visible = true;
                        this.lnkFive.Visible = true;
                        goto Label0;
                    }
            }
        Label0:
            string d = "";
        }

        protected void ddlPageNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ChangeDisplayOfPaging(this.hdnPageNumberonChange.Value);
        }

        public void DropDownPageSize()
        {
            this.ddlPageSize.Items.Insert(0, "");
            this.ddlPageSize.Items[0].Value = "10";
            this.ddlPageSize.Items[0].Text = "10";
            this.ddlPageSize.Items.Insert(1, "");
            this.ddlPageSize.Items[1].Value = "20";
            this.ddlPageSize.Items[1].Text = "20";
            this.ddlPageSize.Items.Insert(2, "");
            this.ddlPageSize.Items[2].Value = "25";
            this.ddlPageSize.Items[2].Text = "25";
            this.ddlPageSize.Items[2].Selected = true;
            this.ddlPageSize.Items.Insert(3, "");
            this.ddlPageSize.Items[3].Value = "30";
            this.ddlPageSize.Items[3].Text = "30";
            this.ddlPageSize.Items.Insert(4, "");
            this.ddlPageSize.Items[4].Value = "40";
            this.ddlPageSize.Items[4].Text = "40";
            this.ddlPageSize.Items.Insert(5, "");
            this.ddlPageSize.Items[5].Value = "50";
            this.ddlPageSize.Items[5].Text = "50";
            this.ddlPageSize.Items.Insert(6, "");
            this.ddlPageSize.Items[6].Value = "100";
            this.ddlPageSize.Items[6].Text = "100";
            this.BindPageNumber();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.AssignPageNumberAndCount();
            if (!base.IsPostBack)
            {
                this.lblPageNumber.Text = Paging.intCurrentPage.ToString();
                this.lblTotalPage.Text = Paging.intPageCount.ToString();
                this.lnkFirst.Attributes.Add("style", "color:red");
            }
        }

        private void PagingOff()
        {
            if (Paging.intPageCount == 1)
            {
                this.lnkStart.CssClass = "Paging_disable";
                this.lnkPrev.CssClass = "Paging_disable";
                this.lnkNext.CssClass = "Paging_disable";
                this.lnkEnd.CssClass = "Paging_disable";
                this.lnkStart.Enabled = false;
                this.lnkPrev.Enabled = false;
                this.lnkNext.Enabled = false;
                this.lnkEnd.Enabled = false;
                return;
            }
            if (Paging.intCurrentPage == 1 && Paging.intPageCount != 1)
            {
                this.lnkStart.CssClass = "Paging_disable";
                this.lnkPrev.CssClass = "Paging_disable";
                this.lnkNext.CssClass = "Paging_enable";
                this.lnkEnd.CssClass = "Paging_enable";
                this.lnkStart.Enabled = false;
                this.lnkPrev.Enabled = false;
                this.lnkNext.Enabled = true;
                this.lnkEnd.Enabled = true;
                return;
            }
            if (Paging.intCurrentPage == Paging.intPageCount)
            {
                this.lnkStart.CssClass = "Paging_enable";
                this.lnkPrev.CssClass = "Paging_enable";
                this.lnkNext.CssClass = "Paging_disable";
                this.lnkEnd.CssClass = "Paging_disable";
                this.lnkStart.Enabled = true;
                this.lnkPrev.Enabled = true;
                this.lnkNext.Enabled = false;
                this.lnkEnd.Enabled = false;
                return;
            }
            if (Paging.intCurrentPage > 1 && Paging.intCurrentPage < Paging.intPageCount)
            {
                this.lnkStart.CssClass = "Paging_enable";
                this.lnkPrev.CssClass = "Paging_enable";
                this.lnkNext.CssClass = "Paging_enable";
                this.lnkEnd.CssClass = "Paging_enable";
                this.lnkStart.Enabled = true;
                this.lnkPrev.Enabled = true;
                this.lnkNext.Enabled = true;
                this.lnkEnd.Enabled = true;
            }
        }

        public void SetDDLValue(DropDownList ddl, string value)
        {
            try
            {
                ListItem listItem = ddl.Items.FindByValue(value);
                ddl.SelectedIndex = ddl.Items.IndexOf(listItem);
            }
            catch
            {
            }
        }

        public event PagingEventHandler OnPageChange;
    }
}
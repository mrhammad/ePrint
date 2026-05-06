using System;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ePrint.usercontrol
{
    public partial class pagingreport : System.Web.UI.UserControl
    {
        public static int intCurrentPage;

        public static int intPageCount;

        public static int intTotalRec;

        public static string ShowRecords;

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

        static pagingreport()
        {
            pagingreport.ShowRecords = "2";
        }

        public pagingreport()
        {
        }

        protected void btn_Command(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            this.ChangeDisplayOfPaging(linkButton.Text.ToString().Trim().ToLower());
        }

        public void ChangeDisplayOfPaging(string currentlySelected)
        {
            int num = pagingreport.intCurrentPage;
            string empty = string.Empty;
            string str = currentlySelected;
            string str1 = str;
            if (str == null)
            {
                goto Label0;
            }
            else if (str1 == "<<")
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
                if (str1 != ">>")
                {
                    goto Label0;
                }
                empty = pagingreport.intPageCount.ToString();
            }
        Label2:
            pagingreport.intCurrentPage = Convert.ToInt32(empty);
            if (empty == "1")
            {
                this.lnkstart.Enabled = false;
                this.lnkPrev.Enabled = false;
                this.lnkNext.Enabled = true;
                this.lnkEnd.Enabled = true;
            }
            else if (empty != pagingreport.intPageCount.ToString())
            {
                this.lnkstart.Enabled = true;
                this.lnkPrev.Enabled = true;
                this.lnkNext.Enabled = true;
                this.lnkEnd.Enabled = true;
            }
            else
            {
                this.lnkstart.Enabled = true;
                this.lnkPrev.Enabled = true;
                this.lnkNext.Enabled = false;
                this.lnkEnd.Enabled = false;
            }
            this.ChangePageNumber(Convert.ToInt32(empty));
            this.lblPageNumber.Text = empty;
            this.lblTotalPage.Text = pagingreport.intPageCount.ToString();
            if (empty == this.lnkFirst.Text)
            {
                this.lnkFirst.Font.Bold = true;
                this.lnkSecond.Font.Bold = false;
                this.lnkThird.Font.Bold = false;
                this.lnkFour.Font.Bold = false;
                this.lnkFive.Font.Bold = false;
                this.lnkFirst.Enabled = false;
                this.lnkSecond.Enabled = true;
                this.lnkThird.Enabled = true;
                this.lnkFour.Enabled = true;
                this.lnkFive.Enabled = true;
                return;
            }
            if (empty == this.lnkSecond.Text)
            {
                this.lnkFirst.Font.Bold = false;
                this.lnkSecond.Font.Bold = true;
                this.lnkThird.Font.Bold = false;
                this.lnkFour.Font.Bold = false;
                this.lnkFive.Font.Bold = false;
                this.lnkFirst.Enabled = true;
                this.lnkSecond.Enabled = false;
                this.lnkThird.Enabled = true;
                this.lnkFour.Enabled = true;
                this.lnkFive.Enabled = true;
                return;
            }
            if (empty == this.lnkThird.Text)
            {
                this.lnkFirst.Font.Bold = false;
                this.lnkSecond.Font.Bold = false;
                this.lnkThird.Font.Bold = true;
                this.lnkFour.Font.Bold = false;
                this.lnkFive.Font.Bold = false;
                this.lnkFirst.Enabled = true;
                this.lnkSecond.Enabled = true;
                this.lnkThird.Enabled = false;
                this.lnkFour.Enabled = true;
                this.lnkFive.Enabled = true;
                return;
            }
            if (empty == this.lnkFour.Text)
            {
                this.lnkFirst.Font.Bold = false;
                this.lnkSecond.Font.Bold = false;
                this.lnkThird.Font.Bold = false;
                this.lnkFour.Font.Bold = true;
                this.lnkFive.Font.Bold = false;
                this.lnkFirst.Enabled = true;
                this.lnkSecond.Enabled = true;
                this.lnkThird.Enabled = true;
                this.lnkFour.Enabled = false;
                this.lnkFive.Enabled = true;
                return;
            }
            if (empty == this.lnkFive.Text)
            {
                this.lnkFirst.Font.Bold = false;
                this.lnkSecond.Font.Bold = false;
                this.lnkThird.Font.Bold = false;
                this.lnkFour.Font.Bold = false;
                this.lnkFive.Font.Bold = true;
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
            int num = pagingreport.intPageCount;
            this.PagingOff();
            int num1 = pagingreport.intCurrentPage;
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
                        this.lblPageNumber.Text = pagingreport.intCurrentPage.ToString();
                        this.lblTotalPage.Text = pagingreport.intPageCount.ToString();
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
            string s = "";
        }

        private void DropDownPageSize()
        {
        }

        public void MakeFirst()
        {
            this.lnkFirst.Font.Bold = true;
            this.lnkSecond.Font.Bold = false;
            this.lnkThird.Font.Bold = false;
            this.lnkFour.Font.Bold = false;
            this.lnkFive.Font.Bold = false;
            this.lnkFirst.Enabled = false;
            this.lnkstart.Enabled = false;
            this.lnkPrev.Enabled = false;
            this.lnkNext.Enabled = true;
            this.lnkEnd.Enabled = true;
            if (pagingreport.intPageCount > 1)
            {
                this.lnkSecond.Enabled = true;
            }
            if (pagingreport.intPageCount > 2)
            {
                this.lnkSecond.Enabled = true;
                this.lnkThird.Enabled = true;
            }
            if (pagingreport.intPageCount > 3)
            {
                this.lnkSecond.Enabled = true;
                this.lnkThird.Enabled = true;
            }
            if (pagingreport.intPageCount > 4)
            {
                this.lnkSecond.Enabled = true;
                this.lnkThird.Enabled = true;
                this.lnkFour.Enabled = true;
            }
            if (pagingreport.intPageCount > 5)
            {
                this.lnkSecond.Enabled = true;
                this.lnkThird.Enabled = true;
                this.lnkFour.Enabled = true;
                this.lnkFive.Enabled = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DropDownPageSize();
            this.MakeFirst();
            this.lblPageNumber.Text = pagingreport.intCurrentPage.ToString();
            this.lblTotalPage.Text = pagingreport.intPageCount.ToString();
        }

        private void PagingOff()
        {
            if (pagingreport.intPageCount == 1)
            {
                this.lnkFirst.Enabled = false;
                return;
            }
            if (pagingreport.intCurrentPage == 1 && pagingreport.intPageCount != 1)
            {
                return;
            }
            if (pagingreport.intCurrentPage == pagingreport.intPageCount)
            {
                return;
            }
            if (pagingreport.intCurrentPage > 1)
            {
                int num = pagingreport.intCurrentPage;
                int num1 = pagingreport.intPageCount;
            }
        }

        public event PagingEventHandlerreport OnPageChange;
    }
}
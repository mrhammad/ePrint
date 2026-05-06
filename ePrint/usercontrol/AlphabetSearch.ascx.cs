using nmsCommon;
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
    public partial class AlphabetSearch : System.Web.UI.UserControl
    {
        private BaseClass objBase = new BaseClass();

        private BasePage objpage = new BasePage();

        private languageClass objLanguage = new languageClass();

        private string tabcolor = string.Empty;

        private string forecolor = string.Empty;

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

        public AlphabetSearch()
        {
        }

        protected void btn_Command(object sender, CommandEventArgs e)
        {
            this.ChangeAlphabateColor(this.plhAlphabeat, "btn_", e.CommandArgument.ToString(), this.tabcolor, this.forecolor);
            this.ChangeFilter(e.CommandArgument.ToString());
        }

        public void ChangeAlphabateColor(PlaceHolder plh, string StrID, string ComandArgument, string tabcolor, string forecolor)
        {
            for (int i = 64; i < 92; i++)
            {
                Button button = (Button)plh.FindControl(string.Concat(StrID, i.ToString()));
                if (string.Compare(ComandArgument.ToString(), " ", true) == 0 || string.Compare(ComandArgument.ToString(), "", true) == 0)
                {
                    if (button.Text != this.objLanguage.convert("All"))
                    {
                        button.CssClass = "lettersorting1";
                        AttributeCollection attributes = button.Attributes;
                        string[] strArrays = new string[] { "javascript:changeStyle(this,'lettersorting1_over','", tabcolor, "','", forecolor, "')" };
                        attributes.Add("onmouseover", string.Concat(strArrays));
                        button.Attributes.Add("onmouseout", "javascript:changeStyle(this,'lettersorting1','#ffffff','#5D7B9D')");
                    }
                    else
                    {
                        button.CssClass = "lettersorting1_over";
                        AttributeCollection attributeCollection = button.Attributes;
                        string[] strArrays1 = new string[] { "javascript:changeStyle(this,'lettersorting1_over','", tabcolor, "','", forecolor, "')" };
                        attributeCollection.Add("onmouseover", string.Concat(strArrays1));
                        AttributeCollection attributes1 = button.Attributes;
                        string[] strArrays2 = new string[] { "javascript:changeStyle(this,'lettersorting1_over','", tabcolor, "','", forecolor, "')" };
                        attributes1.Add("onmouseout", string.Concat(strArrays2));
                    }
                }
                else if (ComandArgument.ToString().ToLower() == "number")
                {
                    if (button.Text != "0-9")
                    {
                        button.CssClass = "lettersorting1";
                        AttributeCollection attributeCollection1 = button.Attributes;
                        string[] strArrays3 = new string[] { "javascript:changeStyle(this,'lettersorting1_over','", tabcolor, "','", forecolor, "')" };
                        attributeCollection1.Add("onmouseover", string.Concat(strArrays3));
                        button.Attributes.Add("onmouseout", "javascript:changeStyle(this,'lettersorting1','#ffffff','#5D7B9D')");
                    }
                    else
                    {
                        button.CssClass = "lettersorting1_over";
                        AttributeCollection attributes2 = button.Attributes;
                        string[] strArrays4 = new string[] { "javascript:changeStyle(this,'lettersorting1_over','", tabcolor, "','", forecolor, "')" };
                        attributes2.Add("onmouseover", string.Concat(strArrays4));
                        AttributeCollection attributeCollection2 = button.Attributes;
                        string[] strArrays5 = new string[] { "javascript:changeStyle(this,'lettersorting1_over','", tabcolor, "','", forecolor, "')" };
                        attributeCollection2.Add("onmouseout", string.Concat(strArrays5));
                    }
                }
                else if (button.Text != ComandArgument.ToString().ToUpper())
                {
                    button.CssClass = "lettersorting1";
                    AttributeCollection attributes3 = button.Attributes;
                    string[] strArrays6 = new string[] { "javascript:changeStyle(this,'lettersorting1_over','", tabcolor, "','", forecolor, "')" };
                    attributes3.Add("onmouseover", string.Concat(strArrays6));
                    button.Attributes.Add("onmouseout", "javascript:changeStyle(this,'lettersorting1','#ffffff','#5D7B9D')");
                }
                else
                {
                    button.CssClass = "lettersorting1_over";
                    AttributeCollection attributeCollection3 = button.Attributes;
                    string[] strArrays7 = new string[] { "javascript:changeStyle(this,'lettersorting1_over','", tabcolor, "','", forecolor, "')" };
                    attributeCollection3.Add("onmouseover", string.Concat(strArrays7));
                    AttributeCollection attributes4 = button.Attributes;
                    string[] strArrays8 = new string[] { "javascript:changeStyle(this,'lettersorting1_over','", tabcolor, "','", forecolor, "')" };
                    attributes4.Add("onmouseout", string.Concat(strArrays8));
                }
            }
        }

        private void ChangeFilter(string newFilter)
        {
            if (this.OnFilterChange != null)
            {
                this.OnFilterChange(newFilter);
            }
        }

        protected override void OnInit(EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.tabcolor = this.objpage.colorCode(Convert.ToInt32(base.Session["companyid"]), base.Session["pagename"].ToString());
            this.forecolor = this.objpage.Forecolor(Convert.ToInt32(base.Session["companyid"]), base.Session["pagename"].ToString());
            base.OnInit(e);
            for (int i = 64; i < 92; i++)
            {
                Button button = new Button()
                {
                    ID = string.Concat("btn_", i.ToString())
                };
                if (i == 64)
                {
                    button.Text = "0-9";
                    button.Width = Unit.Pixel(30);
                    button.CommandArgument = "number";
                }
                else if (i >= 65 && i != 91)
                {
                    string str = new string((char)i, 1);
                    button.Text = str;
                    button.Width = Unit.Pixel(20);
                    button.CommandArgument = str.ToLower();
                }
                else if (i == 91)
                {
                    button.Text = this.objLanguage.convert("All");
                    button.CommandArgument = "";
                }
                button.Command += new CommandEventHandler(this.btn_Command);
                button.CssClass = "lettersorting1";
                AttributeCollection attributes = button.Attributes;
                string[] strArrays = new string[] { "javascript:changeStyle(this,'lettersorting1_over','", this.tabcolor, "','", this.forecolor, "')" };
                attributes.Add("onmouseover", string.Concat(strArrays));
                button.Attributes.Add("onmouseout", "javascript:changeStyle(this,'lettersorting1','#ffffff','#5D7B9D')");
                this.plhAlphabeat.Controls.Add(new LiteralControl("<div style='float:left;padding:2px'>"));
                this.plhAlphabeat.Controls.Add(button);
                this.plhAlphabeat.Controls.Add(new LiteralControl("</div>"));
            }
            this.ChangeAlphabateColor(this.plhAlphabeat, "btn_", "", this.tabcolor, this.forecolor);
        }

        public event SearchChangeEventHandler OnFilterChange;
    }
}
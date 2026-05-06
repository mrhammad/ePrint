using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using nmsCommon;
using RemovingWhiteSpacesAspNet;
using System.Collections.Specialized;
using System.Web.Profile;
using System.Web.SessionState;


namespace ePrint
{
    public partial class printlayout_delivery : System.Web.UI.Page
    {
        private Global gloobj = new Global();

        public string strImagepath;

        private int lablerow;

        private int lablecol;

        private int startrow;

        private int startcol;

        private string itemtitle = string.Empty;

        private string customername = string.Empty;

        private string address1 = string.Empty;

        private string address2 = string.Empty;

        private string address3 = string.Empty;

        private string address4 = string.Empty;

        private string country = string.Empty;

        private string telephone = string.Empty;

        private string prefix = string.Empty;

        private string suffix = string.Empty;

        private string maskcheck = string.Empty;

        private int nooflables;

        private int nooflablesonprint;

        private int noofitemperbox;

        private int maskstartvalue;

        private int startval;

        private int endval;

        private int diffval;

        private int maskendvalue;

        private string[] boxlableaddress;

        private string strItemTitle;

        private string strCustomerName;

        private string strAddress1;

        private string strAddress2;

        private string strAddress3;

        private string strAddress4;

        private string strCountry;

        private string strTelephone;

        private string[] ArryItemTitle;

        private string[] ArryCustomerName;

        private string[] ArryAddress1;

        private string[] ArryAddress2;

        private string[] ArryAddress3;

        private string[] ArryAddress4;

        private string[] ArryCountry;

        private string[] ArryTelephone;

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

        public printlayout_delivery()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.strImagepath = global.imagePath();
            this.gloobj.setpagename("job");
            this.lablerow = (base.Request.Params["LR"].ToString() == "" ? 0 : Convert.ToInt32(base.Request.Params["LR"].ToString()));
            this.lablecol = (base.Request.Params["LC"].ToString() == "" ? 0 : Convert.ToInt32(base.Request.Params["LC"].ToString()));
            this.startrow = (base.Request.Params["SR"].ToString() == "" ? 0 : Convert.ToInt32(base.Request.Params["SR"].ToString()));
            this.startcol = (base.Request.Params["SC"].ToString() == "" ? 0 : Convert.ToInt32(base.Request.Params["SC"].ToString()));
            if (base.Request.Params["ispw"] != null)
            {
                this.nooflables = Convert.ToInt32(base.Request.Params["nooflables"].ToString());
                double num = (double)(this.lablerow * this.lablecol);
                Math.Ceiling((double)this.nooflables / num);
                this.plhlayout.Controls.Add(new LiteralControl("<div id='rotate'>"));
                this.plhlayout.Controls.Add(new LiteralControl(this.Session["boxlableaddress"].ToString()));
                this.plhlayout.Controls.Add(new LiteralControl("</div>"));
                return;
            }
            if (base.Request.Params["ismp"] != null)
            {
                this.plhlayout.Controls.Add(new LiteralControl(this.Session["boxlableaddress"].ToString()));
                return;
            }
            if (base.Request.Params["isop"] != null)
            {
                this.plhlayout.Controls.Add(new LiteralControl(this.Session["boxlableaddress"].ToString()));
                return;
            }
            if (base.Request.Params["isstud"] != null)
            {
                this.plhlayout.Controls.Add(new LiteralControl(this.Session["boxlableaddress"].ToString()));
                return;
            }
            if (base.Request.Params["iscp"] != null)
            {
                this.plhlayout.Controls.Add(new LiteralControl(this.Session["boxlableaddress"].ToString()));
                return;
            }
            if (this.Session["boxlableaddress"] != null)
            {
                string[] strArrays = this.Session["boxlableaddress"].ToString().Split(new char[] { 'µ' });
                for (int i = 0; i < (int)strArrays.Length - 1; i++)
                {
                    string str = strArrays[i];
                    char[] chrArray = new char[] { '~' };
                    this.boxlableaddress = str.Split(chrArray);
                    printlayout_delivery printlayoutDelivery = this;
                    printlayoutDelivery.strItemTitle = string.Concat(printlayoutDelivery.strItemTitle, this.boxlableaddress[0].ToString(), "±");
                    printlayout_delivery printlayoutDelivery1 = this;
                    printlayoutDelivery1.strCustomerName = string.Concat(printlayoutDelivery1.strCustomerName, this.boxlableaddress[1].ToString(), "±");
                    printlayout_delivery printlayoutDelivery2 = this;
                    printlayoutDelivery2.strAddress1 = string.Concat(printlayoutDelivery2.strAddress1, this.boxlableaddress[2].ToString(), "±");
                    printlayout_delivery printlayoutDelivery3 = this;
                    printlayoutDelivery3.strAddress2 = string.Concat(printlayoutDelivery3.strAddress2, this.boxlableaddress[3].ToString(), "±");
                    printlayout_delivery printlayoutDelivery4 = this;
                    printlayoutDelivery4.strAddress3 = string.Concat(printlayoutDelivery4.strAddress3, this.boxlableaddress[4].ToString(), "±");
                    printlayout_delivery printlayoutDelivery5 = this;
                    printlayoutDelivery5.strAddress4 = string.Concat(printlayoutDelivery5.strAddress4, this.boxlableaddress[5].ToString(), "±");
                    printlayout_delivery printlayoutDelivery6 = this;
                    printlayoutDelivery6.strCountry = string.Concat(printlayoutDelivery6.strCountry, this.boxlableaddress[6].ToString(), "±");
                    printlayout_delivery printlayoutDelivery7 = this;
                    printlayoutDelivery7.strTelephone = string.Concat(printlayoutDelivery7.strTelephone, this.boxlableaddress[7].ToString(), "±");
                }
                string str1 = this.strItemTitle;
                char[] chrArray1 = new char[] { '±' };
                this.ArryItemTitle = str1.Split(chrArray1);
                string str2 = this.strCustomerName;
                char[] chrArray2 = new char[] { '±' };
                this.ArryCustomerName = str2.Split(chrArray2);
                string str3 = this.strAddress1;
                char[] chrArray3 = new char[] { '±' };
                this.ArryAddress1 = str3.Split(chrArray3);
                string str4 = this.strAddress2;
                char[] chrArray4 = new char[] { '±' };
                this.ArryAddress2 = str4.Split(chrArray4);
                string str5 = this.strAddress3;
                char[] chrArray5 = new char[] { '±' };
                this.ArryAddress3 = str5.Split(chrArray5);
                string str6 = this.strAddress4;
                char[] chrArray6 = new char[] { '±' };
                this.ArryAddress4 = str6.Split(chrArray6);
                string str7 = this.strCountry;
                char[] chrArray7 = new char[] { '±' };
                this.ArryCountry = str7.Split(chrArray7);
                string str8 = this.strTelephone;
                char[] chrArray8 = new char[] { '±' };
                this.ArryTelephone = str8.Split(chrArray8);
            }
            this.nooflables = Convert.ToInt32(base.Request.Params["nooflables"].ToString());
            this.nooflablesonprint = Convert.ToInt32(base.Request.Params["nooflableonprintview"].ToString());
            this.prefix = base.Request.Params["prefix"].ToString();
            this.suffix = base.Request.Params["suffix"].ToString();
            this.maskcheck = base.Request.Params["maskcheck"].ToString();
            this.noofitemperbox = (base.Request.Params["noofitemperbox"].ToString() == "" ? 0 : Convert.ToInt32(base.Request.Params["noofitemperbox"].ToString()));
            this.maskstartvalue = (base.Request.Params["maskstartval"].ToString() == "" ? 0 : Convert.ToInt32(base.Request.Params["maskstartval"].ToString()));
            this.maskendvalue = (base.Request.Params["maskendval"].ToString() == "" ? 0 : Convert.ToInt32(base.Request.Params["maskendval"].ToString()));
            this.startval = this.maskstartvalue;
            this.diffval = this.noofitemperbox;
            this.endval = this.startval + (this.diffval - 1);
            this.plhlayout.Controls.Add(new LiteralControl("<table cellpadding=0 cellspacing=0 border=0 height=500px width=100%>"));
            this.plhlayout.Controls.Add(new LiteralControl("<tr>"));
            this.plhlayout.Controls.Add(new LiteralControl("<td>"));
            this.plhlayout.Controls.Add(new LiteralControl("<div>"));
            this.plhlayout.Controls.Add(new LiteralControl("<table class='a4sheet' cellpadding='0' cellspacing='10' border='0'>"));
            int num1 = 0;
            int num2 = 1;
            double num3 = 0;
            int num4 = 0;
            double num5 = (double)(this.lablerow * this.lablecol);
            num3 = Math.Ceiling((double)this.nooflables / num5);
            for (int j = 0; (double)j < num3; j++)
            {
                if (this.startrow != 1 && this.startcol >= 1 && j == 0)
                {
                    for (int k = 1; k < this.startrow; k++)
                    {
                        this.plhlayout.Controls.Add(new LiteralControl("<tr>"));
                        this.plhlayout.Controls.Add(new LiteralControl("<td>"));
                        ControlCollection controls = this.plhlayout.Controls;
                        object[] objArray = new object[] { "<div class='boxlable", this.lablerow, this.lablecol, "'>" };
                        controls.Add(new LiteralControl(string.Concat(objArray)));
                        this.plhlayout.Controls.Add(new LiteralControl("</div>"));
                        this.plhlayout.Controls.Add(new LiteralControl("</td>"));
                        this.plhlayout.Controls.Add(new LiteralControl("</tr>"));
                    }
                }
                for (int l = 1; l <= this.lablerow; l++)
                {
                    this.plhlayout.Controls.Add(new LiteralControl("<tr >"));
                    for (int m = 1; m <= this.lablecol; m++)
                    {
                        if (this.nooflables <= num1)
                        {
                            this.plhlayout.Controls.Add(new LiteralControl("<td valign=top>&nbsp;"));
                            ControlCollection controlCollections = this.plhlayout.Controls;
                            object[] objArray1 = new object[] { "<div class='boxlable", this.lablerow, this.lablecol, "'>" };
                            controlCollections.Add(new LiteralControl(string.Concat(objArray1)));
                            this.plhlayout.Controls.Add(new LiteralControl("</div>"));
                            this.plhlayout.Controls.Add(new LiteralControl("</td>"));
                        }
                        else if (this.maskcheck.ToLower() == "true" && this.endval <= this.maskendvalue)
                        {
                            if (this.startcol <= m || l != 1 || j != 0)
                            {
                                this.plhlayout.Controls.Add(new LiteralControl("<td valign=top>"));
                                ControlCollection controls1 = this.plhlayout.Controls;
                                object[] objArray2 = new object[] { "<div class='boxlable", this.lablerow, this.lablecol, "' >" };
                                controls1.Add(new LiteralControl(string.Concat(objArray2)));
                                ControlCollection controlCollections1 = this.plhlayout.Controls;
                                object[] objArray3 = new object[] { "Box # ", num2, " of ", this.nooflablesonprint };
                                controlCollections1.Add(new LiteralControl(string.Concat(objArray3)));
                                if (this.ArryItemTitle[num4] != "")
                                {
                                    this.plhlayout.Controls.Add(new LiteralControl("<br>"));
                                    this.plhlayout.Controls.Add(new LiteralControl(this.ArryItemTitle[num4]));
                                }
                                if (this.ArryCustomerName[num4] != "")
                                {
                                    this.plhlayout.Controls.Add(new LiteralControl("<br>"));
                                    this.plhlayout.Controls.Add(new LiteralControl(this.ArryCustomerName[num4]));
                                }
                                if (this.ArryAddress1[num4] != "")
                                {
                                    this.plhlayout.Controls.Add(new LiteralControl("<br>"));
                                    this.plhlayout.Controls.Add(new LiteralControl(this.ArryAddress1[num4]));
                                }
                                if (this.ArryAddress2[num4] != "")
                                {
                                    this.plhlayout.Controls.Add(new LiteralControl("<br>"));
                                    this.plhlayout.Controls.Add(new LiteralControl(this.ArryAddress2[num4]));
                                }
                                if (this.ArryAddress3[num4] != "")
                                {
                                    this.plhlayout.Controls.Add(new LiteralControl("<br>"));
                                    this.plhlayout.Controls.Add(new LiteralControl(this.ArryAddress3[num4]));
                                }
                                if (this.ArryAddress4[num4] != "")
                                {
                                    this.plhlayout.Controls.Add(new LiteralControl("<br>"));
                                    this.plhlayout.Controls.Add(new LiteralControl(this.ArryAddress4[num4]));
                                }
                                if (this.ArryCountry[num4] != "")
                                {
                                    this.plhlayout.Controls.Add(new LiteralControl("<br>"));
                                    this.plhlayout.Controls.Add(new LiteralControl(this.ArryCountry[num4]));
                                }
                                if (this.ArryTelephone[num4] != "")
                                {
                                    this.plhlayout.Controls.Add(new LiteralControl("<br>"));
                                    this.plhlayout.Controls.Add(new LiteralControl(this.ArryTelephone[num4]));
                                }
                                this.plhlayout.Controls.Add(new LiteralControl("</div>"));
                                this.plhlayout.Controls.Add(new LiteralControl("</td>"));
                                this.startval += this.diffval;
                                this.endval += this.diffval;
                                num4++;
                            }
                            else
                            {
                                this.plhlayout.Controls.Add(new LiteralControl("<td valign=top>&nbsp;"));
                                ControlCollection controls2 = this.plhlayout.Controls;
                                object[] objArray4 = new object[] { "<div class='boxlable", this.lablerow, this.lablecol, "'>" };
                                controls2.Add(new LiteralControl(string.Concat(objArray4)));
                                this.plhlayout.Controls.Add(new LiteralControl("</div>"));
                                this.plhlayout.Controls.Add(new LiteralControl("</td>"));
                                num2--;
                                this.nooflables++;
                            }
                        }
                        else if (this.maskcheck.ToLower() == "false")
                        {
                            if (this.startcol <= m || l != 1 || j != 0)
                            {
                                this.plhlayout.Controls.Add(new LiteralControl("<td valign=top>"));
                                ControlCollection controlCollections2 = this.plhlayout.Controls;
                                object[] objArray5 = new object[] { "<div class='boxlable", this.lablerow, this.lablecol, "' >" };
                                controlCollections2.Add(new LiteralControl(string.Concat(objArray5)));
                                ControlCollection controls3 = this.plhlayout.Controls;
                                object[] objArray6 = new object[] { "Box # ", num2, " of ", this.nooflablesonprint };
                                controls3.Add(new LiteralControl(string.Concat(objArray6)));
                                if (this.ArryItemTitle[num4] != "")
                                {
                                    this.plhlayout.Controls.Add(new LiteralControl("<br>"));
                                    this.plhlayout.Controls.Add(new LiteralControl(this.ArryItemTitle[num4]));
                                }
                                if (this.ArryCustomerName[num4] != "")
                                {
                                    this.plhlayout.Controls.Add(new LiteralControl("<br>"));
                                    this.plhlayout.Controls.Add(new LiteralControl(this.ArryCustomerName[num4]));
                                }
                                if (this.ArryAddress1[num4] != "")
                                {
                                    this.plhlayout.Controls.Add(new LiteralControl("<br>"));
                                    this.plhlayout.Controls.Add(new LiteralControl(this.ArryAddress1[num4]));
                                }
                                if (this.ArryAddress2[num4] != "")
                                {
                                    this.plhlayout.Controls.Add(new LiteralControl("<br>"));
                                    this.plhlayout.Controls.Add(new LiteralControl(this.ArryAddress2[num4]));
                                }
                                if (this.ArryAddress3[num4] != "")
                                {
                                    this.plhlayout.Controls.Add(new LiteralControl("<br>"));
                                    this.plhlayout.Controls.Add(new LiteralControl(this.ArryAddress3[num4]));
                                }
                                if (this.ArryAddress4[num4] != "")
                                {
                                    this.plhlayout.Controls.Add(new LiteralControl("<br>"));
                                    this.plhlayout.Controls.Add(new LiteralControl(this.ArryAddress4[num4]));
                                }
                                if (this.ArryCountry[num4] != "")
                                {
                                    this.plhlayout.Controls.Add(new LiteralControl("<br>"));
                                    this.plhlayout.Controls.Add(new LiteralControl(this.ArryCountry[num4]));
                                }
                                if (this.ArryTelephone[num4] != "")
                                {
                                    this.plhlayout.Controls.Add(new LiteralControl("<br>"));
                                    this.plhlayout.Controls.Add(new LiteralControl(this.ArryTelephone[num4]));
                                }
                                this.plhlayout.Controls.Add(new LiteralControl("</div>"));
                                this.plhlayout.Controls.Add(new LiteralControl("</td>"));
                                num4++;
                            }
                            else
                            {
                                this.plhlayout.Controls.Add(new LiteralControl("<td valign=top>&nbsp;"));
                                ControlCollection controlCollections3 = this.plhlayout.Controls;
                                object[] objArray7 = new object[] { "<div class='boxlable", this.lablerow, this.lablecol, "'>" };
                                controlCollections3.Add(new LiteralControl(string.Concat(objArray7)));
                                this.plhlayout.Controls.Add(new LiteralControl("</div>"));
                                this.plhlayout.Controls.Add(new LiteralControl("</td>"));
                                num2--;
                                this.nooflables++;
                            }
                        }
                        num1++;
                        num2++;
                    }
                    this.plhlayout.Controls.Add(new LiteralControl("</tr>"));
                }
            }
            this.plhlayout.Controls.Add(new LiteralControl("</table>"));
            this.plhlayout.Controls.Add(new LiteralControl("</div>"));
            this.plhlayout.Controls.Add(new LiteralControl("</td>"));
            this.plhlayout.Controls.Add(new LiteralControl("</tr>"));
            this.plhlayout.Controls.Add(new LiteralControl("</table>"));
        }
    }
}
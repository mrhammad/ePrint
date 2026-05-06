using nmsCommon;
using RemovingWhiteSpacesAspNet;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint
{
    public partial class print_layout_large_roll : System.Web.UI.Page, IRequiresSessionState
    {
        //protected Label lblImposition;

        //protected Label lblRowCol;

        //protected PlaceHolder phlayout;

        //protected PlaceHolder phtest;

        private double section_height;

        private double item_height;

        private double section_width;

        private double item_width;

        private string type = string.Empty;

        private int hrgap;

        private int vrgap;

        private int row;

        private int col;

        private int width = 60;

        private double valign_gap;

        private double halign_gap;

        private double ItemTotalHeight;

        private double ItemTotalWeight;

        private double ItemHeight;

        private double ItemWidth;

        private double SectionTotalHeight;

        private double SectionTotalWeight;

        private double VerticalGutter = 5;

        private double HorizontalGutter = 5;

        private string border = "solid";

        private string selected = string.Empty;

        private Global gloobj = new Global();

        public string strImagepath;

        private double SH;

        private double SW;

        private double IW;

        private double IH;

        private double nonHeight;

        private double nonWidth;

        private double PercentageForDivide;

        private double PercentageForShow;

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

        public print_layout_large_roll()
        {
        }

        public PlaceHolder add_contents(PlaceHolder phcontents)
        {
            ControlCollection controls = this.phlayout.Controls;
            object[] objArray = new object[] { "<table border=0  width=", this.width, "%  align=center cellpadding=", this.hrgap, " cellspacing=", this.vrgap, ">" };
            controls.Add(new LiteralControl(string.Concat(objArray)));
            for (int i = 0; i < this.row; i++)
            {
                this.phlayout.Controls.Add(new LiteralControl("<tr>"));
                for (int j = 0; j < this.col; j++)
                {
                    this.phlayout.Controls.Add(new LiteralControl("<td>"));
                    this.phlayout.Controls.Add(new LiteralControl("<img src=images/invis.gif height=100% width=100% border=1/>"));
                    this.phlayout.Controls.Add(new LiteralControl("</td>"));
                }
                this.phlayout.Controls.Add(new LiteralControl("</tr>"));
            }
            this.phlayout.Controls.Add(new LiteralControl("</table>"));
            return phcontents;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int num = 0;
            if (base.Request.Params["qty"] != null)
            {
                try
                {
                    num = Convert.ToInt32(base.Request.Params["qty"]);
                }
                catch
                {
                }
            }
            double num1 = Convert.ToDouble(base.Request.Params["Row_Print"]);
            double num2 = Convert.ToDouble(base.Request.Params["Col_Print"]);
            this.strImagepath = global.imagePath();
            this.gloobj.setpagename("estimate");
            this.SH = (base.Request.Params["SH"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["SH"].ToString()));
            this.SW = (base.Request.Params["SW"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["SW"].ToString()));
            this.IW = (base.Request.Params["IW"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["IW"].ToString()));
            this.IH = (base.Request.Params["IH"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["IH"].ToString()));
            this.HorizontalGutter = (base.Request.Params["hg"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["hg"].ToString()));
            this.VerticalGutter = (base.Request.Params["vg"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["vg"].ToString()));
            this.type = base.Request.Params["type"].ToString();
            if (this.SW > 700)
            {
                this.PercentageForDivide = 700 / this.SW;
                this.PercentageForDivide = (1 - this.PercentageForDivide) * 100;
                this.PercentageForShow = this.PercentageForDivide;
                this.SH = this.SH - this.SH * this.PercentageForDivide / 100;
                this.SW = this.SW - this.SW * this.PercentageForDivide / 100;
                this.IH = this.IH - this.IH * this.PercentageForDivide / 100;
                this.IW = this.IW - this.IW * this.PercentageForDivide / 100;
                this.HorizontalGutter = this.HorizontalGutter - this.HorizontalGutter * this.PercentageForDivide / 100;
                this.VerticalGutter = this.VerticalGutter - this.VerticalGutter * this.PercentageForDivide / 100;
                this.lblImposition.Text = string.Concat("This imposition is scaled down by ", Math.Round(this.PercentageForShow), "% ");
            }
            else if (this.SW < 150)
            {
                this.PercentageForDivide = 150 / this.SW;
                this.PercentageForShow = this.PercentageForDivide / this.SW * 100;
                this.SH = this.SH + this.SH * this.PercentageForDivide;
                this.SW = this.SW + this.SW * this.PercentageForDivide;
                this.IH = this.IH + this.IH * this.PercentageForDivide;
                this.IW = this.IW + this.IW * this.PercentageForDivide;
                this.HorizontalGutter = this.HorizontalGutter + this.HorizontalGutter * this.PercentageForDivide / 100;
                this.VerticalGutter = this.VerticalGutter + this.VerticalGutter * this.PercentageForDivide / 100;
                this.lblImposition.Text = string.Concat("This imposition scale increased by ", Math.Round(this.PercentageForShow), "% ");
            }
            this.SectionTotalHeight = this.SH;
            this.SectionTotalWeight = this.SW;
            this.item_width = this.IW;
            this.item_height = this.IH;
            this.selected = base.Request.Params["selected"].ToString();
            this.row = (base.Request.Params["row"].ToString() == "" ? 0 : Convert.ToInt32(base.Request.Params["row"].ToString()));
            this.col = (base.Request.Params["col"].ToString() == "" ? 0 : Convert.ToInt32(base.Request.Params["col"].ToString()));
            if ((double)num >= num2)
            {
                Label label = this.lblRowCol;
                object[] objArray = new object[] { "Imposition Suggestion: ", num1, " x ", num2 };
                label.Text = string.Concat(objArray);
            }
            else
            {
                Label label1 = this.lblRowCol;
                object[] objArray1 = new object[] { "Imposition Suggestion: ", num1, " x ", num };
                label1.Text = string.Concat(objArray1);
            }
            this.section_width = this.SW + (double)(this.col * 2);
            this.section_height = this.SH + (double)(this.row * 2);
            this.ItemHeight = this.IH;
            this.ItemWidth = this.IW;
            if (this.type != "landscape")
            {
                this.ItemTotalWeight = this.ItemHeight * (double)this.col;
                this.ItemTotalHeight = this.ItemWidth * (double)this.row;
            }
            else
            {
                this.ItemTotalWeight = this.ItemWidth * (double)this.col;
                this.ItemTotalHeight = this.ItemHeight * (double)this.row;
            }
            if (this.selected == "gutters")
            {
                this.section_width = this.section_width + (double)this.col * this.HorizontalGutter;
                this.section_height = this.section_height + (double)this.row * this.VerticalGutter;
            }
            else if (this.selected != "both")
            {
                this.section_width = this.section_width + this.VerticalGutter + this.HorizontalGutter;
            }
            else
            {
                this.section_width = this.section_width + (double)this.col * this.HorizontalGutter;
                this.section_height = this.section_height + (double)this.row * this.VerticalGutter;
                this.border = "dotted";
            }
            this.valign_gap = (double)Convert.ToInt32((this.SectionTotalHeight - this.ItemTotalHeight) / 2);
            this.halign_gap = (double)Convert.ToInt32((this.SectionTotalWeight - this.ItemTotalWeight) / 2);
            double num3 = 3000;
            double num4 = 1500;
            if (this.type != "landscape")
            {
                this.HorizontalGutter = (double)Convert.ToInt32(this.HorizontalGutter * num4 / num3);
                this.VerticalGutter = (double)Convert.ToInt32(this.VerticalGutter * num4 / num3);
                double num5 = 0;
                double num6 = 0;
                double sH = this.SH;
                double sW = this.SW;
                double sH1 = this.SH - this.HorizontalGutter;
                double sW1 = this.SW - this.VerticalGutter;
                double num7 = Convert.ToDouble(base.Request.Params["nonHeight"]);
                double num8 = Convert.ToDouble(base.Request.Params["nonWidth"]);
                double verticalGutter = 0;
                sH = (double)Convert.ToInt32(sH * num4 / num3);
                sW = (double)Convert.ToInt32(sW * num4 / num3);
                sH1 = (double)Convert.ToInt32(sH1 * num4 / num3);
                sW1 = (double)Convert.ToInt32(sW1 * num4 / num3);
                this.ItemHeight = (double)Convert.ToInt32(this.ItemHeight * num4 / num3);
                this.ItemWidth = (double)Convert.ToInt32(this.ItemWidth * num4 / num3);
                num5 = sH - num7;
                num6 = sW - num8;
                double itemWidth = 0;
                double itemHeight = 0;
                if (this.ItemWidth <= this.ItemHeight)
                {
                    itemHeight = this.ItemHeight;
                    itemWidth = this.ItemWidth;
                }
                else
                {
                    itemHeight = this.ItemWidth;
                    itemWidth = this.ItemHeight;
                }
                this.row = Convert.ToInt32(num1);
                verticalGutter = (itemWidth + this.VerticalGutter) * (double)this.col;
                this.phtest.Controls.Add(new LiteralControl("<div style='padding:8px'>"));
                ControlCollection controls = this.phtest.Controls;
                object[] objArray2 = new object[] { "<div  style='width: ", sW, "px;height: ", sH, "px; border:solid 1px black;'>" };
                controls.Add(new LiteralControl(string.Concat(objArray2)));
                if (string.Compare(this.selected, "both", true) == 0 || string.Compare(this.selected, "restriction", true) == 0)
                {
                    this.phtest.Controls.Add(new LiteralControl("<table align='center' cellpadding='0px' cellspacing='0px' border='0px' height='100%' width='100%'>"));
                    this.phtest.Controls.Add(new LiteralControl("<tr valign='middle'>"));
                    this.phtest.Controls.Add(new LiteralControl("<td align='center'>"));
                    ControlCollection controlCollections = this.phtest.Controls;
                    object[] objArray3 = new object[] { "<div style='width:", num6, "px;height:", num5, "px;border: dotted 1px black;' align='center'>" };
                    controlCollections.Add(new LiteralControl(string.Concat(objArray3)));
                }
                this.phtest.Controls.Add(new LiteralControl("<table align='center' cellpadding='0px' cellspacing='0px' border='0px' height='100%' width='100%'>"));
                this.phtest.Controls.Add(new LiteralControl("<tr valign='top'>"));
                this.phtest.Controls.Add(new LiteralControl("<td align='center'>"));
                int num9 = 1;
                for (int i = 0; i < this.row; i++)
                {
                    this.phtest.Controls.Add(new LiteralControl(string.Concat("<table align='center' cellpadding='0px' cellspacing='0px' width='", verticalGutter, "px' border='0px'>")));
                    this.phtest.Controls.Add(new LiteralControl("<tr valign='middle'>"));
                    for (int j = 0; j < this.col; j++)
                    {
                        string str = "black";
                        string str1 = num9.ToString();
                        string str2 = "";
                        if (num < num9)
                        {
                            str = "white";
                            str1 = "";
                            str2 = "";
                        }
                        ControlCollection controls1 = this.phtest.Controls;
                        object[] verticalGutter1 = new object[] { "<td align='center' width='", itemWidth + this.VerticalGutter, "px' Height='", itemHeight + this.HorizontalGutter, "'>" };
                        controls1.Add(new LiteralControl(string.Concat(verticalGutter1)));
                        ControlCollection controlCollections1 = this.phtest.Controls;
                        object[] objArray4 = new object[] { "<div style='width:", itemWidth, "px; height:", itemHeight, "px; border: solid 1px ", str, ";", str2, "'>&nbsp;", str1, "</div>" };
                        controlCollections1.Add(new LiteralControl(string.Concat(objArray4)));
                        this.phtest.Controls.Add(new LiteralControl("</td>"));
                        num9++;
                    }
                    this.phtest.Controls.Add(new LiteralControl("</tr>"));
                    this.phtest.Controls.Add(new LiteralControl("</table>"));
                }
                this.phtest.Controls.Add(new LiteralControl("</td>"));
                this.phtest.Controls.Add(new LiteralControl("</tr>"));
                this.phtest.Controls.Add(new LiteralControl("</table>"));
                if (string.Compare(this.selected, "both", true) == 0 || string.Compare(this.selected, "restriction", true) == 0)
                {
                    this.phtest.Controls.Add(new LiteralControl("</div>"));
                    this.phtest.Controls.Add(new LiteralControl("</td>"));
                    this.phtest.Controls.Add(new LiteralControl("</tr>"));
                    this.phtest.Controls.Add(new LiteralControl("</table>"));
                }
                this.phtest.Controls.Add(new LiteralControl("</div>"));
                if (string.Compare(this.selected, "both", true) == 0 || string.Compare(this.selected, "restriction", true) == 0)
                {
                    this.phtest.Controls.Add(new LiteralControl("</div>"));
                }
                this.phtest.Controls.Add(new LiteralControl("</div>"));
            }
            else
            {
                double num10 = 0;
                double num11 = 0;
                double sH2 = this.SH;
                double sW2 = this.SW;
                double horizontalGutter = 0;
                double verticalGutter2 = 0;
                double num12 = Convert.ToDouble(base.Request.Params["nonHeight"]);
                double num13 = Convert.ToDouble(base.Request.Params["nonWidth"]);
                sH2 = (double)Convert.ToInt32(sH2 * num4 / num3);
                sW2 = (double)Convert.ToInt32(sW2 * num4 / num3);
                horizontalGutter = sH2 - this.HorizontalGutter;
                verticalGutter2 = sW2 - this.VerticalGutter;
                this.ItemHeight = (double)Convert.ToInt32(this.ItemHeight * num4 / num3);
                this.ItemWidth = (double)Convert.ToInt32(this.ItemWidth * num4 / num3);
                num10 = sH2 - num12;
                num11 = sW2 - num13;
                double horizontalGutter1 = 0;
                double verticalGutter3 = 0;
                double itemWidth1 = 0;
                double itemHeight1 = 0;
                if (this.ItemWidth <= this.ItemHeight)
                {
                    itemHeight1 = this.ItemHeight;
                    itemWidth1 = this.ItemWidth;
                }
                else
                {
                    itemHeight1 = this.ItemWidth;
                    itemWidth1 = this.ItemHeight;
                }
                this.row = Convert.ToInt32(num1);
                verticalGutter3 = (itemHeight1 + this.VerticalGutter) * (double)this.col;
                horizontalGutter1 = (itemWidth1 + this.HorizontalGutter) * (double)this.row;
                double num14 = (horizontalGutter - horizontalGutter1) / 2;
                Convert.ToInt32((verticalGutter2 - verticalGutter3) / 2);
                if (this.section_width < verticalGutter3)
                {
                    this.section_width = this.section_width + (verticalGutter3 - this.section_width) + 20;
                }
                if (this.section_height < horizontalGutter1)
                {
                    this.section_height = this.section_height + (horizontalGutter1 - this.section_height) + 20;
                }
                if (verticalGutter2 == verticalGutter3)
                {
                    this.item_width = this.item_width - 2;
                }
                this.phtest.Controls.Add(new LiteralControl("<div style='padding:8px'>"));
                this.phtest.Controls.Add(new LiteralControl(string.Concat("<table cellpadding='1px' cellspacing='1px'  style='width: ", sW2, "px; border:solid 1px black;'>")));
                this.phtest.Controls.Add(new LiteralControl("<tr><td>"));
                if (string.Compare(this.selected, "both", true) == 0 || string.Compare(this.selected, "restriction", true) == 0)
                {
                    this.phtest.Controls.Add(new LiteralControl("<table align='center' cellpadding='0px' cellspacing='0px' border='0px' height='100%' width='100%'>"));
                    this.phtest.Controls.Add(new LiteralControl("<tr valign='top'>"));
                    this.phtest.Controls.Add(new LiteralControl("<td align='center'>"));
                    ControlCollection controls2 = this.phtest.Controls;
                    object[] objArray5 = new object[] { "<div style='width:", num11, "px;height:", num10, "px;border: dotted 1px black;' align='center'>" };
                    controls2.Add(new LiteralControl(string.Concat(objArray5)));
                }
                this.phtest.Controls.Add(new LiteralControl("<table align='center' cellpadding='0px' cellspacing='0px' border='0px' height='100%' width='100%'>"));
                this.phtest.Controls.Add(new LiteralControl("<tr valign='top'>"));
                this.phtest.Controls.Add(new LiteralControl("<td align='center'>"));
                int num15 = 1;
                for (int k = 0; k < this.row; k++)
                {
                    this.phtest.Controls.Add(new LiteralControl(string.Concat("<table align='center' cellpadding='0px' cellspacing='0px' width='", verticalGutter3, "px' border='0px'>")));
                    this.phtest.Controls.Add(new LiteralControl("<tr valign='top'>"));
                    for (int l = 0; l < this.col; l++)
                    {
                        string str3 = "black";
                        string str4 = num15.ToString();
                        string str5 = "";
                        if (num < num15)
                        {
                            str3 = "white";
                            str4 = "";
                            str5 = "";
                        }
                        ControlCollection controlCollections2 = this.phtest.Controls;
                        object[] verticalGutter4 = new object[] { "<td align='center' width='", itemHeight1 + this.VerticalGutter, "px' Height='", itemWidth1 + this.HorizontalGutter, "' style='vertical-align:middle;'>" };
                        controlCollections2.Add(new LiteralControl(string.Concat(verticalGutter4)));
                        ControlCollection controls3 = this.phtest.Controls;
                        object[] objArray6 = new object[] { "<div style='width:", itemHeight1, "px; height:", itemWidth1, "px; border: solid 1px ", str3, ";", str5, "'>&nbsp;", str4, "</div>" };
                        controls3.Add(new LiteralControl(string.Concat(objArray6)));
                        this.phtest.Controls.Add(new LiteralControl("</td>"));
                        num15++;
                    }
                    this.phtest.Controls.Add(new LiteralControl("</tr>"));
                    this.phtest.Controls.Add(new LiteralControl("</table>"));
                }
                this.phtest.Controls.Add(new LiteralControl("</td>"));
                this.phtest.Controls.Add(new LiteralControl("</tr>"));
                this.phtest.Controls.Add(new LiteralControl("</table>"));
                if (string.Compare(this.selected, "both", true) == 0 || string.Compare(this.selected, "restriction", true) == 0)
                {
                    this.phtest.Controls.Add(new LiteralControl("</div>"));
                    this.phtest.Controls.Add(new LiteralControl("</td>"));
                    this.phtest.Controls.Add(new LiteralControl("</tr>"));
                    this.phtest.Controls.Add(new LiteralControl("</table>"));
                }
                this.phtest.Controls.Add(new LiteralControl("</td></tr>"));
                this.phtest.Controls.Add(new LiteralControl("</table>"));
                this.phtest.Controls.Add(new LiteralControl("</div>"));
            }
            if (this.section_height == this.item_height && this.section_width == this.item_width)
            {
                this.add_contents(this.phlayout);
                return;
            }
            if (this.section_height != this.item_height && this.section_width != this.item_width)
            {
                this.width = 98;
                this.phlayout.Controls.Add(new LiteralControl("<table border=0 style='border:solid 1px black' align=center cellpadding=0 width=38% height=200px cellspacing=0>"));
                this.phlayout.Controls.Add(new LiteralControl("<tr height=5px><td>"));
                this.phlayout.Controls.Add(new LiteralControl("<img src=images/invis.gif height=5px  border=0/>"));
                this.phlayout.Controls.Add(new LiteralControl("</td></tr>"));
                this.phlayout.Controls.Add(new LiteralControl("<tr><td>"));
                this.add_contents(this.phlayout);
                this.phlayout.Controls.Add(new LiteralControl("</td></tr>"));
                this.phlayout.Controls.Add(new LiteralControl("<tr height=5px><td>"));
                this.phlayout.Controls.Add(new LiteralControl("<img src=images/invis.gif height=5px  border=0/>"));
                this.phlayout.Controls.Add(new LiteralControl("</td></tr>"));
                this.phlayout.Controls.Add(new LiteralControl("</table>"));
                return;
            }
            if (this.type != "portrait")
            {
                this.width = 96;
                this.phlayout.Controls.Add(new LiteralControl("<table border=0 style='border:solid 1px black' align=center cellpadding=0 width=60% height=400px cellspacing=0>"));
                this.phlayout.Controls.Add(new LiteralControl("<tr><td><table align=center cellpadding=0 width=100% cellspacing=0><tr>"));
                this.phlayout.Controls.Add(new LiteralControl("<td width=2%><img src=images/invis.gif height=100% width=100% border=0/></td>"));
                this.phlayout.Controls.Add(new LiteralControl(" <td>"));
                this.add_contents(this.phlayout);
                this.phlayout.Controls.Add(new LiteralControl(" </td>"));
                this.phlayout.Controls.Add(new LiteralControl("<td width=2%><img src=images/invis.gif height=100% width=100% border=0/></td>"));
                this.phlayout.Controls.Add(new LiteralControl("</table>"));
                return;
            }
            this.width = 100;
            this.phlayout.Controls.Add(new LiteralControl("<table border=0 style='border:solid 1px black' align=center cellpadding=0 width=60% height=400px cellspacing=0>"));
            this.phlayout.Controls.Add(new LiteralControl("<tr height=5px><td>"));
            this.phlayout.Controls.Add(new LiteralControl("<img src=images/invis.gif height=5px  border=0/>"));
            this.phlayout.Controls.Add(new LiteralControl("</td></tr>"));
            this.phlayout.Controls.Add(new LiteralControl("<tr><td>"));
            this.add_contents(this.phlayout);
            this.phlayout.Controls.Add(new LiteralControl("</td></tr>"));
            this.phlayout.Controls.Add(new LiteralControl("<tr height=5px><td>"));
            this.phlayout.Controls.Add(new LiteralControl("<img src=images/invis.gif height=5px  border=0/>"));
            this.phlayout.Controls.Add(new LiteralControl("</td></tr>"));
            this.phlayout.Controls.Add(new LiteralControl("</table>"));
        }

        public PlaceHolder test(PlaceHolder phtest)
        {
            ControlCollection controls = phtest.Controls;
            object[] sectionWidth = new object[] { "<div style='width: ", this.section_width, "px; height: ", this.section_height, "; border: solid 1px blue;' align=left>" };
            controls.Add(new LiteralControl(string.Concat(sectionWidth)));
            for (int i = 0; i < this.row; i++)
            {
                this.phlayout.Controls.Add(new LiteralControl("<div>"));
                for (int j = 0; j < this.col; j++)
                {
                    ControlCollection controlCollections = this.phlayout.Controls;
                    object[] itemWidth = new object[] { "<div style='width:", this.item_width, "; height:", this.item_height, "; border: solid 1px red; float: left'>" };
                    controlCollections.Add(new LiteralControl(string.Concat(itemWidth)));
                    this.phlayout.Controls.Add(new LiteralControl("&nbsp;"));
                    this.phlayout.Controls.Add(new LiteralControl("</div>"));
                }
                this.phlayout.Controls.Add(new LiteralControl("</br>"));
                this.phlayout.Controls.Add(new LiteralControl("</div>"));
            }
            phtest.Controls.Add(new LiteralControl("</div>"));
            return phtest;
        }
    }
}
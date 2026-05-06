using nmsCommon;
using nmsLanguage;
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
    public partial class print_layout : System.Web.UI.Page, IRequiresSessionState
    {
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

        private int dblsidelitho;

        private string border = "solid";

        private string selected = string.Empty;

        private Global gloobj = new Global();

        public string strImagepath;

        private int IsChkTumble;

        private double SH;

        private double SW;

        private double IW;

        private double IH;

        private double PercentageForDivide;

        private double PercentageForShow;

        public languageClass objLanguage = new languageClass();

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

        public print_layout()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            object[] itemWidth;
            this.strImagepath = global.imagePath();
            this.gloobj.setpagename("estimate");
            this.SectionTotalHeight = (base.Request.Params["SH"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["SH"].ToString()));
            this.SectionTotalWeight = (base.Request.Params["SW"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["SW"].ToString()));
            this.item_width = (base.Request.Params["IW"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["IW"].ToString()));
            this.item_height = (base.Request.Params["IH"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["IH"].ToString()));
            this.type = base.Request.Params["type"].ToString();
            this.selected = base.Request.Params["selected"].ToString();
            this.IsChkTumble = Convert.ToInt32(base.Request.Params["IsChkTumble"]);
            this.row = (base.Request.Params["row"].ToString() == "" ? 0 : Convert.ToInt32(base.Request.Params["row"].ToString()));
            this.col = (base.Request.Params["col"].ToString() == "" ? 0 : Convert.ToInt32(base.Request.Params["col"].ToString()));
            this.HorizontalGutter = (base.Request.Params["hg"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["hg"].ToString()));
            this.VerticalGutter = (base.Request.Params["vg"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["vg"].ToString()));
            this.SW = (base.Request.Params["SW"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["SW"].ToString()));
            this.SH = (base.Request.Params["SH"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["SH"].ToString()));
            this.IH = (base.Request.Params["IH"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["IH"].ToString()));
            this.IW = (base.Request.Params["IW"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["IW"].ToString()));
            if (this.type == "manual")
            {
                this.tblMain.Style.Add("display", "none");
                this.tblNew.Style.Add("display", "block");
            }
            else
            {
                this.tblMain.Style.Add("display", "inline");
                this.tblNew.Style.Add("display", "none");
            }
            if (this.SW < 150)
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
            this.section_width = this.SW + (double)(this.col * 2);
            this.section_height = this.SH + (double)(this.row * 2);
            this.ItemHeight = this.IH;
            this.ItemWidth = this.IW;
            if (base.Request.Params["dblside"] != null)
            {
                this.dblsidelitho = Convert.ToInt32(base.Request.Params["dblside"]);
            }
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
            if (this.type != "landscape")
            {
                double num = 0;
                double num1 = 0;
                double sH = this.SH + (double)(this.row * 2);
                double sW = this.SW + (double)(this.col * 2);
                double itemHeight = 0;
                double itemWidth1 = 0;
                if (this.ItemHeight < this.ItemWidth)
                {
                    double itemHeight1 = this.ItemHeight;
                    this.ItemHeight = this.ItemWidth;
                    this.ItemWidth = itemHeight1;
                }
                itemHeight = (this.ItemHeight + this.HorizontalGutter) * (double)this.row + (double)(this.row * 2);
                itemWidth1 = (this.ItemWidth + this.VerticalGutter) * (double)this.col + (double)this.col;
                if (this.IsChkTumble == 1 && this.dblsidelitho == 1)
                {
                    sH = sH * 2;
                }
                else if (this.dblsidelitho == 1)
                {
                    sW = sW * 2;
                }
                ControlCollection controls = this.phtest.Controls;
                itemWidth = new object[] { "<div  style='width: ", sW, "px; height: ", sH, "px;border:solid 1px black;'>" };
                controls.Add(new LiteralControl(string.Concat(itemWidth)));
                if (string.Compare(this.selected, "both", true) == 0 || string.Compare(this.selected, "restriction", true) == 0)
                {
                    double num2 = Convert.ToDouble(base.Request.Params["nonHeight"]) * 2;
                    double num3 = Convert.ToDouble(base.Request.Params["nonWidth"]) * 2;
                    num = sH - num2;
                    num1 = sW - num3;
                    this.phtest.Controls.Add(new LiteralControl("<table align='center' cellpadding='0px' cellspacing='0px'  height='100%' width='100%'>"));
                    this.phtest.Controls.Add(new LiteralControl("<tr valign='middle'>"));
                    this.phtest.Controls.Add(new LiteralControl("<td align='center'>"));
                    ControlCollection controlCollections = this.phtest.Controls;
                    itemWidth = new object[] { "<div style='width:", num1, "px;height:", num, "px;border: dotted 1px black;' align='center'>" };
                    controlCollections.Add(new LiteralControl(string.Concat(itemWidth)));
                }
                if (this.dblsidelitho != 1)
                {
                    this.phtest.Controls.Add(new LiteralControl("<table valign='top' cellpadding='0px' cellspacing='0px' border='0' height='100%' width='100%'>"));
                    this.phtest.Controls.Add(new LiteralControl("<tr>"));
                    ControlCollection controls1 = this.phtest.Controls;
                    itemWidth = new object[] { "<td align='center' width='", itemWidth1, "px' height='", itemHeight, "px'>" };
                    controls1.Add(new LiteralControl(string.Concat(itemWidth)));
                    for (int i = 0; i < this.row; i++)
                    {
                        if (i == this.row - 1)
                        {
                            this.VerticalGutter = 0;
                        }
                        this.phtest.Controls.Add(new LiteralControl("<table valign='top' cellpadding='0px' cellspacing='0px' border=0px'>"));
                        this.phtest.Controls.Add(new LiteralControl("<tr valign='top'>"));
                        for (int j = 0; j < this.col; j++)
                        {
                            if (j != this.col - 1)
                            {
                                ControlCollection controlCollections1 = this.phtest.Controls;
                                itemWidth = new object[] { "<td width='", this.ItemWidth + this.HorizontalGutter, "px' Height='", this.ItemHeight + this.VerticalGutter, "'>" };
                                controlCollections1.Add(new LiteralControl(string.Concat(itemWidth)));
                            }
                            else
                            {
                                ControlCollection controls2 = this.phtest.Controls;
                                itemWidth = new object[] { "<td width='", this.ItemWidth, "px' Height='", this.ItemHeight + this.VerticalGutter, "'>" };
                                controls2.Add(new LiteralControl(string.Concat(itemWidth)));
                            }
                            ControlCollection controlCollections2 = this.phtest.Controls;
                            itemWidth = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 1px black; text-align:center;'></div>" };
                            controlCollections2.Add(new LiteralControl(string.Concat(itemWidth)));
                            this.phtest.Controls.Add(new LiteralControl("</td>"));
                        }
                        this.phtest.Controls.Add(new LiteralControl("</tr>"));
                        this.phtest.Controls.Add(new LiteralControl("</table>"));
                    }
                    this.phtest.Controls.Add(new LiteralControl("</td>"));
                }
                else
                {
                    if (this.col > 1 && this.col % 2 != 0 && this.IsChkTumble == 0)
                    {
                        this.col = this.col - 1;
                    }
                    int num4 = 0;
                    this.phtest.Controls.Add(new LiteralControl("<table valign='top' cellpadding='0px' cellspacing='0px'  height='100%' width='100%'>"));
                    this.phtest.Controls.Add(new LiteralControl("<tr>"));
                    ControlCollection controls3 = this.phtest.Controls;
                    itemWidth = new object[] { "<td align='center' width='", itemWidth1, "px' height='", itemHeight, "px'>" };
                    controls3.Add(new LiteralControl(string.Concat(itemWidth)));
                    for (int k = 0; k < this.row; k++)
                    {
                        if (k == this.row - 1)
                        {
                            this.VerticalGutter = 0;
                        }
                        this.phtest.Controls.Add(new LiteralControl("<table valign='top' cellpadding='0px' cellspacing='1px' border=0px'>"));
                        this.phtest.Controls.Add(new LiteralControl("<tr valign='top'>"));
                        for (int l = 0; l < this.col; l++)
                        {
                            if (l != this.col - 1)
                            {
                                ControlCollection controlCollections3 = this.phtest.Controls;
                                itemWidth = new object[] { "<td width='", this.ItemWidth + this.HorizontalGutter, "px' Height='", this.ItemHeight + this.VerticalGutter, "'>" };
                                controlCollections3.Add(new LiteralControl(string.Concat(itemWidth)));
                            }
                            else
                            {
                                ControlCollection controls4 = this.phtest.Controls;
                                itemWidth = new object[] { "<td width='", this.ItemWidth, "px' Height='", this.ItemHeight + this.VerticalGutter, "'>" };
                                controls4.Add(new LiteralControl(string.Concat(itemWidth)));
                            }
                            if (this.IsChkTumble == 1)
                            {
                                if (num4 % 2 != 0)
                                {
                                    ControlCollection controlCollections4 = this.phtest.Controls;
                                    itemWidth = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black;background-color:#C5D9F1; color:#000000; font-size:small; text-align:center; font-weight:bold;'>B</div>" };
                                    controlCollections4.Add(new LiteralControl(string.Concat(itemWidth)));
                                }
                                else
                                {
                                    ControlCollection controls5 = this.phtest.Controls;
                                    itemWidth = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#1F497D; color:#ffffff; font-size:small; text-align:center; font-weight:bold;'>F</div>" };
                                    controls5.Add(new LiteralControl(string.Concat(itemWidth)));
                                }
                            }
                            else if (this.col > 1)
                            {
                                if (l >= this.col / 2)
                                {
                                    ControlCollection controlCollections5 = this.phtest.Controls;
                                    itemWidth = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#C5D9F1; color:#000000; font-size:small; text-align:center; font-weight:bold;'>B</div>" };
                                    controlCollections5.Add(new LiteralControl(string.Concat(itemWidth)));
                                }
                                else
                                {
                                    ControlCollection controls6 = this.phtest.Controls;
                                    itemWidth = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#1F497D; color:#ffffff; font-size:small; text-align:center; font-weight:bold;'>F</div>" };
                                    controls6.Add(new LiteralControl(string.Concat(itemWidth)));
                                }
                            }
                            else if (l >= this.col)
                            {
                                ControlCollection controlCollections6 = this.phtest.Controls;
                                itemWidth = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#C5D9F1; color:#000000; font-size:small; text-align:center; font-weight:bold;'>B</div>" };
                                controlCollections6.Add(new LiteralControl(string.Concat(itemWidth)));
                            }
                            else
                            {
                                ControlCollection controls7 = this.phtest.Controls;
                                itemWidth = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#1F497D; color:#ffffff; font-size:small; text-align:center; font-weight:bold;'>F</div>" };
                                controls7.Add(new LiteralControl(string.Concat(itemWidth)));
                            }
                            this.phtest.Controls.Add(new LiteralControl("</td>"));
                        }
                        num4++;
                        this.phtest.Controls.Add(new LiteralControl("</tr>"));
                        this.phtest.Controls.Add(new LiteralControl("</table>"));
                    }
                    this.phtest.Controls.Add(new LiteralControl("</td>"));
                    this.HorizontalGutter = (base.Request.Params["hg"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["hg"].ToString()));
                    this.VerticalGutter = (base.Request.Params["vg"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["vg"].ToString()));
                    if (this.IsChkTumble != 1)
                    {
                        ControlCollection controlCollections7 = this.phtest.Controls;
                        itemWidth = new object[] { "<td width='5px' Height='", (this.ItemHeight + this.VerticalGutter) * (double)this.row, "px' > <div style='float:left;border-right: dashed 1px;display: inline; height: ", (this.ItemHeight + this.VerticalGutter) * (double)this.row, "px;'></div></td>" };
                        controlCollections7.Add(new LiteralControl(string.Concat(itemWidth)));
                        ControlCollection controls8 = this.phtest.Controls;
                        itemWidth = new object[] { "<td align='center' width='", itemWidth1, "px' height='", itemHeight, "px'>" };
                        controls8.Add(new LiteralControl(string.Concat(itemWidth)));
                    }
                    else
                    {
                        this.phtest.Controls.Add(new LiteralControl("</tr><tr>"));
                        ControlCollection controlCollections8 = this.phtest.Controls;
                        itemWidth = new object[] { "<td align='center' style='border-top: dashed 1px;' width='", itemWidth1, "px' height='", itemHeight, "px'>" };
                        controlCollections8.Add(new LiteralControl(string.Concat(itemWidth)));
                    }
                    int num5 = 0;
                    for (int m = 0; m < this.row; m++)
                    {
                        if (m == this.row - 1)
                        {
                            this.VerticalGutter = 0;
                        }
                        this.phtest.Controls.Add(new LiteralControl("<table valign='top' cellpadding='0px' cellspacing='1px' border=0px'>"));
                        this.phtest.Controls.Add(new LiteralControl("<tr valign='top'>"));
                        for (int n = 0; n < this.col; n++)
                        {
                            if (n != this.col - 1)
                            {
                                ControlCollection controls9 = this.phtest.Controls;
                                itemWidth = new object[] { "<td width='", this.ItemWidth + this.HorizontalGutter, "px' Height='", this.ItemHeight + this.VerticalGutter, "'>" };
                                controls9.Add(new LiteralControl(string.Concat(itemWidth)));
                            }
                            else
                            {
                                ControlCollection controlCollections9 = this.phtest.Controls;
                                itemWidth = new object[] { "<td width='", this.ItemWidth, "px' Height='", this.ItemHeight + this.VerticalGutter, "'>" };
                                controlCollections9.Add(new LiteralControl(string.Concat(itemWidth)));
                            }
                            if (this.IsChkTumble == 1)
                            {
                                if (num5 % 2 == 0)
                                {
                                    ControlCollection controls10 = this.phtest.Controls;
                                    itemWidth = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#C5D9F1; color:#000000; font-size:small; text-align:center; font-weight:bold;'>B</div>" };
                                    controls10.Add(new LiteralControl(string.Concat(itemWidth)));
                                }
                                else
                                {
                                    ControlCollection controlCollections10 = this.phtest.Controls;
                                    itemWidth = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#1F497D; color:#ffffff; font-size:small; text-align:center; font-weight:bold;'>F</div>" };
                                    controlCollections10.Add(new LiteralControl(string.Concat(itemWidth)));
                                }
                            }
                            else if (this.col > 1)
                            {
                                if (n < this.col / 2)
                                {
                                    ControlCollection controls11 = this.phtest.Controls;
                                    itemWidth = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#1F497D; color:#ffffff; font-size:small; text-align:center; font-weight:bold;'>F</div>" };
                                    controls11.Add(new LiteralControl(string.Concat(itemWidth)));
                                }
                                else
                                {
                                    ControlCollection controlCollections11 = this.phtest.Controls;
                                    itemWidth = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black;background-color:#C5D9F1; color:#000000; font-size:small; text-align:center; font-weight:bold;'>B</div>" };
                                    controlCollections11.Add(new LiteralControl(string.Concat(itemWidth)));
                                }
                            }
                            else if (n < this.col)
                            {
                                ControlCollection controls12 = this.phtest.Controls;
                                itemWidth = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#1F497D; color:#ffffff; font-size:small; text-align:center; font-weight:bold;'>F</div>" };
                                controls12.Add(new LiteralControl(string.Concat(itemWidth)));
                            }
                            else
                            {
                                ControlCollection controlCollections12 = this.phtest.Controls;
                                itemWidth = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black;background-color:#C5D9F1; color:#000000; font-size:small; text-align:center; font-weight:bold;'>B</div>" };
                                controlCollections12.Add(new LiteralControl(string.Concat(itemWidth)));
                            }
                            this.phtest.Controls.Add(new LiteralControl("</td>"));
                        }
                        num5++;
                        this.phtest.Controls.Add(new LiteralControl("</tr>"));
                        this.phtest.Controls.Add(new LiteralControl("</table>"));
                    }
                    this.phtest.Controls.Add(new LiteralControl("</td>"));
                }
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
                return;
            }
            double sH1 = this.SH + (double)(this.row * 2);
            double sW1 = this.SW + (double)(this.col * 2);
            double sH2 = this.SH - this.HorizontalGutter;
            double sW2 = this.SW - this.VerticalGutter;
            double itemHeight2 = 0;
            double itemWidth2 = 0;
            if (this.ItemWidth < this.ItemHeight)
            {
                double itemWidth3 = this.ItemWidth;
                this.ItemWidth = this.ItemHeight;
                this.ItemHeight = itemWidth3;
            }
            itemWidth2 = (this.ItemWidth + this.VerticalGutter) * (double)this.col + (double)(this.col * 2);
            itemHeight2 = (this.ItemHeight + this.HorizontalGutter) * (double)this.row + (double)(this.row * 2);
            double num6 = (sH2 - itemHeight2) / 2;
            Convert.ToInt32((sW2 - itemWidth2) / 2);
            double num7 = 0;
            double num8 = 0;
            if (this.IsChkTumble == 1 && this.dblsidelitho == 1)
            {
                sH1 = sH1 * 2 + 5;
            }
            else if (this.dblsidelitho == 1)
            {
                sW1 = sW1 * 2 + 5;
            }
            ControlCollection controls13 = this.phtest.Controls;
            itemWidth = new object[] { "<div style='width: ", sW1, "px; height: ", sH1, "px;border:solid 1px black;'>" };
            controls13.Add(new LiteralControl(string.Concat(itemWidth)));
            if (string.Compare(this.selected, "both", true) == 0 || string.Compare(this.selected, "restriction", true) == 0)
            {
                double num9 = Convert.ToDouble(base.Request.Params["nonHeight"]) * 2;
                double num10 = Convert.ToDouble(base.Request.Params["nonWidth"]) * 2;
                num7 = sH1 - num9;
                num8 = sW1 - num10;
                double num11 = (sH1 - num7) / 2;
                double num12 = (sW1 - num8) / 2;
                this.phtest.Controls.Add(new LiteralControl("<table align='center' cellpadding='0px' cellspacing='0px' border='0px' height='100%' width='100%'>"));
                this.phtest.Controls.Add(new LiteralControl("<tr valign='middle'>"));
                this.phtest.Controls.Add(new LiteralControl("<td align='center'>"));
                ControlCollection controlCollections13 = this.phtest.Controls;
                object[] objArray = new object[] { "<div style='width:", num8, "px;height:", num7, "px;border: dotted 1px black;' align='center'>" };
                controlCollections13.Add(new LiteralControl(string.Concat(objArray)));
            }
            if (this.dblsidelitho != 1)
            {
                this.phtest.Controls.Add(new LiteralControl("<table valign='top' cellpadding='0px' cellspacing='0px' border='0px' height='100%' width='100%'>"));
                this.phtest.Controls.Add(new LiteralControl("<tr>"));
                ControlCollection controls14 = this.phtest.Controls;
                object[] objArray1 = new object[] { "<td align='center' width='", itemWidth2, "px' height='", itemHeight2, "px'>" };
                controls14.Add(new LiteralControl(string.Concat(objArray1)));
                for (int o = 0; o < this.row; o++)
                {
                    this.phtest.Controls.Add(new LiteralControl("<table valign='top' cellpadding='0px' cellspacing='0px' border='0px'>"));
                    this.phtest.Controls.Add(new LiteralControl("<tr valign='top'>"));
                    if (o == this.row - 1)
                    {
                        this.HorizontalGutter = 0;
                    }
                    for (int p = 0; p < this.col; p++)
                    {
                        if (p != this.col - 1)
                        {
                            ControlCollection controlCollections14 = this.phtest.Controls;
                            object[] objArray2 = new object[] { "<td width='", this.ItemWidth + this.VerticalGutter, "px' Height='", this.ItemHeight + this.HorizontalGutter, "'>" };
                            controlCollections14.Add(new LiteralControl(string.Concat(objArray2)));
                        }
                        else
                        {
                            ControlCollection controls15 = this.phtest.Controls;
                            object[] objArray3 = new object[] { "<td width='", this.ItemWidth, "px' Height='", this.ItemHeight + this.HorizontalGutter, "'>" };
                            controls15.Add(new LiteralControl(string.Concat(objArray3)));
                        }
                        ControlCollection controlCollections15 = this.phtest.Controls;
                        itemWidth = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 1px black;'>&nbsp;</div>" };
                        controlCollections15.Add(new LiteralControl(string.Concat(itemWidth)));
                        this.phtest.Controls.Add(new LiteralControl("</td>"));
                    }
                    this.phtest.Controls.Add(new LiteralControl("</tr>"));
                    this.phtest.Controls.Add(new LiteralControl("</table>"));
                }
                this.phtest.Controls.Add(new LiteralControl("</td>"));
                this.phtest.Controls.Add(new LiteralControl("</tr>"));
            }
            else
            {
                if (this.IsChkTumble == 0)
                {
                    if (this.col > 1 && this.col % 2 != 0)
                    {
                        this.col = this.col - 1;
                    }
                    if (this.row > 1 && this.row % 2 != 0)
                    {
                        this.row = this.row - 1;
                    }
                }
                this.phtest.Controls.Add(new LiteralControl("<table valign='top' cellpadding='0px' cellspacing='0px' border='0px' height='100%' width='100%'>"));
                this.phtest.Controls.Add(new LiteralControl("<tr>"));
                ControlCollection controls16 = this.phtest.Controls;
                object[] objArray4 = new object[] { "<td align='center' width='", itemWidth2, "px' height='", itemHeight2, "px'>" };
                controls16.Add(new LiteralControl(string.Concat(objArray4)));
                int num13 = 0;
                for (int q = 0; q < this.row; q++)
                {
                    if (q == this.row - 1)
                    {
                        this.HorizontalGutter = 0;
                    }
                    this.phtest.Controls.Add(new LiteralControl("<table valign='top' cellpadding='0px' cellspacing='1px'  border='0px'>"));
                    this.phtest.Controls.Add(new LiteralControl("<tr valign='top'>"));
                    for (int r = 0; r < this.col; r++)
                    {
                        if (r != this.col - 1)
                        {
                            ControlCollection controlCollections16 = this.phtest.Controls;
                            object[] itemWidth4 = new object[] { "<td width='", this.ItemWidth + this.VerticalGutter, "px' Height='", this.ItemHeight + this.HorizontalGutter, "'>" };
                            controlCollections16.Add(new LiteralControl(string.Concat(itemWidth4)));
                        }
                        else
                        {
                            ControlCollection controls17 = this.phtest.Controls;
                            object[] itemWidth5 = new object[] { "<td width='", this.ItemWidth, "px' Height='", this.ItemHeight + this.HorizontalGutter, "'>" };
                            controls17.Add(new LiteralControl(string.Concat(itemWidth5)));
                        }
                        if (this.IsChkTumble == 1)
                        {
                            if (num13 % 2 != 0)
                            {
                                ControlCollection controlCollections17 = this.phtest.Controls;
                                object[] objArray5 = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#C5D9F1; color:#000000; font-size:small; text-align:center; font-weight:bold;'>B</div>" };
                                controlCollections17.Add(new LiteralControl(string.Concat(objArray5)));
                            }
                            else
                            {
                                ControlCollection controls18 = this.phtest.Controls;
                                object[] itemWidth6 = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#1F497D; color:#ffffff; font-size:small; text-align:center; font-weight:bold;'>F</div>" };
                                controls18.Add(new LiteralControl(string.Concat(itemWidth6)));
                            }
                        }
                        else if (this.col > 1)
                        {
                            if (r >= this.col / 2)
                            {
                                ControlCollection controlCollections18 = this.phtest.Controls;
                                object[] objArray6 = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#C5D9F1; color:#000000; font-size:small; text-align:center; font-weight:bold;'>B</div>" };
                                controlCollections18.Add(new LiteralControl(string.Concat(objArray6)));
                            }
                            else
                            {
                                ControlCollection controls19 = this.phtest.Controls;
                                object[] itemWidth7 = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#1F497D; color:#ffffff; font-size:small; text-align:center; font-weight:bold;'>F</div>" };
                                controls19.Add(new LiteralControl(string.Concat(itemWidth7)));
                            }
                        }
                        else if (r >= this.col)
                        {
                            ControlCollection controlCollections19 = this.phtest.Controls;
                            object[] objArray7 = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#C5D9F1; color:#000000; font-size:small; text-align:center; font-weight:bold;'>B</div>" };
                            controlCollections19.Add(new LiteralControl(string.Concat(objArray7)));
                        }
                        else
                        {
                            ControlCollection controls20 = this.phtest.Controls;
                            object[] itemWidth8 = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#1F497D; color:#ffffff; font-size:small; text-align:center; font-weight:bold;'>F</div>" };
                            controls20.Add(new LiteralControl(string.Concat(itemWidth8)));
                        }
                        this.phtest.Controls.Add(new LiteralControl("</td>"));
                    }
                    num13++;
                    this.phtest.Controls.Add(new LiteralControl("</tr>"));
                    this.phtest.Controls.Add(new LiteralControl("</table>"));
                }
                this.phtest.Controls.Add(new LiteralControl("</td>"));
                this.HorizontalGutter = (base.Request.Params["hg"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["hg"].ToString()));
                this.VerticalGutter = (base.Request.Params["vg"].ToString() == "" ? 0 : Convert.ToDouble(base.Request.Params["vg"].ToString()));
                int num14 = 0;
                if (this.IsChkTumble != 1)
                {
                    ControlCollection controlCollections20 = this.phtest.Controls;
                    object[] objArray8 = new object[] { "<td width='5px' Height='", itemHeight2, "px'><div style='float:left;border-right: dashed 1px;display: inline; height: ", itemHeight2, "px;'></div></td>" };
                    controlCollections20.Add(new LiteralControl(string.Concat(objArray8)));
                    ControlCollection controls21 = this.phtest.Controls;
                    object[] objArray9 = new object[] { "<td align='center' width='", itemWidth2, "px' height='", itemHeight2, "px'>" };
                    controls21.Add(new LiteralControl(string.Concat(objArray9)));
                }
                else
                {
                    this.phtest.Controls.Add(new LiteralControl("</tr><tr>"));
                    ControlCollection controlCollections21 = this.phtest.Controls;
                    object[] objArray10 = new object[] { "<td align='center' style='border-top: dashed 1px;' width='", itemWidth2, "px' height='", itemHeight2, "px'>" };
                    controlCollections21.Add(new LiteralControl(string.Concat(objArray10)));
                }
                for (int s = 0; s < this.row; s++)
                {
                    if (s == this.row - 1)
                    {
                        this.HorizontalGutter = 0;
                    }
                    this.phtest.Controls.Add(new LiteralControl("<table valign='top' cellpadding='0px' cellspacing='1px' border=0px'>"));
                    this.phtest.Controls.Add(new LiteralControl("<tr valign='top'>"));
                    for (int t = 0; t < this.col; t++)
                    {
                        if (t != this.col - 1)
                        {
                            ControlCollection controls22 = this.phtest.Controls;
                            object[] itemWidth9 = new object[] { "<td width='", this.ItemWidth + this.VerticalGutter, "px' Height='", this.ItemHeight + this.HorizontalGutter, "'>" };
                            controls22.Add(new LiteralControl(string.Concat(itemWidth9)));
                        }
                        else
                        {
                            ControlCollection controlCollections22 = this.phtest.Controls;
                            object[] itemWidth10 = new object[] { "<td width='", this.ItemWidth, "px' Height='", this.ItemHeight + this.HorizontalGutter, "'>" };
                            controlCollections22.Add(new LiteralControl(string.Concat(itemWidth10)));
                        }
                        if (this.IsChkTumble == 1)
                        {
                            if (num14 % 2 != 0)
                            {
                                ControlCollection controls23 = this.phtest.Controls;
                                object[] itemWidth11 = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#C5D9F1; color:#000000; font-size:small; text-align:center; font-weight:bold;'>B</div>" };
                                controls23.Add(new LiteralControl(string.Concat(itemWidth11)));
                            }
                            else
                            {
                                ControlCollection controlCollections23 = this.phtest.Controls;
                                object[] objArray11 = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#1F497D; color:#ffffff; font-size:small; text-align:center; font-weight:bold;'>F</div>" };
                                controlCollections23.Add(new LiteralControl(string.Concat(objArray11)));
                            }
                        }
                        else if (this.col > 1)
                        {
                            if (t < this.col / 2)
                            {
                                ControlCollection controls24 = this.phtest.Controls;
                                object[] itemWidth12 = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#1F497D; color:#ffffff; font-size:small; text-align:center; font-weight:bold;'>F</div>" };
                                controls24.Add(new LiteralControl(string.Concat(itemWidth12)));
                            }
                            else
                            {
                                ControlCollection controlCollections24 = this.phtest.Controls;
                                object[] objArray12 = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#C5D9F1; color:#000000; font-size:small; text-align:center; font-weight:bold;'>B</div>" };
                                controlCollections24.Add(new LiteralControl(string.Concat(objArray12)));
                            }
                        }
                        else if (t > this.col)
                        {
                            ControlCollection controls25 = this.phtest.Controls;
                            object[] itemWidth13 = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#1F497D; color:#ffffff; font-size:small; text-align:center; font-weight:bold;'>F</div>" };
                            controls25.Add(new LiteralControl(string.Concat(itemWidth13)));
                        }
                        else
                        {
                            ControlCollection controlCollections25 = this.phtest.Controls;
                            object[] objArray13 = new object[] { "<div style='width:", this.ItemWidth, "px; height:", this.ItemHeight, "px; border: solid 0px black; background-color:#C5D9F1; color:#000000; font-size:small; text-align:center; font-weight:bold;'>B</div>" };
                            controlCollections25.Add(new LiteralControl(string.Concat(objArray13)));
                        }
                        this.phtest.Controls.Add(new LiteralControl("</td>"));
                    }
                    num14++;
                    this.phtest.Controls.Add(new LiteralControl("</tr>"));
                    this.phtest.Controls.Add(new LiteralControl("</table>"));
                }
                this.phtest.Controls.Add(new LiteralControl("</td></tr>"));
            }
            this.phtest.Controls.Add(new LiteralControl("</table>"));
            if (string.Compare(this.selected, "both", true) == 0 || string.Compare(this.selected, "restriction", true) == 0)
            {
                this.phtest.Controls.Add(new LiteralControl("</div>"));
                this.phtest.Controls.Add(new LiteralControl("</td>"));
                this.phtest.Controls.Add(new LiteralControl("</tr>"));
                this.phtest.Controls.Add(new LiteralControl("</table>"));
            }
            this.phtest.Controls.Add(new LiteralControl("</div>"));


            

        }
    }
}
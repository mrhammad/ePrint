using Chart;
using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.UI;

namespace Reports
{
	public class ChartGenerator : System.Web.UI.Page
	{
		public ChartGenerator()
		{
		}

		private void InitializeComponent()
		{
			base.Load += new EventHandler(this.Page_Load);
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			bool flag;
			Color color;
			Bitmap bitmap;
			base.Response.ContentType = "image/png";
			string item = base.Request.QueryString["chartType"];
			string str = base.Request.QueryString["xValues"];
			string item1 = base.Request.QueryString["yValues"];
			string str1 = base.Request.QueryString["Print"];
			if (item == null)
			{
				item = "";
			}
			if (str1 != null)
			{
				try
				{
					flag = Convert.ToBoolean(str1);
				}
				catch
				{
					flag = false;
				}
			}
			else
			{
				flag = false;
			}
			if (str != null && item1 != null)
			{
				color = (!flag ? Color.FromArgb(255, 253, 244) : Color.White);
				MemoryStream memoryStream = new MemoryStream();
				string str2 = item;
				if (str2 == null || !(str2 == "bar"))
				{
					PieChart pieChart = new PieChart(color);
					pieChart.CollectDataPoints(str.Split("|".ToCharArray()), item1.Split("|".ToCharArray()));
					bitmap = pieChart.Draw();
				}
				else
				{
					BarGraph barGraph = new BarGraph(color)
					{
						VerticalLabel = "$",
						VerticalTickCount = 5,
						ShowLegend = true,
						ShowData = false,
						Height = 400,
						Width = 700
					};
					barGraph.CollectDataPoints(str.Split("|".ToCharArray()), item1.Split("|".ToCharArray()));
					bitmap = barGraph.Draw();
				}
				if (base.Request.UrlReferrer != null && (base.Request.UrlReferrer.Host.ToLower() == Environment.UserDomainName.ToLower() || base.Request.UrlReferrer.Host.ToLower() == "localhost"))
				{
					bitmap.Save(memoryStream, ImageFormat.Png);
					memoryStream.WriteTo(base.Response.OutputStream);
				}
			}
		}
	}
}
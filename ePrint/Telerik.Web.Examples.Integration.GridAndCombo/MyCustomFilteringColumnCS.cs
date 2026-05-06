using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Telerik.Web.Examples.Integration.GridAndCombo
{
	public class MyCustomFilteringColumnCS : GridBoundColumn
	{
		public static string ConnectionString
		{
			get
			{
				return ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
			}
		}

		public MyCustomFilteringColumnCS()
		{
		}

		protected override string GetCurrentFilterValueFromControl(TableCell cell)
		{
			return ((RadComboBox)cell.Controls[0]).Text;
		}

		public static DataTable GetDataTable(string query)
		{
			SqlConnection sqlConnection = new SqlConnection(MyCustomFilteringColumnCS.ConnectionString);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = new SqlCommand(query, sqlConnection)
			};
			DataTable dataTable = new DataTable();
			sqlConnection.Open();
			try
			{
				sqlDataAdapter.Fill(dataTable);
			}
			finally
			{
				sqlConnection.Close();
			}
			return dataTable;
		}

		private void list_ItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
		{
			((RadComboBox)o).DataTextField = this.DataField;
			((RadComboBox)o).DataValueField = this.DataField;
			RadComboBox dataTable = (RadComboBox)o;
			string[] uniqueName = new string[] { "SELECT DISTINCT ", this.UniqueName, " FROM Customers WHERE ", this.UniqueName, " LIKE '", e.Text, "%'" };
			dataTable.DataSource = MyCustomFilteringColumnCS.GetDataTable(string.Concat(uniqueName));
			((RadComboBox)o).DataBind();
		}

		private void list_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
		{
			GridFilteringItem namingContainer = (GridFilteringItem)((RadComboBox)o).NamingContainer;
			if (this.UniqueName == "Index")
			{
				namingContainer.FireCommandEvent("Filter", new Pair("EqualTo", this.UniqueName));
			}
			namingContainer.FireCommandEvent("Filter", new Pair("Contains", this.UniqueName));
		}

		protected override void SetCurrentFilterValueToControl(TableCell cell)
		{
			base.SetCurrentFilterValueToControl(cell);
			RadComboBox item = (RadComboBox)cell.Controls[0];
			if (base.CurrentFilterValue != string.Empty)
			{
				item.Text = base.CurrentFilterValue;
			}
		}

		protected override void SetupFilterControls(TableCell cell)
		{
			base.SetupFilterControls(cell);
			cell.Controls.RemoveAt(0);
			RadComboBox radComboBox = new RadComboBox()
			{
				ID = string.Concat("RadComboBox1", this.UniqueName),
				ShowToggleImage = false,
				Skin = "Office2007",
				EnableLoadOnDemand = true,
				AutoPostBack = true,
				MarkFirstMatch = true,
				Height = Unit.Pixel(100)
			};
			radComboBox.ItemsRequested += new RadComboBoxItemsRequestedEventHandler(this.list_ItemsRequested);
			radComboBox.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(this.list_SelectedIndexChanged);
			cell.Controls.AddAt(0, radComboBox);
			cell.Controls.RemoveAt(1);
		}
	}
}
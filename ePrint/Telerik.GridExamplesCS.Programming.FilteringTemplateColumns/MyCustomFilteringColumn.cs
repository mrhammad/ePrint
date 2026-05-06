using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Telerik.GridExamplesCS.Programming.FilteringTemplateColumns
{
	public class MyCustomFilteringColumn : GridTemplateColumn
	{
		public MyCustomFilteringColumn()
		{
		}

		protected override string GetCurrentFilterValueFromControl(TableCell cell)
		{
			string value = ((RadComboBox)cell.Controls[0]).SelectedItem.Value;
			base.CurrentFilterFunction = (value != "" ? GridKnownFunction.EqualTo : GridKnownFunction.NoFilter);
			return value;
		}

		public DataTable GetDataTable(string queryString)
		{
			SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter()
			{
				SelectCommand = new SqlCommand(queryString, sqlConnection)
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

		private void rcBox_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
		{
			((GridFilteringItem)((RadComboBox)sender).Parent.Parent).FireCommandEvent("Filter", new Pair());
		}

		protected override void SetCurrentFilterValueToControl(TableCell cell)
		{
			if (base.CurrentFilterValue != "")
			{
				((RadComboBox)cell.Controls[0]).Items.FindItemByText(base.CurrentFilterValue).Selected = true;
			}
		}

		protected override void SetupFilterControls(TableCell cell)
		{
			RadComboBox radComboBox = new RadComboBox()
			{
				ID = "DropDownList1",
				Width = Unit.Percentage(100),
				AutoPostBack = true,
				DataTextField = this.DataField,
				DataValueField = this.DataField
			};
			radComboBox.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(this.rcBox_SelectedIndexChanged);
			DataTable dataTable = this.GetDataTable(string.Format("SELECT DISTINCT {0} FROM {1}", this.DataField, "Customers"));
			DataRow dataRow = dataTable.NewRow();
			dataRow[this.DataField] = "";
			dataTable.Rows.InsertAt(dataRow, 0);
			radComboBox.DataSource = dataTable;
			cell.Controls.Add(radComboBox);
		}
	}
}
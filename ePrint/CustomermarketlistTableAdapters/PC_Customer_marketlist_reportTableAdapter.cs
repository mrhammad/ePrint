using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CustomermarketlistTableAdapters
{
	[DataObject(true)]
	[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[DesignerCategory("code")]
	[HelpKeyword("vs.data.TableAdapter")]
	[ToolboxItem(true)]
	public class PC_Customer_marketlist_reportTableAdapter : Component
	{
		private SqlDataAdapter _adapter;

		private SqlConnection _connection;

		private SqlCommand[] _commandCollection;

		private bool _clearBeforeFill;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private SqlDataAdapter Adapter
		{
			get
			{
				if (this._adapter == null)
				{
					this.InitAdapter();
				}
				return this._adapter;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool ClearBeforeFill
		{
			get
			{
				return this._clearBeforeFill;
			}
			set
			{
				this._clearBeforeFill = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected SqlCommand[] CommandCollection
		{
			get
			{
				if (this._commandCollection == null)
				{
					this.InitCommandCollection();
				}
				return this._commandCollection;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal SqlConnection Connection
		{
			get
			{
				if (this._connection == null)
				{
					this.InitConnection();
				}
				return this._connection;
			}
			set
			{
				this._connection = value;
				if (this.Adapter.InsertCommand != null)
				{
					this.Adapter.InsertCommand.Connection = value;
				}
				if (this.Adapter.DeleteCommand != null)
				{
					this.Adapter.DeleteCommand.Connection = value;
				}
				if (this.Adapter.UpdateCommand != null)
				{
					this.Adapter.UpdateCommand.Connection = value;
				}
				for (int i = 0; i < (int)this.CommandCollection.Length; i++)
				{
					if (this.CommandCollection[i] != null)
					{
						this.CommandCollection[i].Connection = value;
					}
				}
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public PC_Customer_marketlist_reportTableAdapter()
		{
			this.ClearBeforeFill = true;
		}

		[DataObjectMethod(DataObjectMethodType.Fill, true)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Fill(Customermarketlist.PC_Customer_marketlist_reportDataTable dataTable, int? companyid)
		{
			this.Adapter.SelectCommand = this.CommandCollection[0];
			if (!companyid.HasValue)
			{
				this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[1].Value = companyid.Value;
			}
			if (this.ClearBeforeFill)
			{
				dataTable.Clear();
			}
			return this.Adapter.Fill(dataTable);
		}

		[DataObjectMethod(DataObjectMethodType.Select, true)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual Customermarketlist.PC_Customer_marketlist_reportDataTable GetData(int? companyid)
		{
			this.Adapter.SelectCommand = this.CommandCollection[0];
			if (!companyid.HasValue)
			{
				this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[1].Value = companyid.Value;
			}
			Customermarketlist.PC_Customer_marketlist_reportDataTable pCCustomerMarketlistReportDataTable = new Customermarketlist.PC_Customer_marketlist_reportDataTable();
			this.Adapter.Fill(pCCustomerMarketlistReportDataTable);
			return pCCustomerMarketlistReportDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitAdapter()
		{
			this._adapter = new SqlDataAdapter();
			DataTableMapping dataTableMapping = new DataTableMapping()
			{
				SourceTable = "Table",
				DataSetTable = "PC_Customer_marketlist_report"
			};
			dataTableMapping.ColumnMappings.Add("Customer", "Customer");
			dataTableMapping.ColumnMappings.Add("ClientID", "ClientID");
			dataTableMapping.ColumnMappings.Add("contactfullname", "contactfullname");
			dataTableMapping.ColumnMappings.Add("contactfirstname", "contactfirstname");
			dataTableMapping.ColumnMappings.Add("contactlastname", "contactlastname");
			dataTableMapping.ColumnMappings.Add("contactstatus", "contactstatus");
			dataTableMapping.ColumnMappings.Add("contactemail", "contactemail");
			dataTableMapping.ColumnMappings.Add("contactphone", "contactphone");
			dataTableMapping.ColumnMappings.Add("BillingAddress", "BillingAddress");
			dataTableMapping.ColumnMappings.Add("BillingAddress2", "BillingAddress2");
			dataTableMapping.ColumnMappings.Add("Billingsuburb", "Billingsuburb");
			dataTableMapping.ColumnMappings.Add("BillingState", "BillingState");
			dataTableMapping.ColumnMappings.Add("BillingPostcode", "BillingPostcode");
			dataTableMapping.ColumnMappings.Add("Billingcountry", "Billingcountry");
			dataTableMapping.ColumnMappings.Add("DeliveryAddress", "DeliveryAddress");
			dataTableMapping.ColumnMappings.Add("DeliveryAddress2", "DeliveryAddress2");
			dataTableMapping.ColumnMappings.Add("Deliverysuburb", "Deliverysuburb");
			dataTableMapping.ColumnMappings.Add("DeliveryState", "DeliveryState");
			dataTableMapping.ColumnMappings.Add("DeliveryPostcode", "DeliveryPostcode");
			dataTableMapping.ColumnMappings.Add("Deliverycountry", "Deliverycountry");
			dataTableMapping.ColumnMappings.Add("Accmanager", "Accmanager");
			dataTableMapping.ColumnMappings.Add("paymentterms", "paymentterms");
			dataTableMapping.ColumnMappings.Add("referralsource", "referralsource");
			dataTableMapping.ColumnMappings.Add("retailexgst", "retailexgst");
			dataTableMapping.ColumnMappings.Add("Gp", "Gp");
			dataTableMapping.ColumnMappings.Add("GPPercentage", "GPPercentage");
			dataTableMapping.ColumnMappings.Add("lastinvoicedate", "lastinvoicedate");
			this._adapter.TableMappings.Add((object)dataTableMapping);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitCommandCollection()
		{
			this._commandCollection = new SqlCommand[] { new SqlCommand() };
			this._commandCollection[0].Connection = this.Connection;
			this._commandCollection[0].CommandText = "dbo.PC_Customer_marketlist_report";
			this._commandCollection[0].CommandType = CommandType.StoredProcedure;
			this._commandCollection[0].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@companyid", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitConnection()
		{
			this._connection = new SqlConnection()
			{
				ConnectionString = ConfigurationManager.ConnectionStrings["CRMConnectionString"].ConnectionString
			};
		}
	}
}
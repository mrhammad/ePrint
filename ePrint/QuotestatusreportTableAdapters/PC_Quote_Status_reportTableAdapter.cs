using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace QuotestatusreportTableAdapters
{
	[DataObject(true)]
	[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[DesignerCategory("code")]
	[HelpKeyword("vs.data.TableAdapter")]
	[ToolboxItem(true)]
	public class PC_Quote_Status_reportTableAdapter : Component
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
		public PC_Quote_Status_reportTableAdapter()
		{
			this.ClearBeforeFill = true;
		}

		[DataObjectMethod(DataObjectMethodType.Fill, true)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Fill(Quotestatusreport.PC_Quote_Status_reportDataTable dataTable, int? companyid)
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
		public virtual Quotestatusreport.PC_Quote_Status_reportDataTable GetData(int? companyid)
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
			Quotestatusreport.PC_Quote_Status_reportDataTable pCQuoteStatusReportDataTable = new Quotestatusreport.PC_Quote_Status_reportDataTable();
			this.Adapter.Fill(pCQuoteStatusReportDataTable);
			return pCQuoteStatusReportDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitAdapter()
		{
			this._adapter = new SqlDataAdapter();
			DataTableMapping dataTableMapping = new DataTableMapping()
			{
				SourceTable = "Table",
				DataSetTable = "PC_Quote_Status_report"
			};
			dataTableMapping.ColumnMappings.Add("centername", "centername");
			dataTableMapping.ColumnMappings.Add("eststatusid", "eststatusid");
			dataTableMapping.ColumnMappings.Add("currentstatus", "currentstatus");
			dataTableMapping.ColumnMappings.Add("dateofstatus", "dateofstatus");
			dataTableMapping.ColumnMappings.Add("quoteno", "quoteno");
			dataTableMapping.ColumnMappings.Add("quoteDate", "quoteDate");
			dataTableMapping.ColumnMappings.Add("invoiceno", "invoiceno");
			dataTableMapping.ColumnMappings.Add("invoicedate", "invoicedate");
			dataTableMapping.ColumnMappings.Add("Customer", "Customer");
			dataTableMapping.ColumnMappings.Add("EstimateItemID", "EstimateItemID");
			dataTableMapping.ColumnMappings.Add("jobtype", "jobtype");
			dataTableMapping.ColumnMappings.Add("qty1", "qty1");
			dataTableMapping.ColumnMappings.Add("subtotal1", "subtotal1");
			dataTableMapping.ColumnMappings.Add("tax1", "tax1");
			dataTableMapping.ColumnMappings.Add("profitmargin1", "profitmargin1");
			dataTableMapping.ColumnMappings.Add("qty2", "qty2");
			dataTableMapping.ColumnMappings.Add("subtotal2", "subtotal2");
			dataTableMapping.ColumnMappings.Add("tax2", "tax2");
			dataTableMapping.ColumnMappings.Add("profitmargin2", "profitmargin2");
			dataTableMapping.ColumnMappings.Add("qty3", "qty3");
			dataTableMapping.ColumnMappings.Add("subtotal3", "subtotal3");
			dataTableMapping.ColumnMappings.Add("tax3", "tax3");
			dataTableMapping.ColumnMappings.Add("profitmargin3", "profitmargin3");
			dataTableMapping.ColumnMappings.Add("qty4", "qty4");
			dataTableMapping.ColumnMappings.Add("subtotal4", "subtotal4");
			dataTableMapping.ColumnMappings.Add("tax4", "tax4");
			dataTableMapping.ColumnMappings.Add("profitmargin4", "profitmargin4");
			dataTableMapping.ColumnMappings.Add("qty5", "qty5");
			dataTableMapping.ColumnMappings.Add("subtotal5", "subtotal5");
			dataTableMapping.ColumnMappings.Add("tax5", "tax5");
			dataTableMapping.ColumnMappings.Add("profitmargin5", "profitmargin5");
			dataTableMapping.ColumnMappings.Add("qty6", "qty6");
			dataTableMapping.ColumnMappings.Add("SubTotal6", "SubTotal6");
			dataTableMapping.ColumnMappings.Add("tax6", "tax6");
			dataTableMapping.ColumnMappings.Add("profitmargin6", "profitmargin6");
			dataTableMapping.ColumnMappings.Add("qty7", "qty7");
			dataTableMapping.ColumnMappings.Add("SubTotal7", "SubTotal7");
			dataTableMapping.ColumnMappings.Add("tax7", "tax7");
			dataTableMapping.ColumnMappings.Add("profitmargin7", "profitmargin7");
			dataTableMapping.ColumnMappings.Add("qty8", "qty8");
			dataTableMapping.ColumnMappings.Add("SubTotal8", "SubTotal8");
			dataTableMapping.ColumnMappings.Add("tax8", "tax8");
			dataTableMapping.ColumnMappings.Add("profitmargin8", "profitmargin8");
			dataTableMapping.ColumnMappings.Add("outstandingamt", "outstandingamt");
			dataTableMapping.ColumnMappings.Add("GP", "GP");
			dataTableMapping.ColumnMappings.Add("GPpercent", "GPpercent");
			dataTableMapping.ColumnMappings.Add("quotecreator", "quotecreator");
			dataTableMapping.ColumnMappings.Add("accountmanager", "accountmanager");
			dataTableMapping.ColumnMappings.Add("jobnumber", "jobnumber");
			this._adapter.TableMappings.Add((object)dataTableMapping);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitCommandCollection()
		{
			this._commandCollection = new SqlCommand[] { new SqlCommand() };
			this._commandCollection[0].Connection = this.Connection;
			this._commandCollection[0].CommandText = "dbo.PC_Quote_Status_report";
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
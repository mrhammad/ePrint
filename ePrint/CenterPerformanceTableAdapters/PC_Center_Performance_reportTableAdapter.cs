using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CenterPerformanceTableAdapters
{
	[DataObject(true)]
	[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[DesignerCategory("code")]
	[HelpKeyword("vs.data.TableAdapter")]
	[ToolboxItem(true)]
	public class PC_Center_Performance_reportTableAdapter : Component
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
		public PC_Center_Performance_reportTableAdapter()
		{
			this.ClearBeforeFill = true;
		}

		[DataObjectMethod(DataObjectMethodType.Fill, true)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Fill(CenterPerformance.PC_Center_Performance_reportDataTable dataTable, int? companyid)
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
		public virtual CenterPerformance.PC_Center_Performance_reportDataTable GetData(int? companyid)
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
			CenterPerformance.PC_Center_Performance_reportDataTable pCCenterPerformanceReportDataTable = new CenterPerformance.PC_Center_Performance_reportDataTable();
			this.Adapter.Fill(pCCenterPerformanceReportDataTable);
			return pCCenterPerformanceReportDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitAdapter()
		{
			this._adapter = new SqlDataAdapter();
			DataTableMapping dataTableMapping = new DataTableMapping()
			{
				SourceTable = "Table",
				DataSetTable = "PC_Center_Performance_report"
			};
			dataTableMapping.ColumnMappings.Add("estimateid", "estimateid");
			dataTableMapping.ColumnMappings.Add("estimateitemid", "estimateitemid");
			dataTableMapping.ColumnMappings.Add("EstimateType", "EstimateType");
			dataTableMapping.ColumnMappings.Add("noofqoutes", "noofqoutes");
			dataTableMapping.ColumnMappings.Add("estsubtotal1", "estsubtotal1");
			dataTableMapping.ColumnMappings.Add("esttax1", "esttax1");
			dataTableMapping.ColumnMappings.Add("estsubtotal2", "estsubtotal2");
			dataTableMapping.ColumnMappings.Add("esttax2", "esttax2");
			dataTableMapping.ColumnMappings.Add("estsubtotal3", "estsubtotal3");
			dataTableMapping.ColumnMappings.Add("esttax3", "esttax3");
			dataTableMapping.ColumnMappings.Add("estsubtotal4", "estsubtotal4");
			dataTableMapping.ColumnMappings.Add("esttax4", "esttax4");
			dataTableMapping.ColumnMappings.Add("estsubtotal5", "estsubtotal5");
			dataTableMapping.ColumnMappings.Add("esttax5", "esttax5");
			dataTableMapping.ColumnMappings.Add("estSubTotal6", "estSubTotal6");
			dataTableMapping.ColumnMappings.Add("esttax6", "esttax6");
			dataTableMapping.ColumnMappings.Add("estSubTotal7", "estSubTotal7");
			dataTableMapping.ColumnMappings.Add("esttax7", "esttax7");
			dataTableMapping.ColumnMappings.Add("estSubTotal8", "estSubTotal8");
			dataTableMapping.ColumnMappings.Add("esttax8", "esttax8");
			dataTableMapping.ColumnMappings.Add("jobsubtotal1", "jobsubtotal1");
			dataTableMapping.ColumnMappings.Add("jobtax1", "jobtax1");
			dataTableMapping.ColumnMappings.Add("jobsubtotal2", "jobsubtotal2");
			dataTableMapping.ColumnMappings.Add("jobtax2", "jobtax2");
			dataTableMapping.ColumnMappings.Add("jobsubtotal3", "jobsubtotal3");
			dataTableMapping.ColumnMappings.Add("jobtax3", "jobtax3");
			dataTableMapping.ColumnMappings.Add("jobsubtotal4", "jobsubtotal4");
			dataTableMapping.ColumnMappings.Add("jobtax4", "jobtax4");
			dataTableMapping.ColumnMappings.Add("jobsubtotal5", "jobsubtotal5");
			dataTableMapping.ColumnMappings.Add("jobtax5", "jobtax5");
			dataTableMapping.ColumnMappings.Add("jobSubTotal6", "jobSubTotal6");
			dataTableMapping.ColumnMappings.Add("jobtax6", "jobtax6");
			dataTableMapping.ColumnMappings.Add("jobSubTotal7", "jobSubTotal7");
			dataTableMapping.ColumnMappings.Add("jobtax7", "jobtax7");
			dataTableMapping.ColumnMappings.Add("jobSubTotal8", "jobSubTotal8");
			dataTableMapping.ColumnMappings.Add("jobtax8", "jobtax8");
			dataTableMapping.ColumnMappings.Add("invsubtotal1", "invsubtotal1");
			dataTableMapping.ColumnMappings.Add("invtax1", "invtax1");
			dataTableMapping.ColumnMappings.Add("invsubtotal2", "invsubtotal2");
			dataTableMapping.ColumnMappings.Add("invtax2", "invtax2");
			dataTableMapping.ColumnMappings.Add("invsubtotal3", "invsubtotal3");
			dataTableMapping.ColumnMappings.Add("invtax3", "invtax3");
			dataTableMapping.ColumnMappings.Add("invsubtotal4", "invsubtotal4");
			dataTableMapping.ColumnMappings.Add("invtax4", "invtax4");
			dataTableMapping.ColumnMappings.Add("invsubtotal5", "invsubtotal5");
			dataTableMapping.ColumnMappings.Add("invtax5", "invtax5");
			dataTableMapping.ColumnMappings.Add("invSubTotal6", "invSubTotal6");
			dataTableMapping.ColumnMappings.Add("invtax6", "invtax6");
			dataTableMapping.ColumnMappings.Add("invSubTotal7", "invSubTotal7");
			dataTableMapping.ColumnMappings.Add("invtax7", "invtax7");
			dataTableMapping.ColumnMappings.Add("invSubTotal8", "invSubTotal8");
			dataTableMapping.ColumnMappings.Add("invtax8", "invtax8");
			dataTableMapping.ColumnMappings.Add("quotesexgst", "quotesexgst");
			dataTableMapping.ColumnMappings.Add("avgquoteval", "avgquoteval");
			dataTableMapping.ColumnMappings.Add("noofjobs", "noofjobs");
			dataTableMapping.ColumnMappings.Add("noofinvoice", "noofinvoice");
			dataTableMapping.ColumnMappings.Add("companyid", "companyid");
			dataTableMapping.ColumnMappings.Add("noofcontact", "noofcontact");
			dataTableMapping.ColumnMappings.Add("noofclient", "noofclient");
			this._adapter.TableMappings.Add((object)dataTableMapping);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitCommandCollection()
		{
			this._commandCollection = new SqlCommand[] { new SqlCommand() };
			this._commandCollection[0].Connection = this.Connection;
			this._commandCollection[0].CommandText = "dbo.PC_Center_Performance_report";
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
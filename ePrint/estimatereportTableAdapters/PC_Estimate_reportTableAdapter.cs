using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace estimatereportTableAdapters
{
	[DataObject(true)]
	[Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[DesignerCategory("code")]
	[HelpKeyword("vs.data.TableAdapter")]
	[ToolboxItem(true)]
	public class PC_Estimate_reportTableAdapter : Component
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
		public PC_Estimate_reportTableAdapter()
		{
			this.ClearBeforeFill = true;
		}

		[DataObjectMethod(DataObjectMethodType.Fill, true)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		[HelpKeyword("vs.data.TableAdapter")]
		public virtual int Fill(estimatereport.PC_Estimate_reportDataTable dataTable, int? companyid, string str1, string str2, string str3, string str4, string str5, string str6, string str7, string str8, string str9, string str10, string str11, string str12, string str13, string str14, string str15, string str16, string str17, string str18, string stragg1, string stragg2, string stragg3, string stragg4, string stragg5, string rdodetail1, string freetext, string StatusIDS, string today, string yest, string startdate, string enddate, string year, string tilldate, string RangeFrom, string RangeTo, string Range, string CustomerID, string includezero)
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
			if (str1 != null)
			{
				this.Adapter.SelectCommand.Parameters[2].Value = str1;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[2].Value = DBNull.Value;
			}
			if (str2 != null)
			{
				this.Adapter.SelectCommand.Parameters[3].Value = str2;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[3].Value = DBNull.Value;
			}
			if (str3 != null)
			{
				this.Adapter.SelectCommand.Parameters[4].Value = str3;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[4].Value = DBNull.Value;
			}
			if (str4 != null)
			{
				this.Adapter.SelectCommand.Parameters[5].Value = str4;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[5].Value = DBNull.Value;
			}
			if (str5 != null)
			{
				this.Adapter.SelectCommand.Parameters[6].Value = str5;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[6].Value = DBNull.Value;
			}
			if (str6 != null)
			{
				this.Adapter.SelectCommand.Parameters[7].Value = str6;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[7].Value = DBNull.Value;
			}
			if (str7 != null)
			{
				this.Adapter.SelectCommand.Parameters[8].Value = str7;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[8].Value = DBNull.Value;
			}
			if (str8 != null)
			{
				this.Adapter.SelectCommand.Parameters[9].Value = str8;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[9].Value = DBNull.Value;
			}
			if (str9 != null)
			{
				this.Adapter.SelectCommand.Parameters[10].Value = str9;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[10].Value = DBNull.Value;
			}
			if (str10 != null)
			{
				this.Adapter.SelectCommand.Parameters[11].Value = str10;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[11].Value = DBNull.Value;
			}
			if (str11 != null)
			{
				this.Adapter.SelectCommand.Parameters[12].Value = str11;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[12].Value = DBNull.Value;
			}
			if (str12 != null)
			{
				this.Adapter.SelectCommand.Parameters[13].Value = str12;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[13].Value = DBNull.Value;
			}
			if (str13 != null)
			{
				this.Adapter.SelectCommand.Parameters[14].Value = str13;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[14].Value = DBNull.Value;
			}
			if (str14 != null)
			{
				this.Adapter.SelectCommand.Parameters[15].Value = str14;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[15].Value = DBNull.Value;
			}
			if (str15 != null)
			{
				this.Adapter.SelectCommand.Parameters[16].Value = str15;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[16].Value = DBNull.Value;
			}
			if (str16 != null)
			{
				this.Adapter.SelectCommand.Parameters[17].Value = str16;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[17].Value = DBNull.Value;
			}
			if (str17 != null)
			{
				this.Adapter.SelectCommand.Parameters[18].Value = str17;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[18].Value = DBNull.Value;
			}
			if (str18 != null)
			{
				this.Adapter.SelectCommand.Parameters[19].Value = str18;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[19].Value = DBNull.Value;
			}
			if (stragg1 != null)
			{
				this.Adapter.SelectCommand.Parameters[20].Value = stragg1;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[20].Value = DBNull.Value;
			}
			if (stragg2 != null)
			{
				this.Adapter.SelectCommand.Parameters[21].Value = stragg2;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[21].Value = DBNull.Value;
			}
			if (stragg3 != null)
			{
				this.Adapter.SelectCommand.Parameters[22].Value = stragg3;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[22].Value = DBNull.Value;
			}
			if (stragg4 != null)
			{
				this.Adapter.SelectCommand.Parameters[23].Value = stragg4;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[23].Value = DBNull.Value;
			}
			if (stragg5 != null)
			{
				this.Adapter.SelectCommand.Parameters[24].Value = stragg5;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[24].Value = DBNull.Value;
			}
			if (rdodetail1 != null)
			{
				this.Adapter.SelectCommand.Parameters[25].Value = rdodetail1;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[25].Value = DBNull.Value;
			}
			if (freetext != null)
			{
				this.Adapter.SelectCommand.Parameters[26].Value = freetext;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[26].Value = DBNull.Value;
			}
			if (StatusIDS != null)
			{
				this.Adapter.SelectCommand.Parameters[27].Value = StatusIDS;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[27].Value = DBNull.Value;
			}
			if (today != null)
			{
				this.Adapter.SelectCommand.Parameters[28].Value = today;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[28].Value = DBNull.Value;
			}
			if (yest != null)
			{
				this.Adapter.SelectCommand.Parameters[29].Value = yest;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[29].Value = DBNull.Value;
			}
			if (startdate != null)
			{
				this.Adapter.SelectCommand.Parameters[30].Value = startdate;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[30].Value = DBNull.Value;
			}
			if (enddate != null)
			{
				this.Adapter.SelectCommand.Parameters[31].Value = enddate;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[31].Value = DBNull.Value;
			}
			if (year != null)
			{
				this.Adapter.SelectCommand.Parameters[32].Value = year;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[32].Value = DBNull.Value;
			}
			if (tilldate != null)
			{
				this.Adapter.SelectCommand.Parameters[33].Value = tilldate;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[33].Value = DBNull.Value;
			}
			if (RangeFrom != null)
			{
				this.Adapter.SelectCommand.Parameters[34].Value = RangeFrom;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[34].Value = DBNull.Value;
			}
			if (RangeTo != null)
			{
				this.Adapter.SelectCommand.Parameters[35].Value = RangeTo;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[35].Value = DBNull.Value;
			}
			if (Range != null)
			{
				this.Adapter.SelectCommand.Parameters[36].Value = Range;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[36].Value = DBNull.Value;
			}
			if (CustomerID != null)
			{
				this.Adapter.SelectCommand.Parameters[37].Value = CustomerID;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[37].Value = DBNull.Value;
			}
			if (includezero != null)
			{
				this.Adapter.SelectCommand.Parameters[38].Value = includezero;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[38].Value = DBNull.Value;
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
		public virtual estimatereport.PC_Estimate_reportDataTable GetData(int? companyid, string str1, string str2, string str3, string str4, string str5, string str6, string str7, string str8, string str9, string str10, string str11, string str12, string str13, string str14, string str15, string str16, string str17, string str18, string stragg1, string stragg2, string stragg3, string stragg4, string stragg5, string rdodetail1, string freetext, string StatusIDS, string today, string yest, string startdate, string enddate, string year, string tilldate, string RangeFrom, string RangeTo, string Range, string CustomerID, string includezero)
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
			if (str1 != null)
			{
				this.Adapter.SelectCommand.Parameters[2].Value = str1;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[2].Value = DBNull.Value;
			}
			if (str2 != null)
			{
				this.Adapter.SelectCommand.Parameters[3].Value = str2;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[3].Value = DBNull.Value;
			}
			if (str3 != null)
			{
				this.Adapter.SelectCommand.Parameters[4].Value = str3;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[4].Value = DBNull.Value;
			}
			if (str4 != null)
			{
				this.Adapter.SelectCommand.Parameters[5].Value = str4;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[5].Value = DBNull.Value;
			}
			if (str5 != null)
			{
				this.Adapter.SelectCommand.Parameters[6].Value = str5;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[6].Value = DBNull.Value;
			}
			if (str6 != null)
			{
				this.Adapter.SelectCommand.Parameters[7].Value = str6;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[7].Value = DBNull.Value;
			}
			if (str7 != null)
			{
				this.Adapter.SelectCommand.Parameters[8].Value = str7;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[8].Value = DBNull.Value;
			}
			if (str8 != null)
			{
				this.Adapter.SelectCommand.Parameters[9].Value = str8;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[9].Value = DBNull.Value;
			}
			if (str9 != null)
			{
				this.Adapter.SelectCommand.Parameters[10].Value = str9;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[10].Value = DBNull.Value;
			}
			if (str10 != null)
			{
				this.Adapter.SelectCommand.Parameters[11].Value = str10;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[11].Value = DBNull.Value;
			}
			if (str11 != null)
			{
				this.Adapter.SelectCommand.Parameters[12].Value = str11;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[12].Value = DBNull.Value;
			}
			if (str12 != null)
			{
				this.Adapter.SelectCommand.Parameters[13].Value = str12;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[13].Value = DBNull.Value;
			}
			if (str13 != null)
			{
				this.Adapter.SelectCommand.Parameters[14].Value = str13;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[14].Value = DBNull.Value;
			}
			if (str14 != null)
			{
				this.Adapter.SelectCommand.Parameters[15].Value = str14;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[15].Value = DBNull.Value;
			}
			if (str15 != null)
			{
				this.Adapter.SelectCommand.Parameters[16].Value = str15;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[16].Value = DBNull.Value;
			}
			if (str16 != null)
			{
				this.Adapter.SelectCommand.Parameters[17].Value = str16;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[17].Value = DBNull.Value;
			}
			if (str17 != null)
			{
				this.Adapter.SelectCommand.Parameters[18].Value = str17;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[18].Value = DBNull.Value;
			}
			if (str18 != null)
			{
				this.Adapter.SelectCommand.Parameters[19].Value = str18;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[19].Value = DBNull.Value;
			}
			if (stragg1 != null)
			{
				this.Adapter.SelectCommand.Parameters[20].Value = stragg1;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[20].Value = DBNull.Value;
			}
			if (stragg2 != null)
			{
				this.Adapter.SelectCommand.Parameters[21].Value = stragg2;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[21].Value = DBNull.Value;
			}
			if (stragg3 != null)
			{
				this.Adapter.SelectCommand.Parameters[22].Value = stragg3;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[22].Value = DBNull.Value;
			}
			if (stragg4 != null)
			{
				this.Adapter.SelectCommand.Parameters[23].Value = stragg4;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[23].Value = DBNull.Value;
			}
			if (stragg5 != null)
			{
				this.Adapter.SelectCommand.Parameters[24].Value = stragg5;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[24].Value = DBNull.Value;
			}
			if (rdodetail1 != null)
			{
				this.Adapter.SelectCommand.Parameters[25].Value = rdodetail1;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[25].Value = DBNull.Value;
			}
			if (freetext != null)
			{
				this.Adapter.SelectCommand.Parameters[26].Value = freetext;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[26].Value = DBNull.Value;
			}
			if (StatusIDS != null)
			{
				this.Adapter.SelectCommand.Parameters[27].Value = StatusIDS;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[27].Value = DBNull.Value;
			}
			if (today != null)
			{
				this.Adapter.SelectCommand.Parameters[28].Value = today;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[28].Value = DBNull.Value;
			}
			if (yest != null)
			{
				this.Adapter.SelectCommand.Parameters[29].Value = yest;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[29].Value = DBNull.Value;
			}
			if (startdate != null)
			{
				this.Adapter.SelectCommand.Parameters[30].Value = startdate;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[30].Value = DBNull.Value;
			}
			if (enddate != null)
			{
				this.Adapter.SelectCommand.Parameters[31].Value = enddate;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[31].Value = DBNull.Value;
			}
			if (year != null)
			{
				this.Adapter.SelectCommand.Parameters[32].Value = year;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[32].Value = DBNull.Value;
			}
			if (tilldate != null)
			{
				this.Adapter.SelectCommand.Parameters[33].Value = tilldate;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[33].Value = DBNull.Value;
			}
			if (RangeFrom != null)
			{
				this.Adapter.SelectCommand.Parameters[34].Value = RangeFrom;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[34].Value = DBNull.Value;
			}
			if (RangeTo != null)
			{
				this.Adapter.SelectCommand.Parameters[35].Value = RangeTo;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[35].Value = DBNull.Value;
			}
			if (Range != null)
			{
				this.Adapter.SelectCommand.Parameters[36].Value = Range;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[36].Value = DBNull.Value;
			}
			if (CustomerID != null)
			{
				this.Adapter.SelectCommand.Parameters[37].Value = CustomerID;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[37].Value = DBNull.Value;
			}
			if (includezero != null)
			{
				this.Adapter.SelectCommand.Parameters[38].Value = includezero;
			}
			else
			{
				this.Adapter.SelectCommand.Parameters[38].Value = DBNull.Value;
			}
			estimatereport.PC_Estimate_reportDataTable pCEstimateReportDataTable = new estimatereport.PC_Estimate_reportDataTable();
			this.Adapter.Fill(pCEstimateReportDataTable);
			return pCEstimateReportDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitAdapter()
		{
			this._adapter = new SqlDataAdapter();
			DataTableMapping dataTableMapping = new DataTableMapping()
			{
				SourceTable = "Table",
				DataSetTable = "PC_Estimate_report"
			};
			dataTableMapping.ColumnMappings.Add("EstimateNumber", "EstimateNumber");
			dataTableMapping.ColumnMappings.Add("Company", "Company");
			dataTableMapping.ColumnMappings.Add("EstimateTitle", "EstimateTitle");
			dataTableMapping.ColumnMappings.Add("CreatedBy", "CreatedBy");
			dataTableMapping.ColumnMappings.Add("CreatedDate", "CreatedDate");
			dataTableMapping.ColumnMappings.Add("dt", "dt");
			dataTableMapping.ColumnMappings.Add("Status", "Status");
			dataTableMapping.ColumnMappings.Add("EstimateDate", "EstimateDate");
			dataTableMapping.ColumnMappings.Add("EstimateValue", "EstimateValue");
			dataTableMapping.ColumnMappings.Add("ItemTitle", "ItemTitle");
			dataTableMapping.ColumnMappings.Add("Description", "Description");
			dataTableMapping.ColumnMappings.Add("Artwork", "Artwork");
			dataTableMapping.ColumnMappings.Add("Colour", "Colour");
			dataTableMapping.ColumnMappings.Add("Size", "Size");
			dataTableMapping.ColumnMappings.Add("Material", "Material");
			dataTableMapping.ColumnMappings.Add("Delivery", "Delivery");
			dataTableMapping.ColumnMappings.Add("Finishing", "Finishing");
			dataTableMapping.ColumnMappings.Add("Notes", "Notes");
			dataTableMapping.ColumnMappings.Add("Instructions", "Instructions");
			dataTableMapping.ColumnMappings.Add("str1", "str1");
			dataTableMapping.ColumnMappings.Add("str2", "str2");
			dataTableMapping.ColumnMappings.Add("str3", "str3");
			dataTableMapping.ColumnMappings.Add("str4", "str4");
			dataTableMapping.ColumnMappings.Add("str5", "str5");
			dataTableMapping.ColumnMappings.Add("str6", "str6");
			dataTableMapping.ColumnMappings.Add("str7", "str7");
			dataTableMapping.ColumnMappings.Add("str8", "str8");
			dataTableMapping.ColumnMappings.Add("str9", "str9");
			dataTableMapping.ColumnMappings.Add("str10", "str10");
			dataTableMapping.ColumnMappings.Add("str11", "str11");
			dataTableMapping.ColumnMappings.Add("str12", "str12");
			dataTableMapping.ColumnMappings.Add("str13", "str13");
			dataTableMapping.ColumnMappings.Add("str14", "str14");
			dataTableMapping.ColumnMappings.Add("str15", "str15");
			dataTableMapping.ColumnMappings.Add("str16", "str16");
			dataTableMapping.ColumnMappings.Add("str17", "str17");
			dataTableMapping.ColumnMappings.Add("str18", "str18");
			dataTableMapping.ColumnMappings.Add("stragg1", "stragg1");
			dataTableMapping.ColumnMappings.Add("stragg2", "stragg2");
			dataTableMapping.ColumnMappings.Add("stragg3", "stragg3");
			dataTableMapping.ColumnMappings.Add("stragg4", "stragg4");
			dataTableMapping.ColumnMappings.Add("stragg5", "stragg5");
			dataTableMapping.ColumnMappings.Add("rdodetail1", "rdodetail1");
			this._adapter.TableMappings.Add((object)dataTableMapping);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitCommandCollection()
		{
			this._commandCollection = new SqlCommand[] { new SqlCommand() };
			this._commandCollection[0].Connection = this.Connection;
			this._commandCollection[0].CommandText = "dbo.PC_Estimate_report";
			this._commandCollection[0].CommandType = CommandType.StoredProcedure;
			this._commandCollection[0].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@companyid", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str1", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str2", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str3", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str4", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str5", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str6", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str7", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str8", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str9", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str10", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str11", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str12", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str13", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str14", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str15", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str16", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str17", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@str18", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@stragg1", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@stragg2", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@stragg3", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@stragg4", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@stragg5", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@rdodetail1", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@freetext", SqlDbType.NVarChar, 250, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@StatusIDS", SqlDbType.NVarChar, 2147483647, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@today", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@yest", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@startdate", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@enddate", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@year", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@tilldate", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@RangeFrom", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@RangeTo", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@Range", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
			this._commandCollection[0].Parameters.Add(new SqlParameter("@includezero", SqlDbType.NVarChar, 10, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
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
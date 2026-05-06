using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telerik.Web.SessionDS
{
	public class SessionDataSourceView : SqlDataSourceView
	{
		private DataSourceView originalView;

		private HttpSessionState session;

		private HttpContext context;

		private SessionDataSource owner;

		private DbCommand selectCommand;

		private Exception selectException;

		private DbParameterCollection currentSelectParameters;

		private string[] PrimaryKeyFields
		{
			get
			{
				if ((this.owner.PrimaryKeyFields ?? "") == "")
				{
					return new string[0];
				}
				return this.owner.PrimaryKeyFields.Split(new char[] { ',' });
			}
		}

		public SessionDataSourceView(SqlDataSource owner, string name, HttpContext context, DataSourceView originalView, HttpSessionState session) : base(owner, name, context)
		{
			this.owner = owner as SessionDataSource;
			this.originalView = originalView;
			this.session = session;
			this.context = context;
		}

		private static void AddNewRows(DataTable targetTable, DataTable newTable)
		{
			if ((int)targetTable.PrimaryKey.Length == 0 || (int)newTable.PrimaryKey.Length == 0)
			{
				return;
			}
			foreach (DataRow row in newTable.Rows)
			{
				object[] primaryKeyValues = SessionDataSourceView.GetPrimaryKeyValues(row, DataRowVersion.Original);
				if (targetTable.Rows.Find(primaryKeyValues) != null || SessionDataSourceView.FindDeletedRow(targetTable, primaryKeyValues) != null)
				{
					continue;
				}
				targetTable.Rows.Add(row.ItemArray).AcceptChanges();
			}
		}

		private static bool CompareRowKeys(object[] rowKey, object[] candidateKey)
		{
			bool flag = true;
			int num = 0;
			while (num < (int)candidateKey.Length)
			{
				if (rowKey[num].Equals(candidateKey[num]))
				{
					num++;
				}
				else
				{
					flag = false;
					break;
				}
			}
			return flag;
		}

		protected override int ExecuteDelete(IDictionary keys, IDictionary oldValues)
		{
			if (this.owner.RevertToOriginalDataSource)
			{
				return base.ExecuteDelete(keys, oldValues);
			}
			DataTable item = (DataTable)this.session[this.owner.DataSourceSessionKey];
			if (item == null)
			{
				return 0;
			}
			DataRow[] dataRowArray = item.Select(this.SelectRecordString(keys));
			if ((int)dataRowArray.Length != 1)
			{
				throw new InvalidOperationException("Unable to locate record to delete. Please asure you have selected the DataKeyNames propery.");
			}
			dataRowArray[0].Delete();
			this.OnDeleted(new SqlDataSourceStatusEventArgs(null, 1, null));
			this.OnDataSourceViewChanged(EventArgs.Empty);
			return 1;
		}

		protected override int ExecuteInsert(IDictionary values)
		{
			object value;
			if (this.owner.RevertToOriginalDataSource)
			{
				return base.ExecuteInsert(values);
			}
			DataTable item = (DataTable)this.session[this.owner.DataSourceSessionKey];
			if (item == null)
			{
				return 0;
			}
			DataRow dataRow = item.NewRow();
			foreach (DictionaryEntry dictionaryEntry in values)
			{
				DataRow dataRow1 = dataRow;
				string key = (string)dictionaryEntry.Key;
				if (dictionaryEntry.Value != null)
				{
					value = dictionaryEntry.Value;
				}
				else
				{
					value = DBNull.Value;
				}
				dataRow1[key] = value;
			}
			foreach (KeyValuePair<string, int> nextPrimaryKey in this.GetNextPrimaryKey())
			{
				dataRow[nextPrimaryKey.Key] = nextPrimaryKey.Value;
			}
			this.ExtractCommandParametersToDataRow(base.InsertParameters, dataRow);
			item.Rows.Add(dataRow);
			this.OnInserted(new SqlDataSourceStatusEventArgs(null, 1, null));
			this.OnDataSourceViewChanged(EventArgs.Empty);
			return 1;
		}

		protected override IEnumerable ExecuteSelect(DataSourceSelectArguments arguments)
		{
			DataTable dataTable;
			DataTable table = ((DataView)base.ExecuteSelect(arguments)).Table;
			DataTable item = (DataTable)this.session[this.owner.DataSourceSessionKey];
			this.InitPrimaryKey(table);
			if (this.owner.RevertToOriginalDataSource)
			{
				this.RaiseOnSelected(table.DefaultView.Count);
				return table.DefaultView;
			}
			if (item != null)
			{
				dataTable = this.SmartMerge(item, table);
			}
			else
			{
				item = table.Copy();
				this.InitPrimaryKey(item);
				this.session[this.owner.DataSourceSessionKey] = item;
				dataTable = item;
			}
			DataView defaultView = dataTable.DefaultView;
			if (!string.IsNullOrEmpty(arguments.SortExpression))
			{
				defaultView.Sort = arguments.SortExpression;
			}
			this.RaiseOnSelected(defaultView.Count);
			return defaultView;
		}

		protected override int ExecuteUpdate(IDictionary keys, IDictionary values, IDictionary oldValues)
		{
			object value;
			if (this.owner.RevertToOriginalDataSource)
			{
				return base.ExecuteUpdate(keys, values, oldValues);
			}
			DataTable item = (DataTable)this.session[this.owner.DataSourceSessionKey];
			if (item == null)
			{
				return 0;
			}
			DataRow[] dataRowArray = item.Select(this.SelectRecordString(keys));
			if ((int)dataRowArray.Length != 1)
			{
				throw new InvalidOperationException("Unable to locate record to update.");
			}
			DataRow dataRow = dataRowArray[0];
			try
			{
				foreach (DictionaryEntry dictionaryEntry in values)
				{
					DataRow dataRow1 = dataRow;
					string key = (string)dictionaryEntry.Key;
					if (dictionaryEntry.Value != null)
					{
						value = dictionaryEntry.Value;
					}
					else
					{
						value = DBNull.Value;
					}
					dataRow1[key] = value;
				}
			}
			catch (ArgumentException argumentException)
			{
				dataRow.RejectChanges();
				throw;
			}
			this.ExtractCommandParametersToDataRow(base.UpdateParameters, dataRow);
			this.OnUpdated(new SqlDataSourceStatusEventArgs(null, 1, null));
			this.OnDataSourceViewChanged(EventArgs.Empty);
			return 1;
		}

		private void ExtractCommandParametersToDataRow(ParameterCollection parameters, DataRow row)
		{
			IOrderedDictionary values = parameters.GetValues(this.context, this.owner);
			for (int i = 0; i < parameters.Count; i++)
			{
				if (values[i] != null)
				{
					row[parameters[i].Name] = values[i];
				}
			}
		}

		private static DataRow FindDeletedRow(DataTable table, object[] rowKey)
		{
			DataTable changes = table.GetChanges(DataRowState.Deleted);
			DataRow dataRow = null;
			if (changes != null)
			{
				foreach (DataRow row in changes.Rows)
				{
					if (!SessionDataSourceView.CompareRowKeys(rowKey, SessionDataSourceView.GetPrimaryKeyValues(row, DataRowVersion.Original)))
					{
						continue;
					}
					dataRow = row;
				}
			}
			return dataRow;
		}

		private string FormatValue(object value)
		{
			if (value is string)
			{
				string str = (string)value;
				return string.Concat("'", str.Replace("'", "''"), "'");
			}
			if (!(value is DateTime))
			{
				return value.ToString();
			}
			DateTime dateTime = (DateTime)value;
			return string.Concat("'", dateTime.ToString(CultureInfo.InvariantCulture), "'");
		}

		private string GetCurrentOrderBy()
		{
			int num = this.owner.SelectCommand.IndexOf("ORDER BY");
			if (num < 0)
			{
				return string.Empty;
			}
			return string.Concat(this.owner.SelectCommand.Substring(num + "ORDER BY".Length).Replace("[", "").Replace("]", ""), " ASC");
		}

		private string GetCurrentSelectFilterExpression()
		{
			int num = this.owner.SelectCommand.IndexOf("WHERE", StringComparison.InvariantCultureIgnoreCase);
			if (num == -1)
			{
				return string.Empty;
			}
			string str = this.owner.SelectCommand.Substring(num + "WHERE".Length);
			foreach (DbParameter currentSelectParameter in this.currentSelectParameters)
			{
				str = str.Replace(currentSelectParameter.ParameterName, this.FormatValue(currentSelectParameter.Value));
			}
			return str;
		}

		private Dictionary<string, int> GetNextPrimaryKey()
		{
			string str = string.Concat(this.owner.DataSourceSessionKey, "_pkSeeds");
			Dictionary<string, int> item = (Dictionary<string, int>)this.session[str];
			if (item == null)
			{
				item = new Dictionary<string, int>();
				string[] primaryKeyFields = this.PrimaryKeyFields;
				for (int i = 0; i < (int)primaryKeyFields.Length; i++)
				{
					item[primaryKeyFields[i]] = -2147483648;
				}
				this.session[str] = item;
			}
			Dictionary<string, int> strs = new Dictionary<string, int>();
			string[] strArrays = this.PrimaryKeyFields;
			for (int j = 0; j < (int)strArrays.Length; j++)
			{
				string str1 = strArrays[j];
				strs[str1] = item[str1];
				item[str1] = item[str1] + 1;
			}
			return strs;
		}

		private static object[] GetPrimaryKeyValues(DataRow row, DataRowVersion version)
		{
			object[] item = new object[(int)row.Table.PrimaryKey.Length];
			for (int i = 0; i < (int)item.Length; i++)
			{
				item[i] = row[row.Table.PrimaryKey[i], version];
			}
			return item;
		}

		private void InitPrimaryKey(DataTable table)
		{
			DataColumn[] dataColumnArray = new DataColumn[(int)this.PrimaryKeyFields.Length];
			for (int i = 0; i < (int)this.PrimaryKeyFields.Length; i++)
			{
				DataColumn item = table.Columns[this.PrimaryKeyFields[i]];
				item.ReadOnly = true;
				dataColumnArray[i] = item;
			}
			table.PrimaryKey = dataColumnArray;
		}

		protected override void OnSelected(SqlDataSourceStatusEventArgs e)
		{
			this.selectCommand = e.Command;
			this.selectException = e.Exception;
		}

		protected override void OnSelecting(SqlDataSourceSelectingEventArgs e)
		{
			this.currentSelectParameters = e.Command.Parameters;
			base.OnSelecting(e);
		}

		private void RaiseOnSelected(int rowCount)
		{
			base.OnSelected(new SqlDataSourceStatusEventArgs(this.selectCommand, rowCount, this.selectException));
		}

		private string SelectRecordString(IDictionary keys)
		{
			string empty = string.Empty;
			foreach (DictionaryEntry key in keys)
			{
				if (empty != string.Empty)
				{
					empty = string.Concat(empty, " AND ");
				}
				if (key.Value == null)
				{
					empty = string.Concat(empty, key.Key, " Is Null");
				}
				else
				{
					object obj = empty;
					object[] objArray = new object[] { obj, key.Key, " = ", this.FormatValue(key.Value) };
					empty = string.Concat(objArray);
				}
			}
			return empty;
		}

		private DataTable SmartMerge(DataTable sessionTable, DataTable queryTable)
		{
			SessionDataSourceView.AddNewRows(sessionTable, queryTable);
			DataTable invariantCulture = queryTable.Copy();
			invariantCulture.Locale = CultureInfo.InvariantCulture;
			invariantCulture.BeginLoadData();
			DataTable changes = sessionTable.GetChanges(DataRowState.Added);
			if (changes != null)
			{
				foreach (DataRow row in changes.Rows)
				{
					invariantCulture.Rows.Add(row.ItemArray);
				}
			}
			DataTable dataTable = sessionTable.GetChanges(DataRowState.Deleted);
			if (dataTable != null)
			{
				foreach (DataRow dataRow in dataTable.Rows)
				{
					DataRow dataRow1 = invariantCulture.Rows.Find(SessionDataSourceView.GetPrimaryKeyValues(dataRow, DataRowVersion.Original));
					if (dataRow1 == null)
					{
						continue;
					}
					dataRow1.Delete();
				}
			}
			DataTable changes1 = sessionTable.GetChanges(DataRowState.Modified);
			if (changes1 != null)
			{
				foreach (DataRow row1 in changes1.Rows)
				{
					invariantCulture.LoadDataRow(row1.ItemArray, true);
				}
			}
			invariantCulture.EndLoadData();
			invariantCulture.AcceptChanges();
			string currentOrderBy = this.GetCurrentOrderBy();
			if (!this.owner.SelectCommand.Contains("WHERE"))
			{
				if (!string.IsNullOrEmpty(currentOrderBy))
				{
					invariantCulture.DefaultView.Sort = currentOrderBy;
				}
				return invariantCulture;
			}
			DataTable dataTable1 = invariantCulture.Copy();
			dataTable1.Rows.Clear();
			dataTable1.BeginLoadData();
			DataRow[] dataRowArray = invariantCulture.Select(this.GetCurrentSelectFilterExpression());
			for (int i = 0; i < (int)dataRowArray.Length; i++)
			{
				DataRow dataRow2 = dataRowArray[i];
				dataTable1.Rows.Add(dataRow2.ItemArray);
			}
			dataTable1.EndLoadData();
			dataTable1.AcceptChanges();
			if (!string.IsNullOrEmpty(currentOrderBy))
			{
				dataTable1.DefaultView.Sort = currentOrderBy;
			}
			return dataTable1;
		}
	}
}
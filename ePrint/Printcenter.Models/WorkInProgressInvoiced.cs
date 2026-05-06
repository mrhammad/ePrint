using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

[DesignerCategory("code")]
[HelpKeyword("vs.data.DataSet")]
[Serializable]
[ToolboxItem(true)]
[XmlRoot("WorkInProgressInvoiced")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
public class WorkInProgressInvoiced : DataSet
{
	private WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedDataTable tablePC_Work_In_Progress_Invoiced;

	private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;

	[Browsable(false)]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedDataTable PC_Work_In_Progress_Invoiced
	{
		get
		{
			return this.tablePC_Work_In_Progress_Invoiced;
		}
	}

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public new DataRelationCollection Relations
	{
		get
		{
			return base.Relations;
		}
	}

	[Browsable(true)]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public override System.Data.SchemaSerializationMode SchemaSerializationMode
	{
		get
		{
			return this._schemaSerializationMode;
		}
		set
		{
			this._schemaSerializationMode = value;
		}
	}

	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public new DataTableCollection Tables
	{
		get
		{
			return base.Tables;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public WorkInProgressInvoiced()
	{
		base.BeginInit();
		this.InitClass();
		CollectionChangeEventHandler collectionChangeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
		base.Tables.CollectionChanged += collectionChangeEventHandler;
		base.Relations.CollectionChanged += collectionChangeEventHandler;
		base.EndInit();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected WorkInProgressInvoiced(SerializationInfo info, StreamingContext context) : base(info, context, false)
	{
		if (base.IsBinarySerialized(info, context))
		{
			this.InitVars(false);
			CollectionChangeEventHandler collectionChangeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
			this.Tables.CollectionChanged += collectionChangeEventHandler;
			this.Relations.CollectionChanged += collectionChangeEventHandler;
			return;
		}
		string value = (string)info.GetValue("XmlSchema", typeof(string));
		if (base.DetermineSchemaSerializationMode(info, context) != System.Data.SchemaSerializationMode.IncludeSchema)
		{
			base.ReadXmlSchema(new XmlTextReader(new StringReader(value)));
		}
		else
		{
			DataSet dataSet = new DataSet();
			dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(value)));
			if (dataSet.Tables["PC_Work_In_Progress_Invoiced"] != null)
			{
				base.Tables.Add(new WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedDataTable(dataSet.Tables["PC_Work_In_Progress_Invoiced"]));
			}
			base.DataSetName = dataSet.DataSetName;
			base.Prefix = dataSet.Prefix;
			base.Namespace = dataSet.Namespace;
			base.Locale = dataSet.Locale;
			base.CaseSensitive = dataSet.CaseSensitive;
			base.EnforceConstraints = dataSet.EnforceConstraints;
			base.Merge(dataSet, false, MissingSchemaAction.Add);
			this.InitVars();
		}
		base.GetSerializationData(info, context);
		CollectionChangeEventHandler collectionChangeEventHandler1 = new CollectionChangeEventHandler(this.SchemaChanged);
		base.Tables.CollectionChanged += collectionChangeEventHandler1;
		this.Relations.CollectionChanged += collectionChangeEventHandler1;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public override DataSet Clone()
	{
		WorkInProgressInvoiced schemaSerializationMode = (WorkInProgressInvoiced)base.Clone();
		schemaSerializationMode.InitVars();
		schemaSerializationMode.SchemaSerializationMode = this.SchemaSerializationMode;
		return schemaSerializationMode;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected override XmlSchema GetSchemaSerializable()
	{
		MemoryStream memoryStream = new MemoryStream();
		base.WriteXmlSchema(new XmlTextWriter(memoryStream, null));
		memoryStream.Position = (long)0;
		return XmlSchema.Read(new XmlTextReader(memoryStream), null);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
	{
		XmlSchemaComplexType xmlSchemaComplexType;
		XmlSchema xmlSchema;
		WorkInProgressInvoiced workInProgressInvoiced = new WorkInProgressInvoiced();
		XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
		{
			Namespace = workInProgressInvoiced.Namespace
		};
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType1.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = workInProgressInvoiced.GetSchemaSerializable();
		if (xs.Contains(schemaSerializable.TargetNamespace))
		{
			MemoryStream memoryStream = new MemoryStream();
			MemoryStream memoryStream1 = new MemoryStream();
			try
			{
				XmlSchema current = null;
				schemaSerializable.Write(memoryStream);
				IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
				while (enumerator.MoveNext())
				{
					current = (XmlSchema)enumerator.Current;
					memoryStream1.SetLength((long)0);
					current.Write(memoryStream1);
					if (memoryStream.Length != memoryStream1.Length)
					{
						continue;
					}
					memoryStream.Position = (long)0;
					memoryStream1.Position = (long)0;
					while (memoryStream.Position != memoryStream.Length && memoryStream.ReadByte() == memoryStream1.ReadByte())
					{
					}
					if (memoryStream.Position != memoryStream.Length)
					{
						continue;
					}
					xmlSchemaComplexType = xmlSchemaComplexType1;
					return xmlSchemaComplexType;
				}
				xmlSchema = xs.Add(schemaSerializable);
				return xmlSchemaComplexType1;
			}
			finally
			{
				if (memoryStream != null)
				{
					memoryStream.Close();
				}
				if (memoryStream1 != null)
				{
					memoryStream1.Close();
				}
			}
			return xmlSchemaComplexType;
		}
		xmlSchema = xs.Add(schemaSerializable);
		return xmlSchemaComplexType1;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private void InitClass()
	{
		base.DataSetName = "WorkInProgressInvoiced";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/WorkInProgressInvoiced.xsd";
		base.EnforceConstraints = true;
		this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
		this.tablePC_Work_In_Progress_Invoiced = new WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedDataTable();
		base.Tables.Add(this.tablePC_Work_In_Progress_Invoiced);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected override void InitializeDerivedDataSet()
	{
		base.BeginInit();
		this.InitClass();
		base.EndInit();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	internal void InitVars()
	{
		this.InitVars(true);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	internal void InitVars(bool initTable)
	{
		this.tablePC_Work_In_Progress_Invoiced = (WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedDataTable)base.Tables["PC_Work_In_Progress_Invoiced"];
		if (initTable && this.tablePC_Work_In_Progress_Invoiced != null)
		{
			this.tablePC_Work_In_Progress_Invoiced.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected override void ReadXmlSerializable(XmlReader reader)
	{
		if (base.DetermineSchemaSerializationMode(reader) != System.Data.SchemaSerializationMode.IncludeSchema)
		{
			base.ReadXml(reader);
			this.InitVars();
			return;
		}
		this.Reset();
		DataSet dataSet = new DataSet();
		dataSet.ReadXml(reader);
		if (dataSet.Tables["PC_Work_In_Progress_Invoiced"] != null)
		{
			base.Tables.Add(new WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedDataTable(dataSet.Tables["PC_Work_In_Progress_Invoiced"]));
		}
		base.DataSetName = dataSet.DataSetName;
		base.Prefix = dataSet.Prefix;
		base.Namespace = dataSet.Namespace;
		base.Locale = dataSet.Locale;
		base.CaseSensitive = dataSet.CaseSensitive;
		base.EnforceConstraints = dataSet.EnforceConstraints;
		base.Merge(dataSet, false, MissingSchemaAction.Add);
		this.InitVars();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private void SchemaChanged(object sender, CollectionChangeEventArgs e)
	{
		if (e.Action == CollectionChangeAction.Remove)
		{
			this.InitVars();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private bool ShouldSerializePC_Work_In_Progress_Invoiced()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected override bool ShouldSerializeRelations()
	{
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected override bool ShouldSerializeTables()
	{
		return false;
	}

	[Serializable]
	[XmlSchemaProvider("GetTypedTableSchema")]
	public class PC_Work_In_Progress_InvoicedDataTable : TypedTableBase<WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow>
	{
		private DataColumn columnstatus;

		private DataColumn columnquoteno;

		private DataColumn columnquoteDate;

		private DataColumn columnCustomer;

		private DataColumn columninvoiceno;

		private DataColumn columninvoicedate;

		private DataColumn columnjobtype;

		private DataColumn columnEstimateItemID;

		private DataColumn columnqty1;

		private DataColumn columnsubtotal1;

		private DataColumn columntax1;

		private DataColumn columnprofitmargin1;

		private DataColumn columnqty2;

		private DataColumn columnsubtotal2;

		private DataColumn columntax2;

		private DataColumn columnprofitmargin2;

		private DataColumn columnqty3;

		private DataColumn columnsubtotal3;

		private DataColumn columntax3;

		private DataColumn columnprofitmargin3;

		private DataColumn columnqty4;

		private DataColumn columnsubtotal4;

		private DataColumn columntax4;

		private DataColumn columnprofitmargin4;

		private DataColumn columnqty5;

		private DataColumn columnsubtotal5;

		private DataColumn columntax5;

		private DataColumn columnprofitmargin5;

		private DataColumn columnqty6;

		private DataColumn columnSubTotal6;

		private DataColumn columntax6;

		private DataColumn columnprofitmargin6;

		private DataColumn columnGP;

		private DataColumn columnGPpercent;

		private DataColumn columndateto;

		private DataColumn columndatefrom;

		private DataColumn columnoptionschosen;

		private DataColumn columnqty7;

		private DataColumn columnSubTotal7;

		private DataColumn columntax7;

		private DataColumn columnprofitmargin7;

		private DataColumn columnqty8;

		private DataColumn columnSubTotal8;

		private DataColumn columntax8;

		private DataColumn columnprofitmargin8;

		[Browsable(false)]
		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int Count
		{
			get
			{
				return base.Rows.Count;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn CustomerColumn
		{
			get
			{
				return this.columnCustomer;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn datefromColumn
		{
			get
			{
				return this.columndatefrom;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn datetoColumn
		{
			get
			{
				return this.columndateto;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn EstimateItemIDColumn
		{
			get
			{
				return this.columnEstimateItemID;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn GPColumn
		{
			get
			{
				return this.columnGP;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn GPpercentColumn
		{
			get
			{
				return this.columnGPpercent;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invoicedateColumn
		{
			get
			{
				return this.columninvoicedate;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invoicenoColumn
		{
			get
			{
				return this.columninvoiceno;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow this[int index]
		{
			get
			{
				return (WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow)base.Rows[index];
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobtypeColumn
		{
			get
			{
				return this.columnjobtype;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn optionschosenColumn
		{
			get
			{
				return this.columnoptionschosen;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn profitmargin1Column
		{
			get
			{
				return this.columnprofitmargin1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn profitmargin2Column
		{
			get
			{
				return this.columnprofitmargin2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn profitmargin3Column
		{
			get
			{
				return this.columnprofitmargin3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn profitmargin4Column
		{
			get
			{
				return this.columnprofitmargin4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn profitmargin5Column
		{
			get
			{
				return this.columnprofitmargin5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn profitmargin6Column
		{
			get
			{
				return this.columnprofitmargin6;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn profitmargin7Column
		{
			get
			{
				return this.columnprofitmargin7;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn profitmargin8Column
		{
			get
			{
				return this.columnprofitmargin8;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn qty1Column
		{
			get
			{
				return this.columnqty1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn qty2Column
		{
			get
			{
				return this.columnqty2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn qty3Column
		{
			get
			{
				return this.columnqty3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn qty4Column
		{
			get
			{
				return this.columnqty4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn qty5Column
		{
			get
			{
				return this.columnqty5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn qty6Column
		{
			get
			{
				return this.columnqty6;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn qty7Column
		{
			get
			{
				return this.columnqty7;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn qty8Column
		{
			get
			{
				return this.columnqty8;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn quoteDateColumn
		{
			get
			{
				return this.columnquoteDate;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn quotenoColumn
		{
			get
			{
				return this.columnquoteno;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn statusColumn
		{
			get
			{
				return this.columnstatus;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn subtotal1Column
		{
			get
			{
				return this.columnsubtotal1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn subtotal2Column
		{
			get
			{
				return this.columnsubtotal2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn subtotal3Column
		{
			get
			{
				return this.columnsubtotal3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn subtotal4Column
		{
			get
			{
				return this.columnsubtotal4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn subtotal5Column
		{
			get
			{
				return this.columnsubtotal5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn SubTotal6Column
		{
			get
			{
				return this.columnSubTotal6;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn SubTotal7Column
		{
			get
			{
				return this.columnSubTotal7;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn SubTotal8Column
		{
			get
			{
				return this.columnSubTotal8;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn tax1Column
		{
			get
			{
				return this.columntax1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn tax2Column
		{
			get
			{
				return this.columntax2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn tax3Column
		{
			get
			{
				return this.columntax3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn tax4Column
		{
			get
			{
				return this.columntax4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn tax5Column
		{
			get
			{
				return this.columntax5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn tax6Column
		{
			get
			{
				return this.columntax6;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn tax7Column
		{
			get
			{
				return this.columntax7;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn tax8Column
		{
			get
			{
				return this.columntax8;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public PC_Work_In_Progress_InvoicedDataTable()
		{
			base.TableName = "PC_Work_In_Progress_Invoiced";
			this.BeginInit();
			this.InitClass();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal PC_Work_In_Progress_InvoicedDataTable(DataTable table)
		{
			base.TableName = table.TableName;
			if (table.CaseSensitive != table.DataSet.CaseSensitive)
			{
				base.CaseSensitive = table.CaseSensitive;
			}
			if (table.Locale.ToString() != table.DataSet.Locale.ToString())
			{
				base.Locale = table.Locale;
			}
			if (table.Namespace != table.DataSet.Namespace)
			{
				base.Namespace = table.Namespace;
			}
			base.Prefix = table.Prefix;
			base.MinimumCapacity = table.MinimumCapacity;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected PC_Work_In_Progress_InvoicedDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this.InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void AddPC_Work_In_Progress_InvoicedRow(WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow AddPC_Work_In_Progress_InvoicedRow(string status, string quoteno, DateTime quoteDate, string Customer, string invoiceno, DateTime invoicedate, string jobtype, int EstimateItemID, int qty1, decimal subtotal1, decimal tax1, decimal profitmargin1, int qty2, decimal subtotal2, decimal tax2, decimal profitmargin2, int qty3, decimal subtotal3, decimal tax3, decimal profitmargin3, int qty4, decimal subtotal4, decimal tax4, decimal profitmargin4, int qty5, decimal subtotal5, decimal tax5, decimal profitmargin5, int qty6, decimal SubTotal6, decimal tax6, decimal profitmargin6, string GP, string GPpercent, string dateto, string datefrom, string optionschosen, int qty7, decimal SubTotal7, decimal tax7, decimal profitmargin7, string qty8, decimal SubTotal8, decimal tax8, decimal profitmargin8)
		{
			WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow pCWorkInProgressInvoicedRow = (WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow)base.NewRow();
			object[] objArray = new object[] { status, quoteno, quoteDate, Customer, invoiceno, invoicedate, jobtype, EstimateItemID, qty1, subtotal1, tax1, profitmargin1, qty2, subtotal2, tax2, profitmargin2, qty3, subtotal3, tax3, profitmargin3, qty4, subtotal4, tax4, profitmargin4, qty5, subtotal5, tax5, profitmargin5, qty6, SubTotal6, tax6, profitmargin6, GP, GPpercent, dateto, datefrom, optionschosen, qty7, SubTotal7, tax7, profitmargin7, qty8, SubTotal8, tax8, profitmargin8 };
			pCWorkInProgressInvoicedRow.ItemArray = objArray;
			base.Rows.Add(pCWorkInProgressInvoicedRow);
			return pCWorkInProgressInvoicedRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedDataTable pCWorkInProgressInvoicedDataTable = (WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedDataTable)base.Clone();
			pCWorkInProgressInvoicedDataTable.InitVars();
			return pCWorkInProgressInvoicedDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType;
			XmlSchema xmlSchema;
			XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			WorkInProgressInvoiced workInProgressInvoiced = new WorkInProgressInvoiced();
			XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
			{
				Namespace = "http://www.w3.org/2001/XMLSchema",
				MinOccurs = new decimal(0),
				MaxOccurs = new decimal(-1, -1, -1, false, 0),
				ProcessContents = XmlSchemaContentProcessing.Lax
			};
			xmlSchemaSequence.Items.Add(xmlSchemaAny);
			XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny()
			{
				Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
				MinOccurs = new decimal(1),
				ProcessContents = XmlSchemaContentProcessing.Lax
			};
			xmlSchemaSequence.Items.Add(xmlSchemaAny1);
			XmlSchemaAttribute xmlSchemaAttribute = new XmlSchemaAttribute()
			{
				Name = "namespace",
				FixedValue = workInProgressInvoiced.Namespace
			};
			xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
			{
				Name = "tableTypeName",
				FixedValue = "PC_Work_In_Progress_InvoicedDataTable"
			};
			xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
			xmlSchemaComplexType1.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = workInProgressInvoiced.GetSchemaSerializable();
			if (xs.Contains(schemaSerializable.TargetNamespace))
			{
				MemoryStream memoryStream = new MemoryStream();
				MemoryStream memoryStream1 = new MemoryStream();
				try
				{
					XmlSchema current = null;
					schemaSerializable.Write(memoryStream);
					IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
					while (enumerator.MoveNext())
					{
						current = (XmlSchema)enumerator.Current;
						memoryStream1.SetLength((long)0);
						current.Write(memoryStream1);
						if (memoryStream.Length != memoryStream1.Length)
						{
							continue;
						}
						memoryStream.Position = (long)0;
						memoryStream1.Position = (long)0;
						while (memoryStream.Position != memoryStream.Length && memoryStream.ReadByte() == memoryStream1.ReadByte())
						{
						}
						if (memoryStream.Position != memoryStream.Length)
						{
							continue;
						}
						xmlSchemaComplexType = xmlSchemaComplexType1;
						return xmlSchemaComplexType;
					}
					xmlSchema = xs.Add(schemaSerializable);
					return xmlSchemaComplexType1;
				}
				finally
				{
					if (memoryStream != null)
					{
						memoryStream.Close();
					}
					if (memoryStream1 != null)
					{
						memoryStream1.Close();
					}
				}
				return xmlSchemaComplexType;
			}
			xmlSchema = xs.Add(schemaSerializable);
			return xmlSchemaComplexType1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitClass()
		{
			this.columnstatus = new DataColumn("status", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstatus);
			this.columnquoteno = new DataColumn("quoteno", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnquoteno);
			this.columnquoteDate = new DataColumn("quoteDate", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.columnquoteDate);
			this.columnCustomer = new DataColumn("Customer", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnCustomer);
			this.columninvoiceno = new DataColumn("invoiceno", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columninvoiceno);
			this.columninvoicedate = new DataColumn("invoicedate", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.columninvoicedate);
			this.columnjobtype = new DataColumn("jobtype", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnjobtype);
			this.columnEstimateItemID = new DataColumn("EstimateItemID", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columnEstimateItemID);
			this.columnqty1 = new DataColumn("qty1", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columnqty1);
			this.columnsubtotal1 = new DataColumn("subtotal1", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnsubtotal1);
			this.columntax1 = new DataColumn("tax1", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columntax1);
			this.columnprofitmargin1 = new DataColumn("profitmargin1", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnprofitmargin1);
			this.columnqty2 = new DataColumn("qty2", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columnqty2);
			this.columnsubtotal2 = new DataColumn("subtotal2", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnsubtotal2);
			this.columntax2 = new DataColumn("tax2", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columntax2);
			this.columnprofitmargin2 = new DataColumn("profitmargin2", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnprofitmargin2);
			this.columnqty3 = new DataColumn("qty3", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columnqty3);
			this.columnsubtotal3 = new DataColumn("subtotal3", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnsubtotal3);
			this.columntax3 = new DataColumn("tax3", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columntax3);
			this.columnprofitmargin3 = new DataColumn("profitmargin3", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnprofitmargin3);
			this.columnqty4 = new DataColumn("qty4", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columnqty4);
			this.columnsubtotal4 = new DataColumn("subtotal4", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnsubtotal4);
			this.columntax4 = new DataColumn("tax4", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columntax4);
			this.columnprofitmargin4 = new DataColumn("profitmargin4", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnprofitmargin4);
			this.columnqty5 = new DataColumn("qty5", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columnqty5);
			this.columnsubtotal5 = new DataColumn("subtotal5", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnsubtotal5);
			this.columntax5 = new DataColumn("tax5", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columntax5);
			this.columnprofitmargin5 = new DataColumn("profitmargin5", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnprofitmargin5);
			this.columnqty6 = new DataColumn("qty6", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columnqty6);
			this.columnSubTotal6 = new DataColumn("SubTotal6", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnSubTotal6);
			this.columntax6 = new DataColumn("tax6", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columntax6);
			this.columnprofitmargin6 = new DataColumn("profitmargin6", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnprofitmargin6);
			this.columnGP = new DataColumn("GP", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnGP);
			this.columnGPpercent = new DataColumn("GPpercent", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnGPpercent);
			this.columndateto = new DataColumn("dateto", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columndateto);
			this.columndatefrom = new DataColumn("datefrom", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columndatefrom);
			this.columnoptionschosen = new DataColumn("optionschosen", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnoptionschosen);
			this.columnqty7 = new DataColumn("qty7", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columnqty7);
			this.columnSubTotal7 = new DataColumn("SubTotal7", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnSubTotal7);
			this.columntax7 = new DataColumn("tax7", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columntax7);
			this.columnprofitmargin7 = new DataColumn("profitmargin7", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnprofitmargin7);
			this.columnqty8 = new DataColumn("qty8", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnqty8);
			this.columnSubTotal8 = new DataColumn("SubTotal8", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnSubTotal8);
			this.columntax8 = new DataColumn("tax8", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columntax8);
			this.columnprofitmargin8 = new DataColumn("profitmargin8", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnprofitmargin8);
			this.columnstatus.MaxLength = 100;
			this.columnquoteno.MaxLength = 25;
			this.columnCustomer.MaxLength = 300;
			this.columninvoiceno.MaxLength = 25;
			this.columnjobtype.ReadOnly = true;
			this.columnjobtype.MaxLength = 1;
			this.columnqty1.ReadOnly = true;
			this.columnsubtotal1.ReadOnly = true;
			this.columntax1.ReadOnly = true;
			this.columnprofitmargin1.ReadOnly = true;
			this.columnqty2.ReadOnly = true;
			this.columnsubtotal2.ReadOnly = true;
			this.columntax2.ReadOnly = true;
			this.columnprofitmargin2.ReadOnly = true;
			this.columnqty3.ReadOnly = true;
			this.columnsubtotal3.ReadOnly = true;
			this.columntax3.ReadOnly = true;
			this.columnprofitmargin3.ReadOnly = true;
			this.columnqty4.ReadOnly = true;
			this.columnsubtotal4.ReadOnly = true;
			this.columntax4.ReadOnly = true;
			this.columnprofitmargin4.ReadOnly = true;
			this.columnqty5.ReadOnly = true;
			this.columnsubtotal5.ReadOnly = true;
			this.columntax5.ReadOnly = true;
			this.columnprofitmargin5.ReadOnly = true;
			this.columnqty6.ReadOnly = true;
			this.columnSubTotal6.ReadOnly = true;
			this.columntax6.ReadOnly = true;
			this.columnprofitmargin6.ReadOnly = true;
			this.columnGP.ReadOnly = true;
			this.columnGP.MaxLength = 1;
			this.columnGPpercent.ReadOnly = true;
			this.columnGPpercent.MaxLength = 1;
			this.columndateto.ReadOnly = true;
			this.columndateto.MaxLength = 1;
			this.columndatefrom.ReadOnly = true;
			this.columndatefrom.MaxLength = 1;
			this.columnoptionschosen.ReadOnly = true;
			this.columnoptionschosen.MaxLength = 1;
			this.columnqty7.ReadOnly = true;
			this.columnSubTotal7.ReadOnly = true;
			this.columntax7.ReadOnly = true;
			this.columnprofitmargin7.ReadOnly = true;
			this.columnqty8.ReadOnly = true;
			this.columnqty8.MaxLength = 1;
			this.columnSubTotal8.ReadOnly = true;
			this.columntax8.ReadOnly = true;
			this.columnprofitmargin8.ReadOnly = true;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void InitVars()
		{
			this.columnstatus = base.Columns["status"];
			this.columnquoteno = base.Columns["quoteno"];
			this.columnquoteDate = base.Columns["quoteDate"];
			this.columnCustomer = base.Columns["Customer"];
			this.columninvoiceno = base.Columns["invoiceno"];
			this.columninvoicedate = base.Columns["invoicedate"];
			this.columnjobtype = base.Columns["jobtype"];
			this.columnEstimateItemID = base.Columns["EstimateItemID"];
			this.columnqty1 = base.Columns["qty1"];
			this.columnsubtotal1 = base.Columns["subtotal1"];
			this.columntax1 = base.Columns["tax1"];
			this.columnprofitmargin1 = base.Columns["profitmargin1"];
			this.columnqty2 = base.Columns["qty2"];
			this.columnsubtotal2 = base.Columns["subtotal2"];
			this.columntax2 = base.Columns["tax2"];
			this.columnprofitmargin2 = base.Columns["profitmargin2"];
			this.columnqty3 = base.Columns["qty3"];
			this.columnsubtotal3 = base.Columns["subtotal3"];
			this.columntax3 = base.Columns["tax3"];
			this.columnprofitmargin3 = base.Columns["profitmargin3"];
			this.columnqty4 = base.Columns["qty4"];
			this.columnsubtotal4 = base.Columns["subtotal4"];
			this.columntax4 = base.Columns["tax4"];
			this.columnprofitmargin4 = base.Columns["profitmargin4"];
			this.columnqty5 = base.Columns["qty5"];
			this.columnsubtotal5 = base.Columns["subtotal5"];
			this.columntax5 = base.Columns["tax5"];
			this.columnprofitmargin5 = base.Columns["profitmargin5"];
			this.columnqty6 = base.Columns["qty6"];
			this.columnSubTotal6 = base.Columns["SubTotal6"];
			this.columntax6 = base.Columns["tax6"];
			this.columnprofitmargin6 = base.Columns["profitmargin6"];
			this.columnGP = base.Columns["GP"];
			this.columnGPpercent = base.Columns["GPpercent"];
			this.columndateto = base.Columns["dateto"];
			this.columndatefrom = base.Columns["datefrom"];
			this.columnoptionschosen = base.Columns["optionschosen"];
			this.columnqty7 = base.Columns["qty7"];
			this.columnSubTotal7 = base.Columns["SubTotal7"];
			this.columntax7 = base.Columns["tax7"];
			this.columnprofitmargin7 = base.Columns["profitmargin7"];
			this.columnqty8 = base.Columns["qty8"];
			this.columnSubTotal8 = base.Columns["SubTotal8"];
			this.columntax8 = base.Columns["tax8"];
			this.columnprofitmargin8 = base.Columns["profitmargin8"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow NewPC_Work_In_Progress_InvoicedRow()
		{
			return (WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.PC_Work_In_Progress_InvoicedRowChanged != null)
			{
				this.PC_Work_In_Progress_InvoicedRowChanged(this, new WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRowChangeEvent((WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.PC_Work_In_Progress_InvoicedRowChanging != null)
			{
				this.PC_Work_In_Progress_InvoicedRowChanging(this, new WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRowChangeEvent((WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.PC_Work_In_Progress_InvoicedRowDeleted != null)
			{
				this.PC_Work_In_Progress_InvoicedRowDeleted(this, new WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRowChangeEvent((WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.PC_Work_In_Progress_InvoicedRowDeleting != null)
			{
				this.PC_Work_In_Progress_InvoicedRowDeleting(this, new WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRowChangeEvent((WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void RemovePC_Work_In_Progress_InvoicedRow(WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow row)
		{
			base.Rows.Remove(row);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRowChangeEventHandler PC_Work_In_Progress_InvoicedRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRowChangeEventHandler PC_Work_In_Progress_InvoicedRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRowChangeEventHandler PC_Work_In_Progress_InvoicedRowDeleted;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRowChangeEventHandler PC_Work_In_Progress_InvoicedRowDeleting;
	}

	public class PC_Work_In_Progress_InvoicedRow : DataRow
	{
		private WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedDataTable tablePC_Work_In_Progress_Invoiced;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Customer
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Work_In_Progress_Invoiced.CustomerColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Customer' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.CustomerColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string datefrom
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Work_In_Progress_Invoiced.datefromColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'datefrom' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.datefromColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string dateto
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Work_In_Progress_Invoiced.datetoColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'dateto' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.datetoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int EstimateItemID
		{
			get
			{
				int item;
				try
				{
					item = (int)base[this.tablePC_Work_In_Progress_Invoiced.EstimateItemIDColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'EstimateItemID' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.EstimateItemIDColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string GP
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Work_In_Progress_Invoiced.GPColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'GP' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.GPColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string GPpercent
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Work_In_Progress_Invoiced.GPpercentColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'GPpercent' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.GPpercentColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime invoicedate
		{
			get
			{
				DateTime item;
				try
				{
					item = (DateTime)base[this.tablePC_Work_In_Progress_Invoiced.invoicedateColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invoicedate' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.invoicedateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string invoiceno
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Work_In_Progress_Invoiced.invoicenoColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invoiceno' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.invoicenoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string jobtype
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Work_In_Progress_Invoiced.jobtypeColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobtype' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.jobtypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string optionschosen
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Work_In_Progress_Invoiced.optionschosenColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'optionschosen' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.optionschosenColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal profitmargin1
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.profitmargin1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'profitmargin1' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.profitmargin1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal profitmargin2
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.profitmargin2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'profitmargin2' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.profitmargin2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal profitmargin3
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.profitmargin3Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'profitmargin3' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.profitmargin3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal profitmargin4
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.profitmargin4Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'profitmargin4' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.profitmargin4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal profitmargin5
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.profitmargin5Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'profitmargin5' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.profitmargin5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal profitmargin6
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.profitmargin6Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'profitmargin6' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.profitmargin6Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal profitmargin7
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.profitmargin7Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'profitmargin7' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.profitmargin7Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal profitmargin8
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.profitmargin8Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'profitmargin8' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.profitmargin8Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int qty1
		{
			get
			{
				int item;
				try
				{
					item = (int)base[this.tablePC_Work_In_Progress_Invoiced.qty1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'qty1' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.qty1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int qty2
		{
			get
			{
				int item;
				try
				{
					item = (int)base[this.tablePC_Work_In_Progress_Invoiced.qty2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'qty2' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.qty2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int qty3
		{
			get
			{
				int item;
				try
				{
					item = (int)base[this.tablePC_Work_In_Progress_Invoiced.qty3Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'qty3' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.qty3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int qty4
		{
			get
			{
				int item;
				try
				{
					item = (int)base[this.tablePC_Work_In_Progress_Invoiced.qty4Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'qty4' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.qty4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int qty5
		{
			get
			{
				int item;
				try
				{
					item = (int)base[this.tablePC_Work_In_Progress_Invoiced.qty5Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'qty5' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.qty5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int qty6
		{
			get
			{
				int item;
				try
				{
					item = (int)base[this.tablePC_Work_In_Progress_Invoiced.qty6Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'qty6' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.qty6Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int qty7
		{
			get
			{
				int item;
				try
				{
					item = (int)base[this.tablePC_Work_In_Progress_Invoiced.qty7Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'qty7' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.qty7Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string qty8
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Work_In_Progress_Invoiced.qty8Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'qty8' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.qty8Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime quoteDate
		{
			get
			{
				DateTime item;
				try
				{
					item = (DateTime)base[this.tablePC_Work_In_Progress_Invoiced.quoteDateColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'quoteDate' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.quoteDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string quoteno
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Work_In_Progress_Invoiced.quotenoColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'quoteno' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.quotenoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string status
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Work_In_Progress_Invoiced.statusColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'status' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.statusColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal subtotal1
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.subtotal1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'subtotal1' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.subtotal1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal subtotal2
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.subtotal2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'subtotal2' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.subtotal2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal subtotal3
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.subtotal3Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'subtotal3' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.subtotal3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal subtotal4
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.subtotal4Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'subtotal4' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.subtotal4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal subtotal5
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.subtotal5Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'subtotal5' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.subtotal5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal SubTotal6
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.SubTotal6Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'SubTotal6' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.SubTotal6Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal SubTotal7
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.SubTotal7Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'SubTotal7' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.SubTotal7Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal SubTotal8
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.SubTotal8Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'SubTotal8' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.SubTotal8Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal tax1
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.tax1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'tax1' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.tax1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal tax2
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.tax2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'tax2' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.tax2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal tax3
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.tax3Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'tax3' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.tax3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal tax4
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.tax4Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'tax4' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.tax4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal tax5
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.tax5Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'tax5' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.tax5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal tax6
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.tax6Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'tax6' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.tax6Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal tax7
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.tax7Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'tax7' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.tax7Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal tax8
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Work_In_Progress_Invoiced.tax8Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'tax8' in table 'PC_Work_In_Progress_Invoiced' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Work_In_Progress_Invoiced.tax8Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal PC_Work_In_Progress_InvoicedRow(DataRowBuilder rb) : base(rb)
		{
			this.tablePC_Work_In_Progress_Invoiced = (WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsCustomerNull()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.CustomerColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsdatefromNull()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.datefromColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsdatetoNull()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.datetoColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsEstimateItemIDNull()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.EstimateItemIDColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsGPNull()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.GPColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsGPpercentNull()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.GPpercentColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsinvoicedateNull()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.invoicedateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsinvoicenoNull()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.invoicenoColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsjobtypeNull()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.jobtypeColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsoptionschosenNull()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.optionschosenColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isprofitmargin1Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.profitmargin1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isprofitmargin2Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.profitmargin2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isprofitmargin3Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.profitmargin3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isprofitmargin4Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.profitmargin4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isprofitmargin5Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.profitmargin5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isprofitmargin6Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.profitmargin6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isprofitmargin7Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.profitmargin7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isprofitmargin8Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.profitmargin8Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isqty1Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.qty1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isqty2Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.qty2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isqty3Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.qty3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isqty4Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.qty4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isqty5Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.qty5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isqty6Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.qty6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isqty7Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.qty7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isqty8Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.qty8Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsquoteDateNull()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.quoteDateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsquotenoNull()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.quotenoColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsstatusNull()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.statusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Issubtotal1Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.subtotal1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Issubtotal2Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.subtotal2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Issubtotal3Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.subtotal3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Issubtotal4Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.subtotal4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Issubtotal5Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.subtotal5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsSubTotal6Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.SubTotal6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsSubTotal7Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.SubTotal7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsSubTotal8Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.SubTotal8Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Istax1Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.tax1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Istax2Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.tax2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Istax3Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.tax3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Istax4Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.tax4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Istax5Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.tax5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Istax6Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.tax6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Istax7Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.tax7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Istax8Null()
		{
			return base.IsNull(this.tablePC_Work_In_Progress_Invoiced.tax8Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetCustomerNull()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.CustomerColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetdatefromNull()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.datefromColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetdatetoNull()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.datetoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetEstimateItemIDNull()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.EstimateItemIDColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetGPNull()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.GPColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetGPpercentNull()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.GPpercentColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetinvoicedateNull()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.invoicedateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetinvoicenoNull()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.invoicenoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetjobtypeNull()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.jobtypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetoptionschosenNull()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.optionschosenColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setprofitmargin1Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.profitmargin1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setprofitmargin2Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.profitmargin2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setprofitmargin3Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.profitmargin3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setprofitmargin4Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.profitmargin4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setprofitmargin5Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.profitmargin5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setprofitmargin6Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.profitmargin6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setprofitmargin7Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.profitmargin7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setprofitmargin8Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.profitmargin8Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setqty1Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.qty1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setqty2Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.qty2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setqty3Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.qty3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setqty4Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.qty4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setqty5Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.qty5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setqty6Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.qty6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setqty7Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.qty7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setqty8Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.qty8Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetquoteDateNull()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.quoteDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetquotenoNull()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.quotenoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetstatusNull()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.statusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setsubtotal1Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.subtotal1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setsubtotal2Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.subtotal2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setsubtotal3Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.subtotal3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setsubtotal4Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.subtotal4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setsubtotal5Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.subtotal5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetSubTotal6Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.SubTotal6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetSubTotal7Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.SubTotal7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetSubTotal8Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.SubTotal8Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Settax1Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.tax1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Settax2Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.tax2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Settax3Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.tax3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Settax4Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.tax4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Settax5Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.tax5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Settax6Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.tax6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Settax7Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.tax7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Settax8Null()
		{
			base[this.tablePC_Work_In_Progress_Invoiced.tax8Column] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class PC_Work_In_Progress_InvoicedRowChangeEvent : EventArgs
	{
		private WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow eventRow;

		private DataRowAction eventAction;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataRowAction Action
		{
			get
			{
				return this.eventAction;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow Row
		{
			get
			{
				return this.eventRow;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public PC_Work_In_Progress_InvoicedRowChangeEvent(WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRow row, DataRowAction action)
		{
			this.eventRow = row;
			this.eventAction = action;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void PC_Work_In_Progress_InvoicedRowChangeEventHandler(object sender, WorkInProgressInvoiced.PC_Work_In_Progress_InvoicedRowChangeEvent e);
}
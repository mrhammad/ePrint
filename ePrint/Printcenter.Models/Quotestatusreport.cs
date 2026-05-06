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
[XmlRoot("Quotestatusreport")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
public class Quotestatusreport : DataSet
{
	private Quotestatusreport.PC_Quote_Status_reportDataTable tablePC_Quote_Status_report;

	private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;

	[Browsable(false)]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Quotestatusreport.PC_Quote_Status_reportDataTable PC_Quote_Status_report
	{
		get
		{
			return this.tablePC_Quote_Status_report;
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
	public Quotestatusreport()
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
	protected Quotestatusreport(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
			if (dataSet.Tables["PC_Quote_Status_report"] != null)
			{
				base.Tables.Add(new Quotestatusreport.PC_Quote_Status_reportDataTable(dataSet.Tables["PC_Quote_Status_report"]));
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
		Quotestatusreport schemaSerializationMode = (Quotestatusreport)base.Clone();
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
		Quotestatusreport quotestatusreport = new Quotestatusreport();
		XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
		{
			Namespace = quotestatusreport.Namespace
		};
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType1.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = quotestatusreport.GetSchemaSerializable();
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
		base.DataSetName = "Quotestatusreport";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/Quotestatusreport.xsd";
		base.EnforceConstraints = true;
		this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
		this.tablePC_Quote_Status_report = new Quotestatusreport.PC_Quote_Status_reportDataTable();
		base.Tables.Add(this.tablePC_Quote_Status_report);
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
		this.tablePC_Quote_Status_report = (Quotestatusreport.PC_Quote_Status_reportDataTable)base.Tables["PC_Quote_Status_report"];
		if (initTable && this.tablePC_Quote_Status_report != null)
		{
			this.tablePC_Quote_Status_report.InitVars();
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
		if (dataSet.Tables["PC_Quote_Status_report"] != null)
		{
			base.Tables.Add(new Quotestatusreport.PC_Quote_Status_reportDataTable(dataSet.Tables["PC_Quote_Status_report"]));
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
	private bool ShouldSerializePC_Quote_Status_report()
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
	public class PC_Quote_Status_reportDataTable : TypedTableBase<Quotestatusreport.PC_Quote_Status_reportRow>
	{
		private DataColumn columncentername;

		private DataColumn columneststatusid;

		private DataColumn columncurrentstatus;

		private DataColumn columndateofstatus;

		private DataColumn columnquoteno;

		private DataColumn columnquoteDate;

		private DataColumn columninvoiceno;

		private DataColumn columninvoicedate;

		private DataColumn columnCustomer;

		private DataColumn columnEstimateItemID;

		private DataColumn columnjobtype;

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

		private DataColumn columnqty7;

		private DataColumn columnSubTotal7;

		private DataColumn columntax7;

		private DataColumn columnprofitmargin7;

		private DataColumn columnqty8;

		private DataColumn columnSubTotal8;

		private DataColumn columntax8;

		private DataColumn columnprofitmargin8;

		private DataColumn columnoutstandingamt;

		private DataColumn columnGP;

		private DataColumn columnGPpercent;

		private DataColumn columnquotecreator;

		private DataColumn columnaccountmanager;

		private DataColumn columnjobnumber;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn accountmanagerColumn
		{
			get
			{
				return this.columnaccountmanager;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn centernameColumn
		{
			get
			{
				return this.columncentername;
			}
		}

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
		public DataColumn currentstatusColumn
		{
			get
			{
				return this.columncurrentstatus;
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
		public DataColumn dateofstatusColumn
		{
			get
			{
				return this.columndateofstatus;
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
		public DataColumn eststatusidColumn
		{
			get
			{
				return this.columneststatusid;
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
		public Quotestatusreport.PC_Quote_Status_reportRow this[int index]
		{
			get
			{
				return (Quotestatusreport.PC_Quote_Status_reportRow)base.Rows[index];
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobnumberColumn
		{
			get
			{
				return this.columnjobnumber;
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
		public DataColumn outstandingamtColumn
		{
			get
			{
				return this.columnoutstandingamt;
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
		public DataColumn quotecreatorColumn
		{
			get
			{
				return this.columnquotecreator;
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
		public PC_Quote_Status_reportDataTable()
		{
			base.TableName = "PC_Quote_Status_report";
			this.BeginInit();
			this.InitClass();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal PC_Quote_Status_reportDataTable(DataTable table)
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
		protected PC_Quote_Status_reportDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this.InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void AddPC_Quote_Status_reportRow(Quotestatusreport.PC_Quote_Status_reportRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Quotestatusreport.PC_Quote_Status_reportRow AddPC_Quote_Status_reportRow(string centername, int eststatusid, string currentstatus, DateTime dateofstatus, string quoteno, DateTime quoteDate, string invoiceno, DateTime invoicedate, string Customer, int EstimateItemID, string jobtype, int qty1, decimal subtotal1, decimal tax1, decimal profitmargin1, int qty2, decimal subtotal2, decimal tax2, decimal profitmargin2, int qty3, decimal subtotal3, decimal tax3, decimal profitmargin3, int qty4, decimal subtotal4, decimal tax4, decimal profitmargin4, int qty5, decimal subtotal5, decimal tax5, decimal profitmargin5, int qty6, decimal SubTotal6, decimal tax6, decimal profitmargin6, int qty7, decimal SubTotal7, decimal tax7, decimal profitmargin7, string qty8, decimal SubTotal8, decimal tax8, decimal profitmargin8, string outstandingamt, string GP, string GPpercent, string quotecreator, string accountmanager, string jobnumber)
		{
			Quotestatusreport.PC_Quote_Status_reportRow pCQuoteStatusReportRow = (Quotestatusreport.PC_Quote_Status_reportRow)base.NewRow();
			object[] objArray = new object[] { centername, eststatusid, currentstatus, dateofstatus, quoteno, quoteDate, invoiceno, invoicedate, Customer, EstimateItemID, jobtype, qty1, subtotal1, tax1, profitmargin1, qty2, subtotal2, tax2, profitmargin2, qty3, subtotal3, tax3, profitmargin3, qty4, subtotal4, tax4, profitmargin4, qty5, subtotal5, tax5, profitmargin5, qty6, SubTotal6, tax6, profitmargin6, qty7, SubTotal7, tax7, profitmargin7, qty8, SubTotal8, tax8, profitmargin8, outstandingamt, GP, GPpercent, quotecreator, accountmanager, jobnumber };
			pCQuoteStatusReportRow.ItemArray = objArray;
			base.Rows.Add(pCQuoteStatusReportRow);
			return pCQuoteStatusReportRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Quotestatusreport.PC_Quote_Status_reportDataTable pCQuoteStatusReportDataTable = (Quotestatusreport.PC_Quote_Status_reportDataTable)base.Clone();
			pCQuoteStatusReportDataTable.InitVars();
			return pCQuoteStatusReportDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Quotestatusreport.PC_Quote_Status_reportDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Quotestatusreport.PC_Quote_Status_reportRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType;
			XmlSchema xmlSchema;
			XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Quotestatusreport quotestatusreport = new Quotestatusreport();
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
				FixedValue = quotestatusreport.Namespace
			};
			xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
			{
				Name = "tableTypeName",
				FixedValue = "PC_Quote_Status_reportDataTable"
			};
			xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
			xmlSchemaComplexType1.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = quotestatusreport.GetSchemaSerializable();
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
			this.columncentername = new DataColumn("centername", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columncentername);
			this.columneststatusid = new DataColumn("eststatusid", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columneststatusid);
			this.columncurrentstatus = new DataColumn("currentstatus", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columncurrentstatus);
			this.columndateofstatus = new DataColumn("dateofstatus", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.columndateofstatus);
			this.columnquoteno = new DataColumn("quoteno", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnquoteno);
			this.columnquoteDate = new DataColumn("quoteDate", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.columnquoteDate);
			this.columninvoiceno = new DataColumn("invoiceno", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columninvoiceno);
			this.columninvoicedate = new DataColumn("invoicedate", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.columninvoicedate);
			this.columnCustomer = new DataColumn("Customer", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnCustomer);
			this.columnEstimateItemID = new DataColumn("EstimateItemID", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columnEstimateItemID);
			this.columnjobtype = new DataColumn("jobtype", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnjobtype);
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
			this.columnoutstandingamt = new DataColumn("outstandingamt", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnoutstandingamt);
			this.columnGP = new DataColumn("GP", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnGP);
			this.columnGPpercent = new DataColumn("GPpercent", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnGPpercent);
			this.columnquotecreator = new DataColumn("quotecreator", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnquotecreator);
			this.columnaccountmanager = new DataColumn("accountmanager", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnaccountmanager);
			this.columnjobnumber = new DataColumn("jobnumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnjobnumber);
			this.columncentername.ReadOnly = true;
			this.columncentername.MaxLength = 1;
			this.columneststatusid.AllowDBNull = false;
			this.columncurrentstatus.MaxLength = 100;
			this.columnquoteno.MaxLength = 25;
			this.columninvoiceno.MaxLength = 25;
			this.columnCustomer.MaxLength = 300;
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
			this.columnqty7.ReadOnly = true;
			this.columnSubTotal7.ReadOnly = true;
			this.columntax7.ReadOnly = true;
			this.columnprofitmargin7.ReadOnly = true;
			this.columnqty8.ReadOnly = true;
			this.columnqty8.MaxLength = 1;
			this.columnSubTotal8.ReadOnly = true;
			this.columntax8.ReadOnly = true;
			this.columnprofitmargin8.ReadOnly = true;
			this.columnoutstandingamt.ReadOnly = true;
			this.columnoutstandingamt.MaxLength = 1;
			this.columnGP.ReadOnly = true;
			this.columnGP.MaxLength = 1;
			this.columnGPpercent.ReadOnly = true;
			this.columnGPpercent.MaxLength = 1;
			this.columnquotecreator.ReadOnly = true;
			this.columnquotecreator.MaxLength = 401;
			this.columnaccountmanager.MaxLength = 200;
			this.columnjobnumber.MaxLength = 50;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void InitVars()
		{
			this.columncentername = base.Columns["centername"];
			this.columneststatusid = base.Columns["eststatusid"];
			this.columncurrentstatus = base.Columns["currentstatus"];
			this.columndateofstatus = base.Columns["dateofstatus"];
			this.columnquoteno = base.Columns["quoteno"];
			this.columnquoteDate = base.Columns["quoteDate"];
			this.columninvoiceno = base.Columns["invoiceno"];
			this.columninvoicedate = base.Columns["invoicedate"];
			this.columnCustomer = base.Columns["Customer"];
			this.columnEstimateItemID = base.Columns["EstimateItemID"];
			this.columnjobtype = base.Columns["jobtype"];
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
			this.columnqty7 = base.Columns["qty7"];
			this.columnSubTotal7 = base.Columns["SubTotal7"];
			this.columntax7 = base.Columns["tax7"];
			this.columnprofitmargin7 = base.Columns["profitmargin7"];
			this.columnqty8 = base.Columns["qty8"];
			this.columnSubTotal8 = base.Columns["SubTotal8"];
			this.columntax8 = base.Columns["tax8"];
			this.columnprofitmargin8 = base.Columns["profitmargin8"];
			this.columnoutstandingamt = base.Columns["outstandingamt"];
			this.columnGP = base.Columns["GP"];
			this.columnGPpercent = base.Columns["GPpercent"];
			this.columnquotecreator = base.Columns["quotecreator"];
			this.columnaccountmanager = base.Columns["accountmanager"];
			this.columnjobnumber = base.Columns["jobnumber"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Quotestatusreport.PC_Quote_Status_reportRow NewPC_Quote_Status_reportRow()
		{
			return (Quotestatusreport.PC_Quote_Status_reportRow)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Quotestatusreport.PC_Quote_Status_reportRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.PC_Quote_Status_reportRowChanged != null)
			{
				this.PC_Quote_Status_reportRowChanged(this, new Quotestatusreport.PC_Quote_Status_reportRowChangeEvent((Quotestatusreport.PC_Quote_Status_reportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.PC_Quote_Status_reportRowChanging != null)
			{
				this.PC_Quote_Status_reportRowChanging(this, new Quotestatusreport.PC_Quote_Status_reportRowChangeEvent((Quotestatusreport.PC_Quote_Status_reportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.PC_Quote_Status_reportRowDeleted != null)
			{
				this.PC_Quote_Status_reportRowDeleted(this, new Quotestatusreport.PC_Quote_Status_reportRowChangeEvent((Quotestatusreport.PC_Quote_Status_reportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.PC_Quote_Status_reportRowDeleting != null)
			{
				this.PC_Quote_Status_reportRowDeleting(this, new Quotestatusreport.PC_Quote_Status_reportRowChangeEvent((Quotestatusreport.PC_Quote_Status_reportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void RemovePC_Quote_Status_reportRow(Quotestatusreport.PC_Quote_Status_reportRow row)
		{
			base.Rows.Remove(row);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Quotestatusreport.PC_Quote_Status_reportRowChangeEventHandler PC_Quote_Status_reportRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Quotestatusreport.PC_Quote_Status_reportRowChangeEventHandler PC_Quote_Status_reportRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Quotestatusreport.PC_Quote_Status_reportRowChangeEventHandler PC_Quote_Status_reportRowDeleted;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Quotestatusreport.PC_Quote_Status_reportRowChangeEventHandler PC_Quote_Status_reportRowDeleting;
	}

	public class PC_Quote_Status_reportRow : DataRow
	{
		private Quotestatusreport.PC_Quote_Status_reportDataTable tablePC_Quote_Status_report;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string accountmanager
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Quote_Status_report.accountmanagerColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'accountmanager' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.accountmanagerColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string centername
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Quote_Status_report.centernameColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'centername' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.centernameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string currentstatus
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Quote_Status_report.currentstatusColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'currentstatus' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.currentstatusColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Customer
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Quote_Status_report.CustomerColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Customer' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.CustomerColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime dateofstatus
		{
			get
			{
				DateTime item;
				try
				{
					item = (DateTime)base[this.tablePC_Quote_Status_report.dateofstatusColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'dateofstatus' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.dateofstatusColumn] = value;
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
					item = (int)base[this.tablePC_Quote_Status_report.EstimateItemIDColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'EstimateItemID' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.EstimateItemIDColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int eststatusid
		{
			get
			{
				return (int)base[this.tablePC_Quote_Status_report.eststatusidColumn];
			}
			set
			{
				base[this.tablePC_Quote_Status_report.eststatusidColumn] = value;
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
					item = (string)base[this.tablePC_Quote_Status_report.GPColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'GP' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.GPColumn] = value;
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
					item = (string)base[this.tablePC_Quote_Status_report.GPpercentColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'GPpercent' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.GPpercentColumn] = value;
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
					item = (DateTime)base[this.tablePC_Quote_Status_report.invoicedateColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invoicedate' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.invoicedateColumn] = value;
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
					item = (string)base[this.tablePC_Quote_Status_report.invoicenoColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invoiceno' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.invoicenoColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string jobnumber
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Quote_Status_report.jobnumberColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobnumber' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.jobnumberColumn] = value;
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
					item = (string)base[this.tablePC_Quote_Status_report.jobtypeColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobtype' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.jobtypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string outstandingamt
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Quote_Status_report.outstandingamtColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'outstandingamt' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.outstandingamtColumn] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.profitmargin1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'profitmargin1' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.profitmargin1Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.profitmargin2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'profitmargin2' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.profitmargin2Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.profitmargin3Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'profitmargin3' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.profitmargin3Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.profitmargin4Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'profitmargin4' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.profitmargin4Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.profitmargin5Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'profitmargin5' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.profitmargin5Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.profitmargin6Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'profitmargin6' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.profitmargin6Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.profitmargin7Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'profitmargin7' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.profitmargin7Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.profitmargin8Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'profitmargin8' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.profitmargin8Column] = value;
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
					item = (int)base[this.tablePC_Quote_Status_report.qty1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'qty1' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.qty1Column] = value;
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
					item = (int)base[this.tablePC_Quote_Status_report.qty2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'qty2' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.qty2Column] = value;
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
					item = (int)base[this.tablePC_Quote_Status_report.qty3Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'qty3' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.qty3Column] = value;
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
					item = (int)base[this.tablePC_Quote_Status_report.qty4Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'qty4' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.qty4Column] = value;
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
					item = (int)base[this.tablePC_Quote_Status_report.qty5Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'qty5' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.qty5Column] = value;
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
					item = (int)base[this.tablePC_Quote_Status_report.qty6Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'qty6' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.qty6Column] = value;
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
					item = (int)base[this.tablePC_Quote_Status_report.qty7Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'qty7' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.qty7Column] = value;
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
					item = (string)base[this.tablePC_Quote_Status_report.qty8Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'qty8' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.qty8Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string quotecreator
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Quote_Status_report.quotecreatorColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'quotecreator' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.quotecreatorColumn] = value;
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
					item = (DateTime)base[this.tablePC_Quote_Status_report.quoteDateColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'quoteDate' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.quoteDateColumn] = value;
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
					item = (string)base[this.tablePC_Quote_Status_report.quotenoColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'quoteno' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.quotenoColumn] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.subtotal1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'subtotal1' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.subtotal1Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.subtotal2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'subtotal2' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.subtotal2Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.subtotal3Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'subtotal3' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.subtotal3Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.subtotal4Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'subtotal4' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.subtotal4Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.subtotal5Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'subtotal5' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.subtotal5Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.SubTotal6Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'SubTotal6' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.SubTotal6Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.SubTotal7Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'SubTotal7' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.SubTotal7Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.SubTotal8Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'SubTotal8' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.SubTotal8Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.tax1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'tax1' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.tax1Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.tax2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'tax2' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.tax2Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.tax3Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'tax3' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.tax3Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.tax4Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'tax4' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.tax4Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.tax5Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'tax5' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.tax5Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.tax6Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'tax6' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.tax6Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.tax7Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'tax7' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.tax7Column] = value;
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
					item = (decimal)base[this.tablePC_Quote_Status_report.tax8Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'tax8' in table 'PC_Quote_Status_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Quote_Status_report.tax8Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal PC_Quote_Status_reportRow(DataRowBuilder rb) : base(rb)
		{
			this.tablePC_Quote_Status_report = (Quotestatusreport.PC_Quote_Status_reportDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsaccountmanagerNull()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.accountmanagerColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IscenternameNull()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.centernameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IscurrentstatusNull()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.currentstatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsCustomerNull()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.CustomerColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsdateofstatusNull()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.dateofstatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsEstimateItemIDNull()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.EstimateItemIDColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsGPNull()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.GPColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsGPpercentNull()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.GPpercentColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsinvoicedateNull()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.invoicedateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsinvoicenoNull()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.invoicenoColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsjobnumberNull()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.jobnumberColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsjobtypeNull()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.jobtypeColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsoutstandingamtNull()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.outstandingamtColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isprofitmargin1Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.profitmargin1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isprofitmargin2Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.profitmargin2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isprofitmargin3Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.profitmargin3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isprofitmargin4Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.profitmargin4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isprofitmargin5Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.profitmargin5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isprofitmargin6Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.profitmargin6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isprofitmargin7Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.profitmargin7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isprofitmargin8Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.profitmargin8Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isqty1Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.qty1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isqty2Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.qty2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isqty3Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.qty3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isqty4Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.qty4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isqty5Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.qty5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isqty6Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.qty6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isqty7Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.qty7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isqty8Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.qty8Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsquotecreatorNull()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.quotecreatorColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsquoteDateNull()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.quoteDateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsquotenoNull()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.quotenoColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Issubtotal1Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.subtotal1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Issubtotal2Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.subtotal2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Issubtotal3Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.subtotal3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Issubtotal4Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.subtotal4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Issubtotal5Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.subtotal5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsSubTotal6Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.SubTotal6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsSubTotal7Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.SubTotal7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsSubTotal8Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.SubTotal8Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Istax1Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.tax1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Istax2Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.tax2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Istax3Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.tax3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Istax4Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.tax4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Istax5Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.tax5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Istax6Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.tax6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Istax7Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.tax7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Istax8Null()
		{
			return base.IsNull(this.tablePC_Quote_Status_report.tax8Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetaccountmanagerNull()
		{
			base[this.tablePC_Quote_Status_report.accountmanagerColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetcenternameNull()
		{
			base[this.tablePC_Quote_Status_report.centernameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetcurrentstatusNull()
		{
			base[this.tablePC_Quote_Status_report.currentstatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetCustomerNull()
		{
			base[this.tablePC_Quote_Status_report.CustomerColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetdateofstatusNull()
		{
			base[this.tablePC_Quote_Status_report.dateofstatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetEstimateItemIDNull()
		{
			base[this.tablePC_Quote_Status_report.EstimateItemIDColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetGPNull()
		{
			base[this.tablePC_Quote_Status_report.GPColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetGPpercentNull()
		{
			base[this.tablePC_Quote_Status_report.GPpercentColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetinvoicedateNull()
		{
			base[this.tablePC_Quote_Status_report.invoicedateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetinvoicenoNull()
		{
			base[this.tablePC_Quote_Status_report.invoicenoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetjobnumberNull()
		{
			base[this.tablePC_Quote_Status_report.jobnumberColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetjobtypeNull()
		{
			base[this.tablePC_Quote_Status_report.jobtypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetoutstandingamtNull()
		{
			base[this.tablePC_Quote_Status_report.outstandingamtColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setprofitmargin1Null()
		{
			base[this.tablePC_Quote_Status_report.profitmargin1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setprofitmargin2Null()
		{
			base[this.tablePC_Quote_Status_report.profitmargin2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setprofitmargin3Null()
		{
			base[this.tablePC_Quote_Status_report.profitmargin3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setprofitmargin4Null()
		{
			base[this.tablePC_Quote_Status_report.profitmargin4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setprofitmargin5Null()
		{
			base[this.tablePC_Quote_Status_report.profitmargin5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setprofitmargin6Null()
		{
			base[this.tablePC_Quote_Status_report.profitmargin6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setprofitmargin7Null()
		{
			base[this.tablePC_Quote_Status_report.profitmargin7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setprofitmargin8Null()
		{
			base[this.tablePC_Quote_Status_report.profitmargin8Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setqty1Null()
		{
			base[this.tablePC_Quote_Status_report.qty1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setqty2Null()
		{
			base[this.tablePC_Quote_Status_report.qty2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setqty3Null()
		{
			base[this.tablePC_Quote_Status_report.qty3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setqty4Null()
		{
			base[this.tablePC_Quote_Status_report.qty4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setqty5Null()
		{
			base[this.tablePC_Quote_Status_report.qty5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setqty6Null()
		{
			base[this.tablePC_Quote_Status_report.qty6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setqty7Null()
		{
			base[this.tablePC_Quote_Status_report.qty7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setqty8Null()
		{
			base[this.tablePC_Quote_Status_report.qty8Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetquotecreatorNull()
		{
			base[this.tablePC_Quote_Status_report.quotecreatorColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetquoteDateNull()
		{
			base[this.tablePC_Quote_Status_report.quoteDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetquotenoNull()
		{
			base[this.tablePC_Quote_Status_report.quotenoColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setsubtotal1Null()
		{
			base[this.tablePC_Quote_Status_report.subtotal1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setsubtotal2Null()
		{
			base[this.tablePC_Quote_Status_report.subtotal2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setsubtotal3Null()
		{
			base[this.tablePC_Quote_Status_report.subtotal3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setsubtotal4Null()
		{
			base[this.tablePC_Quote_Status_report.subtotal4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setsubtotal5Null()
		{
			base[this.tablePC_Quote_Status_report.subtotal5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetSubTotal6Null()
		{
			base[this.tablePC_Quote_Status_report.SubTotal6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetSubTotal7Null()
		{
			base[this.tablePC_Quote_Status_report.SubTotal7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetSubTotal8Null()
		{
			base[this.tablePC_Quote_Status_report.SubTotal8Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Settax1Null()
		{
			base[this.tablePC_Quote_Status_report.tax1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Settax2Null()
		{
			base[this.tablePC_Quote_Status_report.tax2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Settax3Null()
		{
			base[this.tablePC_Quote_Status_report.tax3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Settax4Null()
		{
			base[this.tablePC_Quote_Status_report.tax4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Settax5Null()
		{
			base[this.tablePC_Quote_Status_report.tax5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Settax6Null()
		{
			base[this.tablePC_Quote_Status_report.tax6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Settax7Null()
		{
			base[this.tablePC_Quote_Status_report.tax7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Settax8Null()
		{
			base[this.tablePC_Quote_Status_report.tax8Column] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class PC_Quote_Status_reportRowChangeEvent : EventArgs
	{
		private Quotestatusreport.PC_Quote_Status_reportRow eventRow;

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
		public Quotestatusreport.PC_Quote_Status_reportRow Row
		{
			get
			{
				return this.eventRow;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public PC_Quote_Status_reportRowChangeEvent(Quotestatusreport.PC_Quote_Status_reportRow row, DataRowAction action)
		{
			this.eventRow = row;
			this.eventAction = action;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void PC_Quote_Status_reportRowChangeEventHandler(object sender, Quotestatusreport.PC_Quote_Status_reportRowChangeEvent e);
}
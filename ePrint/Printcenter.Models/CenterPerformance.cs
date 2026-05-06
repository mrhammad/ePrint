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
[XmlRoot("CenterPerformance")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
public class CenterPerformance : DataSet
{
	private CenterPerformance.PC_Center_Performance_reportDataTable tablePC_Center_Performance_report;

	private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;

	[Browsable(false)]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public CenterPerformance.PC_Center_Performance_reportDataTable PC_Center_Performance_report
	{
		get
		{
			return this.tablePC_Center_Performance_report;
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
	public CenterPerformance()
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
	protected CenterPerformance(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
			if (dataSet.Tables["PC_Center_Performance_report"] != null)
			{
				base.Tables.Add(new CenterPerformance.PC_Center_Performance_reportDataTable(dataSet.Tables["PC_Center_Performance_report"]));
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
		CenterPerformance schemaSerializationMode = (CenterPerformance)base.Clone();
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
		CenterPerformance centerPerformance = new CenterPerformance();
		XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
		{
			Namespace = centerPerformance.Namespace
		};
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType1.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = centerPerformance.GetSchemaSerializable();
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
		base.DataSetName = "CenterPerformance";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/CenterPerformance.xsd";
		base.EnforceConstraints = true;
		this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
		this.tablePC_Center_Performance_report = new CenterPerformance.PC_Center_Performance_reportDataTable();
		base.Tables.Add(this.tablePC_Center_Performance_report);
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
		this.tablePC_Center_Performance_report = (CenterPerformance.PC_Center_Performance_reportDataTable)base.Tables["PC_Center_Performance_report"];
		if (initTable && this.tablePC_Center_Performance_report != null)
		{
			this.tablePC_Center_Performance_report.InitVars();
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
		if (dataSet.Tables["PC_Center_Performance_report"] != null)
		{
			base.Tables.Add(new CenterPerformance.PC_Center_Performance_reportDataTable(dataSet.Tables["PC_Center_Performance_report"]));
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
	private bool ShouldSerializePC_Center_Performance_report()
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
	public class PC_Center_Performance_reportDataTable : TypedTableBase<CenterPerformance.PC_Center_Performance_reportRow>
	{
		private DataColumn columnestimateid;

		private DataColumn columnestimateitemid;

		private DataColumn columnEstimateType;

		private DataColumn columnnoofqoutes;

		private DataColumn columnestsubtotal1;

		private DataColumn columnesttax1;

		private DataColumn columnestsubtotal2;

		private DataColumn columnesttax2;

		private DataColumn columnestsubtotal3;

		private DataColumn columnesttax3;

		private DataColumn columnestsubtotal4;

		private DataColumn columnesttax4;

		private DataColumn columnestsubtotal5;

		private DataColumn columnesttax5;

		private DataColumn columnestSubTotal6;

		private DataColumn columnesttax6;

		private DataColumn columnestSubTotal7;

		private DataColumn columnesttax7;

		private DataColumn columnestSubTotal8;

		private DataColumn columnesttax8;

		private DataColumn columnjobsubtotal1;

		private DataColumn columnjobtax1;

		private DataColumn columnjobsubtotal2;

		private DataColumn columnjobtax2;

		private DataColumn columnjobsubtotal3;

		private DataColumn columnjobtax3;

		private DataColumn columnjobsubtotal4;

		private DataColumn columnjobtax4;

		private DataColumn columnjobsubtotal5;

		private DataColumn columnjobtax5;

		private DataColumn columnjobSubTotal6;

		private DataColumn columnjobtax6;

		private DataColumn columnjobSubTotal7;

		private DataColumn columnjobtax7;

		private DataColumn columnjobSubTotal8;

		private DataColumn columnjobtax8;

		private DataColumn columninvsubtotal1;

		private DataColumn columninvtax1;

		private DataColumn columninvsubtotal2;

		private DataColumn columninvtax2;

		private DataColumn columninvsubtotal3;

		private DataColumn columninvtax3;

		private DataColumn columninvsubtotal4;

		private DataColumn columninvtax4;

		private DataColumn columninvsubtotal5;

		private DataColumn columninvtax5;

		private DataColumn columninvSubTotal6;

		private DataColumn columninvtax6;

		private DataColumn columninvSubTotal7;

		private DataColumn columninvtax7;

		private DataColumn columninvSubTotal8;

		private DataColumn columninvtax8;

		private DataColumn columnquotesexgst;

		private DataColumn columnavgquoteval;

		private DataColumn columnnoofjobs;

		private DataColumn columnnoofinvoice;

		private DataColumn columncompanyid;

		private DataColumn columnnoofcontact;

		private DataColumn columnnoofclient;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn avgquotevalColumn
		{
			get
			{
				return this.columnavgquoteval;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn companyidColumn
		{
			get
			{
				return this.columncompanyid;
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
		public DataColumn estimateidColumn
		{
			get
			{
				return this.columnestimateid;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn estimateitemidColumn
		{
			get
			{
				return this.columnestimateitemid;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn EstimateTypeColumn
		{
			get
			{
				return this.columnEstimateType;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn estsubtotal1Column
		{
			get
			{
				return this.columnestsubtotal1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn estsubtotal2Column
		{
			get
			{
				return this.columnestsubtotal2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn estsubtotal3Column
		{
			get
			{
				return this.columnestsubtotal3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn estsubtotal4Column
		{
			get
			{
				return this.columnestsubtotal4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn estsubtotal5Column
		{
			get
			{
				return this.columnestsubtotal5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn estSubTotal6Column
		{
			get
			{
				return this.columnestSubTotal6;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn estSubTotal7Column
		{
			get
			{
				return this.columnestSubTotal7;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn estSubTotal8Column
		{
			get
			{
				return this.columnestSubTotal8;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn esttax1Column
		{
			get
			{
				return this.columnesttax1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn esttax2Column
		{
			get
			{
				return this.columnesttax2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn esttax3Column
		{
			get
			{
				return this.columnesttax3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn esttax4Column
		{
			get
			{
				return this.columnesttax4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn esttax5Column
		{
			get
			{
				return this.columnesttax5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn esttax6Column
		{
			get
			{
				return this.columnesttax6;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn esttax7Column
		{
			get
			{
				return this.columnesttax7;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn esttax8Column
		{
			get
			{
				return this.columnesttax8;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invsubtotal1Column
		{
			get
			{
				return this.columninvsubtotal1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invsubtotal2Column
		{
			get
			{
				return this.columninvsubtotal2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invsubtotal3Column
		{
			get
			{
				return this.columninvsubtotal3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invsubtotal4Column
		{
			get
			{
				return this.columninvsubtotal4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invsubtotal5Column
		{
			get
			{
				return this.columninvsubtotal5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invSubTotal6Column
		{
			get
			{
				return this.columninvSubTotal6;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invSubTotal7Column
		{
			get
			{
				return this.columninvSubTotal7;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invSubTotal8Column
		{
			get
			{
				return this.columninvSubTotal8;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invtax1Column
		{
			get
			{
				return this.columninvtax1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invtax2Column
		{
			get
			{
				return this.columninvtax2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invtax3Column
		{
			get
			{
				return this.columninvtax3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invtax4Column
		{
			get
			{
				return this.columninvtax4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invtax5Column
		{
			get
			{
				return this.columninvtax5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invtax6Column
		{
			get
			{
				return this.columninvtax6;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invtax7Column
		{
			get
			{
				return this.columninvtax7;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn invtax8Column
		{
			get
			{
				return this.columninvtax8;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public CenterPerformance.PC_Center_Performance_reportRow this[int index]
		{
			get
			{
				return (CenterPerformance.PC_Center_Performance_reportRow)base.Rows[index];
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobsubtotal1Column
		{
			get
			{
				return this.columnjobsubtotal1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobsubtotal2Column
		{
			get
			{
				return this.columnjobsubtotal2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobsubtotal3Column
		{
			get
			{
				return this.columnjobsubtotal3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobsubtotal4Column
		{
			get
			{
				return this.columnjobsubtotal4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobsubtotal5Column
		{
			get
			{
				return this.columnjobsubtotal5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobSubTotal6Column
		{
			get
			{
				return this.columnjobSubTotal6;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobSubTotal7Column
		{
			get
			{
				return this.columnjobSubTotal7;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobSubTotal8Column
		{
			get
			{
				return this.columnjobSubTotal8;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobtax1Column
		{
			get
			{
				return this.columnjobtax1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobtax2Column
		{
			get
			{
				return this.columnjobtax2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobtax3Column
		{
			get
			{
				return this.columnjobtax3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobtax4Column
		{
			get
			{
				return this.columnjobtax4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobtax5Column
		{
			get
			{
				return this.columnjobtax5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobtax6Column
		{
			get
			{
				return this.columnjobtax6;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobtax7Column
		{
			get
			{
				return this.columnjobtax7;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn jobtax8Column
		{
			get
			{
				return this.columnjobtax8;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn noofclientColumn
		{
			get
			{
				return this.columnnoofclient;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn noofcontactColumn
		{
			get
			{
				return this.columnnoofcontact;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn noofinvoiceColumn
		{
			get
			{
				return this.columnnoofinvoice;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn noofjobsColumn
		{
			get
			{
				return this.columnnoofjobs;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn noofqoutesColumn
		{
			get
			{
				return this.columnnoofqoutes;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn quotesexgstColumn
		{
			get
			{
				return this.columnquotesexgst;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public PC_Center_Performance_reportDataTable()
		{
			base.TableName = "PC_Center_Performance_report";
			this.BeginInit();
			this.InitClass();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal PC_Center_Performance_reportDataTable(DataTable table)
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
		protected PC_Center_Performance_reportDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this.InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void AddPC_Center_Performance_reportRow(CenterPerformance.PC_Center_Performance_reportRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public CenterPerformance.PC_Center_Performance_reportRow AddPC_Center_Performance_reportRow(string EstimateType, int noofqoutes, decimal estsubtotal1, decimal esttax1, decimal estsubtotal2, decimal esttax2, decimal estsubtotal3, decimal esttax3, decimal estsubtotal4, decimal esttax4, decimal estsubtotal5, decimal esttax5, decimal estSubTotal6, decimal esttax6, decimal estSubTotal7, decimal esttax7, decimal estSubTotal8, decimal esttax8, decimal jobsubtotal1, decimal jobtax1, decimal jobsubtotal2, decimal jobtax2, decimal jobsubtotal3, decimal jobtax3, decimal jobsubtotal4, decimal jobtax4, decimal jobsubtotal5, decimal jobtax5, decimal jobSubTotal6, decimal jobtax6, decimal jobSubTotal7, decimal jobtax7, decimal jobSubTotal8, decimal jobtax8, decimal invsubtotal1, decimal invtax1, decimal invsubtotal2, decimal invtax2, decimal invsubtotal3, decimal invtax3, decimal invsubtotal4, decimal invtax4, decimal invsubtotal5, decimal invtax5, decimal invSubTotal6, decimal invtax6, decimal invSubTotal7, decimal invtax7, decimal invSubTotal8, decimal invtax8, string quotesexgst, string avgquoteval, int noofjobs, int noofinvoice, int companyid, int noofcontact, int noofclient)
		{
			CenterPerformance.PC_Center_Performance_reportRow pCCenterPerformanceReportRow = (CenterPerformance.PC_Center_Performance_reportRow)base.NewRow();
			object[] estimateType = new object[] { null, null, EstimateType, noofqoutes, estsubtotal1, esttax1, estsubtotal2, esttax2, estsubtotal3, esttax3, estsubtotal4, esttax4, estsubtotal5, esttax5, estSubTotal6, esttax6, estSubTotal7, esttax7, estSubTotal8, esttax8, jobsubtotal1, jobtax1, jobsubtotal2, jobtax2, jobsubtotal3, jobtax3, jobsubtotal4, jobtax4, jobsubtotal5, jobtax5, jobSubTotal6, jobtax6, jobSubTotal7, jobtax7, jobSubTotal8, jobtax8, invsubtotal1, invtax1, invsubtotal2, invtax2, invsubtotal3, invtax3, invsubtotal4, invtax4, invsubtotal5, invtax5, invSubTotal6, invtax6, invSubTotal7, invtax7, invSubTotal8, invtax8, quotesexgst, avgquoteval, noofjobs, noofinvoice, companyid, noofcontact, noofclient };
			pCCenterPerformanceReportRow.ItemArray = estimateType;
			base.Rows.Add(pCCenterPerformanceReportRow);
			return pCCenterPerformanceReportRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			CenterPerformance.PC_Center_Performance_reportDataTable pCCenterPerformanceReportDataTable = (CenterPerformance.PC_Center_Performance_reportDataTable)base.Clone();
			pCCenterPerformanceReportDataTable.InitVars();
			return pCCenterPerformanceReportDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new CenterPerformance.PC_Center_Performance_reportDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(CenterPerformance.PC_Center_Performance_reportRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType;
			XmlSchema xmlSchema;
			XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			CenterPerformance centerPerformance = new CenterPerformance();
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
				FixedValue = centerPerformance.Namespace
			};
			xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
			{
				Name = "tableTypeName",
				FixedValue = "PC_Center_Performance_reportDataTable"
			};
			xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
			xmlSchemaComplexType1.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = centerPerformance.GetSchemaSerializable();
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
			this.columnestimateid = new DataColumn("estimateid", typeof(long), null, MappingType.Element);
			base.Columns.Add(this.columnestimateid);
			this.columnestimateitemid = new DataColumn("estimateitemid", typeof(long), null, MappingType.Element);
			base.Columns.Add(this.columnestimateitemid);
			this.columnEstimateType = new DataColumn("EstimateType", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnEstimateType);
			this.columnnoofqoutes = new DataColumn("noofqoutes", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columnnoofqoutes);
			this.columnestsubtotal1 = new DataColumn("estsubtotal1", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnestsubtotal1);
			this.columnesttax1 = new DataColumn("esttax1", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnesttax1);
			this.columnestsubtotal2 = new DataColumn("estsubtotal2", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnestsubtotal2);
			this.columnesttax2 = new DataColumn("esttax2", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnesttax2);
			this.columnestsubtotal3 = new DataColumn("estsubtotal3", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnestsubtotal3);
			this.columnesttax3 = new DataColumn("esttax3", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnesttax3);
			this.columnestsubtotal4 = new DataColumn("estsubtotal4", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnestsubtotal4);
			this.columnesttax4 = new DataColumn("esttax4", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnesttax4);
			this.columnestsubtotal5 = new DataColumn("estsubtotal5", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnestsubtotal5);
			this.columnesttax5 = new DataColumn("esttax5", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnesttax5);
			this.columnestSubTotal6 = new DataColumn("estSubTotal6", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnestSubTotal6);
			this.columnesttax6 = new DataColumn("esttax6", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnesttax6);
			this.columnestSubTotal7 = new DataColumn("estSubTotal7", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnestSubTotal7);
			this.columnesttax7 = new DataColumn("esttax7", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnesttax7);
			this.columnestSubTotal8 = new DataColumn("estSubTotal8", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnestSubTotal8);
			this.columnesttax8 = new DataColumn("esttax8", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnesttax8);
			this.columnjobsubtotal1 = new DataColumn("jobsubtotal1", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnjobsubtotal1);
			this.columnjobtax1 = new DataColumn("jobtax1", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnjobtax1);
			this.columnjobsubtotal2 = new DataColumn("jobsubtotal2", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnjobsubtotal2);
			this.columnjobtax2 = new DataColumn("jobtax2", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnjobtax2);
			this.columnjobsubtotal3 = new DataColumn("jobsubtotal3", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnjobsubtotal3);
			this.columnjobtax3 = new DataColumn("jobtax3", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnjobtax3);
			this.columnjobsubtotal4 = new DataColumn("jobsubtotal4", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnjobsubtotal4);
			this.columnjobtax4 = new DataColumn("jobtax4", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnjobtax4);
			this.columnjobsubtotal5 = new DataColumn("jobsubtotal5", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnjobsubtotal5);
			this.columnjobtax5 = new DataColumn("jobtax5", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnjobtax5);
			this.columnjobSubTotal6 = new DataColumn("jobSubTotal6", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnjobSubTotal6);
			this.columnjobtax6 = new DataColumn("jobtax6", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnjobtax6);
			this.columnjobSubTotal7 = new DataColumn("jobSubTotal7", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnjobSubTotal7);
			this.columnjobtax7 = new DataColumn("jobtax7", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnjobtax7);
			this.columnjobSubTotal8 = new DataColumn("jobSubTotal8", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnjobSubTotal8);
			this.columnjobtax8 = new DataColumn("jobtax8", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnjobtax8);
			this.columninvsubtotal1 = new DataColumn("invsubtotal1", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columninvsubtotal1);
			this.columninvtax1 = new DataColumn("invtax1", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columninvtax1);
			this.columninvsubtotal2 = new DataColumn("invsubtotal2", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columninvsubtotal2);
			this.columninvtax2 = new DataColumn("invtax2", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columninvtax2);
			this.columninvsubtotal3 = new DataColumn("invsubtotal3", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columninvsubtotal3);
			this.columninvtax3 = new DataColumn("invtax3", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columninvtax3);
			this.columninvsubtotal4 = new DataColumn("invsubtotal4", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columninvsubtotal4);
			this.columninvtax4 = new DataColumn("invtax4", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columninvtax4);
			this.columninvsubtotal5 = new DataColumn("invsubtotal5", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columninvsubtotal5);
			this.columninvtax5 = new DataColumn("invtax5", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columninvtax5);
			this.columninvSubTotal6 = new DataColumn("invSubTotal6", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columninvSubTotal6);
			this.columninvtax6 = new DataColumn("invtax6", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columninvtax6);
			this.columninvSubTotal7 = new DataColumn("invSubTotal7", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columninvSubTotal7);
			this.columninvtax7 = new DataColumn("invtax7", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columninvtax7);
			this.columninvSubTotal8 = new DataColumn("invSubTotal8", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columninvSubTotal8);
			this.columninvtax8 = new DataColumn("invtax8", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columninvtax8);
			this.columnquotesexgst = new DataColumn("quotesexgst", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnquotesexgst);
			this.columnavgquoteval = new DataColumn("avgquoteval", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnavgquoteval);
			this.columnnoofjobs = new DataColumn("noofjobs", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columnnoofjobs);
			this.columnnoofinvoice = new DataColumn("noofinvoice", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columnnoofinvoice);
			this.columncompanyid = new DataColumn("companyid", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columncompanyid);
			this.columnnoofcontact = new DataColumn("noofcontact", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columnnoofcontact);
			this.columnnoofclient = new DataColumn("noofclient", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columnnoofclient);
			this.columnestimateid.AutoIncrement = true;
			this.columnestimateid.AutoIncrementSeed = (long)-1;
			this.columnestimateid.AutoIncrementStep = (long)-1;
			this.columnestimateid.AllowDBNull = false;
			this.columnestimateid.ReadOnly = true;
			this.columnestimateitemid.AutoIncrement = true;
			this.columnestimateitemid.AutoIncrementSeed = (long)-1;
			this.columnestimateitemid.AutoIncrementStep = (long)-1;
			this.columnestimateitemid.ReadOnly = true;
			this.columnEstimateType.MaxLength = 1;
			this.columnnoofqoutes.ReadOnly = true;
			this.columnestsubtotal1.ReadOnly = true;
			this.columnesttax1.ReadOnly = true;
			this.columnestsubtotal2.ReadOnly = true;
			this.columnesttax2.ReadOnly = true;
			this.columnestsubtotal3.ReadOnly = true;
			this.columnesttax3.ReadOnly = true;
			this.columnestsubtotal4.ReadOnly = true;
			this.columnesttax4.ReadOnly = true;
			this.columnestsubtotal5.ReadOnly = true;
			this.columnesttax5.ReadOnly = true;
			this.columnestSubTotal6.ReadOnly = true;
			this.columnesttax6.ReadOnly = true;
			this.columnestSubTotal7.ReadOnly = true;
			this.columnesttax7.ReadOnly = true;
			this.columnestSubTotal8.ReadOnly = true;
			this.columnesttax8.ReadOnly = true;
			this.columnjobsubtotal1.ReadOnly = true;
			this.columnjobtax1.ReadOnly = true;
			this.columnjobsubtotal2.ReadOnly = true;
			this.columnjobtax2.ReadOnly = true;
			this.columnjobsubtotal3.ReadOnly = true;
			this.columnjobtax3.ReadOnly = true;
			this.columnjobsubtotal4.ReadOnly = true;
			this.columnjobtax4.ReadOnly = true;
			this.columnjobsubtotal5.ReadOnly = true;
			this.columnjobtax5.ReadOnly = true;
			this.columnjobSubTotal6.ReadOnly = true;
			this.columnjobtax6.ReadOnly = true;
			this.columnjobSubTotal7.ReadOnly = true;
			this.columnjobtax7.ReadOnly = true;
			this.columnjobSubTotal8.ReadOnly = true;
			this.columnjobtax8.ReadOnly = true;
			this.columninvsubtotal1.ReadOnly = true;
			this.columninvtax1.ReadOnly = true;
			this.columninvsubtotal2.ReadOnly = true;
			this.columninvtax2.ReadOnly = true;
			this.columninvsubtotal3.ReadOnly = true;
			this.columninvtax3.ReadOnly = true;
			this.columninvsubtotal4.ReadOnly = true;
			this.columninvtax4.ReadOnly = true;
			this.columninvsubtotal5.ReadOnly = true;
			this.columninvtax5.ReadOnly = true;
			this.columninvSubTotal6.ReadOnly = true;
			this.columninvtax6.ReadOnly = true;
			this.columninvSubTotal7.ReadOnly = true;
			this.columninvtax7.ReadOnly = true;
			this.columninvSubTotal8.ReadOnly = true;
			this.columninvtax8.ReadOnly = true;
			this.columnquotesexgst.ReadOnly = true;
			this.columnquotesexgst.MaxLength = 1;
			this.columnavgquoteval.ReadOnly = true;
			this.columnavgquoteval.MaxLength = 1;
			this.columnnoofjobs.ReadOnly = true;
			this.columnnoofinvoice.ReadOnly = true;
			this.columncompanyid.ReadOnly = true;
			this.columnnoofcontact.ReadOnly = true;
			this.columnnoofclient.ReadOnly = true;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void InitVars()
		{
			this.columnestimateid = base.Columns["estimateid"];
			this.columnestimateitemid = base.Columns["estimateitemid"];
			this.columnEstimateType = base.Columns["EstimateType"];
			this.columnnoofqoutes = base.Columns["noofqoutes"];
			this.columnestsubtotal1 = base.Columns["estsubtotal1"];
			this.columnesttax1 = base.Columns["esttax1"];
			this.columnestsubtotal2 = base.Columns["estsubtotal2"];
			this.columnesttax2 = base.Columns["esttax2"];
			this.columnestsubtotal3 = base.Columns["estsubtotal3"];
			this.columnesttax3 = base.Columns["esttax3"];
			this.columnestsubtotal4 = base.Columns["estsubtotal4"];
			this.columnesttax4 = base.Columns["esttax4"];
			this.columnestsubtotal5 = base.Columns["estsubtotal5"];
			this.columnesttax5 = base.Columns["esttax5"];
			this.columnestSubTotal6 = base.Columns["estSubTotal6"];
			this.columnesttax6 = base.Columns["esttax6"];
			this.columnestSubTotal7 = base.Columns["estSubTotal7"];
			this.columnesttax7 = base.Columns["esttax7"];
			this.columnestSubTotal8 = base.Columns["estSubTotal8"];
			this.columnesttax8 = base.Columns["esttax8"];
			this.columnjobsubtotal1 = base.Columns["jobsubtotal1"];
			this.columnjobtax1 = base.Columns["jobtax1"];
			this.columnjobsubtotal2 = base.Columns["jobsubtotal2"];
			this.columnjobtax2 = base.Columns["jobtax2"];
			this.columnjobsubtotal3 = base.Columns["jobsubtotal3"];
			this.columnjobtax3 = base.Columns["jobtax3"];
			this.columnjobsubtotal4 = base.Columns["jobsubtotal4"];
			this.columnjobtax4 = base.Columns["jobtax4"];
			this.columnjobsubtotal5 = base.Columns["jobsubtotal5"];
			this.columnjobtax5 = base.Columns["jobtax5"];
			this.columnjobSubTotal6 = base.Columns["jobSubTotal6"];
			this.columnjobtax6 = base.Columns["jobtax6"];
			this.columnjobSubTotal7 = base.Columns["jobSubTotal7"];
			this.columnjobtax7 = base.Columns["jobtax7"];
			this.columnjobSubTotal8 = base.Columns["jobSubTotal8"];
			this.columnjobtax8 = base.Columns["jobtax8"];
			this.columninvsubtotal1 = base.Columns["invsubtotal1"];
			this.columninvtax1 = base.Columns["invtax1"];
			this.columninvsubtotal2 = base.Columns["invsubtotal2"];
			this.columninvtax2 = base.Columns["invtax2"];
			this.columninvsubtotal3 = base.Columns["invsubtotal3"];
			this.columninvtax3 = base.Columns["invtax3"];
			this.columninvsubtotal4 = base.Columns["invsubtotal4"];
			this.columninvtax4 = base.Columns["invtax4"];
			this.columninvsubtotal5 = base.Columns["invsubtotal5"];
			this.columninvtax5 = base.Columns["invtax5"];
			this.columninvSubTotal6 = base.Columns["invSubTotal6"];
			this.columninvtax6 = base.Columns["invtax6"];
			this.columninvSubTotal7 = base.Columns["invSubTotal7"];
			this.columninvtax7 = base.Columns["invtax7"];
			this.columninvSubTotal8 = base.Columns["invSubTotal8"];
			this.columninvtax8 = base.Columns["invtax8"];
			this.columnquotesexgst = base.Columns["quotesexgst"];
			this.columnavgquoteval = base.Columns["avgquoteval"];
			this.columnnoofjobs = base.Columns["noofjobs"];
			this.columnnoofinvoice = base.Columns["noofinvoice"];
			this.columncompanyid = base.Columns["companyid"];
			this.columnnoofcontact = base.Columns["noofcontact"];
			this.columnnoofclient = base.Columns["noofclient"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public CenterPerformance.PC_Center_Performance_reportRow NewPC_Center_Performance_reportRow()
		{
			return (CenterPerformance.PC_Center_Performance_reportRow)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new CenterPerformance.PC_Center_Performance_reportRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.PC_Center_Performance_reportRowChanged != null)
			{
				this.PC_Center_Performance_reportRowChanged(this, new CenterPerformance.PC_Center_Performance_reportRowChangeEvent((CenterPerformance.PC_Center_Performance_reportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.PC_Center_Performance_reportRowChanging != null)
			{
				this.PC_Center_Performance_reportRowChanging(this, new CenterPerformance.PC_Center_Performance_reportRowChangeEvent((CenterPerformance.PC_Center_Performance_reportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.PC_Center_Performance_reportRowDeleted != null)
			{
				this.PC_Center_Performance_reportRowDeleted(this, new CenterPerformance.PC_Center_Performance_reportRowChangeEvent((CenterPerformance.PC_Center_Performance_reportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.PC_Center_Performance_reportRowDeleting != null)
			{
				this.PC_Center_Performance_reportRowDeleting(this, new CenterPerformance.PC_Center_Performance_reportRowChangeEvent((CenterPerformance.PC_Center_Performance_reportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void RemovePC_Center_Performance_reportRow(CenterPerformance.PC_Center_Performance_reportRow row)
		{
			base.Rows.Remove(row);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event CenterPerformance.PC_Center_Performance_reportRowChangeEventHandler PC_Center_Performance_reportRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event CenterPerformance.PC_Center_Performance_reportRowChangeEventHandler PC_Center_Performance_reportRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event CenterPerformance.PC_Center_Performance_reportRowChangeEventHandler PC_Center_Performance_reportRowDeleted;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event CenterPerformance.PC_Center_Performance_reportRowChangeEventHandler PC_Center_Performance_reportRowDeleting;
	}

	public class PC_Center_Performance_reportRow : DataRow
	{
		private CenterPerformance.PC_Center_Performance_reportDataTable tablePC_Center_Performance_report;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string avgquoteval
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Center_Performance_report.avgquotevalColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'avgquoteval' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.avgquotevalColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int companyid
		{
			get
			{
				int item;
				try
				{
					item = (int)base[this.tablePC_Center_Performance_report.companyidColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'companyid' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.companyidColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public long estimateid
		{
			get
			{
				return (long)base[this.tablePC_Center_Performance_report.estimateidColumn];
			}
			set
			{
				base[this.tablePC_Center_Performance_report.estimateidColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public long estimateitemid
		{
			get
			{
				long item;
				try
				{
					item = (long)base[this.tablePC_Center_Performance_report.estimateitemidColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'estimateitemid' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.estimateitemidColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string EstimateType
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Center_Performance_report.EstimateTypeColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'EstimateType' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.EstimateTypeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal estsubtotal1
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.estsubtotal1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'estsubtotal1' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.estsubtotal1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal estsubtotal2
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.estsubtotal2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'estsubtotal2' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.estsubtotal2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal estsubtotal3
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.estsubtotal3Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'estsubtotal3' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.estsubtotal3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal estsubtotal4
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.estsubtotal4Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'estsubtotal4' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.estsubtotal4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal estsubtotal5
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.estsubtotal5Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'estsubtotal5' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.estsubtotal5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal estSubTotal6
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.estSubTotal6Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'estSubTotal6' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.estSubTotal6Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal estSubTotal7
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.estSubTotal7Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'estSubTotal7' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.estSubTotal7Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal estSubTotal8
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.estSubTotal8Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'estSubTotal8' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.estSubTotal8Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal esttax1
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.esttax1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'esttax1' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.esttax1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal esttax2
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.esttax2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'esttax2' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.esttax2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal esttax3
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.esttax3Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'esttax3' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.esttax3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal esttax4
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.esttax4Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'esttax4' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.esttax4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal esttax5
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.esttax5Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'esttax5' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.esttax5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal esttax6
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.esttax6Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'esttax6' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.esttax6Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal esttax7
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.esttax7Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'esttax7' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.esttax7Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal esttax8
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.esttax8Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'esttax8' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.esttax8Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal invsubtotal1
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.invsubtotal1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invsubtotal1' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.invsubtotal1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal invsubtotal2
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.invsubtotal2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invsubtotal2' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.invsubtotal2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal invsubtotal3
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.invsubtotal3Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invsubtotal3' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.invsubtotal3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal invsubtotal4
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.invsubtotal4Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invsubtotal4' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.invsubtotal4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal invsubtotal5
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.invsubtotal5Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invsubtotal5' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.invsubtotal5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal invSubTotal6
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.invSubTotal6Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invSubTotal6' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.invSubTotal6Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal invSubTotal7
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.invSubTotal7Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invSubTotal7' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.invSubTotal7Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal invSubTotal8
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.invSubTotal8Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invSubTotal8' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.invSubTotal8Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal invtax1
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.invtax1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invtax1' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.invtax1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal invtax2
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.invtax2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invtax2' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.invtax2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal invtax3
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.invtax3Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invtax3' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.invtax3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal invtax4
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.invtax4Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invtax4' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.invtax4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal invtax5
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.invtax5Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invtax5' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.invtax5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal invtax6
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.invtax6Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invtax6' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.invtax6Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal invtax7
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.invtax7Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invtax7' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.invtax7Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal invtax8
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.invtax8Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'invtax8' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.invtax8Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal jobsubtotal1
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.jobsubtotal1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobsubtotal1' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.jobsubtotal1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal jobsubtotal2
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.jobsubtotal2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobsubtotal2' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.jobsubtotal2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal jobsubtotal3
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.jobsubtotal3Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobsubtotal3' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.jobsubtotal3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal jobsubtotal4
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.jobsubtotal4Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobsubtotal4' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.jobsubtotal4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal jobsubtotal5
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.jobsubtotal5Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobsubtotal5' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.jobsubtotal5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal jobSubTotal6
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.jobSubTotal6Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobSubTotal6' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.jobSubTotal6Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal jobSubTotal7
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.jobSubTotal7Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobSubTotal7' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.jobSubTotal7Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal jobSubTotal8
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.jobSubTotal8Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobSubTotal8' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.jobSubTotal8Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal jobtax1
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.jobtax1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobtax1' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.jobtax1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal jobtax2
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.jobtax2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobtax2' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.jobtax2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal jobtax3
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.jobtax3Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobtax3' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.jobtax3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal jobtax4
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.jobtax4Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobtax4' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.jobtax4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal jobtax5
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.jobtax5Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobtax5' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.jobtax5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal jobtax6
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.jobtax6Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobtax6' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.jobtax6Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal jobtax7
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.jobtax7Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobtax7' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.jobtax7Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal jobtax8
		{
			get
			{
				decimal item;
				try
				{
					item = (decimal)base[this.tablePC_Center_Performance_report.jobtax8Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'jobtax8' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.jobtax8Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int noofclient
		{
			get
			{
				int item;
				try
				{
					item = (int)base[this.tablePC_Center_Performance_report.noofclientColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'noofclient' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.noofclientColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int noofcontact
		{
			get
			{
				int item;
				try
				{
					item = (int)base[this.tablePC_Center_Performance_report.noofcontactColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'noofcontact' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.noofcontactColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int noofinvoice
		{
			get
			{
				int item;
				try
				{
					item = (int)base[this.tablePC_Center_Performance_report.noofinvoiceColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'noofinvoice' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.noofinvoiceColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int noofjobs
		{
			get
			{
				int item;
				try
				{
					item = (int)base[this.tablePC_Center_Performance_report.noofjobsColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'noofjobs' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.noofjobsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int noofqoutes
		{
			get
			{
				int item;
				try
				{
					item = (int)base[this.tablePC_Center_Performance_report.noofqoutesColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'noofqoutes' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.noofqoutesColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string quotesexgst
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Center_Performance_report.quotesexgstColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'quotesexgst' in table 'PC_Center_Performance_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Center_Performance_report.quotesexgstColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal PC_Center_Performance_reportRow(DataRowBuilder rb) : base(rb)
		{
			this.tablePC_Center_Performance_report = (CenterPerformance.PC_Center_Performance_reportDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsavgquotevalNull()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.avgquotevalColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IscompanyidNull()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.companyidColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsestimateitemidNull()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.estimateitemidColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsEstimateTypeNull()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.EstimateTypeColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isestsubtotal1Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.estsubtotal1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isestsubtotal2Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.estsubtotal2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isestsubtotal3Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.estsubtotal3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isestsubtotal4Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.estsubtotal4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isestsubtotal5Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.estsubtotal5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsestSubTotal6Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.estSubTotal6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsestSubTotal7Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.estSubTotal7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsestSubTotal8Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.estSubTotal8Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isesttax1Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.esttax1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isesttax2Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.esttax2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isesttax3Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.esttax3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isesttax4Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.esttax4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isesttax5Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.esttax5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isesttax6Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.esttax6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isesttax7Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.esttax7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isesttax8Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.esttax8Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isinvsubtotal1Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.invsubtotal1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isinvsubtotal2Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.invsubtotal2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isinvsubtotal3Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.invsubtotal3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isinvsubtotal4Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.invsubtotal4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isinvsubtotal5Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.invsubtotal5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsinvSubTotal6Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.invSubTotal6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsinvSubTotal7Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.invSubTotal7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsinvSubTotal8Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.invSubTotal8Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isinvtax1Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.invtax1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isinvtax2Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.invtax2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isinvtax3Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.invtax3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isinvtax4Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.invtax4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isinvtax5Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.invtax5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isinvtax6Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.invtax6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isinvtax7Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.invtax7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isinvtax8Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.invtax8Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isjobsubtotal1Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.jobsubtotal1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isjobsubtotal2Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.jobsubtotal2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isjobsubtotal3Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.jobsubtotal3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isjobsubtotal4Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.jobsubtotal4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isjobsubtotal5Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.jobsubtotal5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsjobSubTotal6Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.jobSubTotal6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsjobSubTotal7Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.jobSubTotal7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsjobSubTotal8Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.jobSubTotal8Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isjobtax1Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.jobtax1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isjobtax2Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.jobtax2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isjobtax3Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.jobtax3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isjobtax4Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.jobtax4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isjobtax5Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.jobtax5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isjobtax6Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.jobtax6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isjobtax7Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.jobtax7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isjobtax8Null()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.jobtax8Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsnoofclientNull()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.noofclientColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsnoofcontactNull()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.noofcontactColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsnoofinvoiceNull()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.noofinvoiceColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsnoofjobsNull()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.noofjobsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsnoofqoutesNull()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.noofqoutesColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsquotesexgstNull()
		{
			return base.IsNull(this.tablePC_Center_Performance_report.quotesexgstColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetavgquotevalNull()
		{
			base[this.tablePC_Center_Performance_report.avgquotevalColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetcompanyidNull()
		{
			base[this.tablePC_Center_Performance_report.companyidColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetestimateitemidNull()
		{
			base[this.tablePC_Center_Performance_report.estimateitemidColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetEstimateTypeNull()
		{
			base[this.tablePC_Center_Performance_report.EstimateTypeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setestsubtotal1Null()
		{
			base[this.tablePC_Center_Performance_report.estsubtotal1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setestsubtotal2Null()
		{
			base[this.tablePC_Center_Performance_report.estsubtotal2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setestsubtotal3Null()
		{
			base[this.tablePC_Center_Performance_report.estsubtotal3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setestsubtotal4Null()
		{
			base[this.tablePC_Center_Performance_report.estsubtotal4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setestsubtotal5Null()
		{
			base[this.tablePC_Center_Performance_report.estsubtotal5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetestSubTotal6Null()
		{
			base[this.tablePC_Center_Performance_report.estSubTotal6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetestSubTotal7Null()
		{
			base[this.tablePC_Center_Performance_report.estSubTotal7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetestSubTotal8Null()
		{
			base[this.tablePC_Center_Performance_report.estSubTotal8Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setesttax1Null()
		{
			base[this.tablePC_Center_Performance_report.esttax1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setesttax2Null()
		{
			base[this.tablePC_Center_Performance_report.esttax2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setesttax3Null()
		{
			base[this.tablePC_Center_Performance_report.esttax3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setesttax4Null()
		{
			base[this.tablePC_Center_Performance_report.esttax4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setesttax5Null()
		{
			base[this.tablePC_Center_Performance_report.esttax5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setesttax6Null()
		{
			base[this.tablePC_Center_Performance_report.esttax6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setesttax7Null()
		{
			base[this.tablePC_Center_Performance_report.esttax7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setesttax8Null()
		{
			base[this.tablePC_Center_Performance_report.esttax8Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setinvsubtotal1Null()
		{
			base[this.tablePC_Center_Performance_report.invsubtotal1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setinvsubtotal2Null()
		{
			base[this.tablePC_Center_Performance_report.invsubtotal2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setinvsubtotal3Null()
		{
			base[this.tablePC_Center_Performance_report.invsubtotal3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setinvsubtotal4Null()
		{
			base[this.tablePC_Center_Performance_report.invsubtotal4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setinvsubtotal5Null()
		{
			base[this.tablePC_Center_Performance_report.invsubtotal5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetinvSubTotal6Null()
		{
			base[this.tablePC_Center_Performance_report.invSubTotal6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetinvSubTotal7Null()
		{
			base[this.tablePC_Center_Performance_report.invSubTotal7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetinvSubTotal8Null()
		{
			base[this.tablePC_Center_Performance_report.invSubTotal8Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setinvtax1Null()
		{
			base[this.tablePC_Center_Performance_report.invtax1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setinvtax2Null()
		{
			base[this.tablePC_Center_Performance_report.invtax2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setinvtax3Null()
		{
			base[this.tablePC_Center_Performance_report.invtax3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setinvtax4Null()
		{
			base[this.tablePC_Center_Performance_report.invtax4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setinvtax5Null()
		{
			base[this.tablePC_Center_Performance_report.invtax5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setinvtax6Null()
		{
			base[this.tablePC_Center_Performance_report.invtax6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setinvtax7Null()
		{
			base[this.tablePC_Center_Performance_report.invtax7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setinvtax8Null()
		{
			base[this.tablePC_Center_Performance_report.invtax8Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setjobsubtotal1Null()
		{
			base[this.tablePC_Center_Performance_report.jobsubtotal1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setjobsubtotal2Null()
		{
			base[this.tablePC_Center_Performance_report.jobsubtotal2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setjobsubtotal3Null()
		{
			base[this.tablePC_Center_Performance_report.jobsubtotal3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setjobsubtotal4Null()
		{
			base[this.tablePC_Center_Performance_report.jobsubtotal4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setjobsubtotal5Null()
		{
			base[this.tablePC_Center_Performance_report.jobsubtotal5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetjobSubTotal6Null()
		{
			base[this.tablePC_Center_Performance_report.jobSubTotal6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetjobSubTotal7Null()
		{
			base[this.tablePC_Center_Performance_report.jobSubTotal7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetjobSubTotal8Null()
		{
			base[this.tablePC_Center_Performance_report.jobSubTotal8Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setjobtax1Null()
		{
			base[this.tablePC_Center_Performance_report.jobtax1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setjobtax2Null()
		{
			base[this.tablePC_Center_Performance_report.jobtax2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setjobtax3Null()
		{
			base[this.tablePC_Center_Performance_report.jobtax3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setjobtax4Null()
		{
			base[this.tablePC_Center_Performance_report.jobtax4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setjobtax5Null()
		{
			base[this.tablePC_Center_Performance_report.jobtax5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setjobtax6Null()
		{
			base[this.tablePC_Center_Performance_report.jobtax6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setjobtax7Null()
		{
			base[this.tablePC_Center_Performance_report.jobtax7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setjobtax8Null()
		{
			base[this.tablePC_Center_Performance_report.jobtax8Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetnoofclientNull()
		{
			base[this.tablePC_Center_Performance_report.noofclientColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetnoofcontactNull()
		{
			base[this.tablePC_Center_Performance_report.noofcontactColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetnoofinvoiceNull()
		{
			base[this.tablePC_Center_Performance_report.noofinvoiceColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetnoofjobsNull()
		{
			base[this.tablePC_Center_Performance_report.noofjobsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetnoofqoutesNull()
		{
			base[this.tablePC_Center_Performance_report.noofqoutesColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetquotesexgstNull()
		{
			base[this.tablePC_Center_Performance_report.quotesexgstColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class PC_Center_Performance_reportRowChangeEvent : EventArgs
	{
		private CenterPerformance.PC_Center_Performance_reportRow eventRow;

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
		public CenterPerformance.PC_Center_Performance_reportRow Row
		{
			get
			{
				return this.eventRow;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public PC_Center_Performance_reportRowChangeEvent(CenterPerformance.PC_Center_Performance_reportRow row, DataRowAction action)
		{
			this.eventRow = row;
			this.eventAction = action;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void PC_Center_Performance_reportRowChangeEventHandler(object sender, CenterPerformance.PC_Center_Performance_reportRowChangeEvent e);
}
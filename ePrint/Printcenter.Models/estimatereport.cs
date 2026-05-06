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
[XmlRoot("estimatereport")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
public class estimatereport : DataSet
{
	private estimatereport.PC_Estimate_reportDataTable tablePC_Estimate_report;

	private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;

	[Browsable(false)]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public estimatereport.PC_Estimate_reportDataTable PC_Estimate_report
	{
		get
		{
			return this.tablePC_Estimate_report;
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
	public estimatereport()
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
	protected estimatereport(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
			if (dataSet.Tables["PC_Estimate_report"] != null)
			{
				base.Tables.Add(new estimatereport.PC_Estimate_reportDataTable(dataSet.Tables["PC_Estimate_report"]));
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
		estimatereport schemaSerializationMode = (estimatereport)base.Clone();
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
		estimatereport _estimatereport = new estimatereport();
		XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
		{
			Namespace = _estimatereport.Namespace
		};
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType1.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = _estimatereport.GetSchemaSerializable();
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
		base.DataSetName = "estimatereport";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/estimatereport.xsd";
		base.EnforceConstraints = true;
		this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
		this.tablePC_Estimate_report = new estimatereport.PC_Estimate_reportDataTable();
		base.Tables.Add(this.tablePC_Estimate_report);
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
		this.tablePC_Estimate_report = (estimatereport.PC_Estimate_reportDataTable)base.Tables["PC_Estimate_report"];
		if (initTable && this.tablePC_Estimate_report != null)
		{
			this.tablePC_Estimate_report.InitVars();
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
		if (dataSet.Tables["PC_Estimate_report"] != null)
		{
			base.Tables.Add(new estimatereport.PC_Estimate_reportDataTable(dataSet.Tables["PC_Estimate_report"]));
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
	private bool ShouldSerializePC_Estimate_report()
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
	public class PC_Estimate_reportDataTable : TypedTableBase<estimatereport.PC_Estimate_reportRow>
	{
		private DataColumn columnEstimateNumber;

		private DataColumn columnCompany;

		private DataColumn columnEstimateTitle;

		private DataColumn columnCreatedBy;

		private DataColumn columnCreatedDate;

		private DataColumn columndt;

		private DataColumn columnStatus;

		private DataColumn columnEstimateDate;

		private DataColumn columnEstimateValue;

		private DataColumn columnItemTitle;

		private DataColumn columnDescription;

		private DataColumn columnArtwork;

		private DataColumn columnColour;

		private DataColumn columnSize;

		private DataColumn columnMaterial;

		private DataColumn columnDelivery;

		private DataColumn columnFinishing;

		private DataColumn columnNotes;

		private DataColumn columnInstructions;

		private DataColumn columnstr1;

		private DataColumn columnstr2;

		private DataColumn columnstr3;

		private DataColumn columnstr4;

		private DataColumn columnstr5;

		private DataColumn columnstr6;

		private DataColumn columnstr7;

		private DataColumn columnstr8;

		private DataColumn columnstr9;

		private DataColumn columnstr10;

		private DataColumn columnstr11;

		private DataColumn columnstr12;

		private DataColumn columnstr13;

		private DataColumn columnstr14;

		private DataColumn columnstr15;

		private DataColumn columnstr16;

		private DataColumn columnstr17;

		private DataColumn columnstr18;

		private DataColumn columnstragg1;

		private DataColumn columnstragg2;

		private DataColumn columnstragg3;

		private DataColumn columnstragg4;

		private DataColumn columnstragg5;

		private DataColumn columnrdodetail1;

		private DataColumn columnEstimateid;

		private DataColumn columnEstimateItemID;

		private DataColumn columnstatusid;

		private DataColumn columnEstimateValuesm;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn ArtworkColumn
		{
			get
			{
				return this.columnArtwork;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn ColourColumn
		{
			get
			{
				return this.columnColour;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn CompanyColumn
		{
			get
			{
				return this.columnCompany;
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
		public DataColumn CreatedByColumn
		{
			get
			{
				return this.columnCreatedBy;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn CreatedDateColumn
		{
			get
			{
				return this.columnCreatedDate;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DeliveryColumn
		{
			get
			{
				return this.columnDelivery;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DescriptionColumn
		{
			get
			{
				return this.columnDescription;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn dtColumn
		{
			get
			{
				return this.columndt;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn EstimateDateColumn
		{
			get
			{
				return this.columnEstimateDate;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn EstimateidColumn
		{
			get
			{
				return this.columnEstimateid;
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
		public DataColumn EstimateNumberColumn
		{
			get
			{
				return this.columnEstimateNumber;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn EstimateTitleColumn
		{
			get
			{
				return this.columnEstimateTitle;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn EstimateValueColumn
		{
			get
			{
				return this.columnEstimateValue;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn EstimateValuesmColumn
		{
			get
			{
				return this.columnEstimateValuesm;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn FinishingColumn
		{
			get
			{
				return this.columnFinishing;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn InstructionsColumn
		{
			get
			{
				return this.columnInstructions;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public estimatereport.PC_Estimate_reportRow this[int index]
		{
			get
			{
				return (estimatereport.PC_Estimate_reportRow)base.Rows[index];
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn ItemTitleColumn
		{
			get
			{
				return this.columnItemTitle;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn MaterialColumn
		{
			get
			{
				return this.columnMaterial;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn NotesColumn
		{
			get
			{
				return this.columnNotes;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn rdodetail1Column
		{
			get
			{
				return this.columnrdodetail1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn SizeColumn
		{
			get
			{
				return this.columnSize;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn StatusColumn
		{
			get
			{
				return this.columnStatus;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn statusidColumn
		{
			get
			{
				return this.columnstatusid;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str10Column
		{
			get
			{
				return this.columnstr10;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str11Column
		{
			get
			{
				return this.columnstr11;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str12Column
		{
			get
			{
				return this.columnstr12;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str13Column
		{
			get
			{
				return this.columnstr13;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str14Column
		{
			get
			{
				return this.columnstr14;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str15Column
		{
			get
			{
				return this.columnstr15;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str16Column
		{
			get
			{
				return this.columnstr16;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str17Column
		{
			get
			{
				return this.columnstr17;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str18Column
		{
			get
			{
				return this.columnstr18;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str1Column
		{
			get
			{
				return this.columnstr1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str2Column
		{
			get
			{
				return this.columnstr2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str3Column
		{
			get
			{
				return this.columnstr3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str4Column
		{
			get
			{
				return this.columnstr4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str5Column
		{
			get
			{
				return this.columnstr5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str6Column
		{
			get
			{
				return this.columnstr6;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str7Column
		{
			get
			{
				return this.columnstr7;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str8Column
		{
			get
			{
				return this.columnstr8;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn str9Column
		{
			get
			{
				return this.columnstr9;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn stragg1Column
		{
			get
			{
				return this.columnstragg1;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn stragg2Column
		{
			get
			{
				return this.columnstragg2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn stragg3Column
		{
			get
			{
				return this.columnstragg3;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn stragg4Column
		{
			get
			{
				return this.columnstragg4;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn stragg5Column
		{
			get
			{
				return this.columnstragg5;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public PC_Estimate_reportDataTable()
		{
			base.TableName = "PC_Estimate_report";
			this.BeginInit();
			this.InitClass();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal PC_Estimate_reportDataTable(DataTable table)
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
		protected PC_Estimate_reportDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this.InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void AddPC_Estimate_reportRow(estimatereport.PC_Estimate_reportRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public estimatereport.PC_Estimate_reportRow AddPC_Estimate_reportRow(string EstimateNumber, string Company, string EstimateTitle, string CreatedBy, string CreatedDate, DateTime dt, string Status, string EstimateDate, decimal EstimateValue, string ItemTitle, string Description, string Artwork, string Colour, string Size, string Material, string Delivery, string Finishing, string Notes, string Instructions, string str1, string str2, string str3, string str4, string str5, string str6, string str7, string str8, string str9, string str10, string str11, string str12, string str13, string str14, string str15, string str16, string str17, string str18, string stragg1, string stragg2, string stragg3, string stragg4, string stragg5, string rdodetail1, string Estimateid, string EstimateItemID, string statusid, string EstimateValuesm)
		{
			estimatereport.PC_Estimate_reportRow pCEstimateReportRow = (estimatereport.PC_Estimate_reportRow)base.NewRow();
			object[] estimateNumber = new object[] { EstimateNumber, Company, EstimateTitle, CreatedBy, CreatedDate, dt, Status, EstimateDate, EstimateValue, ItemTitle, Description, Artwork, Colour, Size, Material, Delivery, Finishing, Notes, Instructions, str1, str2, str3, str4, str5, str6, str7, str8, str9, str10, str11, str12, str13, str14, str15, str16, str17, str18, stragg1, stragg2, stragg3, stragg4, stragg5, rdodetail1, Estimateid, EstimateItemID, statusid, EstimateValuesm };
			pCEstimateReportRow.ItemArray = estimateNumber;
			base.Rows.Add(pCEstimateReportRow);
			return pCEstimateReportRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			estimatereport.PC_Estimate_reportDataTable pCEstimateReportDataTable = (estimatereport.PC_Estimate_reportDataTable)base.Clone();
			pCEstimateReportDataTable.InitVars();
			return pCEstimateReportDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new estimatereport.PC_Estimate_reportDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(estimatereport.PC_Estimate_reportRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType;
			XmlSchema xmlSchema;
			XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			estimatereport _estimatereport = new estimatereport();
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
				FixedValue = _estimatereport.Namespace
			};
			xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
			{
				Name = "tableTypeName",
				FixedValue = "PC_Estimate_reportDataTable"
			};
			xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
			xmlSchemaComplexType1.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = _estimatereport.GetSchemaSerializable();
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
			this.columnEstimateNumber = new DataColumn("EstimateNumber", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnEstimateNumber);
			this.columnCompany = new DataColumn("Company", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnCompany);
			this.columnEstimateTitle = new DataColumn("EstimateTitle", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnEstimateTitle);
			this.columnCreatedBy = new DataColumn("CreatedBy", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnCreatedBy);
			this.columnCreatedDate = new DataColumn("CreatedDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnCreatedDate);
			this.columndt = new DataColumn("dt", typeof(DateTime), null, MappingType.Element);
			base.Columns.Add(this.columndt);
			this.columnStatus = new DataColumn("Status", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnStatus);
			this.columnEstimateDate = new DataColumn("EstimateDate", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnEstimateDate);
			this.columnEstimateValue = new DataColumn("EstimateValue", typeof(decimal), null, MappingType.Element);
			base.Columns.Add(this.columnEstimateValue);
			this.columnItemTitle = new DataColumn("ItemTitle", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnItemTitle);
			this.columnDescription = new DataColumn("Description", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnDescription);
			this.columnArtwork = new DataColumn("Artwork", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnArtwork);
			this.columnColour = new DataColumn("Colour", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnColour);
			this.columnSize = new DataColumn("Size", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnSize);
			this.columnMaterial = new DataColumn("Material", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnMaterial);
			this.columnDelivery = new DataColumn("Delivery", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnDelivery);
			this.columnFinishing = new DataColumn("Finishing", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnFinishing);
			this.columnNotes = new DataColumn("Notes", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnNotes);
			this.columnInstructions = new DataColumn("Instructions", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnInstructions);
			this.columnstr1 = new DataColumn("str1", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr1);
			this.columnstr2 = new DataColumn("str2", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr2);
			this.columnstr3 = new DataColumn("str3", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr3);
			this.columnstr4 = new DataColumn("str4", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr4);
			this.columnstr5 = new DataColumn("str5", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr5);
			this.columnstr6 = new DataColumn("str6", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr6);
			this.columnstr7 = new DataColumn("str7", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr7);
			this.columnstr8 = new DataColumn("str8", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr8);
			this.columnstr9 = new DataColumn("str9", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr9);
			this.columnstr10 = new DataColumn("str10", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr10);
			this.columnstr11 = new DataColumn("str11", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr11);
			this.columnstr12 = new DataColumn("str12", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr12);
			this.columnstr13 = new DataColumn("str13", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr13);
			this.columnstr14 = new DataColumn("str14", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr14);
			this.columnstr15 = new DataColumn("str15", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr15);
			this.columnstr16 = new DataColumn("str16", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr16);
			this.columnstr17 = new DataColumn("str17", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr17);
			this.columnstr18 = new DataColumn("str18", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstr18);
			this.columnstragg1 = new DataColumn("stragg1", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstragg1);
			this.columnstragg2 = new DataColumn("stragg2", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstragg2);
			this.columnstragg3 = new DataColumn("stragg3", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstragg3);
			this.columnstragg4 = new DataColumn("stragg4", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstragg4);
			this.columnstragg5 = new DataColumn("stragg5", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstragg5);
			this.columnrdodetail1 = new DataColumn("rdodetail1", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnrdodetail1);
			this.columnEstimateid = new DataColumn("Estimateid", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnEstimateid);
			this.columnEstimateItemID = new DataColumn("EstimateItemID", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnEstimateItemID);
			this.columnstatusid = new DataColumn("statusid", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnstatusid);
			this.columnEstimateValuesm = new DataColumn("EstimateValuesm", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnEstimateValuesm);
			this.columnEstimateNumber.MaxLength = 25;
			this.columnCompany.MaxLength = 100;
			this.columnEstimateTitle.MaxLength = 100;
			this.columnCreatedBy.ReadOnly = true;
			this.columnCreatedBy.MaxLength = 401;
			this.columnCreatedDate.ReadOnly = true;
			this.columnCreatedDate.MaxLength = 64;
			this.columndt.AllowDBNull = false;
			this.columnStatus.ReadOnly = true;
			this.columnStatus.MaxLength = 100;
			this.columnEstimateDate.ReadOnly = true;
			this.columnEstimateDate.MaxLength = 64;
			this.columnEstimateValue.AllowDBNull = false;
			this.columnItemTitle.ReadOnly = true;
			this.columnItemTitle.MaxLength = 1073741823;
			this.columnDescription.ReadOnly = true;
			this.columnDescription.MaxLength = 1073741823;
			this.columnArtwork.ReadOnly = true;
			this.columnArtwork.MaxLength = 1073741823;
			this.columnColour.ReadOnly = true;
			this.columnColour.MaxLength = 1073741823;
			this.columnSize.ReadOnly = true;
			this.columnSize.MaxLength = 1073741823;
			this.columnMaterial.ReadOnly = true;
			this.columnMaterial.MaxLength = 1073741823;
			this.columnDelivery.ReadOnly = true;
			this.columnDelivery.MaxLength = 1073741823;
			this.columnFinishing.ReadOnly = true;
			this.columnFinishing.MaxLength = 1073741823;
			this.columnNotes.ReadOnly = true;
			this.columnNotes.MaxLength = 1073741823;
			this.columnInstructions.ReadOnly = true;
			this.columnInstructions.MaxLength = 1073741823;
			this.columnstr1.ReadOnly = true;
			this.columnstr1.MaxLength = 100;
			this.columnstr2.ReadOnly = true;
			this.columnstr2.MaxLength = 100;
			this.columnstr3.ReadOnly = true;
			this.columnstr3.MaxLength = 100;
			this.columnstr4.ReadOnly = true;
			this.columnstr4.MaxLength = 100;
			this.columnstr5.ReadOnly = true;
			this.columnstr5.MaxLength = 100;
			this.columnstr6.ReadOnly = true;
			this.columnstr6.MaxLength = 100;
			this.columnstr7.ReadOnly = true;
			this.columnstr7.MaxLength = 100;
			this.columnstr8.ReadOnly = true;
			this.columnstr8.MaxLength = 100;
			this.columnstr9.ReadOnly = true;
			this.columnstr9.MaxLength = 100;
			this.columnstr10.ReadOnly = true;
			this.columnstr10.MaxLength = 100;
			this.columnstr11.ReadOnly = true;
			this.columnstr11.MaxLength = 100;
			this.columnstr12.ReadOnly = true;
			this.columnstr12.MaxLength = 100;
			this.columnstr13.ReadOnly = true;
			this.columnstr13.MaxLength = 100;
			this.columnstr14.ReadOnly = true;
			this.columnstr14.MaxLength = 100;
			this.columnstr15.ReadOnly = true;
			this.columnstr15.MaxLength = 100;
			this.columnstr16.ReadOnly = true;
			this.columnstr16.MaxLength = 100;
			this.columnstr17.ReadOnly = true;
			this.columnstr17.MaxLength = 100;
			this.columnstr18.ReadOnly = true;
			this.columnstr18.MaxLength = 100;
			this.columnstragg1.ReadOnly = true;
			this.columnstragg1.MaxLength = 100;
			this.columnstragg2.ReadOnly = true;
			this.columnstragg2.MaxLength = 100;
			this.columnstragg3.ReadOnly = true;
			this.columnstragg3.MaxLength = 100;
			this.columnstragg4.ReadOnly = true;
			this.columnstragg4.MaxLength = 100;
			this.columnstragg5.ReadOnly = true;
			this.columnstragg5.MaxLength = 100;
			this.columnrdodetail1.ReadOnly = true;
			this.columnrdodetail1.MaxLength = 100;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void InitVars()
		{
			this.columnEstimateNumber = base.Columns["EstimateNumber"];
			this.columnCompany = base.Columns["Company"];
			this.columnEstimateTitle = base.Columns["EstimateTitle"];
			this.columnCreatedBy = base.Columns["CreatedBy"];
			this.columnCreatedDate = base.Columns["CreatedDate"];
			this.columndt = base.Columns["dt"];
			this.columnStatus = base.Columns["Status"];
			this.columnEstimateDate = base.Columns["EstimateDate"];
			this.columnEstimateValue = base.Columns["EstimateValue"];
			this.columnItemTitle = base.Columns["ItemTitle"];
			this.columnDescription = base.Columns["Description"];
			this.columnArtwork = base.Columns["Artwork"];
			this.columnColour = base.Columns["Colour"];
			this.columnSize = base.Columns["Size"];
			this.columnMaterial = base.Columns["Material"];
			this.columnDelivery = base.Columns["Delivery"];
			this.columnFinishing = base.Columns["Finishing"];
			this.columnNotes = base.Columns["Notes"];
			this.columnInstructions = base.Columns["Instructions"];
			this.columnstr1 = base.Columns["str1"];
			this.columnstr2 = base.Columns["str2"];
			this.columnstr3 = base.Columns["str3"];
			this.columnstr4 = base.Columns["str4"];
			this.columnstr5 = base.Columns["str5"];
			this.columnstr6 = base.Columns["str6"];
			this.columnstr7 = base.Columns["str7"];
			this.columnstr8 = base.Columns["str8"];
			this.columnstr9 = base.Columns["str9"];
			this.columnstr10 = base.Columns["str10"];
			this.columnstr11 = base.Columns["str11"];
			this.columnstr12 = base.Columns["str12"];
			this.columnstr13 = base.Columns["str13"];
			this.columnstr14 = base.Columns["str14"];
			this.columnstr15 = base.Columns["str15"];
			this.columnstr16 = base.Columns["str16"];
			this.columnstr17 = base.Columns["str17"];
			this.columnstr18 = base.Columns["str18"];
			this.columnstragg1 = base.Columns["stragg1"];
			this.columnstragg2 = base.Columns["stragg2"];
			this.columnstragg3 = base.Columns["stragg3"];
			this.columnstragg4 = base.Columns["stragg4"];
			this.columnstragg5 = base.Columns["stragg5"];
			this.columnrdodetail1 = base.Columns["rdodetail1"];
			this.columnEstimateid = base.Columns["Estimateid"];
			this.columnEstimateItemID = base.Columns["EstimateItemID"];
			this.columnstatusid = base.Columns["statusid"];
			this.columnEstimateValuesm = base.Columns["EstimateValuesm"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public estimatereport.PC_Estimate_reportRow NewPC_Estimate_reportRow()
		{
			return (estimatereport.PC_Estimate_reportRow)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new estimatereport.PC_Estimate_reportRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.PC_Estimate_reportRowChanged != null)
			{
				this.PC_Estimate_reportRowChanged(this, new estimatereport.PC_Estimate_reportRowChangeEvent((estimatereport.PC_Estimate_reportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.PC_Estimate_reportRowChanging != null)
			{
				this.PC_Estimate_reportRowChanging(this, new estimatereport.PC_Estimate_reportRowChangeEvent((estimatereport.PC_Estimate_reportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.PC_Estimate_reportRowDeleted != null)
			{
				this.PC_Estimate_reportRowDeleted(this, new estimatereport.PC_Estimate_reportRowChangeEvent((estimatereport.PC_Estimate_reportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.PC_Estimate_reportRowDeleting != null)
			{
				this.PC_Estimate_reportRowDeleting(this, new estimatereport.PC_Estimate_reportRowChangeEvent((estimatereport.PC_Estimate_reportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void RemovePC_Estimate_reportRow(estimatereport.PC_Estimate_reportRow row)
		{
			base.Rows.Remove(row);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event estimatereport.PC_Estimate_reportRowChangeEventHandler PC_Estimate_reportRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event estimatereport.PC_Estimate_reportRowChangeEventHandler PC_Estimate_reportRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event estimatereport.PC_Estimate_reportRowChangeEventHandler PC_Estimate_reportRowDeleted;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event estimatereport.PC_Estimate_reportRowChangeEventHandler PC_Estimate_reportRowDeleting;
	}

	public class PC_Estimate_reportRow : DataRow
	{
		private estimatereport.PC_Estimate_reportDataTable tablePC_Estimate_report;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Artwork
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.ArtworkColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Artwork' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.ArtworkColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Colour
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.ColourColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Colour' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.ColourColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Company
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.CompanyColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Company' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.CompanyColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string CreatedBy
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.CreatedByColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'CreatedBy' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.CreatedByColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string CreatedDate
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.CreatedDateColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'CreatedDate' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.CreatedDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Delivery
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.DeliveryColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Delivery' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.DeliveryColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Description
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.DescriptionColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Description' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.DescriptionColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DateTime dt
		{
			get
			{
				return (DateTime)base[this.tablePC_Estimate_report.dtColumn];
			}
			set
			{
				base[this.tablePC_Estimate_report.dtColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string EstimateDate
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.EstimateDateColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'EstimateDate' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.EstimateDateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Estimateid
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.EstimateidColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Estimateid' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.EstimateidColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string EstimateItemID
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.EstimateItemIDColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'EstimateItemID' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.EstimateItemIDColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string EstimateNumber
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.EstimateNumberColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'EstimateNumber' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.EstimateNumberColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string EstimateTitle
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.EstimateTitleColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'EstimateTitle' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.EstimateTitleColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public decimal EstimateValue
		{
			get
			{
				return (decimal)base[this.tablePC_Estimate_report.EstimateValueColumn];
			}
			set
			{
				base[this.tablePC_Estimate_report.EstimateValueColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string EstimateValuesm
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.EstimateValuesmColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'EstimateValuesm' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.EstimateValuesmColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Finishing
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.FinishingColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Finishing' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.FinishingColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Instructions
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.InstructionsColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Instructions' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.InstructionsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string ItemTitle
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.ItemTitleColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'ItemTitle' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.ItemTitleColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Material
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.MaterialColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Material' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.MaterialColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Notes
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.NotesColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Notes' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.NotesColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string rdodetail1
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.rdodetail1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'rdodetail1' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.rdodetail1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Size
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.SizeColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Size' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.SizeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Status
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.StatusColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Status' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.StatusColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string statusid
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.statusidColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'statusid' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.statusidColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str1
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str1' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str10
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str10Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str10' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str10Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str11
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str11Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str11' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str11Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str12
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str12Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str12' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str12Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str13
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str13Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str13' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str13Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str14
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str14Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str14' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str14Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str15
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str15Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str15' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str15Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str16
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str16Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str16' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str16Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str17
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str17Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str17' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str17Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str18
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str18Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str18' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str18Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str2
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str2' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str3
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str3Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str3' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str4
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str4Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str4' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str5
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str5Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str5' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str6
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str6Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str6' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str6Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str7
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str7Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str7' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str7Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str8
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str8Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str8' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str8Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string str9
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.str9Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'str9' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.str9Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string stragg1
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.stragg1Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'stragg1' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.stragg1Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string stragg2
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.stragg2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'stragg2' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.stragg2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string stragg3
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.stragg3Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'stragg3' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.stragg3Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string stragg4
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.stragg4Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'stragg4' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.stragg4Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string stragg5
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Estimate_report.stragg5Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'stragg5' in table 'PC_Estimate_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Estimate_report.stragg5Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal PC_Estimate_reportRow(DataRowBuilder rb) : base(rb)
		{
			this.tablePC_Estimate_report = (estimatereport.PC_Estimate_reportDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsArtworkNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.ArtworkColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsColourNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.ColourColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsCompanyNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.CompanyColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsCreatedByNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.CreatedByColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsCreatedDateNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.CreatedDateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsDeliveryNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.DeliveryColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsDescriptionNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.DescriptionColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsEstimateDateNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.EstimateDateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsEstimateidNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.EstimateidColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsEstimateItemIDNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.EstimateItemIDColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsEstimateNumberNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.EstimateNumberColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsEstimateTitleNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.EstimateTitleColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsEstimateValuesmNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.EstimateValuesmColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsFinishingNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.FinishingColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsInstructionsNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.InstructionsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsItemTitleNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.ItemTitleColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsMaterialNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.MaterialColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsNotesNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.NotesColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isrdodetail1Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.rdodetail1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsSizeNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.SizeColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsstatusidNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.statusidColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsStatusNull()
		{
			return base.IsNull(this.tablePC_Estimate_report.StatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr10Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str10Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr11Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str11Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr12Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str12Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr13Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str13Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr14Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str14Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr15Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str15Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr16Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str16Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr17Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str17Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr18Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str18Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr1Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr2Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr3Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr4Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr5Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr6Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str6Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr7Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str7Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr8Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str8Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstr9Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.str9Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstragg1Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.stragg1Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstragg2Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.stragg2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstragg3Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.stragg3Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstragg4Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.stragg4Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool Isstragg5Null()
		{
			return base.IsNull(this.tablePC_Estimate_report.stragg5Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetArtworkNull()
		{
			base[this.tablePC_Estimate_report.ArtworkColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetColourNull()
		{
			base[this.tablePC_Estimate_report.ColourColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetCompanyNull()
		{
			base[this.tablePC_Estimate_report.CompanyColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetCreatedByNull()
		{
			base[this.tablePC_Estimate_report.CreatedByColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetCreatedDateNull()
		{
			base[this.tablePC_Estimate_report.CreatedDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetDeliveryNull()
		{
			base[this.tablePC_Estimate_report.DeliveryColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetDescriptionNull()
		{
			base[this.tablePC_Estimate_report.DescriptionColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetEstimateDateNull()
		{
			base[this.tablePC_Estimate_report.EstimateDateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetEstimateidNull()
		{
			base[this.tablePC_Estimate_report.EstimateidColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetEstimateItemIDNull()
		{
			base[this.tablePC_Estimate_report.EstimateItemIDColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetEstimateNumberNull()
		{
			base[this.tablePC_Estimate_report.EstimateNumberColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetEstimateTitleNull()
		{
			base[this.tablePC_Estimate_report.EstimateTitleColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetEstimateValuesmNull()
		{
			base[this.tablePC_Estimate_report.EstimateValuesmColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetFinishingNull()
		{
			base[this.tablePC_Estimate_report.FinishingColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetInstructionsNull()
		{
			base[this.tablePC_Estimate_report.InstructionsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetItemTitleNull()
		{
			base[this.tablePC_Estimate_report.ItemTitleColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetMaterialNull()
		{
			base[this.tablePC_Estimate_report.MaterialColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetNotesNull()
		{
			base[this.tablePC_Estimate_report.NotesColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setrdodetail1Null()
		{
			base[this.tablePC_Estimate_report.rdodetail1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetSizeNull()
		{
			base[this.tablePC_Estimate_report.SizeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetstatusidNull()
		{
			base[this.tablePC_Estimate_report.statusidColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetStatusNull()
		{
			base[this.tablePC_Estimate_report.StatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr10Null()
		{
			base[this.tablePC_Estimate_report.str10Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr11Null()
		{
			base[this.tablePC_Estimate_report.str11Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr12Null()
		{
			base[this.tablePC_Estimate_report.str12Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr13Null()
		{
			base[this.tablePC_Estimate_report.str13Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr14Null()
		{
			base[this.tablePC_Estimate_report.str14Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr15Null()
		{
			base[this.tablePC_Estimate_report.str15Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr16Null()
		{
			base[this.tablePC_Estimate_report.str16Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr17Null()
		{
			base[this.tablePC_Estimate_report.str17Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr18Null()
		{
			base[this.tablePC_Estimate_report.str18Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr1Null()
		{
			base[this.tablePC_Estimate_report.str1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr2Null()
		{
			base[this.tablePC_Estimate_report.str2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr3Null()
		{
			base[this.tablePC_Estimate_report.str3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr4Null()
		{
			base[this.tablePC_Estimate_report.str4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr5Null()
		{
			base[this.tablePC_Estimate_report.str5Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr6Null()
		{
			base[this.tablePC_Estimate_report.str6Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr7Null()
		{
			base[this.tablePC_Estimate_report.str7Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr8Null()
		{
			base[this.tablePC_Estimate_report.str8Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstr9Null()
		{
			base[this.tablePC_Estimate_report.str9Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstragg1Null()
		{
			base[this.tablePC_Estimate_report.stragg1Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstragg2Null()
		{
			base[this.tablePC_Estimate_report.stragg2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstragg3Null()
		{
			base[this.tablePC_Estimate_report.stragg3Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstragg4Null()
		{
			base[this.tablePC_Estimate_report.stragg4Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void Setstragg5Null()
		{
			base[this.tablePC_Estimate_report.stragg5Column] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class PC_Estimate_reportRowChangeEvent : EventArgs
	{
		private estimatereport.PC_Estimate_reportRow eventRow;

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
		public estimatereport.PC_Estimate_reportRow Row
		{
			get
			{
				return this.eventRow;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public PC_Estimate_reportRowChangeEvent(estimatereport.PC_Estimate_reportRow row, DataRowAction action)
		{
			this.eventRow = row;
			this.eventAction = action;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void PC_Estimate_reportRowChangeEventHandler(object sender, estimatereport.PC_Estimate_reportRowChangeEvent e);
}
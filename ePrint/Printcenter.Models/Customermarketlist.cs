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
[XmlRoot("Customermarketlist")]
[XmlSchemaProvider("GetTypedDataSetSchema")]
public class Customermarketlist : DataSet
{
	private Customermarketlist.PC_Customer_marketlist_reportDataTable tablePC_Customer_marketlist_report;

	private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;

	[Browsable(false)]
	[DebuggerNonUserCode]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public Customermarketlist.PC_Customer_marketlist_reportDataTable PC_Customer_marketlist_report
	{
		get
		{
			return this.tablePC_Customer_marketlist_report;
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
	public Customermarketlist()
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
	protected Customermarketlist(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
			if (dataSet.Tables["PC_Customer_marketlist_report"] != null)
			{
				base.Tables.Add(new Customermarketlist.PC_Customer_marketlist_reportDataTable(dataSet.Tables["PC_Customer_marketlist_report"]));
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
		Customermarketlist schemaSerializationMode = (Customermarketlist)base.Clone();
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
		Customermarketlist customermarketlist = new Customermarketlist();
		XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
		XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
		XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
		{
			Namespace = customermarketlist.Namespace
		};
		xmlSchemaSequence.Items.Add(xmlSchemaAny);
		xmlSchemaComplexType1.Particle = xmlSchemaSequence;
		XmlSchema schemaSerializable = customermarketlist.GetSchemaSerializable();
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
		base.DataSetName = "Customermarketlist";
		base.Prefix = "";
		base.Namespace = "http://tempuri.org/Customermarketlist.xsd";
		base.EnforceConstraints = true;
		this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
		this.tablePC_Customer_marketlist_report = new Customermarketlist.PC_Customer_marketlist_reportDataTable();
		base.Tables.Add(this.tablePC_Customer_marketlist_report);
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
		this.tablePC_Customer_marketlist_report = (Customermarketlist.PC_Customer_marketlist_reportDataTable)base.Tables["PC_Customer_marketlist_report"];
		if (initTable && this.tablePC_Customer_marketlist_report != null)
		{
			this.tablePC_Customer_marketlist_report.InitVars();
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
		if (dataSet.Tables["PC_Customer_marketlist_report"] != null)
		{
			base.Tables.Add(new Customermarketlist.PC_Customer_marketlist_reportDataTable(dataSet.Tables["PC_Customer_marketlist_report"]));
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
	private bool ShouldSerializePC_Customer_marketlist_report()
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
	public class PC_Customer_marketlist_reportDataTable : TypedTableBase<Customermarketlist.PC_Customer_marketlist_reportRow>
	{
		private DataColumn columnCustomer;

		private DataColumn columnClientID;

		private DataColumn columncontactfullname;

		private DataColumn columncontactfirstname;

		private DataColumn columncontactlastname;

		private DataColumn columncontactstatus;

		private DataColumn columncontactemail;

		private DataColumn columncontactphone;

		private DataColumn columnBillingAddress;

		private DataColumn columnBillingAddress2;

		private DataColumn columnBillingsuburb;

		private DataColumn columnBillingState;

		private DataColumn columnBillingPostcode;

		private DataColumn columnBillingcountry;

		private DataColumn columnDeliveryAddress;

		private DataColumn columnDeliveryAddress2;

		private DataColumn columnDeliverysuburb;

		private DataColumn columnDeliveryState;

		private DataColumn columnDeliveryPostcode;

		private DataColumn columnDeliverycountry;

		private DataColumn columnAccmanager;

		private DataColumn columnpaymentterms;

		private DataColumn columnreferralsource;

		private DataColumn columnretailexgst;

		private DataColumn columnGp;

		private DataColumn columnGPPercentage;

		private DataColumn columnlastinvoicedate;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn AccmanagerColumn
		{
			get
			{
				return this.columnAccmanager;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn BillingAddress2Column
		{
			get
			{
				return this.columnBillingAddress2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn BillingAddressColumn
		{
			get
			{
				return this.columnBillingAddress;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn BillingcountryColumn
		{
			get
			{
				return this.columnBillingcountry;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn BillingPostcodeColumn
		{
			get
			{
				return this.columnBillingPostcode;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn BillingStateColumn
		{
			get
			{
				return this.columnBillingState;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn BillingsuburbColumn
		{
			get
			{
				return this.columnBillingsuburb;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn ClientIDColumn
		{
			get
			{
				return this.columnClientID;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn contactemailColumn
		{
			get
			{
				return this.columncontactemail;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn contactfirstnameColumn
		{
			get
			{
				return this.columncontactfirstname;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn contactfullnameColumn
		{
			get
			{
				return this.columncontactfullname;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn contactlastnameColumn
		{
			get
			{
				return this.columncontactlastname;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn contactphoneColumn
		{
			get
			{
				return this.columncontactphone;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn contactstatusColumn
		{
			get
			{
				return this.columncontactstatus;
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
		public DataColumn CustomerColumn
		{
			get
			{
				return this.columnCustomer;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DeliveryAddress2Column
		{
			get
			{
				return this.columnDeliveryAddress2;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DeliveryAddressColumn
		{
			get
			{
				return this.columnDeliveryAddress;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DeliverycountryColumn
		{
			get
			{
				return this.columnDeliverycountry;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DeliveryPostcodeColumn
		{
			get
			{
				return this.columnDeliveryPostcode;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DeliveryStateColumn
		{
			get
			{
				return this.columnDeliveryState;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn DeliverysuburbColumn
		{
			get
			{
				return this.columnDeliverysuburb;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn GpColumn
		{
			get
			{
				return this.columnGp;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn GPPercentageColumn
		{
			get
			{
				return this.columnGPPercentage;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Customermarketlist.PC_Customer_marketlist_reportRow this[int index]
		{
			get
			{
				return (Customermarketlist.PC_Customer_marketlist_reportRow)base.Rows[index];
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn lastinvoicedateColumn
		{
			get
			{
				return this.columnlastinvoicedate;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn paymenttermsColumn
		{
			get
			{
				return this.columnpaymentterms;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn referralsourceColumn
		{
			get
			{
				return this.columnreferralsource;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public DataColumn retailexgstColumn
		{
			get
			{
				return this.columnretailexgst;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public PC_Customer_marketlist_reportDataTable()
		{
			base.TableName = "PC_Customer_marketlist_report";
			this.BeginInit();
			this.InitClass();
			this.EndInit();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal PC_Customer_marketlist_reportDataTable(DataTable table)
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
		protected PC_Customer_marketlist_reportDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this.InitVars();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void AddPC_Customer_marketlist_reportRow(Customermarketlist.PC_Customer_marketlist_reportRow row)
		{
			base.Rows.Add(row);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Customermarketlist.PC_Customer_marketlist_reportRow AddPC_Customer_marketlist_reportRow(string Customer, string contactfullname, string contactfirstname, string contactlastname, string contactstatus, string contactemail, string contactphone, string BillingAddress, string BillingAddress2, string Billingsuburb, string BillingState, string BillingPostcode, string Billingcountry, string DeliveryAddress, string DeliveryAddress2, string Deliverysuburb, string DeliveryState, string DeliveryPostcode, string Deliverycountry, string Accmanager, string paymentterms, string referralsource, string retailexgst, string Gp, string GPPercentage, string lastinvoicedate)
		{
			Customermarketlist.PC_Customer_marketlist_reportRow pCCustomerMarketlistReportRow = (Customermarketlist.PC_Customer_marketlist_reportRow)base.NewRow();
			object[] customer = new object[] { Customer, null, contactfullname, contactfirstname, contactlastname, contactstatus, contactemail, contactphone, BillingAddress, BillingAddress2, Billingsuburb, BillingState, BillingPostcode, Billingcountry, DeliveryAddress, DeliveryAddress2, Deliverysuburb, DeliveryState, DeliveryPostcode, Deliverycountry, Accmanager, paymentterms, referralsource, retailexgst, Gp, GPPercentage, lastinvoicedate };
			pCCustomerMarketlistReportRow.ItemArray = customer;
			base.Rows.Add(pCCustomerMarketlistReportRow);
			return pCCustomerMarketlistReportRow;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override DataTable Clone()
		{
			Customermarketlist.PC_Customer_marketlist_reportDataTable pCCustomerMarketlistReportDataTable = (Customermarketlist.PC_Customer_marketlist_reportDataTable)base.Clone();
			pCCustomerMarketlistReportDataTable.InitVars();
			return pCCustomerMarketlistReportDataTable;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataTable CreateInstance()
		{
			return new Customermarketlist.PC_Customer_marketlist_reportDataTable();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Customermarketlist.PC_Customer_marketlist_reportRow FindByClientID(int ClientID)
		{
			DataRowCollection rows = base.Rows;
			object[] clientID = new object[] { ClientID };
			return (Customermarketlist.PC_Customer_marketlist_reportRow)rows.Find(clientID);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override Type GetRowType()
		{
			return typeof(Customermarketlist.PC_Customer_marketlist_reportRow);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
		{
			XmlSchemaComplexType xmlSchemaComplexType;
			XmlSchema xmlSchema;
			XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
			XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
			Customermarketlist customermarketlist = new Customermarketlist();
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
				FixedValue = customermarketlist.Namespace
			};
			xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
			XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
			{
				Name = "tableTypeName",
				FixedValue = "PC_Customer_marketlist_reportDataTable"
			};
			xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
			xmlSchemaComplexType1.Particle = xmlSchemaSequence;
			XmlSchema schemaSerializable = customermarketlist.GetSchemaSerializable();
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
			this.columnCustomer = new DataColumn("Customer", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnCustomer);
			this.columnClientID = new DataColumn("ClientID", typeof(int), null, MappingType.Element);
			base.Columns.Add(this.columnClientID);
			this.columncontactfullname = new DataColumn("contactfullname", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columncontactfullname);
			this.columncontactfirstname = new DataColumn("contactfirstname", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columncontactfirstname);
			this.columncontactlastname = new DataColumn("contactlastname", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columncontactlastname);
			this.columncontactstatus = new DataColumn("contactstatus", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columncontactstatus);
			this.columncontactemail = new DataColumn("contactemail", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columncontactemail);
			this.columncontactphone = new DataColumn("contactphone", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columncontactphone);
			this.columnBillingAddress = new DataColumn("BillingAddress", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnBillingAddress);
			this.columnBillingAddress2 = new DataColumn("BillingAddress2", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnBillingAddress2);
			this.columnBillingsuburb = new DataColumn("Billingsuburb", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnBillingsuburb);
			this.columnBillingState = new DataColumn("BillingState", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnBillingState);
			this.columnBillingPostcode = new DataColumn("BillingPostcode", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnBillingPostcode);
			this.columnBillingcountry = new DataColumn("Billingcountry", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnBillingcountry);
			this.columnDeliveryAddress = new DataColumn("DeliveryAddress", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnDeliveryAddress);
			this.columnDeliveryAddress2 = new DataColumn("DeliveryAddress2", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnDeliveryAddress2);
			this.columnDeliverysuburb = new DataColumn("Deliverysuburb", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnDeliverysuburb);
			this.columnDeliveryState = new DataColumn("DeliveryState", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnDeliveryState);
			this.columnDeliveryPostcode = new DataColumn("DeliveryPostcode", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnDeliveryPostcode);
			this.columnDeliverycountry = new DataColumn("Deliverycountry", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnDeliverycountry);
			this.columnAccmanager = new DataColumn("Accmanager", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnAccmanager);
			this.columnpaymentterms = new DataColumn("paymentterms", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnpaymentterms);
			this.columnreferralsource = new DataColumn("referralsource", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnreferralsource);
			this.columnretailexgst = new DataColumn("retailexgst", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnretailexgst);
			this.columnGp = new DataColumn("Gp", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnGp);
			this.columnGPPercentage = new DataColumn("GPPercentage", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnGPPercentage);
			this.columnlastinvoicedate = new DataColumn("lastinvoicedate", typeof(string), null, MappingType.Element);
			base.Columns.Add(this.columnlastinvoicedate);
			ConstraintCollection constraints = base.Constraints;
			DataColumn[] dataColumnArray = new DataColumn[] { this.columnClientID };
			constraints.Add(new UniqueConstraint("Constraint1", dataColumnArray, true));
			this.columnCustomer.MaxLength = 300;
			this.columnClientID.AutoIncrement = true;
			this.columnClientID.AutoIncrementSeed = (long)-1;
			this.columnClientID.AutoIncrementStep = (long)-1;
			this.columnClientID.AllowDBNull = false;
			this.columnClientID.ReadOnly = true;
			this.columnClientID.Unique = true;
			this.columncontactfullname.ReadOnly = true;
			this.columncontactfullname.MaxLength = 401;
			this.columncontactfirstname.ReadOnly = true;
			this.columncontactfirstname.MaxLength = 200;
			this.columncontactlastname.ReadOnly = true;
			this.columncontactlastname.MaxLength = 200;
			this.columncontactstatus.ReadOnly = true;
			this.columncontactstatus.MaxLength = 1;
			this.columncontactemail.ReadOnly = true;
			this.columncontactemail.MaxLength = 1;
			this.columncontactphone.ReadOnly = true;
			this.columncontactphone.MaxLength = 1;
			this.columnBillingAddress.ReadOnly = true;
			this.columnBillingAddress.MaxLength = 2147483647;
			this.columnBillingAddress2.ReadOnly = true;
			this.columnBillingAddress2.MaxLength = 1;
			this.columnBillingsuburb.ReadOnly = true;
			this.columnBillingsuburb.MaxLength = 1;
			this.columnBillingState.ReadOnly = true;
			this.columnBillingState.MaxLength = 2147483647;
			this.columnBillingPostcode.ReadOnly = true;
			this.columnBillingPostcode.MaxLength = 2147483647;
			this.columnBillingcountry.ReadOnly = true;
			this.columnBillingcountry.MaxLength = 2147483647;
			this.columnDeliveryAddress.ReadOnly = true;
			this.columnDeliveryAddress.MaxLength = 2147483647;
			this.columnDeliveryAddress2.ReadOnly = true;
			this.columnDeliveryAddress2.MaxLength = 1;
			this.columnDeliverysuburb.ReadOnly = true;
			this.columnDeliverysuburb.MaxLength = 1;
			this.columnDeliveryState.ReadOnly = true;
			this.columnDeliveryState.MaxLength = 2147483647;
			this.columnDeliveryPostcode.ReadOnly = true;
			this.columnDeliveryPostcode.MaxLength = 2147483647;
			this.columnDeliverycountry.ReadOnly = true;
			this.columnDeliverycountry.MaxLength = 2147483647;
			this.columnAccmanager.ReadOnly = true;
			this.columnAccmanager.MaxLength = 1;
			this.columnpaymentterms.ReadOnly = true;
			this.columnpaymentterms.MaxLength = 1;
			this.columnreferralsource.ReadOnly = true;
			this.columnreferralsource.MaxLength = 1;
			this.columnretailexgst.ReadOnly = true;
			this.columnretailexgst.MaxLength = 1;
			this.columnGp.ReadOnly = true;
			this.columnGp.MaxLength = 1;
			this.columnGPPercentage.ReadOnly = true;
			this.columnGPPercentage.MaxLength = 1;
			this.columnlastinvoicedate.ReadOnly = true;
			this.columnlastinvoicedate.MaxLength = 1;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void InitVars()
		{
			this.columnCustomer = base.Columns["Customer"];
			this.columnClientID = base.Columns["ClientID"];
			this.columncontactfullname = base.Columns["contactfullname"];
			this.columncontactfirstname = base.Columns["contactfirstname"];
			this.columncontactlastname = base.Columns["contactlastname"];
			this.columncontactstatus = base.Columns["contactstatus"];
			this.columncontactemail = base.Columns["contactemail"];
			this.columncontactphone = base.Columns["contactphone"];
			this.columnBillingAddress = base.Columns["BillingAddress"];
			this.columnBillingAddress2 = base.Columns["BillingAddress2"];
			this.columnBillingsuburb = base.Columns["Billingsuburb"];
			this.columnBillingState = base.Columns["BillingState"];
			this.columnBillingPostcode = base.Columns["BillingPostcode"];
			this.columnBillingcountry = base.Columns["Billingcountry"];
			this.columnDeliveryAddress = base.Columns["DeliveryAddress"];
			this.columnDeliveryAddress2 = base.Columns["DeliveryAddress2"];
			this.columnDeliverysuburb = base.Columns["Deliverysuburb"];
			this.columnDeliveryState = base.Columns["DeliveryState"];
			this.columnDeliveryPostcode = base.Columns["DeliveryPostcode"];
			this.columnDeliverycountry = base.Columns["Deliverycountry"];
			this.columnAccmanager = base.Columns["Accmanager"];
			this.columnpaymentterms = base.Columns["paymentterms"];
			this.columnreferralsource = base.Columns["referralsource"];
			this.columnretailexgst = base.Columns["retailexgst"];
			this.columnGp = base.Columns["Gp"];
			this.columnGPPercentage = base.Columns["GPPercentage"];
			this.columnlastinvoicedate = base.Columns["lastinvoicedate"];
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public Customermarketlist.PC_Customer_marketlist_reportRow NewPC_Customer_marketlist_reportRow()
		{
			return (Customermarketlist.PC_Customer_marketlist_reportRow)base.NewRow();
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
		{
			return new Customermarketlist.PC_Customer_marketlist_reportRow(builder);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if (this.PC_Customer_marketlist_reportRowChanged != null)
			{
				this.PC_Customer_marketlist_reportRowChanged(this, new Customermarketlist.PC_Customer_marketlist_reportRowChangeEvent((Customermarketlist.PC_Customer_marketlist_reportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if (this.PC_Customer_marketlist_reportRowChanging != null)
			{
				this.PC_Customer_marketlist_reportRowChanging(this, new Customermarketlist.PC_Customer_marketlist_reportRowChangeEvent((Customermarketlist.PC_Customer_marketlist_reportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if (this.PC_Customer_marketlist_reportRowDeleted != null)
			{
				this.PC_Customer_marketlist_reportRowDeleted(this, new Customermarketlist.PC_Customer_marketlist_reportRowChangeEvent((Customermarketlist.PC_Customer_marketlist_reportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if (this.PC_Customer_marketlist_reportRowDeleting != null)
			{
				this.PC_Customer_marketlist_reportRowDeleting(this, new Customermarketlist.PC_Customer_marketlist_reportRowChangeEvent((Customermarketlist.PC_Customer_marketlist_reportRow)e.Row, e.Action));
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void RemovePC_Customer_marketlist_reportRow(Customermarketlist.PC_Customer_marketlist_reportRow row)
		{
			base.Rows.Remove(row);
		}

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Customermarketlist.PC_Customer_marketlist_reportRowChangeEventHandler PC_Customer_marketlist_reportRowChanged;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Customermarketlist.PC_Customer_marketlist_reportRowChangeEventHandler PC_Customer_marketlist_reportRowChanging;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Customermarketlist.PC_Customer_marketlist_reportRowChangeEventHandler PC_Customer_marketlist_reportRowDeleted;

		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event Customermarketlist.PC_Customer_marketlist_reportRowChangeEventHandler PC_Customer_marketlist_reportRowDeleting;
	}

	public class PC_Customer_marketlist_reportRow : DataRow
	{
		private Customermarketlist.PC_Customer_marketlist_reportDataTable tablePC_Customer_marketlist_report;

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Accmanager
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.AccmanagerColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Accmanager' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.AccmanagerColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string BillingAddress
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.BillingAddressColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'BillingAddress' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.BillingAddressColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string BillingAddress2
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.BillingAddress2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'BillingAddress2' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.BillingAddress2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Billingcountry
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.BillingcountryColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Billingcountry' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.BillingcountryColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string BillingPostcode
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.BillingPostcodeColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'BillingPostcode' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.BillingPostcodeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string BillingState
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.BillingStateColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'BillingState' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.BillingStateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Billingsuburb
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.BillingsuburbColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Billingsuburb' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.BillingsuburbColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public int ClientID
		{
			get
			{
				return (int)base[this.tablePC_Customer_marketlist_report.ClientIDColumn];
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.ClientIDColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string contactemail
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.contactemailColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'contactemail' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.contactemailColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string contactfirstname
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.contactfirstnameColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'contactfirstname' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.contactfirstnameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string contactfullname
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.contactfullnameColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'contactfullname' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.contactfullnameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string contactlastname
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.contactlastnameColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'contactlastname' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.contactlastnameColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string contactphone
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.contactphoneColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'contactphone' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.contactphoneColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string contactstatus
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.contactstatusColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'contactstatus' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.contactstatusColumn] = value;
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
					item = (string)base[this.tablePC_Customer_marketlist_report.CustomerColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Customer' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.CustomerColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string DeliveryAddress
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.DeliveryAddressColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'DeliveryAddress' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.DeliveryAddressColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string DeliveryAddress2
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.DeliveryAddress2Column];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'DeliveryAddress2' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.DeliveryAddress2Column] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Deliverycountry
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.DeliverycountryColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Deliverycountry' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.DeliverycountryColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string DeliveryPostcode
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.DeliveryPostcodeColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'DeliveryPostcode' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.DeliveryPostcodeColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string DeliveryState
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.DeliveryStateColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'DeliveryState' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.DeliveryStateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Deliverysuburb
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.DeliverysuburbColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Deliverysuburb' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.DeliverysuburbColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string Gp
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.GpColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'Gp' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.GpColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string GPPercentage
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.GPPercentageColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'GPPercentage' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.GPPercentageColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string lastinvoicedate
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.lastinvoicedateColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'lastinvoicedate' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.lastinvoicedateColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string paymentterms
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.paymenttermsColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'paymentterms' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.paymenttermsColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string referralsource
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.referralsourceColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'referralsource' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.referralsourceColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string retailexgst
		{
			get
			{
				string item;
				try
				{
					item = (string)base[this.tablePC_Customer_marketlist_report.retailexgstColumn];
				}
				catch (InvalidCastException invalidCastException)
				{
					throw new StrongTypingException("The value for column 'retailexgst' in table 'PC_Customer_marketlist_report' is DBNull.", invalidCastException);
				}
				return item;
			}
			set
			{
				base[this.tablePC_Customer_marketlist_report.retailexgstColumn] = value;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal PC_Customer_marketlist_reportRow(DataRowBuilder rb) : base(rb)
		{
			this.tablePC_Customer_marketlist_report = (Customermarketlist.PC_Customer_marketlist_reportDataTable)base.Table;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsAccmanagerNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.AccmanagerColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsBillingAddress2Null()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.BillingAddress2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsBillingAddressNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.BillingAddressColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsBillingcountryNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.BillingcountryColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsBillingPostcodeNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.BillingPostcodeColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsBillingStateNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.BillingStateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsBillingsuburbNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.BillingsuburbColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IscontactemailNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.contactemailColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IscontactfirstnameNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.contactfirstnameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IscontactfullnameNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.contactfullnameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IscontactlastnameNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.contactlastnameColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IscontactphoneNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.contactphoneColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IscontactstatusNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.contactstatusColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsCustomerNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.CustomerColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsDeliveryAddress2Null()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.DeliveryAddress2Column);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsDeliveryAddressNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.DeliveryAddressColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsDeliverycountryNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.DeliverycountryColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsDeliveryPostcodeNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.DeliveryPostcodeColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsDeliveryStateNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.DeliveryStateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsDeliverysuburbNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.DeliverysuburbColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsGpNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.GpColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsGPPercentageNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.GPPercentageColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IslastinvoicedateNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.lastinvoicedateColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IspaymenttermsNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.paymenttermsColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsreferralsourceNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.referralsourceColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsretailexgstNull()
		{
			return base.IsNull(this.tablePC_Customer_marketlist_report.retailexgstColumn);
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetAccmanagerNull()
		{
			base[this.tablePC_Customer_marketlist_report.AccmanagerColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetBillingAddress2Null()
		{
			base[this.tablePC_Customer_marketlist_report.BillingAddress2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetBillingAddressNull()
		{
			base[this.tablePC_Customer_marketlist_report.BillingAddressColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetBillingcountryNull()
		{
			base[this.tablePC_Customer_marketlist_report.BillingcountryColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetBillingPostcodeNull()
		{
			base[this.tablePC_Customer_marketlist_report.BillingPostcodeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetBillingStateNull()
		{
			base[this.tablePC_Customer_marketlist_report.BillingStateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetBillingsuburbNull()
		{
			base[this.tablePC_Customer_marketlist_report.BillingsuburbColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetcontactemailNull()
		{
			base[this.tablePC_Customer_marketlist_report.contactemailColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetcontactfirstnameNull()
		{
			base[this.tablePC_Customer_marketlist_report.contactfirstnameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetcontactfullnameNull()
		{
			base[this.tablePC_Customer_marketlist_report.contactfullnameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetcontactlastnameNull()
		{
			base[this.tablePC_Customer_marketlist_report.contactlastnameColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetcontactphoneNull()
		{
			base[this.tablePC_Customer_marketlist_report.contactphoneColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetcontactstatusNull()
		{
			base[this.tablePC_Customer_marketlist_report.contactstatusColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetCustomerNull()
		{
			base[this.tablePC_Customer_marketlist_report.CustomerColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetDeliveryAddress2Null()
		{
			base[this.tablePC_Customer_marketlist_report.DeliveryAddress2Column] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetDeliveryAddressNull()
		{
			base[this.tablePC_Customer_marketlist_report.DeliveryAddressColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetDeliverycountryNull()
		{
			base[this.tablePC_Customer_marketlist_report.DeliverycountryColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetDeliveryPostcodeNull()
		{
			base[this.tablePC_Customer_marketlist_report.DeliveryPostcodeColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetDeliveryStateNull()
		{
			base[this.tablePC_Customer_marketlist_report.DeliveryStateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetDeliverysuburbNull()
		{
			base[this.tablePC_Customer_marketlist_report.DeliverysuburbColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetGpNull()
		{
			base[this.tablePC_Customer_marketlist_report.GpColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetGPPercentageNull()
		{
			base[this.tablePC_Customer_marketlist_report.GPPercentageColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetlastinvoicedateNull()
		{
			base[this.tablePC_Customer_marketlist_report.lastinvoicedateColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetpaymenttermsNull()
		{
			base[this.tablePC_Customer_marketlist_report.paymenttermsColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetreferralsourceNull()
		{
			base[this.tablePC_Customer_marketlist_report.referralsourceColumn] = Convert.DBNull;
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetretailexgstNull()
		{
			base[this.tablePC_Customer_marketlist_report.retailexgstColumn] = Convert.DBNull;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class PC_Customer_marketlist_reportRowChangeEvent : EventArgs
	{
		private Customermarketlist.PC_Customer_marketlist_reportRow eventRow;

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
		public Customermarketlist.PC_Customer_marketlist_reportRow Row
		{
			get
			{
				return this.eventRow;
			}
		}

		[DebuggerNonUserCode]
		[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public PC_Customer_marketlist_reportRowChangeEvent(Customermarketlist.PC_Customer_marketlist_reportRow row, DataRowAction action)
		{
			this.eventRow = row;
			this.eventAction = action;
		}
	}

	[GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void PC_Customer_marketlist_reportRowChangeEventHandler(object sender, Customermarketlist.PC_Customer_marketlist_reportRowChangeEvent e);
}
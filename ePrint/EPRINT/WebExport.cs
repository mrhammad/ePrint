using Spire.DataExport.Common;
using Spire.DataExport.XLS;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;
using System.Xml;
using System.Xml.Xsl;

namespace EPRINT
{
	public class WebExport
	{
		private HttpResponse response;

		private string appType;

		public WebExport()
		{
			this.appType = "Web";
			this.response = HttpContext.Current.Response;
		}

		public WebExport(string ApplicationType)
		{
			this.appType = ApplicationType;
			if (this.appType != "Web" && this.appType != "Win")
			{
				throw new Exception("Provide valid application format (Web/Win)");
			}
			if (this.appType == "Web")
			{
				this.response = HttpContext.Current.Response;
			}
		}

		private void CreateStylesheet(XmlTextWriter writer, string[] sHeaders, string[] sFileds, WebExport.ExportFormat FormatType, string type)
		{
			try
			{
				string str = "http://www.w3.org/1999/XSL/Transform";
				writer.Formatting = Formatting.Indented;
				writer.WriteStartDocument();
				writer.WriteStartElement("xsl", "stylesheet", str);
				writer.WriteAttributeString("version", "1.0");
				writer.WriteStartElement("xsl:output");
				writer.WriteAttributeString("method", "text");
				writer.WriteAttributeString("version", "4.0");
				writer.WriteEndElement();
				writer.WriteStartElement("xsl:template");
				writer.WriteAttributeString("match", "/");
				for (int i = 0; i < (int)sHeaders.Length; i++)
				{
					writer.WriteString("\"");
					writer.WriteStartElement("xsl:value-of");
					writer.WriteAttributeString("select", string.Concat("'", sHeaders[i], "'"));
					writer.WriteEndElement();
					writer.WriteString("\"");
					if (i != (int)sFileds.Length - 1)
					{
						writer.WriteString((FormatType == WebExport.ExportFormat.CSV ? type : "\t"));
					}
				}
				writer.WriteStartElement("xsl:for-each");
				writer.WriteAttributeString("select", "Export/Values");
				writer.WriteString("\r\n");
				for (int j = 0; j < (int)sFileds.Length; j++)
				{
					writer.WriteString("\"");
					writer.WriteStartElement("xsl:value-of");
					writer.WriteAttributeString("select", sFileds[j]);
					writer.WriteEndElement();
					writer.WriteString("\"");
					if (j != (int)sFileds.Length - 1)
					{
						writer.WriteString((FormatType == WebExport.ExportFormat.CSV ? type : "\t"));
					}
				}
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteEndDocument();
			}
			catch (Exception exception)
			{
				throw exception;
			}
		}

		public void Export_with_CSV_Web(DataTable dsExport, string FileName)
		{
			CellExport cellExport = new CellExport()
			{
				ActionAfterExport = ActionType.OpenView,
				AutoFitColWidth = true
			};
			cellExport.DataFormats.CultureName = "en-US";
			cellExport.DataFormats.Currency = "#,###,##0.00";
			cellExport.DataFormats.DateTime = "yyyy-M-d H:mm";
			cellExport.DataFormats.Float = "#,###,##0.00";
			cellExport.DataFormats.Integer = "#,###,##0";
			cellExport.DataFormats.Time = "H:mm";
			cellExport.SheetOptions.AggregateFormat.Font.Name = "Arial";
			cellExport.SheetOptions.CustomDataFormat.Font.Name = "Arial";
			cellExport.SheetOptions.DefaultFont.Name = "Arial";
			cellExport.SheetOptions.FooterFormat.Font.Name = "Arial";
			cellExport.SheetOptions.HeaderFormat.Font.Name = "Arial";
			cellExport.SheetOptions.HyperlinkFormat.Font.Color = CellColor.Blue;
			cellExport.SheetOptions.HyperlinkFormat.Font.Name = "Arial";
			cellExport.SheetOptions.HyperlinkFormat.Font.Underline = XlsFontUnderline.Single;
			cellExport.SheetOptions.NoteFormat.Alignment.Horizontal = HorizontalAlignment.Left;
			cellExport.SheetOptions.NoteFormat.Alignment.Vertical = VerticalAlignment.Top;
			cellExport.SheetOptions.NoteFormat.Font.Bold = true;
			cellExport.SheetOptions.NoteFormat.Font.Name = "Tahoma";
			cellExport.SheetOptions.NoteFormat.Font.Size = 8f;
			cellExport.SheetOptions.TitlesFormat.Font.Bold = true;
			cellExport.SheetOptions.TitlesFormat.Font.Name = "Arial";
			cellExport.DataTable = dsExport;
			cellExport.DataSource = ExportSource.DataTable;
			FileName = FileName.ToLower().Replace(".xls", "");
			cellExport.FileName = string.Concat(FileName, ".csv");
			MemoryStream memoryStream = new MemoryStream();
			cellExport.SaveToStream(memoryStream);
			byte[] numArray = new byte[checked(memoryStream.Length)];
			memoryStream.Read(numArray, 0, (int)numArray.Length);
			memoryStream.Close();
			this.response.ContentType = "application/vnd.ms-excel";
			this.response.AddHeader("content-disposition", string.Concat("attachment; filename=\"", cellExport.FileName, "\""));
			this.response.BinaryWrite(numArray);
			HttpContext.Current.ApplicationInstance.CompleteRequest();
		}

		public void Export_with_XSLT_Web(DataSet dsExport, string[] sHeaders, string[] sFileds, WebExport.ExportFormat FormatType, string FileName, string type)
		{
			try
			{
				this.response.Clear();
				this.response.Buffer = true;
				if (FormatType != WebExport.ExportFormat.CSV)
				{
					this.response.ContentType = "application/xls";
					this.response.AppendHeader("content-disposition", string.Concat("attachment; filename=\"", FileName, "\""));
				}
				else
				{
					this.response.ContentType = "text/csv";
					this.response.AppendHeader("content-disposition", string.Concat("attachment; filename=\"", FileName, "\""));
				}
				MemoryStream memoryStream = new MemoryStream();
				XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
				this.CreateStylesheet(xmlTextWriter, sHeaders, sFileds, FormatType, type);
				xmlTextWriter.Flush();
				memoryStream.Seek((long)0, SeekOrigin.Begin);
				XmlDataDocument xmlDataDocument = new XmlDataDocument(dsExport);
				XslTransform xslTransform = new XslTransform();
				xslTransform.Load(new XmlTextReader(memoryStream), null, null);
				StringWriter stringWriter = new StringWriter();
				xslTransform.Transform(xmlDataDocument, null, stringWriter, null);
				this.response.Write(stringWriter.ToString());
				stringWriter.Close();
				xmlTextWriter.Close();
				memoryStream.Close();
				this.response.End();
			}
			catch (ThreadAbortException threadAbortException)
			{
				string message = threadAbortException.Message;
			}
			catch (Exception exception)
			{
				throw exception;
			}
		}

		public void Export_with_XSLT_Web(DataTable dsExport, string FileName)
		{
			CellExport cellExport = new CellExport()
			{
				ActionAfterExport = ActionType.OpenView,
				AutoFitColWidth = true
			};
			cellExport.DataFormats.CultureName = "en-US";
			cellExport.DataFormats.Currency = "#,###,##0.00";
			cellExport.DataFormats.DateTime = "yyyy-M-d H:mm";
			cellExport.DataFormats.Float = "#,###,##0.00";
			cellExport.DataFormats.Integer = "#,###,##0";
			cellExport.DataFormats.Time = "H:mm";
			cellExport.SheetOptions.AggregateFormat.Font.Name = "Arial";
			cellExport.SheetOptions.CustomDataFormat.Font.Name = "Arial";
			cellExport.SheetOptions.DefaultFont.Name = "Arial";
			cellExport.SheetOptions.FooterFormat.Font.Name = "Arial";
			cellExport.SheetOptions.HeaderFormat.Font.Name = "Arial";
			cellExport.SheetOptions.HyperlinkFormat.Font.Color = CellColor.Blue;
			cellExport.SheetOptions.HyperlinkFormat.Font.Name = "Arial";
			cellExport.SheetOptions.HyperlinkFormat.Font.Underline = XlsFontUnderline.Single;
			cellExport.SheetOptions.NoteFormat.Alignment.Horizontal = HorizontalAlignment.Left;
			cellExport.SheetOptions.NoteFormat.Alignment.Vertical = VerticalAlignment.Top;
			cellExport.SheetOptions.NoteFormat.Font.Bold = true;
			cellExport.SheetOptions.NoteFormat.Font.Name = "Tahoma";
			cellExport.SheetOptions.NoteFormat.Font.Size = 8f;
			cellExport.SheetOptions.TitlesFormat.Font.Bold = true;
			cellExport.SheetOptions.TitlesFormat.Font.Name = "Arial";
			cellExport.DataTable = dsExport;
			cellExport.DataSource = ExportSource.DataTable;
			FileName = FileName.ToLower().Replace(".csv", "").Replace(".xls", "");
			cellExport.FileName = string.Concat(FileName, ".xls");
			MemoryStream memoryStream = new MemoryStream();
			cellExport.SaveToStream(memoryStream);
			byte[] numArray = new byte[checked(memoryStream.Length)];
			memoryStream.Read(numArray, 0, (int)numArray.Length);
			memoryStream.Close();
			this.response.ContentType = "application/vnd.ms-excel";
			this.response.AddHeader("content-disposition", string.Concat("attachment; filename=\"", cellExport.FileName, "\""));
			this.response.BinaryWrite(numArray);
			HttpContext.Current.ApplicationInstance.CompleteRequest();
		}

		private string ReplaceSpclChars(string fieldName)
		{
			fieldName = fieldName.Replace(" ", "_x0020_");
			fieldName = fieldName.Replace("%", "_x0025_");
			fieldName = fieldName.Replace("#", "_x0023_");
			fieldName = fieldName.Replace("&", "_x0026_");
			fieldName = fieldName.Replace("/", "_x002F_");
			return fieldName;
		}

		public void WebExportDetails(DataTable DetailsTable, WebExport.ExportFormat FormatType, string FileName, string type)
		{
			try
			{
				DataSet dataSet = new DataSet("Export");
				DataTable dataTable = DetailsTable.Copy();
				dataTable.TableName = "Values";
				dataSet.Tables.Add(dataTable);
				string[] columnName = new string[dataTable.Columns.Count];
				string[] strArrays = new string[dataTable.Columns.Count];
				for (int i = 0; i < dataTable.Columns.Count; i++)
				{
					columnName[i] = dataTable.Columns[i].ColumnName;
					strArrays[i] = this.ReplaceSpclChars(dataTable.Columns[i].ColumnName);
				}
				if (this.appType == "Web")
				{
					this.Export_with_XSLT_Web(dataSet, columnName, strArrays, FormatType, FileName, type);
				}
			}
			catch (Exception exception)
			{
				throw exception;
			}
		}

		public enum ExportFormat
		{
			CSV = 1,
			Excel = 2
		}
	}
}
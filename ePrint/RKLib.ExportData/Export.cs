using System;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;
using System.Xml;
using System.Xml.Xsl;

namespace RKLib.ExportData
{
	public class Export
	{
		private HttpResponse response;

		private string appType;

		public Export()
		{
			this.appType = "Web";
			this.response = HttpContext.Current.Response;
		}

		public Export(string ApplicationType)
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

		private void CreateStylesheet(XmlTextWriter writer, string[] sHeaders, string[] sFileds, Export.ExportFormat FormatType, string type)
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
						writer.WriteString((FormatType == Export.ExportFormat.CSV ? type : "\t"));
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
						writer.WriteString((FormatType == Export.ExportFormat.CSV ? type : "\t"));
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

		public void Export_with_XSLT_Web(DataSet dsExport, string[] sHeaders, string[] sFileds, Export.ExportFormat FormatType, string FileName, string type)
		{
			try
			{
				this.response.Clear();
				this.response.Buffer = true;
				if (FormatType != Export.ExportFormat.CSV)
				{
					this.response.ContentType = "application/vnd.ms-excel";
					this.response.AppendHeader("content-disposition", string.Concat("inline; filename=", FileName));
				}
				else
				{
					this.response.ContentType = "text/csv";
					this.response.AppendHeader("content-disposition", string.Concat("inline; filename=", FileName));
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

		public void ExportDetails(DataTable DetailsTable, Export.ExportFormat FormatType, string FileName, string type)
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
					if (!dataTable.Columns[i].ColumnName.Contains("Annual Revenue"))
					{
						columnName[i] = dataTable.Columns[i].ColumnName;
						strArrays[i] = this.ReplaceSpclChars(dataTable.Columns[i].ColumnName);
					}
					else
					{
						columnName[i] = dataTable.Columns[i].ColumnName;
						strArrays[i] = this.ReplaceSpclChars1(dataTable.Columns[i].ColumnName);
					}
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

		private string ReplaceSpclChars(string fieldName)
		{
			fieldName = fieldName.Replace(" ", "_x0020_");
			fieldName = fieldName.Replace("%", "_x0025_");
			fieldName = fieldName.Replace("#", "_x0023_");
			fieldName = fieldName.Replace("&", "_x0026_");
			fieldName = fieldName.Replace("/", "_x002F_");
			return fieldName;
		}

		private string ReplaceSpclChars1(string fieldName)
		{
			fieldName = fieldName.Replace(" ", "_x0020_");
			fieldName = fieldName.Replace("%", "_x0025_");
			fieldName = fieldName.Replace("#", "_x0023_");
			fieldName = fieldName.Replace("&", "_x0026_");
			fieldName = fieldName.Replace("/", "_x002F_");
			fieldName = fieldName.Replace("(", "");
			fieldName = fieldName.Replace(")", "");
			return fieldName;
		}

		public void Save_ExportedDetails_InPath(DataTable DetailsTable, Export.ExportFormat FormatType, string FileNameWithPath, string type)
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
					if (!dataTable.Columns[i].ColumnName.Contains("Annual Revenue"))
					{
						columnName[i] = dataTable.Columns[i].ColumnName;
						strArrays[i] = this.ReplaceSpclChars(dataTable.Columns[i].ColumnName);
					}
					else
					{
						columnName[i] = dataTable.Columns[i].ColumnName;
						strArrays[i] = this.ReplaceSpclChars1(dataTable.Columns[i].ColumnName);
					}
				}
				if (this.appType == "Web")
				{
					try
					{
						this.response.Clear();
						this.response.Buffer = true;
						MemoryStream memoryStream = new MemoryStream();
						XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
						this.CreateStylesheet(xmlTextWriter, columnName, strArrays, FormatType, type);
						xmlTextWriter.Flush();
						memoryStream.Seek((long)0, SeekOrigin.Begin);
						XmlDataDocument xmlDataDocument = new XmlDataDocument(dataSet);
						XslTransform xslTransform = new XslTransform();
						xslTransform.Load(new XmlTextReader(memoryStream), null, null);
						StringWriter stringWriter = new StringWriter();
						xslTransform.Transform(xmlDataDocument, null, stringWriter, null);
						FileStream fileStream = new FileStream(FileNameWithPath, FileMode.Create);
						StreamWriter streamWriter = new StreamWriter(fileStream);
						streamWriter.Write(stringWriter.ToString());
						streamWriter.Close();
						fileStream.Close();
						stringWriter.Close();
						xmlTextWriter.Close();
						memoryStream.Close();
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
			}
			catch (Exception exception1)
			{
				throw exception1;
			}
		}

		public enum ExportFormat
		{
			CSV = 1,
			Excel = 2
		}
	}
}
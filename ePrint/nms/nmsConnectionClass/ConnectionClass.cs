using System;
using System.Configuration;
using System.Web;
using System.Web.SessionState;

namespace nmsConnectionClass
{
	public class ConnectionClass
	{
		public static string AccountingCode
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["AccountingCode"] == null)
				{
					return "n";
				}
				if (EprintConfigurationManager.AppSettings["AccountingCode"].ToString() == "e")
				{
					return "e";
				}
				if (EprintConfigurationManager.AppSettings["AccountingCode"].ToString() == "d")
				{
					return "d";
				}
				return "n";
			}
		}

		public static string AccountingExport
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["AccountingExport"] == null)
				{
					return "n";
				}
				if (EprintConfigurationManager.AppSettings["AccountingExport"] != "AE")
				{
					return "n";
				}
				return EprintConfigurationManager.AppSettings["AccountingExport"].ToString();
			}
		}

		public static string B2BURL
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["B2BURL"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["B2BURL"].ToString();
			}
		}

		public static string B2CURL
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["B2CURL"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["B2CURL"].ToString();
			}
		}

		public static string CurrencySymbol
		{
			get
			{
				if (HttpContext.Current.Session["CurrencySymbol"] == null)
				{
					return "$";
				}
				return HttpContext.Current.Session["CurrencySymbol"].ToString().Trim();
			}
		}

		public static string DefaultImageHeight
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["DefaultImageHeight"] == null)
				{
					return "0";
				}
				return EprintConfigurationManager.AppSettings["DefaultImageHeight"].ToString();
			}
		}

		public static string DefaultImageWidth
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["DefaultImageWidth"] == null)
				{
					return "0";
				}
				return EprintConfigurationManager.AppSettings["DefaultImageWidth"].ToString();
			}
		}

		public static string DeliveryNote
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["DeliveryNote"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["DeliveryNote"].ToString();
			}
		}

		public static string DeliveryNotePrefix
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["DeliveryNotePrefix"] == null)
				{
					return "DEL-";
				}
				return EprintConfigurationManager.AppSettings["DeliveryNotePrefix"].ToString();
			}
		}

		public static long DeliveryStatusID
		{
			get
			{

				long num = (long)0;

                //long.TryParse(EprintConfigurationManager.AppSettings["DeliveryStausID"].ToString(), out num);
                if (EprintConfigurationManager.AppSettings["DeliveryStausID"] != null)
				{
					num = (EprintConfigurationManager.AppSettings["DeliveryStausID"] == "0" ? (long)0 : Convert.ToInt64(EprintConfigurationManager.AppSettings["DeliveryStausID"].ToString()));
				}
				return num;
			}
		}

		public static string DigitalBooklet
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["DigitalBooklet"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["DigitalBooklet"].ToString();
			}
		}

		public static string DigitalPads
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["DigitalPads"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["DigitalPads"].ToString();
			}
		}

		public static string DigitalSingleItem
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["DigitalSingleItem"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["DigitalSingleItem"].ToString();
			}
		}

        public static string DigitalNCR
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["DigitalNCR"] == null)
                {
                    return null;
                }
                return EprintConfigurationManager.AppSettings["DigitalNCR"].ToString();
            }
        }

        public static string EditableFrontEndPath
		{
			get
			{
				string str = "";
				if (EprintConfigurationManager.AppSettings["EditableFrontEndPath"] != null)
				{
					str = (EprintConfigurationManager.AppSettings["EditableFrontEndPath"] == "" ? "" : EprintConfigurationManager.AppSettings["EditableFrontEndPath"].ToString());
				}
				return str;
			}
		}

		public static string EditableTemplate
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["EditableTemplate"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["EditableTemplate"].ToString();
			}
		}

		public static string EditableTemplatePath
		{
			get
			{
				string str = "";
				if (EprintConfigurationManager.AppSettings["EditableTemplatePath"] != null)
				{
					str = (EprintConfigurationManager.AppSettings["EditableTemplatePath"] == "" ? "" : EprintConfigurationManager.AppSettings["EditableTemplatePath"].ToString());
				}
				return str;
			}
		}

		public static string EmailEnable
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["EmailEnable"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["EmailEnable"].ToString();
			}
		}

		public static string EmailHostName
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["EmailHostName"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["EmailHostName"].ToString();
			}
		}

		public static string EmailPassword
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["EmailPassword"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["EmailPassword"].ToString();
			}
		}

		public static string EmailUserName
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["EmailUserName"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["EmailUserName"].ToString();
			}
		}

		public static bool EnableBulkEmailSend
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["EnableBulkEmailSend"] == null)
				{
					return false;
				}
				if (Convert.ToBoolean(EprintConfigurationManager.AppSettings["EnableBulkEmailSend"]))
				{
					return true;
				}
				return false;
			}
		}

		public static bool EnableNetsuite
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["EnableNetsuite"] == null)
				{
					return false;
				}
				if (Convert.ToBoolean(EprintConfigurationManager.AppSettings["EnableNetsuite"]))
				{
					return true;
				}
				return false;
			}
		}

		public static string EstimatePrefix
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["EstimatePrefix"] == null)
				{
					return "EST-";
				}
				return EprintConfigurationManager.AppSettings["EstimatePrefix"].ToString();
			}
		}

		public static string faviconpath
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["faviconpath"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["faviconpath"].ToString();
			}
		}

		public static string FileExtension
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["FileExtension"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["FileExtension"].ToString();
			}
		}

		public static string FreshBooksAPI
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["FreshBooksAPI"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["FreshBooksAPI"].ToString();
			}
		}

		public static string ImageHandlerPath
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["ImageHandlerPath"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["ImageHandlerPath"];
			}
		}

		public static string ImagePathFromFrontEnd
		{
			get
			{
				string str = "";
				if (EprintConfigurationManager.AppSettings["ImagePathFromFrontEnd"] != null)
				{
					str = (EprintConfigurationManager.AppSettings["ImagePathFromFrontEnd"] == "" ? "" : EprintConfigurationManager.AppSettings["ImagePathFromFrontEnd"].ToString());
				}
				return str;
			}
		}

		public static string InventoryManagement
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["InventoryManagement"] == null)
				{
					return "n";
				}
				if (EprintConfigurationManager.AppSettings["InventoryManagement"] != "IM")
				{
					return "n";
				}
				return EprintConfigurationManager.AppSettings["InventoryManagement"].ToString();
			}
		}

		public static string InvoicePrefix
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["InvoicePrefix"] == null)
				{
					return "INV-";
				}
				return EprintConfigurationManager.AppSettings["InvoicePrefix"].ToString();
			}
		}

		public static string Is_crm_order_module
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["Is_crm_order_module"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["Is_crm_order_module"].ToString();
			}
		}

		public static bool Is_estorecampaign
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["IsestoreCampaign"] == null)
				{
					return false;
				}
				return Convert.ToBoolean(EprintConfigurationManager.AppSettings["IsestoreCampaign"]);
			}
		}

		public static bool Is_Non_Printing_System
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["Is_Non_Printing_System"] == null)
				{
					return false;
				}
				return Convert.ToBoolean(EprintConfigurationManager.AppSettings["Is_Non_Printing_System"]);
			}
		}

		public static bool ISDisableItemSplit
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["DisableItemSplit"] == null)
				{
					return false;
				}
				if (Convert.ToBoolean(EprintConfigurationManager.AppSettings["DisableItemSplit"]))
				{
					return true;
				}
				return false;
			}
		}

		public static bool IsHandy
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["IsHandy"] == null)
				{
					return false;
				}
				if (EprintConfigurationManager.AppSettings["IsHandy"] != "true")
				{
					return false;
				}
				return Convert.ToBoolean(EprintConfigurationManager.AppSettings["IsHandy"]);
			}
		}

		public static string IsLocal
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["IsLocal"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["IsLocal"].ToString();
			}
		}

		public static string IsmailChimpEnabled
		{
			get
			{
				string str = "";
				if (EprintConfigurationManager.AppSettings["IsmailChimpEnabled"] != null)
				{
					str = (EprintConfigurationManager.AppSettings["IsmailChimpEnabled"] != "true" ? "false" : EprintConfigurationManager.AppSettings["IsmailChimpEnabled"].ToString());
				}
				return str;
			}
		}

		public static bool IsOccy
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["IsOccy"] == null)
				{
					return false;
				}
				if (EprintConfigurationManager.AppSettings["IsOccy"] != "true")
				{
					return false;
				}
				return Convert.ToBoolean(EprintConfigurationManager.AppSettings["IsOccy"]);
			}
		}

		public static string IsPaymentEnable
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["IsPaymentEnable"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["IsPaymentEnable"].ToString();
			}
		}

		public static string IsProductDescAutofill
		{
			get
			{
				string str = "false";
				str = (EprintConfigurationManager.AppSettings["IsProductDescAutofill"] == null ? "false" : EprintConfigurationManager.AppSettings["IsProductDescAutofill"]);
				return str;
			}
		}

		public static bool IsQuickBooks
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["IsQuickBooks"] == null)
				{
					return false;
				}
				return Convert.ToBoolean(EprintConfigurationManager.AppSettings["IsQuickBooks"]);
			}
		}

		public static bool IsQuickBooksAPI
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["IsQuickBooks"] == null)
				{
					return false;
				}
				return Convert.ToBoolean(EprintConfigurationManager.AppSettings["IsQuickBooks"]);
			}
		}

		public static bool IsSplitItem
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["IsSplitItem"] == null)
				{
					return false;
				}
				return Convert.ToBoolean(EprintConfigurationManager.AppSettings["IsSplitItem"]);
			}
		}

		public static bool IsSquareMeter
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["IsSquareMeter"] == null)
				{
					return false;
				}
				return Convert.ToBoolean(EprintConfigurationManager.AppSettings["IsSquareMeter"]);
			}
		}

		public static string ISSubScribeUser
		{
			get
			{
				string str = "";
				if (EprintConfigurationManager.AppSettings["ISSubScribeUser"] != null)
				{
					str = (EprintConfigurationManager.AppSettings["ISSubScribeUser"] != "true" ? "false" : EprintConfigurationManager.AppSettings["ISSubScribeUser"].ToString());
				}
				return str;
			}
		}

		public static bool IsTerritoryManagerEmail
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["IsTerritoryManagerEmail"] == null)
				{
					return false;
				}
				if (Convert.ToBoolean(EprintConfigurationManager.AppSettings["IsTerritoryManagerEmail"]))
				{
					return true;
				}
				return false;
			}
		}

		public static int JobCompletionDate
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["JobCompletionDate"] == null)
				{
					return 7;
				}
				return Convert.ToInt32(EprintConfigurationManager.AppSettings["JobCompletionDate"]);
			}
		}

		public static string JobPrefix
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["JobPrefix"] == null)
				{
					return "JOB-";
				}
				return EprintConfigurationManager.AppSettings["JobPrefix"].ToString();
			}
		}

		public static string KeySeparator
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["KeySeparator"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["KeySeparator"].ToString();
			}
		}

		public static string LargeFormat
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["LargeFormat"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["LargeFormat"].ToString();
			}
		}

		public static string LargeFormatCalculation
		{
			get
			{
				string str = "";
				if (EprintConfigurationManager.AppSettings["LargeFormatCalculation"] != null)
				{
					str = (EprintConfigurationManager.AppSettings["LargeFormatCalculation"] == "" ? "" : EprintConfigurationManager.AppSettings["LargeFormatCalculation"].ToString());
				}
				return str;
			}
		}

		public static string Linear
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["Linear"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["Linear"].ToString();
			}
		}

		public static string mSmtpClientEnableSsl
		{
			get
			{
				string str = "";
				if (EprintConfigurationManager.AppSettings["mSmtpClientEnableSsl"] != null)
				{
					str = (EprintConfigurationManager.AppSettings["mSmtpClientEnableSsl"] != "true" ? "false" : EprintConfigurationManager.AppSettings["mSmtpClientEnableSsl"].ToString());
				}
				return str;
			}
		}

		public static int mSmtpClientPort
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["mSmtpClientPort"] == null)
				{
					return 25;
				}
				return Convert.ToInt32(EprintConfigurationManager.AppSettings["mSmtpClientPort"]);
			}
		}

		public static string MYOB
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["MYOB"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["MYOB"].ToString();
			}
		}

        // far saasu
        public static string SAASU
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["SAASU"] == null)
                {
                    return "";
                }
                return EprintConfigurationManager.AppSettings["SAASU"].ToString();
            }
        }

		public static string MYOBAPI
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["MYOBAPI"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["MYOBAPI"].ToString();
			}
		}

        public static string SAASUAPI
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["SAASUAPI"] == null)
                {
                    return "";
                }
                return EprintConfigurationManager.AppSettings["SAASUAPI"].ToString();
            }
        }

		public static string NavisionExport
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["NavisionExport"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["NavisionExport"].ToString();
			}
		}

		public static string OffsetBooklet
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["OffsetBooklet"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["OffsetBooklet"].ToString();
			}
		}

		public static string OffsetNCR
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["OffsetNCR"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["OffsetNCR"].ToString();
			}
		}

		public static string OffsetPad
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["OffsetPad"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["OffsetPad"].ToString();
			}
		}

		public static string OffsetSingleItem
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["OffsetSingleItem"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["OffsetSingleItem"].ToString();
			}
		}

		public static string OldData
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["OldData"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["OldData"].ToString();
			}
		}

		public static string Ordernumbervalidtiononlyforcoralcoastsystem
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["Ordernumbervalidtiononlyforcoralcoastsystem"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["Ordernumbervalidtiononlyforcoralcoastsystem"].ToString();
			}
		}

		public static string OtherCosts
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["OtherCosts"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["OtherCosts"].ToString();
			}
		}

		public static string Paypalbusiness
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["Paypalbusiness"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["Paypalbusiness"].ToString();
			}
		}

        public static string StripeKey
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["StripeKey"] == null)
                {
                    return null;
                }
                return EprintConfigurationManager.AppSettings["StripeKey"].ToString();
            }
        }

        public static string StripeLogoImage
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["logoimage"] == null)
                {
                    return null;
                }
                return EprintConfigurationManager.AppSettings["logoimage"].ToString();
            }
        }

        public static string StripeMessage
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["message"] == null)
                {
                    return null;
                }
                return EprintConfigurationManager.AppSettings["message"].ToString();
            }
        }

        public static string StripeRedirectURL
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["redirecturl"] == null)
                {
                    return null;
                }
                return EprintConfigurationManager.AppSettings["redirecturl"].ToString();
            }
        }

        public static string StripeLogoURL
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["LogoURL"] == null)
                {
                    return null;
                }
                return EprintConfigurationManager.AppSettings["LogoURL"].ToString();
            }
        }

        public static string PriceCatalogue
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["PriceCatalogue"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["PriceCatalogue"].ToString();
			}
		}
        //Add inventory as a sub item
        public static string Inventory
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["Inventory"] == null)
                {
                    return null;
                }
                return EprintConfigurationManager.AppSettings["Inventory"].ToString();
            }
        }

		public static string PrintBroker
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["PrintBroker"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["PrintBroker"].ToString();
			}
		}

		public static string PrintSystem
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["PrintSystem"] == null)
				{
					return "yes";
				}
				if (EprintConfigurationManager.AppSettings["PrintSystem"] != "no")
				{
					return "yes";
				}
				return EprintConfigurationManager.AppSettings["PrintSystem"].ToString();
			}
		}

		public static bool ProductFileConverter
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["ProductFileConverter"] == null)
				{
					return false;
				}
				if (Convert.ToBoolean(EprintConfigurationManager.AppSettings["ProductFileConverter"]))
				{
					return true;
				}
				return false;
			}
		}

		public static string ProfitTaxKey
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["ProfitTaxKey"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["ProfitTaxKey"].ToString();
			}
		}

		public static string Progresstojobdates
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["Progresstojobdates"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["Progresstojobdates"].ToString();
			}
		}

		public static string ProgresstoJobDatesBlank
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["ProgresstoJobDatesBlank"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["ProgresstoJobDatesBlank"].ToString();
			}
		}

		public static long PurchaseStatusID
		{
			get
			{
				long num = (long)0;
				if (EprintConfigurationManager.AppSettings["PurchaseStatusID"] != null)
				{
					num = (EprintConfigurationManager.AppSettings["PurchaseStatusID"] == "0" ? (long)0 : Convert.ToInt64(EprintConfigurationManager.AppSettings["PurchaseStatusID"].ToString()));
				}
				return num;
			}
		}

		public static string PurhcasePrefix
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["PurchasePrefix"] == null)
				{
					return "PO-";
				}
				return EprintConfigurationManager.AppSettings["PurchasePrefix"].ToString();
			}
		}

		public static string QuickQuote
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["QuickQuote"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["QuickQuote"].ToString();
			}
		}

        public static string DeliveryCost
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["DeliveryCost"] == null)
                {
                    return null;
                }
                return EprintConfigurationManager.AppSettings["DeliveryCost"].ToString();
            }
        }

		public static string eDeliveryCost
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["eDeliveryCost"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["eDeliveryCost"].ToString();
			}
		}

		public static string zip2tax
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["zip2tax"] == null)
                {
                    return null;
                }
                return EprintConfigurationManager.AppSettings["zip2tax"].ToString();
            }
        }

        public static string RadEditorUploadSize
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["RadEditorUploadSize"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["RadEditorUploadSize"].ToString();
			}
		}

		public static string RewriteModule
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["RewriteModule"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["RewriteModule"].ToString();
			}
		}

		public static string SecureDocPath
		{
			get
			{
				string str = "";
				if (EprintConfigurationManager.AppSettings["SecureDocPath"] != null)
				{
					str = (EprintConfigurationManager.AppSettings["SecureDocPath"] == "" ? "" : EprintConfigurationManager.AppSettings["SecureDocPath"].ToString());
				}
				return str;
			}
		}

		public static string SecureVirtualPath
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["SecureVirtualPath"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["SecureVirtualPath"].ToString().Trim();
			}
		}

		public static string ServerName
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["ServerName"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["ServerName"];
			}
		}

		public static string SheetFedDigital
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["SheetFedDigital"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["SheetFedDigital"].ToString();
			}
		}

		public static string SheetFedOffset
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["SheetFedOffset"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["SheetFedOffset"].ToString();
			}
		}

		public static string SquareMeter
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["SquareMeter"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["SquareMeter"].ToString();
			}
		}
		public static string Tilling
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["Tilling"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["Tilling"].ToString();
			}
		}
		public static string Tax2
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["Tax2"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["Tax2"].ToString();
			}
		}

		public static bool UnitOfMeasure
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["UnitOfMeasure"] == null)
				{
					return false;
				}
				if (EprintConfigurationManager.AppSettings["UnitOfMeasure"] != "true")
				{
					return false;
				}
				return Convert.ToBoolean(EprintConfigurationManager.AppSettings["UnitOfMeasure"]);
			}
		}

		public static string VersionNumber
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["VersionNumber"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["VersionNumber"].ToString();
			}
		}

        public static string ShipAPiKey
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["ShipAPiKey"] == null)
                {
                    return "";
                }
                return EprintConfigurationManager.AppSettings["ShipAPiKey"].ToString();
            }
        }

        public static string Warehouse
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["Warehouse"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["Warehouse"].ToString();
			}
		}

		public static string WarehouseDisplay
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["WarehouseDisplay"] == null)
				{
					return null;
				}
				return EprintConfigurationManager.AppSettings["WarehouseDisplay"].ToString();
			}
		}

		public static string WebStore
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["WebStore"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["WebStore"].ToString();
			}
		}

		public static string XeroAccountingCodeMode
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["XeroAccountingCodeMode"] == null)
				{
					return "Default";
				}
				return EprintConfigurationManager.AppSettings["XeroAccountingCodeMode"].ToString();
			}
		}

		public static bool XeroOnlyItemTitle
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["XeroOnlyItemTitle"] == null)
				{
					return false;
				}
				if (EprintConfigurationManager.AppSettings["XeroOnlyItemTitle"] != "true")
				{
					return false;
				}
				return Convert.ToBoolean(EprintConfigurationManager.AppSettings["XeroOnlyItemTitle"]);
			}
		}

        public static string SageOne
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["SageOne"] == null)
                {
                    return "";
                }
                return EprintConfigurationManager.AppSettings["SageOne"].ToString();
            }
        }

        public static string IsCBM
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["IsCBM"] == null)
                {
                    return "";
                }
                return EprintConfigurationManager.AppSettings["IsCBM"].ToString();
            }
        }

        public static string isMatrixCalculation
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["isMatrixCalculation"] == null)
                {
                    return "";
                }
                return EprintConfigurationManager.AppSettings["isMatrixCalculation"].ToString();
            }
        }

        public static string Sage50
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["Sage50"] == null)
                {
                    return "";
                }
                return EprintConfigurationManager.AppSettings["Sage50"].ToString();
            }
        }

        public static string Sage50Business
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["Sage50Business"] == null)
                {
                    return "";
                }
                return EprintConfigurationManager.AppSettings["Sage50Business"].ToString();
            }
        }
		public static string ReckonHosted
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["ReckonHosted"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["ReckonHosted"].ToString();
			}
		}
		public static string Quickbooks_Online
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["Quickbooks_Online"] == null)
                {
                    return "";
                }
                return EprintConfigurationManager.AppSettings["Quickbooks_Online"].ToString();
            }
        }

        public static string isEnableImportOrders
        {
            get
            {
                if (EprintConfigurationManager.AppSettings["isEnableImportOrders"] == null)
                {
                    return "";
                }
                return EprintConfigurationManager.AppSettings["isEnableImportOrders"].ToString();
            }
        }

		public static string IsDecoration
		{
			get
			{
				if (EprintConfigurationManager.AppSettings["IsDecoration"] == null)
				{
					return "";
				}
				return EprintConfigurationManager.AppSettings["IsDecoration"].ToString();
			}
		}

		public ConnectionClass()
		{
		}
	}
}
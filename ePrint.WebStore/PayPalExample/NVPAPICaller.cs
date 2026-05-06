using nmsCommon;
using nmsConnection;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Net;
using System.Web;

namespace PayPalExample
{
	public class NVPAPICaller
	{
		private const string CVV2 = "CVV2";

		private const string SIGNATURE = "SIGNATURE";

		private const string PWD = "PWD";

		private const string ACCT = "ACCT";

		private const int Timeout = 10000;

		private string pendpointurl = "https://api-3t.paypal.com/nvp";

		private string host = "www.paypal.com";

		private string returnURL = string.Concat("http://", HttpContext.Current.Request.Url.Authority, "/Sucess.aspx");

		private string cancelURL = string.Concat("http://", HttpContext.Current.Request.Url.Authority, "/cancel.aspx");

		private bool bSandbox;

		public string APIUsername = ConnectionClass.PayPal_Live_APIUsername;

		private string APIPassword = ConnectionClass.PayPal_Live_APIPassword;

		private string APISignature = ConnectionClass.PayPal_Live_APISignature;

		private string Subject = "";

		private string BNCode = "PP-ECWizard";

		private readonly static string[] SECURED_NVPS;

		static NVPAPICaller()
		{
			string[] strArrays = new string[] { "ACCT", "CVV2", "SIGNATURE", "PWD" };
			NVPAPICaller.SECURED_NVPS = strArrays;
		}

		public NVPAPICaller()
		{
		}

		private string buildCredentialsNVPString()
		{
			NVPCodec nVPCodec = new NVPCodec();
			if (!NVPAPICaller.IsEmpty(this.APIUsername))
			{
				nVPCodec["USER"] = this.APIUsername;
			}
			if (!NVPAPICaller.IsEmpty(this.APIPassword))
			{
				nVPCodec["PWD"] = this.APIPassword;
			}
			if (!NVPAPICaller.IsEmpty(this.APISignature))
			{
				nVPCodec["SIGNATURE"] = this.APISignature;
			}
			if (!NVPAPICaller.IsEmpty(this.Subject))
			{
				nVPCodec["SUBJECT"] = this.Subject;
			}
			nVPCodec["VERSION"] = "84.0";
			return nVPCodec.Encode();
		}

		public bool ConfirmPayment(string finalPaymentAmount, string token, string PayerId, string currency, ref NVPCodec decoder, ref string retMsg)
		{
			this.ReassignDetails();
			if (this.bSandbox)
			{
				this.pendpointurl = "https://api-3t.sandbox.paypal.com/nvp";
			}
			NVPCodec nVPCodec = new NVPCodec();
			nVPCodec["METHOD"] = "DoExpressCheckoutPayment";
			nVPCodec["TOKEN"] = token;
			nVPCodec["PAYMENTACTION"] = "Sale";
			nVPCodec["PAYERID"] = PayerId;
			nVPCodec["AMT"] = finalPaymentAmount;
			nVPCodec["CURRENCYCODE"] = currency;
			string str = this.HttpCall(nVPCodec.Encode());
			decoder = new NVPCodec();
			decoder.Decode(str);
			string lower = decoder["ACK"].ToLower();
			if (lower != null && (lower == "success" || lower == "successwithwarning"))
			{
				return true;
			}
			string[] item = new string[] { "ErrorCode=", decoder["L_ERRORCODE0"], "&Desc=", decoder["L_SHORTMESSAGE0"], "&Desc2=", decoder["L_LONGMESSAGE0"] };
			retMsg = string.Concat(item);
			return false;
		}

		public bool ExpressCheckout(int CompanyID, string returnURL, string CancelURL, DataTable dtCart, DataTable dtAddress, ref string token, ref string retMsg)
		{
			commonclass _commonclass = new commonclass();
			BaseClass baseClass = new BaseClass();
			this.ReassignDetails();
			if (this.bSandbox)
			{
				this.pendpointurl = "https://api-3t.sandbox.paypal.com/nvp";
			}
			NVPCodec nVPCodec = new NVPCodec();
			nVPCodec["METHOD"] = "SetExpressCheckout";
			nVPCodec["RETURNURL"] = returnURL;
			nVPCodec["CANCELURL"] = CancelURL;
			nVPCodec["SOLUTIONTYPE"] = "Sole";
			nVPCodec["LANDINGPAGE"] = "Billing";
			foreach (DataRow row in dtAddress.Rows)
			{
				nVPCodec["PAYMENTREQUEST_0_NAME"] = baseClass.SpecialDecode(string.Concat(row["firstname"].ToString(), " ", row["lastname"].ToString()));
				nVPCodec["PAYMENTREQUEST_0_SHIPTOSTREET"] = baseClass.SpecialDecode(row["address1"].ToString());
				nVPCodec["PAYMENTREQUEST_0_SHIPTOCITY"] = baseClass.SpecialDecode(row["address2"].ToString());
				nVPCodec["PAYMENTREQUEST_0_SHIPTOSTATE"] = baseClass.SpecialDecode(row["address3"].ToString());
				nVPCodec["PAYMENTREQUEST_0_SHIPTOZIP"] = baseClass.SpecialDecode(row["address4"].ToString());
				nVPCodec["PAYMENTREQUEST_0_SHIPTOCOUNTRY"] = "AU";
				nVPCodec["PAYMENTREQUEST_0_PHONENUM"] = row["Phone"].ToString();
			}
			int num = 1;
			int num1 = 0;
			decimal num2 = new decimal(0);
			decimal num3 = new decimal(0);
			decimal num4 = new decimal(0);
			decimal num5 = new decimal(0);
			decimal num6 = new decimal(0);
			foreach (DataRow dataRow in dtCart.Rows)
			{
				if (num == 1)
				{
					nVPCodec["PAYMENTREQUEST_0_CURRENCYCODE"] = dataRow["currency"].ToString();
					num3 = Convert.ToDecimal(dataRow["TotalCartAdditionalPrice"]);
					num6 = num6 + num3;
				}
				nVPCodec[string.Concat("L_PAYMENTREQUEST_0_NAME", num1)] = baseClass.SpecialDecode(dataRow["CatalogueName"].ToString());
				nVPCodec[string.Concat("L_PAYMENTREQUEST_0_AMT", num1)] = _commonclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(Convert.ToDecimal(dataRow["CartTotalPrice"])), 2, "", false, false, true);
				nVPCodec[string.Concat("L_PAYMENTREQUEST_0_QTY", num1)] = "1";
				nVPCodec["PAYMENTREQUEST_0_PAYMENTACTION"] = "SALE";
				num2 = num2 + Convert.ToDecimal(dataRow["CartTotalPrice"]);
				num4 = Convert.ToDecimal(_commonclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow["Tax"]), 2, "", false, false, false));
				num6 = num6 + Convert.ToDecimal(_commonclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(dataRow["CartTotalPrice"]), 2, "", false, false, false));
				num++;
				num1++;
			}
			nVPCodec["PAYMENTREQUEST_0_SHIPPINGAMT"] = "0.00";
			nVPCodec["PAYMENTREQUEST_0_INSURANCEAMT"] = "0.00";
			num4 = (num4 * num6) / new decimal(100);
			num4 = Convert.ToDecimal(_commonclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(num4), 2, "", false, false, false));
			num2 = Convert.ToDecimal(_commonclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(num2), 2, "", false, false, false));
			num5 = (num3 + num2) + num4;
			nVPCodec["PAYMENTREQUEST_0_AMT"] = _commonclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(num5), 2, "", false, false, true);
			nVPCodec["PAYMENTREQUEST_0_ITEMAMT"] = _commonclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(num2), 2, "", false, false, true);
			nVPCodec["PAYMENTREQUEST_0_TAXAMT"] = _commonclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(num4), 2, "", false, false, true);
			nVPCodec["PAYMENTREQUEST_0_HANDLINGAMT"] = _commonclass.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(num3), 2, "", false, false, true);
			string str = this.HttpCall(nVPCodec.Encode());
			NVPCodec nVPCodec1 = new NVPCodec();
			nVPCodec1.Decode(str);
			string lower = nVPCodec1["ACK"].ToLower();
			if (lower != null && (lower == "success" || lower == "successwithwarning"))
			{
				token = nVPCodec1["TOKEN"];
				string[] strArrays = new string[] { "https://", this.host, "/cgi-bin/webscr?cmd=_express-checkout&token=", token, "&useraction=COMMIT" };
				retMsg = string.Concat(strArrays);
				return true;
			}
			string[] item = new string[] { "ErrorCode=", nVPCodec1["L_ERRORCODE0"], "¶Desc=", nVPCodec1["L_SHORTMESSAGE0"], "¶Desc2=", nVPCodec1["L_LONGMESSAGE0"] };
			retMsg = string.Concat(item);
			return false;
		}

		public bool GetDetails(string token, ref NVPCodec decoder, ref string retMsg)
		{
			this.ReassignDetails();
			if (this.bSandbox)
			{
				this.pendpointurl = "https://api-3t.sandbox.paypal.com/nvp";
			}
			NVPCodec nVPCodec = new NVPCodec();
			nVPCodec["METHOD"] = "GetExpressCheckoutDetails";
			nVPCodec["TOKEN"] = token;
			string str = this.HttpCall(nVPCodec.Encode());
			decoder = new NVPCodec();
			decoder.Decode(str);
			string lower = decoder["ACK"].ToLower();
			if (lower != null && (lower == "success" || lower == "successwithwarning"))
			{
				return true;
			}
			string[] item = new string[] { "ErrorCode=", decoder["L_ERRORCODE0"], "&Desc=", decoder["L_SHORTMESSAGE0"], "&Desc2=", decoder["L_LONGMESSAGE0"] };
			retMsg = string.Concat(item);
			return false;
		}

		public string HttpCall(string NvpRequest)
		{
			string end;
			string str = this.pendpointurl;
			string str1 = string.Concat(NvpRequest, "&", this.buildCredentialsNVPString());
			str1 = string.Concat(str1, "&BUTTONSOURCE=", HttpUtility.UrlEncode(this.BNCode));
			HttpWebRequest length = (HttpWebRequest)WebRequest.Create(str);
			length.Timeout = 10000;
			length.Method = "POST";
			length.ContentLength = (long)str1.Length;
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(length.GetRequestStream()))
				{
					streamWriter.Write(str1);
				}
			}
			catch (Exception exception)
			{
			}
			using (StreamReader streamReader = new StreamReader(((HttpWebResponse)length.GetResponse()).GetResponseStream()))
			{
				end = streamReader.ReadToEnd();
			}
			return end;
		}

		public static bool IsEmpty(string s)
		{
			if (s == null)
			{
				return true;
			}
			return s.Trim() == string.Empty;
		}

		public void ReassignDetails()
		{
			string empty = string.Empty;
			string str = string.Empty;
			string empty1 = string.Empty;
			if (ConnectionClass.PaypalTestUrl != null)
			{
				string paypalTestUrl = ConnectionClass.PaypalTestUrl;
			}
			if (ConnectionClass.PaypalLiveUrl != null)
			{
				string paypalLiveUrl = ConnectionClass.PaypalLiveUrl;
			}
			if (ConnectionClass.PaypalLiveMode != null)
			{
				empty = ConnectionClass.PaypalLiveMode;
			}
			if (empty.ToLower() == "yes")
			{
				this.host = "www.paypal.com";
				this.APIUsername = ConnectionClass.PayPal_Live_APIUsername;
				this.APIPassword = ConnectionClass.PayPal_Live_APIPassword;
				this.APISignature = ConnectionClass.PayPal_Live_APISignature;
				this.bSandbox = false;
				return;
			}
			this.host = "www.sandbox.paypal.com";
			this.APIUsername = ConnectionClass.PayPal_SandBox_APIUsername;
			this.APIPassword = ConnectionClass.PayPal_SandBox_APIPassword;
			this.APISignature = ConnectionClass.PayPal_SandBox_APISignature;
			this.bSandbox = true;
		}

		public void SetCredentials(string Userid, string Pwd, string Signature)
		{
			this.APIUsername = Userid;
			this.APIPassword = Pwd;
			this.APISignature = Signature;
		}
	}
}
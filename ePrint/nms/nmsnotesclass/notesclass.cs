using nmsCommon;
using System;

namespace nmsnotesclass
{
	public class notesclass
	{
		public int CompanyID;

		public string CustomerName = string.Empty;

		public string NotesType = string.Empty;

		public string Old_Status_name = string.Empty;

		public string email_address = string.Empty;

		public string Item_number = string.Empty;

		public string Item_title = string.Empty;

		public string attachments = string.Empty;

		public string Status_name = string.Empty;

		public string Template_name = string.Empty;

		public string Customer_Name = string.Empty;

		public string Created_Date = string.Empty;

		public string TempAttachment = string.Empty;

		public string Created_dateTime = DateTime.Now.ToString();

		public string Old_Item_title = string.Empty;

		public string Old_Subtotal = string.Empty;

		public string Old_SubtotalID = string.Empty;

		public string New_Subtotal = string.Empty;

		public string Del_ItemTitle = string.Empty;

		public string Old_TaxRate = string.Empty;

		public string Old_ProfitMargin = string.Empty;

		public string New_TaxRate = string.Empty;

		public string New_ProfitMargin = string.Empty;

		public string New_Item_title = string.Empty;

		public string CarrierName = string.Empty;

		public string Estimate_type = string.Empty;

		public string Estimate_number = string.Empty;

		public string new_Estimate_number = string.Empty;

		public string Po_Attachment = string.Empty;

		public string Delivery_Attachment = string.Empty;

		public string Job_type = string.Empty;

		public string Job_number = string.Empty;

		public string new_Job_number = string.Empty;

		public string PO_Numbers = string.Empty;

		public string Invoice_type = string.Empty;

		public string Invoice_number = string.Empty;

		public string new_Invoice_number = string.Empty;

		public string Amount_Paid = string.Empty;

		public string Payment_Type = string.Empty;

		public string Previous_Amount = string.Empty;

		public string Delivery_number = string.Empty;

		public string Po_number = string.Empty;

		public string new_PO_number = string.Empty;

		public string Product_title = string.Empty;

		public string Product_code = string.Empty;

		public string NoteType = "S";

		public string ModuleName = string.Empty;

		public string NewItem_number = string.Empty;

		public string strImagepath = global.imagePath();

		public int UserID;

		public long ModuleID;

		public long ItemID;

		public notesclass()
		{
		}
	}
}
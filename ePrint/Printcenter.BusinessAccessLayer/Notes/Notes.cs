using nmsCommon;
using nmsnotesclass;
using Printcenter.DataAccessLayer.DbNotes;
using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;

namespace Printcenter.BusinessAccessLayer.Notes
{
	public class Notes
	{
		private commonClass commclass = new commonClass();

		public Notes()
		{
		}

		public static void insert_Activity_History(int CompanyID, string NoteType, string ModuleName, long ModuleID, string Description, DateTime CreateDate, int CreateUserId, long ItemID)
		{
			DbNotes dbNote = new DbNotes();
			dbNote.insert_Activity_History(CompanyID, NoteType, ModuleName, ModuleID, Description, CreateDate, CreateUserId, ItemID);
		}

		public void NotesAdd(notesclass obj)
		{
			Hashtable hashtables = new Hashtable();
			string currencyinRequiredFormate = this.commclass.GetCurrencyinRequiredFormate("", true);
			hashtables["EstCreate"] = "Estimate <Estimate_type> created, <Estimate_number>";
			hashtables["EstInfoRerun"] = "Estimate Info re-run";
			hashtables["EstItemRerun"] = "Estimate Item <Item_number> re-run";
			hashtables["EstAdd_attachment"] = "Estimate attachments <attachments> added";
			hashtables["EstNewItemAdd"] = " <Estimate_type> <Item_number>, <Item_title> added";
			hashtables["EstChangeStatus"] = "Status updated for Estimate <Estimate_number> to <Status_name>";
			hashtables["EstItemTitleEdit"] = "Estimate Item title updated for <Item_number>, from <Old_Item_title> to <Item_title_new>";
			hashtables["EstItemDescPhrase"] = "Item description edited, saved to phrasebook of <Item_title>, <Item_number>";
			hashtables["EstItemDesc"] = "Item description edited and saved <Item_title>, <Item_number>";
			hashtables["EstCopied"] = "Estimate copied to <new_Estimate_number>";
			hashtables["EstNewCopied"] = "Estimate copied from <Estimate_number>";
			string[] strArrays = new string[] { "Estimate subtotal updated for <Item_number>, from ", currencyinRequiredFormate, " <Subtotal_old> to ", currencyinRequiredFormate, " <Subtotal_new>" };
			hashtables["EstSubTotal"] = string.Concat(strArrays);
			string[] strArrays1 = new string[] { "Estimate subtotal updated for <Item_number>, from ", currencyinRequiredFormate, " <Subtotal_old> to ", currencyinRequiredFormate, " <Subtotal_new>" };
			hashtables["EstSubTotalForOthers"] = string.Concat(strArrays1);
			hashtables["EstProMargin"] = "Estimate profit margin(%) updated for <Item_number>, from <ProfitMargin_old>% to  <ProfitMargin_new>%";
			string[] strArrays2 = new string[] { "Estimate Tax Rate updated for <Item_number>, from ", currencyinRequiredFormate, "<TaxRate_old> to ", currencyinRequiredFormate, "<TaxRate_new>" };
			hashtables["EstTax"] = string.Concat(strArrays2);
			hashtables["EstTemplateView"] = "Estimate viewed in the Template <Template_name>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
			string[] strArrays3 = new string[] { "Estimate profit margin(", currencyinRequiredFormate, ") updated for <Item_number>, from ", currencyinRequiredFormate, "<ProfitMargin_old> to ", currencyinRequiredFormate, "<ProfitMargin_new> and saved" };
			hashtables["EstProMarginPrice"] = string.Concat(strArrays3);
			hashtables["EstTempViewEdit"] = "Estimate viewed in the Template <Template_name> and info edited & saved.";
			hashtables["EstTempViewEditSent"] = "Estimate viewed in the Template <Template_name>, info edited and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
			hashtables["EstTemplateSent"] = "Estimate viewed in the Template <Template_name>, and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
            hashtables["EstTemplateSentWithStatusChange"] = "Estimate viewed in the Template <Template_name>, and Status Updated to <Estimate_status_change> and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";

            
            hashtables["EstProgWithPOandDel"] = "Estimate progressed to Job # <Job_number>.<br /> PO # - <Po_Attachment>.<br />Delivery Note # <a href='<Delivery_Attachment>' target='_blank'><Delivery_number></a>";
			hashtables["EstProgWithPO"] = "Estimate progressed to Job # <Job_number>.<br /> PO # <Po_Attachment>.<br />No Delivery Note raised";
			hashtables["EstProgWithDel"] = "Estimate progressed to Job # <Job_number>.<br /> No PO raised .<br />Delivery Note # <a href='<Delivery_Attachment>' target='_blank'><Delivery_number></a>";
			hashtables["EstProgWithOutPOandDel"] = "Estimate progressed to Job # <Job_number>.<br /> No PO raised.<br />No Delivery Note raised";
			hashtables["EstItemDeleted"] = "Estimate <Item_number>, <Item_title> deleted";
			hashtables["EstItemProgtoJob"] = "Estimate Item <Item_number> progressed to Job # <Job_number>";
			hashtables["EstArchivedandProgtoJob"] = "Estimate <Estimate_number> has been Archived ";
			hashtables["EstitemProcreated"] = "Product Catalogue <Product_title> <Product_code> has been created for Estimate Item <Item_number>, <Item_title>";
			hashtables["EstitemProUpdated"] = "Product Catalogue <Product_title> <Product_code> has been updated for Estimate Item <Item_number>, <Item_title>";
			hashtables["EstItemArchived"] = "Estimate Item <Item_number> has been Archived ";
			hashtables["EstUnArchived"] = "Estimate <Estimate_number> has been UnArchived ";
			hashtables["EstItemUnArchived"] = "Estimate Item <Item_number> has been UnArchived ";
			hashtables["ArtworkAttchmentAdded"] = "Artwork attachments <attachments> added for Item <Item_number>, <Item_title>";
			hashtables["ArtworkAttchmentUpdated"] = "Artwork attachments <attachments> updated for Item <Item_number>, <Item_title>";
			hashtables["SupplierRFQTempSend"] = "Supplier RFQ Template <Template_name> viewed and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
			hashtables["OrdJobProgInv"] = "Job progressed to Invoice # <Invoice_number>";
			hashtables["OrdItemRerun"] = "Order Item <Item_number>, <Item_title> re-run";
			hashtables["OrderAdd_attachment"] = "Order attachments <attachments> added";
			hashtables["OrdChangeStatus"] = "Status updated for eStore Order <Invoice_number> to <Status_name> and saved";
			hashtables["OrderTempSend"] = "Order viewed in the Template  <Template_name> and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
            hashtables["OrderTempSendWithStatusChange"] = "Order viewed in the Template  <Template_name>  and Status Updated to <Order_status_change> and  emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";

            hashtables["OrderTemplateView"] = "Order viewed in the Template <Template_name>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
			hashtables["OrdTempViewEdit"] = "Order viewed in the Template <Template_name> and info edited & saved.";
			hashtables["OrdProgWithPOandDel"] = "Order progressed to Job # <Job_number>.<br /> PO # - <Po_Attachment>.<br />Delivery Note # <a href='<Delivery_Attachment>' target='_blank'><Delivery_number></a>";
			hashtables["OrdProgWithPO"] = "Order progressed to Job # <Job_number>.<br /> PO # <Po_Attachment>.<br />No Delivery Note raised";
			hashtables["OrdProgWithDel"] = "Order progressed to Job # <Job_number>.<br /> No PO raised .<br />Delivery Note # <a href='<Delivery_Attachment>' target='_blank'><Delivery_number></a>";
			hashtables["OrdProgWithOutPOandDel"] = "Order progressed to Job # <Job_number>.<br /> No PO raised.<br />No Delivery Note raised";
			hashtables["OrdItemDeleted"] = "Order <Item_number>, <Item_title> deleted";
			hashtables["OrderItemTitleEdit"] = "Order Item title updated for <Item_number>, from <Old_Item_title> to <Item_title_new>";
			string[] strArrays4 = new string[] { "Order Tax Rate updated for <Item_number>, from ", currencyinRequiredFormate, "<TaxRate_old> to ", currencyinRequiredFormate, "<TaxRate_new>" };
			hashtables["OrderTax"] = string.Concat(strArrays4);
			string[] strArrays5 = new string[] { "Order subtotal updated for <Item_number>, from ", currencyinRequiredFormate, " <Subtotal_old> to ", currencyinRequiredFormate, " <Subtotal_new>" };
			hashtables["OrderSubTotalForOthers"] = string.Concat(strArrays5);
			string[] strArrays6 = new string[] { "Order subtotal updated for <Item_number>, from ", currencyinRequiredFormate, " <Subtotal_old> to ", currencyinRequiredFormate, " <Subtotal_new>" };
			hashtables["OrderSubTotal"] = string.Concat(strArrays6);
			hashtables["OrderProMargin"] = "Order profit margin(%) updated for <Item_number>, from <ProfitMargin_old>% to  <ProfitMargin_new>%";
			string[] strArrays7 = new string[] { "Order profit margin(", currencyinRequiredFormate, ") updated for <Item_number>, from ", currencyinRequiredFormate, "<ProfitMargin_old> to ", currencyinRequiredFormate, "<ProfitMargin_new>" };
			hashtables["OrderProMarginPrice"] = string.Concat(strArrays7);
			hashtables["OrderItemDeleted"] = "Order <Item_number>, <Item_title> deleted";
			hashtables["OrderItemProgtoJob"] = "Order Item <Item_number> progressed to Job # <Job_number>";
			hashtables["OrdArchivedandProgtoJob"] = "Order <Estimate_number> has been Archived ";
			hashtables["OrdItemArchived"] = "Order Item <Item_number> has been Archived ";
			hashtables["OrdUnArchived"] = "Order <Estimate_number> has been UnArchived ";
			hashtables["OrdItemUnArchived"] = "Order Item <Item_number> has been UnArchived ";
			hashtables["JobCreate"] = "Job created from Estimate # <Estimate_number>";
			hashtables["JobDirCreate"] = "Job <Job_type> created, <Job_number>";
			hashtables["JobInfoRerun"] = "Job Info re-run";
			hashtables["JobItemRerun"] = "Job Item <Item_number> re-run";
			hashtables["JobRevertWithPOandDel"] = "Job reverted to Estimate with deletion of PO(s)<PO_Numbers> & Delivery Note(s) <Delivery_number>";
			hashtables["JobRevertWithPO"] = "Job reverted to Estimate with deletion of PO(s)<PO_Numbers> & no Delivery Note(s)";
			hashtables["JobRevertWithDel"] = "Job reverted to Estimate with deletion of Delivery Note(s) <Delivery_number> but without deleting the PO";
			hashtables["JobRevertWithOutPOandDel"] = "Job reverted to Estimate with no deletion of PO(s) & Delivery Note(s)";
			hashtables["JobRevertWithOutPOandDelFromorder"] = "Job reverted to Order with no deletion of PO(s) & Delivery Note(s)";
			hashtables["JobRevertWithPOFromorder"] = "Job reverted to Order with deletion of PO(s)<PO_Numbers> & no Delivery Note(s)";
			hashtables["JobRevertWithDelFromorder"] = "Job reverted to Order with deletion of Delivery Note(s) <Delivery_number> but without deleting the PO";
			hashtables["JobRevertWithPOandDelFromorder"] = "Job reverted to Order with deletion of PO(s)<PO_Numbers> & Delivery Note(s) <Delivery_number>";
			hashtables["JobAdd_attachment"] = "Job attachments <attachments> added";
			hashtables["JobNewItemAdd"] = "New <Job_type> <Item_number>, <Item_title> added";
			hashtables["JobChangeStatus"] = "Status updated for job <Job_number> to <Status_name>";
			hashtables["JobItemTitleEdit"] = "Job Item title updated for <Item_number>, from <Old_Item_title> to <Item_title_new>";
			hashtables["JobTemplateView"] = "Job viewed in the Template <Template_name>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
			hashtables["JobTempViewEdit"] = "Job viewed in the Template <Template_name>, info edited & saved.";
			hashtables["JobTempViewEditSent"] = "Job viewed in the Template <Template_name>, info edited and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
			hashtables["JobTemplateSent"] = "job viewed in the Template <Template_name>, and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
            hashtables["JobTemplateSentWithStatusChange"] = "job viewed in the Template <Template_name>, and Status Updated to <Job_status_change> and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";

            hashtables["JobPOCreate"] = "PO(s) <PO_Numbers> created from Quick Links for <Item_number>";
			hashtables["JobPOViewd"] = "Job PO viewed for <Job_number>, <Po_number>";
			hashtables["JobPOEdited"] = "Job PO viewed for <Job_number>, <Po_number>, and edited";
			hashtables["JobPODelete"] = "Job PO Viewed  for <Job_number>, <Po_number> and deleted";
			hashtables["JobPOViedInTemp"] = "Job PO viewed in the Template for <Job_number>, <Po_number>, <Template_name>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
			hashtables["JobPOViedInTempEdit"] = "Job PO Viewed in the Template for <Job_number>, <Template_name>,info edited and saved.";
			hashtables["JobPOViedInTempEditSend"] = "Job PO Viewed in the Template for <Job_number>, <Template_name>, info edited and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
			hashtables["JobPOViedInTempSend"] = "Job PO viewed in the Template for <Template_name> and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
			hashtables["JobDelCreate"] = "Delivery Note <Delivery_number> created from Quick Links <Item_number>";
			hashtables["JobProgInvPayment"] = "Job <Job_number> progressed to Invoice # <Invoice_number> with Payment";
			hashtables["JobProgInv"] = "Job <Job_number> progressed to Invoice # <Invoice_number> without Payment";
			hashtables["JobProgInvDetail"] = "Job progressed to Invoice <Invoice_number>";
			hashtables["JobCardEdit"] = "Job card updated for <Item_number>, <Item_title>";
			hashtables["JobCardEditSend"] = "Job card viewed, edited, saved and email sent to recipient <email_address>";
			hashtables["JobCopied"] = "Job copied to <new_Job_number>";
			hashtables["JobNewCopied"] = "Job copied from <Job_number>";
			string[] strArrays8 = new string[] { "Job subtotal updated for <Item_number>, from ", currencyinRequiredFormate, " <Subtotal_old> to ", currencyinRequiredFormate, " <Subtotal_new> for Quantity<Subtotal_ID>" };
			hashtables["JobSubTotal"] = string.Concat(strArrays8);
			string[] strArrays9 = new string[] { "Job subtotal updated for <Item_number>, from ", currencyinRequiredFormate, " <Subtotal_old> to ", currencyinRequiredFormate, " <Subtotal_new>" };
			hashtables["JobSubTotalForOthers"] = string.Concat(strArrays9);
			hashtables["JobProMargin"] = "Job profit margin updated for <Item_number>, from <ProfitMargin_old>% to <ProfitMargin_new>%";
			string[] strArrays10 = new string[] { "Job taxrate updated for <Item_number>, from ", currencyinRequiredFormate, "<TaxRate_old> to ", currencyinRequiredFormate, "<TaxRate_new>" };
			hashtables["JobTax"] = string.Concat(strArrays10);
			hashtables["JobItemDeleted"] = "Job <Item_number>, <Item_title> deleted";
			string[] strArrays11 = new string[] { "Job profit margin(", currencyinRequiredFormate, ") updated for <Item_number>, from ", currencyinRequiredFormate, "<ProfitMargin_old> to ", currencyinRequiredFormate, "<ProfitMargin_new>" };
			hashtables["JobProMarginPrice"] = string.Concat(strArrays11);
			hashtables["JobItemProgInv"] = "Job Item <Job_number> progressed to Invoice # <Invoice_number>";
			hashtables["JobArchivedandProgtoInv"] = "Job <Job_number> has been Archived ";
			hashtables["JobitemProcreated"] = "Product Catalogue <Product_title> <Product_code> has been created for Job Item <Item_number>, <Item_title>";
			hashtables["JobitemProUpdated"] = "Product Catalogue <Product_title> <Product_code> has been Updated for Job Item <Item_number>, <Item_title>";
			hashtables["JobItemRevertedFromEstimate"] = "Job item <Item_number> reverted to Estimate";
			hashtables["JobItemRevertedFromOrder"] = "Job item <Item_number> reverted to Order";
			hashtables["JobItemArchived"] = "Job Item <Item_number> has been Archived ";
			hashtables["JobUnArchived"] = "Job <Job_number> has been UnArchived ";
			hashtables["JobItemUnArchived"] = "Job Item <Item_number> has been UnArchived ";
			hashtables["InvDirCreate"] = "Invoice <Invoice_type>, <Invoice_number> created";
			hashtables["InvCreate"] = "Invoice created from Job # <Job_number>";
			hashtables["MultipleInvCreate"] = "Invoice created from multiple Jobs";
			hashtables["InvInfoRerun"] = "Invoice Info re-run";
			hashtables["InvItemRerun"] = "Invoice Item <Item_number> re-run";
			hashtables["InvAdd_attachment"] = "Invoice attachments <attachments> added";
			hashtables["InvNewItemAdd"] = "A New <Invoice_type>, <Item_number>, <Item_title> added";
			hashtables["InvChangeStatus"] = "Status updated for Invoice <Invoice_number> to <Status_name>";
			hashtables["InvItemTitleEdit"] = "Invoice Item title updated for <Item_number>, from <Old_Item_title> to <Item_title_new> and saved";
			hashtables["InvTemplateView"] = "Invoice viewed in the Template <Template_name>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
			hashtables["InvTempViewEdit"] = "Invoice viewed in the Template <Template_name>, info edited.";
			hashtables["InvTempViewEditSent"] = "Invoice viewed in the Template <Template_name>, info edited and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
			hashtables["InvTemplateSent"] = "Invoice viewed in the Template <Template_name> emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
            hashtables["InvTemplateSentWithStatusChange"] = "Invoice viewed in the Template <Template_name> and Status Updated to <Inv_status_change>  and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";


            hashtables["InvCopied"] = "Invoice copied to <New_Invoice_number>";
			hashtables["InvNewCopied"] = "Invoice copied from <Invoice_number>";
			string[] strArrays12 = new string[] { "Invoice subtotal updated for <Item_number>, from ", currencyinRequiredFormate, " <Subtotal_old> to ", currencyinRequiredFormate, " <Subtotal_new> for Quantity<Subtotal_ID>" };
			hashtables["InvSubTotal"] = string.Concat(strArrays12);
			string[] strArrays13 = new string[] { "Job subtotal updated for <Item_number>, from ", currencyinRequiredFormate, " <Subtotal_old> to ", currencyinRequiredFormate, " <Subtotal_new>" };
			hashtables["InvSubTotalForOthers"] = string.Concat(strArrays13);
			hashtables["InvProMargin"] = "Invoice profit margin updated for <Item_number>, from <ProfitMargin_old>% to  <ProfitMargin_new>%";
			string[] strArrays14 = new string[] { "Invoice taxrate updated for <Item_number>, from ", currencyinRequiredFormate, "<TaxRate_old> to ", currencyinRequiredFormate, "<TaxRate_new>" };
			hashtables["InvTax"] = string.Concat(strArrays14);
			hashtables["InvPayment"] = "Invoice Paid";
			hashtables["InvNotPayment"] = "Payment Status changed from Yes to No";
			hashtables["InvfullPayment"] = "Job progressed to Invoice, # <Invoice_number> with full Payment";
			hashtables["InvfullPaid"] = string.Concat("Invoice full payment made for the amount ", currencyinRequiredFormate, "<Amount_Paid>");
			hashtables["InvPartPaid"] = string.Concat("Part Payment made for the amount ", currencyinRequiredFormate, "<Amount_Paid>");
			hashtables["InvfullPaidMain"] = string.Concat("Invoice full payment made for the amount ", currencyinRequiredFormate, "<Amount_Paid> via main view");
			hashtables["InvPaymentDelete"] = "Payment Deleted";
			string[] strArrays15 = new string[] { "Payment edited from ", currencyinRequiredFormate, "<Previous_Amount> to ", currencyinRequiredFormate, "<Amount_Paid>" };
			hashtables["InvPaymentUpdate"] = string.Concat(strArrays15);
			hashtables["InvItemDeleted"] = "Invoice <Item_number>, <Item_title> deleted";
			string[] strArrays16 = new string[] { "Invoice profit margin(", currencyinRequiredFormate, ") updated for <Item_number>, from ", currencyinRequiredFormate, "<ProfitMargin_old> to ", currencyinRequiredFormate, "<ProfitMargin_new>" };
			hashtables["InvProMarginPrice"] = string.Concat(strArrays16);
			hashtables["InvCreatedWithPayment"] = "Invoice <Invoice_number> created from Job # <Job_number> with Payment";
			hashtables["InvCreatedWithoutPayment"] = "Invoice <Invoice_number> created from Job # <Job_number> without Payment";
			hashtables["InvitemProcreated"] = "Product Catalogue <Product_title> <Product_code> has been created for Invoice Item <Item_number>, <Item_title>";
			hashtables["InvitemProUpdated"] = "Product Catalogue <Product_title> <Product_code> has been updated for Invoice Item <Item_number>, <Item_title>";
			hashtables["InvArchived"] = "Invoice <Invoice_number> has been Archived ";
            hashtables["InvExported"] = "Invoice <Invoice_number> has been Exported ";
            hashtables["InvUnexported"] = "Invoice <Invoice_number> has been Unexported ";
            hashtables["InvItemArchived"] = "Invoice Item <Item_number> has been Archived ";
			hashtables["InvUnArchived"] = "Invoice <Invoice_number> has been UnArchived ";
			hashtables["InvItemUnArchived"] = "Invoice Item <Item_number> has been UnArchived ";
			hashtables["POCreated"] = "Purchase <Po_number> created";
			hashtables["POUpdate"] = "PO <Po_number> updated";
			hashtables["POChangeStatus"] = "Status updated for PO <Po_number> to <Status_name>";
			hashtables["POViewTemp"] = "PO Viewed in the Template <Template_name>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
			hashtables["POTempEdit"] = "PO Viewed in the Template <Template_name>, info edited.";
			hashtables["POAdd_attachment"] = "PO attachments <attachments> added";
			hashtables["POTempEditSend"] = "PO Viewed in the Template <Template_name>, info edited and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
			hashtables["POTempSend"] = "PO viewed in the Template <Template_name> and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
            hashtables["POTempSendWithStatusChange"] = "PO viewed in the Template <Template_name> and Status Updated to <PO_status_change>  and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";


            hashtables["POCreatedFromJob"] = "PO <Po_number> created from <Job_number>";
			hashtables["POCopied"] = "PO copied to <new_PO_number>";
			hashtables["PONewCopied"] = "PO copied from <Po_number>";
			hashtables["POItemInserted"] = "Purchase Item <Item_title> has been Inserted";
			hashtables["DelCreated"] = "Delivery Note <Delivery_number> created";
			hashtables["DelUpdate"] = "Delivery Note <Delivery_number> updated";
			hashtables["DelChangeStatus"] = "Status updated to <Status_name>";
			hashtables["DeliveryDelUpdate"] = "Deliery Note item <Del_ItemTitle> deleted";
			hashtables["DeliveryGoodsDelivered"] = "Delivery Note saved with Goods Delivered option ticked";
			hashtables["DelViewTemp"] = "Delivery Note Viewed  in the Template  <Template_name>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
			hashtables["DelTempEdit"] = "Delivery Note viewed in the Template <Template_name>, info edited.";
			hashtables["DelAdd_attachment"] = "Delivery Note attachments <attachments> added";
			hashtables["DelTempEditSend"] = "Delivery Note Viewed  in the Template  <Template_name>, info edited and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
			hashtables["DelTempSend"] = "Delivery Note  viewed in the Template  <Template_name> and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";
            hashtables["DelTempSendWithStatusChange"] = "Delivery Note  viewed in the Template  <Template_name> and Status Updated to <Del_status_change>  and emailed to the recipient <email_address>. <a href='<TempAttachment>' target='_blank'><img src='<strImagepath>pdf-icon.png' border='0' width='20px' height='20px' title='PDF' /></a>";


            hashtables["DelCreatedFromJob"] = "Delivery Note <Delivery_number> created from <Job_number>";
			hashtables["DelCarInfoChanged"] = "Delivery Note Carrier Information updated to <Carrier_Name>";
			hashtables["CopyItem"] = "A new <NewItem_number> Copied from <Item_number>";
			hashtables["EstDetailUpdate"] = "Estimate details updated";
			hashtables["JobDetailUpdate"] = "Job details updated";
			hashtables["InvDetailUpdate"] = "Invoice details updated";
			hashtables["EstSubItemDelte"] = "Sub item of Estimate <Item_number>, <Item_title> deleted";
			hashtables["EstSubItemAdded"] = "<Estimate_type> was added as subitem for <Item_number>";
			hashtables["EstSubItemRerun"] = "Sub item <Item_number>, Re-run in Estimate item <Item_number>";
			hashtables["JobSubItemRerun"] = "Sub item <Item_number>, Re-run in Job item <Item_number>";
			hashtables["InvSubItemRerun"] = "Sub item <Item_number>, Re-run in Invoice item <Item_number>";
			hashtables["OrderSubItemRerun"] = "Sub item <Item_number>, Re-run in Order item <Item_number>";
			hashtables["JobSubItemDelte"] = "Sub item of Job <Item_number>, <Item_title> deleted";
			hashtables["InvoiceSubItemDelte"] = "Sub item of Invoice <Item_number>, <Item_title> deleted";
			hashtables["OrderSubItemDelte"] = "Sub item of Order <Item_number>, <Item_title> deleted";

			hashtables["ManualProofApproval"] = "Manual Approve Selected and confirmed by <CustomerName>.";
			hashtables["ManualProofRejection"] = "Manual Reject Selected and confirmed by <CustomerName>.";
			string str = hashtables[obj.NotesType].ToString();
			str = str.Replace("<CustomerName>", obj.CustomerName);
			str = str.Replace("<email_address>", obj.email_address);
            str = str.Replace("<Item_number>", obj.Item_number);
			str = str.Replace("<Item_title>", obj.Item_title);
			str = str.Replace("<attachments>", obj.attachments);
			str = str.Replace("<Status_name>", obj.Status_name);
            str = str.Replace("<Job_status_change>", obj.Status_name);
            str = str.Replace("<Inv_status_change>", obj.Status_name);
            str = str.Replace("<PO_status_change>", obj.Status_name);
            str = str.Replace("<Del_status_change>", obj.Status_name);
            str = str.Replace("<Order_status_change>", obj.Status_name);
            str = str.Replace("<Estimate_status_change>", obj.Status_name);

            str = str.Replace("<Template_name>", obj.Template_name);
			str = str.Replace("<Customer_Name>", obj.Customer_Name);
			str = str.Replace("<Created_Date>", obj.Created_Date);
			str = str.Replace("<Item_title_new>", obj.New_Item_title);
			str = str.Replace("<Subtotal_new>", obj.New_Subtotal);
			str = str.Replace("<Subtotal_old>", obj.Old_Subtotal);
			str = str.Replace("<Subtotal_ID>", obj.Old_SubtotalID);
			str = str.Replace("<TaxRate_old>", obj.Old_TaxRate);
			str = str.Replace("<ProfitMargin_old>", obj.Old_ProfitMargin);
			str = str.Replace("<TaxRate_new>", obj.New_TaxRate);
			str = str.Replace("<ProfitMargin_new>", obj.New_ProfitMargin);
			str = str.Replace("<Estimate_type>", obj.Estimate_type);
			str = str.Replace("<Estimate_number>", obj.Estimate_number);
			str = str.Replace("<new_Estimate_number>", obj.new_Estimate_number);
			str = str.Replace("<Job_type>", obj.Job_type);
			str = str.Replace("<Job_number>", obj.Job_number);
			str = str.Replace("<new_Job_number>", obj.new_Job_number);
			str = str.Replace("<PO_Numbers>", obj.PO_Numbers);
			str = str.Replace("<Invoice_type>", obj.Invoice_type);
			str = str.Replace("<Invoice_number>", obj.Invoice_number);
			str = str.Replace("<New_Invoice_number>", obj.new_Invoice_number);
			str = str.Replace("<Amount_Paid>", obj.Amount_Paid);
			str = str.Replace("<Payment_Type>", obj.Payment_Type);
			str = str.Replace("<Previous_Amount>", obj.Previous_Amount);
			str = str.Replace("<Delivery_number>", obj.Delivery_number);
			str = str.Replace("<Del_ItemTitle>", obj.Del_ItemTitle);
			str = str.Replace("<Carrier_Name>", obj.CarrierName);
			str = str.Replace("<Po_number>", obj.Po_number);
			str = str.Replace("<new_PO_number>", obj.new_PO_number);
			str = str.Replace("<TempAttachment>", obj.TempAttachment);
			str = str.Replace("<Product_title>", obj.Product_title);
			str = str.Replace("<Product_code>", obj.Product_code);
			str = str.Replace("<NewItem_number>", obj.NewItem_number);
			str = str.Replace("<strImagepath>", obj.strImagepath);
			str = str.Replace("<Po_Attachment>", obj.Po_Attachment);
			str = str.Replace("<Delivery_Attachment>", obj.Delivery_Attachment);
			str = str.Replace("<Old_Item_title>", obj.Old_Item_title);

			long itemID = (long)0;
			if (obj.ItemID != (long)0)
			{
				long num = obj.ItemID;
				itemID = obj.ItemID;
			}
			HttpContext.Current.Session["DateFormat"].ToString();
			DateTime dateTime = this.commclass.Eprint_return_ActualDate_Before_View(obj.Created_dateTime, obj.CompanyID, obj.UserID, true);
			Printcenter.BusinessAccessLayer.Notes.Notes.insert_Activity_History(obj.CompanyID, obj.NoteType, obj.ModuleName, obj.ModuleID, str, dateTime, obj.UserID, itemID);
		}

		public static DataTable select_EstimateType_for_Activity_History(long EstimateID, long EstimateItemID)
		{
			return (new DbNotes()).select_EstimateType_for_Activity_History(EstimateID, EstimateItemID);
		}

		public static DataTable select_item_number_for_Activity_History(long EstimateID, long EstimateItemID, string ModuleType)
		{
			return (new DbNotes()).select_item_number_for_Activity_History(EstimateID, EstimateItemID, ModuleType);
		}

		public static DataTable select_item_Title_for_Activity_History(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType)
		{
			return (new DbNotes()).select_item_Title_for_Activity_History(CompanyID, EstimateID, EstimateItemID, EstimateType);
		}

		public enum NotesType
		{
			EstCreate,
			EstInfoRerun,
			EstItemRerun,
			EstAdd_attachment,
			EstNewItemAdd,
			EstChangeStatus,
			EstItemTitleEdit,
			EstItemDescPhrase,
			EstItemDesc,
			EstCopied,
			EstNewCopied,
			EstSubTotalForOthers,
			EstSubTotal,
			EstProMargin,
			EstProMarginPrice,
			EstTax,
			EstTemplateView,
			EstTempViewEdit,
			EstTempViewEditSent,
			EstTemplateSent,
            EstTemplateSentWithStatusChange,
            EstProgWithPOandDel,
			EstProgWithPO,
			EstProgWithDel,
			EstProgWithOutPOandDel,
			EstItemDeleted,
			EstSubItemDelte,
			EstSubItemAdded,
			EstSubItemRerun,
			EstItemProgtoJob,
			EstArchivedandProgtoJob,
			EstitemProcreated,
			EstitemProUpdated,
			EstItemArchived,
			EstUnArchived,
			EstItemUnArchived,
			SupplierRFQTempSend,
			OrdChangeStatus,
			OrdItemRerun,
			OrderAdd_attachment,
			OrdTempViewEdit,
			OrdProgWithPOandDel,
			OrdProgWithPO,
			OrdProgWithDel,
			OrdProgWithOutPOandDel,
			OrderTempSend,
            OrderTempSendWithStatusChange,
            OrderTemplateView,
			OrdItemDeleted,
			OrderItemTitleEdit,
			OrderTax,
			OrderSubTotalForOthers,
			OrderSubTotal,
			OrderProMargin,
			OrderProMarginPrice,
			OrderSubItemDelte,
			OrderSubItemRerun,
			OrderItemDeleted,
			OrderItemProgtoJob,
			OrdArchivedandProgtoJob,
			OrditemProcreated,
			OrdItemArchived,
			OrdUnArchived,
			OrdItemUnArchived,
			JobCreate,
			JobDirCreate,
			JobInfoRerun,
			JobItemRerun,
			JobRevertWithPOandDel,
			JobRevertWithPO,
			JobRevertWithDel,
			JobRevertWithOutPOandDel,
			JobAdd_attachment,
			JobNewItemAdd,
			JobChangeStatus,
			JobItemTitleEdit,
			JobItemDeleted,
			JobTemplateView,
			JobTempViewEdit,
			JobTempViewEditSent,
			JobTemplateSent,
            JobTemplateSentWithStatusChange,
            JobPOCreate,
			JobPOViewd,
			JobPOEdited,
			JobPODelete,
			JobPOViedInTemp,
			JobPOViedInTempEdit,
			JobPOViedInTempEditSend,
			JobPOViedInTempSend,
			JobDelCreate,
			JObDelVied,
			JobDelEdit,
			JobDelDelete,
			JobDelViewTemp,
			JobDelEditTemp,
			JobDelEditTempSend,
			JobDelTempSend,
			JobProgInvPayment,
			JobProgInv,
			JobProgInvDetail,
			JobCardEdit,
			JobCardEditSend,
			JobItemDescPhrase,
			JobCopied,
			JobNewCopied,
			JobSubTotal,
			JobSubTotalForOthers,
			JobProMargin,
			JobProMarginPrice,
			JobTax,
			OrdJobProgInv,
			JobSubItemRerun,
			JobSubItemDelte,
			JobItemProgInv,
			JobRevertWithOutPOandDelFromorder,
			JobRevertWithPOandDelFromorder,
			JobRevertWithPOFromorder,
			JobRevertWithDelFromorder,
			JobArchivedandProgtoInv,
			JobitemProcreated,
			JobitemProUpdated,
			JobItemRevertedFromEstimate,
			JobItemRevertedFromOrder,
			JobItemArchived,
			JobUnArchived,
			JobItemUnArchived,
			InvDirCreate,
			InvCreate,
			MultipleInvCreate,
			InvInfoRerun,
			InvItemRerun,
			InvAdd_attachment,
			InvNewItemAdd,
			InvChangeStatus,
			InvItemTitleEdit,
			InvItemDeleted,
			InvTemplateView,
			InvTempViewEdit,
			InvTempViewEditSent,
			InvTemplateSent,
            InvTemplateSentWithStatusChange,
            InvItemDescPhrase,
			InvCopied,
			InvNewCopied,
			InvSubTotal,
			InvSubTotalForOthers,
			InvProMargin,
			InvProMarginPrice,
			InvTax,
			InvPayment,
			InvNotPayment,
			InvfullPayment,
			InvfullPaid,
			InvPartPaid,
			InvPaymentDelete,
			InvPaymentUpdate,
			InvfullPaidMain,
			InvSubItemRerun,
			InvoiceSubItemDelte,
			InvCreatedWithPayment,
			InvCreatedWithoutPayment,
			InvitemProcreated,
			InvitemProUpdated,
			InvArchived,
			InvItemArchived,
			InvUnArchived,
			InvItemUnArchived,
			POCreated,
			POUpdate,
			POChangeStatus,
			POViewTemp,
			POTempEdit,
			POAdd_attachment,
			POTempEditSend,
			POTempSend,
            POTempSendWithStatusChange,
            POCreatedFromJob,
			POCopied,
			PONewCopied,
			POItemInserted,
			DelCreated,
			DelUpdate,
			DeliveryDelUpdate,
			DeliveryGoodsDelivered,
			DelChangeStatus,
			DelViewTemp,
			DelTempEdit,
			DelAdd_attachment,
			DelTempEditSend,
			DelTempSend,
            DelTempSendWithStatusChange,
            DelCreatedFromJob,
			DelCarInfoChanged,
			CopyItem,
			EstDetailUpdate,
			JobDetailUpdate,
			InvDetailUpdate,
			ArtworkAttchmentAdded,
			ArtworkAttchmentUpdated,
            InvExported,
            InvUnexported,
			ManualProofApproval,
			ManualProofRejection
        }
	}
}
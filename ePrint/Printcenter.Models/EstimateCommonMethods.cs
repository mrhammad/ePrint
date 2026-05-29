using Microsoft.Practices.EnterpriseLibrary.Data;
using nmsCommon;
using nmsLanguage;
using Printcenter.BusinessAccessLayer.Setting;
using Printcenter.UI.EstimatesNew;
using Printcenter.UI.Jobs;
using Printcenter.UI.Setting;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

public class EstimateCommonMethods
{
	public EstimateCommonMethods()
	{
	}

	public static void Description_Add_Or_rerun(long EstimateItemID, long EstimateID, string Estimationtype, int CompanyID, EstimateCommonMethodsItems objItems)
	{
		BaseClass baseClass = new BaseClass();
		SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateID", (object)EstimateID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@EstimateType", Estimationtype), new SqlParameter("@ItemTitleLabel", baseClass.SpecialEncode(objItems.ItemTitleLabel)), new SqlParameter("@ItemTitleValue", baseClass.SpecialEncode(objItems.ItemTitle)), new SqlParameter("@IsItemTitle", (object)objItems.isItemTitleLabel), new SqlParameter("@DescriptionLabel", baseClass.SpecialEncode(objItems.DescriptionLabel)), new SqlParameter("@DescriptionValue", baseClass.SpecialEncode(objItems.Description)), new SqlParameter("@IsDescription", (object)objItems.isDescriptionLabel), new SqlParameter("@ArtworkLabel", baseClass.SpecialEncode(objItems.ArtworkLabel)), new SqlParameter("@ArtworkValue", baseClass.SpecialEncode(objItems.Artwork)), new SqlParameter("@IsArtwork", (object)objItems.isArtworkLabel), new SqlParameter("@ColourLabel", baseClass.SpecialEncode(objItems.ColourLabel)), new SqlParameter("@ColourValue", baseClass.SpecialEncode(objItems.Colour)), new SqlParameter("@IsColour", (object)objItems.isColourLabel), new SqlParameter("@SizeLabel", baseClass.SpecialEncode(objItems.SizeLabel)), new SqlParameter("@SizeValue", baseClass.SpecialEncode(objItems.Size)), new SqlParameter("@IsSize", (object)objItems.isSizeLabel), new SqlParameter("@MaterialLabel", baseClass.SpecialEncode(objItems.MaterialLabel)), new SqlParameter("@MaterialValue", baseClass.SpecialEncode(objItems.Material)), new SqlParameter("@IsMaterial", (object)objItems.isMaterialLabel), new SqlParameter("@DeliveryLabel", baseClass.SpecialEncode(objItems.DeliveryLabel)), new SqlParameter("@DeliveryValue", baseClass.SpecialEncode(objItems.Delivery)), new SqlParameter("@IsDelivery", (object)objItems.isDeliveryLabel), new SqlParameter("@FinishingLabel", baseClass.SpecialEncode(objItems.FinishingLabel)), new SqlParameter("@FinishingValue", baseClass.SpecialEncode(objItems.Finishing)), new SqlParameter("@IsFinishing", (object)objItems.isFinishingLabel), new SqlParameter("@ProofsLabel", baseClass.SpecialEncode(objItems.ProofsLabel)), new SqlParameter("@ProofsValue", baseClass.SpecialEncode(objItems.Proofs)), new SqlParameter("@IsProofs", (object)objItems.isProofsLabel), new SqlParameter("@PackingLabel", baseClass.SpecialEncode(objItems.PackingLabel)), new SqlParameter("@PackingValue", baseClass.SpecialEncode(objItems.Packing)), new SqlParameter("@IsPacking", (object)objItems.isPackingLabel), new SqlParameter("@NotesLabel", baseClass.SpecialEncode(objItems.NotesLabel)), new SqlParameter("@NotesValue", baseClass.SpecialEncode(objItems.Notes)), new SqlParameter("@IsNotes", (object)objItems.isNotesLabel), new SqlParameter("@InstructionsLabel", baseClass.SpecialEncode(objItems.InstructionsLabel)), new SqlParameter("@InstructionsValue", baseClass.SpecialEncode(objItems.Instructions)), new SqlParameter("@IsInstructions", (object)objItems.isInstructionsLabel), new SqlParameter("@CustomDescriptionLabel1", baseClass.SpecialEncode(objItems.CustomDescriptionLabel1)), new SqlParameter("@CustomDescriptionValue1", baseClass.SpecialEncode(objItems.CustomDescription1)), new SqlParameter("@isCustomDescription1", (object)objItems.isCustomDescription1), new SqlParameter("@CustomDescriptionLabel2", baseClass.SpecialEncode(objItems.CustomDescriptionLabel2)), new SqlParameter("@CustomDescriptionValue2", baseClass.SpecialEncode(objItems.CustomDescription2)), new SqlParameter("@isCustomDescription2", (object)objItems.isCustomDescription2), new SqlParameter("@CustomDescriptionLabel3", baseClass.SpecialEncode(objItems.CustomDescriptionLabel3)), new SqlParameter("@CustomDescriptionValue3", baseClass.SpecialEncode(objItems.CustomDescription3)), new SqlParameter("@isCustomDescription3", (object)objItems.isCustomDescription3), new SqlParameter("@CustomDescriptionLabel4", baseClass.SpecialEncode(objItems.CustomDescriptionLabel4)), new SqlParameter("@CustomDescriptionValue4", baseClass.SpecialEncode(objItems.CustomDescription4)), new SqlParameter("@isCustomDescription4", (object)objItems.isCustomDescription4), new SqlParameter("@CustomDescriptionLabel5", baseClass.SpecialEncode(objItems.CustomDescriptionLabel5)), new SqlParameter("@CustomDescriptionValue5", baseClass.SpecialEncode(objItems.CustomDescription5)), new SqlParameter("@isCustomDescription5", (object)objItems.isCustomDescription5), new SqlParameter("@CustomDescriptionLabel6", baseClass.SpecialEncode(objItems.CustomDescriptionLabel6)), new SqlParameter("@CustomDescriptionValue6", baseClass.SpecialEncode(objItems.CustomDescription6)), new SqlParameter("@isCustomDescription6", (object)objItems.isCustomDescription6), new SqlParameter("@CustomDescriptionLabel7", baseClass.SpecialEncode(objItems.CustomDescriptionLabel7)), new SqlParameter("@CustomDescriptionValue7", baseClass.SpecialEncode(objItems.CustomDescription7)), new SqlParameter("@isCustomDescription7", (object)objItems.isCustomDescription7), new SqlParameter("@CustomDescriptionLabel8", baseClass.SpecialEncode(objItems.CustomDescriptionLabel8)), new SqlParameter("@CustomDescriptionValue8", baseClass.SpecialEncode(objItems.CustomDescription8)), new SqlParameter("@isCustomDescription8", (object)objItems.isCustomDescription8), new SqlParameter("@CustomDescriptionLabel9", baseClass.SpecialEncode(objItems.CustomDescriptionLabel9)), new SqlParameter("@CustomDescriptionValue9", baseClass.SpecialEncode(objItems.CustomDescription9)), new SqlParameter("@isCustomDescription9", (object)objItems.isCustomDescription9), new SqlParameter("@CustomDescriptionLabel10", baseClass.SpecialEncode(objItems.CustomDescriptionLabel10)), new SqlParameter("@CustomDescriptionValue10", baseClass.SpecialEncode(objItems.CustomDescription10)), new SqlParameter("@isCustomDescription10", (object)objItems.isCustomDescription10), new SqlParameter("@CustomDescriptionLabel11", baseClass.SpecialEncode(objItems.CustomDescriptionLabel11)), new SqlParameter("@CustomDescriptionValue11", baseClass.SpecialEncode(objItems.CustomDescription11)), new SqlParameter("@isCustomDescription11", (object)objItems.isCustomDescription11), new SqlParameter("@CustomDescriptionLabel12", baseClass.SpecialEncode(objItems.CustomDescriptionLabel12)), new SqlParameter("@CustomDescriptionValue12", baseClass.SpecialEncode(objItems.CustomDescription12)), new SqlParameter("@isCustomDescription12", (object)objItems.isCustomDescription12), new SqlParameter("@CustomDescriptionLabel13", baseClass.SpecialEncode(objItems.CustomDescriptionLabel13)), new SqlParameter("@CustomDescriptionValue13", baseClass.SpecialEncode(objItems.CustomDescription13)), new SqlParameter("@isCustomDescription13", (object)objItems.isCustomDescription13), new SqlParameter("@CustomDescriptionLabel14", baseClass.SpecialEncode(objItems.CustomDescriptionLabel14)), new SqlParameter("@CustomDescriptionValue14", baseClass.SpecialEncode(objItems.CustomDescription14)), new SqlParameter("@isCustomDescription14", (object)objItems.isCustomDescription14), new SqlParameter("@CustomDescriptionLabel15", baseClass.SpecialEncode(objItems.CustomDescriptionLabel15)), new SqlParameter("@CustomDescriptionValue15", baseClass.SpecialEncode(objItems.CustomDescription15)), new SqlParameter("@isCustomDescription15", (object)objItems.isCustomDescription15), new SqlParameter("@CustomDescriptionLabel16", baseClass.SpecialEncode(objItems.CustomDescriptionLabel16)), new SqlParameter("@CustomDescriptionValue16", baseClass.SpecialEncode(objItems.CustomDescription16)), new SqlParameter("@isCustomDescription16", (object)objItems.isCustomDescription16), new SqlParameter("@CustomDescriptionLabel17", baseClass.SpecialEncode(objItems.CustomDescriptionLabel17)), new SqlParameter("@CustomDescriptionValue17", baseClass.SpecialEncode(objItems.CustomDescription17)), new SqlParameter("@isCustomDescription17", (object)objItems.isCustomDescription17), new SqlParameter("@CustomDescriptionLabel18", baseClass.SpecialEncode(objItems.CustomDescriptionLabel18)), new SqlParameter("@CustomDescriptionValue18", baseClass.SpecialEncode(objItems.CustomDescription18)), new SqlParameter("@isCustomDescription18", (object)objItems.isCustomDescription18), new SqlParameter("@CustomDescriptionLabel19", baseClass.SpecialEncode(objItems.CustomDescriptionLabel19)), new SqlParameter("@CustomDescriptionValue19", baseClass.SpecialEncode(objItems.CustomDescription19)), new SqlParameter("@isCustomDescription19", (object)objItems.isCustomDescription19), new SqlParameter("@CustomDescriptionLabel20", baseClass.SpecialEncode(objItems.CustomDescriptionLabel20)), new SqlParameter("@CustomDescriptionValue20", baseClass.SpecialEncode(objItems.CustomDescription20)), new SqlParameter("@isCustomDescription20", (object)objItems.isCustomDescription20), new SqlParameter("@CustomDescriptionLabel21", baseClass.SpecialEncode(objItems.CustomDescriptionLabel21)), new SqlParameter("@CustomDescriptionValue21", baseClass.SpecialEncode(objItems.CustomDescription21)), new SqlParameter("@isCustomDescription21", (object)objItems.isCustomDescription21), new SqlParameter("@CustomDescriptionLabel22", baseClass.SpecialEncode(objItems.CustomDescriptionLabel22)), new SqlParameter("@CustomDescriptionValue22", baseClass.SpecialEncode(objItems.CustomDescription22)), new SqlParameter("@isCustomDescription22", (object)objItems.isCustomDescription22), new SqlParameter("@CustomDescriptionLabel23", baseClass.SpecialEncode(objItems.CustomDescriptionLabel23)), new SqlParameter("@CustomDescriptionValue23", baseClass.SpecialEncode(objItems.CustomDescription23)), new SqlParameter("@isCustomDescription23", (object)objItems.isCustomDescription23), new SqlParameter("@CustomDescriptionLabel24", baseClass.SpecialEncode(objItems.CustomDescriptionLabel24)), new SqlParameter("@CustomDescriptionValue24", baseClass.SpecialEncode(objItems.CustomDescription24)), new SqlParameter("@isCustomDescription24", (object)objItems.isCustomDescription24), new SqlParameter("@CustomDescriptionLabel25", baseClass.SpecialEncode(objItems.CustomDescriptionLabel25)), new SqlParameter("@CustomDescriptionValue25", baseClass.SpecialEncode(objItems.CustomDescription25)), new SqlParameter("@isCustomDescription25", (object)objItems.isCustomDescription25), new SqlParameter("@IsItemTitleTemplate", (object)objItems.IsItemTitleTemplate), new SqlParameter("@IsDescriptionTemplate", (object)objItems.IsDescriptionTemplate), new SqlParameter("@IsArtworkTemplate", (object)objItems.IsArtworkTemplate), new SqlParameter("@IsColourTemplate", (object)objItems.IsColourTemplate), new SqlParameter("@IsSizeTemplate", (object)objItems.IsSizeTemplate), new SqlParameter("@IsMaterialTemplate", (object)objItems.IsMaterialTemplate), new SqlParameter("@IsDeliveryTemplate", (object)objItems.IsDeliveryTemplate), new SqlParameter("@IsFinishingTemplate", (object)objItems.IsFinishingTemplate), new SqlParameter("@IsProofsTemplate", (object)objItems.IsProofsTemplate), new SqlParameter("@IsPackingTemplate", (object)objItems.IsPackingTemplate), new SqlParameter("@IsNotesTemplate", (object)objItems.IsNotesTemplate), new SqlParameter("@IsInstructionsTemplate", (object)objItems.IsInstructionsTemplate), new SqlParameter("@isCustomDescription1Template", (object)objItems.IsCustomDescription1Template), new SqlParameter("@isCustomDescription2Template", (object)objItems.IsCustomDescription2Template), new SqlParameter("@isCustomDescription3Template", (object)objItems.IsCustomDescription3Template), new SqlParameter("@isCustomDescription4Template", (object)objItems.IsCustomDescription4Template), new SqlParameter("@isCustomDescription5Template", (object)objItems.IsCustomDescription5Template), new SqlParameter("@isCustomDescription6Template", (object)objItems.IsCustomDescription6Template), new SqlParameter("@isCustomDescription7Template", (object)objItems.IsCustomDescription7Template), new SqlParameter("@isCustomDescription8Template", (object)objItems.IsCustomDescription8Template), new SqlParameter("@isCustomDescription9Template", (object)objItems.IsCustomDescription9Template), new SqlParameter("@isCustomDescription10Template", (object)objItems.IsCustomDescription10Template), new SqlParameter("@isCustomDescription11Template", (object)objItems.IsCustomDescription11Template), new SqlParameter("@isCustomDescription12Template", (object)objItems.IsCustomDescription12Template), new SqlParameter("@isCustomDescription13Template", (object)objItems.IsCustomDescription13Template), new SqlParameter("@isCustomDescription14Template", (object)objItems.IsCustomDescription14Template), new SqlParameter("@isCustomDescription15Template", (object)objItems.IsCustomDescription15Template), new SqlParameter("@isCustomDescription16Template", (object)objItems.IsCustomDescription16Template), new SqlParameter("@isCustomDescription17Template", (object)objItems.IsCustomDescription17Template), new SqlParameter("@isCustomDescription18Template", (object)objItems.IsCustomDescription18Template), new SqlParameter("@isCustomDescription19Template", (object)objItems.IsCustomDescription19Template), new SqlParameter("@isCustomDescription20Template", (object)objItems.IsCustomDescription20Template), new SqlParameter("@isCustomDescription21Template", (object)objItems.IsCustomDescription21Template), new SqlParameter("@isCustomDescription22Template", (object)objItems.IsCustomDescription22Template), new SqlParameter("@isCustomDescription23Template", (object)objItems.IsCustomDescription23Template), new SqlParameter("@isCustomDescription24Template", (object)objItems.IsCustomDescription24Template), new SqlParameter("@isCustomDescription25Template", (object)objItems.IsCustomDescription25Template) };
		SqlParameter[] sqlParameterArray = sqlParameter;
		commonClass _commonClass = new commonClass();
		SQL.ExecuteNonQuery(_commonClass.strConnection, CommandType.StoredProcedure, "PC_EstItemDescription_AddOrRerun", sqlParameterArray);
	}

	public static void EditUpdateIDescriptionsInSummary(int CompanyID, long EstimateID, long EstimateItemID, string EstimateType, string AllItemDescnValues, bool CopyCustomerDesnToSuplrDesn, bool ChkCopyPOState, bool ChkCopyDNState, string itemTitle, string Module, int UserId =0)
	{
		BaseClass baseClass = new BaseClass();
		EstimateCommonMethodsItems estimateCommonMethodsItem = new EstimateCommonMethodsItems();
		string[] strArrays = AllItemDescnValues.Split(new char[] { 'µ' });
		for (int i = 0; i < (int)strArrays.Length - 1; i++)
		{
			string[] strArrays1 = new string[] { "~|~" };
			string[] strArrays2 = strArrays[i].Split(strArrays1, StringSplitOptions.None);
			if (strArrays2[0].ToString() == "ItemTitleValue")
			{
				estimateCommonMethodsItem.ItemTitleLabel = strArrays2[1];
				estimateCommonMethodsItem.ItemTitle = strArrays2[2].Replace("\r\n", "<br/>");
				estimateCommonMethodsItem.IsItemTitleTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsItemTitleToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "DescriptionValue")
			{
				estimateCommonMethodsItem.DescriptionLabel = strArrays2[1];
				estimateCommonMethodsItem.Description = strArrays2[2];
				estimateCommonMethodsItem.IsDescriptionTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsDescriptionToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "ArtworkValue")
			{
				estimateCommonMethodsItem.ArtworkLabel = strArrays2[1];
				estimateCommonMethodsItem.Artwork = strArrays2[2];
				estimateCommonMethodsItem.IsArtworkTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsArtworkToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "ColourValue")
			{
				estimateCommonMethodsItem.ColourLabel = strArrays2[1];
				estimateCommonMethodsItem.Colour = strArrays2[2];
				estimateCommonMethodsItem.IsColourTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsColourToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "SizeValue")
			{
				estimateCommonMethodsItem.SizeLabel = strArrays2[1];
				estimateCommonMethodsItem.Size = strArrays2[2];
				estimateCommonMethodsItem.IsSizeTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsSizeToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "MaterialValue")
			{
				estimateCommonMethodsItem.MaterialLabel = strArrays2[1];
				estimateCommonMethodsItem.Material = strArrays2[2];
				estimateCommonMethodsItem.IsMaterialTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsMaterialToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "DeliveryValue")
			{
				estimateCommonMethodsItem.DeliveryLabel = strArrays2[1];
				estimateCommonMethodsItem.Delivery = strArrays2[2];
				estimateCommonMethodsItem.IsDeliveryTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsDeliveryToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "FinishingValue")
			{
				estimateCommonMethodsItem.FinishingLabel = strArrays2[1];
				estimateCommonMethodsItem.Finishing = strArrays2[2];
				estimateCommonMethodsItem.IsFinishingTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsFinishingToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "ProofsValue")
			{
				estimateCommonMethodsItem.ProofsLabel = strArrays2[1];
				estimateCommonMethodsItem.Proofs = strArrays2[2];
				estimateCommonMethodsItem.IsProofsTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsProofsToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "PackingValue")
			{
				estimateCommonMethodsItem.PackingLabel = strArrays2[1];
				estimateCommonMethodsItem.Packing = strArrays2[2];
				estimateCommonMethodsItem.IsPackingTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsPackingToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "NotesValue")
			{
				estimateCommonMethodsItem.NotesLabel = strArrays2[1];
				estimateCommonMethodsItem.Notes = strArrays2[2];
				estimateCommonMethodsItem.IsNotesTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsNotesToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "InstructionsValue")
			{
				estimateCommonMethodsItem.InstructionsLabel = strArrays2[1];
				estimateCommonMethodsItem.Instructions = strArrays2[2];
				estimateCommonMethodsItem.IsInstructionsTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsInstructionsToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue1")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel1 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription1 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription1Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription1ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue2")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel2 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription2 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription2Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription2ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue3")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel3 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription3 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription3Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription3ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue4")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel4 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription4 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription4Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription4ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue5")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel5 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription5 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription5Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription5ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue6")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel6 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription6 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription6Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription6ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue7")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel7 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription7 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription7Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription7ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue8")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel8 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription8 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription8Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription8ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue9")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel9 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription9 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription9Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription9ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue10")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel10 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription10 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription10Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription10ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue11")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel11 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription11 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription11Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription11ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue12")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel12 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription12 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription12Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription12ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue13")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel13 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription13 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription13Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription13ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue14")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel14 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription14 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription14Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription14ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue15")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel15 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription15 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription15Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription15ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue16")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel16 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription16 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription16Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription16ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue17")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel17 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription17 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription17Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription17ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue18")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel18 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription18 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription18Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription18ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue19")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel19 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription19 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription19Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription19ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue20")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel20 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription20 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription20Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription20ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue21")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel21 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription21 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription21Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription21ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue22")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel22 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription22 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription22Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription22ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue23")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel23 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription23 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription23Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription23ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue24")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel24 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription24 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription24Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription24ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue25")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel25 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription25 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription25Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription25ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
		}
		SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateID", (object)EstimateID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@Estimatetype", EstimateType), new SqlParameter("@PageType", Module), new SqlParameter("@CopyCustomerDescnToSupplierDesn", (object)CopyCustomerDesnToSuplrDesn), new SqlParameter("@ItemTitleLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.ItemTitleLabel)), new SqlParameter("@ItemTitleValue", baseClass.SpecialEncode(estimateCommonMethodsItem.ItemTitle)), new SqlParameter("@IsItemTitleTemplate", (object)estimateCommonMethodsItem.IsItemTitleTemplate), new SqlParameter("@IsItemTitleToPhrase", (object)estimateCommonMethodsItem.IsItemTitleToPhrase), new SqlParameter("@DescriptionLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.DescriptionLabel)), new SqlParameter("@DescriptionValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Description)), new SqlParameter("@IsDescriptionTemplate", (object)estimateCommonMethodsItem.IsDescriptionTemplate), new SqlParameter("@IsDescriptionToPhrase", (object)estimateCommonMethodsItem.IsDescriptionToPhrase), new SqlParameter("@ArtworkLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.ArtworkLabel)), new SqlParameter("@ArtworkValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Artwork)), new SqlParameter("@IsArtworkTemplate", (object)estimateCommonMethodsItem.IsArtworkTemplate), new SqlParameter("@IsArtworkToPhrase", (object)estimateCommonMethodsItem.IsArtworkToPhrase), new SqlParameter("@ColourLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.ColourLabel)), new SqlParameter("@ColourValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Colour)), new SqlParameter("@IsColourTemplate", (object)estimateCommonMethodsItem.IsColourTemplate), new SqlParameter("@IsColourToPhrase", (object)estimateCommonMethodsItem.IsColourToPhrase), new SqlParameter("@SizeLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.SizeLabel)), new SqlParameter("@SizeValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Size)), new SqlParameter("@IsSizeTemplate", (object)estimateCommonMethodsItem.IsSizeTemplate), new SqlParameter("@IsSizeToPhrase", (object)estimateCommonMethodsItem.IsSizeToPhrase), new SqlParameter("@MaterialLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.MaterialLabel)), new SqlParameter("@MaterialValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Material)), new SqlParameter("@IsMaterialTemplate", (object)estimateCommonMethodsItem.IsMaterialTemplate), new SqlParameter("@IsMaterialToPhrase", (object)estimateCommonMethodsItem.IsMaterialToPhrase), new SqlParameter("@DeliveryLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.DeliveryLabel)), new SqlParameter("@DeliveryValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Delivery)), new SqlParameter("@IsDeliveryTemplate", (object)estimateCommonMethodsItem.IsDeliveryTemplate), new SqlParameter("@IsDeliveryToPhrase", (object)estimateCommonMethodsItem.IsDeliveryToPhrase), new SqlParameter("@FinishingLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.FinishingLabel)), new SqlParameter("@FinishingValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Finishing)), new SqlParameter("@IsFinishingTemplate", (object)estimateCommonMethodsItem.IsFinishingTemplate), new SqlParameter("@IsFinishingToPhrase", (object)estimateCommonMethodsItem.IsFinishingToPhrase), new SqlParameter("@ProofsLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.ProofsLabel)), new SqlParameter("@ProofsValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Proofs)), new SqlParameter("@IsProofsTemplate", (object)estimateCommonMethodsItem.IsProofsTemplate), new SqlParameter("@IsProofsToPhrase", (object)estimateCommonMethodsItem.IsProofsToPhrase), new SqlParameter("@PackingLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.PackingLabel)), new SqlParameter("@PackingValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Packing)), new SqlParameter("@IsPackingTemplate", (object)estimateCommonMethodsItem.IsPackingTemplate), new SqlParameter("@IsPackingToPhrase", (object)estimateCommonMethodsItem.IsPackingToPhrase), new SqlParameter("@NotesLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.NotesLabel)), new SqlParameter("@NotesValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Notes)), new SqlParameter("@IsNotesTemplate", (object)estimateCommonMethodsItem.IsNotesTemplate), new SqlParameter("@IsNotesToPhrase", (object)estimateCommonMethodsItem.IsNotesToPhrase), new SqlParameter("@InstructionsLabel ", baseClass.SpecialEncode(estimateCommonMethodsItem.InstructionsLabel)), new SqlParameter("@InstructionsValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Instructions)), new SqlParameter("@IsInstructionsTemplate", (object)estimateCommonMethodsItem.IsInstructionsTemplate), new SqlParameter("@IsInstructionsToPhrase", (object)estimateCommonMethodsItem.IsInstructionsToPhrase), new SqlParameter("@CustomDescriptionLabel1", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel1)), new SqlParameter("@CustomDescription1", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription1)), new SqlParameter("@IsCustomDescription1Template", (object)estimateCommonMethodsItem.IsCustomDescription1Template), new SqlParameter("@IsCustomDescription1ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription1ToPhrase), new SqlParameter("@CustomDescriptionLabel2", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel2)), new SqlParameter("@CustomDescription2", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription2)), new SqlParameter("@IsCustomDescription2Template", (object)estimateCommonMethodsItem.IsCustomDescription2Template), new SqlParameter("@IsCustomDescription2ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription2ToPhrase), new SqlParameter("@CustomDescriptionLabel3", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel3)), new SqlParameter("@CustomDescription3", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription3)), new SqlParameter("@IsCustomDescription3Template", (object)estimateCommonMethodsItem.IsCustomDescription3Template), new SqlParameter("@IsCustomDescription3ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription3ToPhrase), new SqlParameter("@CustomDescriptionLabel4", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel4)), new SqlParameter("@CustomDescription4", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription4)), new SqlParameter("@IsCustomDescription4Template", (object)estimateCommonMethodsItem.IsCustomDescription4Template), new SqlParameter("@IsCustomDescription4ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription4ToPhrase), new SqlParameter("@CustomDescriptionLabel5", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel5)), new SqlParameter("@CustomDescription5", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription5)), new SqlParameter("@IsCustomDescription5Template", (object)estimateCommonMethodsItem.IsCustomDescription5Template), new SqlParameter("@IsCustomDescription5ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription5ToPhrase), new SqlParameter("@CustomDescriptionLabel6", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel6)), new SqlParameter("@CustomDescription6", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription6)), new SqlParameter("@IsCustomDescription6Template", (object)estimateCommonMethodsItem.IsCustomDescription6Template), new SqlParameter("@IsCustomDescription6ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription6ToPhrase), new SqlParameter("@CustomDescriptionLabel7", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel7)), new SqlParameter("@CustomDescription7", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription7)), new SqlParameter("@IsCustomDescription7Template", (object)estimateCommonMethodsItem.IsCustomDescription7Template), new SqlParameter("@IsCustomDescription7ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription7ToPhrase), new SqlParameter("@CustomDescriptionLabel8", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel8)), new SqlParameter("@CustomDescription8", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription8)), new SqlParameter("@IsCustomDescription8Template", (object)estimateCommonMethodsItem.IsCustomDescription8Template), new SqlParameter("@IsCustomDescription8ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription8ToPhrase), new SqlParameter("@CustomDescriptionLabel9", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel9)), new SqlParameter("@CustomDescription9", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription9)), new SqlParameter("@IsCustomDescription9Template", (object)estimateCommonMethodsItem.IsCustomDescription9Template), new SqlParameter("@IsCustomDescription9ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription9ToPhrase), new SqlParameter("@CustomDescriptionLabel10", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel10)), new SqlParameter("@CustomDescription10", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription10)), new SqlParameter("@IsCustomDescription10Template", (object)estimateCommonMethodsItem.IsCustomDescription10Template), new SqlParameter("@IsCustomDescription10ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription10ToPhrase), new SqlParameter("@CustomDescriptionLabel11", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel11)), new SqlParameter("@CustomDescription11", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription11)), new SqlParameter("@IsCustomDescription11Template", (object)estimateCommonMethodsItem.IsCustomDescription11Template), new SqlParameter("@IsCustomDescription11ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription11ToPhrase), new SqlParameter("@CustomDescriptionLabel12", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel12)), new SqlParameter("@CustomDescription12", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription12)), new SqlParameter("@IsCustomDescription12Template", (object)estimateCommonMethodsItem.IsCustomDescription12Template), new SqlParameter("@IsCustomDescription12ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription12ToPhrase), new SqlParameter("@CustomDescriptionLabel13", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel13)), new SqlParameter("@CustomDescription13", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription13)), new SqlParameter("@IsCustomDescription13Template", (object)estimateCommonMethodsItem.IsCustomDescription13Template), new SqlParameter("@IsCustomDescription13ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription13ToPhrase), new SqlParameter("@CustomDescriptionLabel14", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel14)), new SqlParameter("@CustomDescription14", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription14)), new SqlParameter("@IsCustomDescription14Template", (object)estimateCommonMethodsItem.IsCustomDescription14Template), new SqlParameter("@IsCustomDescription14ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription14ToPhrase), new SqlParameter("@CustomDescriptionLabel15", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel15)), new SqlParameter("@CustomDescription15", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription15)), new SqlParameter("@IsCustomDescription15Template", (object)estimateCommonMethodsItem.IsCustomDescription15Template), new SqlParameter("@IsCustomDescription15ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription15ToPhrase), new SqlParameter("@CustomDescriptionLabel16", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel16)), new SqlParameter("@CustomDescription16", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription16)), new SqlParameter("@IsCustomDescription16Template", (object)estimateCommonMethodsItem.IsCustomDescription16Template), new SqlParameter("@IsCustomDescription16ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription16ToPhrase), new SqlParameter("@CustomDescriptionLabel17", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel17)), new SqlParameter("@CustomDescription17", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription17)), new SqlParameter("@IsCustomDescription17Template", (object)estimateCommonMethodsItem.IsCustomDescription17Template), new SqlParameter("@IsCustomDescription17ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription17ToPhrase), new SqlParameter("@CustomDescriptionLabel18", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel18)), new SqlParameter("@CustomDescription18", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription18)), new SqlParameter("@IsCustomDescription18Template", (object)estimateCommonMethodsItem.IsCustomDescription18Template), new SqlParameter("@IsCustomDescription18ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription18ToPhrase), new SqlParameter("@CustomDescriptionLabel19", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel19)), new SqlParameter("@CustomDescription19", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription19)), new SqlParameter("@IsCustomDescription19Template", (object)estimateCommonMethodsItem.IsCustomDescription19Template), new SqlParameter("@IsCustomDescription19ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription19ToPhrase), new SqlParameter("@CustomDescriptionLabel20", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel20)), new SqlParameter("@CustomDescription20", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription20)), new SqlParameter("@IsCustomDescription20Template", (object)estimateCommonMethodsItem.IsCustomDescription20Template), new SqlParameter("@IsCustomDescription20ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription20ToPhrase), new SqlParameter("@CustomDescriptionLabel21", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel21)), new SqlParameter("@CustomDescription21", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription21)), new SqlParameter("@IsCustomDescription21Template", (object)estimateCommonMethodsItem.IsCustomDescription21Template), new SqlParameter("@IsCustomDescription21ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription21ToPhrase), new SqlParameter("@CustomDescriptionLabel22", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel22)), new SqlParameter("@CustomDescription22", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription22)), new SqlParameter("@IsCustomDescription22Template", (object)estimateCommonMethodsItem.IsCustomDescription22Template), new SqlParameter("@IsCustomDescription22ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription22ToPhrase), new SqlParameter("@CustomDescriptionLabel23", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel23)), new SqlParameter("@CustomDescription23", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription23)), new SqlParameter("@IsCustomDescription23Template", (object)estimateCommonMethodsItem.IsCustomDescription23Template), new SqlParameter("@IsCustomDescription23ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription23ToPhrase), new SqlParameter("@CustomDescriptionLabel24", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel24)), new SqlParameter("@CustomDescription24", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription24)), new SqlParameter("@IsCustomDescription24Template", (object)estimateCommonMethodsItem.IsCustomDescription24Template), new SqlParameter("@IsCustomDescription24ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription24ToPhrase), new SqlParameter("@CustomDescriptionLabel25", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel25)), new SqlParameter("@CustomDescription25", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription25)), new SqlParameter("@IsCustomDescription25Template", (object)estimateCommonMethodsItem.IsCustomDescription25Template), new SqlParameter("@IsCustomDescription25ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription25ToPhrase), new SqlParameter("@UserID", (object)UserId) };
		SqlParameter[] sqlParameterArray = sqlParameter;
		commonClass _commonClass = new commonClass();
		SQL.ExecuteNonQuery(_commonClass.strConnection, CommandType.StoredProcedure, "PC_EstItemDescription_Update", sqlParameterArray);
		if (EstimateType.ToLower() == "o" && (ChkCopyPOState || ChkCopyDNState))
		{
			string empty = string.Empty;
			DataSet dataSet = new DataSet();
			SqlParameter[] sqlParameter1 = new SqlParameter[] { new SqlParameter("@EstimateItemID", (object)EstimateItemID) };
			dataSet = SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PC_EstimateDescription_Outwork", sqlParameter1);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				string[] strArrays3 = dataSet.Tables[0].Rows[0]["PODescription"].ToString().Split(new char[] { 'µ' });
				for (int j = 0; j < (int)strArrays3.Length; j++)
				{
					if (strArrays3[j] != "")
					{
						stringBuilder.Append(EstimateCommonMethods.strItemDesc(strArrays3[j]));
					}
				}
				empty = stringBuilder.ToString();
			}
			if (ChkCopyPOState)
			{
				SqlParameter[] sqlParameterArray1 = new SqlParameter[] { new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@Description", empty) };
				dataSet = SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PC_PurchaseItemDescription_Update", sqlParameterArray1);
			}
			if (ChkCopyDNState)
			{
				SqlParameter[] sqlParameter2 = new SqlParameter[] { new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@Description", empty) };
				dataSet = SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PC_DeliveryItemDescription_Update", sqlParameter2);
			}
		}
		(new SummaryClass()).Insert_ActivityHistory_OnItemDescriptionUpdate(EstimateID, EstimateItemID, EstimateType, Module, itemTitle);
	}
	public static void UpdateProofItemDescriptionInSummary(int CompanyID, long EstimateID, long EstimateItemID,long ProofItemID, string EstimateType, string AllItemDescnValues, bool CopyCustomerDesnToSuplrDesn, bool ChkCopyPOState, bool ChkCopyDNState, string itemTitle, string Module)
	{
		BaseClass baseClass = new BaseClass();
		EstimateCommonMethodsItems estimateCommonMethodsItem = new EstimateCommonMethodsItems();
		long UserID = Convert.ToInt64(baseClass.Session["UserID"].ToString());
		string[] strArrays = AllItemDescnValues.Split(new char[] { 'µ' });
		for (int i = 0; i < (int)strArrays.Length - 1; i++)
		{
			string[] strArrays1 = new string[] { "~|~" };
			string[] strArrays2 = strArrays[i].Split(strArrays1, StringSplitOptions.None);
			if (strArrays2[0].ToString() == "ItemTitleValue")
			{
				estimateCommonMethodsItem.ItemTitleLabel = strArrays2[1];
				estimateCommonMethodsItem.ItemTitle = strArrays2[2].Replace("\r\n", "<br/>");
				estimateCommonMethodsItem.IsItemTitleTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsItemTitleToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "DescriptionValue")
			{
				estimateCommonMethodsItem.DescriptionLabel = strArrays2[1];
				estimateCommonMethodsItem.Description = strArrays2[2];
				estimateCommonMethodsItem.IsDescriptionTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsDescriptionToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "ArtworkValue")
			{
				estimateCommonMethodsItem.ArtworkLabel = strArrays2[1];
				estimateCommonMethodsItem.Artwork = strArrays2[2];
				estimateCommonMethodsItem.IsArtworkTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsArtworkToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "ColourValue")
			{
				estimateCommonMethodsItem.ColourLabel = strArrays2[1];
				estimateCommonMethodsItem.Colour = strArrays2[2];
				estimateCommonMethodsItem.IsColourTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsColourToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "SizeValue")
			{
				estimateCommonMethodsItem.SizeLabel = strArrays2[1];
				estimateCommonMethodsItem.Size = strArrays2[2];
				estimateCommonMethodsItem.IsSizeTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsSizeToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "MaterialValue")
			{
				estimateCommonMethodsItem.MaterialLabel = strArrays2[1];
				estimateCommonMethodsItem.Material = strArrays2[2];
				estimateCommonMethodsItem.IsMaterialTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsMaterialToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "DeliveryValue")
			{
				estimateCommonMethodsItem.DeliveryLabel = strArrays2[1];
				estimateCommonMethodsItem.Delivery = strArrays2[2];
				estimateCommonMethodsItem.IsDeliveryTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsDeliveryToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "FinishingValue")
			{
				estimateCommonMethodsItem.FinishingLabel = strArrays2[1];
				estimateCommonMethodsItem.Finishing = strArrays2[2];
				estimateCommonMethodsItem.IsFinishingTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsFinishingToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "ProofsValue")
			{
				estimateCommonMethodsItem.ProofsLabel = strArrays2[1];
				estimateCommonMethodsItem.Proofs = strArrays2[2];
				estimateCommonMethodsItem.IsProofsTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsProofsToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "PackingValue")
			{
				estimateCommonMethodsItem.PackingLabel = strArrays2[1];
				estimateCommonMethodsItem.Packing = strArrays2[2];
				estimateCommonMethodsItem.IsPackingTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsPackingToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "NotesValue")
			{
				estimateCommonMethodsItem.NotesLabel = strArrays2[1];
				estimateCommonMethodsItem.Notes = strArrays2[2];
				estimateCommonMethodsItem.IsNotesTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsNotesToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "InstructionsValue")
			{
				estimateCommonMethodsItem.InstructionsLabel = strArrays2[1];
				estimateCommonMethodsItem.Instructions = strArrays2[2];
				estimateCommonMethodsItem.IsInstructionsTemplate = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsInstructionsToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue1")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel1 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription1 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription1Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription1ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue2")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel2 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription2 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription2Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription2ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue3")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel3 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription3 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription3Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription3ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue4")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel4 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription4 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription4Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription4ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue5")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel5 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription5 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription5Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription5ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue6")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel6 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription6 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription6Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription6ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue7")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel7 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription7 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription7Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription7ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue8")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel8 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription8 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription8Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription8ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue9")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel9 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription9 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription9Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription9ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue10")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel10 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription10 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription10Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription10ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue11")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel11 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription11 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription11Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription11ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue12")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel12 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription12 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription12Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription12ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue13")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel13 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription13 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription13Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription13ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue14")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel14 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription14 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription14Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription14ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue15")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel15 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription15 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription15Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription15ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue16")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel16 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription16 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription16Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription16ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue17")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel17 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription17 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription17Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription17ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue18")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel18 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription18 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription18Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription18ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue19")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel19 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription19 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription19Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription19ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue20")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel20 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription20 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription20Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription20ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue21")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel21 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription21 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription21Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription21ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue22")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel22 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription22 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription22Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription22ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue23")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel23 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription23 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription23Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription23ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue24")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel24 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription24 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription24Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription24ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
			if (strArrays2[0].ToString() == "CustomDescriptionValue25")
			{
				estimateCommonMethodsItem.CustomDescriptionLabel25 = strArrays2[1];
				estimateCommonMethodsItem.CustomDescription25 = strArrays2[2];
				estimateCommonMethodsItem.IsCustomDescription25Template = Convert.ToBoolean(strArrays2[3]);
				estimateCommonMethodsItem.IsCustomDescription25ToPhrase = Convert.ToBoolean(strArrays2[4]);
			}
		}
		SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@UserID", (object)UserID), new SqlParameter("@EstimateID", (object)EstimateID), new SqlParameter("@EstimateItemID", (object)EstimateItemID), new SqlParameter("@ProofItemID", (object)ProofItemID), new SqlParameter("@Estimatetype", EstimateType), new SqlParameter("@PageType", Module), new SqlParameter("@CopyCustomerDescnToSupplierDesn", (object)CopyCustomerDesnToSuplrDesn), new SqlParameter("@ItemTitleLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.ItemTitleLabel)), new SqlParameter("@ItemTitleValue", baseClass.SpecialEncode(estimateCommonMethodsItem.ItemTitle)), new SqlParameter("@IsItemTitleTemplate", (object)estimateCommonMethodsItem.IsItemTitleTemplate), new SqlParameter("@IsItemTitleToPhrase", (object)estimateCommonMethodsItem.IsItemTitleToPhrase), new SqlParameter("@DescriptionLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.DescriptionLabel)), new SqlParameter("@DescriptionValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Description)), new SqlParameter("@IsDescriptionTemplate", (object)estimateCommonMethodsItem.IsDescriptionTemplate), new SqlParameter("@IsDescriptionToPhrase", (object)estimateCommonMethodsItem.IsDescriptionToPhrase), new SqlParameter("@ArtworkLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.ArtworkLabel)), new SqlParameter("@ArtworkValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Artwork)), new SqlParameter("@IsArtworkTemplate", (object)estimateCommonMethodsItem.IsArtworkTemplate), new SqlParameter("@IsArtworkToPhrase", (object)estimateCommonMethodsItem.IsArtworkToPhrase), new SqlParameter("@ColourLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.ColourLabel)), new SqlParameter("@ColourValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Colour)), new SqlParameter("@IsColourTemplate", (object)estimateCommonMethodsItem.IsColourTemplate), new SqlParameter("@IsColourToPhrase", (object)estimateCommonMethodsItem.IsColourToPhrase), new SqlParameter("@SizeLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.SizeLabel)), new SqlParameter("@SizeValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Size)), new SqlParameter("@IsSizeTemplate", (object)estimateCommonMethodsItem.IsSizeTemplate), new SqlParameter("@IsSizeToPhrase", (object)estimateCommonMethodsItem.IsSizeToPhrase), new SqlParameter("@MaterialLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.MaterialLabel)), new SqlParameter("@MaterialValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Material)), new SqlParameter("@IsMaterialTemplate", (object)estimateCommonMethodsItem.IsMaterialTemplate), new SqlParameter("@IsMaterialToPhrase", (object)estimateCommonMethodsItem.IsMaterialToPhrase), new SqlParameter("@DeliveryLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.DeliveryLabel)), new SqlParameter("@DeliveryValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Delivery)), new SqlParameter("@IsDeliveryTemplate", (object)estimateCommonMethodsItem.IsDeliveryTemplate), new SqlParameter("@IsDeliveryToPhrase", (object)estimateCommonMethodsItem.IsDeliveryToPhrase), new SqlParameter("@FinishingLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.FinishingLabel)), new SqlParameter("@FinishingValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Finishing)), new SqlParameter("@IsFinishingTemplate", (object)estimateCommonMethodsItem.IsFinishingTemplate), new SqlParameter("@IsFinishingToPhrase", (object)estimateCommonMethodsItem.IsFinishingToPhrase), new SqlParameter("@ProofsLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.ProofsLabel)), new SqlParameter("@ProofsValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Proofs)), new SqlParameter("@IsProofsTemplate", (object)estimateCommonMethodsItem.IsProofsTemplate), new SqlParameter("@IsProofsToPhrase", (object)estimateCommonMethodsItem.IsProofsToPhrase), new SqlParameter("@PackingLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.PackingLabel)), new SqlParameter("@PackingValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Packing)), new SqlParameter("@IsPackingTemplate", (object)estimateCommonMethodsItem.IsPackingTemplate), new SqlParameter("@IsPackingToPhrase", (object)estimateCommonMethodsItem.IsPackingToPhrase), new SqlParameter("@NotesLabel", baseClass.SpecialEncode(estimateCommonMethodsItem.NotesLabel)), new SqlParameter("@NotesValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Notes)), new SqlParameter("@IsNotesTemplate", (object)estimateCommonMethodsItem.IsNotesTemplate), new SqlParameter("@InstructionsLabel ", baseClass.SpecialEncode(estimateCommonMethodsItem.InstructionsLabel)), new SqlParameter("@InstructionsValue", baseClass.SpecialEncode(estimateCommonMethodsItem.Instructions)), new SqlParameter("@IsInstructionsTemplate", (object)estimateCommonMethodsItem.IsInstructionsTemplate), new SqlParameter("@IsInstructionsToPhrase", (object)estimateCommonMethodsItem.IsInstructionsToPhrase), new SqlParameter("@CustomDescriptionLabel1", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel1)), new SqlParameter("@CustomDescription1", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription1)), new SqlParameter("@IsCustomDescription1Template", (object)estimateCommonMethodsItem.IsCustomDescription1Template), new SqlParameter("@IsCustomDescription1ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription1ToPhrase), new SqlParameter("@CustomDescriptionLabel2", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel2)), new SqlParameter("@CustomDescription2", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription2)), new SqlParameter("@IsCustomDescription2Template", (object)estimateCommonMethodsItem.IsCustomDescription2Template), new SqlParameter("@IsCustomDescription2ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription2ToPhrase), new SqlParameter("@CustomDescriptionLabel3", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel3)), new SqlParameter("@CustomDescription3", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription3)), new SqlParameter("@IsCustomDescription3Template", (object)estimateCommonMethodsItem.IsCustomDescription3Template), new SqlParameter("@IsCustomDescription3ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription3ToPhrase), new SqlParameter("@CustomDescriptionLabel4", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel4)), new SqlParameter("@CustomDescription4", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription4)), new SqlParameter("@IsCustomDescription4Template", (object)estimateCommonMethodsItem.IsCustomDescription4Template), new SqlParameter("@IsCustomDescription4ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription4ToPhrase), new SqlParameter("@CustomDescriptionLabel5", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel5)), new SqlParameter("@CustomDescription5", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription5)), new SqlParameter("@IsCustomDescription5Template", (object)estimateCommonMethodsItem.IsCustomDescription5Template), new SqlParameter("@IsCustomDescription5ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription5ToPhrase), new SqlParameter("@CustomDescriptionLabel6", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel6)), new SqlParameter("@CustomDescription6", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription6)), new SqlParameter("@IsCustomDescription6Template", (object)estimateCommonMethodsItem.IsCustomDescription6Template), new SqlParameter("@IsCustomDescription6ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription6ToPhrase), new SqlParameter("@CustomDescriptionLabel7", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel7)), new SqlParameter("@CustomDescription7", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription7)), new SqlParameter("@IsCustomDescription7Template", (object)estimateCommonMethodsItem.IsCustomDescription7Template), new SqlParameter("@IsCustomDescription7ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription7ToPhrase), new SqlParameter("@CustomDescriptionLabel8", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel8)), new SqlParameter("@CustomDescription8", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription8)), new SqlParameter("@IsCustomDescription8Template", (object)estimateCommonMethodsItem.IsCustomDescription8Template), new SqlParameter("@IsCustomDescription8ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription8ToPhrase), new SqlParameter("@CustomDescriptionLabel9", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel9)), new SqlParameter("@CustomDescription9", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription9)), new SqlParameter("@IsCustomDescription9Template", (object)estimateCommonMethodsItem.IsCustomDescription9Template), new SqlParameter("@IsCustomDescription9ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription9ToPhrase), new SqlParameter("@CustomDescriptionLabel10", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel10)), new SqlParameter("@CustomDescription10", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription10)), new SqlParameter("@IsCustomDescription10Template", (object)estimateCommonMethodsItem.IsCustomDescription10Template), new SqlParameter("@IsCustomDescription10ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription10ToPhrase), new SqlParameter("@CustomDescriptionLabel11", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel11)), new SqlParameter("@CustomDescription11", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription11)), new SqlParameter("@IsCustomDescription11Template", (object)estimateCommonMethodsItem.IsCustomDescription11Template), new SqlParameter("@IsCustomDescription11ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription11ToPhrase), new SqlParameter("@CustomDescriptionLabel12", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel12)), new SqlParameter("@CustomDescription12", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription12)), new SqlParameter("@IsCustomDescription12Template", (object)estimateCommonMethodsItem.IsCustomDescription12Template), new SqlParameter("@IsCustomDescription12ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription12ToPhrase), new SqlParameter("@CustomDescriptionLabel13", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel13)), new SqlParameter("@CustomDescription13", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription13)), new SqlParameter("@IsCustomDescription13Template", (object)estimateCommonMethodsItem.IsCustomDescription13Template), new SqlParameter("@IsCustomDescription13ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription13ToPhrase), new SqlParameter("@CustomDescriptionLabel14", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel14)), new SqlParameter("@CustomDescription14", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription14)), new SqlParameter("@IsCustomDescription14Template", (object)estimateCommonMethodsItem.IsCustomDescription14Template), new SqlParameter("@IsCustomDescription14ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription14ToPhrase), new SqlParameter("@CustomDescriptionLabel15", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel15)), new SqlParameter("@CustomDescription15", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription15)), new SqlParameter("@IsCustomDescription15Template", (object)estimateCommonMethodsItem.IsCustomDescription15Template), new SqlParameter("@IsCustomDescription15ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription15ToPhrase), new SqlParameter("@CustomDescriptionLabel16", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel16)), new SqlParameter("@CustomDescription16", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription16)), new SqlParameter("@IsCustomDescription16Template", (object)estimateCommonMethodsItem.IsCustomDescription16Template), new SqlParameter("@IsCustomDescription16ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription16ToPhrase), new SqlParameter("@CustomDescriptionLabel17", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel17)), new SqlParameter("@CustomDescription17", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription17)), new SqlParameter("@IsCustomDescription17Template", (object)estimateCommonMethodsItem.IsCustomDescription17Template), new SqlParameter("@IsCustomDescription17ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription17ToPhrase), new SqlParameter("@CustomDescriptionLabel18", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel18)), new SqlParameter("@CustomDescription18", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription18)), new SqlParameter("@IsCustomDescription18Template", (object)estimateCommonMethodsItem.IsCustomDescription18Template), new SqlParameter("@IsCustomDescription18ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription18ToPhrase), new SqlParameter("@CustomDescriptionLabel19", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel19)), new SqlParameter("@CustomDescription19", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription19)), new SqlParameter("@IsCustomDescription19Template", (object)estimateCommonMethodsItem.IsCustomDescription19Template), new SqlParameter("@IsCustomDescription19ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription19ToPhrase), new SqlParameter("@CustomDescriptionLabel20", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel20)), new SqlParameter("@CustomDescription20", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription20)), new SqlParameter("@IsCustomDescription20Template", (object)estimateCommonMethodsItem.IsCustomDescription20Template), new SqlParameter("@IsCustomDescription20ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription20ToPhrase), new SqlParameter("@CustomDescriptionLabel21", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel21)), new SqlParameter("@CustomDescription21", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription21)), new SqlParameter("@IsCustomDescription21Template", (object)estimateCommonMethodsItem.IsCustomDescription21Template), new SqlParameter("@IsCustomDescription21ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription21ToPhrase), new SqlParameter("@CustomDescriptionLabel22", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel22)), new SqlParameter("@CustomDescription22", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription22)), new SqlParameter("@IsCustomDescription22Template", (object)estimateCommonMethodsItem.IsCustomDescription22Template), new SqlParameter("@IsCustomDescription22ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription22ToPhrase), new SqlParameter("@CustomDescriptionLabel23", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel23)), new SqlParameter("@CustomDescription23", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription23)), new SqlParameter("@IsCustomDescription23Template", (object)estimateCommonMethodsItem.IsCustomDescription23Template), new SqlParameter("@IsCustomDescription23ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription23ToPhrase), new SqlParameter("@CustomDescriptionLabel24", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel24)), new SqlParameter("@CustomDescription24", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription24)), new SqlParameter("@IsCustomDescription24Template", (object)estimateCommonMethodsItem.IsCustomDescription24Template), new SqlParameter("@IsCustomDescription24ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription24ToPhrase), new SqlParameter("@CustomDescriptionLabel25", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescriptionLabel25)), new SqlParameter("@CustomDescription25", baseClass.SpecialEncode(estimateCommonMethodsItem.CustomDescription25)), new SqlParameter("@IsCustomDescription25Template", (object)estimateCommonMethodsItem.IsCustomDescription25Template), new SqlParameter("@IsCustomDescription25ToPhrase", (object)estimateCommonMethodsItem.IsCustomDescription25ToPhrase) };
		SqlParameter[] sqlParameterArray = sqlParameter;
		commonClass _commonClass = new commonClass();
		SQL.ExecuteNonQuery(_commonClass.strConnection, CommandType.StoredProcedure, "PC_ProofItemDescription_Update", sqlParameterArray);
	(new SummaryClass()).Insert_ActivityHistory_OnItemDescriptionUpdate(EstimateID, EstimateItemID, EstimateType, Module, itemTitle);
	}

	public static string GetCommonItemDescription_ForAllTypes(long EstimateItemID)
	{
		string empty = string.Empty;
		commonClass _commonClass = new commonClass();
		SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@EstimateItemID", (object)EstimateItemID) };
		DataSet dataSet = SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PC_EstItemDescription_Select_ForAllTypes", sqlParameter);
		foreach (DataRow row in dataSet.Tables[0].Rows)
		{
			object obj = empty;
			object[] item = new object[] { obj, row["DatabaseFieldName"], "»", row["ItemLabel"], "»", row["ItemValue"], "»", row["isChecked"], "µ" };
			empty = string.Concat(item);
		}
		return empty;
	}

	private static string GetPrintbrokerSplitValue(string[] parts, int index)
	{
		if (parts == null || index < 0 || index >= parts.Length || parts[index] == null)
		{
			return string.Empty;
		}
		return parts[index];
	}

	private static void getPrintbrokerdetailsfromprev(string Estimationtype, int CompanyID, long EstimateItemID, EstimateCommonMethodsItems objItems)
	{
		string empty = string.Empty;
		if (string.Compare(Estimationtype, "O", true) == 0)
		{
			try
			{
				empty = EstimatesBasePage.estimate_printbroker_itemdescription_select(CompanyID, EstimateItemID, "O", "Values");
				if (string.IsNullOrEmpty(empty))
				{
					return;
				}
				string[] strArrays = empty.Split(new char[] { '~' });
				objItems.ItemTitle = GetPrintbrokerSplitValue(strArrays, 0);
				objItems.Description = GetPrintbrokerSplitValue(strArrays, 1);
				objItems.Artwork = GetPrintbrokerSplitValue(strArrays, 2);
				objItems.Colour = GetPrintbrokerSplitValue(strArrays, 3);
				objItems.Size = GetPrintbrokerSplitValue(strArrays, 4);
				try
				{
					if (objItems.Size.ToString().IndexOf(".0") != -1)
					{
						string str = objItems.Size.ToString();
						char[] chrArray = new char[] { 'X' };
						string str1 = str.Split(chrArray)[0].ToString().Replace(".0000", "").Replace(".000", "").Replace(".00", "").Replace(".0", "");
						string str2 = objItems.Size.ToString();
						char[] chrArray1 = new char[] { 'X' };
						objItems.Size = string.Concat(str1, " x ", str2.Split(chrArray1)[1].ToString().Replace(".0000", "").Replace(".000", "").Replace(".00", "").Replace(".0", ""));
					}
				}
				catch
				{
					objItems.Size = GetPrintbrokerSplitValue(strArrays, 4);
				}
				objItems.Material = GetPrintbrokerSplitValue(strArrays, 5);
				objItems.Delivery = GetPrintbrokerSplitValue(strArrays, 6);
				objItems.Finishing = GetPrintbrokerSplitValue(strArrays, 7);
				objItems.Proofs = GetPrintbrokerSplitValue(strArrays, 8);
				objItems.Packing = GetPrintbrokerSplitValue(strArrays, 9);
				objItems.Notes = GetPrintbrokerSplitValue(strArrays, 10);
				objItems.Instructions = GetPrintbrokerSplitValue(strArrays, 11);
				objItems.CustomDescription1 = GetPrintbrokerSplitValue(strArrays, 12);
				objItems.CustomDescription2 = GetPrintbrokerSplitValue(strArrays, 13);
				objItems.CustomDescription3 = GetPrintbrokerSplitValue(strArrays, 14);
				objItems.CustomDescription4 = GetPrintbrokerSplitValue(strArrays, 15);
				objItems.CustomDescription5 = GetPrintbrokerSplitValue(strArrays, 16);
				objItems.CustomDescription6 = GetPrintbrokerSplitValue(strArrays, 17);
				objItems.CustomDescription7 = GetPrintbrokerSplitValue(strArrays, 18);
				objItems.CustomDescription8 = GetPrintbrokerSplitValue(strArrays, 19);
				objItems.CustomDescription9 = GetPrintbrokerSplitValue(strArrays, 20);
				objItems.CustomDescription10 = GetPrintbrokerSplitValue(strArrays, 21);
				objItems.CustomDescription11 = GetPrintbrokerSplitValue(strArrays, 22);
				objItems.CustomDescription12 = GetPrintbrokerSplitValue(strArrays, 23);
				objItems.CustomDescription13 = GetPrintbrokerSplitValue(strArrays, 24);
				objItems.CustomDescription14 = GetPrintbrokerSplitValue(strArrays, 25);
				objItems.CustomDescription15 = GetPrintbrokerSplitValue(strArrays, 26);
				objItems.CustomDescription16 = GetPrintbrokerSplitValue(strArrays, 27);
				objItems.CustomDescription17 = GetPrintbrokerSplitValue(strArrays, 28);
				objItems.CustomDescription18 = GetPrintbrokerSplitValue(strArrays, 29);
				objItems.CustomDescription19 = GetPrintbrokerSplitValue(strArrays, 30);
				objItems.CustomDescription20 = GetPrintbrokerSplitValue(strArrays, 31);
				objItems.CustomDescription21 = GetPrintbrokerSplitValue(strArrays, 32);
				objItems.CustomDescription22 = GetPrintbrokerSplitValue(strArrays, 33);
				objItems.CustomDescription23 = GetPrintbrokerSplitValue(strArrays, 34);
				objItems.CustomDescription24 = GetPrintbrokerSplitValue(strArrays, 35);
				objItems.CustomDescription25 = GetPrintbrokerSplitValue(strArrays, 36);
			}
			catch
			{
			}
		}
		if (string.Compare(Estimationtype, "C", true) == 0)
		{
			try
			{
				foreach (DataRow row in EstimateCommonMethods.PC_Pricecatalogue_Description_Select_Reeng(EstimateItemID).Rows)
				{
					empty = row["ItemDescription"].ToString();
				}
				if (empty.Trim().Length > 0)
				{
					string[] strArrays1 = empty.ToString().Split(new char[] { 'µ' });
					for (int i = 0; i < (int)strArrays1.Length; i++)
					{
						string[] strArrays2 = strArrays1[i].ToString().Split(new char[] { '»' });
						if ((int)strArrays2.Length > 3)
						{
							if (string.Compare(strArrays2[0], "ItemTitle", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0 && !objItems.ItemTitle.Contains("<br/>"))
								{
									objItems.ItemTitle = strArrays2[2].ToString().Replace("\r\n", "<br/>");
								}
							}
							else if (string.Compare(strArrays2[0], "Description", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.Description = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Artwork", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.Artwork = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Colour", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.Colour = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Size", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.Size = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Material", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.Material = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Delivery", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.Delivery = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Finishing", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.Finishing = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Proofs", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.Proofs = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Packing", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.Packing = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Notes", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.Notes = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Instructions", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.Instructions = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 1", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription1 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 2", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription2 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 3", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription3 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 4", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription4 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 5", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription5 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 6", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription6 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 7", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription7 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 8", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription8 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 9", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription9 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 10", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription10 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 11", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription11 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 12", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription12 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 13", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription13 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 14", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription14 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 15", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription15 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 16", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription16 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 17", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription17 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 18", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription18 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 19", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription19 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 20", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription20 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 21", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription21 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 22", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription22 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 23", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription23 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 24", true) == 0)
							{
								if (strArrays2[2].ToString().Trim().Length > 0)
								{
									objItems.CustomDescription24 = strArrays2[2].ToString();
								}
							}
							else if (string.Compare(strArrays2[0], "Custom Description 25", true) == 0 && strArrays2[2].ToString().Trim().Length > 0)
							{
								objItems.CustomDescription25 = strArrays2[2].ToString();
							}
						}
					}
				}
			}
			catch
			{
			}
		}
	}

	public static void insert_UpdatePriceCatalogueQty(long PriceCatalogueID, long EstimateID, long EstimateItemID, string Estimatetype, int isAddNew)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_insert_UpdatePriceCatalogueQty");
		database.AddInParameter(storedProcCommand, "@PriceCatalogueID", DbType.Int64, PriceCatalogueID);
		database.AddInParameter(storedProcCommand, "@EstimateID", DbType.Int64, EstimateID);
		database.AddInParameter(storedProcCommand, "@EstimateitemID", DbType.Int64, EstimateItemID);
		database.AddInParameter(storedProcCommand, "@estimatetype", DbType.String, Estimatetype);
		database.AddInParameter(storedProcCommand, "@chkAddNew", DbType.Int16, isAddNew);
		database.ExecuteNonQuery(storedProcCommand);
	}

	public static string MakeCompleteLinkBlankIfEndsWithColon(string ToReplace)
	{
		string[] strArrays = new string[] { "\r\n" };
		string[] strArrays1 = ToReplace.Split(strArrays, StringSplitOptions.None);
		string empty = string.Empty;
		for (int i = 0; i < (int)strArrays1.Length; i++)
		{
			empty = (strArrays1[i].Trim().ToLower().Replace("\n", "") == "side2:" || strArrays1[i].Trim().ToLower().Replace("\n", "") == "side2 :" || strArrays1[i].Trim().ToLower().Replace("\n", "") == "othercost name:" || strArrays1[i].Trim().ToLower().Replace("\n", "") == "othercost name :" || strArrays1[i].Trim().ToLower().Replace("\n", "") == "othercost:" || strArrays1[i].Trim().ToLower().Replace("\n", "") == "othercost :" || strArrays1[i].Trim().ToLower().Replace("\n", "") == "othercost :" || strArrays1[i].Trim().ToLower().Replace("\n", "") == "description:" || strArrays1[i].Trim().ToLower().Replace("\n", "") == "description :" ? string.Concat(empty, strArrays[0].ToString()) : string.Concat(empty, strArrays1[i], strArrays[0].ToString()));
		}
		return empty;
	}

	public static DataTable PC_Pricecatalogue_Description_Select_Reeng(long EstimateItemID)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DataTable dataTable = new DataTable();
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_Pricecatalogue_Description_Select_Reeng");
		database.AddInParameter(storedProcCommand, "@EstimateItemID", DbType.Int64, EstimateItemID);
		using (IDataReader dataReader = database.ExecuteReader(storedProcCommand))
		{
			dataTable.Load(dataReader);
		}
		return dataTable;
	}

	public static void PCR_FormulaTags_Replace(long EstimateItemID, string Estimatetype)
	{
		Database database = CustomDatabaseFactory.CreateDatabase((new commonClass()).strConnection);
		DbCommand storedProcCommand = database.GetStoredProcCommand("PC_FormulaTags_Replace");
		database.AddInParameter(storedProcCommand, "@Estimateitemid", DbType.Int64, EstimateItemID);
		database.AddInParameter(storedProcCommand, "@estimatetype", DbType.String, Estimatetype);
		database.ExecuteNonQuery(storedProcCommand);
	}

	public static string RemoveSpecialChar(string ToReplace)
	{
		string[] strArrays = new string[] { "\n" };
		string[] strArrays1 = ToReplace.Split(strArrays, StringSplitOptions.None);
		string empty = string.Empty;
		for (int i = 0; i < (int)strArrays1.Length; i++)
		{
			if (strArrays1[i].Trim().IndexOf(":") == -1)
			{
				empty = string.Concat(empty, strArrays1[i], strArrays[0].ToString());
			}
			else if (strArrays1[i].Replace(":", "").Trim().Length > 0)
			{
				empty = string.Concat(empty, strArrays1[i], strArrays[0].ToString());
			}
		}
		return EstimateCommonMethods.MakeCompleteLinkBlankIfEndsWithColon(empty);
	}

	//public static void ShowDescriptionOnSummary(string pgType, int CompanyID, long ModuleID, long EstimateItemID, PlaceHolder plh, string itemTitle, string Isfromactivityhist, Boolean IsLocking=false)
	//{
	//	BaseClass baseClass = new BaseClass();
	//	string str = global.strimagepath;
	//	string empty = string.Empty;
	//	string empty1 = string.Empty;
	//	bool flag = false;
	//	bool flag1 = false;
	//	string str1 = "visibility:visible;";
	//	string empty2 = string.Empty;
	//	string str2 = string.Empty;
	//	Convert.ToInt32(HttpContext.Current.Session["UserID"]);
	//	languageClass _languageClass = new languageClass();
	//	commonClass _commonClass = new commonClass();
	//	SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID) };
	//	DataSet dataSet = SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PC_EstItemDescription_View", sqlParameter);
	//	foreach (DataRow row in dataSet.Tables[0].Rows)
	//	{
	//		flag = Convert.ToBoolean(row["HasPurchaseOrder"]);
	//		flag1 = Convert.ToBoolean(row["HasDeliveryNote"]);
	//	}
	//	foreach (DataRow dataRow in dataSet.Tables[1].Rows)
	//	{
	//		empty1 = Convert.ToString(dataRow["EstimateType"]);
	//	}
	//	foreach (DataRow row1 in dataSet.Tables[3].Rows)
	//	{
	//		empty2 = row1["SalesPersonID"].ToString();
	//	}
	//	plh.Controls.Add(new LiteralControl(string.Concat("<table cellpadding='0' cellspacing='0' align='center' id='tblDescription", EstimateItemID.ToString(), "' width='430px'   border='0'>")));
	//	plh.Controls.Add(new LiteralControl("<tr>"));
	//	plh.Controls.Add(new LiteralControl("<td valign='top' align='left' height='25px' >"));
	//	plh.Controls.Add(new LiteralControl("<div align='left' style='padding-top:15px;' >"));
	//	plh.Controls.Add(new LiteralControl(string.Concat("<b>&nbsp;&nbsp;", _languageClass.GetLanguageConversion("Customer_Item_Descriptions"), "</b> ")));
	//	plh.Controls.Add(new LiteralControl("</div>"));
	//	plh.Controls.Add(new LiteralControl("<div  align='right'>"));
	//	ControlCollection controls = plh.Controls;
	//	string[] languageConversion = new string[] { "<img style='margin-top: -15px; padding-bottom: 10px;' alt='Img' title='", _languageClass.GetLanguageConversion("Save_Phrase_Book"), "'  Class='book_icon' src='", str, "book.png'  />" };
	//	controls.Add(new LiteralControl(string.Concat(languageConversion)));
	//	plh.Controls.Add(new LiteralControl("</div >"));
	//	plh.Controls.Add(new LiteralControl("</td>"));
	//	plh.Controls.Add(new LiteralControl("</tr>"));
	//	plh.Controls.Add(new LiteralControl("<tr valign='top'>"));
	//	plh.Controls.Add(new LiteralControl("<td align='left' valign='top'>"));
	//	if (empty1 != "O")
	//	{
	//		plh.Controls.Add(new LiteralControl("<div style=' border:0px solid red;vertical-align:top; height:auto'>"));
	//	}
	//	else
	//	{
	//		plh.Controls.Add(new LiteralControl("<div style=' border:0px solid green; height:auto vertical-align:top'>"));
	//	}
	//	plh.Controls.Add(new LiteralControl(string.Concat("<table valign='top' cellpadding='0' cellspacing='3' align='center' id='tblDescription_nat", EstimateItemID.ToString(), "' width='450px'  border='0'>")));
	//	if (Isfromactivityhist.ToLower() == "yes")
	//	{
	//		str1 = "visibility:hidden;";
	//	}

	//       //var locking = objBase.ReturnRoles_Privileges_Others("locking").ToLower();
	//       //var IsJobLocked = EstimatesBasePage.PC_select_JobLocking_Status(jobID);

	//       foreach (DataRow dataRow1 in dataSet.Tables[2].Rows)
	//	{
	//		plh.Controls.Add(new LiteralControl("<tr valign='top'>"));
	//		plh.Controls.Add(new LiteralControl("<td align='center' valign='top'  style='width:'10px'>"));
	//		string str3 = string.Concat("chk_", EstimateItemID.ToString(), "_", dataRow1["FieldName"].ToString());
	//		if (Isfromactivityhist.ToLower() != "yes" || !IsLocking)
	//		{
	//			ControlCollection controlCollections = plh.Controls;
	//			string[] strArrays = new string[] { "<input id='", str3, "'  type='checkbox' ", dataRow1["isFromTemplate"].ToString(), "/>" };
	//			controlCollections.Add(new LiteralControl(string.Concat(strArrays)));
	//		}
	//		else
	//		{
	//			ControlCollection controls1 = plh.Controls;
	//			string[] strArrays1 = new string[] { "<input id='", str3, "' disabled='disabled'  type='checkbox' ", dataRow1["isFromTemplate"].ToString(), "/>" };
	//			controls1.Add(new LiteralControl(string.Concat(strArrays1)));
	//		}
	//		plh.Controls.Add(new LiteralControl("</td>"));
	//		plh.Controls.Add(new LiteralControl("<td valign='top' style='width='100%;'>"));
	//		object[] estimateItemID = new object[] { "txtlabel_", EstimateItemID, "_", dataRow1["FieldName"].ToString() };
	//		string str4 = string.Concat(estimateItemID);
	//           if ( !IsLocking)
	//           {
	//               ControlCollection controlCollections1 = plh.Controls;
	//               string[] strArrays2 = new string[] { "<textarea  rows='0' cols='20'   id='", str4, "'   style='width:145px; height:20px; resize: none;' class='textboxnew'>", baseClass.SpecialDecode(dataRow1["Itemlabel"].ToString()), "</textarea>" };
	//               controlCollections1.Add(new LiteralControl(string.Concat(strArrays2)));
	//           }
	//           else
	//           {
	//               ControlCollection controlCollections1 = plh.Controls;
	//               string[] strArrays2 = new string[] { "<textarea  rows='0' cols='20' disabled='disabled'   id='", str4, "'   style='width:145px; height:20px; resize: none;' class='textboxnew'>", baseClass.SpecialDecode(dataRow1["Itemlabel"].ToString()), "</textarea>" };
	//               controlCollections1.Add(new LiteralControl(string.Concat(strArrays2)));
	//           }
	//		plh.Controls.Add(new LiteralControl("</td>"));
	//		plh.Controls.Add(new LiteralControl("<td valign='top' style='float:left;width:17px; cursor:pointer; ' >"));
	//		object[] objArray = new object[] { "txt_", EstimateItemID, "_", dataRow1["FieldName"].ToString() };
	//		string str5 = string.Concat(objArray);
	//		ControlCollection controls2 = plh.Controls;
	//		object[] estimateItemID1 = new object[] { "<img src='", str, "plus.gif' style='", str1, "'  id='ImgPhrase_", EstimateItemID, "_", dataRow1["FieldName"].ToString(), "' onclick=\"javascript:OpenPhraseBook('", dataRow1["PhraseType"].ToString(), "','", str5, "','", ModuleID, "','", dataRow1["PhraseValue"].ToString(), "');return false;\"/>" };
	//		controls2.Add(new LiteralControl(string.Concat(estimateItemID1)));
	//		plh.Controls.Add(new LiteralControl("</td>"));
	//		plh.Controls.Add(new LiteralControl("<td valign='top'>"));
	//           if (!IsLocking)
	//           {
	//               ControlCollection controlCollections2 = plh.Controls;
	//               object[] objArray1 = new object[] { "<textarea class='textboxnewmulti' style='width:225px;' rows='1' cols='35' id='txt_", EstimateItemID, "_", dataRow1["FieldName"].ToString(), "' title='", baseClass.SpecialDecode(dataRow1["ItemValue"].ToString().Replace("<br/>", "\n").Replace("=", "&equals")), "' >", baseClass.SpecialDecode(dataRow1["ItemValue"].ToString().Replace("'", "`").Replace("<br/>", "\n")), "</textarea>" };
	//               controlCollections2.Add(new LiteralControl(string.Concat(objArray1)));
	//           }
	//           else
	//           {
	//               ControlCollection controlCollections2 = plh.Controls;
	//               object[] objArray1 = new object[] { "<textarea class='textboxnewmulti' style='width:225px;' rows='1' cols='35' disabled='disabled' id='txt_", EstimateItemID, "_", dataRow1["FieldName"].ToString(), "' title='", baseClass.SpecialDecode(dataRow1["ItemValue"].ToString().Replace("<br/>", "\n").Replace("=", "&equals")), "' >", baseClass.SpecialDecode(dataRow1["ItemValue"].ToString().Replace("'", "`").Replace("<br/>", "\n")), "</textarea>" };
	//               controlCollections2.Add(new LiteralControl(string.Concat(objArray1)));
	//           }
	//		plh.Controls.Add(new LiteralControl("</td>"));
	//		plh.Controls.Add(new LiteralControl("<td>"));
	//		string str6 = string.Concat("chk_toPhrase_", EstimateItemID.ToString(), "_", dataRow1["PhraseValue"].ToString());
	//		if (Isfromactivityhist.ToLower() != "yes")
	//		{
	//			plh.Controls.Add(new LiteralControl(string.Concat("<input id=", str6, " style='margin-left:-2px;' type='checkbox'/>")));
	//		}
	//		else
	//		{
	//			plh.Controls.Add(new LiteralControl(string.Concat("<input id=", str6, "  type='checkbox' style='margin-left:-2px;' disabled='disabled'/>")));
	//		}
	//		plh.Controls.Add(new LiteralControl("</td>"));
	//		plh.Controls.Add(new LiteralControl("</tr>"));
	//		object obj = empty;
	//		object[] objArray2 = new object[] { obj, dataRow1["PhraseValue"].ToString(), '£', str3, '\u00B6', str4, '$', str5, '€', str6, 'µ' };
	//		empty = string.Concat(objArray2);
	//	}
	//	plh.Controls.Add(new LiteralControl("<tr>"));
	//	plh.Controls.Add(new LiteralControl("<td align='center' valign='top'  style='width:'10px'>"));
	//	plh.Controls.Add(new LiteralControl("</td>"));
	//	plh.Controls.Add(new LiteralControl("<td valign='top' style='width:'132px; padding-left:5px;  padding-top:20px;'>"));
	//	plh.Controls.Add(new LiteralControl(string.Concat("<div style='padding-top:10px;'>", _languageClass.GetLanguageConversion("Accounting_Code"), "</div>")));
	//	plh.Controls.Add(new LiteralControl("</td>"));
	//	plh.Controls.Add(new LiteralControl("<td valign='top' style='float:left;width:17px; cursor:pointer; ' >"));
	//	plh.Controls.Add(new LiteralControl("</td>"));
	//	plh.Controls.Add(new LiteralControl("<td valign='top' style='width:'40%;'>"));
	//	DataTable dataTable = new DataTable();
	//	DataTable dataTable1 = new DataTable();
	//	dataTable = Settings.Setting_accountingCode_SelectAllRevenueCode(CompanyID);
	//	dataTable1 = EstimatesBasePage.Select_AccountingCode_For_Summary(CompanyID, EstimateItemID, empty1, ModuleID);
	//	plh.Controls.Add(new LiteralControl("<div style='width:'100%;'>"));
	//	DropDownList dropDownList = new DropDownList()
	//	{
	//		DataSource = dataTable,
	//		ID = string.Concat("ddlAc_Code_", EstimateItemID),
	//		DataValueField = "AccountCodeID",
	//		DataTextField = "Code"
	//	};
	//	AttributeCollection attributes = dropDownList.Attributes;
	//	object[] companyID = new object[] { "javascript:SaveAccountingcode('", CompanyID, "','", EstimateItemID, "', '", empty1, "',this.value)" };
	//	attributes.Add("onchange", string.Concat(companyID));
	//	dropDownList.DataBind();
	//	if (dataTable1.Rows.Count <= 0)
	//	{
	//		dropDownList.Items.Insert(0, new ListItem("---Select---", "Select"));
	//		dropDownList.SelectedIndex = 0;
	//	}
	//	else
	//	{
	//		baseClass.SetDDLValue(dropDownList, dataTable1.Rows[0]["AccountCodeID"].ToString());
	//	}
	//	dropDownList.Style.Add("width", "98%");
	//	dropDownList.Style.Add("margin-top", "10px");
	//	plh.Controls.Add(dropDownList);
	//	plh.Controls.Add(new LiteralControl("</div>"));
	//	plh.Controls.Add(new LiteralControl("</div>"));
	//	plh.Controls.Add(new LiteralControl("</td>"));
	//	plh.Controls.Add(new LiteralControl("<td>"));
	//	plh.Controls.Add(new LiteralControl("</td>"));
	//	plh.Controls.Add(new LiteralControl("</tr>"));
	//	plh.Controls.Add(new LiteralControl("</table>"));
	//	plh.Controls.Add(new LiteralControl("<tr valign='top'>"));
	//	if (empty1 == "O")
	//	{
	//		plh.Controls.Add(new LiteralControl("<td valign='top'>"));
	//		plh.Controls.Add(new LiteralControl("<div style='padding:10px 0px 0px 9px; border:0px solid green;'>"));
	//		plh.Controls.Add(new LiteralControl("<span> Copy the item description fields above to:</span>"));
	//		plh.Controls.Add(new LiteralControl("<div  style='padding:4px 0px 0px 0px;'>"));

	//           //Rertieve the settings as 
	//           string IsCopyOutworkDescFieldsToSupplier = "";
	//           foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(CompanyID).Rows)
	//           {
	//               if (Convert.ToBoolean(row["CopyOutworkDescFieldsToSupplier"]))
	//               {
	//                   IsCopyOutworkDescFieldsToSupplier = " checked='checked'";
	//               }
	//           }

	//               plh.Controls.Add(new LiteralControl(string.Concat("<input id='ChkboxCopy_Supplier_", EstimateItemID, "' type='checkbox' " + IsCopyOutworkDescFieldsToSupplier + " /><span>  Supplier request for quote item description fields</span>")));
	//		plh.Controls.Add(new LiteralControl("</div>"));
	//		if (pgType.ToLower() == "job")
	//		{
	//			if (flag)
	//			{
	//				plh.Controls.Add(new LiteralControl("<div >"));
	//				plh.Controls.Add(new LiteralControl(string.Concat("<input id='ChkboxCopy_PO_", EstimateItemID, "' type='checkbox' checked='true' /><span>  Purchase order item description fields</span>")));
	//				plh.Controls.Add(new LiteralControl("</div>"));
	//			}
	//			if (flag1)
	//			{
	//				plh.Controls.Add(new LiteralControl("<div >"));
	//				plh.Controls.Add(new LiteralControl(string.Concat("<input id='ChkboxCopy_DN_", EstimateItemID, "' type='checkbox' checked='true' /><span>  Delivery note item description fields</span>")));
	//				plh.Controls.Add(new LiteralControl("</div>"));
	//			}
	//		}
	//		plh.Controls.Add(new LiteralControl("</div>"));
	//		plh.Controls.Add(new LiteralControl("</td>"));
	//		plh.Controls.Add(new LiteralControl("</tr>"));
	//	}
	//	str2 = (new BaseClass()).ReturnRoles_Privileges_Others("editrecords");
	//	if (Isfromactivityhist.ToLower() != "yes")
	//	{
	//		plh.Controls.Add(new LiteralControl("<tr>"));
	//		plh.Controls.Add(new LiteralControl("<td valign='top' align='right' style=' border:0px solid green; padding-right:37px;padding-top:5px'>"));
	//		if (str2.ToLower() != "his")
	//		{
	//			ControlCollection controls3 = plh.Controls;
	//			object[] estimateItemID2 = new object[] { "<input type='submit' style='display:none' id='Button_", EstimateItemID, "' value='", _languageClass.GetLanguageConversion("Update"), "' class='button' onclick=\"javascript:UpdateItemDescription('", ModuleID, "','", EstimateItemID, "','", empty, "','", empty1, "', '", pgType, "','", flag, "','", flag1, "','", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "');return false;\" /> " };
	//			controls3.Add(new LiteralControl(string.Concat(estimateItemID2)));
	//			ControlCollection controlCollections3 = plh.Controls;
	//			object[] estimateItemID3 = new object[] { "<input type='hidden' style='display:none' id='hdnDescButton_", EstimateItemID, "' value=\"", ModuleID, "▬", EstimateItemID, "▬", empty, "▬", empty1, "▬", pgType, "▬", flag, "▬", flag1, "▬", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "\" /> " };
	//			controlCollections3.Add(new LiteralControl(string.Concat(estimateItemID3)));
	//		}
	//		else if (HttpContext.Current.Session["UserID"].ToString() != empty2)
	//		{
	//			ControlCollection controls4 = plh.Controls;
	//			object[] objArray3 = new object[] { "<input style='display:none' type='submit' id='Button_", EstimateItemID, "' value='", _languageClass.GetLanguageConversion("Update"), "' class='button' onclick=\"javascript:UpdateItemDescription('", ModuleID, "','", EstimateItemID, "','", empty, "','", empty1, "', '", pgType, "','", flag, "','", flag1, "','", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "');return false;\" /> " };
	//			controls4.Add(new LiteralControl(string.Concat(objArray3)));
	//			ControlCollection controlCollections4 = plh.Controls;
	//			object[] estimateItemID4 = new object[] { "<input style='display:none' type='hidden' id='hdnDescButton_", EstimateItemID, "' value=\"", ModuleID, "▬", EstimateItemID, "▬", empty, "▬", empty1, "▬", pgType, "▬", flag, "▬", flag1, "▬", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "\" /> " };
	//			controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID4)));
	//		}
	//		else
	//		{
	//			ControlCollection controls5 = plh.Controls;
	//			object[] objArray4 = new object[] { "<input  type='submit' style='display:none' id='Button_", EstimateItemID, "' value='", _languageClass.GetLanguageConversion("Update"), "' class='button' onclick=\"javascript:UpdateItemDescription('", ModuleID, "','", EstimateItemID, "','", empty, "','", empty1, "', '", pgType, "','", flag, "','", flag1, "','", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "');return false;\" /> " };
	//			controls5.Add(new LiteralControl(string.Concat(objArray4)));
	//			ControlCollection controlCollections5 = plh.Controls;
	//			object[] estimateItemID5 = new object[] { "<input  type='hidden' style='display:none' id='hdnDescButton_", EstimateItemID, "' value=\"", ModuleID, "▬", EstimateItemID, "▬", empty, "▬", empty1, "▬", pgType, "▬", flag, "▬", flag1, "▬", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "\" /> " };
	//			controlCollections5.Add(new LiteralControl(string.Concat(estimateItemID5)));
	//		}
	//		plh.Controls.Add(new LiteralControl("</td>"));
	//		plh.Controls.Add(new LiteralControl("</tr>"));
	//	}
	//	plh.Controls.Add(new LiteralControl("</table>"));
	//}
	public static void ShowDescriptionOnSummary(string pgType, int CompanyID, long ModuleID, long EstimateItemID, PlaceHolder plh, string itemTitle, string Isfromactivityhist, Boolean IsLocking = false)
	{
		BaseClass baseClass = new BaseClass();
		string str = global.strimagepath;
		string empty = string.Empty;
		string empty1 = string.Empty;
		bool flag = false;
		bool flag1 = false;
		string str1 = "visibility:visible;";
		string empty2 = string.Empty;
		string str2 = string.Empty;
		Convert.ToInt32(HttpContext.Current.Session["UserID"]);
		languageClass _languageClass = new languageClass();
		commonClass _commonClass = new commonClass();
		SqlParameter[] sqlParameter = new SqlParameter[] { new SqlParameter("@CompanyID", (object)CompanyID), new SqlParameter("@EstimateItemID", (object)EstimateItemID) };
		DataSet dataSet = SQL.ExecuteDataset(_commonClass.strConnection, CommandType.StoredProcedure, "PC_EstItemDescription_View", sqlParameter);
		foreach (DataRow row in dataSet.Tables[0].Rows)
		{
			flag = Convert.ToBoolean(row["HasPurchaseOrder"]);
			flag1 = Convert.ToBoolean(row["HasDeliveryNote"]);
		}
		foreach (DataRow dataRow in dataSet.Tables[1].Rows)
		{
			empty1 = Convert.ToString(dataRow["EstimateType"]);
		}
		foreach (DataRow row1 in dataSet.Tables[3].Rows)
		{
			empty2 = row1["SalesPersonID"].ToString();
		}
		plh.Controls.Add(new LiteralControl(string.Concat("<table cellpadding='0' cellspacing='0' align='center' id='tblDescription", EstimateItemID.ToString(), "' width='430px'   border='0'>")));
		plh.Controls.Add(new LiteralControl("<tr>"));
		plh.Controls.Add(new LiteralControl("<td valign='top' align='left' height='25px' >"));
		plh.Controls.Add(new LiteralControl("<div align='left' style='padding-top:15px;' >"));
		plh.Controls.Add(new LiteralControl(string.Concat("<b>&nbsp;&nbsp;", _languageClass.GetLanguageConversion("Customer_Item_Descriptions"), "</b> ")));
		plh.Controls.Add(new LiteralControl("</div>"));
		plh.Controls.Add(new LiteralControl("<div  align='right'>"));
		ControlCollection controls = plh.Controls;
		string[] languageConversion = new string[] { "<img style='margin-top: -15px; padding-bottom: 10px;' alt='Img' title='", _languageClass.GetLanguageConversion("Save_Phrase_Book"), "'  Class='book_icon' src='", str, "book.png'  />" };
		controls.Add(new LiteralControl(string.Concat(languageConversion)));
		plh.Controls.Add(new LiteralControl("</div >"));
		plh.Controls.Add(new LiteralControl("</td>"));
		plh.Controls.Add(new LiteralControl("</tr>"));
		plh.Controls.Add(new LiteralControl("<tr valign='top'>"));
		plh.Controls.Add(new LiteralControl("<td align='left' valign='top'>"));
		if (empty1 != "O")
		{
			plh.Controls.Add(new LiteralControl("<div style=' border:0px solid red;vertical-align:top; height:auto'>"));
		}
		else
		{
			plh.Controls.Add(new LiteralControl("<div style=' border:0px solid green; height:auto vertical-align:top'>"));
		}
		plh.Controls.Add(new LiteralControl(string.Concat("<table valign='top' cellpadding='0' cellspacing='3' align='center' id='tblDescription_nat", EstimateItemID.ToString(), "' width='450px'  border='0'>")));
		if (Isfromactivityhist.ToLower() == "yes")
		{
			str1 = "visibility:hidden;";
		}

		//var locking = objBase.ReturnRoles_Privileges_Others("locking").ToLower();
		//var IsJobLocked = EstimatesBasePage.PC_select_JobLocking_Status(jobID);

		foreach (DataRow dataRow1 in dataSet.Tables[2].Rows)
		{
			plh.Controls.Add(new LiteralControl("<tr valign='top'>"));
			plh.Controls.Add(new LiteralControl("<td align='center' valign='top'  style='width:'10px'>"));
			string str3 = string.Concat("chk_", EstimateItemID.ToString(), "_", dataRow1["FieldName"].ToString());
			if (Isfromactivityhist.ToLower() != "yes" || !IsLocking)
			{
				ControlCollection controlCollections = plh.Controls;
				string[] strArrays = new string[] { "<input id='", str3, "'  type='checkbox' ", dataRow1["isFromTemplate"].ToString(), "/>" };
				controlCollections.Add(new LiteralControl(string.Concat(strArrays)));
			}
			else
			{
				ControlCollection controls1 = plh.Controls;
				string[] strArrays1 = new string[] { "<input id='", str3, "' disabled='disabled'  type='checkbox' ", dataRow1["isFromTemplate"].ToString(), "/>" };
				controls1.Add(new LiteralControl(string.Concat(strArrays1)));
			}
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("<td valign='top' style='width='100%;'>"));
			object[] estimateItemID = new object[] { "txtlabel_", EstimateItemID, "_", dataRow1["FieldName"].ToString() };
			string str4 = string.Concat(estimateItemID);
			if (!IsLocking)
			{
				ControlCollection controlCollections1 = plh.Controls;
				string[] strArrays2 = new string[] { "<textarea  rows='0' cols='20'   id='", str4, "'   style='width:145px; height:20px; resize: none;' class='textboxnew'>", baseClass.SpecialDecode(dataRow1["Itemlabel"].ToString()), "</textarea>" };
				controlCollections1.Add(new LiteralControl(string.Concat(strArrays2)));
			}
			else
			{
				ControlCollection controlCollections1 = plh.Controls;
				string[] strArrays2 = new string[] { "<textarea  rows='0' cols='20' disabled='disabled'   id='", str4, "'   style='width:145px; height:20px; resize: none;' class='textboxnew'>", baseClass.SpecialDecode(dataRow1["Itemlabel"].ToString()), "</textarea>" };
				controlCollections1.Add(new LiteralControl(string.Concat(strArrays2)));
			}
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("<td valign='top' style='float:left;width:17px; cursor:pointer; ' >"));
			object[] objArray = new object[] { "txt_", EstimateItemID, "_", dataRow1["FieldName"].ToString() };
			string str5 = string.Concat(objArray);
			ControlCollection controls2 = plh.Controls;
			object[] estimateItemID1 = new object[] { "<img src='", str, "plus.gif' style='", str1, "'  id='ImgPhrase_", EstimateItemID, "_", dataRow1["FieldName"].ToString(), "' onclick=\"javascript:OpenPhraseBook('", dataRow1["PhraseType"].ToString(), "','", str5, "','", ModuleID, "','", dataRow1["PhraseValue"].ToString(), "');return false;\"/>" };
			controls2.Add(new LiteralControl(string.Concat(estimateItemID1)));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("<td valign='top'>"));
			if (!IsLocking)
			{
				ControlCollection controlCollections2 = plh.Controls;
				object[] objArray1 = new object[] { "<textarea class='textboxnewmulti' style='width:225px;' rows='1' cols='35' id='txt_", EstimateItemID, "_", dataRow1["FieldName"].ToString(), "' title='", baseClass.SpecialDecode(dataRow1["ItemValue"].ToString().Replace("<br/>", "\n").Replace("=", "&equals")), "' >", baseClass.SpecialDecode(dataRow1["ItemValue"].ToString().Replace("'", "`").Replace("<br/>", "\n")), "</textarea>" };
				controlCollections2.Add(new LiteralControl(string.Concat(objArray1)));
			}
			else
			{
				ControlCollection controlCollections2 = plh.Controls;
				object[] objArray1 = new object[] { "<textarea class='textboxnewmulti' style='width:225px;' rows='1' cols='35' disabled='disabled' id='txt_", EstimateItemID, "_", dataRow1["FieldName"].ToString(), "' title='", baseClass.SpecialDecode(dataRow1["ItemValue"].ToString().Replace("<br/>", "\n").Replace("=", "&equals")), "' >", baseClass.SpecialDecode(dataRow1["ItemValue"].ToString().Replace("'", "`").Replace("<br/>", "\n")), "</textarea>" };
				controlCollections2.Add(new LiteralControl(string.Concat(objArray1)));
			}
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("<td>"));
			string str6 = string.Concat("chk_toPhrase_", EstimateItemID.ToString(), "_", dataRow1["PhraseValue"].ToString());
			if (Isfromactivityhist.ToLower() != "yes")
			{
				plh.Controls.Add(new LiteralControl(string.Concat("<input id=", str6, " style='margin-left:-2px;' type='checkbox'/>")));
			}
			else
			{
				plh.Controls.Add(new LiteralControl(string.Concat("<input id=", str6, "  type='checkbox' style='margin-left:-2px;' disabled='disabled'/>")));
			}
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
			object obj = empty;
			object[] objArray2 = new object[] { obj, dataRow1["PhraseValue"].ToString(), '£', str3, '\u00B6', str4, '$', str5, '€', str6, 'µ' };
			empty = string.Concat(objArray2);
		}
		plh.Controls.Add(new LiteralControl("<tr>"));
		plh.Controls.Add(new LiteralControl("<td align='center' valign='top'  style='width:'10px'>"));
		plh.Controls.Add(new LiteralControl("</td>"));
		plh.Controls.Add(new LiteralControl("<td valign='top' style='width:'132px; padding-left:5px;  padding-top:20px;'>"));
		plh.Controls.Add(new LiteralControl(string.Concat("<div style='padding-top:10px;'>", _languageClass.GetLanguageConversion("Accounting_Code"), "</div>")));
		plh.Controls.Add(new LiteralControl("</td>"));
		plh.Controls.Add(new LiteralControl("<td valign='top' style='float:left;width:17px; cursor:pointer; ' >"));
		plh.Controls.Add(new LiteralControl("</td>"));
		plh.Controls.Add(new LiteralControl("<td valign='top' style='width:'40%;'>"));
		DataTable dataTable = new DataTable();
		DataTable dataTable1 = new DataTable();
		dataTable = Settings.Setting_accountingCode_SelectAllRevenueCode(CompanyID);
		dataTable1 = EstimatesBasePage.Select_AccountingCode_For_Summary(CompanyID, EstimateItemID, empty1, ModuleID);
		plh.Controls.Add(new LiteralControl("<div style='width:'100%;'>"));
		DropDownList dropDownList = new DropDownList()
		{
			DataSource = dataTable,
			ID = string.Concat("ddlAc_Code_", EstimateItemID),
			DataValueField = "AccountCodeID",
			DataTextField = "Code"
		};
		AttributeCollection attributes = dropDownList.Attributes;
		object[] companyID = new object[] { "javascript:SaveAccountingcode('", CompanyID, "','", EstimateItemID, "', '", empty1, "',this.value)" };
		attributes.Add("onchange", string.Concat(companyID));
		dropDownList.DataBind();
		if (dataTable1.Rows.Count <= 0)
		{
			dropDownList.Items.Insert(0, new ListItem("---Select---", "Select"));
			dropDownList.SelectedIndex = 0;
		}
		else
		{
			baseClass.SetDDLValue(dropDownList, dataTable1.Rows[0]["AccountCodeID"].ToString());
		}
		dropDownList.Style.Add("width", "98%");
		dropDownList.Style.Add("margin-top", "10px");
		plh.Controls.Add(dropDownList);
		plh.Controls.Add(new LiteralControl("</div>"));
		plh.Controls.Add(new LiteralControl("</div>"));
		plh.Controls.Add(new LiteralControl("</td>"));
		plh.Controls.Add(new LiteralControl("<td>"));
		plh.Controls.Add(new LiteralControl("</td>"));
		plh.Controls.Add(new LiteralControl("</tr>"));
		plh.Controls.Add(new LiteralControl("</table>"));
		plh.Controls.Add(new LiteralControl("<tr valign='top'>"));
		if (empty1 == "O")
		{
			plh.Controls.Add(new LiteralControl("<td valign='top'>"));
			plh.Controls.Add(new LiteralControl("<div style='padding:10px 0px 0px 9px; border:0px solid green;'>"));
			plh.Controls.Add(new LiteralControl("<span> Copy the item description fields above to:</span>"));
			plh.Controls.Add(new LiteralControl("<div  style='padding:4px 0px 0px 0px;'>"));

			//Rertieve the settings as 
			string IsCopyOutworkDescFieldsToSupplier = "";
			string chkOutworkDescBoxesEnable = " checked='checked'";
			foreach (DataRow row in SettingsBasePage.Price_For_Whole_Pack_Select(CompanyID).Rows)
			{
				if (Convert.ToBoolean(row["CopyOutworkDescFieldsToSupplier"]))
				{
					IsCopyOutworkDescFieldsToSupplier = " checked='checked'";
				}
				if (Convert.ToBoolean(row["DontTickDescbox"]))
				{
					chkOutworkDescBoxesEnable = "";
				}
				
			}

			plh.Controls.Add(new LiteralControl(string.Concat("<input id='ChkboxCopy_Supplier_", EstimateItemID, "' type='checkbox' " + IsCopyOutworkDescFieldsToSupplier + " /><span>  Supplier request for quote item description fields</span>")));
			plh.Controls.Add(new LiteralControl("</div>"));
			if (pgType.ToLower() == "job")
			{
				if (flag)
				{
					plh.Controls.Add(new LiteralControl("<div >"));
					plh.Controls.Add(new LiteralControl(string.Concat("<input id='ChkboxCopy_PO_", EstimateItemID, "' type='checkbox' " + chkOutworkDescBoxesEnable + " /><span>  Purchase order item description fields</span>")));
					plh.Controls.Add(new LiteralControl("</div>"));
				}
				if (flag1)
				{
					plh.Controls.Add(new LiteralControl("<div >"));
					plh.Controls.Add(new LiteralControl(string.Concat("<input id='ChkboxCopy_DN_", EstimateItemID, "' type='checkbox' " + chkOutworkDescBoxesEnable + " /><span>  Delivery note item description fields</span>")));
					plh.Controls.Add(new LiteralControl("</div>"));
				}
			}
			plh.Controls.Add(new LiteralControl("</div>"));
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
		}
		str2 = (new BaseClass()).ReturnRoles_Privileges_Others("editrecords");
		if (Isfromactivityhist.ToLower() != "yes")
		{
			plh.Controls.Add(new LiteralControl("<tr>"));
			plh.Controls.Add(new LiteralControl("<td valign='top' align='right' style=' border:0px solid green; padding-right:37px;padding-top:5px'>"));
			if (str2.ToLower() != "his")
			{
				ControlCollection controls3 = plh.Controls;
				object[] estimateItemID2 = new object[] { "<input type='submit' style='display:none' id='Button_", EstimateItemID, "' value='", _languageClass.GetLanguageConversion("Update"), "' class='button' onclick=\"javascript:UpdateItemDescription('", ModuleID, "','", EstimateItemID, "','", empty, "','", empty1, "', '", pgType, "','", flag, "','", flag1, "','", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "');return false;\" /> " };
				controls3.Add(new LiteralControl(string.Concat(estimateItemID2)));
				ControlCollection controlCollections3 = plh.Controls;
				object[] estimateItemID3 = new object[] { "<input type='hidden' style='display:none' id='hdnDescButton_", EstimateItemID, "' value=\"", ModuleID, "▬", EstimateItemID, "▬", empty, "▬", empty1, "▬", pgType, "▬", flag, "▬", flag1, "▬", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "\" /> " };
				controlCollections3.Add(new LiteralControl(string.Concat(estimateItemID3)));
			}
			else if (HttpContext.Current.Session["UserID"].ToString() != empty2)
			{
				ControlCollection controls4 = plh.Controls;
				object[] objArray3 = new object[] { "<input style='display:none' type='submit' id='Button_", EstimateItemID, "' value='", _languageClass.GetLanguageConversion("Update"), "' class='button' onclick=\"javascript:UpdateItemDescription('", ModuleID, "','", EstimateItemID, "','", empty, "','", empty1, "', '", pgType, "','", flag, "','", flag1, "','", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "');return false;\" /> " };
				controls4.Add(new LiteralControl(string.Concat(objArray3)));
				ControlCollection controlCollections4 = plh.Controls;
				object[] estimateItemID4 = new object[] { "<input style='display:none' type='hidden' id='hdnDescButton_", EstimateItemID, "' value=\"", ModuleID, "▬", EstimateItemID, "▬", empty, "▬", empty1, "▬", pgType, "▬", flag, "▬", flag1, "▬", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "\" /> " };
				controlCollections4.Add(new LiteralControl(string.Concat(estimateItemID4)));
			}
			else
			{
				ControlCollection controls5 = plh.Controls;
				object[] objArray4 = new object[] { "<input  type='submit' style='display:none' id='Button_", EstimateItemID, "' value='", _languageClass.GetLanguageConversion("Update"), "' class='button' onclick=\"javascript:UpdateItemDescription('", ModuleID, "','", EstimateItemID, "','", empty, "','", empty1, "', '", pgType, "','", flag, "','", flag1, "','", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "');return false;\" /> " };
				controls5.Add(new LiteralControl(string.Concat(objArray4)));
				ControlCollection controlCollections5 = plh.Controls;
				object[] estimateItemID5 = new object[] { "<input  type='hidden' style='display:none' id='hdnDescButton_", EstimateItemID, "' value=\"", ModuleID, "▬", EstimateItemID, "▬", empty, "▬", empty1, "▬", pgType, "▬", flag, "▬", flag1, "▬", itemTitle.Replace("\n", "").Replace("\r", "").Replace("\"", "").Replace("'", ""), "\" /> " };
				controlCollections5.Add(new LiteralControl(string.Concat(estimateItemID5)));
			}
			plh.Controls.Add(new LiteralControl("</td>"));
			plh.Controls.Add(new LiteralControl("</tr>"));
		}
		plh.Controls.Add(new LiteralControl("</table>"));
	}

	public static void ShowJobCardDetails(int CompanyID, long EstimateID, long EstimateItemID, string Estimatetype)
	{
		DataRow[] dataRowArray;
		int i;
		char[] chrArray;
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder1 = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		StringBuilder stringBuilder3 = new StringBuilder();
		StringBuilder stringBuilder4 = new StringBuilder();
		StringBuilder stringBuilder5 = new StringBuilder();
		StringBuilder stringBuilder6 = new StringBuilder();
		StringBuilder stringBuilder7 = new StringBuilder();
		StringBuilder stringBuilder8 = new StringBuilder();
		StringBuilder stringBuilder9 = new StringBuilder();
		StringBuilder stringBuilder10 = new StringBuilder();
		StringBuilder stringBuilder11 = new StringBuilder();
		StringBuilder stringBuilder12 = new StringBuilder();
		long num = (long)0;
		foreach (DataRow row in JobBasePage.PCR_JOBCard_GetAllItems(EstimateItemID).Tables[0].Rows)
		{
			StringBuilder stringBuilder13 = new StringBuilder();
			StringBuilder stringBuilder14 = new StringBuilder();
			StringBuilder stringBuilder15 = new StringBuilder();
			StringBuilder stringBuilder16 = new StringBuilder();
			StringBuilder stringBuilder17 = new StringBuilder();
			StringBuilder stringBuilder18 = new StringBuilder();
			StringBuilder stringBuilder19 = new StringBuilder();
			StringBuilder stringBuilder20 = new StringBuilder();
			StringBuilder stringBuilder21 = new StringBuilder();
			StringBuilder stringBuilder22 = new StringBuilder();
			StringBuilder stringBuilder23 = new StringBuilder();
			StringBuilder stringBuilder24 = new StringBuilder();
			StringBuilder stringBuilder25 = new StringBuilder();
			num = Convert.ToInt64(row["ParentItemID"]);
			EstimateItemID = Convert.ToInt64(row["EstimateItemID"]);
			Estimatetype = row["EstimateType"].ToString();
			string empty = string.Empty;
			if (Estimatetype.ToLower() == "x")
			{
				Estimatetype = "C";
				empty = "X";
			}
			string str = "sub";
			if (Convert.ToBoolean(row["isParentItem"]))
			{
				str = "main";
			}
			DataTable item = JobBasePage.PCR_Select_JobCardSettings_ForReplace(CompanyID, Estimatetype, str).Tables[0];
			foreach (DataRow dataRow in item.Rows)
			{
				if (dataRow["SectionName"].ToString().Trim().ToLower() == "pre press")
				{
					if (str != "sub")
					{
						stringBuilder13.Append(dataRow["Description"].ToString());
					}
					else
					{
						stringBuilder13.Append(string.Concat("\r\n", dataRow["Description"].ToString()));
					}
				}
				else if (dataRow["SectionName"].ToString().Trim().ToLower() == "press")
				{
					if (str != "sub")
					{
						stringBuilder14.Append(dataRow["Description"].ToString());
					}
					else
					{
						stringBuilder14.Append(string.Concat("\r\n", dataRow["Description"].ToString()));
					}
				}
				else if (dataRow["SectionName"].ToString().Trim().ToLower() == "post press")
				{
					if (str != "sub")
					{
						stringBuilder15.Append(dataRow["Description"].ToString());
					}
					else
					{
						stringBuilder15.Append(string.Concat("\r\n", dataRow["Description"].ToString()));
					}
				}
				else if (dataRow["SectionName"].ToString().Trim().ToLower() == "warehouse")
				{
					if (str != "sub")
					{
						stringBuilder16.Append(dataRow["Description"].ToString());
					}
					else
					{
						stringBuilder16.Append(string.Concat("\r\n", dataRow["Description"].ToString()));
					}
				}
				else if (dataRow["SectionName"].ToString().Trim().ToLower() == "product catalogue")
				{
					if (str != "sub")
					{
						stringBuilder17.Append(dataRow["Description"].ToString());
					}
					else
					{
						stringBuilder17.Append(string.Concat("\r\n", dataRow["Description"].ToString()));
					}
				}
				else if (dataRow["SectionName"].ToString().Trim().ToLower() == "outwork")
				{
					if (str != "sub")
					{
						stringBuilder18.Append(dataRow["Description"].ToString());
					}
					else
					{
						stringBuilder18.Append(string.Concat("\r\n", dataRow["Description"].ToString()));
					}
				}
				else if (dataRow["SectionName"].ToString().Trim().ToLower() == "admin")
				{
					if (str != "sub")
					{
						stringBuilder19.Append(dataRow["Description"].ToString());
					}
					else
					{
						stringBuilder19.Append(string.Concat("\r\n", dataRow["Description"].ToString()));
					}
				}
				else if (dataRow["SectionName"].ToString().Trim().ToLower() == "paper")
				{
					if (str != "sub")
					{
						stringBuilder20.Append(dataRow["Description"].ToString());
					}
					else
					{
						stringBuilder20.Append(string.Concat("\r\n", dataRow["Description"].ToString()));
					}
				}
				else if (dataRow["SectionName"].ToString().Trim().ToLower() == "ink")
				{
					if (str != "sub")
					{
						stringBuilder21.Append(dataRow["Description"].ToString());
					}
					else
					{
						stringBuilder21.Append(string.Concat("\r\n", dataRow["Description"].ToString()));
					}
				}
				else if (dataRow["SectionName"].ToString().Trim().ToLower() == "plates")
				{
					if (str != "sub")
					{
						stringBuilder22.Append(dataRow["Description"].ToString());
					}
					else
					{
						stringBuilder22.Append(string.Concat("\r\n", dataRow["Description"].ToString()));
					}
				}
				else if (dataRow["SectionName"].ToString().Trim().ToLower() == "guillotine")
				{
					if (str != "sub")
					{
						stringBuilder23.Append(dataRow["Description"].ToString());
					}
					else
					{
						stringBuilder23.Append(string.Concat("\r\n", dataRow["Description"].ToString()));
					}
				}
				else if (dataRow["SectionName"].ToString().Trim().ToLower() != "wash up")
				{
					if (dataRow["SectionName"].ToString().Trim().ToLower() != "make ready")
					{
						continue;
					}
					if (str != "sub")
					{
						stringBuilder25.Append(dataRow["Description"].ToString());
					}
					else
					{
						stringBuilder25.Append(string.Concat("\r\n", dataRow["Description"].ToString()));
					}
				}
				else if (str != "sub")
				{
					stringBuilder24.Append(dataRow["Description"].ToString());
				}
				else
				{
					stringBuilder24.Append(string.Concat("\r\n", dataRow["Description"].ToString()));
				}
			}
			DataTable dataTable = JobBasePage.PCR_Select_JobCardTags_ForReplace(CompanyID).Tables[0];
			DataSet dataSet = JobBasePage.PCR_JOBCard_Values_To_Replace(EstimateItemID, Estimatetype, num);
			StringBuilder stringBuilder26 = new StringBuilder();
			int num1 = 1;
			commonClass _commonClass = new commonClass();
			foreach (DataRow row1 in dataSet.Tables[0].Rows)
			{
				foreach (DataRow dataRow1 in dataTable.Rows)
				{
					string empty1 = string.Empty;
					string str1 = string.Empty;
					string str2 = dataRow1["TagName"].ToString().Replace("<", "").Replace(">", "");
					if (!dataSet.Tables[0].Columns.Contains(str2))
					{
						continue;
					}
					string removeDecimalPlacesIfZero = string.Empty;
					if (str2.Trim().ToLower() == "booklet_or_ncr_section_no")
					{
						removeDecimalPlacesIfZero = num1.ToString();
					}
					else if (str2.Trim().ToLower() == "othercost_name")
					{
						commonClass _commonClass1 = new commonClass();
						removeDecimalPlacesIfZero = num1.ToString();
						StringBuilder stringBuilder27 = new StringBuilder();
						string str3 = row1["CalculationType"].ToString();
						stringBuilder27.Append(string.Concat(row1["othercost_name"].ToString(), "\r\n"));
						if (Convert.ToBoolean(row["isParentItem"]))
						{
							stringBuilder27.Append(string.Concat("Description: ", row1["Description"].ToString(), "\r\n"));
						}
						else
						{
							stringBuilder27.Append(string.Concat("Description: ", row1["Notes"].ToString(), "\r\n"));
						}
						if (string.Compare(str3, "t", true) == 0)
						{
							stringBuilder27.Append(string.Concat("Hours: ", _commonClass1.Eprint_ReturnFinal_Formated_Amount(CompanyID, 0, Convert.ToDecimal(row1["HoursOrQty"].ToString()), 0, "", false, false, true), "\r\n"));
						}
						else if (string.Compare(str3, "q", true) != 0)
						{
							stringBuilder27.Append("\r\n");
						}
						else
						{
							stringBuilder27.Append(string.Concat("Quantity: ", Convert.ToInt32(row1["HoursOrQty"]), "\r\n"));
						}
						stringBuilder27.Append("\r\n");
						removeDecimalPlacesIfZero = stringBuilder27.ToString();
					}
					else if (str2.Trim().ToLower() == "side1ink_name")
					{
						if (Estimatetype == "L")
						{
							foreach (DataRow row2 in EstimatesBasePage.LargeItem_ink_UnitPrice_MinimumCost_Select(CompanyID, EstimateItemID).Rows)
							{
								empty1 = string.Concat(empty1, row2["InventoryName"].ToString(), ", ");
							}
							try
							{
								empty1 = empty1.Remove(empty1.Length - 2, 2);
							}
							catch
							{
							}
						}
						if (Estimatetype != "F" && Estimatetype != "D")
						{
							if (Estimatetype == "K" || Estimatetype == "N")
							{
								empty1 = string.Concat(empty1, EstimatesBasePage.TakeLithoInkDetails_jobcard(EstimateItemID, num1, CompanyID));
							}
						}
						else if (Convert.ToBoolean(row1["IsDoubleSided"]))
						{
							DataTable dataTable1 = EstimatesBasePage.estimate_lithopress_select_ink_name_item_desc(CompanyID, EstimateItemID, "Single", (long)0, (long)0, Estimatetype);
							if (dataTable1.Rows.Count > 0)
							{
								dataRowArray = dataTable1.Select("sidenumber='side1'");
								for (i = 0; i < (int)dataRowArray.Length; i++)
								{
									DataRow dataRow2 = dataRowArray[i];
									empty1 = string.Concat(empty1, dataRow2["InkName"].ToString(), ", ");
								}
								try
								{
									empty1 = empty1.Remove(empty1.Length - 2, 2);
								}
								catch
								{
								}
							}
						}
						else
						{
							DataTable dataTable2 = EstimatesBasePage.estimate_lithopress_select_ink_name_item_desc(CompanyID, EstimateItemID, "Single", (long)0, (long)0, Estimatetype);
							if (dataTable2.Rows.Count > 0)
							{
								foreach (DataRow row3 in dataTable2.Rows)
								{
									empty1 = string.Concat(empty1, row3["InkName"].ToString(), ", ");
								}
								try
								{
									empty1 = empty1.Remove(empty1.Length - 2, 2);
								}
								catch
								{
								}
							}
						}
						removeDecimalPlacesIfZero = empty1;
					}
					else if (str2.Trim().ToLower() == "side2ink_name")
					{
						if (Estimatetype == "L")
						{
							foreach (DataRow dataRow3 in EstimatesBasePage.LargeItem_ink_UnitPrice_MinimumCost_Select(CompanyID, EstimateItemID).Rows)
							{
								empty1 = string.Concat(empty1, dataRow3["InventoryName"].ToString(), ", ");
							}
							try
							{
								empty1 = empty1.Remove(empty1.Length - 2, 2);
							}
							catch
							{
							}
						}
						if (Estimatetype != "F" && Estimatetype != "D")
						{
							if (Estimatetype == "K" || Estimatetype == "N")
							{
								str1 = string.Concat(str1, EstimatesBasePage.TakeLithoInkDetails_jobcardNew(EstimateItemID, num1, CompanyID));
							}
						}
						else if (Convert.ToBoolean(row1["IsDoubleSided"]))
						{
							DataTable dataTable3 = EstimatesBasePage.estimate_lithopress_select_ink_name_item_desc(CompanyID, EstimateItemID, "Double", (long)0, (long)0, Estimatetype);
							if (dataTable3.Rows.Count > 0)
							{
								dataRowArray = dataTable3.Select("sidenumber='side2'");
								for (i = 0; i < (int)dataRowArray.Length; i++)
								{
									DataRow dataRow4 = dataRowArray[i];
									str1 = string.Concat(str1, dataRow4["InkName"].ToString(), ", ");
								}
								if (str1 != "")
								{
									try
									{
										str1 = str1.Remove(str1.Length - 2, 2);
									}
									catch
									{
									}
								}
							}
						}
						removeDecimalPlacesIfZero = str1;
					}
					else if (str2.Trim().ToLower() == "firsttrim_yes_no" || str2.Trim().ToLower() == "firsttrim_numberof_cuts" || str2.Trim().ToLower() == "firsttrim_numberof_bundles" || str2.Trim().ToLower() == "secondtrim_yes_no" || str2.Trim().ToLower() == "secondtrim_numberof_cuts" || str2.Trim().ToLower() == "secondtrim_numberof_bundles")
					{
						removeDecimalPlacesIfZero = (row1["Guillotine_Name"].ToString().Trim() != "" ? row1[str2].ToString() : "");
					}
					else if (str2.Trim().ToLower() == "no_of_colourside2")
					{
						removeDecimalPlacesIfZero = (row1["Single_Side_Or_Double_Side"].ToString().Trim() != "single" ? row1[str2].ToString() : "");
					}
					else if (str2.Trim().ToLower() != "inventory_gsm")
					{
						removeDecimalPlacesIfZero = (str2.Trim().ToLower() != "PrintSheetquantity_excl_spoilage" ? row1[str2].ToString() : _commonClass.ToRemoveDecimalPlacesIfZero(row1[str2].ToString()));
					}
					else
					{
						removeDecimalPlacesIfZero = _commonClass.ToRemoveDecimalPlacesIfZero(row1[str2].ToString());
					}
					if (str2.Trim().ToLower() == "inventorysheet_name" && row1[str2].ToString().Contains("µ"))
					{
						string empty2 = string.Empty;
						string str4 = row1[str2].ToString();
						chrArray = new char[] { 'µ' };
						string[] strArrays = str4.Split(chrArray);
						for (int j = 0; j < (int)strArrays.Length; j++)
						{
							if (strArrays[j].ToString().Trim().Length > 0)
							{
								empty2 = string.Concat(empty2, _commonClass.ToRemoveDecimalPlacesIfZero(strArrays[j].ToString()), "µ");
							}
						}
						removeDecimalPlacesIfZero = empty2.ToString().Replace("µ", "\n");
					}


                    if (str2.Trim().ToLower() == "inventorysheet_name1")
                    {
                        string empty2 = string.Empty;
                        string str4 = row1[str2].ToString();
                        if (str4.ToString().Trim().Length > 0)
                        {
                            empty2 =  _commonClass.ToRemoveDecimalPlacesIfZero(str4);

                        }
                        removeDecimalPlacesIfZero = empty2.ToString();
                    }
                    if (str2.Trim().ToLower() == "inventorysheet_name2")
                    {
                        string empty2 = string.Empty;
                        string str4 = row1[str2].ToString();
                        if (str4.ToString().Trim().Length > 0)
                        {
                            empty2 = _commonClass.ToRemoveDecimalPlacesIfZero(str4);

                        }
                        removeDecimalPlacesIfZero = empty2.ToString();
                    }
                    if (str2.Trim().ToLower() == "inventorysheet_name3")
                    {
                        string empty2 = string.Empty;
                        string str4 = row1[str2].ToString();
                        if (str4.ToString().Trim().Length > 0)
                        {
                            empty2 = _commonClass.ToRemoveDecimalPlacesIfZero(str4);

                        }
                        removeDecimalPlacesIfZero = empty2.ToString();
                    }
                    if (str2.Trim().ToLower() == "inventorysheet_name4")
                    {
                        string empty2 = string.Empty;
                        string str4 = row1[str2].ToString();
                        if (str4.ToString().Trim().Length > 0)
                        {
                            empty2 = _commonClass.ToRemoveDecimalPlacesIfZero(str4);

                        }
                        removeDecimalPlacesIfZero = empty2.ToString();
                    }
                    if (str2.Trim().ToLower() == "inventorysheet_name5")
                    {
                        string empty2 = string.Empty;
                        string str4 = row1[str2].ToString();
                        if (str4.ToString().Trim().Length > 0)
                        {
                            empty2 = _commonClass.ToRemoveDecimalPlacesIfZero(str4);

                        }
                        removeDecimalPlacesIfZero = empty2.ToString();
                    }




                    if (str2.Trim().ToLower() == "inventorysheet_size" && row1[str2].ToString().Contains("µ"))
					{
						string empty3 = string.Empty;
						string str5 = row1[str2].ToString();
						chrArray = new char[] { 'µ' };
						string[] strArrays1 = str5.Split(chrArray);
						for (int k = 0; k < (int)strArrays1.Length; k++)
						{
							if (_commonClass.ToRemoveDecimalPlacesIfZero(strArrays1[k].ToString()) != "0")
							{
								empty3 = string.Concat(empty3, _commonClass.ToRemoveDecimalPlacesIfZero(strArrays1[k].ToString()), "µ");
							}
						}
						removeDecimalPlacesIfZero = empty3.ToString().Replace("µ", "\n");
					}


                    if (str2.Trim().ToLower() == "inventorysheet_size1")
                    {
                        string empty3 = string.Empty;
                        string str5 = row1[str2].ToString();
                       
                            if (_commonClass.ToRemoveDecimalPlacesIfZero(str5) != "0")
                            {
                                empty3 = _commonClass.ToRemoveDecimalPlacesIfZero(str5);
                            }
                      
                        removeDecimalPlacesIfZero = empty3.ToString();
						if (removeDecimalPlacesIfZero == "0")
							removeDecimalPlacesIfZero = "";
                    }
                    if (str2.Trim().ToLower() == "inventorysheet_size2")
                    {
                        string empty3 = string.Empty;
                        string str5 = row1[str2].ToString();

                        if (_commonClass.ToRemoveDecimalPlacesIfZero(str5) != "0")
                        {
                            empty3 = _commonClass.ToRemoveDecimalPlacesIfZero(str5);
                        }

                        removeDecimalPlacesIfZero = empty3.ToString();
                        if (removeDecimalPlacesIfZero == "0")
                            removeDecimalPlacesIfZero = "";
                    }
                    if (str2.Trim().ToLower() == "inventorysheet_size3")
                    {
                        string empty3 = string.Empty;
                        string str5 = row1[str2].ToString();

                        if (_commonClass.ToRemoveDecimalPlacesIfZero(str5) != "0")
                        {
                            empty3 = _commonClass.ToRemoveDecimalPlacesIfZero(str5);
                        }

                        removeDecimalPlacesIfZero = empty3.ToString();
                        if (removeDecimalPlacesIfZero == "0")
                            removeDecimalPlacesIfZero = "";
                    }
                    if (str2.Trim().ToLower() == "inventorysheet_size4")
                    {
                        string empty3 = string.Empty;
                        string str5 = row1[str2].ToString();

                        if (_commonClass.ToRemoveDecimalPlacesIfZero(str5) != "0")
                        {
                            empty3 = _commonClass.ToRemoveDecimalPlacesIfZero(str5);
                        }

                        removeDecimalPlacesIfZero = empty3.ToString();
                        if (removeDecimalPlacesIfZero == "0")
                            removeDecimalPlacesIfZero = "";
                    }
                    if (str2.Trim().ToLower() == "inventorysheet_size5")
                    {
                        string empty3 = string.Empty;
                        string str5 = row1[str2].ToString();

                        if (_commonClass.ToRemoveDecimalPlacesIfZero(str5) != "0")
                        {
                            empty3 = _commonClass.ToRemoveDecimalPlacesIfZero(str5);
                        }

                        removeDecimalPlacesIfZero = empty3.ToString();
                        if (removeDecimalPlacesIfZero == "0")
                            removeDecimalPlacesIfZero = "";
                    }



                    // Paper_Weight
                    if (str2.Trim().ToLower() == "paper_weight" && row1[str2].ToString().Contains("µ"))
                    {
                        string empty4 = string.Empty;
                        string str5 = row1[str2].ToString();
                        chrArray = new char[] { 'µ' };
                        string[] strArrays1 = str5.Split(chrArray);
                        for (int k = 0; k < (int)strArrays1.Length; k++)
                        {
                            if (_commonClass.ToRemoveDecimalPlacesIfZero(strArrays1[k].ToString()) != "0")
                            {
                                empty4 = string.Concat(empty4, _commonClass.ToRemoveDecimalPlacesIfZero(strArrays1[k].ToString()), "µ");
                            }
                        }
                        removeDecimalPlacesIfZero = empty4.ToString().Replace("µ", "\n");
                    }
					if (str2.Trim().ToLower() == "inventroysheet_quantity")
					{
						removeDecimalPlacesIfZero = _commonClass.ToRemoveDecimalPlacesIfZero(row1[str2].ToString());
					}
					if (str2.Trim().ToLower() == "Print_Sheets_Per_SectionNumber")
					{
						removeDecimalPlacesIfZero = _commonClass.ToRemoveDecimalPlacesIfZero(row1[str2].ToString());
					}
					if (str2.Trim().ToLower() == "inventory_gsm" && row1[str2].ToString().Contains("µ"))
					{
						string empty4 = string.Empty;
						string str6 = row1[str2].ToString();
						chrArray = new char[] { 'µ' };
						string[] strArrays2 = str6.Split(chrArray);
						for (int l = 0; l < (int)strArrays2.Length; l++)
						{
							if (_commonClass.ToRemoveDecimalPlacesIfZero(strArrays2[l].ToString()) != "0")
							{
								empty4 = string.Concat(empty4, _commonClass.ToRemoveDecimalPlacesIfZero(strArrays2[l].ToString()), "µ");
							}
						}
						removeDecimalPlacesIfZero = empty4.Replace("µ", "\n");
					}
					commonClass _commonClass2 = new commonClass();
					if (str2.Trim().ToLower() == "work_n_tumble")
					{
						removeDecimalPlacesIfZero = (row1["Work_n_Tumble"].ToString() == "" ? "" : _commonClass2.GetCurrencyinRequiredFormate(_commonClass2.Eprint_ReturnFinal_Formated_Amount(CompanyID, Convert.ToInt32(HttpContext.Current.Session["UserID"]), Convert.ToDecimal(row1["Work_n_Tumble"].ToString()), 0, "", false, false, true), true));
					}
					if (str2.Trim().ToLower() == "work_n_turn")
					{
						removeDecimalPlacesIfZero = (row1["Work_n_Turn"].ToString() == "" ? "" : _commonClass2.GetCurrencyinRequiredFormate(_commonClass2.Eprint_ReturnFinal_Formated_Amount(CompanyID, Convert.ToInt32(HttpContext.Current.Session["UserID"]), Convert.ToDecimal(row1["Work_n_Turn"].ToString()), 0, "", false, false, true), true));
					}
					if (str2.Trim().ToLower() == "sheet_work")
					{
						removeDecimalPlacesIfZero = (row1["Sheet_Work"].ToString() == "" ? "" : _commonClass2.GetCurrencyinRequiredFormate(_commonClass2.Eprint_ReturnFinal_Formated_Amount(CompanyID, Convert.ToInt32(HttpContext.Current.Session["UserID"]), Convert.ToDecimal(row1["Sheet_Work"].ToString()), 0, "", false, false, true), true));
					}
					if (str2.Trim().ToLower() != "othercost_name")
					{
						stringBuilder13.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder14.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder15.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder16.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder17.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
                        // remove empty tags
                        if (removeDecimalPlacesIfZero == "")
                        {
                            string emptylabel = "<" + str2 + "_Label>";
                            stringBuilder18.Replace(emptylabel, removeDecimalPlacesIfZero);
                        }
						stringBuilder18.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder19.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder20.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder21.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder22.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder23.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder24.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder25.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
					}
					else
					{
						if (row1["JobcardCategory"].ToString().ToLower() != "pre press")
						{
							stringBuilder13.Replace(dataRow1["TagName"].ToString(), "");
						}
						else
						{
							stringBuilder13.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						}
						if (row1["JobcardCategory"].ToString().ToLower() != "press")
						{
							stringBuilder14.Replace(dataRow1["TagName"].ToString(), "");
						}
						else
						{
							stringBuilder14.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						}
						if (row1["JobcardCategory"].ToString().ToLower() != "post press")
						{
							stringBuilder15.Replace(dataRow1["TagName"].ToString(), "");
						}
						else
						{
							stringBuilder15.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						}
						if (row1["JobcardCategory"].ToString().ToLower() != "admin")
						{
							stringBuilder19.Replace(dataRow1["TagName"].ToString(), "");
						}
						else
						{
							stringBuilder19.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						}
						removeDecimalPlacesIfZero = "";
						stringBuilder16.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder17.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder18.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder20.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder21.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder22.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder23.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder24.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
						stringBuilder25.Replace(dataRow1["TagName"].ToString(), removeDecimalPlacesIfZero);
					}
				}
				num1++;
				if (dataSet.Tables[0].Rows.Count < num1 || !(Estimatetype.Trim().ToUpper() == "B") && !(Estimatetype.Trim().ToUpper() == "K") && !(Estimatetype.Trim().ToUpper() == "N"))
				{
					continue;
				}
				DataTable item1 = JobBasePage.PCR_Select_JobCardSettings_ForReplace(CompanyID, Estimatetype, str).Tables[0];
				foreach (DataRow row4 in item1.Rows)
				{
					if (row4["SectionName"].ToString().Trim().ToLower() == "pre press")
					{
						stringBuilder13.Append(string.Concat("\n\r", row4["Description"].ToString()));
					}
					else if (row4["SectionName"].ToString().Trim().ToLower() == "press")
					{
						stringBuilder14.Append(string.Concat("\n\r", row4["Description"].ToString()));
					}
					else if (row4["SectionName"].ToString().Trim().ToLower() == "post press")
					{
						stringBuilder15.Append(string.Concat("\n\r", row4["Description"].ToString()));
					}
					else if (row4["SectionName"].ToString().Trim().ToLower() == "warehouse")
					{
						stringBuilder16.Append(string.Concat("\n\r", row4["Description"].ToString()));
					}
					else if (row4["SectionName"].ToString().Trim().ToLower() == "product catalogue")
					{
						stringBuilder17.Append(string.Concat("\n\r", row4["Description"].ToString()));
					}
					else if (row4["SectionName"].ToString().Trim().ToLower() == "outwork")
					{
						stringBuilder18.Append(string.Concat("\n\r", row4["Description"].ToString()));
					}
					else if (row4["SectionName"].ToString().Trim().ToLower() == "admin")
					{
						stringBuilder19.Append(string.Concat("\n\r", row4["Description"].ToString()));
					}
					else if (row4["SectionName"].ToString().Trim().ToLower() == "paper")
					{
						stringBuilder20.Append(string.Concat("\n\r", row4["Description"].ToString()));
					}
					else if (row4["SectionName"].ToString().Trim().ToLower() == "ink")
					{
						stringBuilder21.Append(string.Concat("\n\r", row4["Description"].ToString()));
					}
					else if (row4["SectionName"].ToString().Trim().ToLower() == "plates")
					{
						stringBuilder22.Append(string.Concat("\n\r", row4["Description"].ToString()));
					}
					else if (row4["SectionName"].ToString().Trim().ToLower() == "guillotine")
					{
						stringBuilder23.Append(string.Concat("\n\r", row4["Description"].ToString()));
					}
					else if (row4["SectionName"].ToString().Trim().ToLower() != "wash up")
					{
						if (row4["SectionName"].ToString().Trim().ToLower() != "make ready")
						{
							continue;
						}
						stringBuilder25.Append(string.Concat("\n\r", row4["Description"].ToString()));
					}
					else
					{
						stringBuilder24.Append(string.Concat("\n\r", row4["Description"].ToString()));
					}
				}
			}
			//if (Convert.ToBoolean(row["isParentItem"]))
			//{
				foreach (DataRow row5 in dataSet.Tables[1].Rows)
				{
					foreach (DataRow dataRow5 in dataTable.Rows)
					{
						string str7 = dataRow5["TagName"].ToString().Replace("<", "").Replace(">", "");
						if (!dataSet.Tables[1].Columns.Contains(str7))
						{
							continue;
						}                        
						stringBuilder13.Replace(dataRow5["TagName"].ToString(), row5[str7].ToString());
						stringBuilder14.Replace(dataRow5["TagName"].ToString(), row5[str7].ToString());
						stringBuilder15.Replace(dataRow5["TagName"].ToString(), row5[str7].ToString());
						stringBuilder16.Replace(dataRow5["TagName"].ToString(), row5[str7].ToString());
						stringBuilder17.Replace(dataRow5["TagName"].ToString(), row5[str7].ToString());
                        // remove empty tags
                        if (Convert.ToString(row5[str7]) == "")
                        {
                            string removelabel = "<" + str7 + "_Label>";
                            stringBuilder18.Replace(removelabel, "");
                        }
						stringBuilder18.Replace(dataRow5["TagName"].ToString(), row5[str7].ToString());
						stringBuilder19.Replace(dataRow5["TagName"].ToString(), row5[str7].ToString());
						stringBuilder20.Replace(dataRow5["TagName"].ToString(), row5[str7].ToString());
						stringBuilder21.Replace(dataRow5["TagName"].ToString(), row5[str7].ToString());
						stringBuilder22.Replace(dataRow5["TagName"].ToString(), row5[str7].ToString());
						stringBuilder23.Replace(dataRow5["TagName"].ToString(), row5[str7].ToString());
						stringBuilder24.Replace(dataRow5["TagName"].ToString(), row5[str7].ToString());
						stringBuilder25.Replace(dataRow5["TagName"].ToString(), row5[str7].ToString());                        
					}
				}
			//}
			if (Estimatetype.Trim().ToLower() == "o")
			{
				string empty5 = string.Empty;
				foreach (DataRow row6 in dataSet.Tables[2].Rows)
				{
					empty5 = row6["ItemDescription"].ToString();
				}
				string str8 = empty5.ToString();
				chrArray = new char[] { 'µ' };
				string[] strArrays3 = str8.Split(chrArray);
				for (int m = 0; m < (int)strArrays3.Length; m++)
				{
					string str9 = strArrays3[m].ToString();
					chrArray = new char[] { '»' };
					string[] strArrays4 = str9.Split(chrArray);
					if ((int)strArrays4.Length > 3)
					{
						if (string.Compare(strArrays4[0], "ItemTitle", true) == 0)
						{
							stringBuilder13.Replace("<Supplier_Item_Title_Label>", strArrays4[1].ToString());
							stringBuilder13.Replace("<Supplier_Item_Title>", strArrays4[2].ToString());
							stringBuilder14.Replace("<Supplier_Item_Title_Label>", strArrays4[1].ToString());
							stringBuilder14.Replace("<Supplier_Item_Title>", strArrays4[2].ToString());
							stringBuilder15.Replace("<Supplier_Item_Title_Label>", strArrays4[1].ToString());
							stringBuilder15.Replace("<Supplier_Item_Title>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Title_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Title>", strArrays4[2].ToString());
							stringBuilder17.Replace("<Supplier_Item_Title_Label>", strArrays4[1].ToString());
							stringBuilder17.Replace("<Supplier_Item_Title>", strArrays4[2].ToString());
							stringBuilder18.Replace("<Supplier_Item_Title_Label>", strArrays4[1].ToString());
							stringBuilder18.Replace("<Supplier_Item_Title>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Title_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Title>", strArrays4[2].ToString());
							stringBuilder19.Replace("<Supplier_Item_Title_Label>", strArrays4[1].ToString());
							stringBuilder19.Replace("<Supplier_Item_Title>", strArrays4[2].ToString());
							stringBuilder20.Replace("<Supplier_Item_Title_Label>", strArrays4[1].ToString());
							stringBuilder20.Replace("<Supplier_Item_Title>", strArrays4[2].ToString());
							stringBuilder21.Replace("<Supplier_Item_Title_Label>", strArrays4[1].ToString());
							stringBuilder21.Replace("<Supplier_Item_Title>", strArrays4[2].ToString());
							stringBuilder22.Replace("<Supplier_Item_Title_Label>", strArrays4[1].ToString());
							stringBuilder22.Replace("<Supplier_Item_Title>", strArrays4[2].ToString());
							stringBuilder23.Replace("<Supplier_Item_Title_Label>", strArrays4[1].ToString());
							stringBuilder23.Replace("<Supplier_Item_Title>", strArrays4[2].ToString());
							stringBuilder24.Replace("<Supplier_Item_Title_Label>", strArrays4[1].ToString());
							stringBuilder24.Replace("<Supplier_Item_Title>", strArrays4[2].ToString());
							stringBuilder25.Replace("<Supplier_Item_Title_Label>", strArrays4[1].ToString());
							stringBuilder25.Replace("<Supplier_Item_Title>", strArrays4[2].ToString());
						}
						else if (string.Compare(strArrays4[0], "Description", true) == 0)
						{
							stringBuilder13.Replace("<Supplier_Item_Description_Label>", strArrays4[1].ToString());
							stringBuilder13.Replace("<Supplier_Item_Description>", strArrays4[2].ToString());
							stringBuilder14.Replace("<Supplier_Item_Description_Label>", strArrays4[1].ToString());
							stringBuilder14.Replace("<Supplier_Item_Description>", strArrays4[2].ToString());
							stringBuilder15.Replace("<Supplier_Item_Description_Label>", strArrays4[1].ToString());
							stringBuilder15.Replace("<Supplier_Item_Description>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Description_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Description>", strArrays4[2].ToString());
							stringBuilder17.Replace("<Supplier_Item_Description_Label>", strArrays4[1].ToString());
							stringBuilder17.Replace("<Supplier_Item_Description>", strArrays4[2].ToString());
							stringBuilder18.Replace("<Supplier_Item_Description_Label>", strArrays4[1].ToString());
							stringBuilder18.Replace("<Supplier_Item_Description>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Description_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Description>", strArrays4[2].ToString());
							stringBuilder19.Replace("<Supplier_Item_Description_Label>", strArrays4[1].ToString());
							stringBuilder19.Replace("<Supplier_Item_Description>", strArrays4[2].ToString());
							stringBuilder20.Replace("<Supplier_Item_Description_Label>", strArrays4[1].ToString());
							stringBuilder20.Replace("<Supplier_Item_Description>", strArrays4[2].ToString());
							stringBuilder21.Replace("<Supplier_Item_Description_Label>", strArrays4[1].ToString());
							stringBuilder21.Replace("<Supplier_Item_Description>", strArrays4[2].ToString());
							stringBuilder22.Replace("<Supplier_Item_Description_Label>", strArrays4[1].ToString());
							stringBuilder22.Replace("<Supplier_Item_Description>", strArrays4[2].ToString());
							stringBuilder23.Replace("<Supplier_Item_Description_Label>", strArrays4[1].ToString());
							stringBuilder23.Replace("<Supplier_Item_Description>", strArrays4[2].ToString());
							stringBuilder24.Replace("<Supplier_Item_Description_Label>", strArrays4[1].ToString());
							stringBuilder24.Replace("<Supplier_Item_Description>", strArrays4[2].ToString());
							stringBuilder25.Replace("<Supplier_Item_Description_Label>", strArrays4[1].ToString());
							stringBuilder25.Replace("<Supplier_Item_Description>", strArrays4[2].ToString());
						}
						else if (string.Compare(strArrays4[0], "Artwork", true) == 0)
						{
							stringBuilder13.Replace("<Supplier_Item_Artwork_Label>", strArrays4[1].ToString());
							stringBuilder13.Replace("<Supplier_Item_Artwork>", strArrays4[2].ToString());
							stringBuilder14.Replace("<Supplier_Item_Artwork_Label>", strArrays4[1].ToString());
							stringBuilder14.Replace("<Supplier_Item_Artwork>", strArrays4[2].ToString());
							stringBuilder15.Replace("<Supplier_Item_Artwork_Label>", strArrays4[1].ToString());
							stringBuilder15.Replace("<Supplier_Item_Artwork>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Artwork_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Artwork>", strArrays4[2].ToString());
							stringBuilder17.Replace("<Supplier_Item_Artwork_Label>", strArrays4[1].ToString());
							stringBuilder17.Replace("<Supplier_Item_Artwork>", strArrays4[2].ToString());
							stringBuilder18.Replace("<Supplier_Item_Artwork_Label>", strArrays4[1].ToString());
							stringBuilder18.Replace("<Supplier_Item_Artwork>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Artwork_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Artwork>", strArrays4[2].ToString());
							stringBuilder19.Replace("<Supplier_Item_Artwork_Label>", strArrays4[1].ToString());
							stringBuilder19.Replace("<Supplier_Item_Artwork>", strArrays4[2].ToString());
							stringBuilder20.Replace("<Supplier_Item_Artwork_Label>", strArrays4[1].ToString());
							stringBuilder20.Replace("<Supplier_Item_Artwork>", strArrays4[2].ToString());
							stringBuilder21.Replace("<Supplier_Item_Artwork_Label>", strArrays4[1].ToString());
							stringBuilder21.Replace("<Supplier_Item_Artwork>", strArrays4[2].ToString());
							stringBuilder22.Replace("<Supplier_Item_Artwork_Label>", strArrays4[1].ToString());
							stringBuilder22.Replace("<Supplier_Item_Artwork>", strArrays4[2].ToString());
							stringBuilder23.Replace("<Supplier_Item_Artwork_Label>", strArrays4[1].ToString());
							stringBuilder23.Replace("<Supplier_Item_Artwork>", strArrays4[2].ToString());
							stringBuilder24.Replace("<Supplier_Item_Artwork_Label>", strArrays4[1].ToString());
							stringBuilder24.Replace("<Supplier_Item_Artwork>", strArrays4[2].ToString());
							stringBuilder25.Replace("<Supplier_Item_Artwork_Label>", strArrays4[1].ToString());
							stringBuilder25.Replace("<Supplier_Item_Artwork>", strArrays4[2].ToString());
						}
						else if (string.Compare(strArrays4[0], "Colour", true) == 0)
						{
							stringBuilder13.Replace("<Supplier_Item_Colour_Label>", strArrays4[1].ToString());
							stringBuilder13.Replace("<Supplier_Item_Colour>", strArrays4[2].ToString());
							stringBuilder14.Replace("<Supplier_Item_Colour_Label>", strArrays4[1].ToString());
							stringBuilder14.Replace("<Supplier_Item_Colour>", strArrays4[2].ToString());
							stringBuilder15.Replace("<Supplier_Item_Colour_Label>", strArrays4[1].ToString());
							stringBuilder15.Replace("<Supplier_Item_Colour>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Colour_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Colour>", strArrays4[2].ToString());
							stringBuilder17.Replace("<Supplier_Item_Colour_Label>", strArrays4[1].ToString());
							stringBuilder17.Replace("<Supplier_Item_Colour>", strArrays4[2].ToString());
							stringBuilder18.Replace("<Supplier_Item_Colour_Label>", strArrays4[1].ToString());
							stringBuilder18.Replace("<Supplier_Item_Colour>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Colour_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Colour>", strArrays4[2].ToString());
							stringBuilder19.Replace("<Supplier_Item_Colour_Label>", strArrays4[1].ToString());
							stringBuilder19.Replace("<Supplier_Item_Colour>", strArrays4[2].ToString());
							stringBuilder20.Replace("<Supplier_Item_Colour_Label>", strArrays4[1].ToString());
							stringBuilder20.Replace("<Supplier_Item_Colour>", strArrays4[2].ToString());
							stringBuilder21.Replace("<Supplier_Item_Colour_Label>", strArrays4[1].ToString());
							stringBuilder21.Replace("<Supplier_Item_Colour>", strArrays4[2].ToString());
							stringBuilder22.Replace("<Supplier_Item_Colour_Label>", strArrays4[1].ToString());
							stringBuilder22.Replace("<Supplier_Item_Colour>", strArrays4[2].ToString());
							stringBuilder23.Replace("<Supplier_Item_Colour_Label>", strArrays4[1].ToString());
							stringBuilder23.Replace("<Supplier_Item_Colour>", strArrays4[2].ToString());
							stringBuilder24.Replace("<Supplier_Item_Colour_Label>", strArrays4[1].ToString());
							stringBuilder24.Replace("<Supplier_Item_Colour>", strArrays4[2].ToString());
							stringBuilder25.Replace("<Supplier_Item_Colour_Label>", strArrays4[1].ToString());
							stringBuilder25.Replace("<Supplier_Item_Colour>", strArrays4[2].ToString());
						}
						else if (string.Compare(strArrays4[0], "Size", true) == 0)
						{
							stringBuilder13.Replace("<Supplier_Item_Size_Label>", strArrays4[1].ToString());
							stringBuilder13.Replace("<Supplier_Item_Size>", strArrays4[2].ToString());
							stringBuilder14.Replace("<Supplier_Item_Size_Label>", strArrays4[1].ToString());
							stringBuilder14.Replace("<Supplier_Item_Size>", strArrays4[2].ToString());
							stringBuilder15.Replace("<Supplier_Item_Size_Label>", strArrays4[1].ToString());
							stringBuilder15.Replace("<Supplier_Item_Size>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Size_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Size>", strArrays4[2].ToString());
							stringBuilder17.Replace("<Supplier_Item_Size_Label>", strArrays4[1].ToString());
							stringBuilder17.Replace("<Supplier_Item_Size>", strArrays4[2].ToString());
							stringBuilder18.Replace("<Supplier_Item_Size_Label>", strArrays4[1].ToString());
							stringBuilder18.Replace("<Supplier_Item_Size>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Size_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Size>", strArrays4[2].ToString());
							stringBuilder19.Replace("<Supplier_Item_Size_Label>", strArrays4[1].ToString());
							stringBuilder19.Replace("<Supplier_Item_Size>", strArrays4[2].ToString());
							stringBuilder20.Replace("<Supplier_Item_Size_Label>", strArrays4[1].ToString());
							stringBuilder20.Replace("<Supplier_Item_Size>", strArrays4[2].ToString());
							stringBuilder21.Replace("<Supplier_Item_Size_Label>", strArrays4[1].ToString());
							stringBuilder21.Replace("<Supplier_Item_Size>", strArrays4[2].ToString());
							stringBuilder22.Replace("<Supplier_Item_Size_Label>", strArrays4[1].ToString());
							stringBuilder22.Replace("<Supplier_Item_Size>", strArrays4[2].ToString());
							stringBuilder23.Replace("<Supplier_Item_Size_Label>", strArrays4[1].ToString());
							stringBuilder23.Replace("<Supplier_Item_Size>", strArrays4[2].ToString());
							stringBuilder24.Replace("<Supplier_Item_Size_Label>", strArrays4[1].ToString());
							stringBuilder24.Replace("<Supplier_Item_Size>", strArrays4[2].ToString());
							stringBuilder25.Replace("<Supplier_Item_Size_Label>", strArrays4[1].ToString());
							stringBuilder25.Replace("<Supplier_Item_Size>", strArrays4[2].ToString());
						}
						else if (string.Compare(strArrays4[0], "Material", true) == 0)
						{
							stringBuilder13.Replace("<Supplier_Item_Material_Label>", strArrays4[1].ToString());
							stringBuilder13.Replace("<Supplier_Item_Material>", strArrays4[2].ToString());
							stringBuilder14.Replace("<Supplier_Item_Material_Label>", strArrays4[1].ToString());
							stringBuilder14.Replace("<Supplier_Item_Material>", strArrays4[2].ToString());
							stringBuilder15.Replace("<Supplier_Item_Material_Label>", strArrays4[1].ToString());
							stringBuilder15.Replace("<Supplier_Item_Material>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Material_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Material>", strArrays4[2].ToString());
							stringBuilder17.Replace("<Supplier_Item_Material_Label>", strArrays4[1].ToString());
							stringBuilder17.Replace("<Supplier_Item_Material>", strArrays4[2].ToString());
							stringBuilder18.Replace("<Supplier_Item_Material_Label>", strArrays4[1].ToString());
							stringBuilder18.Replace("<Supplier_Item_Material>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Material_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Material>", strArrays4[2].ToString());
							stringBuilder19.Replace("<Supplier_Item_Material_Label>", strArrays4[1].ToString());
							stringBuilder19.Replace("<Supplier_Item_Material>", strArrays4[2].ToString());
							stringBuilder20.Replace("<Supplier_Item_Material_Label>", strArrays4[1].ToString());
							stringBuilder20.Replace("<Supplier_Item_Material>", strArrays4[2].ToString());
							stringBuilder21.Replace("<Supplier_Item_Material_Label>", strArrays4[1].ToString());
							stringBuilder21.Replace("<Supplier_Item_Material>", strArrays4[2].ToString());
							stringBuilder22.Replace("<Supplier_Item_Material_Label>", strArrays4[1].ToString());
							stringBuilder22.Replace("<Supplier_Item_Material>", strArrays4[2].ToString());
							stringBuilder23.Replace("<Supplier_Item_Material_Label>", strArrays4[1].ToString());
							stringBuilder23.Replace("<Supplier_Item_Material>", strArrays4[2].ToString());
							stringBuilder24.Replace("<Supplier_Item_Material_Label>", strArrays4[1].ToString());
							stringBuilder24.Replace("<Supplier_Item_Material>", strArrays4[2].ToString());
							stringBuilder25.Replace("<Supplier_Item_Material_Label>", strArrays4[1].ToString());
							stringBuilder25.Replace("<Supplier_Item_Material>", strArrays4[2].ToString());
						}
						else if (string.Compare(strArrays4[0], "Delivery", true) == 0)
						{
							stringBuilder13.Replace("<Supplier_Item_Delivery_Label>", strArrays4[1].ToString());
							stringBuilder13.Replace("<Supplier_Item_Delivery>", strArrays4[2].ToString());
							stringBuilder14.Replace("<Supplier_Item_Delivery_Label>", strArrays4[1].ToString());
							stringBuilder14.Replace("<Supplier_Item_Delivery>", strArrays4[2].ToString());
							stringBuilder15.Replace("<Supplier_Item_Delivery_Label>", strArrays4[1].ToString());
							stringBuilder15.Replace("<Supplier_Item_Delivery>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Delivery_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Delivery>", strArrays4[2].ToString());
							stringBuilder17.Replace("<Supplier_Item_Delivery_Label>", strArrays4[1].ToString());
							stringBuilder17.Replace("<Supplier_Item_Delivery>", strArrays4[2].ToString());
							stringBuilder18.Replace("<Supplier_Item_Delivery_Label>", strArrays4[1].ToString());
							stringBuilder18.Replace("<Supplier_Item_Delivery>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Delivery_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Delivery>", strArrays4[2].ToString());
							stringBuilder19.Replace("<Supplier_Item_Delivery_Label>", strArrays4[1].ToString());
							stringBuilder19.Replace("<Supplier_Item_Delivery>", strArrays4[2].ToString());
							stringBuilder20.Replace("<Supplier_Item_Delivery_Label>", strArrays4[1].ToString());
							stringBuilder20.Replace("<Supplier_Item_Delivery>", strArrays4[2].ToString());
							stringBuilder21.Replace("<Supplier_Item_Delivery_Label>", strArrays4[1].ToString());
							stringBuilder21.Replace("<Supplier_Item_Delivery>", strArrays4[2].ToString());
							stringBuilder22.Replace("<Supplier_Item_Delivery_Label>", strArrays4[1].ToString());
							stringBuilder22.Replace("<Supplier_Item_Delivery>", strArrays4[2].ToString());
							stringBuilder23.Replace("<Supplier_Item_Delivery_Label>", strArrays4[1].ToString());
							stringBuilder23.Replace("<Supplier_Item_Delivery>", strArrays4[2].ToString());
							stringBuilder24.Replace("<Supplier_Item_Delivery_Label>", strArrays4[1].ToString());
							stringBuilder24.Replace("<Supplier_Item_Delivery>", strArrays4[2].ToString());
							stringBuilder25.Replace("<Supplier_Item_Delivery_Label>", strArrays4[1].ToString());
							stringBuilder25.Replace("<Supplier_Item_Delivery>", strArrays4[2].ToString());
						}
						else if (string.Compare(strArrays4[0], "Finishing", true) == 0)
						{
							stringBuilder13.Replace("<Supplier_Item_Finishing_Label>", strArrays4[1].ToString());
							stringBuilder13.Replace("<Supplier_Item_Finishing>", strArrays4[2].ToString());
							stringBuilder14.Replace("<Supplier_Item_Finishing_Label>", strArrays4[1].ToString());
							stringBuilder14.Replace("<Supplier_Item_Finishing>", strArrays4[2].ToString());
							stringBuilder15.Replace("<Supplier_Item_Finishing_Label>", strArrays4[1].ToString());
							stringBuilder15.Replace("<Supplier_Item_Finishing>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Finishing_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Finishing>", strArrays4[2].ToString());
							stringBuilder17.Replace("<Supplier_Item_Finishing_Label>", strArrays4[1].ToString());
							stringBuilder17.Replace("<Supplier_Item_Finishing>", strArrays4[2].ToString());
							stringBuilder18.Replace("<Supplier_Item_Finishing_Label>", strArrays4[1].ToString());
							stringBuilder18.Replace("<Supplier_Item_Finishing>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Finishing_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Finishing>", strArrays4[2].ToString());
							stringBuilder19.Replace("<Supplier_Item_Finishing_Label>", strArrays4[1].ToString());
							stringBuilder19.Replace("<Supplier_Item_Finishing>", strArrays4[2].ToString());
							stringBuilder20.Replace("<Supplier_Item_Finishing_Label>", strArrays4[1].ToString());
							stringBuilder20.Replace("<Supplier_Item_Finishing>", strArrays4[2].ToString());
							stringBuilder21.Replace("<Supplier_Item_Finishing_Label>", strArrays4[1].ToString());
							stringBuilder21.Replace("<Supplier_Item_Finishing>", strArrays4[2].ToString());
							stringBuilder22.Replace("<Supplier_Item_Finishing_Label>", strArrays4[1].ToString());
							stringBuilder22.Replace("<Supplier_Item_Finishing>", strArrays4[2].ToString());
							stringBuilder23.Replace("<Supplier_Item_Finishing_Label>", strArrays4[1].ToString());
							stringBuilder23.Replace("<Supplier_Item_Finishing>", strArrays4[2].ToString());
							stringBuilder24.Replace("<Supplier_Item_Finishing_Label>", strArrays4[1].ToString());
							stringBuilder24.Replace("<Supplier_Item_Finishing>", strArrays4[2].ToString());
							stringBuilder25.Replace("<Supplier_Item_Finishing_Label>", strArrays4[1].ToString());
							stringBuilder25.Replace("<Supplier_Item_Finishing>", strArrays4[2].ToString());
						}
						else if (string.Compare(strArrays4[0], "Proofs", true) == 0)
						{
							stringBuilder13.Replace("<Supplier_Item_Proofs_Label>", strArrays4[1].ToString());
							stringBuilder13.Replace("<Supplier_Item_Proofs>", strArrays4[2].ToString());
							stringBuilder14.Replace("<Supplier_Item_Proofs_Label>", strArrays4[1].ToString());
							stringBuilder14.Replace("<Supplier_Item_Proofs>", strArrays4[2].ToString());
							stringBuilder15.Replace("<Supplier_Item_Proofs_Label>", strArrays4[1].ToString());
							stringBuilder15.Replace("<Supplier_Item_Proofs>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Proofs_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Proofs>", strArrays4[2].ToString());
							stringBuilder17.Replace("<Supplier_Item_Proofs_Label>", strArrays4[1].ToString());
							stringBuilder17.Replace("<Supplier_Item_Proofs>", strArrays4[2].ToString());
							stringBuilder18.Replace("<Supplier_Item_Proofs_Label>", strArrays4[1].ToString());
							stringBuilder18.Replace("<Supplier_Item_Proofs>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Proofs_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Proofs>", strArrays4[2].ToString());
							stringBuilder19.Replace("<Supplier_Item_Proofs_Label>", strArrays4[1].ToString());
							stringBuilder19.Replace("<Supplier_Item_Proofs>", strArrays4[2].ToString());
							stringBuilder20.Replace("<Supplier_Item_Proofs_Label>", strArrays4[1].ToString());
							stringBuilder20.Replace("<Supplier_Item_Proofs>", strArrays4[2].ToString());
							stringBuilder21.Replace("<Supplier_Item_Proofs_Label>", strArrays4[1].ToString());
							stringBuilder21.Replace("<Supplier_Item_Proofs>", strArrays4[2].ToString());
							stringBuilder22.Replace("<Supplier_Item_Proofs_Label>", strArrays4[1].ToString());
							stringBuilder22.Replace("<Supplier_Item_Proofs>", strArrays4[2].ToString());
							stringBuilder23.Replace("<Supplier_Item_Proofs_Label>", strArrays4[1].ToString());
							stringBuilder23.Replace("<Supplier_Item_Proofs>", strArrays4[2].ToString());
							stringBuilder24.Replace("<Supplier_Item_Proofs_Label>", strArrays4[1].ToString());
							stringBuilder24.Replace("<Supplier_Item_Proofs>", strArrays4[2].ToString());
							stringBuilder25.Replace("<Supplier_Item_Proofs_Label>", strArrays4[1].ToString());
							stringBuilder25.Replace("<Supplier_Item_Proofs>", strArrays4[2].ToString());
						}
						else if (string.Compare(strArrays4[0], "Packing", true) == 0)
						{
							stringBuilder13.Replace("<Supplier_Item_Packing_Label>", strArrays4[1].ToString());
							stringBuilder13.Replace("<Supplier_Item_Packing>", strArrays4[2].ToString());
							stringBuilder14.Replace("<Supplier_Item_Packing_Label>", strArrays4[1].ToString());
							stringBuilder14.Replace("<Supplier_Item_Packing>", strArrays4[2].ToString());
							stringBuilder15.Replace("<Supplier_Item_Packing_Label>", strArrays4[1].ToString());
							stringBuilder15.Replace("<Supplier_Item_Packing>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Packing_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Packing>", strArrays4[2].ToString());
							stringBuilder17.Replace("<Supplier_Item_Packing_Label>", strArrays4[1].ToString());
							stringBuilder17.Replace("<Supplier_Item_Packing>", strArrays4[2].ToString());
							stringBuilder18.Replace("<Supplier_Item_Packing_Label>", strArrays4[1].ToString());
							stringBuilder18.Replace("<Supplier_Item_Packing>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Packing_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Packing>", strArrays4[2].ToString());
							stringBuilder19.Replace("<Supplier_Item_Packing_Label>", strArrays4[1].ToString());
							stringBuilder19.Replace("<Supplier_Item_Packing>", strArrays4[2].ToString());
							stringBuilder20.Replace("<Supplier_Item_Packing_Label>", strArrays4[1].ToString());
							stringBuilder20.Replace("<Supplier_Item_Packing>", strArrays4[2].ToString());
							stringBuilder21.Replace("<Supplier_Item_Packing_Label>", strArrays4[1].ToString());
							stringBuilder21.Replace("<Supplier_Item_Packing>", strArrays4[2].ToString());
							stringBuilder22.Replace("<Supplier_Item_Packing_Label>", strArrays4[1].ToString());
							stringBuilder22.Replace("<Supplier_Item_Packing>", strArrays4[2].ToString());
							stringBuilder23.Replace("<Supplier_Item_Packing_Label>", strArrays4[1].ToString());
							stringBuilder23.Replace("<Supplier_Item_Packing>", strArrays4[2].ToString());
							stringBuilder24.Replace("<Supplier_Item_Packing_Label>", strArrays4[1].ToString());
							stringBuilder24.Replace("<Supplier_Item_Packing>", strArrays4[2].ToString());
							stringBuilder25.Replace("<Supplier_Item_Packing_Label>", strArrays4[1].ToString());
							stringBuilder25.Replace("<Supplier_Item_Packing>", strArrays4[2].ToString());
						}
						else if (string.Compare(strArrays4[0], "Notes", true) == 0)
						{
							stringBuilder13.Replace("<Supplier_Item_Notes_Label>", strArrays4[1].ToString());
							stringBuilder13.Replace("<Supplier_Item_Notes>", strArrays4[2].ToString());
							stringBuilder14.Replace("<Supplier_Item_Notes_Label>", strArrays4[1].ToString());
							stringBuilder14.Replace("<Supplier_Item_Notes>", strArrays4[2].ToString());
							stringBuilder15.Replace("<Supplier_Item_Notes_Label>", strArrays4[1].ToString());
							stringBuilder15.Replace("<Supplier_Item_Notes>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Notes_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Notes>", strArrays4[2].ToString());
							stringBuilder17.Replace("<Supplier_Item_Notes_Label>", strArrays4[1].ToString());
							stringBuilder17.Replace("<Supplier_Item_Notes>", strArrays4[2].ToString());
							stringBuilder18.Replace("<Supplier_Item_Notes_Label>", strArrays4[1].ToString());
							stringBuilder18.Replace("<Supplier_Item_Notes>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Notes_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Notes>", strArrays4[2].ToString());
							stringBuilder19.Replace("<Supplier_Item_Notes_Label>", strArrays4[1].ToString());
							stringBuilder19.Replace("<Supplier_Item_Notes>", strArrays4[2].ToString());
							stringBuilder20.Replace("<Supplier_Item_Notes_Label>", strArrays4[1].ToString());
							stringBuilder20.Replace("<Supplier_Item_Notes>", strArrays4[2].ToString());
							stringBuilder21.Replace("<Supplier_Item_Notes_Label>", strArrays4[1].ToString());
							stringBuilder21.Replace("<Supplier_Item_Notes>", strArrays4[2].ToString());
							stringBuilder22.Replace("<Supplier_Item_Notes_Label>", strArrays4[1].ToString());
							stringBuilder22.Replace("<Supplier_Item_Notes>", strArrays4[2].ToString());
							stringBuilder23.Replace("<Supplier_Item_Notes_Label>", strArrays4[1].ToString());
							stringBuilder23.Replace("<Supplier_Item_Notes>", strArrays4[2].ToString());
							stringBuilder24.Replace("<Supplier_Item_Notes_Label>", strArrays4[1].ToString());
							stringBuilder24.Replace("<Supplier_Item_Notes>", strArrays4[2].ToString());
							stringBuilder25.Replace("<Supplier_Item_Notes_Label>", strArrays4[1].ToString());
							stringBuilder25.Replace("<Supplier_Item_Notes>", strArrays4[2].ToString());
						}
						else if (string.Compare(strArrays4[0], "Instructions", true) == 0)
						{
							stringBuilder13.Replace("<Supplier_Item_Terms_Instructions_Label>", strArrays4[1].ToString());
							stringBuilder13.Replace("<Supplier_Item_Terms_Instructions>", strArrays4[2].ToString());
							stringBuilder14.Replace("<Supplier_Item_Terms_Instructions_Label>", strArrays4[1].ToString());
							stringBuilder14.Replace("<Supplier_Item_Terms_Instructions>", strArrays4[2].ToString());
							stringBuilder15.Replace("<Supplier_Item_Terms_Instructions_Label>", strArrays4[1].ToString());
							stringBuilder15.Replace("<Supplier_Item_Terms_Instructions>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Terms_Instructions_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Terms_Instructions>", strArrays4[2].ToString());
							stringBuilder17.Replace("<Supplier_Item_Terms_Instructions_Label>", strArrays4[1].ToString());
							stringBuilder17.Replace("<Supplier_Item_Terms_Instructions>", strArrays4[2].ToString());
							stringBuilder18.Replace("<Supplier_Item_Terms_Instructions_Label>", strArrays4[1].ToString());
							stringBuilder18.Replace("<Supplier_Item_Terms_Instructions>", strArrays4[2].ToString());
							stringBuilder16.Replace("<Supplier_Item_Terms_Instructions_Label>", strArrays4[1].ToString());
							stringBuilder16.Replace("<Supplier_Item_Terms_Instructions>", strArrays4[2].ToString());
							stringBuilder19.Replace("<Supplier_Item_Terms_Instructions_Label>", strArrays4[1].ToString());
							stringBuilder19.Replace("<Supplier_Item_Terms_Instructions>", strArrays4[2].ToString());
							stringBuilder20.Replace("<Supplier_Item_Terms_Instructions_Label>", strArrays4[1].ToString());
							stringBuilder20.Replace("<Supplier_Item_Terms_Instructions>", strArrays4[2].ToString());
							stringBuilder21.Replace("<Supplier_Item_Terms_Instructions_Label>", strArrays4[1].ToString());
							stringBuilder21.Replace("<Supplier_Item_Terms_Instructions>", strArrays4[2].ToString());
							stringBuilder22.Replace("<Supplier_Item_Terms_Instructions_Label>", strArrays4[1].ToString());
							stringBuilder22.Replace("<Supplier_Item_Terms_Instructions>", strArrays4[2].ToString());
							stringBuilder23.Replace("<Supplier_Item_Terms_Instructions_Label>", strArrays4[1].ToString());
							stringBuilder23.Replace("<Supplier_Item_Terms_Instructions>", strArrays4[2].ToString());
							stringBuilder24.Replace("<Supplier_Item_Terms_Instructions_Label>", strArrays4[1].ToString());
							stringBuilder24.Replace("<Supplier_Item_Terms_Instructions>", strArrays4[2].ToString());
							stringBuilder25.Replace("<Supplier_Item_Terms_Instructions_Label>", strArrays4[1].ToString());
							stringBuilder25.Replace("<Supplier_Item_Terms_Instructions>", strArrays4[2].ToString());
						}
						for (int n = 1; n <= 25; n++)
						{
							if (string.Compare(strArrays4[0], string.Concat("Custom Description ", n.ToString()), true) == 0)
							{
								stringBuilder13.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), "_Label>"), strArrays4[1].ToString());
								stringBuilder13.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), ">"), strArrays4[2].ToString());
								stringBuilder14.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), "_Label>"), strArrays4[1].ToString());
								stringBuilder14.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), ">"), strArrays4[2].ToString());
								stringBuilder15.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), "_Label>"), strArrays4[1].ToString());
								stringBuilder15.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), ">"), strArrays4[2].ToString());
								stringBuilder16.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), "_Label>"), strArrays4[1].ToString());
								stringBuilder16.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), ">"), strArrays4[2].ToString());
								stringBuilder17.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), "_Label>"), strArrays4[1].ToString());
								stringBuilder17.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), ">"), strArrays4[2].ToString());
								stringBuilder18.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), "_Label>"), strArrays4[1].ToString());
								stringBuilder18.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), ">"), strArrays4[2].ToString());
								stringBuilder16.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), "_Label>"), strArrays4[1].ToString());
								stringBuilder16.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), ">"), strArrays4[2].ToString());
								stringBuilder19.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), "_Label>"), strArrays4[1].ToString());
								stringBuilder19.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), ">"), strArrays4[2].ToString());
								stringBuilder20.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), "_Label>"), strArrays4[1].ToString());
								stringBuilder20.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), ">"), strArrays4[2].ToString());
								stringBuilder21.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), "_Label>"), strArrays4[1].ToString());
								stringBuilder21.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), ">"), strArrays4[2].ToString());
								stringBuilder22.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), "_Label>"), strArrays4[1].ToString());
								stringBuilder22.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), ">"), strArrays4[2].ToString());
								stringBuilder23.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), "_Label>"), strArrays4[1].ToString());
								stringBuilder23.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), ">"), strArrays4[2].ToString());
								stringBuilder24.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), "_Label>"), strArrays4[1].ToString());
								stringBuilder24.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), ">"), strArrays4[2].ToString());
								stringBuilder25.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), "_Label>"), strArrays4[1].ToString());
								stringBuilder25.Replace(string.Concat("<Supplier_Custom_Description_", n.ToString(), ">"), strArrays4[2].ToString());
							}
						}
					}
				}
			}
			if (empty.Trim().ToLower() == "x")
			{
				StringBuilder stringBuilder28 = new StringBuilder();
				foreach (DataRow dataRow6 in dataSet.Tables[2].Rows)
				{
					stringBuilder28.Append(string.Concat(dataRow6["webothercostName"].ToString(), ": ", dataRow6["SelectedValue"].ToString(), "\n"));
				}
				stringBuilder13.Replace("<estore_Additionaloptions_Name>", stringBuilder28.ToString());
				stringBuilder14.Replace("<estore_Additionaloptions_Name>", stringBuilder28.ToString());
				stringBuilder15.Replace("<estore_Additionaloptions_Name>", stringBuilder28.ToString());
				stringBuilder16.Replace("<estore_Additionaloptions_Name>", stringBuilder28.ToString());
				stringBuilder17.Replace("<estore_Additionaloptions_Name>", stringBuilder28.ToString());
				stringBuilder18.Replace("<estore_Additionaloptions_Name>", stringBuilder28.ToString());
				stringBuilder19.Replace("<estore_Additionaloptions_Name>", stringBuilder28.ToString());
				stringBuilder20.Replace("<estore_Additionaloptions_Name>", stringBuilder28.ToString());
				stringBuilder21.Replace("<estore_Additionaloptions_Name>", stringBuilder28.ToString());
				stringBuilder22.Replace("<estore_Additionaloptions_Name>", stringBuilder28.ToString());
				stringBuilder23.Replace("<estore_Additionaloptions_Name>", stringBuilder28.ToString());
				stringBuilder24.Replace("<estore_Additionaloptions_Name>", stringBuilder28.ToString());
				stringBuilder25.Replace("<estore_Additionaloptions_Name>", stringBuilder28.ToString());
			}
			foreach (DataRow row7 in dataTable.Rows)
			{
				if (row7["TagName"].ToString().Trim().ToLower() == "<1linebreak>")
				{
					continue;
				}
				if (stringBuilder13.ToString().Contains(row7["TagName"].ToString()))
				{
					stringBuilder13.Replace(row7["TagName"].ToString(), " ");
				}
				if (stringBuilder14.ToString().Contains(row7["TagName"].ToString()))
				{
					stringBuilder14.Replace(row7["TagName"].ToString(), "");
				}
				if (stringBuilder15.ToString().Contains(row7["TagName"].ToString()))
				{
					stringBuilder15.Replace(row7["TagName"].ToString(), "");
				}
				if (stringBuilder16.ToString().Contains(row7["TagName"].ToString()))
				{
					stringBuilder16.Replace(row7["TagName"].ToString(), "");
				}
				if (stringBuilder17.ToString().Contains(row7["TagName"].ToString()))
				{
					stringBuilder17.Replace(row7["TagName"].ToString(), "");
				}
				if (stringBuilder18.ToString().Contains(row7["TagName"].ToString()))
				{
					stringBuilder18.Replace(row7["TagName"].ToString(), "");
				}
				if (stringBuilder19.ToString().Contains(row7["TagName"].ToString()))
				{
					stringBuilder19.Replace(row7["TagName"].ToString(), "");
				}
				if (stringBuilder20.ToString().Contains(row7["TagName"].ToString()))
				{
					stringBuilder20.Replace(row7["TagName"].ToString(), "");
				}
				if (stringBuilder21.ToString().Contains(row7["TagName"].ToString()))
				{
					stringBuilder21.Replace(row7["TagName"].ToString(), "");
				}
				if (stringBuilder22.ToString().Contains(row7["TagName"].ToString()))
				{
					stringBuilder22.Replace(row7["TagName"].ToString(), "");
				}
				if (stringBuilder23.ToString().Contains(row7["TagName"].ToString()))
				{
					stringBuilder23.Replace(row7["TagName"].ToString(), "");
				}
				if (stringBuilder24.ToString().Contains(row7["TagName"].ToString()))
				{
					stringBuilder24.Replace(row7["TagName"].ToString(), "");
				}
				if (!stringBuilder25.ToString().Contains(row7["TagName"].ToString()))
				{
					continue;
				}
				stringBuilder25.Replace(row7["TagName"].ToString(), "");
			}
			stringBuilder.Append(stringBuilder13);
			stringBuilder1.Append(stringBuilder14);
			stringBuilder2.Append(stringBuilder15);
			stringBuilder3.Append(stringBuilder16);
			stringBuilder4.Append(stringBuilder17);
			stringBuilder5.Append(stringBuilder18);
			stringBuilder6.Append(stringBuilder19);
			stringBuilder7.Append(stringBuilder20);
			stringBuilder8.Append(stringBuilder21);
			stringBuilder9.Append(stringBuilder22);
			stringBuilder10.Append(stringBuilder23);
			stringBuilder11.Append(stringBuilder24);
			stringBuilder12.Append(stringBuilder25);
		}
		JobBasePage.PCR_JOBCard_Values_Update_After_Replace(num, EstimateCommonMethods.RemoveSpecialChar(stringBuilder.ToString()), EstimateCommonMethods.RemoveSpecialChar(stringBuilder1.ToString()), EstimateCommonMethods.RemoveSpecialChar(stringBuilder2.ToString()), EstimateCommonMethods.RemoveSpecialChar(stringBuilder4.ToString()), EstimateCommonMethods.RemoveSpecialChar(stringBuilder5.ToString()), EstimateCommonMethods.RemoveSpecialChar(stringBuilder3.ToString()), EstimateCommonMethods.RemoveSpecialChar(stringBuilder6.ToString()), EstimateCommonMethods.RemoveSpecialChar(stringBuilder7.ToString()), EstimateCommonMethods.RemoveSpecialChar(stringBuilder8.ToString()), EstimateCommonMethods.RemoveSpecialChar(stringBuilder9.ToString()), EstimateCommonMethods.RemoveSpecialChar(stringBuilder10.ToString()), EstimateCommonMethods.RemoveSpecialChar(stringBuilder11.ToString()), EstimateCommonMethods.RemoveSpecialChar(stringBuilder12.ToString()));
	}

	public static string strItemDesc(string strArray_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			string[] strArrays = strArray_0.Split(new char[] { '»' });
			if ((int)strArrays.Length != 2)
			{
				for (int i = 0; i < (int)strArrays.Length; i++)
				{
					if (i == 2 && string.Compare(strArrays[3].ToString(), "true", true) == 0 && !string.IsNullOrEmpty(strArrays[2].ToString()))
					{
						stringBuilder.AppendFormat("{0}: {1} \n", strArrays[1].ToString(), strArrays[2].ToString());
					}
				}
			}
			else
			{
				for (int j = 0; j < (int)strArrays.Length; j++)
				{
					if (j == 1 && !string.IsNullOrEmpty(strArrays[1].ToString()))
					{
						stringBuilder.AppendFormat("{0}: {1} \n", strArrays[0].ToString(), strArrays[1].ToString());
					}
				}
			}
		}
		catch
		{
		}
		return stringBuilder.ToString();
	}

	private static void TakeItemDescriptionFromPhrase(EstimateCommonMethodsItems objItems, int CompanyID, string Estimationtype)
	{
		foreach (DataRow row in SettingsBasePage.settings_default_phrasebook_forestimate_select(CompanyID, "Estimate").Rows)
		{
			string str = row["PhraseType"].ToString();
			string str1 = row["PhraseText"].ToString();
			if (string.Compare(str, "Estimate Title", true) == 0)
			{
				objItems.ItemTitle = str1;
			}
			if (string.Compare(str, "Estimate Description", true) == 0)
			{
				objItems.Description = str1;
			}
			if (string.Compare(str, "Estimate Artwork", true) == 0)
			{
				objItems.Artwork = str1;
			}
			if (string.Compare(str, "Estimate Colours", true) == 0)
			{
				objItems.Colour = str1;
			}
			if (string.Compare(str, "Estimate Size", true) == 0)
			{
				objItems.Size = str1;
			}
			if (string.Compare(str, "Estimate Material", true) == 0)
			{
				objItems.Material = str1;
			}
			if (string.Compare(str, "Estimate Delivery", true) == 0)
			{
				objItems.Delivery = str1;
			}
			if (string.Compare(str, "Estimate Finishing", true) == 0)
			{
				objItems.Finishing = str1;
			}
			if (string.Compare(str, "Estimate Proofs", true) == 0)
			{
				objItems.Proofs = str1;
			}
			if (string.Compare(str, "Estimate Packing", true) == 0)
			{
				objItems.Packing = str1;
			}
			if (string.Compare(str, "Estimate Notes", true) == 0)
			{
				objItems.Notes = str1;
			}
			if (string.Compare(str, "Estimate Terms", true) == 0)
			{
				objItems.Instructions = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription1", true) == 0)
			{
				objItems.CustomDescription1 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription2", true) == 0)
			{
				objItems.CustomDescription2 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription3", true) == 0)
			{
				objItems.CustomDescription3 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription4", true) == 0)
			{
				objItems.CustomDescription4 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription5", true) == 0)
			{
				objItems.CustomDescription5 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription6", true) == 0)
			{
				objItems.CustomDescription6 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription7", true) == 0)
			{
				objItems.CustomDescription7 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription8", true) == 0)
			{
				objItems.CustomDescription8 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription9", true) == 0)
			{
				objItems.CustomDescription9 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription10", true) == 0)
			{
				objItems.CustomDescription10 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription11", true) == 0)
			{
				objItems.CustomDescription11 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription12", true) == 0)
			{
				objItems.CustomDescription12 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription13", true) == 0)
			{
				objItems.CustomDescription13 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription14", true) == 0)
			{
				objItems.CustomDescription14 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription15", true) == 0)
			{
				objItems.CustomDescription15 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription16", true) == 0)
			{
				objItems.CustomDescription16 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription17", true) == 0)
			{
				objItems.CustomDescription17 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription18", true) == 0)
			{
				objItems.CustomDescription18 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription19", true) == 0)
			{
				objItems.CustomDescription19 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription20", true) == 0)
			{
				objItems.CustomDescription20 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription21", true) == 0)
			{
				objItems.CustomDescription21 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription22", true) == 0)
			{
				objItems.CustomDescription22 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription23", true) == 0)
			{
				objItems.CustomDescription23 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription24", true) == 0)
			{
				objItems.CustomDescription24 = str1;
			}
			if (string.Compare(str, "Estimate CustomDescription25", true) != 0)
			{
				continue;
			}
			objItems.CustomDescription25 = str1;
		}
	}

	private static void TakeItemLabelsFromSettings(EstimateCommonMethodsItems objItems, int CompanyID, string Estimationtype)
	{
		DataSet dataSet = EstimatesBasePage.itemdescription_selectall_fromSettings_foralltypes(CompanyID, Estimationtype);
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet != null)
		{
			objItems.isItemTitleLabel = true;
			objItems.IsItemTitleTemplate = true;
			objItems.ItemTitleLabel = dataSet.Tables[0].Rows[0]["ScreenName"].ToString();
			if (dataSet.Tables[0].Rows[1]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isDescriptionLabel = false;
				objItems.IsDescriptionTemplate = false;
				objItems.DescriptionLabel = dataSet.Tables[0].Rows[1]["ScreenName"].ToString();
			}
			else
			{
				objItems.isDescriptionLabel = true;
				objItems.IsDescriptionTemplate = true;
				objItems.DescriptionLabel = dataSet.Tables[0].Rows[1]["ScreenName"].ToString();
			}
			if (dataSet.Tables[0].Rows[2]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isArtworkLabel = false;
				objItems.IsArtworkTemplate = false;
				objItems.ArtworkLabel = dataSet.Tables[0].Rows[2]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isArtworkLabel = true;
				objItems.IsArtworkTemplate = true;
				objItems.ArtworkLabel = dataSet.Tables[0].Rows[2]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[3]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isColourLabel = false;
				objItems.IsColourTemplate = false;
				objItems.ColourLabel = dataSet.Tables[0].Rows[3]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isColourLabel = true;
				objItems.IsColourTemplate = true;
				objItems.ColourLabel = dataSet.Tables[0].Rows[3]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[4]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isSizeLabel = false;
				objItems.IsSizeTemplate = false;
				objItems.SizeLabel = dataSet.Tables[0].Rows[4]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isSizeLabel = true;
				objItems.IsSizeTemplate = true;
				objItems.SizeLabel = dataSet.Tables[0].Rows[4]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[5]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isMaterialLabel = false;
				objItems.IsMaterialTemplate = false;
				objItems.MaterialLabel = dataSet.Tables[0].Rows[5]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isMaterialLabel = true;
				objItems.IsMaterialTemplate = true;
				objItems.MaterialLabel = dataSet.Tables[0].Rows[5]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[6]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isDeliveryLabel = false;
				objItems.IsDeliveryTemplate = false;
				objItems.DeliveryLabel = dataSet.Tables[0].Rows[6]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isDeliveryLabel = true;
				objItems.IsDeliveryTemplate = true;
				objItems.DeliveryLabel = dataSet.Tables[0].Rows[6]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[7]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isFinishingLabel = false;
				objItems.IsFinishingTemplate = false;
				objItems.FinishingLabel = dataSet.Tables[0].Rows[7]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isFinishingLabel = true;
				objItems.IsFinishingTemplate = true;
				objItems.FinishingLabel = dataSet.Tables[0].Rows[7]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[8]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isProofsLabel = false;
				objItems.IsProofsTemplate = false;
				objItems.ProofsLabel = dataSet.Tables[0].Rows[8]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isProofsLabel = true;
				objItems.IsProofsTemplate = true;
				objItems.ProofsLabel = dataSet.Tables[0].Rows[8]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[9]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isPackingLabel = false;
				objItems.IsPackingTemplate = false;
				objItems.PackingLabel = dataSet.Tables[0].Rows[9]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isPackingLabel = true;
				objItems.IsPackingTemplate = true;
				objItems.PackingLabel = dataSet.Tables[0].Rows[9]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[10]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isNotesLabel = false;
				objItems.IsNotesTemplate = false;
				objItems.NotesLabel = dataSet.Tables[0].Rows[10]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isNotesLabel = true;
				objItems.IsNotesTemplate = true;
				objItems.NotesLabel = dataSet.Tables[0].Rows[10]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[11]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isInstructionsLabel = false;
				objItems.IsInstructionsTemplate = false;
				objItems.InstructionsLabel = dataSet.Tables[0].Rows[11]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isInstructionsLabel = true;
				objItems.IsInstructionsTemplate = true;
				objItems.InstructionsLabel = dataSet.Tables[0].Rows[11]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[12]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription1 = false;
				objItems.IsCustomDescription1Template = false;
				objItems.CustomDescriptionLabel1 = dataSet.Tables[0].Rows[12]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription1 = true;
				objItems.IsCustomDescription1Template = true;
				objItems.CustomDescriptionLabel1 = dataSet.Tables[0].Rows[12]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[13]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription2 = false;
				objItems.IsCustomDescription2Template = false;
				objItems.CustomDescriptionLabel2 = dataSet.Tables[0].Rows[13]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription2 = true;
				objItems.IsCustomDescription2Template = true;
				objItems.CustomDescriptionLabel2 = dataSet.Tables[0].Rows[13]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[14]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription3 = false;
				objItems.IsCustomDescription3Template = false;
				objItems.CustomDescriptionLabel3 = dataSet.Tables[0].Rows[14]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription3 = true;
				objItems.IsCustomDescription3Template = true;
				objItems.CustomDescriptionLabel3 = dataSet.Tables[0].Rows[14]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[15]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription4 = false;
				objItems.IsCustomDescription4Template = false;
				objItems.CustomDescriptionLabel4 = dataSet.Tables[0].Rows[15]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription4 = true;
				objItems.IsCustomDescription4Template = true;
				objItems.CustomDescriptionLabel4 = dataSet.Tables[0].Rows[15]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[16]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription5 = false;
				objItems.IsCustomDescription5Template = false;
				objItems.CustomDescriptionLabel5 = dataSet.Tables[0].Rows[16]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription5 = true;
				objItems.IsCustomDescription5Template = true;
				objItems.CustomDescriptionLabel5 = dataSet.Tables[0].Rows[16]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[17]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription6 = false;
				objItems.IsCustomDescription6Template = false;
				objItems.CustomDescriptionLabel6 = dataSet.Tables[0].Rows[17]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription6 = true;
				objItems.IsCustomDescription6Template = true;
				objItems.CustomDescriptionLabel6 = dataSet.Tables[0].Rows[17]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[18]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription7 = false;
				objItems.IsCustomDescription7Template = false;
				objItems.CustomDescriptionLabel7 = dataSet.Tables[0].Rows[18]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription7 = true;
				objItems.IsCustomDescription7Template = true;
				objItems.CustomDescriptionLabel7 = dataSet.Tables[0].Rows[18]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[19]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription8 = false;
				objItems.IsCustomDescription8Template = false;
				objItems.CustomDescriptionLabel8 = dataSet.Tables[0].Rows[19]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription8 = true;
				objItems.IsCustomDescription8Template = true;
				objItems.CustomDescriptionLabel8 = dataSet.Tables[0].Rows[19]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[20]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription9 = false;
				objItems.IsCustomDescription9Template = false;
				objItems.CustomDescriptionLabel9 = dataSet.Tables[0].Rows[20]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription9 = true;
				objItems.IsCustomDescription9Template = true;
				objItems.CustomDescriptionLabel9 = dataSet.Tables[0].Rows[20]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[21]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription10 = false;
				objItems.IsCustomDescription10Template = false;
				objItems.CustomDescriptionLabel10 = dataSet.Tables[0].Rows[21]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription10 = true;
				objItems.IsCustomDescription10Template = true;
				objItems.CustomDescriptionLabel10 = dataSet.Tables[0].Rows[21]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[22]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription11 = false;
				objItems.IsCustomDescription11Template = false;
				objItems.CustomDescriptionLabel11 = dataSet.Tables[0].Rows[22]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription11 = true;
				objItems.IsCustomDescription11Template = true;
				objItems.CustomDescriptionLabel11 = dataSet.Tables[0].Rows[22]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[23]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription12 = false;
				objItems.IsCustomDescription12Template = false;
				objItems.CustomDescriptionLabel12 = dataSet.Tables[0].Rows[23]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription12 = true;
				objItems.IsCustomDescription12Template = true;
				objItems.CustomDescriptionLabel12 = dataSet.Tables[0].Rows[23]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[24]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription13 = false;
				objItems.IsCustomDescription13Template = false;
				objItems.CustomDescriptionLabel13 = dataSet.Tables[0].Rows[24]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription13 = true;
				objItems.IsCustomDescription13Template = true;
				objItems.CustomDescriptionLabel13 = dataSet.Tables[0].Rows[24]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[25]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription14 = false;
				objItems.IsCustomDescription14Template = false;
				objItems.CustomDescriptionLabel14 = dataSet.Tables[0].Rows[25]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription14 = true;
				objItems.IsCustomDescription14Template = true;
				objItems.CustomDescriptionLabel14 = dataSet.Tables[0].Rows[25]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[26]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription15 = false;
				objItems.IsCustomDescription15Template = false;
				objItems.CustomDescriptionLabel15 = dataSet.Tables[0].Rows[26]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription15 = true;
				objItems.IsCustomDescription15Template = true;
				objItems.CustomDescriptionLabel15 = dataSet.Tables[0].Rows[26]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[27]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription16 = false;
				objItems.IsCustomDescription16Template = false;
				objItems.CustomDescriptionLabel16 = dataSet.Tables[0].Rows[27]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription16 = true;
				objItems.IsCustomDescription16Template = true;
				objItems.CustomDescriptionLabel16 = dataSet.Tables[0].Rows[27]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[28]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription17 = false;
				objItems.IsCustomDescription17Template = false;
				objItems.CustomDescriptionLabel17 = dataSet.Tables[0].Rows[28]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription17 = true;
				objItems.IsCustomDescription17Template = true;
				objItems.CustomDescriptionLabel17 = dataSet.Tables[0].Rows[28]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[29]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription18 = false;
				objItems.IsCustomDescription18Template = false;
				objItems.CustomDescriptionLabel18 = dataSet.Tables[0].Rows[29]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription18 = true;
				objItems.IsCustomDescription18Template = true;
				objItems.CustomDescriptionLabel18 = dataSet.Tables[0].Rows[29]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[30]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription19 = false;
				objItems.IsCustomDescription19Template = false;
				objItems.CustomDescriptionLabel19 = dataSet.Tables[0].Rows[30]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription19 = true;
				objItems.IsCustomDescription19Template = true;
				objItems.CustomDescriptionLabel19 = dataSet.Tables[0].Rows[30]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[31]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription20 = false;
				objItems.IsCustomDescription20Template = false;
				objItems.CustomDescriptionLabel20 = dataSet.Tables[0].Rows[31]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription20 = true;
				objItems.IsCustomDescription20Template = true;
				objItems.CustomDescriptionLabel20 = dataSet.Tables[0].Rows[31]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[32]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription21 = false;
				objItems.IsCustomDescription21Template = false;
				objItems.CustomDescriptionLabel21 = dataSet.Tables[0].Rows[32]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription21 = true;
				objItems.IsCustomDescription21Template = true;
				objItems.CustomDescriptionLabel21 = dataSet.Tables[0].Rows[32]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[33]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription22 = false;
				objItems.IsCustomDescription22Template = false;
				objItems.CustomDescriptionLabel22 = dataSet.Tables[0].Rows[33]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription22 = true;
				objItems.IsCustomDescription22Template = true;
				objItems.CustomDescriptionLabel22 = dataSet.Tables[0].Rows[33]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[34]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription23 = false;
				objItems.IsCustomDescription23Template = false;
				objItems.CustomDescriptionLabel23 = dataSet.Tables[0].Rows[34]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription23 = true;
				objItems.IsCustomDescription23Template = true;
				objItems.CustomDescriptionLabel23 = dataSet.Tables[0].Rows[34]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[35]["IsChecked"].ToString().Trim().ToLower() != "true")
			{
				objItems.isCustomDescription24 = false;
				objItems.IsCustomDescription24Template = false;
				objItems.CustomDescriptionLabel24 = dataSet.Tables[0].Rows[35]["ScreenName"].ToString().Trim();
			}
			else
			{
				objItems.isCustomDescription24 = true;
				objItems.IsCustomDescription24Template = true;
				objItems.CustomDescriptionLabel24 = dataSet.Tables[0].Rows[35]["ScreenName"].ToString().Trim();
			}
			if (dataSet.Tables[0].Rows[36]["IsChecked"].ToString().Trim().ToLower() == "true")
			{
				objItems.isCustomDescription25 = true;
				objItems.IsCustomDescription25Template = true;
				objItems.CustomDescriptionLabel25 = dataSet.Tables[0].Rows[36]["ScreenName"].ToString().Trim();
				return;
			}
			objItems.isCustomDescription25 = false;
			objItems.IsCustomDescription25Template = false;
			objItems.CustomDescriptionLabel25 = dataSet.Tables[0].Rows[36]["ScreenName"].ToString().Trim();
		}
	}

	public static void UpdateDescription(long EstimateItemID, long EstimateID, string Estimationtype, bool isRerun)
	{
		string[] str;
		char[] chrArray;
		int count;
		string size;
		BasePage basePage = new BasePage();
		commonClass _commonClass = new commonClass();
		EstimateCommonMethodsItems estimateCommonMethodsItem = new EstimateCommonMethodsItems();
		int num = Convert.ToInt32(HttpContext.Current.Session["CompanyID"]);
		int num1 = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
		string regionalSettings = basePage.GetRegionalSettings(num, "PaperMeasure");
		string regionalSettings1 = basePage.GetRegionalSettings(num, "Colour");
		string empty = string.Empty;
		string empty1 = string.Empty;
		string DecimalPaperSizeFlag = string.Empty;
		int DecimalPaperSize = 0;
		foreach (DataRow dataRow in SettingsBasePage.Price_For_Whole_Pack_Select(num).Rows)
		{
			DecimalPaperSizeFlag = dataRow["Decimal3ForPaperSizes"] != DBNull.Value
							   ? dataRow["Decimal3ForPaperSizes"].ToString() : "False";
		}
		if (DecimalPaperSizeFlag.ToLower() == "true")
		{
			DecimalPaperSize = 3;
		}
		else
		{
			DecimalPaperSize = 0;
		}
		if (EstimateItemID != (long)0)
		{
			try
			{
				EstimateCommonMethods.TakeItemLabelsFromSettings(estimateCommonMethodsItem, num, Estimationtype);
			}
			catch
			{
			}
			try
			{
				if (Estimationtype.Trim().ToLower() != "c")
				{
					EstimateCommonMethods.TakeItemDescriptionFromPhrase(estimateCommonMethodsItem, num, Estimationtype);
				}
			}
			catch
			{
			}
			if (string.Compare(Estimationtype, "S", true) == 0)
			{
				DataTable dataTable = EstimatesBasePage.item_select_itemDescription_foralltypes(num, EstimateItemID, "S");
				string str1 = string.Empty;
				empty = "ItemDescDigital_Single";
				DataTable dataTable1 = SettingsBasePage.DefaultSettings_ProductType_Select((long)num, empty);
				if (dataTable1.Rows.Count > 0)
				{
					empty1 = dataTable1.Rows[0]["ItemDescDigital_Single"].ToString();
				}
				foreach (DataRow row in dataTable.Rows)
				{
					estimateCommonMethodsItem.ItemTitle = row["ItemTitle"].ToString();
					estimateCommonMethodsItem.IsDoubleSided = row["IsDoubleSided"].ToString();
					estimateCommonMethodsItem.Colour = row["Colour"].ToString();
					estimateCommonMethodsItem.Sidecolour = row["SideColor"].ToString();
					estimateCommonMethodsItem.isjobcustom = row["isjobcustom"].ToString();
					if (estimateCommonMethodsItem.isjobcustom.Trim().ToLower() != "false")
					{
						string str2 = row["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						string str3 = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str2.Split(chrArray)[0].ToString()), DecimalPaperSize, " ", false, false, false);
						string str4 = row["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						estimateCommonMethodsItem.Size = string.Concat(str3, "X", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str4.Split(chrArray)[1].ToString()), DecimalPaperSize, " ", false, false, false));
					}
					else
					{
						str = new string[] { row["PaperSizeName"].ToString(), ": ", null, null, null };
						string str5 = row["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						str[2] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str5.Split(chrArray)[0].ToString()), DecimalPaperSize, " ", false, false, false);
						str[3] = "X";
						string str6 = row["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						str[4] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str6.Split(chrArray)[1].ToString()), DecimalPaperSize, " ", false, false, false);
						estimateCommonMethodsItem.Size = string.Concat(str);
					}
					estimateCommonMethodsItem.Size = string.Concat(estimateCommonMethodsItem.Size, " ", regionalSettings);
					estimateCommonMethodsItem.Material = row["papername"].ToString();
				}
				if (estimateCommonMethodsItem.IsDoubleSided != "True")
				{
					if (estimateCommonMethodsItem.Colour != "color")
					{
						estimateCommonMethodsItem.Colour = "Black & White";
					}
					else
					{
						estimateCommonMethodsItem.Colour = regionalSettings1;
					}
					estimateCommonMethodsItem.Colour = string.Concat("Side1: ", estimateCommonMethodsItem.Colour);
				}
				else
				{
					if (estimateCommonMethodsItem.Colour != "color")
					{
						estimateCommonMethodsItem.Colour = "Black & White";
					}
					else
					{
						estimateCommonMethodsItem.Colour = regionalSettings1;
					}
					if (estimateCommonMethodsItem.Sidecolour != "color")
					{
						estimateCommonMethodsItem.Sidecolour = "Black & White";
					}
					else
					{
						estimateCommonMethodsItem.Sidecolour = regionalSettings1;
					}
					estimateCommonMethodsItem.Colour = string.Concat("Side1: ", estimateCommonMethodsItem.Colour, "\nSide2: ", estimateCommonMethodsItem.Sidecolour);
				}
				if (empty1.ToLower() == "true")
				{
					DataTable dataTable2 = SettingsBasePage.PhraseBook_Colour_Size_Material_Select((long)num);
					if (dataTable2.Rows.Count > 0)
					{
						estimateCommonMethodsItem.Colour = dataTable2.Rows[0]["Colours"].ToString();
						estimateCommonMethodsItem.Material = dataTable2.Rows[0]["Material"].ToString();
						estimateCommonMethodsItem.Size = dataTable2.Rows[0]["Size"].ToString();
					}
				}
			}
			else if (string.Compare(Estimationtype, "P", true) == 0)
			{
				DataTable dataTable3 = EstimatesBasePage.item_select_itemDescription_foralltypes(num, EstimateItemID, "P");
				empty = "ItemDescDigital_Pad";
				DataTable dataTable4 = SettingsBasePage.DefaultSettings_ProductType_Select((long)num, empty);
				if (dataTable4.Rows.Count > 0)
				{
					empty1 = dataTable4.Rows[0]["ItemDescDigital_Pad"].ToString();
				}
				foreach (DataRow dataRow in dataTable3.Rows)
				{
					estimateCommonMethodsItem.ItemTitle = dataRow["ItemTitle"].ToString();
					estimateCommonMethodsItem.IsDoubleSided = dataRow["IsDoubleSided"].ToString();
					estimateCommonMethodsItem.Colour = dataRow["Colour"].ToString();
					estimateCommonMethodsItem.Sidecolour = dataRow["SideColor"].ToString();
					estimateCommonMethodsItem.LeavesPerPad = string.Concat(Convert.ToString(_commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(dataRow["LeavesPerPad"].ToString()), 0, "", true, false, false)), " page Pads");
					estimateCommonMethodsItem.isjobcustom = dataRow["isjobcustom"].ToString();
					if (estimateCommonMethodsItem.isjobcustom.Trim().ToLower() != "false")
					{
						string str7 = dataRow["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						string str8 = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str7.Split(chrArray)[0].ToString()), DecimalPaperSize, " ", false, false, false);
						string str9 = dataRow["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						estimateCommonMethodsItem.Size = string.Concat(str8, "X", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str9.Split(chrArray)[1].ToString()), DecimalPaperSize, " ", false, false, false));
					}
					else
					{
						str = new string[] { dataRow["PaperSizeName"].ToString(), ": ", null, null, null };
						string str10 = dataRow["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						str[2] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str10.Split(chrArray)[0].ToString()), DecimalPaperSize, " ", false, false, false);
						str[3] = "X";
						string str11 = dataRow["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						str[4] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str11.Split(chrArray)[1].ToString()), DecimalPaperSize, " ", false, false, false);
						estimateCommonMethodsItem.Size = string.Concat(str);
					}
					estimateCommonMethodsItem.Size = string.Concat(estimateCommonMethodsItem.Size, " ", regionalSettings);
					estimateCommonMethodsItem.Material = dataRow["papername"].ToString();
				}
				if (estimateCommonMethodsItem.IsDoubleSided != "True")
				{
					if (estimateCommonMethodsItem.Colour != "color")
					{
						estimateCommonMethodsItem.Colour = "Black & White";
					}
					else
					{
						estimateCommonMethodsItem.Colour = regionalSettings1;
					}
					estimateCommonMethodsItem.Colour = string.Concat("Side1: ", estimateCommonMethodsItem.Colour);
				}
				else
				{
					if (estimateCommonMethodsItem.Colour != "color")
					{
						estimateCommonMethodsItem.Colour = "Black & White";
					}
					else
					{
						estimateCommonMethodsItem.Colour = regionalSettings1;
					}
					if (estimateCommonMethodsItem.Sidecolour != "color")
					{
						estimateCommonMethodsItem.Sidecolour = "Black & White";
					}
					else
					{
						estimateCommonMethodsItem.Sidecolour = regionalSettings1;
					}
					estimateCommonMethodsItem.Colour = string.Concat("Side1: ", estimateCommonMethodsItem.Colour, "\nSide2: ", estimateCommonMethodsItem.Sidecolour);
				}
				if (empty1.ToLower() == "true")
				{
					DataTable dataTable5 = SettingsBasePage.PhraseBook_Colour_Size_Material_Select((long)num);
					if (dataTable5.Rows.Count > 0)
					{
						estimateCommonMethodsItem.Colour = dataTable5.Rows[0]["Colours"].ToString();
						estimateCommonMethodsItem.Material = dataTable5.Rows[0]["Material"].ToString();
						estimateCommonMethodsItem.Size = dataTable5.Rows[0]["Size"].ToString();
					}
				}
			}
			else if (string.Compare(Estimationtype, "B", true) == 0)
			{
				DataTable dataTable6 = EstimatesBasePage.item_select_itemDescription_foralltypes(num, EstimateItemID, "B");
				estimateCommonMethodsItem.Size = "";
				estimateCommonMethodsItem.Material = "";
				estimateCommonMethodsItem.Colour = "";
				int num2 = 1;
				estimateCommonMethodsItem.Size = "";
				string empty2 = string.Empty;
				empty = "ItemDescDigital_Booklet";
				DataTable dataTable7 = SettingsBasePage.DefaultSettings_ProductType_Select((long)num, empty);
				if (dataTable7.Rows.Count > 0)
				{
					empty1 = dataTable7.Rows[0]["ItemDescDigital_Booklet"].ToString();
				}
				foreach (DataRow row1 in dataTable6.Rows)
				{
					estimateCommonMethodsItem.ItemTitle = row1["ItemTitle"].ToString();
					estimateCommonMethodsItem.IsDoubleSided = row1["IsDoubleSided"].ToString();
					estimateCommonMethodsItem.Colour = row1["Colour"].ToString();
					estimateCommonMethodsItem.Sidecolour = row1["SideColor"].ToString();
					count = dataTable6.Rows.Count;
					estimateCommonMethodsItem.BookletSections = string.Concat(count.ToString(), " Section Booklet");
					estimateCommonMethodsItem.isjobcustom = row1["isjobcustom"].ToString();
					if (estimateCommonMethodsItem.isjobcustom.Trim().ToLower() != "false")
					{
						EstimateCommonMethodsItems estimateCommonMethodsItem1 = estimateCommonMethodsItem;
						string size1 = estimateCommonMethodsItem1.Size;
						string str12 = row1["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						string str13 = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str12.Split(chrArray)[0].ToString()), DecimalPaperSize, " ", false, false, false);
						string str14 = row1["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						estimateCommonMethodsItem1.Size = string.Concat(size1, str13, "X", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str14.Split(chrArray)[1].ToString()), DecimalPaperSize, " ", false, false, false));
					}
					else
					{
						EstimateCommonMethodsItems estimateCommonMethodsItem2 = estimateCommonMethodsItem;
						size = estimateCommonMethodsItem2.Size;
						str = new string[] { size, row1["PaperSizeName"].ToString(), ": ", null, null, null };
						string str15 = row1["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						str[3] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str15.Split(chrArray)[0].ToString()), DecimalPaperSize, " ", false, false, false);
						str[4] = "X";
						string str16 = row1["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						str[5] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str16.Split(chrArray)[1].ToString()), DecimalPaperSize, " ", false, false, false);
						estimateCommonMethodsItem2.Size = string.Concat(str);
					}
					estimateCommonMethodsItem.Size = string.Concat(estimateCommonMethodsItem.Size, " ", regionalSettings, " \n");
					EstimateCommonMethodsItems estimateCommonMethodsItem3 = estimateCommonMethodsItem;
					size = estimateCommonMethodsItem3.Material;
					str = new string[] { size, row1["SectionReference"].ToString(), ": ", row1["papername"].ToString(), "\u00a0\n" };
					estimateCommonMethodsItem3.Material = string.Concat(str);
					if (estimateCommonMethodsItem.IsDoubleSided != "True")
					{
						if (estimateCommonMethodsItem.Colour != "color")
						{
							estimateCommonMethodsItem.Colour = "Black & White";
						}
						else
						{
							estimateCommonMethodsItem.Colour = regionalSettings1;
						}
						size = empty2;
						str = new string[] { size, row1["SectionReference"].ToString(), ": Side1: ", estimateCommonMethodsItem.Colour, "\n" };
						empty2 = string.Concat(str);
					}
					else
					{
						if (estimateCommonMethodsItem.Colour != "color")
						{
							estimateCommonMethodsItem.Colour = "Black & White";
						}
						else
						{
							estimateCommonMethodsItem.Colour = regionalSettings1;
						}
						if (estimateCommonMethodsItem.Sidecolour != "color")
						{
							estimateCommonMethodsItem.Sidecolour = "Black & White";
						}
						else
						{
							estimateCommonMethodsItem.Sidecolour = regionalSettings1;
						}
						size = empty2;
						str = new string[] { size, row1["SectionReference"].ToString(), ": Side1: ", estimateCommonMethodsItem.Colour, "\n", row1["SectionReference"].ToString(), ": Side2: ", estimateCommonMethodsItem.Sidecolour, "\u00a0\n" };
						empty2 = string.Concat(str);
					}
					num2++;
				}
				estimateCommonMethodsItem.Colour = empty2;
				if (empty1.ToLower() == "true")
				{
					DataTable dataTable8 = SettingsBasePage.PhraseBook_Colour_Size_Material_Select((long)num);
					if (dataTable8.Rows.Count > 0)
					{
						estimateCommonMethodsItem.Colour = dataTable8.Rows[0]["Colours"].ToString();
						estimateCommonMethodsItem.Material = dataTable8.Rows[0]["Material"].ToString();
						estimateCommonMethodsItem.Size = dataTable8.Rows[0]["Size"].ToString();
					}
				}
			}
			else if (string.Compare(Estimationtype, "L", true) == 0)
			{
				string empty3 = string.Empty;
				if (HttpContext.Current.Request.Params["calcType"] != null)
				{
					empty3 = HttpContext.Current.Request.Params["calcType"].ToString();
				}
				if (empty3.ToLower() == "linear")
				{
					empty = "ItemDescLinear";
				}
				else if (empty3.ToLower() == "square")
				{
					empty = "ItemDescSquare_Meter";
				}
				else if (empty3.ToLower() == "tilling")
				{
					empty = "ItemDescSquare_Meter";
				}
				DataTable dataTable9 = SettingsBasePage.DefaultSettings_ProductType_Select((long)num, empty);
				if (dataTable9.Rows.Count > 0)
				{
					if (empty == "ItemDescLinear")
					{
						empty1 = dataTable9.Rows[0]["ItemDescLinear"].ToString();
					}
					else if (empty == "ItemDescSquare_Meter")
					{
						empty1 = dataTable9.Rows[0]["ItemDescSquare_Meter"].ToString();
					}
				}
				foreach (DataRow dataRow1 in EstimatesBasePage.item_select_itemDescription_foralltypes(num, EstimateItemID, "L").Rows)
				{
					estimateCommonMethodsItem.ItemTitle = dataRow1["ItemTitle"].ToString();
					estimateCommonMethodsItem.IsDoubleSided = dataRow1["IsDoubleSided"].ToString();
					estimateCommonMethodsItem.Colour = dataRow1["Colour"].ToString();
					estimateCommonMethodsItem.Sidecolour = dataRow1["SideColor"].ToString();
					estimateCommonMethodsItem.isjobcustom = dataRow1["isjobcustom"].ToString();
					if (estimateCommonMethodsItem.isjobcustom.Trim().ToLower() != "false")
					{
						string str17 = dataRow1["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						string str18 = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str17.Split(chrArray)[0].ToString()), 0, " ", false, false, false);
						string str19 = dataRow1["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						estimateCommonMethodsItem.Size = string.Concat(str18, "X", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str19.Split(chrArray)[1].ToString()), 0, " ", false, false, false));
					}
					else
					{
						str = new string[] { dataRow1["PaperSizeName"].ToString(), ": ", null, null, null };
						string str20 = dataRow1["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						str[2] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str20.Split(chrArray)[0].ToString()), 0, " ", false, false, false);
						str[3] = "X";
						string str21 = dataRow1["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						str[4] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str21.Split(chrArray)[1].ToString()), 0, " ", false, false, false);
						estimateCommonMethodsItem.Size = string.Concat(str);
					}
					estimateCommonMethodsItem.Size = string.Concat(estimateCommonMethodsItem.Size, " ", regionalSettings);
					estimateCommonMethodsItem.Material = dataRow1["papername"].ToString();
				}
				if (estimateCommonMethodsItem.IsDoubleSided != "True")
				{
					if (estimateCommonMethodsItem.Colour == "color")
					{
						estimateCommonMethodsItem.Colour = "Full Colour";
					}
					else if (estimateCommonMethodsItem.Colour == "swhite")
					{
						estimateCommonMethodsItem.Colour = "Single Special";
					}
					else if (estimateCommonMethodsItem.Colour == "dwhite")
					{
						estimateCommonMethodsItem.Colour = "Double Special";
					}
					else if (estimateCommonMethodsItem.Colour == "colourwithswhite")
					{
						estimateCommonMethodsItem.Colour = "Full Colour Plus Special";
					}
					else if (estimateCommonMethodsItem.Colour == "colourwithdwhite")
					{
						estimateCommonMethodsItem.Colour = "Full Colour Plus Double Special";
					}
					estimateCommonMethodsItem.Colour = string.Concat("Single Sided Print: ", estimateCommonMethodsItem.Colour);
				}
				else
				{
					if (estimateCommonMethodsItem.Colour == "color")
					{
						estimateCommonMethodsItem.Colour = "Full Colour";
					}
					else if (estimateCommonMethodsItem.Colour == "swhite")
					{
						estimateCommonMethodsItem.Colour = "Single Special";
					}
					else if (estimateCommonMethodsItem.Colour == "dwhite")
					{
						estimateCommonMethodsItem.Colour = "Double Special";
					}
					else if (estimateCommonMethodsItem.Colour == "colourwithswhite")
					{
						estimateCommonMethodsItem.Colour = "Full Colour Plus Special";
					}
					else if (estimateCommonMethodsItem.Colour == "colourwithdwhite")
					{
						estimateCommonMethodsItem.Colour = "Full Colour Plus Double Special";
					}
					if (estimateCommonMethodsItem.Sidecolour == "color")
					{
						estimateCommonMethodsItem.Sidecolour = "Full Colour";
					}
					else if (estimateCommonMethodsItem.Sidecolour == "swhite")
					{
						estimateCommonMethodsItem.Sidecolour = "Single Special";
					}
					else if (estimateCommonMethodsItem.Sidecolour == "dwhite")
					{
						estimateCommonMethodsItem.Sidecolour = "Double Special";
					}
					else if (estimateCommonMethodsItem.Sidecolour == "colourwithswhite")
					{
						estimateCommonMethodsItem.Sidecolour = "Full Colour Plus Special";
					}
					else if (estimateCommonMethodsItem.Sidecolour == "colourwithdwhite")
					{
						estimateCommonMethodsItem.Sidecolour = "Full Colour Plus Double Special";
					}
					estimateCommonMethodsItem.Colour = string.Concat("Side1: ", estimateCommonMethodsItem.Colour, "\nSide2: ", estimateCommonMethodsItem.Sidecolour);
				}
				if (empty1.ToLower() == "true")
				{
					DataTable dataTable10 = SettingsBasePage.PhraseBook_Colour_Size_Material_Select((long)num);
					if (dataTable10.Rows.Count > 0)
					{
						estimateCommonMethodsItem.Colour = dataTable10.Rows[0]["Colours"].ToString();
						estimateCommonMethodsItem.Material = dataTable10.Rows[0]["Material"].ToString();
						estimateCommonMethodsItem.Size = dataTable10.Rows[0]["Size"].ToString();
					}
				}
			}
			else if (string.Compare(Estimationtype, "W", true) == 0)
			{
				foreach (DataRow row2 in EstimatesBasePage.item_select_itemDescription_foralltypes(num, EstimateItemID, "W").Rows)
				{
					estimateCommonMethodsItem.ItemTitle = row2["papername"].ToString();
					estimateCommonMethodsItem.WareHouseDescription = row2["WareDesc"].ToString();
					if (row2["jobheight"].ToString() != "" && row2["jobwidth"].ToString() != "")
					{
						str = new string[] { _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(row2["jobheight"].ToString()), 0, " ", false, false, false), "X", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(row2["jobwidth"].ToString()), 0, " ", false, false, false), " ", regionalSettings };
						estimateCommonMethodsItem.Size = string.Concat(str);
					}
					estimateCommonMethodsItem.Material = row2["papername"].ToString();
				}
			}
			else if (string.Compare(Estimationtype, "C", true) == 0)
			{
				foreach (DataRow dataRow2 in EstimatesBasePage.item_select_itemDescription_foralltypes(num, EstimateItemID, "C").Rows)
				{
					estimateCommonMethodsItem.ItemTitle = dataRow2["ItemTitle"].ToString();
				}
			}
			else if (string.Compare(Estimationtype, "O", true) == 0)
			{
				foreach (DataRow row3 in EstimatesBasePage.item_select_itemDescription_foralltypes(num, EstimateItemID, "o").Rows)
				{
					estimateCommonMethodsItem.ItemTitle = row3["ItemTitle"].ToString();
				}
			}
			else if (string.Compare(Estimationtype, "U", true) == 0)
			{
				foreach (DataRow dataRow3 in EstimatesBasePage.item_select_itemDescription_foralltypes(num, EstimateItemID, "U").Rows)
				{
					estimateCommonMethodsItem.ItemTitle = dataRow3["itemtitle"].ToString();
				}
			}
			else if (string.Compare(Estimationtype, "F", true) == 0)
			{
				empty = "ItemDescOffset_Single";
				DataTable dataTable11 = SettingsBasePage.DefaultSettings_ProductType_Select((long)num, empty);
				if (dataTable11.Rows.Count > 0)
				{
					empty1 = dataTable11.Rows[0]["ItemDescOffset_Single"].ToString();
				}
				foreach (DataRow row4 in EstimatesBasePage.item_select_itemDescription_foralltypes(num, EstimateItemID, "F").Rows)
				{
					estimateCommonMethodsItem.ItemTitle = row4["ItemTitle"].ToString();
					estimateCommonMethodsItem.SidesPrinted = row4["sidesprinted"].ToString();
					estimateCommonMethodsItem.isjobcustom = row4["isjobcustom"].ToString();
					if (estimateCommonMethodsItem.isjobcustom.Trim().ToLower() != "false")
					{
						string str22 = row4["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						string str23 = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str22.Split(chrArray)[0].ToString()), DecimalPaperSize, " ", false, false, false);
						string str24 = row4["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						estimateCommonMethodsItem.Size = string.Concat(str23, "X", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str24.Split(chrArray)[1].ToString()), DecimalPaperSize, " ", false, false, false));
					}
					else
					{
						str = new string[] { row4["PaperSizeName"].ToString(), ": ", null, null, null };
						string str25 = row4["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						str[2] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str25.Split(chrArray)[0].ToString()), DecimalPaperSize, " ", false, false, false);
						str[3] = "X";
						string str26 = row4["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						str[4] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str26.Split(chrArray)[1].ToString()), DecimalPaperSize, " ", false, false, false);
						estimateCommonMethodsItem.Size = string.Concat(str);
					}
					estimateCommonMethodsItem.Size = string.Concat(estimateCommonMethodsItem.Size, " ", regionalSettings);
					estimateCommonMethodsItem.Material = row4["papername"].ToString();
				}
				estimateCommonMethodsItem.Colour = EstimatesBasePage.TakeLithoInkDetails_old(estimateCommonMethodsItem.SidesPrinted, Estimationtype, num, EstimateItemID);
				if (empty1.ToLower() == "true")
				{
					DataTable dataTable12 = SettingsBasePage.PhraseBook_Colour_Size_Material_Select((long)num);
					if (dataTable12.Rows.Count > 0)
					{
						estimateCommonMethodsItem.Colour = dataTable12.Rows[0]["Colours"].ToString();
						estimateCommonMethodsItem.Material = dataTable12.Rows[0]["Material"].ToString();
						estimateCommonMethodsItem.Size = dataTable12.Rows[0]["Size"].ToString();
					}
				}
			}
			else if (string.Compare(Estimationtype, "D", true) == 0)
			{
				empty = "ItemDescOffset_Pad";
				DataTable dataTable13 = SettingsBasePage.DefaultSettings_ProductType_Select((long)num, empty);
				if (dataTable13.Rows.Count > 0)
				{
					empty1 = dataTable13.Rows[0]["ItemDescOffset_Pad"].ToString();
				}
				foreach (DataRow dataRow4 in EstimatesBasePage.item_select_itemDescription_foralltypes(num, EstimateItemID, "D").Rows)
				{
					estimateCommonMethodsItem.ItemTitle = dataRow4["ItemTitle"].ToString();
					estimateCommonMethodsItem.SidesPrinted = dataRow4["sidesprinted"].ToString();
					estimateCommonMethodsItem.isjobcustom = dataRow4["isjobcustom"].ToString();
					estimateCommonMethodsItem.LeavesPerPad = string.Concat(Convert.ToString(_commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(dataRow4["LeavesPerPad"].ToString()), 0, "", true, false, false)), " page Pads");
					if (estimateCommonMethodsItem.isjobcustom.Trim().ToLower() != "false")
					{
						string str27 = dataRow4["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						string str28 = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str27.Split(chrArray)[0].ToString()), DecimalPaperSize, " ", false, false, false);
						string str29 = dataRow4["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						estimateCommonMethodsItem.Size = string.Concat(str28, "X", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str29.Split(chrArray)[1].ToString()), DecimalPaperSize, " ", false, false, false));
					}
					else
					{
						str = new string[] { dataRow4["PaperSizeName"].ToString(), ": ", null, null, null };
						string str30 = dataRow4["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						str[2] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str30.Split(chrArray)[0].ToString()), DecimalPaperSize, " ", false, false, false);
						str[3] = "X";
						string str31 = dataRow4["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						str[4] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str31.Split(chrArray)[1].ToString()), DecimalPaperSize, " ", false, false, false);
						estimateCommonMethodsItem.Size = string.Concat(str);
					}
					estimateCommonMethodsItem.Size = string.Concat(estimateCommonMethodsItem.Size, " ", regionalSettings);
					estimateCommonMethodsItem.Material = dataRow4["papername"].ToString();
				}
				estimateCommonMethodsItem.Colour = EstimatesBasePage.TakeLithoInkDetails_old(estimateCommonMethodsItem.SidesPrinted, Estimationtype, num, EstimateItemID);
				if (empty1.ToLower() == "true")
				{
					DataTable dataTable14 = SettingsBasePage.PhraseBook_Colour_Size_Material_Select((long)num);
					if (dataTable14.Rows.Count > 0)
					{
						estimateCommonMethodsItem.Colour = dataTable14.Rows[0]["Colours"].ToString();
						estimateCommonMethodsItem.Material = dataTable14.Rows[0]["Material"].ToString();
						estimateCommonMethodsItem.Size = dataTable14.Rows[0]["Size"].ToString();
					}
				}
			}
			else if (string.Compare(Estimationtype, "N", true) == 0)
			{
				int num3 = 1;
				int num4 = 0;
				estimateCommonMethodsItem.Material = "";
				estimateCommonMethodsItem.Colour = "";
				estimateCommonMethodsItem.Size = "";
				empty = "ItemDescOffset_NCR";
				DataTable dataTable15 = SettingsBasePage.DefaultSettings_ProductType_Select((long)num, empty);
				if (dataTable15.Rows.Count > 0)
				{
					empty1 = dataTable15.Rows[0]["ItemDescOffset_NCR"].ToString();
				}
				foreach (DataRow row5 in EstimatesBasePage.item_select_itemDescription_foralltypes(num, EstimateItemID, "N").Rows)
				{
					estimateCommonMethodsItem.ItemTitle = row5["ItemTitle"].ToString();
					estimateCommonMethodsItem.SidesPrinted = row5["sidesprinted"].ToString();
					estimateCommonMethodsItem.isjobcustom = row5["isjobcustom"].ToString();
					estimateCommonMethodsItem.SectionReference = row5["SectionReference"].ToString();
					estimateCommonMethodsItem.NCRDescription = string.Concat(_commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(row5["NcrSetsPerPad"].ToString()), 0, "", true, false, false), " set NCR Book, ", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(row5["NcrPartsPerSet"].ToString()), 0, "", true, false, false), " parts per set");
					if (num4 == 0)
					{
						if (estimateCommonMethodsItem.isjobcustom.Trim().ToLower() != "false")
						{
							EstimateCommonMethodsItems estimateCommonMethodsItem4 = estimateCommonMethodsItem;
							string size2 = estimateCommonMethodsItem4.Size;
							string str32 = row5["JobSize"].ToString();
							chrArray = new char[] { 'X' };
							string str33 = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str32.Split(chrArray)[0].ToString()), DecimalPaperSize, " ", false, false, false);
							string str34 = row5["JobSize"].ToString();
							chrArray = new char[] { 'X' };
							estimateCommonMethodsItem4.Size = string.Concat(size2, str33, " X ", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str34.Split(chrArray)[1].ToString()), DecimalPaperSize, " ", false, false, false));
						}
						else
						{
							EstimateCommonMethodsItems estimateCommonMethodsItem5 = estimateCommonMethodsItem;
							size = estimateCommonMethodsItem5.Size;
							str = new string[] { size, row5["PaperSizeName"].ToString(), ": ", null, null, null };
							string str35 = row5["JobSize"].ToString();
							chrArray = new char[] { 'X' };
							str[3] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str35.Split(chrArray)[0].ToString()), DecimalPaperSize, " ", false, false, false);
							str[4] = " X ";
							string str36 = row5["JobSize"].ToString();
							chrArray = new char[] { 'X' };
							str[5] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str36.Split(chrArray)[1].ToString()), DecimalPaperSize, " ", false, false, false);
							estimateCommonMethodsItem5.Size = string.Concat(str);
						}
						estimateCommonMethodsItem.Size = string.Concat(estimateCommonMethodsItem.Size, " ", regionalSettings, "\n");
					}
					EstimateCommonMethodsItems estimateCommonMethodsItem6 = estimateCommonMethodsItem;
					size = estimateCommonMethodsItem6.Material;
					str = new string[] { size, estimateCommonMethodsItem.SectionReference, ":", row5["papername"].ToString(), "\n" };
					estimateCommonMethodsItem6.Material = string.Concat(str);
					num4++;
					EstimateCommonMethodsItems estimateCommonMethodsItem7 = estimateCommonMethodsItem;
					estimateCommonMethodsItem7.Colour = string.Concat(estimateCommonMethodsItem7.Colour, EstimatesBasePage.TakeLithoInkDetails(estimateCommonMethodsItem.SidesPrinted, Estimationtype, EstimateItemID, Convert.ToInt64(row5["Estimatelithoncritemid"].ToString()), (long)0, num3, estimateCommonMethodsItem.SectionReference, num));
					num3++;
				}
				if (empty1.ToLower() == "true")
				{
					DataTable dataTable16 = SettingsBasePage.PhraseBook_Colour_Size_Material_Select((long)num);
					if (dataTable16.Rows.Count > 0)
					{
						estimateCommonMethodsItem.Colour = dataTable16.Rows[0]["Colours"].ToString();
						estimateCommonMethodsItem.Material = dataTable16.Rows[0]["Material"].ToString();
						estimateCommonMethodsItem.Size = dataTable16.Rows[0]["Size"].ToString();
					}
				}
			}
            else if (string.Compare(Estimationtype, "R", true) == 0)
            {
                int num3 = 1;
                int num4 = 0;
                estimateCommonMethodsItem.Material = "";
                estimateCommonMethodsItem.Colour = "";
                estimateCommonMethodsItem.Size = "";
                empty = "ItemDescOffset_NCR";
                DataTable dataTable15 = SettingsBasePage.DefaultSettings_ProductType_Select((long)num, empty);
                if (dataTable15.Rows.Count > 0)
                {
                    empty1 = dataTable15.Rows[0]["ItemDescOffset_NCR"].ToString();
                }
                foreach (DataRow row5 in EstimatesBasePage.item_select_itemDescription_foralltypes(num, EstimateItemID, "N").Rows)
                {
                    estimateCommonMethodsItem.ItemTitle = row5["ItemTitle"].ToString();
                    estimateCommonMethodsItem.SidesPrinted = row5["sidesprinted"].ToString();
                    estimateCommonMethodsItem.isjobcustom = row5["isjobcustom"].ToString();
                    estimateCommonMethodsItem.SectionReference = row5["SectionReference"].ToString();
                    estimateCommonMethodsItem.NCRDescription = string.Concat(_commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(row5["NcrSetsPerPad"].ToString()), 0, "", true, false, false), " set NCR Book, ", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(row5["NcrPartsPerSet"].ToString()), 0, "", true, false, false), " parts per set");
                    if (num4 == 0)
                    {
                        if (estimateCommonMethodsItem.isjobcustom.Trim().ToLower() != "false")
                        {
                            EstimateCommonMethodsItems estimateCommonMethodsItem4 = estimateCommonMethodsItem;
                            string size2 = estimateCommonMethodsItem4.Size;
                            string str32 = row5["JobSize"].ToString();
                            chrArray = new char[] { 'X' };
                            string str33 = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str32.Split(chrArray)[0].ToString()), 0, " ", false, false, false);
                            string str34 = row5["JobSize"].ToString();
                            chrArray = new char[] { 'X' };
                            estimateCommonMethodsItem4.Size = string.Concat(size2, str33, " X ", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str34.Split(chrArray)[1].ToString()), 0, " ", false, false, false));
                        }
                        else
                        {
                            EstimateCommonMethodsItems estimateCommonMethodsItem5 = estimateCommonMethodsItem;
                            size = estimateCommonMethodsItem5.Size;
                            str = new string[] { size, row5["PaperSizeName"].ToString(), ": ", null, null, null };
                            string str35 = row5["JobSize"].ToString();
                            chrArray = new char[] { 'X' };
                            str[3] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str35.Split(chrArray)[0].ToString()), 0, " ", false, false, false);
                            str[4] = " X ";
                            string str36 = row5["JobSize"].ToString();
                            chrArray = new char[] { 'X' };
                            str[5] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str36.Split(chrArray)[1].ToString()), 0, " ", false, false, false);
                            estimateCommonMethodsItem5.Size = string.Concat(str);
                        }
                        estimateCommonMethodsItem.Size = string.Concat(estimateCommonMethodsItem.Size, " ", regionalSettings, "\n");
                    }
                    EstimateCommonMethodsItems estimateCommonMethodsItem6 = estimateCommonMethodsItem;
                    size = estimateCommonMethodsItem6.Material;
                    str = new string[] { size, estimateCommonMethodsItem.SectionReference, ":", row5["papername"].ToString(), "\n" };
                    estimateCommonMethodsItem6.Material = string.Concat(str);
                    num4++;
                    EstimateCommonMethodsItems estimateCommonMethodsItem7 = estimateCommonMethodsItem;
                    estimateCommonMethodsItem7.Colour = string.Concat(estimateCommonMethodsItem7.Colour, EstimatesBasePage.TakeLithoInkDetails(estimateCommonMethodsItem.SidesPrinted, Estimationtype, EstimateItemID, Convert.ToInt64(row5["Estimatelithoncritemid"].ToString()), (long)0, num3, estimateCommonMethodsItem.SectionReference, num));
                    num3++;
                }
                if (empty1.ToLower() == "true")
                {
                    DataTable dataTable16 = SettingsBasePage.PhraseBook_Colour_Size_Material_Select((long)num);
                    if (dataTable16.Rows.Count > 0)
                    {
                        estimateCommonMethodsItem.Colour = dataTable16.Rows[0]["Colours"].ToString();
                        estimateCommonMethodsItem.Material = dataTable16.Rows[0]["Material"].ToString();
                        estimateCommonMethodsItem.Size = dataTable16.Rows[0]["Size"].ToString();
                    }
                }
            }
            else if (string.Compare(Estimationtype, "K", true) == 0)
			{
				int num5 = 1;
				DataTable dataTable17 = EstimatesBasePage.item_select_itemDescription_foralltypes(num, EstimateItemID, "K");
				estimateCommonMethodsItem.Colour = "";
				estimateCommonMethodsItem.Size = "";
				estimateCommonMethodsItem.Material = "";
				empty = "ItemDescOffset_Booklet";
				DataTable dataTable18 = SettingsBasePage.DefaultSettings_ProductType_Select((long)num, empty);
				if (dataTable18.Rows.Count > 0)
				{
					empty1 = dataTable18.Rows[0]["ItemDescOffset_Booklet"].ToString();
				}
				foreach (DataRow dataRow5 in dataTable17.Rows)
				{
					estimateCommonMethodsItem.ItemTitle = dataRow5["ItemTitle"].ToString();
					estimateCommonMethodsItem.SidesPrinted = dataRow5["sidesprinted"].ToString();
					estimateCommonMethodsItem.isjobcustom = dataRow5["isjobcustom"].ToString();
					estimateCommonMethodsItem.SectionReference = dataRow5["SectionReference"].ToString();
					count = dataTable17.Rows.Count;
					estimateCommonMethodsItem.BookletSections = string.Concat(count.ToString(), " Section Booklet");
					if (estimateCommonMethodsItem.isjobcustom.Trim().ToLower() != "false")
					{
						EstimateCommonMethodsItems estimateCommonMethodsItem8 = estimateCommonMethodsItem;
						string size3 = estimateCommonMethodsItem8.Size;
						string str37 = dataRow5["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						string str38 = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str37.Split(chrArray)[0].ToString()), DecimalPaperSize, " ", false, false, false);
						string str39 = dataRow5["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						estimateCommonMethodsItem8.Size = string.Concat(size3, str38, "X", _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str39.Split(chrArray)[1].ToString()), DecimalPaperSize, " ", false, false, false));
					}
					else
					{
						EstimateCommonMethodsItems estimateCommonMethodsItem9 = estimateCommonMethodsItem;
						size = estimateCommonMethodsItem9.Size;
						str = new string[] { size, dataRow5["PaperSizeName"].ToString(), ": ", null, null, null };
						string str40 = dataRow5["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						str[3] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str40.Split(chrArray)[0].ToString()), DecimalPaperSize, " ", false, false, false);
						str[4] = "X";
						string str41 = dataRow5["JobSize"].ToString();
						chrArray = new char[] { 'X' };
						str[5] = _commonClass.Eprint_ReturnFinal_Formated_Amount(num, num1, Convert.ToDecimal(str41.Split(chrArray)[1].ToString()), DecimalPaperSize, " ", false, false, false);
						estimateCommonMethodsItem9.Size = string.Concat(str);
					}
					estimateCommonMethodsItem.Size = string.Concat(estimateCommonMethodsItem.Size, " ", regionalSettings, "\n");
					EstimateCommonMethodsItems estimateCommonMethodsItem10 = estimateCommonMethodsItem;
					size = estimateCommonMethodsItem10.Material;
					str = new string[] { size, estimateCommonMethodsItem.SectionReference, ":", dataRow5["papername"].ToString(), "\n" };
					estimateCommonMethodsItem10.Material = string.Concat(str);
					EstimateCommonMethodsItems estimateCommonMethodsItem11 = estimateCommonMethodsItem;
					estimateCommonMethodsItem11.Colour = string.Concat(estimateCommonMethodsItem11.Colour, EstimatesBasePage.TakeLithoInkDetails(estimateCommonMethodsItem.SidesPrinted, Estimationtype, EstimateItemID, (long)0, Convert.ToInt64(dataRow5["Estimatelithobookletitemid"].ToString()), num5, estimateCommonMethodsItem.SectionReference, num));
					num5++;
				}
				if (empty1.ToLower() == "true")
				{
					DataTable dataTable19 = SettingsBasePage.PhraseBook_Colour_Size_Material_Select((long)num);
					if (dataTable19.Rows.Count > 0)
					{
						estimateCommonMethodsItem.Colour = dataTable19.Rows[0]["Colours"].ToString();
						estimateCommonMethodsItem.Material = dataTable19.Rows[0]["Material"].ToString();
						estimateCommonMethodsItem.Size = dataTable19.Rows[0]["Size"].ToString();
					}
				}
			}
			else if (string.Compare(Estimationtype, "Q", true) == 0)
			{
				foreach (DataRow row6 in EstimatesBasePage.item_select_itemDescription_foralltypes(num, EstimateItemID, "Q").Rows)
				{
					estimateCommonMethodsItem.ItemTitle = row6["ItemTitle"].ToString();
					try
					{
						string str42 = row6["ItemDescription"].ToString();
						chrArray = new char[] { 'µ' };
						string str43 = str42.Split(chrArray)[1].ToString();
						chrArray = new char[] { '»' };
						estimateCommonMethodsItem.Description = str43.Split(chrArray)[2];
					}
					catch
					{
						estimateCommonMethodsItem.Description = "";
					}
				}
			}
			else if (string.Compare(Estimationtype, "x", true) == 0)
			{
				foreach (DataRow dataRow6 in EstimatesBasePage.item_select_itemDescription_foralltypes(num, EstimateItemID, "X").Rows)
				{
					estimateCommonMethodsItem.ItemTitle = dataRow6["ItemTitle"].ToString();
				}
			}
			if (!estimateCommonMethodsItem.Size.Contains("\n"))
			{
				string str44 = estimateCommonMethodsItem.Size.ToString();
				chrArray = new char[] { 'X' };
				if ((int)str44.Split(chrArray).Length > 1)
				{
					string str45 = estimateCommonMethodsItem.Size.ToString();
					chrArray = new char[] { 'X' };
					string str46 = str45.Split(chrArray)[0].ToString().Replace(".0000", "").Replace(".000", "").Replace(".00", "").Replace(".0", "");
					string str47 = estimateCommonMethodsItem.Size.ToString();
					chrArray = new char[] { 'X' };
					estimateCommonMethodsItem.Size = string.Concat(str46, " x ", str47.Split(chrArray)[1].ToString().Replace(".0000", "").Replace(".000", "").Replace(".00", "").Replace(".0", ""));
				}
				if (string.Compare(Estimationtype, "W", true) == 0 && (estimateCommonMethodsItem.Size.Trim() == "0 x 0 mm" || estimateCommonMethodsItem.Size.Trim() == "0 x 0 In."))
				{
					estimateCommonMethodsItem.Size = "";
				}
			}
			else
			{
				string size4 = estimateCommonMethodsItem.Size;
				chrArray = new char[] { '\n' };
				string[] strArrays = size4.Split(chrArray);
				estimateCommonMethodsItem.Size = "";
				string[] strArrays1 = strArrays;
				for (int i = 0; i < (int)strArrays1.Length; i++)
				{
					string str48 = strArrays1[i];
					if (str48.Contains("X"))
					{
						EstimateCommonMethodsItems estimateCommonMethodsItem12 = estimateCommonMethodsItem;
						size = estimateCommonMethodsItem12.Size;
						str = new string[] { size, null, null, null, null };
						chrArray = new char[] { 'X' };
						str[1] = _commonClass.ToRemoveDecimalPlacesIfZero(str48.Split(chrArray)[0].ToString());
						str[2] = " x ";
						chrArray = new char[] { 'X' };
						str[3] = str48.Split(chrArray)[1].ToString().Replace(".0000", "").Replace(".000", "").Replace(".00", "").Replace(".0", "");
						str[4] = "\n";
						estimateCommonMethodsItem12.Size = string.Concat(str);
					}
					if (string.Compare(Estimationtype, "W", true) == 0 && (estimateCommonMethodsItem.Size.Trim() == "0 x 0 mm" || estimateCommonMethodsItem.Size.Trim() == "0 x 0 In."))
					{
						estimateCommonMethodsItem.Size = "";
					}
				}
			}
			if (string.Compare(Estimationtype, "W", true) == 0 && isRerun)
			{
				estimateCommonMethodsItem.Colour = "";
			}
			if (string.Compare(Estimationtype, "W", true) == 0 && (estimateCommonMethodsItem.Size.Trim() == "0 x 0 mm" || estimateCommonMethodsItem.Size.Trim() == "0 x 0 In."))
			{
				estimateCommonMethodsItem.Size = "";
			}
			if (string.Compare(Estimationtype, "P", true) == 0 || string.Compare(Estimationtype, "D", true) == 0)
			{
				estimateCommonMethodsItem.Description = estimateCommonMethodsItem.LeavesPerPad;
			}
			else if (string.Compare(Estimationtype, "B", true) == 0 || string.Compare(Estimationtype, "K", true) == 0)
			{
				estimateCommonMethodsItem.Description = estimateCommonMethodsItem.BookletSections;
			}
			else if (string.Compare(Estimationtype, "N", true) == 0)
			{
				estimateCommonMethodsItem.Description = estimateCommonMethodsItem.NCRDescription;
			}
			else if (string.Compare(Estimationtype, "W", true) == 0)
			{
				estimateCommonMethodsItem.Description = estimateCommonMethodsItem.WareHouseDescription;
			}
			if (Estimationtype == "U" && HttpContext.Current.Session["Othercostdescription"] != null && HttpContext.Current.Session["Othercostdescription"].ToString() != "")
			{
				estimateCommonMethodsItem.Description = HttpContext.Current.Session["Othercostdescription"].ToString();
			}
			if (string.Compare(Estimationtype, "O", true) == 0 || string.Compare(Estimationtype, "C", true) == 0)
			{
				EstimateCommonMethods.getPrintbrokerdetailsfromprev(Estimationtype, num, EstimateItemID, estimateCommonMethodsItem);
			}
			EstimateCommonMethods.Description_Add_Or_rerun(EstimateItemID, EstimateID, Estimationtype, num, estimateCommonMethodsItem);
		}
	}
}

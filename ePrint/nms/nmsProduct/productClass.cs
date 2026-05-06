using nmsCommon;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace nmsProduct
{
	public class productClass
	{
		public productClass()
		{
		}

		public void assignproduct(int productid, int id, int userorgroup)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_product_assign", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@productid", productid);
			sqlCommand.Parameters.AddWithValue("@id", id);
			sqlCommand.Parameters.AddWithValue("@userorgroup", userorgroup);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void listprice_Add(int productID, int companyID, int priceID, double listPrice, int isactive, int isStandard)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_product_pricelist_add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@productID", productID);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@priceID", priceID);
			sqlCommand.Parameters.AddWithValue("@listPrice", listPrice);
			sqlCommand.Parameters.AddWithValue("@isactive", isactive);
			sqlCommand.Parameters.AddWithValue("@isStandard", isStandard);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public ArrayList listprice_Array(int productID, int companyID)
		{
			ArrayList arrayLists = new ArrayList();
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_product_listprice_select", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@productID", productID);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
			while (sqlDataReader.Read())
			{
				arrayLists.Add(sqlDataReader["priceid"]);
			}
			sqlDataReader.Close();
			_commonClass.closeConnection();
			return arrayLists;
		}

		public void listprice_Delete(int productpriceID, int companyID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_product_listprice_delete", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@productpriceID", productpriceID);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void listprice_Edit(int productpriceID, int companyID, double listPrice, int isactive, int isStandard)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_product_pricelist_edit", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@productpriceID", productpriceID);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@listPrice", listPrice);
			sqlCommand.Parameters.AddWithValue("@isactive", isactive);
			sqlCommand.Parameters.AddWithValue("@isStandard", isStandard);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public int product_Add(string productalias, int companyID, string productname, string productCategory, string productcode, int isactive, string description, string createDate, string modifiedDate, string lastViewDate, int createUserID, int modifyUserID, string qtyscheduletype, string qtyinstallmentperiod, int noofqtyinstallments, int isDelete, string revenuescheduletype, string revenueinstallmentperiod, int noofrevenueinstallments, int isquantityschedule, int isrevenueschedule)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_product_add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			SqlParameter sqlParameter = sqlCommand.Parameters.AddWithValue("ReturnValue", SqlDbType.Int);
			sqlParameter.Direction = ParameterDirection.ReturnValue;
			sqlCommand.Parameters.AddWithValue("@productalias", productalias);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@productname", productname);
			sqlCommand.Parameters.AddWithValue("@productCategory", productCategory);
			sqlCommand.Parameters.AddWithValue("@productcode", productcode);
			sqlCommand.Parameters.AddWithValue("@isactive", isactive);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@createDate", createDate);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@createUserID", createUserID);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@qtyscheduletype", qtyscheduletype);
			sqlCommand.Parameters.AddWithValue("@qtyinstallmentperiod", qtyinstallmentperiod);
			sqlCommand.Parameters.AddWithValue("@noofqtyinstallments", noofqtyinstallments);
			sqlCommand.Parameters.AddWithValue("@revenuescheduletype", revenuescheduletype);
			sqlCommand.Parameters.AddWithValue("@revenueinstallmentperiod", revenueinstallmentperiod);
			sqlCommand.Parameters.AddWithValue("@noofrevenueinstallments", noofrevenueinstallments);
			sqlCommand.Parameters.AddWithValue("@isDelete", isDelete);
			sqlCommand.Parameters.AddWithValue("@isquantityschedule", isquantityschedule);
			sqlCommand.Parameters.AddWithValue("@isrevenueschedule", isrevenueschedule);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
			return (int)sqlCommand.Parameters["ReturnValue"].Value;
		}

		public void product_AddCustomizValue(int CustomizeId, int Id, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_product_AddCustomizeValue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@customizeid", CustomizeId);
			sqlCommand.Parameters.AddWithValue("@id", Id);
			sqlCommand.Parameters.AddWithValue("@customizedvalue", customizedValue);
			sqlCommand.Parameters.AddWithValue("@CompanyID", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void product_Delete(int productId)
		{
			commonClass _commonClass = new commonClass();
			string str = string.Concat("crm_product_delete ", productId);
			(new SqlCommand(str, _commonClass.openConnection())).ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void product_Edit(int productID, string productalias, int companyID, string productname, string productCategory, string productcode, int isactive, string description, string modifiedDate, string lastViewDate, int modifyUserID, string qtyscheduletype, string qtyinstallmentperiod, int noofqtyinstallments, string revenuescheduletype, string revenueinstallmentperiod, int noofrevenueinstallments, int isquantityschedule, int isrevenueschedule)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_product_edit", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@productID", productID);
			sqlCommand.Parameters.AddWithValue("@productalias", productalias);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@productname", productname);
			sqlCommand.Parameters.AddWithValue("@productCategory", productCategory);
			sqlCommand.Parameters.AddWithValue("@productcode", productcode);
			sqlCommand.Parameters.AddWithValue("@isactive", isactive);
			sqlCommand.Parameters.AddWithValue("@description", description);
			sqlCommand.Parameters.AddWithValue("@modifiedDate", modifiedDate);
			sqlCommand.Parameters.AddWithValue("@lastViewDate", lastViewDate);
			sqlCommand.Parameters.AddWithValue("@modifyUserID", modifyUserID);
			sqlCommand.Parameters.AddWithValue("@qtyscheduletype", qtyscheduletype);
			sqlCommand.Parameters.AddWithValue("@qtyinstallmentperiod", qtyinstallmentperiod);
			sqlCommand.Parameters.AddWithValue("@noofqtyinstallments", noofqtyinstallments);
			sqlCommand.Parameters.AddWithValue("@revenuescheduletype", revenuescheduletype);
			sqlCommand.Parameters.AddWithValue("@revenueinstallmentperiod", revenueinstallmentperiod);
			sqlCommand.Parameters.AddWithValue("@noofrevenueinstallments", noofrevenueinstallments);
			sqlCommand.Parameters.AddWithValue("@isquantityschedule", isquantityschedule);
			sqlCommand.Parameters.AddWithValue("@isrevenueschedule", isrevenueschedule);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void product_EditCustomizeVAlue(int CustomizeID, int Id, string customizedValue, int companyid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_product_editcustomizevalue", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@CustomizeID", CustomizeID);
			sqlCommand.Parameters.AddWithValue("@Id", Id);
			sqlCommand.Parameters.AddWithValue("@customizedValue", customizedValue);
			sqlCommand.Parameters.AddWithValue("@companyID", companyid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void standardprice_Add(int productID, int companyID, double standardPrice, int isactive)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_product_standardprice_add", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@productID", productID);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@standardPrice", standardPrice);
			sqlCommand.Parameters.AddWithValue("@isactive", isactive);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void standardprice_Delete(int standardpriceID, int companyID)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_product_standardprice_delete", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@productstandardpriceID", standardpriceID);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void standardprice_Edit(int standardpriceID, int companyID, double standardPrice, int isactive)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_product_standardprice_edit", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@productstandardpriceID", standardpriceID);
			sqlCommand.Parameters.AddWithValue("@companyID", companyID);
			sqlCommand.Parameters.AddWithValue("@standardPrice", standardPrice);
			sqlCommand.Parameters.AddWithValue("@isactive", isactive);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}

		public void Unassignproduct(int productid)
		{
			commonClass _commonClass = new commonClass();
			SqlCommand sqlCommand = new SqlCommand("crm_product_Unassign", _commonClass.openConnection())
			{
				CommandType = CommandType.StoredProcedure
			};
			sqlCommand.Parameters.AddWithValue("@productid", productid);
			sqlCommand.ExecuteNonQuery();
			_commonClass.closeConnection();
		}
	}
}
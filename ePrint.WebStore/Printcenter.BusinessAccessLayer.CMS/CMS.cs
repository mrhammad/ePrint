using Printcenter.DataAccessLayer.CMS;
using System;
using System.Data;

namespace Printcenter.BusinessAccessLayer.CMS
{
	public class CMS
	{
		public CMS()
		{
		}

		public static DataTable CSMPages_get(int companyID, int accountID, int pageID)
		{
			return (new DBCMS()).CMSPages_get(companyID, accountID, pageID);
		}

		public static DataTable GetDetailForHome(long AccountID)
		{
			return (new DBCMS()).GetDetailForHome(AccountID);
		}

		public static DataTable GetDisplaySettings(long AccountID)
		{
			return (new DBCMS()).GetDisplaySettings(AccountID);
		}

		public static DataTable getGuestDetail(long UserID)
		{
			return (new DBCMS()).getGuestDetail(UserID);
		}

		public static DataTable headerSelect(int companyID, int accountID, string type)
		{
			return (new DBCMS()).headerSelect(companyID, accountID, type);
		}

		public static DataTable homePageSelect(long PageID, int CompanyID, int AccountID)
		{
			return (new DBCMS()).homePageSelect(PageID, CompanyID, AccountID);
		}

		public static DataTable paymentSelect(int CompanyID, int AccountID)
		{
			return (new DBCMS()).paymentSelect(CompanyID, AccountID);
		}

		public static DataTable Select_BannerImages(long AccountID, int PageID, string Location, string Page)
		{
			return (new DBCMS()).Select_BannerImages(AccountID, PageID, Location, Page);
		}

		public static DataTable select_TermsAndConditions(int CompanyID, int AccountID)
		{
			return (new DBCMS()).select_TermsAndConditions(CompanyID, AccountID);
		}

        internal static DataTable Get_CurrencySymbol_Currency_Company(int companyID)
        {
			return (new DBCMS()).Get_CurrencySymbol_Currency_Company(companyID);
		}
    }
}
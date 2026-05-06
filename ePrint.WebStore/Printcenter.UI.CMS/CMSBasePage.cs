using Printcenter.BusinessAccessLayer.CMS;
using System;
using System.Data;

namespace Printcenter.UI.CMS
{
	public class CMSBasePage
	{
		public CMSBasePage()
		{
		}

		public static DataTable CMSPages_get(int companyID, int accountID, int pageID)
		{
			return Printcenter.BusinessAccessLayer.CMS.CMS.CSMPages_get(companyID, accountID, pageID);
		}

		public static DataTable GetDetailForHome(long AccountID)
		{
			return Printcenter.BusinessAccessLayer.CMS.CMS.GetDetailForHome(AccountID);
		}

		public static DataTable GetDisplaySettings(long AccountID)
		{
			return Printcenter.BusinessAccessLayer.CMS.CMS.GetDisplaySettings(AccountID);
		}

		public static DataTable getGuestDetail(long UserID)
		{
			return Printcenter.BusinessAccessLayer.CMS.CMS.getGuestDetail(UserID);
		}

		public static DataTable headerSelect(int companyID, int accountID, string type)
		{
			return Printcenter.BusinessAccessLayer.CMS.CMS.headerSelect(companyID, accountID, type);
		}

		public static DataTable homePageSelect(long PageID, int CompanyID, int AccountID)
		{
			return Printcenter.BusinessAccessLayer.CMS.CMS.homePageSelect(PageID, CompanyID, AccountID);
		}

		public static DataTable paymentSelect(int CompanyID, int AccountID)
		{
			return Printcenter.BusinessAccessLayer.CMS.CMS.paymentSelect(CompanyID, AccountID);
		}

		public static DataTable Select_BannerImages(long AccountID, int PageID, string Location, string Page)
		{
			return Printcenter.BusinessAccessLayer.CMS.CMS.Select_BannerImages(AccountID, PageID, Location, Page);
		}

		public static DataTable select_TermsAndConditions(int CompanyID, int AccountID)
		{
			return Printcenter.BusinessAccessLayer.CMS.CMS.select_TermsAndConditions(CompanyID, AccountID);
		}

        internal static DataTable Get_CurrencySymbol_Currency_Company(int companyID)
        {
			return Printcenter.BusinessAccessLayer.CMS.CMS.Get_CurrencySymbol_Currency_Company(companyID);
		}
    }
}
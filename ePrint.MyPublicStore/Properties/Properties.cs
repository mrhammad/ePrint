using Printcenter.UI.Products;
using System;
using System.Collections.Generic;
using System.Web.Services;
public class Properties
{
    public Properties()
    {
    }

    [WebMethod(EnableSession = true)]
    public static IList<Properties.GetQuantity> LoadQuantity(string ChangedProductID)
    {
        IList<Properties.GetQuantity> getQuantities;
        try
        {
            getQuantities = ProductBasePage.Product_CatalogueQty_SelectFor_OtherMultiple((long)Convert.ToInt16(ChangedProductID));
        }
        catch
        {
            getQuantities = null;
        }
        return getQuantities;
    }

    public class GetQuantity
    {
        public string AvailableQuantity
        {
            get;
            set;
        }

        public string CatalogueName
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string DrawStockFrom
        {
            get;
            set;
        }

        public string FromQuantity
        {
            get;
            set;
        }

        public string IsBackOrder
        {
            get;
            set;
        }

        public string IsCumulativePricing
        {
            get;
            set;
        }

        public string IsPriceStartFrom
        {
            get;
            set;
        }

        public string IsShortDescription
        {
            get;
            set;
        }

        public string IsShowSoldInPacksof
        {
            get;
            set;
        }

        public string IsShowStock
        {
            get;
            set;
        }

        public string IsStockItem
        {
            get;
            set;
        }

        public string Markup
        {
            get;
            set;
        }

        public string MatrixType
        {
            get;
            set;
        }

        public string NewPrice
        {
            get;
            set;
        }

        public string Price
        {
            get;
            set;
        }

        public string ProductID
        {
            get;
            set;
        }

        public string ProductImage
        {
            get;
            set;
        }

        public string ProductTaxId
        {
            get;
            set;
        }

        public string ProductTaxName
        {
            get;
            set;
        }

        public string ProductTaxRate
        {
            get;
            set;
        }

        public string SellingPrice
        {
            get;
            set;
        }

        public string SoldInPacksof
        {
            get;
            set;
        }

        public string ToQuantity
        {
            get;
            set;
        }

        public GetQuantity()
        {
        }
    }
}

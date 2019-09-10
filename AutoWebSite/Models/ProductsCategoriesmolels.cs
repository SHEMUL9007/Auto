using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWebSite
{
    public class ProductsCategoriesmolels
    {
        #region Direct properties
        public int ProductsID { get; set; }
        public int CategoryID { get; set; }
        public int SellerID { get; set; }
        public string Name { get; set; }
        public string Descrption { get; set; }
        public decimal ReservePrice { get; set; }
        public int WinningofferID { get; set; }
        public string Comments { get; set; }
        public string Photos { get; set; }
        public string Categorie { get; set; }

        #endregion
    }
}
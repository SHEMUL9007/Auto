using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ProductBLL
    {
        public ProductBLL()
        {

        }
        public ProductBLL(ProductDal dal)
        {
            this.ProductsID = dal.ProductsID;
            this.CategoryID = dal.CategoryID;
            this.SellerID = dal.SellerID;
            this.Name = dal.Name;
            this.Descrption = dal.Descrption;
            this.ReservePrice = dal.ReservePrice;
            this.Comments = dal.Comments;
            this.Photos = dal.Photos;
            this.Categories = dal.Categories;
            this.SellerEmail = dal.SellerEmail;
            this.SellerName = dal.SellerName;
        }
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
        public string Categories { get; set; }
        public string SellerEmail { get; set; }
        public string SellerName { get; set; }

        #endregion
        public override string ToString()
        {
            return $"Product:ProductsID:{ProductsID,5}CategoryID{CategoryID}SellerID:{SellerID}Name{Name}Descrption{Descrption}ReservePrice{ReservePrice}WinningofferID{WinningofferID}Comments{Comments}Photos{Photos}Categories{Categories}SellerEmail{SellerEmail}SellerEmail{SellerEmail}";
        }
    }
}

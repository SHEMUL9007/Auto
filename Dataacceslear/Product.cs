using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDal
    {
        public int ProductsID { get; set; }
        public int CategoryID { get; set; }
        public int SellerID { get; set; }
        public string Name { get; set; }
        public string Descrption { get; set; }
        public decimal ReservePrice { get; set; }
        public int WinningofferID { get; set; }
        public string Comments { get; set; }
        public string Categories { get; set; } 
        public string Photos { get; set; }
        public string SellerEmail { get; set; }
        public string SellerName { get; set; }
        public override string ToString()
        {
            return $"Product:ProductsID:{ProductsID,5}CategoryID{CategoryID}SellerID:{SellerID}Name{Name}Descrption{Descrption}ReservePrice{ReservePrice}WinningofferID{WinningofferID}Comments{Comments}Categories:{Categories}Photos{Photos}SellerEmail:{SellerEmail}SellerName:{SellerName}";
        }






    }
}

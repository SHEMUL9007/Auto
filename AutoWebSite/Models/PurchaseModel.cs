using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWebSite.Models
{
    public class PurchaseModel
    {
        public PurchaseModel() { }

        public PurchaseModel(ProductBLL product)
        {
            Name = product.Name;
            Description = product.Descrption;
            ReservePrice = product.ReservePrice;
            Comments = product.Comments;

        }
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal ReservePrice { get; set; }

        public decimal OfferedPrice { get; set; }

        public string Comments { get; set; }

        public decimal Profit { get; set; }


    }
}
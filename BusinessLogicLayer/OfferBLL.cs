using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BusinessLogicLayer
{
    public class OfferBLL
    {
        public OfferBLL()
        {

        }
        public OfferBLL(OfferDal dal)
        {
            this.offerID = dal.offerID;
            this.ProductID = dal.ProductID;
            this.BuyerID = dal.BuyerID;
            this.Offerprice = dal.Offerprice;
            this.offerstate = dal.offerstate;
            this.ExpireDate = dal.ExpireDate;
            this.Comments = dal.Comments;
            this.ProductName = dal.ProductName;
            this.BuyerName = dal.ProductName;
            this.EmailAdderess = dal.ProductName;
           
        }
        public int offerID { get; set; }
        public int ProductID { get; set; }
        public int BuyerID { get; set; }
        public decimal Offerprice { get; set; }
        public int offerstate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Comments { get; set; }
        public string ProductName { get; set; }
        public string BuyerName { get; set; }
        public string EmailAdderess { get; set; }

        public override string ToString()
        {
            return $"Offer:offerID:{offerID}productID:{ProductID}BuyerID:{BuyerID}Offerprice:{Offerprice}offerstate:{offerstate}ExpireDate:{ExpireDate}comments:{Comments}ProductName:{ProductName}BuyerName:{BuyerName}EmailAdderess:{EmailAdderess}";
        }
    }
    
       
    
}

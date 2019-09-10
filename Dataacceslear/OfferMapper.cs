using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OfferMapper:Mapper
    {
        int OffsetToOfferID;
        int OffsetToProductID;
        int OffsetToBuyerID;
        int OffsetToOfferPrice;
        int OffsetToOfferstate;
        int OffsetToExpireDate;
        int OffsetToComments;
        int OffsetToProductName;
        int OffsetToBuyerName;
        int OffsetToEmailAdderess;
        public OfferMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToOfferID = reader.GetOrdinal("OfferID");
            Assert(0 == OffsetToOfferID, $"OfferID is{OffsetToOfferID}not 0 as expected");
            OffsetToProductID = reader.GetOrdinal("ProductID");
            Assert(1 == OffsetToProductID, $"ProductID is{OffsetToProductID}not 1 as expected");
            OffsetToBuyerID = reader.GetOrdinal("BuyerID");
            Assert(2 == OffsetToBuyerID, $"BuyerID is{OffsetToBuyerID}not 2 as expected");
            OffsetToOfferPrice = reader.GetOrdinal("OfferPrice");
            Assert(3 == OffsetToOfferPrice, $"OfferPrice is{OffsetToOfferPrice}not 3 as expected");
            OffsetToOfferstate = reader.GetOrdinal("Offerstate");
            Assert(4 == OffsetToOfferstate, $"Offerstate is{OffsetToOfferstate}not 4 as expected");
            OffsetToExpireDate = reader.GetOrdinal("ExpireDate");
            Assert(5 == OffsetToExpireDate, $"ExpireDate is{OffsetToExpireDate}not 5 as expected");
            OffsetToComments = reader.GetOrdinal("Comments");
            Assert(6 == OffsetToComments, $"Comments is{OffsetToComments}not 6 as expected");
            OffsetToProductName = reader.GetOrdinal("ProductName");
            Assert(7 == OffsetToProductName, $"Product is{OffsetToProductName}not 7 as expected");
            OffsetToBuyerName = reader.GetOrdinal("BuyerName");
            Assert(8 == OffsetToBuyerName, $"BuyerName is{OffsetToBuyerName}not 8 as expected");
            OffsetToEmailAdderess = reader.GetOrdinal("EmailAdderess");
            Assert(9 == OffsetToEmailAdderess, $"EmailAddress is{OffsetToEmailAdderess}not 9 as expected");
        }
        public OfferDal OfferFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            OfferDal ProposedReturnValue = new OfferDal();
            ProposedReturnValue.offerID = reader.GetInt32(OffsetToOfferID);
            ProposedReturnValue.ProductID = reader.GetInt32(OffsetToProductID);
            ProposedReturnValue.BuyerID = reader.GetInt32(OffsetToBuyerID);
            ProposedReturnValue.Offerprice = reader.GetDecimal(OffsetToOfferPrice);
            ProposedReturnValue.offerstate = reader.GetInt32(OffsetToOfferstate);
            ProposedReturnValue.ExpireDate = reader.GetDateTime(OffsetToExpireDate);
            ProposedReturnValue.Comments = reader.GetString(OffsetToComments);
            ProposedReturnValue.ProductName = reader.GetString(OffsetToProductName);
            ProposedReturnValue.BuyerName = reader.GetString(OffsetToBuyerName);
            ProposedReturnValue.EmailAdderess = reader.GetString(OffsetToEmailAdderess);

            return ProposedReturnValue;
        }

    }
}

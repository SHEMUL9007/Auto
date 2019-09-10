using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductMapper:Mapper
    {
        int OffsetToProductsID;
        int OffsetToCategoryID;
        int OffsetToSellerID;
        int OffsetToName;
        int OffsetToDescription;
        int OffsetToReserveprice;
        int OffsetToWinningOffer;
        int OffsetToComments;
        int OffsetToPhotos;
        int OffersetToCategories;
        int OffersetToSellerEmail;
        int OffersetToSellerName;

        public ProductMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToProductsID = reader.GetOrdinal("ProductsID");
            Assert(0 == OffsetToProductsID, $"ProductsID is {OffsetToProductsID} not 0 as expected");
            OffsetToCategoryID = reader.GetOrdinal("CategoryID");
            Assert(1 == OffsetToCategoryID, $"CategoryID is {OffsetToCategoryID} not 1 as expected");
            OffsetToSellerID = reader.GetOrdinal("SellerID");
            Assert(2 == OffsetToSellerID, $"SellerID is {OffsetToSellerID} not 2 as expected");
            OffsetToName = reader.GetOrdinal("ProductName");
            Assert(3 == OffsetToName, $"Name is {OffsetToSellerID} not 3 as expected");
            OffsetToDescription = reader.GetOrdinal("Description");
            Assert(4 == OffsetToDescription, $"Description is {OffsetToDescription} not 4 as expected");
            OffsetToReserveprice = reader.GetOrdinal("Reserveprice");
            Assert(5 == OffsetToReserveprice, $"Reserveprice is {OffsetToReserveprice} not 5 as expected");
            OffsetToWinningOffer = reader.GetOrdinal("WinningOfferID");
            Assert(6 == OffsetToWinningOffer, $"WinningOffer is {OffsetToWinningOffer} not 6 as expected");
            OffsetToComments = reader.GetOrdinal("Comments");
            Assert(7 == OffsetToComments, $"Comments is {OffsetToComments} not 7 as expected");
            OffsetToPhotos = reader.GetOrdinal("Photos");
            Assert(9 == OffsetToPhotos, $"Photos is {OffsetToPhotos} not 9 as expected");
            OffersetToCategories = reader.GetOrdinal("Categories");
            Assert(8 == OffersetToCategories, $"Categories is {OffersetToCategories} not 8 as expected");
            OffersetToSellerEmail = reader.GetOrdinal("SellerEmail");
            Assert(10 == OffersetToSellerEmail, $"SellerID is {OffersetToSellerEmail} not 10 as expected");
            OffersetToSellerName = reader.GetOrdinal("SellerName");
            Assert(11 == OffersetToSellerName, $"SellerName is {OffersetToSellerName} not 11 as expected");

        }
        public ProductDal ProductFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            ProductDal ProposedReturnValue = new ProductDal();
            ProposedReturnValue.ProductsID = reader.GetInt32(OffsetToProductsID);
            ProposedReturnValue.CategoryID = reader.GetInt32(OffsetToCategoryID);
            ProposedReturnValue.SellerID = reader.GetInt32(OffsetToSellerID);
            ProposedReturnValue.Name = reader.GetString(OffsetToName);
            ProposedReturnValue.Descrption = reader.GetString(OffsetToDescription);
            ProposedReturnValue.ReservePrice = reader.GetDecimal(OffsetToReserveprice);
            ProposedReturnValue.WinningofferID = Getint32OrDefault(reader,OffsetToWinningOffer);
            ProposedReturnValue.Comments = reader.GetString(OffsetToComments);
            ProposedReturnValue.Photos = GetstringOrDefault(reader,OffsetToPhotos);
            ProposedReturnValue.Categories = reader.GetString(OffersetToCategories);
            ProposedReturnValue.SellerEmail = reader.GetString(OffersetToSellerEmail);
            ProposedReturnValue.SellerName = reader.GetString(OffersetToSellerName);
            return ProposedReturnValue;
        }

    }
    
}

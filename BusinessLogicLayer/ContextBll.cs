using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ContextBll : IDisposable
    {
        DataAccessLayer.ContextDal _context = new DataAccessLayer.ContextDal();
        public void Dispose()
        {
            ((IDisposable)_context).Dispose();
        }
        bool Log(Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
        public ContextBll()
        {
            try
            {
                string connectionstring;
                
                    
                    var test = System.Configuration.ConfigurationManager.ConnectionStrings;
                var test2 = test["DefaultConnectionString"];
                var test3 = test2.ConnectionString;
                _context.ConnectionString = test3;
            }
            catch (Exception ex) when (Log(ex))
            {
                // this exception does not have a 
                // reasonable handler, simply log it
            }
        }
        //public void GenerateNotConnected()
        //{
        //    _context.GenerateNotConnected();

        //}
        //public void GenerateStoredProcedureNotFound()
        //{
        //    _context.GenerateStoredProcedureNotFound();
        //}
        //public void GenerateParameterNotIncluded()
        //{
        //    _context.GenerateParameterNotIncluded();
        //}
        //Role 
        public RoleBLL FindRoleByID(int RoleID)
        {
            RoleBLL ProposedReturnValue = null;
            RoleDal DataLayerObject = _context.FindRoleByID(RoleID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new RoleBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }
        public List<RoleBLL> GetRoles(int skip, int take)
        {
            List<RoleBLL> ProposedReturnValue = new List<RoleBLL>();
            List<RoleDal> ListOfDataLayerObjects = _context.GetRoles(skip, take);
            foreach (RoleDal role in ListOfDataLayerObjects)
            {
                RoleBLL BusinessObject = new RoleBLL(role);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }
        public int ObtainRoleCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.ObtainRoleCount();
            return proposedReturnValue;
        }
        public int CreateRole(string Role)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.CreateRole(Role);
            return proposedReturnValue;
        }
        public int CreateRole(RoleBLL Role)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.CreateRole(Role.Role);
            return proposedReturnValue;
        }
        public void UpdateRole(int Role, string RoleID)
        {
            _context.UpdateRole(Role, RoleID);
        }
        public void UpdateRole(RoleBLL Role)
        {
            _context.UpdateRole(Role.RoleID, Role.Role);
        }
        public void DeleteRole(int RoleID)
        {
            _context.DeleteRole(RoleID);

        }
        public void DeleteRole(RoleBLL Role)
        {
            _context.DeleteRole(Role.RoleID);
        }
        //User
        public int CreateUser(int UserID, string Email, string Name, string password, string Hash, int roleID)
        {
            
            int proposedReturnValue = -1;
            proposedReturnValue = _context.CreateUser(UserID, Email, Name, password, Hash, roleID);

            return proposedReturnValue;
        }
        public int CreateUser(UserBLL user)
        {
          

            int proposedReturnValue = -1;
            proposedReturnValue = _context.CreateUser(user.UserID, user.EmailAdderess, user.Name, user.Password, user.Hash, user.RoleID);
            return proposedReturnValue;
        }
        public void updateUser
            (int UserID, string Email, string Name, string password, string Hash, int roleID)
        {
    
            _context.UpdateUser(UserID, Email, Name, password, Hash, roleID);
        }
        public void UpdateUser(UserBLL user)
        {
   

            _context.UpdateUser(user.UserID, user.EmailAdderess, user.Name, user.Password, user.Hash, user.RoleID);
        }
        public void DeleteUser(int UserID)
        {
            _context.DeleteUser(UserID);
        }
        public void DeleteUser(UserBLL User)
        {
            _context.DeleteUser(User.UserID);
        }
        public UserBLL FindUserByID(int UserID)
        {
            UserBLL ProposedReturnValue = null;
            UserDal DataLayerObject = _context.FindUserByID(UserID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new UserBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }
        public UserBLL FindUserByEmail(string Email)
        {
            UserBLL ProposedReturnValue = null;
            UserDal DataLayerObject = _context.FindUserByEmail(Email);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new UserBLL(DataLayerObject);
            }
            return ProposedReturnValue;

        }
        public List<UserBLL> GetUsers(int skip, int take)
        {
            List<UserBLL> ProposedReturnValue = new List<UserBLL>();
            List<UserDal> ListOfDataLayerObjects = _context.GetUsers(skip, take);
            foreach (UserDal User in ListOfDataLayerObjects)
            {
                UserBLL BusinessObject = new UserBLL(User);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }
        public int ObtainUserCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.ObtainUserCount();
            return proposedReturnValue;
        }
        //Product
        public int CreateProduct
            (int ProductID, int CategorieID, int SellerID, string Name, string Description, Decimal ReservePrice, int WinningOfferID, string Comments, string Photos,string Categories,string SellerEmail,string SellerName)
        {
           

            int proposedReturnValue = -1;
            proposedReturnValue = _context.CreateProduct
                (ProductID, CategorieID, SellerID, Name, Description, ReservePrice, WinningOfferID, Comments, Photos,Categories,SellerEmail,SellerName);
            return proposedReturnValue;
        }
        public int CreateProduct(ProductBLL product)
        {
           

            int proposedReturnValue = -1;
            proposedReturnValue = _context.CreateProduct
                (product.ProductsID, product.CategoryID, product.SellerID, product.Name, product.Descrption, product.ReservePrice, product.WinningofferID, product.Comments, product.Photos, product.Categories, product.SellerName, product.SellerName);
            return proposedReturnValue;
        }
        public void UpdateProduct(int ProductID, int CategorieID, int SellerID, string Name, string Description, Decimal ReservePrice, int WinningOfferID, string Comments, string Photos,string Categories,string SellerEmail,string sellerName)
        {
           
           _context.UpdateProduct(ProductID, CategorieID, SellerID, Name, Description, ReservePrice, WinningOfferID, Comments, Photos,Categories,SellerEmail,sellerName);
        }
        public void UpdateProduct(ProductBLL product)
        {
           

            _context.UpdateProduct(product.ProductsID, product.CategoryID, product.SellerID, product.Name, product.Descrption, product.ReservePrice, product.WinningofferID, product.Comments, product.Photos, product.Categories, product.SellerEmail, product.SellerName);
        }
        public void DeleteProduct(int ProductsID)
        {
            _context.DeleteProduct(ProductsID);
        }
        public void DeleteProduct(ProductBLL Product)
        {
            _context.DeleteProduct(Product.ProductsID);
        }
        public ProductBLL FindProductByID(int ProductID)
        {
            ProductBLL ProposedReturnValue = null;
            ProductDal DataLayerObject = _context.FindProductByID(ProductID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new ProductBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }
        public List<ProductBLL> GetProducts(int skip, int take)
        {
            List<ProductBLL> ProposedReturnValue = new List<ProductBLL>();
            List<ProductDal> ListOfDataLayerObjects = _context.GetProducts(skip, take);
            foreach (ProductDal product in ListOfDataLayerObjects)
            {
                ProductBLL BusinessObject = new ProductBLL(product);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }

        public int ObtainProductCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.ObtainProductCount();
            return proposedReturnValue;
        }
        //Offer

        public OfferBLL FindOfferByID(int OfferID)
        {
           OfferBLL ProposedReturnValue = null;
            OfferDal DataLayerObject = _context.FindOfferByID(OfferID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new OfferBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }
        public int CreateOffer
      (int OfferID, int ProductID, int BuyerID, decimal OfferPrice, int Offerstate, DateTime Expire, string Comments,string ProductName,string BuyerName,string EmailAdderess)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.CreateOffer
                    (ProductID, BuyerID, OfferPrice, Offerstate, Expire, Comments,ProductName,BuyerName);
            return proposedReturnValue;
        }
        public int CreateOffer(OfferBLL Offer)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.CreateOffer
                (Offer.ProductID, Offer.BuyerID, Offer.Offerprice, Offer.offerstate, Offer.ExpireDate, Offer.Comments,Offer.ProductName,Offer.BuyerName);
            return proposedReturnValue;
        }
        public void UpdateOfferID
                (int OfferID, int ProductID, int BuyerID, decimal OfferPrice, int Offerstate, DateTime Expire, string Comments,string ProductName,string BuyerName)
        {

            _context.UpdateOffer
                    (OfferID, ProductID, BuyerID, OfferPrice, Offerstate, Expire, Comments);
        }
        public void UpdateOffer(OfferBLL offer)
        {
            _context.UpdateOffer
                    (offer.offerID, offer.ProductID, offer.BuyerID, offer.Offerprice, offer.offerstate, offer.ExpireDate, offer.Comments);

        }
        public void DeleteOffer(int OfferID)
        {
            _context.DeleteOffer(OfferID);
        }
        public void DeleteOffer(OfferBLL offers)
        {
            _context.DeleteOffer(offers.offerID);
        }


        public List<OfferBLL> GetOffer(int skip, int take)
        {
            List<OfferBLL> ProposedReturnValue = new List<OfferBLL>();
            List<OfferDal> ListOfDataLayerObjects = _context.GetOffers(skip, take);
            foreach (OfferDal offer in ListOfDataLayerObjects)
            {
                OfferBLL BusinessObject = new OfferBLL(offer);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }
        public int ObtainOfferCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.ObtainOfferCount();
            return proposedReturnValue;
        }
        //Categorie
        public CategorieBLL FindCategorieByID(int categorieID)
        {
            CategorieBLL ProposedReturnValue = null;
            CategorieDal DataLayerObject = _context.FindCategorieByID(categorieID);
            if (null != DataLayerObject)
            {
                ProposedReturnValue = new CategorieBLL(DataLayerObject);
            }
            return ProposedReturnValue;
        }
        public int CreateCategories
            (int CategoriesID, string Categories)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.CreateCategorie
            (CategoriesID, Categories);

            return proposedReturnValue;
        }
        public int CreateCategories(CategorieBLL categorie)
        {
            int proposedReturnValue = -1;
            proposedReturnValue = _context.CreateCategorie(categorie.CategorieID, categorie.Categorie);
            return proposedReturnValue;
        }
        public void UpdateCategories(int CategoriesID, string Categories)
        {
            _context.UpdateCategori(CategoriesID, Categories);
        }
        public void UpdateCategories(CategorieBLL categorie)
        {
            _context.UpdateCategori(categorie.CategorieID, categorie.Categorie);
        }
        public void DeleteCategories(int categoriesID)
        {
            _context.DeleteCategorie(categoriesID);
        }
        public void DeleteCategirie(CategorieBLL categorie)
        {
            _context.DeleteCategorie(categorie.CategorieID);
        }


        public List<CategorieBLL> GetCategorie(int skip, int take)
        {
            List<CategorieBLL> ProposedReturnValue = new List<CategorieBLL>();
            List<CategorieDal> ListOfDataLayerObjects = _context.GetCategories(skip, take);
            foreach (CategorieDal categorie in ListOfDataLayerObjects)
            { CategorieBLL BusinessObject = new  CategorieBLL(categorie);
                ProposedReturnValue.Add(BusinessObject);
            }
            return ProposedReturnValue;
        }
        public int ObtainCategoriCount()
        {
            int proposedReturnValue = 0;
            proposedReturnValue = _context.ObtainCategorieCount();
            return proposedReturnValue;
        }
    }
}

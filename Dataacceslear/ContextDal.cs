using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace DataAccessLayer
{
    public class ContextDal : IDisposable
    {
        #region Context
        SqlConnection _connection = new SqlConnection();

        public void Dispose()
        {
            _connection = new SqlConnection();

        }
        public string ConnectionString
        {
            get { return _connection.ConnectionString; }
            set { _connection.ConnectionString = value; }
        }
        void EnsureConnected()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {

            }
            else if (_connection.State == System.Data.ConnectionState.Broken)
            {
                _connection.Close();
                _connection.Open();
            }
            else if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
            else
            {

            }
        }
        bool Log(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
        #endregion

        #region Role
        //ROLE
        public RoleDal FindRoleByID(int RoleID)
        {
            RoleDal ProposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindRoleByID", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        RoleMapper m = new RoleMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ProposedReturnValue = m.RoleFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"Found more than 1 Role with key{ RoleID}");
                        }
                    }

                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ProposedReturnValue;
        }
        public List<RoleDal> GetRoles(int skip, int take)
        {
            List<RoleDal> proposedReturnValue = new List<RoleDal>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetRoles", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        RoleMapper m = new RoleMapper(reader);
                        while (reader.Read())
                        {
                            RoleDal r = m.RoleFromReader(reader);
                            proposedReturnValue.Add(r);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int ObtainRoleCount()
        {
            int proposedreturnvalue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ObtainRoleCount", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedreturnvalue = (int)answer;
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedreturnvalue;
        }
        public int CreateRole(string Role)
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateRole", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Role", Role);
                    command.Parameters.AddWithValue("@RoleID", 0);
                    command.Parameters["@RoleID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    proposedReturnValue =
                        Convert.ToInt32(command.Parameters["@RoleID"].Value);
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;
        }

        public void UpdateRole(int RoleID, string Role)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UpdateRole", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Role", Role);
                    command.Parameters.AddWithValue("@RoleID", RoleID);

                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        public void DeleteRole(int RoleID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteRole", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@RoleID", RoleID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        #endregion
        #region User
        //User
        public UserDal FindUserByID(int UserID)
        {
            UserDal proposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command
                    = new SqlCommand("FindUserByID", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", UserID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper m = new UserMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            proposedReturnValue = m.UserFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new
                              Exception($"Found more than 1 User with key {UserID}");
                        }
                    }
                }

            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public UserDal FindUserByEmail(string Email)
        {
            UserDal proposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command
                    = new SqlCommand("FindUserByEmail", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", Email);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper m = new UserMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            proposedReturnValue = m.UserFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new
                    Exception($"Found more than 1 Email with key {Email}");
                        }

                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
            }
            return proposedReturnValue;
        }
        public List<UserDal> GetUsers(int skip, int take)
        {
            List<UserDal> proposedReturnValue = new List<UserDal>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetUsers", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper m = new UserMapper(reader);
                        while (reader.Read())
                        {
                            UserDal r = m.UserFromReader(reader);
                            proposedReturnValue.Add(r);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int ObtainUserCount()
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ObtainUserCount", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int CreateUser(int UserID, string Email, string Name, string Password, string Hash, int RoleID)
        {
            int ProposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateUser", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", 0);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Hash", Hash);
                    command.Parameters.AddWithValue("@RoleID", RoleID);

                    command.Parameters["@UserID"].Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    ProposedReturnValue = Convert.ToInt32(command.Parameters["@UserID"].Value);
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ProposedReturnValue;
        }
        public void UpdateUser(int UserID, string Email, string Name, string Password, string Hash, int RoleID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UpdateUser", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Hash", Hash);
                    command.Parameters.AddWithValue("@RoleID", RoleID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        public void DeleteUser(int UserID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteUser", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserID", UserID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        #endregion
        #region product
        //product
        public ProductDal FindProductByID(int ProductID)
        {
            ProductDal ProposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindProductByID", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@productID", ProductID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ProductMapper m = new ProductMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ProposedReturnValue = m.ProductFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"Found more than 1 User with key{ProductID}");
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {
            }
            return ProposedReturnValue;
        }
        public List<ProductDal> GetProducts(int skip, int take)
        {
            List<ProductDal> proposedReturnValue = new List<ProductDal>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetProducts", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ProductMapper m = new ProductMapper(reader);
                        while (reader.Read())
                        {
                            ProductDal r = m.ProductFromReader(reader);
                            proposedReturnValue.Add(r);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int ObtainProductCount()
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ObtainProductCount", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;

        }
        public int CreateProduct(int ProductID, int CategoryID, int SellerID, string Name, string Description, decimal ReservePrice, int WinningOfferID, string Comments, string Photos, string Categories, string SellerEmail, string sellerName)
        {
            int ProposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateProducts", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@SellerID", SellerID);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@ReservePrice", ReservePrice);
                    command.Parameters.AddWithValue("@WinningOfferID", WinningOfferID);
                    command.Parameters.AddWithValue("@Comments", Comments);
                    command.Parameters.AddWithValue("@Photos", Photos);
                    command.Parameters.AddWithValue("@ProductID", 0).
                    Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    ProposedReturnValue =
                        Convert.ToInt32(command.Parameters["@ProductID"].Value);
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ProposedReturnValue;
        }
        public void UpdateProduct(int ProductID, int CategoryID, int SellerID, string Name, string Description, decimal ReservePrice, int WinningOfferID, string Comments, string Photos, string Categories, string SellerEmail, string sellerName)
        {
            try
            {
                if (null == Photos)
                {
                    Photos = "";
                }
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UpdateProduct", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@SellerID", SellerID);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@ReservePrice", ReservePrice);
                    command.Parameters.AddWithValue("@WinningOfferID", WinningOfferID);
                    command.Parameters.AddWithValue("@Comments", Comments);
                    command.Parameters.AddWithValue("@Photos", Photos);


                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }

        }
        public void DeleteProduct(int ProductID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteProduct", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProductsID", ProductID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        #endregion
        #region Offer
        //Offer
        public OfferDal FindOfferByID(int OfferID)
        {
            OfferDal ProposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindOfferByID", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OfferID", OfferID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        OfferMapper m = new OfferMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ProposedReturnValue = m.OfferFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"Found more than 1 Offer with key{OfferID}");
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ProposedReturnValue;
        }
        public List<OfferDal> GetOffers(int skip, int take)
        {
            List<OfferDal> proposedReturnValue = new List<OfferDal>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetOffers", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        OfferMapper m = new OfferMapper(reader);
                        while (reader.Read())
                        {
                            OfferDal r = m.OfferFromReader(reader);
                            proposedReturnValue.Add(r);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int ObtainOfferCount()
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ObtainOfferCount", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;

        }
        public int CreateOffer(int ProductID, int buyerID, decimal Offerprice, int Offerstate, DateTime Expire, string Comments, string productName, string buyerName)
        {
            int ProposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateOffer", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@BuyerID", buyerID);
                    command.Parameters.AddWithValue("@Offerprice", Offerprice);
                    command.Parameters.AddWithValue("@Offerstate", Offerstate);
                    command.Parameters.AddWithValue("Expire", Expire);
                    command.Parameters.AddWithValue("@Comments", Comments);

                    command.Parameters.AddWithValue("@OfferID", 0).
                   Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    ProposedReturnValue =
                        Convert.ToInt32(command.Parameters["@OfferID"].Value);
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ProposedReturnValue;
        }
        public void UpdateOffer(int OfferID, int ProductID, int buyerID, decimal Offerprice, int Offerstate, DateTime Expire, string Comments)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UpdateOffer", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OfferID", OfferID);
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@BuyerID", buyerID);
                    command.Parameters.AddWithValue("@Offerprice", Offerprice);
                    command.Parameters.AddWithValue("@Offerstate", Offerstate);
                    command.Parameters.AddWithValue("Expire", Expire);
                    command.Parameters.AddWithValue("@Comments", Comments);
                    command.ExecuteNonQuery();


                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }

        }
        public void DeleteOffer(int OfferID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteOffer", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Offer", OfferID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }

        }
        #endregion
        #region categories
        //Categories
        public CategorieDal FindCategorieByID(int CategorieID)
        {
            CategorieDal ProposedReturnValue = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindCategoryByID", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", CategorieID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        CategorieMapper m = new CategorieMapper(reader);
                        int count = 0;
                        while (reader.Read())
                        {
                            ProposedReturnValue = m.CategorieFromReader(reader);
                            count++;
                        }
                        if (count > 1)
                        {
                            throw new Exception($"Found more than 1 User with key{CategorieID}");
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ProposedReturnValue;
        }
        public List<CategorieDal> GetCategories(int skip, int take)
        {
            List<CategorieDal> proposedReturnValue = new List<CategorieDal>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetCategories", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Skip", skip);
                    command.Parameters.AddWithValue("@Take", take);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        CategorieMapper m = new CategorieMapper(reader);
                        while (reader.Read())
                        {
                            CategorieDal r = m.CategorieFromReader(reader);
                            proposedReturnValue.Add(r);
                        }
                    }
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int ObtainCategorieCount()
        {
            int proposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("ObtainCategorieCount", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    object answer = command.ExecuteScalar();
                    proposedReturnValue = (int)answer;
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return proposedReturnValue;
        }
        public int CreateCategorie(int CategorieID, string Categorie)
        {
            int ProposedReturnValue = -1;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("createCategoris", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@categoris", Categorie); command.Parameters.AddWithValue("@CategorisID", 0)
                    .
                    Direction = System.Data.ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    ProposedReturnValue =
                        Convert.ToInt32(command.Parameters["@categorisID"].Value);
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
            return ProposedReturnValue;
        }
        public void UpdateCategori(int CategorieID, string Categorie)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("UpdateCategori", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategorisID", CategorieID);
                    command.Parameters.AddWithValue("@Categoris", Categorie);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }

        }
        public void DeleteCategorie(int CategorieID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteCategorie", _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CategoriesID", CategorieID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) when (Log(ex))
            {

            }
        }
        #endregion
    }


}

using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class UserBLL
    {
        public UserBLL()
        {
        }
        public UserBLL(UserDal dal)
        {
            this.UserID = dal.UserID;
            this.EmailAdderess = dal.EmailAdderess;
            this.Name = dal.Name;
            this.Password = dal.Password;
            this.Hash = dal.Hash;
            this.RoleID = dal.RoleID;
            this.Role = dal.Role;
        }
        #region Direct properties

        //[System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int UserID { get; set; }
        public string EmailAdderess { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Hash { get; set; }
        public int RoleID { get; set; }
        #endregion
        public string Role { get; set; }
        public override string ToString()
        {
            return $"User: UserID:{UserID,5} EmailAdderess:{EmailAdderess,25} Name: {Name,30}Password:{Password,10}Hash:{Hash}RoleID:{RoleID} Role:{Role}";
        }
        
    }
}

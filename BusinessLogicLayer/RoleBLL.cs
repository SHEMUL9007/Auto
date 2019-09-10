using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class RoleBLL
    {
        //[System.ComponentModel.DataAnnotations.Display(Name = "ONSHORE LOVER")]
        public int RoleID { get; set; }
        public string Role { get; set; }
        public RoleBLL()
        {

        }
        public RoleBLL(DataAccessLayer.RoleDal dal)
        {
            this.RoleID = dal.RoleID;
            this.Role = dal.Role;
        }
        public override string ToString()
        {
            return $"RoleID: {RoleID,5} RoleName:{Role}";
        }
    }
}

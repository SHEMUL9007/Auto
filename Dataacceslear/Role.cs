using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoleDal

    {
        public int RoleID { get; set; }
        public string Role { get; set; }
        public override string ToString()
        {
            return $"RoleID:{RoleID,5} Role:{Role,25}";
        }
    }
}

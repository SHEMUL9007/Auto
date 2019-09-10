using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoleMapper:Mapper
    {
        int OffsetToRoleID;
        int OffsetToRole;
        public RoleMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToRoleID = reader.GetOrdinal("RoleID");
            Assert(0 == OffsetToRoleID, "The RoleID is not 0 as expected");
            OffsetToRole = reader.GetOrdinal("Role");
            Assert(1 == OffsetToRole, "The RoleName is not 1 as expected");
        }
        public RoleDal RoleFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            RoleDal proposedReturnValue = new RoleDal();
            proposedReturnValue.RoleID = reader.GetInt32(OffsetToRoleID);
            proposedReturnValue.Role = reader.GetString(OffsetToRole); 
            return proposedReturnValue;
        }


    }
}

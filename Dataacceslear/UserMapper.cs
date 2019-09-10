using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserMapper:Mapper
    {
        int OffsetToUserID;  
        int OffsetToEmailAdderess;   
        int OffsetToName;
        int OffsetToPassword;
        int OffsetToHash;
        int OffsetToRoleID;
        int OffsetToRole;   

        public UserMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(0 == OffsetToUserID, $"UserID is {OffsetToUserID} not 0 as expected");
            OffsetToEmailAdderess = reader.GetOrdinal("EMailAdderess");
            Assert(1 == OffsetToEmailAdderess, $"EmailAdderess is {OffsetToEmailAdderess} not 1 as expected");
            OffsetToName = reader.GetOrdinal("Name");
            Assert(2 == OffsetToName, $"Name is {OffsetToName} not 2 as expected");
            OffsetToPassword = reader.GetOrdinal("Password");
            Assert(3 == OffsetToPassword, $"Passwoed is {OffsetToPassword} not 3 as expected");
            OffsetToHash = reader.GetOrdinal("Hash");
            Assert(4 == OffsetToHash, $"Hash is {OffsetToHash} not 4 as expected");
            OffsetToRoleID = reader.GetOrdinal("RoleID");
            Assert(5 == OffsetToRoleID, $"RoleID is {OffsetToRoleID} not 5 as expected");
            OffsetToRole = reader.GetOrdinal("Role");
            Assert(6 == OffsetToRole, $"Role is {OffsetToRole} not 6 as expected");

        }
        public UserDal UserFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            UserDal ProposedReturnValue = new UserDal();
            ProposedReturnValue.UserID = reader.GetInt32(OffsetToUserID);
            ProposedReturnValue.EmailAdderess = reader.GetString(OffsetToEmailAdderess);
            ProposedReturnValue.Hash = reader.GetString(OffsetToHash);
            ProposedReturnValue.Name = reader.GetString(OffsetToName);
            ProposedReturnValue.Password = reader.GetString(OffsetToPassword);
            ProposedReturnValue.RoleID = reader.GetInt32(OffsetToRoleID);
            ProposedReturnValue.Role = reader.GetString(OffsetToRole);
            return ProposedReturnValue;
        }
    }
}

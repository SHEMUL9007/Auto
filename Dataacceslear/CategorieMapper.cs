using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategorieMapper:Mapper
    {
        int OffsetToCategorieID;
        int OffsetToCategorie;
        public CategorieMapper(System.Data.SqlClient.SqlDataReader reader)
        {
            OffsetToCategorieID = reader.GetOrdinal("CategoriesID");
            Assert(0 == OffsetToCategorieID, "The CategoriesID is not 0 as expected");
            OffsetToCategorie = reader.GetOrdinal("Categories");
            Assert(1 == OffsetToCategorie, "The Categorie is not 1 as expected");
        }
        public CategorieDal CategorieFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            CategorieDal proposedReturnValue = new CategorieDal();
            proposedReturnValue.CategorieID = reader.GetInt32(OffsetToCategorieID);
            proposedReturnValue.Categorie = reader.GetString(OffsetToCategorie);
            return proposedReturnValue;
        }

    }
}

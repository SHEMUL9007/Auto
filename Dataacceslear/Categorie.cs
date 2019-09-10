using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
  public class CategorieDal
    {
        public int CategorieID { get; set; }
        public string Categorie { get; set; }
        public override string ToString()
        {
            return $"Categorie:CategoriesID:{CategorieID}Categories:{Categorie}";
        }
    }
}

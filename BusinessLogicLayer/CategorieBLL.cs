using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CategorieBLL
    {
        public CategorieBLL()
        {

        }
        public CategorieBLL(CategorieDal dal)
        {
            this.CategorieID = dal.CategorieID;
            this.Categorie = dal.Categorie;
        }
        public int CategorieID { get; set; }
        public string Categorie { get; set; }
        public override string ToString()
        {
            return $"Categorie:CategoriesID:{CategorieID}Categories:{Categorie}";
        }
    }
}

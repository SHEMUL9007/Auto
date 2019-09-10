using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoWebSite;
using BusinessLogicLayer;

namespace AutoWebSite.Controllers
{
    public class ProductcategitisController : Controller
    { 
       

        // GET: Productcategitis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productcategitis/Create
        [HttpPost]
        public ActionResult Create(ProductsCategoriesmolels collection)
        {
            try
            {
                using (ContextBll ctx = new ContextBll())
                {
                int catid=    ctx.CreateCategories(collection.CategoryID, collection.Categorie);
                    ctx.CreateProduct(collection.ProductsID, catid, collection.SellerID, collection.Name, collection.Descrption, collection.ReservePrice, collection.WinningofferID, collection.Comments, collection.Photos, collection.Categorie, "sellerName", "sellerName");

                }
                    // TODO: Add insert logic
                    return RedirectToAction("Index","Products");
            }
            catch(Exception EX)
            {
                return View();
            }
        }



        

        
            
        
    }
}

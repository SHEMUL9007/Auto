using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoWebSite.Models;
using BusinessLogicLayer;

namespace AutoWebSite.Controllers
{
    public class ProductsController : Controller
    {
        List<SelectListItem> GetCategorieItems()
        {
            List<SelectListItem> ProposedReturnValue = new List<SelectListItem>();
            using (ContextBll ctx = new ContextBll())
            {
                List<CategorieBLL> roles = ctx.GetCategorie(0, 25);
                foreach (CategorieBLL r in roles)
                {
                    SelectListItem i = new SelectListItem();

                    i.Value = r.CategorieID.ToString();
                    i.Text = r.Categorie;
                    ProposedReturnValue.Add(i);
                }
            }
            return ProposedReturnValue;
        }

       
            List<SelectListItem> GetSellerItems()
            {
                List<SelectListItem> ProposedReturnValue = new List<SelectListItem>();
                using (ContextBll ctx = new ContextBll())
                {
                    List<UserBLL> roles = ctx.GetUsers(0, 25);
                    foreach (UserBLL r in roles)
                    {
                        SelectListItem i = new SelectListItem();

                        i.Value = r.UserID.ToString();
                        i.Text = r.Name;
                        ProposedReturnValue.Add(i);
                    }
                }
                return ProposedReturnValue;
            }

            public ActionResult Page(int PageNumber, int PageSize)
            {

                ViewBag.PageNumber = PageNumber;
                ViewBag.PageSize = PageSize;
                List<ProductBLL> Model = new List<ProductBLL>();

                try
                {
                    using (ContextBll ctx = new ContextBll())
                    {
                        ViewBag.TotalCount = ctx.ObtainProductCount();
                        Model = ctx.GetProducts(PageNumber * PageSize, PageSize);
                    }
                    return View("Index", Model);
                }
                catch (Exception ex)
                {
                    ViewBag.Exception = ex;
                    return View("Error");
                }
            }
            // GET: Products
            public ActionResult Index()
        {
            return RedirectToRoute(new { Controller = "Products", Action = "Page", PageNumber = 0, PageSize = ApplicationConfig.DefaultPageSize });
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            ProductBLL product;
            try
            {
                using (ContextBll ctx = new ContextBll())
                {
                    product = ctx.FindProductByID(id);
                    if (null == product)
                    {
                        return View("ItemNotFound"); 
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ProductBLL defProduct = new ProductBLL();
            defProduct.ProductsID = 0;
            ViewBag.Products = GetCategorieItems();
            ViewBag.Products = GetSellerItems();
            return View(defProduct);
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(BusinessLogicLayer.ProductBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
             using(ContextBll ctx = new ContextBll())
                {
                    ctx.CreateProduct(collection);
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            ProductBLL Product;
            try
            {
                using (ContextBll ctx = new ContextBll())
                {
                    Product = ctx.FindProductByID(id);
                    if (null == Product)
                    {
                        return View("ItemNotFound"); 
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            ViewBag.Product = GetCategorieItems();
            return View(Product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BusinessLogicLayer.ProductBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBll ctx = new ContextBll())
                {
                    ctx.UpdateProduct(collection);
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
           ProductBLL product;
            try
            {
                using (ContextBll ctx = new ContextBll())
                {
                product = ctx.FindProductByID(id);
                    if (null == product)
                    {
                        return View("ItemNotFound"); 
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BusinessLogicLayer.ProductBLL collection)
        {
            try
            {
                using (ContextBll ctx = new ContextBll())
                {
                    ctx.DeleteProduct(id);
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }
        [HttpGet]
        public ActionResult Purchase(int id)
        {
            ProductBLL Product;
            try
            {
                using (ContextBll ctx = new ContextBll())
                {
                    Product = ctx.FindProductByID(id);
                    if (null == Product)
                    {
                        return View("ItemNotFound");
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
          
            return View(new PurchaseModel(Product));
        }
        [HttpPost]
        public ActionResult Purchase(PurchaseModel model)
        {
            
            try
            {
                BusinessLogicLayer.Meaningfulcalculation mc = new Meaningfulcalculation();
                model.Profit
                = mc.calculate_profit(model.OfferedPrice, model.ReservePrice);
                ModelState.Clear();
               
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }

            

            return View(model);
        }
    }
}

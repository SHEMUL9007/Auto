using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;

namespace AutoWebSite.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult Page(int PageNumber, int PageSize)
        {
            ViewBag.PageNumber = PageNumber;
            ViewBag.PageSize = PageSize;
            List<CategorieBLL> Model = new List<CategorieBLL>();
            try
            {
                using (ContextBll ctx = new ContextBll())
                {
                    ViewBag.TotalCount = ctx.ObtainCategoriCount();
                    Model = ctx.GetCategorie(PageNumber * PageSize, PageSize);
                }
                return View("Index", Model);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }

        }
        public ActionResult Index()
        {
            return RedirectToRoute(new { Controller = "Categories", Action = "Page", PageNumber = 0, PageSize = ApplicationConfig.DefaultPageSize });
        }
        public ActionResult Details(int id)
        {
            CategorieBLL categorie;
            try
            {
                using(ContextBll ctx =new ContextBll())
                {
                    categorie = ctx.FindCategorieByID(id);
                    if(null == categorie)
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
            return View(categorie);
        }


            // GET: Categories
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: Categories/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Categories/Create
        public ActionResult Create()
        {
            CategorieBLL defCategorie = new CategorieBLL();
            defCategorie.CategorieID = 0;
            return View(defCategorie);
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(BusinessLogicLayer.CategorieBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBll ctx = new ContextBll())
                {
                    ctx.CreateCategories(collection);
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            CategorieBLL categorie;
            try
            {
                using (ContextBll ctx = new ContextBll())
                {
                   categorie = ctx.FindCategorieByID(id);
                    if (null == categorie)
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
            return View(categorie);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BusinessLogicLayer.CategorieBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBll ctx = new ContextBll())
                {
                    ctx.UpdateCategories(collection);
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
           
            try
            {
                using (ContextBll ctx = new ContextBll())
                {
                   ctx.DeleteCategories(id);
                    
                }
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
            return RedirectToAction("Index");
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BusinessLogicLayer.CategorieBLL collection)
        {
            try
            {
                using (ContextBll ctx = new ContextBll())
                {
                    ctx.DeleteCategories(id);
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }
    }
}

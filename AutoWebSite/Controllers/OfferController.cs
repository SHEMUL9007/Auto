using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoWebSite.Controllers
{
  
    public class OfferController : Controller
    {
        public ActionResult Page(int PageNumber, int PageSize)
        {
            ViewBag.PageNumber = PageNumber;
            ViewBag.PageSize = PageSize;
            List<OfferBLL> Model = new List<OfferBLL>();
            try
            {
                using (ContextBll ctx = new ContextBll())
                {
                    ViewBag.TotalCount = ctx.ObtainRoleCount();
                    Model = ctx.GetOffer(PageNumber * PageSize, PageSize);
                }
                return View("Index", Model);
            }
            catch (Exception ex)
            {
                ViewBag.Exception = ex;
                return View("Error");
            }
        }
        List<SelectListItem> GetProductsItems()
        {
            List<SelectListItem> ProposedReturnValue = new List<SelectListItem>();
            using (ContextBll ctx = new ContextBll())
            {
                List<OfferBLL> roles = ctx.GetOffer(0, 25);
                foreach (OfferBLL r in roles)
                {
                    SelectListItem i = new SelectListItem();

                    i.Value = r.ProductID.ToString();
                    i.Text = r.ProductName;
                    ProposedReturnValue.Add(i);
                }
            }
            return ProposedReturnValue;
        }


        List<SelectListItem> GetBuyersItems()
        {
            List<SelectListItem> ProposedReturnValue = new List<SelectListItem>();
            using (ContextBll ctx = new ContextBll())
            {
                List<UserBLL> users = ctx.GetUsers(0, 25);
                foreach (UserBLL r in users)
                {
                    SelectListItem i = new SelectListItem();

                    i.Value = r.UserID.ToString();
                    i.Text = r.EmailAdderess;
                    ProposedReturnValue.Add(i);
                }
            }
            return ProposedReturnValue;
        }
        // GET: Offer
        public ActionResult Index()
        {
            return RedirectToRoute(new { Controller = "Offer", Action = "Page", PageNumber = 0, PageSize = ApplicationConfig.DefaultPageSize });
        }

        // GET: Offer/Details/5
        public ActionResult Details(int id)
        {
            OfferBLL Offer;
            try
            {
                using (ContextBll ctx = new ContextBll())
                {
                    Offer = ctx.FindOfferByID(id);
                    if (null == Offer)
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
            return View(Offer);
        }

        // GET: Offer/Create
        public ActionResult Create()
        {
            OfferBLL defOffer = new OfferBLL();
            defOffer.offerID = 0;
            ViewBag.Offer =GetProductsItems();
            ViewBag.Offer =GetBuyersItems();
            return View(defOffer);
        }

        // POST: Offer/Create
        [HttpPost]
        public ActionResult Create(BusinessLogicLayer.OfferBLL collection)
        {

            try
            {
                // TODO: Add insert logic here
                using (ContextBll ctx = new ContextBll())
                {
                    ctx.CreateOffer(collection);
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }

        // GET: Offer/Edit/5
        public ActionResult Edit(int id)
        {
            OfferBLL Offer;
            try
            {
                using (ContextBll ctx = new ContextBll())
                {
                  Offer = ctx.FindOfferByID(id);
                    if (null == Offer)
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
            ViewBag.Offer =GetProductsItems();
            ViewBag.Offer = GetBuyersItems();
            return View(Offer);
        }
    

        // POST: Offer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BusinessLogicLayer.OfferBLL collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBll ctx = new ContextBll())
                {
                    ctx.UpdateOffer(collection);
                }

                return RedirectToAction("Index");
            }
            catch (Exception Ex)
            {
                ViewBag.Exception = Ex;
                return View("Error");
            }
        }

        // GET: Offer/Delete/5
        public ActionResult Delete(int id)
        {
            OfferBLL Offer;
            try
            {
                using (ContextBll ctx = new ContextBll())
                {
                  Offer = ctx.FindOfferByID(id);
                    if (null ==Offer)
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
            return View(Offer);
        }

        // POST: Offer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BusinessLogicLayer.OfferBLL collection)
        {
            try
            {
                using (ContextBll ctx = new ContextBll())
                {
                    ctx.DeleteOffer(collection);
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoWebSite.Controllers
{
  
    public class HomeController : Controller
    {  public static string GetUntil(string text, string limiter = "@")
       {
        int charLocation = text.IndexOf(limiter, StringComparison.Ordinal);
        return text.Substring(0, charLocation);
       }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    
    [HttpGet]
    public ActionResult Logout()
    {
        Session.Remove("AUTHUsername");
        Session.Remove("AUTHRoles");
        return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult Login()
    {
            // displays empty login screen with predefined returnURL
            LoginModel m = new LoginModel();
        m.Message = TempData["Message"]?.ToString() ?? "";
        m.ReturnURL = TempData["ReturnURL"]?.ToString() ?? @"~/Home";
        m.EMail = "Email Address";
        m.Password = "genericpassword";

        return View(m);
    }

    [HttpPost]
    public ActionResult Login(LoginModel info)
    {
        using (BusinessLogicLayer.ContextBll ctx = new BusinessLogicLayer.ContextBll())
        {
                if (!ModelState.IsValid)
                {
                    return View(info);
                }
            BusinessLogicLayer.UserBLL user = ctx.FindUserByEmail(info.EMail);
            if (user == null)
            {
                info.Message = $"The Username '{info.EMail}' does not exist in the database";
                return View(info);
            }
            string actual = user.Password;
            //string potential = info.Password + user.Salt ;
            //bool validateduser = System.Web.Helpers.Crypto.VerifyHashedPassword(actual, potential);
            string potential = info.Password;
            string ValidationType = $"ClearText:({user.UserID})";
            bool validateduser = actual == potential;
            if (!validateduser)
            {
                
                potential =   user.Hash;
                                       
                validateduser = System.Web.Helpers.Crypto.VerifyHashedPassword( potential,actual);
                ValidationType = $"HASHED:({user.UserID})";
            }
            if (validateduser)
            {
                if (string.IsNullOrEmpty(info.ReturnURL))
                    {
                        info.ReturnURL = "~/products";
                    }
                Session["AUTHUsername"] = user.EmailAdderess;
                Session["AUTHRoles"] = user.Role;
                Session["AUTHTYPE"] = ValidationType;
                return Redirect(info.ReturnURL);
            }
            info.Message = "The password was incorrect";
            return View(info);
        }
    }

    public ActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Register(RegistrationModel info)
    {
        using (BusinessLogicLayer.ContextBll ctx = new BusinessLogicLayer.ContextBll())
        {
                if (!ModelState.IsValid)
                {
                    return View(info);
                }
                BusinessLogicLayer.UserBLL user = ctx.FindUserByEmail(info.EMail);
            if (user != null)
            {
                info.Message = $"The Email Address '{info.EMail}' already exists in the database";
                return View(info);
            }
            user = new BusinessLogicLayer.UserBLL();
            
            user.EmailAdderess = info.EMail;
                //user.Password = System.Web.Helpers.Crypto.
                //    GenerateSalt(Constants.SaltSize);
                user.Password = info.Password;
            user.Hash = System.Web.Helpers.Crypto.
                HashPassword(info.Password);
                                          // + user.Hash
            user.RoleID = 3;
            string GetUntil(string text, string limiter = "@")
                {
                    int charLocation = text.IndexOf(limiter, StringComparison.Ordinal);
                    return text.Substring(0, charLocation);
                }

                user.Name = GetUntil(info.EMail);// extract all letters befor @

            ctx.CreateUser(user);
            Session["AUTHUsername"] = (user.EmailAdderess);
            Session["AUTHRoles"] = user.Role;
            Session["AUTHTYPE"] = "HASHED";
            return RedirectToAction("Index");
        }
    }

    public ActionResult Hash()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return View("NotLoggedIn");

        }
        if (User.Identity.AuthenticationType.StartsWith("HASHED"))
        {
            return View("AlreadyHashed");
        }
        if (User.Identity.AuthenticationType.StartsWith("IMPERSONATED"))
        {
            return View("ActionNotAllowed");
        }
        using (BusinessLogicLayer.ContextBll ctx = new BusinessLogicLayer.ContextBll())
        {
            BusinessLogicLayer.UserBLL user = ctx.FindUserByEmail(User.Identity.Name);
            if (user == null)
            {
                Exception Message = new Exception($"The Username '{User.Identity.Name}' does not exist in the database");
                ViewBag.Exception = Message;
                return View("Error");
            }
            //user.Hash = System.Web.Helpers.Crypto.GenerateSalt(Constants.SaltSize);
            user.Hash = System.Web.Helpers.Crypto.HashPassword(user.Hash + user.Hash);
            ctx.UpdateUser(user);

            string ValidationType = $"HASHED:({user.UserID})";

                Session["AUTHUsername"] = user.EmailAdderess;
            Session["AUTHRoles"] = user.Role;
            Session["AUTHTYPE"] = ValidationType;

            return RedirectToAction("Index", "Home");
        }

    }


}
}
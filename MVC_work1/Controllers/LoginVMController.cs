using MVC_work1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_work1.Controllers
{
    [AllowAnonymous]
    public class LoginVMController : Controller
    {
        user_infoRepository uiRepo = RepositoryHelper.Getuser_infoRepository();

        // GET: LoginVM
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user_info ui)
        {
            if (ModelState.IsValid)
            {
                //RedirectToAction("Index", )

                FormsAuthentication.RedirectFromLoginPage(ui.username, false);
            }

            return View(ui);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "LoginVM");
        }
    }
}
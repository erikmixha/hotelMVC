using AdministratorPanel2018v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AdministratorPanel2018v3.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Login(Account model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (HotelDatabase2018Entities1 entities = new HotelDatabase2018Entities1())
                {
                    string username = model.Username;
                    string password = model.Password;

                    var x = (from acc in entities.Accounts
                             join emp in entities.Employees
                             on acc.AccountID equals emp.AccountID

                             where acc.Username == username
                             where acc.Password == password
                             where emp.Status=="Active"
                             select acc).ToList();
                    if (x.Count()!=0)
                    {
                        int accid = x.ElementAt(0).AccountID;

                        var e = (from emp in entities.Employees
                                 where emp.AccountID == accid

                                 select emp).ToList();


                        FormsAuthentication.SetAuthCookie(username, false);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            int? roleid = e.ElementAt(0).RoleID;

                            switch (roleid)
                            {
                                case 1:
                                    return RedirectToAction("Index", "Administrator");
                                    
                                case 2:
                                    return RedirectToAction("Index", "Manager");
                                case 3:
                                    return RedirectToAction("Index", "Reception");
                            }



                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    }
                }
            }

            return View(model);
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }




    }
}
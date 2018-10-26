using AdministratorPanel2018v3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace AdministratorPanel2018v3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

        }

        protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        string roles = string.Empty;

                        using (HotelDatabase2018Entities1 entities = new HotelDatabase2018Entities1())
                        {
                            Account user = entities.Accounts.SingleOrDefault(u => u.Username == username);

                            var emp = (from u in entities.Employees
                                       where u.AccountID == user.AccountID
                                       select u).ToList();

                            int? roleid = emp.ElementAt(0).RoleID;

                            var role = (from r in entities.Roles
                                        where r.RoleID == roleid
                                        select r).ToList();

                            roles = role.ElementAt(0).Description;
                        }
                        
                        e.User = new System.Security.Principal.GenericPrincipal(
                          new System.Security.Principal.GenericIdentity(username, "Forms"), roles.Split(';'));
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        string roles = string.Empty;

                        using (HotelDatabase2018Entities1 entities = new HotelDatabase2018Entities1())
                        {
                            Account user = entities.Accounts.SingleOrDefault(u => u.Username == username);

                            var emp = (from u in entities.Employees
                                       where u.AccountID == user.AccountID
                                       select u).ToList();

                            int? roleid = emp.ElementAt(0).RoleID;

                            var role = (from r in entities.Roles
                                        where r.RoleID == roleid
                                        select r).ToList();

                            roles = role.ElementAt(0).Description;
                        }


                        HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(
                          new System.Security.Principal.GenericIdentity(username, "Forms"), roles.Split(';'));
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }




    }
}

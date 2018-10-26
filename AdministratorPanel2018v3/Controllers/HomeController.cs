using AdministratorPanel2018v3.Models;
using AdministratorPanel2018v3.Models.New_Clases;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdministratorPanel2018v3.Controllers
{
    public class HomeController : Controller
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index()
        {
            logger.Debug("Debug message");
            logger.Warn("Warn message");
            logger.Error("Error message");
            logger.Fatal("Fatal message");
            return View();
        }



    }
}
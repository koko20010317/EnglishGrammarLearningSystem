using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EnglishGrammarLearningSystem.Controllers
{
    [Authorize]
    public class PretestController : Controller
    {
        public static string dbPath = AppDomain.CurrentDomain.BaseDirectory + @"Content\DB.xlsx";

        public ActionResult PreTest() 
        {

            return View();
        }


    }
}
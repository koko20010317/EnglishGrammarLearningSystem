using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace EnglishGrammarLearningSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public static string dbPath = AppDomain.CurrentDomain.BaseDirectory + @"Content\DB.xlsx";
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!string.IsNullOrEmpty(filterContext.HttpContext.User.Identity.Name))
            {
                using (var wb = new XLWorkbook(dbPath))
                {
                    bool pretestDone = false;

                    for (int i = 2; i <= 101; i++)
                    {
                        string r_userID = wb.Worksheet("Record_pretest").Cell(i, 2).Value.ToString();
                        if (r_userID == filterContext.HttpContext.User.Identity.Name)
                        {                            
                            pretestDone = true;
                            break;
                        }
                    }

                    for (int i = 2; i <= 101; i++)
                    {
                        if (wb.Worksheet("User").Cell(i, 1).Value.ToString() == filterContext.HttpContext.User.Identity.Name) 
                        {
                            ViewBag.UserName = wb.Worksheet("User").Cell(i, 2).Value.ToString();
                            break;
                        }
                    }

                    if (pretestDone)
                    {
                        
                    }
                    else
                    {
                        //return RedirectToAction("PreTest", "Home");
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "PreTest", action = "PreTest" }));
                    }
                }
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PreTest()
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
    }
}
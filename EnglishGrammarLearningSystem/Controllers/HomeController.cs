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
    public class HomeController : Controller
    {
        public static string dbPath = AppDomain.CurrentDomain.BaseDirectory + @"Content\DB.xlsx";
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            int currentUserID = 0;
            string userName = "UNKNOWN";
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


                    // 
                    if (pretestDone)
                    {
                        //return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        //return RedirectToAction("PreTest", "Home");
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "PreTest", action = "PreTest" }));
                        // filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "PreTest", "Home" } });
                    }
                }
                //currentUserID = 0;
                //if (int.TryParse(filterContext.HttpContext.User.Identity.Name, out currentUserID))
                //{
                //    using (ProjectTrackingSystemDBContext db = new ProjectTrackingSystemDBContext())
                //    {
                //        var currentUserData = ProjectTrackingSystemDBContext.GetAvailableUserData(db, currentUserID);
                //        if (currentUserData != null)
                //        {
                //            userName = currentUserData.Login_User_ID;

                //            var superUsers = Service.CommonService.superUserList;
                //        }
                //    }
                //}
            }
            //ViewBag.CurrentUserName = userName;

            //if (HttpContext.Request.Browser.Browser.ToLower() != "Chrome".ToLower() && HttpContext.Request.Browser.Browser.ToLower() != "Firefox".ToLower())
            //{
            //    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "Controller", "Error" }, { "Action", "BrowserNS" } });
            //}
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
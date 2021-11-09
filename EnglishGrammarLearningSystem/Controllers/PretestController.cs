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

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            using (var wb = new XLWorkbook(dbPath))
            {
                for (int i = 2; i <= 101; i++)
                {
                    if (wb.Worksheet("User").Cell(i, 1).Value.ToString() == filterContext.HttpContext.User.Identity.Name)
                    {
                        ViewBag.UserName = wb.Worksheet("User").Cell(i, 2).Value.ToString();
                        break;
                    }
                }
            }

        }

        public ActionResult PreTest()
        {
            string userID = ViewBag.user;
            var qList = new List<Models.PretestViewModels>();

            // 隨機取十題
            List<int> listNumbers = new List<int>();
            int number;
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                do
                {
                    number = rand.Next(1, 30);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }

            // read 題庫
            using (var wb = new XLWorkbook(dbPath))
            {
                int index = 1;
                foreach (int id in listNumbers.OrderBy(p => p).ToList())
                {
                    qList.Add(new Models.PretestViewModels
                    {
                        QLID = id,
                        QID = index,
                        Question = wb.Worksheet("PreTest").Cell(id + 1, 2).Value.ToString(),
                        Options = wb.Worksheet("PreTest").Cell(id + 1, 3).Value.ToString(),
                        UserID = userID
                    });
                    index++;
                }
            }
            return View(qList);
        }

        [HttpPost]
        public ActionResult PreTestSubmit(List<Models.PretestViewModels> data)
        {
            var qList = new List<Models.PretestViewModels>();

            using (var wb = new XLWorkbook(dbPath))
            {

            }

            return PartialView("_PretestPartial", qList);
        }


    }
}
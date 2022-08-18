using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasonProjectASPNETMVC5.Controllers
{
    public class ValidationController : Controller
    {
        Models.Repository.ITestTableRepository MyTestDB = new Models.Repository.TestTableRepository();


        // GET: Validation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListAllData_Valid()
        {
            IQueryable<Models.TestTable> allData = MyTestDB.ListAllData();
            if (allData == null)
            {
                return HttpNotFound();
            }

            return View(allData);
        }

        public ActionResult CreateData_Valid()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateData_Valid(Models.TestTable testTable)
        {
            if ((testTable != null) && (ModelState.IsValid))
            {
                MyTestDB.AddData(testTable);
                return RedirectToAction("ListAllData");
            }
            else
            {
                ModelState.AddModelError("Error1", " 錯誤訊息1");
                ModelState.AddModelError("Error2", " 錯誤訊息2 ");
                return View();
            }
        }


    }
}
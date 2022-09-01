using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasonProjectASPNETMVC5.Controllers
{
    public class ControlItemController : Controller
    {
        private Models.MyTestDB2Context _db = new Models.MyTestDB2Context();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }

        // GET: ControlItem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create2()
        {
            return View();
        }
        public ActionResult Create3()
        {
            var dt = _db.DepartmentTables;
            SelectList ListItems = new SelectList(dt, "DepartmentID", "DepartmentName");

            ViewBag.DPListItem = ListItems;
            return View();
        }

        public ActionResult Create4()
        {

        }
    }
}
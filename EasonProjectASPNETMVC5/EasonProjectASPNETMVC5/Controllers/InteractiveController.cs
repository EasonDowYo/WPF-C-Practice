using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasonProjectASPNETMVC5.Controllers
{
    public class InteractiveController : Controller
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

        // GET: Interactive
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create1()
        {
            var a = _db.DepartmentTables;
            SelectList listItem = new SelectList(a, "DepartmentID", "DepartmentName");
            ViewBag.DepartmentList = listItem;
            return View();

        }

        [HttpPost]
        public ActionResult GetStudentList(string id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (!string.IsNullOrWhiteSpace(id))
            {
                int i = Convert.ToInt32(id);
                IQueryable<Models.StudentTable> result = _db.StudentTables.Where(u => u.DepartmentID == i);

                foreach (var a in result)
                {
                    sb.AppendFormat("<option value\"{0}>{1}</option>",a.DepartmentID.ToString(),a.StudentName);
                }


            }

            return Content(sb.ToString());


        }
        public ActionResult Create2()
        {
            var a = _db.DepartmentTables;
            SelectList listItem = new SelectList(a, "DepartmentID", "DepartmentName");
            ViewBag.DepartmentList = listItem;
            return View();
        }
        [HttpPost]
        public ActionResult GetStudentList2(string id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("<select id=\"{0}\" name=\"{1}\">", "StudentID", "StudentID");
            if (!string.IsNullOrWhiteSpace(id))
            {
                int i = Convert.ToInt32(id);
                IQueryable<Models.StudentTable> result = _db.StudentTables.Where(u => u.DepartmentID == i);

                foreach (var a in result)
                {
                    sb.AppendFormat("<option value\"{0}>{1}</option>", a.DepartmentID.ToString(), a.StudentName);
                }


            }
            sb.Append("</select>");
            return Content(sb.ToString());


        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasonProjectASPNETMVC5.Controllers
{
    public class MultiDBTableController : Controller
    {
        private Models.MyTestDB2Context _db = new Models.MyTestDB2Context();
        protected override void Dispose(bool disposing)
        {

            _db.Dispose();
            base.Dispose(disposing);
        }

        // GET: MultiDBTable
        public ActionResult Index()
        {
            
            return View(_db.StudentTables);
        }

        public ActionResult GetDepartmentStudent( int id=1)
        {
            return View(_db.DepartmentTables.Where(s => s.DepartmentID == id).Single());
        }

        public ActionResult GetDepartmentStudent5()
        {
            var result = from d in _db.DepartmentTables
                         join u in _db.StudentTables 
                         on d.DepartmentID equals u.DepartmentID  // 兩個資料表的連結(JOIN)
                         orderby d.DepartmentID
                         select new Models.DepartmentStudentViewModel { DepartmentViewModel= d, StudentViewModel = u };

            return View(result.ToList());
        }
        public ActionResult ListDepartmentStudentJOIN(int id=2)
        {
            var result = from d in _db.DepartmentTables
                         join u in _db.StudentTables
                         on d.DepartmentID equals u.DepartmentID into dt2 // 兩個資料表的連結(JOIN)
                         from u in dt2.DefaultIfEmpty()
                         orderby d.DepartmentID
                         select new Models.DepartmentStudentViewModel { DepartmentViewModel = d, StudentViewModel = u };

            return View(result.ToList());
        }
        public ActionResult ListDepartmentStudent2()
        {
            List<Models.DepartmentStudent2ViewModel> dsvm = new List<Models.DepartmentStudent2ViewModel>();

            foreach(var dt in _db.DepartmentTables)
            {
                List<Models.StudentTable> st = new List<Models.StudentTable>();
                foreach(var ss in _db.StudentTables.Where(item => item.DepartmentID == dt.DepartmentID))
                {
                    st.Add(ss);
                }
                dsvm.Add(new Models.DepartmentStudent2ViewModel { SDTbl = st, DPTbl = dt });

            }
            return View(dsvm.ToList());
        }
        public ActionResult ListDepartmentStudent3()
        {
            Models.DepartmentStudent3ViewModel dsvm = new Models.DepartmentStudent3ViewModel
            {
                DPTbl3 = _db.DepartmentTables.ToList(),
                SDTbl3 = _db.StudentTables.ToList()
            };

            
            return View(dsvm);
        }
    }
}
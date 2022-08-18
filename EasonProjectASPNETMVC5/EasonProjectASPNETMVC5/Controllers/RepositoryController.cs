using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasonProjectASPNETMVC5.Controllers
{
    public class RepositoryController : Controller
    {
        // GET: Repository
        Models.Repository.ITestTableRepository MyTestDB = new Models.Repository.TestTableRepository();
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        MyTestDB.DB_Dispose();
        //    }
        //    base.Dispose(disposing);
        //}



        public ActionResult Index()
        {
            return View();
        }
    }
}
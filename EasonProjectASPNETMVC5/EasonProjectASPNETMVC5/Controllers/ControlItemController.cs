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
            var dt = _db.DepartmentTables.ToList();   // 這一列改成 ADO.NET程式，就能到資料庫撈取您要的數據，
            // 例如 https://www.c-sharpcorner.com/article/dropdownlist-in-asp-net-mvc/
            //  http://so79.blogspot.tw/2014/03/mvc-dropdownlist.html

            List<SelectListItem> listItems = new List<SelectListItem>();
            // SelectListItem與SelectList的用法 https://dotblogs.com.tw/brooke/2016/06/21/164605

            foreach (var d in dt)
            {
                listItems.Add(new SelectListItem()
                {
                    Text = d.DepartmentName,    // 寫 <option>子選項的 Text & Value
                    Value = d.DepartmentID.ToString(),
                    Selected = false   // 是否被選取（預設值）？
                });
            }

            Models.DropDownListViewModel Vmodel = new Models.DropDownListViewModel()
            {   // 搭配ViewModel，放在 /ModelsDropDownList目錄底下 DDLViewModel.cs
                DDL_List = listItems
            };

            return View(Vmodel);
        }


        public ActionResult Create6()
        {
            return View();
        }
    }
}
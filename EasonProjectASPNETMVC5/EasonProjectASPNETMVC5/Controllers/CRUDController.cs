using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasonProjectASPNETMVC5.Controllers
{
    public class CRUDController : Controller
    {
        private Models.MyTestDBContext _db = new Models.MyTestDBContext();


        // GET: CRUD
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ListAllData()
        {
            IQueryable<Models.TestTable> DataList = from _uu in _db.TestTables
                                                    select _uu;
            if (DataList == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(DataList.ToList());
            }

        }

        [HttpGet]
        public ActionResult OneDataDetails(int? _ID=1)
        {
            if (_ID == null || _ID.HasValue == false)
            {   //// 沒有輸入文章編號（_ID），就會報錯 - Bad Request
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            IQueryable<Models.TestTable> DataList = from _uu in _db.TestTables
                                                    where _uu.ID == _ID
                                                    select _uu;

            IQueryable<Models.TestTable> test = _db.TestTables.Where(x => x.ID == _ID);
            Models.TestTable test2= _db.TestTables.FirstOrDefault(b => b.ID == _ID);
            Models.TestTable ut = _db.TestTables.Find(_ID);

            if (DataList == null)
            {    // 找不到這一筆記錄
                return HttpNotFound();
            }
            else
            {
                return View(DataList.FirstOrDefault());

            }
        }

        public ActionResult CreateData()
        {
            return View();
        }

        [HttpPost, ActionName("CreateData")]   // 把下面的動作名稱，改成 CreateConfirm 試試看？
        [ValidateAntiForgeryToken]   // 避免CSRF攻擊
        public ActionResult CreateResult(Models.TestTable _TestTable)
        {
            if ((_TestTable != null) && (ModelState.IsValid))
            {   
                _db.TestTables.Add(_TestTable);
                _db.SaveChanges();
                return RedirectToAction("ListAllData");
            }
            else
            {   
                ModelState.AddModelError("Error1", " 錯誤訊息1");   
                ModelState.AddModelError("Error2", " 錯誤訊息2 ");
                return View();   
            }
        }

        public ActionResult DeleteData(int? _ID)
        {
            if (_ID == null)
            {   
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Models.TestTable tt = _db.TestTables.Find(_ID);
            if (tt == null)
            {   
                return HttpNotFound();
            }
            else
            {
                return View(tt);
            }

        }
        [HttpPost, ActionName("DeleteData")]
        [ValidateAntiForgeryToken]   //  https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/implementing-basic-crud-functionality-with-the-entity-framework-in-asp-net-mvc-application#overpost
        //  http://stephenwalther.com/archive/2009/01/21/asp-net-mvc-tip-46-ndash-donrsquot-use-delete-links-because
        //  https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/examining-the-details-and-delete-methods
        public ActionResult DeleteConfirm(int _ID)
        {
            if (ModelState.IsValid)
            {
                Models.TestTable tt = _db.TestTables.Find(_ID);
                _db.TestTables.Remove(tt);
                _db.SaveChanges();

                return RedirectToAction("ListAllData");
            }
            else
            {   
                ModelState.AddModelError("Error1", " 錯誤訊息1");
                ModelState.AddModelError("Error2", " 錯誤訊息2 ");
                return View();
            }
        }
        public ActionResult EditData(int? _ID)
        {
            if (_ID == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Models.TestTable tt = _db.TestTables.Find(_ID);
            if (tt == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tt);
            }

        }
        [HttpPost, ActionName("EditData")]
        [ValidateAntiForgeryToken]   
        // [Bind(Include=.......)] 也可以寫在 Model的類別檔裡面，就不用重複地寫在新增、刪除、修改每個動作之中。需搭配 System.Web.Mvc命名空間。
        // 可以避免 overposting attacks （過多發佈）攻擊  http://www.cnblogs.com/Erik_Xu/p/5497501.html
        // 參考資料 http://blog.kkbruce.net/2011/10/aspnet-mvc-model-binding6.html
        public ActionResult EditCheck([Bind(Include = "ID,SerialNumber,rDateTime,Station,Value1,Value2,Result")]  Models.TestTable testTable)
        {   // 參考資料 http://blog.kkbruce.net/2011/10/aspnet-mvc-model-binding6.html
            if (testTable == null)
            {   
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)   
            {    
                _db.Entry(testTable).State = System.Data.Entity.EntityState.Modified;  //確認被修改（狀態：Modified）
                _db.SaveChanges();

                //// 第二種寫法：========================================= (start)
                #region
                //// 使用上方 Details動作的程式，先列出這一筆的內容，給使用者確認
                //UserTable ut = _db.UserTables.Find(_userTable.UserId);                

                //if (ut == null)
                //{   // 找不到這一筆記錄
                //    return HttpNotFound();
                //}
                //else   {
                //    ut.UserName = _userTable.UserName;  // 修改後的值
                //    ut.UserSex = _userTable.UserSex;
                //    ut.UserBirthDay = _userTable.UserBirthDay;
                //    ut.UserMobilePhone = _userTable.UserMobilePhone;

                //    _db.SaveChanges();   // 回寫資料庫（進行修改）
                //}
                //// 第二種寫法：========================================= (end)
                #endregion

                //return Content(" 更新一筆記錄，成功！");    // 更新成功後，出現訊息（字串）。
                return RedirectToAction("ListAllData");
            }
            else
            {
                return View(testTable);  // 若沒有修改成功，則列出原本畫面
                //return Content(" *** 更新失敗！！*** "); 
            }
        }

        public ActionResult SearchData(string searchStr)
        {
            
            ViewData["SW"] = searchStr;

            
            //第二種寫法：  
            IQueryable<Models.TestTable> ListAll = from _userTable in _db.TestTables
                                            select _userTable;

            if (!String.IsNullOrEmpty(searchStr) && ModelState.IsValid)
            {
                return View(ListAll.Where(s => s.Station.Contains(searchStr)));
                // 討論串  https://stackoverflow.com/questions/29824798/need-help-understanding-linq-in-mvc/29825045#29825045
                // 原廠文件（中文） https://docs.microsoft.com/zh-tw/dotnet/framework/data/adonet/ef/language-reference/method-based-query-syntax-examples-filtering
            }
            else
            {   // 找不到任何記錄（請參閱最下方的 override HandleUnknowAction()）
                return HttpNotFound();
            }
            

        }

        public ActionResult Search_MultiCondition()
        {
            return View();   //產生一個搜尋畫面。類似「新增 Create」的畫面。  可以輸入多個搜尋條件。
        }


        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Search_MultiCondition(Models.TestTable _testTable)
        {   
            string sn = _testTable.SerialNumber;   
            string station = _testTable.Station;   
            var ListAll = _db.TestTables.Select(s => s);

            if (!string.IsNullOrWhiteSpace(sn))  
            {
                ListAll = ListAll.Where(s => s.SerialNumber.Contains(sn));
            }

            if (!string.IsNullOrWhiteSpace(station))
            {
                ListAll = ListAll.Where(s => s.Station.Contains(station));
            }
            
            if ((_testTable != null) && (ModelState.IsValid))
            {
                return View("Search_MultiCondition_Result", ListAll);
            }
            else
            {   
                return HttpNotFound();
            }
        }
        protected override void Dispose(bool disposing)
        {//此為釋放資料庫資源的用途
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasonProjectASPNETMVC5.Controllers
{
    public class FirstController : Controller
    {
        // GET: First
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyAction1()
        {
            return View();
        }
        public ActionResult AssignAction()
        {
            return View("AssignedView");
        }
        public ActionResult AssignAction2()
        {
            return View("~/Views/First/AssignedView.cshtml");
        }
        public string OnlyReturnString()
        {
            return "OnlyReturnString";
        }
        public ActionResult ReturnContent()
        {
            return Content("ReturnContent");
        }
        
        //protected override void HandleUnknownAction(string actionName)
        //{
        //    Response.Redirect("https://www.google.com.tw/");
        //    base.HandleUnknownAction(actionName);
        //}

    }
}
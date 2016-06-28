using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VDC.Helpers;

namespace VDC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult ValidCode()
        {
            string validateCode = CodeHelper.CreateRandomCode(4);
            Session["ValidateCode"] = validateCode;
            var img = CodeHelper.CreateImage(validateCode);

            return File(img.ToArray(), "image/jpeg");
        }

        [HttpPost]
        public ActionResult ValidUserInputCode(string code)
        {
            if (Session["ValidateCode"] == null)
            {
                return Json(new { result = false }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = Session["ValidateCode"].ToString().ToLower() == code.ToLower() }, JsonRequestBehavior.AllowGet);
        }
    }
}
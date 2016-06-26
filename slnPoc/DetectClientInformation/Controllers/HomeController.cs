namespace DetectClientInformation.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Propertis = GetRequestInfo();
            return this.View();
        }

        public Dictionary<string, string> GetRequestInfo()
        {
            var dics = new Dictionary<string, string>();

            foreach (var item in this.Request.GetType().GetProperties())
            {
                if (item != null)
                {
                    var value = this.Request.GetType().GetProperty(item.Name).GetValue(this.Request).ToString();
                    dics.Add(item.Name, value);
                }

            }

            return dics;
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}
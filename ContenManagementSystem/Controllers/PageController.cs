using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContenManagementSystem.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            ViewData["innerHtml"] = "<div id =\"div1\">" +
                "<div class='container'><div class='row'><div class='col-md-6'><p>Hello</p></div><div class='col-md-6'><p>Test</p></div></div></div></div>";
            return View("DynamicPage");
        }

        //https://stackoverflow.com/questions/20333021/asp-net-mvc-how-to-pass-data-from-view-to-controller/20333227
        public ActionResult PageManager()
        {
            return View("DynamicPageManager");
        }
    }
}
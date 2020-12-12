using ContenManagementSystem.Constants;
using ContenManagementSystem.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContenManagementSystem.Controllers
{
    //[Authorize]
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            string pageId = Convert.ToString(Url.RequestContext.RouteData.Values["id"]);
            if (pageId != "")
            {
                ViewData["innerHtml"] = getDataByPageID(pageId);
            }
            else
            {
                ViewData["innerHtml"] = "";
            }
            return View("DynamicPage");
        }

        public ActionResult PageManager()
        {
            return View("DynamicPageManager");
        }

        public ActionResult PageCreator()
        {
            return View("PageCreator");
        }

        [HttpPost]
        public ActionResult savePageSettings(PageManagerView pageManagerView)
        {
            string s = markupCreator(pageManagerView);

            var doc = new HtmlDocument();
            doc.LoadHtml(s);
            var htmlBody = doc.DocumentNode.SelectSingleNode("//div[1]");
            HtmlNode selectedNode = htmlBody.SelectSingleNode("//div[" + pageManagerView.SectionId + "]/div[" + pageManagerView.DivisionId + "]");
            selectedNode.AppendChild(HtmlNode.CreateNode("<p>"+pageManagerView.Sectiontext+"</p>"));
            ViewData["innerHtml"] = "<div id =\"div1\"><div class='container'>" + htmlBody.OuterHtml + "</div></div>";
            ApplicationDbContext context = new ApplicationDbContext();
            var page = context.Pages.Where(p => p.PageId == "test").FirstOrDefault();
            if(page!= null)
            {
                page.PageHTML = Convert.ToString(ViewData["innerHtml"]);
                context.SaveChanges();
            }
            //context.Pages.Add(new Page() {PageId = "test", PageHTML = Convert.ToString(ViewData["innerHtml"]) });
            //context.SaveChangesAsync();
            //ViewData["innerHTML"] = getDataByPageID("test");
            //return View("DynamicPage",ViewData);
            return RedirectToAction("Index", "Page", new { id ="test"});
        }

        private string getDataByPageID(string pageId)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            return context.Pages.Where(p => p.PageId == pageId).Select(p => p.PageHTML).FirstOrDefault();
        }

        private string markupCreator(PageManagerView pageManagerView)
        {            
            string s = "<div class='container'><div class='row'>";
            for (int i = 0; i < Convert.ToInt32(pageManagerView.NumberOfDivisions); i++)
            {
                s += PageConstants.cols[Convert.ToInt32(pageManagerView.NumberOfDivisions)];
            }
            s += "</div></div>";
            return s;
        }

        [HttpPost]
        public JsonResult temp(Tester model)
        {
            Console.WriteLine(model.pageName);
            string s = "<div class='container'>";
            for (int i = 0; i < Convert.ToInt32(model.numberOfSections); i++)
            {
                s += PageConstants.rows + i;
                for (int j = 0; j < Convert.ToInt32(model.numberOfDivisions); j++)
                {
                    s += PageConstants.cols[Convert.ToInt32(model.numberOfDivisions)];
                }
                s += "</div>";
            }
            s += "</div>";
            //return s;

            return Json(new { result = "Success" });
        }

    }

    public class Tester
    {
        public string pageName { get; set; }
        public string numberOfSections { get; set; }
        public string sectionNumber { get; set; }
        public string numberOfDivisions { get; set; }
        public string divisionNumber { get; set; }
        public string divisionType { get; set; }
    }
}
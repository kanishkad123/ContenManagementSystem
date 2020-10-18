using ContenManagementSystem.Models;
using HtmlAgilityPack;
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

        public ActionResult PageManager()
        {
            return View("DynamicPageManager");
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
            return View("DynamicPage",ViewData);
        }

        private string markupCreator(PageManagerView pageManagerView)
        {
            Dictionary<int,string> cols = new Dictionary<int, string>();
            cols.Add(1,"<div class='col-md-12'></div>");
            cols.Add(2,"<div class='col-md-6'></div>");
            cols.Add(3,"<div class='col-md-4'></div>");
            cols.Add(4,"<div class='col-md-3'></div>");
            cols.Add(6,"<div class='col-md-2'></div>");
            cols.Add(12,"<div class='col-md-1'></div>");
            string s = "<div class='container'><div class='row'>";
            for (int i = 0; i < Convert.ToInt32(pageManagerView.NumberOfDivisions); i++)
            {
                s += cols[Convert.ToInt32(pageManagerView.NumberOfDivisions)];
            }
            s += "</div></div>";
            return s;
        }
    }
}
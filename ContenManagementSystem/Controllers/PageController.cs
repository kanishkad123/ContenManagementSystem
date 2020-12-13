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
            PageManagerView pv = new PageManagerView();
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                //var pages = dbContext.PageStructures.Select(p => new SelectListItem {Value=p.pageName,Text=p.pageName });
                //pv.pages = new SelectList(pages, "Value", "Text");
                return View("DynamicPageManager");
            }
        }
        [Authorize(Roles= "Admin")]
        public ActionResult PageCreator()
        {
            return View("PageCreator");
        }

        [HttpPost]
        public ActionResult savePageSettings(PageManagerView pageManagerView)
        {
            //string s = markupCreator(pageManagerView);

            var doc = new HtmlDocument();
            //doc.LoadHtml(s);
            var htmlBody = doc.DocumentNode.SelectSingleNode("//div[1]");
            //HtmlNode selectedNode = htmlBody.SelectSingleNode("//div[" + pageManagerView.SectionId + "]/div[" + pageManagerView.DivisionId + "]");
            //selectedNode.AppendChild(HtmlNode.CreateNode("<p>"+pageManagerView.Sectiontext+"</p>"));
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

        //private string markupCreator(PageManagerView pageManagerView)
        //{            
        //    string s = "<div class='container'><div class='row'>";
        //    for (int i = 0; i < Convert.ToInt32(pageManagerView.NumberOfDivisions); i++)
        //    {
        //        s += PageConstants.cols[Convert.ToInt32(pageManagerView.NumberOfDivisions)];
        //    }
        //    s += "</div></div>";
        //    return s;
        //}

        [HttpPost]
        public JsonResult temp(Tester model)
        {
            string s = "<div class='container'>";
            for (int i = 0; i < model.sections.Count; i++)
            {
                s += PageConstants.rows;
                for (int j = 0; j < model.sections[i].divs.Count; j++)
                {
                    s += PageConstants.cols[model.sections[i].divs.Count];
                }
                s += "</div>";
            }
            s += "</div>";

            var doc = new HtmlDocument();
            doc.LoadHtml(s);
            var htmlBody = doc.DocumentNode.SelectSingleNode("//div[1]");
            for (int i = 0; i < model.sections.Count; i++)
            {
                for (int j = 0; j < model.sections[i].divs.Count; j++)
                {
                    int xpath_i = i + 1;
                    int xpath_j = j + 1;
                    HtmlNode selectedNode = doc.DocumentNode.SelectSingleNode("//div[1]/div[" + xpath_i + "]/div[" + xpath_j + "]");
                    switch (model.sections[i].divs[j].divtype)
                    {
                        case "text/html":
                            selectedNode.AppendChild(HtmlNode.CreateNode("<p>" + model.sections[i].divs[j].divData + "</p>"));
                            break;
                        case "image":
                            selectedNode.AppendChild(HtmlNode.CreateNode("<img src='" + model.sections[i].divs[j].divData + "'/>"));
                            break;
                        default:
                            break;
                    }
                    
                }
            }
            string htmlFinal = "<div id =\"div1\"><div class='container'>" + htmlBody.OuterHtml + "</div></div>";

            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                dbContext.Pages.Add(new Page { PageId = model.pageName, PageHTML = htmlFinal });
                dbContext.SaveChanges();
                //dbContext.PageStructures.Add(new PageStructure
                //{
                //    pageName = model.pageName,
                //    numberOfSections = item.sectionNumber,
                //    numberOfDivisions = item.divisions
                //});
                //dbContext.SaveChanges();
            }
            return Json(new { result = "Success" });
        }

        //[HttpPost]
        //public JsonResult pageSections(string pageName)
        //{
        //    string pageSec = "";
        //    using (ApplicationDbContext dbContext = new ApplicationDbContext())
        //    {
        //        pageSec = dbContext.PageStructures.Where(p => p.pageName == pageName)
        //            .OrderBy(p=>p.numberOfSections+" "+ "descending").FirstOrDefault().numberOfSections;
        //    }
        //    return Json(new { sections = pageSec });
        //}

        //[HttpPost]
        //public JsonResult pageDivisions(string pageSectionNumber)
        //{
        //    string div = "";
        //    using (ApplicationDbContext dbContext = new ApplicationDbContext())
        //    {
        //        div = dbContext.PageStructures.Where(p => p.pageName == pageSectionNumber.Split('&')[0] && p.numberOfSections == pageSectionNumber.Split('&')[1])
        //            .FirstOrDefault().numberOfDivisions;
        //    }
        //    return Json(new { divisions = div });
        //}

    }

    public class Tester
    {
        public string pageName { get; set; }
        public List<tem> sections { get; set; }
    }

    public class tem
    {
        public string sectionNumber { get; set; }
        public List<tt> divs { get; set; }
    }

    public class tt
    {
        public string divnumber { get; set; }
        public string divtype { get; set; }
        public string divData { get; set; }
    }
}
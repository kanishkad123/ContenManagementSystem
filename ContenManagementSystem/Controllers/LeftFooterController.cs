using ContenManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContenManagementSystem.Controllers

{
    public class LeftFooterController : Controller
    {
        // GET: LeftFooter
        public ActionResult Index()
        {
            LeftFooterModel lfm = new LeftFooterModel();
            lfm.para1 = "test123";
            lfm.videourl = new Uri("youtube.com");
            ViewBag.para1 = lfm.para1;

            return View();
        }

    }
}
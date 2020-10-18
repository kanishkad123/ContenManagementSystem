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
            lfm.para1 = "Cloud computing is the on-demand availability of computer system resources, especially data storage and computing power, without direct active management by the user. The term is generally used to describe data centers available to many users over the Internet.";
            lfm.videourl = "youtube.com";
            lfm.noofLikes = 6;
            lfm.videoDescription = "Technical Webinar: Developing .NET MVC Websites with Kentico Cloud*";
            ViewBag.videodescription = lfm.videoDescription;
            ViewBag.para1 = lfm.para1;
            ViewBag.nooflikes = lfm.noofLikes;

            return View("LeftFooterView");
        }

    }
}
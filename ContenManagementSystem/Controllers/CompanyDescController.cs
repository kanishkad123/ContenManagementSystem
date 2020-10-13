using ContenManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContenManagementSystem.Controllers
{
    public class CompanyDescController : Controller
    {
        // GET: CompanyDesc
        [ActionName("View")]
        public ActionResult Index()
        {
            CompanyDescClass company = new CompanyDescClass();
            company.pullData();

            return View(company);
        }


    }
}
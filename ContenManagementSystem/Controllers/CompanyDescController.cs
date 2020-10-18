using ContenManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ContenManagementSystem.Controllers
{
    public class CompanyDescController : Controller
    {
        CompanyDescClass company = new CompanyDescClass();
        Boolean initialized = false;

        // GET: CompanyDesc
        //[ActionName("View")]
        public ActionResult Index()
        {
            if (!initialized) {
                company.pullData(); 
                initialized = true;
            }
            return View("View", company);
        }

        [HttpGet]
        public ActionResult Edit(CompanyDescClass company)
        {
            System.Diagnostics.Debug.WriteLine(company.Address);
            return View("View", company);
        }


        public ActionResult ReView(CompanyDescClass company)
        {
            return View("View", company);
        }


    }
}
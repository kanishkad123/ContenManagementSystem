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
        CompanyDescClass company = new CompanyDescClass();
        Boolean initialized = false;

        // GET: CompanyDesc
        [ActionName("View")]
        public ActionResult Index()
        {
            if (!initialized) {
                company.pullData(); 
                initialized = true;
            } 



            return View(company);
        }

        public ActionResult Edit(CompanyDescClass company)
        {
            this.company = company;
            return View(company);
        }


    }
}
using ContenManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;

namespace ContenManagementSystem.Controllers
{
    public class MainPageController : Controller
    {
        // GET: MainPage
        ViewModel viewModel = new ViewModel() ;
        Boolean initialized = false;
        public ActionResult Index()
        {
            if (!initialized)
            {
                viewModel.company.pullData();
                initialized = true;
            }

            return View("Main", viewModel);
        }
    }
}
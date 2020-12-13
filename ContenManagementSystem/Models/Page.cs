using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContenManagementSystem.Models
{
    public class Page
    {
        public string PageId { get; set; }
        public string PageHTML { get; set; }
    }
    public class PageStructure
    {
        public string pageName { get; set; }
        public string numberOfSections { get; set; }
        public string numberOfDivisions { get; set; }
    }
    public class PageManagerView
    {
        public IEnumerable<SelectListItem> pages { get; set; }
        public List<string> sections { get; set; }
        public List<string> divisions { get; set; }

        //public string PageId { get; set; }
        //public string SectionId { get; set; }
        //public string NumberOfDivisions { get; set; }
        //public string DivisionId { get; set; }
        //public string Sectiontext { get; set; }
    }
    public class PageSettings
    {
        public string pageName { get; set; }
        public List<SetionSettings> sections { get; set; }
    }

    public class SetionSettings
    {
        public string sectionNumber { get; set; }
        public List<DivisionSettings> divs { get; set; }
    }

    public class DivisionSettings
    {
        public string divnumber { get; set; }
        public string divtype { get; set; }
        public string divData { get; set; }
    }
}
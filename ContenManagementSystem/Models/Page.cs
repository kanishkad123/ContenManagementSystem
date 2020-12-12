﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.Models
{
    public class Page
    {
        public string PageId { get; set; }
        public string PageHTML { get; set; }
    }

    public class PageManagerView
    {
        public string PageId { get; set; }
        public string SectionId { get; set; }
        public string NumberOfDivisions { get; set; }
        public string DivisionId { get; set; }
        public string Sectiontext { get; set; }
    }
}
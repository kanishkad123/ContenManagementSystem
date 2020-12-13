﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.Models
{
    public class feedBackPage
    {
        [Key]
        public int Id { get; set; }
        public string senderEmailAddress { get; set; }
        public string feedBack { get; set; }
        public int rating { get; set; }

        public int subject { get; set; }
    }
}
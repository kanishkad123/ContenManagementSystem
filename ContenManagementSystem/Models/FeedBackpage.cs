using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.Models
{
    public class FeedBackpage
    {
        [Key]
        public int Id { get; set; }
        public string senderEmailAddress { get; set; }
        public string feedBack { get; set; }
        public int rating { get; set; }
    }
}
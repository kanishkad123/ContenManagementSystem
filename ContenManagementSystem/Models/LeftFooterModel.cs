using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace ContenManagementSystem.Models
{
    public class LeftFooterModel
    {   
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public String para1 { get; set; }
        public String para2 { get; set; }

        public String videourl { get; set; }

        public int noofLikes { get; set; }
        public String videoDescription { get; set; }


    }
}
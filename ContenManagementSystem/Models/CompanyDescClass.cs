using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.Models
{
    public class CompanyDescClass
    {

        public int CompanyDescClassID { get; set; }
        public string ShortDesc { get; set; } = "";
        public string Address { get; set; } = "";
        public string Website { get; set; } = "";

        public string Telephone { get; set; } = ""; //maybe long


        public Dictionary<string,string> OpenningHours { get; set; } = new Dictionary<string, string>(); //maybe datatime?  //maybe just a list?

        public Dictionary<string, string> ClosingHours { get; set; } = new Dictionary<string, string>();

        public List<Employee> Employees { get; set; } = new List<Employee>();

        

        public void pullData()
        {
            //Later will be recieving parameters and pulling from database
            //For now it generates dummy data

            ShortDesc = "State of the art scamming company, with long proven history of facilitating businesses perferct the art of fraud, our mission is not to only deciet but to do it with style, we religiously practice what we preach on Juhanna.";
            Address = "0 trace street, Toronto";
            Website = "example@wordpress.com";
            Telephone = "(915) 6263-2312";

            OpenningHours.Add("Monday","0800");
            OpenningHours.Add("Tuesday", "0800");
            OpenningHours.Add("Wednesday", "0800");
            OpenningHours.Add("Thursday", "0800");
            OpenningHours.Add("Friday", "0800");
            OpenningHours.Add("Saturday", "0800");
            OpenningHours.Add("Sunday", "1000");

            ClosingHours.Add("Monday", "1700");
            ClosingHours.Add("Tuesday", "1700");
            ClosingHours.Add("Wednesday", "1700");
            ClosingHours.Add("Thursday", "1700");
            ClosingHours.Add("Friday", "1700");
            ClosingHours.Add("Saturday", "1500");
            ClosingHours.Add("Sunday", "1500");

            Employees.Add(new Employee() { pictureID = "../images/1.jpg", empName = "Arnold", position = "Big Boss" });
            Employees.Add(new Employee() { pictureID = "../images/2.jpg", empName = "Maggie", position = "Cleaner" });
            Employees.Add(new Employee() { pictureID = "../images/3.jpg", empName = "Niko", position = "Conflict Resolution" });
            Employees.Add(new Employee() { pictureID = "../images/4.jpg", empName = "Borat", position = "Human resauces" });
            Employees.Add(new Employee() { pictureID = "../images/5.jpg", empName = "Johanna", position = "Junior Developer" });


        }
    }

    
}
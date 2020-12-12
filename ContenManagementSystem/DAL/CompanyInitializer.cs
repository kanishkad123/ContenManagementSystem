using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ContenManagementSystem.Models;



namespace ContenManagementSystem.DAL
{
    public class CompanyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CompanyContext>
    {


        protected override void Seed(CompanyContext context)
        {

            var CompanyDescClasses = new List<CompanyDescClass>
            {

            new CompanyDescClass{
                ShortDesc = "State of the art scamming company, with long proven history of facilitating businesses perferct the art of fraud, our mission is not to only deciet but to do it with style, we religiously practice what we preach on Juhanna.",
                Address = "0 trace street, Toronto",
                Website = "example@wordpress.com",
                Telephone = "(915) 6263-2312",
                OpenHours= new CompanyOpenHours()
                {
                    mondayOpen="0800",mondayClose="1700",
                    tuesdayOpen="0800",tuesdayClose="1700",
                    wednesdayOpen="0800",wednesdayClose="1700",
                    thursdayOpen="0700", thursdayClose="1700",
                    fridayOpen="0800",fridayClose="1700",
                    saturdayOpen="1000",saturdayClose="1400",
                    sundayOpen="1000",sundayClose="1400"

                },
                   Employees= new List<CompanyEmployee>()
                    {
                        new CompanyEmployee() { pictureID = "../images/1.jpg", empName = "Arnold", position = "Big Boss" } ,
                        new CompanyEmployee() { pictureID = "../images/2.jpg", empName = "Maggie", position = "Cleaner" },
                        new CompanyEmployee() { pictureID = "../images/3.jpg", empName = "Niko", position = "Conflict Resolution" },
                        new CompanyEmployee() { pictureID = "../images/4.jpg", empName = "Borat", position = "Human resauces" },
                        new CompanyEmployee() { pictureID = "../images/5.jpg", empName = "Johanna", position = "Junior Developer" }
                    }
                },

              new CompanyDescClass{
                ShortDesc = "We are the Good food, Good life company. We believe in the power of food to enhance lives. Good food nourishes and delights the senses. It helps children grow healthy, pets thrive, parents age gracefully and everyone live life to the fullest.",
                Address = "99 no way, Toronto",
                Website = "example@nestle.com",
                Telephone = "(900) 6688-2448",
                OpenHours= new CompanyOpenHours()
                {
                    mondayOpen="0800",mondayClose="1700",
                    tuesdayOpen="0800",tuesdayClose="1700",
                    wednesdayOpen="0800",wednesdayClose="1700",
                    thursdayOpen="0700", thursdayClose="1700",
                    fridayOpen="0800",fridayClose="1700",
                    saturdayOpen="1000",saturdayClose="1400",
                    sundayOpen="1000",sundayClose="1400"

                },
                   Employees= new List<CompanyEmployee>()
                    {
                        new CompanyEmployee() { pictureID = "../images/3.jpg", empName = "Seb", position = "CEO" } ,
                        new CompanyEmployee() { pictureID = "../images/1.jpg", empName = "Dan", position = "HR" },
                        new CompanyEmployee() { pictureID = "../images/4.jpg", empName = "Rob", position = "PR" },
                        new CompanyEmployee() { pictureID = "../images/5.jpg", empName = "Fat", position = "IT" },
                        new CompanyEmployee() { pictureID = "../images/2.jpg", empName = "Pat", position = "OK" }
                    }
                }

            };

            CompanyDescClasses.ForEach(s => {
                context.CompanyDescClasses.Add(s);
                context.OpenHours.Add(s.OpenHours);
                foreach (CompanyEmployee employee in s.Employees)
                {
                    context.Employees.Add(employee);
                }

            });
            context.SaveChanges();
        }
    }
}
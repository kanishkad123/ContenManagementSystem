using ContenManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.DAL
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var pages = new List<Page>
            {
                new Page{PageId="home",PageHTML="<div>hello</div>"}
            };
            pages.ForEach(pg => context.Pages.Add(pg));
            context.SaveChanges();
        }
    }
}
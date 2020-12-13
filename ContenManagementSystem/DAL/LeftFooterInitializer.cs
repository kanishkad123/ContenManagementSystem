using ContenManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.DAL
{
    public class LeftFooterInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LeftFooterContext>
    {
        protected override void Seed(LeftFooterContext context)
        {
            context.leftFooterModel.Add(new LeftFooterModel(1, "Hi i am suvvansh", "there is a way", "youtube.com", 6, "yes thats youtube"));
            context.feedBackPages.Add(new feedBackPage(1, "suvaanshkumar@gmail.com", "very good", 9, "About feedback"));
            context.SaveChanges();
        }
    }
}